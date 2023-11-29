using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NvidiaStreamPatch
{
	public partial class Form1 : Form
	{
		//
		//	Driverfiler som skal patches, x64 og x86.
		//
		private static string[] TargetFiles = {
			"C:\\WINDOWS\\system32\\nvencodeapi64.dll",
			"C:\\WINDOWS\\SysWOW64\\nvencodeapi.dll"
		};
		
		//
		//	Søkemønstre til patcheområde. Oppdatert 5.9.23 til å scanne etter adresser selv.
		//	Testet OK på daværende driver men bør testes mer. Adresser søkes etter og bekreftes av bruker før patching.
		//
		private static byte[][] SearchPatterns = { // 0x90 = wildcard.
			new byte[] { 0x48, 0x8B, 0x53, 0x08, 0x48, 0x8B, 0xCD, 0x90, 0x90, 0x90, 0x90, 0x90, 0x8B, 0xF0, 0x85, 0xC0, 0x75, 0x05, 0x49, 0x89, 0x2F },
			new byte[] { 0xFF, 0x75, 0xF0, 0xFF, 0x76, 0x08, 0x90, 0x90, 0x90, 0x90, 0x90, 0x89, 0x45, 0x08, 0x85, 0xC0, 0x8B, 0x45, 0x0C } 
		};

		//
		//	Adresser.
		//
		private long[] TargetAddresses = { 0x0, 0x0 };

		//
        // Tilhørende bytes for skriving.
		// Også SelectedIndex-basert.
        //
		private static byte[][] WriteBytes = {
			new byte[] { 0x33, 0xC0, 0x8B, 0xF0 }, 
			new byte[] { 0x33, 0xC0, 0x89, 0x45, 0x08 } 
		};

		//
		// Tilhørende orginale bytes.
		//
		private static byte[][] SearchBytes = {
			new byte[] { 0x8B, 0xF0, 0x85, 0xC0 },
			new byte[] { 0x89, 0x45, 0x08, 0x85, 0xC0 } 
		};

		// Lesebuffer for sjekk av orginale bytes.
		private static byte[][] CheckBytes = { 
			new byte[] { 0x00, 0x00, 0x00, 0x00 },
			new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }
		};

		// Klargjør vinduet.
		public Form1()
		{
			InitializeComponent();
			lnkMoreDetails.Select();
		}
		
		// Knapptrykk.
		private void btnPatch_Click(object sender, EventArgs e)
		{
			// Hent adresser som skal patches.
			for (int a=0; a<TargetAddresses.Count(); a++) {
				TargetAddresses[a] = FindBytePattern(a);
				if (TargetAddresses[a] == -1) {
					MessageBox.Show("Can't find patch address for "+ TargetFiles[a] +".\n\nExiting.");
					Application.Exit();
				}

				// Korriger adresse til faktisk patchområde.
				for (int b=0; b<SearchPatterns[a].Count(); b++) {
					bool Found = true;
					for (int c=0; c<SearchBytes[a].Count(); c++) {
						if (SearchBytes[a][c] != SearchPatterns[a][b+c]) {
							Found = false;
							break;
						}
					}
					if (Found) {
						TargetAddresses[a] += b;
						TargetAddresses[a] += 0xC00;
						break;
					}
				}
			}

			// Debugging.
			if (MessageBox.Show(
					"Patch address for "+ TargetFiles[0] +" is 0x"+ TargetAddresses[0].ToString("X") +"\n"+
					"Patch address for "+ TargetFiles[1] +" is 0x"+ TargetAddresses[1].ToString("X") +"\n"+
					"\nContinue?", "Scan OK", MessageBoxButtons.YesNo
			) == DialogResult.Yes)
				PatchIt();
		}

		// Patchefunksjon.
		private void PatchIt()
		{
			try {

			// Deaktiver knapp mens vi utfører endringer.
			btnPatch10.Enabled = false;
			btnPatch10.Text = "Wait..";

			// Håndter alle filer.
			for (int a=0; a<TargetFiles.Count(); a++) {
			
				// Opprett en sikkerhetskopi.
				File.Copy(TargetFiles[a], TargetFiles[a] + ".backup", true);

				// Les forventede bytes på forventet sted.
				using (Stream fs = File.Open(TargetFiles[a], FileMode.Open)) {
					fs.Position = TargetAddresses[a] - 0xC00;
					fs.Read(CheckBytes[a], 0, CheckBytes[a].Length);
				}
			
				// Bekreft at de finnes der vi forventer det.
				if (BitConverter.ToString(CheckBytes[a]) != BitConverter.ToString(SearchBytes[a])) {
					MessageBox.Show("Target bytes for "+ TargetFiles[a] +" outdated, already patched or not valid.\n\nExiting.");
					Application.Exit();
				}
			
				// Skriv bytes.
				using (Stream fs = File.Open(TargetFiles[a], FileMode.Open)) {
					fs.Position = TargetAddresses[a] - 0xC00;
					fs.Write(WriteBytes[a], 0, WriteBytes[a].Length);
				}
			}

			// Antar alt gikk greit.
			btnPatch10.Text = "OK";
			btnPatch10.Enabled = false;
			
			MessageBox.Show(
				"Files successfully patched.\n\n"+
				"Backups placed in same folder.", 
				"Patched!", 
				MessageBoxButtons.OK, 
				MessageBoxIcon.Information
			);

			// Håndter feil.
			} catch (Exception ee) {
				MessageBox.Show("ERROR: "+ ee.Message +", "+ ee.Source);
			}
		}

		//
		//	Hjelpefunksjon for gjennomsøk av bytes.
		//
		private int FindBytePattern(int target)
		{
			bool Found = false;
			byte[] FileBytes = File.ReadAllBytes(TargetFiles[target]);
			
			// Loop gjennom alle bytes i fila.
			for (int i=0; i<FileBytes.Length-SearchPatterns[target].Length; i++) {
				
				// Utgangspunkt i funn, må overleve sammenligninger.
				Found = true;

				// Loop gjennom lengden på søkemønster.
				for (int j=0; j<SearchPatterns[target].Length; j++) {

					// Sjekk om [i + j] fremover er lik søkemønster.
					if (SearchPatterns[target][j] != FileBytes[i + j] && SearchPatterns[target][j] != 0x90) {
						Found = false;
						break;
					}
				}

				// Returner offset i FileBytes hvis mønster ble funnet.
				if (Found) 
					return i;
			}

			return -1;
		}

		// Link til mer info om hva vi faktisk gjør.
		private void lnkMoreDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/keylase/nvidia-patch/tree/master/win");
		}
    }
}

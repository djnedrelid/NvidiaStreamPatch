namespace NvidiaStreamPatch
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.btnPatch10 = new System.Windows.Forms.Button();
			this.lnkMoreDetails = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.White;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox1.Location = new System.Drawing.Point(12, 39);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(209, 58);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.TabStop = false;
			this.richTextBox1.Text = "This patch attempts to remove restriction on maximum number of simultaneous NVENC" +
    " video encoding sessions imposed by Nvidia to consumer-grade GPUs.";
			// 
			// btnPatch10
			// 
			this.btnPatch10.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnPatch10.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnPatch10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
			this.btnPatch10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.btnPatch10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPatch10.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPatch10.Location = new System.Drawing.Point(77, 116);
			this.btnPatch10.Name = "btnPatch10";
			this.btnPatch10.Size = new System.Drawing.Size(66, 35);
			this.btnPatch10.TabIndex = 2;
			this.btnPatch10.Text = "PATCH";
			this.btnPatch10.UseVisualStyleBackColor = true;
			this.btnPatch10.Click += new System.EventHandler(this.btnPatch_Click);
			// 
			// lnkMoreDetails
			// 
			this.lnkMoreDetails.AutoSize = true;
			this.lnkMoreDetails.Location = new System.Drawing.Point(79, 100);
			this.lnkMoreDetails.Name = "lnkMoreDetails";
			this.lnkMoreDetails.Size = new System.Drawing.Size(64, 13);
			this.lnkMoreDetails.TabIndex = 3;
			this.lnkMoreDetails.TabStop = true;
			this.lnkMoreDetails.Text = "More details";
			this.lnkMoreDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMoreDetails_LinkClicked);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.LightGray;
			this.label1.Location = new System.Drawing.Point(104, 174);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "ժʝ_";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(193, 28);
			this.label2.TabIndex = 5;
			this.label2.Text = "Standalone Patch Tool";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(225, 190);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lnkMoreDetails);
			this.Controls.Add(this.btnPatch10);
			this.Controls.Add(this.richTextBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "NvidiaStreamPatch 64-bit";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button btnPatch10;
		private System.Windows.Forms.LinkLabel lnkMoreDetails;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
    }
}


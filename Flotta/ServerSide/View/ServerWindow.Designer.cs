namespace Flotta.ServerSide.View
{
	partial class ServerWindow
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
			this.label1 = new System.Windows.Forms.Label();
			this.clientCountLbl = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.logConsole = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Client connessi:";
			// 
			// clientCountLbl
			// 
			this.clientCountLbl.AutoSize = true;
			this.clientCountLbl.Location = new System.Drawing.Point(96, 17);
			this.clientCountLbl.Name = "clientCountLbl";
			this.clientCountLbl.Size = new System.Drawing.Size(13, 13);
			this.clientCountLbl.TabIndex = 1;
			this.clientCountLbl.Text = "0";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(182, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(90, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Nuovo Client";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.NewClient);
			// 
			// logConsole
			// 
			this.logConsole.ReadOnly = true;
			this.logConsole.Location = new System.Drawing.Point(12, 41);
			this.logConsole.Name = "logConsole";
			this.logConsole.Size = new System.Drawing.Size(260, 208);
			this.logConsole.TabIndex = 3;
			this.logConsole.Text = "";
			// 
			// ServerWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.logConsole);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.clientCountLbl);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ServerWindow";
			this.Text = "Server – Flotta";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label clientCountLbl;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox logConsole;
	}
}
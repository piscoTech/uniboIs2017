namespace Flotta.ClientSide.Interface
{
	partial class UpdateTesseraDialog
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pin = new System.Windows.Forms.TextBox();
			this.codice = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(198, 93);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Salva";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnSave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "PIN";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Codice";
			// 
			// pin
			// 
			this.pin.Location = new System.Drawing.Point(15, 64);
			this.pin.Name = "pin";
			this.pin.Size = new System.Drawing.Size(258, 20);
			this.pin.TabIndex = 2;
			// 
			// codice
			// 
			this.codice.Location = new System.Drawing.Point(15, 25);
			this.codice.Name = "codice";
			this.codice.Size = new System.Drawing.Size(258, 20);
			this.codice.TabIndex = 1;
			// 
			// UpdateTesseraDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 125);
			this.Controls.Add(this.codice);
			this.Controls.Add(this.pin);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "UpdateTesseraDialog";
			this.Text = "Modifica – Tessera – Flotta";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox pin;
		private System.Windows.Forms.TextBox codice;
	}
}
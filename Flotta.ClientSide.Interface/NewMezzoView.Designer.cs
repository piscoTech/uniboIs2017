namespace Flotta.ClientSide.Interface
{
	partial class NewMezzoView
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
			this.tabViewGenerale = new TabGeneraleView();
			this.SuspendLayout();
			// 
			// tabViewGenerale
			// 
			this.tabViewGenerale.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabViewGenerale.Location = new System.Drawing.Point(0, 0);
			this.tabViewGenerale.Modello = "";
			this.tabViewGenerale.Name = "tabViewGenerale";
			this.tabViewGenerale.Size = new System.Drawing.Size(344, 461);
			this.tabViewGenerale.TabIndex = 0;
			this.tabViewGenerale.Targa = "";
			// 
			// NewMezzoInterface
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 461);
			this.Controls.Add(this.tabViewGenerale);
			this.MinimumSize = new System.Drawing.Size(360, 500);
			this.Name = "NewMezzoInterface";
			this.Text = "Nuovo mezzo – Flotta";
			this.ResumeLayout(false);

		}

		#endregion

		private TabGeneraleView tabViewGenerale;
	}
}
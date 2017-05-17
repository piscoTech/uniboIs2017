namespace Flotta.ClientSide.Interface
{
	partial class NewMezzoDialog
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
			this.tabGeneraleView = new TabGeneraleView();
			this.SuspendLayout();
			// 
			// tabGeneraleView
			// 
			this.tabGeneraleView.Altezza = 0F;
			this.tabGeneraleView.AnnoImmatricolazione = ((uint)(0u));
			this.tabGeneraleView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGeneraleView.Location = new System.Drawing.Point(0, 0);
			this.tabGeneraleView.Lunghezza = 0F;
			this.tabGeneraleView.Modello = "";
			this.tabGeneraleView.Name = "tabGeneraleView";
			this.tabGeneraleView.Numero = ((uint)(0u));
			this.tabGeneraleView.NumeroTelaio = "";
			this.tabGeneraleView.Portata = 0F;
			this.tabGeneraleView.Profondita = 0F;
			this.tabGeneraleView.Size = new System.Drawing.Size(344, 461);
			this.tabGeneraleView.TabIndex = 0;
			this.tabGeneraleView.Targa = "";
			this.tabGeneraleView.VolumeCarico = 0F;
			// 
			// NewMezzoDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 461);
			this.Controls.Add(this.tabGeneraleView);
			this.MinimumSize = new System.Drawing.Size(360, 500);
			this.Name = "NewMezzoDialog";
			this.Text = "Nuovo mezzo – Flotta";
			this.ResumeLayout(false);

		}

		#endregion

		private TabGeneraleView tabGeneraleView;
	}
}
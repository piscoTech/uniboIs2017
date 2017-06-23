namespace Flotta.ClientSide.View
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabGeneraleView = new Flotta.ClientSide.View.TabGeneraleView();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 439);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(744, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tabGeneraleView);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(744, 439);
			this.panel1.TabIndex = 2;
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
			this.tabGeneraleView.NumeroCartaCircolazione = "";
			this.tabGeneraleView.NumeroTelaio = "";
			this.tabGeneraleView.Portata = 0F;
			this.tabGeneraleView.Profondita = 0F;
			this.tabGeneraleView.Size = new System.Drawing.Size(744, 439);
			this.tabGeneraleView.TabIndex = 0;
			this.tabGeneraleView.Targa = "";
			this.tabGeneraleView.VolumeCarico = 0F;
			// 
			// NewMezzoDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(744, 461);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.MinimumSize = new System.Drawing.Size(760, 500);
			this.Name = "NewMezzoDialog";
			this.Text = "Nuovo mezzo – Flotta";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel panel1;
		private TabGeneraleView tabGeneraleView;
	}
}
namespace Flotta.ClientSide.View
{
	partial class MezzoTabView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MezzoTabView));
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.tabGeneraleView = new Flotta.ClientSide.View.TabGeneraleView();
			this.tabScadenzeView = new Flotta.ClientSide.View.TabScadenzeView();
			this.tabManutenzioniView = new Flotta.ClientSide.View.TabManutenzioniView();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Controls.Add(this.tabPage3);
			this.tabControl.Controls.Add(this.tabPage4);
			this.tabControl.Controls.Add(this.tabPage5);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(364, 419);
			this.tabControl.TabIndex = 0;
			this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabChange);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tabGeneraleView);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(356, 393);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Generale";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabGeneraleView
			// 
			this.tabGeneraleView.Altezza = 0F;
			this.tabGeneraleView.AnnoImmatricolazione = ((uint)(0u));
			this.tabGeneraleView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabGeneraleView.Location = new System.Drawing.Point(3, 3);
			this.tabGeneraleView.Lunghezza = 0F;
			this.tabGeneraleView.Modello = "";
			this.tabGeneraleView.Name = "tabGeneraleView";
			this.tabGeneraleView.Numero = ((uint)(0u));
			this.tabGeneraleView.NumeroCartaCircolazione = "";
			this.tabGeneraleView.NumeroTelaio = "";
			this.tabGeneraleView.Portata = 0F;
			this.tabGeneraleView.Profondita = 0F;
			this.tabGeneraleView.Size = new System.Drawing.Size(350, 387);
			this.tabGeneraleView.TabIndex = 0;
			this.tabGeneraleView.Targa = "";
			this.tabGeneraleView.VolumeCarico = 0F;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.tabScadenzeView);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(356, 393);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Scadenze";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabScadenzeView
			// 
			this.tabScadenzeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabScadenzeView.Location = new System.Drawing.Point(3, 3);
			this.tabScadenzeView.Name = "tabScadenzeView";
			this.tabScadenzeView.Size = new System.Drawing.Size(350, 387);
			this.tabScadenzeView.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.tabManutenzioniView);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(356, 393);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Manutenzioni";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.label4);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(356, 393);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Galleria";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Location = new System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(356, 393);
			this.label4.TabIndex = 1;
			this.label4.Text = "Non implementato";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.label5);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(356, 393);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Incidenti";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Location = new System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(356, 393);
			this.label5.TabIndex = 1;
			this.label5.Text = "Non implementato";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabManutenzioniView
			// 
			this.tabManutenzioniView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabManutenzioniView.Location = new System.Drawing.Point(0, 0);
			this.tabManutenzioniView.Name = "tabManutenzioniView";
			this.tabManutenzioniView.Size = new System.Drawing.Size(356, 393);
			this.tabManutenzioniView.TabIndex = 0;
			// 
			// MezzoTabView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Name = "MezzoTabView";
			this.Size = new System.Drawing.Size(364, 419);
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Label label5;
		private TabGeneraleView tabGeneraleView;
		private TabScadenzeView tabScadenzeView;
		private TabManutenzioniView tabManutenzioniView;
	}
}

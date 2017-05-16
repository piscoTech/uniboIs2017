namespace Flotta.ClientSide.Interface
{
	partial class ClientWindow
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
			if(disposing && (components != null))
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
			this.mezziList = new System.Windows.Forms.DataGridView();
			this.noSelectionLbl = new System.Windows.Forms.Label();
			this.mezzoTabView = new MezzoTabView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.flottaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nuovoMezzoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tipiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tessereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dispositiviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.permessiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manutenzioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assicurazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.mezziList)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mezziList
			// 
			this.mezziList.AllowUserToAddRows = false;
			this.mezziList.AllowUserToDeleteRows = false;
			this.mezziList.AllowUserToResizeColumns = false;
			this.mezziList.AllowUserToResizeRows = false;
			this.mezziList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.mezziList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.mezziList.Dock = System.Windows.Forms.DockStyle.Left;
			this.mezziList.Location = new System.Drawing.Point(0, 24);
			this.mezziList.MultiSelect = false;
			this.mezziList.Name = "mezziList";
			this.mezziList.ReadOnly = true;
			this.mezziList.RowHeadersVisible = false;
			this.mezziList.Size = new System.Drawing.Size(240, 437);
			this.mezziList.TabIndex = 1;
			this.mezziList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MezzoClicked);
			// 
			// noSelectionLbl
			// 
			this.noSelectionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.noSelectionLbl.Location = new System.Drawing.Point(240, 24);
			this.noSelectionLbl.Name = "noSelectionLbl";
			this.noSelectionLbl.Size = new System.Drawing.Size(344, 437);
			this.noSelectionLbl.TabIndex = 3;
			this.noSelectionLbl.Text = "Seleziona un mezzo";
			this.noSelectionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// mezzoTabView
			// 
			this.mezzoTabView.CurrentTab = 0;
			this.mezzoTabView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mezzoTabView.Location = new System.Drawing.Point(240, 24);
			this.mezzoTabView.Name = "mezzoTabView";
			this.mezzoTabView.Size = new System.Drawing.Size(344, 437);
			this.mezzoTabView.TabIndex = 4;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flottaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(584, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// flottaToolStripMenuItem
			// 
			this.flottaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoMezzoToolStripMenuItem,
            this.tipiToolStripMenuItem});
			this.flottaToolStripMenuItem.Name = "flottaToolStripMenuItem";
			this.flottaToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.flottaToolStripMenuItem.Text = "Flotta";
			// 
			// nuovoMezzoToolStripMenuItem
			// 
			this.nuovoMezzoToolStripMenuItem.Name = "nuovoMezzoToolStripMenuItem";
			this.nuovoMezzoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.nuovoMezzoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.nuovoMezzoToolStripMenuItem.Text = "Nuovo mezzo";
			this.nuovoMezzoToolStripMenuItem.Click += new System.EventHandler(this.NewMezzo);
			// 
			// tipiToolStripMenuItem
			// 
			this.tipiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tessereToolStripMenuItem,
            this.dispositiviToolStripMenuItem,
            this.permessiToolStripMenuItem,
            this.manutenzioniToolStripMenuItem,
            this.assicurazioniToolStripMenuItem});
			this.tipiToolStripMenuItem.Name = "tipiToolStripMenuItem";
			this.tipiToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.tipiToolStripMenuItem.Text = "Tipi";
			// 
			// tessereToolStripMenuItem
			// 
			this.tessereToolStripMenuItem.Name = "tessereToolStripMenuItem";
			this.tessereToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.tessereToolStripMenuItem.Text = "Tessere";
			this.tessereToolStripMenuItem.Click += new System.EventHandler(this.OnOpenTesseraTypes);
			// 
			// dispositiviToolStripMenuItem
			// 
			this.dispositiviToolStripMenuItem.Name = "dispositiviToolStripMenuItem";
			this.dispositiviToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.dispositiviToolStripMenuItem.Text = "Dispositivi";
			this.dispositiviToolStripMenuItem.Click += new System.EventHandler(this.OnOpenDispositivoTypes);
			// 
			// permessiToolStripMenuItem
			// 
			this.permessiToolStripMenuItem.Name = "permessiToolStripMenuItem";
			this.permessiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.permessiToolStripMenuItem.Text = "Permessi";
			this.permessiToolStripMenuItem.Click += new System.EventHandler(this.OnOpenPermessoTypes);
			// 
			// manutenzioniToolStripMenuItem
			// 
			this.manutenzioniToolStripMenuItem.Name = "manutenzioniToolStripMenuItem";
			this.manutenzioniToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.manutenzioniToolStripMenuItem.Text = "Manutenzioni";
			this.manutenzioniToolStripMenuItem.Click += new System.EventHandler(this.OnOpenManutenzioneTypes);
			// 
			// assicurazioniToolStripMenuItem
			// 
			this.assicurazioniToolStripMenuItem.Name = "assicurazioniToolStripMenuItem";
			this.assicurazioniToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.assicurazioniToolStripMenuItem.Text = "Assicurazioni";
			this.assicurazioniToolStripMenuItem.Click += new System.EventHandler(this.OnOpenAssicurazioneTypes);
			// 
			// ClientWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 461);
			this.Controls.Add(this.mezzoTabView);
			this.Controls.Add(this.noSelectionLbl);
			this.Controls.Add(this.mezziList);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(600, 500);
			this.Name = "ClientWindow";
			this.Text = "Mezzi – Flotta";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseClient);
			((System.ComponentModel.ISupportInitialize)(this.mezziList)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.DataGridView mezziList;
		private System.Windows.Forms.Label noSelectionLbl;
		private MezzoTabView mezzoTabView;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem flottaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nuovoMezzoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tipiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tessereToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dispositiviToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem permessiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem manutenzioniToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem assicurazioniToolStripMenuItem;
	}
}
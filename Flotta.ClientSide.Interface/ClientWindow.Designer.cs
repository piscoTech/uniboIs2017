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
			this.mezziList = new System.Windows.Forms.DataGridView();
			this.noSelectionLbl = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.flottaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nuovoMezzoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tipiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.officineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.currentUserItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modificaPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userAdminActionSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.manageUserItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.mezzoTabView = new Flotta.ClientSide.Interface.MezzoTabView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.mezziList)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
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
			this.mezziList.Location = new System.Drawing.Point(0, 0);
			this.mezziList.MultiSelect = false;
			this.mezziList.Name = "mezziList";
			this.mezziList.ReadOnly = true;
			this.mezziList.RowHeadersVisible = false;
			this.mezziList.Size = new System.Drawing.Size(240, 515);
			this.mezziList.TabIndex = 0;
			this.mezziList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MezzoClicked);
			// 
			// noSelectionLbl
			// 
			this.noSelectionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.noSelectionLbl.Location = new System.Drawing.Point(0, 0);
			this.noSelectionLbl.Name = "noSelectionLbl";
			this.noSelectionLbl.Size = new System.Drawing.Size(744, 515);
			this.noSelectionLbl.TabIndex = 3;
			this.noSelectionLbl.Text = "Seleziona un mezzo";
			this.noSelectionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flottaToolStripMenuItem,
            this.userMenu});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(984, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// flottaToolStripMenuItem
			// 
			this.flottaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoMezzoToolStripMenuItem,
            this.toolStripSeparator2,
            this.tipiToolStripMenuItem,
            this.officineToolStripMenuItem});
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
			// 
			// tipiToolStripMenuItem
			// 
			this.tipiToolStripMenuItem.Name = "tipiToolStripMenuItem";
			this.tipiToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.tipiToolStripMenuItem.Text = "Tipi";
			// 
			// officineToolStripMenuItem
			// 
			this.officineToolStripMenuItem.Name = "officineToolStripMenuItem";
			this.officineToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.officineToolStripMenuItem.Text = "Officine";
			this.officineToolStripMenuItem.Click += new System.EventHandler(this.OnManageOfficine);
			// 
			// userMenu
			// 
			this.userMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserItem,
            this.modificaPasswordToolStripMenuItem,
            this.userAdminActionSeparator,
            this.manageUserItem});
			this.userMenu.Name = "userMenu";
			this.userMenu.Size = new System.Drawing.Size(54, 20);
			this.userMenu.Text = "Utente";
			// 
			// currentUserItem
			// 
			this.currentUserItem.Enabled = false;
			this.currentUserItem.Name = "currentUserItem";
			this.currentUserItem.Size = new System.Drawing.Size(174, 22);
			this.currentUserItem.Text = "[Current user]";
			// 
			// modificaPasswordToolStripMenuItem
			// 
			this.modificaPasswordToolStripMenuItem.Name = "modificaPasswordToolStripMenuItem";
			this.modificaPasswordToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.modificaPasswordToolStripMenuItem.Text = "Modifica password";
			this.modificaPasswordToolStripMenuItem.Click += new System.EventHandler(this.OnChangePassword);
			// 
			// userAdminActionSeparator
			// 
			this.userAdminActionSeparator.Name = "userAdminActionSeparator";
			this.userAdminActionSeparator.Size = new System.Drawing.Size(171, 6);
			// 
			// manageUserItem
			// 
			this.manageUserItem.Name = "manageUserItem";
			this.manageUserItem.Size = new System.Drawing.Size(174, 22);
			this.manageUserItem.Text = "Gestisci utenti";
			this.manageUserItem.Click += new System.EventHandler(this.OnManageUsers);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 539);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(984, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.mezziList);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(984, 515);
			this.panel1.TabIndex = 8;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.mezzoTabView);
			this.panel2.Controls.Add(this.noSelectionLbl);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(240, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(744, 515);
			this.panel2.TabIndex = 5;
			// 
			// mezzoTabView
			// 
			this.mezzoTabView.CurrentTab = 0;
			this.mezzoTabView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mezzoTabView.Location = new System.Drawing.Point(0, 0);
			this.mezzoTabView.Name = "mezzoTabView";
			this.mezzoTabView.Size = new System.Drawing.Size(744, 515);
			this.mezzoTabView.TabIndex = 4;
			// 
			// ClientWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(1000, 600);
			this.Name = "ClientWindow";
			this.Text = "Mezzi – Flotta";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseClient);
			((System.ComponentModel.ISupportInitialize)(this.mezziList)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView mezziList;
		private System.Windows.Forms.Label noSelectionLbl;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem flottaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nuovoMezzoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tipiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem officineToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem userMenu;
		private System.Windows.Forms.ToolStripMenuItem currentUserItem;
		private System.Windows.Forms.ToolStripMenuItem modificaPasswordToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator userAdminActionSeparator;
		private System.Windows.Forms.ToolStripMenuItem manageUserItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private MezzoTabView mezzoTabView;
	}
}
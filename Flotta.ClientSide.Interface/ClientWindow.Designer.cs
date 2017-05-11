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
			this.mezzoTabControl = new Flotta.ClientSide.Interface.MezzoTabControl();
			((System.ComponentModel.ISupportInitialize)(this.mezziList)).BeginInit();
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
			this.mezziList.Size = new System.Drawing.Size(240, 473);
			this.mezziList.TabIndex = 1;
			this.mezziList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MezzoClicked);
			// 
			// noSelectionLbl
			// 
			this.noSelectionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.noSelectionLbl.Location = new System.Drawing.Point(240, 0);
			this.noSelectionLbl.Name = "noSelectionLbl";
			this.noSelectionLbl.Size = new System.Drawing.Size(344, 473);
			this.noSelectionLbl.TabIndex = 3;
			this.noSelectionLbl.Text = "Seleziona un mezzo";
			this.noSelectionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// mezzoTabControl
			// 
			this.mezzoTabControl.CurrentTab = 0;
			this.mezzoTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mezzoTabControl.Location = new System.Drawing.Point(240, 0);
			this.mezzoTabControl.Name = "mezzoTabControl";
			this.mezzoTabControl.Size = new System.Drawing.Size(344, 473);
			this.mezzoTabControl.TabIndex = 4;
			// 
			// ClientWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 473);
			this.Controls.Add(this.mezzoTabControl);
			this.Controls.Add(this.noSelectionLbl);
			this.Controls.Add(this.mezziList);
			this.MinimumSize = new System.Drawing.Size(600, 500);
			this.Name = "ClientWindow";
			this.Text = "Mezzi – Flotta";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseClient);
			((System.ComponentModel.ISupportInitialize)(this.mezziList)).EndInit();
			this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.DataGridView mezziList;
		private System.Windows.Forms.Label noSelectionLbl;
		private MezzoTabControl mezzoTabControl;
	}
}
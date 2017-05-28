namespace Flotta.ClientSide.Interface
{
	partial class TabScadenzeView
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
			this.scadenzeList = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.scadenzeList)).BeginInit();
			this.SuspendLayout();
			// 
			// scadenzeList
			// 
			this.scadenzeList.AllowUserToAddRows = false;
			this.scadenzeList.AllowUserToDeleteRows = false;
			this.scadenzeList.AllowUserToResizeColumns = false;
			this.scadenzeList.AllowUserToResizeRows = false;
			this.scadenzeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.scadenzeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.scadenzeList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scadenzeList.Location = new System.Drawing.Point(0, 0);
			this.scadenzeList.MultiSelect = false;
			this.scadenzeList.Name = "scadenzeList";
			this.scadenzeList.ReadOnly = true;
			this.scadenzeList.RowHeadersVisible = false;
			this.scadenzeList.Size = new System.Drawing.Size(259, 325);
			this.scadenzeList.TabIndex = 3;
			this.scadenzeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnScadenzaClick);
			this.scadenzeList.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.OnScadenzaRowPaint);
			// 
			// TabScadenzeView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.scadenzeList);
			this.Name = "TabScadenzeView";
			this.Size = new System.Drawing.Size(259, 325);
			((System.ComponentModel.ISupportInitialize)(this.scadenzeList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView scadenzeList;
	}
}

namespace Flotta.ClientSide.Interface
{
	partial class OfficinaManagerWindow
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
			this.typeList = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.typeList)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// typeList
			// 
			this.typeList.AllowUserToAddRows = false;
			this.typeList.AllowUserToDeleteRows = false;
			this.typeList.AllowUserToResizeColumns = false;
			this.typeList.AllowUserToResizeRows = false;
			this.typeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.typeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.typeList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.typeList.Location = new System.Drawing.Point(0, 0);
			this.typeList.MultiSelect = false;
			this.typeList.Name = "typeList";
			this.typeList.ReadOnly = true;
			this.typeList.RowHeadersVisible = false;
			this.typeList.Size = new System.Drawing.Size(403, 307);
			this.typeList.TabIndex = 1;
			this.typeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 282);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(403, 25);
			this.panel1.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Right;
			this.button1.Location = new System.Drawing.Point(328, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 25);
			this.button1.TabIndex = 2;
			this.button1.Text = "Nuova";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnCreateNewType);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 307);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(403, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Controls.Add(this.typeList);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(403, 307);
			this.panel2.TabIndex = 5;
			// 
			// OfficinaManagerWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 329);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.statusStrip1);
			this.Name = "OfficinaManagerWindow";
			this.Text = "Officine – Flotta";
			((System.ComponentModel.ISupportInitialize)(this.typeList)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView typeList;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel panel2;
	}
}
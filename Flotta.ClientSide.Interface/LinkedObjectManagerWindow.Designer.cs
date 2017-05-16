﻿namespace Flotta.ClientSide.Interface
{
	partial class LinkedObjectManagerWindow
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
			((System.ComponentModel.ISupportInitialize)(this.typeList)).BeginInit();
			this.panel1.SuspendLayout();
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
			this.typeList.Size = new System.Drawing.Size(403, 329);
			this.typeList.TabIndex = 2;
			this.typeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 304);
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
			this.button1.TabIndex = 0;
			this.button1.Text = "Nuovo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnCreateNewType);
			// 
			// LinkedObjectManagerWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 329);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.typeList);
			this.Name = "LinkedObjectManagerWindow";
			this.Text = "LinkedObjectManagerWindow";
			((System.ComponentModel.ISupportInitialize)(this.typeList)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView typeList;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
	}
}
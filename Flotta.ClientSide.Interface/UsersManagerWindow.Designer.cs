﻿namespace Flotta.ClientSide.Interface
{
	partial class UsersManagerWindow
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
			this.usersList = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.usersList)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// usersList
			// 
			this.usersList.AllowUserToAddRows = false;
			this.usersList.AllowUserToDeleteRows = false;
			this.usersList.AllowUserToResizeColumns = false;
			this.usersList.AllowUserToResizeRows = false;
			this.usersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.usersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.usersList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.usersList.Location = new System.Drawing.Point(0, 0);
			this.usersList.MultiSelect = false;
			this.usersList.Name = "usersList";
			this.usersList.ReadOnly = true;
			this.usersList.RowHeadersVisible = false;
			this.usersList.Size = new System.Drawing.Size(403, 329);
			this.usersList.TabIndex = 2;
			this.usersList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
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
			this.button1.Click += new System.EventHandler(this.OnCreateNewUser);
			// 
			// UsersTypeManagerWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 329);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.usersList);
			this.Name = "UsersTypeManagerWindow";
			this.Text = "Utenti – Flotta";
			((System.ComponentModel.ISupportInitialize)(this.usersList)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView usersList;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
	}
}
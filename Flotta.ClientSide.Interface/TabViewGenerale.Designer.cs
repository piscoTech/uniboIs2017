namespace Flotta.ClientSide.Interface
{
	partial class TabViewGenerale
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
			this.mezzoTitle = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.enterEditBtn = new System.Windows.Forms.Button();
			this.cancelEditBtn = new System.Windows.Forms.Button();
			this.saveEditBtn = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// mezzoTitle
			// 
			this.mezzoTitle.AutoSize = true;
			this.mezzoTitle.Location = new System.Drawing.Point(145, 45);
			this.mezzoTitle.Name = "mezzoTitle";
			this.mezzoTitle.Size = new System.Drawing.Size(35, 13);
			this.mezzoTitle.TabIndex = 3;
			this.mezzoTitle.Text = "label1";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.enterEditBtn);
			this.panel2.Controls.Add(this.cancelEditBtn);
			this.panel2.Controls.Add(this.saveEditBtn);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 359);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(488, 25);
			this.panel2.TabIndex = 2;
			// 
			// enterEditBtn
			// 
			this.enterEditBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.enterEditBtn.Location = new System.Drawing.Point(263, 0);
			this.enterEditBtn.Name = "enterEditBtn";
			this.enterEditBtn.Size = new System.Drawing.Size(75, 25);
			this.enterEditBtn.TabIndex = 2;
			this.enterEditBtn.Text = "Modifica";
			this.enterEditBtn.UseVisualStyleBackColor = true;
			this.enterEditBtn.Visible = false;
			this.enterEditBtn.Click += new System.EventHandler(this.OnEnterEdit);
			// 
			// cancelEditBtn
			// 
			this.cancelEditBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.cancelEditBtn.Location = new System.Drawing.Point(338, 0);
			this.cancelEditBtn.Name = "cancelEditBtn";
			this.cancelEditBtn.Size = new System.Drawing.Size(75, 25);
			this.cancelEditBtn.TabIndex = 1;
			this.cancelEditBtn.Text = "Annulla";
			this.cancelEditBtn.UseVisualStyleBackColor = true;
			this.cancelEditBtn.Click += new System.EventHandler(this.OnCancelEdit);
			// 
			// saveEditBtn
			// 
			this.saveEditBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.saveEditBtn.Location = new System.Drawing.Point(413, 0);
			this.saveEditBtn.Name = "saveEditBtn";
			this.saveEditBtn.Size = new System.Drawing.Size(75, 25);
			this.saveEditBtn.TabIndex = 0;
			this.saveEditBtn.Text = "Salva";
			this.saveEditBtn.UseVisualStyleBackColor = true;
			this.saveEditBtn.Click += new System.EventHandler(this.OnSaveEdit);
			// 
			// TabViewGenerale
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mezzoTitle);
			this.Controls.Add(this.panel2);
			this.Name = "TabViewGenerale";
			this.Size = new System.Drawing.Size(488, 384);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label mezzoTitle;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button enterEditBtn;
		private System.Windows.Forms.Button cancelEditBtn;
		private System.Windows.Forms.Button saveEditBtn;
	}
}

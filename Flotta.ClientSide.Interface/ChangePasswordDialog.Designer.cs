namespace Flotta.ClientSide.Interface
{
	partial class ChangePasswordDialog
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
			this.label1 = new System.Windows.Forms.Label();
			this.newPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.repeatPassword = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.oldPassword = new System.Windows.Forms.TextBox();
			this.submitButton = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nuova password";
			// 
			// newPassword
			// 
			this.newPassword.Location = new System.Drawing.Point(2, 15);
			this.newPassword.Margin = new System.Windows.Forms.Padding(2);
			this.newPassword.Name = "newPassword";
			this.newPassword.PasswordChar = '*';
			this.newPassword.Size = new System.Drawing.Size(288, 20);
			this.newPassword.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 37);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Ripeti password";
			// 
			// repeatPassword
			// 
			this.repeatPassword.Location = new System.Drawing.Point(2, 52);
			this.repeatPassword.Margin = new System.Windows.Forms.Padding(2);
			this.repeatPassword.Name = "repeatPassword";
			this.repeatPassword.PasswordChar = '*';
			this.repeatPassword.Size = new System.Drawing.Size(288, 20);
			this.repeatPassword.TabIndex = 3;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.newPassword);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.repeatPassword);
			this.flowLayoutPanel1.Controls.Add(this.label3);
			this.flowLayoutPanel1.Controls.Add(this.oldPassword);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(310, 152);
			this.flowLayoutPanel1.TabIndex = 5;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.submitButton);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 127);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(310, 25);
			this.panel1.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Dock = System.Windows.Forms.DockStyle.Right;
			this.button1.Location = new System.Drawing.Point(246, 0);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 25);
			this.button1.TabIndex = 5;
			this.button1.Text = "Annulla";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(2, 74);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Vecchia password";
			// 
			// oldPassword
			// 
			this.oldPassword.Location = new System.Drawing.Point(2, 89);
			this.oldPassword.Margin = new System.Windows.Forms.Padding(2);
			this.oldPassword.Name = "oldPassword";
			this.oldPassword.PasswordChar = '*';
			this.oldPassword.Size = new System.Drawing.Size(288, 20);
			this.oldPassword.TabIndex = 5;
			// 
			// submitButton
			// 
			this.submitButton.AutoSize = true;
			this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.submitButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.submitButton.Location = new System.Drawing.Point(146, 0);
			this.submitButton.Margin = new System.Windows.Forms.Padding(2);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(100, 25);
			this.submitButton.TabIndex = 6;
			this.submitButton.Text = "Cambia password";
			this.submitButton.UseVisualStyleBackColor = true;
			this.submitButton.Click += new System.EventHandler(this.OnSave);
			// 
			// ChangePasswordDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(310, 152);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.Name = "ChangePasswordDialog";
			this.Text = "Cambia password – Flotta";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox newPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox repeatPassword;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox oldPassword;
		private System.Windows.Forms.Button submitButton;
	}
}
namespace Flotta.ClientSide.Interface
{
	partial class UpdateUserDialog
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.passwordLbl = new System.Windows.Forms.Label();
			this.repeatPasswordLbl = new System.Windows.Forms.Label();
			this.username = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.repeatPassword = new System.Windows.Forms.TextBox();
			this.isAdmin = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.saveBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.username);
			this.flowLayoutPanel1.Controls.Add(this.passwordLbl);
			this.flowLayoutPanel1.Controls.Add(this.password);
			this.flowLayoutPanel1.Controls.Add(this.repeatPasswordLbl);
			this.flowLayoutPanel1.Controls.Add(this.repeatPassword);
			this.flowLayoutPanel1.Controls.Add(this.isAdmin);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(370, 173);
			this.flowLayoutPanel1.TabIndex = 0;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username";
			// 
			// passwordLbl
			// 
			this.passwordLbl.AutoSize = true;
			this.passwordLbl.Location = new System.Drawing.Point(3, 39);
			this.passwordLbl.Name = "passwordLbl";
			this.passwordLbl.Size = new System.Drawing.Size(53, 13);
			this.passwordLbl.TabIndex = 1;
			this.passwordLbl.Text = "Password";
			// 
			// repeatPasswordLbl
			// 
			this.repeatPasswordLbl.AutoSize = true;
			this.repeatPasswordLbl.Location = new System.Drawing.Point(3, 78);
			this.repeatPasswordLbl.Name = "repeatPasswordLbl";
			this.repeatPasswordLbl.Size = new System.Drawing.Size(82, 13);
			this.repeatPasswordLbl.TabIndex = 2;
			this.repeatPasswordLbl.Text = "Ripeti password";
			// 
			// username
			// 
			this.username.Location = new System.Drawing.Point(3, 16);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(167, 20);
			this.username.TabIndex = 3;
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(3, 55);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(167, 20);
			this.password.TabIndex = 4;
			// 
			// repeatPassword
			// 
			this.repeatPassword.Location = new System.Drawing.Point(3, 94);
			this.repeatPassword.Name = "repeatPassword";
			this.repeatPassword.PasswordChar = '*';
			this.repeatPassword.Size = new System.Drawing.Size(167, 20);
			this.repeatPassword.TabIndex = 5;
			// 
			// isAdmin
			// 
			this.isAdmin.AutoSize = true;
			this.isAdmin.Location = new System.Drawing.Point(3, 120);
			this.isAdmin.Name = "isAdmin";
			this.isAdmin.Size = new System.Drawing.Size(55, 17);
			this.isAdmin.TabIndex = 6;
			this.isAdmin.Text = "Admin";
			this.isAdmin.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.saveBtn);
			this.panel1.Controls.Add(this.cancelBtn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 148);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(370, 25);
			this.panel1.TabIndex = 1;
			// 
			// saveBtn
			// 
			this.saveBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.saveBtn.Location = new System.Drawing.Point(220, 0);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(75, 25);
			this.saveBtn.TabIndex = 3;
			this.saveBtn.Text = "Salva";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.OnSave);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.cancelBtn.Location = new System.Drawing.Point(295, 0);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 25);
			this.cancelBtn.TabIndex = 2;
			this.cancelBtn.Text = "Annulla";
			this.cancelBtn.UseVisualStyleBackColor = true;
			// 
			// UpdateUserDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(370, 173);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "UpdateUserDialog";
			this.Text = "Modifica Utente – Flotta";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.Label passwordLbl;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label repeatPasswordLbl;
		private System.Windows.Forms.TextBox repeatPassword;
		private System.Windows.Forms.CheckBox isAdmin;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Button cancelBtn;
	}
}
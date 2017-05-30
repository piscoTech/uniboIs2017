namespace Flotta.ClientSide.Interface
{
	partial class AuthenticateUserDialog
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
			this.username = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.password = new System.Windows.Forms.TextBox();
			this.submitButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 11);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username";
			// 
			// username
			// 
			this.username.Location = new System.Drawing.Point(10, 28);
			this.username.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(288, 20);
			this.username.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 51);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password";
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(10, 68);
			this.password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(288, 20);
			this.password.TabIndex = 3;
			// 
			// submitButton
			// 
			this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.submitButton.Location = new System.Drawing.Point(232, 92);
			this.submitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(64, 25);
			this.submitButton.TabIndex = 4;
			this.submitButton.Text = "Login";
			this.submitButton.UseVisualStyleBackColor = true;
			// 
			// AuthenticateUserDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(308, 127);
			this.Controls.Add(this.submitButton);
			this.Controls.Add(this.password);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.username);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.Name = "AuthenticateUserDialog";
			this.Text = "Login – Flotta";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Button submitButton;
	}
}
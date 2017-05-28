namespace Flotta.ClientSide.Interface
{
	partial class UpdateOfficinaDialog
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
			this.controlContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.btnPanel = new System.Windows.Forms.Panel();
			this.saveBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.editBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.name = new System.Windows.Forms.TextBox();
			this.phone = new System.Windows.Forms.TextBox();
			this.street = new System.Windows.Forms.TextBox();
			this.zipCode = new System.Windows.Forms.TextBox();
			this.city = new System.Windows.Forms.TextBox();
			this.state = new System.Windows.Forms.TextBox();
			this.province = new System.Windows.Forms.TextBox();
			this.controlContainer.SuspendLayout();
			this.btnPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// controlContainer
			// 
			this.controlContainer.Controls.Add(this.label1);
			this.controlContainer.Controls.Add(this.name);
			this.controlContainer.Controls.Add(this.label2);
			this.controlContainer.Controls.Add(this.phone);
			this.controlContainer.Controls.Add(this.label3);
			this.controlContainer.Controls.Add(this.street);
			this.controlContainer.Controls.Add(this.label4);
			this.controlContainer.Controls.Add(this.zipCode);
			this.controlContainer.Controls.Add(this.label5);
			this.controlContainer.Controls.Add(this.city);
			this.controlContainer.Controls.Add(this.label6);
			this.controlContainer.Controls.Add(this.province);
			this.controlContainer.Controls.Add(this.label7);
			this.controlContainer.Controls.Add(this.state);
			this.controlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.controlContainer.Location = new System.Drawing.Point(0, 0);
			this.controlContainer.Name = "controlContainer";
			this.controlContainer.Size = new System.Drawing.Size(401, 285);
			this.controlContainer.TabIndex = 12;
			this.controlContainer.WrapContents = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nome";
			// 
			// btnPanel
			// 
			this.btnPanel.Controls.Add(this.saveBtn);
			this.btnPanel.Controls.Add(this.cancelBtn);
			this.btnPanel.Controls.Add(this.editBtn);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnPanel.Location = new System.Drawing.Point(0, 285);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.Size = new System.Drawing.Size(401, 25);
			this.btnPanel.TabIndex = 11;
			// 
			// saveBtn
			// 
			this.saveBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.saveBtn.Location = new System.Drawing.Point(251, 0);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(75, 25);
			this.saveBtn.TabIndex = 1;
			this.saveBtn.Text = "Salva";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(OnSave);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.cancelBtn.Location = new System.Drawing.Point(326, 0);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 25);
			this.cancelBtn.TabIndex = 0;
			this.cancelBtn.Text = "Annulla";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(OnCancelEdit);
			// 
			// editBtn
			// 
			this.editBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.editBtn.Location = new System.Drawing.Point(326, 0);
			this.editBtn.Name = "editBtn";
			this.editBtn.Size = new System.Drawing.Size(75, 25);
			this.editBtn.TabIndex = 0;
			this.editBtn.Text = "Modifica";
			this.editBtn.UseVisualStyleBackColor = true;
			this.editBtn.Click += new System.EventHandler(OnEdit);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Telefono";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Via";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 117);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "CAP";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 156);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(28, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Città";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 195);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Provincia";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 234);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Nazione";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(3, 16);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(244, 20);
			this.name.TabIndex = 8;
			// 
			// phone
			// 
			this.phone.Location = new System.Drawing.Point(3, 55);
			this.phone.Name = "phone";
			this.phone.Size = new System.Drawing.Size(122, 20);
			this.phone.TabIndex = 9;
			// 
			// street
			// 
			this.street.Location = new System.Drawing.Point(3, 94);
			this.street.Name = "street";
			this.street.Size = new System.Drawing.Size(244, 20);
			this.street.TabIndex = 10;
			// 
			// zipCode
			// 
			this.zipCode.Location = new System.Drawing.Point(3, 133);
			this.zipCode.Name = "zipCode";
			this.zipCode.Size = new System.Drawing.Size(62, 20);
			this.zipCode.TabIndex = 11;
			// 
			// city
			// 
			this.city.Location = new System.Drawing.Point(3, 172);
			this.city.Name = "city";
			this.city.Size = new System.Drawing.Size(244, 20);
			this.city.TabIndex = 12;
			// 
			// state
			// 
			this.state.Location = new System.Drawing.Point(3, 250);
			this.state.Name = "state";
			this.state.Size = new System.Drawing.Size(122, 20);
			this.state.TabIndex = 13;
			// 
			// province
			// 
			this.province.Location = new System.Drawing.Point(3, 211);
			this.province.Name = "province";
			this.province.Size = new System.Drawing.Size(35, 20);
			this.province.TabIndex = 14;
			// 
			// UpdateOfficinaDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 340);
			this.Controls.Add(this.controlContainer);
			this.Controls.Add(this.btnPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "UpdateOfficinaDialog";
			this.Text = "Modifica – Officina – Flotta";
			this.controlContainer.ResumeLayout(false);
			this.controlContainer.PerformLayout();
			this.btnPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel controlContainer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel btnPanel;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button editBtn;
		private System.Windows.Forms.TextBox name;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox phone;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox street;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox zipCode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox city;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox province;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox state;
	}
}
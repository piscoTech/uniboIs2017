namespace Flotta.ClientSide.Interface
{
	partial class UpdateScadenzaDialog
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
			this.date = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.saveBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.type = new System.Windows.Forms.ComboBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.dateFields = new System.Windows.Forms.FlowLayoutPanel();
			this.format = new System.Windows.Forms.ComboBox();
			this.recurFields = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.recurNum = new System.Windows.Forms.TextBox();
			this.recurType = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.dateFields.SuspendLayout();
			this.recurFields.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// date
			// 
			this.date.Location = new System.Drawing.Point(3, 16);
			this.date.Name = "date";
			this.date.Size = new System.Drawing.Size(200, 20);
			this.date.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Data";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Periodo di ricorrenza";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Tipo";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Formato";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.saveBtn);
			this.panel1.Controls.Add(this.cancelBtn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 176);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(418, 25);
			this.panel1.TabIndex = 8;
			// 
			// saveBtn
			// 
			this.saveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.saveBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.saveBtn.Location = new System.Drawing.Point(268, 0);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(75, 25);
			this.saveBtn.TabIndex = 6;
			this.saveBtn.Text = "Salva";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(OnSave);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.cancelBtn.Location = new System.Drawing.Point(343, 0);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 25);
			this.cancelBtn.TabIndex = 7;
			this.cancelBtn.Text = "Annulla";
			this.cancelBtn.UseVisualStyleBackColor = true;
			// 
			// type
			// 
			this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.type.FormattingEnabled = true;
			this.type.Location = new System.Drawing.Point(3, 16);
			this.type.Name = "type";
			this.type.Size = new System.Drawing.Size(147, 21);
			this.type.TabIndex = 1;
			this.type.SelectedIndexChanged += new System.EventHandler(this.OnTypeChanged);
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.label3);
			this.flowLayoutPanel2.Controls.Add(this.type);
			this.flowLayoutPanel2.Controls.Add(this.dateFields);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(418, 176);
			this.flowLayoutPanel2.TabIndex = 10;
			this.flowLayoutPanel2.WrapContents = false;
			// 
			// dateFields
			// 
			this.dateFields.AutoSize = true;
			this.dateFields.Controls.Add(this.label1);
			this.dateFields.Controls.Add(this.date);
			this.dateFields.Controls.Add(this.label4);
			this.dateFields.Controls.Add(this.format);
			this.dateFields.Controls.Add(this.recurFields);
			this.dateFields.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.dateFields.Location = new System.Drawing.Point(0, 43);
			this.dateFields.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.dateFields.Name = "dateFields";
			this.dateFields.Size = new System.Drawing.Size(206, 131);
			this.dateFields.TabIndex = 10;
			this.dateFields.WrapContents = false;
			// 
			// format
			// 
			this.format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.format.FormattingEnabled = true;
			this.format.Location = new System.Drawing.Point(3, 55);
			this.format.Name = "format";
			this.format.Size = new System.Drawing.Size(147, 21);
			this.format.TabIndex = 3;
			// 
			// recurFields
			// 
			this.recurFields.AutoSize = true;
			this.recurFields.Controls.Add(this.label2);
			this.recurFields.Controls.Add(this.flowLayoutPanel3);
			this.recurFields.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.recurFields.Location = new System.Drawing.Point(0, 82);
			this.recurFields.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.recurFields.Name = "recurFields";
			this.recurFields.Size = new System.Drawing.Size(204, 46);
			this.recurFields.TabIndex = 11;
			this.recurFields.WrapContents = false;
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.AutoSize = true;
			this.flowLayoutPanel3.Controls.Add(this.recurNum);
			this.flowLayoutPanel3.Controls.Add(this.recurType);
			this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 16);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(204, 27);
			this.flowLayoutPanel3.TabIndex = 12;
			this.flowLayoutPanel3.WrapContents = false;
			// 
			// recurNum
			// 
			this.recurNum.Location = new System.Drawing.Point(3, 3);
			this.recurNum.Name = "recurNum";
			this.recurNum.Size = new System.Drawing.Size(45, 20);
			this.recurNum.TabIndex = 4;
			// 
			// recurType
			// 
			this.recurType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.recurType.FormattingEnabled = true;
			this.recurType.Location = new System.Drawing.Point(54, 3);
			this.recurType.Name = "recurType";
			this.recurType.Size = new System.Drawing.Size(147, 21);
			this.recurType.TabIndex = 5;
			// 
			// UpdateScadenzaDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 201);
			this.Controls.Add(this.flowLayoutPanel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "UpdateScadenzaDialog";
			this.panel1.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.dateFields.ResumeLayout(false);
			this.dateFields.PerformLayout();
			this.recurFields.ResumeLayout(false);
			this.recurFields.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DateTimePicker date;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.ComboBox type;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.ComboBox format;
		private System.Windows.Forms.FlowLayoutPanel dateFields;
		private System.Windows.Forms.FlowLayoutPanel recurFields;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
		private System.Windows.Forms.TextBox recurNum;
		private System.Windows.Forms.ComboBox recurType;
	}
}
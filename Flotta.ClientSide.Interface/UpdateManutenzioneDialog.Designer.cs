namespace Flotta.ClientSide.Interface
{
	partial class UpdateManutenzioneDialog
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
			this.notes = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cost = new System.Windows.Forms.TextBox();
			this.btnPanel = new System.Windows.Forms.Panel();
			this.saveBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.type = new System.Windows.Forms.ComboBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.officina = new System.Windows.Forms.ComboBox();
			this.btnPanel.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// date
			// 
			this.date.Location = new System.Drawing.Point(3, 16);
			this.date.Name = "date";
			this.date.Size = new System.Drawing.Size(200, 20);
			this.date.TabIndex = 0;
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
			this.label2.Location = new System.Drawing.Point(3, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Note";
			// 
			// notes
			// 
			this.notes.Location = new System.Drawing.Point(3, 95);
			this.notes.Name = "notes";
			this.notes.Size = new System.Drawing.Size(354, 20);
			this.notes.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Tipo";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 158);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Costo €";
			// 
			// cost
			// 
			this.cost.Location = new System.Drawing.Point(3, 174);
			this.cost.Name = "cost";
			this.cost.Size = new System.Drawing.Size(85, 20);
			this.cost.TabIndex = 7;
			// 
			// btnPanel
			// 
			this.btnPanel.Controls.Add(this.saveBtn);
			this.btnPanel.Controls.Add(this.cancelBtn);
			this.btnPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnPanel.Location = new System.Drawing.Point(0, 201);
			this.btnPanel.Name = "btnPanel";
			this.btnPanel.Size = new System.Drawing.Size(432, 25);
			this.btnPanel.TabIndex = 8;
			// 
			// saveBtn
			// 
			this.saveBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.saveBtn.Location = new System.Drawing.Point(282, 0);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(75, 25);
			this.saveBtn.TabIndex = 1;
			this.saveBtn.Text = "Salva";
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.OnSave);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Right;
			this.cancelBtn.Location = new System.Drawing.Point(357, 0);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 25);
			this.cancelBtn.TabIndex = 0;
			this.cancelBtn.Text = "Annulla";
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.UseVisualStyleBackColor = true;
			// 
			// type
			// 
			this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.type.FormattingEnabled = true;
			this.type.Location = new System.Drawing.Point(3, 55);
			this.type.Name = "type";
			this.type.Size = new System.Drawing.Size(200, 21);
			this.type.TabIndex = 9;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.date);
			this.flowLayoutPanel1.Controls.Add(this.label3);
			this.flowLayoutPanel1.Controls.Add(this.type);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.notes);
			this.flowLayoutPanel1.Controls.Add(this.label5);
			this.flowLayoutPanel1.Controls.Add(this.officina);
			this.flowLayoutPanel1.Controls.Add(this.label4);
			this.flowLayoutPanel1.Controls.Add(this.cost);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(432, 201);
			this.flowLayoutPanel1.TabIndex = 10;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 118);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Officina";
			// 
			// officina
			// 
			this.officina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.officina.FormattingEnabled = true;
			this.officina.Location = new System.Drawing.Point(3, 134);
			this.officina.Name = "officina";
			this.officina.Size = new System.Drawing.Size(200, 21);
			this.officina.TabIndex = 11;
			// 
			// NewManutenzioneDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 226);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.btnPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "NewManutenzioneDialog";
			this.Text = "Modifica manutenzione – Flotta";
			this.btnPanel.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DateTimePicker date;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox notes;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox cost;
		private System.Windows.Forms.Panel btnPanel;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.ComboBox type;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox officina;
	}
}
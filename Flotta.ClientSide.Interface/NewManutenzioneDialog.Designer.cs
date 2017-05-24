namespace Flotta.ClientSide.Interface
{
	partial class NewManutenzioneDialog
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
			this.data = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.note = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.costo = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.annulla = new System.Windows.Forms.Button();
			this.salva = new System.Windows.Forms.Button();
			this.types = new System.Windows.Forms.ComboBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// data
			// 
			this.data.Location = new System.Drawing.Point(60, 9);
			this.data.Name = "data";
			this.data.Size = new System.Drawing.Size(200, 20);
			this.data.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Data:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Note";
			// 
			// note
			// 
			this.note.Location = new System.Drawing.Point(60, 50);
			this.note.Name = "note";
			this.note.Size = new System.Drawing.Size(100, 20);
			this.note.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Tipo";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 157);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Costo";
			// 
			// costo
			// 
			this.costo.Location = new System.Drawing.Point(60, 157);
			this.costo.Name = "costo";
			this.costo.Size = new System.Drawing.Size(100, 20);
			this.costo.TabIndex = 7;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.annulla);
			this.flowLayoutPanel1.Controls.Add(this.salva);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 313);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(422, 33);
			this.flowLayoutPanel1.TabIndex = 8;
			// 
			// annulla
			// 
			this.annulla.Location = new System.Drawing.Point(3, 3);
			this.annulla.Name = "annulla";
			this.annulla.Size = new System.Drawing.Size(75, 23);
			this.annulla.TabIndex = 0;
			this.annulla.Text = "Annulla";
			this.annulla.UseVisualStyleBackColor = true;
			this.annulla.Click += new System.EventHandler(this.OnCancelManutenzione);
			// 
			// salva
			// 
			this.salva.Location = new System.Drawing.Point(84, 3);
			this.salva.Name = "salva";
			this.salva.Size = new System.Drawing.Size(75, 23);
			this.salva.TabIndex = 1;
			this.salva.Text = "Salva";
			this.salva.UseVisualStyleBackColor = true;
			this.salva.Click += new System.EventHandler(this.OnSaveManutenzione);
			// 
			// types
			// 
			this.types.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.types.FormattingEnabled = true;
			this.types.Location = new System.Drawing.Point(60, 102);
			this.types.Name = "types";
			this.types.Size = new System.Drawing.Size(121, 21);
			this.types.TabIndex = 9;
			// 
			// NewManutenzioneDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(422, 346);
			this.Controls.Add(this.types);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.costo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.note);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.data);
			this.Name = "NewManutenzioneDialog";
			this.Text = "NewManutenzioneDialog";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker data;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox note;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox costo;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button annulla;
		private System.Windows.Forms.Button salva;
		private System.Windows.Forms.ComboBox types;
	}
}
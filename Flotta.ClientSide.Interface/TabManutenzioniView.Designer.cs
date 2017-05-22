namespace Flotta.ClientSide.Interface
{
	partial class TabManutenzioniView
	{
		/// <summary> 
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Pulire le risorse in uso.
		/// </summary>
		/// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Codice generato da Progettazione componenti

		/// <summary> 
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Modifica = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Elimina = new System.Windows.Forms.DataGridViewButtonColumn();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Note,
            this.Costo,
            this.Tipo,
            this.Modifica,
            this.Elimina});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(444, 509);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// Data
			// 
			this.Data.FillWeight = 83.45177F;
			this.Data.HeaderText = "Data";
			this.Data.Name = "Data";
			this.Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// Note
			// 
			this.Note.FillWeight = 83.45177F;
			this.Note.HeaderText = "Note";
			this.Note.Name = "Note";
			// 
			// Costo
			// 
			this.Costo.FillWeight = 83.45177F;
			this.Costo.HeaderText = "Costo";
			this.Costo.Name = "Costo";
			this.Costo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// Tipo
			// 
			this.Tipo.FillWeight = 83.45177F;
			this.Tipo.HeaderText = "Tipo";
			this.Tipo.Name = "Tipo";
			// 
			// Modifica
			// 
			this.Modifica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Modifica.FillWeight = 182.7411F;
			this.Modifica.HeaderText = "Modifica";
			this.Modifica.Name = "Modifica";
			this.Modifica.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Modifica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Modifica.Text = "Modifica";
			this.Modifica.UseColumnTextForButtonValue = true;
			this.Modifica.Width = 60;
			// 
			// Elimina
			// 
			this.Elimina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Elimina.FillWeight = 83.45177F;
			this.Elimina.HeaderText = "Elimina";
			this.Elimina.Name = "Elimina";
			this.Elimina.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Elimina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Elimina.Text = "Elimina";
			this.Elimina.UseColumnTextForButtonValue = true;
			this.Elimina.Width = 60;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.button1);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 476);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(444, 33);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Nuovo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnNewManutenzione);
			// 
			// TabManutenzioniView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "TabManutenzioniView";
			this.Size = new System.Drawing.Size(444, 509);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Data;
		private System.Windows.Forms.DataGridViewTextBoxColumn Note;
		private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
		private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
		private System.Windows.Forms.DataGridViewButtonColumn Modifica;
		private System.Windows.Forms.DataGridViewButtonColumn Elimina;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button button1;
	}
}

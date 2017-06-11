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
			this.manutenzioniList = new System.Windows.Forms.DataGridView();
			this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Officina = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Allegato = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Modifica = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Elimina = new System.Windows.Forms.DataGridViewButtonColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.manutenzioniList)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// manutenzioniList
			// 
			this.manutenzioniList.AllowUserToAddRows = false;
			this.manutenzioniList.AllowUserToDeleteRows = false;
			this.manutenzioniList.AllowUserToResizeColumns = false;
			this.manutenzioniList.AllowUserToResizeRows = false;
			this.manutenzioniList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.manutenzioniList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.manutenzioniList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Tipo,
            this.Note,
            this.Officina,
            this.Costo,
            this.Allegato,
            this.Modifica,
            this.Elimina});
			this.manutenzioniList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.manutenzioniList.Location = new System.Drawing.Point(0, 0);
			this.manutenzioniList.MultiSelect = false;
			this.manutenzioniList.Name = "manutenzioniList";
			this.manutenzioniList.ReadOnly = true;
			this.manutenzioniList.RowHeadersVisible = false;
			this.manutenzioniList.Size = new System.Drawing.Size(444, 509);
			this.manutenzioniList.TabIndex = 0;
			this.manutenzioniList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
			// 
			// Data
			// 
			this.Data.DataPropertyName = "Date";
			this.Data.FillWeight = 83.45177F;
			this.Data.HeaderText = "Data";
			this.Data.Name = "Data";
			this.Data.ReadOnly = true;
			this.Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// Tipo
			// 
			this.Tipo.DataPropertyName = "Tipo";
			this.Tipo.FillWeight = 83.45177F;
			this.Tipo.HeaderText = "Tipo";
			this.Tipo.Name = "Tipo";
			this.Tipo.ReadOnly = true;
			// 
			// Note
			// 
			this.Note.DataPropertyName = "Note";
			this.Note.FillWeight = 83.45177F;
			this.Note.HeaderText = "Note";
			this.Note.Name = "Note";
			this.Note.ReadOnly = true;
			// 
			// Officina
			// 
			this.Officina.DataPropertyName = "Officina";
			this.Officina.HeaderText = "Officina";
			this.Officina.Name = "Officina";
			this.Officina.ReadOnly = true;
			// 
			// Costo
			// 
			this.Costo.DataPropertyName = "Costo";
			this.Costo.FillWeight = 83.45177F;
			this.Costo.HeaderText = "Costo €";
			this.Costo.Name = "Costo";
			this.Costo.ReadOnly = true;
			this.Costo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// Allegato
			// 
			this.Allegato.DataPropertyName = "AllegatoPath";
			this.Allegato.FillWeight = 83.45177F;
			this.Allegato.HeaderText = "Allegato";
			this.Allegato.Name = "Allegato";
			this.Allegato.ReadOnly = true;
			this.Allegato.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// Modifica
			// 
			this.Modifica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Modifica.FillWeight = 182.7411F;
			this.Modifica.HeaderText = "Modifica";
			this.Modifica.Name = "Modifica";
			this.Modifica.ReadOnly = true;
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
			this.Elimina.ReadOnly = true;
			this.Elimina.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Elimina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Elimina.Text = "Elimina";
			this.Elimina.UseColumnTextForButtonValue = true;
			this.Elimina.Width = 60;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 484);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(444, 25);
			this.panel1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Right;
			this.button1.Location = new System.Drawing.Point(369, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 25);
			this.button1.TabIndex = 1;
			this.button1.Text = "Nuovo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OnNewManutenzione);
			// 
			// TabManutenzioniView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.manutenzioniList);
			this.Name = "TabManutenzioniView";
			this.Size = new System.Drawing.Size(444, 509);
			((System.ComponentModel.ISupportInitialize)(this.manutenzioniList)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView manutenzioniList;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Data;
		private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
		private System.Windows.Forms.DataGridViewTextBoxColumn Note;
		private System.Windows.Forms.DataGridViewTextBoxColumn Officina;
		private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
		private System.Windows.Forms.DataGridViewTextBoxColumn Allegato;
		private System.Windows.Forms.DataGridViewButtonColumn Modifica;
		private System.Windows.Forms.DataGridViewButtonColumn Elimina;
	}
}

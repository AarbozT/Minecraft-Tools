namespace Minecraft_Tools
{
    partial class Ventana_Donaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana_Donaciones));
            this.DataGridView_Principal = new System.Windows.Forms.DataGridView();
            this.Columna_Imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.Columna_Donante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Principal)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView_Principal
            // 
            this.DataGridView_Principal.AllowUserToAddRows = false;
            this.DataGridView_Principal.AllowUserToDeleteRows = false;
            this.DataGridView_Principal.AllowUserToResizeColumns = false;
            this.DataGridView_Principal.AllowUserToResizeRows = false;
            this.DataGridView_Principal.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView_Principal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_Principal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_Principal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Principal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columna_Imagen,
            this.Columna_Donante,
            this.Columna_Fecha,
            this.Columna_Cantidad,
            this.Columna_Moneda});
            this.DataGridView_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView_Principal.Location = new System.Drawing.Point(0, 0);
            this.DataGridView_Principal.MultiSelect = false;
            this.DataGridView_Principal.Name = "DataGridView_Principal";
            this.DataGridView_Principal.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_Principal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView_Principal.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_Principal.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridView_Principal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Principal.Size = new System.Drawing.Size(484, 211);
            this.DataGridView_Principal.TabIndex = 0;
            this.DataGridView_Principal.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView_Principal_DataError);
            this.DataGridView_Principal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Donaciones_KeyDown);
            // 
            // Columna_Imagen
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            this.Columna_Imagen.DefaultCellStyle = dataGridViewCellStyle2;
            this.Columna_Imagen.HeaderText = "";
            this.Columna_Imagen.Name = "Columna_Imagen";
            this.Columna_Imagen.ReadOnly = true;
            this.Columna_Imagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Columna_Imagen.Width = 16;
            // 
            // Columna_Donante
            // 
            this.Columna_Donante.HeaderText = "Donator";
            this.Columna_Donante.Name = "Columna_Donante";
            this.Columna_Donante.ReadOnly = true;
            // 
            // Columna_Fecha
            // 
            this.Columna_Fecha.HeaderText = "Date";
            this.Columna_Fecha.Name = "Columna_Fecha";
            this.Columna_Fecha.ReadOnly = true;
            // 
            // Columna_Cantidad
            // 
            this.Columna_Cantidad.HeaderText = "Quantity";
            this.Columna_Cantidad.Name = "Columna_Cantidad";
            this.Columna_Cantidad.ReadOnly = true;
            // 
            // Columna_Moneda
            // 
            this.Columna_Moneda.HeaderText = "Currency";
            this.Columna_Moneda.Name = "Columna_Moneda";
            this.Columna_Moneda.ReadOnly = true;
            // 
            // Ventana_Donaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.DataGridView_Principal);
            this.DoubleBuffered = true;
            this.Name = "Ventana_Donaciones";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Donations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ventana_Donaciones_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ventana_Donaciones_FormClosed);
            this.Load += new System.EventHandler(this.Ventana_Donaciones_Load);
            this.Shown += new System.EventHandler(this.Ventana_Donaciones_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Donaciones_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Principal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView_Principal;
        private System.Windows.Forms.DataGridViewImageColumn Columna_Imagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Donante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Moneda;
    }
}
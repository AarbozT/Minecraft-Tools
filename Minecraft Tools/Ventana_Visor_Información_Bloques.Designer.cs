namespace Minecraft_Tools
{
    partial class Ventana_Visor_Información_Bloques
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana_Visor_Información_Bloques));
            this.Barra_Estado = new System.Windows.Forms.ToolStrip();
            this.Barra_Estado_Botón_Excepción = new System.Windows.Forms.ToolStripButton();
            this.Barra_Estado_Separador_1 = new System.Windows.Forms.ToolStripSeparator();
            this.Barra_Estado_Etiqueta_CPU = new System.Windows.Forms.ToolStripLabel();
            this.Barra_Estado_Separador_2 = new System.Windows.Forms.ToolStripSeparator();
            this.Barra_Estado_Etiqueta_Memoria = new System.Windows.Forms.ToolStripLabel();
            this.Barra_Estado_Separador_3 = new System.Windows.Forms.ToolStripSeparator();
            this.Barra_Estado_Etiqueta_FPS = new System.Windows.Forms.ToolStripLabel();
            this.Barra_Estado_Separador_4 = new System.Windows.Forms.ToolStripSeparator();
            this.Barra_Estado_Etiqueta_Sugerencia = new System.Windows.Forms.ToolStripLabel();
            this.Barra_Estado_Separador_5 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menú_Contextual_Visor_Ayuda = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Acerca = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Depurador_Excepciones = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Abrir_Carpeta = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_1 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_Restablecer_Tonos = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Aleatorizar_Tonos = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Voltear_Notas_Horizontalmente = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Voltear_Notas_Verticalmente = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_2 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_Copiar = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_3 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_Guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.Temporizador_Principal = new System.Windows.Forms.Timer(this.components);
            this.DataGridView_Principal = new System.Windows.Forms.DataGridView();
            this.Columna_Icono = new System.Windows.Forms.DataGridViewImageColumn();
            this.Columna_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Nombre_1_13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Código_Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Dimensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Obtención = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Transparencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columna_Obsoleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barra_Estado.SuspendLayout();
            this.Menú_Contextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Principal)).BeginInit();
            this.SuspendLayout();
            // 
            // Barra_Estado
            // 
            this.Barra_Estado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Barra_Estado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Barra_Estado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Barra_Estado_Botón_Excepción,
            this.Barra_Estado_Separador_1,
            this.Barra_Estado_Etiqueta_CPU,
            this.Barra_Estado_Separador_2,
            this.Barra_Estado_Etiqueta_Memoria,
            this.Barra_Estado_Separador_3,
            this.Barra_Estado_Etiqueta_FPS,
            this.Barra_Estado_Separador_4,
            this.Barra_Estado_Etiqueta_Sugerencia,
            this.Barra_Estado_Separador_5});
            this.Barra_Estado.Location = new System.Drawing.Point(0, 436);
            this.Barra_Estado.Name = "Barra_Estado";
            this.Barra_Estado.Size = new System.Drawing.Size(884, 25);
            this.Barra_Estado.TabIndex = 41;
            this.Barra_Estado.Text = "Status bar";
            // 
            // Barra_Estado_Botón_Excepción
            // 
            this.Barra_Estado_Botón_Excepción.AutoToolTip = false;
            this.Barra_Estado_Botón_Excepción.Image = global::Minecraft_Tools.Properties.Resources.Excepción_Gris;
            this.Barra_Estado_Botón_Excepción.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.Barra_Estado_Botón_Excepción.Name = "Barra_Estado_Botón_Excepción";
            this.Barra_Estado_Botón_Excepción.Size = new System.Drawing.Size(95, 22);
            this.Barra_Estado_Botón_Excepción.Text = "Exceptions: 0";
            this.Barra_Estado_Botón_Excepción.Visible = false;
            this.Barra_Estado_Botón_Excepción.Click += new System.EventHandler(this.Barra_Estado_Botón_Excepción_Click);
            // 
            // Barra_Estado_Separador_1
            // 
            this.Barra_Estado_Separador_1.Name = "Barra_Estado_Separador_1";
            this.Barra_Estado_Separador_1.Size = new System.Drawing.Size(6, 25);
            this.Barra_Estado_Separador_1.Visible = false;
            // 
            // Barra_Estado_Etiqueta_CPU
            // 
            this.Barra_Estado_Etiqueta_CPU.Image = global::Minecraft_Tools.Properties.Resources.Procesador;
            this.Barra_Estado_Etiqueta_CPU.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.Barra_Estado_Etiqueta_CPU.Name = "Barra_Estado_Etiqueta_CPU";
            this.Barra_Estado_Etiqueta_CPU.Size = new System.Drawing.Size(71, 22);
            this.Barra_Estado_Etiqueta_CPU.Text = "CPU: 0 %";
            // 
            // Barra_Estado_Separador_2
            // 
            this.Barra_Estado_Separador_2.Name = "Barra_Estado_Separador_2";
            this.Barra_Estado_Separador_2.Size = new System.Drawing.Size(6, 25);
            // 
            // Barra_Estado_Etiqueta_Memoria
            // 
            this.Barra_Estado_Etiqueta_Memoria.Image = global::Minecraft_Tools.Properties.Resources.Memoria;
            this.Barra_Estado_Etiqueta_Memoria.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.Barra_Estado_Etiqueta_Memoria.Name = "Barra_Estado_Etiqueta_Memoria";
            this.Barra_Estado_Etiqueta_Memoria.Size = new System.Drawing.Size(82, 22);
            this.Barra_Estado_Etiqueta_Memoria.Text = "RAM: 0 MB";
            // 
            // Barra_Estado_Separador_3
            // 
            this.Barra_Estado_Separador_3.Name = "Barra_Estado_Separador_3";
            this.Barra_Estado_Separador_3.Size = new System.Drawing.Size(6, 25);
            // 
            // Barra_Estado_Etiqueta_FPS
            // 
            this.Barra_Estado_Etiqueta_FPS.Image = global::Minecraft_Tools.Properties.Resources.Temporizador;
            this.Barra_Estado_Etiqueta_FPS.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.Barra_Estado_Etiqueta_FPS.Name = "Barra_Estado_Etiqueta_FPS";
            this.Barra_Estado_Etiqueta_FPS.Size = new System.Drawing.Size(54, 22);
            this.Barra_Estado_Etiqueta_FPS.Text = "FPS: 0";
            // 
            // Barra_Estado_Separador_4
            // 
            this.Barra_Estado_Separador_4.Name = "Barra_Estado_Separador_4";
            this.Barra_Estado_Separador_4.Size = new System.Drawing.Size(6, 25);
            // 
            // Barra_Estado_Etiqueta_Sugerencia
            // 
            this.Barra_Estado_Etiqueta_Sugerencia.Image = global::Minecraft_Tools.Properties.Resources.Ayuda;
            this.Barra_Estado_Etiqueta_Sugerencia.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.Barra_Estado_Etiqueta_Sugerencia.Name = "Barra_Estado_Etiqueta_Sugerencia";
            this.Barra_Estado_Etiqueta_Sugerencia.Size = new System.Drawing.Size(561, 22);
            this.Barra_Estado_Etiqueta_Sugerencia.Text = "Tip: soon the information of all the blocks will be complete, so please keep an e" +
    "ye for any new update.";
            // 
            // Barra_Estado_Separador_5
            // 
            this.Barra_Estado_Separador_5.Name = "Barra_Estado_Separador_5";
            this.Barra_Estado_Separador_5.Size = new System.Drawing.Size(6, 25);
            // 
            // Menú_Contextual
            // 
            this.Menú_Contextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menú_Contextual_Visor_Ayuda,
            this.Menú_Contextual_Acerca,
            this.Menú_Contextual_Depurador_Excepciones,
            this.Menú_Contextual_Abrir_Carpeta,
            this.Menú_Contextual_Separador_1,
            this.Menú_Contextual_Restablecer_Tonos,
            this.Menú_Contextual_Aleatorizar_Tonos,
            this.Menú_Contextual_Voltear_Notas_Horizontalmente,
            this.Menú_Contextual_Voltear_Notas_Verticalmente,
            this.Menú_Contextual_Separador_2,
            this.Menú_Contextual_Copiar,
            this.Menú_Contextual_Separador_3,
            this.Menú_Contextual_Guardar});
            this.Menú_Contextual.Name = "Menú_Contextual";
            this.Menú_Contextual.Size = new System.Drawing.Size(285, 242);
            // 
            // Menú_Contextual_Visor_Ayuda
            // 
            this.Menú_Contextual_Visor_Ayuda.Image = global::Minecraft_Tools.Properties.Resources.Ayuda;
            this.Menú_Contextual_Visor_Ayuda.Name = "Menú_Contextual_Visor_Ayuda";
            this.Menú_Contextual_Visor_Ayuda.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.Menú_Contextual_Visor_Ayuda.Size = new System.Drawing.Size(284, 22);
            this.Menú_Contextual_Visor_Ayuda.Text = "Help viewer...";
            // 
            // Menú_Contextual_Acerca
            // 
            this.Menú_Contextual_Acerca.Image = global::Minecraft_Tools.Properties.Resources.Jupisoft_16;
            this.Menú_Contextual_Acerca.Name = "Menú_Contextual_Acerca";
            this.Menú_Contextual_Acerca.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.Menú_Contextual_Acerca.Size = new System.Drawing.Size(284, 22);
            this.Menú_Contextual_Acerca.Text = "About...";
            // 
            // Menú_Contextual_Depurador_Excepciones
            // 
            this.Menú_Contextual_Depurador_Excepciones.Image = global::Minecraft_Tools.Properties.Resources.Excepción;
            this.Menú_Contextual_Depurador_Excepciones.Name = "Menú_Contextual_Depurador_Excepciones";
            this.Menú_Contextual_Depurador_Excepciones.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.Menú_Contextual_Depurador_Excepciones.Size = new System.Drawing.Size(284, 22);
            this.Menú_Contextual_Depurador_Excepciones.Text = "Exception debugger...";
            // 
            // Menú_Contextual_Abrir_Carpeta
            // 
            this.Menú_Contextual_Abrir_Carpeta.Image = global::Minecraft_Tools.Properties.Resources.Ejecutar;
            this.Menú_Contextual_Abrir_Carpeta.Name = "Menú_Contextual_Abrir_Carpeta";
            this.Menú_Contextual_Abrir_Carpeta.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.Menú_Contextual_Abrir_Carpeta.Size = new System.Drawing.Size(284, 22);
            this.Menú_Contextual_Abrir_Carpeta.Text = "Open the default save folder...";
            // 
            // Menú_Contextual_Separador_1
            // 
            this.Menú_Contextual_Separador_1.Name = "Menú_Contextual_Separador_1";
            this.Menú_Contextual_Separador_1.Size = new System.Drawing.Size(281, 6);
            // 
            // Menú_Contextual_Restablecer_Tonos
            // 
            this.Menú_Contextual_Restablecer_Tonos.Image = global::Minecraft_Tools.Properties.Resources.Restablecer;
            this.Menú_Contextual_Restablecer_Tonos.Name = "Menú_Contextual_Restablecer_Tonos";
            this.Menú_Contextual_Restablecer_Tonos.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.Menú_Contextual_Restablecer_Tonos.Size = new System.Drawing.Size(284, 22);
            this.Menú_Contextual_Restablecer_Tonos.Text = "Restore the pitch of all the notes";
            // 
            // Menú_Contextual_Aleatorizar_Tonos
            // 
            this.Menú_Contextual_Aleatorizar_Tonos.Image = global::Minecraft_Tools.Properties.Resources.Aleatorio;
            this.Menú_Contextual_Aleatorizar_Tonos.Name = "Menú_Contextual_Aleatorizar_Tonos";
            this.Menú_Contextual_Aleatorizar_Tonos.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.Menú_Contextual_Aleatorizar_Tonos.Size = new System.Drawing.Size(284, 22);
            this.Menú_Contextual_Aleatorizar_Tonos.Text = "Randomize the pitch of all the notes";
            // 
            // Menú_Contextual_Voltear_Notas_Horizontalmente
            // 
            this.Menú_Contextual_Voltear_Notas_Horizontalmente.CheckOnClick = true;
            this.Menú_Contextual_Voltear_Notas_Horizontalmente.Name = "Menú_Contextual_Voltear_Notas_Horizontalmente";
            this.Menú_Contextual_Voltear_Notas_Horizontalmente.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.Menú_Contextual_Voltear_Notas_Horizontalmente.Size = new System.Drawing.Size(284, 22);
            this.Menú_Contextual_Voltear_Notas_Horizontalmente.Text = "Randomly flip the notes horizontally";
            // 
            // Menú_Contextual_Voltear_Notas_Verticalmente
            // 
            this.Menú_Contextual_Voltear_Notas_Verticalmente.CheckOnClick = true;
            this.Menú_Contextual_Voltear_Notas_Verticalmente.Name = "Menú_Contextual_Voltear_Notas_Verticalmente";
            this.Menú_Contextual_Voltear_Notas_Verticalmente.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.Menú_Contextual_Voltear_Notas_Verticalmente.Size = new System.Drawing.Size(284, 22);
            this.Menú_Contextual_Voltear_Notas_Verticalmente.Text = "Randomly flip the notes vertically";
            // 
            // Menú_Contextual_Separador_2
            // 
            this.Menú_Contextual_Separador_2.Name = "Menú_Contextual_Separador_2";
            this.Menú_Contextual_Separador_2.Size = new System.Drawing.Size(281, 6);
            // 
            // Menú_Contextual_Copiar
            // 
            this.Menú_Contextual_Copiar.Image = global::Minecraft_Tools.Properties.Resources.Copiar;
            this.Menú_Contextual_Copiar.Name = "Menú_Contextual_Copiar";
            this.Menú_Contextual_Copiar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Menú_Contextual_Copiar.Size = new System.Drawing.Size(284, 22);
            this.Menú_Contextual_Copiar.Text = "Copy as an image";
            // 
            // Menú_Contextual_Separador_3
            // 
            this.Menú_Contextual_Separador_3.Name = "Menú_Contextual_Separador_3";
            this.Menú_Contextual_Separador_3.Size = new System.Drawing.Size(281, 6);
            // 
            // Menú_Contextual_Guardar
            // 
            this.Menú_Contextual_Guardar.Image = global::Minecraft_Tools.Properties.Resources.Guardar;
            this.Menú_Contextual_Guardar.Name = "Menú_Contextual_Guardar";
            this.Menú_Contextual_Guardar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Menú_Contextual_Guardar.Size = new System.Drawing.Size(284, 22);
            this.Menú_Contextual_Guardar.Text = "Save as a PNG image";
            // 
            // Temporizador_Principal
            // 
            this.Temporizador_Principal.Interval = 1;
            this.Temporizador_Principal.Tick += new System.EventHandler(this.Temporizador_Principal_Tick);
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
            this.Columna_Icono,
            this.Columna_Nombre,
            this.Columna_Nombre_1_13,
            this.Columna_ID,
            this.Columna_Data,
            this.Columna_Color,
            this.Columna_Código_Hash,
            this.Columna_Dimensions,
            this.Columna_Obtención,
            this.Columna_Transparencia,
            this.Columna_Obsoleto});
            this.DataGridView_Principal.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.DataGridView_Principal.Size = new System.Drawing.Size(884, 436);
            this.DataGridView_Principal.TabIndex = 0;
            this.DataGridView_Principal.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView_Principal_DataError);
            this.DataGridView_Principal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Visor_Información_Entidades_KeyDown);
            // 
            // Columna_Icono
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            this.Columna_Icono.DefaultCellStyle = dataGridViewCellStyle2;
            this.Columna_Icono.HeaderText = "";
            this.Columna_Icono.Name = "Columna_Icono";
            this.Columna_Icono.ReadOnly = true;
            this.Columna_Icono.Width = 16;
            // 
            // Columna_Nombre
            // 
            this.Columna_Nombre.HeaderText = "Name";
            this.Columna_Nombre.Name = "Columna_Nombre";
            this.Columna_Nombre.ReadOnly = true;
            // 
            // Columna_Nombre_1_13
            // 
            this.Columna_Nombre_1_13.HeaderText = "1.13+ name";
            this.Columna_Nombre_1_13.Name = "Columna_Nombre_1_13";
            this.Columna_Nombre_1_13.ReadOnly = true;
            // 
            // Columna_ID
            // 
            this.Columna_ID.HeaderText = "1.12- ID";
            this.Columna_ID.Name = "Columna_ID";
            this.Columna_ID.ReadOnly = true;
            // 
            // Columna_Data
            // 
            this.Columna_Data.HeaderText = "1.12- Data";
            this.Columna_Data.Name = "Columna_Data";
            this.Columna_Data.ReadOnly = true;
            // 
            // Columna_Color
            // 
            this.Columna_Color.HeaderText = "Average color";
            this.Columna_Color.Name = "Columna_Color";
            this.Columna_Color.ReadOnly = true;
            // 
            // Columna_Código_Hash
            // 
            this.Columna_Código_Hash.HeaderText = "Hash code";
            this.Columna_Código_Hash.Name = "Columna_Código_Hash";
            this.Columna_Código_Hash.ReadOnly = true;
            // 
            // Columna_Dimensions
            // 
            this.Columna_Dimensions.HeaderText = "Dimensions";
            this.Columna_Dimensions.Name = "Columna_Dimensions";
            this.Columna_Dimensions.ReadOnly = true;
            // 
            // Columna_Obtención
            // 
            this.Columna_Obtención.HeaderText = "Obtention";
            this.Columna_Obtención.Name = "Columna_Obtención";
            this.Columna_Obtención.ReadOnly = true;
            // 
            // Columna_Transparencia
            // 
            this.Columna_Transparencia.HeaderText = "Transparency";
            this.Columna_Transparencia.Name = "Columna_Transparencia";
            this.Columna_Transparencia.ReadOnly = true;
            // 
            // Columna_Obsoleto
            // 
            this.Columna_Obsoleto.HeaderText = "Obsolete";
            this.Columna_Obsoleto.Name = "Columna_Obsoleto";
            this.Columna_Obsoleto.ReadOnly = true;
            // 
            // Ventana_Visor_Información_Bloques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.ContextMenuStrip = this.Menú_Contextual;
            this.Controls.Add(this.DataGridView_Principal);
            this.Controls.Add(this.Barra_Estado);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ventana_Visor_Información_Bloques";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Block Information Viewer by Jupisoft";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ventana_Visor_Información_Entidades_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ventana_Visor_Información_Entidades_FormClosed);
            this.Load += new System.EventHandler(this.Ventana_Visor_Información_Entidades_Load);
            this.Shown += new System.EventHandler(this.Ventana_Visor_Información_Entidades_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Visor_Información_Entidades_KeyDown);
            this.Barra_Estado.ResumeLayout(false);
            this.Barra_Estado.PerformLayout();
            this.Menú_Contextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Principal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Barra_Estado;
        private System.Windows.Forms.ToolStripButton Barra_Estado_Botón_Excepción;
        private System.Windows.Forms.ToolStripSeparator Barra_Estado_Separador_1;
        private System.Windows.Forms.ToolStripLabel Barra_Estado_Etiqueta_CPU;
        private System.Windows.Forms.ToolStripSeparator Barra_Estado_Separador_2;
        private System.Windows.Forms.ToolStripLabel Barra_Estado_Etiqueta_Memoria;
        private System.Windows.Forms.ToolStripSeparator Barra_Estado_Separador_3;
        private System.Windows.Forms.ToolStripLabel Barra_Estado_Etiqueta_FPS;
        private System.Windows.Forms.ToolStripSeparator Barra_Estado_Separador_4;
        private System.Windows.Forms.ToolStripLabel Barra_Estado_Etiqueta_Sugerencia;
        private System.Windows.Forms.ToolStripSeparator Barra_Estado_Separador_5;
        private System.Windows.Forms.ContextMenuStrip Menú_Contextual;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Visor_Ayuda;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Acerca;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Depurador_Excepciones;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Abrir_Carpeta;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_1;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Restablecer_Tonos;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Aleatorizar_Tonos;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Voltear_Notas_Horizontalmente;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Voltear_Notas_Verticalmente;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_2;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Copiar;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_3;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Guardar;
        private System.Windows.Forms.Timer Temporizador_Principal;
        private System.Windows.Forms.DataGridView DataGridView_Principal;
        private System.Windows.Forms.DataGridViewImageColumn Columna_Icono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Nombre_1_13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Código_Hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Dimensions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Obtención;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Transparencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columna_Obsoleto;
    }
}
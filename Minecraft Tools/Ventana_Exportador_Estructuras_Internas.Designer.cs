﻿namespace Minecraft_Tools
{
    partial class Ventana_Exportador_Estructuras_Internas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana_Exportador_Estructuras_Internas));
            this.Menú_Contextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menú_Contextual_Visor_Ayuda = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Acerca = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Depurador_Excepciones = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Abrir_Carpeta = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_1 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_Actualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_6 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_7 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_8 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_2 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_9 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_10 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_11 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_12 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_3 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_Copiar = new System.Windows.Forms.ToolStripMenuItem();
            this.Menú_Contextual_Separador_4 = new System.Windows.Forms.ToolStripSeparator();
            this.Menú_Contextual_Guardar = new System.Windows.Forms.ToolStripMenuItem();
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
            this.Temporizador_Principal = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Etiqueta_Ruta = new System.Windows.Forms.Label();
            this.Botón_Exportar = new System.Windows.Forms.Button();
            this.Barra_Progreso = new System.Windows.Forms.ProgressBar();
            this.ComboBox_Ruta = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Etiqueta_Información = new System.Windows.Forms.Label();
            this.Menú_Contextual.SuspendLayout();
            this.Barra_Estado.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menú_Contextual
            // 
            this.Menú_Contextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menú_Contextual_Visor_Ayuda,
            this.Menú_Contextual_Acerca,
            this.Menú_Contextual_Depurador_Excepciones,
            this.Menú_Contextual_Abrir_Carpeta,
            this.Menú_Contextual_Separador_1,
            this.Menú_Contextual_Actualizar,
            this.Menú_Contextual_6,
            this.Menú_Contextual_7,
            this.Menú_Contextual_8,
            this.Menú_Contextual_Separador_2,
            this.Menú_Contextual_9,
            this.Menú_Contextual_10,
            this.Menú_Contextual_11,
            this.Menú_Contextual_12,
            this.Menú_Contextual_Separador_3,
            this.Menú_Contextual_Copiar,
            this.Menú_Contextual_Separador_4,
            this.Menú_Contextual_Guardar});
            this.Menú_Contextual.Name = "Menú_Contextual";
            this.Menú_Contextual.Size = new System.Drawing.Size(252, 336);
            // 
            // Menú_Contextual_Visor_Ayuda
            // 
            this.Menú_Contextual_Visor_Ayuda.Image = global::Minecraft_Tools.Properties.Resources.Ayuda;
            this.Menú_Contextual_Visor_Ayuda.Name = "Menú_Contextual_Visor_Ayuda";
            this.Menú_Contextual_Visor_Ayuda.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.Menú_Contextual_Visor_Ayuda.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_Visor_Ayuda.Text = "Help viewer...";
            this.Menú_Contextual_Visor_Ayuda.Click += new System.EventHandler(this.Menú_Contextual_Visor_Ayuda_Click);
            // 
            // Menú_Contextual_Acerca
            // 
            this.Menú_Contextual_Acerca.Image = global::Minecraft_Tools.Properties.Resources.Jupisoft_16;
            this.Menú_Contextual_Acerca.Name = "Menú_Contextual_Acerca";
            this.Menú_Contextual_Acerca.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.Menú_Contextual_Acerca.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_Acerca.Text = "About...";
            this.Menú_Contextual_Acerca.Click += new System.EventHandler(this.Menú_Contextual_Acerca_Click);
            // 
            // Menú_Contextual_Depurador_Excepciones
            // 
            this.Menú_Contextual_Depurador_Excepciones.Image = global::Minecraft_Tools.Properties.Resources.Excepción;
            this.Menú_Contextual_Depurador_Excepciones.Name = "Menú_Contextual_Depurador_Excepciones";
            this.Menú_Contextual_Depurador_Excepciones.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.Menú_Contextual_Depurador_Excepciones.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_Depurador_Excepciones.Text = "Exception debugger...";
            this.Menú_Contextual_Depurador_Excepciones.Click += new System.EventHandler(this.Menú_Contextual_Depurador_Excepciones_Click);
            // 
            // Menú_Contextual_Abrir_Carpeta
            // 
            this.Menú_Contextual_Abrir_Carpeta.Image = global::Minecraft_Tools.Properties.Resources.Ejecutar;
            this.Menú_Contextual_Abrir_Carpeta.Name = "Menú_Contextual_Abrir_Carpeta";
            this.Menú_Contextual_Abrir_Carpeta.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.Menú_Contextual_Abrir_Carpeta.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_Abrir_Carpeta.Text = "Open the default save folder...";
            this.Menú_Contextual_Abrir_Carpeta.Click += new System.EventHandler(this.Menú_Contextual_Abrir_Carpeta_Click);
            // 
            // Menú_Contextual_Separador_1
            // 
            this.Menú_Contextual_Separador_1.Name = "Menú_Contextual_Separador_1";
            this.Menú_Contextual_Separador_1.Size = new System.Drawing.Size(248, 6);
            // 
            // Menú_Contextual_Actualizar
            // 
            this.Menú_Contextual_Actualizar.Image = global::Minecraft_Tools.Properties.Resources.Actualizar;
            this.Menú_Contextual_Actualizar.Name = "Menú_Contextual_Actualizar";
            this.Menú_Contextual_Actualizar.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.Menú_Contextual_Actualizar.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_Actualizar.Text = "Refresh";
            this.Menú_Contextual_Actualizar.Click += new System.EventHandler(this.Menú_Contextual_Actualizar_Click);
            // 
            // Menú_Contextual_6
            // 
            this.Menú_Contextual_6.Checked = true;
            this.Menú_Contextual_6.CheckOnClick = true;
            this.Menú_Contextual_6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menú_Contextual_6.Name = "Menú_Contextual_6";
            this.Menú_Contextual_6.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.Menú_Contextual_6.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_6.Text = "Soon...";
            // 
            // Menú_Contextual_7
            // 
            this.Menú_Contextual_7.Checked = true;
            this.Menú_Contextual_7.CheckOnClick = true;
            this.Menú_Contextual_7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menú_Contextual_7.Name = "Menú_Contextual_7";
            this.Menú_Contextual_7.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.Menú_Contextual_7.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_7.Text = "Soon...";
            // 
            // Menú_Contextual_8
            // 
            this.Menú_Contextual_8.Checked = true;
            this.Menú_Contextual_8.CheckOnClick = true;
            this.Menú_Contextual_8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menú_Contextual_8.Name = "Menú_Contextual_8";
            this.Menú_Contextual_8.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.Menú_Contextual_8.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_8.Text = "Soon...";
            // 
            // Menú_Contextual_Separador_2
            // 
            this.Menú_Contextual_Separador_2.Name = "Menú_Contextual_Separador_2";
            this.Menú_Contextual_Separador_2.Size = new System.Drawing.Size(248, 6);
            // 
            // Menú_Contextual_9
            // 
            this.Menú_Contextual_9.Checked = true;
            this.Menú_Contextual_9.CheckOnClick = true;
            this.Menú_Contextual_9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menú_Contextual_9.Name = "Menú_Contextual_9";
            this.Menú_Contextual_9.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.Menú_Contextual_9.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_9.Text = "Soon...";
            // 
            // Menú_Contextual_10
            // 
            this.Menú_Contextual_10.Checked = true;
            this.Menú_Contextual_10.CheckOnClick = true;
            this.Menú_Contextual_10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menú_Contextual_10.Name = "Menú_Contextual_10";
            this.Menú_Contextual_10.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.Menú_Contextual_10.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_10.Text = "Soon...";
            // 
            // Menú_Contextual_11
            // 
            this.Menú_Contextual_11.Checked = true;
            this.Menú_Contextual_11.CheckOnClick = true;
            this.Menú_Contextual_11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menú_Contextual_11.Name = "Menú_Contextual_11";
            this.Menú_Contextual_11.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.Menú_Contextual_11.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_11.Text = "Soon...";
            // 
            // Menú_Contextual_12
            // 
            this.Menú_Contextual_12.Checked = true;
            this.Menú_Contextual_12.CheckOnClick = true;
            this.Menú_Contextual_12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menú_Contextual_12.Name = "Menú_Contextual_12";
            this.Menú_Contextual_12.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.Menú_Contextual_12.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_12.Text = "Soon...";
            // 
            // Menú_Contextual_Separador_3
            // 
            this.Menú_Contextual_Separador_3.Name = "Menú_Contextual_Separador_3";
            this.Menú_Contextual_Separador_3.Size = new System.Drawing.Size(248, 6);
            // 
            // Menú_Contextual_Copiar
            // 
            this.Menú_Contextual_Copiar.Image = global::Minecraft_Tools.Properties.Resources.Copiar;
            this.Menú_Contextual_Copiar.Name = "Menú_Contextual_Copiar";
            this.Menú_Contextual_Copiar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Menú_Contextual_Copiar.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_Copiar.Text = "Copy";
            this.Menú_Contextual_Copiar.Click += new System.EventHandler(this.Menú_Contextual_Copiar_Click);
            // 
            // Menú_Contextual_Separador_4
            // 
            this.Menú_Contextual_Separador_4.Name = "Menú_Contextual_Separador_4";
            this.Menú_Contextual_Separador_4.Size = new System.Drawing.Size(248, 6);
            // 
            // Menú_Contextual_Guardar
            // 
            this.Menú_Contextual_Guardar.Image = global::Minecraft_Tools.Properties.Resources.Guardar;
            this.Menú_Contextual_Guardar.Name = "Menú_Contextual_Guardar";
            this.Menú_Contextual_Guardar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Menú_Contextual_Guardar.Size = new System.Drawing.Size(251, 22);
            this.Menú_Contextual_Guardar.Text = "Save";
            this.Menú_Contextual_Guardar.Click += new System.EventHandler(this.Menú_Contextual_Guardar_Click);
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
            this.Barra_Estado.TabIndex = 5;
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
            this.Barra_Estado_Etiqueta_Sugerencia.Size = new System.Drawing.Size(677, 16);
            this.Barra_Estado_Etiqueta_Sugerencia.Text = "Tip: exports at once all the NBT structure files found in the selected path and i" +
    "t\'s subfolders as a new 1.12.2- Minecraft world.";
            // 
            // Barra_Estado_Separador_5
            // 
            this.Barra_Estado_Separador_5.Name = "Barra_Estado_Separador_5";
            this.Barra_Estado_Separador_5.Size = new System.Drawing.Size(6, 25);
            // 
            // Temporizador_Principal
            // 
            this.Temporizador_Principal.Interval = 1;
            this.Temporizador_Principal.Tick += new System.EventHandler(this.Temporizador_Principal_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(852, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(20, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // Etiqueta_Ruta
            // 
            this.Etiqueta_Ruta.AutoSize = true;
            this.Etiqueta_Ruta.Location = new System.Drawing.Point(9, 15);
            this.Etiqueta_Ruta.Margin = new System.Windows.Forms.Padding(0);
            this.Etiqueta_Ruta.Name = "Etiqueta_Ruta";
            this.Etiqueta_Ruta.Size = new System.Drawing.Size(32, 13);
            this.Etiqueta_Ruta.TabIndex = 0;
            this.Etiqueta_Ruta.Text = "Path:";
            // 
            // Botón_Exportar
            // 
            this.Botón_Exportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Botón_Exportar.Image = global::Minecraft_Tools.Properties.Resources.Minecraft;
            this.Botón_Exportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Exportar.Location = new System.Drawing.Point(772, 10);
            this.Botón_Exportar.Name = "Botón_Exportar";
            this.Botón_Exportar.Size = new System.Drawing.Size(100, 24);
            this.Botón_Exportar.TabIndex = 2;
            this.Botón_Exportar.Text = " Export... ";
            this.Botón_Exportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Exportar.UseVisualStyleBackColor = true;
            this.Botón_Exportar.Click += new System.EventHandler(this.Botón_Exportar_Click);
            this.Botón_Exportar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Exportador_Estructuras_Internas_KeyDown);
            // 
            // Barra_Progreso
            // 
            this.Barra_Progreso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Barra_Progreso.Location = new System.Drawing.Point(0, 416);
            this.Barra_Progreso.Name = "Barra_Progreso";
            this.Barra_Progreso.Size = new System.Drawing.Size(884, 20);
            this.Barra_Progreso.TabIndex = 4;
            // 
            // ComboBox_Ruta
            // 
            this.ComboBox_Ruta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Ruta.BackColor = System.Drawing.Color.White;
            this.ComboBox_Ruta.FormattingEnabled = true;
            this.ComboBox_Ruta.Location = new System.Drawing.Point(44, 11);
            this.ComboBox_Ruta.Name = "ComboBox_Ruta";
            this.ComboBox_Ruta.Size = new System.Drawing.Size(722, 21);
            this.ComboBox_Ruta.TabIndex = 1;
            this.ComboBox_Ruta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Exportador_Estructuras_Internas_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(852, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(20, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Visible = false;
            // 
            // Etiqueta_Información
            // 
            this.Etiqueta_Información.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Etiqueta_Información.Location = new System.Drawing.Point(9, 38);
            this.Etiqueta_Información.Margin = new System.Windows.Forms.Padding(0);
            this.Etiqueta_Información.Name = "Etiqueta_Información";
            this.Etiqueta_Información.Size = new System.Drawing.Size(866, 375);
            this.Etiqueta_Información.TabIndex = 3;
            this.Etiqueta_Información.Text = resources.GetString("Etiqueta_Información.Text");
            this.Etiqueta_Información.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ventana_Exportador_Estructuras_Internas
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.ContextMenuStrip = this.Menú_Contextual;
            this.Controls.Add(this.Etiqueta_Información);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.ComboBox_Ruta);
            this.Controls.Add(this.Barra_Progreso);
            this.Controls.Add(this.Etiqueta_Ruta);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Barra_Estado);
            this.Controls.Add(this.Botón_Exportar);
            this.DoubleBuffered = true;
            this.Name = "Ventana_Exportador_Estructuras_Internas";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Internal Structures Exporter by Jupisoft";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ventana_Exportador_Estructuras_Internas_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ventana_Exportador_Estructuras_Internas_FormClosed);
            this.Load += new System.EventHandler(this.Ventana_Exportador_Estructuras_Internas_Load);
            this.Shown += new System.EventHandler(this.Ventana_Exportador_Estructuras_Internas_Shown);
            this.SizeChanged += new System.EventHandler(this.Ventana_Exportador_Estructuras_Internas_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Ventana_Exportador_Estructuras_Internas_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Ventana_Exportador_Estructuras_Internas_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Exportador_Estructuras_Internas_KeyDown);
            this.Menú_Contextual.ResumeLayout(false);
            this.Barra_Estado.ResumeLayout(false);
            this.Barra_Estado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip Menú_Contextual;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Visor_Ayuda;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Acerca;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Depurador_Excepciones;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Abrir_Carpeta;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_1;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Actualizar;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_6;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_7;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_8;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_2;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_9;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_10;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_11;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_12;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_3;
        private System.Windows.Forms.ToolStripSeparator Menú_Contextual_Separador_4;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Copiar;
        private System.Windows.Forms.ToolStripMenuItem Menú_Contextual_Guardar;
        private System.Windows.Forms.ToolStrip Barra_Estado;
        private System.Windows.Forms.ToolStripButton Barra_Estado_Botón_Excepción;
        private System.Windows.Forms.ToolStripSeparator Barra_Estado_Separador_1;
        private System.Windows.Forms.ToolStripLabel Barra_Estado_Etiqueta_CPU;
        private System.Windows.Forms.ToolStripSeparator Barra_Estado_Separador_2;
        private System.Windows.Forms.ToolStripLabel Barra_Estado_Etiqueta_Memoria;
        private System.Windows.Forms.ToolStripSeparator Barra_Estado_Separador_3;
        private System.Windows.Forms.ToolStripLabel Barra_Estado_Etiqueta_FPS;
        private System.Windows.Forms.ToolStripSeparator Barra_Estado_Separador_4;
        private System.Windows.Forms.ToolStripSeparator Barra_Estado_Separador_5;
        private System.Windows.Forms.ToolStripLabel Barra_Estado_Etiqueta_Sugerencia;
        private System.Windows.Forms.Timer Temporizador_Principal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Etiqueta_Ruta;
        private System.Windows.Forms.Button Botón_Exportar;
        private System.Windows.Forms.ProgressBar Barra_Progreso;
        private System.Windows.Forms.ComboBox ComboBox_Ruta;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Etiqueta_Información;
    }
}
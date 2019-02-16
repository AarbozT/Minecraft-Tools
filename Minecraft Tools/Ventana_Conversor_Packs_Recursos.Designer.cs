namespace Minecraft_Tools
{
    partial class Ventana_Conversor_Packs_Recursos
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
            this.Grupo_Principal = new System.Windows.Forms.GroupBox();
            this.Botón_Cargar_Archivos = new System.Windows.Forms.Button();
            this.ComboBox_Carpetas = new System.Windows.Forms.ComboBox();
            this.Botón_Cargar_Carpetas = new System.Windows.Forms.Button();
            this.Grupo_Faithful_1_13_1 = new System.Windows.Forms.GroupBox();
            this.TextBox_Faithful_1_13_1 = new System.Windows.Forms.TextBox();
            this.Grupo_Minecraft_1_12_2 = new System.Windows.Forms.GroupBox();
            this.TextBox_Minecraft_1_12_2 = new System.Windows.Forms.TextBox();
            this.Grupo_Minecraft_1_13_1 = new System.Windows.Forms.GroupBox();
            this.TextBox_Minecraft_1_13_1 = new System.Windows.Forms.TextBox();
            this.Grupo_Faithful_1_12_2 = new System.Windows.Forms.GroupBox();
            this.TextBox_Faithful_1_12_2 = new System.Windows.Forms.TextBox();
            this.Grupo_Principal.SuspendLayout();
            this.Grupo_Faithful_1_13_1.SuspendLayout();
            this.Grupo_Minecraft_1_12_2.SuspendLayout();
            this.Grupo_Minecraft_1_13_1.SuspendLayout();
            this.Grupo_Faithful_1_12_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grupo_Principal
            // 
            this.Grupo_Principal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grupo_Principal.Controls.Add(this.Botón_Cargar_Archivos);
            this.Grupo_Principal.Controls.Add(this.ComboBox_Carpetas);
            this.Grupo_Principal.Controls.Add(this.Botón_Cargar_Carpetas);
            this.Grupo_Principal.Controls.Add(this.Grupo_Faithful_1_13_1);
            this.Grupo_Principal.Controls.Add(this.Grupo_Minecraft_1_12_2);
            this.Grupo_Principal.Controls.Add(this.Grupo_Minecraft_1_13_1);
            this.Grupo_Principal.Controls.Add(this.Grupo_Faithful_1_12_2);
            this.Grupo_Principal.Location = new System.Drawing.Point(12, 12);
            this.Grupo_Principal.Name = "Grupo_Principal";
            this.Grupo_Principal.Size = new System.Drawing.Size(860, 537);
            this.Grupo_Principal.TabIndex = 0;
            this.Grupo_Principal.TabStop = false;
            this.Grupo_Principal.Text = "These controls should only be used by a programmer, not by a regular user";
            // 
            // Botón_Cargar_Archivos
            // 
            this.Botón_Cargar_Archivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Botón_Cargar_Archivos.Image = global::Minecraft_Tools.Properties.Resources.Ordenar;
            this.Botón_Cargar_Archivos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Cargar_Archivos.Location = new System.Drawing.Point(6, 178);
            this.Botón_Cargar_Archivos.Name = "Botón_Cargar_Archivos";
            this.Botón_Cargar_Archivos.Size = new System.Drawing.Size(848, 24);
            this.Botón_Cargar_Archivos.TabIndex = 6;
            this.Botón_Cargar_Archivos.Text = " Load the files list between all the Minecraft versions and resource packs... ";
            this.Botón_Cargar_Archivos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Cargar_Archivos.UseVisualStyleBackColor = true;
            this.Botón_Cargar_Archivos.Click += new System.EventHandler(this.Botón_Cargar_Archivos_Click);
            // 
            // ComboBox_Carpetas
            // 
            this.ComboBox_Carpetas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Carpetas.BackColor = System.Drawing.Color.White;
            this.ComboBox_Carpetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Carpetas.FormattingEnabled = true;
            this.ComboBox_Carpetas.Location = new System.Drawing.Point(6, 151);
            this.ComboBox_Carpetas.Name = "ComboBox_Carpetas";
            this.ComboBox_Carpetas.Size = new System.Drawing.Size(848, 21);
            this.ComboBox_Carpetas.TabIndex = 5;
            // 
            // Botón_Cargar_Carpetas
            // 
            this.Botón_Cargar_Carpetas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Botón_Cargar_Carpetas.Image = global::Minecraft_Tools.Properties.Resources.Ordenar;
            this.Botón_Cargar_Carpetas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Cargar_Carpetas.Location = new System.Drawing.Point(6, 121);
            this.Botón_Cargar_Carpetas.Name = "Botón_Cargar_Carpetas";
            this.Botón_Cargar_Carpetas.Size = new System.Drawing.Size(848, 24);
            this.Botón_Cargar_Carpetas.TabIndex = 4;
            this.Botón_Cargar_Carpetas.Text = " Load the folders list between all the Minecraft versions and resource packs... ";
            this.Botón_Cargar_Carpetas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Cargar_Carpetas.UseVisualStyleBackColor = true;
            this.Botón_Cargar_Carpetas.Click += new System.EventHandler(this.Botón_Cargar_Carpetas_Click);
            // 
            // Grupo_Faithful_1_13_1
            // 
            this.Grupo_Faithful_1_13_1.Controls.Add(this.TextBox_Faithful_1_13_1);
            this.Grupo_Faithful_1_13_1.Location = new System.Drawing.Point(212, 70);
            this.Grupo_Faithful_1_13_1.Name = "Grupo_Faithful_1_13_1";
            this.Grupo_Faithful_1_13_1.Size = new System.Drawing.Size(200, 45);
            this.Grupo_Faithful_1_13_1.TabIndex = 3;
            this.Grupo_Faithful_1_13_1.TabStop = false;
            this.Grupo_Faithful_1_13_1.Text = "Faithful for 1.13.1 resource path";
            this.Grupo_Faithful_1_13_1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Grupos_DragDrop);
            this.Grupo_Faithful_1_13_1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Grupos_DragEnter);
            // 
            // TextBox_Faithful_1_13_1
            // 
            this.TextBox_Faithful_1_13_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Faithful_1_13_1.BackColor = System.Drawing.Color.White;
            this.TextBox_Faithful_1_13_1.Location = new System.Drawing.Point(6, 19);
            this.TextBox_Faithful_1_13_1.Name = "TextBox_Faithful_1_13_1";
            this.TextBox_Faithful_1_13_1.Size = new System.Drawing.Size(188, 20);
            this.TextBox_Faithful_1_13_1.TabIndex = 0;
            // 
            // Grupo_Minecraft_1_12_2
            // 
            this.Grupo_Minecraft_1_12_2.Controls.Add(this.TextBox_Minecraft_1_12_2);
            this.Grupo_Minecraft_1_12_2.Location = new System.Drawing.Point(6, 19);
            this.Grupo_Minecraft_1_12_2.Name = "Grupo_Minecraft_1_12_2";
            this.Grupo_Minecraft_1_12_2.Size = new System.Drawing.Size(200, 45);
            this.Grupo_Minecraft_1_12_2.TabIndex = 0;
            this.Grupo_Minecraft_1_12_2.TabStop = false;
            this.Grupo_Minecraft_1_12_2.Text = "Minecraft 1.12.2 resource path";
            this.Grupo_Minecraft_1_12_2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Grupos_DragDrop);
            this.Grupo_Minecraft_1_12_2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Grupos_DragEnter);
            // 
            // TextBox_Minecraft_1_12_2
            // 
            this.TextBox_Minecraft_1_12_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Minecraft_1_12_2.BackColor = System.Drawing.Color.White;
            this.TextBox_Minecraft_1_12_2.Location = new System.Drawing.Point(6, 19);
            this.TextBox_Minecraft_1_12_2.Name = "TextBox_Minecraft_1_12_2";
            this.TextBox_Minecraft_1_12_2.Size = new System.Drawing.Size(188, 20);
            this.TextBox_Minecraft_1_12_2.TabIndex = 0;
            // 
            // Grupo_Minecraft_1_13_1
            // 
            this.Grupo_Minecraft_1_13_1.Controls.Add(this.TextBox_Minecraft_1_13_1);
            this.Grupo_Minecraft_1_13_1.Location = new System.Drawing.Point(6, 70);
            this.Grupo_Minecraft_1_13_1.Name = "Grupo_Minecraft_1_13_1";
            this.Grupo_Minecraft_1_13_1.Size = new System.Drawing.Size(200, 45);
            this.Grupo_Minecraft_1_13_1.TabIndex = 2;
            this.Grupo_Minecraft_1_13_1.TabStop = false;
            this.Grupo_Minecraft_1_13_1.Text = "Minecraft 1.13.1 resource path";
            this.Grupo_Minecraft_1_13_1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Grupos_DragDrop);
            this.Grupo_Minecraft_1_13_1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Grupos_DragEnter);
            // 
            // TextBox_Minecraft_1_13_1
            // 
            this.TextBox_Minecraft_1_13_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Minecraft_1_13_1.BackColor = System.Drawing.Color.White;
            this.TextBox_Minecraft_1_13_1.Location = new System.Drawing.Point(6, 19);
            this.TextBox_Minecraft_1_13_1.Name = "TextBox_Minecraft_1_13_1";
            this.TextBox_Minecraft_1_13_1.Size = new System.Drawing.Size(188, 20);
            this.TextBox_Minecraft_1_13_1.TabIndex = 0;
            // 
            // Grupo_Faithful_1_12_2
            // 
            this.Grupo_Faithful_1_12_2.Controls.Add(this.TextBox_Faithful_1_12_2);
            this.Grupo_Faithful_1_12_2.Location = new System.Drawing.Point(212, 19);
            this.Grupo_Faithful_1_12_2.Name = "Grupo_Faithful_1_12_2";
            this.Grupo_Faithful_1_12_2.Size = new System.Drawing.Size(200, 45);
            this.Grupo_Faithful_1_12_2.TabIndex = 1;
            this.Grupo_Faithful_1_12_2.TabStop = false;
            this.Grupo_Faithful_1_12_2.Text = "Faithful for 1.12.2 resource path";
            this.Grupo_Faithful_1_12_2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Grupos_DragDrop);
            this.Grupo_Faithful_1_12_2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Grupos_DragEnter);
            // 
            // TextBox_Faithful_1_12_2
            // 
            this.TextBox_Faithful_1_12_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Faithful_1_12_2.BackColor = System.Drawing.Color.White;
            this.TextBox_Faithful_1_12_2.Location = new System.Drawing.Point(6, 19);
            this.TextBox_Faithful_1_12_2.Name = "TextBox_Faithful_1_12_2";
            this.TextBox_Faithful_1_12_2.Size = new System.Drawing.Size(188, 20);
            this.TextBox_Faithful_1_12_2.TabIndex = 0;
            // 
            // Ventana_Conversor_Packs_Recursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.Grupo_Principal);
            this.DoubleBuffered = true;
            this.Name = "Ventana_Conversor_Packs_Recursos";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resource Packs Converter by Jupisoft - [Drag and drop it\'s extracted folders on t" +
    "heir correct places]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ventana_Conversor_Packs_Recursos_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ventana_Conversor_Packs_Recursos_FormClosed);
            this.Load += new System.EventHandler(this.Ventana_Conversor_Packs_Recursos_Load);
            this.Shown += new System.EventHandler(this.Ventana_Conversor_Packs_Recursos_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Conversor_Packs_Recursos_KeyDown);
            this.Grupo_Principal.ResumeLayout(false);
            this.Grupo_Faithful_1_13_1.ResumeLayout(false);
            this.Grupo_Faithful_1_13_1.PerformLayout();
            this.Grupo_Minecraft_1_12_2.ResumeLayout(false);
            this.Grupo_Minecraft_1_12_2.PerformLayout();
            this.Grupo_Minecraft_1_13_1.ResumeLayout(false);
            this.Grupo_Minecraft_1_13_1.PerformLayout();
            this.Grupo_Faithful_1_12_2.ResumeLayout(false);
            this.Grupo_Faithful_1_12_2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo_Principal;
        private System.Windows.Forms.GroupBox Grupo_Minecraft_1_12_2;
        private System.Windows.Forms.TextBox TextBox_Minecraft_1_12_2;
        private System.Windows.Forms.GroupBox Grupo_Faithful_1_12_2;
        private System.Windows.Forms.TextBox TextBox_Faithful_1_12_2;
        private System.Windows.Forms.GroupBox Grupo_Faithful_1_13_1;
        private System.Windows.Forms.TextBox TextBox_Faithful_1_13_1;
        private System.Windows.Forms.GroupBox Grupo_Minecraft_1_13_1;
        private System.Windows.Forms.TextBox TextBox_Minecraft_1_13_1;
        private System.Windows.Forms.Button Botón_Cargar_Carpetas;
        private System.Windows.Forms.ComboBox ComboBox_Carpetas;
        private System.Windows.Forms.Button Botón_Cargar_Archivos;
    }
}
namespace Minecraft_Tools
{
    partial class Ventana_Nombre_Usuario
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Etiqueta_Nombre_Usuario = new System.Windows.Forms.Label();
            this.Botón_Aceptar = new System.Windows.Forms.Button();
            this.Botón_Cancelar = new System.Windows.Forms.Button();
            this.Botón_Restablecer = new System.Windows.Forms.Button();
            this.Botón_Eliminar = new System.Windows.Forms.Button();
            this.ComboBox_Nombre_Usuario = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(452, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(20, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // Etiqueta_Nombre_Usuario
            // 
            this.Etiqueta_Nombre_Usuario.AutoSize = true;
            this.Etiqueta_Nombre_Usuario.Location = new System.Drawing.Point(12, 15);
            this.Etiqueta_Nombre_Usuario.Name = "Etiqueta_Nombre_Usuario";
            this.Etiqueta_Nombre_Usuario.Size = new System.Drawing.Size(61, 13);
            this.Etiqueta_Nombre_Usuario.TabIndex = 5;
            this.Etiqueta_Nombre_Usuario.Text = "User name:";
            // 
            // Botón_Aceptar
            // 
            this.Botón_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Botón_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Botón_Aceptar.Image = global::Minecraft_Tools.Properties.Resources.Aceptar;
            this.Botón_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Aceptar.Location = new System.Drawing.Point(266, 38);
            this.Botón_Aceptar.Name = "Botón_Aceptar";
            this.Botón_Aceptar.Size = new System.Drawing.Size(100, 24);
            this.Botón_Aceptar.TabIndex = 3;
            this.Botón_Aceptar.Text = "Accept ";
            this.Botón_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Aceptar.UseVisualStyleBackColor = true;
            this.Botón_Aceptar.Click += new System.EventHandler(this.Botón_Aceptar_Click);
            this.Botón_Aceptar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Nombre_Usuario_KeyDown);
            // 
            // Botón_Cancelar
            // 
            this.Botón_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Botón_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Botón_Cancelar.Image = global::Minecraft_Tools.Properties.Resources.Cancelar;
            this.Botón_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Cancelar.Location = new System.Drawing.Point(372, 38);
            this.Botón_Cancelar.Name = "Botón_Cancelar";
            this.Botón_Cancelar.Size = new System.Drawing.Size(100, 24);
            this.Botón_Cancelar.TabIndex = 4;
            this.Botón_Cancelar.Text = " Cancel ";
            this.Botón_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Cancelar.UseVisualStyleBackColor = true;
            this.Botón_Cancelar.Click += new System.EventHandler(this.Botón_Cancelar_Click);
            this.Botón_Cancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Nombre_Usuario_KeyDown);
            // 
            // Botón_Restablecer
            // 
            this.Botón_Restablecer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Botón_Restablecer.Image = global::Minecraft_Tools.Properties.Resources.Restablecer;
            this.Botón_Restablecer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Restablecer.Location = new System.Drawing.Point(12, 38);
            this.Botón_Restablecer.Name = "Botón_Restablecer";
            this.Botón_Restablecer.Size = new System.Drawing.Size(100, 24);
            this.Botón_Restablecer.TabIndex = 1;
            this.Botón_Restablecer.Text = " Restore ";
            this.Botón_Restablecer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Restablecer.UseVisualStyleBackColor = true;
            this.Botón_Restablecer.Click += new System.EventHandler(this.Botón_Restablecer_Click);
            this.Botón_Restablecer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Nombre_Usuario_KeyDown);
            // 
            // Botón_Eliminar
            // 
            this.Botón_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Botón_Eliminar.Image = global::Minecraft_Tools.Properties.Resources.Papelera_Reciclaje;
            this.Botón_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Eliminar.Location = new System.Drawing.Point(118, 38);
            this.Botón_Eliminar.Name = "Botón_Eliminar";
            this.Botón_Eliminar.Size = new System.Drawing.Size(100, 24);
            this.Botón_Eliminar.TabIndex = 2;
            this.Botón_Eliminar.Text = " Clear ";
            this.Botón_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Eliminar.UseVisualStyleBackColor = true;
            this.Botón_Eliminar.Click += new System.EventHandler(this.Botón_Eliminar_Click);
            this.Botón_Eliminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Nombre_Usuario_KeyDown);
            // 
            // ComboBox_Nombre_Usuario
            // 
            this.ComboBox_Nombre_Usuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Nombre_Usuario.BackColor = System.Drawing.Color.White;
            this.ComboBox_Nombre_Usuario.FormattingEnabled = true;
            this.ComboBox_Nombre_Usuario.Location = new System.Drawing.Point(79, 11);
            this.ComboBox_Nombre_Usuario.Name = "ComboBox_Nombre_Usuario";
            this.ComboBox_Nombre_Usuario.Size = new System.Drawing.Size(393, 21);
            this.ComboBox_Nombre_Usuario.TabIndex = 0;
            this.ComboBox_Nombre_Usuario.Text = "Xisumavoid";
            this.ComboBox_Nombre_Usuario.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Nombre_Usuario_SelectedIndexChanged);
            this.ComboBox_Nombre_Usuario.TextChanged += new System.EventHandler(this.ComboBox_Nombre_Usuario_TextChanged);
            this.ComboBox_Nombre_Usuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Nombre_Usuario_KeyDown);
            // 
            // Ventana_Nombre_Usuario
            // 
            this.AcceptButton = this.Botón_Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Botón_Cancelar;
            this.ClientSize = new System.Drawing.Size(484, 74);
            this.Controls.Add(this.Botón_Eliminar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Etiqueta_Nombre_Usuario);
            this.Controls.Add(this.Botón_Restablecer);
            this.Controls.Add(this.Botón_Cancelar);
            this.Controls.Add(this.Botón_Aceptar);
            this.Controls.Add(this.ComboBox_Nombre_Usuario);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ventana_Nombre_Usuario";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change the User Name by Jupisoft";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ventana_Nombre_Usuario_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ventana_Nombre_Usuario_FormClosed);
            this.Load += new System.EventHandler(this.Ventana_Nombre_Usuario_Load);
            this.Shown += new System.EventHandler(this.Ventana_Nombre_Usuario_Shown);
            this.SizeChanged += new System.EventHandler(this.Ventana_Nombre_Usuario_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Nombre_Usuario_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Etiqueta_Nombre_Usuario;
        private System.Windows.Forms.Button Botón_Aceptar;
        private System.Windows.Forms.Button Botón_Cancelar;
        private System.Windows.Forms.Button Botón_Restablecer;
        private System.Windows.Forms.Button Botón_Eliminar;
        private System.Windows.Forms.ComboBox ComboBox_Nombre_Usuario;
    }
}
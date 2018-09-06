namespace Minecraft_Tools
{
    partial class Ventana_Selector_Herramientas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana_Selector_Herramientas));
            this.Botón_Aceptar = new System.Windows.Forms.Button();
            this.Botón_Cancelar = new System.Windows.Forms.Button();
            this.Botón_Restablecer = new System.Windows.Forms.Button();
            this.Panel_Inferior = new System.Windows.Forms.Panel();
            this.ListView_Principal = new System.Windows.Forms.ListView();
            this.Panel_Separador = new System.Windows.Forms.Panel();
            this.Panel_Inferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // Botón_Aceptar
            // 
            this.Botón_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Botón_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Botón_Aceptar.Image = global::Minecraft_Tools.Properties.Resources.Aceptar;
            this.Botón_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Aceptar.Location = new System.Drawing.Point(666, 13);
            this.Botón_Aceptar.Margin = new System.Windows.Forms.Padding(12, 12, 3, 12);
            this.Botón_Aceptar.Name = "Botón_Aceptar";
            this.Botón_Aceptar.Size = new System.Drawing.Size(100, 24);
            this.Botón_Aceptar.TabIndex = 0;
            this.Botón_Aceptar.Text = " Accept ";
            this.Botón_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Aceptar.UseVisualStyleBackColor = true;
            // 
            // Botón_Cancelar
            // 
            this.Botón_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Botón_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Botón_Cancelar.Image = global::Minecraft_Tools.Properties.Resources.Cancelar;
            this.Botón_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Cancelar.Location = new System.Drawing.Point(772, 13);
            this.Botón_Cancelar.Margin = new System.Windows.Forms.Padding(3, 12, 12, 12);
            this.Botón_Cancelar.Name = "Botón_Cancelar";
            this.Botón_Cancelar.Size = new System.Drawing.Size(100, 24);
            this.Botón_Cancelar.TabIndex = 1;
            this.Botón_Cancelar.Text = " Cancel ";
            this.Botón_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Cancelar.UseVisualStyleBackColor = true;
            // 
            // Botón_Restablecer
            // 
            this.Botón_Restablecer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Botón_Restablecer.Image = global::Minecraft_Tools.Properties.Resources.Restablecer;
            this.Botón_Restablecer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Restablecer.Location = new System.Drawing.Point(12, 13);
            this.Botón_Restablecer.Margin = new System.Windows.Forms.Padding(12);
            this.Botón_Restablecer.Name = "Botón_Restablecer";
            this.Botón_Restablecer.Size = new System.Drawing.Size(100, 24);
            this.Botón_Restablecer.TabIndex = 2;
            this.Botón_Restablecer.Text = " Restore ";
            this.Botón_Restablecer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Restablecer.UseVisualStyleBackColor = true;
            // 
            // Panel_Inferior
            // 
            this.Panel_Inferior.Controls.Add(this.Panel_Separador);
            this.Panel_Inferior.Controls.Add(this.Botón_Aceptar);
            this.Panel_Inferior.Controls.Add(this.Botón_Cancelar);
            this.Panel_Inferior.Controls.Add(this.Botón_Restablecer);
            this.Panel_Inferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Inferior.Location = new System.Drawing.Point(0, 412);
            this.Panel_Inferior.Name = "Panel_Inferior";
            this.Panel_Inferior.Size = new System.Drawing.Size(884, 49);
            this.Panel_Inferior.TabIndex = 1;
            // 
            // ListView_Principal
            // 
            this.ListView_Principal.BackColor = System.Drawing.Color.White;
            this.ListView_Principal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_Principal.Location = new System.Drawing.Point(0, 0);
            this.ListView_Principal.Name = "ListView_Principal";
            this.ListView_Principal.Size = new System.Drawing.Size(884, 412);
            this.ListView_Principal.TabIndex = 0;
            this.ListView_Principal.UseCompatibleStateImageBehavior = false;
            // 
            // Panel_Separador
            // 
            this.Panel_Separador.BackColor = System.Drawing.Color.Black;
            this.Panel_Separador.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Separador.Location = new System.Drawing.Point(0, 0);
            this.Panel_Separador.Name = "Panel_Separador";
            this.Panel_Separador.Size = new System.Drawing.Size(884, 1);
            this.Panel_Separador.TabIndex = 3;
            // 
            // Ventana_Selector_Herramientas
            // 
            this.AcceptButton = this.Botón_Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Botón_Cancelar;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.ListView_Principal);
            this.Controls.Add(this.Panel_Inferior);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ventana_Selector_Herramientas";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool Selector by Jupisoft";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ventana_Selector_Herramientas_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ventana_Selector_Herramientas_FormClosed);
            this.Load += new System.EventHandler(this.Ventana_Selector_Herramientas_Load);
            this.Shown += new System.EventHandler(this.Ventana_Selector_Herramientas_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Selector_Herramientas_KeyDown);
            this.Panel_Inferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Botón_Aceptar;
        private System.Windows.Forms.Button Botón_Cancelar;
        private System.Windows.Forms.Button Botón_Restablecer;
        private System.Windows.Forms.Panel Panel_Inferior;
        private System.Windows.Forms.ListView ListView_Principal;
        private System.Windows.Forms.Panel Panel_Separador;
    }
}
﻿namespace Minecraft_Tools
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana_Selector_Herramientas));
            this.Panel_Inferior = new System.Windows.Forms.Panel();
            this.Botón_Aceptar = new System.Windows.Forms.Button();
            this.Botón_Cancelar = new System.Windows.Forms.Button();
            this.CheckBox_Rojo = new System.Windows.Forms.CheckBox();
            this.CheckBox_Azul = new System.Windows.Forms.CheckBox();
            this.CheckBox_Negro = new System.Windows.Forms.CheckBox();
            this.Botón_Aleatorizar = new System.Windows.Forms.Button();
            this.Botón_Restablecer = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.Panel_Separador = new System.Windows.Forms.Panel();
            this.ListView_Principal = new System.Windows.Forms.ListView();
            this.Lista_Imágenes_16 = new System.Windows.Forms.ImageList(this.components);
            this.Panel_Inferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Inferior
            // 
            this.Panel_Inferior.Controls.Add(this.Botón_Aceptar);
            this.Panel_Inferior.Controls.Add(this.Botón_Cancelar);
            this.Panel_Inferior.Controls.Add(this.CheckBox_Rojo);
            this.Panel_Inferior.Controls.Add(this.CheckBox_Azul);
            this.Panel_Inferior.Controls.Add(this.CheckBox_Negro);
            this.Panel_Inferior.Controls.Add(this.Botón_Aleatorizar);
            this.Panel_Inferior.Controls.Add(this.Botón_Restablecer);
            this.Panel_Inferior.Controls.Add(this.textBox9);
            this.Panel_Inferior.Controls.Add(this.Panel_Separador);
            this.Panel_Inferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Inferior.Location = new System.Drawing.Point(0, 392);
            this.Panel_Inferior.Name = "Panel_Inferior";
            this.Panel_Inferior.Size = new System.Drawing.Size(934, 49);
            this.Panel_Inferior.TabIndex = 1;
            // 
            // Botón_Aceptar
            // 
            this.Botón_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Botón_Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Botón_Aceptar.Image = global::Minecraft_Tools.Properties.Resources.Aceptar;
            this.Botón_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Aceptar.Location = new System.Drawing.Point(716, 13);
            this.Botón_Aceptar.Margin = new System.Windows.Forms.Padding(12, 12, 3, 12);
            this.Botón_Aceptar.Name = "Botón_Aceptar";
            this.Botón_Aceptar.Size = new System.Drawing.Size(100, 24);
            this.Botón_Aceptar.TabIndex = 0;
            this.Botón_Aceptar.Text = " Accept ";
            this.Botón_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Aceptar.UseVisualStyleBackColor = true;
            this.Botón_Aceptar.Click += new System.EventHandler(this.Botón_Aceptar_Click);
            this.Botón_Aceptar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Selector_Herramientas_KeyDown);
            // 
            // Botón_Cancelar
            // 
            this.Botón_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Botón_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Botón_Cancelar.Image = global::Minecraft_Tools.Properties.Resources.Cancelar;
            this.Botón_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Cancelar.Location = new System.Drawing.Point(822, 13);
            this.Botón_Cancelar.Margin = new System.Windows.Forms.Padding(3, 12, 12, 12);
            this.Botón_Cancelar.Name = "Botón_Cancelar";
            this.Botón_Cancelar.Size = new System.Drawing.Size(100, 24);
            this.Botón_Cancelar.TabIndex = 1;
            this.Botón_Cancelar.Text = " Cancel ";
            this.Botón_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Cancelar.UseVisualStyleBackColor = true;
            this.Botón_Cancelar.Click += new System.EventHandler(this.Botón_Cancelar_Click);
            this.Botón_Cancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Selector_Herramientas_KeyDown);
            // 
            // CheckBox_Rojo
            // 
            this.CheckBox_Rojo.AutoSize = true;
            this.CheckBox_Rojo.Cursor = System.Windows.Forms.Cursors.Help;
            this.CheckBox_Rojo.ForeColor = System.Drawing.Color.Red;
            this.CheckBox_Rojo.Location = new System.Drawing.Point(436, 17);
            this.CheckBox_Rojo.Name = "CheckBox_Rojo";
            this.CheckBox_Rojo.Size = new System.Drawing.Size(101, 17);
            this.CheckBox_Rojo.TabIndex = 6;
            this.CheckBox_Rojo.Text = "Tool won\'t work";
            this.CheckBox_Rojo.ThreeState = true;
            this.CheckBox_Rojo.UseVisualStyleBackColor = true;
            this.CheckBox_Rojo.CheckStateChanged += new System.EventHandler(this.CheckBox_Rojo_CheckStateChanged);
            this.CheckBox_Rojo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Selector_Herramientas_KeyDown);
            // 
            // CheckBox_Azul
            // 
            this.CheckBox_Azul.AutoSize = true;
            this.CheckBox_Azul.Checked = true;
            this.CheckBox_Azul.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.CheckBox_Azul.Cursor = System.Windows.Forms.Cursors.Help;
            this.CheckBox_Azul.ForeColor = System.Drawing.Color.Blue;
            this.CheckBox_Azul.Location = new System.Drawing.Point(330, 17);
            this.CheckBox_Azul.Name = "CheckBox_Azul";
            this.CheckBox_Azul.Size = new System.Drawing.Size(101, 17);
            this.CheckBox_Azul.TabIndex = 5;
            this.CheckBox_Azul.Text = "Tool might work";
            this.CheckBox_Azul.ThreeState = true;
            this.CheckBox_Azul.UseVisualStyleBackColor = true;
            this.CheckBox_Azul.CheckStateChanged += new System.EventHandler(this.CheckBox_Azul_CheckStateChanged);
            this.CheckBox_Azul.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Selector_Herramientas_KeyDown);
            // 
            // CheckBox_Negro
            // 
            this.CheckBox_Negro.AutoSize = true;
            this.CheckBox_Negro.Checked = true;
            this.CheckBox_Negro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Negro.Cursor = System.Windows.Forms.Cursors.Help;
            this.CheckBox_Negro.Location = new System.Drawing.Point(224, 17);
            this.CheckBox_Negro.Name = "CheckBox_Negro";
            this.CheckBox_Negro.Size = new System.Drawing.Size(98, 17);
            this.CheckBox_Negro.TabIndex = 4;
            this.CheckBox_Negro.Text = "Tool works fine";
            this.CheckBox_Negro.ThreeState = true;
            this.CheckBox_Negro.UseVisualStyleBackColor = true;
            this.CheckBox_Negro.CheckStateChanged += new System.EventHandler(this.CheckBox_Negro_CheckStateChanged);
            this.CheckBox_Negro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Selector_Herramientas_KeyDown);
            // 
            // Botón_Aleatorizar
            // 
            this.Botón_Aleatorizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Botón_Aleatorizar.Image = global::Minecraft_Tools.Properties.Resources.Aleatorio;
            this.Botón_Aleatorizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Aleatorizar.Location = new System.Drawing.Point(118, 13);
            this.Botón_Aleatorizar.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.Botón_Aleatorizar.Name = "Botón_Aleatorizar";
            this.Botón_Aleatorizar.Size = new System.Drawing.Size(100, 24);
            this.Botón_Aleatorizar.TabIndex = 3;
            this.Botón_Aleatorizar.Text = " Randomize ";
            this.Botón_Aleatorizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Aleatorizar.UseVisualStyleBackColor = true;
            this.Botón_Aleatorizar.Click += new System.EventHandler(this.Botón_Aleatorizar_Click);
            this.Botón_Aleatorizar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Selector_Herramientas_KeyDown);
            // 
            // Botón_Restablecer
            // 
            this.Botón_Restablecer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Botón_Restablecer.Image = global::Minecraft_Tools.Properties.Resources.Restablecer;
            this.Botón_Restablecer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Restablecer.Location = new System.Drawing.Point(12, 13);
            this.Botón_Restablecer.Margin = new System.Windows.Forms.Padding(12, 12, 3, 12);
            this.Botón_Restablecer.Name = "Botón_Restablecer";
            this.Botón_Restablecer.Size = new System.Drawing.Size(100, 24);
            this.Botón_Restablecer.TabIndex = 2;
            this.Botón_Restablecer.Text = " Restore ";
            this.Botón_Restablecer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Botón_Restablecer.UseVisualStyleBackColor = true;
            this.Botón_Restablecer.Click += new System.EventHandler(this.Botón_Restablecer_Click);
            this.Botón_Restablecer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Selector_Herramientas_KeyDown);
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.BackColor = System.Drawing.Color.White;
            this.textBox9.Enabled = false;
            this.textBox9.Location = new System.Drawing.Point(902, 15);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(20, 20);
            this.textBox9.TabIndex = 8;
            this.textBox9.Visible = false;
            // 
            // Panel_Separador
            // 
            this.Panel_Separador.BackColor = System.Drawing.Color.Black;
            this.Panel_Separador.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Separador.Location = new System.Drawing.Point(0, 0);
            this.Panel_Separador.Name = "Panel_Separador";
            this.Panel_Separador.Size = new System.Drawing.Size(934, 1);
            this.Panel_Separador.TabIndex = 7;
            // 
            // ListView_Principal
            // 
            this.ListView_Principal.BackColor = System.Drawing.Color.White;
            this.ListView_Principal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView_Principal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListView_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_Principal.FullRowSelect = true;
            this.ListView_Principal.HideSelection = false;
            this.ListView_Principal.Location = new System.Drawing.Point(0, 0);
            this.ListView_Principal.Margin = new System.Windows.Forms.Padding(0);
            this.ListView_Principal.MultiSelect = false;
            this.ListView_Principal.Name = "ListView_Principal";
            this.ListView_Principal.Size = new System.Drawing.Size(934, 392);
            this.ListView_Principal.TabIndex = 0;
            this.ListView_Principal.UseCompatibleStateImageBehavior = false;
            this.ListView_Principal.View = System.Windows.Forms.View.Tile;
            this.ListView_Principal.SelectedIndexChanged += new System.EventHandler(this.ListView_Principal_SelectedIndexChanged);
            this.ListView_Principal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Selector_Herramientas_KeyDown);
            this.ListView_Principal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_Principal_MouseDoubleClick);
            this.ListView_Principal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListView_Principal_MouseDown);
            // 
            // Lista_Imágenes_16
            // 
            this.Lista_Imágenes_16.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.Lista_Imágenes_16.ImageSize = new System.Drawing.Size(16, 16);
            this.Lista_Imágenes_16.TransparentColor = System.Drawing.Color.Empty;
            // 
            // Ventana_Selector_Herramientas
            // 
            this.AcceptButton = this.Botón_Aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Botón_Cancelar;
            this.ClientSize = new System.Drawing.Size(934, 441);
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
            this.Panel_Inferior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Botón_Aceptar;
        private System.Windows.Forms.Button Botón_Cancelar;
        private System.Windows.Forms.Button Botón_Restablecer;
        private System.Windows.Forms.Panel Panel_Inferior;
        private System.Windows.Forms.ListView ListView_Principal;
        private System.Windows.Forms.Panel Panel_Separador;
        private System.Windows.Forms.ImageList Lista_Imágenes_16;
        private System.Windows.Forms.CheckBox CheckBox_Negro;
        private System.Windows.Forms.CheckBox CheckBox_Rojo;
        private System.Windows.Forms.CheckBox CheckBox_Azul;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button Botón_Aleatorizar;
    }
}
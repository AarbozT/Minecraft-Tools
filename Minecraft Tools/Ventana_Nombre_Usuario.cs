using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Nombre_Usuario : Form
    {
        public Ventana_Nombre_Usuario()
        {
            InitializeComponent();
        }

        internal bool Variable_Nuevo_Usuario = false;
        internal bool Variable_Siempre_Visible = false;
        internal string Texto_Usuario = Program.Texto_Usuario;

        private void Ventana_Nombre_Usuario_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                ComboBox_Nombre_Usuario.Items.Add(Environment.UserName);
                if (!Variable_Nuevo_Usuario)
                {
                    this.Text = "Change the User Name for " + Program.Texto_Usuario + " by Jupisoft";
                    ComboBox_Nombre_Usuario.Text = Texto_Usuario;
                }
                else
                {
                    this.Text = "Welcome dear user, please input your desired user name...";
                    ComboBox_Nombre_Usuario.Text = Texto_Usuario;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Nombre_Usuario_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Nombre_Usuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Nombre_Usuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Nombre_Usuario_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Nombre_Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!e.Alt && !e.Control && !e.Shift)
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        this.Close();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void ComboBox_Nombre_Usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Texto_Usuario = ComboBox_Nombre_Usuario.Text;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void ComboBox_Nombre_Usuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Texto_Usuario = ComboBox_Nombre_Usuario.Text;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Restablecer_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox_Nombre_Usuario.Text = "Xisumavoid";
                ComboBox_Nombre_Usuario.Select();
                ComboBox_Nombre_Usuario.Focus();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBox_Nombre_Usuario.Text = null;
                ComboBox_Nombre_Usuario.Select();
                ComboBox_Nombre_Usuario.Focus();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                bool Nombre_Vacío = true;
                if (!string.IsNullOrEmpty(Texto_Usuario))
                {
                    foreach (char Caracter in Texto_Usuario)
                    {
                        if (!char.IsWhiteSpace(Caracter))
                        {
                            Nombre_Vacío = false;
                            break;
                        }
                    }
                }
                if (!Nombre_Vacío)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    Texto_Usuario = "Xisumavoid";
                    this.DialogResult = DialogResult.Cancel;
                }
                this.Close();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }
    }
}

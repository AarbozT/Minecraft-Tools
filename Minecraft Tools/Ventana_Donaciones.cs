using Minecraft_Tools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Donaciones : Form
    {
        public Ventana_Donaciones()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Structure that holds up all the information about any donation.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Donaciones
        {
            /// <summary>
            /// The name of the donator.
            /// </summary>
            internal string Nombre;
            /// <summary>
            /// The date the donation was done.
            /// </summary>
            internal DateTime Fecha;
            /// <summary>
            /// The quantity of money received.
            /// </summary>
            internal decimal Cantidad;
            /// <summary>
            /// The type of money received.
            /// </summary>
            internal string Moneda;

            internal Donaciones(string Nombre, DateTime Fecha, decimal Cantidad, string Moneda)
            {
                this.Nombre = Nombre;
                this.Fecha = Fecha;
                this.Cantidad = Cantidad;
                this.Moneda = Moneda;
            }

            /// <summary>
            /// Array that holds up all the information about the donations received by Jupisoft.
            /// </summary>
            internal static readonly Donaciones[] Matriz_Donaciones = new Donaciones[]
            {
                new Donaciones("Alexander", new DateTime(2018, 10, 12), 81.87m, "Euros (€)"),
            };
        }

        internal readonly string Texto_Título = "Donations received by Jupisoft";
        internal bool Variable_Siempre_Visible = false;

        private void Ventana_Donaciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                //this.WindowState = FormWindowState.Maximized;
                this.Text = Texto_Título + " - [Donations: " + Program.Traducir_Número(Donaciones.Matriz_Donaciones.Length) + "]";
                if (Donaciones.Matriz_Donaciones != null && Donaciones.Matriz_Donaciones.Length > 0)
                {
                    DataGridView_Principal.Sort(Columna_Donante, ListSortDirection.Ascending);
                    DataGridView_Principal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    DataGridView_Principal.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    foreach (Donaciones Donación in Donaciones.Matriz_Donaciones)
                    {
                        DataGridView_Principal.Rows.Add(new object[] { Resources.Usuario, Donación.Nombre, Program.Traducir_Fecha_Inglés(Donación.Fecha), Donación.Cantidad,Donación.Moneda });
                    }
                    DataGridView_Principal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DataGridView_Principal.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Donaciones_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Donaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Donaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Donaciones_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!e.Alt && !e.Control && !e.Shift)
                {
                    if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        this.Close();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void DataGridView_Principal_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.ThrowException = false;
                Depurador.Escribir_Excepción(e.Exception != null ? e.Exception.ToString() : null);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }
    }
}

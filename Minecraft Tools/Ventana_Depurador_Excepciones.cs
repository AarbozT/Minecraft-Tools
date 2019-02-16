using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Depurador_Excepciones : Form
    {
        public Ventana_Depurador_Excepciones()
        {
            InitializeComponent();
        }

        internal static bool Invertir_Orden = true;
        internal static int Ordenar = 2;
        internal FileStream Lector_Depurador = null;
        internal BinaryReader Lector_Depurador_Binario = null;
        internal bool Ocupado = false;
        internal bool Variable_Siempre_Visible = false;

        private void Ventana_Depurador_Excepciones_Load(object sender, EventArgs e)
        {
            this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
            /*this.Text = Lenguaje.Diccionarios_Lenguajes[Lenguaje.Actual][Lenguaje.Textos.Ventana_Depurador_This];
            Menú_Contextual_Invertir_Orden.Text = Lenguaje.Diccionarios_Lenguajes[Lenguaje.Actual][Lenguaje.Textos.Ventana_Depurador_Menú_Contextual_Invertir_Orden];
            Menú_Contextual_Ordenar_0.Text = Lenguaje.Diccionarios_Lenguajes[Lenguaje.Actual][Lenguaje.Textos.Ventana_Depurador_Menú_Contextual_Ordenar_0];
            Menú_Contextual_Ordenar_1.Text = Lenguaje.Diccionarios_Lenguajes[Lenguaje.Actual][Lenguaje.Textos.Ventana_Depurador_Menú_Contextual_Ordenar_1];
            Menú_Contextual_Ordenar_2.Text = Lenguaje.Diccionarios_Lenguajes[Lenguaje.Actual][Lenguaje.Textos.Ventana_Depurador_Menú_Contextual_Ordenar_2];
            Menú_Contextual_Ordenar_3.Text = Lenguaje.Diccionarios_Lenguajes[Lenguaje.Actual][Lenguaje.Textos.Ventana_Depurador_Menú_Contextual_Ordenar_3];
            Menú_Contextual_Ordenar_4.Text = Lenguaje.Diccionarios_Lenguajes[Lenguaje.Actual][Lenguaje.Textos.Ventana_Depurador_Menú_Contextual_Ordenar_4];
            */
            this.WindowState = FormWindowState.Maximized;
        }

        private void Ventana_Depurador_Excepciones_Shown(object sender, EventArgs e)
        {
            Ocupado = true;
            Menú_Contextual_Invertir_Orden.Checked = Invertir_Orden;
            Menú_Contextual.Items["Menú_Contextual_Ordenar_" + Ordenar.ToString()].PerformClick();
            Ocupado = false;
            Cargar_Errores();
            this.Activate();
        }

        private void Ventana_Depurador_Excepciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            Lector_Depurador_Binario.Close();
            Lector_Depurador_Binario.Dispose();
            Lector_Depurador_Binario = null;
            Lector_Depurador.Close();
            Lector_Depurador.Dispose();
            Lector_Depurador = null;
        }

        private void Ventana_Depurador_Excepciones_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Ventana_Depurador_Excepciones_KeyDown(object sender, KeyEventArgs e)
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

        private void Menú_Contextual_Invertir_Orden_CheckedChanged(object sender, EventArgs e)
        {
            Invertir_Orden = Menú_Contextual_Invertir_Orden.Checked;
            Cargar_Errores();
        }

        private void Menú_Contextual_Ordenar_Click(object sender, EventArgs e)
        {
            Ocupado = true;
            for (int Índice = 0; Índice < Menú_Contextual.Items.Count; Índice++) if (Menú_Contextual.Items[Índice].GetType() == typeof(ToolStripMenuItem) && Menú_Contextual.Items[Índice].Name.StartsWith("Menú_Contextual_Ordenar_")) ((ToolStripMenuItem)Menú_Contextual.Items[Índice]).Checked = false;
            ToolStripMenuItem Menú = (ToolStripMenuItem)sender;
            Menú.Checked = true;
            Ordenar = int.Parse(Menú.Name.Replace("Menú_Contextual_Ordenar_", null));
            Ocupado = false;
            Cargar_Errores();
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct Excepciones
        {
            internal uint CRC32;
            internal DateTime Primera_Fecha;
            internal DateTime Última_Fecha;
            internal long Repeticiones;
            internal int Longitud;
            internal string Mensaje;

            internal Excepciones(uint CRC32, DateTime Fecha_Inicial, DateTime Fecha_Final, long Repeticiones, int Longitud, string Mensaje)
            {
                this.CRC32 = CRC32;
                this.Primera_Fecha = Fecha_Inicial;
                this.Última_Fecha = Fecha_Final;
                this.Repeticiones = Repeticiones;
                this.Longitud = Longitud;
                this.Mensaje = Mensaje;
            }
        }

        internal class Comparador_Excepciones : IComparer<Excepciones>
        {
            public int Compare(Excepciones Excepción_1, Excepciones Excepción_2)
            {
                if (Ordenar == 0) // CRC32
                {
                    if (Excepción_1.CRC32 < Excepción_2.CRC32) return -1;
                    else if (Excepción_1.CRC32 > Excepción_2.CRC32) return 1;
                    else return 0;
                }
                else if (Ordenar == 1) // Primera Fecha
                {
                    return DateTime.Compare(Excepción_1.Primera_Fecha, Excepción_2.Primera_Fecha);
                }
                else if (Ordenar == 2) // Última Fecha
                {
                    return DateTime.Compare(Excepción_1.Última_Fecha, Excepción_2.Última_Fecha);
                }
                else if (Ordenar == 3) // Repeticiones
                {
                    if (Excepción_1.Repeticiones < Excepción_2.Repeticiones) return -1;
                    else if (Excepción_1.Repeticiones > Excepción_2.Repeticiones) return 1;
                    else return 0;
                }
                else if (Ordenar == 4) // Mensaje
                {
                    return string.Compare(Excepción_1.Mensaje, Excepción_2.Mensaje);
                }
                return 0;
            }
        }

        internal void Cargar_Errores()
        {
            try
            {
                if (!Ocupado)
                {
                    long Depurador_Errores = 0L, Depurador_Errores_Únicos = 0L;
                    string Texto = null;
                    Lector_Depurador = new FileStream(Application.StartupPath + "\\Debugger", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                    Lector_Depurador.Seek(0L, SeekOrigin.Begin);
                    Lector_Depurador_Binario = new BinaryReader(Lector_Depurador, Encoding.ASCII);
                    if (Lector_Depurador != null && Lector_Depurador_Binario != null && Lector_Depurador.Length > 0L)
                    {
                        List<Excepciones> Lista_Excepciones = new List<Excepciones>();
                        for (long Índice = 0L; Índice < Lector_Depurador.Length;)
                        {
                            uint CRC32 = 0;
                            DateTime Primera_Fecha = DateTime.MinValue;
                            DateTime Última_Fecha = DateTime.MinValue;
                            long Repeticiones = 0L;
                            int Longitud = 0;
                            string Mensaje = null;
                            try { CRC32 = Lector_Depurador_Binario.ReadUInt32(); }
                            catch { CRC32 = 0; }
                            try { Primera_Fecha = DateTime.FromBinary(Lector_Depurador_Binario.ReadInt64()); }
                            catch { Primera_Fecha = DateTime.MinValue; }
                            try { Última_Fecha = DateTime.FromBinary(Lector_Depurador_Binario.ReadInt64()); }
                            catch { Última_Fecha = DateTime.MinValue; }
                            try { Repeticiones = Lector_Depurador_Binario.ReadInt64(); }
                            catch { Repeticiones = 0L; }
                            try { Longitud = Lector_Depurador_Binario.ReadInt32(); }
                            catch { Longitud = 0; }
                            try { Mensaje = Encoding.Unicode.GetString(Lector_Depurador_Binario.ReadBytes(Longitud)); }
                            catch { Mensaje = "Unknown error."; }
                            Depurador_Errores += Repeticiones;
                            Depurador_Errores_Únicos++;
                            Lista_Excepciones.Add(new Excepciones(CRC32, Primera_Fecha, Última_Fecha, Repeticiones, Longitud, Mensaje));
                            Índice += 32 + Longitud;
                        }
                        if (Lista_Excepciones.Count > 0)
                        {
                            Lista_Excepciones.Sort(new Comparador_Excepciones());
                            if (Invertir_Orden) Lista_Excepciones.Reverse();
                            for (int Índice = 0; Índice < Lista_Excepciones.Count; Índice++)
                            {
                                Texto += "[" + (Índice + 1).ToString() + "] [x" + Program.Traducir_Número(Lista_Excepciones[Índice].Repeticiones) + /*"] [CRC-32: " + Program.Traducir_Número(Lista_Excepciones[Índice].CRC32) + */"] [" + Program.Traducir_Fecha_Hora(Lista_Excepciones[Índice].Primera_Fecha) + "] [" + Program.Traducir_Fecha_Hora(Lista_Excepciones[Índice].Última_Fecha) + "] " + Lista_Excepciones[Índice].Mensaje + "\r\n\r\n";
                            }
                        }
                    }
                    this.Text = "Exception Debugger by Jupisoft - [Errors: " + Program.Traducir_Número(Depurador_Errores) + ", Unique Errors: " + Program.Traducir_Número(Depurador_Errores_Únicos) + "]";
                    if (!string.IsNullOrEmpty(Texto)) Texto = "[Dear " + Program.Texto_Usuario + " if you want to help with the debugging of these exceptions, please send the \"Debugger\" file to: Jupitermauro@gmail.com]\r\n\r\n" + Texto.TrimEnd("\r\n\r\n".ToCharArray());
                    Editor_RTF.Text = Texto;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }
    }
}

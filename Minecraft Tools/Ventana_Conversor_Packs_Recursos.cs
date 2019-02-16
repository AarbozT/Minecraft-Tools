using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Conversor_Packs_Recursos : Form
    {
        public Ventana_Conversor_Packs_Recursos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Structure that holds up all the information about a resource folder from any Minecraft version, this includes all of it's resource files.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Carpetas
        {
            internal string Ruta_1_12_2;
            internal string Ruta_1_13_1;
            internal Recursos[] Matriz_Recursos;

            internal Carpetas(string Ruta_1_12_2, string Ruta_1_13_1, Recursos[] Matriz_Recursos)
            {
                this.Ruta_1_12_2 = Ruta_1_12_2;
                this.Ruta_1_13_1 = Ruta_1_13_1;
                this.Matriz_Recursos = Matriz_Recursos;
            }

            internal static readonly Carpetas[] Matriz_Carpetas = new Carpetas[]
            {
                //new Recursos(Resources.Ejecutar, "None (select it manually everytime)", null, CheckState.Checked),
                
            };
        }

        /// <summary>
        /// Structure that holds up all the information about a resource from any Minecraft version.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Recursos
        {
            /// <summary>
            /// A relative resource path for the 1.12.2 Minecraft version.
            /// </summary>
            internal Dictionary<string, string> Diccionario_Rutas;
            /// <summary>
            /// A relative resource path for the 1.13.1 Minecraft version.
            /// </summary>
            internal Dictionary<string, string> Diccionario_Nombres;
            /// <summary>
            /// A relative resource path for any version.
            /// </summary>
            internal string Ruta;
            /// <summary>
            /// A resource name with it's extension for any version.
            /// </summary>
            internal string Nombre;
            /// <summary>
            /// A useful value to know if 2 files are the same. Mostly these values will come from the 1.13.1 Minecraft version (the latest at this moment).
            /// </summary>
            internal uint CRC_32;
            /// <summary>
            /// A useful value to know from which version comes this resource and even if it's from Minecraft or Faithful.
            /// </summary>
            internal string Versión;

            internal Recursos(Dictionary<string, string> Diccionario_Rutas, Dictionary<string, string> Diccionario_Nombres, string Ruta, string Nombre, uint CRC_32, string Versión)
            {
                this.Diccionario_Rutas = Diccionario_Rutas;
                this.Diccionario_Nombres = Diccionario_Nombres;
                this.Ruta = Ruta;
                this.Nombre = Nombre;
                this.CRC_32 = CRC_32;
                this.Versión = Versión;
            }

            internal static readonly Recursos[] Matriz_Recursos = new Recursos[]
            {
                //new Recursos(Resources.Ejecutar, "None (select it manually everytime)", null, CheckState.Checked),
                
            };

            /// <summary>
            /// Searches for all the available resources in the specified folders and generates a unique list of relative paths used later for correctly convert resource packs between Minecraft versions. Note this function still requires a lot of manual work where the resource names are different between versions, but at least will be a list of the relative paths that haven't been automatically found, so they can be manually moved.
            /// </summary>
            internal void Buscar_Recursos()
            {
                try
                {
                    /*string Ruta_Minecraft_1_12_2 = TextBox_Minecraft_1_12_2.Text;
                    string Ruta_Faithful_1_12_2 = TextBox_Minecraft_1_12_2.Text;

                    string Ruta_Faithful_1_13_1 = @"C:\Users\Jupisoft\Videos\__DVDs copiados\Faithful+1.13.1-rv2";
                    string Ruta_Minecraft_1_13_1 = @"C:\Users\Jupisoft\Videos\__DVDs copiados\1.13.1";
                    */












                }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            }
        }

        internal readonly string Texto_Título = "Tool Selector for " + Program.Texto_Usuario + " by Jupisoft";
        internal bool Variable_Siempre_Visible = false;
        internal bool Variable_Excepción = false;
        internal bool Variable_Excepción_Imagen = false;
        internal int Variable_Excepción_Total = 0;
        internal bool Variable_Memoria = false;
        internal static Stopwatch Cronómetro_FPS = Stopwatch.StartNew();
        internal long Segundo_FPS_Anterior = 0L;
        internal long FPS_Temporal = 0L;
        internal long FPS_Real = 0L;
        internal bool Ocupado = false;

        // pack_format: Pack version. If this number does not match the current required number,
        // the resource pack will display an error and required additional confirmation to load the
        // pack. Requires 1 for 1.6-1.9, 2 for 1.9 and 1.10, 3 for 1.11 and 1.12, and 4 for 1.13.

        private void Ventana_Conversor_Packs_Recursos_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                this.WindowState = FormWindowState.Maximized;
                if (string.Compare(Environment.UserName, "Jupisoft", true) != 0)
                {
                    Grupo_Principal.Enabled = false; // Only allow access to programmers (if you are one, comment the beginning of line with "//").
                }
                Grupo_Minecraft_1_12_2.AllowDrop = true;

                TextBox_Minecraft_1_12_2.Text = @"C:\Users\Jupisoft\Videos\__DVDs copiados\1.12.2";
                TextBox_Faithful_1_12_2.Text = @"C:\Users\Jupisoft\Videos\__DVDs copiados\Faithful+1.12.2-rv4";

                TextBox_Minecraft_1_13_1.Text = @"C:\Users\Jupisoft\Videos\__DVDs copiados\1.13.1";
                TextBox_Faithful_1_13_1.Text = @"C:\Users\Jupisoft\Videos\__DVDs copiados\Faithful+1.13.1-rv2";
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Conversor_Packs_Recursos_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Conversor_Packs_Recursos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Conversor_Packs_Recursos_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Conversor_Packs_Recursos_KeyDown(object sender, KeyEventArgs e)
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
                    /*else if (e.KeyCode == Keys.Enter)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }*/
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Grupos_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, true) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Grupos_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                {
                    string[] Matriz_Rutas = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                    if (Matriz_Rutas != null && Matriz_Rutas.Length > 0)
                    {
                        foreach (string Ruta in Matriz_Rutas)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(Ruta) && Directory.Exists(Ruta))
                                {
                                    GroupBox Grupo = sender as GroupBox;
                                    if (Grupo != null)
                                    {
                                        string Nombre = "TextBox_" + Grupo.Name.Replace("Grupo_", null);
                                        if (Grupo.Controls != null && Grupo.Controls.Count > 0 && Grupo.Controls.ContainsKey(Nombre))
                                        {
                                            ((TextBox)Grupo.Controls[Nombre]).Text = Ruta;
                                            break;
                                        }
                                    }
                                }
                            }
                            catch (Exception Excepción)
                            {
                                Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null);
                                continue;
                            }
                        }
                        Matriz_Rutas = null;
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Cargar_Carpetas_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> Lista_Rutas_Relativas = new List<string>();
                string[] Matriz_Carpetas = Directory.GetDirectories(TextBox_Minecraft_1_12_2.Text, "*", SearchOption.AllDirectories);
                foreach (string Carpeta in Matriz_Carpetas)
                {
                    string Rutas_Relativa = Carpeta.Substring(TextBox_Minecraft_1_12_2.Text.Length + 1);
                    if (!string.IsNullOrEmpty(Rutas_Relativa) && !Lista_Rutas_Relativas.Contains(Rutas_Relativa))
                    {
                        Lista_Rutas_Relativas.Add(Rutas_Relativa);
                    }
                }
                Matriz_Carpetas = null;
                Matriz_Carpetas = Directory.GetDirectories(TextBox_Faithful_1_12_2.Text, "*", SearchOption.AllDirectories);
                foreach (string Carpeta in Matriz_Carpetas)
                {
                    string Rutas_Relativa = Carpeta.Substring(TextBox_Faithful_1_12_2.Text.Length + 1);
                    if (!string.IsNullOrEmpty(Rutas_Relativa) && !Lista_Rutas_Relativas.Contains(Rutas_Relativa))
                    {
                        Lista_Rutas_Relativas.Add(Rutas_Relativa);
                    }
                }
                Matriz_Carpetas = null;
                Matriz_Carpetas = Directory.GetDirectories(TextBox_Minecraft_1_13_1.Text, "*", SearchOption.AllDirectories);
                foreach (string Carpeta in Matriz_Carpetas)
                {
                    string Rutas_Relativa = Carpeta.Substring(TextBox_Minecraft_1_13_1.Text.Length + 1);
                    if (!string.IsNullOrEmpty(Rutas_Relativa) && !Lista_Rutas_Relativas.Contains(Rutas_Relativa))
                    {
                        Lista_Rutas_Relativas.Add(Rutas_Relativa);
                    }
                }
                Matriz_Carpetas = null;
                Matriz_Carpetas = Directory.GetDirectories(TextBox_Faithful_1_13_1.Text, "*", SearchOption.AllDirectories);
                foreach (string Carpeta in Matriz_Carpetas)
                {
                    string Rutas_Relativa = Carpeta.Substring(TextBox_Faithful_1_13_1.Text.Length + 1);
                    if (!string.IsNullOrEmpty(Rutas_Relativa) && !Lista_Rutas_Relativas.Contains(Rutas_Relativa))
                    {
                        Lista_Rutas_Relativas.Add(Rutas_Relativa);
                    }
                }
                Matriz_Carpetas = null;
                Lista_Rutas_Relativas.Sort();
                ComboBox_Carpetas.Items.AddRange(Lista_Rutas_Relativas.ToArray());
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Cargar_Archivos_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar_Carpetas(TextBox_Minecraft_1_12_2.Text, TextBox_Faithful_1_12_2.Text, TextBox_Minecraft_1_13_1.Text, TextBox_Faithful_1_13_1.Text, ComboBox_Carpetas.Text);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        internal List<Recursos> Buscar_Archivos(string Ruta_Base, string Ruta_Relativa, string Versión)
        {
            try
            {
                List<Recursos> Lista_Recursos = new List<Recursos>();
                if (!string.IsNullOrEmpty(Ruta_Base) && Directory.Exists(Ruta_Base) && !string.IsNullOrEmpty(Ruta_Relativa) && Directory.Exists(Ruta_Relativa))
                {
                    string[] Matriz_Archivos = Directory.GetFiles(Ruta_Base + "\\" + Ruta_Relativa, "*", SearchOption.TopDirectoryOnly);
                    if (Matriz_Archivos != null && Matriz_Archivos.Length > 0)
                    {
                        if (Matriz_Archivos.Length > 1) Array.Sort(Matriz_Archivos);
                        foreach (string Ruta in Matriz_Archivos)
                        {
                            string Nombre = Path.GetFileName(Ruta);
                            string Ruta_Recurso = Ruta_Relativa + "\\" + Nombre;
                            Lista_Recursos.Add(new Recursos(null, null, Ruta_Recurso, Nombre, Program.Obtener_CRC_32(Ruta), Versión));
                        }
                        return Lista_Recursos;
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal Carpetas Buscar_Carpetas(string Ruta_MC_1_12_2, string Ruta_FF_1_12_2, string Ruta_MC_1_13_1, string Ruta_FF_1_13_1, string Ruta_Relativa)
        {
            try
            {
                List<Recursos> Lista_Recursos_MC_1_12_2 = Buscar_Archivos(Ruta_MC_1_12_2, Ruta_Relativa, "1.12.2");
                List<Recursos> Lista_Recursos_FF_1_12_2 = Buscar_Archivos(Ruta_FF_1_12_2, Ruta_Relativa, "1.12.2");
                List<Recursos> Lista_Recursos_MC_1_13_1 = Buscar_Archivos(Ruta_MC_1_13_1, Ruta_Relativa, "1.13.1");
                List<Recursos> Lista_Recursos_FF_1_13_1 = Buscar_Archivos(Ruta_FF_1_13_1, Ruta_Relativa, "1.13.1");
                if (Lista_Recursos_MC_1_12_2 != null && Lista_Recursos_FF_1_12_2 != null && Lista_Recursos_MC_1_13_1 != null && Lista_Recursos_FF_1_13_1 != null)
                {
                    List<Recursos> Lista_Recursos = new List<Recursos>();
                    List<Recursos>[] Matriz_Listas_Recursos_Minecraft = new List<Recursos>[]
                    {
                        Lista_Recursos_MC_1_12_2,
                        Lista_Recursos_MC_1_13_1,
                    };
                    List<Recursos>[] Matriz_Listas_Recursos_Faithful = new List<Recursos>[]
                    {
                        Lista_Recursos_FF_1_12_2,
                        Lista_Recursos_FF_1_13_1,
                    };
                    string[] Matriz_Versiones = new string[] { "1.12.2", "1.13.1" };
                    Dictionary<string, string> Diccionario_Rutas = new Dictionary<string, string>();
                    Dictionary<string, string> Diccionario_Nombres = new Dictionary<string, string>();
                    foreach (string Versión in Matriz_Versiones)
                    {
                        Diccionario_Rutas.Add(Versión, null);
                        Diccionario_Nombres.Add(Versión, null);
                    }
                    Dictionary<uint, long> Diccionario_CRCs = new Dictionary<uint, long>();
                    for (int Índice = 0; Índice < Matriz_Listas_Recursos_Minecraft.Length; Índice++)
                    {
                        foreach (Recursos Recurso in Matriz_Listas_Recursos_Minecraft[Índice])
                        {
                            if (!Diccionario_CRCs.ContainsKey(Recurso.CRC_32))
                            {
                                Diccionario_CRCs.Add(Recurso.CRC_32, 1L);
                            }
                            else Diccionario_CRCs[Recurso.CRC_32]++;
                        }
                    } // Prevent duplicate CRC comparison errors.
                    for (int Índice_Salida = 0; Índice_Salida < Matriz_Listas_Recursos_Minecraft.Length; Índice_Salida++)
                    {
                        for (int Índice_Entrada = 0; Índice_Entrada < Matriz_Listas_Recursos_Minecraft.Length; Índice_Entrada++)
                        {
                            if (Índice_Entrada != Índice_Salida)
                            {
                                foreach (Recursos Recurso_Entrada in Matriz_Listas_Recursos_Minecraft[Índice_Entrada])
                                {
                                    bool Encontrado = false; // 1st pass, look for equal names:
                                    Diccionario_Rutas[Recurso_Entrada.Versión] = Recurso_Entrada.Ruta;
                                    Diccionario_Nombres[Recurso_Entrada.Versión] = Recurso_Entrada.Nombre;
                                    foreach (Recursos Recurso_Salida in Matriz_Listas_Recursos_Minecraft[Índice_Salida])
                                    {
                                        if (string.Compare(Recurso_Entrada.Nombre, Recurso_Salida.Nombre, true) == 0)
                                        {
                                            Diccionario_Rutas[Recurso_Salida.Versión] = Recurso_Salida.Ruta;
                                            Diccionario_Nombres[Recurso_Salida.Versión] = Recurso_Salida.Nombre;
                                            Encontrado = true;
                                            break;
                                        }
                                    }
                                    if (!Encontrado) // 2nd pass, look for equal CRCs:
                                    {
                                        if (Diccionario_CRCs[Recurso_Entrada.CRC_32] <= Matriz_Versiones.LongLength) // Only allow 1 equal CRC per version.
                                        {
                                            //Diccionario_Rutas[Recurso_Entrada.Versión] = Recurso_Entrada.Ruta;
                                            //Diccionario_Nombres[Recurso_Entrada.Versión] = Recurso_Entrada.Nombre;
                                            foreach (Recursos Recurso_Salida in Matriz_Listas_Recursos_Minecraft[Índice_Salida])
                                            {
                                                if (Diccionario_CRCs[Recurso_Salida.CRC_32] <= Matriz_Versiones.LongLength) // Only allow 1 equal CRC per version.
                                                {
                                                    if (Recurso_Entrada.CRC_32 == Recurso_Salida.CRC_32)
                                                    {
                                                        Diccionario_Rutas[Recurso_Salida.Versión] = Recurso_Salida.Ruta;
                                                        Diccionario_Nombres[Recurso_Salida.Versión] = Recurso_Salida.Nombre;
                                                        Encontrado = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (Encontrado)
                                    {
                                        bool Repetido = false;
                                        foreach (Recursos Recurso in Lista_Recursos)
                                        {
                                            bool Diccionario_Repetido = true;
                                            foreach (string Versión in Matriz_Versiones)
                                            {
                                                if (!Recurso.Diccionario_Rutas.ContainsKey(Versión) || !Diccionario_Rutas.ContainsKey(Versión) || string.Compare(Recurso.Diccionario_Rutas[Versión], Diccionario_Rutas[Versión], true) != 0)
                                                {
                                                    Diccionario_Repetido = false;
                                                    break;
                                                }
                                            }
                                            if (Diccionario_Repetido)
                                            {
                                                Repetido = true;
                                                break;
                                            }
                                        }
                                        if (!Repetido) Lista_Recursos.Add(new Recursos(Diccionario_Rutas, Diccionario_Nombres, null, null, 0, null));
                                    }
                                    else // Resource not found, add it to the manual list:
                                    {
                                        // ...
                                    }
                                }
                            }
                        }
                    }



                    return new Carpetas(null, null, Lista_Recursos.ToArray());
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return new Carpetas();
        }
    }
}

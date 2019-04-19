using Ionic.Zlib;
using Microsoft.Win32;
using Minecraft_Tools.Properties;
using Substrate;
using Substrate.Core;
using Substrate_Jupisoft.Nbt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Exportador_Estructuras_Internas : Form
    {
        public Ventana_Exportador_Estructuras_Internas()
        {
            InitializeComponent();
        }

        internal static readonly string Ruta_Estructuras = Application.StartupPath + "\\Structures";

        internal Thread Subproceso = null;
        internal bool Pendiente_Subproceso_Abortar = false;
        internal bool Subproceso_Activo = false;

        internal enum Tipos_Recetas : int
        {
            Crafting_shaped,
            Crafting_shapeless,
            Smelting,
        }

        /// <summary>
        /// Structure that holds up all the information about a Minecraft recipe.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Recetas
        {
            internal string Nombre;
            internal string Recurso;
            internal Tipos_Recetas Tipo;
            internal string Grupo;
            internal List<string> Lista_Receta;
            internal List<string> Lista_Recursos;
            internal double Experiencia;
            internal double Tiempo;

            internal Recetas(string Nombre, string Recurso, Tipos_Recetas Tipo, string Grupo, List<string> Lista_Receta, List<string> Lista_Recursos, double Experiencia, double Tiempo)
            {
                this.Nombre = Nombre;
                this.Recurso = Nombre.Replace(' ', '_').Replace('~', '_').Replace('=', '_').Replace('+', '_').Replace('-', '_').Replace('\\', '_').Replace('/', '_').Replace(':', '_').Replace('*', '_').Replace('?', '_').Replace('\"', '_').Replace('<', '_').Replace('>', '_').Replace('|', '_').Replace('.', '_');
                this.Tipo = Tipo;
                this.Grupo = Grupo;
                this.Lista_Receta = Lista_Receta;
                this.Lista_Recursos = Lista_Recursos;
                this.Experiencia = Experiencia;
                this.Tiempo = Tiempo;
            }

            internal static readonly Recetas[] Matriz_Recetas = new Recetas[]
            {
                /*new Recetas
                (
                    "",
                    "",
                    "",
                    "",
                    ""
                ),*/
            };
        }

        /// <summary>
        /// Structure that holds up all the information about a Minecraft NBT structure as 1.12.2- world format.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Estructuras
        {
            /// <summary>
            /// The original file name.
            /// </summary>
            internal string Nombre;
            internal int Dimensiones_X;
            internal int Dimensiones_Y;
            internal int Dimensiones_Z;
            internal string Texto_Autor;
            internal int Versión_Data;
            internal int[,,] Matriz_Índices_Paleta;
            internal List<List<byte>> Lista_Paletas_ID;
            internal List<List<byte>> Lista_Paletas_Data;

            internal Estructuras(string Nombre, int Dimensiones_X, int Dimensiones_Y, int Dimensiones_Z, string Texto_Autor, int Versión_Data, int[,,] Matriz_Índices_Paleta, List<List<byte>> Lista_Paletas_ID, List<List<byte>> Lista_Paletas_Data)
            {
                this.Nombre = Nombre;
                this.Dimensiones_X = Dimensiones_X;
                this.Dimensiones_Y = Dimensiones_Y;
                this.Dimensiones_Z = Dimensiones_Z;
                this.Texto_Autor = Texto_Autor;
                this.Versión_Data = Versión_Data;
                this.Matriz_Índices_Paleta = Matriz_Índices_Paleta;
                this.Lista_Paletas_ID = Lista_Paletas_ID;
                this.Lista_Paletas_Data = Lista_Paletas_Data;
            }

            /*internal static readonly Estructuras[] Matriz_Estructuras = new Estructuras[]
            {
                new Recetas
                (
                    "",
                    "",
                    "",
                    "",
                    ""
                ),
            };*/
        }

        internal readonly string Texto_Título = "Minecraft Internal Structures Exporter for " + Program.Texto_Usuario + " by Jupisoft";
        internal bool Variable_Siempre_Visible = false;
        internal bool Variable_Excepción = false;
        internal bool Variable_Excepción_Imagen = false;
        internal int Variable_Excepción_Total = 0;
        internal bool Variable_Memoria = false;
        internal static Stopwatch FPS_Cronómetro = Stopwatch.StartNew();
        internal long FPS_Segundo_Anterior = 0L;
        internal long FPS_Temporal = 0L;
        internal long FPS_Real = 0L;
        internal bool Ocupado = false;
        internal Stopwatch Cronómetro_Total = new Stopwatch();

        private void Ventana_Exportador_Estructuras_Internas_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                this.Text = Texto_Título + " - [The original NBT files will never be modified]";
                this.WindowState = FormWindowState.Maximized;
                Ocupado = true;
                ComboBox_Ruta.Items.Add(Ruta_Estructuras);
                ComboBox_Ruta.SelectedIndex = 0;
                if (Directory.Exists(Ruta_Estructuras))
                {
                    string[] Matriz_Rutas = Directory.GetDirectories(Ruta_Estructuras, "*", SearchOption.AllDirectories);
                    if (Matriz_Rutas != null && Matriz_Rutas.Length > 0)
                    {
                        if (Matriz_Rutas.Length > 1) Array.Sort(Matriz_Rutas);
                        ComboBox_Ruta.Items.AddRange(Matriz_Rutas);
                        Matriz_Rutas = null;
                    }
                }
                Registro_Cargar_Opciones();
                Ocupado = false;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Exportador_Estructuras_Internas_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Exportador_Estructuras_Internas_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Subproceso_Activo)
                {
                    if (MessageBox.Show(this, "Currently there is a world conversion in progress.\r\nDo you want to cancel it, but saving what has been done?", Program.Texto_Título_Versión, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes && Subproceso_Activo) // Since a message can stay on top for infinite time, double check if it's still converting.
                    {
                        Pendiente_Subproceso_Abortar = true;
                    }
                    e.Cancel = true;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Exportador_Estructuras_Internas_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Exportador_Estructuras_Internas_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, true) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Exportador_Estructuras_Internas_DragDrop(object sender, DragEventArgs e)
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
                                if (!string.IsNullOrEmpty(Ruta) && (File.Exists(Ruta) || Directory.Exists(Ruta)))
                                {
                                    //Minecraft.Información_Niveles Información_Nivel = Minecraft.Información_Niveles.Obtener_Información_Nivel(Ruta);
                                    SystemSounds.Beep.Play();
                                    break;
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

        private void Ventana_Exportador_Estructuras_Internas_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Exportador_Estructuras_Internas_KeyDown(object sender, KeyEventArgs e)
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
                    else if (e.KeyCode == Keys.Enter)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        Botón_Exportar.PerformClick();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        internal void Registro_Cargar_Opciones()
        {
            try
            {
                /*RegistryKey Clave = Registry.CurrentUser.CreateSubKey("Software\\Jupisoft\\Minecraft Tools\\" + Program.Texto_Versión + "\\Template");

                // bool
                try { Variable_ = bool.Parse((string)Clave.GetValue("Variable_", bool.TrueString)); }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; Variable_ = true; }

                // int
                try { Variable_ = (int)Clave.GetValue("Variable_", 0); }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; Variable_ = 0; }
                
                // Correct any bad value after loading:
                if ((int)Variable_ < 0 || (int)Variable_ > (int)Variables.Variable) Variable_ = Variables.Variable;

                // Apply all the loaded values:
                ComboBox_Variable_.SelectedIndex = (int)Variable_;

                Menú_Contextual_Variable_.Checked = Variable_;*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        internal void Registro_Guardar_Opciones()
        {
            try
            {
                /*RegistryKey Clave = Registry.CurrentUser.CreateSubKey("Software\\Jupisoft\\Minecraft Tools\\" + Program.Texto_Versión + "\\Template");
                string[] Matriz_Nombres = Clave.GetValueNames();
                if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                {
                    for (int Índice = 0; Índice < Matriz_Nombres.Length; Índice++)
                    {
                        Clave.DeleteValue(Matriz_Nombres[Índice]);
                    }
                }
                Matriz_Nombres = null;
                
                // bool
                try { Clave.SetValue("Variable_", Variable_doDaylightCycle.ToString(), RegistryValueKind.String); }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }

                // int
                try { Clave.SetValue("Tickspeed", (int)Variable_, RegistryValueKind.DWord); }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        internal void Registro_Restablecer_Opciones()
        {
            try
            {
                /*RegistryKey Clave = Registry.CurrentUser.CreateSubKey("Software\\Jupisoft\\Minecraft Tools\\" + Program.Texto_Versión + "\\Template");
                string[] Matriz_Nombres = Clave.GetValueNames();
                if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                {
                    for (int Índice = 0; Índice < Matriz_Nombres.Length; Índice++)
                    {
                        try { Clave.DeleteValue(Matriz_Nombres[Índice]); }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                    }
                    Matriz_Nombres = null;
                }
                Clave.Close();
                Clave = null;*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Visor_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana_Visor_Ayuda Ventana = new Ventana_Visor_Ayuda();
                Ventana.Ayuda = Ventana_Visor_Ayuda.Ayudas.Main_window;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Acerca_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana_Acerca Ventana = new Ventana_Acerca();
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Depurador_Excepciones_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana_Depurador_Excepciones Ventana = new Ventana_Depurador_Excepciones();
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Abrir_Carpeta_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Crear_Carpetas(Program.Ruta_Minecraft);
                Program.Ejecutar_Ruta(Program.Ruta_Guardado_Minecraft, ProcessWindowStyle.Maximized);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Actualizar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Copiar_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (Picture.Image != null)
                {
                    Clipboard.SetImage(Picture.Image);
                    SystemSounds.Asterisk.Play();
                }*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (Picture.Image != null)
                {
                    Program.Crear_Carpetas(Program.Ruta_Minecraft);
                    Picture.Image.Save(Program.Ruta_Minecraft + "\\" + Program.Obtener_Nombre_Temporal_Sin_Guiones() + ".png", ImageFormat.Png);
                    SystemSounds.Asterisk.Play();
                }*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Barra_Estado_Botón_Excepción_Click(object sender, EventArgs e)
        {
            try
            {
                Variable_Excepción = false;
                Variable_Excepción_Imagen = false;
                Variable_Excepción_Total = 0;
                Barra_Estado_Botón_Excepción.Visible = false;
                Barra_Estado_Separador_1.Visible = false;
                Barra_Estado_Botón_Excepción.Image = Resources.Excepción_Gris;
                Barra_Estado_Botón_Excepción.ForeColor = Color.Black;
                Barra_Estado_Botón_Excepción.Text = "Exceptions: 0";
                Ventana_Depurador_Excepciones Ventana = new Ventana_Depurador_Excepciones();
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Temporizador_Principal_Tick(object sender, EventArgs e)
        {
            try
            {
                int Tick = Environment.TickCount;
                try
                {
                    if (Variable_Excepción)
                    {
                        if ((Environment.TickCount / 500) % 2 == 0)
                        {
                            if (!Variable_Excepción_Imagen)
                            {
                                Variable_Excepción_Imagen = true;
                                Barra_Estado_Botón_Excepción.Image = Resources.Excepción;
                                Barra_Estado_Botón_Excepción.ForeColor = Color.Red;
                                Barra_Estado_Botón_Excepción.Text = "Exceptions: " + Program.Traducir_Número(Variable_Excepción_Total);
                            }
                        }
                        else
                        {
                            if (Variable_Excepción_Imagen)
                            {
                                Variable_Excepción_Imagen = false;
                                Barra_Estado_Botón_Excepción.Image = Resources.Excepción_Gris;
                                Barra_Estado_Botón_Excepción.ForeColor = Color.Black;
                                Barra_Estado_Botón_Excepción.Text = "Exceptions: " + Program.Traducir_Número(Variable_Excepción_Total);
                            }
                        }
                        if (!Barra_Estado_Botón_Excepción.Visible) Barra_Estado_Botón_Excepción.Visible = true;
                        if (!Barra_Estado_Separador_1.Visible) Barra_Estado_Separador_1.Visible = true;
                    }
                }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
                try
                {
                    try
                    {
                        if (Tick % 250 == 0) // Only update every quarter second
                        {
                            if (Program.Rendimiento_Procesador != null)
                            {
                                double CPU = (double)Program.Rendimiento_Procesador.NextValue();
                                if (CPU < 0d) CPU = 0d;
                                else if (CPU > 100d) CPU = 100d;
                                Barra_Estado_Etiqueta_CPU.Text = "CPU: " + Program.Traducir_Número_Decimales_Redondear(CPU, 2) + " %";
                            }
                            Program.Proceso.Refresh();
                            long Memoria_Bytes = Program.Proceso.PagedMemorySize64;
                            Barra_Estado_Etiqueta_Memoria.Text = "RAM: " + Program.Traducir_Tamaño_Bytes_Automático(Memoria_Bytes, 2, true);
                            if (Memoria_Bytes < 4294967296L) // < 4 GB
                            {
                                if (Variable_Memoria)
                                {
                                    Variable_Memoria = false;
                                    Barra_Estado_Etiqueta_Memoria.ForeColor = Color.Black;
                                }
                            }
                            else // >= 4 GB
                            {
                                if ((Environment.TickCount / 500) % 2 == 0)
                                {
                                    if (!Variable_Memoria)
                                    {
                                        Variable_Memoria = true;
                                        Barra_Estado_Etiqueta_Memoria.ForeColor = Color.Red;
                                    }
                                }
                                else
                                {
                                    if (Variable_Memoria)
                                    {
                                        Variable_Memoria = false;
                                        Barra_Estado_Etiqueta_Memoria.ForeColor = Color.Black;
                                    }
                                }
                            }
                        }
                    }
                    catch { Barra_Estado_Etiqueta_Memoria.Text = "RAM: ? MB (? GB)"; }
                }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
                long FPS_Milisegundo = FPS_Cronómetro.ElapsedMilliseconds;
                long FPS_Segundo = FPS_Milisegundo / 1000L;
                if (FPS_Segundo != FPS_Segundo_Anterior)
                {
                    FPS_Segundo_Anterior = FPS_Segundo;
                    FPS_Real = FPS_Temporal;
                    Barra_Estado_Etiqueta_FPS.Text = FPS_Real.ToString() + " FPS";
                    FPS_Temporal = 0L;
                }
                FPS_Temporal++;
                if (Cronómetro_Total != null && Cronómetro_Total.IsRunning) // Show the conversion time.
                {
                    this.Text = Texto_Título + " - [Conversion time: " + Program.Traducir_Intervalo_Horas_Minutos_Segundos(Cronómetro_Total.Elapsed) + "]";
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Exportar_Click(object sender, EventArgs e)
        {
            try
            {
                string Ruta_Entrada = ComboBox_Ruta.Text;
                if (string.IsNullOrEmpty(Ruta_Entrada) || !Directory.Exists(Ruta_Entrada))
                {
                    Ruta_Entrada = Ruta_Estructuras;
                    Program.Crear_Carpetas(Ruta_Estructuras);
                } // At least the path folder should always exist.
                string[] Matriz_Rutas = Directory.GetFiles(Ruta_Entrada, "*.nbt", SearchOption.AllDirectories);
                if (Matriz_Rutas != null && Matriz_Rutas.Length > 0)
                {
                    if (Matriz_Rutas.Length > 1) Array.Sort(Matriz_Rutas);
                    Botón_Exportar.Enabled = false;
                    Subproceso = new Thread(new ParameterizedThreadStart(Subproceso_DoWork));
                    Subproceso.IsBackground = true;
                    Subproceso.Priority = ThreadPriority.Normal;
                    Subproceso.Start(Matriz_Rutas);
                    Matriz_Rutas = null;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        /// <summary>
        /// Thread function that converts the available dimensions of any 1.13+ Minecraft world.
        /// </summary>
        internal void Subproceso_DoWork(object Objeto)
        {
            bool Subproceso_Abortado = false; // Used to know if the window must be closed.
            try
            {
                Subproceso_Activo = true;
                Cronómetro_Total = Stopwatch.StartNew();
                this.Invoke(new Invocación.Delegado_Control_Cursor(Invocación.Ejecutar_Delegado_Control_Cursor), new object[] { this, Cursors.WaitCursor });
                this.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso, 0 });
                string[] Matriz_Rutas = Objeto as string[];
                if (Matriz_Rutas != null && Matriz_Rutas.Length > 0)
                {
                    int Total_Estructuras_NBT = Matriz_Rutas.Length;
                    this.Invoke(new Invocación.Delegado_ProgressBar_Maximum(Invocación.Ejecutar_Delegado_ProgressBar_Maximum), new object[] { Barra_Progreso, Total_Estructuras_NBT * 2 });
                    int Índice_Archivo = 0;

                    // Assume that at least some file will be valid, so start a new world now.
                    string Ruta_Salida = Program.Ruta_Guardado_Minecraft + "\\" + Program.Obtener_Nombre_Temporal() + " Structures";
                    if (Directory.Exists(Ruta_Salida))
                    {
                        this.Invoke(new Invocación.Delegado_IWin32Window_MessageBox(Invocación.Ejecutar_Delegado_IWin32Window_MessageBox), new object[] { this, "Somehow the directory name for the new Minecraft map already exists.\r\nPlease try it again if the system clock is running properly.\r\nPath: \"" + Ruta_Salida + "\".", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning });
                        Ruta_Salida = null;
                        return;
                    }
                    Program.Crear_Carpetas(Ruta_Salida);
                    AnvilWorld Mundo = AnvilWorld.Create(Ruta_Salida);
                    Mundo.Level.LevelName = Path.GetFileName(Ruta_Salida);
                    Mundo.Level.UseMapFeatures = true; // ?
                                                       //Mundo.Level.GeneratorOptions = "1;minecraft:bedrock"; // Not used for now.
                    Mundo.Level.GameType = GameType.CREATIVE;
                    Mundo.Level.Spawn = new SpawnPoint(16, 1, 16);
                    Mundo.Level.AllowCommands = true; // Allow cheats.
                    Mundo.Level.GameRules.DoMobSpawning = true; // Spawn mobs.
                    Mundo.Level.GameRules.DoFireTick = false; // Prevent the new level to burn out.
                    Mundo.Level.GameRules.MobGriefing = false; // Prevent the mobs to destroy anything.
                    Mundo.Level.GameRules.KeepInventory = true; // Keep the player inventory.
                    //Mundo.Level.RainTime = (int)Información_Nivel.RainTime;
                    //Mundo.Level.IsRaining = Información_Nivel.Raining != 0L;
                    Mundo.Level.Player = new Player();
                    Mundo.Level.Player.Dimension = 0; // 0 = Overworld, -1 = Nether, +1 = The End.
                    Mundo.Level.Player.Position = new Vector3();
                    Mundo.Level.Player.Position.X = 16d; // Try to spawn where the player was.
                    Mundo.Level.Player.Position.Y = 1d;
                    Mundo.Level.Player.Position.Z = 16d;
                    Substrate.Orientation Orientación = new Substrate.Orientation();
                    Orientación.Pitch = 0d; // -90º to +90º // 0º = Camera centered (looking into the horizon).
                    Orientación.Yaw = -45d; // -180º to +180º // -45º = Camera rotation (looking at the southeast).
                    Mundo.Level.Player.Rotation = Orientación;
                    Mundo.Level.Player.Spawn = new SpawnPoint(16, 1, 16);
                    Mundo.Level.Player.Abilities.Flying = true; // Start with creative flight enabled.
                    Mundo.Level.RandomSeed = 4; // Seed "4" with a lot of ocean around (and icebergs in 1.13+).
                    //Mundo.Level.ThunderTime = (int)Información_Nivel.ThunderTime;
                    //Mundo.Level.IsThundering = Información_Nivel.Thundering != 0L;
                    
                    IChunkManager Chunks_Overworld = Mundo.GetChunkManager(0); // Get ready to add chunks and blocks.
                    BlockManager Bloques_Overworld = Mundo.GetBlockManager(0);
                    List<Estructuras> Lista_Estructuras = new List<Estructuras>();
                    foreach (string Ruta in Matriz_Rutas)
                    {
                        try
                        {
                            Índice_Archivo++;
                            this.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso, Índice_Archivo });
                            FileStream Lector = new FileStream(Ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            if (Lector != null && Lector.Length > 0L)
                            {
                                NbtTree Árbol = null;
                                try
                                {
                                    Lector.Seek(0L, SeekOrigin.Begin);
                                    Árbol = new NbtTree();
                                    Árbol.ReadFrom(Lector);
                                }
                                catch { Árbol = null; }
                                if (Árbol == null || Árbol.Root == null)
                                {
                                    try
                                    {
                                        Lector.Seek(0L, SeekOrigin.Begin);
                                        Árbol = new NbtTree();
                                        Árbol.ReadFrom(new GZipStream(Lector, CompressionMode.Decompress));
                                    }
                                    catch { Árbol = null; }
                                }
                                if (Árbol == null || Árbol.Root == null)
                                {
                                    try
                                    {
                                        Lector.Seek(0L, SeekOrigin.Begin);
                                        Árbol = new NbtTree();
                                        Árbol.ReadFrom(new ZlibStream(Lector, CompressionMode.Decompress));
                                    }
                                    catch { Árbol = null; }
                                }
                                if (Árbol == null || Árbol.Root == null)
                                {
                                    try
                                    {
                                        Lector.Seek(0L, SeekOrigin.Begin);
                                        Árbol = new NbtTree();
                                        Árbol.ReadFrom(new DeflateStream(Lector, CompressionMode.Decompress));
                                    }
                                    catch { Árbol = null; }
                                }
                                if (Árbol != null && Árbol.Root != null && Árbol.Root.Keys != null && Árbol.Root.Keys.Count > 0)
                                {
                                    int Dimensiones_X = 0;
                                    int Dimensiones_Y = 0;
                                    int Dimensiones_Z = 0;
                                    foreach (string Clave in Árbol.Root.Keys)
                                    {
                                        try
                                        {
                                            if (Pendiente_Subproceso_Abortar)
                                            {
                                                Pendiente_Subproceso_Abortar = false;
                                                Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                Chunks_Overworld = null;
                                                Bloques_Overworld = null;
                                                Mundo.Save(); // Save the part of the world already generated.
                                                Mundo = null;
                                                Subproceso_Abortado = true;
                                                return; // Cancel safely before time.
                                            }
                                            if (string.Compare(Clave, "size", true) == 0)
                                            {
                                                TagNodeList Lista_Int = Árbol.Root[Clave] as TagNodeList;
                                                if (Lista_Int != null && Lista_Int.Count >= 3)
                                                {
                                                    try { Dimensiones_X = Lista_Int[0].ToTagInt(); }
                                                    catch { Dimensiones_X = 0; }
                                                    try { Dimensiones_Y = Lista_Int[1].ToTagInt(); }
                                                    catch { Dimensiones_Y = 0; }
                                                    try { Dimensiones_Z = Lista_Int[2].ToTagInt(); }
                                                    catch { Dimensiones_Z = 0; }
                                                    Lista_Int = null;
                                                }
                                                break;
                                            }
                                        }
                                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                    }
                                    if (Dimensiones_X > 0 && Dimensiones_Y > 0 && Dimensiones_Z > 0) // Add the structure.
                                    {
                                        int Total_Bloques = Dimensiones_X * Dimensiones_Y * Dimensiones_Z;
                                        string Texto_Autor = null;
                                        foreach (string Clave in Árbol.Root.Keys)
                                        {
                                            try
                                            {
                                                if (Pendiente_Subproceso_Abortar)
                                                {
                                                    Pendiente_Subproceso_Abortar = false;
                                                    Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                    Chunks_Overworld = null;
                                                    Bloques_Overworld = null;
                                                    Mundo.Save(); // Save the part of the world already generated.
                                                    Mundo = null;
                                                    Subproceso_Abortado = true;
                                                    return; // Cancel safely before time.
                                                }
                                                if (string.Compare(Clave, "author", true) == 0)
                                                {
                                                    TagNodeString Nodo_String = Árbol.Root[Clave] as TagNodeString;
                                                    if (Nodo_String != null)
                                                    {
                                                        try { Texto_Autor = Nodo_String.ToString(); }
                                                        catch { Texto_Autor = null; }
                                                        Nodo_String = null;
                                                    }
                                                    break;
                                                }
                                            }
                                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                        }
                                        int Versión_Data = -1;
                                        foreach (string Clave in Árbol.Root.Keys)
                                        {
                                            try
                                            {
                                                if (Pendiente_Subproceso_Abortar)
                                                {
                                                    Pendiente_Subproceso_Abortar = false;
                                                    Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                    Chunks_Overworld = null;
                                                    Bloques_Overworld = null;
                                                    Mundo.Save(); // Save the part of the world already generated.
                                                    Mundo = null;
                                                    Subproceso_Abortado = true;
                                                    return; // Cancel safely before time.
                                                }
                                                if (string.Compare(Clave, "DataVersion", true) == 0) // Made for 1477.
                                                {
                                                    TagNodeInt Nodo_Int = Árbol.Root[Clave] as TagNodeInt;
                                                    if (Nodo_Int != null)
                                                    {
                                                        try { Versión_Data = Nodo_Int; } // Ignore it for now.
                                                        catch { Versión_Data = -1; }
                                                        Nodo_Int = null;
                                                    }
                                                    break;
                                                }
                                            }
                                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                        }
                                        int Índice_Paleta_Máximo = -1;
                                        int[,,] Matriz_Índices_Paleta = new int[Dimensiones_X, Dimensiones_Y, Dimensiones_Z]; // Palette indexes.
                                        for (int Índice_Z = 0; Índice_Z < Dimensiones_Z; Índice_Z++)
                                        {
                                            for (int Índice_Y = 0; Índice_Y < Dimensiones_Y; Índice_Y++)
                                            {
                                                for (int Índice_X = 0; Índice_X < Dimensiones_X; Índice_X++)
                                                {
                                                    Matriz_Índices_Paleta[Índice_X, Índice_Y, Índice_Z] = -1; // Should be changed to air.
                                                }
                                            }
                                        }
                                        foreach (string Clave in Árbol.Root.Keys)
                                        {
                                            try
                                            {
                                                if (Pendiente_Subproceso_Abortar)
                                                {
                                                    Pendiente_Subproceso_Abortar = false;
                                                    Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                    Chunks_Overworld = null;
                                                    Bloques_Overworld = null;
                                                    Mundo.Save(); // Save the part of the world already generated.
                                                    Mundo = null;
                                                    Subproceso_Abortado = true;
                                                    return; // Cancel safely before time.
                                                }
                                                if (string.Compare(Clave, "blocks", true) == 0)
                                                {
                                                    TagNodeList Nodo_Lista = Árbol.Root[Clave] as TagNodeList;
                                                    if (Nodo_Lista != null && Nodo_Lista.Count > 0)
                                                    {
                                                        foreach (TagNodeCompound Nodo in Nodo_Lista)
                                                        {
                                                            try
                                                            {
                                                                int X = -1;
                                                                int Y = -1;
                                                                int Z = -1;
                                                                int Índice_Paleta = -1;
                                                                foreach (string Subclave in Nodo.Keys)
                                                                {
                                                                    try
                                                                    {
                                                                        if (Pendiente_Subproceso_Abortar)
                                                                        {
                                                                            Pendiente_Subproceso_Abortar = false;
                                                                            Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                                            Chunks_Overworld = null;
                                                                            Bloques_Overworld = null;
                                                                            Mundo.Save(); // Save the part of the world already generated.
                                                                            Mundo = null;
                                                                            Subproceso_Abortado = true;
                                                                            return; // Cancel safely before time.
                                                                        }
                                                                        if (string.Compare(Subclave, "pos", true) == 0)
                                                                        {
                                                                            TagNodeList Lista_Int = Nodo[Subclave] as TagNodeList;
                                                                            if (Lista_Int != null && Lista_Int.Count >= 3)
                                                                            {
                                                                                try { X = Lista_Int[0].ToTagInt(); }
                                                                                catch { X = -1; }
                                                                                try { Y = Lista_Int[1].ToTagInt(); }
                                                                                catch { Y = -1; }
                                                                                try { Z = Lista_Int[2].ToTagInt(); }
                                                                                catch { Z = -1; }
                                                                                Lista_Int = null;
                                                                            }
                                                                            break;
                                                                        }
                                                                    }
                                                                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                                                }
                                                                if (X > -1 && Y > -1 && Z > -1 && X < Dimensiones_X && Y < Dimensiones_Y && Z < Dimensiones_Z) // Within bounds.
                                                                {
                                                                    foreach (string Subclave in Nodo.Keys)
                                                                    {
                                                                        try
                                                                        {
                                                                            if (Pendiente_Subproceso_Abortar)
                                                                            {
                                                                                Pendiente_Subproceso_Abortar = false;
                                                                                Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                                                Chunks_Overworld = null;
                                                                                Bloques_Overworld = null;
                                                                                Mundo.Save(); // Save the part of the world already generated.
                                                                                Mundo = null;
                                                                                Subproceso_Abortado = true;
                                                                                return; // Cancel safely before time.
                                                                            }
                                                                            if (string.Compare(Subclave, "state", true) == 0)
                                                                            {
                                                                                TagNodeInt Nodo_Int = Nodo[Subclave] as TagNodeInt;
                                                                                if (Nodo_Int != null)
                                                                                {
                                                                                    try
                                                                                    {
                                                                                        Índice_Paleta = Nodo_Int;
                                                                                        if (Índice_Paleta > Índice_Paleta_Máximo) Índice_Paleta_Máximo = Índice_Paleta;
                                                                                    }
                                                                                    catch { Índice_Paleta = -1; }
                                                                                    Nodo_Int = null;
                                                                                }
                                                                                break;
                                                                            }
                                                                        }
                                                                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                                                    }
                                                                    if (Índice_Paleta > -1 && Índice_Paleta < Total_Bloques) // Add the block.
                                                                    {
                                                                        Matriz_Índices_Paleta[X, Y, Z] = Índice_Paleta;
                                                                    }
                                                                }
                                                            }
                                                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                                        }
                                                        Nodo_Lista = null;
                                                    }
                                                    break;
                                                }
                                            }
                                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                        }
                                        Índice_Paleta_Máximo++; // This is the total length of the palettes. It shouldn't be zero.
                                        // Assume that the palette indexes were decoded without errors. Might need a check in the future.
                                        List<List<byte>> Lista_Paletas_ID = new List<List<byte>>(); // 1.13+ to 1.12.2- block conversions.
                                        List<List<byte>> Lista_Paletas_Data = new List<List<byte>>(); // Add all the structure variations.
                                        foreach (string Clave in Árbol.Root.Keys)
                                        {
                                            try
                                            {
                                                if (Pendiente_Subproceso_Abortar)
                                                {
                                                    Pendiente_Subproceso_Abortar = false;
                                                    Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                    Chunks_Overworld = null;
                                                    Bloques_Overworld = null;
                                                    Mundo.Save(); // Save the part of the world already generated.
                                                    Mundo = null;
                                                    Subproceso_Abortado = true;
                                                    return; // Cancel safely before time.
                                                }
                                                if (string.Compare(Clave, "palettes", true) == 0) // Multiple palettes version.
                                                {
                                                    TagNodeList Nodo_Listas = Árbol.Root[Clave] as TagNodeList;
                                                    if (Nodo_Listas != null && Nodo_Listas.Count > 0)
                                                    {
                                                        int Índice_Paleta = -1;
                                                        foreach (TagNodeList Nodo_Lista_Paleta in Nodo_Listas)
                                                        {
                                                            try
                                                            {
                                                                Índice_Paleta++;
                                                                Lista_Paletas_ID.Add(new List<byte>(new byte[Índice_Paleta_Máximo])); // Add new lists for each structure palette.
                                                                Lista_Paletas_Data.Add(new List<byte>(new byte[Índice_Paleta_Máximo]));
                                                                int Índice_Bloque = -1;
                                                                foreach (TagNodeCompound Nodo_Bloque in Nodo_Lista_Paleta)
                                                                {
                                                                    try
                                                                    {
                                                                        Índice_Bloque++;
                                                                        List<string> Lista_Propiedades = new List<string>();
                                                                        foreach (string Subclave in Nodo_Bloque.Keys)
                                                                        {
                                                                            try
                                                                            {
                                                                                if (Pendiente_Subproceso_Abortar)
                                                                                {
                                                                                    Pendiente_Subproceso_Abortar = false;
                                                                                    Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                                                    Chunks_Overworld = null;
                                                                                    Bloques_Overworld = null;
                                                                                    Mundo.Save(); // Save the part of the world already generated.
                                                                                    Mundo = null;
                                                                                    Subproceso_Abortado = true;
                                                                                    return; // Cancel safely before time.
                                                                                }
                                                                                if (string.Compare(Subclave, "Properties", true) == 0)
                                                                                {
                                                                                    TagNodeCompound Nodo_Propiedades = Nodo_Bloque[Subclave] as TagNodeCompound;
                                                                                    if (Nodo_Propiedades != null && Nodo_Propiedades.Count > 0)
                                                                                    {
                                                                                        foreach (string Clave_Propiedad in Nodo_Propiedades.Keys)
                                                                                        {
                                                                                            string Propiedad = null;
                                                                                            try { Propiedad = Clave_Propiedad + ": " + (Nodo_Propiedades[Clave_Propiedad] as TagNodeString); }
                                                                                            catch { Propiedad = null; }
                                                                                            Lista_Propiedades.Add(Propiedad);
                                                                                        }
                                                                                        Nodo_Propiedades = null;
                                                                                    }
                                                                                    break;
                                                                                }
                                                                            }
                                                                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                                                        }
                                                                        //if (Lista_Propiedades.Count > 1) Lista_Propiedades.Sort(); // Not really needed (only for debug).
                                                                        string Nombre_1_13 = "minecraft:air"; // Default.
                                                                        foreach (string Subclave in Nodo_Bloque.Keys)
                                                                        {
                                                                            try
                                                                            {
                                                                                if (Pendiente_Subproceso_Abortar)
                                                                                {
                                                                                    Pendiente_Subproceso_Abortar = false;
                                                                                    Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                                                    Chunks_Overworld = null;
                                                                                    Bloques_Overworld = null;
                                                                                    Mundo.Save(); // Save the part of the world already generated.
                                                                                    Mundo = null;
                                                                                    Subproceso_Abortado = true;
                                                                                    return; // Cancel safely before time.
                                                                                }
                                                                                if (string.Compare(Subclave, "Name", true) == 0)
                                                                                {
                                                                                    try { Nombre_1_13 = Nodo_Bloque[Subclave] as TagNodeString; }
                                                                                    catch { Nombre_1_13 = "minecraft:air"; }
                                                                                    break;
                                                                                }
                                                                            }
                                                                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                                                        }
                                                                        byte Data;
                                                                        byte ID = Minecraft_Bloques_1_13_a_1_12.Obtener_ID_Data_Bloque_Ajustados(Nombre_1_13, Lista_Propiedades, out Data);
                                                                        Lista_Paletas_ID[Índice_Paleta][Índice_Bloque] = ID;
                                                                        Lista_Paletas_Data[Índice_Paleta][Índice_Bloque] = Data;
                                                                    }
                                                                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                                                }
                                                            }
                                                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                                        }
                                                        Nodo_Listas = null;
                                                    }
                                                    break;
                                                }
                                                else if (string.Compare(Clave, "palette", true) == 0) // Single palette version.
                                                {
                                                    TagNodeList Nodo_Lista_Paleta = Árbol.Root[Clave] as TagNodeList;
                                                    if (Nodo_Lista_Paleta != null && Nodo_Lista_Paleta.Count > 0)
                                                    {
                                                        int Índice_Paleta = 0;
                                                        Lista_Paletas_ID.Add(new List<byte>(new byte[Índice_Paleta_Máximo])); // Add new lists for each structure palette.
                                                        Lista_Paletas_Data.Add(new List<byte>(new byte[Índice_Paleta_Máximo]));
                                                        int Índice_Bloque = -1;
                                                        foreach (TagNodeCompound Nodo_Bloque in Nodo_Lista_Paleta)
                                                        {
                                                            try
                                                            {
                                                                Índice_Bloque++;
                                                                List<string> Lista_Propiedades = new List<string>();
                                                                foreach (string Subclave in Nodo_Bloque.Keys)
                                                                {
                                                                    try
                                                                    {
                                                                        if (Pendiente_Subproceso_Abortar)
                                                                        {
                                                                            Pendiente_Subproceso_Abortar = false;
                                                                            Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                                            Chunks_Overworld = null;
                                                                            Bloques_Overworld = null;
                                                                            Mundo.Save(); // Save the part of the world already generated.
                                                                            Mundo = null;
                                                                            Subproceso_Abortado = true;
                                                                            return; // Cancel safely before time.
                                                                        }
                                                                        if (string.Compare(Subclave, "Properties", true) == 0)
                                                                        {
                                                                            TagNodeCompound Nodo_Propiedades = Nodo_Bloque[Subclave] as TagNodeCompound;
                                                                            if (Nodo_Propiedades != null && Nodo_Propiedades.Count > 0)
                                                                            {
                                                                                foreach (string Clave_Propiedad in Nodo_Propiedades.Keys)
                                                                                {
                                                                                    string Propiedad = null;
                                                                                    try { Propiedad = Clave_Propiedad + ": " + (Nodo_Propiedades[Clave_Propiedad] as TagNodeString); }
                                                                                    catch { Propiedad = null; }
                                                                                    Lista_Propiedades.Add(Propiedad);
                                                                                }
                                                                                Nodo_Propiedades = null;
                                                                            }
                                                                            break;
                                                                        }
                                                                    }
                                                                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                                                }
                                                                //if (Lista_Propiedades.Count > 1) Lista_Propiedades.Sort(); // Not really needed (only for debug).
                                                                string Nombre_1_13 = "minecraft:air"; // Default.
                                                                foreach (string Subclave in Nodo_Bloque.Keys)
                                                                {
                                                                    try
                                                                    {
                                                                        if (Pendiente_Subproceso_Abortar)
                                                                        {
                                                                            Pendiente_Subproceso_Abortar = false;
                                                                            Chunks_Overworld.Save(); // Save the part of the chunks already generated.
                                                                            Chunks_Overworld = null;
                                                                            Bloques_Overworld = null;
                                                                            Mundo.Save(); // Save the part of the world already generated.
                                                                            Mundo = null;
                                                                            Subproceso_Abortado = true;
                                                                            return; // Cancel safely before time.
                                                                        }
                                                                        if (string.Compare(Subclave, "Name", true) == 0)
                                                                        {
                                                                            try { Nombre_1_13 = Nodo_Bloque[Subclave] as TagNodeString; }
                                                                            catch { Nombre_1_13 = "minecraft:air"; }
                                                                            break;
                                                                        }
                                                                    }
                                                                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                                                }
                                                                byte Data;
                                                                byte ID = Minecraft_Bloques_1_13_a_1_12.Obtener_ID_Data_Bloque_Ajustados(Nombre_1_13, Lista_Propiedades, out Data);
                                                                Lista_Paletas_ID[Índice_Paleta][Índice_Bloque] = ID;
                                                                Lista_Paletas_Data[Índice_Paleta][Índice_Bloque] = Data;
                                                            }
                                                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                                        }
                                                    }
                                                    break;
                                                }
                                            }
                                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                                        }
                                        Lista_Estructuras.Add(new Estructuras(Path.GetDirectoryName(Ruta) + "\\" + Path.GetFileNameWithoutExtension(Ruta), Dimensiones_X, Dimensiones_Y, Dimensiones_Z, Texto_Autor, Versión_Data, Matriz_Índices_Paleta, Lista_Paletas_ID, Lista_Paletas_Data));
                                    }
                                    Árbol = null;
                                    Lector.Close();
                                    Lector.Dispose();
                                    Lector = null;
                                    GC.Collect(); // Recover RAM memory after every NBT file.
                                    GC.GetTotalMemory(true);
                                }
                            }
                        }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                    }
                    Matriz_Rutas = null;
                    if (Lista_Estructuras != null && Lista_Estructuras.Count > 0) // Add them to the world.
                    {
                        int Separación_Estructuras = 4; // Space between different structures.
                        int Longitud_X = Separación_Estructuras; // Total X size, start with a space.
                        int Longitud_Z = 0; // Total Z size.
                        foreach (Estructuras Estructura in Lista_Estructuras)
                        {
                            try
                            {
                                for (int Índice_Paleta = 0; Índice_Paleta < Estructura.Lista_Paletas_ID.Count; Índice_Paleta++)
                                {
                                    Longitud_X += Estructura.Dimensiones_X + Separación_Estructuras; // End with a space.
                                }
                                if (Estructura.Dimensiones_Z > Longitud_Z) Longitud_Z = Estructura.Dimensiones_Z;
                            }
                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                        }
                        Longitud_X += 32; // Add 2 empty chunks around, so 32 blocks in total.
                        Longitud_Z += 32 + (Separación_Estructuras * 2); // Add 2 empty chunks and spaces around.
                        if (Longitud_X % 16 != 0) Longitud_X += 16 - (Longitud_X % 16); // Sync it with the walls and chunks.
                        if (Longitud_Z % 16 != 0) Longitud_Z += 16 - (Longitud_Z % 16);
                        // Add all the needed chunks before the structures.
                        for (int Índice_Z = 0; Índice_Z < Longitud_Z; Índice_Z += 16)
                        {
                            for (int Índice_X = 0; Índice_X < Longitud_X; Índice_X += 16)
                            {
                                ChunkRef Chunk = Chunks_Overworld.CreateChunk(Índice_X / 16, Índice_Z / 16);
                                Chunk.IsLightPopulated = true; // For 1.13+ conversion support.
                                Chunk.IsTerrainPopulated = true;
                                Chunk.Blocks.AutoLight = false;

                                // Do nothing else here...

                                Chunk.Blocks.RebuildHeightMap(); // Automatic height map.
                                //Chunk.Blocks.RebuildBlockLight(); // Automatic block light.
                                Chunk.Blocks.RebuildSkyLight(); // Automatic sky light.
                            }
                        }
                        AlphaBlock Bloque_Cristal = new AlphaBlock(20, 0); // Glass walls around to hold liquids.
                        for (int Índice_Y = 0; Índice_Y < 63; Índice_Y++) // Top glass wall.
                        {
                            for (int Índice_X = 0; Índice_X < Longitud_X - 1; Índice_X++)
                            {
                                Bloques_Overworld.SetBlock(Índice_X, Índice_Y, 0, Bloque_Cristal);
                                Bloques_Overworld.SetBlockLight(Índice_X, Índice_Y, 0, 15); // Maximum light.
                            }
                        }
                        for (int Índice_Y = 0; Índice_Y < 63; Índice_Y++) // Right glass wall.
                        {
                            for (int Índice_Z = 0; Índice_Z < Longitud_Z - 1; Índice_Z++)
                            {
                                Bloques_Overworld.SetBlock(Longitud_X - 1, Índice_Y, Índice_Z, Bloque_Cristal);
                                Bloques_Overworld.SetBlockLight(Longitud_X - 1, Índice_Y, Índice_Z, 15); // Maximum light.
                            }
                        }
                        for (int Índice_Y = 0; Índice_Y < 63; Índice_Y++) // Bottom glass wall.
                        {
                            for (int Índice_X = 1; Índice_X < Longitud_X; Índice_X++)
                            {
                                Bloques_Overworld.SetBlock(Índice_X, Índice_Y, Longitud_Z - 1, Bloque_Cristal);
                                Bloques_Overworld.SetBlockLight(Índice_X, Índice_Y, Longitud_Z - 1, 15); // Maximum light.
                            }
                        }
                        for (int Índice_Y = 0; Índice_Y < 63; Índice_Y++) // Left glass wall.
                        {
                            for (int Índice_Z = 1; Índice_Z < Longitud_Z; Índice_Z++)
                            {
                                Bloques_Overworld.SetBlock(0, Índice_Y, Índice_Z, Bloque_Cristal);
                                Bloques_Overworld.SetBlockLight(0, Índice_Y, Índice_Z, 15); // Maximum light.
                            }
                        }
                        AlphaBlock Bloque_Lecho_Roca = new AlphaBlock(7, 0); // Bedrock bottom layer to walk on.
                        for (int Índice_Z = 16; Índice_Z < Longitud_Z - 16; Índice_Z++)
                        {
                            for (int Índice_X = 16; Índice_X < Longitud_X - 16; Índice_X++)
                            {
                                Bloques_Overworld.SetBlock(Índice_X, 0, Índice_Z, Bloque_Lecho_Roca); // 1 bottom layer.
                            }
                        }
                        int X = 16 + Separación_Estructuras; // Skip 1 chunk around.
                        int Y = 1 + Separación_Estructuras; // Add bedrock and the air separation over it.
                        int Z = 16 + Separación_Estructuras; // Skip 1 chunk around.
                        int Índice_Estructura = Total_Estructuras_NBT;
                        foreach (Estructuras Estructura in Lista_Estructuras)
                        {
                            try
                            {
                                Índice_Estructura++;
                                this.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso, Índice_Estructura });
                                for (int Índice_Paleta = 0; Índice_Paleta < Estructura.Lista_Paletas_ID.Count; Índice_Paleta++)
                                {
                                    int Índice_Línea = 1;
                                    string[] Matriz_Líneas = new string[4] { "", "", "", "" };
                                    for (int Índice_Caracter = Estructura.Nombre.Length - 1; Índice_Caracter >= 0 && Índice_Línea >= 0; Índice_Caracter--)
                                    {
                                        Matriz_Líneas[Índice_Línea] = Estructura.Nombre[Índice_Caracter] + Matriz_Líneas[Índice_Línea];
                                        if (Matriz_Líneas[Índice_Línea].Length >= 14) Índice_Línea--;
                                    } // Use the first 3 lines for the structure path and name.
                                    Matriz_Líneas[2] = "Type #" + (Índice_Paleta + 1).ToString() + ", " + Estructura.Versión_Data.ToString();
                                    if (Matriz_Líneas[2].Length > 14) Matriz_Líneas[2] = Matriz_Líneas[2].Substring(0, 14); // Type and version.
                                    Matriz_Líneas[3] = !string.IsNullOrEmpty(Estructura.Texto_Autor) ? Estructura.Texto_Autor : "Unknown";
                                    if (Matriz_Líneas[3].Length > 14) Matriz_Líneas[3] = Matriz_Líneas[3].Substring(0, 14); // Author.
                                    AlphaBlock Bloque_Señal = new AlphaBlock(63, 8);
                                    Substrate.TileEntities.TileEntitySign Entidad_Señal = new Substrate.TileEntities.TileEntitySign();
                                    Entidad_Señal.Text1 = Matriz_Líneas[0];
                                    Entidad_Señal.Text2 = Matriz_Líneas[1];
                                    Entidad_Señal.Text3 = Matriz_Líneas[2];
                                    Entidad_Señal.Text4 = Matriz_Líneas[3];
                                    Entidad_Señal.X = X + (Estructura.Dimensiones_X / 2);
                                    Entidad_Señal.Y = 1;
                                    Entidad_Señal.Z = 19;
                                    Bloque_Señal.SetTileEntity(Entidad_Señal);
                                    Bloques_Overworld.SetBlock(X + (Estructura.Dimensiones_X / 2), 1, 19, Bloque_Señal); // Sign with info.
                                    Bloques_Overworld.SetBlockLight(X + (Estructura.Dimensiones_X / 2), 1, 19, 8); // Maximum light.

                                    for (int Índice_Z = 0; Índice_Z < Estructura.Dimensiones_Z; Índice_Z++)
                                    {
                                        for (int Índice_Y = 0; Índice_Y < Estructura.Dimensiones_Y; Índice_Y++)
                                        {
                                            for (int Índice_X = 0; Índice_X < Estructura.Dimensiones_X; Índice_X++)
                                            {
                                                if (Estructura.Matriz_Índices_Paleta[Índice_X, Índice_Y, Índice_Z] > -1) Bloques_Overworld.SetBlock(X + Índice_X, Y + Índice_Y, Z + Índice_Z, new AlphaBlock(Estructura.Lista_Paletas_ID[Índice_Paleta][Estructura.Matriz_Índices_Paleta[Índice_X, Índice_Y, Índice_Z]], Estructura.Lista_Paletas_Data[Índice_Paleta][Estructura.Matriz_Índices_Paleta[Índice_X, Índice_Y, Índice_Z]]));
                                                //else Bloques_Overworld.SetBlock(X + Índice_X, Y + Índice_Y, Z + Índice_Z, new AlphaBlock(0, 0)); // Air.
                                                Bloques_Overworld.SetBlockLight(X + Índice_X, Y + Índice_Y, Z + Índice_Z, 8); // Maximum light.
                                            }
                                        }
                                    }
                                    X += Estructura.Dimensiones_X + Separación_Estructuras;
                                }
                            }
                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                        }
                    }
                    this.Invoke(new Invocación.Delegado_ProgressBar_Maximum(Invocación.Ejecutar_Delegado_ProgressBar_Maximum), new object[] { Barra_Progreso, Barra_Progreso.Maximum });
                    Chunks_Overworld.Save(); // Save the chunks of the new region to save RAM memory.
                    Chunks_Overworld = null;
                    Bloques_Overworld = null;
                    Mundo.Save();
                    Mundo = null;
                    Lista_Estructuras = null; // Free all the resources and variables.
                    SystemSounds.Asterisk.Play();
                }
                Cronómetro_Total.Reset();
                Cronómetro_Total = null;
            }
            catch (ThreadAbortException) { Subproceso_Abortado = true; } // Aborted, ignore this exception.
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            finally
            {
                try
                {
                    AnvilChunk.Biomes_Jupisoft = null; // Always reset the temporary biome array.
                    Pendiente_Subproceso_Abortar = false;
                    Subproceso_Activo = false;
                    Subproceso = null;
                    GC.Collect(); // Recover RAM memory at the end.
                    GC.GetTotalMemory(true);
                    if (!Subproceso_Abortado)
                    {
                        //this.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { this, Texto_Título + " - [The original NBT files will never be modified]" });
                        this.Invoke(new Invocación.Delegado_Control_Enabled(Invocación.Ejecutar_Delegado_Control_Enabled), new object[] { Botón_Exportar, true });
                        this.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso, 0 });
                        this.Invoke(new Invocación.Delegado_ProgressBar_Maximum(Invocación.Ejecutar_Delegado_ProgressBar_Maximum), new object[] { Barra_Progreso, 100 });
                        this.Invoke(new Invocación.Delegado_Control_Cursor(Invocación.Ejecutar_Delegado_Control_Cursor), new object[] { this, Cursors.Default });
                    }
                    else
                    {
                        try { this.Close(); } // Close the window.
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
                    }
                }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            }
        }
    }
}

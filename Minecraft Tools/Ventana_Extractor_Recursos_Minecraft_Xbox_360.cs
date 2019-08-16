using ImageMagick;
using Minecraft_Tools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
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
    public partial class Ventana_Extractor_Recursos_Minecraft_Xbox_360 : Form
    {
        public Ventana_Extractor_Recursos_Minecraft_Xbox_360()
        {
            InitializeComponent();
        }

        internal static readonly string Ruta_Xbox_360 = Application.StartupPath + "\\Xbox";
        internal static readonly string Ruta_PC = Application.StartupPath + "\\PC";

        internal readonly string Texto_Título = "Minecraft Xbox 360 Edition Resources Extractor for " + Program.Texto_Usuario + " by Jupisoft";
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

        internal Thread Subproceso = null;
        internal bool Pendiente_Subproceso_Abortar = false;
        internal bool Subproceso_Abortado = false;
        internal bool Subproceso_Activo = false;

        private void Ventana_Extractor_Recursos_Minecraft_Xbox_360_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                this.Text = Texto_Título;
                this.WindowState = FormWindowState.Maximized;
                Ocupado = true;
                Program.Crear_Carpetas(Ruta_Xbox_360);
                TextBox_Ruta.Text = Ruta_Xbox_360;
                Picture_Mass_Effect.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Mass_Effect, 64, 64, true, false, CheckState.Checked);
                Registro_Cargar_Opciones();
                Ocupado = false;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Extractor_Recursos_Minecraft_Xbox_360_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal.Start();
                /*// For Optifine's rainbow sky light try (experimental and fun):
                // Result: the light moves to fast on transitions and then too slow. Useless?
                Bitmap Imagen = new Bitmap(64, 64, PixelFormat.Format32bppArgb);
                Graphics Pintar = Graphics.FromImage(Imagen);
                Pintar.CompositingMode = CompositingMode.SourceCopy;
                Pintar.CompositingQuality = CompositingQuality.HighQuality;
                Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Pintar.SmoothingMode = SmoothingMode.HighQuality;
                Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;
                for (int Índice = 0; Índice < 64; Índice++)
                {
                    int Índice_1530 = (Índice * 1529) / 64; // Skip the last to space it.
                    SolidBrush Pincel = new SolidBrush(Program.Obtener_Color_Puro_1530(Índice_1530));
                    Pintar.FillRectangle(Pincel, Índice, 0, 64, 16);
                    Pincel.Dispose();
                    Pincel = null;
                }
                Pintar.Dispose();
                Pintar = null;
                Program.Guardar_Imagen_Temporal(Imagen);*/
                /*// For Optifine's rainbow torch light try (experimental and fun):
                // Result: it worked as expected, more or less, it might be very useful.
                Bitmap Imagen = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
                Graphics Pintar = Graphics.FromImage(Imagen);
                Pintar.CompositingMode = CompositingMode.SourceCopy;
                Pintar.CompositingQuality = CompositingQuality.HighQuality;
                Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Pintar.SmoothingMode = SmoothingMode.HighQuality;
                Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;
                for (int Índice = 0; Índice < 16; Índice++)
                {
                    int Índice_1530 = (Índice * 1529) / 16; // Skip the last to space it.
                    SolidBrush Pincel = new SolidBrush(Program.Obtener_Color_Puro_1530(Índice_1530));
                    Pintar.FillRectangle(Pincel, 0, Índice, 16, 1);
                    Pincel.Dispose();
                    Pincel = null;
                }
                Pintar.Dispose();
                Pintar = null;
                Program.Guardar_Imagen_Temporal(Imagen);*/
                /*bool[][] Matriz_XY = new bool[6][] // Forager puzzle solver.
                {
                    new bool[6]{ false, false, false, false, false, true },
                    new bool[6]{ false, false, false, false, false, false },
                    new bool[6]{ false, false, false, false, false, false },
                    new bool[6]{ false, false, false, false, false, false },
                    new bool[6]{ false, false, false, false, true, false },
                    new bool[6]{ false, false, false, false, false, false },
                };*/
                /*for (int Índice_Iteración = 0; Índice_Iteración < 1000000; Índice_Iteración++)
                {
                    bool[][] Matriz_Temporal = new bool[6][] // Forager puzzle solver.
                    {
                        new bool[6]{ false, true, false, false, true, true },
                        new bool[6]{ false, false, true, true, false, false },
                        new bool[6]{ false, true, true, true, false, true },
                        new bool[6]{ true, false, true, true, true, true },
                        new bool[6]{ false, true, true, false, false, false },
                        new bool[6]{ false, false, false, true, false, false },
                    };
                    List<Point> Lista_Posiciones = new List<Point>();
                    bool Terminado = true;
                    for (int Índice_Paso = 0; Índice_Paso < 100; Índice_Paso++)
                    {
                        Point Posición = new Point(Program.Rand.Next(0, 6), Program.Rand.Next(0, 6));
                        Lista_Posiciones.Add(Posición);
                        if (Posición.X - 1 > -1) Matriz_Temporal[Posición.Y][Posición.X - 1] = !Matriz_Temporal[Posición.Y][Posición.X - 1]; // Invert left.
                        if (Posición.X + 1 < 6) Matriz_Temporal[Posición.Y][Posición.X + 1] = !Matriz_Temporal[Posición.Y][Posición.X + 1]; // Invert right.
                        Matriz_Temporal[Posición.Y][Posición.X] = !Matriz_Temporal[Posición.Y][Posición.X]; // Always invert center.
                        if (Posición.Y - 1 > -1) Matriz_Temporal[Posición.Y - 1][Posición.X] = !Matriz_Temporal[Posición.Y - 1][Posición.X]; // Invert top.
                        if (Posición.Y + 1 < 6) Matriz_Temporal[Posición.Y + 1][Posición.X] = !Matriz_Temporal[Posición.Y + 1][Posición.X]; // Invert bottom.

                        // Check if all are off.
                        Terminado = true;
                        for (int Índice_Y = 0; Índice_Y < 6; Índice_Y++)
                        {
                            for (int Índice_X = 0; Índice_X < 6; Índice_X++)
                            {
                                if (Matriz_Temporal[Índice_Y][Índice_X])
                                {
                                    Terminado = false;
                                    break;
                                }
                                if (!Terminado) break;
                            }
                        }
                        // Check if all are on.
                        Terminado = true;
                        for (int Índice_Y = 0; Índice_Y < 6; Índice_Y++)
                        {
                            for (int Índice_X = 0; Índice_X < 6; Índice_X++)
                            {
                                if (!Matriz_Temporal[Índice_Y][Índice_X])
                                {
                                    Terminado = false;
                                    break;
                                }
                                if (!Terminado) break;
                            }
                        }
                        if (Terminado) break;
                    }
                    if (Terminado)
                    {
                        string Texto = null;
                        foreach (Point Posición in Lista_Posiciones)
                        {
                            Texto += Posición.ToString() + "\r\n";
                        }
                        Clipboard.SetText(Texto);
                        MessageBox.Show("Fin");
                        return;
                    }
                }
                MessageBox.Show("?");*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Extractor_Recursos_Minecraft_Xbox_360_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Temporizador_Principal.Stop();
                if (Subproceso_Activo)
                {
                    if (MessageBox.Show(this, "Currently there is a resource extraction in progress.\r\nDo you want to cancel it, but saving what has been done?", Program.Texto_Título_Versión, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes && Subproceso_Activo) // Since a message can stay on top for infinite time, double check if it's still converting.
                    {
                        Pendiente_Subproceso_Abortar = true;
                    }
                    e.Cancel = true;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Extractor_Recursos_Minecraft_Xbox_360_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Extractor_Recursos_Minecraft_Xbox_360_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, true) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Extractor_Recursos_Minecraft_Xbox_360_DragDrop(object sender, DragEventArgs e)
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

        private void Ventana_Extractor_Recursos_Minecraft_Xbox_360_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Extractor_Recursos_Minecraft_Xbox_360_KeyDown(object sender, KeyEventArgs e)
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
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        //internal BackgroundWorker Subproceso = null;

        private void Botón_Extraer_Click(object sender, EventArgs e)
        {
            try
            {
                Botón_Extraer.Enabled = false;
                TextBox_Ruta.Enabled = false;
                Subproceso = new Thread(new ThreadStart(Subproceso_DoWork));
                Subproceso.IsBackground = true;
                Subproceso.Priority = ThreadPriority.Normal;
                Subproceso.Start();
                /*Subproceso = new BackgroundWorker();
                Subproceso.DoWork += Subproceso_DoWork;
                Subproceso.RunWorkerCompleted += Subproceso_RunWorkerCompleted;
                Subproceso.WorkerReportsProgress = false;
                Subproceso.WorkerSupportsCancellation = true;
                Subproceso.RunWorkerAsync();*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        internal int Extraer_Recursos_Recursivos(string Ruta, string Ruta_Salida, ref int Índice_Recurso, SortedDictionary<long, string> Diccionario_Índices_Rutas)
        {
            try
            {
                if (!string.IsNullOrEmpty(Ruta) && File.Exists(Ruta))
                {
                    FileStream Lector = new FileStream(Ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    if (Lector.Length >= 4L && Lector.Length < 2147483648L) // 2 GB.
                    {
                        byte[] Matriz_Bytes = new byte[Lector.Length]; // Load the whole file into memory.
                        Lector.Seek(0L, SeekOrigin.Begin);
                        int Longitud = Lector.Read(Matriz_Bytes, 0, Matriz_Bytes.Length);
                        //if (Longitud < Matriz_Bytes.Length) Array.Resize(ref Matriz_Bytes, Longitud);
                        Lector.Close();
                        Lector.Dispose();
                        Lector = null;
                        if (Pendiente_Subproceso_Abortar) return 0; // Cancel safely before time.
                        int Total_Recursos = Extraer_Recursos_Máximos(Matriz_Bytes, Ruta_Salida, ref Índice_Recurso, 1, Diccionario_Índices_Rutas);
                        //int Total_Recursos = Extraer_Recursos_Recursivos(Matriz_Bytes, Ruta_Salida, ref Índice_Recurso, 1);
                        Matriz_Bytes = null;
                        GC.Collect(); // Recover RAM memory at the end.
                        GC.GetTotalMemory(true);
                        return Total_Recursos;
                    }
                    else // Ignore empty or too big files.
                    {
                        Lector.Close();
                        Lector.Dispose();
                        Lector = null;
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            return 0;
        }

        internal static bool Variable_Extraer_Tamaño_Máximo = false;

        /// <summary>
        /// Recursively extracts and exports any known image found within the specified byte array, until all the possible images have been saved.
        /// </summary>
        /// <param name="Matriz_Bytes">Any valid byte array with at least 4 bytes.</param>
        /// <param name="Ruta_Salida">The output folder path.</param>
        /// <param name="Índice_Recurso_Global">The global extracted resources index.</param>
        /// <returns>Returns the number of extracted images. Returns 0 on any error.</returns>
        internal int Extraer_Recursos_Recursivos(byte[] Matriz_Bytes, string Ruta_Salida, ref int Índice_Recurso_Global, int Iteración, SortedDictionary<long, string> Diccionario_Índices_Rutas)
        {
            try
            {
                int Total_Recursos = 0;
                if (Matriz_Bytes != null && Matriz_Bytes.Length >= 4) // 4 bytes for the headers.
                {
                    //int Marcadores_Android = 0; // 0, 114, 101, 115
                    //int Marcadores_BlackBerry = 0; // 0, 47
                    //int Marcadores_BMP_Apertura = 0; // 66, 77, 54 = BM6
                    //int Marcadores_BMP_Cierre = 0; // ?
                    //int Marcadores_GIF_Apertura = 0; // 71, 73, 70, 56 = GIF8
                    //int Marcadores_GIF_Cierre = 0; // 0, 59
                    //int Marcadores_JPG_Apertura = 0; // 255, 216, 255, 224~239 = ÿØÿ~
                    //int Marcadores_JPG_Cierre = 0; // 255, 217
                    //int Marcadores_PNG_Apertura = 0; // 137, 80, 78, 71 = ~PNG
                    //int Marcadores_PNG_Cierre = 0; // 174, 66, 96, 130
                    //int Marcadores_TGA_Apertura = 0; // 0, 0, 2, 0
                    //int Marcadores_TGA_Cierre = 0; // ?
                    //int Marcadores_TIF_Apertura = 0; // 73, 73, 42, 0
                    //int Marcadores_TIF_Cierre = 0; // ?

                    //List<int> Lista_Marcadores_Android = new List<int>();
                    //List<int> Lista_Marcadores_BlackBerry = new List<int>();
                    //List<int> Lista_Marcadores_BMP_Apertura = new List<int>();
                    //List<int> Lista_Marcadores_BMP_Cierre = new List<int>();
                    List<int> Lista_Marcadores_GIF_Apertura = new List<int>();
                    //List<int> Lista_Marcadores_GIF_Cierre = new List<int>();
                    List<int> Lista_Marcadores_JPG_Apertura = new List<int>();
                    //List<int> Lista_Marcadores_JPG_Cierre = new List<int>();
                    List<int> Lista_Marcadores_PNG_Apertura = new List<int>();
                    //List<int> Lista_Marcadores_PNG_Cierre = new List<int>();
                    //List<int> Lista_Marcadores_TGA_Apertura = new List<int>();
                    //List<int> Lista_Marcadores_TGA_Cierre = new List<int>();
                    //List<int> Lista_Marcadores_TIF_Apertura = new List<int>();
                    //List<int> Lista_Marcadores_TIF_Cierre = new List<int>();

                    int Longitud = Matriz_Bytes.Length; // Quicker access to the length?
                    // This looks for known image header bytes, and remember it's positions.
                    for (int Índice_Byte = 0; Índice_Byte < Longitud; Índice_Byte++)
                    {
                        if (Pendiente_Subproceso_Abortar) return 0; // Cancel safely before time.
                        //if (Índice_Byte + 3 < Longitud && Matriz_Bytes[Índice_Byte] == 0 && Matriz_Bytes[Índice_Byte + 1] == 114 && Matriz_Bytes[Índice_Byte + 2] == 101 && Matriz_Bytes[Índice_Byte + 3] == 115 && !Lista_Marcadores_Android.Contains(Índice_Byte)) Lista_Marcadores_Android.Add(Índice_Byte + 1);

                        //if (Matriz_Bytes[Índice_Byte] == 0 && Matriz_Bytes[Índice_Byte + 1] == 47 && !Lista_Marcadores_BlackBerry.Contains(Índice_Byte + 2)) Lista_Marcadores_BlackBerry.Add(Índice_Byte + 2);

                        //if (Índice_Byte + 2 < Longitud && Matriz_Bytes[Índice_Byte] == 66 && Matriz_Bytes[Índice_Byte + 1] == 77 && Matriz_Bytes[Índice_Byte + 2] == 54 && !Lista_Marcadores_BMP_Apertura.Contains(Índice_Byte)) Lista_Marcadores_BMP_Apertura.Add(Índice_Byte);

                        if (Índice_Byte + 3 < Longitud && Matriz_Bytes[Índice_Byte] == 71 && Matriz_Bytes[Índice_Byte + 1] == 73 && Matriz_Bytes[Índice_Byte + 2] == 70 && Matriz_Bytes[Índice_Byte + 3] == 56 && !Lista_Marcadores_GIF_Apertura.Contains(Índice_Byte)) Lista_Marcadores_GIF_Apertura.Add(Índice_Byte);
                        //if (Índice_Byte + 1 < Longitud && Matriz_Bytes[Índice_Byte] == 0 && Matriz_Bytes[Índice_Byte + 1] == 59 && !Lista_Marcadores_GIF_Cierre.Contains(Índice_Byte + 2)) Lista_Marcadores_GIF_Cierre.Add(Índice_Byte + 2);

                        if (Índice_Byte + 2/*3*/ < Longitud && Matriz_Bytes[Índice_Byte] == 255 && Matriz_Bytes[Índice_Byte + 1] == 216 && Matriz_Bytes[Índice_Byte + 2] == 255 && /*Matriz_Bytes_Búfer[Índice_Byte + 3] >= 128/*224 && Matriz_Bytes_Búfer[Índice_Byte + 3] <= 239 && */!Lista_Marcadores_JPG_Apertura.Contains(Índice_Byte)) Lista_Marcadores_JPG_Apertura.Add(Índice_Byte);
                        //if (Índice_Byte + 1 < Longitud && Matriz_Bytes[Índice_Byte] == 255 && Matriz_Bytes[Índice_Byte + 1] == 217 && !Lista_Marcadores_JPG_Cierre.Contains(Índice_Byte + 2)) Lista_Marcadores_JPG_Cierre.Add(Índice_Byte + 2);

                        if (Índice_Byte + 3 < Longitud && Matriz_Bytes[Índice_Byte] == 137 && Matriz_Bytes[Índice_Byte + 1] == 80 && Matriz_Bytes[Índice_Byte + 2] == 78 && Matriz_Bytes[Índice_Byte + 3] == 71 && !Lista_Marcadores_PNG_Apertura.Contains(Índice_Byte)) Lista_Marcadores_PNG_Apertura.Add(Índice_Byte);
                        //if (Índice_Byte + 1 < Longitud && Matriz_Bytes[Índice_Byte] == 96 && Matriz_Bytes[Índice_Byte + 1] == 130 && !Lista_Marcadores_PNG_Cierre.Contains(Índice_Byte + 2)) Lista_Marcadores_PNG_Cierre.Add(Índice_Byte + 2);

                        //if (Índice_Búfer + 3 < Longitud && Matriz_Bytes_Búfer[Índice_Byte] == 0 && Matriz_Bytes_Búfer[Índice_Byte + 1] == 0 && Matriz_Bytes_Búfer[Índice_Byte + 2] == 2 && Matriz_Bytes_Búfer[Índice_Byte + 3] == 0 && !Lista_Marcadores_TGA_Apertura.Contains(Índice_Byte)) Lista_Marcadores_TGA_Apertura.Add(Índice_Byte);

                        //if (Índice_Byte + 3 < Longitud && Matriz_Bytes[Índice_Byte] == 73 && Matriz_Bytes[Índice_Byte + 1] == 73 && Matriz_Bytes[Índice_Byte + 2] == 42 && Matriz_Bytes[Índice_Byte + 3] == 0 && !Lista_Marcadores_TIF_Apertura.Contains(Índice_Byte)) Lista_Marcadores_TIF_Apertura.Add(Índice_Byte);
                    }

                    //List<string> Lista_Extensiones = new List<string>(new string[] { ".gif", ".jpg", ".png" });
                    List<List<int>> Lista_Listas_Apertura = new List<List<int>>();
                    //List<List<int>> Lista_Listas_Cierre = new List<List<int>>();

                    Lista_Listas_Apertura.Add(new List<int>());
                    Lista_Listas_Apertura[0].AddRange(Lista_Marcadores_GIF_Apertura);
                    Lista_Listas_Apertura[0].AddRange(Lista_Marcadores_JPG_Apertura);
                    Lista_Listas_Apertura[0].AddRange(Lista_Marcadores_PNG_Apertura);
                    Lista_Listas_Apertura[0].Sort();

                    //Lista_Listas_Cierre.Add(Lista_Marcadores_GIF_Cierre);
                    //Lista_Listas_Cierre.Add(Lista_Marcadores_JPG_Cierre);
                    //Lista_Listas_Cierre.Add(Lista_Marcadores_PNG_Cierre);

                    for (int Índice_Formato = 0; Índice_Formato < Lista_Listas_Apertura.Count; Índice_Formato++) // 3 known image formats.
                    {
                        for (int Índice_Apertura = 0; Índice_Apertura < Lista_Listas_Apertura[Índice_Formato].Count; Índice_Apertura++)
                        {
                            if (Pendiente_Subproceso_Abortar) return 0; // Cancel safely before time.
                            int Índice_Formato_Cierre = -1;
                            if (Índice_Apertura + 1 < Lista_Listas_Apertura[Índice_Formato].Count)
                            {
                                Índice_Formato_Cierre = Lista_Listas_Apertura[Índice_Formato][Índice_Apertura + 1];
                            }
                            else Índice_Formato_Cierre = Longitud;
                            /*if (Lista_Listas_Cierre[Índice_Formato].Count > 0)
                            {
                                for (int Índice_Cierre = 0; Índice_Cierre < Lista_Listas_Cierre[Índice_Formato].Count; Índice_Cierre++)
                                {
                                    if (Lista_Listas_Cierre[Índice_Formato][Índice_Cierre] > Lista_Listas_Apertura[Índice_Formato][Índice_Apertura])
                                    {
                                        Índice_Formato_Cierre = Lista_Listas_Cierre[Índice_Formato][Índice_Cierre];
                                        break;
                                    }
                                }
                            }
                            else Índice_Formato_Cierre = Longitud;*/
                            /*if (Índice_Apertura + 1 < Lista_Listas_Apertura[Índice_Formato].Count)
                            {
                                if (Lista_Listas_Cierre[Índice_Formato][0] < Lista_Listas_Apertura[Índice_Formato][Índice_Apertura + 1])
                                {
                                    for (int Subíndice = Lista_Listas_Cierre[Índice_Formato].Count - 1; Subíndice >= 0; Subíndice--)
                                    {
                                        if (Pendiente_Subproceso_Abortar) return 0; // Cancel safely before time.
                                        if (Lista_Listas_Cierre[Índice_Formato][Subíndice] < Lista_Listas_Apertura[Índice_Formato][Índice_Apertura + 1])
                                        {
                                            if (Lista_Listas_Cierre[Índice_Formato][Subíndice] > Lista_Listas_Apertura[Índice_Formato][Índice_Apertura]) Índice_Formato_Cierre = Lista_Listas_Cierre[Índice_Formato][Subíndice];
                                            else Índice_Formato_Cierre = Lista_Listas_Apertura[Índice_Formato][Índice_Apertura + 1];
                                            break;
                                        }
                                    }
                                }
                                else Índice_Formato_Cierre = Lista_Listas_Apertura[Índice_Formato][Índice_Apertura + 1];
                            }
                            else if (Lista_Listas_Cierre[Índice_Formato].Count > 0 && Lista_Listas_Cierre[Índice_Formato][Lista_Listas_Cierre[Índice_Formato].Count - 1] > Lista_Listas_Apertura[Índice_Formato][Índice_Apertura]) Índice_Formato_Cierre = Lista_Listas_Cierre[Índice_Formato][Lista_Listas_Cierre[Índice_Formato].Count - 1];
                            else Índice_Formato_Cierre = Longitud;*/

                            byte[] Matriz_Bytes_Recurso = new byte[!Variable_Extraer_Tamaño_Máximo ? Índice_Formato_Cierre - Lista_Listas_Apertura[Índice_Formato][Índice_Apertura] : Longitud - Lista_Listas_Apertura[Índice_Formato][Índice_Apertura]];
                            //Lector.Seek(Lista_Listas_Apertura[Índice_Formato][Índice], SeekOrigin.Begin);
                            //Lector.Read(Matriz_Bytes_Recurso, 0, Matriz_Bytes_Recurso.Length);
                            Array.Copy(Matriz_Bytes, Lista_Listas_Apertura[Índice_Formato][Índice_Apertura], Matriz_Bytes_Recurso, 0, Matriz_Bytes_Recurso.Length);

                            bool Recurso_Válido = false;
                            try
                            {
                                MemoryStream Lector_Memoria = new MemoryStream(Matriz_Bytes_Recurso, true);
                                if (Lector_Memoria != null)
                                {
                                    Image Imagen_Original = Image.FromStream(Lector_Memoria, false, false);
                                    if (Imagen_Original != null) // A new resource has been found.
                                    {
                                        Recurso_Válido = true;
                                        Imagen_Original.Dispose();
                                        Imagen_Original = null;
                                    }
                                    Lector_Memoria.Close();
                                    Lector_Memoria.Dispose();
                                    Lector_Memoria = null;
                                }
                            }
                            catch { Recurso_Válido = false; }
                            /*finally
                            {
                                GC.Collect(); // Recover RAM memory at the end.
                                GC.GetTotalMemory(true);
                            }*/
                            //catch { Recurso_Válido = false; }
                            if (Recurso_Válido)
                            {
                                MemoryStream Lector_Memoria = new MemoryStream(Matriz_Bytes_Recurso);
                                if (Lector_Memoria != null)
                                {
                                    Image Imagen_Original = Image.FromStream(Lector_Memoria, false, false);
                                    if (Imagen_Original != null)
                                    {
                                        int Ancho = Imagen_Original.Width;
                                        int Alto = Imagen_Original.Height;
                                        Bitmap Imagen = new Bitmap(Ancho, Alto, /*!Image.IsAlphaPixelFormat(Imagen_Original.PixelFormat) ? PixelFormat.Format24bppRgb : */PixelFormat.Format32bppArgb);
                                        Graphics Pintar = Graphics.FromImage(Imagen);
                                        Pintar.CompositingMode = CompositingMode.SourceCopy;
                                        Pintar.CompositingQuality = CompositingQuality.HighQuality;
                                        Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                        Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                        Pintar.SmoothingMode = SmoothingMode.HighQuality;
                                        Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;
                                        Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                                        Pintar.Dispose();
                                        Pintar = null; // This copy should remove unused bytes from the resource.
                                        if (Ruta_Salida.ToLowerInvariant().EndsWith("media")) // Some images have R and B inverted.
                                        {
                                            BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                                            byte[] Matriz_Bytes_ARGB = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                                            Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes_ARGB, 0, Matriz_Bytes_ARGB.Length);
                                            int Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                                            int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                                            byte Valor = 0;
                                            for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                                            {
                                                for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento) // Swap Red and Blue.
                                                {
                                                    Valor = Matriz_Bytes_ARGB[Índice];
                                                    Matriz_Bytes_ARGB[Índice] = Matriz_Bytes_ARGB[Índice + 2];
                                                    Matriz_Bytes_ARGB[Índice + 2] = Valor;
                                                }
                                            }
                                            Marshal.Copy(Matriz_Bytes_ARGB, 0, Bitmap_Data.Scan0, Matriz_Bytes_ARGB.Length);
                                            Imagen.UnlockBits(Bitmap_Data);
                                            Bitmap_Data = null;
                                            Matriz_Bytes_ARGB = null;
                                        }
                                        Program.Crear_Carpetas(Ruta_Salida);
                                        string Ruta = Total_Recursos.ToString(); // Use a numeric file name.
                                        while (Ruta.Length < 8) Ruta = '0' + Ruta; // Set file name length to 8.
                                        Ruta = Ruta_Salida + "\\" + Ruta; // Add the full path.
                                        while (File.Exists(Ruta + ".png")) Ruta += '_'; // Avoid overwriting.
                                        Ruta += ".png"; // Add the extension.
                                        Imagen.Save(Ruta, ImageFormat.Png); // Save the resource.
                                        Total_Recursos++; // Resource saved without errors.
                                        Índice_Recurso_Global++; // Increase the counter of saved resources.
                                        this.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { this, Texto_Título + " - [Resources extracted: " + Program.Traducir_Número(Índice_Recurso_Global + 1) + "]" });
                                        Ruta = null; // Free the rest of variables.
                                        Imagen.Dispose();
                                        Imagen = null;
                                        Imagen_Original.Dispose();
                                        Imagen_Original = null;
                                    }
                                    Lector_Memoria.Close();
                                    Lector_Memoria.Dispose();
                                    Lector_Memoria = null;
                                }
                                /*if (Iteración <= 1 && Matriz_Bytes_Recurso.Length > 4) // Look a second time for more resources inside this one.
                                {
                                    Array.Copy(Matriz_Bytes_Recurso, 4, Matriz_Bytes_Recurso, 0, Matriz_Bytes_Recurso.Length - 4); // Move 4 bytes to the left.
                                    Array.Resize(ref Matriz_Bytes_Recurso, Matriz_Bytes_Recurso.Length - 4); // Remove the first byte and resize.
                                    Extraer_Recursos_Recursivos(Matriz_Bytes_Recurso, Ruta_Salida, ref Índice_Recurso, Iteración + 1);
                                }*/
                                /*else
                                {
                                    // Ignore it, it was already saved from the function above, which is also this one.
                                }*/
                            }
                            else continue; // Ignore.
                        }
                    }
                }
                return Total_Recursos;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            return 0;
        }

        /// <summary>
        /// Recursively extracts and exports any known image found within the specified byte array, until all the possible images have been saved.
        /// </summary>
        /// <param name="Matriz_Bytes">Any valid byte array with at least 4 bytes.</param>
        /// <param name="Ruta_Salida">The output folder path.</param>
        /// <param name="Índice_Recurso_Global">The global extracted resources index.</param>
        /// <returns>Returns the number of extracted images. Returns 0 on any error.</returns>
        internal int Extraer_Recursos_Máximos(byte[] Matriz_Bytes, string Ruta_Salida, ref int Índice_Recurso_Global, int Iteración, SortedDictionary<long, string> Diccionario_Índices_Rutas)
        {
            try
            {
                int Total_Recursos = 0;
                if (Matriz_Bytes != null && Matriz_Bytes.Length >= 0)
                {
                    bool Modo_TGA = false; // It needs the CPU intense and extremely slow TGA mode?
                    int Índice_Siguiente = -1;
                    /*if (Diccionario_Índices_Rutas != null && Diccionario_Índices_Rutas.Count > 0)
                    {
                        foreach (KeyValuePair<long, string> Entrada in Diccionario_Índices_Rutas)
                        {
                            if (Entrada.Key >= Índice_Byte) // We are here.
                            {
                                if (!string.IsNullOrEmpty(Entrada.Value) && Entrada.Value.EndsWith(".tga"))
                                {
                                    Modo_TGA = true; // It should be a TGA image.
                                    break;
                                }
                            }
                        }
                    }*/
                    if (!Modo_TGA)
                    {
                        // Try to export all the images inside, but it's the slower mode.
                        int Longitud = Matriz_Bytes.Length; // Quicker access to the length?
                        this.Invoke(new Invocación.Delegado_ProgressBar_Maximum(Invocación.Ejecutar_Delegado_ProgressBar_Maximum), new object[] { Barra_Progreso_Archivo, Longitud });
                        Dictionary<uint, object> Diccionario_CRC_32 = new Dictionary<uint, object>();
                        for (int Índice_Byte = 0; Índice_Byte < Longitud; Índice_Byte++)
                        {
                            try
                            {
                                if (Pendiente_Subproceso_Abortar) return 0; // Cancel safely before time.
                                this.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Archivo, Índice_Byte });
                                byte[] Matriz_Bytes_Temporal = new byte[Longitud - Índice_Byte];
                                Array.Copy(Matriz_Bytes, Índice_Byte, Matriz_Bytes_Temporal, 0, Matriz_Bytes_Temporal.Length);
                                MemoryStream Lector_Memoria = new MemoryStream(Matriz_Bytes_Temporal);
                                if (Lector_Memoria != null)
                                {
                                    Image Imagen_Original = null;
                                    try
                                    {
                                        MagickReadSettings MRS = new MagickReadSettings();
                                        MRS.Format = MagickFormat.Tga;
                                        MagickImage Imagen_Magick = new MagickImage(Matriz_Bytes_Temporal, MRS);
                                        Imagen_Original = Imagen_Magick.ToBitmap();
                                        //Imagen_Original = Imagen_Magick.ToBitmap(ImageFormat.Png);
                                    }
                                    catch { Imagen_Original = null; }
                                    if (Imagen_Original == null)
                                    {
                                        try { Imagen_Original = Image.FromStream(Lector_Memoria, false, false); }
                                        catch { Imagen_Original = null; }
                                    }
                                    if (Imagen_Original != null)
                                    {
                                        int Ancho = Imagen_Original.Width;
                                        int Alto = Imagen_Original.Height;
                                        Bitmap Imagen = new Bitmap(Ancho, Alto, /*!Image.IsAlphaPixelFormat(Imagen_Original.PixelFormat) ? PixelFormat.Format24bppRgb : */PixelFormat.Format32bppArgb);
                                        Graphics Pintar = Graphics.FromImage(Imagen);
                                        Pintar.CompositingMode = CompositingMode.SourceCopy;
                                        Pintar.CompositingQuality = CompositingQuality.HighQuality;
                                        Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                        Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                        Pintar.SmoothingMode = SmoothingMode.HighQuality;
                                        Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;
                                        Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                                        Pintar.Dispose();
                                        Pintar = null; // This copy should remove unused bytes from the resource.
                                        if (Ruta_Salida.ToLowerInvariant().EndsWith("media")) // Some images have R and B inverted.
                                        {
                                            BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                                            byte[] Matriz_Bytes_ARGB = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                                            Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes_ARGB, 0, Matriz_Bytes_ARGB.Length);
                                            int Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                                            int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                                            byte Valor = 0;
                                            for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                                            {
                                                for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento) // Swap Red and Blue.
                                                {
                                                    Valor = Matriz_Bytes_ARGB[Índice];
                                                    Matriz_Bytes_ARGB[Índice] = Matriz_Bytes_ARGB[Índice + 2];
                                                    Matriz_Bytes_ARGB[Índice + 2] = Valor;
                                                }
                                            }
                                            Marshal.Copy(Matriz_Bytes_ARGB, 0, Bitmap_Data.Scan0, Matriz_Bytes_ARGB.Length);
                                            Imagen.UnlockBits(Bitmap_Data);
                                            Bitmap_Data = null;
                                            Matriz_Bytes_ARGB = null;
                                        }
                                        Program.Crear_Carpetas(Ruta_Salida);
                                        MemoryStream Lector_Memoria_Salida = new MemoryStream();
                                        Imagen.Save(Lector_Memoria_Salida, ImageFormat.Png); // Save the resource.
                                        byte[] Matriz_Bytes_Salida = Lector_Memoria_Salida.ToArray();
                                        uint CRC_32 = Program.Calcular_CRC32(Matriz_Bytes_Salida);
                                        if (!Diccionario_CRC_32.ContainsKey(CRC_32))
                                        {
                                            Diccionario_CRC_32.Add(CRC_32, null);
                                            string Ruta = Total_Recursos.ToString(); // Use a numeric file name.
                                            while (Ruta.Length < 8) Ruta = '0' + Ruta; // Set file name length to 8.
                                            Ruta = Ruta_Salida + "\\" + Ruta; // Add the full path.
                                            while (File.Exists(Ruta + ".png")) Ruta += '_'; // Avoid overwriting.
                                            Ruta += ".png"; // Add the extension.
                                            FileStream Lector_Salida = new FileStream(Ruta, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
                                            Lector_Salida.SetLength(0L);
                                            Lector_Salida.Seek(0L, SeekOrigin.Begin);
                                            Lector_Salida.Write(Matriz_Bytes_Salida, 0, Matriz_Bytes_Salida.Length);
                                            Lector_Salida.Close();
                                            Lector_Salida.Dispose();
                                            Lector_Salida = null;
                                            Total_Recursos++; // Resource saved without errors.
                                            Índice_Recurso_Global++; // Increase the counter of saved resources.
                                            this.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { this, Texto_Título + " - [Resources extracted: " + Program.Traducir_Número(Índice_Recurso_Global + 1) + "]" });
                                            Ruta = null; // Free the rest of variables.
                                        }
                                        Matriz_Bytes_Salida = null;
                                        Lector_Memoria_Salida.Close();
                                        Lector_Memoria_Salida.Dispose();
                                        Lector_Memoria_Salida = null;
                                        Imagen.Dispose();
                                        Imagen = null;
                                        Imagen_Original.Dispose();
                                        Imagen_Original = null;
                                    }
                                    Lector_Memoria.Close();
                                    Lector_Memoria.Dispose();
                                    Lector_Memoria = null;
                                }
                                Matriz_Bytes_Temporal = null;
                            }
                            catch { continue; }
                            //catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                        }
                    }
                    else
                    {
                        // Try to export all the images inside, but it's the slower mode.
                        int Longitud = Matriz_Bytes.Length; // Quicker access to the length?
                        this.Invoke(new Invocación.Delegado_ProgressBar_Maximum(Invocación.Ejecutar_Delegado_ProgressBar_Maximum), new object[] { Barra_Progreso_Archivo, Longitud });
                        Dictionary<uint, object> Diccionario_CRC_32 = new Dictionary<uint, object>();
                        for (int Índice_Byte = 0; Índice_Byte < Longitud; Índice_Byte++)
                        {
                            try
                            {
                                if (Pendiente_Subproceso_Abortar) return 0; // Cancel safely before time.
                                this.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Archivo, Índice_Byte });
                                byte[] Matriz_Bytes_Temporal = new byte[Longitud - Índice_Byte];
                                Array.Copy(Matriz_Bytes, Índice_Byte, Matriz_Bytes_Temporal, 0, Matriz_Bytes_Temporal.Length);
                                MemoryStream Lector_Memoria = new MemoryStream(Matriz_Bytes_Temporal);
                                if (Lector_Memoria != null)
                                {
                                    Image Imagen_Original = null;
                                    try
                                    {
                                        MagickReadSettings MRS = new MagickReadSettings();
                                        MRS.Format = MagickFormat.Tga;
                                        MagickImage Imagen_Magick = new MagickImage(Matriz_Bytes_Temporal, MRS);
                                        Imagen_Original = Imagen_Magick.ToBitmap();
                                        //Imagen_Original = Imagen_Magick.ToBitmap(ImageFormat.Png);
                                    }
                                    catch { Imagen_Original = null; }
                                    if (Imagen_Original == null)
                                    {
                                        try { Imagen_Original = Image.FromStream(Lector_Memoria, false, false); }
                                        catch { Imagen_Original = null; }
                                    }
                                    if (Imagen_Original != null)
                                    {
                                        int Ancho = Imagen_Original.Width;
                                        int Alto = Imagen_Original.Height;
                                        Bitmap Imagen = new Bitmap(Ancho, Alto, /*!Image.IsAlphaPixelFormat(Imagen_Original.PixelFormat) ? PixelFormat.Format24bppRgb : */PixelFormat.Format32bppArgb);
                                        Graphics Pintar = Graphics.FromImage(Imagen);
                                        Pintar.CompositingMode = CompositingMode.SourceCopy;
                                        Pintar.CompositingQuality = CompositingQuality.HighQuality;
                                        Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                        Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                        Pintar.SmoothingMode = SmoothingMode.HighQuality;
                                        Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;
                                        Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                                        Pintar.Dispose();
                                        Pintar = null; // This copy should remove unused bytes from the resource.
                                        if (Ruta_Salida.ToLowerInvariant().EndsWith("media")) // Some images have R and B inverted.
                                        {
                                            BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                                            byte[] Matriz_Bytes_ARGB = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                                            Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes_ARGB, 0, Matriz_Bytes_ARGB.Length);
                                            int Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                                            int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                                            byte Valor = 0;
                                            for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                                            {
                                                for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento) // Swap Red and Blue.
                                                {
                                                    Valor = Matriz_Bytes_ARGB[Índice];
                                                    Matriz_Bytes_ARGB[Índice] = Matriz_Bytes_ARGB[Índice + 2];
                                                    Matriz_Bytes_ARGB[Índice + 2] = Valor;
                                                }
                                            }
                                            Marshal.Copy(Matriz_Bytes_ARGB, 0, Bitmap_Data.Scan0, Matriz_Bytes_ARGB.Length);
                                            Imagen.UnlockBits(Bitmap_Data);
                                            Bitmap_Data = null;
                                            Matriz_Bytes_ARGB = null;
                                        }
                                        Program.Crear_Carpetas(Ruta_Salida);
                                        MemoryStream Lector_Memoria_Salida = new MemoryStream();
                                        Imagen.Save(Lector_Memoria_Salida, ImageFormat.Png); // Save the resource.
                                        byte[] Matriz_Bytes_Salida = Lector_Memoria_Salida.ToArray();
                                        uint CRC_32 = Program.Calcular_CRC32(Matriz_Bytes_Salida);
                                        if (!Diccionario_CRC_32.ContainsKey(CRC_32))
                                        {
                                            Diccionario_CRC_32.Add(CRC_32, null);
                                            string Ruta = Total_Recursos.ToString(); // Use a numeric file name.
                                            while (Ruta.Length < 8) Ruta = '0' + Ruta; // Set file name length to 8.
                                            Ruta = Ruta_Salida + "\\" + Ruta; // Add the full path.
                                            while (File.Exists(Ruta + ".png")) Ruta += '_'; // Avoid overwriting.
                                            Ruta += ".png"; // Add the extension.
                                            FileStream Lector_Salida = new FileStream(Ruta, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
                                            Lector_Salida.SetLength(0L);
                                            Lector_Salida.Seek(0L, SeekOrigin.Begin);
                                            Lector_Salida.Write(Matriz_Bytes_Salida, 0, Matriz_Bytes_Salida.Length);
                                            Lector_Salida.Close();
                                            Lector_Salida.Dispose();
                                            Lector_Salida = null;
                                            Total_Recursos++; // Resource saved without errors.
                                            Índice_Recurso_Global++; // Increase the counter of saved resources.
                                            this.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { this, Texto_Título + " - [Resources extracted: " + Program.Traducir_Número(Índice_Recurso_Global + 1) + "]" });
                                            Ruta = null; // Free the rest of variables.
                                        }
                                        Matriz_Bytes_Salida = null;
                                        Lector_Memoria_Salida.Close();
                                        Lector_Memoria_Salida.Dispose();
                                        Lector_Memoria_Salida = null;
                                        Imagen.Dispose();
                                        Imagen = null;
                                        Imagen_Original.Dispose();
                                        Imagen_Original = null;
                                    }
                                    Lector_Memoria.Close();
                                    Lector_Memoria.Dispose();
                                    Lector_Memoria = null;
                                }
                                Matriz_Bytes_Temporal = null;
                            }
                            catch { continue; }
                            //catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                        }
                    }
                }
                return Total_Recursos;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            return 0;
        }

        /// <summary>
        /// Thread function that extracts all the available Minecraft Xbox 360 Edition resources.
        /// </summary>
        internal void Subproceso_DoWork()
        {
            Subproceso_Abortado = false; // Used to know if the window must be closed.
            try
            {
                Subproceso_Activo = true;
                this.Invoke(new Invocación.Delegado_Control_Cursor(Invocación.Ejecutar_Delegado_Control_Cursor), new object[] { this, Cursors.WaitCursor });
                string Ruta_Entrada = TextBox_Ruta.Text;
                if (!string.IsNullOrEmpty(Ruta_Entrada) && Directory.Exists(Ruta_Entrada))
                {
                    string[] Matriz_Rutas = Directory.GetFiles(Ruta_Entrada, "*", SearchOption.AllDirectories);
                    if (Matriz_Rutas != null && Matriz_Rutas.Length > 0)
                    {
                        if (Matriz_Rutas.Length > 1) Array.Sort(Matriz_Rutas);
                        this.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso, 0 });
                        this.Invoke(new Invocación.Delegado_ProgressBar_Maximum(Invocación.Ejecutar_Delegado_ProgressBar_Maximum), new object[] { Barra_Progreso, Matriz_Rutas.Length * 2 });
                        Program.Crear_Carpetas(Ruta_PC);
                        int Índice_Ruta = 0;
                        int Índice_Recurso = 0;
                        foreach (string Ruta in Matriz_Rutas)
                        {
                            try
                            {
                                if (Pendiente_Subproceso_Abortar) return; // Cancel safely before time.
                                Índice_Ruta++;
                                this.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso, Índice_Ruta });
                                Program.Crear_Carpetas(Path.GetDirectoryName(Ruta_PC + Ruta.Substring(Ruta_Entrada.Length)) + "\\" + Path.GetFileNameWithoutExtension(Ruta));
                                SortedDictionary<long, string> Diccionario_Índices_Rutas = Xbox_360.Obtener_Nombres_Packs_Recursos(Ruta, Path.GetDirectoryName(Ruta_PC + Ruta.Substring(Ruta_Entrada.Length)) + "\\" + Path.GetFileNameWithoutExtension(Ruta) + "\\_" + Path.GetFileNameWithoutExtension(Ruta) + "_.txt", false);
                                //Extraer_Recursos_Recursivos(Ruta, Path.GetDirectoryName(Ruta_PC + Ruta.Substring(Ruta_Entrada.Length))/* + "\\" + Path.GetFileNameWithoutExtension(Ruta)*/, ref Índice_Recurso);
                                Extraer_Recursos_Recursivos(Ruta, Path.GetDirectoryName(Ruta_PC + Ruta.Substring(Ruta_Entrada.Length)) + "\\" + Path.GetFileNameWithoutExtension(Ruta), ref Índice_Recurso, Diccionario_Índices_Rutas);
                            }
                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                        }
                        SystemSounds.Asterisk.Play(); // Done.
                        Matriz_Rutas = null;
                    }
                }
            }
            catch (ThreadAbortException) { Subproceso_Abortado = true; } // Aborted, ignore this exception.
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            finally
            {
                try
                {
                    Subproceso_Activo = false;
                    Subproceso = null;
                    GC.Collect(); // Recover RAM memory at the end.
                    GC.GetTotalMemory(true);
                    if (!Subproceso_Abortado && !Pendiente_Subproceso_Abortar)
                    {
                        Pendiente_Subproceso_Abortar = false;
                        this.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso, 0 });
                        this.Invoke(new Invocación.Delegado_ProgressBar_Maximum(Invocación.Ejecutar_Delegado_ProgressBar_Maximum), new object[] { Barra_Progreso, 100 });
                        this.Invoke(new Invocación.Delegado_Control_Cursor(Invocación.Ejecutar_Delegado_Control_Cursor), new object[] { this, Cursors.Default });
                        this.Invoke(new Invocación.Delegado_Control_Enabled(Invocación.Ejecutar_Delegado_Control_Enabled), new object[] { TextBox_Ruta, true });
                        this.Invoke(new Invocación.Delegado_Control_Enabled(Invocación.Ejecutar_Delegado_Control_Enabled), new object[] { Botón_Extraer, true });
                        this.Invoke(new Invocación.Delegado_Control_Select(Invocación.Ejecutar_Delegado_Control_Select), new object[] { Botón_Extraer });
                        this.Invoke(new Invocación.Delegado_Control_Focus(Invocación.Ejecutar_Delegado_Control_Focus), new object[] { Botón_Extraer });
                    }
                    else
                    {
                        Temporizador_Principal.Stop();
                        this.Invoke(new Invocación.Delegado_Form_Close(Invocación.Ejecutar_Delegado_Form_Close), new object[] { this }); // Close the window.
                    }
                }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            }
        }

        private void Pictures_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                PictureBox Picture = sender as PictureBox;
                if (Picture != null)
                {
                    if (Picture == Picture_Adventure_Time) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Adventure_Time_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Candy) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Candy_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Cartoon) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Cartoon_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Chinese_Mythology) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Chinese_Mythology_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_City) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_City_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Egyptian_Mythology) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Egyptian_Mythology_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Fallout) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Fallout_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Fantasy) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Fantasy_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Festive) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Festive_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Greek_Mythology) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Greek_Mythology_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Halloween) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Halloween_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Halloween_2015) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Halloween_2015_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Halo) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Halo_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Mass_Effect) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Mass_Effect_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Natural) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Natural_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Norse_Mythology) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Norse_Mythology_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Pattern) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Pattern_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Pirates_Of_The_Caribbean) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Pirates_Of_The_Caribbean_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Plastic) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Plastic_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Skyrim) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Skyrim_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Steampunk) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Steampunk_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Super_Cute_Texture_Pack) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_Super_Cute_Texture_Pack_Preview, 580, 288, true, false, CheckState.Checked);
                    else if (Picture == Picture_Xbox_360_The_Nightmare_Before_Christmas) Picture_Vista_Previa.Image = Program.Obtener_Imagen_Miniatura(Resources.Xbox_360_The_Nightmare_Before_Christmas_Preview, 580, 288, true, false, CheckState.Checked);
                    else Picture_Vista_Previa.Image = null;
                }
                else Picture_Vista_Previa.Image = null;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Pictures_MouseLeave(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

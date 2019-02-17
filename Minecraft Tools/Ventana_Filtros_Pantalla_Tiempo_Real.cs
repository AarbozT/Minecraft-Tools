using Minecraft_Tools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
    public partial class Ventana_Filtros_Pantalla_Tiempo_Real : Form
    {
        public Ventana_Filtros_Pantalla_Tiempo_Real()
        {
            InitializeComponent();
        }

        internal enum Filtros : int
        {
            Original = 0,
            Negativo,
            Voltear_Horizontalmente,
            Voltear_Verticalmente,
            Girar_180,
            Brillo_Menos,
            Brillo_Más,
            Intensidad_Menos,
            Intensidad_Más,
            Raíz_Cuadrada_Menos,
            Raíz_Cuadrada_Más,
            Logaritmo_Menos,
            Logaritmo_Más,
            Normalizar,
            Normalizar_Centro,
            Diferencia_Mínima,
            Arco_Iris_Bordes,
            Arco_Iris_Relleno,
            Intercambiar_RGB_RBG,
            Intercambiar_RGB_GRB,
            Intercambiar_RGB_GBR,
            Intercambiar_RGB_BRG,
            Intercambiar_RGB_BGR,
            Termografía,
            Termografía_Variable,
            Mínimo,
            Mediana,
            Máximo,
            Rojo,
            Verde,
            Azul,
            Matiz,
            Saturación,
            Luminosidad,
            HSL_a_RGB,
            RGB_a_HSL,
        }

        internal enum Zooms : int
        {
            Zoom_1x = 0,
            Zoom_2x,
            Zoom_4x,
            Zoom_8x,
            Zoom_16x,
            Zoom_32x,
            Zoom_64x,
            Zoom_128x,
            Zoom_256x
        }
        
        internal static readonly Rectangle Rectángulo_Pantalla = Screen.PrimaryScreen.Bounds;
        internal static Filtros Variable_Filtro = Filtros.Original;
        internal static Zooms Variable_Zoom = Zooms.Zoom_1x;
        internal static bool Variable_Zoom_Suave = false;
        internal static bool Variable_Seguir_Cursor = true;

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        internal readonly string Texto_Título = "Real Time Screen Filters for " + Program.Texto_Usuario + " by Jupisoft";
        internal bool Variable_Siempre_Visible = true;
        internal bool Variable_Pantalla_Completa = false;
        internal bool Variable_Excepción = false;
        internal bool Variable_Excepción_Imagen = false;
        internal int Variable_Excepción_Total = 0;
        internal bool Variable_Memoria = false;
        internal static Stopwatch FPS_Cronómetro = Stopwatch.StartNew();
        internal long FPS_Segundo_Anterior = 0L;
        internal long FPS_Temporal = 0L;
        internal long FPS_Real = 0L;
        internal bool Ocupado = false;

        internal int Índice_Termografía = 0;

        private void Ventana_Plantilla_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                this.Text = Texto_Título;
                this.Location = new Point(this.Location.X, 0); // Move the window at the top of the screen.
                ComboBox_Filtro.SelectedIndex = (int)Variable_Filtro; // Load the previously used options.
                ComboBox_Zoom.SelectedIndex = (int)Variable_Zoom; // TODO: load from the registry.
                CheckBox_Zoom_Suave.Checked = Variable_Zoom_Suave;
                CheckBox_Seguir_Cursor.Checked = Variable_Seguir_Cursor;
                Menú_Contextual_Siempre_Visible.Checked = Variable_Siempre_Visible;
                Ocupado = true;
                Registro_Cargar_Opciones();
                Ocupado = false;
                Menú_Contextual_GitHub.Enabled = string.Compare(Environment.UserName, "Jupisoft") == 0;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Plantilla_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Plantilla_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Variable_Pantalla_Completa) Menú_Contextual_Pantalla_Completa.PerformClick();
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Plantilla_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Plantilla_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Plantilla_KeyDown(object sender, KeyEventArgs e)
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
                    else if (e.KeyCode == Keys.Enter)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        Menú_Contextual_Pantalla_Completa.PerformClick();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Menú_Contextual_Pantalla_Completa.PerformClick();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ComboBox_Filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboBox_Filtro.SelectedIndex > -1)
                {
                    Índice_Termografía = 0;
                    Variable_Filtro = (Filtros)ComboBox_Filtro.SelectedIndex;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ComboBox_Zoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboBox_Zoom.SelectedIndex > -1)
                {
                    Variable_Zoom = (Zooms)ComboBox_Zoom.SelectedIndex;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Zoom_Suave_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Zoom_Suave = CheckBox_Zoom_Suave.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Seguir_Cursor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Seguir_Cursor = CheckBox_Seguir_Cursor.Checked;
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

        private void Menú_Contextual_Siempre_Visible_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Siempre_Visible = Menú_Contextual_Siempre_Visible.Checked;
                this.TopMost = Variable_Siempre_Visible;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Pantalla_Completa_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Pantalla_Completa = Menú_Contextual_Pantalla_Completa.Checked;
                if (!Variable_Pantalla_Completa)
                {
                    Temporizador_Principal.Stop();
                    Picture.Image = null;
                    if (this.TopMost != Variable_Siempre_Visible) this.TopMost = Variable_Siempre_Visible;
                    this.Opacity = 1d;
                    this.TransparencyKey = Color.Transparent;
                    this.AllowTransparency = false;
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.FixedSingle;
                    Cursor.Show();
                    Tabla_Principal.Visible = true;
                    Barra_Estado.Visible = true;
                    Menú_Contextual_Siempre_Visible.Enabled = true;
                    Temporizador_Principal.Start();
                }
                else
                {
                    Temporizador_Principal.Stop();
                    Picture.Image = null;
                    Menú_Contextual_Siempre_Visible.Enabled = false;
                    Barra_Estado.Visible = false;
                    Tabla_Principal.Visible = false;
                    Cursor.Hide();
                    if (!Variable_Siempre_Visible) this.TopMost = true;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    this.AllowTransparency = true;
                    this.TransparencyKey = Color.Black;
                    this.Opacity = 0.5d;
                    Temporizador_Principal.Start();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Copiar_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                if (Picture.Image != null)
                {
                    Clipboard.SetImage(Picture.Image);
                    SystemSounds.Asterisk.Play();
                }
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                if (Picture.Image != null)
                {
                    Program.Crear_Carpetas(Program.Ruta_Minecraft);
                    Picture.Image.Save(Program.Ruta_Minecraft + "\\" + Program.Obtener_Nombre_Temporal_Sin_Guiones() + ".png", ImageFormat.Png);
                    SystemSounds.Asterisk.Play();
                }
                Temporizador_Principal.Start();
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

                if (!Variable_GitHub)
                {
                    Rectangle Rectángulo = new Rectangle(CheckBox_Seguir_Cursor.Checked ? Control.MousePosition : new Point(Rectángulo_Pantalla.Width / 2, Rectángulo_Pantalla.Height / 2), Picture.ClientSize);
                    int Ancho = Rectángulo.Width;
                    int Alto = Rectángulo.Height;
                    if (Ancho > 0 && Alto > 0)
                    {
                        Rectángulo.X -= (Rectángulo.Width / 2);
                        Rectángulo.Y -= (Rectángulo.Height / 2);

                        if (Rectángulo.X < 0) Rectángulo.X = 0;
                        else if (Rectángulo.X + Rectángulo.Width >= Rectángulo_Pantalla.Width) Rectángulo.X = Rectángulo_Pantalla.Width - Rectángulo.Width;
                        if (Rectángulo.Y < 0) Rectángulo.Y = 0;
                        else if (Rectángulo.Y + Rectángulo.Height >= Rectángulo_Pantalla.Height) Rectángulo.Y = Rectángulo_Pantalla.Height - Rectángulo.Height;

                        if (Variable_Pantalla_Completa)
                        {
                            //Picture.Visible = false;
                            //Picture.Image = null;
                            //Picture.Refresh();
                        }

                        Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format24bppRgb);
                        Graphics Pintar = Graphics.FromImage(Imagen);
                        //Pintar.CopyFromScreen(Rectángulo.X, Rectángulo.Y, 0, 0, Imagen.Size, Filtro != Filtros.Negativo ? CopyPixelOperation.SourceCopy : CopyPixelOperation.NotSourceCopy);
                        using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero)) // Desktop window?
                        {
                            IntPtr hSrcDC = gsrc.GetHdc();
                            IntPtr hDC = Pintar.GetHdc();
                            int retval = BitBlt(hDC, 0, 0, Ancho, Alto, hSrcDC, Rectángulo.X, Rectángulo.Y, Variable_Filtro != Filtros.Negativo ? (int)CopyPixelOperation.SourceCopy : (int)CopyPixelOperation.NotSourceCopy);
                            Pintar.ReleaseHdc();
                            gsrc.ReleaseHdc();
                        }
                        Pintar.Dispose();
                        Pintar = null;

                        if (Variable_Zoom != Zooms.Zoom_1x)
                        {
                            int Zoom = int.Parse(Variable_Zoom.ToString().Replace("Zoom_", null).Replace("x", null));
                            int Ancho_Zoom = Ancho / Zoom;
                            int Alto_Zoom = Alto / Zoom;
                            int X_Zoom = (Ancho / 2) - (Ancho_Zoom / 2);
                            int Y_Zoom = (Alto / 2) - (Alto_Zoom / 2);
                            Bitmap Imagen_Zoom = new Bitmap(Ancho, Alto, PixelFormat.Format24bppRgb);
                            Pintar = Graphics.FromImage(Imagen_Zoom);
                            //Pintar.Clear(Color.Gray);
                            Pintar.CompositingMode = CompositingMode.SourceCopy;
                            Pintar.CompositingQuality = CompositingQuality.HighQuality;
                            Pintar.InterpolationMode = !Variable_Zoom_Suave ? InterpolationMode.NearestNeighbor : InterpolationMode.HighQualityBicubic;
                            Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            Pintar.SmoothingMode = SmoothingMode.HighQuality;
                            Pintar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                            Pintar.DrawImage(Imagen, new Rectangle(0, 0, Ancho, Alto), new Rectangle(X_Zoom, Y_Zoom, Ancho_Zoom, Alto_Zoom), GraphicsUnit.Pixel);
                            Pintar.Dispose();
                            Pintar = null;
                            Imagen = Imagen_Zoom;
                        }

                        if (Variable_Filtro == Filtros.Voltear_Horizontalmente)
                        {
                            Imagen.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        }
                        else if (Variable_Filtro == Filtros.Voltear_Verticalmente)
                        {
                            Imagen.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        }
                        else if (Variable_Filtro == Filtros.Girar_180)
                        {
                            Imagen.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                        }

                        if (Variable_Filtro != Filtros.Original && (Variable_Filtro < Filtros.Voltear_Horizontalmente || Variable_Filtro > Filtros.Girar_180))
                        {
                            bool Cancelar_Marshal_Copy = false; // If false, copy back the modified pixels.
                            BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                            byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                            Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                            int Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                            int Bytes_Ancho = Math.Abs(Bitmap_Data.Stride);
                            int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                            /*if (Variable_Filtro == Filtros.Negativo)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = (byte)(255 - Matriz_Bytes[Índice + 2]);
                                        Matriz_Bytes[Índice + 1] = (byte)(255 - Matriz_Bytes[Índice + 1]);
                                        Matriz_Bytes[Índice] = (byte)(255 - Matriz_Bytes[Índice]);
                                    }
                                }
                            }
                            else */
                            if (Variable_Filtro == Filtros.Brillo_Menos)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = (byte)Math.Max(Matriz_Bytes[Índice + 2] - 128, 0);
                                        Matriz_Bytes[Índice + 1] = (byte)Math.Max(Matriz_Bytes[Índice + 1] - 128, 0);
                                        Matriz_Bytes[Índice] = (byte)Math.Max(Matriz_Bytes[Índice] - 128, 0);
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Brillo_Más)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = (byte)Math.Min(Matriz_Bytes[Índice + 2] + 128, 255);
                                        Matriz_Bytes[Índice + 1] = (byte)Math.Min(Matriz_Bytes[Índice + 1] + 128, 255);
                                        Matriz_Bytes[Índice] = (byte)Math.Min(Matriz_Bytes[Índice] + 128, 255);
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Intensidad_Menos)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = (byte)(Matriz_Bytes[Índice + 2] / 2);
                                        Matriz_Bytes[Índice + 1] = (byte)(Matriz_Bytes[Índice + 1] / 2);
                                        Matriz_Bytes[Índice] = (byte)(Matriz_Bytes[Índice] / 2);
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Intensidad_Más)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = (byte)Math.Min(Matriz_Bytes[Índice + 2] * 2, 255);
                                        Matriz_Bytes[Índice + 1] = (byte)Math.Min(Matriz_Bytes[Índice + 1] * 2, 255);
                                        Matriz_Bytes[Índice] = (byte)Math.Min(Matriz_Bytes[Índice] * 2, 255);
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Raíz_Cuadrada_Menos)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = Program.Matriz_Bytes_Filtro_Raíz_Cuadrada_Menos[Matriz_Bytes[Índice + 2]];
                                        Matriz_Bytes[Índice + 1] = Program.Matriz_Bytes_Filtro_Raíz_Cuadrada_Menos[Matriz_Bytes[Índice + 1]];
                                        Matriz_Bytes[Índice] = Program.Matriz_Bytes_Filtro_Raíz_Cuadrada_Menos[Matriz_Bytes[Índice]];
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Raíz_Cuadrada_Más)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = Program.Matriz_Bytes_Filtro_Raíz_Cuadrada[Matriz_Bytes[Índice + 2]];
                                        Matriz_Bytes[Índice + 1] = Program.Matriz_Bytes_Filtro_Raíz_Cuadrada[Matriz_Bytes[Índice + 1]];
                                        Matriz_Bytes[Índice] = Program.Matriz_Bytes_Filtro_Raíz_Cuadrada[Matriz_Bytes[Índice]];
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Logaritmo_Menos)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = Program.Matriz_Bytes_Filtro_Logaritmo_Menos[Matriz_Bytes[Índice + 2]];
                                        Matriz_Bytes[Índice + 1] = Program.Matriz_Bytes_Filtro_Logaritmo_Menos[Matriz_Bytes[Índice + 1]];
                                        Matriz_Bytes[Índice] = Program.Matriz_Bytes_Filtro_Logaritmo_Menos[Matriz_Bytes[Índice]];
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Logaritmo_Más)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = Program.Matriz_Bytes_Filtro_Logaritmo[Matriz_Bytes[Índice + 2]];
                                        Matriz_Bytes[Índice + 1] = Program.Matriz_Bytes_Filtro_Logaritmo[Matriz_Bytes[Índice + 1]];
                                        Matriz_Bytes[Índice] = Program.Matriz_Bytes_Filtro_Logaritmo[Matriz_Bytes[Índice]];
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Normalizar)
                            {
                                SortedDictionary<byte, long> Diccionario_Valores_R = new SortedDictionary<byte, long>();
                                SortedDictionary<byte, long> Diccionario_Valores_G = new SortedDictionary<byte, long>();
                                SortedDictionary<byte, long> Diccionario_Valores_B = new SortedDictionary<byte, long>();
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        if (!Diccionario_Valores_R.ContainsKey(Matriz_Bytes[Índice + 2]))
                                        {
                                            Diccionario_Valores_R.Add(Matriz_Bytes[Índice + 2], 1L);
                                        }
                                        //else Diccionario_Valores_R[Matriz_Bytes[Índice + 2]]++;

                                        if (!Diccionario_Valores_G.ContainsKey(Matriz_Bytes[Índice + 1]))
                                        {
                                            Diccionario_Valores_G.Add(Matriz_Bytes[Índice + 1], 1L);
                                        }
                                        //else Diccionario_Valores_G[Matriz_Bytes[Índice + 1]]++;

                                        if (!Diccionario_Valores_B.ContainsKey(Matriz_Bytes[Índice]))
                                        {
                                            Diccionario_Valores_B.Add(Matriz_Bytes[Índice], 1L);
                                        }
                                        //else Diccionario_Valores_B[Matriz_Bytes[Índice]]++;
                                    }
                                    if (Diccionario_Valores_R.Count >= 256 && Diccionario_Valores_G.Count >= 256 && Diccionario_Valores_B.Count >= 256) break;
                                }
                                if (Diccionario_Valores_R.Count < 256 || Diccionario_Valores_G.Count < 256 || Diccionario_Valores_B.Count < 256)
                                {
                                    byte[] Matriz_Bytes_Normalización_R = new byte[256];
                                    byte[] Matriz_Bytes_Normalización_G = new byte[256];
                                    byte[] Matriz_Bytes_Normalización_B = new byte[256];
                                    for (int Índice = 0; Índice < 256; Índice++)
                                    {
                                        if (Diccionario_Valores_R.ContainsKey((byte)Índice))
                                        {
                                            int Valor_R = (int)Math.Round(((double)Índice * 256d) / (double)Diccionario_Valores_R.Count, MidpointRounding.AwayFromZero);
                                            if (Valor_R < 0) Valor_R = 0;
                                            else if (Valor_R > 255) Valor_R = 255;
                                            Matriz_Bytes_Normalización_R[Índice] = (byte)Valor_R;
                                        }
                                        if (Diccionario_Valores_G.ContainsKey((byte)Índice))
                                        {
                                            int Valor_G = (int)Math.Round(((double)Índice * 256d) / (double)Diccionario_Valores_G.Count, MidpointRounding.AwayFromZero);
                                            if (Valor_G < 0) Valor_G = 0;
                                            else if (Valor_G > 255) Valor_G = 255;
                                            Matriz_Bytes_Normalización_G[Índice] = (byte)Valor_G;
                                        }
                                        if (Diccionario_Valores_B.ContainsKey((byte)Índice))
                                        {
                                            int Valor_B = (int)Math.Round(((double)Índice * 256d) / (double)Diccionario_Valores_B.Count, MidpointRounding.AwayFromZero);
                                            if (Valor_B < 0) Valor_B = 0;
                                            else if (Valor_B > 255) Valor_B = 255;
                                            Matriz_Bytes_Normalización_B[Índice] = (byte)Valor_B;
                                        }
                                    }
                                    for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                    {
                                        for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                        {
                                            Matriz_Bytes[Índice + 2] = Matriz_Bytes_Normalización_R[Matriz_Bytes[Índice + 2]];
                                            Matriz_Bytes[Índice + 1] = Matriz_Bytes_Normalización_G[Matriz_Bytes[Índice + 1]];
                                            Matriz_Bytes[Índice] = Matriz_Bytes_Normalización_B[Matriz_Bytes[Índice]];
                                        }
                                    }
                                }
                                else Cancelar_Marshal_Copy = true;
                            }
                            else if (Variable_Filtro == Filtros.Normalizar_Centro)
                            {
                                //bool Cancelar = false;
                                byte Mínimo_R = 255, Mínimo_G = 255, Mínimo_B = 255;
                                byte Máximo_R = 0, Máximo_G = 0, Máximo_B = 0;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        if (Matriz_Bytes[Índice + 2] < Mínimo_R) Mínimo_R = Matriz_Bytes[Índice + 2];
                                        if (Matriz_Bytes[Índice + 2] > Máximo_R) Máximo_R = Matriz_Bytes[Índice + 2];
                                        if (Matriz_Bytes[Índice + 1] < Mínimo_G) Mínimo_G = Matriz_Bytes[Índice + 1];
                                        if (Matriz_Bytes[Índice + 1] > Máximo_G) Máximo_G = Matriz_Bytes[Índice + 1];
                                        if (Matriz_Bytes[Índice] < Mínimo_B) Mínimo_B = Matriz_Bytes[Índice];
                                        if (Matriz_Bytes[Índice] > Máximo_B) Máximo_B = Matriz_Bytes[Índice];
                                        if (Mínimo_R <= 0 && Mínimo_G <= 0 && Mínimo_B <= 0 && Máximo_R >= 255 && Máximo_G >= 255 && Máximo_B >= 255) break;
                                    }
                                }
                                if (Mínimo_R > 0 || Mínimo_G > 0 || Mínimo_B > 0 || Máximo_R < 255 || Máximo_G < 255 || Máximo_B < 255)
                                {
                                    byte[] Matriz_R = new byte[256];
                                    byte[] Matriz_G = new byte[256];
                                    byte[] Matriz_B = new byte[256];
                                    int Media_R = Máximo_R - Mínimo_R;
                                    int Media_G = Máximo_G - Mínimo_G;
                                    int Media_B = Máximo_B - Mínimo_B;
                                    for (int Índice = Mínimo_R, Media = 0; Índice <= Máximo_R; Índice++, Media++) if (Media > 0) Matriz_R[Índice] = (byte)((Media * 255) / Media_R);
                                    for (int Índice = Mínimo_G, Media = 0; Índice <= Máximo_G; Índice++, Media++) if (Media > 0) Matriz_G[Índice] = (byte)((Media * 255) / Media_G);
                                    for (int Índice = Mínimo_B, Media = 0; Índice <= Máximo_B; Índice++, Media++) if (Media > 0) Matriz_B[Índice] = (byte)((Media * 255) / Media_B);
                                    for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                    {
                                        for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                        {
                                            Matriz_Bytes[Índice + 2] = Matriz_R[Matriz_Bytes[Índice + 2]];
                                            Matriz_Bytes[Índice + 1] = Matriz_G[Matriz_Bytes[Índice + 1]];
                                            Matriz_Bytes[Índice] = Matriz_B[Matriz_Bytes[Índice]];
                                        }
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Diferencia_Mínima)
                            {
                                byte[] Matriz_Bytes_Original = (byte[])Matriz_Bytes.Clone();
                                for (int Índice_Y = 0, Índice = 0, Subíndice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        byte Rojo = Matriz_Bytes_Original[Índice + 2];
                                        byte Verde = Matriz_Bytes_Original[Índice + 1];
                                        byte Azul = Matriz_Bytes_Original[Índice];
                                        int Valor_R = 255, Valor_G = 255, Valor_B = 255;
                                        int Valor_R_Temporal = 0, Valor_G_Temporal = 0, Valor_B_Temporal = 0;
                                        for (int Subíndice_Y = -1, X = 0; Subíndice_Y <= 1; Subíndice_Y++, X++)
                                        {
                                            for (int Subíndice_X = -1, Y = 0; Subíndice_X <= 1; Subíndice_X++, Y++)
                                            {
                                                if ((Subíndice_X != 0 || Subíndice_Y != 0) && Índice_X + Subíndice_X > -1 && Índice_X + Subíndice_X < Ancho && Índice_Y + Subíndice_Y > -1 && Índice_Y + Subíndice_Y < Alto)
                                                {
                                                    Subíndice = (Bytes_Ancho * (Índice_Y + Subíndice_Y)) + ((Índice_X + Subíndice_X) * Bytes_Aumento);
                                                    Valor_R_Temporal = Math.Abs(Rojo - Matriz_Bytes_Original[Subíndice + 2]);
                                                    Valor_G_Temporal = Math.Abs(Verde - Matriz_Bytes_Original[Subíndice + 1]);
                                                    Valor_B_Temporal = Math.Abs(Azul - Matriz_Bytes_Original[Subíndice]);
                                                    if (Valor_R_Temporal < Valor_R && Valor_R_Temporal > 0 && Matriz_Bytes_Original[Subíndice + 2] < Rojo) Valor_R = Valor_R_Temporal;
                                                    if (Valor_G_Temporal < Valor_G && Valor_G_Temporal > 0 && Matriz_Bytes_Original[Subíndice + 1] < Verde) Valor_G = Valor_G_Temporal;
                                                    if (Valor_B_Temporal < Valor_B && Valor_B_Temporal > 0 && Matriz_Bytes_Original[Subíndice] < Azul) Valor_B = Valor_B_Temporal;
                                                }
                                            }
                                        }
                                        Matriz_Bytes[Índice + 2] = (byte)(255 - Valor_R);
                                        Matriz_Bytes[Índice + 1] = (byte)(255 - Valor_G);
                                        Matriz_Bytes[Índice] = (byte)(255 - Valor_B);
                                    }
                                }
                                Matriz_Bytes_Original = null;
                            }
                            else if (Variable_Filtro == Filtros.Arco_Iris_Bordes)
                            {
                                byte[] Matriz_Bytes_Original = (byte[])Matriz_Bytes.Clone();
                                int Porcentaje = 75;
                                int Matiz_Índice = 0;
                                int Matiz_Subíndice = 0;
                                Color Color_ARGB = Color.Empty;
                                for (int Índice_Y = 0, Índice = 0, Subíndice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        bool Cancelar = false;
                                        Matiz_Índice = Program.HSL.Obtener_Matiz_0_a_11(Matriz_Bytes_Original[Índice + 2], Matriz_Bytes_Original[Índice + 1], Matriz_Bytes_Original[Índice]);

                                        byte Rojo = Matriz_Bytes_Original[Índice + 2];
                                        byte Verde = Matriz_Bytes_Original[Índice + 1];
                                        byte Azul = Matriz_Bytes_Original[Índice];
                                        int Valor_R = 255, Valor_G = 255, Valor_B = 255;
                                        int Valor_R_Temporal = 0, Valor_G_Temporal = 0, Valor_B_Temporal = 0;
                                        for (int Subíndice_Y = -1, X = 0; Subíndice_Y <= 1; Subíndice_Y++, X++)
                                        {
                                            for (int Subíndice_X = -1, Y = 0; Subíndice_X <= 1; Subíndice_X++, Y++)
                                            {
                                                if ((Subíndice_X != 0 || Subíndice_Y != 0) && Índice_X + Subíndice_X > -1 && Índice_X + Subíndice_X < Ancho && Índice_Y + Subíndice_Y > -1 && Índice_Y + Subíndice_Y < Alto)
                                                {
                                                    Subíndice = (Bytes_Ancho * (Índice_Y + Subíndice_Y)) + ((Índice_X + Subíndice_X) * Bytes_Aumento);
                                                    Matiz_Subíndice = Program.HSL.Obtener_Matiz_0_a_11(Matriz_Bytes_Original[Subíndice + 2], Matriz_Bytes_Original[Subíndice + 1], Matriz_Bytes_Original[Subíndice]);
                                                    if (Matiz_Índice != Matiz_Subíndice)
                                                    {
                                                        Cancelar = true;
                                                        Subíndice_X = 2;
                                                        Subíndice_Y = 2;
                                                        break;
                                                    }


                                                    Valor_R_Temporal = Math.Abs(Rojo - Matriz_Bytes_Original[Subíndice + 2]);
                                                    Valor_G_Temporal = Math.Abs(Verde - Matriz_Bytes_Original[Subíndice + 1]);
                                                    Valor_B_Temporal = Math.Abs(Azul - Matriz_Bytes_Original[Subíndice]);
                                                    if (Valor_R_Temporal < Valor_R && Valor_R_Temporal > 0 && Matriz_Bytes_Original[Subíndice + 2] < Rojo) Valor_R = Valor_R_Temporal;
                                                    if (Valor_G_Temporal < Valor_G && Valor_G_Temporal > 0 && Matriz_Bytes_Original[Subíndice + 1] < Verde) Valor_G = Valor_G_Temporal;
                                                    if (Valor_B_Temporal < Valor_B && Valor_B_Temporal > 0 && Matriz_Bytes_Original[Subíndice] < Azul) Valor_B = Valor_B_Temporal;
                                                }
                                                /*else
                                                {
                                                    Cancelar = true;
                                                    Subíndice_X = 2;
                                                    Subíndice_Y = 2;
                                                    break;
                                                }*/
                                            }
                                        }

                                        if (!Cancelar)
                                        {
                                            Matriz_Bytes[Índice + 2] = (byte)((Matriz_Bytes[Índice + 2] * Porcentaje) / 100);
                                            Matriz_Bytes[Índice + 1] = (byte)((Matriz_Bytes[Índice + 1] * Porcentaje) / 100);
                                            Matriz_Bytes[Índice] = (byte)((Matriz_Bytes[Índice] * Porcentaje) / 100);
                                        }
                                        else
                                        {
                                            Color_ARGB = Program.Obtener_Color_Puro_0_a_11(Matiz_Índice);
                                            Matriz_Bytes[Índice + 2] = Color_ARGB.R;
                                            Matriz_Bytes[Índice + 1] = Color_ARGB.G;
                                            Matriz_Bytes[Índice] = Color_ARGB.B;
                                        }
                                        //Matriz_Bytes[Índice + 2] = (byte)(255 - Valor_R);
                                        //Matriz_Bytes[Índice + 1] = (byte)(255 - Valor_G);
                                        //Matriz_Bytes[Índice] = (byte)(255 - Valor_B);
                                    }
                                }
                                Matriz_Bytes_Original = null;
                            }
                            else if (Variable_Filtro == Filtros.Arco_Iris_Relleno)
                            {
                                int Matiz = 0;
                                Color Color_ARGB = Color.Empty;
                                int Porcentaje = 50;
                                int Porcentaje_Resto = 100 - Porcentaje;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matiz = Program.HSL.Obtener_Matiz_0_a_11(Matriz_Bytes[Índice + 2], Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice]);
                                        Color_ARGB = Program.Obtener_Color_Puro_0_a_11(Matiz);
                                        //Matriz_Bytes[Índice + 2] = Color_ARGB.R;
                                        //Matriz_Bytes[Índice + 1] = Color_ARGB.G;
                                        //Matriz_Bytes[Índice] = Color_ARGB.B;
                                        Matriz_Bytes[Índice + 2] = (byte)(((Color_ARGB.R * Porcentaje) + (Matriz_Bytes[Índice + 2] * Porcentaje_Resto)) / 100);
                                        Matriz_Bytes[Índice + 1] = (byte)(((Color_ARGB.G * Porcentaje) + (Matriz_Bytes[Índice + 1] * Porcentaje_Resto)) / 100);
                                        Matriz_Bytes[Índice] = (byte)(((Color_ARGB.B * Porcentaje) + (Matriz_Bytes[Índice] * Porcentaje_Resto)) / 100);
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Intercambiar_RGB_RBG)
                            {
                                byte Valor_RGB;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Valor_RGB = Matriz_Bytes[Índice + 1];
                                        Matriz_Bytes[Índice + 1] = Matriz_Bytes[Índice];
                                        Matriz_Bytes[Índice] = Valor_RGB;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Intercambiar_RGB_GRB)
                            {
                                byte Valor_RGB;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Valor_RGB = Matriz_Bytes[Índice + 2];
                                        Matriz_Bytes[Índice + 2] = Matriz_Bytes[Índice + 1];
                                        Matriz_Bytes[Índice + 1] = Valor_RGB;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Intercambiar_RGB_GBR)
                            {
                                byte Valor_R, Valor_G, Valor_B;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Valor_R = Matriz_Bytes[Índice + 2];
                                        Valor_G = Matriz_Bytes[Índice + 1];
                                        Valor_B = Matriz_Bytes[Índice];
                                        Matriz_Bytes[Índice + 2] = Valor_G;
                                        Matriz_Bytes[Índice + 1] = Valor_B;
                                        Matriz_Bytes[Índice] = Valor_R;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Intercambiar_RGB_BRG)
                            {
                                byte Valor_R, Valor_G, Valor_B;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Valor_R = Matriz_Bytes[Índice + 2];
                                        Valor_G = Matriz_Bytes[Índice + 1];
                                        Valor_B = Matriz_Bytes[Índice];
                                        Matriz_Bytes[Índice + 2] = Valor_B;
                                        Matriz_Bytes[Índice + 1] = Valor_R;
                                        Matriz_Bytes[Índice] = Valor_G;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Intercambiar_RGB_BGR)
                            {
                                byte Valor_RGB;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Valor_RGB = Matriz_Bytes[Índice + 2];
                                        Matriz_Bytes[Índice + 2] = Matriz_Bytes[Índice];
                                        Matriz_Bytes[Índice] = Valor_RGB;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Termografía)
                            {
                                int Matiz;
                                Color Color_ARGB;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        //if (Matriz_Bytes[Índice] != Matriz_Bytes[Índice + 1] || Matriz_Bytes[Índice] != Matriz_Bytes[Índice + 2])
                                        {
                                            Matiz = Matriz_Bytes[Índice + 2] + Matriz_Bytes[Índice + 1] + Matriz_Bytes[Índice];
                                            Color_ARGB = Program.Obtener_Color_Puro_1530(1275 - ((Matiz * 5) / 3));
                                            Matriz_Bytes[Índice + 2] = Color_ARGB.R;
                                            Matriz_Bytes[Índice + 1] = Color_ARGB.G;
                                            Matriz_Bytes[Índice] = Color_ARGB.B;
                                        }
                                        /*else
                                        {
                                            Matriz_Bytes[Índice + 2] = 255;
                                            Matriz_Bytes[Índice + 1] = 255;
                                            Matriz_Bytes[Índice] = 255;
                                        }*/
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Termografía_Variable)
                            {
                                int Matiz;
                                Color Color_ARGB;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        //if (Matriz_Bytes[Índice] != Matriz_Bytes[Índice + 1] || Matriz_Bytes[Índice] != Matriz_Bytes[Índice + 2])
                                        {
                                            Matiz = (Matriz_Bytes[Índice + 2] + Matriz_Bytes[Índice + 1] + Matriz_Bytes[Índice]) + Índice_Termografía;
                                            Matiz *= 2;
                                            if (Matiz >= 1530) Matiz -= 1530;
                                            Color_ARGB = Program.Obtener_Color_Puro_1530(1529 - Matiz);
                                            Matriz_Bytes[Índice + 2] = Color_ARGB.R;
                                            Matriz_Bytes[Índice + 1] = Color_ARGB.G;
                                            Matriz_Bytes[Índice] = Color_ARGB.B;
                                        }
                                        /*else
                                        {
                                            Matriz_Bytes[Índice + 2] = 255;
                                            Matriz_Bytes[Índice + 1] = 255;
                                            Matriz_Bytes[Índice] = 255;
                                        }*/
                                    }
                                }
                                Índice_Termografía++;
                                if (Índice_Termografía >= 765) Índice_Termografía = 0;
                            }
                            else if (Variable_Filtro == Filtros.Mínimo)
                            {
                                byte Mínimo;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Mínimo = Math.Min(Matriz_Bytes[Índice + 2], Math.Min(Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice]));
                                        if (Matriz_Bytes[Índice + 2] > Mínimo) Matriz_Bytes[Índice + 2] = 0;
                                        if (Matriz_Bytes[Índice + 1] > Mínimo) Matriz_Bytes[Índice + 1] = 0;
                                        if (Matriz_Bytes[Índice] > Mínimo) Matriz_Bytes[Índice] = 0;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Mediana)
                            {
                                byte Mínimo;
                                byte Máximo;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Mínimo = Math.Min(Matriz_Bytes[Índice + 2], Math.Min(Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice]));
                                        Máximo = Math.Max(Matriz_Bytes[Índice + 2], Math.Max(Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice]));
                                        if (Matriz_Bytes[Índice + 2] == Mínimo || Matriz_Bytes[Índice + 2] == Máximo) Matriz_Bytes[Índice + 2] = 0;
                                        if (Matriz_Bytes[Índice + 1] == Mínimo || Matriz_Bytes[Índice + 1] == Máximo) Matriz_Bytes[Índice + 1] = 0;
                                        if (Matriz_Bytes[Índice] == Mínimo || Matriz_Bytes[Índice] == Máximo) Matriz_Bytes[Índice] = 0;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Máximo)
                            {
                                byte Máximo;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Máximo = Math.Max(Matriz_Bytes[Índice + 2], Math.Max(Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice]));
                                        if (Matriz_Bytes[Índice + 2] < Máximo) Matriz_Bytes[Índice + 2] = 0;
                                        if (Matriz_Bytes[Índice + 1] < Máximo) Matriz_Bytes[Índice + 1] = 0;
                                        if (Matriz_Bytes[Índice] < Máximo) Matriz_Bytes[Índice] = 0;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Rojo)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 1] = 0;
                                        Matriz_Bytes[Índice] = 0;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Verde)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = 0;
                                        Matriz_Bytes[Índice] = 0;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Azul)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matriz_Bytes[Índice + 2] = 0;
                                        Matriz_Bytes[Índice + 1] = 0;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Matiz)
                            {
                                double Matiz, Saturación, Luminosidad;
                                int Valor;
                                Color Color_ARGB;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        if (Matriz_Bytes[Índice] != Matriz_Bytes[Índice + 1] || Matriz_Bytes[Índice] != Matriz_Bytes[Índice + 2]) // Not gray scale.
                                        {
                                            Program.HSL.From_RGB(Matriz_Bytes[Índice + 2], Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice], out Matiz, out Saturación, out Luminosidad);
                                            Valor = (int)(Matiz * 4.25d);
                                            if (Valor < 0) Valor = 0;
                                            else if (Valor > 1529) Valor = 1529;
                                            Color_ARGB = Program.Obtener_Color_Puro_1530(Valor);
                                            Matriz_Bytes[Índice + 2] = Color_ARGB.R;
                                            Matriz_Bytes[Índice + 1] = Color_ARGB.G;
                                            Matriz_Bytes[Índice] = Color_ARGB.B;
                                        }
                                        else
                                        {
                                            Matriz_Bytes[Índice + 2] = 255;
                                            Matriz_Bytes[Índice + 1] = 255;
                                            Matriz_Bytes[Índice] = 255;
                                        }
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Saturación)
                            {
                                double Matiz, Saturación, Luminosidad;
                                int Valor;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Program.HSL.From_RGB(Matriz_Bytes[Índice + 2], Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice], out Matiz, out Saturación, out Luminosidad);
                                        Valor = (int)(Saturación * 2.55d);
                                        if (Valor < 0) Valor = 0;
                                        else if (Valor > 255) Valor = 255;
                                        Matriz_Bytes[Índice] = (byte)Valor;
                                        Matriz_Bytes[Índice + 1] = Matriz_Bytes[Índice];
                                        Matriz_Bytes[Índice + 2] = Matriz_Bytes[Índice];
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.Luminosidad)
                            {
                                double Matiz, Saturación, Luminosidad;
                                int Valor;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Program.HSL.From_RGB(Matriz_Bytes[Índice + 2], Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice], out Matiz, out Saturación, out Luminosidad);
                                        Valor = (int)(Luminosidad * 2.55d);
                                        if (Valor < 0) Valor = 0;
                                        else if (Valor > 255) Valor = 255;
                                        Matriz_Bytes[Índice] = (byte)Valor;
                                        Matriz_Bytes[Índice + 1] = Matriz_Bytes[Índice];
                                        Matriz_Bytes[Índice + 2] = Matriz_Bytes[Índice];
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.HSL_a_RGB)
                            {
                                double Matiz, Saturación, Luminosidad;
                                int Rojo, Verde, Azul;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Program.HSL.From_RGB(Matriz_Bytes[Índice + 2], Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice], out Matiz, out Saturación, out Luminosidad);

                                        Rojo = (int)((Matiz * 255d) / 360d);
                                        if (Rojo < 0) Rojo = 0;
                                        else if (Rojo > 255) Rojo = 255;

                                        Verde = (int)((Saturación * 255d) / 100d);
                                        if (Verde < 0) Verde = 0;
                                        else if (Verde > 255) Verde = 255;

                                        Azul = (int)((Luminosidad * 255d) / 100d);
                                        if (Azul < 0) Azul = 0;
                                        else if (Azul > 255) Azul = 255;

                                        Matriz_Bytes[Índice + 2] = (byte)Rojo;
                                        Matriz_Bytes[Índice + 1] = (byte)Verde;
                                        Matriz_Bytes[Índice] = (byte)Azul;
                                    }
                                }
                            }
                            else if (Variable_Filtro == Filtros.RGB_a_HSL)
                            {
                                double Matiz, Saturación, Luminosidad;
                                byte Rojo, Verde, Azul;
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Matiz = (int)((Matriz_Bytes[Índice + 2] * 360d) / 255d);
                                        if (Matiz < 0d) Matiz = 0d;
                                        else if (Matiz >= 360d) Matiz = 0d;

                                        Saturación = (int)((Matriz_Bytes[Índice + 1] * 100d) / 255d);
                                        if (Saturación < 0d) Saturación = 0d;
                                        else if (Saturación > 100d) Saturación = 100d;

                                        Luminosidad = (int)((Matriz_Bytes[Índice] * 100d) / 255d);
                                        if (Luminosidad < 0d) Luminosidad = 0d;
                                        else if (Luminosidad > 100d) Luminosidad = 100d;

                                        Program.HSL.To_RGB(Matiz, Saturación, Luminosidad, out Rojo, out Verde, out Azul);

                                        Matriz_Bytes[Índice + 2] = Rojo;
                                        Matriz_Bytes[Índice + 1] = Verde;
                                        Matriz_Bytes[Índice] = Azul;
                                    }
                                }
                            }
                            if (!Cancelar_Marshal_Copy) Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                            Imagen.UnlockBits(Bitmap_Data);
                            Bitmap_Data = null;
                        }
                        Picture.Image = Imagen;
                        if (Variable_Pantalla_Completa)
                        {
                            //Picture.Visible = true;
                            //Picture.Image = null;
                            //Picture.Refresh();
                        }
                    }
                }
                else if ((Control.ModifierKeys & Keys.LShiftKey) != Keys.LShiftKey && (Control.ModifierKeys & Keys.RShiftKey) != Keys.RShiftKey) // Just for Jupisoft (or users of GitHub Desktop)...
                {
                    // This will commit multiple changes "automatically", and it's
                    // designed to check file after file individually and commit
                    // it's changes, but in this case that should always be the
                    // deletion of the files. Screen should have 1.024 x 768 pixels.
                    Rectangle Rectángulo = new Rectangle(17, 146, 1, 1);
                    int Ancho = 1;
                    int Alto = 1;

                    Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format24bppRgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    //Pintar.CopyFromScreen(Rectángulo.X, Rectángulo.Y, 0, 0, Imagen.Size, Filtro != Filtros.Negativo ? CopyPixelOperation.SourceCopy : CopyPixelOperation.NotSourceCopy);
                    using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero)) // Desktop window?
                    {
                        IntPtr hSrcDC = gsrc.GetHdc();
                        IntPtr hDC = Pintar.GetHdc();
                        int retval = BitBlt(hDC, 0, 0, Ancho, Alto, hSrcDC, Rectángulo.X, Rectángulo.Y, (int)CopyPixelOperation.SourceCopy);
                        Pintar.ReleaseHdc();
                        gsrc.ReleaseHdc();
                    }
                    Pintar.Dispose();
                    Pintar = null;

                    BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadOnly, Imagen.PixelFormat);
                    byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                    Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                    int Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                    int Bytes_Ancho = Math.Abs(Bitmap_Data.Stride);
                    int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                    Imagen.UnlockBits(Bitmap_Data);
                    Bitmap_Data = null;
                    Imagen.Dispose();
                    Imagen = null;

                    CheckState Estado = CheckState.Indeterminate;
                    for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                    {
                        for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                        {
                            int Valor = (Matriz_Bytes[Índice + 2] + Matriz_Bytes[Índice + 1] + Matriz_Bytes[Índice]) / 3;
                            if (Valor >= 224 && Valor < 255/*(Matriz_Bytes[Índice + 2] == 236 && Matriz_Bytes[Índice + 1] == 236 && Matriz_Bytes[Índice] == 236) ||
                                (Matriz_Bytes[Índice + 2] == 231 && Matriz_Bytes[Índice + 1] == 231 && Matriz_Bytes[Índice] == 231)*/)
                            {
                                Estado = CheckState.Unchecked;
                            }
                            else if ((Matriz_Bytes[Índice + 2] == 102 && Matriz_Bytes[Índice + 1] == 102 && Matriz_Bytes[Índice] == 102) ||
                                (Matriz_Bytes[Índice + 2] == 168 && Matriz_Bytes[Índice + 1] == 170 && Matriz_Bytes[Índice] == 171))
                            {
                                Estado = CheckState.Checked;
                            }
                            else
                            {
                                Estado = CheckState.Indeterminate;
                            }
                        }
                    }
                    Matriz_Bytes = null;

                    this.Text = "GitHub Desktop: " + Estado.ToString();

                    if (Estado != CheckState.Indeterminate)
                    {
                        Cronómetro_GitHub.Reset();
                        if (Estado == CheckState.Unchecked)
                        {
                            PInvoke.SetCursorPos(17, 146);
                            PInvoke.mouse_event(PInvoke.MouseEventF.LeftDown, 0, 0, 0, 0);
                            PInvoke.mouse_event(PInvoke.MouseEventF.LeftUp, 0, 0, 0, 0);
                            Thread.Sleep(40);
                        }
                        else
                        {
                            Rectángulo = new Rectangle(55, 660, 1, 1);

                            Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format24bppRgb);
                            Pintar = Graphics.FromImage(Imagen);
                            //Pintar.CopyFromScreen(Rectángulo.X, Rectángulo.Y, 0, 0, Imagen.Size, Filtro != Filtros.Negativo ? CopyPixelOperation.SourceCopy : CopyPixelOperation.NotSourceCopy);
                            using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero)) // Desktop window?
                            {
                                IntPtr hSrcDC = gsrc.GetHdc();
                                IntPtr hDC = Pintar.GetHdc();
                                int retval = BitBlt(hDC, 0, 0, Ancho, Alto, hSrcDC, Rectángulo.X, Rectángulo.Y, (int)CopyPixelOperation.SourceCopy);
                                Pintar.ReleaseHdc();
                                gsrc.ReleaseHdc();
                            }
                            Pintar.Dispose();
                            Pintar = null;

                            Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadOnly, Imagen.PixelFormat);
                            Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                            Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                            Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                            Bytes_Ancho = Math.Abs(Bitmap_Data.Stride);
                            Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                            Imagen.UnlockBits(Bitmap_Data);
                            Bitmap_Data = null;
                            Imagen.Dispose();
                            Imagen = null;

                            GitHub_Estados Estado_GitHub = GitHub_Estados.Desconocido;
                            for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                            {
                                for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                {
                                    if (Matriz_Bytes[Índice + 2] == 100 && Matriz_Bytes[Índice + 1] == 160 && Matriz_Bytes[Índice] == 228)
                                    {
                                        Estado_GitHub = GitHub_Estados.Deshabilitado;
                                    }
                                    else if (Matriz_Bytes[Índice + 2] == 3 && Matriz_Bytes[Índice + 1] == 102 && Matriz_Bytes[Índice] == 214)
                                    {
                                        Estado_GitHub = GitHub_Estados.Habilitado;
                                    }
                                    else if (Matriz_Bytes[Índice + 2] == 251 && Matriz_Bytes[Índice + 1] == 252 && Matriz_Bytes[Índice] == 253)
                                    {
                                        Estado_GitHub = GitHub_Estados.Esperar;
                                    }
                                    else
                                    {
                                        Estado_GitHub = GitHub_Estados.Desconocido;
                                    }
                                }
                            }
                            Matriz_Bytes = null;

                            if (Estado_GitHub != GitHub_Estados.Desconocido)
                            {
                                if (Estado_GitHub == GitHub_Estados.Habilitado)
                                {
                                    PInvoke.SetCursorPos(55, 660);
                                    PInvoke.mouse_event(PInvoke.MouseEventF.LeftDown, 0, 0, 0, 0);
                                    PInvoke.mouse_event(PInvoke.MouseEventF.LeftUp, 0, 0, 0, 0);
                                    Thread.Sleep(40);
                                }
                            }
                        }
                    }
                    else if (!Cronómetro_GitHub.IsRunning)
                    {
                        Cronómetro_GitHub.Restart();
                    }
                    else if (Cronómetro_GitHub.ElapsedMilliseconds >= 1000L)
                    {
                        Menú_Contextual_GitHub.Checked = false;
                        Cronómetro_GitHub.Reset();
                        SystemSounds.Hand.Play();
                    }
                }
                else Menú_Contextual_GitHub.Checked = false;

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

        internal enum GitHub_Estados : byte
        {
            Deshabilitado = 0,
            Habilitado,
            Esperar,
            Desconocido
        }

        internal Stopwatch Cronómetro_GitHub = new Stopwatch();
        internal static bool Variable_GitHub = false;

        private void Menú_Contextual_GitHub_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_GitHub = Menú_Contextual_GitHub.Checked;
                //Temporizador_Principal.Interval = !Variable_GitHub ? 1 : 40;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

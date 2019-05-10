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

        /// <summary>
        /// Enumeration that defines the image filters supported by this tool.
        /// </summary>
        internal enum Filtros : int
        {
            Original = 0,
            Negative,
            Flip_horizontally,
            Flip_vertically,
            Rotate_180_degrees,
            Brightness_negative,
            Brightness_positive,
            Intensity_negative,
            Intensity_positive,
            Gamma_negative,
            Gamma_positive,
            Square_root_negative,
            Square_root_positive,
            Logarithm_negative,
            Logarithm_positive__night_vision___,
            Normalization,
            Centered_normalization,
            Differences_over_time__use_on_video___,
            Minimum_difference,
            Minimum_difference_for_JPEG_1,
            Minimum_difference_for_JPEG_2,
            Minimum_difference_for_JPEG_3,
            Minimum_difference_for_JPEG_4,
            Minimum_difference_for_JPEG_5,
            Minimum_difference_for_JPEG_6,
            Minimum_difference_for_JPEG_7,
            Minimum_difference_for_JPEG_8,
            Minimum_difference_for_JPEG_9,
            Minimum_difference_for_JPEG_10,
            Minimum_difference_for_JPEG_11,
            Minimum_difference_for_JPEG_12,
            Minimum_difference_for_JPEG_13,
            Minimum_difference_for_JPEG_14,
            Minimum_difference_for_JPEG_15,
            Minimum_difference_for_JPEG_16,
            Rainbow_at_30_degrees,
            Rainbow_at_30_degrees_filled,
            Swap_RGB_colors_to_RBG,
            Swap_RGB_colors_to_GRB,
            Swap_RGB_colors_to_GBR,
            Swap_RGB_colors_to_BRG,
            Swap_RGB_colors_to_BGR,
            Termography,
            Variable_termography__3D_X____Ray___,
            Minimum_RGB,
            Median_RGB,
            Maximum_RGB,
            Red,
            Yellow,
            Green,
            Cyan,
            Blue,
            Magenta,
            Hue,
            Saturation,
            Lightness,
            HSL_to_RGB,
            RGB_to_HSL,
            Cyan_color_channel,
            Magenta_color_channel,
            Yellow_color_channel,
            Black_color_channel,
            Image_magick_filter,
        }

        /// <summary>
        /// Enumeration that defines the zoom levels supported by this tool.
        /// </summary>
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
        internal static bool Variable_Negativo = false;
        internal static Filtros Variable_Filtro = Filtros.Original;
        internal static Zooms Variable_Zoom = Zooms.Zoom_1x;
        internal static CheckState Variable_Zoom_Suave = CheckState.Unchecked;
        internal static bool Variable_Seguir_Cursor = true;
        internal static bool Variable_Mantener_Cursor_Centrado = false;

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

        /// <summary>
        /// Used to see what pixels change over time.
        /// </summary>
        internal byte[] Matriz_Bytes_Anterior = null;
        internal byte[] Matriz_Bytes_Anterior_Filtrada = null;

        private void Ventana_Plantilla_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                this.Text = Texto_Título;
                this.Location = new Point(this.Location.X, 0); // Move the window at the top of the screen.
                string[] Matriz_Nombres = Enum.GetNames(typeof(Filtros));
                if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                {
                    foreach (string Nombre in Matriz_Nombres)
                    {
                        ComboBox_Filtro.Items.Add(Nombre.Replace("____", "-").Replace("___", ")").Replace("__", " (").Replace("_", " "));
                    }
                }
                else ComboBox_Filtro.Items.Add("Original");
                CheckBox_Negativo.Checked = Variable_Negativo;
                ComboBox_Filtro.SelectedIndex = (int)Variable_Filtro; // Load the previously used options.
                CheckBox_Zoom_Suave.CheckState = Variable_Zoom_Suave;
                ComboBox_Zoom.SelectedIndex = (int)Variable_Zoom; // TODO: load from the registry.
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

        private void Ventana_Filtros_Pantalla_Tiempo_Real_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, true) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Filtros_Pantalla_Tiempo_Real_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                {
                    string[] Matriz_Rutas = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                    if (Matriz_Rutas != null && Matriz_Rutas.Length > 0)
                    {
                        foreach (string Ruta in Matriz_Rutas)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(Ruta) && File.Exists(Ruta))
                                {
                                    FileStream Lector = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                                    Image Imagen_Original = null;
                                    try { Imagen_Original = Image.FromStream(Lector, false, false); }
                                    catch { Imagen_Original = null; }
                                    if (Imagen_Original != null)
                                    {
                                        int Ancho = Imagen_Original.Width;
                                        int Alto = Imagen_Original.Height;
                                        Bitmap Imagen = new Bitmap(Ancho, Alto, !Image.IsAlphaPixelFormat(Imagen_Original.PixelFormat) ? PixelFormat.Format24bppRgb : PixelFormat.Format32bppArgb);
                                        Graphics Pintar = Graphics.FromImage(Imagen);
                                        Pintar.CompositingMode = CompositingMode.SourceCopy;
                                        Pintar.CompositingQuality = CompositingQuality.HighQuality;
                                        Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                        Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                        Pintar.SmoothingMode = SmoothingMode.HighQuality;
                                        Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                                        Pintar.Dispose();
                                        Pintar = null;
                                        Imagen = Filtrar_Imagen(Imagen, Variable_Filtro);
                                        Imagen.Save(Program.Obtener_Ruta_Temporal_Escritorio() + " " + Path.GetFileNameWithoutExtension(Ruta) + ".png", ImageFormat.Png);
                                        Imagen.Dispose();
                                        Imagen = null;
                                        Imagen_Original.Dispose();
                                        Imagen_Original = null;
                                        Lector.Close();
                                        Lector.Dispose();
                                        Lector = null;
                                        SystemSounds.Asterisk.Play();
                                        return;
                                    }
                                    Lector.Close();
                                    Lector.Dispose();
                                    Lector = null;
                                    //XNA_Jupisoft.Convertir_XNB_a_WAV(Ruta, Program.Obtener_Ruta_Temporal_Escritorio());
                                }
                            }
                            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                        }
                    }
                    Matriz_Rutas = null;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            finally { this.Cursor = Cursors.Default; }
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

        private void CheckBox_Negativo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Negativo = CheckBox_Negativo.Checked;
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

        private void CheckBox_Zoom_Suave_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Zoom_Suave = CheckBox_Zoom_Suave.CheckState;
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
                if (Program.Edición_Aplicación != CheckState.Checked)
                {
                    Ventana_Visor_Ayuda Ventana = new Ventana_Visor_Ayuda();
                    Ventana.Ayuda = Ventana_Visor_Ayuda.Ayudas.Main_window;
                    Ventana.ShowDialog(this);
                    Ventana.Dispose();
                    Ventana = null;
                }
                else MessageBox.Show(this, "Esta ventana contiene decenas de filtros de imagen avanzados.\r\n\r\nSelecciona el que desees utilizar de la lista superior y mueve el cursor sobre la zona de la pantalla que desees filtrar.\r\n\r\nEn teoría debería soportar hasta vídeos que se reproduzcan en otras aplicaciones al igual que cualquier fotografía.\r\n\r\nPero ahora incluye soporte para arrastrar y soltar cualquier imagen, la cual será filtrada y guardada en el escritorio, siempre como una imagen nueva en PNG para no perder calidad. Por lo que tus imágenes originales jamás serán modificadas de ninguna forma.\r\n\r\nEl programa incluye opciones avanzadas como muchos niveles de zoom y suavizado variable.\r\n\r\nAlgunos de los filtros incluidos son variables con el tiempo, o sea que hay que dejar el cursor un rato sobre la misma zona para ir viendo como durante un rato va variando la imagen, permitiendo ver así detalles invisibles a simple vista.\r\n\r\nLa mayoría de los filtros incluidos han sido diseñados por Jupisoft desde el 2004 hasta hoy, así que son fruto de mucho trabajo y cálculos matemáticos complejos, aunque a la vez basados en fórmulas bastante simples de entender.\r\n\r\nSi aún tienes dudas sobre cualquier función del programa, por favor envía un correo a Jupitermauro@gmail.com, muchísimas gracias.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Question);
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

        private void Menú_Contextual_Mover_Cursor_Centro_Click(object sender, EventArgs e)
        {
            try
            {
                Point Posición = Picture.PointToScreen(new Point(Picture.ClientSize.Width / 2, Picture.ClientSize.Height / 2));
                PInvoke.SetCursorPos(Posición.X, Posición.Y);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Mantener_Cursor_Centrado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Mantener_Cursor_Centrado = Menú_Contextual_Mantener_Cursor_Centrado.Checked;
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
                    if (Variable_Mantener_Cursor_Centrado)
                    {
                        Point Posición_Cursor = Control.MousePosition;
                        Point Posición = Picture.PointToScreen(new Point(Picture.ClientSize.Width / 2, Picture.ClientSize.Height / 2));
                        if (Posición_Cursor.X != Posición.X || Posición_Cursor.Y != Posición.Y) PInvoke.SetCursorPos(Posición.X, Posición.Y);
                    }
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
                            int retval = BitBlt(hDC, 0, 0, Ancho, Alto, hSrcDC, Rectángulo.X, Rectángulo.Y, !Variable_Negativo ? (int)CopyPixelOperation.SourceCopy : (int)CopyPixelOperation.NotSourceCopy);
                            Pintar.ReleaseHdc();
                            gsrc.ReleaseHdc();
                        }
                        Pintar.Dispose();
                        Pintar = null;

                        int Ancho_Zoom = Ancho;
                        int Alto_Zoom = Alto;
                        if (Variable_Zoom != Zooms.Zoom_1x)
                        {
                            int Zoom = int.Parse(Variable_Zoom.ToString().Replace("Zoom_", null).Replace("x", null));
                            Ancho /= Zoom;
                            Alto /= Zoom;
                            int X_Zoom = (Ancho_Zoom / 2) - (Ancho / 2);
                            int Y_Zoom = (Alto_Zoom / 2) - (Alto / 2);
                            /*Bitmap Imagen_Zoom = new Bitmap(Ancho, Alto, PixelFormat.Format24bppRgb);
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
                            Imagen = Imagen_Zoom;*/
                            Imagen = Imagen.Clone(new Rectangle(X_Zoom, Y_Zoom, Ancho, Alto), Imagen.PixelFormat);
                        }

                        Imagen = Filtrar_Imagen(Imagen, Variable_Filtro);

                        if (Variable_Zoom != Zooms.Zoom_1x) // Zoom after all the filters.
                        {
                            /*int Zoom = int.Parse(Variable_Zoom.ToString().Replace("Zoom_", null).Replace("x", null));
                            Ancho_Zoom = Ancho / Zoom;
                            Alto_Zoom = Alto / Zoom;
                            X_Zoom = (Ancho / 2) - (Ancho_Zoom / 2);
                            Y_Zoom = (Alto / 2) - (Alto_Zoom / 2);*/
                            Bitmap Imagen_Zoom = new Bitmap(Ancho_Zoom, Alto_Zoom, PixelFormat.Format24bppRgb);
                            Pintar = Graphics.FromImage(Imagen_Zoom);
                            Pintar.CompositingMode = CompositingMode.SourceCopy;
                            Pintar.CompositingQuality = CompositingQuality.HighQuality;
                            Pintar.InterpolationMode = Variable_Zoom_Suave == CheckState.Unchecked ? InterpolationMode.NearestNeighbor : Variable_Zoom_Suave == CheckState.Checked ? InterpolationMode.Default : InterpolationMode.HighQualityBicubic;
                            Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            Pintar.SmoothingMode = SmoothingMode.HighQuality;
                            Pintar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                            Pintar.DrawImage(Imagen, new Rectangle(0, 0, Ancho_Zoom, Alto_Zoom), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                            Pintar.Dispose();
                            Pintar = null;
                            Imagen = Imagen_Zoom;
                        }

                        Picture.Image = Imagen;
                        Picture.Invalidate();
                        Picture.Update();
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
                    //Rectangle Rectángulo = new Rectangle(17, 146, 1, 1); // Old VGA.
                    Rectangle Rectángulo = new Rectangle(17, 147, 1, 1); // New VGA.
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
                            if (Valor >= 192 && Valor < 255/*(Matriz_Bytes[Índice + 2] == 236 && Matriz_Bytes[Índice + 1] == 236 && Matriz_Bytes[Índice] == 236) ||
                                (Matriz_Bytes[Índice + 2] == 231 && Matriz_Bytes[Índice + 1] == 231 && Matriz_Bytes[Índice] == 231)*/)
                            {
                                Estado = CheckState.Unchecked;
                            }
                            else if (Valor <= 128) //((Matriz_Bytes[Índice + 2] == 102 && Matriz_Bytes[Índice + 1] == 102 && Matriz_Bytes[Índice] == 102) ||
                                //(Matriz_Bytes[Índice + 2] == 168 && Matriz_Bytes[Índice + 1] == 170 && Matriz_Bytes[Índice] == 171))
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
                    //Temporizador_Principal.Stop();
                    //MessageBox.Show(this, "GitHub Desktop: " + Estado.ToString());
                    //Temporizador_Principal.Start();

                    if (Estado != CheckState.Indeterminate)
                    {
                        Cronómetro_GitHub.Reset();
                        if (Estado == CheckState.Unchecked)
                        {
                            PInvoke.SetCursorPos(17, 147);
                            PInvoke.mouse_event(PInvoke.MouseEventF.LeftDown, 0, 0, 0, 0);
                            PInvoke.mouse_event(PInvoke.MouseEventF.LeftUp, 0, 0, 0, 0);
                            Thread.Sleep(40);
                            //Temporizador_Principal.Stop();
                            //MessageBox.Show(this, "Checked?");
                            //Temporizador_Principal.Start();
                        }
                        else
                        {
                            //Rectángulo = new Rectangle(55, 660, 1, 1); // Old VGA.
                            Rectángulo = new Rectangle(55, 660, 1, 1); // New VGA.

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
                            //Temporizador_Principal.Stop();
                            //MessageBox.Show(this, "Estado_GitHub 2: " + Estado_GitHub.ToString());
                            //Temporizador_Principal.Start();

                            if (Estado_GitHub != GitHub_Estados.Desconocido)
                            {
                                if (Estado_GitHub == GitHub_Estados.Habilitado)
                                {
                                    PInvoke.SetCursorPos(55, 660);
                                    PInvoke.mouse_event(PInvoke.MouseEventF.LeftDown, 0, 0, 0, 0);
                                    PInvoke.mouse_event(PInvoke.MouseEventF.LeftUp, 0, 0, 0, 0);
                                    Thread.Sleep(40);
                                    //Temporizador_Principal.Stop();
                                    //MessageBox.Show(this, "Clicked?");
                                    //Temporizador_Principal.Start();
                                }
                            }
                        }
                    }
                    else if (!Cronómetro_GitHub.IsRunning)
                    {
                        Cronómetro_GitHub.Restart();
                    }
                    else if (Cronómetro_GitHub.ElapsedMilliseconds >= 2000L)
                    {
                        Menú_Contextual_GitHub.Checked = false;
                        Cronómetro_GitHub.Reset();
                        SystemSounds.Hand.Play();
                    }
                    else if (Control.MousePosition.X != 621 || Control.MousePosition.Y != 419)
                    {
                        PInvoke.SetCursorPos(621, 419); // Try to avoid the Close button if an error happens.
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

        internal Bitmap Filtrar_Imagen(Bitmap Imagen, Filtros Filtro)
        {
            try
            {
                if (Imagen != null)
                {
                    int Ancho = Imagen.Width;
                    int Alto = Imagen.Height;
                    if (Filtro == Filtros.Flip_horizontally)
                    {
                        Imagen.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                    else if (Filtro == Filtros.Flip_vertically)
                    {
                        Imagen.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    }
                    else if (Filtro == Filtros.Rotate_180_degrees)
                    {
                        Imagen.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                    }
                    else if (Filtro == Filtros.Gamma_negative || Filtro == Filtros.Gamma_positive || Filtro == Filtros.Cyan_color_channel || Filtro == Filtros.Magenta_color_channel || Filtro == Filtros.Yellow_color_channel || Filtro == Filtros.Black_color_channel)
                    {
                        Bitmap Imagen_Atributos = new Bitmap(Ancho, Alto, !Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? PixelFormat.Format24bppRgb : PixelFormat.Format32bppArgb);
                        Graphics Pintar_Atributos = Graphics.FromImage(Imagen_Atributos);
                        Pintar_Atributos.CompositingMode = CompositingMode.SourceCopy;
                        Pintar_Atributos.CompositingQuality = CompositingQuality.HighQuality;
                        Pintar_Atributos.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Pintar_Atributos.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Pintar_Atributos.SmoothingMode = SmoothingMode.HighQuality;
                        ImageAttributes Atributos = new ImageAttributes();
                        if (Filtro == Filtros.Gamma_negative) Atributos.SetGamma(2.0f);
                        else if (Filtro == Filtros.Gamma_positive) Atributos.SetGamma(0.5f);
                        else if (Filtro == Filtros.Cyan_color_channel) Atributos.SetOutputChannel(ColorChannelFlag.ColorChannelC);
                        else if (Filtro == Filtros.Magenta_color_channel) Atributos.SetOutputChannel(ColorChannelFlag.ColorChannelM);
                        else if (Filtro == Filtros.Yellow_color_channel) Atributos.SetOutputChannel(ColorChannelFlag.ColorChannelY);
                        else if (Filtro == Filtros.Black_color_channel) Atributos.SetOutputChannel(ColorChannelFlag.ColorChannelK);
                        Pintar_Atributos.DrawImage(Imagen, new Rectangle(0, 0, Ancho, Alto), 0, 0, Ancho, Alto, GraphicsUnit.Pixel, Atributos);
                        Atributos.Dispose();
                        Atributos = null;
                        Pintar_Atributos.Dispose();
                        Pintar_Atributos = null;
                        Imagen = Imagen_Atributos;
                    }
                    else if (Filtro == Filtros.Image_magick_filter)
                    {
                        MagickImage Imagen_Mágica = new MagickImage(Imagen.Clone() as Bitmap);
                        //Imagen_Mágica.Implode(5d, PixelInterpolateMethod.Average); // Esfera.
                        //Imagen_Mágica.Raise(16); // Marco.
                        //Imagen_Mágica.Swirl(PixelInterpolateMethod.Nearest, 9d); // Giro.
                        //Imagen_Mágica.Normalize();
                        //Imagen_Mágica.SigmoidalContrast(32d);
                        //Imagen_Mágica.Solarize(0.5d);
                        //Imagen_Mágica.Transpose();
                        Imagen_Mágica.Swirl(360d); // Giro.
                        Imagen = Imagen_Mágica.ToBitmap();
                        Imagen_Mágica.Dispose();
                        Imagen_Mágica = null;
                    }
                    else if (Filtro != Filtros.Original && (Filtro < Filtros.Flip_horizontally || Filtro > Filtros.Rotate_180_degrees))
                    {
                        bool Cancelar_Marshal_Copy = false; // If false, copy back the modified pixels.
                        BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                        byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                        Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                        int Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                        int Bytes_Ancho = Math.Abs(Bitmap_Data.Stride);
                        int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                        if (Filtro == Filtros.Negative)
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
                        else if (Filtro == Filtros.Brightness_negative)
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
                        else if (Filtro == Filtros.Brightness_positive)
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
                        else if (Filtro == Filtros.Intensity_negative)
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
                        else if (Filtro == Filtros.Intensity_positive)
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
                        else if (Filtro == Filtros.Square_root_negative)
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
                        else if (Filtro == Filtros.Square_root_positive)
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
                        else if (Filtro == Filtros.Logarithm_negative)
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
                        else if (Filtro == Filtros.Logarithm_positive__night_vision___)
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
                        else if (Filtro == Filtros.Normalization)
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
                        else if (Filtro == Filtros.Centered_normalization)
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
                        else if (Filtro == Filtros.Differences_over_time__use_on_video___)
                        {
                            byte[] Matriz_Bytes_Original = (byte[])Matriz_Bytes.Clone();
                            if (Matriz_Bytes_Anterior == null || Matriz_Bytes_Anterior.Length != Matriz_Bytes.Length)
                            {
                                Matriz_Bytes_Anterior = (byte[])Matriz_Bytes.Clone();
                                Matriz_Bytes_Anterior_Filtrada = (byte[])Matriz_Bytes.Clone();
                            }
                            int Diferencia_Máxima_R = 0;
                            int Diferencia_Máxima_G = 0;
                            int Diferencia_Máxima_B = 0;
                            // Find the maximum RGB differences.
                            int Diferencia_R, Diferencia_G, Diferencia_B;
                            for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                            {
                                for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                {
                                    Diferencia_R = Math.Abs(Matriz_Bytes_Original[Índice + 2] - Matriz_Bytes_Anterior[Índice + 2]);
                                    Diferencia_G = Math.Abs(Matriz_Bytes_Original[Índice + 1] - Matriz_Bytes_Anterior[Índice + 1]);
                                    Diferencia_B = Math.Abs(Matriz_Bytes_Original[Índice] - Matriz_Bytes_Anterior[Índice]);
                                    if (Diferencia_R > Diferencia_Máxima_R) Diferencia_Máxima_R = Diferencia_R;
                                    if (Diferencia_G > Diferencia_Máxima_G) Diferencia_Máxima_G = Diferencia_G;
                                    if (Diferencia_B > Diferencia_Máxima_B) Diferencia_Máxima_B = Diferencia_B;
                                }
                            }
                            // Assign the new values.
                            //Matriz_Bytes = new byte[Matriz_Bytes.Length]; // Clear the whole array.
                            Array.Clear(Matriz_Bytes, 0, Matriz_Bytes.Length); // Clear the whole array.
                            if (Diferencia_Máxima_R > 0 || Diferencia_Máxima_G > 0 || Diferencia_Máxima_B > 0)
                            {
                                for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                                {
                                    for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                    {
                                        Diferencia_R = Math.Abs(Matriz_Bytes_Original[Índice + 2] - Matriz_Bytes_Anterior[Índice + 2]);
                                        Diferencia_G = Math.Abs(Matriz_Bytes_Original[Índice + 1] - Matriz_Bytes_Anterior[Índice + 1]);
                                        Diferencia_B = Math.Abs(Matriz_Bytes_Original[Índice] - Matriz_Bytes_Anterior[Índice]);
                                        if (Diferencia_R > 0) Matriz_Bytes[Índice + 2] = (byte)((Diferencia_R * 255) / Diferencia_Máxima_R);
                                        if (Diferencia_G > 0) Matriz_Bytes[Índice + 1] = (byte)((Diferencia_G * 255) / Diferencia_Máxima_G);
                                        if (Diferencia_B > 0) Matriz_Bytes[Índice] = (byte)((Diferencia_B * 255) / Diferencia_Máxima_B);
                                    }
                                }
                                Matriz_Bytes_Anterior_Filtrada = (byte[])Matriz_Bytes.Clone();
                            }
                            else // Avoid flickering if nothing has changed. The screen won't turn black.
                            {
                                Matriz_Bytes = (byte[])Matriz_Bytes_Anterior_Filtrada.Clone();
                            }
                            Matriz_Bytes_Anterior = Matriz_Bytes_Original;
                        }
                        else if (Filtro >= Filtros.Minimum_difference && Filtro <= Filtros.Minimum_difference_for_JPEG_16)
                        {
                            byte[] Matriz_Bytes_Original = (byte[])Matriz_Bytes.Clone();
                            int Ruido_JPEG = 0; // Used to avoid JPEG noise. 0 = Disabled. 2 = Default.
                            try
                            {
                                string Nombre = Filtro.ToString();
                                if (char.IsDigit(Nombre[Nombre.Length - 1]))
                                {
                                    Ruido_JPEG = int.Parse(Nombre.Substring(Nombre.Length - 2, 2).Replace("_", null));
                                }
                            }
                            catch { Ruido_JPEG = 0; }
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
                                                if (Valor_R_Temporal < Valor_R && Valor_R_Temporal > Ruido_JPEG && Matriz_Bytes_Original[Subíndice + 2] < Rojo) Valor_R = Valor_R_Temporal;
                                                if (Valor_G_Temporal < Valor_G && Valor_G_Temporal > Ruido_JPEG && Matriz_Bytes_Original[Subíndice + 1] < Verde) Valor_G = Valor_G_Temporal;
                                                if (Valor_B_Temporal < Valor_B && Valor_B_Temporal > Ruido_JPEG && Matriz_Bytes_Original[Subíndice] < Azul) Valor_B = Valor_B_Temporal;
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
                        else if (Filtro == Filtros.Rainbow_at_30_degrees)
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
                        else if (Filtro == Filtros.Rainbow_at_30_degrees_filled)
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
                        else if (Filtro == Filtros.Swap_RGB_colors_to_RBG)
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
                        else if (Filtro == Filtros.Swap_RGB_colors_to_GRB)
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
                        else if (Filtro == Filtros.Swap_RGB_colors_to_GBR)
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
                        else if (Filtro == Filtros.Swap_RGB_colors_to_BRG)
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
                        else if (Filtro == Filtros.Swap_RGB_colors_to_BGR)
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
                        else if (Filtro == Filtros.Termography)
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
                        else if (Filtro == Filtros.Variable_termography__3D_X____Ray___)
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
                        else if (Filtro == Filtros.Minimum_RGB)
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
                        else if (Filtro == Filtros.Median_RGB)
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
                        else if (Filtro == Filtros.Maximum_RGB)
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
                        else if (Filtro == Filtros.Red)
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
                        else if (Filtro == Filtros.Yellow)
                        {
                            for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                            {
                                for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                {
                                    Matriz_Bytes[Índice] = 0;
                                }
                            }
                        }
                        else if (Filtro == Filtros.Green)
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
                        else if (Filtro == Filtros.Cyan)
                        {
                            for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                            {
                                for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                {
                                    Matriz_Bytes[Índice + 2] = 0;
                                }
                            }
                        }
                        else if (Filtro == Filtros.Blue)
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
                        else if (Filtro == Filtros.Magenta)
                        {
                            for (int Índice_Y = 0, Índice = 0; Índice_Y < Alto; Índice_Y++, Índice += Bytes_Diferencia)
                            {
                                for (int Índice_X = 0; Índice_X < Ancho; Índice_X++, Índice += Bytes_Aumento)
                                {
                                    Matriz_Bytes[Índice + 1] = 0;
                                }
                            }
                        }
                        else if (Filtro == Filtros.Hue)
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
                        else if (Filtro == Filtros.Saturation)
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
                        else if (Filtro == Filtros.Lightness)
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
                        else if (Filtro == Filtros.HSL_to_RGB)
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
                        else if (Filtro == Filtros.RGB_to_HSL)
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
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            return Imagen;
        }
    }
}

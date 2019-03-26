using ICSharpCode.SharpZipLib.Zip;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Generador_Packs_Recursos_Nivel_Luz: Form
    {
        public Ventana_Generador_Packs_Recursos_Nivel_Luz()
        {
            InitializeComponent();
        }

        internal readonly string Texto_Título = "Custom Light Level Resource Packs Generator for " + Program.Texto_Usuario + " by Jupisoft";
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

        private void Ventana_Generador_Packs_Recursos_Nivel_Luz_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                this.Text = Texto_Título + " - [The resource packs will be saved on your desktop]";
                this.WindowState = FormWindowState.Maximized;
                Ocupado = true;
                Registro_Cargar_Opciones();
                ComboBox_Formato_Pack.SelectedIndex = 3;
                ComboBox_Nivel_Luz.SelectedIndex = 15;
                Ocupado = false;
                Actualizar_Nivel_Luz();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Generador_Packs_Recursos_Nivel_Luz_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal.Start();
                /*ColorDialog Diálogo_Color = new ColorDialog();
                Diálogo_Color.AllowFullOpen = true;
                Diálogo_Color.AnyColor = true;
                Diálogo_Color.Color = Variable_Color_Fondo;
                Diálogo_Color.CustomColors = new int[16] { 255, 65535, 65280, 16776960, 16711680, 16711935, 0, 16777215, 128, 32896, 32768, 8421376, 8388608, 8388736, 8421504, 12632256 };
                Diálogo_Color.FullOpen = true;
                Diálogo_Color.SolidColorOnly = false;
                if (Diálogo_Color.ShowDialog(this) == DialogResult.OK)
                {
                    Variable_Color_Fondo = Color.FromArgb(255, Diálogo_Color.Color.R, Diálogo_Color.Color.G, Diálogo_Color.Color.B);
                    Registro_Guardar_Opciones();
                    Picture.BackColor = Variable_Color_Fondo;
                    Picture.Refresh();
                }
                Diálogo_Color.Dispose();
                Diálogo_Color = null;*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Generador_Packs_Recursos_Nivel_Luz_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Generador_Packs_Recursos_Nivel_Luz_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Generador_Packs_Recursos_Nivel_Luz_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Generador_Packs_Recursos_Nivel_Luz_KeyDown(object sender, KeyEventArgs e)
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

        private void ComboBox_Formato_Pack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Generar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int Alfa = (int)NumericUpDown_Alfa.Value;
                int Rojo = (int)NumericUpDown_Rojo.Value;
                int Verde = (int)NumericUpDown_Verde.Value;
                int Azul = (int)NumericUpDown_Azul.Value;
                //int Nivel_Luz = (Rojo + Verde + Azul) / 3; // Which method is the best, average?
                //int Nivel_Luz = Math.Max(Rojo, Math.Max(Verde, Azul)); // Or maximum?
                int Dimensión_Mínima = Math.Min((int)NumericUpDown_Dimensión_Mínima.Value, (int)NumericUpDown_Dimensión_Máxima.Value); // Avoid user input errors.
                int Dimensión_Máxima = Math.Max((int)NumericUpDown_Dimensión_Mínima.Value, (int)NumericUpDown_Dimensión_Máxima.Value); // Get the true minimum and maximum.
                Bitmap Imagen = new Bitmap(64, 32, PixelFormat.Format32bppArgb);
                Graphics Pintar = Graphics.FromImage(Imagen);
                Pintar.CompositingMode = CompositingMode.SourceCopy;
                Pintar.CompositingQuality = CompositingQuality.HighQuality;
                Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Pintar.SmoothingMode = SmoothingMode.HighQuality;
                Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;
                SolidBrush Pincel = new SolidBrush(Color.FromArgb(Alfa, Rojo, Verde, Azul));
                Pintar.FillRectangle(Pincel, 0, 0, 64, 32);
                //Pincel.Dispose(); // Don't close it yet, it's used below.
                //Pincel = null;
                Pintar.Dispose();
                Pintar = null;
                MemoryStream Lector_Memoria = new MemoryStream(); // Save the image as PNG in the memory.
                Imagen.Save(Lector_Memoria, ImageFormat.Png);
                byte[] Matriz_Bytes = Lector_Memoria.ToArray(); // Get the bytes of the saved image.
                Lector_Memoria.Close();
                Lector_Memoria.Dispose();
                Lector_Memoria = null;
                Imagen.Dispose();
                Imagen = null;
                
                int Formato_Pack = ComboBox_Formato_Pack.SelectedIndex + 1;
                string Ruta_ZIP = Program.Obtener_Ruta_Temporal_Escritorio() + " Light ARGB " + Alfa.ToString() + ", " + Rojo.ToString() + ", " + Verde.ToString() + ", " + Azul.ToString() + " [" + (Formato_Pack == 1 ? "1.6+" : Formato_Pack == 2 ? "1.9+" : Formato_Pack == 3 ? "1.11+" : "1.13+") + "].zip";
                FileStream Lector = new FileStream(Ruta_ZIP, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                Lector.SetLength(0L);
                Lector.Seek(0L, SeekOrigin.Begin);
                ZipOutputStream Archivo_ZIP = new ZipOutputStream(Lector); // Start a new zip file.
                
                for (int Índice = Dimensión_Mínima; Índice <= Dimensión_Máxima; Índice++)
                {
                    Archivo_ZIP.PutNextEntry(new ZipEntry("assets/minecraft/" + (Formato_Pack < 4 ? "mcpatcher" : "optifine") + "/lightmap/world" + Índice.ToString() + ".png"));
                    Archivo_ZIP.Write(Matriz_Bytes, 0, Matriz_Bytes.Length); // Add copies of the image in the zip.
                    Archivo_ZIP.CloseEntry();
                } // This even supports modpacks dimensions, just search it's ID numbers and include them.
                Matriz_Bytes = null;

                // package net.minecraft.util.text:
                /*BLACK("BLACK", '0', 0),
                DARK_BLUE("DARK_BLUE", '1', 1),
                DARK_GREEN("DARK_GREEN", '2', 2),
                DARK_AQUA("DARK_AQUA", '3', 3),
                DARK_RED("DARK_RED", '4', 4),
                DARK_PURPLE("DARK_PURPLE", '5', 5),
                GOLD("GOLD", '6', 6),
                GRAY("GRAY", '7', 7),
                DARK_GRAY("DARK_GRAY", '8', 8),
                BLUE("BLUE", '9', 9),
                GREEN("GREEN", 'a', 10),
                AQUA("AQUA", 'b', 11),
                RED("RED", 'c', 12),
                LIGHT_PURPLE("LIGHT_PURPLE", 'd', 13),
                YELLOW("YELLOW", 'e', 14),
                WHITE("WHITE", 'f', 15),
                OBFUSCATED("OBFUSCATED", 'k', true),
                BOLD("BOLD", 'l', true),
                STRIKETHROUGH("STRIKETHROUGH", 'm', true),
                UNDERLINE("UNDERLINE", 'n', true),
                ITALIC("ITALIC", 'o', true),
                RESET("RESET", 'r', -1);*/

                // §0 = Color black.
                // §1 = Color blue.
                // §2 = Color green.
                // §3 = Color cyan.
                // §4 = Color Red.
                // §5 = Color fuchsia.
                // §6 = Color yellow.
                // §7 = Color light gray.
                // §8 = Color gray.
                // §9 = Color light blue.
                // §a = Color lime.
                // §b = Color cyan.
                // §c = Color red.
                // §d = Color .
                // §e = Color yellow.
                // §f = Color white.
                // § = Color .
                // § = Color .
                // § = Color .
                // § = Color .
                // § = Color .
                // § = Color .
                // § = Color .
                // § = Color .
                // § = Color .

                Archivo_ZIP.PutNextEntry(new ZipEntry("pack.mcmeta"));
                Matriz_Bytes = Encoding.UTF8.GetBytes("{\r\n  \"pack\": {\r\n    \"pack_format\": " + Formato_Pack.ToString() + ",\r\n    \"description\": \"§fLight§r §7A§cR§aG§9B:§r §7" + Alfa.ToString() + "§r, §c" + Rojo.ToString() + "§r, §a" + Verde.ToString() + "§r, §9" + Azul.ToString() + "§r\\n§fDimensions:§r §7" + Dimensión_Mínima.ToString() + "§r to §7" + Dimensión_Máxima.ToString() + "§r\"\r\n  }\r\n}\r\n");
                Archivo_ZIP.Write(Matriz_Bytes, 0, Matriz_Bytes.Length);
                Archivo_ZIP.CloseEntry();
                Matriz_Bytes = null;

                int Ancho_Alto = 64; // 256.
                Imagen = new Bitmap(Ancho_Alto, Ancho_Alto, PixelFormat.Format32bppArgb); // Generate the pack image.
                Pintar = Graphics.FromImage(Imagen);
                Pintar.CompositingMode = CompositingMode.SourceCopy;
                Pintar.CompositingQuality = CompositingQuality.HighQuality;
                Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Pintar.SmoothingMode = SmoothingMode.HighQuality;
                Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;
                TextureBrush Pincel_Fondo = new TextureBrush(Resources.Fondo, WrapMode.Tile);
                Pintar.FillRectangle(Pincel_Fondo, 0, 0, Ancho_Alto, Ancho_Alto);
                Pincel_Fondo.Dispose();
                Pincel_Fondo = null;
                Pintar.CompositingMode = CompositingMode.SourceOver; // Mix with the background.
                Pintar.FillRectangle(Pincel, 0, 0, Ancho_Alto, Ancho_Alto);
                Pincel.Dispose(); // Close it now.
                Pincel = null;
                Pintar.Dispose();
                Pintar = null;
                Lector_Memoria = new MemoryStream(); // Save the image as PNG in the memory.
                Imagen.Save(Lector_Memoria, ImageFormat.Png);
                Matriz_Bytes = Lector_Memoria.ToArray(); // Get the bytes of the saved image.
                Lector_Memoria.Close();
                Lector_Memoria.Dispose();
                Lector_Memoria = null;
                Imagen.Dispose();
                Imagen = null;

                Archivo_ZIP.PutNextEntry(new ZipEntry("pack.png"));
                Archivo_ZIP.Write(Matriz_Bytes, 0, Matriz_Bytes.Length);
                Archivo_ZIP.CloseEntry();
                Matriz_Bytes = null;

                Archivo_ZIP.Finish();
                Archivo_ZIP.Close();
                Archivo_ZIP.Dispose();
                Archivo_ZIP = null;
                Matriz_Bytes = null;
                SystemSounds.Asterisk.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            finally { this.Cursor = Cursors.Default; }
        }

        private void ComboBox_Nivel_Luz_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Ocupado && ComboBox_Nivel_Luz.SelectedIndex > -1)
                {
                    Ocupado = true;
                    //int Nivel_Luz = ComboBox_Nivel_Luz.SelectedIndex * 16; // 0 ~ 240, absolute dark at zero.
                    //int Nivel_Luz = ((ComboBox_Nivel_Luz.SelectedIndex + 1) * 16) - 1; // 15 ~ 255.
                    int Nivel_Luz = ComboBox_Nivel_Luz.SelectedIndex * 17; // 0 ~ 255.
                    NumericUpDown_Alfa.Value = 255; // Alpha changes anything at all?
                    NumericUpDown_Rojo.Value = Nivel_Luz; // Gray scale light level.
                    NumericUpDown_Verde.Value = Nivel_Luz;
                    NumericUpDown_Azul.Value = Nivel_Luz;
                    Ocupado = false;
                    Actualizar_Nivel_Luz();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void NumericUpDown_Alfa_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TrackBar_Alfa.Value != (int)NumericUpDown_Alfa.Value)
                {
                    TrackBar_Alfa.Value = (int)NumericUpDown_Alfa.Value;
                }
                Actualizar_Nivel_Luz();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void TrackBar_Alfa_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (NumericUpDown_Alfa.Value != TrackBar_Alfa.Value)
                {
                    NumericUpDown_Alfa.Value = TrackBar_Alfa.Value;
                } // Don't update, just sync it.
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void NumericUpDown_Rojo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TrackBar_Rojo.Value != (int)NumericUpDown_Rojo.Value)
                {
                    TrackBar_Rojo.Value = (int)NumericUpDown_Rojo.Value;
                }
                Actualizar_Nivel_Luz();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void TrackBar_Rojo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (NumericUpDown_Rojo.Value != TrackBar_Rojo.Value)
                {
                    NumericUpDown_Rojo.Value = TrackBar_Rojo.Value;
                } // Don't update, just sync it.
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void NumericUpDown_Verde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TrackBar_Verde.Value != (int)NumericUpDown_Verde.Value)
                {
                    TrackBar_Verde.Value = (int)NumericUpDown_Verde.Value;
                }
                Actualizar_Nivel_Luz();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void TrackBar_Verde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (NumericUpDown_Verde.Value != TrackBar_Verde.Value)
                {
                    NumericUpDown_Verde.Value = TrackBar_Verde.Value;
                } // Don't update, just sync it.
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void NumericUpDown_Azul_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TrackBar_Azul.Value != (int)NumericUpDown_Azul.Value)
                {
                    TrackBar_Azul.Value = (int)NumericUpDown_Azul.Value;
                }
                Actualizar_Nivel_Luz();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void TrackBar_Azul_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (NumericUpDown_Azul.Value != TrackBar_Azul.Value)
                {
                    NumericUpDown_Azul.Value = TrackBar_Azul.Value;
                } // Don't update, just sync it.
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void NumericUpDown_Dimensión_Mínima_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TrackBar_Dimensión_Mínima.Value != (int)NumericUpDown_Dimensión_Mínima.Value)
                {
                    TrackBar_Dimensión_Mínima.Value = (int)NumericUpDown_Dimensión_Mínima.Value;
                }
                Actualizar_Nivel_Luz();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void TrackBar_Dimensión_Mínima_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (NumericUpDown_Dimensión_Mínima.Value != TrackBar_Dimensión_Mínima.Value)
                {
                    NumericUpDown_Dimensión_Mínima.Value = TrackBar_Dimensión_Mínima.Value;
                } // Don't update, just sync it.

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void NumericUpDown_Dimensión_Máxima_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TrackBar_Dimensión_Máxima.Value != (int)NumericUpDown_Dimensión_Máxima.Value)
                {
                    TrackBar_Dimensión_Máxima.Value = (int)NumericUpDown_Dimensión_Máxima.Value;
                }
                Actualizar_Nivel_Luz();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void TrackBar_Dimensión_Máxima_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (NumericUpDown_Dimensión_Máxima.Value != TrackBar_Dimensión_Máxima.Value)
                {
                    NumericUpDown_Dimensión_Máxima.Value = TrackBar_Dimensión_Máxima.Value;
                } // Don't update, just sync it.
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        internal void Actualizar_Nivel_Luz()
        {
            try
            {
                if (!Ocupado)
                {
                    try
                    {
                        Ocupado = true;
                        int Alfa = (int)NumericUpDown_Alfa.Value;
                        int Rojo = (int)NumericUpDown_Rojo.Value;
                        int Verde = (int)NumericUpDown_Verde.Value;
                        int Azul = (int)NumericUpDown_Azul.Value;

                        Bitmap Imagen_Alfa = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
                        Graphics Pintar_Alfa = Graphics.FromImage(Imagen_Alfa);
                        Pintar_Alfa.CompositingMode = CompositingMode.SourceCopy;
                        Pintar_Alfa.CompositingQuality = CompositingQuality.HighQuality;
                        Pintar_Alfa.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Pintar_Alfa.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Pintar_Alfa.SmoothingMode = SmoothingMode.HighQuality;
                        Pintar_Alfa.TextRenderingHint = TextRenderingHint.AntiAlias;
                        SolidBrush Pincel_Alfa = new SolidBrush(Color.FromArgb(Alfa, Rojo, Verde, Azul));
                        Pintar_Alfa.FillRectangle(Pincel_Alfa, 0, 0, 16, 16);
                        Pincel_Alfa.Dispose();
                        Pincel_Alfa = null;
                        Pintar_Alfa.Dispose();
                        Pintar_Alfa = null;

                        Bitmap Imagen_Rojo = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
                        Graphics Pintar_Rojo = Graphics.FromImage(Imagen_Rojo);
                        Pintar_Rojo.CompositingMode = CompositingMode.SourceCopy;
                        Pintar_Rojo.CompositingQuality = CompositingQuality.HighQuality;
                        Pintar_Rojo.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Pintar_Rojo.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Pintar_Rojo.SmoothingMode = SmoothingMode.HighQuality;
                        Pintar_Rojo.TextRenderingHint = TextRenderingHint.AntiAlias;
                        SolidBrush Pincel_Rojo = new SolidBrush(Color.FromArgb(Alfa, Rojo, 0, 0));
                        Pintar_Rojo.FillRectangle(Pincel_Rojo, 0, 0, 16, 16);
                        Pincel_Rojo.Dispose();
                        Pincel_Rojo = null;
                        Pintar_Rojo.Dispose();
                        Pintar_Rojo = null;

                        Bitmap Imagen_Verde = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
                        Graphics Pintar_Verde = Graphics.FromImage(Imagen_Verde);
                        Pintar_Verde.CompositingMode = CompositingMode.SourceCopy;
                        Pintar_Verde.CompositingQuality = CompositingQuality.HighQuality;
                        Pintar_Verde.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Pintar_Verde.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Pintar_Verde.SmoothingMode = SmoothingMode.HighQuality;
                        Pintar_Verde.TextRenderingHint = TextRenderingHint.AntiAlias;
                        SolidBrush Pincel_Verde = new SolidBrush(Color.FromArgb(Alfa, 0, Verde, 0));
                        Pintar_Verde.FillRectangle(Pincel_Verde, 0, 0, 16, 16);
                        Pincel_Verde.Dispose();
                        Pincel_Verde = null;
                        Pintar_Verde.Dispose();
                        Pintar_Verde = null;

                        Bitmap Imagen_Azul = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
                        Graphics Pintar_Azul = Graphics.FromImage(Imagen_Azul);
                        Pintar_Azul.CompositingMode = CompositingMode.SourceCopy;
                        Pintar_Azul.CompositingQuality = CompositingQuality.HighQuality;
                        Pintar_Azul.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Pintar_Azul.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Pintar_Azul.SmoothingMode = SmoothingMode.HighQuality;
                        Pintar_Azul.TextRenderingHint = TextRenderingHint.AntiAlias;
                        SolidBrush Pincel_Azul = new SolidBrush(Color.FromArgb(Alfa, 0, 0, Azul));
                        Pintar_Azul.FillRectangle(Pincel_Azul, 0, 0, 16, 16);
                        Pincel_Azul.Dispose();
                        Pincel_Azul = null;
                        Pintar_Azul.Dispose();
                        Pintar_Azul = null;
                        
                        Picture_Alfa.Image = Imagen_Alfa;
                        Picture_Rojo.Image = Imagen_Rojo;
                        Picture_Verde.Image = Imagen_Verde;
                        Picture_Azul.Image = Imagen_Azul;
                    }
                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
                    finally { Ocupado = false; } // Always reset at the end.
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

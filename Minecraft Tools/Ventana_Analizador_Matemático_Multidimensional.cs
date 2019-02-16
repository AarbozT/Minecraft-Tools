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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Analizador_Matemático_Multidimensional : Form
    {
        public Ventana_Analizador_Matemático_Multidimensional()
        {
            InitializeComponent();
        }

        internal enum Filtros : int
        {
            Original = 0,
            Negative,
            Bit_inversion_in_base_2,
            Bit_inversion_in_base_4,
            Bit_inversion_in_base_16,
            Bit_inversion_in_bases_2_and_4,
            Bit_inversion_in_bases_2_and_16,
            Bit_inversion_in_bases_4_and_16,
            Bit_inversion_in_bases_2___4_and_16,
        }

        internal static Filtros Filtro = Filtros.Bit_inversion_in_bases_2_and_16;
        internal static byte[] Matriz_Bytes_Personalizado_Cifrado = null;
        internal static byte[] Matriz_Bytes_Personalizado_Descifrado = null;
        internal static byte[] Matriz_Bytes_Personalizado_2_Cifrado = null;
        internal static byte[] Matriz_Bytes_Personalizado_2_Descifrado = null;
        internal Label[] Matriz_Etiquetas = null;
        internal Label[][] Matriz_Etiquetas_XY = null;
        internal static byte[] Matriz_Bytes_Actual = null;
        internal bool Tecla_Alt_Presionada = false;
        internal bool Tecla_Control_Presionada = false;
        internal bool Tecla_Mayúsculas_Presionada = false;

        internal readonly string Texto_Título = "Multidimensional Mathematic Analyzer for " + Program.Texto_Usuario + " by Jupisoft";
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

        private void Ventana_Analizador_Matemático_Multidimensional_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                this.Text = Texto_Título;
                //this.WindowState = FormWindowState.Maximized;
                Ocupado = true;
                Registro_Cargar_Opciones();
                Ocupado = false;
                Matriz_Etiquetas = new Label[256];
                Matriz_Etiquetas_XY = new Label[16][];
                for (int Y = 0, Índice = 0; Y < 16; Y++)
                {
                    Matriz_Etiquetas_XY[Y] = new Label[16];
                    for (int X = 0; X < 16; X++, Índice++)
                    {
                        Label Etiqueta = new Label();
                        //Etiqueta.AutoEllipsis = true;
                        Etiqueta.AutoSize = false;
                        Etiqueta.BackColor = Color.White;
                        Etiqueta.BorderStyle = BorderStyle.FixedSingle;
                        Etiqueta.Location = new Point(12 + (26 * X), 12 + (26 * Y));
                        Etiqueta.Margin = Padding.Empty;
                        Etiqueta.Name = "Etiqueta_" + Índice.ToString();
                        Etiqueta.Size = new Size(27, 27);
                        Etiqueta.TabIndex = 6 + Índice;
                        Etiqueta.TextAlign = ContentAlignment.MiddleCenter;
                        Etiqueta.UseMnemonic = false;
                        Controls.Add(Etiqueta);
                        Matriz_Etiquetas[Índice] = Etiqueta;
                        Matriz_Etiquetas_XY[Y][X] = Etiqueta;
                    }
                }

                Bitmap Imagen_Fondo = new Bitmap(256, 256, PixelFormat.Format24bppRgb);
                using (Graphics Pintar = Graphics.FromImage(Imagen_Fondo))
                {
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    Pintar.Clear(Color.White);
                    using (SolidBrush Pincel = new SolidBrush(Color.FromArgb(224, 224, 224)))
                    {
                        Pintar.FillRectangle(Pincel, 0, 63, 256, 1);
                        Pintar.FillRectangle(Pincel, 0, 127, 256, 1);
                        Pintar.FillRectangle(Pincel, 0, 191, 256, 1);
                        Pintar.FillRectangle(Pincel, 64, 0, 1, 256);
                        Pintar.FillRectangle(Pincel, 128, 0, 1, 256);
                        Pintar.FillRectangle(Pincel, 192, 0, 1, 256);
                    }
                    using (Pen Lápiz = new Pen(Color.FromArgb(236, 233, 216))) Pintar.DrawLine(Lápiz, 0, 255, 255, 0);
                }
                Picture.BackgroundImage = Imagen_Fondo;
                Picture.Image = new Bitmap(256, 256, PixelFormat.Format32bppArgb);

                string[] Matriz_Nombres = Enum.GetNames(typeof(Filtros));
                if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                {
                    foreach (string Nombre in Matriz_Nombres)
                    {
                        Combo_Filtro.Items.Add(Nombre.Replace("__", ",").Replace("_", " "));
                    }
                }
                Matriz_Nombres = null;
                //if (Combo_Filtro.Items.Count > 0) Combo_Filtro.SelectedIndex = 0;
                if (Combo_Filtro.Items.Count > 0)
                {
                    Combo_Filtro.SelectedIndex = (int)Filtros.Bit_inversion_in_bases_2_and_16; // Fractal.
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Analizador_Matemático_Multidimensional_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Analizador_Matemático_Multidimensional_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Analizador_Matemático_Multidimensional_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Analizador_Matemático_Multidimensional_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, true) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Analizador_Matemático_Multidimensional_DragDrop(object sender, DragEventArgs e)
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

        private void Ventana_Analizador_Matemático_Multidimensional_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Analizador_Matemático_Multidimensional_KeyDown(object sender, KeyEventArgs e)
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

        internal void Establecer_Valores(Byte[] Matriz_Bytes_Cifrado, Byte[] Matriz_Bytes_Descifrado)
        {
            /*using (Graphics Pintar = Graphics.FromImage(Picture.Image))
            {
                Pintar.CompositingMode = CompositingMode.SourceCopy;
                Pintar.Clear(Color.Transparent);
                for (int Índice = 0; Índice < 256; Índice++)
                {
                    //int Valor = Índice;
                    int Valor = Índice + 0;
                    //int Valor = (255 - Índice) + 0;
                    if (Valor < 0) Valor += 256;
                    else if (Valor > 255) Valor -= 256;
                    int Valor_Logarítmico = Program.Matriz_Logaritmo[Índice];
                    Pintar.FillRectangle(Brushes.Fuchsia, Índice, 255 - (Math.Max(Valor, Valor_Logarítmico) - Math.Min(Valor, Valor_Logarítmico)), 1, 1);
                    /*if (Valor != Valor_Logarítmico)
                    {
                        Pintar.FillRectangle(Brushes.Red, Índice, 255 - Valor, 1, 1);
                        Pintar.FillRectangle(Brushes.Blue, Índice, 255 - Valor_Logarítmico, 1, 1);
                    }
                    else Pintar.FillRectangle(Brushes.Fuchsia, Índice, 255 - Valor, 1, 1);*/
            /*
}
}
return;*/
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (Matriz_Bytes_Cifrado == null || Matriz_Bytes_Cifrado.Length < 256)
                {
                    Matriz_Bytes_Cifrado = new Byte[256];
                    for (int Índice = 0; Índice < Matriz_Bytes_Cifrado.Length; Índice++)
                    {
                        try { Matriz_Bytes_Cifrado[Índice] = (Byte)Índice; }
                        catch { continue; }
                    }
                }
                if (Matriz_Bytes_Descifrado == null || Matriz_Bytes_Descifrado.Length < 256)
                {
                    Matriz_Bytes_Descifrado = new Byte[256];
                    for (int Índice = 0; Índice < Matriz_Bytes_Descifrado.Length; Índice++)
                    {
                        try { Matriz_Bytes_Descifrado[Índice] = (Byte)Índice; }
                        catch { continue; }
                    }
                }

                Byte[] Matriz_Bytes = new Byte[256];
                if (Tecla_Alt_Presionada == false && Tecla_Control_Presionada == false && Tecla_Mayúsculas_Presionada == false)
                {
                    for (int Índice = 0; Índice < 256; Índice++) Matriz_Bytes[Índice] = Matriz_Bytes_Cifrado[Índice];
                    /*int Total = 0;
                    for (int Índice = 0; Índice < 256; Índice++)
                    {
                        Matriz_Bytes[Índice] = Matriz_Bytes_Cifrado[Índice];
                        if (Matriz_Bytes_Cifrado[Matrices.Matriz_Bytes_Voltear_X[Matrices.Matriz_Bytes_Girar_270[Índice]]] == Índice) Total++;
                    }
                    MessageBox.Show(this, Total.ToString());*/
                }
                else if (Tecla_Alt_Presionada)
                {
                    for (int Índice = 0; Índice < 256; Índice++) Matriz_Bytes[Índice] = Matriz_Bytes_Descifrado[Índice];
                }
                else if (Tecla_Control_Presionada)
                {
                    for (int Índice = 0; Índice < 256; Índice++) Matriz_Bytes[Índice] = Matriz_Bytes_Descifrado[Matriz_Bytes_Cifrado[Índice]];
                }
                else if (Tecla_Mayúsculas_Presionada)
                {
                    for (int Índice = 0; Índice < 256; Índice++) Matriz_Bytes[Índice] = (Byte)Índice;
                }
                Dictionary<Byte, int> Diccionario = new Dictionary<Byte, int>();
                for (int Índice = 0; Índice < 256; Índice++)
                {
                    if (Diccionario.ContainsKey(Matriz_Bytes[Índice]) == false) Diccionario.Add(Matriz_Bytes[Índice], 1);
                    else Diccionario[Matriz_Bytes[Índice]]++;
                }
                //int Bytes_Duplicados = 0;
                //foreach (KeyValuePair<Byte, int> Entrada in Diccionario) if (Entrada.Value > 1) Bytes_Duplicados += Entrada.Value;
                this.Text = Texto_Título + " - [Unique bytes: " + Diccionario.Count.ToString() + "]";
                Matriz_Bytes_Actual = Matriz_Bytes;
                //Matriz_Bytes_Actual = Matriz_Bytes.Clone() as Byte[];
                int Bytes_Verdes = 0, Bytes_Rojos = 0, Bytes_Amarillos = 0;

                using (Graphics Pintar = Graphics.FromImage(Picture.Image))
                {
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    Pintar.Clear(Color.Transparent);
                    for (int Índice = 0; Índice < Matriz_Etiquetas.Length; Índice++)
                    {
                        try
                        {
                            try
                            {
                                if (Matriz_Bytes[Índice] == Índice)
                                {
                                    Bytes_Verdes++;
                                    Matriz_Etiquetas[Índice].BackColor = Color.FromArgb(176, 255, 176);
                                }
                                else if (Diccionario[Matriz_Bytes[Índice]] < 2)
                                {
                                    Bytes_Rojos++;
                                    Matriz_Etiquetas[Índice].BackColor = Color.FromArgb(255, 176, 176);
                                }
                                else
                                {
                                    Bytes_Amarillos++;
                                    Matriz_Etiquetas[Índice].BackColor = Color.FromArgb(255, 255, 176);
                                }
                                //Matriz_Etiquetas[Índice].BackColor = Matriz_Bytes[Índice] == Índice ? Color.FromArgb(176, 255, 176) : Diccionario[Matriz_Bytes[Índice]] <= 1 ? Color.FromArgb(255, 176, 176) : Color.FromArgb(255, 255, 176);
                            }
                            catch { }
                            try { Matriz_Etiquetas[Índice].Text = Matriz_Bytes[Índice].ToString();/* + "\r\n" + Matriz_Bytes_Descifrado[Matriz_Bytes[Índice]].ToString();*/ }
                            catch { }
                            try { Pintar.FillRectangle(Brushes.Black, Índice, 255 - Matriz_Bytes[Índice], 1, 1); }
                            catch { }
                        }
                        catch { continue; }
                    }
                }
                //Etiqueta_Verde.Text = "Bytes Originales: " + Bytes_Verdes + ".";
                //Etiqueta_Rojo.Text = "Bytes Modificados: " + Bytes_Rojos + ".";
                //Etiqueta_Azul.Text = "Bytes Duplicados: " + Bytes_Amarillos + ".";
                Etiqueta_Verde.Text = "Green color information: original " + Program.Traducir_Número(Bytes_Verdes) + (Bytes_Verdes != 1 ? "bytes" : "byte");
                Etiqueta_Rojo.Text = "Red color information: modified " + Program.Traducir_Número(Bytes_Rojos) + (Bytes_Rojos != 1 ? "bytes" : "byte");
                Etiqueta_Azul.Text = "Yellow color information: duplicated " + Program.Traducir_Número(Bytes_Amarillos) + (Bytes_Amarillos != 1 ? "bytes" : "byte");
                Picture.Refresh();
                Etiqueta_Verde.Refresh();
                Etiqueta_Rojo.Refresh();
                Etiqueta_Azul.Refresh();
            }
            catch (Exception Excepción) { Application.OnThreadException(Excepción); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Combo_Filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Combo_Filtro.SelectedIndex > -1)
                {
                    Filtro = (Filtros)Combo_Filtro.SelectedIndex;
                    byte[] Matriz_Bytes_Original = new byte[256];
                    for (int Índice = 0; Índice < 256; Índice++)
                    {
                        Matriz_Bytes_Original[Índice] = (byte)Índice;
                    }
                    byte[] Matriz_Bytes_Filtro = Matriz_Bytes_Original.Clone() as byte[];
                    if (Filtro == Filtros.Original)
                    {
                        Establecer_Valores(Matriz_Bytes_Filtro.Clone() as byte[], Matriz_Bytes_Filtro.Clone() as byte[]);
                    }
                    else if (Filtro == Filtros.Negative)
                    {
                        for (int Índice = 0; Índice < 256; Índice++)
                        {
                            Matriz_Bytes_Filtro[Índice] = (byte)(255 - Índice);
                        }
                        Establecer_Valores(Matriz_Bytes_Filtro.Clone() as byte[], Matriz_Bytes_Filtro.Clone() as byte[]);
                    }
                    else if (Filtro == Filtros.Bit_inversion_in_base_2)
                    {
                        for (int Índice = 0; Índice < 256; Índice++)
                        {
                            Matriz_Bytes_Filtro[Índice] = Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_2[Matriz_Bytes_Filtro[Índice]];
                        }
                        Establecer_Valores(Matriz_Bytes_Filtro.Clone() as byte[], Matriz_Bytes_Filtro.Clone() as byte[]);
                    }
                    else if (Filtro == Filtros.Bit_inversion_in_base_4)
                    {
                        for (int Índice = 0; Índice < 256; Índice++)
                        {
                            Matriz_Bytes_Filtro[Índice] = Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_4[Matriz_Bytes_Filtro[Índice]];
                        }
                        Establecer_Valores(Matriz_Bytes_Filtro.Clone() as byte[], Matriz_Bytes_Filtro.Clone() as byte[]);
                    }
                    else if (Filtro == Filtros.Bit_inversion_in_base_16)
                    {
                        for (int Índice = 0; Índice < 256; Índice++)
                        {
                            Matriz_Bytes_Filtro[Índice] = Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_16[Matriz_Bytes_Filtro[Índice]];
                        }
                        Establecer_Valores(Matriz_Bytes_Filtro.Clone() as byte[], Matriz_Bytes_Filtro.Clone() as byte[]);
                    }
                    else if (Filtro == Filtros.Bit_inversion_in_bases_2_and_4)
                    {
                        for (int Índice = 0; Índice < 256; Índice++)
                        {
                            Matriz_Bytes_Filtro[Índice] = Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_4[Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_2[Matriz_Bytes_Filtro[Índice]]];
                        }
                        Establecer_Valores(Matriz_Bytes_Filtro.Clone() as byte[], Matriz_Bytes_Filtro.Clone() as byte[]);
                    }
                    else if (Filtro == Filtros.Bit_inversion_in_bases_2_and_16)
                    {
                        for (int Índice = 0; Índice < 256; Índice++)
                        {
                            Matriz_Bytes_Filtro[Índice] = Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_16[Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_2[Matriz_Bytes_Filtro[Índice]]];
                        }
                        Establecer_Valores(Matriz_Bytes_Filtro.Clone() as byte[], Matriz_Bytes_Filtro.Clone() as byte[]);
                    }
                    else if (Filtro == Filtros.Bit_inversion_in_bases_4_and_16)
                    {
                        for (int Índice = 0; Índice < 256; Índice++)
                        {
                            Matriz_Bytes_Filtro[Índice] = Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_16[Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_4[Matriz_Bytes_Filtro[Índice]]];
                        }
                        Establecer_Valores(Matriz_Bytes_Filtro.Clone() as byte[], Matriz_Bytes_Filtro.Clone() as byte[]);
                    }
                    else if (Filtro == Filtros.Bit_inversion_in_bases_2___4_and_16)
                    {
                        for (int Índice = 0; Índice < 256; Índice++)
                        {
                            Matriz_Bytes_Filtro[Índice] = Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_16[Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_4[Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_2[Matriz_Bytes_Filtro[Índice]]]];
                        }
                        Establecer_Valores(Matriz_Bytes_Filtro.Clone() as byte[], Matriz_Bytes_Filtro.Clone() as byte[]);
                    }
                    else // Unknown filter.
                    {
                        Establecer_Valores(Matriz_Bytes_Filtro.Clone() as byte[], Matriz_Bytes_Filtro.Clone() as byte[]);
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Right)
                {
                    this.Close();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

using Ionic.Zlib;
using Substrate_Jupisoft.Nbt;
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
    public partial class Ventana_Buscador_Chunks_Limos : Form
    {
        public Ventana_Buscador_Chunks_Limos()
        {
            InitializeComponent();
        }

        internal static bool Mostrar_Reglas = true;

        internal readonly string Texto_Título = "Slime Chunks Finder for " + Program.Texto_Usuario + " by Jupisoft";
        internal Stopwatch Cronómetro_Memoria = new Stopwatch(); // Turn the text red when over 4 GB
        internal bool Variable_Siempre_Visible = false;

        internal static int X = 0;
        internal static int Z = 0;
        internal static int Variable_Zoom = 16;

        internal bool Ocupado = false;

        internal int Separación_Regla = -1;

        private void Ventana_Buscador_Chunks_Limos_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Texto_Título;
                Ocupado = true;
                this.WindowState = FormWindowState.Maximized;
                Picture.KeyDown += Ventana_Buscador_Chunks_Limos_KeyDown;
                if (Separación_Regla < 0)
                {
                    Bitmap Imagen = Program.Obtener_Imagen_Texto(int.MinValue.ToString(), Etiqueta_Semilla.Font, Color.Black);
                    Rectangle Rectángulo = Program.Buscar_Zona_Recorte_Imagen(Imagen);
                    Imagen.Dispose();
                    Imagen = null;
                    if (Rectángulo.X > -1 && Rectángulo.Y > -1 && Rectángulo.X < int.MaxValue && Rectángulo.Y < int.MaxValue && Rectángulo.Width > 0 && Rectángulo.Height > 0)
                    {
                        Separación_Regla = Rectángulo.Width + 19; // Contar 6 de espacio antes y después del texto y 1 barra de 1 de ancho y 6 más de espacio
                        for (int Índice = 1; Índice < Separación_Regla * 2; Índice *= 2)
                        {
                            if (Índice >= Separación_Regla)
                            {
                                Separación_Regla = Índice;
                                break;
                            }
                        }

                        /*//Imagen.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\origgg.png", ImageFormat.Png);
                        Imagen = Imagen.Clone(Rectángulo, PixelFormat.Format32bppArgb);
                        //Imagen.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\origgg2.png", ImageFormat.Png);
                        //MessageBox.Show(Rectángulo.ToString());
                        if (Combo_Texto_Superior_Ángulo.SelectedIndex == 1) Imagen.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        if (Combo_Texto_Superior_Ángulo.SelectedIndex == 2) Imagen.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        if (Combo_Texto_Superior_Ángulo.SelectedIndex == 3) Imagen.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        if (CheckBox_Texto_Superior_Voltear_X.Checked) Imagen.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        if (CheckBox_Texto_Superior_Voltear_Y.Checked) Imagen.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        return Imagen;*/
                    }
                    else Separación_Regla = 256; // ¿Forzar si fallase?...

                    /*Bitmap Imagen_1_x_1 = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
                    Graphics Pintar_1_x_1 = Graphics.FromImage();

                    Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    Pintar.CompositingQuality = CompositingQuality.HighQuality;
                    Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Pintar.SmoothingMode = SmoothingMode.None;
                    //Pintar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho_Original, Alto_Original), GraphicsUnit.Pixel);
                    Pintar.Dispose();
                    Pintar = null;*/
                }
                Numérico_Semilla.Minimum = long.MinValue;
                Numérico_Semilla.Maximum = long.MaxValue;

                Numérico_X_Bloque.Minimum = int.MinValue;
                Numérico_X_Bloque.Maximum = int.MaxValue;
                Numérico_Z_Bloque.Minimum = int.MinValue;
                Numérico_Z_Bloque.Maximum = int.MaxValue;

                Numérico_X_Chunk.Minimum = (int.MinValue / 16) - 1;
                Numérico_X_Chunk.Maximum = int.MaxValue / 16;
                Numérico_Z_Chunk.Minimum = (int.MinValue / 16) - 1;
                Numérico_Z_Chunk.Maximum = int.MaxValue / 16;

                Numérico_X_Región.Minimum = (int.MinValue / 512) - 1;
                Numérico_X_Región.Maximum = int.MaxValue / 512;
                Numérico_Z_Región.Minimum = (int.MinValue / 512) - 1;
                Numérico_Z_Región.Maximum = int.MaxValue / 512;

                Numérico_X_Bloque.Value = X;
                Numérico_Z_Bloque.Value = Z;
                ComboBox_Zoom.Text = Variable_Zoom.ToString() + "x";
                TextBox_Semilla.Text = Program.Texto_Usuario;
                TextBox_Semilla.Select();
                TextBox_Semilla.Focus();
                TextBox_Semilla.SelectAll();
                Ocupado = false;
                Buscar_Chunks_Limos();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Picture_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Ventana_Buscador_Chunks_Limos_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Buscador_Chunks_Limos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Buscador_Chunks_Limos_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Buscador_Chunks_Limos_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, true) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Buscador_Chunks_Limos_DragDrop(object sender, DragEventArgs e)
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
                                    Minecraft.Información_Niveles Información_Nivel = Minecraft.Información_Niveles.Obtener_Información_Nivel(Ruta);
                                    Numérico_Semilla.Value = Información_Nivel.RandomSeed;
                                    return;
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

        private void Ventana_Buscador_Chunks_Limos_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                Buscar_Chunks_Limos();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Buscador_Chunks_Limos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.A || e.KeyCode == Keys.D || e.KeyCode == Keys.W || e.KeyCode == Keys.S)
                {
                    if (!TextBox_Semilla.Focused)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        int Desplazamiento_Zoom = 1;
                        int Desplazamiento_X = e.KeyCode == Keys.A ? -Desplazamiento_Zoom : e.KeyCode == Keys.D ? Desplazamiento_Zoom : 0;
                        int Desplazamiento_Z = e.KeyCode == Keys.W ? -Desplazamiento_Zoom : e.KeyCode == Keys.S ? Desplazamiento_Zoom : 0;
                        if (e.Alt)
                        {
                            Desplazamiento_X *= 4;
                            Desplazamiento_Z *= 4;
                        }
                        if (e.Control)
                        {
                            Desplazamiento_X *= 8;
                            Desplazamiento_Z *= 8;
                        }
                        if (e.Shift)
                        {
                            Desplazamiento_X *= 16;
                            Desplazamiento_Z *= 16;
                        }
                        /*decimal Valor_X = */
                        Numérico_X_Chunk.Value += Desplazamiento_X;
                        /*decimal Valor_Z = */
                        Numérico_Z_Chunk.Value += Desplazamiento_Z;
                    }
                }
                else if (!e.Alt && !e.Control && !e.Shift)
                {
                    if (e.KeyCode == Keys.Escape) this.Close();
                    else if (e.KeyCode == Keys.Enter)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Temporizador_Principal_Tick(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Program.Proceso.Refresh();
                    long Memoria_Bytes = Program.Proceso.PagedMemorySize64;
                    Barra_Estado_Etiqueta_Memoria.Text = "RAM: " + Program.Traducir_Tamaño_Bytes_Automático(Memoria_Bytes, 2, true);
                    if (Memoria_Bytes >= 4294967296L && !Cronómetro_Memoria.IsRunning) Cronómetro_Memoria.Restart();
                    else if (Memoria_Bytes < 4294967296L && Cronómetro_Memoria.IsRunning)
                    {
                        Cronómetro_Memoria.Reset();
                        Barra_Estado_Etiqueta_Memoria.ForeColor = Color.Black;
                    }
                    if (Cronómetro_Memoria.IsRunning)
                    {
                        Barra_Estado_Etiqueta_Memoria.ForeColor = (Cronómetro_Memoria.ElapsedMilliseconds / 500L) % 2 == 0 ? Color.Black : Color.Red;
                    }
                }
                catch { Barra_Estado_Etiqueta_Memoria.Text = "RAM: ? MB (? GB)"; }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_Semilla_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Numérico_Semilla.Refresh();
                if (!Ocupado)
                {
                    Buscar_Chunks_Limos();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void TextBox_Semilla_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextBox_Semilla.Text))
                {
                    try { Numérico_Semilla.Value = Ventana_Calculadora_Infinita_Semillas_Mundos.Calcular_Semilla(TextBox_Semilla.Text); }
                    catch { Numérico_Semilla.Value = 0m; }
                }
                else Numérico_Semilla.Value = 0m;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_X_Bloque_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Numérico_X_Bloque.Refresh();
                if (!Ocupado)
                {
                    Ocupado = true;
                    X = (int)Numérico_X_Bloque.Value;
                    int Valor_X_Chunk = X / 16;
                    int Valor_X_Región = X / 512;
                    if (X < 0)
                    {
                        Valor_X_Chunk--;
                        Valor_X_Región--;
                    }
                    if (Numérico_X_Chunk.Value != Valor_X_Chunk) Numérico_X_Chunk.Value = Valor_X_Chunk;
                    if (Numérico_X_Región.Value != Valor_X_Región) Numérico_X_Región.Value = Valor_X_Región;
                    Ocupado = false;
                    Buscar_Chunks_Limos();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_Z_Bloque_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Numérico_Z_Bloque.Refresh();
                if (!Ocupado)
                {
                    Ocupado = true;
                    Z = (int)Numérico_Z_Bloque.Value;
                    int Valor_Z_Chunk = Z / 16;
                    int Valor_Z_Región = Z / 512;
                    if (Z < 0)
                    {
                        Valor_Z_Chunk--;
                        Valor_Z_Región--;
                    }
                    if (Numérico_Z_Chunk.Value != Valor_Z_Chunk) Numérico_Z_Chunk.Value = Valor_Z_Chunk;
                    if (Numérico_Z_Región.Value != Valor_Z_Región) Numérico_Z_Región.Value = Valor_Z_Región;
                    Ocupado = false;
                    Buscar_Chunks_Limos();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_X_Chunk_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Numérico_X_Chunk.Refresh();
                if (!Ocupado)
                {
                    Ocupado = true;
                    decimal Valor_X_Bloque = Math.Truncate(Numérico_X_Chunk.Value * 16m);
                    //if (Numérico_X_Chunk.Value < 0m) Valor_X_Bloque--;
                    if (Valor_X_Bloque < Numérico_X_Bloque.Minimum) Valor_X_Bloque = Numérico_X_Bloque.Minimum;
                    else if (Valor_X_Bloque > Numérico_X_Bloque.Maximum) Valor_X_Bloque = Numérico_X_Bloque.Maximum;
                    X = (int)Valor_X_Bloque;
                    int Valor_X_Región = X / 512;
                    if (X < 0) Valor_X_Región--;
                    if (Numérico_X_Bloque.Value != Valor_X_Bloque) Numérico_X_Bloque.Value = Valor_X_Bloque;
                    if (Numérico_X_Región.Value != Valor_X_Región) Numérico_X_Región.Value = Valor_X_Región;
                    Ocupado = false;
                    Buscar_Chunks_Limos();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_Z_Chunk_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Numérico_Z_Chunk.Refresh();
                if (!Ocupado)
                {
                    Ocupado = true;
                    decimal Valor_Z_Bloque = Math.Truncate(Numérico_Z_Chunk.Value * 16m);
                    if (Valor_Z_Bloque < Numérico_Z_Bloque.Minimum) Valor_Z_Bloque = Numérico_Z_Bloque.Minimum;
                    else if (Valor_Z_Bloque > Numérico_Z_Bloque.Maximum) Valor_Z_Bloque = Numérico_Z_Bloque.Maximum;
                    Z = (int)Valor_Z_Bloque;
                    int Valor_Z_Región = Z / 512;
                    if (Z < 0) Valor_Z_Región--;
                    if (Numérico_Z_Bloque.Value != Valor_Z_Bloque) Numérico_Z_Bloque.Value = Valor_Z_Bloque;
                    if (Numérico_Z_Región.Value != Valor_Z_Región) Numérico_Z_Región.Value = Valor_Z_Región;
                    Ocupado = false;
                    Buscar_Chunks_Limos();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_X_Región_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Numérico_X_Región.Refresh();
                if (!Ocupado)
                {
                    Ocupado = true;
                    decimal Valor_X_Bloque = Math.Truncate(Numérico_X_Región.Value * 512m);
                    if (Valor_X_Bloque < Numérico_X_Bloque.Minimum) Valor_X_Bloque = Numérico_X_Bloque.Minimum;
                    else if (Valor_X_Bloque > Numérico_X_Bloque.Maximum) Valor_X_Bloque = Numérico_X_Bloque.Maximum;
                    X = (int)Valor_X_Bloque;
                    int Valor_X_Chunk = X / 16;
                    //if (Numérico_X_Región.Value < 0m) Valor_X_Chunk--;
                    if (Numérico_X_Bloque.Value != Valor_X_Bloque) Numérico_X_Bloque.Value = Valor_X_Bloque;
                    if (Numérico_X_Chunk.Value != Valor_X_Chunk) Numérico_X_Chunk.Value = Valor_X_Chunk;
                    Ocupado = false;
                    Buscar_Chunks_Limos();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_Z_Región_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Numérico_Z_Región.Refresh();
                if (!Ocupado)
                {
                    Ocupado = true;
                    decimal Valor_Z_Bloque = Math.Truncate(Numérico_Z_Región.Value * 512m);
                    if (Valor_Z_Bloque < Numérico_Z_Bloque.Minimum) Valor_Z_Bloque = Numérico_Z_Bloque.Minimum;
                    else if (Valor_Z_Bloque > Numérico_Z_Bloque.Maximum) Valor_Z_Bloque = Numérico_Z_Bloque.Maximum;
                    Z = (int)Valor_Z_Bloque;
                    int Valor_Z_Chunk = Z / 16;
                    if (Numérico_Z_Bloque.Value != Valor_Z_Bloque) Numérico_Z_Bloque.Value = Valor_Z_Bloque;
                    if (Numérico_Z_Chunk.Value != Valor_Z_Chunk) Numérico_Z_Chunk.Value = Valor_Z_Chunk;
                    Ocupado = false;
                    Buscar_Chunks_Limos();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void ComboBox_Zoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboBox_Zoom.SelectedIndex > -1)
                {
                    Variable_Zoom = int.Parse(ComboBox_Zoom.Text.Replace("x", null));
                    /*Registro_Guardar_Opciones();
                    if (Variable_Cuadrícula_Chunks)
                    {
                        Picture.Image = Obtener_Imagen_Cuadrícula_Chunks(Ancho_Cliente, Alto_Cliente);
                        Picture.Invalidate();
                        Picture.Update();
                    }*/
                    Buscar_Chunks_Limos();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        internal void Buscar_Chunks_Limos()
        {
            try
            {
                if (!Ocupado)
                {
                    this.Cursor = Cursors.WaitCursor;
                    int Ancho = Picture.ClientSize.Width;
                    int Alto = Picture.ClientSize.Height;
                    if ((Mostrar_Reglas && Ancho > 40 && Alto > 40) || (!Mostrar_Reglas && Ancho > 0 && Alto > 0))
                    {
                        Rectangle Rectángulo_Área_Cliente_Sin_Reglas = Mostrar_Reglas ? new Rectangle(20, 20, Ancho - 40, Alto - 40) : new Rectangle(0, 0, Ancho, Alto);
                        int Dimensiones_X = int.MinValue;
                        int Dimensiones_Z = int.MinValue;
                        int Dimensiones_Ancho = 0;
                        int Dimensiones_Alto = 0;
                        int Chunks_Visibles = 0;
                        int Chunks_Limos = 0;

                        int Ancho_Mitad = Ancho / 2;
                        int Alto_Mitad = Alto / 2;

                        int X = Ancho_Mitad / Variable_Zoom;
                        if (X * Variable_Zoom < Ancho_Mitad) X++;
                        int XX = X * Variable_Zoom;
                        int XXX = Ancho_Mitad - XX;

                        int Z = Alto_Mitad / Variable_Zoom;
                        if (Z * Variable_Zoom < Alto_Mitad) Z++;
                        int ZZ = Z * Variable_Zoom;
                        int ZZZ = Alto_Mitad - ZZ;

                        int XXXX = (int)Numérico_X_Chunk.Value - X;
                        int ZZZZ = (int)Numérico_Z_Chunk.Value - Z;

                        // ...

                        //int Separación_Regla = 32; // Región / 16 // O cada 256 bloques
                        //Separación_Regla = 0;

                        // ...

                        Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                        Graphics Pintar = Graphics.FromImage(Imagen);
                        Pintar.CompositingMode = CompositingMode.SourceCopy;
                        Pintar.CompositingQuality = CompositingQuality.HighQuality;
                        Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Pintar.SmoothingMode = SmoothingMode.None;
                        Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;



                        SolidBrush Pincel_Rojo = new SolidBrush(Color.FromArgb(255, 255, 224, 224));
                        for (int Índice_Z = 0, Chunk_Z = ZZZZ, Pintar_Z = ZZZ; Índice_Z < Alto; Índice_Z++, Chunk_Z++, Pintar_Z += Variable_Zoom)
                        {
                            for (int Índice_X = 0, Chunk_X = XXXX, Pintar_X = XXX; Índice_X < Ancho; Índice_X++, Chunk_X++, Pintar_X += Variable_Zoom)
                            {
                                bool Chunk_Limos = new Program.Random_Java((ulong)((long)Numérico_Semilla.Value + (long)(Chunk_X * Chunk_X * 4987142) + (long)(Chunk_X * 5947611) + (long)(Chunk_Z * Chunk_Z) * 4392871L + (long)(Chunk_Z * 389711) ^ 987234911L)).NextInt(10) == 0;
                                //MessageBox.Show((Chunk_Central_X + Chunk_X).ToString() + ", " + (Chunk_Central_Z + Chunk_Z).ToString());
                                Pintar.FillRectangle(Chunk_Limos ? Brushes.Lime : Pincel_Rojo, Pintar_X, Pintar_Z, Variable_Zoom, Variable_Zoom);
                                Rectangle Rectángulo = new Rectangle(Pintar_X, Pintar_Z, Variable_Zoom, Variable_Zoom);
                                if (Rectángulo.IntersectsWith(Rectángulo_Área_Cliente_Sin_Reglas))
                                {
                                    if (Dimensiones_X <= int.MinValue) Dimensiones_X = Índice_X;
                                    if (Dimensiones_Z <= int.MinValue) Dimensiones_Z = Índice_Z;
                                    if (Índice_Z == Dimensiones_Z) Dimensiones_Ancho++;
                                    if (Índice_X == Dimensiones_X) Dimensiones_Alto++;
                                    Chunks_Visibles++;
                                    if (Chunk_Limos) Chunks_Limos++;
                                }
                            }
                        }

                        //Bitmap Imagen_Regla_X = new Bitmap(Ancho, 20, PixelFormat.Format32bppArgb);
                        //Graphics Pintar_Regla_X = Graphics.FromImage(Imagen_Regla_X);
                        //Pintar_Regla_X.CompositingMode = CompositingMode.SourceOver;
                        /*Pintar_Regla_X.CompositingQuality = CompositingQuality.HighQuality;
                        Pintar_Regla_X.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Pintar_Regla_X.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Pintar_Regla_X.SmoothingMode = SmoothingMode.None;
                        Pintar_Regla_X.TextRenderingHint = TextRenderingHint.AntiAlias;*/
                        //Pintar_Regla_X.Clear(Color.White);

                        //int Regla_X = XXXX + (Separación_Regla - (XXXX % Separación_Regla));
                        //int Regla_X = XXXX - (XXXX % Separación_Regla);

                        //int Chunks_X = Separación_Regla / Variable_Zoom;
                        //MessageBox.Show(Chunks_X.ToString(), Separación_Regla.ToString());

                        if (Mostrar_Reglas)
                        {
                            Pintar.FillRectangle(Brushes.White, 0, 0, Ancho, 20);
                            Pintar.FillRectangle(Brushes.White, 0, Alto - 20, Ancho, 20);

                            Pintar.FillRectangle(Brushes.White, 0, 0, 20, Alto);
                            Pintar.FillRectangle(Brushes.White, Ancho - 20, 0, 20, Alto);

                            Pintar.CompositingMode = CompositingMode.SourceOver;
                            Pintar.FillRectangle(Program.Pincel_Trama, 0, 0, Ancho, 1);
                            Pintar.FillRectangle(Program.Pincel_Trama, 0, 19, Ancho, 1);
                            Pintar.FillRectangle(Program.Pincel_Trama, 0, Alto - 20, Ancho, 1);
                            Pintar.FillRectangle(Program.Pincel_Trama, 0, Alto - 1, Ancho, 1);

                            Pintar.FillRectangle(Program.Pincel_Trama, 0, 0, 1, Alto);
                            Pintar.FillRectangle(Program.Pincel_Trama, 19, 0, 1, Alto);
                            Pintar.FillRectangle(Program.Pincel_Trama, Ancho - 20, 0, 1, Alto);
                            Pintar.FillRectangle(Program.Pincel_Trama, Ancho - 1, 0, 1, Alto);

                            int Regla_X = Ancho_Mitad;
                            double Regla_XX = (double)Numérico_X_Chunk.Value * 16d;
                            int Regla_XXX = 0;
                            while (Regla_X > 0)
                            {
                                Regla_X -= Separación_Regla;
                                Regla_XXX -= (Separación_Regla * 16) / Variable_Zoom;
                            }
                            int Regla_Z = Alto_Mitad;
                            double Regla_ZZ = (double)Numérico_Z_Chunk.Value * 16d;
                            int Regla_ZZZ = 0;
                            while (Regla_Z > 0)
                            {
                                Regla_Z -= Separación_Regla;
                                Regla_ZZZ -= (Separación_Regla * 16) / Variable_Zoom;
                            }
                            for (int Índice_X = Regla_X, Chunk_X = Regla_XXX; Índice_X < Ancho; Índice_X += Separación_Regla, Chunk_X += (Separación_Regla * 16) / Variable_Zoom)
                            {
                                Pintar.FillRectangle(Program.Pincel_Trama, Índice_X, 0, 1, Alto);
                                Bitmap Imagen_Número = Program.Obtener_Imagen_Texto(Program.Traducir_Número(Chunk_X), Etiqueta_Semilla.Font, Color.Black);
                                Rectangle Rectángulo = Program.Buscar_Zona_Recorte_Imagen(Imagen_Número);
                                if (Rectángulo.X > -1 && Rectángulo.Y > -1 && Rectángulo.X < int.MaxValue && Rectángulo.Y < int.MaxValue && Rectángulo.Width > 0 && Rectángulo.Height > 0)
                                {
                                    Imagen_Número = Imagen_Número.Clone(Rectángulo, PixelFormat.Format32bppArgb);
                                    Pintar.DrawImage(Imagen_Número, new Rectangle(Índice_X + 3, (20 - Rectángulo.Height) / 2, Rectángulo.Width, Rectángulo.Height), new Rectangle(0, 0, Rectángulo.Width, Rectángulo.Height), GraphicsUnit.Pixel);
                                    Imagen_Número.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                    Pintar.DrawImage(Imagen_Número, new Rectangle(Índice_X + 3, (Alto - 20) + (Rectángulo.Height / 2), Rectángulo.Width, Rectángulo.Height), new Rectangle(0, 0, Rectángulo.Width, Rectángulo.Height), GraphicsUnit.Pixel);
                                }
                                Imagen_Número.Dispose();
                                Imagen_Número = null;
                            }
                            for (int Índice_Z = Regla_Z, Chunk_Z = Regla_ZZZ; Índice_Z < Alto; Índice_Z += Separación_Regla, Chunk_Z += (Separación_Regla * 16) / Variable_Zoom)
                            {
                                Pintar.FillRectangle(Program.Pincel_Trama, 0, Índice_Z, Ancho, 1);
                                Bitmap Imagen_Número = Program.Obtener_Imagen_Texto(Program.Traducir_Número(Chunk_Z), Etiqueta_Semilla.Font, Color.Black);
                                Rectangle Rectángulo = Program.Buscar_Zona_Recorte_Imagen(Imagen_Número);
                                if (Rectángulo.X > -1 && Rectángulo.Y > -1 && Rectángulo.X < int.MaxValue && Rectángulo.Y < int.MaxValue && Rectángulo.Width > 0 && Rectángulo.Height > 0)
                                {
                                    Imagen_Número = Imagen_Número.Clone(Rectángulo, PixelFormat.Format32bppArgb);
                                    Imagen_Número.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                    Rectángulo = new Rectangle(Rectángulo.Y, Rectángulo.X, Rectángulo.Height, Rectángulo.Width);
                                    Pintar.DrawImage(Imagen_Número, new Rectangle((20 - Rectángulo.Width) / 2, Índice_Z + 3, Rectángulo.Width, Rectángulo.Height), new Rectangle(0, 0, Rectángulo.Width, Rectángulo.Height), GraphicsUnit.Pixel);
                                    Imagen_Número.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                    Pintar.DrawImage(Imagen_Número, new Rectangle((Ancho - 20) + (Rectángulo.Width / 2), Índice_Z + 3, Rectángulo.Width, Rectángulo.Height), new Rectangle(0, 0, Rectángulo.Width, Rectángulo.Height), GraphicsUnit.Pixel);
                                }
                                Imagen_Número.Dispose();
                                Imagen_Número = null;
                            }
                            Pintar.CompositingMode = CompositingMode.SourceCopy;
                            Pintar.FillRectangle(Brushes.White, 1, 1, 18, 18);
                            Pintar.FillRectangle(Brushes.White, Ancho - 19, 1, 18, 18);
                            Pintar.FillRectangle(Brushes.White, 1, Alto - 19, 18, 18);
                            Pintar.FillRectangle(Brushes.White, Ancho - 19, Alto - 19, 18, 18);
                        }

                        //Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho_Original, Alto_Original), GraphicsUnit.Pixel);
                        Pintar.Dispose();
                        Pintar = null;

                        Barra_Estado_Etiqueta_Dimensiones.Text = "Dimensions: " + Program.Traducir_Número(Dimensiones_Ancho) + " x " + Program.Traducir_Número(Dimensiones_Alto) + " chunks";
                        Barra_Estado_Etiqueta_Chunks_Visibles.Text = "Visible chunks: " + Program.Traducir_Número(Chunks_Visibles);
                        Barra_Estado_Etiqueta_Chunks_Limos.Text = "Slime chunks: " + Program.Traducir_Número(Chunks_Limos);

                        Picture.BackgroundImage = Imagen;
                        Picture.Refresh();

                        /*Rectangle Rectángulo = Program.Buscar_Zona_Recorte_Imagen(Imagen);
                        if (Rectángulo.X > -1 && Rectángulo.Y > -1 && Rectángulo.X < int.MaxValue && Rectángulo.Y < int.MaxValue && Rectángulo.Width > 0 && Rectángulo.Height > 0)
                        {
                            //Imagen.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\origgg.png", ImageFormat.Png);
                            Imagen = Imagen.Clone(Rectángulo, PixelFormat.Format32bppArgb);
                            //Imagen.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\origgg2.png", ImageFormat.Png);
                            //MessageBox.Show(Rectángulo.ToString());
                            if (Combo_Texto_Superior_Ángulo.SelectedIndex == 1) Imagen.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            if (Combo_Texto_Superior_Ángulo.SelectedIndex == 2) Imagen.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            if (Combo_Texto_Superior_Ángulo.SelectedIndex == 3) Imagen.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            if (CheckBox_Texto_Superior_Voltear_X.Checked) Imagen.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            if (CheckBox_Texto_Superior_Voltear_Y.Checked) Imagen.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            return Imagen;
                        }*/
                    }
                    else Picture.BackgroundImage = null;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Menú_Contextual_Copiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Picture.BackgroundImage != null)
                {
                    Clipboard.SetImage(Picture.BackgroundImage);
                    SystemSounds.Asterisk.Play();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Picture.BackgroundImage != null)
                {
                    Program.Crear_Carpetas(Program.Ruta_Guardado_Imágenes_Buscador_Chunks_Limos);
                    if (Directory.Exists(Program.Ruta_Guardado_Imágenes_Buscador_Chunks_Limos))
                    {
                        string Ruta = Program.Ruta_Guardado_Imágenes_Buscador_Chunks_Limos + "\\" + Program.Obtener_Nombre_Temporal_Sin_Guiones() + " Slime chunks (Seed " + Numérico_Semilla.Value.ToString() + ") [Chunk XZ " + Program.Traducir_Número(Numérico_X_Chunk.Value) + ", " + Program.Traducir_Número(Numérico_Z_Chunk.Value) + "].png";
                        try
                        {
                            Picture.BackgroundImage.Save(Ruta, ImageFormat.Png);
                            try { Program.Ejecutar_Ruta(Ruta, ProcessWindowStyle.Normal); }
                            catch { }
                            SystemSounds.Asterisk.Play();
                        }
                        catch { MessageBox.Show(this, "The program couldn't save the map to:\r\n" + Ruta + ".\r\nPlease try it again later and make sure you have the right privileges.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        Ruta = null;
                    }
                    else MessageBox.Show(this, "The program couldn't create the save folder for the map at:\r\n" + Program.Ruta_Guardado_Imágenes_Buscador_Chunks_Limos + ".\r\nPlease try it again later and make sure you have the right privileges.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Picture.Select();
                    Picture.Focus();
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    int Ancho = Picture.ClientSize.Width;
                    int Alto = Picture.ClientSize.Height;
                    int Ancho_Mitad = Ancho / 2;
                    int Alto_Mitad = Alto / 2;
                    int X = Ancho_Mitad / Variable_Zoom;
                    if (X * Variable_Zoom < Ancho_Mitad) X++;
                    int XX = X * Variable_Zoom;
                    int XXX = Ancho_Mitad - XX;
                    int Z = Alto_Mitad / Variable_Zoom;
                    if (Z * Variable_Zoom < Alto_Mitad) Z++;
                    int ZZ = Z * Variable_Zoom;
                    int ZZZ = Alto_Mitad - ZZ;
                    int XXXX = (int)Numérico_X_Chunk.Value - X;
                    int ZZZZ = (int)Numérico_Z_Chunk.Value - Z;
                    XXXX = (XXXX * 16) + (((e.X + Math.Abs(XXX)) * 16) / Variable_Zoom);
                    ZZZZ = (ZZZZ * 16) + (((e.Y + Math.Abs(ZZZ)) * 16) / Variable_Zoom);
                    Clipboard.SetText("/tp @p " + XXXX.ToString() + " 100 " + ZZZZ.ToString());
                    SystemSounds.Asterisk.Play();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_Semilla_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    byte[] Matriz_Bytes = new byte[8];
                    Program.Rand.NextBytes(Matriz_Bytes); // Workaround to get random 64 bits seeds.
                    Numérico_Semilla.Value = (decimal)BitConverter.ToInt64(Matriz_Bytes, 0);
                    Matriz_Bytes = null;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void TextBox_Semilla_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    string Texto = TextBox_Semilla.Text;
                    if (!string.IsNullOrEmpty(Texto))
                    {
                        bool Todos_Caracteres_Minúsculas = true;
                        bool Todos_Caracteres_Mayúsculas = true;
                        for (int Índice_Caracter = 0; Índice_Caracter < Texto.Length; Índice_Caracter++)
                        {
                            if (char.IsLetter(Texto[Índice_Caracter]) && (!char.IsLower(Texto[Índice_Caracter]) || !char.IsUpper(Texto[Índice_Caracter])))
                            {
                                if (char.IsLower(Texto[Índice_Caracter])) Todos_Caracteres_Mayúsculas = false;
                                else Todos_Caracteres_Minúsculas = false;
                            }
                        }
                        if (Todos_Caracteres_Minúsculas) // "xisumavoid" to "Xisumavoid"
                        {
                            Texto = Texto.Substring(0, 1).ToUpperInvariant() + (Texto.Length > 1 ? Texto.Substring(1).ToLowerInvariant() : null);
                        }
                        else if (Todos_Caracteres_Mayúsculas) // "XISUMAVOID" to "xisumavoid"
                        {
                            Texto = Texto.ToLowerInvariant();
                        }
                        else // "?" to "XISUMAVOID"
                        {
                            Texto = Texto.ToUpperInvariant();
                        }
                        TextBox_Semilla.Text = Texto;
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void ComboBox_Zoom_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    ComboBox_Zoom.Text = "16x";
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_X_Bloque_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Numérico_X_Bloque.Value = 0m;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_Z_Bloque_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Numérico_Z_Bloque.Value = 0m;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_X_Chunk_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Numérico_X_Chunk.Value = 0m;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_Z_Chunk_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Numérico_Z_Chunk.Value = 0m;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_X_Región_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Numérico_X_Región.Value = 0m;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Numérico_Z_Región_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Numérico_Z_Región.Value = 0m;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                int Ancho = Picture.ClientSize.Width;
                int Alto = Picture.ClientSize.Height;
                if (e.X >= 0 && e.Y >= 0 && e.X < Ancho && e.Y < Alto)
                {
                    int Ancho_Mitad = Ancho / 2;
                    int Alto_Mitad = Alto / 2;
                    int X = Ancho_Mitad / Variable_Zoom;
                    if (X * Variable_Zoom < Ancho_Mitad) X++;
                    int XX = X * Variable_Zoom;
                    int XXX = Ancho_Mitad - XX;
                    int Z = Alto_Mitad / Variable_Zoom;
                    if (Z * Variable_Zoom < Alto_Mitad) Z++;
                    int ZZ = Z * Variable_Zoom;
                    int ZZZ = Alto_Mitad - ZZ;
                    int XXXX = (int)Numérico_X_Chunk.Value - X;
                    int ZZZZ = (int)Numérico_Z_Chunk.Value - Z;
                    XXXX = (XXXX * 16) + (((e.X + Math.Abs(XXX)) * 16) / Variable_Zoom);
                    ZZZZ = (ZZZZ * 16) + (((e.Y + Math.Abs(ZZZ)) * 16) / Variable_Zoom);
                    this.Text = Texto_Título + "- [Looking at Block XZ: " + Program.Traducir_Número(XXXX) + ", " + Program.Traducir_Número(ZZZZ) + "]";
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Mostrar_Reglas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Mostrar_Reglas = Menú_Contextual_Mostrar_Reglas.Checked;
                Buscar_Chunks_Limos();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Visor_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana_Visor_Ayuda Ventana = new Ventana_Visor_Ayuda();
                Ventana.Ayuda = Ventana_Visor_Ayuda.Ayudas.Slime_chunks_finder;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
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
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
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
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Abrir_Carpeta_Mapas_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Crear_Carpetas(Program.Ruta_Guardado_Imágenes_Buscador_Chunks_Limos);
                Process Proceso = new Process();
                Proceso.StartInfo.Arguments = null;
                Proceso.StartInfo.ErrorDialog = false;
                Proceso.StartInfo.FileName = Program.Ruta_Guardado_Imágenes_Buscador_Chunks_Limos;
                Proceso.StartInfo.UseShellExecute = true;
                Proceso.StartInfo.Verb = "open";
                Proceso.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                try { Proceso.Start(); }
                catch { SystemSounds.Beep.Play(); }
                Proceso.Close();
                Proceso.Dispose();
                Proceso = null;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar_Chunks_Limos();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }
    }
}

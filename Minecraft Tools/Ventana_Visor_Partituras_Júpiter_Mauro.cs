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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Visor_Partituras_Júpiter_Mauro : Form
    {
        public Ventana_Visor_Partituras_Júpiter_Mauro()
        {
            InitializeComponent();
        }

        internal static readonly double[] Matriz_Ángulos_7_Notas = new double[12]
        {
            (360d / 14d), // Do
            ((360d * 1d) / 7d), // Do#
            ((360d * 2d) / 7d) - (360d / 14d), // Re
            ((360d * 2d) / 7d), // Re#
            ((360d * 3d) / 7d) - (360d / 14d), // Mi
            ((360d * 4d) / 7d) - (360d / 14d), // Fa
            ((360d * 4d) / 7d), // Fa#
            ((360d * 5d) / 7d) - (360d / 14d), // Sol
            ((360d * 5d) / 7d), // Sol#
            ((360d * 6d) / 7d) - (360d / 14d), // La
            ((360d * 6d) / 7d), // La#
            ((360d * 7d) / 7d) - (360d / 14d), // Si
        };
        internal static readonly double[] Matriz_Ángulos_12_Notas = new double[12]
        {
            ((360d * 1d) / 12d) - (360d / 24d), // Do
            ((360d * 2d) / 12d) - (360d / 24d), // Do#
            ((360d * 3d) / 12d) - (360d / 24d), // Re
            ((360d * 4d) / 12d) - (360d / 24d), // Re#
            ((360d * 5d) / 12d) - (360d / 24d), // Mi
            ((360d * 6d) / 12d) - (360d / 24d), // Fa
            ((360d * 7d) / 12d) - (360d / 24d), // Fa#
            ((360d * 8d) / 12d) - (360d / 24d), // Sol
            ((360d * 9d) / 12d) - (360d / 24d), // Sol#
            ((360d * 10d) / 12d) - (360d / 24d), // La
            ((360d * 11d) / 12d) - (360d / 24d), // La#
            ((360d * 12d) / 12d) - (360d / 24d), // Si
        };

        internal static readonly string[] Matriz_Notas = new string[12] { "Do", "Do#", "Re", "Re#", "Mi", "Fa", "Fa#", "Sol", "Sol#", "La", "La#", "Si" };
        internal static readonly string[] Matriz_Notas_CDEFGAB = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        internal static readonly Color[] Matriz_Colores_12_Notas = new Color[12] { Color.FromArgb(255, 0, 0), Color.FromArgb(255, 144, 0), Color.FromArgb(255, 176, 0), Color.FromArgb(255, 216, 0), Color.FromArgb(255, 255, 0), Color.FromArgb(0, 255, 0), Color.FromArgb(0, 255, 192), Color.FromArgb(0, 96, 255), Color.FromArgb(80, 0, 255), Color.FromArgb(128, 0, 255), Color.FromArgb(160, 0, 255), Color.FromArgb(255, 0, 176) };
        internal static readonly Pen[] Matriz_Lápices_12_Notas = new Pen[12] { new Pen(Color.FromArgb(255, 0, 0)), new Pen(Color.FromArgb(255, 144, 0)), new Pen(Color.FromArgb(255, 176, 0)), new Pen(Color.FromArgb(255, 216, 0)), new Pen(Color.FromArgb(255, 255, 0)), new Pen(Color.FromArgb(0, 255, 0)), new Pen(Color.FromArgb(0, 255, 192)), new Pen(Color.FromArgb(0, 96, 255)), new Pen(Color.FromArgb(80, 0, 255)), new Pen(Color.FromArgb(128, 0, 255)), new Pen(Color.FromArgb(160, 0, 255)), new Pen(Color.FromArgb(255, 0, 176)) };
        internal static readonly SolidBrush[] Matriz_Pinceles_12_Notas = new SolidBrush[12] { new SolidBrush(Color.FromArgb(255, 0, 0)), new SolidBrush(Color.FromArgb(255, 144, 0)), new SolidBrush(Color.FromArgb(255, 176, 0)), new SolidBrush(Color.FromArgb(255, 216, 0)), new SolidBrush(Color.FromArgb(255, 255, 0)), new SolidBrush(Color.FromArgb(0, 255, 0)), new SolidBrush(Color.FromArgb(0, 255, 192)), new SolidBrush(Color.FromArgb(0, 96, 255)), new SolidBrush(Color.FromArgb(80, 0, 255)), new SolidBrush(Color.FromArgb(128, 0, 255)), new SolidBrush(Color.FromArgb(160, 0, 255)), new SolidBrush(Color.FromArgb(255, 0, 176)) };
        internal static readonly Font Fuente_Notas = new Font("Arial", 16f, FontStyle.Bold);
        internal static readonly int[] Matriz_Pentagrama_Espectro_Índices = new int[12] { 0, 144, 184, 224, 255, 590, 694, 876, 1148, 1196, 1228, 1244 };
        internal static readonly int[] Matriz_Pentagrama_Notas = new int[12] { 171, 171, 162, 162, 154, 145, 145, 137, 137, 128, 128, 120 };

        internal Bitmap Crear_Imagen_Rueda_Notas(List<int> Lista_Notas, bool Rueda_12_Notas, bool Forzar_Toda_Rueda, bool Español)
        {
            try
            {
                Bitmap Imagen = new Bitmap(384, 256, PixelFormat.Format24bppRgb);
                Graphics Pintar = Graphics.FromImage(Imagen);
                Pintar.CompositingMode = CompositingMode.SourceCopy;
                Pintar.CompositingQuality = CompositingQuality.HighSpeed;
                Pintar.InterpolationMode = InterpolationMode.NearestNeighbor;
                Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Pintar.SmoothingMode = SmoothingMode.None;
                Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;

                // Separadores

                Pintar.FillRectangle(Brushes.Gray, 110, 0, 1, 256);
                Pintar.FillRectangle(Brushes.Gray, 127, 0, 1, 256);
                Pintar.DrawImage(Resources.Pentagrama, new Rectangle(0, 0, 110, 256), new Rectangle(0, 0, 110, 256), GraphicsUnit.Pixel);

                // Pentagrama

                Color Color_Fondo = Color.FromArgb(255, 0, 0, 0);
                List<int> Lista_Pentagrama = Lista_Notas.GetRange(0, Lista_Notas.Count);
                bool Pentagrama_Colorear_Notas = true;
                bool Pentagrama_Invertir_Pentagrama = false;
                bool Pentagrama_Notas_Parte_Superior = true;
                bool Pentagrama_Partir_Octavas_Mitad = true;

                Bitmap Imagen_Clave_Sol_Espectro = new Bitmap(48, 136, PixelFormat.Format32bppArgb);
                Graphics Pintar_Clave_Sol_Espectro = Graphics.FromImage(Imagen_Clave_Sol_Espectro);
                Pintar_Clave_Sol_Espectro.CompositingMode = CompositingMode.SourceCopy;
                if (Lista_Pentagrama.Count > 1)
                {
                    Lista_Pentagrama.Sort();
                    if (Pentagrama_Partir_Octavas_Mitad)
                    {
                        List<int> Lista_Temporal = new List<int>();
                        for (int Índice = 0; Índice < Lista_Pentagrama.Count; Índice++)
                        {
                            if (Lista_Pentagrama[Índice] < 6) Lista_Temporal.Add(Lista_Pentagrama[Índice]);
                        }
                        for (int Índice = Lista_Pentagrama.Count - 1; Índice >= 0; Índice--)
                        {
                            if (Lista_Pentagrama[Índice] >= 6) Lista_Temporal.Insert(0, Lista_Pentagrama[Índice]);
                        }
                        Lista_Pentagrama = new List<int>(Lista_Temporal.GetRange(0, Lista_Temporal.Count));
                        Lista_Temporal = null;
                    }
                    Color[] Matriz_Colores = new Color[Lista_Pentagrama.Count];
                    float[] Matriz_Posiciones = new float[Lista_Pentagrama.Count];
                    for (int Índice = 0, Índice_Invertido = Lista_Pentagrama.Count - 1; Índice < Lista_Pentagrama.Count; Índice++, Índice_Invertido--)
                    {
                        Matriz_Colores[Índice_Invertido] = Matriz_Colores_12_Notas[Lista_Pentagrama[Índice]]; // Obtener_Color_Puro_1530((Lista_Pentagrama[Índice] * 1529) / 11);
                        Matriz_Posiciones[Índice] = (float)((double)Índice / (double)(Matriz_Posiciones.Length - 1));
                    }
                    LinearGradientBrush Pincel = new LinearGradientBrush(new Rectangle(0, 0, 16, 256), Color_Fondo, Color_Fondo, LinearGradientMode.Vertical);
                    ColorBlend Mezcla_Colores = new ColorBlend(Lista_Pentagrama.Count);
                    Mezcla_Colores.Colors = Matriz_Colores;
                    Mezcla_Colores.Positions = Matriz_Posiciones;
                    Pincel.GammaCorrection = true;
                    Pincel.InterpolationColors = Mezcla_Colores;
                    Pintar.FillRectangle(Pincel, 111, 0, 16, 256);
                    Pincel.Dispose();
                    Pincel = null;
                    /*int Ancho_Espectro = 16;
                    Bitmap Imagen_Espectroscopio_Pentagrama_Temporal = new Bitmap(384, 256, PixelFormat.Format24bppRgb);
                    Graphics Pintar_Espectroscopio_Pentagrama_Temporal = Graphics.FromImage(Imagen_Espectroscopio_Pentagrama_Temporal);
                    Pintar_Espectroscopio_Pentagrama_Temporal.CompositingMode = CompositingMode.SourceCopy;
                    Pintar_Espectroscopio_Pentagrama_Temporal.DrawImage(Imagen_Espectroscopio_Pentagrama, new Rectangle(0, 0, 384 - Ancho_Espectro, 256), new Rectangle(Ancho_Espectro, 0, 384 - Ancho_Espectro, 256), GraphicsUnit.Pixel);
                    Pintar_Espectroscopio_Pentagrama_Temporal.DrawImage(Imagen_Pentagrama_Espectro, new Rectangle(384 - Ancho_Espectro, 0, Ancho_Espectro, 256), new Rectangle(0, 0, Ancho_Espectro, 256), GraphicsUnit.Pixel);
                    Pintar_Espectroscopio_Pentagrama_Temporal.Dispose();
                    Pintar_Espectroscopio_Pentagrama_Temporal = null;
                    Imagen_Espectroscopio_Pentagrama = Imagen_Espectroscopio_Pentagrama_Temporal;*/
                    if (Pentagrama_Colorear_Notas)
                    {
                        Pincel = new LinearGradientBrush(new Rectangle(0, 0, 48, 136), Color_Fondo, Color_Fondo, LinearGradientMode.Vertical);
                        Mezcla_Colores = new ColorBlend(Lista_Pentagrama.Count);
                        Mezcla_Colores.Colors = Matriz_Colores;
                        Mezcla_Colores.Positions = Matriz_Posiciones;
                        Pincel.GammaCorrection = true;
                        Pincel.InterpolationColors = Mezcla_Colores;
                        Pintar_Clave_Sol_Espectro.FillRectangle(Pincel, 0, 0, 48, 136); // 7, 63, 48, 136
                        Pincel.Dispose();
                        Pincel = null;
                        Matriz_Posiciones = null;
                        Matriz_Colores = null;
                    }
                }
                else if (Lista_Pentagrama.Count == 1)
                {
                    using (SolidBrush Pincel = new SolidBrush(Matriz_Colores_12_Notas[Lista_Pentagrama[0]])) Pintar.FillRectangle(Pincel, 111, 0, 16, 256);
                    //Pintar.Clear(Matriz_Colores_12_Notas[Lista_Pentagrama[0]]);
                    if (Pentagrama_Colorear_Notas) Pintar_Clave_Sol_Espectro.Clear(Matriz_Colores_12_Notas[Lista_Pentagrama[0]]);
                }
                else
                {
                    using (SolidBrush Pincel = new SolidBrush(Color_Fondo.R + Color_Fondo.G + Color_Fondo.B <= 384 ? Color.Gray : Color.Gray)) Pintar.FillRectangle(Pincel, 111, 0, 16, 256);
                    //Pintar.Clear(Color_Fondo.R + Color_Fondo.G + Color_Fondo.B <= 384 ? Color.Gray : Color.Gray);
                    /*if (Pentagrama_Colorear_Notas) */
                    Pintar_Clave_Sol_Espectro.Clear(Color_Fondo.R + Color_Fondo.G + Color_Fondo.B <= 384 ? Color.Gray : Color.Gray);
                }
                Pintar_Clave_Sol_Espectro.Dispose();
                Pintar_Clave_Sol_Espectro = null;
                Bitmap Imagen_Pentagrama = Resources.Pentagrama;
                Bitmap Imagen_Clave_Sol = Imagen_Pentagrama.Clone(new Rectangle(7, 63, 48, 136), PixelFormat.Format32bppArgb);

                BitmapData Bitmap_Data_Clave_Sol_Espectro = Imagen_Clave_Sol_Espectro.LockBits(new Rectangle(0, 0, 48, 136), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                byte[] Matriz_Bytes_Clave_Sol_Espectro = new byte[26112];
                Marshal.Copy(Bitmap_Data_Clave_Sol_Espectro.Scan0, Matriz_Bytes_Clave_Sol_Espectro, 0, Matriz_Bytes_Clave_Sol_Espectro.Length);
                Imagen_Clave_Sol_Espectro.UnlockBits(Bitmap_Data_Clave_Sol_Espectro);
                Bitmap_Data_Clave_Sol_Espectro = null;

                BitmapData Bitmap_Data_Clave_Sol = Imagen_Clave_Sol.LockBits(new Rectangle(0, 0, 48, 136), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                byte[] Matriz_Bytes_Clave_Sol = new byte[26112];
                Marshal.Copy(Bitmap_Data_Clave_Sol.Scan0, Matriz_Bytes_Clave_Sol, 0, Matriz_Bytes_Clave_Sol.Length);
                //int Bytes_Diferencia = Math.Abs(Bitmap_Data_Clave_Sol.Stride) - ((49 * Image.GetPixelFormatSize(PixelFormat.Format32bppArgb)) / 8);

                //MessageBox.Show(Bitmap_Data_Pentagrama.Stride.ToString() + ", " + Bitmap_Data_Clave_Sol.Stride.ToString());
                //MessageBox.Show(Matriz_Bytes_Pentagrama.Length.ToString() + ", " + Matriz_Bytes_Clave_Sol.Length.ToString());

                for (int Índice_Y = 0, Índice_Byte = 0; Índice_Y < 136; Índice_Y++)
                {
                    for (int Índice_X = 0; Índice_X < 48; Índice_X++, Índice_Byte += 4)
                    {
                        //if (Matriz_Bytes_Clave_Sol[Índice_Byte + 3] == 255 && Matriz_Bytes_Clave_Sol[Índice_Byte + 2] == 0 && Matriz_Bytes_Clave_Sol[Índice_Byte + 1] == 0 && Matriz_Bytes_Clave_Sol[Índice_Byte] == 0) // Negro
                        //if (Matriz_Bytes_Clave_Sol[Índice_Byte + 3] > 0 && Matriz_Bytes_Clave_Sol[Índice_Byte + 2] == 0 && Matriz_Bytes_Clave_Sol[Índice_Byte + 1] == 0 && Matriz_Bytes_Clave_Sol[Índice_Byte] == 0) // Negro
                        if (Matriz_Bytes_Clave_Sol[Índice_Byte + 2] == 0 && Matriz_Bytes_Clave_Sol[Índice_Byte + 1] == 0 && Matriz_Bytes_Clave_Sol[Índice_Byte] == 0)
                        {
                            //Matriz_Bytes_Clave_Sol[Índice_Byte + 3] = Matriz_Bytes_Clave_Sol_Espectro[Índice_Byte + 3];
                            Matriz_Bytes_Clave_Sol[Índice_Byte + 2] = Matriz_Bytes_Clave_Sol_Espectro[Índice_Byte + 2];
                            Matriz_Bytes_Clave_Sol[Índice_Byte + 1] = Matriz_Bytes_Clave_Sol_Espectro[Índice_Byte + 1];
                            Matriz_Bytes_Clave_Sol[Índice_Byte] = Matriz_Bytes_Clave_Sol_Espectro[Índice_Byte];
                        }
                    }
                }
                Marshal.Copy(Matriz_Bytes_Clave_Sol, 0, Bitmap_Data_Clave_Sol.Scan0, Matriz_Bytes_Clave_Sol.Length);
                Imagen_Clave_Sol.UnlockBits(Bitmap_Data_Clave_Sol);
                Bitmap_Data_Clave_Sol = null;
                Matriz_Bytes_Clave_Sol = null;
                Matriz_Bytes_Clave_Sol_Espectro = null;
                //Graphics Pintar_Pentagrama = Pintar; //Graphics.FromImage(Imagen_Pentagrama);
                Pintar.CompositingMode = CompositingMode.SourceCopy;
                Pintar.DrawImage(Imagen_Clave_Sol, new Rectangle(7, 63, 48, 136), new Rectangle(0, 0, 48, 136), GraphicsUnit.Pixel);
                Pintar.CompositingMode = CompositingMode.SourceOver;
                Imagen_Clave_Sol.Dispose();
                Imagen_Clave_Sol = null;
                Imagen_Clave_Sol_Espectro.Dispose();
                Imagen_Clave_Sol_Espectro = null;
                //Pintar_Pentagrama_Superior.CompositingMode = CompositingMode.SourceOver;
                //Pintar_Pentagrama_Superior.DrawImage(!Pentagrama_Invertir_Pentagrama ? !Pentagrama_Notas_Parte_Superior ? !Pentagrama_Partir_Octavas_Mitad ? Resources.Pentagrama_Inferior : Resources.Pentagrama : !Pentagrama_Partir_Octavas_Mitad ? Resources.Pentagrama_Superior : Resources.Pentagrama : !Pentagrama_Notas_Parte_Superior ? !Pentagrama_Partir_Octavas_Mitad ? Resources.Pentagrama_Inferior_Invertido : Resources.Pentagrama_Invertido : !Pentagrama_Partir_Octavas_Mitad ? Resources.Pentagrama_Superior_Invertido : Resources.Pentagrama_Invertido, new Rectangle(0, 0, 110, 256), new Rectangle(0, 0, 110, 256), GraphicsUnit.Pixel);
                //Pintar_Pentagrama_Superior.CompositingMode = CompositingMode.SourceCopy;



                string Texto_Do = null;
                string Texto_C = null;
                if (Lista_Pentagrama.Count > 0)
                {
                    //Pintar_Pentagrama.CompositingMode = CompositingMode.SourceOver;
                    for (int Índice = 0; Índice < Lista_Pentagrama.Count; Índice++)
                    {
                        Bitmap Imagen_Nota = Lista_Pentagrama[Índice] != 1 && Lista_Pentagrama[Índice] != 3 && Lista_Pentagrama[Índice] != 6 && Lista_Pentagrama[Índice] != 8 && Lista_Pentagrama[Índice] != 10 ? Resources.Pentagrama_Nota : Resources.Pentagrama_Nota_Sostenida;
                        if (Pentagrama_Colorear_Notas)
                        {
                            int Ancho_Nota = Imagen_Nota.Width;
                            int Alto_Nota = Imagen_Nota.Height;
                            BitmapData Bitmap_Data = Imagen_Nota.LockBits(new Rectangle(0, 0, Ancho_Nota, Alto_Nota), ImageLockMode.ReadWrite, Imagen_Nota.PixelFormat);
                            byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * Alto_Nota];
                            Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                            int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho_Nota * Image.GetPixelFormatSize(Imagen_Nota.PixelFormat)) / 8);
                            for (int Y_Nota = 0, Índice_Byte = 0; Y_Nota < Alto_Nota; Y_Nota++, Índice_Byte += Bytes_Diferencia)
                            {
                                for (int X_Nota = 0; X_Nota < Ancho_Nota; X_Nota++, Índice_Byte += 4)
                                {
                                    if (Matriz_Bytes[Índice_Byte + 2] == 0 && Matriz_Bytes[Índice_Byte + 1] == 0 && Matriz_Bytes[Índice_Byte] == 0)
                                    {
                                        Matriz_Bytes[Índice_Byte + 2] = Matriz_Colores_12_Notas[Lista_Pentagrama[Índice]].R;
                                        Matriz_Bytes[Índice_Byte + 1] = Matriz_Colores_12_Notas[Lista_Pentagrama[Índice]].G;
                                        Matriz_Bytes[Índice_Byte] = Matriz_Colores_12_Notas[Lista_Pentagrama[Índice]].B;
                                    }
                                }
                            }
                            Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                            Imagen_Nota.UnlockBits(Bitmap_Data);
                        }
                        if (Lista_Pentagrama[Índice] != 1 && Lista_Pentagrama[Índice] != 3 && Lista_Pentagrama[Índice] != 6 && Lista_Pentagrama[Índice] != 8 && Lista_Pentagrama[Índice] != 10)
                        {
                            Pintar.DrawImage(Imagen_Nota, new Rectangle(77, Matriz_Pentagrama_Notas[Lista_Pentagrama[Índice]] + ((!Pentagrama_Partir_Octavas_Mitad && Pentagrama_Notas_Parte_Superior) || (Pentagrama_Partir_Octavas_Mitad && Lista_Pentagrama[Índice] < 6) ? -60 : 0), 27, 18), new Rectangle(0, 0, 27, 18), GraphicsUnit.Pixel);
                        }
                        else Pintar.DrawImage(Imagen_Nota, new Rectangle(58, (Matriz_Pentagrama_Notas[Lista_Pentagrama[Índice]] - 13) + ((!Pentagrama_Partir_Octavas_Mitad && Pentagrama_Notas_Parte_Superior) || (Pentagrama_Partir_Octavas_Mitad && Lista_Pentagrama[Índice] < 6) ? -60 : 0), 46, 49), new Rectangle(0, 0, 46, 49), GraphicsUnit.Pixel);
                        Texto_Do += Matriz_Notas[Lista_Pentagrama[Índice]] + ", ";
                        Texto_C += Matriz_Notas_CDEFGAB[Lista_Pentagrama[Índice]] + ", ";
                    }
                    //Pintar_Pentagrama.CompositingMode = CompositingMode.SourceCopy;
                    Texto_Do = Texto_Do.Replace(" Sostenido", "#").TrimEnd(", ".ToCharArray());
                    Texto_C = Texto_C.TrimEnd(", ".ToCharArray());
                }
                //Picture_Pentagrama_Espectro.Image = Imagen_Pentagrama_Espectro;
                //Picture_Pentagrama.Image = Imagen_Pentagrama;
                //Picture_Pentagrama.Image = Imagen_Pentagrama_Superior;
                /*if (Lenguaje.Actual == Lenguaje.Lenguajes.Alemán) Etiqueta_Pentagrama_Notas.Text = Lista_Pentagrama.Count.ToString() + string.Empty;
                else if (Lenguaje.Actual == Lenguaje.Lenguajes.Catalán) Etiqueta_Pentagrama_Notas.Text = Lista_Pentagrama.Count.ToString() + (Lista_Pentagrama.Count != 1 ? " Notes" : " Nota");
                else if (Lenguaje.Actual == Lenguaje.Lenguajes.Español) Etiqueta_Pentagrama_Notas.Text = Lista_Pentagrama.Count.ToString() + (Lista_Pentagrama.Count != 1 ? " Notas" : " Nota");
                else if (Lenguaje.Actual == Lenguaje.Lenguajes.Inglés) Etiqueta_Pentagrama_Notas.Text = Lista_Pentagrama.Count.ToString() + (Lista_Pentagrama.Count != 1 ? " Notes" : " Note");
                Etiqueta_Pentagrama_Notas_Do.Text = Texto_Do;
                Etiqueta_Pentagrama_Notas_C.Text = Texto_C;*/

                // Rueda de notas

                Pintar.CompositingMode = CompositingMode.SourceCopy;
                Pintar.CompositingQuality = CompositingQuality.HighSpeed;
                Pintar.InterpolationMode = InterpolationMode.NearestNeighbor;
                Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Pintar.SmoothingMode = SmoothingMode.None;
                Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;

                if (!Rueda_12_Notas)
                {
                    //double Ángulo_Inicial = -90d;
                    double Grados_Tecla_Blanca = 360d / 7d;
                    double Grados_Tecla_Negra = Grados_Tecla_Blanca / 3d;

                    for (int Índice = 0; Índice < 7; Índice++)
                    {
                        if ((Índice == 0 && Lista_Notas.Contains(0)) ||
                            (Índice == 1 && Lista_Notas.Contains(2)) ||
                            (Índice == 2 && Lista_Notas.Contains(4)) ||
                            (Índice == 3 && Lista_Notas.Contains(5)) ||
                            (Índice == 4 && Lista_Notas.Contains(7)) ||
                            (Índice == 5 && Lista_Notas.Contains(9)) ||
                            (Índice == 6 && Lista_Notas.Contains(11)) ||
                            Forzar_Toda_Rueda)
                        {
                            SolidBrush Pincel = null;
                            if (Índice == 0) Pincel = new SolidBrush(Matriz_Colores_12_Notas[0]);
                            else if (Índice == 1) Pincel = new SolidBrush(Matriz_Colores_12_Notas[2]);
                            else if (Índice == 2) Pincel = new SolidBrush(Matriz_Colores_12_Notas[4]);
                            else if (Índice == 3) Pincel = new SolidBrush(Matriz_Colores_12_Notas[5]);
                            else if (Índice == 4) Pincel = new SolidBrush(Matriz_Colores_12_Notas[7]);
                            else if (Índice == 5) Pincel = new SolidBrush(Matriz_Colores_12_Notas[9]);
                            else if (Índice == 6) Pincel = new SolidBrush(Matriz_Colores_12_Notas[11]);
                            Pintar.FillPie(Pincel, new Rectangle(128, 0, 256, 256), (float)(-90d + (Grados_Tecla_Blanca * (double)Índice)), (float)Grados_Tecla_Blanca);
                            Pincel.Dispose();
                            Pincel = null;
                            Pintar.DrawPie(Pens.Gray, new Rectangle(128, 0, 256, 256), (float)(-90d + (Grados_Tecla_Blanca * (double)Índice)), (float)Grados_Tecla_Blanca);
                        }
                        else Pintar.DrawPie(Pens.Gray, new Rectangle(128, 0, 256, 256), (float)(-90d + (Grados_Tecla_Blanca * (double)Índice)), (float)Grados_Tecla_Blanca);
                    }
                    for (int Índice = 0; Índice < 7; Índice++)
                    {
                        if ((Índice == 1 && Lista_Notas.Contains(1)) ||
                            (Índice == 2 && Lista_Notas.Contains(3)) ||
                            (Índice == 4 && Lista_Notas.Contains(6)) ||
                            (Índice == 5 && Lista_Notas.Contains(8)) ||
                            (Índice == 6 && Lista_Notas.Contains(10)) ||
                            (Índice != 0 && Índice != 3 && Forzar_Toda_Rueda))
                        {
                            SolidBrush Pincel = null;
                            if (Índice == 1) Pincel = new SolidBrush(Matriz_Colores_12_Notas[1]);
                            else if (Índice == 2) Pincel = new SolidBrush(Matriz_Colores_12_Notas[3]);
                            else if (Índice == 4) Pincel = new SolidBrush(Matriz_Colores_12_Notas[6]);
                            else if (Índice == 5) Pincel = new SolidBrush(Matriz_Colores_12_Notas[8]);
                            else if (Índice == 6) Pincel = new SolidBrush(Matriz_Colores_12_Notas[10]);
                            Pintar.FillPie(Pincel, new Rectangle(128, 0, 256, 256), (float)((-90d + (Grados_Tecla_Blanca * (double)Índice)) - (Grados_Tecla_Negra / 2d)), (float)Grados_Tecla_Negra);
                            Pincel.Dispose();
                            Pincel = null;
                            Pintar.DrawPie(Pens.Gray, new Rectangle(128, 0, 256, 256), (float)((-90d + (Grados_Tecla_Blanca * (double)Índice)) - (Grados_Tecla_Negra / 2d)), (float)Grados_Tecla_Negra);
                        }
                        else if (Índice != 0 && Índice != 3)
                        {
                            Pintar.FillPie(Brushes.Transparent, new Rectangle(128, 0, 256, 256), (float)((-90d + (Grados_Tecla_Blanca * (double)Índice)) - (Grados_Tecla_Negra / 2d)), (float)Grados_Tecla_Negra);
                            Pintar.DrawPie(Pens.Gray, new Rectangle(128, 0, 256, 256), (float)((-90d + (Grados_Tecla_Blanca * (double)Índice)) - (Grados_Tecla_Negra / 2d)), (float)Grados_Tecla_Negra);
                        }
                    }
                    for (int Índice = 0; Índice < 7; Índice++)
                    {
                        /*SolidBrush Pincel = null;
                        if (Índice == 0 && (Lista_Pentagrama.Contains(0) || Modo_Relleno)) Pincel = new SolidBrush(Matriz_Pentagrama_Espectro[0]);
                        else if (Índice == 1 && (Lista_Pentagrama.Contains(2) || Modo_Relleno)) Pincel = new SolidBrush(Matriz_Pentagrama_Espectro[2]);
                        else if (Índice == 2 && (Lista_Pentagrama.Contains(4) || Modo_Relleno)) Pincel = new SolidBrush(Matriz_Pentagrama_Espectro[4]);
                        else if (Índice == 3 && (Lista_Pentagrama.Contains(5) || Modo_Relleno)) Pincel = new SolidBrush(Matriz_Pentagrama_Espectro[5]);
                        else if (Índice == 4 && (Lista_Pentagrama.Contains(7) || Modo_Relleno)) Pincel = new SolidBrush(Matriz_Pentagrama_Espectro[7]);
                        else if (Índice == 5 && (Lista_Pentagrama.Contains(9) || Modo_Relleno)) Pincel = new SolidBrush(Matriz_Pentagrama_Espectro[9]);
                        else if (Índice == 6 && (Lista_Pentagrama.Contains(11) || Modo_Relleno)) Pincel = new SolidBrush(Matriz_Pentagrama_Espectro[11]);
                        else Pincel = (SolidBrush)Brushes.Black;
                        if (Pincel != null) Pintar.FillPie(Pincel, new Rectangle(144, 80, 96, 96), (float)(-90d + (Grados_Tecla_Blanca * (double)Índice)), (float)Grados_Tecla_Blanca);
                        //Pincel.Dispose();
                        //Pincel = null;*/
                        double Zoom = 96.8d;
                        double Resto = (256d - Zoom) / 2d;
                        if (Índice != 0 && Índice != 3) Pintar.DrawPie(Pens.Gray, new RectangleF((float)(128d + Resto), (float)Resto, (float)Zoom, (float)Zoom), (float)((-90d + (Grados_Tecla_Blanca * (double)Índice)) - (Grados_Tecla_Negra / 2d)), (float)Grados_Tecla_Negra);
                    }
                    for (int Índice = 0; Índice < 7; Índice++)
                    {
                        SolidBrush Pincel = null;
                        if (Índice == 0 && (Lista_Notas.Contains(0) || Forzar_Toda_Rueda)) Pincel = new SolidBrush(Matriz_Colores_12_Notas[0]);
                        else if (Índice == 1 && (Lista_Notas.Contains(2) || Forzar_Toda_Rueda)) Pincel = new SolidBrush(Matriz_Colores_12_Notas[2]);
                        else if (Índice == 2 && (Lista_Notas.Contains(4) || Forzar_Toda_Rueda)) Pincel = new SolidBrush(Matriz_Colores_12_Notas[4]);
                        else if (Índice == 3 && (Lista_Notas.Contains(5) || Forzar_Toda_Rueda)) Pincel = new SolidBrush(Matriz_Colores_12_Notas[5]);
                        else if (Índice == 4 && (Lista_Notas.Contains(7) || Forzar_Toda_Rueda)) Pincel = new SolidBrush(Matriz_Colores_12_Notas[7]);
                        else if (Índice == 5 && (Lista_Notas.Contains(9) || Forzar_Toda_Rueda)) Pincel = new SolidBrush(Matriz_Colores_12_Notas[9]);
                        else if (Índice == 6 && (Lista_Notas.Contains(11) || Forzar_Toda_Rueda)) Pincel = new SolidBrush(Matriz_Colores_12_Notas[11]);
                        else Pincel = (SolidBrush)Brushes.Transparent;
                        double Zoom = 96d;
                        double Resto = (256d - Zoom) / 2d;
                        if (Pincel != null) Pintar.FillPie(Pincel, (float)(128d + Resto), (float)Resto, (float)Zoom, (float)Zoom, (float)(-90d + (Grados_Tecla_Blanca * (double)Índice)), (float)Grados_Tecla_Blanca);
                    }
                    Pintar.TranslateTransform(256f, 128f);
                    for (int Índice = 0; Índice < 7; Índice++)
                    {
                        Pintar.DrawLine(Pens.Gray, 0f, 0f, 0f, -48f);
                        Pintar.RotateTransform((float)Grados_Tecla_Blanca);
                    }
                    Pintar.ResetTransform();

                    // Cerrar líneas

                    Pintar.FillRectangle(Brushes.Gray, 304, 134, 1, 1); // D#

                    Pintar.FillRectangle(Brushes.Gray, 238, 173, 1, 1); // F#

                    Pintar.FillRectangle(Brushes.Gray, 207, 133, 1, 1); // G#
                    Pintar.FillRectangle(Brushes.Gray, 209, 139, 1, 1);

                    Pintar.FillRectangle(Brushes.Gray, 214, 102, 1, 1); // A#
                }
                else
                {
                    double Grados_Tecla_Blanca = 360d / 12d;
                    for (int Índice = 0; Índice < 12; Índice++)
                    {
                        if (Lista_Notas.Contains(Índice) || Forzar_Toda_Rueda)
                        {
                            SolidBrush Pincel = new SolidBrush(Matriz_Colores_12_Notas[Índice]);
                            Pintar.FillPie(Pincel, new Rectangle(128, 0, 256, 256), (float)(-90d + (Grados_Tecla_Blanca * (double)Índice)), (float)Grados_Tecla_Blanca);
                            Pincel.Dispose();
                            Pincel = null;
                            Pintar.DrawPie(Pens.Gray, new Rectangle(128, 0, 256, 256), (float)(-90d + (Grados_Tecla_Blanca * (double)Índice)), (float)Grados_Tecla_Blanca);
                        }
                        else Pintar.DrawPie(Pens.Gray, new Rectangle(128, 0, 256, 256), (float)(-90d + (Grados_Tecla_Blanca * (double)Índice)), (float)Grados_Tecla_Blanca);
                    }
                }

                Pintar.FillRectangle(Brushes.Gray, 254, 255, 4, 1);

                // ...

                if (Lista_Notas.Count > 0) // Proporción triangular
                {
                    List<double> Lista_Ángulos = new List<double>();
                    foreach (int Nota in Lista_Notas)
                    {
                        double Ángulo = !Rueda_12_Notas ? Matriz_Ángulos_7_Notas[Nota] : Matriz_Ángulos_12_Notas[Nota];
                        Lista_Ángulos.Add(Ángulo);
                    }
                    List<PointF> Lista_Puntos = new List<PointF>();
                    /*Lista_Ángulos = new List<double>();
                    Lista_Ángulos.Add(135d);
                    Lista_Ángulos.Add(225d);
                    Lista_Ángulos.Add(315d);*/
                    string Texto_Ángulos = null;
                    //int Índice_Ángulo_Siguiente = Lista_Ángulos.Count - 1;

                    //double Ángulos2 = 0d;

                    for (int Índice = 0; Índice < Lista_Ángulos.Count; Índice++)
                    {
                        double Seno_X = 128d * Math.Sin((Lista_Ángulos[Índice] * Math.PI) / 180d);
                        double Coseno_Y = 128d * Math.Cos(((Lista_Ángulos[Índice] + 180d) * Math.PI) / 180d);
                        Lista_Puntos.Add(new PointF((float)(Seno_X), (float)(Coseno_Y)));

                        // ...

                        /*if (Lista_Ángulos.Count == 3 && Índice == 0)
                        {
                            int Índice_A = Índice;
                            int Índice_B = Índice + 1;
                            int Índice_C = Índice - 1;

                            if (Índice_B < 0) Índice_B += Lista_Ángulos.Count;
                            if (Índice_B >= Lista_Ángulos.Count) Índice_B -= Lista_Ángulos.Count;
                            if (Índice_C < 0) Índice_C += Lista_Ángulos.Count;
                            if (Índice_C >= Lista_Ángulos.Count) Índice_C -= Lista_Ángulos.Count;

                            double x = 128d * Math.Sin((Lista_Ángulos[Índice_A] * Math.PI) / 180d);
                            double xx = 128d * Math.Sin((Lista_Ángulos[Índice_B] * Math.PI) / 180d);
                            double xxx = 128d * Math.Sin((Lista_Ángulos[Índice_C] * Math.PI) / 180d);
                            double y = 128d * Math.Cos(((Lista_Ángulos[Índice_A] + 180d) * Math.PI) / 180d);
                            double yy = 128d * Math.Cos(((Lista_Ángulos[Índice_B] + 180d) * Math.PI) / 180d);
                            double yyy = 128d * Math.Cos(((Lista_Ángulos[Índice_C] + 180d) * Math.PI) / 180d);

                            double dotprod = (xxx - x) * (xx - x) + (yyy - y) * (yy - y);
                            double len1squared = (xx - x) * (xx - x) + (yy - y) * (yy - y);
                            double len2squared = (xxx - x) * (xxx - x) + (yyy - y) * (yyy - y);
                            double angle = Math.Acos(dotprod / Math.Sqrt(len1squared * len2squared));

                            this.Text = angle.ToString();
                        }*/

                        // ...

                        int Índice_Anterior = Índice - 1;
                        if (Índice_Anterior < 0) Índice_Anterior = Lista_Ángulos.Count - 1;
                        int Índice_Siguiente = Índice + 1;
                        if (Índice_Siguiente >= Lista_Ángulos.Count) Índice_Siguiente = 0;
                        double Ángulo = Math.Abs(Lista_Ángulos[Índice_Siguiente] - Lista_Ángulos[Índice_Anterior]) / 2d;
                        //double Ángulo = (Math.Abs(Lista_Ángulos[Índice_Siguiente] - Lista_Ángulos[Índice]) + Math.Abs(Lista_Ángulos[Índice] - Lista_Ángulos[Índice_Anterior])) / 2d;
                        //double Ángulo = (Lista_Ángulos[Math.Max(Índice_Siguiente, Índice_Anterior)] - Lista_Ángulos[Math.Min(Índice_Siguiente, Índice_Anterior)]) / 2d;
                        //while (Ángulo < 0d) Ángulo += 360d;
                        //while (Ángulo > 360d) Ángulo -= 360d;
                        //Ángulo /= 2d;
                        //Texto_Ángulos += Math.Round(Lista_Ángulos[Índice]).ToString() + ",";
                        Texto_Ángulos += Math.Round(Ángulo, MidpointRounding.AwayFromZero).ToString() + (Índice < Lista_Ángulos.Count - 1 ? "º, " : "º");
                        //Índice_Ángulo_Siguiente++;
                        //if (Índice_Ángulo_Siguiente >= Lista_Ángulos.Count) Índice_Ángulo_Siguiente = 0;
                        //Ángulos2 += Ángulo;
                    }
                    //Ángulos2 /= (double)Lista_Ángulos.Count;
                    //Texto_Ángulos = Math.Round(Ángulos2, MidpointRounding.AwayFromZero).ToString() + "º; "/* + Texto_Ángulos*/;
                    //if (Lista_Ángulos.Count != 3) Texto_Ángulos = null;

                    Pintar.ResetTransform();
                    Pintar.TranslateTransform(256f, 128f);
                    for (int Índice = 0; Índice < Lista_Puntos.Count; Índice++) Pintar.DrawLine(Color_Fondo.R + Color_Fondo.G + Color_Fondo.B <= 384 ? Pens.White : Pens.Black, new PointF(0f, 0f), Lista_Puntos[Índice]);
                    if (Lista_Puntos.Count > 1) Pintar.DrawPolygon(Color_Fondo.R + Color_Fondo.G + Color_Fondo.B <= 384 ? Pens.White : Pens.Black, Lista_Puntos.ToArray());
                    else Pintar.DrawLine(Color_Fondo.R + Color_Fondo.G + Color_Fondo.B <= 384 ? Pens.White : Pens.Black, new PointF(0f, 0f), Lista_Puntos[0]);
                    //Etiqueta_Espectroscopio_2.Text = Lista_Ángulos.Count > 2 ? Texto_Ángulos : Lista_Ángulos.Count > 1 ? Math.Round(Math.Abs(Lista_Ángulos[1] - Lista_Ángulos[0]) / 2d, MidpointRounding.AwayFromZero).ToString() + "º" : Lista_Ángulos.Count > 0 ? Math.Round(Lista_Ángulos[0] / 2d, MidpointRounding.AwayFromZero).ToString() + "º" : "0º";
                    Lista_Puntos = null;
                    Lista_Ángulos = null;
                    // this // 
                }

                Pintar.ResetTransform();
                Pintar.TranslateTransform(256f, 128f);

                // ...

                if (Lista_Notas.Count > 0) // Letras de las notas activas
                {
                    Pintar.CompositingMode = CompositingMode.SourceOver;
                    Pintar.SmoothingMode = SmoothingMode.HighQuality;
                    foreach (int Nota in Lista_Notas)
                    {
                        string Texto_Nota = !Español ? Matriz_Notas_CDEFGAB[Nota] : Matriz_Notas[Nota];
                        SizeF Dimensiones = Pintar.MeasureString(Texto_Nota, Fuente_Notas);
                        Pintar.ResetTransform();
                        //Pintar.TranslateTransform(192f, 128f);
                        //Pintar.RotateTransform(!Rueda_12_Notas ? (float)(Matriz_Ángulos_7_Notas[Nota] - (Texto_Nota.Length == 1 ? 4.25d : 6.75d)) : (float)(Matriz_Ángulos_12_Notas[Nota] - (Texto_Nota.Length == 2 ? 6.75d : Texto_Nota.Length == 3 ? 8.25d : 10d)));
                        Pintar.TranslateTransform(256f, 128f);
                        Pintar.RotateTransform(!Rueda_12_Notas ? (float)(Matriz_Ángulos_7_Notas[Nota] - (float)((double)Dimensiones.Width / 3.5d)/*(Texto_Nota.Length == 1 ? 4.25d : 6.75d)*/) : (float)(Matriz_Ángulos_12_Notas[Nota] - (float)((double)Dimensiones.Width / 3.5d)/*(Texto_Nota.Length == 2 ? 6.75d : Texto_Nota.Length == 3 ? 8.25d : 10d)*/));
                        Pintar.DrawString(Texto_Nota, Fuente_Notas, Brushes.Black, new PointF(1f, (-140f + Dimensiones.Height) + 1f)); // Sombra 3D
                        Pintar.DrawString(Texto_Nota, Fuente_Notas, Brushes.White, new PointF(0f, -140f + Dimensiones.Height));
                        //Fuente = null;
                    }
                    Pintar.ResetTransform();
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    Pintar.SmoothingMode = SmoothingMode.None;
                }



                Pintar.Dispose();
                Pintar = null;
                return Imagen;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            return null;
        }

        internal Bitmap[] Matriz_Notas_Inicio = new Bitmap[12] { Resources.Nota_Do_Inicio, Resources.Nota_Do_Sostenido_Inicio, Resources.Nota_Re_Inicio, Resources.Nota_Re_Sostenido_Inicio, Resources.Nota_Mi_Inicio, Resources.Nota_Fa_Inicio, Resources.Nota_Fa_Sostenido_Inicio, Resources.Nota_Sol_Inicio, Resources.Nota_Sol_Sostenido_Inicio, Resources.Nota_La_Inicio, Resources.Nota_La_Sostenido_Inicio, Resources.Nota_Si_Inicio };
        internal Bitmap[] Matriz_Notas_Centro = new Bitmap[12] { Resources.Nota_Do_Centro, Resources.Nota_Do_Sostenido_Centro, Resources.Nota_Re_Centro, Resources.Nota_Re_Sostenido_Centro, Resources.Nota_Mi_Centro, Resources.Nota_Fa_Centro, Resources.Nota_Fa_Sostenido_Centro, Resources.Nota_Sol_Centro, Resources.Nota_Sol_Sostenido_Centro, Resources.Nota_La_Centro, Resources.Nota_La_Sostenido_Centro, Resources.Nota_Si_Centro };
        //internal TextureBrush[] Matriz_Notas_Centro = new TextureBrush[12] { new TextureBrush(Resources.Nota_Do_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_Do_Sostenido_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_Re_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_Re_Sostenido_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_Mi_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_Fa_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_Fa_Sostenido_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_Sol_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_Sol_Sostenido_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_La_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_La_Sostenido_Centro, WrapMode.Tile), new TextureBrush(Resources.Nota_Si_Centro, WrapMode.Tile) };
        internal Bitmap[] Matriz_Notas_Fin = new Bitmap[12] { Resources.Nota_Do_Fin, Resources.Nota_Do_Sostenido_Fin, Resources.Nota_Re_Fin, Resources.Nota_Re_Sostenido_Fin, Resources.Nota_Mi_Fin, Resources.Nota_Fa_Fin, Resources.Nota_Fa_Sostenido_Fin, Resources.Nota_Sol_Fin, Resources.Nota_Sol_Sostenido_Fin, Resources.Nota_La_Fin, Resources.Nota_La_Sostenido_Fin, Resources.Nota_Si_Fin };

        internal readonly string Texto_Título = "Júpiter Mauro Scores Viewer for " + Program.Texto_Usuario + " by Jupisoft";
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

        internal int Variable_Desviación = 0;

        // TODO: all the PNG scores with only 16 colors, midi files and fsc files.

        // 4x = 12 pixels of width per note, 192 per bar.
        // 5x = 8 pixels of width per note, 128 per bar.
        // 8x = 6 pixels of width per note, 96 per bar.
        // 16x = 3 pixels of width per note, 48 per bar.

        private void Ventana_Visor_Partituras_Júpiter_Mauro_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                this.Text = Texto_Título + " - [Scores: " + Program.Traducir_Número(Jupisoft_Scores.Lista_Partituras_Jupisoft.Count) + ", all released under Creative Commons, CC-BY-SA 4.0]";
                this.WindowState = FormWindowState.Maximized;
                Ocupado = true;
                Registro_Cargar_Opciones();
                Ocupado = false;
                if (Jupisoft_Scores.Lista_Partituras_Jupisoft != null && Jupisoft_Scores.Lista_Partituras_Jupisoft.Count > 0)
                {
                    foreach (Jupisoft_Scores.Partituras_Jupisoft Partitura_Jupisoft in Jupisoft_Scores.Lista_Partituras_Jupisoft)
                    {
                        try
                        {
                            ComboBox_Partitura.Items.Add(Partitura_Jupisoft.Título + " [" + Partitura_Jupisoft.Álbum + "] [TRACK " + Program.Traducir_Número(Partitura_Jupisoft.Pista) + "] [" + Partitura_Jupisoft.Duración_Barras.ToString() + " BARS]");
                        }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; continue; }
                    }
                    if (ComboBox_Partitura.Items.Count > 0) ComboBox_Partitura.SelectedIndex = Program.Rand.Next(0, ComboBox_Partitura.Items.Count);
                    //if (ComboBox_Partitura.Items.Count > 0) ComboBox_Partitura.SelectedIndex = 0;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Partituras_Júpiter_Mauro_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal.Start();
                //Generar_Imagen_4_Bits();
                //Jupisoft_Scores.Analizar_Partituras_FSC();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Partituras_Júpiter_Mauro_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Reproductor != null)
                {
                    Reproductor.Dispose();
                    Reproductor = null;
                }
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Partituras_Júpiter_Mauro_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Partituras_Júpiter_Mauro_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
                Picture.Width = Panel_Picture.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
                ComboBox_Partitura_SelectedIndexChanged(ComboBox_Partitura, EventArgs.Empty); // Force a redraw.
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Partituras_Júpiter_Mauro_KeyDown(object sender, KeyEventArgs e)
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
                    else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.MediaPlayPause)
                    {
                        try
                        {
                            e.Handled = true;
                            e.SuppressKeyPress = true;
                            Temporizador_Principal.Stop();
                            if (Reproductor != null)
                            {
                                if (!Reproductor.IsPlaying()) Reproductor.Play(0, 0, 0);
                                else Reproductor.Stop();
                            }
                            Pintar_Capa.Clear(Color.Transparent);
                            Borrar_Capa = false;
                            Picture.Invalidate(new Rectangle(0, 1, Picture.ClientSize.Width, Alto_Capa));
                            Picture.Update();
                            Temporizador_Principal_Tick(Temporizador_Principal, EventArgs.Empty);
                            Temporizador_Principal.Start();
                        }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
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
                try
                {
                    if (Borrar_Capa)
                    {
                        Pintar_Capa.Clear(Color.Transparent);
                        Borrar_Capa = false;
                        Picture.Invalidate(new Rectangle(0, 1, Picture.ClientSize.Width, Alto_Capa));
                    }
                    if (Reproductor != null)
                    {
                        if (Reproductor.IsPlaying())
                        {
                            int Milisegundo = Reproductor.GetCurentMilisecond();
                            int Milisegundo_Capa = Milisegundo - 250; // Delay to try to sync with the MIDI sound (latency).
                            if (Milisegundo_Capa < 0) Milisegundo_Capa = 0; // Always start at zero.
                            
                            int X_Barra = Reproductor_Longitud > 0 ? (int)Math.Round(((double)Milisegundo_Capa * 64d) / (double)Math.Max(Reproductor_Longitud, 15000), MidpointRounding.AwayFromZero) : 0;
                            if (X_Barra < 0) X_Barra = 0;
                            else if (X_Barra > 64) X_Barra = 64;
                            X_Barra *= 12;
                            SolidBrush Pincel = new SolidBrush(Color.FromArgb(64, 255, 255, 255));
                            Pintar_Capa.FillRectangle(Pincel, 63 + X_Barra, 19, 12, Alto_Capa - 20);
                            Pincel.Dispose();
                            Pincel = null;

                            int X_Marcador = Reproductor_Longitud > 0 ? (int)Math.Round(((double)Milisegundo_Capa * 769d) / (double)Math.Max(Reproductor_Longitud, 15000), MidpointRounding.AwayFromZero) : 0;
                            if (X_Marcador < 0) X_Marcador = 0;
                            else if (X_Marcador > 769) X_Marcador = 769;
                            Pintar_Capa.CompositingMode = CompositingMode.SourceOver;
                            Pintar_Capa.DrawImage(Resources.Score_Marker, new Rectangle((X_Capa + 63 + X_Marcador) - 8, 1, 17, 10), new Rectangle(0, 0, 17, 10), GraphicsUnit.Pixel);
                            Pintar_Capa.CompositingMode = CompositingMode.SourceCopy;

                            Borrar_Capa = true;
                            Picture.Invalidate(new Rectangle(0, 1, Picture.ClientSize.Width, Alto_Capa));
                            int Progreso = Reproductor_Longitud > 0 ? (int)Math.Round(((double)Milisegundo * 100d) / (double)Reproductor_Longitud, MidpointRounding.AwayFromZero) : 0;
                            if (Progreso < 0) Progreso = 0;
                            else if (Progreso > 100) Progreso = 100;
                            Barra_Progreso.Value = Progreso;
                        }
                        else Barra_Progreso.Value = 0;
                    }
                    Picture.Update();
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

        internal void Generar_Imagen_4_Bits()
        {
            try
            {
                string Ruta_Entrada = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Sitio web de Jupisoft\\png";
                string Ruta_Salida = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Quantized";
                Program.Crear_Carpetas(Ruta_Salida);
                string[] Matriz_Carpetas = Directory.GetDirectories(Ruta_Entrada, "*", SearchOption.TopDirectoryOnly);
                string[] Matriz_Archivos = Directory.GetFiles(Ruta_Entrada, "*.png", SearchOption.AllDirectories);
                if (Matriz_Carpetas != null && Matriz_Carpetas.Length > 0)
                {
                    foreach (string Ruta in Matriz_Carpetas)
                    {
                        Program.Crear_Carpetas(Ruta_Salida + "\\" + Path.GetFileName(Ruta));
                    }
                }
                foreach (string Ruta in Matriz_Archivos)
                {
                    Bitmap Imagen_Original = Program.Obtener_Imagen_Ruta(Ruta);
                    if (Imagen_Original != null)
                    {
                        int Ancho = Imagen_Original.Width;
                        int Alto = Imagen_Original.Height;
                        /*Color[] Matriz_Paleta = new Color[16]
                        {
                            Color.FromArgb(255, 0, 0, 0), // C.
                            Color.FromArgb(255, 255, 144, 0), // C#.
                            Color.FromArgb(255, 255, 176, 0), // D.
                            Color.FromArgb(255, 255, 216, 0), // D#.
                            Color.FromArgb(255, 255, 255, 0), // E.
                            Color.FromArgb(255, 0, 255, 0), // F.
                            Color.FromArgb(255, 0, 255, 192), // F#.
                            Color.FromArgb(255, 0, 96, 255), // G.
                            Color.FromArgb(255, 80, 0, 255), // G#.
                            Color.FromArgb(255, 128, 0, 255), // A.
                            Color.FromArgb(255, 160, 0, 255), // A#.
                            Color.FromArgb(255, 255, 0, 176), // B.
                            Color.FromArgb(255, 155, 155, 55), // Background.
                            Color.FromArgb(255, 149, 149, 49), // Background dark.
                            //Color.FromArgb(255, 131, 131, 31), // Grid lines.
                            Color.FromArgb(255, 0, 0, 0), // Borders.
                            Color.FromArgb(255, 213, 217, 225) // White key color.
                        };
                        Bitmap Imagen_Paleta = new Bitmap(Matriz_Paleta.Length, 1, PixelFormat.Format24bppRgb);
                        Graphics Pintar_Paleta = Graphics.FromImage(Imagen_Paleta);
                        Pintar_Paleta.CompositingMode = CompositingMode.SourceCopy;
                        int Índice_X = 0;
                        foreach (Color Color_ARGB in Matriz_Paleta)
                        {
                            SolidBrush Pincel = new SolidBrush(Color_ARGB);
                            Pintar_Paleta.FillRectangle(Pincel, Índice_X, 0, 1, 1);
                            Pincel.Dispose();
                            Pincel = null;
                            Índice_X++;
                        }
                        Pintar_Paleta.Dispose();
                        Pintar_Paleta = null;*/

                        //MagickImage Imagen_Mapa = new MagickImage(Imagen_Paleta);
                        MagickImage Imagen_Mapeada = new MagickImage(Imagen_Original.Clone() as Bitmap);
                        QuantizeSettings Ajustes_Cuantización = new QuantizeSettings();
                        Ajustes_Cuantización.Colors = 256; // 16 // 256
                        //Ajustes_Cuantización.ColorSpace = ColorSpace.RGB;
                        Ajustes_Cuantización.DitherMethod = DitherMethod.No;
                        //Ajustes_Cuantización.MeasureErrors = false;
                        //Ajustes_Cuantización.TreeDepth = Diccionario_Paleta.Count; // 8

                        //Imagen_Mapeada.Map(Imagen_Mapa, Ajustes_Cuantización);
                        Imagen_Mapeada.Quantize(Ajustes_Cuantización);
                        Bitmap Imagen_Cuantizada = Imagen_Mapeada.ToBitmap(ImageFormat.Png);
                        Imagen_Cuantizada.Save(Ruta.Replace(Ruta_Entrada, Ruta_Salida), ImageFormat.Png);
                        Imagen_Cuantizada.Dispose();
                        Imagen_Cuantizada = null;
                        Imagen_Mapeada.Dispose();
                        Imagen_Mapeada = null;

                        /*Bitmap Imagen_Cuantizada = new Bitmap(Ancho, Alto, PixelFormat.Format24bppRgb);
                        Graphics Pintar_Cuantizada = Graphics.FromImage(Imagen_Cuantizada);
                        Pintar_Cuantizada.CompositingMode = CompositingMode.SourceCopy;
                        Pintar_Cuantizada.DrawImage(Imagen_Mapeada.ToBitmap(ImageFormat.Png), new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                        Pintar_Cuantizada.Dispose();
                        Pintar_Cuantizada = null;
                        Imagen_Cuantizada.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\qwertyuiop.png");
                        //Picture_2.BackgroundImage = Imagen_Cuantizada;
                        Imagen_Paleta.Dispose();
                        Imagen_Paleta = null;
                        Imagen_Mapa.Dispose();
                        Imagen_Mapa = null;
                        Imagen_Mapeada.Dispose();
                        Imagen_Mapeada = null;*/
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        internal int X_Capa = 0;
        internal int Ancho_Capa = 0;
        internal int Alto_Capa = 0;
        internal bool Borrar_Capa = false;
        internal Graphics Pintar_Capa = null;
        internal MCI_Player Reproductor = null;
        internal int Reproductor_Longitud = 0;

        private void ComboBox_Partitura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Temporizador_Principal.Stop();
                if (ComboBox_Partitura.SelectedIndex > -1)
                {
                    Jupisoft_Scores.Partituras_Jupisoft Partitura_Jupisoft = Jupisoft_Scores.Lista_Partituras_Jupisoft[ComboBox_Partitura.SelectedIndex];
                    try
                    {
                        if (Reproductor != null)
                        {
                            Reproductor.Dispose();
                            Reproductor = null;
                        }
                        string Pista = Partitura_Jupisoft.Pista.ToString();
                        while (Pista.Length < 2) Pista = '0' + Pista;
                        string Ruta_Midi = Application.StartupPath + "\\Midi\\" + Partitura_Jupisoft.Álbum + "\\" + Pista + " " + Partitura_Jupisoft.Título + ".mid";
                        if (File.Exists(Ruta_Midi))
                        {
                            Reproductor = new MCI_Player(new List<string>(new string[] { Ruta_Midi }));
                            Reproductor.Play(0, 0, 0);
                            Reproductor_Longitud = Reproductor.GetSongLength();
                        }
                        else SystemSounds.Beep.Play();
                    }
                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
                    int Ancho_Cliente = Picture.ClientSize.Width;
                    if (Ancho_Cliente > 0)
                    {
                        int Multiplicador_Notas = 0;
                        Bitmap Imagen_Partitura_Fondo = null;
                        if (Partitura_Jupisoft.Duración_Barras <= 4)
                        {
                            Multiplicador_Notas = 12;
                            Imagen_Partitura_Fondo = Resources.Score_4x;
                        }
                        else if (Partitura_Jupisoft.Duración_Barras <= 8)
                        {
                            Multiplicador_Notas = 6;
                            Imagen_Partitura_Fondo = Resources.Score_8x;
                        }
                        else
                        {
                            Multiplicador_Notas = 3;
                            Imagen_Partitura_Fondo = Resources.Score_16x;
                        }
                        int Mínimo_Y = int.MaxValue;
                        int Máximo_Y = int.MinValue;
                        foreach (Rectangle Rectángulo_Nota in Partitura_Jupisoft.Lista_Notas)
                        {
                            if (Rectángulo_Nota.Y < Mínimo_Y) Mínimo_Y = Rectángulo_Nota.Y;
                            if (Rectángulo_Nota.Y > Máximo_Y) Máximo_Y = Rectángulo_Nota.Y;
                        }
                        Mínimo_Y += Variable_Desviación; // Allow to rotate the notes in real time.
                        Máximo_Y += Variable_Desviación;
                        int Ancho_Partitura = Imagen_Partitura_Fondo.Width;
                        int Alto_Partitura = 20 + ((Math.Abs(Máximo_Y - Mínimo_Y) + 1) * 12);
                        int Ancho_Acordes = Math.Max(Ancho_Cliente / 384, 1);
                        int Alto_Acordes = Partitura_Jupisoft.Lista_Acordes.Count / Ancho_Acordes;
                        if (Ancho_Acordes * Alto_Acordes < Partitura_Jupisoft.Lista_Acordes.Count) Alto_Acordes++;
                        int Ancho = Math.Max(Ancho_Acordes * 384, Ancho_Partitura);
                        int Alto = (Alto_Partitura + 1) + (Alto_Acordes * 256);
                        int Diferencia_Acordes = (832 - (Ancho_Acordes * 384)) / 2;
                        if (Diferencia_Acordes < 0) Diferencia_Acordes = 0;
                        X_Capa = (Ancho - 832) / 2;
                        Ancho_Capa = Ancho;
                        Alto_Capa = Alto_Partitura + 1;
                        Bitmap Imagen_Partitura = new Bitmap(Ancho_Partitura, Alto_Partitura, PixelFormat.Format32bppArgb);
                        Graphics Pintar_Partitura = Graphics.FromImage(Imagen_Partitura);
                        Pintar_Partitura.CompositingMode = CompositingMode.SourceCopy;
                        Pintar_Partitura.DrawImage(Imagen_Partitura_Fondo, new Rectangle(0, 0, Ancho_Partitura, 19), new Rectangle(0, 0, Ancho_Partitura, 19), GraphicsUnit.Pixel);
                        Pintar_Partitura.DrawImage(Imagen_Partitura_Fondo, new Rectangle(0, 19, Ancho_Partitura, Alto_Partitura - 19), new Rectangle(0, (19 + ((124 - Máximo_Y) * 12))/* - (Variable_Desviación * 12)*/, Ancho_Partitura, Alto_Partitura - 19), GraphicsUnit.Pixel);
                        foreach (Rectangle Rectángulo_Nota in Partitura_Jupisoft.Lista_Notas)
                        {
                            int Nota = Rectángulo_Nota.Y + Variable_Desviación;
                            int Nota_12 = Nota % 12;
                            int X = ((Rectángulo_Nota.X * 16) * Multiplicador_Notas) / 384;
                            int Y = 20 + (((124 - Nota) * 12) - ((124 - Máximo_Y) * 12));
                            int Longitud = ((Rectángulo_Nota.Width * 16) * Multiplicador_Notas) / 384;
                            if (Longitud < 6) Longitud = 6;
                            //Pintar_Partitura.FillRectangle(Brushes.Red, 63 + X, Y, Longitud, 11);
                            Pintar_Partitura.DrawImage(Matriz_Notas_Inicio[Nota_12], new Rectangle(63 + X, Y, 2, 11), new Rectangle(0, 0, 2, 11), GraphicsUnit.Pixel);
                            for (int Índice = 2; Índice < Longitud - 3; Índice++)
                            {
                                Pintar_Partitura.DrawImage(Matriz_Notas_Centro[Nota_12], new Rectangle(63 + X + Índice, Y, 1, 11), new Rectangle(0, 0, 1, 11), GraphicsUnit.Pixel);
                            }
                            //Pintar_Partitura.FillRectangle(Matriz_Notas_Centro[Nota], 65 + X, Y, Longitud - 5, 11);
                            Pintar_Partitura.DrawImage(Matriz_Notas_Fin[Nota_12], new Rectangle(63 + X + (Longitud - 3), Y, 3, 11), new Rectangle(0, 0, 3, 11), GraphicsUnit.Pixel);
                        }
                        Pintar_Partitura.Dispose();
                        Pintar_Partitura = null;
                        Imagen_Partitura_Fondo.Dispose();
                        Imagen_Partitura_Fondo = null;
                        Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                        Graphics Pintar = Graphics.FromImage(Imagen);
                        Pintar.CompositingMode = CompositingMode.SourceCopy;
                        Pintar.DrawImage(Imagen_Partitura, new Rectangle(0, 0, Ancho_Partitura, Alto_Partitura), new Rectangle(0, 0, Ancho_Partitura, Alto_Partitura), GraphicsUnit.Pixel);
                        for (int Y = 0, Índice_Acorde = 0; Y < Alto_Acordes; Y++)
                        {
                            for (int X = 0; X < Ancho_Acordes; X++, Índice_Acorde++)
                            {
                                if (Índice_Acorde < Partitura_Jupisoft.Lista_Acordes.Count)
                                {
                                    List<int> Lista_Notas = Jupisoft_Scores.Obtener_Notas(Partitura_Jupisoft.Lista_Acordes[Índice_Acorde]);
                                    for (int Índice = 0; Índice < Lista_Notas.Count; Índice++)
                                    {
                                        Lista_Notas[Índice] += Variable_Desviación;
                                        while (Lista_Notas[Índice] < 0) Lista_Notas[Índice] += 12;
                                        while (Lista_Notas[Índice] > 11) Lista_Notas[Índice] -= 12;
                                    }
                                    Bitmap Imagen_Acorde = Crear_Imagen_Rueda_Notas(Lista_Notas, false, false, false);
                                    Pintar.DrawImage(Imagen_Acorde, new Rectangle(Diferencia_Acordes + (X * 384), (Alto_Partitura + 1) + (Y * 256), 384, 256), new Rectangle(0, 0, 384, 256), GraphicsUnit.Pixel);
                                    Imagen_Acorde.Dispose();
                                    Imagen_Acorde = null;
                                }
                            }
                        }
                        Pintar.Dispose();
                        Pintar = null;
                        Imagen_Partitura.Dispose();
                        Imagen_Partitura = null;
                        Picture.Height = Alto + 2;
                        Picture.BackgroundImage = Imagen;
                        Picture.Image = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                        Pintar_Capa = Graphics.FromImage(Picture.Image);
                        Pintar_Capa.CompositingMode = CompositingMode.SourceCopy;
                        Borrar_Capa = false;
                        Picture.Refresh();
                        Temporizador_Principal_Tick(Temporizador_Principal, EventArgs.Empty);
                        Temporizador_Principal.Start();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            finally { this.Cursor = Cursors.Default; }
        }

        private void NumericUpDown_Desviación_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown_Desviación.Refresh();
                Variable_Desviación = (int)NumericUpDown_Desviación.Value;
                ComboBox_Partitura_SelectedIndexChanged(ComboBox_Partitura, EventArgs.Empty);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void NumericUpDown_Desviación_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    NumericUpDown_Desviación.Value = 0m;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Panel_Picture.Select();
                    Panel_Picture.Focus();
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    Temporizador_Principal.Stop();
                    if (Reproductor != null)
                    {
                        if (!Reproductor.IsPlaying()) Reproductor.Play(0, 0, 0);
                        else Reproductor.Stop();
                    }
                    Pintar_Capa.Clear(Color.Transparent);
                    Borrar_Capa = false;
                    Picture.Invalidate(new Rectangle(0, 1, Picture.ClientSize.Width, Alto_Capa));
                    Picture.Update();
                    Temporizador_Principal_Tick(Temporizador_Principal, EventArgs.Empty);
                    Temporizador_Principal.Start();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ComboBox_Partitura_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    if (ComboBox_Partitura.Items.Count > 0) ComboBox_Partitura.SelectedIndex = Program.Rand.Next(0, ComboBox_Partitura.Items.Count);
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

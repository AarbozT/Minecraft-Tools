using Microsoft.Win32;
using Minecraft_Tools.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    internal static class Program
    {
        /// <summary>
        /// The Windows registry build date, used to know if the older settings should be deleted.
        /// </summary>
        internal static readonly string Texto_Fecha = "2018_09_06_03_17_56_771";
        /// <summary>
        /// The Minecraft version that most tools of this application will support.
        /// </summary>
        internal static readonly string Texto_Minecraft_Versión = "1.13.1"; // 1.13 (Snapshot 18w20c)

        /// <summary>
        /// Since the application was first designed for "Xisumavoid", this will be the default user name, but can be changed later from the help menu.
        /// </summary>
        internal static string Texto_Usuario = Environment.UserName;
        internal static string Texto_Título = "Minecraft Tools by Jupisoft";
        internal static string Texto_Programa = "Minecraft Tools";
        internal static readonly string Texto_Versión = "1.0.0.0";
        internal static readonly string Texto_Versión_Fecha = Texto_Versión + " (" + Texto_Fecha.Replace("_", null) + ")";
        internal static string Texto_Título_Versión = Texto_Título + " " + Texto_Versión;

        internal static readonly string Ruta_Minecraft = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft";
        internal static readonly string Ruta_Guardado_Minecraft = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\saves";
        internal static readonly string Ruta_Twitch = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Curse";
        internal static readonly string Ruta_Guardado_Twitch = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Curse\\Minecraft\\Instances";
        internal static readonly string Ruta_Guardado_Imágenes = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools";
        internal static readonly string Ruta_Guardado_Imágenes_Afinador_Bloques_Nota = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Note Blocks Tuner";
        internal static readonly string Ruta_Guardado_Imágenes_Buscador_Chunks_Limos = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Slime Chunks Finder";
        internal static readonly string Ruta_Guardado_Imágenes_Buscador_JAR = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\JAR Finder";
        internal static readonly string Ruta_Guardado_Imágenes_Generador_Miniaturas_Color_Medio = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Thumbnails and Average Color";
        internal static readonly string Ruta_Guardado_Imágenes_Diseñador_Estandartes = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Banner Designer";
        internal static readonly string Ruta_Guardado_Imágenes_Exportador_Estructuras_Pintadas = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Painted Structures";
        internal static readonly string Ruta_Guardado_Imágenes_Estructuras_Personalizadas = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Custom Structures";
        internal static readonly string Ruta_Guardado_Imágenes_Información_Miembros_Hermitcraft = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Hermitcraft Members Information";
        internal static readonly string Ruta_Guardado_Imágenes_Paletas = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Palettes";
        internal static readonly string Ruta_Guardado_Imágenes_Pixel_Art = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Pixel Art";
        internal static readonly string Ruta_Guardado_Imágenes_Realistic_World_Viewer_2D = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Realistic World Viewer in 2D";
        internal static readonly string Ruta_Guardado_Imágenes_Reloj_Minecraft_Tiempo_Real = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Real Time Minecraft Clock";
        internal static readonly string Ruta_Guardado_Imágenes_Secretos = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Secrets";
        internal static readonly string Ruta_Guardado_Imágenes_Visor_Cuadros = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Paintings Viewer";
        internal static readonly string Ruta_Guardado_Imágenes_Visor_NBT = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\NBT Viewer";
        internal static readonly string Ruta_Guardado_Imágenes_Visor_Nombres_Encantamientos = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Jupisoft\\Minecraft Tools\\Enchantment Names Viewer";

        internal static Random Rand = new Random();
        internal static List<char> Lista_Caracteres_Prohibidos = new List<char>();
        internal static readonly char Caracter_Coma_Decimal = (0.5d).ToString()[1];
        internal static readonly char Caracter_Punto_Decimal = Caracter_Coma_Decimal != '.' ? '.' : ',';
        internal static readonly char Caracter_Signo_Negativo = (-1).ToString()[0];

        internal static readonly Bitmap Imagen_Transparente = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
        internal static HatchBrush Pincel_Trama = new HatchBrush(HatchStyle.Percent50, Color.FromArgb(128, 0, 0, 0), Color.Transparent);
        internal static TextureBrush Pincel_Fondo = new TextureBrush(Resources.Fondo, WrapMode.Tile);

        internal static class HSL
        {
            /// <summary>
            /// Convierte un color RGB en uno HSL.
            /// </summary>
            /// <param name="Rojo">Valor entre 0 y 255.</param>
            /// <param name="Verde">Valor entre 0 y 255.</param>
            /// <param name="Azul">Valor entre 0 y 255.</param>
            /// <param name="Matiz">Valor entre 0 y 360.</param>
            /// <param name="Saturación">Valor entre 0 y 100.</param>
            /// <param name="Luminosidad">Valor entre 0 y 100.</param>
            internal static void From_RGB(byte Rojo, byte Verde, byte Azul, out double Matiz, out double Saturación, out double Luminosidad)
            {
                Matiz = 0d;
                Saturación = 0d;
                Luminosidad = 0d;
                double Rojo_1 = Rojo / 255d;
                double Verde_1 = Verde / 255d;
                double Azul_1 = Azul / 255d;
                double Máximo, Mínimo, Diferencia;
                Máximo = Math.Max(Rojo_1, Math.Max(Verde_1, Azul_1));
                Mínimo = Math.Min(Rojo_1, Math.Min(Verde_1, Azul_1));
                Luminosidad = (Mínimo + Máximo) / 2d;
                if (Luminosidad <= 0d) return;
                Diferencia = Máximo - Mínimo;
                Saturación = Diferencia;
                if (Saturación > 0d) Saturación /= (Luminosidad <= 0.5d) ? (Máximo + Mínimo) : (2d - Máximo - Mínimo);
                else
                {
                    Luminosidad = Math.Round(Luminosidad * 100d, 1, MidpointRounding.AwayFromZero);
                    return;
                }
                double Rojo_2 = (Máximo - Rojo_1) / Diferencia;
                double Verde_2 = (Máximo - Verde_1) / Diferencia;
                double Azul_2 = (Máximo - Azul_1) / Diferencia;
                if (Rojo_1 == Máximo) Matiz = (Verde_1 == Mínimo ? 5d + Azul_2 : 1d - Verde_2);
                else if (Verde_1 == Máximo) Matiz = (Azul_1 == Mínimo ? 1d + Rojo_2 : 3d - Azul_2);
                else Matiz = (Rojo_1 == Mínimo ? 3d + Verde_2 : 5d - Rojo_2);
                Matiz /= 6d;
                if (Matiz >= 1d) Matiz = 0d;
                Matiz *= 360d;
                Saturación *= 100d;
                Luminosidad *= 100d;
                //if (Matiz < 0d || Matiz >= 360d) MessageBox.Show("To Matiz", Matiz.ToString());
                //if (Saturación < 0d || Saturación > 100d) MessageBox.Show("To Saturación");
                //if (Luminosidad < 0d || Luminosidad > 100d) MessageBox.Show("To Luminosidad");
                //Matiz = Math.Round(Matiz * 360d, 1, MidpointRounding.AwayFromZero); // 0.0d ~ 360.0d
                //Saturación = Math.Round(Saturación * 100d, 1, MidpointRounding.AwayFromZero); // 0.0d ~ 100.0d
                //Luminosidad = Math.Round(Luminosidad * 100d, 1, MidpointRounding.AwayFromZero); // 0.0d ~ 100.0d
                //if (Matiz >= 360d) Matiz = 0d;
            }

            /// <summary>
            /// Convierte un color HSL en uno RGB.
            /// </summary>
            /// <param name="Matiz">Valor entre 0 y 360.</param>
            /// <param name="Saturación">Valor entre 0 y 100.</param>
            /// <param name="Luminosidad">Valor entre 0 y 100.</param>
            /// <param name="Rojo">Valor entre 0 y 255.</param>
            /// <param name="Verde">Valor entre 0 y 255.</param>
            /// <param name="Azul">Valor entre 0 y 255.</param>
            internal static void To_RGB(double Matiz, double Saturación, double Luminosidad, out byte Rojo, out byte Verde, out byte Azul)
            {
                if (Matiz >= 360d) Matiz = 0d;
                //Matiz = Math.Round(Matiz, 1, MidpointRounding.AwayFromZero);
                //Saturación = Math.Round(Saturación, 1, MidpointRounding.AwayFromZero);
                //Luminosidad = Math.Round(Luminosidad, 1, MidpointRounding.AwayFromZero);
                Matiz /= 360d; // 0.0d ~ 1.0d
                Saturación /= 100d; // 0.0d ~ 1.0d
                Luminosidad /= 100d; // 0.0d ~ 1.0d
                double Rojo_Temporal = Luminosidad; // Default to Gray
                double Verde_Temporal = Luminosidad;
                double Azul_Temporal = Luminosidad;
                double v = Luminosidad <= 0.5d ? (Luminosidad * (1d + Saturación)) : (Luminosidad + Saturación - Luminosidad * Saturación);
                if (v > 0d)
                {
                    double m, sv, Sextante, fract, vsf, mid1, mid2;
                    m = Luminosidad + Luminosidad - v;
                    sv = (v - m) / v;
                    Matiz *= 6d;
                    Sextante = Math.Floor(Matiz);
                    fract = Matiz - Sextante;
                    vsf = v * sv * fract;
                    mid1 = m + vsf;
                    mid2 = v - vsf;
                    if (Sextante == 0d)
                    {
                        Rojo_Temporal = v;
                        Verde_Temporal = mid1;
                        Azul_Temporal = m;
                    }
                    else if (Sextante == 1d)
                    {
                        Rojo_Temporal = mid2;
                        Verde_Temporal = v;
                        Azul_Temporal = m;
                    }
                    else if (Sextante == 2d)
                    {
                        Rojo_Temporal = m;
                        Verde_Temporal = v;
                        Azul_Temporal = mid1;
                    }
                    else if (Sextante == 3d)
                    {
                        Rojo_Temporal = m;
                        Verde_Temporal = mid2;
                        Azul_Temporal = v;
                    }
                    else if (Sextante == 4d)
                    {
                        Rojo_Temporal = mid1;
                        Verde_Temporal = m;
                        Azul_Temporal = v;
                    }
                    else if (Sextante == 5d)
                    {
                        Rojo_Temporal = v;
                        Verde_Temporal = m;
                        Azul_Temporal = mid2;
                    }
                }
                Rojo = (byte)Math.Round(Rojo_Temporal * 255d, MidpointRounding.AwayFromZero);
                Verde = (byte)Math.Round(Verde_Temporal * 255d, MidpointRounding.AwayFromZero);
                Azul = (byte)Math.Round(Azul_Temporal * 255d, MidpointRounding.AwayFromZero);
            }

            internal static byte Obtener_Matiz_0_a_255(byte Rojo, byte Verde, byte Azul)
            {
                /*int Matiz = 0;
                int Saturación = 0;
                int Luminosidad = 0;
                //double Rojo_1 = Rojo / 255d;
                //double Verde_1 = Verde / 255d;
                //double Azul_1 = Azul / 255d;
                //double Máximo, Mínimo, Diferencia;
                int Máximo = Math.Max(Rojo, Math.Max(Verde, Azul));
                int Mínimo = Math.Min(Rojo, Math.Min(Verde, Azul));
                Luminosidad = (Mínimo + Máximo) / 2;
                if (Luminosidad <= 0) return 0;
                int Diferencia = Máximo - Mínimo;
                Saturación = Diferencia;
                if (Saturación > 0) Saturación /= (Luminosidad <= 128) ? (Máximo + Mínimo) : (510 - Máximo - Mínimo);
                else
                {
                    //Luminosidad = Math.Round(Luminosidad * 100d, 1, MidpointRounding.AwayFromZero);
                    return 0;
                }
                int Rojo_2 = (Máximo - Rojo) / Diferencia;
                int Verde_2 = (Máximo - Verde) / Diferencia;
                int Azul_2 = (Máximo - Azul) / Diferencia;
                if (Rojo == Máximo) Matiz = (Verde == Mínimo ? 1275 + Azul_2 : 255 - Verde_2);
                else if (Verde == Máximo) Matiz = (Azul == Mínimo ? 255 + Rojo_2 : 765 - Azul_2);
                else Matiz = (Rojo == Mínimo ? 765 + Verde_2 : 1275 - Rojo_2);
                if (Matiz >= 1530) Matiz = 0;
                Matiz /= 6;

                //Matiz *= 360d;
                //Saturación *= 100d;
                //Luminosidad *= 100d;



                if (Rojo != Verde || Rojo != Azul)
                {
                    int Matiz = 0;
                    Byte Mínimo = Math.Min(Rojo, Math.Min(Verde, Azul));
                    Byte Máximo = Math.Max(Rojo, Math.Max(Verde, Azul));
                    if (Rojo == Máximo) Matiz = (Verde == Mínimo ? (5 * 255) + (((Máximo - Azul) * 255) / (Máximo - Mínimo)) : (1 * 255) - (((Máximo - Verde) * 255) / (Máximo - Mínimo)));
                    else if (Verde == Máximo) Matiz = (Azul == Mínimo ? (1 * 255) + (((Máximo - Rojo) * 255) / (Máximo - Mínimo)) : (3 * 255) - (((Máximo - Azul) * 255) / (Máximo - Mínimo)));
                    else Matiz = (Rojo == Mínimo ? (3 * 255) + (((Máximo - Verde) * 255) / (Máximo - Mínimo)) : (5 * 255) - (((Máximo - Rojo) * 255) / (Máximo - Mínimo)));
                    Matiz++; // 2013_02_10_09_13_04_593
                    if (Matiz >/*=*//* 1530) Matiz = 0;
                    return (Byte)(Matiz / 6);
                }*/
                return 0;
            }

            internal static byte Obtener_Saturación_0_a_255(byte Rojo, byte Verde, byte Azul)
            {
                if (Rojo != Verde || Rojo != Azul)
                {
                    byte Mínimo = Math.Min(Rojo, Math.Min(Verde, Azul));
                    byte Máximo = Math.Max(Rojo, Math.Max(Verde, Azul));
                    return (byte)(((Máximo - Mínimo) * 255) / ((((Mínimo + Máximo) / 2) <= 128) ? (Máximo + Mínimo) : (510 - Máximo - Mínimo)));
                }
                return 0;
            }

            internal static byte Obtener_Brillo_0_a_255(byte Rojo, byte Verde, byte Azul)
            {
                return (byte)((Math.Min(Rojo, Math.Min(Verde, Azul)) + Math.Max(Rojo, Math.Max(Verde, Azul))) / 2);
            }
        }

        /// <summary>
        /// Function designed to convert any ARGB color into a 3D one based on a height value. Note that the sea level ends at Y = 62.
        /// </summary>
        /// <param name="Color_ARGB">Any valid ARGB value.</param>
        /// <param name="Y">Any desired height value between 0 and 255.</param>
        /// <param name="Color_3D">True to generate a new 3D color. False to return the original color.</param>
        /// <returns>Returns the modified ARGB color based on the specified height. Returns null on any error.</returns>
        internal static Color Obtener_Color_3D(Color Color_ARGB, int Y, bool Color_3D)
        {
            try
            {
                if (Color_3D)
                {
                    if (Y < 62) // Below the sea level (Darker color)
                    {
                        int Diferencia = Y; // Height difference from the sea level.
                        int Rojo = Color_ARGB.R + ((64 * Diferencia) / 61);
                        int Verde = Color_ARGB.G + ((64 * Diferencia) / 61);
                        int Azul = Color_ARGB.B + ((64 * Diferencia) / 61);
                        if (Rojo < 0) Rojo = 0;
                        else if (Rojo > 255) Rojo = 255;
                        if (Verde < 0) Verde = 0;
                        else if (Verde > 255) Verde = 255;
                        if (Azul < 0) Azul = 0;
                        else if (Azul > 255) Azul = 255;
                        return Color.FromArgb(255, Rojo, Verde, Azul);
                    }
                    else if (Y > 62) // Above the sea level (Brighter color)
                    {
                        int Diferencia = 192 - (255 - Y); // Inverted height difference from the sea level.
                        int Rojo = Color_ARGB.R + ((64 * Diferencia) / 192);
                        int Verde = Color_ARGB.G + ((64 * Diferencia) / 192);
                        int Azul = Color_ARGB.B + ((64 * Diferencia) / 192);
                        if (Rojo < 0) Rojo = 0;
                        else if (Rojo > 255) Rojo = 255;
                        if (Verde < 0) Verde = 0;
                        else if (Verde > 255) Verde = 255;
                        if (Azul < 0) Azul = 0;
                        else if (Azul > 255) Azul = 255;
                        return Color.FromArgb(255, Rojo, Verde, Azul);
                    }
                    /*if (Y != 64) // 64 = Original color
                    {
                        if (Y < 64) // From 0 to 63 = Darker color
                        {
                            int Multiplicador = ((Y + 1) / 2) + 32;
                            Color_ARGB = Color.FromArgb(255, (byte)(Math.Min(256, Math.Max(1, ((Color_ARGB.R + 1) * Multiplicador) / 64)) - 1), (byte)(Math.Min(256, Math.Max(1, ((Color_ARGB.G + 1) * Multiplicador) / 64)) - 1), (byte)(Math.Min(256, Math.Max(1, ((Color_ARGB.B + 1) * Multiplicador) / 64)) - 1));
                        }
                        else // From 65 to 128 = Brighter color
                        {
                            int Divisor = (32 - ((Math.Min(128, Y) - 65) / 2)) + 32;
                            Color_ARGB = Color.FromArgb(255, (byte)(Math.Min(256, Math.Max(1, ((Color_ARGB.R + 1) * 64) / Divisor)) - 1), (byte)(Math.Min(256, Math.Max(1, ((Color_ARGB.G + 1) * 64) / Divisor)) - 1), (byte)(Math.Min(256, Math.Max(1, ((Color_ARGB.B + 1) * 64) / Divisor)) - 1));
                        }
                    }*/
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return Color_ARGB;
        }

        internal static Color Obtener_Color_Puro_1530(int Índice)
        {
            if (Índice > -1 && Índice < 1530)
            {
                if (Índice < 255) return Color.FromArgb(255, Índice, 0);
                else if (Índice < 510) return Color.FromArgb(510 - Índice, 255, 0);
                else if (Índice < 765) return Color.FromArgb(0, 255, 255 - (765 - Índice));
                else if (Índice < 1020) return Color.FromArgb(0, 1020 - Índice, 255);
                else if (Índice < 1275) return Color.FromArgb(255 - (1275 - Índice), 0, 255);
                else return Color.FromArgb(255, 0, 1530 - Índice);
            }
            //else if (Índice == 1530) return Color.FromArgb(255, 0, 1);
            return Color.FromArgb(255, 255, 255);
        }

        internal static string Obtener_Nombre_Temporal()
        {
            try
            {
                DateTime Fecha = DateTime.Now;
                string Año = Fecha.Year.ToString();
                string Mes = Fecha.Month.ToString();
                string Día = Fecha.Day.ToString();
                string Hora = Fecha.Hour.ToString();
                string Minuto = Fecha.Minute.ToString();
                string Segundo = Fecha.Second.ToString();
                string Milisegundo = Fecha.Millisecond.ToString();
                while (Año.Length < 4) Año = '0' + Año;
                while (Mes.Length < 2) Mes = '0' + Mes;
                while (Día.Length < 2) Día = '0' + Día;
                while (Hora.Length < 2) Hora = '0' + Hora;
                while (Minuto.Length < 2) Minuto = '0' + Minuto;
                while (Segundo.Length < 2) Segundo = '0' + Segundo;
                while (Milisegundo.Length < 3) Milisegundo = '0' + Milisegundo;
                return Año + "_" + Mes + "_" + Día + "_" + Hora + "_" + Minuto + "_" + Segundo + "_" + Milisegundo;
            }
            catch { }
            return "0000_00_00_00_00_00_000";
        }

        internal static string Obtener_Nombre_Temporal_Sin_Guiones()
        {
            try
            {
                DateTime Fecha = DateTime.Now;
                string Año = Fecha.Year.ToString();
                string Mes = Fecha.Month.ToString();
                string Día = Fecha.Day.ToString();
                string Hora = Fecha.Hour.ToString();
                string Minuto = Fecha.Minute.ToString();
                string Segundo = Fecha.Second.ToString();
                string Milisegundo = Fecha.Millisecond.ToString();
                while (Año.Length < 4) Año = '0' + Año;
                while (Mes.Length < 2) Mes = '0' + Mes;
                while (Día.Length < 2) Día = '0' + Día;
                while (Hora.Length < 2) Hora = '0' + Hora;
                while (Minuto.Length < 2) Minuto = '0' + Minuto;
                while (Segundo.Length < 2) Segundo = '0' + Segundo;
                while (Milisegundo.Length < 3) Milisegundo = '0' + Milisegundo;
                return Año + Mes + Día + Hora + Minuto + Segundo + Milisegundo;
            }
            catch { }
            return "00000000000000000";
        }

        internal static string Traducir_Texto_Mayúsculas_Minúsculas_Automáticamente(string Nombre)
        {
            try
            {
                if (!string.IsNullOrEmpty(Nombre))
                {
                    Nombre = Nombre.ToLowerInvariant();
                    string Texto = null;
                    bool Letra_Anterior = false;
                    for (int Índice_Caracter = 0; Índice_Caracter < Nombre.Length; Índice_Caracter++)
                    {
                        if (char.IsLetter(Nombre[Índice_Caracter]))
                        {
                            if (!Letra_Anterior)
                            {
                                Texto += char.ToUpperInvariant(Nombre[Índice_Caracter]);
                                Letra_Anterior = true;
                            }
                            else
                            {
                                Texto += Nombre[Índice_Caracter];
                                Letra_Anterior = true;
                            }
                        }
                        else
                        {
                            Texto += Nombre[Índice_Caracter];
                            Letra_Anterior = false;
                        }
                    }
                    return Texto;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return Nombre;
        }

        /// <summary>
        /// Useful for testing images and save them near the program to see if they end up looking as intented.
        /// </summary>
        internal static void Guardar_Imagen_Temporal(Image Imagen)
        {
            try
            {
                if (Imagen != null)
                {
                    Imagen.Save(Application.StartupPath + "\\" + Obtener_Nombre_Temporal() + ".png", ImageFormat.Png);
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        /// <summary>
        /// Useful for testing images and save them near the program with the specified name to see if they end up looking as intented.
        /// </summary>
        internal static void Guardar_Imagen_Temporal(Image Imagen, string Nombre_Sin_Extensión)
        {
            Guardar_Imagen_Temporal(Imagen, Nombre_Sin_Extensión, false);
        }

        /// <summary>
        /// Useful for testing images and save them near the program with the specified name to see if they end up looking as intented.
        /// </summary>
        internal static void Guardar_Imagen_Temporal(Image Imagen, string Nombre_Sin_Extensión, bool Sobrescribir)
        {
            try
            {
                if (Imagen != null)
                {
                    if (!string.IsNullOrEmpty(Nombre_Sin_Extensión))
                    {
                        if (!File.Exists(Application.StartupPath + "\\" + Nombre_Sin_Extensión + ".png") || Sobrescribir)
                        {
                            Imagen.Save(Application.StartupPath + "\\" + Nombre_Sin_Extensión + ".png", ImageFormat.Png);
                        }
                    }
                    else Guardar_Imagen_Temporal(Imagen);
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        /// <summary>
        /// Function used to recolor any image or texture using the specified color to replace all of it's pixels.
        /// </summary>
        /// <param name="Imagen">Any valid image in 32 bits ARGB or 24 bits RGB format.</param>
        /// <param name="Color_ARGB">Any valid ARGB color.</param>
        /// <returns>Returns the recolored image. Returns null on any error.</returns>
        internal static Bitmap Recolorear_Imagen(Bitmap Imagen, Color Color_ARGB)
        {
            try
            {
                if (Imagen != null && Color_ARGB != Color.Empty)
                {
                    int Ancho = Imagen.Width;
                    int Alto = Imagen.Height;
                    BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                    byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                    Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                    int Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                    int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                    byte Rojo = Color_ARGB.R;
                    byte Verde = Color_ARGB.G;
                    byte Azul = Color_ARGB.B;
                    for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                    {
                        for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento)
                        {
                            Matriz_Bytes[Índice + 2] = Rojo;
                            Matriz_Bytes[Índice + 1] = Verde;
                            Matriz_Bytes[Índice] = Azul;
                        }
                    }
                    Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                    Imagen.UnlockBits(Bitmap_Data);
                    Bitmap_Data = null;
                    Matriz_Bytes = null;
                    return Imagen;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        /// <summary>
        /// Function used to recolor any image or texture using the specified color to replace it's hue and saturation in the original image, and mix it's lightness with the original in the image. Although this function works for now it's just a patch to recolor certain Minecraft textures like grass block or most plants, among others, so they aren't in grayscale anymore.
        /// </summary>
        /// <param name="Imagen">Any valid image in 32 bits ARGB or 24 bits RGB format.</param>
        /// <param name="Color_ARGB">Any valid ARGB color.</param>
        /// <returns>Returns the recolored image. Returns null on any error.</returns>
        internal static Bitmap Recolorear_Imagen_HSL(Bitmap Imagen, Color Color_ARGB)
        {
            try
            {
                if (Imagen != null && Color_ARGB != Color.Empty)
                {
                    int Ancho = Imagen.Width;
                    int Alto = Imagen.Height;
                    BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                    byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                    Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                    int Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                    int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                    double Matiz, Saturación, Luminosidad;
                    double Matiz_Original, Saturación_Original, Luminosidad_Original;
                    byte Rojo, Verde, Azul;
                    for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                    {
                        for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento)
                        {
                            Program.HSL.From_RGB(Color_ARGB.R, Color_ARGB.G, Color_ARGB.B, out Matiz, out Saturación, out Luminosidad);
                            Program.HSL.From_RGB(Matriz_Bytes[Índice + 2], Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice], out Matiz_Original, out Saturación_Original, out Luminosidad_Original);
                            Program.HSL.To_RGB(Matiz, Saturación, (Luminosidad + Luminosidad_Original) / 2, out Rojo, out Verde, out Azul);
                            Matriz_Bytes[Índice + 2] = Rojo;
                            Matriz_Bytes[Índice + 1] = Verde;
                            Matriz_Bytes[Índice] = Azul;
                        }
                    }
                    Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                    Imagen.UnlockBits(Bitmap_Data);
                    Bitmap_Data = null;
                    Matriz_Bytes = null;
                    return Imagen;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        /// <summary>
        /// 2018_03_05_09_02_42_131
        /// </summary>
        internal static DateTime Traducir_Fecha(string Texto_Fecha)
        {
            try
            {
                if (!string.IsNullOrEmpty(Texto_Fecha))
                {
                    string Texto_Números = null;
                    foreach (char Caracter in Texto_Fecha)
                    {
                        if (char.IsDigit(Caracter)) Texto_Números += Caracter;
                    }
                    if (!string.IsNullOrEmpty(Texto_Números) && Texto_Números.Length >= 17)
                    {
                        int Año = int.Parse(Texto_Números.Substring(0, 4));
                        int Mes = int.Parse(Texto_Números.Substring(4, 2));
                        int Día = int.Parse(Texto_Números.Substring(6, 2));
                        int Hora = int.Parse(Texto_Números.Substring(8, 2));
                        int Minuto = int.Parse(Texto_Números.Substring(10, 2));
                        int Segundo = int.Parse(Texto_Números.Substring(12, 2));
                        int Milisegundo = int.Parse(Texto_Números.Substring(14, 3));
                        return new DateTime(Año, Mes, Día, Hora, Minuto, Segundo, Milisegundo);
                    }
                }
            }
            catch { }
            return DateTime.MinValue;
        }

        internal static string Traducir_Fecha(DateTime Fecha)
        {
            try
            {
                if (Fecha != null && Fecha >= DateTime.MinValue && Fecha <= DateTime.MaxValue)
                {
                    string Año = Fecha.Year.ToString();
                    string Mes = Fecha.Month.ToString();
                    string Día = Fecha.Day.ToString();
                    string Hora = Fecha.Hour.ToString();
                    string Minuto = Fecha.Minute.ToString();
                    string Segundo = Fecha.Second.ToString();
                    string Milisegundo = Fecha.Millisecond.ToString();
                    while (Año.Length < 4) Año = "0" + Año;
                    while (Mes.Length < 2) Mes = "0" + Mes;
                    while (Día.Length < 2) Día = "0" + Día;
                    while (Hora.Length < 2) Hora = "0" + Hora;
                    while (Minuto.Length < 2) Minuto = "0" + Minuto;
                    while (Segundo.Length < 2) Segundo = "0" + Segundo;
                    while (Milisegundo.Length < 3) Milisegundo = "0" + Milisegundo;
                    return Día + "-" + Mes + "-" + Año + ", " + Hora + ":" + Minuto + ":" + Segundo + "." + Milisegundo;
                }
            }
            catch (Exception Excepción) { Application.OnThreadException(Excepción); }
            return "??-??-????, ??:??:??.???";
        }

        internal static string Traducir_Intervalo_Minutos_Segundos(TimeSpan Intervalo)
        {
            try
            {
                string Minutos = Intervalo.Minutes.ToString();
                string Segundos = Intervalo.Seconds.ToString();
                string Milisegundos = Intervalo.Milliseconds.ToString();
                while (Minutos.Length < 2) Minutos = "0" + Minutos;
                while (Segundos.Length < 2) Segundos = "0" + Segundos;
                while (Milisegundos.Length < 3) Milisegundos = "0" + Milisegundos;
                return Minutos + ":" + Segundos + "." + Milisegundos;
            }
            catch (Exception Excepción) { Application.OnThreadException(Excepción); }
            return "00:00.000";
        }

        internal static string Traducir_Número(sbyte Valor)
        {
            return Valor.ToString();
        }

        internal static string Traducir_Número(byte Valor)
        {
            return Valor.ToString();
        }

        internal static string Traducir_Número(short Valor)
        {
            return Valor > -1000 && Valor < 1000 ? Valor.ToString() : Traducir_Número(Valor.ToString());
        }

        internal static string Traducir_Número(ushort Valor)
        {
            return Valor < 1000 ? Valor.ToString() : Traducir_Número(Valor.ToString());
        }

        internal static string Traducir_Número(int Valor)
        {
            return Valor > -1000 && Valor < 1000 ? Valor.ToString() : Traducir_Número(Valor.ToString());
        }

        internal static string Traducir_Número(uint Valor)
        {
            return Valor < 1000 ? Valor.ToString() : Traducir_Número(Valor.ToString());
        }

        internal static string Traducir_Número(long Valor)
        {
            return Valor > -1000L && Valor < 1000L ? Valor.ToString() : Traducir_Número(Valor.ToString());
        }

        internal static string Traducir_Número(ulong Valor)
        {
            return Valor < 1000UL ? Valor.ToString() : Traducir_Número(Valor.ToString());
        }

        internal static string Traducir_Número(float Valor)
        {
            //if (Single.IsNegativeInfinity(Valor)) return "-?";
            //else if (Single.IsPositiveInfinity(Valor)) return "+?";
            //else if (Single.IsNaN(Valor)) return "?";
            if (float.IsInfinity(Valor) || float.IsNaN(Valor)) return "0";
            else return Valor > -1000f && Valor < 1000f ? Valor.ToString().Replace(Caracter_Coma_Decimal, ',') : Traducir_Número(Valor.ToString());
        }

        internal static string Traducir_Número(double Valor)
        {
            //if (Double.IsNegativeInfinity(Valor)) return "-?";
            //else if (Double.IsPositiveInfinity(Valor)) return "+?";
            //else if (Double.IsNaN(Valor)) return "?";
            if (double.IsInfinity(Valor) || double.IsNaN(Valor)) return "0";
            else return Valor > -1000d && Valor < 1000d ? Valor.ToString().Replace(Caracter_Coma_Decimal, ',') : Traducir_Número(Valor.ToString());
        }

        internal static string Traducir_Número(decimal Valor)
        {
            return Valor > -1000m && Valor < 1000m ? Valor.ToString().Replace(Caracter_Coma_Decimal, ',') : Traducir_Número(Valor.ToString());
        }

        internal static string Traducir_Número(string Texto)
        {
            Texto = Texto.Replace(Caracter_Coma_Decimal, ',').Replace(".", null);
            for (int Índice = !Texto.Contains(",") ? Texto.Length - 3 : Texto.IndexOf(',') - 3, Índice_Final = !Texto.StartsWith("-") ? 0 : 1; Índice > Índice_Final; Índice -= 3) Texto = Texto.Insert(Índice, ".");
            return Texto;
            /*Texto = Texto.Replace(Caracter_Coma_Decimal, ',');
            if (Texto.Contains(".")) Texto = Texto.Replace(".", null);
            int Índice = Texto.IndexOf(',');
            for (Índice = Índice < 0 ? Texto.Length - 3 : Índice - 3; Índice > (Texto[0] != '-' ? 0 : 1); Índice -= 3) Texto = Texto.Insert(Índice, ".");
            return Texto;*/
        }

        internal static string Traducir_Número_Decimales_Redondear(double Valor, int Decimales)
        {
            Valor = Math.Round(Valor, Decimales, MidpointRounding.AwayFromZero);
            string Texto = double.IsInfinity(Valor) || double.IsNaN(Valor) ? "0" : Valor > -1000d && Valor < 1000d ? Valor.ToString().Replace(Caracter_Coma_Decimal, ',') : Traducir_Número(Valor.ToString());
            if (Texto.Contains(",") == false) Texto += ',' + new string('0', Decimales);
            else
            {
                Decimales = Decimales - (Texto.Length - (Texto.IndexOf(',') + 1));
                if (Decimales > 0) Texto += new string('0', Decimales);
            }
            return Texto;
        }

        internal static string Traducir_Número_Decimales_Redondear(decimal Valor, int Decimales)
        {
            Valor = Math.Round(Valor, Decimales, MidpointRounding.AwayFromZero);
            string Texto = Valor > -1000m && Valor < 1000m ? Valor.ToString().Replace(Caracter_Coma_Decimal, ',') : Traducir_Número(Valor.ToString());
            if (Texto.Contains(",") == false) Texto += ',' + new string('0', Decimales);
            else
            {
                Decimales -= Texto.Length - (Texto.IndexOf(',') + 1);
                if (Decimales > 0) Texto += new string('0', Decimales);
            }
            return Texto;
        }

        internal static string Traducir_Tamaño_Bytes_Automático(long Tamaño_Bytes, int Decimales, bool Decimales_Cero)
        {
            try
            {
                decimal Valor = (decimal)Tamaño_Bytes;
                int Índice = 0;
                for (; Índice < 7; Índice++)
                {
                    if (Valor < 1024m) break;
                    else Valor = Valor / 1024m;
                }
                string Texto = Traducir_Número(Math.Round(Valor, Decimales, MidpointRounding.AwayFromZero));
                if (Decimales_Cero)
                {
                    if (!Texto.Contains(Caracter_Coma_Decimal.ToString())) Texto += ',' + new string('0', Decimales);
                    else
                    {
                        Decimales = Decimales - (Texto.Length - (Texto.IndexOf(Caracter_Coma_Decimal) + 1));
                        if (Decimales > 0) Texto += new string('0', Decimales);
                    }
                }
                if (Índice == 0) Texto += Tamaño_Bytes == 1L ? " Byte" : " Bytes";
                else if (Índice == 1) Texto += " KB";
                else if (Índice == 2) Texto += " MB";
                else if (Índice == 3) Texto += " GB";
                else if (Índice == 4) Texto += " TB";
                else if (Índice == 5) Texto += " PB";
                else if (Índice == 6) Texto += " EB";
                return Texto;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return "? Bytes";
        }

        internal static readonly uint[] Matriz_CRC32 = new uint[256]
        {
            0x00000000, 0x77073096, 0xEE0E612C, 0x990951BA, 0x076DC419,
            0x706AF48F, 0xE963A535, 0x9E6495A3, 0x0EDB8832, 0x79DCB8A4,
            0xE0D5E91E, 0x97D2D988, 0x09B64C2B, 0x7EB17CBD, 0xE7B82D07,
            0x90BF1D91, 0x1DB71064, 0x6AB020F2, 0xF3B97148, 0x84BE41DE,
            0x1ADAD47D, 0x6DDDE4EB, 0xF4D4B551, 0x83D385C7, 0x136C9856,
            0x646BA8C0, 0xFD62F97A, 0x8A65C9EC, 0x14015C4F, 0x63066CD9,
            0xFA0F3D63, 0x8D080DF5, 0x3B6E20C8, 0x4C69105E, 0xD56041E4,
            0xA2677172, 0x3C03E4D1, 0x4B04D447, 0xD20D85FD, 0xA50AB56B,
            0x35B5A8FA, 0x42B2986C, 0xDBBBC9D6, 0xACBCF940, 0x32D86CE3,
            0x45DF5C75, 0xDCD60DCF, 0xABD13D59, 0x26D930AC, 0x51DE003A,
            0xC8D75180, 0xBFD06116, 0x21B4F4B5, 0x56B3C423, 0xCFBA9599,
            0xB8BDA50F, 0x2802B89E, 0x5F058808, 0xC60CD9B2, 0xB10BE924,
            0x2F6F7C87, 0x58684C11, 0xC1611DAB, 0xB6662D3D, 0x76DC4190,
            0x01DB7106, 0x98D220BC, 0xEFD5102A, 0x71B18589, 0x06B6B51F,
            0x9FBFE4A5, 0xE8B8D433, 0x7807C9A2, 0x0F00F934, 0x9609A88E,
            0xE10E9818, 0x7F6A0DBB, 0x086D3D2D, 0x91646C97, 0xE6635C01,
            0x6B6B51F4, 0x1C6C6162, 0x856530D8, 0xF262004E, 0x6C0695ED,
            0x1B01A57B, 0x8208F4C1, 0xF50FC457, 0x65B0D9C6, 0x12B7E950,
            0x8BBEB8EA, 0xFCB9887C, 0x62DD1DDF, 0x15DA2D49, 0x8CD37CF3,
            0xFBD44C65, 0x4DB26158, 0x3AB551CE, 0xA3BC0074, 0xD4BB30E2,
            0x4ADFA541, 0x3DD895D7, 0xA4D1C46D, 0xD3D6F4FB, 0x4369E96A,
            0x346ED9FC, 0xAD678846, 0xDA60B8D0, 0x44042D73, 0x33031DE5,
            0xAA0A4C5F, 0xDD0D7CC9, 0x5005713C, 0x270241AA, 0xBE0B1010,
            0xC90C2086, 0x5768B525, 0x206F85B3, 0xB966D409, 0xCE61E49F,
            0x5EDEF90E, 0x29D9C998, 0xB0D09822, 0xC7D7A8B4, 0x59B33D17,
            0x2EB40D81, 0xB7BD5C3B, 0xC0BA6CAD, 0xEDB88320, 0x9ABFB3B6,
            0x03B6E20C, 0x74B1D29A, 0xEAD54739, 0x9DD277AF, 0x04DB2615,
            0x73DC1683, 0xE3630B12, 0x94643B84, 0x0D6D6A3E, 0x7A6A5AA8,
            0xE40ECF0B, 0x9309FF9D, 0x0A00AE27, 0x7D079EB1, 0xF00F9344,
            0x8708A3D2, 0x1E01F268, 0x6906C2FE, 0xF762575D, 0x806567CB,
            0x196C3671, 0x6E6B06E7, 0xFED41B76, 0x89D32BE0, 0x10DA7A5A,
            0x67DD4ACC, 0xF9B9DF6F, 0x8EBEEFF9, 0x17B7BE43, 0x60B08ED5,
            0xD6D6A3E8, 0xA1D1937E, 0x38D8C2C4, 0x4FDFF252, 0xD1BB67F1,
            0xA6BC5767, 0x3FB506DD, 0x48B2364B, 0xD80D2BDA, 0xAF0A1B4C,
            0x36034AF6, 0x41047A60, 0xDF60EFC3, 0xA867DF55, 0x316E8EEF,
            0x4669BE79, 0xCB61B38C, 0xBC66831A, 0x256FD2A0, 0x5268E236,
            0xCC0C7795, 0xBB0B4703, 0x220216B9, 0x5505262F, 0xC5BA3BBE,
            0xB2BD0B28, 0x2BB45A92, 0x5CB36A04, 0xC2D7FFA7, 0xB5D0CF31,
            0x2CD99E8B, 0x5BDEAE1D, 0x9B64C2B0, 0xEC63F226, 0x756AA39C,
            0x026D930A, 0x9C0906A9, 0xEB0E363F, 0x72076785, 0x05005713,
            0x95BF4A82, 0xE2B87A14, 0x7BB12BAE, 0x0CB61B38, 0x92D28E9B,
            0xE5D5BE0D, 0x7CDCEFB7, 0x0BDBDF21, 0x86D3D2D4, 0xF1D4E242,
            0x68DDB3F8, 0x1FDA836E, 0x81BE16CD, 0xF6B9265B, 0x6FB077E1,
            0x18B74777, 0x88085AE6, 0xFF0F6A70, 0x66063BCA, 0x11010B5C,
            0x8F659EFF, 0xF862AE69, 0x616BFFD3, 0x166CCF45, 0xA00AE278,
            0xD70DD2EE, 0x4E048354, 0x3903B3C2, 0xA7672661, 0xD06016F7,
            0x4969474D, 0x3E6E77DB, 0xAED16A4A, 0xD9D65ADC, 0x40DF0B66,
            0x37D83BF0, 0xA9BCAE53, 0xDEBB9EC5, 0x47B2CF7F, 0x30B5FFE9,
            0xBDBDF21C, 0xCABAC28A, 0x53B39330, 0x24B4A3A6, 0xBAD03605,
            0xCDD70693, 0x54DE5729, 0x23D967BF, 0xB3667A2E, 0xC4614AB8,
            0x5D681B02, 0x2A6F2B94, 0xB40BBE37, 0xC30C8EA1, 0x5A05DF1B,
            0x2D02EF8D
        };

        /// <summary>
        /// Calcula el CRC de 32 bits de la matriz de bytes indicada.
        /// </summary>
        internal static uint Calcular_CRC32(Byte[] Matriz_Bytes)
        {
            if (Matriz_Bytes == null) return 0;
            uint CRC_32_Bits = 0xFFFFFFFF;
            for (int Índice = 0; Índice < Matriz_Bytes.Length; Índice++) CRC_32_Bits = Matriz_CRC32[(Byte)(CRC_32_Bits ^ Matriz_Bytes[Índice])] ^ (CRC_32_Bits >> 8);
            return ~CRC_32_Bits;
        }

        /// <summary>
        /// Calcula el CRC de 32 bits de la matriz de bytes indicada.
        /// </summary>
        internal static uint Calcular_CRC32(Byte[] Matriz_Bytes, int Longitud)
        {
            if (Matriz_Bytes == null || Matriz_Bytes.Length <= 0) return 0;
            else if (Longitud <= 0) Longitud = Matriz_Bytes.Length;
            uint Valor_CRC32 = 0xFFFFFFFF;
            for (int Índice = 0; Índice < Longitud; Índice++) Valor_CRC32 = Matriz_CRC32[(Byte)(Valor_CRC32 ^ Matriz_Bytes[Índice])] ^ (Valor_CRC32 >> 8);
            return ~Valor_CRC32;
        }

        /// <summary>
        /// Calcula el CRC de 32 bits de la matriz de bytes indicada, continuando desde un valor anterior que debe iniciarse por primera vez en cero.
        /// </summary>
        internal static uint Calcular_CRC32(Byte[] Matriz_Bytes, int Longitud, uint Valor_CRC32)
        {
            if (Matriz_Bytes == null || Matriz_Bytes.Length <= 0) return 0;
            else if (Longitud <= 0) Longitud = Matriz_Bytes.Length;
            Valor_CRC32 = ~Valor_CRC32;
            for (int Índice = 0; Índice < Longitud; Índice++) Valor_CRC32 = Matriz_CRC32[(Byte)(Valor_CRC32 ^ Matriz_Bytes[Índice])] ^ (Valor_CRC32 >> 8);
            return ~Valor_CRC32;
        }

        /// <summary>
        /// Calcula el CRC de 32 bits del archivo indicado, excluyendo el propio CRC 32 ya almacenado.
        /// </summary>
        internal static uint Calcular_CRC32_Sin_CRC_32(String Ruta)
        {
            uint Valor_CRC32 = 0xFFFFFFFF;
            FileStream Lector = new FileStream(Ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            if (Lector.Length > 4L)
            {
                Byte[] Matriz_Bytes = new Byte[4096];
                for (long Índice = 0L; Índice < Lector.Length; Índice += 4096L)
                {
                    int Longitud = Lector.Read(Matriz_Bytes, 0, 4096);
                    for (int Subíndice = 0; Subíndice < Longitud; Subíndice++) if (Índice + Subíndice < Lector.Length - 4) Valor_CRC32 = Matriz_CRC32[(Byte)(Valor_CRC32 ^ Matriz_Bytes[Subíndice])] ^ (Valor_CRC32 >> 8);
                }
                Matriz_Bytes = null;
            }
            Lector.Close();
            Lector.Dispose();
            return ~Valor_CRC32;
        }

        /// <summary>
        /// Calcula el CRC de 32 bits del archivo indicado.
        /// </summary>
        internal static uint Calcular_CRC32(String Ruta)
        {
            uint Valor_CRC32 = 0xFFFFFFFF;
            FileStream Lector = new FileStream(Ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Byte[] Matriz_Bytes = new Byte[4096];
            for (long Índice = 0L; Índice < Lector.Length; Índice += 4096L)
            {
                int Longitud = Lector.Read(Matriz_Bytes, 0, 4096);
                for (int Subíndice = 0; Subíndice < Longitud; Subíndice++) Valor_CRC32 = Matriz_CRC32[(Byte)(Valor_CRC32 ^ Matriz_Bytes[Subíndice])] ^ (Valor_CRC32 >> 8);
            }
            Matriz_Bytes = null;
            Lector.Close();
            Lector.Dispose();
            return ~Valor_CRC32;
        }

        /// <summary>
        /// Creates all the directories is the specified path if they don't exist yet, without showing any exception.
        /// </summary>
        /// <param name="Ruta">Any valid directory path.</param>
        /// <returns>Returns true if the specified directories in the path now exist. Returns false on any exception, possibly indicating that the directories might not exist.</returns>
        internal static bool Crear_Carpetas(string Ruta)
        {
            try
            {
                if (!Directory.Exists(Ruta))
                {
                    Directory.CreateDirectory(Ruta);
                    return true;
                }
                else return true;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return false;
        }

        /// <summary>
        /// Deletes an existing file or directory and it's subfolders.
        /// </summary>
        /// <param name="Ruta">Any valid file or directory path.</param>
        /// <returns>Returns true if the file or directory doesn't exist anymore. Returns false on any error.</returns>
        internal static bool Eliminar_Archivo_Carpeta(string Ruta)
        {
            try
            {
                Eliminar_Archivo_Carpeta(Ruta, true);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return false;
        }

        /// <summary>
        /// Deletes an existing file or directory.
        /// </summary>
        /// <param name="Ruta">Any valid file or directory path.</param>
        /// <param name="Eliminar_Subcarpetas">True to delete all the subfolders.</param>
        /// <returns>Returns true if the file or directory doesn't exist anymore. Returns false on any error.</returns>
        internal static bool Eliminar_Archivo_Carpeta(string Ruta, bool Eliminar_Subcarpetas)
        {
            try
            {
                if (!string.IsNullOrEmpty(Ruta) && (File.Exists(Ruta) || Directory.Exists(Ruta)))
                {
                    try { Quitar_Atributo_Sólo_Lectura(Ruta); }
                    catch { }
                    try
                    {
                        if (File.Exists(Ruta)) File.Delete(Ruta);
                        else Directory.Delete(Ruta, Eliminar_Subcarpetas);
                    }
                    catch { }
                }
                if (string.IsNullOrEmpty(Ruta) || !File.Exists(Ruta)) return true;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return false;
        }

        /// <summary>
        /// This function makes sure that the selected file or directory doesn't have a read-only attribute, and if it does, tries to remove it automatically.
        /// </summary>
        /// <param name="Ruta">Any valid and existing file or directory path.</param>
        internal static void Quitar_Atributo_Sólo_Lectura(string Ruta)
        {
            try
            {
                if (!string.IsNullOrEmpty(Ruta) && (File.Exists(Ruta) || Directory.Exists(Ruta)))
                {
                    FileSystemInfo Info = File.Exists(Ruta) ? (FileSystemInfo)new FileInfo(Ruta) : (FileSystemInfo)new DirectoryInfo(Ruta);
                    FileAttributes Atributos = Info.Attributes;
                    if ((Atributos & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        Atributos -= FileAttributes.ReadOnly;
                        if (Atributos <= 0) Atributos |= FileAttributes.Normal;
                        Info.Attributes = Atributos;
                    }
                    Info = null;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        /// <summary>
        /// Executes the specified file, directory or URL, with the specified window style.
        /// </summary>
        /// <param name="Ruta">Any valid file or directory path.</param>
        /// <param name="Estado">Any valid window style.</param>
        /// <returns>Returns true if the process can be executed. Returns false if it can't be executed.</returns>
        internal static bool Ejecutar_Ruta(string Ruta, ProcessWindowStyle Estado)
        {
            try
            {
                if (!string.IsNullOrEmpty(Ruta))
                {
                    Process Proceso = new Process();
                    Proceso.StartInfo.Arguments = null;
                    Proceso.StartInfo.ErrorDialog = false;
                    Proceso.StartInfo.FileName = Ruta;
                    Proceso.StartInfo.UseShellExecute = true;
                    Proceso.StartInfo.Verb = "open";
                    Proceso.StartInfo.WindowStyle = Estado;
                    if (File.Exists(Ruta)) Proceso.StartInfo.WorkingDirectory = Ruta;
                    else if (Directory.Exists(Ruta)) Proceso.StartInfo.WorkingDirectory = Ruta;
                    bool Resultado;
                    try { Resultado = Proceso.Start(); }
                    catch { Resultado = false; }
                    Proceso.Close();
                    Proceso.Dispose();
                    Proceso = null;
                    return Resultado;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return false;
        }

        internal static Bitmap Obtener_Imagen_Autozoom(Bitmap Imagen_Original, int Ancho_Cliente, int Alto_Cliente, bool Autozoom, CheckState Antialiasing, out int Zoom)
        {
            Zoom = 1;
            try
            {
                if (Imagen_Original != null && Autozoom)
                {
                    int Ancho = Imagen_Original.Width;
                    int Alto = Imagen_Original.Height;
                    if (Ancho_Cliente <= 0) Ancho_Cliente = 1;
                    if (Alto_Cliente <= 0) Alto_Cliente = 1;
                    int Ancho_Zoom = Ancho_Cliente / Ancho;
                    int Alto_Zoom = Alto_Cliente / Alto;
                    Zoom = Math.Max(Math.Min(Ancho_Zoom, Alto_Zoom), 1);
                    Ancho_Zoom = Ancho * Zoom;
                    Alto_Zoom = Alto * Zoom;
                    Bitmap Imagen = new Bitmap(Ancho_Zoom, Alto_Zoom, PixelFormat.Format32bppArgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    //Pintar.Clear(Color.Black);
                    Pintar.CompositingMode = CompositingMode.SourceOver;
                    Pintar.CompositingQuality = CompositingQuality.HighQuality;
                    Pintar.InterpolationMode = Antialiasing == CheckState.Unchecked ? InterpolationMode.NearestNeighbor : Antialiasing == CheckState.Checked ? InterpolationMode.HighQualityBilinear : InterpolationMode.HighQualityBicubic;
                    Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Pintar.SmoothingMode = SmoothingMode.None;
                    Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho_Zoom, Alto_Zoom), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                    Pintar.Dispose();
                    Pintar = null;
                    return Imagen;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return Imagen_Original;
        }

        internal static Bitmap Obtener_Imagen_Zoom(Bitmap Imagen_Original, int Zoom, CheckState Antialiasing)
        {
            try
            {
                if (Zoom < 1) Zoom = 1;
                int Ancho = Imagen_Original.Width;
                int Alto = Imagen_Original.Height;
                int Ancho_Zoom = Ancho * Zoom;
                int Alto_Zoom = Alto * Zoom;
                Bitmap Imagen = new Bitmap(Ancho_Zoom, Alto_Zoom, PixelFormat.Format32bppArgb);
                Graphics Pintar = Graphics.FromImage(Imagen);
                Pintar.Clear(Color.Black);
                Pintar.CompositingMode = CompositingMode.SourceOver;
                Pintar.CompositingQuality = CompositingQuality.HighQuality;
                Pintar.InterpolationMode = Antialiasing == CheckState.Unchecked ? InterpolationMode.NearestNeighbor : Antialiasing == CheckState.Checked ? InterpolationMode.HighQualityBilinear : InterpolationMode.HighQualityBicubic;
                Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Pintar.SmoothingMode = SmoothingMode.None;
                Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho_Zoom, Alto_Zoom), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                Pintar.Dispose();
                Pintar = null;
                return Imagen;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return Imagen_Original;
        }

        internal static Bitmap Obtener_Imagen_Color(Color Color_ARGB)
        {
            try
            {
                Bitmap Imagen = new Bitmap(16, 16, PixelFormat.Format24bppRgb);
                Graphics Pintar = Graphics.FromImage(Imagen);
                if (Color_ARGB.A < 255)
                {
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    //Pintar.DrawImage(Resources.Fondo, new Rectangle(0, 0, 16, 16), new Rectangle(0, 0, 16, 16), GraphicsUnit.Pixel);
                    Pintar.DrawImage(Resources.Fondo, new Rectangle(1, 1, 14, 14), new Rectangle(1, 1, 14, 14), GraphicsUnit.Pixel);
                }
                Pintar.CompositingMode = CompositingMode.SourceOver;
                SolidBrush Pincel = new SolidBrush(Color_ARGB);
                //Pintar.FillRectangle(Pincel, 0, 0, 16, 16);
                Pintar.FillRectangle(Pincel, 1, 1, 14, 14);
                Pincel.Dispose();
                Pincel = null;
                Pintar.Dispose();
                Pintar = null;
                return Imagen;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        /// <summary>
        /// Obtains a miniature (or any size really) from any valid image, keeping it's original aspect ratio if desired.
        /// </summary>
        /// <param name="Imagen_Original">Any valid image.</param>
        /// <param name="Ancho_Miniatura">The desired width of the miniature.</param>
        /// <param name="Alto_Miniatura">The desired height of the miniature.</param>
        /// <param name="Relación_Aspecto">If true the miniature will keep the original aspect ratio.</param>
        /// <param name="Antialiasing">If true the miniature will be drawn with high interpolation, reducing the alias effect, at the cost of getting a bit blurred.</param>
        /// <returns>Returns the miniature drawn with the specified options. On any error it will return null.</returns>
        internal static Bitmap Obtener_Imagen_Miniatura(Image Imagen_Original, int Ancho_Miniatura, int Alto_Miniatura, bool Relación_Aspecto, bool Antialiasing)
        {
            try
            {
                if (Imagen_Original != null)
                {
                    int Ancho_Original = Imagen_Original.Width;
                    int Alto_Original = Imagen_Original.Height;
                    int Ancho = Ancho_Miniatura;
                    int Alto = Alto_Miniatura;
                    if (Relación_Aspecto) // Keep the original aspect ratio.
                    {
                        Ancho = (Alto_Miniatura * Ancho_Original) / Alto_Original;
                        Alto = (Ancho_Miniatura * Alto_Original) / Ancho_Original;
                        if (Ancho <= Ancho_Miniatura) Alto = Alto_Miniatura;
                        else if (Alto <= Alto_Miniatura) Ancho = Ancho_Miniatura;
                    }
                    if (Ancho < 1) Ancho = 1;
                    if (Alto < 1) Alto = 1;
                    Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    //Pintar.Clear(Color.Black);
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    Pintar.CompositingQuality = CompositingQuality.HighQuality;
                    Pintar.InterpolationMode = !Antialiasing ? InterpolationMode.NearestNeighbor : InterpolationMode.HighQualityBicubic;
                    Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Pintar.SmoothingMode = SmoothingMode.None;
                    Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho_Original, Alto_Original), GraphicsUnit.Pixel);
                    Pintar.Dispose();
                    Pintar = null;
                    return Imagen;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static Bitmap Obtener_Imagen_Alfa_Brillo(Bitmap Imagen)
        {
            if (Imagen != null && Image.IsAlphaPixelFormat(Imagen.PixelFormat))
            {
                int Ancho = Imagen.Width;
                int Alto = Imagen.Height;
                BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Imagen.Width, Imagen.Height), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                int Ancho_Stride = Math.Abs(Bitmap_Data.Stride);
                int Bytes_Aumento = !Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 3 : 4;
                int Bytes_Diferencia = Ancho_Stride - ((Imagen.Width * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                byte[] Matriz_Bytes = new byte[Ancho_Stride * Imagen.Height];
                Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                {
                    for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento)
                    {
                        int Valor = (Matriz_Bytes[Índice + 2] + Matriz_Bytes[Índice + 1] + Matriz_Bytes[Índice]) / 3;
                        Matriz_Bytes[Índice + 3] = (byte)Valor;
                    }
                }
                Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                Imagen.UnlockBits(Bitmap_Data);
                Matriz_Bytes = null;
            }
            return Imagen;
        }

        /// <summary>
        /// Replaces any non transparent ARGB color by the selected one on any valid image.
        /// </summary>
        /// <param name="Imagen">Any valid image.</param>
        /// <param name="Color_ARGB">The color to replace.</param>
        /// <returns>Returns the repainted image. Returns null on any error.</returns>
        internal static Bitmap Obtener_Imagen_Pintada(Bitmap Imagen, Color Color_ARGB)
        {
            if (Imagen != null && Image.IsAlphaPixelFormat(Imagen.PixelFormat))
            {
                int Ancho = Imagen.Width;
                int Alto = Imagen.Height;
                BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Imagen.Width, Imagen.Height), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                int Ancho_Stride = Math.Abs(Bitmap_Data.Stride);
                int Bytes_Aumento = !Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 3 : 4;
                int Bytes_Diferencia = Ancho_Stride - ((Imagen.Width * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                byte[] Matriz_Bytes = new byte[Ancho_Stride * Imagen.Height];
                Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                {
                    for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento)
                    {
                        if (Matriz_Bytes[Índice + 3] >= 255) // Not a transparent pixel
                        {
                            Matriz_Bytes[Índice + 2] = Color_ARGB.R;
                            Matriz_Bytes[Índice + 1] = Color_ARGB.G;
                            Matriz_Bytes[Índice] = Color_ARGB.B;
                        }
                    }
                }
                Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                Imagen.UnlockBits(Bitmap_Data);
                Matriz_Bytes = null;
            }
            return Imagen;
        }

        /// <summary>
        /// Replaces the desired ARGB color by the selected one on any valid image.
        /// </summary>
        /// <param name="Imagen">Any valid image.</param>
        /// <param name="Color_ARGB_Origen">The color to find.</param>
        /// <param name="Color_ARGB">The color to replace.</param>
        /// <returns>Returns the repainted image. Returns null on any error.</returns>
        internal static Bitmap Obtener_Imagen_Pintada(Bitmap Imagen, Color Color_ARGB_Origen, Color Color_ARGB)
        {
            if (Imagen != null && Image.IsAlphaPixelFormat(Imagen.PixelFormat))
            {
                byte Alfa = Color_ARGB_Origen.A;
                byte Rojo = Color_ARGB_Origen.R;
                byte Verde = Color_ARGB_Origen.G;
                byte Azul = Color_ARGB_Origen.B;
                int Ancho = Imagen.Width;
                int Alto = Imagen.Height;
                BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Imagen.Width, Imagen.Height), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                int Ancho_Stride = Math.Abs(Bitmap_Data.Stride);
                int Bytes_Aumento = !Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 3 : 4;
                int Bytes_Diferencia = Ancho_Stride - ((Imagen.Width * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                byte[] Matriz_Bytes = new byte[Ancho_Stride * Imagen.Height];
                Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                {
                    for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento)
                    {
                        if (Matriz_Bytes[Índice + 3] == Alfa && Matriz_Bytes[Índice + 2] == Rojo && Matriz_Bytes[Índice + 1] == Verde && Matriz_Bytes[Índice] == Azul) // It's the same color, so replace it.
                        {
                            Matriz_Bytes[Índice + 3] = Color_ARGB.A;
                            Matriz_Bytes[Índice + 2] = Color_ARGB.R;
                            Matriz_Bytes[Índice + 1] = Color_ARGB.G;
                            Matriz_Bytes[Índice] = Color_ARGB.B;
                        }
                    }
                }
                Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                Imagen.UnlockBits(Bitmap_Data);
                Matriz_Bytes = null;
            }
            return Imagen;
        }

        /// <summary>
        /// Obtains a Minecraft texture form the application resources based on the specified name, which should start with "minecraft_".
        /// </summary>
        /// <param name="Nombre_Textura">The name of an existing texture in the application resources.</param>
        /// <returns>Returns an image from the resources. Returns null if the texture doesn't exist and on any error.</returns>
        internal static Bitmap Obtener_Imagen_Recursos(string Nombre_Textura)
        {
            try
            {
                Bitmap Imagen_Original = null;
                try { Imagen_Original = (Bitmap)Resources.ResourceManager.GetObject(Nombre_Textura.Replace(' ', '_').Replace('~', '_').Replace('=', '_').Replace('+', '_').Replace('-', '_').Replace('\\', '_').Replace('/', '_').Replace(':', '_').Replace('*', '_').Replace('?', '_').Replace('\"', '_').Replace('<', '_').Replace('>', '_').Replace('|', '_').Replace('.', '_')); }
                catch { Imagen_Original = null; }
                if (Imagen_Original != null)
                {
                    if (Imagen_Original.PixelFormat == PixelFormat.Format32bppArgb) return Imagen_Original;
                    else
                    {
                        int Ancho = Imagen_Original.Width;
                        int Alto = Imagen_Original.Height;
                        Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                        Graphics Pintar = Graphics.FromImage(Imagen);
                        Pintar.CompositingMode = CompositingMode.SourceCopy;
                        Pintar.CompositingQuality = CompositingQuality.HighQuality;
                        Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Pintar.SmoothingMode = SmoothingMode.None;
                        Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                        Pintar.Dispose();
                        Pintar = null;
                        Imagen_Original.Dispose();
                        Imagen_Original = null;
                        return Imagen;
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        /// <summary>
        /// Loads an image into memory from any valid existing file.
        /// </summary>
        /// <param name="Ruta">Any valid existing filepath.</param>
        /// <returns>Returns the loaded image converted to a valid format. Returns null on any error.</returns>
        internal static Bitmap Obtener_Imagen_Ruta(string Ruta)
        {
            try
            {
                if (!string.IsNullOrEmpty(Ruta) && File.Exists(Ruta))
                {
                    FileStream Lector = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                    if (Lector != null && Lector.Length > 0L)
                    {
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
                            Imagen_Original.Dispose();
                            Imagen_Original = null;
                            Lector.Close();
                            Lector.Dispose();
                            Lector = null;
                            return Imagen;
                        }
                        Lector.Close();
                        Lector.Dispose();
                        Lector = null;
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        /// <summary>
        /// Draws a full Minecraft skin viewed from the front. Note that the hair pixels needs to be bigger than the rest, so to draw it properly the skin needs to have a minimum zoom of 4. The skin images without zoom should have about 16 x 32 pixels.
        /// </summary>
        /// <param name="Imagen_Original">Any valid skin image of 32 x 32 or 64 x 64 pixels.</param>
        /// <param name="Dibujar_Pelo">If true, the hair will be drawn.</param>
        /// <param name="Dibujar_Chaqueta">If true, the jacket will be drawn.</param>
        /// <param name="Dibujar_Brazos_Chaqueta">If true, the jacket's arms will be drawn.</param>
        /// <param name="Dibujar_Pantalones">If true, the pants will be drawn.</param>
        /// <returns>Returns a new image containing the skin viewed from the front with a zoom of 4x. Returns null on any error.</returns>
        internal static Bitmap Obtener_Imagen_Skin_2D(Bitmap Imagen_Original, bool Dibujar_Pelo, bool Dibujar_Chaqueta, bool Dibujar_Brazos_Chaqueta, bool Dibujar_Pantalones)
        {
            try
            {
                if (Imagen_Original != null)
                {
                    double Multiplicador = 7.5d; // Tweaked by hand, might not be fully accurate.
                    double Multiplicador_Pelo = 9.25d; // Tweaked by hand, might not be fully accurate.
                    double Diferencia_Pelo = (8d * (Multiplicador_Pelo - Multiplicador)) / 2d; // Tweaked by hand, might not be fully accurate.
                    double Diferencia_Pelo_Superior = (8d * (Multiplicador_Pelo - Multiplicador)) / 1.75d; // Tweaked by hand, might not be fully accurate.
                    Bitmap Imagen = new Bitmap((int)Math.Round(16d * Multiplicador, MidpointRounding.AwayFromZero), (int)Math.Round((32d * Multiplicador) + Diferencia_Pelo_Superior, MidpointRounding.AwayFromZero), PixelFormat.Format32bppArgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    Pintar.CompositingQuality = CompositingQuality.HighQuality;
                    Pintar.InterpolationMode = InterpolationMode.NearestNeighbor;
                    Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Pintar.SmoothingMode = SmoothingMode.HighQuality;
                    if (Imagen_Original.Height >= 64)
                    {
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)Diferencia_Pelo_Superior, (float)(8d * Multiplicador), (float)(8d * Multiplicador)), new RectangleF(8f, 8f, 8f, 8f), GraphicsUnit.Pixel); // Head
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(8d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(20f, 20f, 8f, 12f), GraphicsUnit.Pixel); // Body
                        Pintar.DrawImage(Imagen_Original, new RectangleF(0f, (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(36f, 52f, 4f, 12f), GraphicsUnit.Pixel); // Left arm
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(12d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(44f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Right arm
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(20f, 52f, 4f, 12f), GraphicsUnit.Pixel); // Left leg
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(8d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(4f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Right leg

                        Pintar.CompositingMode = CompositingMode.SourceOver; // Overlay
                        if (Dibujar_Pelo) Pintar.DrawImage(Imagen_Original, new RectangleF((float)((4d * Multiplicador) - Diferencia_Pelo), 0f, (float)(8d * Multiplicador_Pelo), (float)(8d * Multiplicador_Pelo)), new RectangleF(40f, 8f, 8f, 8f), GraphicsUnit.Pixel); // Hair
                        if (Dibujar_Chaqueta) Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(8d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(20f, 36f, 8f, 12f), GraphicsUnit.Pixel); // Jacket
                        if (Dibujar_Brazos_Chaqueta)
                        {
                            Pintar.DrawImage(Imagen_Original, new RectangleF(0f, (float)((8 * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(52f, 52f, 4f, 12f), GraphicsUnit.Pixel); // Left jacket arm
                            Pintar.DrawImage(Imagen_Original, new RectangleF((float)(12d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(44f, 36f, 4f, 12f), GraphicsUnit.Pixel); // Right jacket arm
                        }
                        if (Dibujar_Pantalones)
                        {
                            Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(4f, 52f, 4f, 12f), GraphicsUnit.Pixel); // Left pants leg
                            Pintar.DrawImage(Imagen_Original, new RectangleF((float)(8d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(4f, 36f, 4f, 12f), GraphicsUnit.Pixel); // Right pants leg
                        }
                    }
                    else // 32
                    {
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)Diferencia_Pelo_Superior, (float)(8d * Multiplicador), (float)(8d * Multiplicador)), new RectangleF(8f, 8f, 8f, 8f), GraphicsUnit.Pixel); // Head
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(8d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(20f, 20f, 8f, 12f), GraphicsUnit.Pixel); // Body
                        Pintar.DrawImage(Imagen_Original, new RectangleF(0f, (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(44f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Left arm
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(4f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Left leg
                        Imagen_Original.RotateFlip(RotateFlipType.RotateNoneFlipX); // Flip the image.
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(12d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(16f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Right arm
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(8d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(56f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Right leg
                        Imagen_Original.RotateFlip(RotateFlipType.RotateNoneFlipX); // Restore the image.

                        Pintar.CompositingMode = CompositingMode.SourceOver; // Overlay
                        if (Dibujar_Pelo) Pintar.DrawImage(Imagen_Original, new RectangleF((float)((4d * Multiplicador) - Diferencia_Pelo), 0f, (float)(8d * Multiplicador_Pelo), (float)(8d * Multiplicador_Pelo)), new RectangleF(40f, 8f, 8f, 8f), GraphicsUnit.Pixel); // Hair
                    }
                    Pintar.Dispose();
                    Pintar = null;
                    return Imagen;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        /// <summary>
        /// Draws a full Minecraft skin viewed from the front. Note that the hair pixels needs to be bigger than the rest, so to draw it properly the skin needs to have a minimum zoom of 4. The skin images without zoom should have 16 x 32 pixels.
        /// </summary>
        /// <param name="Imagen_Original">Any valid skin image of 32 x 32 or 64 x 64 pixels.</param>
        /// <param name="Dibujar_Pelo">If true, the hair will be drawn.</param>
        /// <param name="Dibujar_Chaqueta">If true, the jacket will be drawn.</param>
        /// <param name="Dibujar_Brazos_Chaqueta">If true, the jacket's arms will be drawn.</param>
        /// <param name="Dibujar_Pantalones">If true, the pants will be drawn.</param>
        /// <returns>Returns a new image containing the skin viewed from the front with a zoom of 4x. Returns null on any error.</returns>
        internal static Bitmap Obtener_Imagen_Skin_2D_Dual(Bitmap Imagen_Original, bool Dibujar_Pelo, bool Dibujar_Chaqueta, bool Dibujar_Brazos_Chaqueta, bool Dibujar_Pantalones)
        {
            try // Note: this function is unfinished, use the above one...
            {
                if (Imagen_Original != null)
                {
                    double Multiplicador = 7.5d; // Tweaked by hand, might not be fully accurate.
                    double Multiplicador_Pelo = 9.25d; // Tweaked by hand, might not be fully accurate.
                    double Diferencia_Pelo = (8d * (Multiplicador_Pelo - Multiplicador)) / 2d; // Tweaked by hand, might not be fully accurate.
                    double Diferencia_Pelo_Superior = (8d * (Multiplicador_Pelo - Multiplicador)) / 1.75d; // Tweaked by hand, might not be fully accurate.
                    Bitmap Imagen = new Bitmap((int)Math.Round(16d * Multiplicador, MidpointRounding.AwayFromZero), (int)Math.Round((32d * Multiplicador) + Diferencia_Pelo_Superior, MidpointRounding.AwayFromZero), PixelFormat.Format32bppArgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    Pintar.CompositingQuality = CompositingQuality.HighQuality;
                    Pintar.InterpolationMode = InterpolationMode.NearestNeighbor;
                    Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Pintar.SmoothingMode = SmoothingMode.HighQuality;
                    if (Imagen_Original.Height >= 64)
                    {
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)Diferencia_Pelo_Superior, (float)(8d * Multiplicador), (float)(8d * Multiplicador)), new RectangleF(8f, 8f, 8f, 8f), GraphicsUnit.Pixel); // Head
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(8d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(20f, 20f, 8f, 12f), GraphicsUnit.Pixel); // Body
                        Pintar.DrawImage(Imagen_Original, new RectangleF(0f, (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(36f, 52f, 4f, 12f), GraphicsUnit.Pixel); // Left arm
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(12d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(44f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Right arm
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(20f, 52f, 4f, 12f), GraphicsUnit.Pixel); // Left leg
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(8d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(4f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Right leg

                        Pintar.CompositingMode = CompositingMode.SourceOver; // Overlay
                        if (Dibujar_Pelo) Pintar.DrawImage(Imagen_Original, new RectangleF((float)((4d * Multiplicador) - Diferencia_Pelo), 0f, (float)(8d * Multiplicador_Pelo), (float)(8d * Multiplicador_Pelo)), new RectangleF(40f, 8f, 8f, 8f), GraphicsUnit.Pixel); // Hair
                        if (Dibujar_Chaqueta) Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(8d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(20f, 36f, 8f, 12f), GraphicsUnit.Pixel); // Jacket
                        if (Dibujar_Brazos_Chaqueta)
                        {
                            Pintar.DrawImage(Imagen_Original, new RectangleF(0f, (float)((8 * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(52f, 52f, 4f, 12f), GraphicsUnit.Pixel); // Left jacket arm
                            Pintar.DrawImage(Imagen_Original, new RectangleF((float)(12d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(44f, 36f, 4f, 12f), GraphicsUnit.Pixel); // Right jacket arm
                        }
                        if (Dibujar_Pantalones)
                        {
                            Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(4f, 52f, 4f, 12f), GraphicsUnit.Pixel); // Left pants leg
                            Pintar.DrawImage(Imagen_Original, new RectangleF((float)(8d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(4f, 36f, 4f, 12f), GraphicsUnit.Pixel); // Right pants leg
                        }
                    }
                    else // 32
                    {
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)Diferencia_Pelo_Superior, (float)(8d * Multiplicador), (float)(8d * Multiplicador)), new RectangleF(8f, 8f, 8f, 8f), GraphicsUnit.Pixel); // Head
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(8d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(20f, 20f, 8f, 12f), GraphicsUnit.Pixel); // Body
                        Pintar.DrawImage(Imagen_Original, new RectangleF(0f, (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(44f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Left arm
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(4d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(4f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Left leg
                        Imagen_Original.RotateFlip(RotateFlipType.RotateNoneFlipX); // Flip the image.
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(12d * Multiplicador), (float)((8d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(16f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Right arm
                        Pintar.DrawImage(Imagen_Original, new RectangleF((float)(8d * Multiplicador), (float)((20d * Multiplicador) + Diferencia_Pelo_Superior), (float)(4d * Multiplicador), (float)(12d * Multiplicador)), new RectangleF(56f, 20f, 4f, 12f), GraphicsUnit.Pixel); // Right leg
                        Imagen_Original.RotateFlip(RotateFlipType.RotateNoneFlipX); // Restore the image.

                        Pintar.CompositingMode = CompositingMode.SourceOver; // Overlay
                        if (Dibujar_Pelo) Pintar.DrawImage(Imagen_Original, new RectangleF((float)((4d * Multiplicador) - Diferencia_Pelo), 0f, (float)(8d * Multiplicador_Pelo), (float)(8d * Multiplicador_Pelo)), new RectangleF(40f, 8f, 8f, 8f), GraphicsUnit.Pixel); // Hair
                    }
                    Pintar.Dispose();
                    Pintar = null;
                    return Imagen;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static Bitmap Obtener_Imagen_Texto(string Texto, Font Fuente, Color Color_ARGB)
        {
            try
            {
                if (!string.IsNullOrEmpty(Texto) && Fuente != null)
                {
                    Bitmap Imagen = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    SizeF Dimensiones = Pintar.MeasureString(Texto, Fuente);
                    Pintar.Dispose();
                    Pintar = null;
                    Imagen.Dispose();
                    Imagen = null;
                    if (Dimensiones.Width > 0 && Dimensiones.Height > 0)
                    {
                        Imagen = new Bitmap((int)Dimensiones.Width + 4, (int)Dimensiones.Height + 4, PixelFormat.Format32bppArgb);
                        Pintar = Graphics.FromImage(Imagen);
                        Pintar.CompositingMode = CompositingMode.SourceOver;
                        Pintar.CompositingQuality = CompositingQuality.HighQuality;
                        Pintar.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Pintar.PageUnit = GraphicsUnit.Pixel;
                        Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        Pintar.SmoothingMode = SmoothingMode.HighQuality;
                        Pintar.TextRenderingHint = TextRenderingHint.AntiAlias;

                        SolidBrush Pincel = new SolidBrush(Color_ARGB);
                        Pintar.DrawString(Texto, Fuente, Pincel, 2f, 2f);
                        Pincel.Dispose();
                        Pincel = null;
                        Pintar.Dispose();
                        Pintar = null;
                        return Imagen;
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static string Traducir_Lista_Variables(List<string> Lista_Líneas)
        {
            try
            {
                if (Lista_Líneas != null && Lista_Líneas.Count > 0)
                {
                    string Texto = null;
                    foreach (string Línea in Lista_Líneas)
                    {
                        try { Texto += Línea + ", "; }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    if (!string.IsNullOrEmpty(Texto)) return Texto.TrimEnd(", ".ToCharArray());
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static string Traducir_Lista_Variables(string[] Matriz_Líneas)
        {
            try
            {
                if (Matriz_Líneas != null && Matriz_Líneas.Length > 0)
                {
                    string Texto = null;
                    foreach (string Línea in Matriz_Líneas)
                    {
                        try { Texto += Línea + ", "; }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    if (!string.IsNullOrEmpty(Texto)) return Texto.TrimEnd(", ".ToCharArray());
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static string Traducir_Lista_Variables(List<object> Lista_Objetos)
        {
            try
            {
                if (Lista_Objetos != null && Lista_Objetos.Count > 0)
                {
                    string Texto = null;
                    foreach (object Objeto in Lista_Objetos)
                    {
                        try { Texto += Objeto.ToString() + ", "; }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    if (!string.IsNullOrEmpty(Texto)) return Texto.TrimEnd(", ".ToCharArray());
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static string Traducir_Lista_Variables(object[] Matriz_Objetos)
        {
            try
            {
                if (Matriz_Objetos != null && Matriz_Objetos.Length > 0)
                {
                    string Texto = null;
                    foreach (object Objeto in Matriz_Objetos)
                    {
                        try { Texto += Objeto.ToString() + ", "; }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    if (!string.IsNullOrEmpty(Texto)) return Texto.TrimEnd(", ".ToCharArray());
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static string Traducir_Lista_Variables(List<byte> Lista_Objetos)
        {
            try
            {
                if (Lista_Objetos != null && Lista_Objetos.Count > 0)
                {
                    string Texto = null;
                    foreach (byte Valor in Lista_Objetos)
                    {
                        try { Texto += Valor.ToString() + ", "; }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    if (!string.IsNullOrEmpty(Texto)) return Texto.TrimEnd(", ".ToCharArray());
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static string Traducir_Lista_Variables(byte[] Matriz_Objetos)
        {
            try
            {
                if (Matriz_Objetos != null && Matriz_Objetos.Length > 0)
                {
                    string Texto = null;
                    foreach (byte Valor in Matriz_Objetos)
                    {
                        try { Texto += Valor.ToString() + ", "; }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    if (!string.IsNullOrEmpty(Texto)) return Texto.TrimEnd(", ".ToCharArray());
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static byte[] Obtener_Matriz_Bytes_Imagen(Bitmap Imagen)
        {
            try
            {
                int Ancho = Imagen.Width;
                int Alto = Imagen.Height;
                BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadOnly, Imagen.PixelFormat);
                byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                Imagen.UnlockBits(Bitmap_Data);
                Bitmap_Data = null;
                return Matriz_Bytes;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static Bitmap Obtener_Imagen_Sobre_Fondo(Bitmap Imagen_Original, Color Color_ARGB)
        {
            try
            {
                if (Imagen_Original != null && Color_ARGB != Color.Empty)
                {
                    int Ancho = Imagen_Original.Width;
                    int Alto = Imagen_Original.Height;
                    Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    Pintar.Clear(Color_ARGB);
                    Pintar.CompositingMode = CompositingMode.SourceOver;
                    Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                    Pintar.Dispose();
                    Pintar = null;
                    return Imagen;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return null;
        }

        internal static Rectangle Buscar_Zona_Recorte_Imagen(Bitmap Imagen)
        {
            if (Imagen != null)
            {
                int Ancho = Imagen.Width;
                int Alto = Imagen.Height;
                int Rectángulo_X = int.MaxValue;
                int Rectángulo_Y = int.MaxValue;
                int Rectángulo_Ancho = int.MinValue;
                int Rectángulo_Alto = int.MinValue;
                BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Imagen.Width, Imagen.Height), ImageLockMode.ReadOnly, Imagen.PixelFormat);
                int Ancho_Stride = Math.Abs(Bitmap_Data.Stride);
                int Bytes_Aumento = !Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 3 : 4;
                int Bytes_Diferencia = Ancho_Stride - ((Imagen.Width * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                byte[] Matriz_Bytes = new byte[Ancho_Stride * Imagen.Height];
                Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                Imagen.UnlockBits(Bitmap_Data);
                for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                {
                    for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento)
                    {
                        if (Matriz_Bytes[Índice + 3] > 0) // Not a fully transparent pixel
                        {
                            if (X < Rectángulo_X) Rectángulo_X = X;
                            if (X + 1 > Rectángulo_Ancho) Rectángulo_Ancho = X + 1;
                            if (Y < Rectángulo_Y) Rectángulo_Y = Y;
                            if (Y + 1 > Rectángulo_Alto) Rectángulo_Alto = Y + 1;
                        }
                    }
                }
                Matriz_Bytes = null;
                //Rectangle Rectángulo = Rectangle.FromLTRB(Rectángulo_X, Rectángulo_Y, Rectángulo_Ancho, Rectángulo_Alto);
                //if (Rectángulo.Width <= 0 || Rectángulo.Height <= 0) Rectángulo = new Rectangle(0, 0, Ancho, Alto);
                return Rectangle.FromLTRB(Rectángulo_X, Rectángulo_Y, Rectángulo_Ancho, Rectángulo_Alto);
            }
            return Rectangle.Empty;
        }

        /// <summary>
        /// java.util.Random.
        /// </summary>
        [Serializable]
        public class Random_Java
        {
            public Random_Java(ulong Semilla)
            {
                this.Semilla = (Semilla ^ 0x5DEECE66DUL) & ((1UL << 48) - 1);
            }

            public int NextInt(int Número)
            {
                if (Número <= 0) throw new ArgumentException("The supplied number must be positive.");

                if ((Número & -Número) == Número)  // i.e., n is a power of 2
                    return (int)((Número * (long)Next(31)) >> 31);

                long bits, val;
                do
                {
                    bits = Next(31);
                    val = bits % (uint)Número;
                }
                while (bits - val + (Número - 1) < 0);

                return (int)val;
            }

            protected uint Next(int Bits)
            {
                Semilla = (Semilla * 0x5DEECE66DL + 0xBL) & ((1L << 48) - 1);

                return (uint)(Semilla >> (48 - Bits));
            }

            private ulong Semilla;
        }

        //internal static Pen[] Matriz_Lápices_Arco_Iris_256 = null;
        internal static SolidBrush[] Matriz_Pinceles_Arco_Iris_256 = null;
        internal static SolidBrush[] Matriz_Pinceles_Grises_256 = null;
        internal static SolidBrush[] Matriz_Pinceles_Termografía_256 = null;
        internal static Process Proceso = Process.GetCurrentProcess();
        internal static PerformanceCounter Rendimiento_Procesador = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Matriz_Argumentos)
        {
            //try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Depurador.Iniciar_Depurador();
                // Only for "The End" screensaver, currently unfinished...
                if (Matriz_Argumentos != null && Matriz_Argumentos.Length > 0)
                {
                    string Argumento = Matriz_Argumentos[0];
                    if (!string.IsNullOrEmpty(Argumento))
                    {
                        Argumento = Argumento.ToLowerInvariant();
                        if (Argumento.Contains("c")) // Customize
                        {
                            Ventana_Salvapantallas_El_Fin Ventana = new Ventana_Salvapantallas_El_Fin();
                            Ventana.ShowDialog();
                            Ventana.Dispose();
                            Ventana = null;
                            return;
                        }
                        else if (Argumento.Contains("p")) // Preview
                        {
                            Ventana_Salvapantallas_El_Fin Ventana = new Ventana_Salvapantallas_El_Fin();
                            Ventana.ShowDialog();
                            Ventana.Dispose();
                            Ventana = null;
                            return;
                        }
                        else// if (Argumento.Contains("s")) // Screensaver
                        {
                            Ventana_Salvapantallas_El_Fin Ventana = new Ventana_Salvapantallas_El_Fin();
                            Ventana.ShowDialog();
                            Ventana.Dispose();
                            Ventana = null;
                            return;
                        }
                    }
                    else
                    {
                        Ventana_Salvapantallas_El_Fin Ventana = new Ventana_Salvapantallas_El_Fin();
                        Ventana.ShowDialog();
                        Ventana.Dispose();
                        Ventana = null;
                        return;
                    }
                }
                Copias_Seguridad.Iniciar_Copias_Seguridad();
                Lista_Caracteres_Prohibidos.AddRange(Path.GetInvalidPathChars());
                Lista_Caracteres_Prohibidos.AddRange(Path.GetInvalidFileNameChars());
                try { Rendimiento_Procesador = new PerformanceCounter("Processor", "% Processor Time", "_Total", true); }
                catch { Rendimiento_Procesador = null; }
                //try
                {
                    Minecraft.Cargar_Biomas();
                    Minecraft.Bloques.Reiniciar_Diccionarios_Bloques();
                    //Minecraft.Reiniciar_Diccionario_Nombres_Bloques();
                    Ventana_Generador_Pixel_Art.Preiniciar_Lista_Paleta();
                    /*MessageBox.Show(Minecraft.Bloques.Matriz_Bloques.Length.ToString());
                    foreach (Minecraft.Bloques Bloque in Minecraft.Bloques.Matriz_Bloques)
                    {
                        MessageBox.Show(Bloque.Transparencia_Textura.ToString(), Bloque.Nombre);
                    }*/
                    Matriz_Pinceles_Arco_Iris_256 = new SolidBrush[256];
                    Matriz_Pinceles_Grises_256 = new SolidBrush[256];
                    Matriz_Pinceles_Termografía_256 = new SolidBrush[256];
                    for (int Índice = 0; Índice < 256; Índice++)
                    {
                        int Índice_Arco_Iris = (Índice * 1529) / 255;
                        int Índice_Termografía = 1275 - ((Índice * 1275) / 255);
                        Matriz_Pinceles_Arco_Iris_256[Índice] = new SolidBrush(Obtener_Color_Puro_1530(Índice_Arco_Iris));
                        Matriz_Pinceles_Grises_256[Índice] = new SolidBrush(Color.FromArgb(255,Índice, Índice, Índice));
                        Matriz_Pinceles_Termografía_256[Índice] = new SolidBrush(Obtener_Color_Puro_1530(Índice_Termografía));
                    }
                }
                //catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
                try
                {
                    RegistryKey Clave = Registry.CurrentUser.CreateSubKey("Software\\Jupisoft\\Minecraft Tools\\" + Texto_Versión);
                    string Texto_Fecha_Anterior = null;
                    try { Texto_Fecha_Anterior = Clave.GetValue("Version", null) as string; }
                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Texto_Fecha_Anterior = null; }
                    if (!string.IsNullOrEmpty(Texto_Fecha_Anterior) && string.Compare(Texto_Fecha.Replace("_", null), Texto_Fecha_Anterior, true) != 0)
                    {
                        string[] Matriz_Nombres = null;
                        try
                        {
                            Matriz_Nombres = Clave.GetSubKeyNames();
                            if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                            {
                                for (int Índice = 0; Índice < Matriz_Nombres.Length; Índice++)
                                {
                                    try { Clave.DeleteSubKey(Matriz_Nombres[Índice]); }
                                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                }
                            }
                            Matriz_Nombres = null;
                        }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
                        try
                        {
                            Matriz_Nombres = Clave.GetValueNames();
                            if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                            {
                                for (int Índice = 0; Índice < Matriz_Nombres.Length; Índice++)
                                {
                                    if (string.Compare(Matriz_Nombres[Índice], "User_Name") != 0) // Don't delete the user name
                                    {
                                        try { Clave.DeleteValue(Matriz_Nombres[Índice]); }
                                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                                    }
                                }
                            }
                            Matriz_Nombres = null;
                        }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
                        MessageBox.Show("The program's settings were saved from a different version.\r\nTo ensure compatibility, all have been restored to their default values.\r\n\r\nSaved version: " + Texto_Fecha_Anterior + ".\r\nCurrent version: " + Texto_Fecha.Replace("_", null) + ".", Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    try { Clave.SetValue("Version", Texto_Fecha.Replace("_", null), RegistryValueKind.String); }
                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
                    Clave.Close();
                    Clave = null;
                }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
                try { SevenZip.SevenZipBase.SetLibraryPath(Environment.Is64BitProcess ? Application.StartupPath + "\\7z64.dll" : Application.StartupPath + "\\7z.dll"); }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
                Application.Run(new Ventana_Principal());
            }
            //catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }
    }
}

using Minecraft_Tools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Acerca : Form
    {
        public Ventana_Acerca()
        {
            InitializeComponent();
        }
        
        internal string Texto_Desarrollador = "Jupisoft (Júpiter Mauro, from Spain)";
        internal string Texto_Copyright = "© 2004 - " + Math.Max(2019, DateTime.Now.Year).ToString() + " by Jupisoft, all rights reserved";
        internal string Texto_Comentarios = "\"Only for the Glory of God\", quote from Johann Sebastian Bach, and thanks to all the people that have posted comments";
        internal string Texto_Librerías = "Magick.NET, SevenZipSharp and Substrate. Some images are copyright by Mojang, Mattel, Heraclio Fournier, etc";
        internal static List<string> Lista_Gracias = new List<string>(); //new List<string>(new string[] { "BigBadLoser", "Brad Breeck", "C418", "David Maeso", "DenBob", "Fratelli Stellari", "Mattel", "MrLesk", "MSpaceDev", "Minecraft Forum", "minepowaa", "Mojang", "PM_ME_YOUR_HOOMAN", "ScotsMiser", "swagmiter", "The FLipside Forum", "Xisumavoid" });
        internal bool Variable_Siempre_Visible = false;

        internal int Modo_Color = 0;
        internal int Índice_Matiz = 0;

        private void Ventana_Acerca_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                this.Text = "About " + Program.Texto_Título_Versión;
                TextBox_Programa.Text = Program.Texto_Programa;
                TextBox_Versión.Text = Program.Texto_Versión_Fecha;
                TextBox_Desarrollador.Text = Texto_Desarrollador;
                TextBox_Copyright.Text = Texto_Copyright;
                TextBox_Comentarios.Text = Texto_Comentarios;
                TextBox_Librerías.Text = Texto_Librerías;
                TextBox_Minecraft.Text = Program.Texto_Minecraft_Versión + " [" + Program.Traducir_Número(Minecraft.Bloques.Matriz_Bloques.Length) + (Minecraft.Bloques.Matriz_Bloques.Length != 1 ? " vanilla blocks known" : " vanilla block known") + "]";
                string Texto_Gracias = null;
                foreach (string Nombre in Lista_Gracias)
                {
                    Texto_Gracias += Nombre + ", ";
                }
                TextBox_Gracias.Text = Texto_Gracias.TrimEnd(", ".ToCharArray()) + " and everyone else";
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Acerca_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Acerca_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Acerca_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Acerca_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Acerca_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!e.Alt && !e.Control && !e.Shift)
                {
                    if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Propiedades_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PInvoke.SHObjectProperties(this.Handle, PInvoke.SHObjectPropertiesFlags.FilePath, Application.ExecutablePath, null)) SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Sitio_Hermitcraft_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://hermitcraft.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Sitio_Minecraft_Forum_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.minecraftforum.net/forums/minecraft-java-edition/recent-updates-and-snapshots/2894808-minecraft-1-13-new-chunk-format-fully-decoded-read", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Sitio_Jupisoft_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://jupisoft.x10host.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Correo_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("mailto:jupitermauro@gmail.com?subject=" + Program.Texto_Programa + " " + Program.Texto_Versión + ", " + Program.Texto_Fecha.Replace("_", null), ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Donar_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=KSMZ3XNG2R9P6", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Botón_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                /*if (e.Button == MouseButtons.Left)
                {
                    Temporizador_Principal.Enabled = !Temporizador_Principal.Enabled;
                    if (!Temporizador_Principal.Enabled)
                    {
                        Índice_Matiz = 0;
                        Picture.Image = null;
                        Picture.Invalidate();
                        Picture.Update();
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (!Temporizador_Principal.Enabled)
                    {
                        Picture.Image = Filtrar_Imagen(Program.Rand.Next(0, 1529));
                        Picture.Invalidate();
                        Picture.Update();
                    }
                }
                else *///if (e.Button == MouseButtons.Middle)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        internal Bitmap Filtrar_Imagen(int Índice_Matiz)
        {
            Bitmap Imagen = Resources.Jupisoft_256.Clone() as Bitmap;
            BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, 256, 256), ImageLockMode.ReadWrite, Imagen.PixelFormat);
            byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * 256];
            Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
            double Matiz, Saturación, Brillo;
            byte Rojo, Verde, Azul;
            for (int Y = 0, Índice = 0; Y < 256; Y++)
            {
                for (int X = 0; X < 256; X++, Índice += 4)
                {
                    if (Matriz_Bytes[Índice] != Matriz_Bytes[Índice + 1] || Matriz_Bytes[Índice] != Matriz_Bytes[Índice + 2]) // No es gris
                    {
                        Program.HSL.From_RGB(Matriz_Bytes[Índice + 2], Matriz_Bytes[Índice + 1], Matriz_Bytes[Índice], out Matiz, out Saturación, out Brillo);
                        Matiz += (Índice_Matiz * 360d) / 1529d;
                        while (Matiz < 0d) Matiz += 360d;
                        while (Matiz >= 360d) Matiz -= 360d;
                        Program.HSL.To_RGB(Matiz, Saturación, Brillo, out Rojo, out Verde, out Azul);
                        Matriz_Bytes[Índice + 2] = Rojo;
                        Matriz_Bytes[Índice + 1] = Verde;
                        Matriz_Bytes[Índice] = Azul;
                    }
                }
            }
            Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
            Imagen.UnlockBits(Bitmap_Data);
            Bitmap_Data = null;
            Matriz_Bytes = null;
            return Imagen;
        }

        private void Temporizador_Principal_Tick(object sender, EventArgs e)
        {
            try
            {
                Picture.Image = Filtrar_Imagen(Índice_Matiz);
                Picture.Invalidate();
                Picture.Update();
                if (Modo_Color == 0)
                {
                    Índice_Matiz++;
                    if (Índice_Matiz >= 1530) Índice_Matiz = 0;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }
    }
}

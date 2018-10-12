using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Registro_Cambios : Form
    {
        public Ventana_Registro_Cambios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Structure that holds up all the information about a change log entry.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Cambios
        {
            /// <summary>
            /// The date at which a change in the application took place. The hour should be ignored, and the date should represent the exact day the changes were released to the public.
            /// </summary>
            internal DateTime Fecha;
            /// <summary>
            /// The version of the application at which a change took place. Minecraft itself uses strange version increment, since affter 1.9 it should have been 2.0, but instead it was 1.10, so keeping in mind this behavior, this application will be maintained as 1.0 at least until all of it's planned features are fully implemented. So please, use the dates in the change log to know which version is newer.
            /// </summary>
            internal string Versión;
            /// <summary>
            /// The lines of text that describes what changed in the application.
            /// </summary>
            internal string[] Matriz_Líneas;

            internal Cambios(DateTime Fecha, string Versión, string[] Matriz_Líneas)
            {
                this.Fecha = Fecha;
                this.Versión = Versión;
                this.Matriz_Líneas = Matriz_Líneas;
            }

            /// <summary>
            /// The matrix that contains a registry of the changes done in the application over time.
            /// 
            /// [RTF format info]:
            /// 
            /// "\b ": bold start.
            /// "\b0 ": bold end.
            /// 
            /// "\i ": italic start.
            /// "\i0 ": italic end.
            /// 
            /// "\ul ": underline start.
            /// "\ulnone ": underline end.
            /// 
            /// "\strike ": strike start.
            /// "\strike0 ": strike end.
            /// 
            /// "\sub ": subtext start.
            /// "\nosupersub ": subtext end.
            /// 
            /// "\super ": supertext start.
            /// "\nosupersub ": supertext end.
            /// 
            /// "\highlight1 ": highlight start.
            /// "\highlight0 ": highlight end.
            /// 
            /// "\cf1 ": colored font.
            /// "\cf0 ": default colored font.
            /// 
            /// "\pard\qc ": center text.
            /// "\pard ": left text.
            /// "\pard\qr ": right text.
            /// "\pard\qj ": justified text.
            /// 
            /// "\fs18 ": font size 9.
            /// "\fs20 ": font size 10.
            /// "\fs22 ": font size 11.
            /// "\fs24 ": font size 12.
            /// "\fs160 ": font size 80.
            /// Note: the font size seems to be the double on the source code than the actual value.
            /// </summary>
            internal static readonly Cambios[] Matriz_Cambios = new Cambios[]
            {
                /*new Cambios(new DateTime(), "1.0.0.0", new string[]
                {
                    "",
                    ""
                }),*/
                new Cambios(new DateTime(2018, 10, 11), "1.0.0.0", new string[]
                {
                    "Added a lot of the old Minecraft splashes, even from it's other versions.",
                    "Added more than 500 custom splashes, making the Minecraft original ones to be hidden for now.",
                    "Added a new color and shadow to the splash texts.",
                    "Added a new tool for converting 1.13+ worlds to 1.12.2-, meaning some blocks won't be there yet, but might be very useful for several purposes.",
                    "Improved the block information viewer, now middle clicking will copy it's 1.13+ name and now it can sort the blocks with it's names inverted, also the ID now works.",
                    "Recolored the texture \"minecraft_melon_stem.png\" because by mistake it was on grayscale.",
                    "Now pressing a letter between A and Z will go to the first block starting with that letter on the block information viewer.",
                    "Added a lot of new functions to help in the conversion from 1.13+ to 1.12.2-. Also done the first successful conversion.",
                    "Added for each block it's Minecraft category tag from the creative inventory, so now they will be able to be sorted in the same groups like Minecraft.",
                    "Added a new window to see all the donations to Jupisoft, but at least for now no one has ever donated yet, so the new window is empty.",
                    "Added a list with all the possible NBT properties of all the Minecraft 1.13.1 blocks, very useful for the new 1.12.2- conversor or just for learning them.",
                    "Improved even more the block information viewer, now when pressing a letter it will navigate on the first or last block starting with it, but from the selected column.",
                    "Added full support for the 37 new blocks from Minecraft 1.13.1, including it's new textures and average colors, meaning the Realistic 2D world viewer will support them.",
                    "Found a few hundreds of images in the resources that weren't 32 bits with alpha, so now all have been reconverted properly into the specified format.",
                    "Finished a working version of the 1.13+ to 1.12.2- world converter, and is better than expected, even signs save it's messages.",
                    "Fixed dozens of incorrect block metadata (Data values), like orientation, state, etc. But it might be more blocks with incorrect conversion yet.",
                    "Added 4 test options to delete the original world water, lava, stones and dirt, which might be very interesting and dangerous because of the falling chain reactions.",
                    "The source code of the last tool could be used to port back levels from 1.13+ to Java edition, but also to other platforms with a bit of recoding and adapting.",
                    "Now the splash count text (without counting itself) will only show once at the start of the application instead of also randomly.",
                    "Added full support for the Nether and The End dimensions in the 1.12.2- converter and also a lot of awesome and cool test options, so check them out.",
                    "Added special world types like wool, concrete or ores for the 1.13+ to 1.12.2- converter, which finally is fully functional.",
                }),
                new Cambios(new DateTime(2018, 10, 4), "1.0.0.0", new string[]
                {
                    "Deleted the old background image based on a Minecraft launcher file called \"bg.png\", which has inconsistency errors on the oversized pixel borders.",
                    "Added a new function called \"Crear_Imagen_Mosaico_Fondo()\" which generated a new background image to be displayed as a mosaic, based on the dirt block texture.",
                    "The new background image should be better mixed with the red background now and show colors nearer to red on most displays (before it was too orange).",
                    "Started a new resource pack converter tool, which will convert resource packs (or the old texture packs) from any Minecraft version to another.",
                    "Deleted all the tools from it's menu on the main window, now they'll be started from the new tool selector, which has been mostly finished.",
                    "Deleted about 300 png images from the resources containing ASCII characters, because they were repeated after the previous update.",
                    "Added a new function to delete a certain color of any image, used for making transparent the villager trade chart from the Minecraft wiki.",
                    "Finished (for now) the tool Villager tradings viewer, which has an enhanced version of the image from the Minecraft wiki, now with multiple background colors.",
                }),
                new Cambios(new DateTime(2018, 9, 27), "1.0.0.0", new string[]
                {
                    "The application will only be updated through GitHub from now on, although the Minecraft Forum will be updated with the new changes as well.",
                    "Added the ability to show which chunks are slime chunks for making farms on the Realistic 2D world viewer, shown as transparent black and pink diagonal lines.",
                    "Fixed a bug for the Realistic 2D world viewer where it failed when drawing a full world at once by missing several regions, now it has a full new code to do it right.",
                    "Planned a new tool to convert resource packs for 1.12+ to 1.13+, since several folders and files now have other names.",
                    "Finally finished the full code that shows all the ASCII characters that Minecraft supports, shown at the bottom of the main window as splash texts.",
                    "Added a new icon for the Realistic 2D world viewer combining the Minecraft 3D grass block with a semi-transparent magnifying glass.",
                    "The tool selector window now contains almost all the tools included, and although still can't start them, it's almost finished.",
                    "Fully redesigned the main window, which now shows several images from the Minecraft launcher itself and useful links to Minecraft and Mojang sites.",
                    "Added this change log as a new window, and it took several hours to recover all the previous dates and changes."
                }),
                new Cambios(new DateTime(2018, 9, 16), "1.0.0.0", new string[]
                {
                    "The application was first ever published on GitHub, after learning it can't upload files over 50 MB.",
                    "Added on the readme an external link on Mediafire for the 26.601 real Minecraft skins, since it can't be uploaded on GitHub.",
                    "Also it can't upload more than 100 files at once, so for the thousands of images and resources it took several days.",
                    "Most of the unfinished tools are now working, although there's a lot of work to do on them yet before saying they are fully finished."
                }),
                new Cambios(new DateTime(2018, 3, 17), "1.0.0.0", new string[]
                {
                    "The application was first ever published on the Minecraft Forum.",
                    "After the positive response anyone that said anything about the program was added to the Thank you window.",
                    "Also the good feedback helped a lot to inspire and develop it even more quickly.",
                    "During the next weeks several new unfinished tools were added as well as some were fully finished.",
                    "A few days later it's full source code was released for free.",
                    "A few months later it's development was very slow due to the lack of time to program it, so sorry about that."
                }),
                new Cambios(new DateTime(2018, 3, 8), "1.0.0.0", new string[]
                {
                    "After decoding the new Minecraft 1.13 chunk format this application was born.",
                    "Some kind of old 2D world viewer was created some years ago, but it was abandoned at the end, it worked up to Minecraft 1.12.2, but still was unfinished.",
                    "The new idea was to save that old program, improve it and make an all-in-one free tool.",
                    "The plan wasn't release it so quick, but after decoding the new chunk format it just happened.",
                    "The application was first ever shown to Xisumavoid, which made a post about it on reddit in the hope of spreading the new 1.13 chunk format decoding.",
                    "This should help the whole Minecraft community and help others to update their tools for Minecraft 1.13 faster.",
                    "It only included the Realistic 2D world viewer, but it was possibly the first in the world to fully support the new 1.13 chunk format.",
                    "Dozens of other full tools were planned but due to the fast and unexpected release, they were unfinished."
                })
            };
        }

        internal readonly string Texto_Título = "Change log of Minecraft Tools " + Program.Texto_Versión + " for " + Program.Texto_Usuario + " by Jupisoft";
        //internal Ayudas Ayuda = Ayudas.Main_window;
        internal float Variable_Zoom = 1f;
        //internal Stopwatch Cronómetro_Memoria = new Stopwatch(); // Turn the text red when over 4 GB
        internal bool Variable_Siempre_Visible = false;
        internal int Total_Cambios = 0;

        private void Ventana_Registro_Cambios_Load(object sender, EventArgs e)
        {
            try
            {
                float Zoom = Variable_Zoom;
                if (Cambios.Matriz_Cambios != null && Cambios.Matriz_Cambios.Length > 0)
                {
                    string Texto_Cambios = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang3082{\\fonttbl{\\f0\\fnil\\fcharset0 " + Barra_Estado_Etiqueta_Sugerencia.Font.Name + ";}{\\f1\\fnil\\fcharset0 Calibri;}}\r\n{\\*\\generator Riched20 6.3.9600}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs" + (10 * 2).ToString() + " ";
                    for (int Índice = 0; Índice < Cambios.Matriz_Cambios.Length; Índice++)
                    {
                        Texto_Cambios += "\\ul \\b [" + Program.Traducir_Fecha_Inglés(Cambios.Matriz_Cambios[Índice].Fecha) + "]\\b0 \\ulnone \\par";
                        if (Cambios.Matriz_Cambios[Índice].Matriz_Líneas != null && Cambios.Matriz_Cambios[Índice].Matriz_Líneas.Length > 0)
                        {
                            foreach (string Línea in Cambios.Matriz_Cambios[Índice].Matriz_Líneas)
                            {
                                if (!string.IsNullOrEmpty(Línea))
                                {
                                    Texto_Cambios += " - " + Línea + "\\par";
                                }
                            }
                            if (Índice < Cambios.Matriz_Cambios.Length - 1) Texto_Cambios += "\\par";
                            Total_Cambios += Cambios.Matriz_Cambios[Índice].Matriz_Líneas.Length;
                        }
                    }
                    Texto_Cambios += "\\pard\\sa200\\sl276\\slmult1\\f1\\fs22\\lang10\\par}";
                    RichTextBox_Cambios.Rtf = Texto_Cambios;
                    RichTextBox_Cambios.ZoomFactor = Zoom != 1.5f ? 1.5f : 2.5f;
                    RichTextBox_Cambios.ZoomFactor = Zoom;
                }
                this.Text = Texto_Título + " - [Dates and changes registered: " + Program.Traducir_Número(Cambios.Matriz_Cambios.Length) + " and " + Program.Traducir_Número(Total_Cambios) + ", Zoom: " + Program.Traducir_Número(Variable_Zoom) + "x]";
                this.WindowState = FormWindowState.Maximized;
                /*string[] Matriz_Nombres = Enum.GetNames(typeof(Ayudas));
                if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                {
                    for (int Índice = 0; Índice < Matriz_Nombres.Length - 1; Índice++) ComboBox_Ayuda.Items.Add(" " + Matriz_Nombres[Índice].Substring(0, 1).ToUpperInvariant() + Matriz_Nombres[Índice].Substring(1).Replace('_', ' '));
                    Matriz_Nombres = null;
                }
                //RichTextBox_Ayuda.Font = new Font("Courier New", 11f, FontStyle.Regular);
                //RichTextBox_Ayuda.Font = Barra_Estado_Etiqueta_Memoria.Font;
                //RichTextBox_Ayuda.Font = new Font(Barra_Estado_Etiqueta_Memoria.Font.Name, 31f, FontStyle.Regular);
                Registro_Cargar_Opciones();
                if (Ayuda >= 0 && (int)Ayuda < ComboBox_Ayuda.Items.Count) ComboBox_Ayuda.SelectedIndex = (int)Ayuda;
                else if (ComboBox_Ayuda.Items.Count > 0) ComboBox_Ayuda.SelectedIndex = 0;*/




            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Registro_Cambios_Shown(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Start();
                this.Activate();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Registro_Cambios_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Registro_Cambios_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Registro_Cambios_KeyDown(object sender, KeyEventArgs e)
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
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Copiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(RichTextBox_Cambios.Text))
                {
                    RichTextBox_Cambios.Copy();
                    //Clipboard.SetText();
                    SystemSounds.Asterisk.Play();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(RichTextBox_Cambios.Text))
                {
                    RichTextBox_Cambios.SaveFile(Application.StartupPath + "\\Change log " + Program.Obtener_Nombre_Temporal_Sin_Guiones() + ".txt", RichTextBoxStreamType.PlainText);
                    SystemSounds.Asterisk.Play();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Menú_Contextual_Guardar_RTF_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(RichTextBox_Cambios.Text))
                {
                    RichTextBox_Cambios.SaveFile(Application.StartupPath + "\\Change log " + Program.Obtener_Nombre_Temporal_Sin_Guiones() + ".rtf", RichTextBoxStreamType.RichText);
                    SystemSounds.Asterisk.Play();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Temporizador_Principal_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Variable_Zoom != RichTextBox_Cambios.ZoomFactor)
                {
                    Variable_Zoom = RichTextBox_Cambios.ZoomFactor;
                    //Registro_Guardar_Opciones();
                    this.Text = Texto_Título + " - [Dates and changes registered: " + Program.Traducir_Número(Cambios.Matriz_Cambios.Length) + " and " + Program.Traducir_Número(Total_Cambios) + ", Zoom: " + Program.Traducir_Número(Variable_Zoom) + "x]";
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }
    }
}

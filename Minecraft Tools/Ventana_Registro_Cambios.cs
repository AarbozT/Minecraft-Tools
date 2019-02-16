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
                new Cambios(new DateTime(2018, 9, 16), "1.0.0.0", new string[]
                {
                    "The application was first ever published on GitHub, after learning it can't upload files over 50 MB.",
                    "Added on the readme an external link on Mediafire for the 26.601 real Minecraft skins, since it can't be uploaded on GitHub.",
                    "Also it can't upload more than 100 files at once, so for the thousands of images and resources it took several days.",
                    "Most of the unfinished tools are now working, although there's a lot of work to do on them yet before saying they are fully finished."
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
                    "Added special world types like wool, concrete or ores for the 1.13+ to 1.12.2- converter, which finally is fully functional, but super slow.",
                }),
                new Cambios(new DateTime(2018, 10, 21), "1.0.0.0", new string[]
                {
                    "Added a global and much better \"pixel art\" world option for 1.13+ to 1.12.2-, so now the worlds will turn into wool, concrete, etc much faster than before.",
                    "Added a new function for custom block transmutations that will turn any block type into another one, allowing even for block type repetitions.",
                    "Changed the block textures for Ender dragon egg, end rods, sea pickles, flower pots and levers to make them look like they look in Minecraft.",
                    "Moved some obsolete blocks to the bottom of the blocks list and properly set the blocks with any dimensions different than 1 full block.",
                    "Improved a lot the 1.13+ to 1.12.2- world converter, now with block transmutations, quantizations, upside down worlds and even with self-destruct TNT columns.",
                    "Planned to add full 1.12.2- to 1.12.2- support in order to edit or filter the worlds and change it's blocks with transmutations, quantizations and other options.",
                    "Added quantization with support for blocks with partial (or full) transparent textures, like stained glass, etc.",
                    "Changed a bit some blocks average texture color in order to fully support qunatization with variable alpha values.",
                    "Received the first donation ever, thanks to Alexander, so now a received donations window has been fully implemented from the help menu.",
                    "Added a new window for selecting custom transmutations or quantizations with a lot of interesting options.",
                    "Adapted correctly the water and lava spreading level to it's Data values from 1.13+ to 1.12.2- and also corrected the orientation of all the anvils.",
                    "Improved this change log window, now it shows the updates in reversed order and it auto-scrolls to the bottom of the text when it starts.",
                    "Added a lot of new splashes.",
                    "Changed the tool selector window, so now saving your default start tool will work again as it used to do.",
                    "Readapted the code in the about window, since the previous update to alpha in all the images from the resources made a mess in the Jupisoft image there.",
                    "Finally started the development of the animated 3D skin viewer tool, although still will take a while until it's working properly.",
                    "Added the ability to export and import block transmutations and quantizations as plain text files in the 1.13+ to 1.12.2- world converter.",
                    "Corrected a lot of block ID and Data conversions like beds, buttons, observers, trapdoors, pressure plates, slabs, stairs, heads, all logs, etc.",
                    "Corrected also the Data values from the known vanilla blocks for bricks, nether bricks and quartz blocks. Before they were like it's slabs variants.",
                    "WARNING: the image \"DataValuesBeta\" from the wiki has a lot of wrong Data values, like dark and prismarine bricks (inverted), quartz and nether brick slabs, etc.",
                    "Some blocks that need a TileEntity (like banners, heads or shulker boxes) might be invisible after the conversion. Use \"pick block\" on their hit box to show them again.",
                    "Added some new functions in the paintings viewer to export resource pack with the real HD paintings inside with support for multiple pack formats.",
                    "Added a full internal wiki about all the Monster High characters with cool images, although some are missing (like the Dracubecca, Cupid, etc).",
                    "Almost added a new secret to export a Monster High resource pack with paintings at 512 x 512 pixels about Monster High.",
                    "Added a lot of structure markers for the Realistic 2D world viewer that show the players, the spawn point and even the subtypes of all the structures.",
                    "Improved the blocks viewer tool with new combinable filters, very useful to search block types.",
                    "Finished the encoder and decoder of files to (and from) Minecraft worlds, now with an improved 1.12.2- 256 blocks palette, where 1 block equals 1 byte of the file.",
                    "Added full support for all the new Minecraft 1.14 (Snapshot 18w43c) block types, including it's textures but seen in the old original Minecraft textures style.",
                    "Fixed a bug for the Realistic 2D world viewer where it started at 2 when counting the block densities, while it should only have added 1 for each block type.",
                    "Updated the 1.13+ to 1.12.2- world converter, which now has full 1.14+ new block types support.",
                    "Added the average conversion times for each chunk and region in the 1.13+ to 1.12.2- world converter.",
                    "Fixed a bug where the note block sounds, now saved in a folder near the application, weren't loaded correctly, so the tool was muted and useless with that bug.",
                    "Added the colors for the new 1.13 biomes, the difference will be shown on the realistic 2D world viewer.",
                    "Fixed a bug where the map wasn't fully drawn (if that option was selected) after loading a different world on the realistic 2D world viewer.",
                    "Expanded the slime chunks finder, now it can predict where will spawn all Minecraft structures, assuming the world had only one correct biome (use the world buffet).",
                    "Also added a biome list to exactly predict any structure and improved a lot the map colors and rulers, even it's numeric font, now with a better background blending.",
                    "Added an option in the context menu to invert the map colors in the new slime chunks and structures finder.",
                    "Created the first datapack by Jupisoft, with new recipes to craft any monster egg and even spawners (with 10+ nether stars, so it's very hard, but possible to get).",
                    "Added a new map type to detect floating blocks that should fall or be destroyed when updated, like generated floating sand or grass with air below.",
                    "Since the VBO switch is no longer included in the latest snapshots and my Intel HD Graphics makes Minecraft crash after loading any world, I can't play or test it.",
                    "I still can for some reason load a debug world and watch from very far the existing blocks to at least add theoric support for them, but without testing like before sadly.",
                    "Added support for the Minecraft 1.14 Snapshot 18w49a, at least in theory, so hopefully everything will work fine.",
                    "Added a new tool that can really count the FPS at which any program window is drawing on the screen, but it might not work on DirectX windows or so.",
                    "Added a new tool that can find duplicated files inside any folder and even move them inside new subfolders to save a lot of time.",
                    "Added inside the infiniscope tool a picture from Jonathan Swift's Gulliver's travels Laputa and from Steven Universe soundtrack vol. 1 that looks like Laputa.",
                    /*"",
                    ""*/
                }),
                new Cambios(new DateTime(2019, 01, 21), "1.0.0.0", new string[]
                {
                    "Reduced a lot the total size of the application, and now the \"secret files\" won't be included by default to save even more space.",
                    "Added a new tool that allows to see the screen in real time but through several useful filters, including zoom, try it diving underwater inside a shipwreck in Minecraft.",
                }),
                new Cambios(new DateTime(2019, 02, 13), "1.0.0.0", new string[]
                {
                    "A few days ago my Minecraft Forum account was deleted and all my posts are gone forever after reaching almost 20.000 visits. It got hacked or what happened here?",
                    "Now this application has a new thread and full support for all the Minecraft 1.14 snapshot 19w06a new block types and textures.",
                    "Added a new tool that fully describes the new Minecraft 1.13+ new chunk format. This should help others to update their applications to support Minecraft 1.13+ worlds.",
                    "Updated the tool able to reconstruct the resource structure with original file names from any Minecraft folder, now supports JSON files with a single line of code.",
                    "Added a new screen saver tool that randomly draws all the known Minecraft blocks by this application on the screen with random options, but also configurable.",
                    "Added an option to auto-install the screen saver near the other Windows screen savers, but first saves the files to the desktop and then tries to move them.",
                    "Now the screen saver remembers it's options when it's loaded, useful to set it up from the main application and then use the same options in the real screen saver.",
                    "Added a new Score viewer with all the scores composed by Júpiter Mauro (Jupisoft), also available for free on the music site at: http://jupisoft.x10host.com/.",
                    "Saved almost 11 MB of space by simply removing the Jupisoft icons from the designer of all the forms except the main and the blocks screen saver.",
                    "Added several images to draw over them in real time all the scores composed by Jupisoft and also implemented advanced FSC reading functions and custom classes.",
                    "Added all the scores composed by Jupisoft inside the application into custom classes for later use by some tools, but in a way that should save a lot of space.",
                    "Finished the score viewer tool, now the user can even rotate the notes in real time, and the result is better than my own music site, but without any space used.",
                    "Now the score viewer can play the scores as MIDI files, and it has real time positions and markers to follow along the playback with high accuracy.",
                    "Added a new \"infiniscope\" tool, with instructions to develop an ancient device better than a colossal telescope and microscope, please anyone interested get in contact.",
                    "Added a new tool capable of repairing damaged files, if you download any file that ends up corrupted 3 times at different places, you'll get a flawless version with this.",
                    "Added a new multidimensional mathematic analyzer tool, capable of generating fractals and other awesome effects, which needs further investigation by someone.",
                    "Added the secrets window to the tool selector window, making it less secret than before. Added a yellow color for tools with secrets like the infiniscope tool or secrets.",
                }),
                /*new Cambios(new DateTime(), "1.0.0.0", new string[]
                {
                    "",
                    ""
                }),*/
            };
        }

        internal readonly string Texto_Título = "Change Log of Minecraft Tools " + Program.Texto_Versión + " for " + Program.Texto_Usuario + " by Jupisoft";
        //internal Ayudas Ayuda = Ayudas.Main_window;
        internal float Variable_Zoom = 1f;
        //internal Stopwatch Cronómetro_Memoria = new Stopwatch(); // Turn the text red when over 4 GB
        internal bool Variable_Siempre_Visible = false;
        internal int Total_Cambios = 0;

        private void Ventana_Registro_Cambios_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                this.WindowState = FormWindowState.Maximized;
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
                this.Text = Texto_Título + " - [Updates and changes registered: " + Program.Traducir_Número(Cambios.Matriz_Cambios.Length) + " and " + Program.Traducir_Número(Total_Cambios) + ", Zoom: " + Program.Traducir_Número(Variable_Zoom) + "x]";
                RichTextBox_Cambios.SelectionLength = 0; // Select the end of the text.
                RichTextBox_Cambios.SelectionStart = RichTextBox_Cambios.Text.Length;
                RichTextBox_Cambios.ScrollToCaret(); // Navigate to the bottom of the text.
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

using Minecraft_Tools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Selector_Herramientas : Form
    {
        public Ventana_Selector_Herramientas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Structure that holds up all the information about a tool of this application.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Herramientas
        {
            internal Bitmap Imagen;
            internal string Texto;
            internal Type Tipo;
            internal CheckState Estado; 

            internal Herramientas(Bitmap Imagen, string Texto, Type Tipo, CheckState Estado)
            {
                this.Imagen = Imagen;
                this.Texto = Texto;
                this.Tipo = Tipo;
                this.Estado = Estado;
            }

            internal static readonly Herramientas[] Matriz_Herramientas = new Herramientas[]
            {
                new Herramientas(Resources.Ejecutar, "None (select it manually everytime)", null, CheckState.Checked),
                new Herramientas(Resources.Jupisoft_16, "About", typeof(Ventana_Acerca), CheckState.Checked),
                new Herramientas(Resources.Copia_Seguridad, "Backups manager", typeof(Ventana_Administrador_Copias_Seguridad), CheckState.Unchecked),
                new Herramientas(Resources.minecraft_note_block, "Note blocks tuner", typeof(Ventana_Afinador_Bloques_Nota), CheckState.Checked),
                new Herramientas(Resources.minecraft_slime_block, "Slime chunks finder", typeof(Ventana_Buscador_Chunks_Limos), CheckState.Checked),
                new Herramientas(Resources.Calculadora, "World seeds infinite calculator", typeof(Ventana_Calculadora_Infinita_Semillas_Mundos), CheckState.Checked),
                new Herramientas(Resources.WinRAR, "Finder of differences between JAR versions", typeof(Ventana_Comparador_Versiones_JAR), CheckState.Checked),
                new Herramientas(Resources.Excepción, "Exception debugger", typeof(Ventana_Depurador_Excepciones), CheckState.Checked),
                new Herramientas(Resources.Ordenar, "Automatic skin downloader", typeof(Ventana_Descargador_Skins_Automático), CheckState.Unchecked),
                new Herramientas(Resources.minecraft_red_banner, "Banner and shield designer", typeof(Ventana_Diseñador_Estandartes_Escudos), CheckState.Checked),
                new Herramientas(Resources.minecraft_redstone_block, "Redstone designer", null, CheckState.Unchecked),
                new Herramientas(Resources.minecraft_command_block, "Structure generator through commands", null, CheckState.Unchecked),
                new Herramientas(Resources.Paleta, "Painted structures exporter", typeof(Ventana_Exportador_Estructuras_Pintadas), CheckState.Indeterminate),
                new Herramientas(Resources.minecraft_structure_block, "Custom structures generator", typeof(Ventana_Generador_Estructuras_Personalizadas), CheckState.Indeterminate),
                new Herramientas(Resources.Ojo, "Thumbnails and average color generator", typeof(Ventana_Generador_Miniaturas_Color_Medio), CheckState.Checked),
                new Herramientas(Resources.Pixel_Art, "Pixel art generator with world exporter", typeof(Ventana_Generador_Pixel_Art), CheckState.Checked),
                new Herramientas(Resources.Lista, "Thank you", typeof(Ventana_Gracias), CheckState.Checked),
                new Herramientas(Resources.Controles_TextBox, "Block information", typeof(Ventana_Información_Bloques), CheckState.Checked),
                new Herramientas(Resources.Xisumavoid, "Full members information", typeof(Ventana_Información_Miembros_Hermitcraft), CheckState.Checked),
                new Herramientas(Resources.Usuario, "Change the username", typeof(Ventana_Nombre_Usuario), CheckState.Checked),
                new Herramientas(Resources.Controles_TreeView, "Resource structure rebuilder", typeof(Ventana_Reconstructor_Estructura_Archivos_Recursos), CheckState.Checked),
                new Herramientas(Resources.Sol_Luna, "Real time Minecraft clock", typeof(Ventana_Reloj_Minecraft_Tiempo_Real), CheckState.Checked),
                new Herramientas(Resources.minecraft_stone, "Block selector", typeof(Ventana_Selector_Bloques), CheckState.Checked),
                new Herramientas(Resources.Ayuda, "Help viewer", typeof(Ventana_Visor_Ayuda), CheckState.Checked),
                new Herramientas(Resources.Cuadros_Pool, "Paintings viewer", typeof(Ventana_Visor_Cuadros), CheckState.Checked),
                new Herramientas(Resources.Controles_TextBox, "Block information viewer", typeof(Ventana_Visor_Información_Bloques), CheckState.Checked),
                new Herramientas(Resources.minecraft_player_head, "Entities information viewer", typeof(Ventana_Visor_Información_Entidades), CheckState.Checked),
                new Herramientas(Resources.Visor_Mundos_2D, "Realistic world viewer in 2D", typeof(Ventana_Visor_Mundos_Realista_2D), CheckState.Checked),
                new Herramientas(Resources.NBT_Byte, "NBT viewer", typeof(Ventana_Visor_NBT), CheckState.Checked),
                new Herramientas(Resources.minecraft_emerald_block, "Villager tradings viewer", typeof(Ventana_Visor_Ofertas_Aldeanos), CheckState.Unchecked),
                new Herramientas(Resources.Visor_Skins_3D, "Animated 3D skin viewer", null, CheckState.Unchecked),
                new Herramientas(Resources.Subir, "Minecraft internal structures exporter", null, CheckState.Unchecked),
                new Herramientas(Resources.Item_enchanted_book, "Enchantment names viewer", null, CheckState.Unchecked),
                new Herramientas(Resources.minecraft_end_portal_frame, "The End screensaver (install it from the File menu)", null, CheckState.Unchecked),
                new Herramientas(Resources.Candado, "File encoder and decoder from Minecraft worlds", null, CheckState.Unchecked),
                new Herramientas(Resources.Aleatorio, "Start a random tool every time", null, CheckState.Unchecked),
            };

            internal static void Ejecutar_Herramienta(int Índice_Herramienta, bool Siempre_Visible, IWin32Window Ventana_Superior)
            {
                try
                {
                    if (Índice_Herramienta < 0 || Índice_Herramienta >= Matriz_Herramientas.Length)
                    {
                        Índice_Herramienta = Program.Rand.Next(0, Matriz_Herramientas.Length); // Select a random tool.
                    }
                    if (Índice_Herramienta > -1 && Índice_Herramienta < Matriz_Herramientas.Length)
                    {
                        Type Tipo = Matriz_Herramientas[Índice_Herramienta].Tipo;
                        if (Tipo == null) // None
                        {

                        }
                        else if (Tipo == typeof(Ventana_Acerca))
                        {
                            Ventana_Acerca Ventana = new Ventana_Acerca();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Administrador_Copias_Seguridad))
                        {
                            Ventana_Administrador_Copias_Seguridad Ventana = new Ventana_Administrador_Copias_Seguridad();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Afinador_Bloques_Nota))
                        {
                            Ventana_Afinador_Bloques_Nota Ventana = new Ventana_Afinador_Bloques_Nota();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Buscador_Chunks_Limos))
                        {
                            Ventana_Buscador_Chunks_Limos Ventana = new Ventana_Buscador_Chunks_Limos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Calculadora_Infinita_Semillas_Mundos))
                        {
                            Ventana_Calculadora_Infinita_Semillas_Mundos Ventana = new Ventana_Calculadora_Infinita_Semillas_Mundos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Comparador_Versiones_JAR))
                        {
                            Ventana_Comparador_Versiones_JAR Ventana = new Ventana_Comparador_Versiones_JAR();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Depurador_Excepciones))
                        {
                            Ventana_Depurador_Excepciones Ventana = new Ventana_Depurador_Excepciones();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Descargador_Skins_Automático))
                        {
                            Ventana_Descargador_Skins_Automático Ventana = new Ventana_Descargador_Skins_Automático();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Diseñador_Estandartes_Escudos))
                        {
                            Ventana_Diseñador_Estandartes_Escudos Ventana = new Ventana_Diseñador_Estandartes_Escudos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Exportador_Estructuras_Pintadas))
                        {
                            Ventana_Exportador_Estructuras_Pintadas Ventana = new Ventana_Exportador_Estructuras_Pintadas();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Generador_Estructuras_Personalizadas))
                        {
                            Ventana_Generador_Estructuras_Personalizadas Ventana = new Ventana_Generador_Estructuras_Personalizadas();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Generador_Miniaturas_Color_Medio))
                        {
                            Ventana_Generador_Miniaturas_Color_Medio Ventana = new Ventana_Generador_Miniaturas_Color_Medio();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Generador_Pixel_Art))
                        {
                            Ventana_Generador_Pixel_Art Ventana = new Ventana_Generador_Pixel_Art();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Gracias))
                        {
                            Ventana_Gracias Ventana = new Ventana_Gracias();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Información_Bloques))
                        {
                            Ventana_Información_Bloques Ventana = new Ventana_Información_Bloques();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Información_Miembros_Hermitcraft))
                        {
                            Ventana_Información_Miembros_Hermitcraft Ventana = new Ventana_Información_Miembros_Hermitcraft();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Nombre_Usuario))
                        {
                            Ventana_Nombre_Usuario Ventana = new Ventana_Nombre_Usuario();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Reconstructor_Estructura_Archivos_Recursos))
                        {
                            Ventana_Reconstructor_Estructura_Archivos_Recursos Ventana = new Ventana_Reconstructor_Estructura_Archivos_Recursos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Reloj_Minecraft_Tiempo_Real))
                        {
                            Ventana_Reloj_Minecraft_Tiempo_Real Ventana = new Ventana_Reloj_Minecraft_Tiempo_Real();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Selector_Bloques))
                        {
                            Ventana_Selector_Bloques Ventana = new Ventana_Selector_Bloques();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Visor_Ayuda))
                        {
                            Ventana_Visor_Ayuda Ventana = new Ventana_Visor_Ayuda();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Visor_Cuadros))
                        {
                            Ventana_Visor_Cuadros Ventana = new Ventana_Visor_Cuadros();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Visor_Información_Bloques))
                        {
                            Ventana_Visor_Información_Bloques Ventana = new Ventana_Visor_Información_Bloques();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Visor_Información_Entidades))
                        {
                            Ventana_Visor_Información_Entidades Ventana = new Ventana_Visor_Información_Entidades();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Visor_Mundos_Realista_2D))
                        {
                            Ventana_Visor_Mundos_Realista_2D Ventana = new Ventana_Visor_Mundos_Realista_2D();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Visor_NBT))
                        {
                            Ventana_Visor_NBT Ventana = new Ventana_Visor_NBT();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (Tipo == typeof(Ventana_Visor_Ofertas_Aldeanos))
                        {
                            Ventana_Visor_Ofertas_Aldeanos Ventana = new Ventana_Visor_Ofertas_Aldeanos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else MessageBox.Show(Ventana_Superior, "The selected tool couldn't be found or started.r\nMaybe it's under development and soon will be released.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else MessageBox.Show(Ventana_Superior, "The selected tool couldn't be found or started.r\nMaybe it's under development and soon will be released.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception Excepción)
                {
                    Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null);
                    MessageBox.Show(Ventana_Superior, "The selected tool couldn't be found or started.r\nMaybe it's under development and soon will be released.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        internal readonly string Texto_Título = "Tool Selector for " + Program.Texto_Usuario + " by Jupisoft";
        internal bool Variable_Siempre_Visible = false;
        internal bool Variable_Excepción = false;
        internal bool Variable_Excepción_Imagen = false;
        internal int Variable_Excepción_Total = 0;
        internal bool Variable_Memoria = false;
        internal static Stopwatch Cronómetro_FPS = Stopwatch.StartNew();
        internal long Segundo_FPS_Anterior = 0L;
        internal long FPS_Temporal = 0L;
        internal long FPS_Real = 0L;
        internal bool Ocupado = false;

        private void Ventana_Selector_Herramientas_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Texto_Título + " - [Registered tools: " + Program.Traducir_Número(Herramientas.Matriz_Herramientas.Length) + "]";
                //this.WindowState = FormWindowState.Maximized;
                for (int Índice = 0; Índice < Herramientas.Matriz_Herramientas.Length; Índice++)
                {
                    Lista_Imágenes_16.Images.Add(Herramientas.Matriz_Herramientas[Índice].Imagen);
                    ListViewItem Objeto = new ListViewItem(Herramientas.Matriz_Herramientas[Índice].Texto, Índice);
                    Objeto.ForeColor = Herramientas.Matriz_Herramientas[Índice].Estado == CheckState.Checked ? Color.Black : Herramientas.Matriz_Herramientas[Índice].Estado == CheckState.Indeterminate ? Color.Blue : Color.Red;
                    ListView_Principal.Items.Add(Objeto);
                }
                ListView_Principal.SmallImageList = Lista_Imágenes_16;
                ListView_Principal.LargeImageList = Lista_Imágenes_16;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Selector_Herramientas_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                //Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Selector_Herramientas_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Selector_Herramientas_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                /*ICSharpCode.SharpZipLib.Zip.Compression.Deflater Def = new ICSharpCode.SharpZipLib.Zip.Compression.Deflater(ICSharpCode.SharpZipLib.Zip.Compression.Deflater.DEFAULT_COMPRESSION);
                Def.Deflate(new byte[]);
                //Def.SetInput();
                ICSharpCode.SharpZipLib.Zip.ZipFile zip = ICSharpCode.SharpZipLib.Zip.ZipFile.Create();
                zip.Add("", ICSharpCode.SharpZipLib.Zip.CompressionMethod.Deflated);
                zip.Close();
                zip = null;*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Selector_Herramientas_KeyDown(object sender, KeyEventArgs e)
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

        private void CheckBox_Negro_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox_Negro.CheckState != CheckState.Checked) CheckBox_Negro.CheckState = CheckState.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Azul_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox_Azul.CheckState != CheckState.Indeterminate) CheckBox_Azul.CheckState = CheckState.Indeterminate;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Rojo_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox_Rojo.CheckState != CheckState.Unchecked) CheckBox_Rojo.CheckState = CheckState.Unchecked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

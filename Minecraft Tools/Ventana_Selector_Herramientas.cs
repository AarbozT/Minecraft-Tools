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
            internal string Texto;
            internal Bitmap Imagen;
            internal Type Tipo;
            internal string Texto_Tipo;
            internal CheckState Estado; 

            internal Herramientas(string Texto, Bitmap Imagen, Type Tipo, CheckState Estado)
            {
                this.Texto = Texto;
                this.Imagen = Imagen;
                this.Tipo = Tipo;
                this.Texto_Tipo = Tipo != null ? Tipo.FullName : string.Empty;
                this.Estado = Estado;
            }

            internal static readonly Herramientas[] Matriz_Herramientas = new Herramientas[]
            {
                //new Herramientas("Block information", Resources.Controles_TextBox, typeof(Ventana_Información_Bloques), CheckState.Checked),
                //new Herramientas("Start a random tool every time", Resources.Aleatorio, null, CheckState.Unchecked),
                new Herramientas("About", Resources.Jupisoft_16, typeof(Ventana_Acerca), CheckState.Checked),
                new Herramientas("Animated 3D skin viewer", Resources.Visor_Skins_3D, typeof(Ventana_Visor_Skins_Animado_3D), CheckState.Indeterminate),
                new Herramientas("Automatic skin downloader", Resources.Ordenar, typeof(Ventana_Descargador_Skins_Automático), CheckState.Unchecked),
                new Herramientas("Backups manager", Resources.Copia_Seguridad, typeof(Ventana_Administrador_Copias_Seguridad), CheckState.Unchecked),
                new Herramientas("Banner and shield designer", Resources.minecraft_red_banner, typeof(Ventana_Diseñador_Estandartes_Escudos), CheckState.Checked),
                new Herramientas("Block information viewer", Resources.Controles_TextBox, typeof(Ventana_Visor_Información_Bloques), CheckState.Checked),
                new Herramientas("Block selector", Resources.minecraft_stone, typeof(Ventana_Selector_Bloques), CheckState.Checked),
                new Herramientas("Blocks screen saver", Resources.minecraft_dirt, typeof(Ventana_Salvapantallas_Bloques), CheckState.Checked),
                new Herramientas("Change log", Resources.Registro_Cambios, typeof(Ventana_Registro_Cambios), CheckState.Checked),
                new Herramientas("Change the username", Resources.Usuario, typeof(Ventana_Nombre_Usuario), CheckState.Checked),
                new Herramientas("Comparer of Minecraft versions and resource packs", Resources.WinRAR, typeof(Ventana_Comparador_Versiones_JAR), CheckState.Checked),
                new Herramientas("Custom structures generator", Resources.minecraft_structure_block, typeof(Ventana_Generador_Estructuras_Personalizadas), CheckState.Indeterminate),
                new Herramientas("Damaged files rebuilder", Resources.Opciones, typeof(Ventana_Reconstructor_Archivos_Dañados), CheckState.Checked),
                new Herramientas("Donations received", Resources.Agregar, typeof(Ventana_Donaciones), CheckState.Checked),
                new Herramientas("Duplicated files finder", Resources.Copiar, typeof(Ventana_Buscador_Archivos_Duplicados), CheckState.Checked),
                new Herramientas("Enchantment names viewer", Resources.Item_enchanted_book, typeof(Ventana_Visor_Nombres_Encantamientos), CheckState.Checked),
                new Herramientas("Entities information viewer", Resources.minecraft_player_head, typeof(Ventana_Visor_Información_Entidades), CheckState.Checked),
                new Herramientas("Exception debugger", Resources.Excepción, typeof(Ventana_Depurador_Excepciones), CheckState.Checked),
                new Herramientas("File encoder and decoder from Minecraft worlds", Resources.Llave, typeof(Ventana_Codificador_Descodificador_Archivos), CheckState.Checked),
                new Herramientas("FPS counter", Resources.Temporizador, typeof(Ventana_Contador_FPS), CheckState.Checked),
                new Herramientas("Help viewer", Resources.Ayuda, typeof(Ventana_Visor_Ayuda), CheckState.Checked),
                new Herramientas("Hermitcraft members viewer", Resources.Xisumavoid, typeof(Ventana_Información_Miembros_Hermitcraft), CheckState.Checked),
                new Herramientas("Infiniscope [TOP SECRET]", Resources.Ojo_Ciego, typeof(Ventana_Infiniscopio), CheckState.Checked),
                new Herramientas("Júpiter Mauro scores viewer", Resources.Jupisoft_16, typeof(Ventana_Visor_Partituras_Júpiter_Mauro), CheckState.Checked),
                new Herramientas("Minecraft 1.13+ chunk format information viewer", Resources.Región, typeof(Ventana_Visor_Formato_Chunks_1_13), CheckState.Checked),
                new Herramientas("Minecraft 1.13+ to 1.12.2- world converter", Resources.Mundo, typeof(Ventana_Conversor_Mundos_1_13_a_1_12_2), CheckState.Checked),
                new Herramientas("Minecraft internal structures exporter", Resources.Bajar, typeof(Ventana_Exportador_Estructuras_Internas), CheckState.Unchecked),
                new Herramientas("Multidimensional mathematic analyzer", Resources.Fractal, typeof(Ventana_Analizador_Matemático_Multidimensional), CheckState.Checked),
                new Herramientas("Monster High characters", Resources.Monster_High, typeof(Ventana_Monster_High), CheckState.Checked),
                new Herramientas("NBT viewer", Resources.NBT_Byte, typeof(Ventana_Visor_NBT), CheckState.Checked),
                new Herramientas("Note blocks tuner", Resources.minecraft_note_block, typeof(Ventana_Afinador_Bloques_Nota), CheckState.Checked),
                new Herramientas("Painted structures exporter", Resources.Paleta, typeof(Ventana_Exportador_Estructuras_Pintadas), CheckState.Indeterminate),
                new Herramientas("Paintings viewer", Resources.Pool, typeof(Ventana_Visor_Cuadros), CheckState.Checked),
                new Herramientas("Pixel art generator with world exporter", Resources.Pixel_Art, typeof(Ventana_Generador_Pixel_Art), CheckState.Checked),
                new Herramientas("Real time Minecraft clock", Resources.Sol_Luna, typeof(Ventana_Reloj_Minecraft_Tiempo_Real), CheckState.Checked),
                new Herramientas("Real time screen filters", Resources.Pantalla, typeof(Ventana_Filtros_Pantalla_Tiempo_Real), CheckState.Checked),
                new Herramientas("Realistic 2D world viewer", Resources.Visor_Mundos_2D, typeof(Ventana_Visor_Mundos_Realista_2D), CheckState.Checked),
                new Herramientas("Redstone designer", Resources.minecraft_redstone_block, null, CheckState.Unchecked),
                new Herramientas("Resource packs converter", Resources.Pack_Recursos, typeof(Ventana_Conversor_Packs_Recursos), CheckState.Unchecked),
                new Herramientas("Resource structure rebuilder", Resources.Controles_TreeView, typeof(Ventana_Reconstructor_Estructura_Archivos_Recursos), CheckState.Checked),
                new Herramientas("Secrets: hidden", Resources.Candado, typeof(Ventana_Secretos), CheckState.Checked),
                new Herramientas("Slime chunks and structures finder", Resources.minecraft_slime_block, typeof(Ventana_Buscador_Chunks_Limos_Estructuras), CheckState.Checked),
                new Herramientas("Structure generator through commands", Resources.minecraft_command_block, null, CheckState.Unchecked),
                new Herramientas("Thank you", Resources.Lista, typeof(Ventana_Gracias), CheckState.Checked),
                new Herramientas("The End screensaver (WIP, too much lag)", Resources.minecraft_end_portal_frame, typeof(Ventana_Salvapantallas_El_Fin), CheckState.Unchecked),
                new Herramientas("Thumbnails and average color generator", Resources.Ojo, typeof(Ventana_Generador_Miniaturas_Color_Medio), CheckState.Checked),
                new Herramientas("Villager tradings viewer", Resources.minecraft_emerald_block, typeof(Ventana_Visor_Ofertas_Aldeanos), CheckState.Checked),
                new Herramientas("World seeds infinite calculator", Resources.Calculadora, typeof(Ventana_Calculadora_Infinita_Semillas_Mundos), CheckState.Checked),
                //new Herramientas("None (select it manually everytime)", Resources.Ejecutar, null, CheckState.Checked),
            };

            internal static void Ejecutar_Herramienta(int Índice_Herramienta, bool Siempre_Visible, Form Ventana_Superior)
            {
                try
                {
                    if (Índice_Herramienta < 0 || Índice_Herramienta >= Matriz_Herramientas.Length)
                    {
                        Índice_Herramienta = Program.Rand.Next(0, Matriz_Herramientas.Length); // Select a random tool.
                    }
                    if (Índice_Herramienta > -1 && Índice_Herramienta < Matriz_Herramientas.Length)
                    {
                        string Texto_Tipo = Matriz_Herramientas[Índice_Herramienta].Texto_Tipo;
                        if (string.IsNullOrEmpty(Texto_Tipo)) // None
                        {
                            // Do nothing.
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Acerca).FullName, true) == 0)
                        {
                            Ventana_Acerca Ventana = new Ventana_Acerca();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Administrador_Copias_Seguridad).FullName, true) == 0)
                        {
                            Ventana_Administrador_Copias_Seguridad Ventana = new Ventana_Administrador_Copias_Seguridad();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Afinador_Bloques_Nota).FullName, true) == 0)
                        {
                            Ventana_Afinador_Bloques_Nota Ventana = new Ventana_Afinador_Bloques_Nota();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Salvapantallas_Bloques).FullName, true) == 0)
                        {
                            Ventana_Salvapantallas_Bloques Ventana = new Ventana_Salvapantallas_Bloques();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Buscador_Chunks_Limos_Estructuras).FullName, true) == 0)
                        {
                            Ventana_Buscador_Chunks_Limos_Estructuras Ventana = new Ventana_Buscador_Chunks_Limos_Estructuras();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Calculadora_Infinita_Semillas_Mundos).FullName, true) == 0)
                        {
                            Ventana_Calculadora_Infinita_Semillas_Mundos Ventana = new Ventana_Calculadora_Infinita_Semillas_Mundos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Codificador_Descodificador_Archivos).FullName, true) == 0)
                        {
                            Ventana_Codificador_Descodificador_Archivos Ventana = new Ventana_Codificador_Descodificador_Archivos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Comparador_Versiones_JAR).FullName, true) == 0)
                        {
                            Ventana_Comparador_Versiones_JAR Ventana = new Ventana_Comparador_Versiones_JAR();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Depurador_Excepciones).FullName, true) == 0)
                        {
                            Ventana_Depurador_Excepciones Ventana = new Ventana_Depurador_Excepciones();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Skins_Animado_3D).FullName, true) == 0)
                        {
                            Ventana_Visor_Skins_Animado_3D Ventana = new Ventana_Visor_Skins_Animado_3D();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Descargador_Skins_Automático).FullName, true) == 0)
                        {
                            Ventana_Descargador_Skins_Automático Ventana = new Ventana_Descargador_Skins_Automático();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Diseñador_Estandartes_Escudos).FullName, true) == 0)
                        {
                            Ventana_Diseñador_Estandartes_Escudos Ventana = new Ventana_Diseñador_Estandartes_Escudos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Exportador_Estructuras_Internas).FullName, true) == 0)
                        {
                            Ventana_Exportador_Estructuras_Internas Ventana = new Ventana_Exportador_Estructuras_Internas();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Analizador_Matemático_Multidimensional).FullName, true) == 0)
                        {
                            Ventana_Analizador_Matemático_Multidimensional Ventana = new Ventana_Analizador_Matemático_Multidimensional();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Formato_Chunks_1_13).FullName, true) == 0)
                        {
                            Ventana_Visor_Formato_Chunks_1_13 Ventana = new Ventana_Visor_Formato_Chunks_1_13();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Conversor_Mundos_1_13_a_1_12_2).FullName, true) == 0)
                        {
                            Ventana_Conversor_Mundos_1_13_a_1_12_2 Ventana = new Ventana_Conversor_Mundos_1_13_a_1_12_2();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Monster_High).FullName, true) == 0)
                        {
                            Ventana_Monster_High Ventana = new Ventana_Monster_High();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Exportador_Estructuras_Pintadas).FullName, true) == 0)
                        {
                            Ventana_Exportador_Estructuras_Pintadas Ventana = new Ventana_Exportador_Estructuras_Pintadas();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Filtros_Pantalla_Tiempo_Real).FullName, true) == 0)
                        {
                            Ventana_Superior.Visible = false;
                            Ventana_Filtros_Pantalla_Tiempo_Real Ventana = new Ventana_Filtros_Pantalla_Tiempo_Real();
                            //Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                            Ventana_Superior.Visible = true;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Generador_Estructuras_Personalizadas).FullName, true) == 0)
                        {
                            Ventana_Generador_Estructuras_Personalizadas Ventana = new Ventana_Generador_Estructuras_Personalizadas();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Generador_Miniaturas_Color_Medio).FullName, true) == 0)
                        {
                            Ventana_Generador_Miniaturas_Color_Medio Ventana = new Ventana_Generador_Miniaturas_Color_Medio();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Generador_Pixel_Art).FullName, true) == 0)
                        {
                            Ventana_Generador_Pixel_Art Ventana = new Ventana_Generador_Pixel_Art();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Gracias).FullName, true) == 0)
                        {
                            Ventana_Gracias Ventana = new Ventana_Gracias();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Información_Bloques).FullName, true) == 0)
                        {
                            Ventana_Información_Bloques Ventana = new Ventana_Información_Bloques();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Registro_Cambios).FullName, true) == 0)
                        {
                            Ventana_Registro_Cambios Ventana = new Ventana_Registro_Cambios();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Nombre_Usuario).FullName, true) == 0)
                        {
                            Ventana_Nombre_Usuario Ventana = new Ventana_Nombre_Usuario();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Reconstructor_Estructura_Archivos_Recursos).FullName, true) == 0)
                        {
                            Ventana_Reconstructor_Estructura_Archivos_Recursos Ventana = new Ventana_Reconstructor_Estructura_Archivos_Recursos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Secretos).FullName, true) == 0)
                        {
                            Ventana_Secretos Ventana = new Ventana_Secretos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Reloj_Minecraft_Tiempo_Real).FullName, true) == 0)
                        {
                            Ventana_Reloj_Minecraft_Tiempo_Real Ventana = new Ventana_Reloj_Minecraft_Tiempo_Real();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Salvapantallas_El_Fin).FullName, true) == 0)
                        {
                            Ventana_Salvapantallas_El_Fin Ventana = new Ventana_Salvapantallas_El_Fin();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Selector_Bloques).FullName, true) == 0)
                        {
                            Ventana_Selector_Bloques Ventana = new Ventana_Selector_Bloques();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Contador_FPS).FullName, true) == 0)
                        {
                            Ventana_Superior.Visible = false;
                            Ventana_Contador_FPS Ventana = new Ventana_Contador_FPS();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                            Ventana_Superior.Visible = true;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Ayuda).FullName, true) == 0)
                        {
                            Ventana_Visor_Ayuda Ventana = new Ventana_Visor_Ayuda();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Información_Miembros_Hermitcraft).FullName, true) == 0)
                        {
                            Ventana_Información_Miembros_Hermitcraft Ventana = new Ventana_Información_Miembros_Hermitcraft();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Infiniscopio).FullName, true) == 0)
                        {
                            Ventana_Infiniscopio Ventana = new Ventana_Infiniscopio();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Partituras_Júpiter_Mauro).FullName, true) == 0)
                        {
                            Ventana_Visor_Partituras_Júpiter_Mauro Ventana = new Ventana_Visor_Partituras_Júpiter_Mauro();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Cuadros).FullName, true) == 0)
                        {
                            Ventana_Visor_Cuadros Ventana = new Ventana_Visor_Cuadros();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Información_Bloques).FullName, true) == 0)
                        {
                            Ventana_Visor_Información_Bloques Ventana = new Ventana_Visor_Información_Bloques();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Información_Entidades).FullName, true) == 0)
                        {
                            Ventana_Visor_Información_Entidades Ventana = new Ventana_Visor_Información_Entidades();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Mundos_Realista_2D).FullName, true) == 0)
                        {
                            Ventana_Visor_Mundos_Realista_2D Ventana = new Ventana_Visor_Mundos_Realista_2D();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_NBT).FullName, true) == 0)
                        {
                            Ventana_Visor_NBT Ventana = new Ventana_Visor_NBT();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Reconstructor_Archivos_Dañados).FullName, true) == 0)
                        {
                            Ventana_Reconstructor_Archivos_Dañados Ventana = new Ventana_Reconstructor_Archivos_Dañados();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Donaciones).FullName, true) == 0)
                        {
                            Ventana_Donaciones Ventana = new Ventana_Donaciones();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Buscador_Archivos_Duplicados).FullName, true) == 0)
                        {
                            Ventana_Buscador_Archivos_Duplicados Ventana = new Ventana_Buscador_Archivos_Duplicados();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Nombres_Encantamientos).FullName, true) == 0)
                        {
                            Ventana_Visor_Nombres_Encantamientos Ventana = new Ventana_Visor_Nombres_Encantamientos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Ofertas_Aldeanos).FullName, true) == 0)
                        {
                            Ventana_Visor_Ofertas_Aldeanos Ventana = new Ventana_Visor_Ofertas_Aldeanos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Conversor_Packs_Recursos).FullName, true) == 0)
                        {
                            Ventana_Conversor_Packs_Recursos Ventana = new Ventana_Conversor_Packs_Recursos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else MessageBox.Show(Ventana_Superior, "The selected tool couldn't be found or started yet.\nProbably it's under development and soon will be fully released.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else MessageBox.Show(Ventana_Superior, "The selected tool couldn't be found or started yet.\nProbably it's under development and soon will be fully released.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception Excepción)
                {
                    Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null);
                    MessageBox.Show(Ventana_Superior, "The selected tool couldn't be found or started yet.\nProbably it's under development and soon will be fully released.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        internal int Índice_Herramienta = -1;

        /// <summary>
        /// This variable is used to know if the user is selecting the default start tool.
        /// </summary>
        internal bool Seleccionar_Herramienta_Inicio = false;

        //internal int Matiz_Infiniscopio = 0;
        //internal ListViewItem Objeto_Infiniscopio = null;

        private void Ventana_Selector_Herramientas_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                //this.WindowState = FormWindowState.Maximized;
                this.Text = Texto_Título + (!Seleccionar_Herramienta_Inicio ? " - [Registered tools: " + Program.Traducir_Número(Herramientas.Matriz_Herramientas.Length) + "]" : " - [Click accept without a selected tool to delete the stored one]");
                for (int Índice = 0; Índice < Herramientas.Matriz_Herramientas.Length; Índice++)
                {
                    Lista_Imágenes_16.Images.Add(Herramientas.Matriz_Herramientas[Índice].Imagen);
                    ListViewItem Objeto = new ListViewItem(Herramientas.Matriz_Herramientas[Índice].Texto, Índice);
                    Objeto.ForeColor = Herramientas.Matriz_Herramientas[Índice].Estado == CheckState.Checked ? Color.Black : Herramientas.Matriz_Herramientas[Índice].Estado == CheckState.Indeterminate ? Color.Blue : Color.Red;
                    ListView_Principal.Items.Add(Objeto);
                    if (string.Compare(Herramientas.Matriz_Herramientas[Índice].Texto, "Infiniscope [TOP SECRET]", true) == 0 || string.Compare(Herramientas.Matriz_Herramientas[Índice].Texto, "Secrets: hidden", true) == 0 || string.Compare(Herramientas.Matriz_Herramientas[Índice].Texto, "Multidimensional mathematic analyzer", true) == 0)
                    {
                        Objeto.BackColor = Color.Yellow;
                        //Objeto.ForeColor = Color.White;
                        //Objeto_Infiniscopio = Objeto;
                    }
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

        private void CheckBox_Amarillo_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox_Amarillo.CheckState != CheckState.Checked) CheckBox_Amarillo.CheckState = CheckState.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ListView_Principal_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    ListViewItem Objeto = ListView_Principal.HitTest(e.Location).Item;
                    if (Objeto != null)
                    {
                        Índice_Herramienta = Objeto.Index;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ListView_Principal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                /*if (e.Button == MouseButtons.Left)
                {
                    ListViewItem Objeto = ListView_Principal.HitTest(e.Location).Item;
                    if (Objeto != null)
                    {
                        Índice_Herramienta = Objeto.Index;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Restablecer_Click(object sender, EventArgs e)
        {
            try
            {
                Índice_Herramienta = -1;
                // Finish this.
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Aleatorizar_Click(object sender, EventArgs e)
        {
            try
            {
                Índice_Herramienta = int.MaxValue;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Índice_Herramienta > -1)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Índice_Herramienta = -1;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ListView_Principal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ListView_Principal.SelectedIndices != null && ListView_Principal.SelectedIndices.Count > 0)
                {
                    foreach (int Índice in ListView_Principal.SelectedIndices)
                    {
                        Índice_Herramienta = Índice;
                    }
                }
                else Índice_Herramienta = -1;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ListView_Principal_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Índice_Herramienta = -1;
                    this.DialogResult = DialogResult.Cancel;
                    this.Close(); // Since it can be accidentally started from the main window, allow for a fast closing without using the keyboard.
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Temporizador_Principal_Tick(object sender, EventArgs e)
        {
            try
            {
                /*Temporizador_Principal.Stop();
                return;
                if (Objeto_Infiniscopio != null)
                {
                    ListView_Principal.BeginUpdate();
                    Objeto_Infiniscopio.ForeColor = Program.Obtener_Color_Puro_1530(Matiz_Infiniscopio);
                    Matiz_Infiniscopio += 1530 / 12;
                    if (Matiz_Infiniscopio >= 1530) Matiz_Infiniscopio = 0;
                    //ListView_Principal.Invalidate(Objeto_Infiniscopio.GetBounds(ItemBoundsPortion.Entire));
                    ListView_Principal.EndUpdate();
                    //ListView_Principal.Update();
                    //ListView_Principal.Refresh();
                }*/
            }
            catch (Exception Excepción)
            {
                Temporizador_Principal.Stop();
                Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true;
            }
        }
    }
}

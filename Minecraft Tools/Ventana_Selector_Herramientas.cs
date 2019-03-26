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
        /// Enumeration that defines the current state of a tool.
        /// </summary>
        internal enum Estados : int
        {
            /// <summary>
            /// Not working.
            /// </summary>
            Inoperativo = 0,
            /// <summary>
            /// Might work.
            /// </summary>
            Intermedio,
            /// <summary>
            /// It's working.
            /// </summary>
            Funcional
        }

        internal static readonly ListViewGroup Grupo_Minecraft = new ListViewGroup("Minecraft tools  (they are directly related to Minecraft and might be hard to use without it)");
        internal static readonly ListViewGroup Grupo_Universal = new ListViewGroup("Universal tools  (use them for other things besides Minecraft and you'll be surprised)");
        internal static readonly ListViewGroup Grupo_Conocimiento = new ListViewGroup("Knowledge tools  (they might give you advanced knowledge about a lot of secret things)");
        internal static readonly ListViewGroup Grupo_Jupisoft = new ListViewGroup("Application tools  (they let you see or change extra information about this application)");
        internal static readonly ListViewGroup Grupo_Incompleto = new ListViewGroup("Unfinished tools  (sorry, I didn't had enough time to finish them for now, but eventually I will)");

        /// <summary>
        /// Structure that holds up all the information about a tool of this application.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Herramientas
        {
            internal string Texto;
            internal Bitmap Imagen;
            internal Estados Estado;
            internal bool Secretos;
            internal ListViewGroup Grupo;
            internal Type Tipo;
            internal string Texto_Tipo;
            internal DateTime Fecha;

            internal Herramientas(string Texto, Bitmap Imagen, Estados Estado, bool Secretos, ListViewGroup Grupo, Type Tipo, DateTime Fecha)
            {
                this.Texto = Texto;
                this.Imagen = Imagen;
                this.Estado = Estado;
                this.Secretos = Secretos;
                this.Grupo = Grupo;
                this.Tipo = Tipo;
                this.Texto_Tipo = Tipo != null ? Tipo.FullName : string.Empty;
                this.Fecha = Fecha;
            }

            internal static readonly Herramientas[] Matriz_Herramientas = new Herramientas[]
            {
                //new Herramientas("Block information", Resources.Controles_TextBox, typeof(Ventana_Información_Bloques), CheckState.Checked),
                //new Herramientas("Start a random tool every time", Resources.Aleatorio, null, CheckState.Unchecked),
                new Herramientas("3D block viewer with generator and exporter", Resources.Minecraft, Estados.Funcional, false, Grupo_Universal, typeof(Ventana_Visor_Bloques_3D), new DateTime(2019, 3, 7)),
                new Herramientas("About", Resources.Jupisoft_16, Estados.Funcional, false, Grupo_Jupisoft, typeof(Ventana_Acerca), new DateTime(2018, 3, 17)),
                new Herramientas("Animated 3D skin viewer", Resources.Visor_Skins_3D, Estados.Inoperativo, false, Grupo_Minecraft, typeof(Ventana_Visor_Skins_Animado_3D), new DateTime(2018, 3, 17)),
                new Herramientas("Automatic skin downloader", Resources.Ordenar, Estados.Inoperativo, false, Grupo_Minecraft, typeof(Ventana_Descargador_Skins_Automático), new DateTime(2018, 3, 17)),
                new Herramientas("Backups manager", Resources.Copia_Seguridad, Estados.Inoperativo, false, Grupo_Jupisoft, typeof(Ventana_Administrador_Copias_Seguridad), new DateTime(2018, 3, 17)),
                new Herramientas("Banner and shield designer", Resources.minecraft_red_banner, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Diseñador_Estandartes_Escudos), new DateTime(2018, 3, 17)),
                new Herramientas("Block information viewer", Resources.Controles_TextBox, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Visor_Información_Bloques), new DateTime(2018, 3, 17)),
                new Herramientas("Block selector", Resources.minecraft_stone, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Selector_Bloques), new DateTime(2018, 3, 17)),
                new Herramientas("Blocks screen saver in 3D with Windows installer", Resources.minecraft_dirt, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Salvapantallas_Bloques), new DateTime(2018, 3, 17)),
                new Herramientas("Change log", Resources.Registro_Cambios, Estados.Funcional, false, Grupo_Jupisoft, typeof(Ventana_Registro_Cambios), new DateTime(2018, 3, 17)),
                new Herramientas("Change the username", Resources.Usuario, Estados.Funcional, false, Grupo_Jupisoft, typeof(Ventana_Nombre_Usuario), new DateTime(2018, 3, 17)),
                new Herramientas("Comparer of Minecraft versions and resource packs", Resources.WinRAR, Estados.Funcional, false, Grupo_Universal, typeof(Ventana_Comparador_Versiones_JAR), new DateTime(2018, 3, 17)),
                new Herramientas("Custom light level resource packs generator [Optifine]", Resources.Visión_Nocturna, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Generador_Packs_Recursos_Nivel_Luz), new DateTime(2019, 3, 26)),
                new Herramientas("Custom structures generator", Resources.minecraft_structure_block, Estados.Intermedio, false, Grupo_Minecraft, typeof(Ventana_Generador_Estructuras_Personalizadas), new DateTime(2018, 3, 17)),
                new Herramientas("Damaged files rebuilder", Resources.Opciones, Estados.Funcional, false, Grupo_Universal, typeof(Ventana_Reconstructor_Archivos_Dañados), new DateTime(2019, 2, 13)),
                new Herramientas("Donations received", Resources.Agregar, Estados.Funcional, false, Grupo_Jupisoft, typeof(Ventana_Donaciones), new DateTime(2018, 10, 11)),
                new Herramientas("Duplicated files finder", Resources.Copiar, Estados.Funcional, false, Grupo_Universal, typeof(Ventana_Buscador_Archivos_Duplicados), new DateTime(2018, 10, 21)),
                new Herramientas("Enchantment names viewer", Resources.Item_enchanted_book, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Visor_Nombres_Encantamientos), new DateTime(2018, 3, 17)),
                new Herramientas("Entities information viewer", Resources.minecraft_player_head, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Visor_Información_Entidades), new DateTime(2018, 3, 17)),
                new Herramientas("Exception debugger", Resources.Excepción, Estados.Funcional, false, Grupo_Jupisoft, typeof(Ventana_Depurador_Excepciones), new DateTime(2018, 3, 17)),
                new Herramientas("File encoder and decoder from Minecraft worlds", Resources.Llave, Estados.Funcional, false, Grupo_Universal, typeof(Ventana_Codificador_Descodificador_Archivos), new DateTime(2018, 3, 17)),
                new Herramientas("FPS counter", Resources.Temporizador, Estados.Funcional, false, Grupo_Universal, typeof(Ventana_Contador_FPS), new DateTime(2018, 10, 21)),
                new Herramientas("Help viewer", Resources.Ayuda, Estados.Funcional, false, Grupo_Jupisoft, typeof(Ventana_Visor_Ayuda), new DateTime(2018, 3, 17)),
                new Herramientas("Hermitcraft members viewer", Resources.Xisumavoid, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Información_Miembros_Hermitcraft), new DateTime(2018, 3, 17)),
                new Herramientas("Infiniscope [TOP SECRET]", Resources.Ojo_Ciego, Estados.Funcional, true, Grupo_Conocimiento, typeof(Ventana_Infiniscopio), new DateTime(2019, 2, 13)),
                new Herramientas("Júpiter Mauro scores viewer [all under Creative Commons]", Resources.Jupisoft_16, Estados.Funcional, false, Grupo_Conocimiento, typeof(Ventana_Visor_Partituras_Júpiter_Mauro), new DateTime(2018, 3, 17)),
                new Herramientas("Magic card guessing", Resources.Montón_Centro, Estados.Funcional, false, Grupo_Conocimiento, typeof(Ventana_Adivinación_Carta_Mágica), new DateTime(2018, 3, 17)),
                new Herramientas("Minecraft 1.13+ chunk format information viewer", Resources.Región, Estados.Funcional, true, Grupo_Conocimiento, typeof(Ventana_Visor_Formato_Chunks_1_13), new DateTime(2019, 2, 13)),
                new Herramientas("Minecraft 1.13+ to 1.12.2- world converter", Resources.Mundo, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Conversor_Mundos_1_13_a_1_12_2), new DateTime(2018, 3, 17)),
                new Herramientas("Minecraft internal structures exporter", Resources.Bajar, Estados.Inoperativo, false, Grupo_Minecraft, typeof(Ventana_Exportador_Estructuras_Internas), new DateTime(2018, 3, 17)),
                new Herramientas("Multidimensional mathematical analyzer [TOP SECRET]", Resources.Fractal, Estados.Funcional, true, Grupo_Conocimiento, typeof(Ventana_Analizador_Matemático_Multidimensional), new DateTime(2019, 2, 13)),
                new Herramientas("Monster High characters", Resources.Monster_High, Estados.Funcional, false, Grupo_Conocimiento, typeof(Ventana_Monster_High), new DateTime(2018, 10, 21)),
                new Herramientas("NBT viewer", Resources.NBT_Byte, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Visor_NBT), new DateTime(2018, 3, 17)),
                new Herramientas("Note blocks tuner", Resources.minecraft_note_block, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Afinador_Bloques_Nota), new DateTime(2018, 3, 17)),
                new Herramientas("Painted structures exporter", Resources.Paleta, Estados.Intermedio, false, Grupo_Minecraft, typeof(Ventana_Exportador_Estructuras_Pintadas), new DateTime(2018, 3, 17)),
                new Herramientas("Paintings viewer", Resources.Pool, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Visor_Cuadros), new DateTime(2018, 3, 17)),
                new Herramientas("Pixel art generator with world exporter", Resources.Pixel_Art, Estados.Funcional, false, Grupo_Universal, typeof(Ventana_Generador_Pixel_Art), new DateTime(2018, 3, 17)),
                new Herramientas("Real time Minecraft clock", Resources.Sol_Luna, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Reloj_Minecraft_Tiempo_Real), new DateTime(2018, 3, 17)),
                new Herramientas("Real time screen filters", Resources.Pantalla, Estados.Funcional, true, Grupo_Universal, typeof(Ventana_Filtros_Pantalla_Tiempo_Real), new DateTime(2019, 1, 21)),
                new Herramientas("Realistic 2D world viewer", Resources.Visor_Mundos_2D, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Visor_Mundos_Realista_2D), new DateTime(2018, 3, 17)),
                new Herramientas("Recipe viewer", Resources.Menú_Contextual, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Visor_Recetas), new DateTime(2018, 3, 17)),
                new Herramientas("Redstone designer", Resources.minecraft_redstone_block, Estados.Inoperativo, false, Grupo_Minecraft, null, new DateTime(2018, 3, 17)),
                new Herramientas("Resource packs converter with zip and folder support", Resources.Pack_Recursos, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Conversor_Packs_Recursos), new DateTime(2019, 3, 11)),
                new Herramientas("Resource structure rebuilder", Resources.Controles_TreeView, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Reconstructor_Estructura_Archivos_Recursos), new DateTime(2018, 3, 17)),
                new Herramientas("Secrets: hidden", Resources.Candado, Estados.Funcional, true, Grupo_Conocimiento, typeof(Ventana_Secretos), new DateTime(2018, 3, 17)),
                new Herramientas("Sky box resource packs generator [Optifine]", Resources.Cielo, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Generador_Packs_Recursos_Cielos), new DateTime(2019, 3, 24)),
                //new Herramientas("Sky simulator in 3D", Resources.Cielo, Estados.Inoperativo, false, Grupo_Minecraft, typeof(Ventana_Simulador_Cielo_3D), new DateTime(2019, 3, 3)),
                new Herramientas("Slime chunks and structures finder", Resources.minecraft_slime_block, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Buscador_Chunks_Limos_Estructuras), new DateTime(2018, 3, 17)),
                new Herramientas("Structure generator through commands", Resources.minecraft_command_block, Estados.Inoperativo, false, Grupo_Minecraft, null, new DateTime(2018, 3, 17)),
                new Herramientas("Useful seeds registry", Resources.Item_wheat_seeds, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Registro_Semillas_Útiles), new DateTime(2019, 3, 12)),
                new Herramientas("Thank you", Resources.Lista, Estados.Funcional, false, Grupo_Jupisoft, typeof(Ventana_Gracias), new DateTime(2018, 3, 17)),
                new Herramientas("The End screensaver (WIP)", Resources.minecraft_end_portal_frame, Estados.Intermedio, false, Grupo_Minecraft, typeof(Ventana_Salvapantallas_El_Fin), new DateTime(2018, 3, 17)),
                new Herramientas("Thumbnails and average color generator", Resources.Ojo, Estados.Funcional, false, Grupo_Universal, typeof(Ventana_Generador_Miniaturas_Color_Medio), new DateTime(2018, 3, 17)),
                new Herramientas("Villager tradings viewer", Resources.minecraft_emerald_block, Estados.Funcional, false, Grupo_Minecraft, typeof(Ventana_Visor_Ofertas_Aldeanos), new DateTime(2018, 3, 17)),
                new Herramientas("Virtual moon", Resources.Luna, Estados.Intermedio, false, Grupo_Universal, typeof(Ventana_Luna_Virtual), new DateTime(2019, 3, 3)),
                new Herramientas("World seeds infinite calculator", Resources.Calculadora, Estados.Funcional, false, Grupo_Universal, typeof(Ventana_Calculadora_Infinita_Semillas_Mundos), new DateTime(2018, 3, 17)),
                new Herramientas("XNA resources extractor [don't use it for illegal things]", Resources.XNA, Estados.Funcional, false, Grupo_Universal, typeof(Ventana_Extractor_Recursos_XNA), new DateTime(2019, 3, 23)),
                //new Herramientas("None (select it manually everytime)", Resources.Ejecutar, Estados.Funcional, Categorías.Normal, null, new DateTime(2018, 3, 17)),
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
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Bloques_3D).FullName, true) == 0)
                        {
                            Ventana_Visor_Bloques_3D Ventana = new Ventana_Visor_Bloques_3D();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
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
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Extractor_Recursos_XNA).FullName, true) == 0)
                        {
                            Ventana_Extractor_Recursos_XNA Ventana = new Ventana_Extractor_Recursos_XNA();
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
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Generador_Packs_Recursos_Nivel_Luz).FullName, true) == 0)
                        {
                            Ventana_Generador_Packs_Recursos_Nivel_Luz Ventana = new Ventana_Generador_Packs_Recursos_Nivel_Luz();
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
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Adivinación_Carta_Mágica).FullName, true) == 0)
                        {
                            Ventana_Adivinación_Carta_Mágica Ventana = new Ventana_Adivinación_Carta_Mágica();
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
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Registro_Semillas_Útiles).FullName, true) == 0)
                        {
                            Ventana_Registro_Semillas_Útiles Ventana = new Ventana_Registro_Semillas_Útiles();
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
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Generador_Packs_Recursos_Cielos).FullName, true) == 0)
                        {
                            Ventana_Generador_Packs_Recursos_Cielos Ventana = new Ventana_Generador_Packs_Recursos_Cielos();
                            Ventana.Variable_Siempre_Visible = Siempre_Visible;
                            Ventana.ShowDialog(Ventana_Superior);
                            Ventana.Dispose();
                            Ventana = null;
                        }
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Simulador_Cielo_3D).FullName, true) == 0)
                        {
                            Ventana_Simulador_Cielo_3D Ventana = new Ventana_Simulador_Cielo_3D();
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
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Visor_Recetas).FullName, true) == 0)
                        {
                            Ventana_Visor_Recetas Ventana = new Ventana_Visor_Recetas();
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
                        else if (string.Compare(Texto_Tipo, typeof(Ventana_Luna_Virtual).FullName, true) == 0)
                        {
                            Ventana_Luna_Virtual Ventana = new Ventana_Luna_Virtual();
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
                ListView_Principal.Groups.Add(Grupo_Minecraft);
                ListView_Principal.Groups.Add(Grupo_Universal);
                ListView_Principal.Groups.Add(Grupo_Conocimiento);
                ListView_Principal.Groups.Add(Grupo_Jupisoft);
                ListView_Principal.Groups.Add(Grupo_Incompleto);
                DateTime Fecha = DateTime.Now;
                TimeSpan Intervalo = new TimeSpan(100, 0, 0, 0, 0);
                for (int Índice = 0; Índice < Herramientas.Matriz_Herramientas.Length; Índice++)
                {
                    Lista_Imágenes_16.Images.Add(Herramientas.Matriz_Herramientas[Índice].Imagen);
                    ListViewItem Objeto = new ListViewItem(Herramientas.Matriz_Herramientas[Índice].Texto, Índice);

                    if (Herramientas.Matriz_Herramientas[Índice].Estado == Estados.Funcional)
                    {
                        Objeto.ForeColor = Color.Black;
                    }
                    else if (Herramientas.Matriz_Herramientas[Índice].Estado == Estados.Intermedio)
                    {
                        Objeto.ForeColor = Color.Blue;
                    }
                    else if (Herramientas.Matriz_Herramientas[Índice].Estado == Estados.Inoperativo)
                    {
                        Objeto.ForeColor = Color.Red;
                    }
                    else Objeto.ForeColor = Color.Gray; // Unknown.

                    if (Herramientas.Matriz_Herramientas[Índice].Secretos)
                    {
                        Objeto.BackColor = Color.FromArgb(255, 255, 255, 144); // Secret tool.
                    }
                    else if (Fecha - Herramientas.Matriz_Herramientas[Índice].Fecha <= Intervalo)
                    {
                        Objeto.BackColor = Color.FromArgb(255, 240, 240, 240); // New tool.
                    }

                    if (Herramientas.Matriz_Herramientas[Índice].Estado != Estados.Inoperativo)
                    {
                        Objeto.Group = Herramientas.Matriz_Herramientas[Índice].Grupo;
                    }
                    else
                    {
                        Objeto.Group = Grupo_Incompleto;
                    }

                    ListView_Principal.Items.Add(Objeto);
                    if (Program.Edición_Aplicación != CheckState.Unchecked)
                    {
                        if (Program.Edición_Aplicación == CheckState.Checked)
                        {
                            if (string.Compare(Herramientas.Matriz_Herramientas[Índice].Texto_Tipo, typeof(Ventana_Filtros_Pantalla_Tiempo_Real).FullName, true) == 0)
                            {
                                Objeto.Selected = true;
                            }
                        }
                        else if (Program.Edición_Aplicación == CheckState.Indeterminate)
                        {
                            if (string.Compare(Herramientas.Matriz_Herramientas[Índice].Texto_Tipo, typeof(Ventana_Analizador_Matemático_Multidimensional).FullName, true) == 0)
                            {
                                Objeto.Selected = true;
                            }
                        }
                    }
                }
                this.Text = Texto_Título + (!Seleccionar_Herramienta_Inicio ? " - [Registered tools: " + Program.Traducir_Número(Herramientas.Matriz_Herramientas.Length) + ", in " + Program.Traducir_Número(ListView_Principal.Groups.Count) + (ListView_Principal.Groups.Count != 1 ? " groups]" : " group]") : " - [Click accept without a selected tool to delete the stored one]");
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

        private void CheckBox_Gris_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox_Gris.CheckState != CheckState.Checked) CheckBox_Gris.CheckState = CheckState.Checked;
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

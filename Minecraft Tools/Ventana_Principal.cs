using Microsoft.Win32;
using Minecraft_Tools.Properties;
using SevenZip;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Principal : Form
    {
        public Ventana_Principal()
        {
            InitializeComponent();
        }

        internal enum Herramientas : int
        {
            Ninguna = 0,

            Visor_Mundos_Realista_2D,
            Buscador_Chunks_Limos,
            Visor_Skins_Animado_3D,
            Calculadora_Infinita_Semillas_Mundos,

            Generador_Pixel_Art_Exportador_Mundos,
            Exportador_Estructuras_Pintadas,
            Generador_Estructuras_Personalizadas,
            Generador_Miniaturas_Color_Medio,

            Visor_NBT,
            Buscador_Diferencias_Versiones_JAR,
            Diseñador_Piedra_Rojiza,
            Generador_Estructuras_Comandos,

            Reloj_Minecraft_Tiempo_Real,
            Visor_Información_Bloques,
            Administrador_Copias_Seguridad,
            Descargador_Skins_Automático,

            Visor_Cuadros,
            Afinador_Bloques_Nota,
            Diseñador_Estandartes_Escudos,
            Visor_Ofertas_Aldeanos,

            Visor_Información_Entidades,
            Reconstructor_Estructura_Archivos_Recursos,
            Exportador_Estructuras_Internas,
            // Soon...

            Visor_Ayuda,
            Depurador_Interno,
            Cambiar_Nombre_Usuario,
            Acerca,

            Aleatoria,

            Total // Don't use
        }

        internal static bool Variable_Alfabeto_Galáctico = false;
        internal static bool Variable_Siempre_Visible = false;
        internal static Herramientas Variable_Herramienta = Herramientas.Ninguna;
        internal bool Variable_Excepción = false;
        internal bool Variable_Excepción_Imagen = false;
        internal int Variable_Excepción_Total = 0;
        internal bool Variable_Memoria = false;
        internal Stopwatch Splash_Cronómetro = Stopwatch.StartNew();
        internal long Splash_Milisegundo_Anterior = -1L;
        internal bool Splash_Alfabeto_Galáctico_Anterior = false;
        internal string Splash_Texto = null;

        internal static Bitmap[] Matriz_Imágenes_Fuente = null;
        internal static Bitmap[] Matriz_Imágenes_Fuente_SGA = null;
        internal static int[] Matriz_Ancho_Fuente = null;
        internal static int[] Matriz_Ancho_Fuente_SGA = null;

        [StructLayout(LayoutKind.Sequential)]
        internal struct Pistas
        {
            internal string Título_Recursos;
            internal string Título;
            internal string URL_Mp3;

            internal Pistas(string Título_Recursos, string URL_Mp3)
            {
                this.Título_Recursos = Program.Traducir_Texto_Mayúsculas_Minúsculas_Automáticamente(Título_Recursos);
                this.Título = this.Título_Recursos.Replace("___", ":").Replace("__", ".").Replace("_", " ");
                this.URL_Mp3 = URL_Mp3;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct Álbumes
        {
            internal string Título;
            internal string Recurso;
            internal int Año;
            internal string URL_Html;
            internal string URL_Zip;
            internal List<Pistas> Lista_Pistas;

            internal Álbumes(string Título, int Año, string URL_Html, string URL_Zip, List<Pistas> Lista_Pistas)
            {
                this.Título = Program.Traducir_Texto_Mayúsculas_Minúsculas_Automáticamente(Título);
                this.Recurso = this.Título.Replace(" ", "_").Replace("-", "_").Replace(".", "_").Replace(":", "_").Replace("'", "_").Replace("(", "_").Replace(")", "_").Replace("&", "_").Trim("_".ToCharArray());
                while (this.Recurso.Contains("__")) this.Recurso = this.Recurso.Replace("__", "_");
                this.Año = Año;
                this.URL_Html = URL_Html;
                this.URL_Zip = URL_Zip;
                this.Lista_Pistas = Lista_Pistas;
            }
        }

        /// <summary>
        /// List with links to the awesome free albums of my friend David Maeso, if you haven't listened to his music yet, you don't know what you've been missing, so please navigate to any of his links.
        /// </summary>
        internal static readonly List<Álbumes> Lista_Álbumes_David_Maeso = new List<Álbumes>(new Álbumes[]
        {
            new Álbumes("Habitat", 2018,
            "http://www.davidmaeso.com/album-22.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20HABITAT%20[2018].zip", null),
            new Álbumes("Blue", 2017,
            "http://www.davidmaeso.com/album-21.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20BLUE%20[2017].zip", null),
            new Álbumes("Green", 2017,
            "http://www.davidmaeso.com/album-20.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20GREEN%20[2017].zip", null),
            new Álbumes("Red", 2017,
            "http://www.davidmaeso.com/album-19.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20RED%20[2017].zip", null),
            new Álbumes("Sonicscape", 2017,
            "http://www.davidmaeso.com/album-18.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20SONICSCAPE%20[2017].zip", null),
            new Álbumes("Project", 2016,
            "http://www.davidmaeso.com/album-17.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20PROJECT%20[2016].zip", null),
            new Álbumes("Wallflowers", 2016,
            "http://www.davidmaeso.com/album-16.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20WALLFLOWERS%20[2016].zip", null),
            new Álbumes("Inconsequential", 2015,
            "http://www.davidmaeso.com/album-15.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20INCONSEQUENTIAL%20[2015].zip", null),
            new Álbumes("Haunting", 2014, // 2000
            "http://www.davidmaeso.com/album-14.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20HAUNTING%20[2000].zip", null),
            new Álbumes("Discothèque", 2014,
            "http://www.davidmaeso.com/album-13.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20DISCOTHEQUE%20[2014].zip", null),
            new Álbumes("Punchy", 2014,
            "http://www.davidmaeso.com/album-12.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20PUNCHY%20[2014].zip", null),
            new Álbumes("Outplace", 2014,
            "http://www.davidmaeso.com/album-11.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20OUTPLACE%20[2014].zip", null),
            new Álbumes("Weakness", 2012,
            "http://www.davidmaeso.com/album-10.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20WEAKNESS%20[2012].zip", null),
            new Álbumes("Alchemy", 2012,
            "http://www.davidmaeso.com/album-09.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20ALCHEMY%20[2012].zip", null),
            new Álbumes("Landscape", 2008,
            "http://www.davidmaeso.com/album-08.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20LANDSCAPE%20[2008].zip", null),
            new Álbumes("Phobia", 2008,
            "http://www.davidmaeso.com/album-07.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20PHOBIA%20[2008].zip", null),
            new Álbumes("Breathtaking", 2006,
            "http://www.davidmaeso.com/album-06.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20BREATHTAKING%20[2006].zip", null),
            new Álbumes("Wanted", 2006,
            "http://www.davidmaeso.com/album-05.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20WANTED%20[2006].zip", null),
            new Álbumes("Additional", 2004,
            "http://www.davidmaeso.com/album-04.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20ADDITIONAL%20[2004].zip", null),
            new Álbumes("Realistic", 2004,
            "http://www.davidmaeso.com/album-03.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20REALISTIC%20[2004].zip", null),
            new Álbumes("Endless", 2004,
            "http://www.davidmaeso.com/album-02.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20ENDLESS%20[2004].zip", null),
            new Álbumes("Ubiquitous", 2004,
            "http://www.davidmaeso.com/album-01.html",
            "http://www.davidmaeso.com/downloads/David%20Maeso%20_%20UBIQUITOUS%20[2004].zip", null)
        });

        /// <summary>
        /// List with links to the awesome albums by Fratelli Stellari, if you haven't listened to their music yet, you don't know what you've been missing, so please navigate to any of their links.
        /// </summary>
        internal static readonly List<Álbumes> Lista_Álbumes_Fratelli_Stellari = new List<Álbumes>(new Álbumes[]
        {
            // Fratelli Stellari albums:

            new Álbumes("50 Sfumature di Alieno", 2016,
            "https://fratellistellari.bandcamp.com/track/50-sfumature-di-alieno",
            "", null),
            new Álbumes("Advent of the Space Gods", 2016,
            "https://fratellistellari.bandcamp.com/album/advent-of-the-space-gods",
            "", null),
            new Álbumes("Aglien Discomix", 2016,
            "https://fratellistellari.bandcamp.com/album/aglien-discomix",
            "", null),
            new Álbumes("Electrowave", 2018,
            "https://fratellistellari.bandcamp.com/album/electrowave",
            "", null),
            new Álbumes("Galactic Sound", 2016,
            "https://fratellistellari.bandcamp.com/album/galactic-sound",
            "", null),
            new Álbumes("Instrumental Hits Vol. 1", 2017,
            "https://fratellistellari.bandcamp.com/album/instrumental-hits-vol-1",
            "", null),
            new Álbumes("Instrumental Hits Vol. 2", 2017,
            "https://fratellistellari.bandcamp.com/album/instrumental-hits-vol-2",
            "", null),
            new Álbumes("Le Sciantose Aliene (DJoNemesis & Lilly Remix)", 2016,
            "http://www.messaggidallestelle.altervista.org/le-sciantose-aliene.html",
            "", null),
            new Álbumes("Les Trois Mères - Deep Space Mix", 2017,
            "https://fratellistellari.bandcamp.com/track/les-trois-m-res-deep-space-mix",
            "", null),
            new Álbumes("Matres Alienorum", 2016,
            "https://fratellistellari.bandcamp.com/track/matres-alienorum",
            "", null),
            new Álbumes("Milky Way Super Mix", 2016,
            "https://fratellistellari.bandcamp.com/track/milky-way-super-mix",
            "", null),
            new Álbumes("Milky Way Super Mix (Instrumental)", 2017,
            "https://fratellistellari.bandcamp.com/track/milky-way-super-mix-instrumental",
            "", null),
            new Álbumes("Nightflight to Planet X", 2016,
            "https://fratellistellari.bandcamp.com/album/nightflight-to-planet-x",
            "", null),
            new Álbumes("Ufo Dance (Space Edit)", 2016,
            "https://fratellistellari.bandcamp.com/track/ufo-dance-space-edit",
            "", null),

            new Álbumes(), // Add a separator here.

            // DJoNemesis & Lilly albums:

            new Álbumes("An Ufo Over Turin", 2017,
            "https://djonemesis-lilly.bandcamp.com/track/an-ufo-over-turin",
            "", null),
            new Álbumes("Arrival Prophecy", 2017,
            "https://djonemesis-lilly.bandcamp.com/album/arrival-prophecy",
            "", null),
            new Álbumes("Baffo d'Oro", 2016,
            "http://djonemesis-lilly.bandcamp.com/track/baffo-doro",
            "", null),
            new Álbumes("Home Visitors", 2016,
            "http://djonemesis-lilly.bandcamp.com/track/home-visitors",
            "", null),
            new Álbumes("Instrumental Essence Vol. 1", 2017,
            "https://djonemesis-lilly.bandcamp.com/album/instrumental-essence-vol-1",
            "", null),
            new Álbumes("Instrumental Essence Vol. 2", 2017,
            "https://djonemesis-lilly.bandcamp.com/album/instrumental-essence-vol-2",
            "", null),
            new Álbumes("Interstellar Melody", 2016,
            "http://www.djonemesis.altervista.org/interstellar-melody.html",
            "", null),
            new Álbumes("Nibiru Remixing", 2017,
            "https://djonemesis-lilly.bandcamp.com/album/nibiru-remixing",
            "", null),
            new Álbumes("Ritornata dalla Luce", 2016,
            "http://djonemesis-lilly.bandcamp.com/track/ritornata-dalla-luce",
            "", null)
        });

        /// <summary>
        /// List with my own free music albums. What I do most is program cool applications like this one, but what I do most after it is compose new music, so please check any of the albums at least to see if you find any song to your liking, thanks a lot.
        /// </summary>
        internal static readonly List<Álbumes> Lista_Álbumes_Jupisoft = new List<Álbumes>(new Álbumes[]
        {
            new Álbumes("ANUNNAKI", 2018,
            "http://jupisoft.x10host.com/html/anunnaki.html",
            "http://www.mediafire.com/file/x5bmmli5ccg5402/JUPISOFT_-_ANUNNAKI.zip", null),
            new Álbumes("DAY AND NIGHT", 2017,
            "http://jupisoft.x10host.com/html/day_and_night.html",
            "http://www.mediafire.com/file/04o6mv1p9lxjk26/JUPISOFT_-_DAY_AND_NIGHT.zip", null),
            new Álbumes("EMOTIONS", 2017,
            "http://jupisoft.x10host.com/html/emotions.html",
            "http://www.mediafire.com/file/itp62d5yt33ycyb/JUPISOFT_-_EMOTIONS.zip", null),
            new Álbumes("EXTENDED MIXES", 2017,
            "http://jupisoft.x10host.com/html/extended_mixes.html",
            "http://www.mediafire.com/file/1ut12e427y0ii22/JUPISOFT_-_EXTENDED_MIXES.zip", null),
            new Álbumes("EXTENDED MIXES 2.0", 2018,
            "http://jupisoft.x10host.com/html/extended_mixes_2_0.html",
            "http://www.mediafire.com/file/umd0inhmzmy1wx8/JUPISOFT_-_EXTENDED_MIXES_2.0.zip", null),
            new Álbumes("EXTENDED MIXES 3.0", 2018,
            "http://jupisoft.x10host.com/html/extended_mixes_3_0.html",
            "", null),
            new Álbumes("EXTENDED MIXES 4.0", 2018,
            "http://jupisoft.x10host.com/html/extended_mixes_4_0.html",
            "", null),
            new Álbumes("HIGH MIXES", 2018,
            "http://jupisoft.x10host.com/html/high_mixes.html",
            "http://www.mediafire.com/file/522yv6f21md9ayz/JUPISOFT_-_HIGH_MIXES.zip", null),
            new Álbumes("INFINITE MIXES", 2018,
            "http://jupisoft.x10host.com/html/infinite_mixes.html",
            "", null),
            new Álbumes("LIGHTS AND SHADOWS", 2018,
            "http://jupisoft.x10host.com/html/lights_and_shadows.html",
            "http://www.mediafire.com/file/okxb98mbx97n2h9/JUPISOFT_-_LIGHTS_AND_SHADOWS.zip/file", null),
            new Álbumes("LOW MIXES", 2017,
            "http://jupisoft.x10host.com/html/low_mixes.html",
            "http://www.mediafire.com/file/l2u7msw6gjsed9j/JUPISOFT_-_LOW_MIXES.zip", null),
            new Álbumes("LOW MIXES 2.0", 2017,
            "http://jupisoft.x10host.com/html/low_mixes_2_0.html",
            "http://www.mediafire.com/file/3ipn9k5yxqbsx9f/JUPISOFT_-_LOW_MIXES_2.0.zip", null),
            new Álbumes("LOW MIXES 3.0", 2017,
            "http://jupisoft.x10host.com/html/low_mixes_3_0.html",
            "http://www.mediafire.com/file/rhqdq8iplr7dp38/JUPISOFT_-_LOW_MIXES_3.0.zip", null),
            new Álbumes("LOW MIXES 4.0", 2018,
            "http://jupisoft.x10host.com/html/low_mixes_4_0.html",
            "http://www.mediafire.com/file/vay5ri1ug8lm8pp/JUPISOFT_-_LOW_MIXES_4.0.zip", null),
            new Álbumes("LOW MIXES 5.0", 2018,
            "http://jupisoft.x10host.com/html/low_mixes_5_0.html",
            "http://www.mediafire.com/file/khbrbglobb5gkfg/JUPISOFT_-_LOW_MIXES_5.0.zip", null),
            new Álbumes("LOW MIXES 6.0", 2018,
            "http://jupisoft.x10host.com/html/low_mixes_6_0.html",
            "", null),
            new Álbumes("MACHINES", 2017,
            "http://jupisoft.x10host.com/html/machines.html",
            "http://www.mediafire.com/file/wl8e520nlbv5023/JUPISOFT_-_MACHINES.zip", null),
            new Álbumes("MINECRAFT", 2017,
            "http://jupisoft.x10host.com/html/minecraft.html",
            "http://www.mediafire.com/file/p94opbcw520q3ww/JUPISOFT_-_MINECRAFT.zip", null),
            new Álbumes("MINECRAFT 2.0", 2018,
            "http://jupisoft.x10host.com/html/minecraft_2_0.html",
            "http://www.mediafire.com/file/66lyd3od9d2kglm/JUPISOFT_-_MINECRAFT_2.0.zip", null),
            new Álbumes("MONSTER HIGH", 2017,
            "http://jupisoft.x10host.com/html/monster_high.html",
            "http://www.mediafire.com/file/7o9ut8slfl2yt5p/JUPISOFT_-_MONSTER_HIGH.zip", null),
            new Álbumes("MONSTER HIGH 2.0", 2018,
            "http://jupisoft.x10host.com/html/monster_high_2_0.html",
            "http://www.mediafire.com/file/bp75lc3il5n3qq0/JUPISOFT_-_MONSTER_HIGH_2.0.zip", null),
            new Álbumes("MONSTER HIGH 3.0", 2018,
            "http://jupisoft.x10host.com/html/monster_high_3_0.html",
            "http://www.mediafire.com/file/96c7xswpa985suw/JUPISOFT_-_MONSTER_HIGH_3.0.zip", null),
            new Álbumes("REMIXES", 2018,
            "http://jupisoft.x10host.com/html/remixes.html",
            "http://www.mediafire.com/file/cwuj3443mj2chhf/JUPISOFT_-_REMIXES.zip", null),
            new Álbumes("REMIXES 2.0", 2018,
            "http://jupisoft.x10host.com/html/remixes_2_0.html",
            "", null),
            new Álbumes("RESURRECTION", 2017,
            "http://jupisoft.x10host.com/html/resurrection.html",
            "http://www.mediafire.com/file/lgr94577ons01ab/JUPISOFT_-_RESURRECTION.zip", null),
            new Álbumes("SATELLITES", 2017,
            "http://jupisoft.x10host.com/html/satellites.html",
            "http://www.mediafire.com/file/3697tf9g387t3ea/JUPISOFT_-_SATELLITES.zip", null),
            new Álbumes("SEASONS", 2017,
            "http://jupisoft.x10host.com/html/seasons.html",
            "http://www.mediafire.com/file/dt7dp2d2bi05b8o/JUPISOFT_-_SEASONS.zip", null),
            new Álbumes("SOLAR SYSTEM", 2017,
            "http://jupisoft.x10host.com/html/solar_system.html",
            "http://www.mediafire.com/file/q7k6dt0vmd1xl2d/JUPISOFT_-_SOLAR_SYSTEM.zip", null),
            new Álbumes("THANK YOU", 2017,
            "http://jupisoft.x10host.com/html/thank_you.html",
            "http://www.mediafire.com/file/sm27cx2lszxfcnw/JUPISOFT_-_THANK_YOU.zip", null),
            new Álbumes("THANKS AGAIN", 2017,
            "http://jupisoft.x10host.com/html/thanks_again.html",
            "http://www.mediafire.com/file/b9yhl70udksv7zq/JUPISOFT_-_THANKS_AGAIN.zip", null)
        }); // And other new free albums will come soon as well.

        private void Ventana_Principal_Load(object sender, EventArgs e)
        {
            try
            {
                if (Matriz_Imágenes_Fuente == null || Matriz_Imágenes_Fuente.Length <= 0)
                {
                    Matriz_Imágenes_Fuente = new Bitmap[256];
                    Matriz_Ancho_Fuente = new int[256];
                    for (int Índice = 0; Índice < 256; Índice++)
                    {
                        Bitmap Imagen = Program.Obtener_Imagen_Recursos("Fuente_ascii_" + Índice.ToString());
                        if (Imagen != null)
                        {
                            Matriz_Imágenes_Fuente[Índice] = Imagen;
                            Matriz_Ancho_Fuente[Índice] = Imagen.Width;
                        }
                        else Matriz_Ancho_Fuente[Índice] = 4;
                    }
                }
                if (Matriz_Imágenes_Fuente_SGA == null || Matriz_Imágenes_Fuente_SGA.Length <= 0)
                {
                    Matriz_Imágenes_Fuente_SGA = new Bitmap[256];
                    Matriz_Ancho_Fuente_SGA = new int[256];
                    for (int Índice = 0; Índice < 256; Índice++)
                    {
                        Bitmap Imagen_SGA = Program.Obtener_Imagen_Recursos("Fuente_ascii_sga_" + Índice.ToString());
                        if (Imagen_SGA != null)
                        {
                            Matriz_Imágenes_Fuente_SGA[Índice] = Imagen_SGA;
                            Matriz_Ancho_Fuente_SGA[Índice] = Imagen_SGA.Width;
                        }
                        else Matriz_Ancho_Fuente_SGA[Índice] = 4;
                    }
                }

                // Add a little info about David Maeso's free music albums
                // (if you are reading this, please feel free to listen to the songs).
                if (Lista_Álbumes_David_Maeso != null && Lista_Álbumes_David_Maeso.Count > 0)
                {
                    for (int Índice_Álbum = 0; Índice_Álbum < Lista_Álbumes_David_Maeso.Count; Índice_Álbum++)
                    {
                        Menú_Principal_David_Maeso.DropDownItems.Add(new ToolStripMenuItem(Lista_Álbumes_David_Maeso[Índice_Álbum].Título + " (" + Lista_Álbumes_David_Maeso[Índice_Álbum].Año.ToString() + ")...", Program.Obtener_Imagen_Recursos("David_Maeso_" + Lista_Álbumes_David_Maeso[Índice_Álbum].Recurso + "_16"), new EventHandler(Menú_Principal_David_Maeso_Click), "Menú_Principal_David_Maeso_" + Índice_Álbum.ToString()));
                    }
                }
                // Add a little info about Fratelli Stellari's free music albums
                // (if you are reading this, please feel free to listen to their songs).
                //string Texto = null;
                if (Lista_Álbumes_Fratelli_Stellari != null && Lista_Álbumes_Fratelli_Stellari.Count > 0)
                {
                    bool DJoNemesis_Lilly = false;
                    for (int Índice_Álbum = 0; Índice_Álbum < Lista_Álbumes_Fratelli_Stellari.Count; Índice_Álbum++)
                    {
                        if (!string.IsNullOrEmpty(Lista_Álbumes_Fratelli_Stellari[Índice_Álbum].Título))
                        {
                            Menú_Principal_Fratelli_Stellari.DropDownItems.Add(new ToolStripMenuItem((!DJoNemesis_Lilly ? null : "DJoNemesis and Lilly - ") + Lista_Álbumes_Fratelli_Stellari[Índice_Álbum].Título + " (" + Lista_Álbumes_Fratelli_Stellari[Índice_Álbum].Año.ToString() + ")...", Program.Obtener_Imagen_Recursos("Fratelli_Stellari_" + Lista_Álbumes_Fratelli_Stellari[Índice_Álbum].Recurso + "_16"), new EventHandler(Menú_Principal_Fratelli_Stellari_Click), "Menú_Principal_Fratelli_Stellari_" + Índice_Álbum.ToString()));
                            //Program.Guardar_Imagen_Temporal(Program.Obtener_Imagen_Miniatura(Minecraft.Obtener_Textura_Recursos("Fratelli_Stellari_" + Lista_Álbumes_Fratelli_Stellari[Índice_Álbum].Recurso + "_16"), 16, 16, true, true), "Fratelli_Stellari_" + Lista_Álbumes_Fratelli_Stellari[Índice_Álbum].Recurso + "_16");
                        }
                        else
                        {
                            DJoNemesis_Lilly = true;
                            Menú_Principal_Fratelli_Stellari.DropDownItems.Add(new ToolStripSeparator());
                        }
                        //Texto += "Fratelli_Stellari_" + Lista_Álbumes_Fratelli_Stellari[Índice_Álbum].Recurso + "_16" + "\r\n";
                    }
                }
                //Clipboard.SetText(Texto);
                // Add a little info about my own free music albums
                // (if you are reading this, please feel free to listen to the songs,
                // since on the website there are full previews, even with the original
                // MIDI scores ready to download, and all for free).
                if (Lista_Álbumes_Jupisoft != null && Lista_Álbumes_Jupisoft.Count > 0)
                {
                    for (int Índice_Álbum = 0; Índice_Álbum < Lista_Álbumes_Jupisoft.Count; Índice_Álbum++)
                    {
                        Menú_Principal_Jupisoft.DropDownItems.Add(new ToolStripMenuItem(Lista_Álbumes_Jupisoft[Índice_Álbum].Título + " (" + Lista_Álbumes_Jupisoft[Índice_Álbum].Año.ToString() + ")...", Program.Obtener_Imagen_Recursos("Jupisoft_" + Lista_Álbumes_Jupisoft[Índice_Álbum].Recurso + "_16"), new EventHandler(Menú_Principal_Jupisoft_Click), "Menú_Principal_Jupisoft_" + Índice_Álbum.ToString()));
                    }
                }
                /*string Ruta_Imágenes = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Covers";
                string[] Matriz_Rutas = Directory.GetFiles(Ruta_Imágenes, "*.png", SearchOption.TopDirectoryOnly);
                if (Matriz_Rutas != null && Matriz_Rutas.Length > 0)
                {
                    Array.Sort(Matriz_Rutas);
                    int Índice_Álbum = Lista_Álbumes_David_Maeso.Count - 1;
                    foreach (string Ruta in Matriz_Rutas)
                    {
                        FileStream Lector = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                        Image Imagen_Original = null;
                        try { Imagen_Original = Image.FromStream(Lector, false, false); }
                        catch { Imagen_Original = null; }
                        if (Imagen_Original != null)
                        {
                            int Ancho = Imagen_Original.Width;
                            int Alto = Imagen_Original.Height;
                            Bitmap Imagen = new Bitmap(Ancho, Alto, PixelFormat.Format32bppArgb);
                            Graphics Pintar = Graphics.FromImage(Imagen);
                            Pintar.CompositingMode = CompositingMode.SourceCopy;
                            Pintar.DrawImage(Imagen_Original, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Ancho, Alto), GraphicsUnit.Pixel);
                            Pintar.Dispose();
                            Pintar = null;
                            Imagen = Program.Obtener_Imagen_Miniatura(Imagen, 16, 16, true, true);
                            Program.Guardar_Imagen_Temporal(Imagen, Program.Traducir_Texto_Mayúsculas_Minúsculas_Automáticamente("Fratelli_Stellari_" + Lista_Álbumes_Fratelli_Stellari[Índice_Álbum].Título_Recursos/*Path.GetFileNameWithoutExtension(Ruta)*//* + "_16").Replace(" ", "_").Replace(".", "__").Replace(":", "___"));
                            Imagen.Dispose();
                            Imagen = null;
                        }
                        Lector.Close();
                        Lector.Dispose();
                        Lector = null;
                        Índice_Álbum--;
                    }
                }*/
                /*if (Hermitcraft.Hermits.Matriz_Hermits != null && Hermitcraft.Hermits.Matriz_Hermits.Length > 0)
                {
                    foreach (Hermitcraft.Hermits Hermit in Hermitcraft.Hermits.Matriz_Hermits)
                    {
                        Bitmap Imagen = Minecraft.Obtener_Textura_Recursos("Hermitcraft_" + Hermit.Lista_Nombres_Minecraft[0]);
                        if (Imagen != null)
                        {
                            Imagen = Program.Obtener_Imagen_Miniatura(Imagen, 16, 16, true, false);
                            Program.Guardar_Imagen_Temporal(Imagen, "Hermitcraft_" + Hermit.Lista_Nombres_Minecraft[0]);
                        }
                    }
                }*/
                //Program.Guardar_Imagen_Temporal(Program.Obtener_Imagen_Miniatura(Resources.Xisumavoid, 16, 16, true, false));
                this.Text = Program.Texto_Título_Versión + " - [Minecraft: " + Program.Texto_Minecraft_Versión + ", Vanilla blocks known: " + Program.Traducir_Número(Minecraft.Bloques.Matriz_Bloques.Length) + "]";
                this.WindowState = FormWindowState.Maximized;
                Barra_Estado_Etiqueta_Negro.Image = Program.Obtener_Imagen_Color(Barra_Estado_Etiqueta_Negro.ForeColor); // Set this instead of black, in case some user has another default color.
                Barra_Estado_Etiqueta_Azul.Image = Program.Obtener_Imagen_Color(Barra_Estado_Etiqueta_Azul.ForeColor);
                Barra_Estado_Etiqueta_Rojo.Image = Program.Obtener_Imagen_Color(Barra_Estado_Etiqueta_Rojo.ForeColor);
                this.Select();
                this.Focus();

                /*for (int Y = 0, Índice = 0; Y < 16; Y++)
                {
                    for (int X = 0; X < 16; X++, Índice++)
                    {
                        Bitmap Imagen_Temporal = Resources.Fuente_ascii.Clone(new Rectangle(X * 8, Y * 8, 8, 8), PixelFormat.Format32bppArgb);
                        Bitmap Imagen_Temporal_SGA = Resources.Fuente_ascii_sga.Clone(new Rectangle(X * 8, Y * 8, 8, 8), PixelFormat.Format32bppArgb);
                        Rectangle Rectángulo = Program.Buscar_Zona_Recorte_Imagen(Imagen_Temporal);
                        Rectangle Rectángulo_SGA = Program.Buscar_Zona_Recorte_Imagen(Imagen_Temporal_SGA);
                        if (Rectángulo.X > -1 && Rectángulo.Y > -1 && Rectángulo.X < int.MaxValue && Rectángulo.Y < int.MaxValue && Rectángulo.Width > 0 && Rectángulo.Height > 0)
                        {
                            Rectángulo.Y = 0; // Don't move it vertically.
                            Rectángulo.Height = 8;
                            Imagen_Temporal = Imagen_Temporal.Clone(Rectángulo, PixelFormat.Format32bppArgb);
                            //Pintar.DrawImage(Imagen_Temporal, new Rectangle((X * 8) + ((8 - Rectángulo.Width) / 2), Y * 8, Rectángulo.Width, 8), new Rectangle(0, 0, Rectángulo.Width, Rectángulo.Height), GraphicsUnit.Pixel);
                            Program.Guardar_Imagen_Temporal(Imagen_Temporal, "Fuente_ascii_" + Índice.ToString());
                        }
                        if (Rectángulo_SGA.X > -1 && Rectángulo_SGA.Y > -1 && Rectángulo_SGA.X < int.MaxValue && Rectángulo_SGA.Y < int.MaxValue && Rectángulo_SGA.Width > 0 && Rectángulo_SGA.Height > 0)
                        {
                            Rectángulo_SGA.Y = 0; // Don't move it vertically.
                            Rectángulo_SGA.Height = 8;
                            Imagen_Temporal_SGA = Imagen_Temporal_SGA.Clone(Rectángulo_SGA, PixelFormat.Format32bppArgb);
                            //Pintar_SGA.DrawImage(Imagen_Temporal_SGA, new Rectangle((X * 8) + ((8 - Rectángulo_SGA.Width) / 2), Y * 8, Rectángulo_SGA.Width, 8), new Rectangle(0, 0, Rectángulo_SGA.Width, Rectángulo_SGA.Height), GraphicsUnit.Pixel);
                            Program.Guardar_Imagen_Temporal(Imagen_Temporal_SGA, "Fuente_ascii_sga_" + Índice.ToString());
                        }
                        Imagen_Temporal.Dispose();
                        Imagen_Temporal_SGA.Dispose();
                    }
                }*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Principal_Shown(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show((((byte)179 >> 4) & 0xF).ToString()); // Primeros 4 bits de un byte
                //MessageBox.Show(((byte)179 & 0xF).ToString()); // Últimos 4 bits de un byte
                this.Activate();
                Temporizador_Principal.Start();
                bool Mostrar_Herramientas = Registro_Cargar_Opciones();
                if (!Mostrar_Herramientas) Menú_Principal_Herramientas_Abrir_Herramienta_Predeterminada.PerformClick();
                else Menú_Principal_Herramientas.ShowDropDown(); // Show the list of tools to any new user.
                //this.Text = Program.Texto_Título + " - [Minecraft: " + Program.Texto_Minecraft_Versión + ", Vanilla blocks known: " + Program.Traducir_Número(Minecraft.Bloques.Matriz_Bloques.Length) + "]";

                //MessageBox.Show(Minecraft_Biomas.Obtener_Color_ARGB(2302743).ToString());

                // Reset the average ARGB colors of every Minecraft texture:
                /*Minecraft.Diccionario_Bloques_Índices_Colores.Clear();
                foreach (KeyValuePair<short, string> Entrada in Minecraft.Diccionario_Bloques_Índices_Nombres)
                {
                    Color Color_ARGB = Ventana_Color_Medio_Imagen.Obtener_Color_Medio_Imagen(Minecraft.Obtener_Textura_Recursos(Entrada.Value));
                    Minecraft.Diccionario_Bloques_Índices_Colores.Add(Entrada.Key, Color_ARGB);
                }*/

                // Search for equal colors:
                /*int Repeticiones = 0;
                string Texto = null;
                string Texto_Diccionario = null;
                Dictionary<int, short> Diccionario_Colores = new Dictionary<int, short>();
                foreach (KeyValuePair<short, Color> Entrada in Minecraft.Diccionario_Bloques_Índices_Colores)
                {
                    int Código_Hash = Entrada.Value.GetHashCode();
                    //Texto_Diccionario += "Diccionario_Bloques_Índices_Colores.Add(Diccionario_Bloques_Nombres_Índices[\"" + Minecraft.Diccionario_Bloques_Índices_Nombres[Entrada.Key] + "\"], Color.FromArgb(" + Entrada.Value.A.ToString() + ", " + Entrada.Value.R.ToString() + ", " + Entrada.Value.G.ToString() + ", " + Entrada.Value.B.ToString() + "));\r\n";
                    if (!Diccionario_Colores.ContainsKey(Código_Hash))
                    {
                        Diccionario_Colores.Add(Código_Hash, Entrada.Key);
                    }
                    else
                    {
                        //Texto += Entrada.Value.ToString() + " = " + Minecraft.Diccionario_Bloques_Índices_Nombres[Entrada.Key] + "\r\n";
                        Texto += Minecraft.Diccionario_Bloques_Índices_Nombres[Entrada.Key] + " = " + Minecraft.Diccionario_Bloques_Índices_Nombres[Diccionario_Colores[Código_Hash]] + "\r\n";
                        Repeticiones++;
                    }
                }
                if (!string.IsNullOrEmpty(Texto)) Clipboard.SetText(Repeticiones.ToString() + "\r\n\r\n" + Texto + "\r\n" + Texto_Diccionario);*/
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Principal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!e.Alt && !e.Control && !e.Shift)
                {
                    if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Delete)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        Menú_Principal_Archivo_Salir.PerformClick();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Archivo_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Siempre_Visible_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                this.TopMost = Variable_Siempre_Visible;
                Registro_Guardar_Opciones();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Visor_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Visor_Ayuda Ventana = new Ventana_Visor_Ayuda();
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Depurador_Interno_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Depurador Ventana = new Ventana_Depurador();
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Cambiar_Nombre_Usuario_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana_Nombre_Usuario Ventana = new Ventana_Nombre_Usuario();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                if (Ventana.ShowDialog(this) == DialogResult.OK)
                {
                    Program.Texto_Usuario = Ventana.Texto_Usuario;
                    Registro_Guardar_Opciones();
                    Program.Texto_Título = "Minecraft Tools for " + Program.Texto_Usuario + " by Jupisoft";
                    Program.Texto_Programa = "Minecraft Tools for " + Program.Texto_Usuario;
                    Program.Texto_Título_Versión = Program.Texto_Título + " " + Program.Texto_Versión;
                    this.Text = Program.Texto_Título + " - [Minecraft: " + Program.Texto_Minecraft_Versión + ", Vanilla blocks known: " + Program.Traducir_Número(Minecraft.Bloques.Matriz_Bloques.Length) + "]";
                    Barra_Estado_Etiqueta_Sugerencia.Text = "Welcome dear " + Program.Texto_Usuario + ", I wish you a great day.";
                }
                Ventana.Dispose();
                Ventana = null;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Acerca_Click(object sender, EventArgs e)
        {
            try
            {
                Registro_Restablecer_Opciones();
                Ventana_Acerca Ventana = new Ventana_Acerca();
                DialogResult Resultado = Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Herramienta_Predeterminada_Click(object sender, EventArgs e)
        {
            try
            {
                for (int Índice = 0; Índice < Menú_Principal_Herramientas_Herramienta_Predeterminada.DropDownItems.Count; Índice++) if (Menú_Principal_Herramientas_Herramienta_Predeterminada.DropDownItems[Índice].GetType() == typeof(ToolStripMenuItem)) ((ToolStripMenuItem)Menú_Principal_Herramientas_Herramienta_Predeterminada.DropDownItems[Índice]).Checked = false;
                ToolStripMenuItem Menú = (ToolStripMenuItem)sender;
                Menú.Checked = true;
                Variable_Herramienta = (Herramientas)Enum.Parse(typeof(Herramientas), Menú.Name.Replace("Menú_Principal_Herramientas_Herramienta_Predeterminada_", null));
                Registro_Guardar_Opciones();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Abrir_Herramienta_Predeterminada_Click(object sender, EventArgs e)
        {
            try
            {
                if (Variable_Herramienta != Herramientas.Ninguna)
                {
                    if (Variable_Herramienta == Herramientas.Visor_Mundos_Realista_2D) Menú_Principal_Herramientas_Visor_Mundos_Realista_2D.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Buscador_Chunks_Limos) Menú_Principal_Herramientas_Buscador_Chunks_Limos.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Visor_Skins_Animado_3D) Menú_Principal_Herramientas_Herramienta_Predeterminada_Visor_Skins_Animado_3D.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Calculadora_Infinita_Semillas_Mundos) Menú_Principal_Herramientas_Calculadora_Infinita_Semillas_Mundos.PerformClick();

                    else if (Variable_Herramienta == Herramientas.Generador_Pixel_Art_Exportador_Mundos) Menú_Principal_Herramientas_Generador_Pixel_Art_Exportador_Mundos.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Exportador_Estructuras_Pintadas) Menú_Principal_Herramientas_Exportador_Estructuras_Pintadas.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Generador_Estructuras_Personalizadas) Menú_Principal_Herramientas_Generador_Estructuras_Personalizadas.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Generador_Miniaturas_Color_Medio) Menú_Principal_Herramientas_Generador_Miniaturas_Color_Medio.PerformClick();

                    else if (Variable_Herramienta == Herramientas.Visor_NBT) Menú_Principal_Herramientas_Visor_NBT.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Buscador_Diferencias_Versiones_JAR) Menú_Principal_Herramientas_Buscador_Diferencias_Versiones_JAR.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Diseñador_Piedra_Rojiza) Menú_Principal_Herramientas_Diseñador_Piedra_Rojiza.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Generador_Estructuras_Comandos) Menú_Principal_Herramientas_Generador_Estructuras_Comandos.PerformClick();

                    else if (Variable_Herramienta == Herramientas.Reloj_Minecraft_Tiempo_Real) Menú_Principal_Herramientas_Reloj_Minecraft_Tiempo_Real.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Visor_Información_Bloques) Menú_Principal_Herramientas_Visor_Información_Bloques.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Administrador_Copias_Seguridad) Menú_Principal_Herramientas_Administrador_Copias_Seguridad.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Descargador_Skins_Automático) Menú_Principal_Herramientas_Descargador_Skins_Automático.PerformClick();

                    else if (Variable_Herramienta == Herramientas.Visor_Cuadros) Menú_Principal_Herramientas_Visor_Cuadros.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Afinador_Bloques_Nota) Menú_Principal_Herramientas_Afinador_Bloques_Nota.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Diseñador_Estandartes_Escudos) Menú_Principal_Herramientas_Diseñador_Estandartes_Escudos.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Visor_Ofertas_Aldeanos) Menú_Principal_Herramientas_Visor_Ofertas_Aldeanos.PerformClick();

                    else if (Variable_Herramienta == Herramientas.Visor_Información_Entidades) Menú_Principal_Herramientas_Visor_Información_Entidades.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Reconstructor_Estructura_Archivos_Recursos) Menú_Principal_Herramientas_Reconstructor_Estructura_Archivos_Recursos.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Exportador_Estructuras_Internas) Menú_Principal_Herramientas_Exportador_Estructuras_Internas.PerformClick();
                    // Soon...

                    else if (Variable_Herramienta == Herramientas.Visor_Ayuda) Menú_Principal_Ayuda_Visor_Ayuda.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Depurador_Interno) Menú_Principal_Ayuda_Depurador_Interno.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Cambiar_Nombre_Usuario) Menú_Principal_Ayuda_Cambiar_Nombre_Usuario.PerformClick();
                    else if (Variable_Herramienta == Herramientas.Acerca) Menú_Principal_Ayuda_Acerca.PerformClick();

                    else if (Variable_Herramienta == Herramientas.Aleatoria) Menú_Principal_Herramientas_Aleatoria.PerformClick();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        /// <summary>
        /// Loads the saved (or default if missing) options from the Windows registry.
        /// </summary>
        /// <returns>Returns true if the tools menu should be opened (only after selecting a user name). Returns false otherwise.</returns>
        internal bool Registro_Cargar_Opciones()
        {
            bool Mostrar_Herramientas = false;
            try
            {
                RegistryKey Clave = Registry.CurrentUser.CreateSubKey("Software\\Jupisoft\\Minecraft Tools\\" + Program.Texto_Versión);
                try { Program.Texto_Usuario = Clave.GetValue("User_Name", null) as string; }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Program.Texto_Usuario = null; }
                try { Variable_Siempre_Visible = bool.Parse((string)Clave.GetValue("Always_On_Top", bool.FalseString)); }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Siempre_Visible = false; }
                try { Variable_Herramienta = (Herramientas)Clave.GetValue("Default_Tool", 0); }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Herramienta = Herramientas.Ninguna; }

                // Correct any bad value after loading:
                if (Variable_Herramienta < 0 || Variable_Herramienta >= Herramientas.Total) Variable_Herramienta = 0;
                // If the loaded user name is null, ask kindly to the user to provide one name. The user name is only used locally.
                if (string.IsNullOrEmpty(Program.Texto_Usuario))
                {
                    Mostrar_Herramientas = true;
                    Program.Texto_Usuario = Environment.UserName;
                    Ventana_Nombre_Usuario Ventana = new Ventana_Nombre_Usuario();
                    Ventana.Variable_Nuevo_Usuario = true;
                    Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                    if (Ventana.ShowDialog(this) == DialogResult.OK)
                    {
                        Program.Texto_Usuario = Ventana.Texto_Usuario;
                        Registro_Guardar_Opciones(); // Save the new user name, so the application won't ask again for a new user name.
                    }
                    else
                    {
                        Program.Texto_Usuario = Environment.UserName;
                        Registro_Guardar_Opciones(); // Save the default user name, so the application won't ask again for a new user name.
                    }
                    Ventana.Dispose();
                    Ventana = null;
                }
                else // If the loaded user name only contains spaces, load the default one instead
                {
                    bool Nombre_Vacío = true;
                    foreach (char Caracter in Program.Texto_Usuario)
                    {
                        if (!char.IsWhiteSpace(Caracter))
                        {
                            Nombre_Vacío = false;
                            break;
                        }
                    }
                    if (Nombre_Vacío)
                    {
                        Program.Texto_Usuario = Environment.UserName;
                        Registro_Guardar_Opciones(); // Save the default user name, so the application won't ask again for a new user name.
                    }
                }
                Program.Texto_Título = "Minecraft Tools for " + Program.Texto_Usuario + " by Jupisoft";
                Program.Texto_Programa = "Minecraft Tools for " + Program.Texto_Usuario;
                Program.Texto_Título_Versión = Program.Texto_Título + " " + Program.Texto_Versión;
                this.Text = Program.Texto_Título_Versión + " - [Minecraft: " + Program.Texto_Minecraft_Versión + ", Vanilla blocks known: " + Program.Traducir_Número(Minecraft.Bloques.Matriz_Bloques.Length) + "]";
                Barra_Estado_Etiqueta_Sugerencia.Text = "Welcome dear " + Program.Texto_Usuario + ", I wish you a great day.";
                
                Ventana_Gracias.Agradecimientos.Lista_Agradecimientos.Sort(new Ventana_Gracias.Comparador_Agradecimientos());
                Ventana_Acerca.Lista_Gracias.Clear();
                foreach (Ventana_Gracias.Agradecimientos Agradecimiento in Ventana_Gracias.Agradecimientos.Lista_Agradecimientos)
                {
                    Ventana_Acerca.Lista_Gracias.Add(Agradecimiento.Nombre);
                }
                if (!Ventana_Acerca.Lista_Gracias.Contains(Program.Texto_Usuario))
                {
                    Ventana_Gracias.Agradecimientos.Lista_Agradecimientos.Insert(0, new Ventana_Gracias.Agradecimientos(Program.Texto_Usuario, null, DateTime.Now.Date, "Minecraft Tools", "https://www.minecraftforum.net/forums/minecraft-java-edition/recent-updates-and-snapshots/2894808-minecraft-1-13-new-chunk-format-fully-decoded-read"));
                    Ventana_Acerca.Lista_Gracias.Insert(0, Program.Texto_Usuario);
                }

                // Apply all the loaded values:
                Menú_Principal_Ver_Siempre_Visible.Checked = Variable_Siempre_Visible;
                Menú_Principal_Herramientas_Herramienta_Predeterminada.DropDownItems["Menú_Principal_Herramientas_Herramienta_Predeterminada_" + Variable_Herramienta.ToString()].PerformClick();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            return Mostrar_Herramientas;
        }

        internal void Registro_Guardar_Opciones()
        {
            try
            {
                RegistryKey Clave = Registry.CurrentUser.CreateSubKey("Software\\Jupisoft\\Minecraft Tools\\" + Program.Texto_Versión);
                string[] Matriz_Nombres = Clave.GetValueNames();
                if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                {
                    for (int Índice = 0; Índice < Matriz_Nombres.Length; Índice++)
                    {
                        if (string.Compare(Matriz_Nombres[Índice], "Version") != 0 && string.Compare(Matriz_Nombres[Índice], "User_Name") != 0) Clave.DeleteValue(Matriz_Nombres[Índice]);
                    }
                }
                Matriz_Nombres = null;
                try { Clave.SetValue("User_Name", Program.Texto_Usuario, RegistryValueKind.String); }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
                try { Clave.SetValue("Always_On_Top", Menú_Principal_Ver_Siempre_Visible.Checked, RegistryValueKind.String); }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
                try { Clave.SetValue("Default_Tool", (int)Variable_Herramienta, RegistryValueKind.DWord); }
                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        /// <summary>
        /// Calling this before loading a (default) tool might save the program from
        /// starting that same tool after it had a crash, thus letting the user delete
        /// all the options from the Windows registry to avoid any bad setting to keep
        /// crashing the program every time it loads a default tool.
        /// If it didn't crash, it saves again the main options as if nothing ever happened.
        /// Note: the always on top option will be lost if it crashes...
        /// </summary>
        internal void Registro_Restablecer_Opciones()
        {
            try
            {
                RegistryKey Clave = Registry.CurrentUser.CreateSubKey("Software\\Jupisoft\\Minecraft Tools\\" + Program.Texto_Versión);
                string[] Matriz_Nombres = Clave.GetValueNames();
                if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                {
                    for (int Índice = 0; Índice < Matriz_Nombres.Length; Índice++)
                    {
                        try { if (string.Compare(Matriz_Nombres[Índice], "Version") != 0 && string.Compare(Matriz_Nombres[Índice], "User_Name") != 0) Clave.DeleteValue(Matriz_Nombres[Índice]); }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                    }
                    Matriz_Nombres = null;
                }
                Clave.Close();
                Clave = null;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Descargar_Minecraft_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.minecraft.net/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Sitio_Hermitcraft_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://hermitcraft.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Minecraft_Forum_Jupisoft_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.minecraftforum.net/forums/minecraft-java-edition/recent-updates-and-snapshots/2894808-minecraft-1-13-new-chunk-format-fully-decoded-read", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Sitio_Jupisoft_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://jupisoft.x10host.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Enviar_Correo_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("mailto:jupitermauro@gmail.com?subject=" + Program.Texto_Programa + " " + Program.Texto_Versión + ", " + Program.Texto_Fecha.Replace("_", null), ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Donar_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=KSMZ3XNG2R9P6", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Archivo_Borrar_Opciones_Registro_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Do you want to delete all the program options saved in the registry?\r\n\r\nNote: this is useful if you want to \"uninstall\" the program, and want to remove all of it's traces as if it was never executed on this computer.\r\n\r\nAfter this message, the program will exit, then you can delete it if you want. But remember that if you start it again, you will need to delete it's registry options whenever you want to fully uninstall it.\r\n\r\nBut if you want to keep all your settings saved after \"uninstalling\", just delete the program and it's libraries, and the next time you download it, your settings will still be there (if they are from the same version).", Program.Texto_Título_Versión, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    RegistryKey Clave = Registry.CurrentUser.CreateSubKey("Software\\Jupisoft\\Minecraft Tools\\" + Program.Texto_Versión);
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
                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
                    try
                    {
                        Matriz_Nombres = Clave.GetValueNames();
                        if (Matriz_Nombres != null && Matriz_Nombres.Length > 0)
                        {
                            for (int Índice = 0; Índice < Matriz_Nombres.Length; Índice++)
                            {
                                try { Clave.DeleteValue(Matriz_Nombres[Índice]); }
                                catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); continue; }
                            }
                        }
                        Matriz_Nombres = null;
                    }
                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
                    Clave.Close();
                    Clave = null;
                    try
                    {
                        Clave = Registry.CurrentUser.CreateSubKey("Software\\Jupisoft\\Minecraft Tools");
                        Clave.DeleteSubKey(Program.Texto_Versión, true);
                        Clave.Close();
                        Clave = null;
                    }
                    catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
                    finally { Environment.Exit(0); }
                }
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
                Ventana_Depurador Ventana = new Ventana_Depurador();
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
                // Change the splash text randomly every 2,5 seconds.
                long Milisegundos = Splash_Cronómetro.ElapsedMilliseconds / 2500L;
                if (Milisegundos != Splash_Milisegundo_Anterior || Variable_Alfabeto_Galáctico != Splash_Alfabeto_Galáctico_Anterior)
                {
                    if (Milisegundos != Splash_Milisegundo_Anterior)
                    {
                        Splash_Texto = Minecraft_Splashes.Matriz_Líneas[Program.Rand.Next(0, Minecraft_Splashes.Matriz_Líneas.Length)];
                        if (string.IsNullOrEmpty(Splash_Texto)) Splash_Texto = "?";
                        if (Milisegundos % 4L == 0) // Only show every 4 splashes.
                        {
                            DateTime Fecha = DateTime.Now; // Obtain the current system date.
                            //Fecha = new DateTime(2018, 10, 31); // Used only for testing and debugging.
                            if (Fecha.Month == 12 && Fecha.Day == 24) Splash_Texto = "Merry X-mas!";
                            else if (Fecha.Month == 1 && Fecha.Day == 1) Splash_Texto = "Happy new year!";
                            else if (Fecha.Month == 10 && Fecha.Day == 31) Splash_Texto = "OOoooOOOoooo! Spooky!";
                        }
                    }
                    Splash_Milisegundo_Anterior = Milisegundos;
                    Splash_Alfabeto_Galáctico_Anterior = Variable_Alfabeto_Galáctico;
                    int Ancho = 0;
                    foreach (char Caracter in Splash_Texto)
                    {
                        int Valor_Caracter = (int)Caracter;
                        if (Valor_Caracter < 0 || Valor_Caracter > 255) Valor_Caracter = (int)'?';
                        Ancho += (!Variable_Alfabeto_Galáctico ? Matriz_Ancho_Fuente[Valor_Caracter] : Matriz_Ancho_Fuente_SGA[Valor_Caracter]) + 1;
                    }
                    Ancho--;
                    int Ancho_Cliente = Picture_Splash.ClientSize.Width - 24; // 12 pixels of margins x 2.
                    int Alto_Cliente = Picture_Splash.ClientSize.Height - 24; // 12 pixels of margins x 2.
                    int Autozoom = Math.Max(Math.Min(Ancho_Cliente / Ancho, Alto_Cliente / 8), 1); // Minimum of 1x.
                    Bitmap Imagen = new Bitmap(Ancho * Autozoom, Alto_Cliente, PixelFormat.Format32bppArgb);
                    Graphics Pintar = Graphics.FromImage(Imagen);
                    Pintar.CompositingMode = CompositingMode.SourceCopy;
                    Pintar.CompositingQuality = CompositingQuality.HighQuality;
                    Pintar.InterpolationMode = InterpolationMode.NearestNeighbor;
                    Pintar.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    Pintar.SmoothingMode = SmoothingMode.None;
                    for (int Índice_Caracter = 0, Índice_X = 0; Índice_Caracter < Splash_Texto.Length; Índice_Caracter++)
                    {
                        int Valor_Caracter = (int)Splash_Texto[Índice_Caracter];
                        if (Valor_Caracter < 0 || Valor_Caracter > 255) Valor_Caracter = (int)'?';
                        if (!Variable_Alfabeto_Galáctico)
                        {
                            if (Matriz_Imágenes_Fuente[Valor_Caracter] != null) Pintar.DrawImage(Matriz_Imágenes_Fuente[Valor_Caracter], new Rectangle(Índice_X, Alto_Cliente - (8 * Autozoom), Matriz_Ancho_Fuente[Valor_Caracter] * Autozoom, 8 * Autozoom), new Rectangle(0, 0, Matriz_Ancho_Fuente[Valor_Caracter], 8), GraphicsUnit.Pixel);
                            Índice_X += (Matriz_Ancho_Fuente[Valor_Caracter] + 1) * Autozoom;
                        }
                        else
                        {
                            if (Matriz_Imágenes_Fuente_SGA[Valor_Caracter] != null) Pintar.DrawImage(Matriz_Imágenes_Fuente_SGA[Valor_Caracter], new Rectangle(Índice_X, Alto_Cliente - (8 * Autozoom), Matriz_Ancho_Fuente_SGA[Valor_Caracter] * Autozoom, 8 * Autozoom), new Rectangle(0, 0, Matriz_Ancho_Fuente_SGA[Valor_Caracter], 8), GraphicsUnit.Pixel);
                            Índice_X += (Matriz_Ancho_Fuente_SGA[Valor_Caracter] + 1) * Autozoom;
                        }
                    }
                    Pintar.Dispose();
                    Pintar = null;
                    Rectangle Rectángulo = Program.Buscar_Zona_Recorte_Imagen(Imagen);
                    if (Rectángulo.X > -1 && Rectángulo.Y > -1 && Rectángulo.X < int.MaxValue && Rectángulo.Y < int.MaxValue && Rectángulo.Width > 0 && Rectángulo.Height > 0)
                    {
                        Rectángulo.Y = 0; // Don't move it vertically...
                        Rectángulo.Height = Alto_Cliente; // But center it horizontally.
                        Imagen = Imagen.Clone(Rectángulo, PixelFormat.Format32bppArgb);
                    }
                    Imagen = Program.Obtener_Imagen_Pintada(Imagen, Color.Black, Color.White);
                    Picture_Splash.Image = Imagen;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
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
                            if (Tick % 1000 < 500) // Half second on
                            {
                                if (!Variable_Memoria)
                                {
                                    Variable_Memoria = true;
                                    Barra_Estado_Etiqueta_Memoria.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                if (Variable_Memoria) // Half second off
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
        }

        private void Menú_Principal_Ver_Abrir_Carpeta_Minecraft_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(Program.Ruta_Guardado_Minecraft)) Program.Ejecutar_Ruta(Program.Ruta_Guardado_Minecraft, ProcessWindowStyle.Maximized);
                else SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Abrir_Carpeta_Twitch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(Program.Ruta_Guardado_Twitch)) Program.Ejecutar_Ruta(Program.Ruta_Guardado_Twitch, ProcessWindowStyle.Maximized);
                else SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Visor_Mundos_Realista_2D_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Visor_Mundos_Realista_2D Ventana = new Ventana_Visor_Mundos_Realista_2D();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Buscador_Chunks_Limos_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Buscador_Chunks_Limos Ventana = new Ventana_Buscador_Chunks_Limos();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Visor_Skins_Animado_3D_Click(object sender, EventArgs e)
        {
            try
            {
                SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Calculadora_Semillas_Mundos_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Calculadora_Infinita_Semillas_Mundos Ventana = new Ventana_Calculadora_Infinita_Semillas_Mundos();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Generador_Pixel_Art_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Generador_Pixel_Art Ventana = new Ventana_Generador_Pixel_Art();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Exportador_Estructuras_Pintadas_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Exportador_Estructuras_Pintadas Ventana = new Ventana_Exportador_Estructuras_Pintadas();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Generador_Estructuras_Personalizadas_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Generador_Estructuras_Personalizadas Ventana = new Ventana_Generador_Estructuras_Personalizadas();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Generador_Miniaturas_Color_Medio_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Generador_Miniaturas_Color_Medio Ventana = new Ventana_Generador_Miniaturas_Color_Medio();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Visor_NBT_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Visor_NBT Ventana = new Ventana_Visor_NBT();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Buscador_Diferencias_Versiones_JAR_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Comparador_Versiones_JAR Ventana = new Ventana_Comparador_Versiones_JAR();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Diseñador_Piedra_Rojiza_Click(object sender, EventArgs e)
        {
            try
            {
                SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Generador_Estructuras_Comandos_Click(object sender, EventArgs e)
        {
            try
            {
                SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Reloj_Día_Noche_Minecraft_Tiempo_Real_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Reloj_Minecraft_Tiempo_Real Ventana = new Ventana_Reloj_Minecraft_Tiempo_Real();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Visor_Información_Bloques_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Visor_Información_Bloques Ventana = new Ventana_Visor_Información_Bloques();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Administrador_Copias_Seguridad_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Administrador_Copias_Seguridad Ventana = new Ventana_Administrador_Copias_Seguridad();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Descargador_Skins_Automático_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Descagador_Skins_Automático Ventana = new Ventana_Descagador_Skins_Automático();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Visor_Cuadros_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Visor_Cuadros Ventana = new Ventana_Visor_Cuadros();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Afinador_Bloques_Nota_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Afinador_Bloques_Nota Ventana = new Ventana_Afinador_Bloques_Nota();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Diseñador_Estandartes_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Diseñador_Estandartes_Escudos Ventana = new Ventana_Diseñador_Estandartes_Escudos();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Visor_Ofertas_Aldeanos_Click(object sender, EventArgs e)
        {
            try
            {
                SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Visor_Información_Entidades_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Visor_Información_Entidades Ventana = new Ventana_Visor_Información_Entidades();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Aleatoria_Click(object sender, EventArgs e)
        {
            try
            {
                Herramientas Herramienta = (Herramientas)Program.Rand.Next(1, (int)Herramientas.Aleatoria);

                if (Herramienta == Herramientas.Visor_Mundos_Realista_2D) Menú_Principal_Herramientas_Visor_Mundos_Realista_2D.PerformClick();
                else if (Herramienta == Herramientas.Buscador_Chunks_Limos) Menú_Principal_Herramientas_Buscador_Chunks_Limos.PerformClick();
                else if (Herramienta == Herramientas.Visor_Skins_Animado_3D) Menú_Principal_Herramientas_Herramienta_Predeterminada_Visor_Skins_Animado_3D.PerformClick();
                else if (Herramienta == Herramientas.Calculadora_Infinita_Semillas_Mundos) Menú_Principal_Herramientas_Calculadora_Infinita_Semillas_Mundos.PerformClick();

                else if (Herramienta == Herramientas.Generador_Pixel_Art_Exportador_Mundos) Menú_Principal_Herramientas_Generador_Pixel_Art_Exportador_Mundos.PerformClick();
                else if (Herramienta == Herramientas.Exportador_Estructuras_Pintadas) Menú_Principal_Herramientas_Exportador_Estructuras_Pintadas.PerformClick();
                else if (Herramienta == Herramientas.Generador_Estructuras_Personalizadas) Menú_Principal_Herramientas_Generador_Estructuras_Personalizadas.PerformClick();
                else if (Herramienta == Herramientas.Generador_Miniaturas_Color_Medio) Menú_Principal_Herramientas_Generador_Miniaturas_Color_Medio.PerformClick();

                else if (Herramienta == Herramientas.Visor_NBT) Menú_Principal_Herramientas_Visor_NBT.PerformClick();
                else if (Herramienta == Herramientas.Buscador_Diferencias_Versiones_JAR) Menú_Principal_Herramientas_Buscador_Diferencias_Versiones_JAR.PerformClick();
                else if (Herramienta == Herramientas.Diseñador_Piedra_Rojiza) Menú_Principal_Herramientas_Diseñador_Piedra_Rojiza.PerformClick();
                else if (Herramienta == Herramientas.Generador_Estructuras_Comandos) Menú_Principal_Herramientas_Generador_Estructuras_Comandos.PerformClick();

                else if (Herramienta == Herramientas.Reloj_Minecraft_Tiempo_Real) Menú_Principal_Herramientas_Reloj_Minecraft_Tiempo_Real.PerformClick();
                else if (Herramienta == Herramientas.Visor_Información_Bloques) Menú_Principal_Herramientas_Visor_Información_Bloques.PerformClick();
                else if (Herramienta == Herramientas.Administrador_Copias_Seguridad) Menú_Principal_Herramientas_Administrador_Copias_Seguridad.PerformClick();
                else if (Herramienta == Herramientas.Descargador_Skins_Automático) Menú_Principal_Herramientas_Descargador_Skins_Automático.PerformClick();

                else if (Herramienta == Herramientas.Visor_Cuadros) Menú_Principal_Herramientas_Visor_Cuadros.PerformClick();
                else if (Herramienta == Herramientas.Afinador_Bloques_Nota) Menú_Principal_Herramientas_Afinador_Bloques_Nota.PerformClick();
                else if (Herramienta == Herramientas.Diseñador_Estandartes_Escudos) Menú_Principal_Herramientas_Diseñador_Estandartes_Escudos.PerformClick();
                else if (Herramienta == Herramientas.Visor_Ofertas_Aldeanos) Menú_Principal_Herramientas_Visor_Ofertas_Aldeanos.PerformClick();

                else if (Herramienta == Herramientas.Visor_Información_Entidades) Menú_Principal_Herramientas_Visor_Información_Entidades.PerformClick();
                else if (Herramienta == Herramientas.Reconstructor_Estructura_Archivos_Recursos) Menú_Principal_Herramientas_Reconstructor_Estructura_Archivos_Recursos.PerformClick();
                // Soon...
                // Soon...

                else if (Herramienta == Herramientas.Visor_Ayuda) Menú_Principal_Ayuda_Visor_Ayuda.PerformClick();
                else if (Herramienta == Herramientas.Depurador_Interno) Menú_Principal_Ayuda_Depurador_Interno.PerformClick();
                else if (Herramienta == Herramientas.Cambiar_Nombre_Usuario) Menú_Principal_Ayuda_Cambiar_Nombre_Usuario.PerformClick();
                else if (Herramienta == Herramientas.Acerca) Menú_Principal_Ayuda_Acerca.PerformClick();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Reddit_Hermitcraft_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.reddit.com/r/HermitCraft/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Sitio_Xisumavoid_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://xisumavoid.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_BDubs_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/bdoubleo100", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Biffa_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/biffaplays", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Cleo_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/ZombieCleo", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Cubfan_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/cubfan135", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Doc_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.youtube.com/docm77", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Etho_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.youtube.com/ethoslab", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_False_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/FalseSymmetry", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Hypno_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/hypnotizd", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_iJevin_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/ijevin", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Impulse_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.youtube.com/impulseSV", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Iskall_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/Iskall85", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Jessassin_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/thejessassin", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_JoeHills_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/joehillstsd", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Keralis_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/keralis", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Mumbo_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/ThatMumboJumbo", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_PythonGB_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/user/PythonGB", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_ReNDoG_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/rendog", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Scar_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/goodtimeswithscar", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Stress_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/stressmonster101", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_TangoTek_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/TangoTekLP", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Tinfoilchef_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/selif1", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_VintageBeef_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/vintagebeef", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Welsknight_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/welsknightgaming", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_xBCrafted_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/xbxaxcx", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Xisuma_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/xisumavoid", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Zedaph_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://youtube.com/zedaphplays", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Hermitcraft_Información_Completa_Miembros_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Información_Miembros_Hermitcraft Ventana = new Ventana_Información_Miembros_Hermitcraft();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Reconstructor_Estructura_Archivos_Recursos_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Reconstructor_Estructura_Archivos_Recursos Ventana = new Ventana_Reconstructor_Estructura_Archivos_Recursos();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Amidst_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.minecraftforum.net/forums/mapping-and-modding-java-edition/minecraft-tools/1262200-v3-7-amidst-strongholds-village-biome-etc-finder", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Chunk_Base_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://chunkbase.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_MC_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mcedit.net/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_MC_Skin_3D_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.planetminecraft.com/mod/mcskin3d/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Miners_Need_Cool_Shoes_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.needcoolshoes.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Name_MC_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://es.namemc.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_NBT_Explorer_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.minecraftforum.net/forums/mapping-and-modding-java-edition/minecraft-tools/1262665-nbtexplorer-nbt-editor-for-windows-and-mac", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_NBT_Explorer_Minecraft_1_13_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://github.com/jaquadro/NBTExplorer/releases", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Note_Block_Studio_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.stuffbydavid.com/mcnbs", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Optifine_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://optifine.net/home", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Skin_History_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://mcskinhistory.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Skin_Viewer_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.minecraftforum.net/forums/mapping-and-modding-java-edition/minecraft-tools/1261408-minecraft-skin-viewer-1-2-supports-1-8-skins", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Spritecraft_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.diamondpants.com/spritecraft/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Substrate_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.minecraftforum.net/forums/mapping-and-modding-java-edition/minecraft-tools/1261313-sdk-substrate-map-editing-library-for-c-net-1-3-8", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Universal_Minecraft_Editor_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.universalminecrafteditor.com/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_David_Maeso_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem Menú = sender as ToolStripMenuItem;
                if (Menú != null)
                {
                    int Índice_Álbum = int.Parse(Menú.Name.Replace("Menú_Principal_David_Maeso_", null));
                    if (Lista_Álbumes_David_Maeso != null && Lista_Álbumes_David_Maeso.Count > 0 && Índice_Álbum > -1 && Índice_Álbum < Lista_Álbumes_David_Maeso.Count && !string.IsNullOrEmpty(Lista_Álbumes_David_Maeso[Índice_Álbum].URL_Html))
                    {
                        Program.Ejecutar_Ruta(Lista_Álbumes_David_Maeso[Índice_Álbum].URL_Html, ProcessWindowStyle.Normal);
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Fratelli_Stellari_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem Menú = sender as ToolStripMenuItem;
                if (Menú != null)
                {
                    int Índice_Álbum = int.Parse(Menú.Name.Replace("Menú_Principal_Fratelli_Stellari_", null));
                    if (Lista_Álbumes_Fratelli_Stellari != null && Lista_Álbumes_Fratelli_Stellari.Count > 0 && Índice_Álbum > -1 && Índice_Álbum < Lista_Álbumes_Fratelli_Stellari.Count && !string.IsNullOrEmpty(Lista_Álbumes_Fratelli_Stellari[Índice_Álbum].URL_Html))
                    {
                        Program.Ejecutar_Ruta(Lista_Álbumes_Fratelli_Stellari[Índice_Álbum].URL_Html, ProcessWindowStyle.Normal);
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_David_Maeso_Visitar_Web_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.davidmaeso.com/index.html", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Jupisoft_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem Menú = sender as ToolStripMenuItem;
                if (Menú != null)
                {
                    int Índice_Álbum = int.Parse(Menú.Name.Replace("Menú_Principal_Jupisoft_", null));
                    if (Lista_Álbumes_Jupisoft != null && Lista_Álbumes_Jupisoft.Count > 0 && Índice_Álbum > -1 && Índice_Álbum < Lista_Álbumes_Jupisoft.Count && !string.IsNullOrEmpty(Lista_Álbumes_Jupisoft[Índice_Álbum].URL_Html))
                    {
                        Program.Ejecutar_Ruta(Lista_Álbumes_Jupisoft[Índice_Álbum].URL_Html, ProcessWindowStyle.Normal);
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Jupisoft_Visitar_Web_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://jupisoft.x10host.com/index.html", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Gracias_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Gracias Ventana = new Ventana_Gracias();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Fratelli_Stellari_Visitar_Web_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.messaggidallestelle.altervista.org/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Picture_Skin_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //if (e.Button != MouseButtons.Right)
                {
                    Temporizador_Principal.Stop();
                    Registro_Restablecer_Opciones();
                    Ventana_Información_Miembros_Hermitcraft Ventana = new Ventana_Información_Miembros_Hermitcraft();
                    Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                    Ventana.Aleatorizar_Inicio = true;
                    Ventana.ShowDialog(this);
                    Ventana.Dispose();
                    Ventana = null;
                    Registro_Guardar_Opciones();
                    Temporizador_Principal.Start();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Descargar_26601_Skins_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mediafire.com/file/rhbf9vd9e002170/26601+Minecraft+Skins.rar", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ver_Descargar_Packs_Recursos_Edición_Consola_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mediafire.com/file/1cc56joz4091n44/Minecraft+Console+Edition+Packs.zip", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem Menú = sender as ToolStripMenuItem;
                if (Menú != null)
                {
                    int Índice_Herramienta = int.Parse(Menú.Name.Replace("Menú_Principal_Herramientas_", null));
                    if (Índice_Herramienta > -1 && Índice_Herramienta < Ventana_Selector_Herramientas.Herramientas.Matriz_Herramientas.Length)
                    {
                        Temporizador_Principal.Stop();
                        Registro_Restablecer_Opciones();
                        Ventana_Selector_Herramientas.Herramientas.Ejecutar_Herramienta(Índice_Herramienta, Variable_Siempre_Visible, this);
                        Registro_Guardar_Opciones();
                        Temporizador_Principal.Start();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramienta_Predeterminada_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem Menú = sender as ToolStripMenuItem;
                if (Menú != null)
                {
                    int Índice_Herramienta = int.Parse(Menú.Name.Replace("Menú_Principal_Herramienta_Predeterminada_", null));
                    if (Índice_Herramienta > -1 && Índice_Herramienta < Ventana_Selector_Herramientas.Herramientas.Matriz_Herramientas.Length)
                    {
                        Temporizador_Principal.Stop();
                        Registro_Restablecer_Opciones();
                        Ventana_Selector_Herramientas.Herramientas.Ejecutar_Herramienta(Índice_Herramienta, Variable_Siempre_Visible, this);
                        Registro_Guardar_Opciones();
                        Temporizador_Principal.Start();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramienta_Predeterminada_Selector_Herramientas_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Selector_Herramientas Ventana = new Ventana_Selector_Herramientas();
                Ventana.Variable_Siempre_Visible = Variable_Siempre_Visible;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Exportador_Estructuras_Internas_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Exportador_Estructuras_Internas Ventana = new Ventana_Exportador_Estructuras_Internas();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Visor_Nombres_Encantamientos_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Visor_Nombres_Encantamientos Ventana = new Ventana_Visor_Nombres_Encantamientos();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Salvapantallas_El_Fin_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Salvapantallas_El_Fin Ventana = new Ventana_Salvapantallas_El_Fin();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Archivo_Instalar_Salvapantallas_El_Fin_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream Lector_Entrada = new FileStream(Application.ExecutablePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                FileStream Lector_Salida = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Minecraft Tools by Jupisoft.scr", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                Lector_Entrada.Seek(0L, SeekOrigin.Begin);
                Lector_Salida.SetLength(0L);
                Lector_Salida.Seek(0L, SeekOrigin.Begin);
                byte[] Matriz_Bytes = new byte[4096];
                for (long Índice_Bloque = 0L; Índice_Bloque < Lector_Entrada.Length; Índice_Bloque += 4096L)
                {
                    int Longitud = Lector_Entrada.Read(Matriz_Bytes, 0, Matriz_Bytes.Length);
                    if (Longitud > 0) Lector_Salida.Write(Matriz_Bytes, 0, Longitud);
                }
                Matriz_Bytes = null;
                Lector_Salida.Flush();
                Lector_Salida.Close();
                Lector_Salida.Dispose();
                Lector_Salida = null;
                Lector_Entrada.Close();
                Lector_Entrada.Dispose();
                Lector_Entrada = null;
                SystemSounds.Asterisk.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Archivo_Desinstalar_Salvapantallas_El_Fin_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Eliminar_Archivo_Carpeta(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Minecraft Tools by Jupisoft.scr")) SystemSounds.Asterisk.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Herramientas_Codificador_Descodificador_Archivos_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
                Registro_Restablecer_Opciones();
                Ventana_Codificador_Descodificador_Archivos Ventana = new Ventana_Codificador_Descodificador_Archivos();
                Ventana.Variable_Siempre_Visible = Menú_Principal_Ver_Siempre_Visible.Checked;
                Ventana.ShowDialog(this);
                Ventana.Dispose();
                Ventana = null;
                Registro_Guardar_Opciones();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Barra_Estado_Botón_Secretos_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control && string.Compare(Environment.UserName, "Jupisoft", true) == 0)
                {
                    // This function is only used to provide to the user some useful zip...
                    // files encrypted, so it should never be used by the user.
                    // Add the extension ".zip" when exporting those files, but not here.
                    string Ruta_Secretos = Application.StartupPath + "\\Secrets";
                    if (!string.IsNullOrEmpty(Ruta_Secretos) && Directory.Exists(Ruta_Secretos))
                    {
                        string[] Matriz_Rutas = Directory.GetFiles(Ruta_Secretos, "*", SearchOption.AllDirectories);
                        if (Matriz_Rutas != null && Matriz_Rutas.Length > 0)
                        {
                            int Archivos_Encriptados = 0;
                            foreach (string Ruta in Matriz_Rutas)
                            {
                                Program.Quitar_Atributo_Sólo_Lectura(Ruta);
                                FileStream Lector = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                                if (Lector != null && Lector.Length > 0L)
                                {
                                    Lector.Seek(0L, SeekOrigin.Begin);
                                    try
                                    {
                                        // Verify if the zip files can be loaded, meaning they aren't encrypted.
                                        SevenZipExtractor Extractor_7_Zip = new SevenZipExtractor(Lector);
                                        if (Extractor_7_Zip == null || Extractor_7_Zip.FilesCount <= 0 || !Extractor_7_Zip.Check())
                                        {
                                            Extractor_7_Zip = null;
                                            continue; // Skip the files that couldn't be loaded as zip files because they should be already encrypted.
                                        }
                                        else Extractor_7_Zip = null;
                                    }
                                    catch (Exception Excepción)
                                    {
                                        Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null);
                                        continue; // Skip the files that couldn't be loaded as zip files because they should be already encrypted.
                                    }
                                    byte[] Matriz_Bytes = new byte[4096];
                                    for (long Índice_Bloque = 0L; Índice_Bloque < Lector.Length; Índice_Bloque += 4096L)
                                    {
                                        Lector.Seek(Índice_Bloque, SeekOrigin.Begin);
                                        int Longitud = Lector.Read(Matriz_Bytes, 0, Matriz_Bytes.Length);
                                        if (Longitud > 0)
                                        {
                                            Matriz_Bytes = Jupisoft_Encrypting_Decrypting.Encriptar_Matriz_Bytes(Matriz_Bytes, true, false, true, false);
                                            Lector.Seek(Índice_Bloque, SeekOrigin.Begin);
                                            Lector.Write(Matriz_Bytes, 0, Longitud);
                                        }
                                        else break;
                                    }
                                    Lector.Close();
                                    Lector.Dispose();
                                    Lector = null;
                                    Archivos_Encriptados++;
                                }
                            }
                            if (Archivos_Encriptados > 0) MessageBox.Show(this, Program.Traducir_Número(Archivos_Encriptados) + (Archivos_Encriptados != 1 ? " files have" : " file has") + " been encrypted successfully in the \"Secrets\" folder.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if((Control.ModifierKeys & Keys.Shift) != Keys.Shift)
                {
                    Temporizador_Principal.Stop();
                    Registro_Restablecer_Opciones();
                    Ventana_Visor_Ayuda Ventana = new Ventana_Visor_Ayuda();
                    Ventana.Ayuda = Ventana_Visor_Ayuda.Ayudas.Secrets;
                    Ventana.ShowDialog(this);
                    Ventana.Dispose();
                    Ventana = null;
                    Registro_Guardar_Opciones();
                    Temporizador_Principal.Start();
                }
                else
                {
                    //Temporizador_Principal.Stop();
                    //Registro_Restablecer_Opciones();
                    Barra_Estado_Botón_Secretos.Text = "Secrets: visible";
                    Ventana_Secretos Ventana = new Ventana_Secretos();
                    Ventana.ShowDialog(this);
                    Ventana.Dispose();
                    Ventana = null;
                    Barra_Estado_Botón_Secretos.Text = "Secrets: hidden";
                    //Registro_Guardar_Opciones();
                    //Temporizador_Principal.Start();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Picture_Splash_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.None)
                {
                    Variable_Alfabeto_Galáctico = !Variable_Alfabeto_Galáctico;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Reddit_Xisumavoid_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.reddit.com/r/Minecraft/comments/852eoc/minecraft_113_chunk_format_fully_decoded/", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_Licencia_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.gnu.org/licenses/gpl-3.0.html", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Principal_Ayuda_GitHub_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://github.com/Jupisoft111/Minecraft-Tools", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

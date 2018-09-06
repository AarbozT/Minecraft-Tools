using Minecraft_Tools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Visor_Cuadros : Form
    {
        public Ventana_Visor_Cuadros()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Structure that holds up all the information about a painting.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct Cuadros
        {
            internal string Nombre;
            internal string Nombre_Real;
            internal string Versión;
            internal string Descripción;
            internal string Recurso;
            internal string Recurso_Faithful;
            internal string Recurso_Real;
            internal Rectangle Rectángulo;

            internal Cuadros(string Nombre, string Nombre_Real, string Versión, string Descripción, string Recurso, string Recurso_Faithful, string Recurso_Real, Rectangle Rectángulo)
            {
                this.Nombre = Nombre;
                this.Nombre_Real = Nombre_Real;
                this.Versión = Versión;
                this.Descripción = Descripción;
                this.Recurso = Recurso;
                this.Recurso_Faithful = Recurso_Faithful;
                this.Recurso_Real = Recurso_Real;
                this.Rectángulo = Rectángulo;
            }

            internal static readonly Cuadros[] Matriz_Cuadros = new Cuadros[]
            {
                new Cuadros
                (
                    "Alban",
                    "Albanian",
                    "Indev",
                    "A man wearing a fez in a desert-type land stood next to a house and a bush. As the name of the painting suggests, it may be a landscape in Albania. However Albania is mostly snowy mountains and there are no \"deserts\", therefore making it impossible to be located in Albania.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Alban",
                    new Rectangle(32, 0, 16, 16)
                ),
                new Cuadros
                (
                    "Aztec",
                    "de_aztec",
                    "Indev",
                    "Free-look perspective of the map de_aztec from the video game Counter-Strike.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Aztec",
                    new Rectangle(16, 0, 16, 16)
                ),
                new Cuadros
                (
                    "Aztec2",
                    "de_aztec",
                    "Indev",
                    "Free-look perspective of the map de_aztec from the video game Counter-Strike.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Aztec2",
                    new Rectangle(48, 0, 16, 16)
                ),
                new Cuadros
                (
                    "Bomb",
                    "Target successfully bombed",
                    "Indev",
                    "Painting of the Counter-Strike map de_dust2, named \"target successfully bombed\" in reference to the game.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Bomb",
                    new Rectangle(64, 0, 16, 16)
                ),
                new Cuadros
                (
                    "Burning skull",
                    "Skull on Fire",
                    "Beta 1.2_01",
                    "A Skull on pixelated fire; in the background there is a moon in a clear night sky.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_BurningSkull",
                    new Rectangle(128, 192, 64, 64)
                ),
                new Cuadros
                (
                    "Bust",
                    "Bust",
                    "Indev",
                    "Painting of a statue bust surrounded by pixelated fire.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Bust",
                    new Rectangle(32, 128, 32, 32)
                ),
                new Cuadros
                (
                    "Courbet",
                    "Bonjour monsieur Courbet",
                    "Indev",
                    "Two hikers with pointy beards seemingly greeting each other. This painting is based on the realist painter Gustave Courbet's 1854 painting of the same title.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Courbet",
                    new Rectangle(32, 32, 32, 16)
                ),
                new Cuadros
                (
                    "Creebet",
                    "Seaside",
                    "Alpha 1.1.1",
                    "Painting of a view of mountains and a lake, with a small photo of a mountain and a creeper looking at the viewer through a window.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Sea",
                    new Rectangle(128, 32, 32, 16)
                ),
                new Cuadros
                (
                    "Donkey Kong",
                    "Kong",
                    "Alpha 1.1.1",
                    "A paper-looking screenshot of the level 100 m. from the original \"Donkey Kong\" arcade game.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_DonkeyKong",
                    new Rectangle(192, 112, 64, 48)
                ),
                new Cuadros
                (
                    "Fighters",
                    "Fighters",
                    "Indev",
                    "Two pixelated men poised to fight. Paper versions of fighters from the game \"International Karate+\".",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Fighters",
                    new Rectangle(0, 96, 64, 32)
                ),
                new Cuadros
                (
                    "Graham",
                    "Graham",
                    "Alpha 1.1.1",
                    "A small picture of King Graham, the player character in the King's Quest series.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Graham",
                    new Rectangle(16, 64, 16, 32)
                ),
                new Cuadros
                (
                    "Kebab",
                    "Kebab med tre pepperoni",
                    "Indev",
                    "A kebab with three green chili peppers.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Kebab",
                    new Rectangle(0, 0, 16, 16)
                ),
                new Cuadros
                (
                    "Match",
                    "Match",
                    "Indev",
                    "A hand holding a match, causing pixelated fire on a white cubic gas fireplace.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Match",
                    new Rectangle(0, 128, 32, 32)
                ),
                new Cuadros
                (
                    "Pigscene",
                    "RGB",
                    "Alpha 1.1.1",
                    "Painting of a girl that is pointing to a pig on a canvas. In the original version, the canvas shows red, green and blue blocks, representing the three colors of the RGB color model that is typically used by computer displays.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Pigscene",
                    new Rectangle(64, 192, 64, 64)
                ),
                new Cuadros
                (
                    "Plant",
                    "Paradisträd",
                    "Indev",
                    "Still life painting of two plants in pots. \"Paradisträd\" is Swedish for \"Paradise tree\", which is a common name for the depicted species in Scandinavia.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Plant",
                    new Rectangle(80, 0, 16, 16)
                ),
                new Cuadros
                (
                    "Pointer",
                    "Pointer",
                    "Indev",
                    "A painting of the main character of the classic Atari game International Karate (the Karateka character had white hair, this one clearly has black hair) fighting a large hand. It could also be interpreted as the two hands touching as seen in Michelangelo's Sistine Chapel painting.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Pointer",
                    new Rectangle(0, 192, 64, 64)
                ),
                new Cuadros
                (
                    "Pool",
                    "The pool",
                    "Indev",
                    "Some men and women skinny-dipping in a pool over a cube of sorts. Also there is an old man resting in the lower-right edge.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Pool",
                    new Rectangle(0, 32, 32, 16)
                ),
                new Cuadros
                (
                    "Sea",
                    "Seaside",
                    "Indev",
                    "Painting of a view of mountains and a lake, with a small photo of a mountain and a dull-colored plant on the window ledge. Note: In Alpha 1.1.1, this painting was replaced by the next image, featuring a more colorful plant.",
                    "Cuadros_Indev",
                    "Cuadros_Faithful",
                    "Cuadros_Sea",
                    new Rectangle(64, 32, 32, 16)
                ),
                new Cuadros
                (
                    "Sea",
                    "Seaside",
                    "Alpha 1.1.1",
                    "Painting of a view of mountains and a lake, with a small photo of a mountain and a dull-colored plant on the window ledge. Note: In Alpha 1.1.1, this painting replaced the previous image, featuring a less colorful plant.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Sea",
                    new Rectangle(64, 32, 32, 16)
                ),
                new Cuadros
                (
                    "Skeleton",
                    "Mortal Coil",
                    "Alpha 1.1.1",
                    "A painting of the \"Mean Midget\" from the adventure game Grim Fandango.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Skeleton",
                    new Rectangle(192, 64, 64, 48)
                ),
                new Cuadros
                (
                    "Skull and roses",
                    "Moonlight Installation",
                    "Indev",
                    "Painting of a skeleton at night with red flowers in the foreground. The original painting is very different, depicting a woman sitting in a couch, while the skull is in the middle of a body of glacial water of sorts.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_SkullAndRoses",
                    new Rectangle(128, 128, 32, 32)
                ),
                new Cuadros
                (
                    "Stage",
                    "The stage is set",
                    "Indev",
                    "Painting of scenery from Space Quest I, with the character Graham from King's Quest. Note: In Alpha 1.1.1, this painting was replaced by the next image, featuring a larger spider.",
                    "Cuadros_Indev",
                    "Cuadros_Faithful",
                    "Cuadros_Stage",
                    new Rectangle(64, 128, 32, 32)
                ),
                new Cuadros
                (
                    "Stage",
                    "The stage is set",
                    "Alpha 1.1.1",
                    "Painting of scenery from Space Quest I, with the character Graham from King's Quest. Note: In Alpha 1.1.1, this painting replaced the previous image, featuring a smaller spider.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Stage",
                    new Rectangle(64, 128, 32, 32)
                ),
                new Cuadros
                (
                    "Sunset",
                    "sunset_dense",
                    "Indev",
                    "Painting of a view of mountains at sunset.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Sunset",
                    new Rectangle(96, 32, 32, 16)
                ),
                new Cuadros
                (
                    "Void",
                    "The Void",
                    "Indev",
                    "Painting of an angel praying into what appears to be a void with pixelated fire below.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Void",
                    new Rectangle(96, 128, 32, 32)
                ),
                new Cuadros
                (
                    "Wanderer",
                    "Wanderer",
                    "Indev",
                    "A low-resolution version of Caspar David Friedrich's famous painting Wanderer above the Sea of Fog.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Wanderer",
                    new Rectangle(0, 64, 16, 32)
                ),
                new Cuadros
                (
                    "Wasteland",
                    "Wasteland",
                    "Indev",
                    "Painting of a view of some wastelands; a small animal (presumably a rabbit) is sitting on the window ledge.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Wasteland",
                    new Rectangle(96, 0, 16, 16)
                ),
                new Cuadros
                (
                    "Wither",
                    "Wither", // "-",
                    "1.4.2 (Snapshot 12w36a)",
                    "Painting depicting the creation of a wither. This is the only painting not based on a real painting.",
                    "Cuadros",
                    "Cuadros_Faithful",
                    "Cuadros_Wither",
                    new Rectangle(160, 128, 32, 32)
                )
            };
        }
        
        internal static CheckState Variable_HD = CheckState.Indeterminate;
        internal static int Variable_Cuadro = 0;
        internal static CheckState Variable_Antialiasing = CheckState.Unchecked;
        internal static bool Variable_Autozoom = true;
        internal static bool Variable_Filtro_Negativo = false;
        internal static bool Variable_Filtro_Raíz_Cuadrada = false;
        internal static bool Variable_Filtro_Logaritmo = false;

        internal readonly string Texto_Título = "Paintings Viewer for " + Program.Texto_Usuario + " by Jupisoft";
        internal bool Variable_Siempre_Visible = false;
        internal bool Variable_Excepción = false;
        internal bool Variable_Excepción_Imagen = false;
        internal int Variable_Excepción_Total = 0;
        internal bool Variable_Memoria = false;

        private void Ventana_Visor_Cuadros_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Texto_Título;
                this.WindowState = FormWindowState.Maximized;
                for (int Índice_Cuadro = 0; Índice_Cuadro < Cuadros.Matriz_Cuadros.Length; Índice_Cuadro++)
                {
                    ComboBox_Cuadro.Items.Add(Cuadros.Matriz_Cuadros[Índice_Cuadro].Nombre + " (" + Cuadros.Matriz_Cuadros[Índice_Cuadro].Nombre_Real + ") [" + Cuadros.Matriz_Cuadros[Índice_Cuadro].Versión + "]");
                }
                CheckBox_Cuadro_HD.CheckState = Variable_HD;
                CheckBox_Antialiasing.CheckState = Variable_Antialiasing;
                CheckBox_Autozoom.Checked = Variable_Autozoom;
                Menú_Contextual_Filtro_Negativo.Checked = Variable_Filtro_Negativo;
                Menú_Contextual_Filtro_Raíz_Cuadrada.Checked = Variable_Filtro_Raíz_Cuadrada;
                Menú_Contextual_Filtro_Logaritmo.Checked = Variable_Filtro_Logaritmo;
                if (ComboBox_Cuadro.Items.Count > 0) ComboBox_Cuadro.SelectedIndex = 0;
                TextBox_Descripción.Font = new Font("Calibri", 10f);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Cuadros_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Cuadros_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Cuadros_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Cuadros_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                Establecer_Cuadro();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Cuadros_KeyDown(object sender, KeyEventArgs e)
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
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Menú_Contextual_Filtro_Logaritmo.PerformClick();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Cuadro_HD_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_HD = CheckBox_Cuadro_HD.CheckState;
                Establecer_Cuadro();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ComboBox_Cuadro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboBox_Cuadro.SelectedIndex > -1)
                {
                    Variable_Cuadro = ComboBox_Cuadro.SelectedIndex;
                    Establecer_Cuadro();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Antialiasing_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Antialiasing = CheckBox_Antialiasing.CheckState;
                Establecer_Cuadro();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Autozoom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Autozoom = CheckBox_Autozoom.Checked;
                Establecer_Cuadro();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Visor_Ayuda_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana_Visor_Ayuda Ventana = new Ventana_Visor_Ayuda();
                Ventana.Ayuda = Ventana_Visor_Ayuda.Ayudas.Paintings_viewer;
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

        private void Menú_Contextual_Depurador_Interno_Click(object sender, EventArgs e)
        {
            try
            {
                Ventana_Depurador Ventana = new Ventana_Depurador();
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
                Program.Crear_Carpetas(Program.Ruta_Guardado_Imágenes_Visor_Cuadros);
                Program.Ejecutar_Ruta(Program.Ruta_Guardado_Imágenes_Visor_Cuadros, ProcessWindowStyle.Maximized);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Establecer_Cuadro();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Filtro_Negativo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Filtro_Negativo = Menú_Contextual_Filtro_Negativo.Checked;
                Establecer_Cuadro();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Filtro_Raíz_Cuadrada_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Filtro_Raíz_Cuadrada = Menú_Contextual_Filtro_Raíz_Cuadrada.Checked;
                Establecer_Cuadro();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Filtro_Logaritmo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Filtro_Logaritmo = Menú_Contextual_Filtro_Logaritmo.Checked;
                Establecer_Cuadro();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Copiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Picture.Image != null)
                {
                    Clipboard.SetImage(Picture.Image);
                    SystemSounds.Asterisk.Play();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Menú_Contextual_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Picture.Image != null)
                {
                    Program.Crear_Carpetas(Program.Ruta_Guardado_Imágenes_Visor_Cuadros);
                    Picture.Image.Save(Program.Ruta_Guardado_Imágenes_Visor_Cuadros + "\\" + Program.Obtener_Nombre_Temporal_Sin_Guiones() + " " + Cuadros.Matriz_Cuadros[Variable_Cuadro].Nombre + (Variable_HD == CheckState.Unchecked ? null : (Variable_HD == CheckState.Unchecked ? " HD" : " Real")) + ".png", ImageFormat.Png);
                    SystemSounds.Asterisk.Play();
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
                catch { Barra_Estado_Etiqueta_Memoria.Text = "RAM: ? MB (? GB)"; }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        internal static readonly byte[] Matriz_Raíz_Cuadrada = new byte[256] { 0, 16, 23, 28, 32, 36, 39, 42, 45, 48, 50, 53, 55, 58, 60, 62, 64, 66, 68, 70, 71, 73, 75, 77, 78, 80, 81, 83, 84, 86, 87, 89, 90, 92, 93, 94, 96, 97, 98, 100, 101, 102, 103, 105, 106, 107, 108, 109, 111, 112, 113, 114, 115, 116, 117, 118, 119, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 145, 146, 147, 148, 149, 150, 151, 151, 152, 153, 154, 155, 156, 156, 157, 158, 159, 160, 160, 161, 162, 163, 164, 164, 165, 166, 167, 167, 168, 169, 170, 170, 171, 172, 173, 173, 174, 175, 176, 176, 177, 178, 179, 179, 180, 181, 181, 182, 183, 183, 184, 185, 186, 186, 187, 188, 188, 189, 190, 190, 191, 192, 192, 193, 194, 194, 195, 196, 196, 197, 198, 198, 199, 199, 200, 201, 201, 202, 203, 203, 204, 204, 205, 206, 206, 207, 208, 208, 209, 209, 210, 211, 211, 212, 212, 213, 214, 214, 215, 215, 216, 217, 217, 218, 218, 219, 220, 220, 221, 221, 222, 222, 223, 224, 224, 225, 225, 226, 226, 227, 228, 228, 229, 229, 230, 230, 231, 231, 232, 233, 233, 234, 234, 235, 235, 236, 236, 237, 237, 238, 238, 239, 240, 240, 241, 241, 242, 242, 243, 243, 244, 244, 245, 245, 246, 246, 247, 247, 248, 248, 249, 249, 250, 250, 251, 251, 252, 252, 253, 253, 254, 254, 255 };
        internal static readonly byte[] Matriz_Logaritmo = new byte[256] { 0, 31, 50, 63, 73, 82, 89, 95, 100, 105, 110, 114, 117, 121, 124, 127, 130, 132, 135, 137, 140, 142, 144, 146, 148, 149, 151, 153, 154, 156, 158, 159, 160, 162, 163, 164, 166, 167, 168, 169, 170, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 181, 182, 183, 184, 185, 186, 186, 187, 188, 189, 190, 190, 191, 192, 192, 193, 194, 194, 195, 196, 196, 197, 198, 198, 199, 200, 200, 201, 201, 202, 202, 203, 204, 204, 205, 205, 206, 206, 207, 207, 208, 208, 209, 209, 210, 210, 211, 211, 212, 212, 213, 213, 213, 214, 214, 215, 215, 216, 216, 216, 217, 217, 218, 218, 218, 219, 219, 220, 220, 220, 221, 221, 222, 222, 222, 223, 223, 223, 224, 224, 224, 225, 225, 225, 226, 226, 226, 227, 227, 227, 228, 228, 228, 229, 229, 229, 230, 230, 230, 231, 231, 231, 232, 232, 232, 232, 233, 233, 233, 234, 234, 234, 234, 235, 235, 235, 236, 236, 236, 236, 237, 237, 237, 237, 238, 238, 238, 238, 239, 239, 239, 240, 240, 240, 240, 241, 241, 241, 241, 241, 242, 242, 242, 242, 243, 243, 243, 243, 244, 244, 244, 244, 245, 245, 245, 245, 245, 246, 246, 246, 246, 247, 247, 247, 247, 247, 248, 248, 248, 248, 248, 249, 249, 249, 249, 249, 250, 250, 250, 250, 250, 251, 251, 251, 251, 251, 252, 252, 252, 252, 252, 253, 253, 253, 253, 253, 254, 254, 254, 254, 254, 254, 255, 255, 255 };

        internal void Establecer_Cuadro()
        {
            try
            {
                Bitmap Imagen = null;
                if (Variable_HD == CheckState.Unchecked) Imagen = Program.Obtener_Imagen_Recursos(Cuadros.Matriz_Cuadros[Variable_Cuadro].Recurso).Clone(Cuadros.Matriz_Cuadros[Variable_Cuadro].Rectángulo, PixelFormat.Format32bppArgb);
                else if (Variable_HD == CheckState.Checked) Imagen = Program.Obtener_Imagen_Recursos(Cuadros.Matriz_Cuadros[Variable_Cuadro].Recurso_Faithful).Clone(new Rectangle(Cuadros.Matriz_Cuadros[Variable_Cuadro].Rectángulo.X * 2, Cuadros.Matriz_Cuadros[Variable_Cuadro].Rectángulo.Y * 2, Cuadros.Matriz_Cuadros[Variable_Cuadro].Rectángulo.Width * 2, Cuadros.Matriz_Cuadros[Variable_Cuadro].Rectángulo.Height * 2), PixelFormat.Format32bppArgb);
                else Imagen = Program.Obtener_Imagen_Recursos(Cuadros.Matriz_Cuadros[Variable_Cuadro].Recurso_Real);
                int Ancho = Imagen.Width;
                int Alto = Imagen.Height;
                if (Variable_Filtro_Negativo || Variable_Filtro_Raíz_Cuadrada || Variable_Filtro_Logaritmo)
                {
                    BitmapData Bitmap_Data = Imagen.LockBits(new Rectangle(0, 0, Ancho, Alto), ImageLockMode.ReadWrite, Imagen.PixelFormat);
                    byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * Alto];
                    Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                    int Bytes_Aumento = Image.IsAlphaPixelFormat(Imagen.PixelFormat) ? 4 : 3;
                    int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((Ancho * Image.GetPixelFormatSize(Imagen.PixelFormat)) / 8);
                    for (int Y = 0, Índice = 0; Y < Alto; Y++, Índice += Bytes_Diferencia)
                    {
                        for (int X = 0; X < Ancho; X++, Índice += Bytes_Aumento)
                        {
                            if (Variable_Filtro_Negativo)
                            {
                                Matriz_Bytes[Índice + 2] = (byte)(255 - Matriz_Bytes[Índice + 2]);
                                Matriz_Bytes[Índice + 1] = (byte)(255 - Matriz_Bytes[Índice + 1]);
                                Matriz_Bytes[Índice] = (byte)(255 - Matriz_Bytes[Índice]);
                            }
                            if (Variable_Filtro_Raíz_Cuadrada)
                            {
                                Matriz_Bytes[Índice + 2] = Matriz_Raíz_Cuadrada[Matriz_Bytes[Índice + 2]];
                                Matriz_Bytes[Índice + 1] = Matriz_Raíz_Cuadrada[Matriz_Bytes[Índice + 1]];
                                Matriz_Bytes[Índice] = Matriz_Raíz_Cuadrada[Matriz_Bytes[Índice]];
                            }
                            if (Variable_Filtro_Logaritmo)
                            {
                                Matriz_Bytes[Índice + 2] = Matriz_Logaritmo[Matriz_Bytes[Índice + 2]];
                                Matriz_Bytes[Índice + 1] = Matriz_Logaritmo[Matriz_Bytes[Índice + 1]];
                                Matriz_Bytes[Índice] = Matriz_Logaritmo[Matriz_Bytes[Índice]];
                            }
                        }
                    }
                    Marshal.Copy(Matriz_Bytes, 0, Bitmap_Data.Scan0, Matriz_Bytes.Length);
                    Imagen.UnlockBits(Bitmap_Data);
                    Bitmap_Data = null;
                    Matriz_Bytes = null;
                }
                int Zoom = 1;
                if (Variable_Autozoom) Imagen = Program.Obtener_Imagen_Autozoom(Imagen, Picture.ClientSize.Width, Picture.ClientSize.Height, true, Variable_Antialiasing, out Zoom);
                this.Text = Texto_Título + " - [Minecraft " + Cuadros.Matriz_Cuadros[Variable_Cuadro].Versión + ", Dimensions: " + Program.Traducir_Número(Ancho) + " x " + Program.Traducir_Número(Alto) + (Ancho + Alto != 1 ? " pixels" : " pixel") + ", Autozoom: " + Program.Traducir_Número(Zoom) + "x]";
                Picture.Image = Imagen;
                Picture.Refresh();
                TextBox_Descripción.Text = "\"" + Cuadros.Matriz_Cuadros[Variable_Cuadro].Nombre_Real + "\": " + Cuadros.Matriz_Cuadros[Variable_Cuadro].Descripción;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

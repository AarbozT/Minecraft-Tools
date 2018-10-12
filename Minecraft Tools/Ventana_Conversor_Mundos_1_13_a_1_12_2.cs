using ImageMagick;
using Microsoft.Win32;
using Minecraft_Tools.Properties;
using Substrate;
using Substrate.Core;
using Substrate.Nbt;
using System;
using System.Collections;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Conversor_Mundos_1_13_a_1_12_2 : Form
    {
        public Ventana_Conversor_Mundos_1_13_a_1_12_2()
        {
            InitializeComponent();
        }

        internal static readonly int[] Matriz_Máscaras_Bits = new int[]
        {
            1, // 1 bit
            3,
            7,
            15,
            31,
            63,
            127,
            255,
            511,
            1023,
            2047,
            4095 // 12 bits
        };

        // General window variables.
        internal readonly string Texto_Título = "Minecraft 1.13+ to 1.12.2- World Converter for " + Program.Texto_Usuario + " by Jupisoft";
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

        // Variables used to save and reload the window settings each time it starts.
        internal static int Dimensión_Overworld = 0;
        internal static int Dimensión_Nether = 1;
        internal static int Dimensión_The_End = 2;
        internal static bool Prueba_Mundo_Acuático = false;
        internal static bool Prueba_Eliminar_Agua = false;
        internal static bool Prueba_Eliminar_Lava = false;
        internal static bool Prueba_Eliminar_Piedras = false;
        internal static bool Prueba_Eliminar_Tierra = false;
        internal static bool Prueba_Eliminar_Netherrack = false;
        internal static bool Prueba_Eliminar_End_Stone = false;
        internal static bool Prueba_Eliminar_Lecho_Roca = false;
        internal static bool Prueba_Eliminar_Minerales = false;
        internal static bool Prueba_Intercambiar_Agua_Lava = false;
        internal static bool Prueba_Intercambiar_Lava_Agua = false;
        internal static CheckState Prueba_Mundo_Lana = CheckState.Unchecked;
        internal static CheckState Prueba_Mundo_Plástico = CheckState.Unchecked;
        internal static CheckState Prueba_Mundo_Minerales = CheckState.Unchecked;
        internal static bool Prueba_Forzar_Luz_Máxima = false;

        // Temporal variables used in each world conversion.
        internal string Ruta_Mundo = null;
        internal string Ruta_Regiones_Overworld = null;
        internal string Ruta_Regiones_Nether = null;
        internal string Ruta_Regiones_The_End = null;
        Rectangle Rectángulo_Dimensiones_Overworld;
        Rectangle Rectángulo_Dimensiones_Nether;
        Rectangle Rectángulo_Dimensiones_The_End;
        List<Point> Lista_Posiciones_Regiones_Overworld = null;
        List<Point> Lista_Posiciones_Regiones_Nether = null;
        List<Point> Lista_Posiciones_Regiones_The_End = null;
        internal List<string> Lista_Rutas_Mundos_Minecraft = new List<string>();
        internal Thread Subproceso = null;
        internal bool Pendiente_Subproceso_Abortar = false;
        internal bool Subproceso_Activo = false;

        private void Ventana_Conversor_Mundos_1_13_a_1_12_2_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Texto_Título + " - [The original world files will never be modified]";
                this.WindowState = FormWindowState.Maximized;
                ComboBox_Overworld.SelectedIndex = Dimensión_Overworld;
                ComboBox_Nether.SelectedIndex = Dimensión_Nether;
                ComboBox_The_End.SelectedIndex = Dimensión_The_End;
                CheckBox_Mundo_Acuático.Checked = Prueba_Mundo_Acuático;
                CheckBox_Eliminar_Agua.Checked = Prueba_Eliminar_Agua;
                CheckBox_Eliminar_Lava.Checked = Prueba_Eliminar_Lava;
                CheckBox_Eliminar_Piedras.Checked = Prueba_Eliminar_Piedras;
                CheckBox_Eliminar_Tierra.Checked = Prueba_Eliminar_Tierra;
                CheckBox_Eliminar_Netherrack.Checked = Prueba_Eliminar_Netherrack;
                CheckBox_Eliminar_End_Stone.Checked = Prueba_Eliminar_End_Stone;
                CheckBox_Eliminar_Lecho_Roca.Checked = Prueba_Eliminar_Lecho_Roca;
                CheckBox_Eliminar_Minerales.Checked = Prueba_Eliminar_Minerales;
                CheckBox_Intercambiar_Agua_Lava.Checked = Prueba_Intercambiar_Agua_Lava;
                CheckBox_Intercambiar_Lava_Agua.Checked = Prueba_Intercambiar_Lava_Agua;
                CheckBox_Mundo_Lana.CheckState = Prueba_Mundo_Lana;
                CheckBox_Mundo_Plástico.CheckState = Prueba_Mundo_Plástico;
                CheckBox_Mundo_Minerales.CheckState = Prueba_Mundo_Minerales;
                CheckBox_Forzar_Luz_Máxima.Checked = Prueba_Forzar_Luz_Máxima;
                Ocupado = true;
                Registro_Cargar_Opciones(); // Not working yet, sorry.
                Ocupado = false;
                // Load the existing Minecraft worlds from the default save folder:
                if (Directory.Exists(Program.Ruta_Guardado_Minecraft))
                {
                    Lista_Rutas_Mundos_Minecraft.AddRange(Directory.GetDirectories(Program.Ruta_Guardado_Minecraft, "*", SearchOption.TopDirectoryOnly));
                    if (Lista_Rutas_Mundos_Minecraft != null && Lista_Rutas_Mundos_Minecraft.Count > 0)
                    {
                        if (Lista_Rutas_Mundos_Minecraft.Count > 1) Lista_Rutas_Mundos_Minecraft.Sort();
                        foreach (string Ruta in Lista_Rutas_Mundos_Minecraft)
                        {
                            ComboBox_Ruta_Mundo_1_13.Items.Add(Ruta);
                        }
                        ComboBox_Ruta_Mundo_1_13.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Conversor_Mundos_1_13_a_1_12_2_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                ComboBox_Ruta_Mundo_1_13.SelectAll(); // For fast editing.
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Conversor_Mundos_1_13_a_1_12_2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Subproceso_Activo)
                {
                    if (MessageBox.Show(this, "Currently there is a world conversion in progress.\r\nDo you want to cancel it, but saving what has been done?", Program.Texto_Título_Versión, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes && Subproceso_Activo) // Since a message can stay on top for infinite time, double check if it's still converting.
                    {
                        Pendiente_Subproceso_Abortar = true;
                    }
                    e.Cancel = true;
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Conversor_Mundos_1_13_a_1_12_2_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Conversor_Mundos_1_13_a_1_12_2_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, true) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Conversor_Mundos_1_13_a_1_12_2_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                {
                    string[] Matriz_Rutas = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                    if (Matriz_Rutas != null && Matriz_Rutas.Length > 0)
                    {
                        foreach (string Ruta in Matriz_Rutas)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(Ruta) && (File.Exists(Ruta) || Directory.Exists(Ruta)))
                                {
                                    ComboBox_Ruta_Mundo_1_13.Text = Directory.Exists(Ruta) ? Ruta : Path.GetDirectoryName(Ruta);
                                    //Minecraft.Información_Niveles Información_Nivel = Minecraft.Información_Niveles.Obtener_Información_Nivel(Ruta);
                                    break;
                                }
                            }
                            catch (Exception Excepción)
                            {
                                Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null);
                                continue;
                            }
                        }
                        Matriz_Rutas = null;
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Conversor_Mundos_1_13_a_1_12_2_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Conversor_Mundos_1_13_a_1_12_2_KeyDown(object sender, KeyEventArgs e)
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
                        Botón_Convertir.PerformClick();
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ComboBox_Overworld_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dimensión_Overworld = ComboBox_Overworld.SelectedIndex;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ComboBox_Nether_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dimensión_Nether = ComboBox_Nether.SelectedIndex;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void ComboBox_The_End_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dimensión_The_End = ComboBox_The_End.SelectedIndex;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Mundo_Acuático_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Mundo_Acuático = CheckBox_Mundo_Acuático.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Eliminar_Agua_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Eliminar_Agua = CheckBox_Eliminar_Agua.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Eliminar_Lava_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Eliminar_Lava = CheckBox_Eliminar_Lava.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Eliminar_Piedras_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Eliminar_Piedras = CheckBox_Eliminar_Piedras.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Eliminar_Tierra_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Eliminar_Tierra = CheckBox_Eliminar_Tierra.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Eliminar_Netherrack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Eliminar_Netherrack = CheckBox_Eliminar_Netherrack.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Eliminar_End_Stone_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Eliminar_End_Stone = CheckBox_Eliminar_End_Stone.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Eliminar_Lecho_Roca_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Eliminar_Lecho_Roca = CheckBox_Eliminar_Lecho_Roca.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Eliminar_Minerales_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Eliminar_Minerales = CheckBox_Eliminar_Minerales.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Intercambiar_Agua_Lava_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Intercambiar_Agua_Lava = CheckBox_Intercambiar_Agua_Lava.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Intercambiar_Lava_Agua_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Intercambiar_Lava_Agua = CheckBox_Intercambiar_Lava_Agua.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Mundo_Lana_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Mundo_Lana = CheckBox_Mundo_Lana.CheckState;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Mundo_Plástico_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Mundo_Plástico = CheckBox_Mundo_Plástico.CheckState;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Mundo_Minerales_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Mundo_Minerales = CheckBox_Mundo_Minerales.CheckState;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Forzar_Luz_Máxima_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Prueba_Forzar_Luz_Máxima = CheckBox_Forzar_Luz_Máxima.Checked;
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

        private void Botón_Convertir_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificar_Texturas_32_Bits_Alfa(null);
                //return;
                Ruta_Mundo = ComboBox_Ruta_Mundo_1_13.Text;
                if (!string.IsNullOrEmpty(Ruta_Mundo) && Directory.Exists(Ruta_Mundo))
                {
                    Ruta_Regiones_Overworld = Ruta_Mundo + "\\region";
                    Ruta_Regiones_Nether = Ruta_Mundo + "\\DIM-1\\region";
                    Ruta_Regiones_The_End = Ruta_Mundo + "\\DIM1\\region";
                    if (Directory.Exists(Ruta_Regiones_Overworld) || Directory.Exists(Ruta_Regiones_Nether) || Directory.Exists(Ruta_Regiones_The_End))
                    {
                        Lista_Posiciones_Regiones_Overworld = Minecraft.Obtener_Rutas_Regiones(Ruta_Regiones_Overworld, out Rectángulo_Dimensiones_Overworld);
                        Lista_Posiciones_Regiones_Nether = Minecraft.Obtener_Rutas_Regiones(Ruta_Regiones_Nether, out Rectángulo_Dimensiones_Nether);
                        Lista_Posiciones_Regiones_The_End = Minecraft.Obtener_Rutas_Regiones(Ruta_Regiones_The_End, out Rectángulo_Dimensiones_The_End);
                        if ((Lista_Posiciones_Regiones_Overworld != null && Lista_Posiciones_Regiones_Overworld.Count > 0) ||
                            (Lista_Posiciones_Regiones_Nether != null && Lista_Posiciones_Regiones_Nether.Count > 0) ||
                            (Lista_Posiciones_Regiones_The_End != null && Lista_Posiciones_Regiones_The_End.Count > 0))
                        {
                            long Total_Regiones = Lista_Posiciones_Regiones_Overworld.Count + Lista_Posiciones_Regiones_Nether.Count + Lista_Posiciones_Regiones_The_End.Count;
                            if (MessageBox.Show(this, "The selected world is ready to be converted.\r\nThe original world files will never be modified.\r\n\r\n" +
                                "Overworld region files: " + Program.Traducir_Número(Lista_Posiciones_Regiones_Overworld.Count) + " (chunks: " + Program.Traducir_Número((long)Lista_Posiciones_Regiones_Overworld.Count * 1024L) + ", blocks: " + Program.Traducir_Número((long)Lista_Posiciones_Regiones_Overworld.Count * 1024L * 65536L) + ").\r\n" +
                                "Nether region files: " + Program.Traducir_Número(Lista_Posiciones_Regiones_Nether.Count) + " (chunks: " + Program.Traducir_Número((long)Lista_Posiciones_Regiones_Nether.Count * 1024L) + ", blocks: " + Program.Traducir_Número((long)Lista_Posiciones_Regiones_Nether.Count * 1024L * 65536L) + ").\r\n" +
                                "The End region files: " + Program.Traducir_Número(Lista_Posiciones_Regiones_The_End.Count) + " (chunks: " + Program.Traducir_Número((long)Lista_Posiciones_Regiones_The_End.Count * 1024L) + ", blocks: " + Program.Traducir_Número((long)Lista_Posiciones_Regiones_The_End.Count * 1024L * 65536L) + ").\r\n\r\n" +
                                "Total region files: " + Program.Traducir_Número(Total_Regiones) + " (chunks: " + Program.Traducir_Número(Total_Regiones * 1024L) + ", blocks: " + Program.Traducir_Número((long)Total_Regiones * 1024L * 65536L) + ").\r\n" +
                                "\r\nDo you want to start the conversion as a new 1.12.2- world?", Program.Texto_Título_Versión, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ComboBox_Ruta_Mundo_1_13.Enabled = false;
                                Botón_Convertir.Enabled = false;
                                Subproceso = new Thread(new ThreadStart(Subproceso_DoWork));
                                Subproceso.IsBackground = true;
                                Subproceso.Priority = ThreadPriority.Normal;
                                Subproceso.Start();
                            }
                        }
                        else MessageBox.Show(this, "The select world doesn't have any region file.\r\nPlease select a different world.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else MessageBox.Show(this, "The select world doesn't have any region folder.\r\nPlease select a different world.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show(this, "The select world path is not valid.\r\nPlease select a different world.", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        //List<string> Lista_Propiedades_Ejemplos = new List<string>(); // For tests.

        /// <summary>
        /// The list with all the possible properties of the blocks in Minecraft 1.13.1, extracted directly from a debug world (see the secrets on the help viewer by pressing F1 to know how to create one), which should've created all the possible values at once. Here the values have been sorted and all include at least one block name that uses every property for a better understanding. This is also very useful to know which properties and what values can be expected, and also for converting between 1.12.2- and 1.13+. But note that maybe not all the blocks that share a common value like "age" might have the same value range between them, so be aware of that.
        /// </summary>
        internal static readonly List<string> Lista_Propiedades_Únicas = new List<string>(new string[]
        {
            "age: 0", // sugar_cane.
            "age: 1", // sugar_cane.
            "age: 2", // fire.
            "age: 3", // sugar_cane.
            "age: 4", // sugar_cane.
            "age: 5", // fire.
            "age: 6", // potatoes.
            "age: 7", // potatoes.
            "age: 8", // fire.
            "age: 9", // sugar_cane.
            "age: 10", // sugar_cane.
            "age: 11", // fire.
            "age: 12", // sugar_cane.
            "age: 13", // fire.
            "age: 14", // fire.
            "age: 15", // cactus.
            "age: 16", // kelp.
            "age: 17", // kelp.
            "age: 18", // kelp.
            "age: 19", // kelp.
            "age: 20", // kelp.
            "age: 21", // kelp.
            "age: 22", // kelp.
            "age: 23", // kelp.
            "age: 24", // kelp.
            "age: 25", // kelp.
            "attached: false", // tripwire.
            "attached: true", // tripwire_hook.
            "axis: x", // stripped_birch_log.
            "axis: y", // stripped_birch_log.
            "axis: z", // stripped_birch_log.
            "bites: 0", // cake.
            "bites: 1", // cake.
            "bites: 2", // cake.
            "bites: 3", // cake.
            "bites: 4", // cake.
            "bites: 5", // cake.
            "bites: 6", // cake.
            "conditional: false", // chain_command_block.
            "conditional: true", // command_block.
            "delay: 1", // repeater.
            "delay: 2", // repeater.
            "delay: 3", // repeater.
            "delay: 4", // repeater.
            "disarmed: false", // tripwire.
            "disarmed: true", // tripwire.
            "distance: 1", // jungle_leaves.
            "distance: 2", // jungle_leaves.
            "distance: 3", // jungle_leaves.
            "distance: 4", // jungle_leaves.
            "distance: 5", // jungle_leaves.
            "distance: 6", // jungle_leaves.
            "distance: 7", // jungle_leaves.
            "down: false", // red_mushroom_block.
            "down: true", // brown_mushroom_block.
            "drag: false", // bubble_column.
            "drag: true", // bubble_column.
            "east: false", // fire.
            "east: none", // redstone_wire.
            "east: side", // redstone_wire.
            "east: true", // fire.
            "east: up", // redstone_wire.
            "eggs: 1", // turtle_egg.
            "eggs: 2", // turtle_egg.
            "eggs: 3", // turtle_egg.
            "eggs: 4", // turtle_egg.
            "enabled: false", // hopper.
            "enabled: true", // hopper.
            "extended: false", // sticky_piston.
            "extended: true", // sticky_piston.
            "eye: false", // end_portal_frame.
            "eye: true", // end_portal_frame.
            "face: ceiling", // jungle_button.
            "face: floor", // oak_button.
            "face: wall", // oak_button.
            "facing: down", // end_rod.
            "facing: east", // lime_bed.
            "facing: north", // white_bed.
            "facing: south", // blue_bed.
            "facing: up", // end_rod.
            "facing: west", // lime_bed.
            "half: bottom", // oak_stairs.
            "half: lower", // iron_door.
            "half: top", // oak_stairs.
            "half: upper", // oak_door.
            "has_bottle_0: false", // brewing_stand.
            "has_bottle_0: true", // brewing_stand.
            "has_bottle_1: false", // brewing_stand.
            "has_bottle_1: true", // brewing_stand.
            "has_bottle_2: false", // brewing_stand.
            "has_bottle_2: true", // brewing_stand.
            "has_record: false", // jukebox.
            "has_record: true", // jukebox.
            "hatch: 0", // turtle_egg.
            "hatch: 1", // turtle_egg.
            "hatch: 2", // turtle_egg.
            "hinge: left", // oak_door.
            "hinge: right", // oak_door.
            "in_wall: false", // jungle_fence_gate.
            "in_wall: true", // jungle_fence_gate.
            "instrument: basedrum", // note_block.
            "instrument: bass", // note_block.
            "instrument: bell", // note_block.
            "instrument: chime", // note_block.
            "instrument: flute", // note_block.
            "instrument: guitar", // note_block.
            "instrument: harp", // note_block.
            "instrument: hat", // note_block.
            "instrument: snare", // note_block.
            "instrument: xylophone", // note_block.
            "inverted: false", // daylight_detector.
            "inverted: true", // daylight_detector.
            "layers: 1", // snow.
            "layers: 2", // snow.
            "layers: 3", // snow.
            "layers: 4", // snow.
            "layers: 5", // snow.
            "layers: 6", // snow.
            "layers: 7", // snow.
            "layers: 8", // snow.
            "level: 0", // water.
            "level: 1", // water.
            "level: 2", // water.
            "level: 3", // water.
            "level: 4", // water.
            "level: 5", // water.
            "level: 6", // water.
            "level: 7", // water.
            "level: 8", // water.
            "level: 9", // water.
            "level: 10", // water.
            "level: 11", // water.
            "level: 12", // water.
            "level: 13", // water.
            "level: 14", // water.
            "level: 15", // water.
            "lit: false", // furnace.
            "lit: true", // furnace.
            "locked: false", // repeater.
            "locked: true", // repeater.
            "mode: compare", // comparator.
            "mode: corner", // structure_block.
            "mode: data", // structure_block.
            "mode: load", // structure_block.
            "mode: save", // structure_block.
            "mode: subtract", // comparator.
            "moisture: 0", // farmland.
            "moisture: 1", // farmland.
            "moisture: 2", // farmland.
            "moisture: 3", // farmland.
            "moisture: 4", // farmland.
            "moisture: 5", // farmland.
            "moisture: 6", // farmland.
            "moisture: 7", // farmland.
            "north: false", // fire.
            "north: none", // redstone_wire.
            "north: side", // redstone_wire.
            "north: true", // fire.
            "north: up", // redstone_wire.
            "note: 0", // note_block.
            "note: 1", // note_block.
            "note: 2", // note_block.
            "note: 3", // note_block.
            "note: 4", // note_block.
            "note: 5", // note_block.
            "note: 6", // note_block.
            "note: 7", // note_block.
            "note: 8", // note_block.
            "note: 9", // note_block.
            "note: 10", // note_block.
            "note: 11", // note_block.
            "note: 12", // note_block.
            "note: 13", // note_block.
            "note: 14", // note_block.
            "note: 15", // note_block.
            "note: 16", // note_block.
            "note: 17", // note_block.
            "note: 18", // note_block.
            "note: 19", // note_block.
            "note: 20", // note_block.
            "note: 21", // note_block.
            "note: 22", // note_block.
            "note: 23", // note_block.
            "note: 24", // note_block.
            "occupied: false", // blue_bed.
            "occupied: true", // lime_bed.
            "open: false", // oak_door.
            "open: true", // iron_door.
            "part: foot", // lime_bed.
            "part: head", // blue_bed.
            "persistent: false", // jungle_leaves.
            "persistent: true", // jungle_leaves.
            "pickles: 1", // sea_pickle.
            "pickles: 2", // sea_pickle.
            "pickles: 3", // sea_pickle.
            "pickles: 4", // sea_pickle.
            "power: 0", // redstone_wire.
            "power: 1", // redstone_wire.
            "power: 2", // redstone_wire.
            "power: 3", // redstone_wire.
            "power: 4", // redstone_wire.
            "power: 5", // redstone_wire.
            "power: 6", // redstone_wire.
            "power: 7", // redstone_wire.
            "power: 8", // redstone_wire.
            "power: 9", // redstone_wire.
            "power: 10", // redstone_wire.
            "power: 11", // redstone_wire.
            "power: 12", // redstone_wire.
            "power: 13", // redstone_wire.
            "power: 14", // redstone_wire.
            "power: 15", // redstone_wire.
            "powered: false", // note_block.
            "powered: true", // note_block.
            "rotation: 0", // sign.
            "rotation: 1", // zombie_head.
            "rotation: 2", // zombie_head.
            "rotation: 3", // sign.
            "rotation: 4", // sign.
            "rotation: 5", // green_banner.
            "rotation: 6", // green_banner.
            "rotation: 7", // green_banner.
            "rotation: 8", // gray_banner.
            "rotation: 9", // gray_banner.
            "rotation: 10", // gray_banner.
            "rotation: 11", // orange_banner.
            "rotation: 12", // orange_banner.
            "rotation: 13", // orange_banner.
            "rotation: 14", // orange_banner.
            "rotation: 15", // wither_skeleton_skull.
            "shape: ascending_east", // detector_rail.
            "shape: ascending_north", // detector_rail.
            "shape: ascending_south", // detector_rail.
            "shape: ascending_west", // detector_rail.
            "shape: east_west", // detector_rail.
            "shape: inner_left", // oak_stairs.
            "shape: inner_right", // oak_stairs.
            "shape: north_east", // rail.
            "shape: north_south", // activator_rail.
            "shape: north_west", // rail.
            "shape: outer_left", // oak_stairs.
            "shape: outer_right", // oak_stairs.
            "shape: south_east", // rail.
            "shape: south_west", // rail.
            "shape: straight", // oak_stairs.
            "short: false", // piston_head.
            "short: true", // piston_head.
            "snowy: false", // grass_block.
            "snowy: true", // grass_block.
            "south: false", // fire.
            "south: none", // redstone_wire.
            "south: side", // redstone_wire.
            "south: true", // fire.
            "south: up", // redstone_wire.
            "stage: 0", // oak_sapling.
            "stage: 1", // oak_sapling.
            "triggered: false", // dropper.
            "triggered: true", // dropper.
            "type: bottom", // purpur_slab.
            "type: double", // red_sandstone_slab.
            "type: left", // trapped_chest.
            "type: normal", // piston_head.
            "type: right", // trapped_chest.
            "type: single", // trapped_chest.
            "type: sticky", // piston_head.
            "type: top", // purpur_slab.
            "unstable: false", // tnt.
            "unstable: true", // tnt.
            "up: false", // fire.
            "up: true", // fire.
            "waterlogged: false", // oak_stairs.
            "waterlogged: true", // oak_stairs.
            "west: false", // fire.
            "west: none", // redstone_wire.
            "west: side", // redstone_wire.
            "west: true", // fire.
            "west: up" // redstone_wire.
        });

        /// <summary>
        /// Converts the new 1.13+ block names to other similar blocks from 1.12.2-. Suggestions are welocme to use better old blocks as replacements.
        /// </summary>
        /// <param name="Nombre">Any valid Minecraft block name, starting with "minecraft:".</param>
        /// <returns>The replaced block name or the original if it was present at 1.12.2-.</returns>
        internal string Reemplazar_Bloques_Minecraft_1_13(string Nombre)
        {
            try
            {
                // Tests with block deletion, this could usually never be done before, so enjoy.
                if (CheckBox_Mundo_Acuático.Checked)
                {
                    if (string.Compare(Nombre, "minecraft:air", true) == 0) Nombre = "minecraft:water";
                }
                if (CheckBox_Eliminar_Agua.Checked) // Update a column of water for a chain reaction! [WARNING]
                {
                    if (string.Compare(Nombre, "minecraft:water", true) == 0) Nombre = "minecraft:air"; // Cool test to dry the oceans, etc.
                }
                if (CheckBox_Eliminar_Lava.Checked)
                {
                    if (string.Compare(Nombre, "minecraft:lava", true) == 0) Nombre = "minecraft:air";
                }
                if (CheckBox_Eliminar_Piedras.Checked)
                {
                    if (string.Compare(Nombre, "minecraft:stone", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:cobblestone", true) == 0) Nombre = "minecraft:air"; // Should this be deleted?
                    if (string.Compare(Nombre, "minecraft:mossy_cobblestone", true) == 0) Nombre = "minecraft:air"; // Should this be deleted?
                    if (string.Compare(Nombre, "minecraft:andesite", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:diorite", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:granite", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:sandstone", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:red_sandstone", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:prismarine", true) == 0) Nombre = "minecraft:air"; // Should this be deleted?
                    //if (string.Compare(Nombre, "", true) == 0) Nombre = "minecraft:air"; // Add more blocks here?
                }
                if (CheckBox_Eliminar_Tierra.Checked)
                {
                    if (string.Compare(Nombre, "minecraft:dirt", true) == 0) Nombre = "minecraft:air";
                }
                if (CheckBox_Eliminar_Netherrack.Checked)
                {
                    if (string.Compare(Nombre, "minecraft:netherrack", true) == 0) Nombre = "minecraft:air";
                }
                if (CheckBox_Eliminar_End_Stone.Checked)
                {
                    if (string.Compare(Nombre, "minecraft:end_stone", true) == 0) Nombre = "minecraft:air";
                }
                if (CheckBox_Eliminar_Lecho_Roca.Checked)
                {
                    if (string.Compare(Nombre, "minecraft:bedrock", true) == 0) Nombre = "minecraft:air";
                }
                if (CheckBox_Eliminar_Minerales.Checked)
                {
                    if (string.Compare(Nombre, "minecraft:coal_ore", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:diamond_ore", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:emerald_ore", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:gold_ore", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:iron_ore", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:lapis_ore", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:nether_quartz_ore", true) == 0) Nombre = "minecraft:air";
                    if (string.Compare(Nombre, "minecraft:redstone_ore", true) == 0) Nombre = "minecraft:air";
                }
                if (CheckBox_Intercambiar_Agua_Lava.Checked)
                {
                    if (string.Compare(Nombre, "minecraft:water", true) == 0) Nombre = "minecraft:lava";
                    if (string.Compare(Nombre, "minecraft:flowing_water", true) == 0) Nombre = "minecraft:flowing_lava";
                }
                if (CheckBox_Intercambiar_Lava_Agua.Checked) // Try this on the Nether and swim in water!
                {
                    if (string.Compare(Nombre, "minecraft:lava", true) == 0) Nombre = "minecraft:water";
                    if (string.Compare(Nombre, "minecraft:flowing_lava", true) == 0) Nombre = "minecraft:flowing_water";
                }

                // The proper block replacement from 1.13+ to 1.12.2-, but replacements could be better.
                //if (string.Compare(Nombre, "minecraft:acacia_bark", true) == 0) Nombre = "minecraft:acacia_log";
                if (string.Compare(Nombre, "minecraft:acacia_button", true) == 0) Nombre = "minecraft:oak_button";
                else if (string.Compare(Nombre, "minecraft:acacia_pressure_plate", true) == 0) Nombre = "minecraft:oak_pressure_plate";
                else if (string.Compare(Nombre, "minecraft:acacia_trapdoor", true) == 0) Nombre = "minecraft:oak_trapdoor";
                else if (string.Compare(Nombre, "minecraft:attached_melon_stem", true) == 0) Nombre = "minecraft:melon_stem";
                else if (string.Compare(Nombre, "minecraft:attached_pumpkin_stem", true) == 0) Nombre = "minecraft:pumpkin_stem";
                else if (string.Compare(Nombre, "minecraft:banner", true) == 0) Nombre = "minecraft:white_banner";
                else if (string.Compare(Nombre, "minecraft:bed", true) == 0) Nombre = "minecraft:red_bed";
                //else if (string.Compare(Nombre, "minecraft:birch_bark", true) == 0) Nombre = "minecraft:birch_log";
                else if (string.Compare(Nombre, "minecraft:birch_button", true) == 0) Nombre = "minecraft:oak_button";
                else if (string.Compare(Nombre, "minecraft:birch_pressure_plate", true) == 0) Nombre = "minecraft:oak_pressure_plate";
                else if (string.Compare(Nombre, "minecraft:birch_trapdoor", true) == 0) Nombre = "minecraft:oak_trapdoor";
                else if (string.Compare(Nombre, "minecraft:black_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:blue_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:blue_coral", true) == 0) Nombre = "minecraft:blue_concrete";
                else if (string.Compare(Nombre, "minecraft:blue_coral_fan", true) == 0) Nombre = "minecraft:blue_concrete";
                else if (string.Compare(Nombre, "minecraft:blue_coral_plant", true) == 0) Nombre = "minecraft:blue_concrete";
                else if (string.Compare(Nombre, "minecraft:blue_dead_coral", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:blue_ice", true) == 0) Nombre = "minecraft:light_blue_concrete"; // minecraft:packed_ice
                else if (string.Compare(Nombre, "minecraft:brain_coral", true) == 0) Nombre = "minecraft:pink_concrete";
                else if (string.Compare(Nombre, "minecraft:brain_coral_block", true) == 0) Nombre = "minecraft:pink_concrete";
                else if (string.Compare(Nombre, "minecraft:brain_coral_fan", true) == 0) Nombre = "minecraft:pink_concrete";
                else if (string.Compare(Nombre, "minecraft:brain_coral_wall_fan", true) == 0) Nombre = "minecraft:pink_concrete";
                else if (string.Compare(Nombre, "minecraft:brown_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:bubble_column", true) == 0) Nombre = "minecraft:water";
                else if (string.Compare(Nombre, "minecraft:bubble_coral", true) == 0) Nombre = "minecraft:purple_concrete";
                else if (string.Compare(Nombre, "minecraft:bubble_coral_block", true) == 0) Nombre = "minecraft:purple_concrete";
                else if (string.Compare(Nombre, "minecraft:bubble_coral_fan", true) == 0) Nombre = "minecraft:purple_concrete";
                else if (string.Compare(Nombre, "minecraft:bubble_coral_wall_fan", true) == 0) Nombre = "minecraft:purple_concrete";
                else if (string.Compare(Nombre, "minecraft:cave_air", true) == 0) Nombre = "minecraft:air";
                else if (string.Compare(Nombre, "minecraft:conduit", true) == 0) Nombre = "minecraft:beacon";
                //else if (string.Compare(Nombre, "minecraft:creeper_wall_head", true) == 0) Nombre = "minecraft:creeper_head";
                else if (string.Compare(Nombre, "minecraft:cyan_bed", true) == 0) Nombre = "minecraft:red_bed";
                //else if (string.Compare(Nombre, "minecraft:dark_oak_bark", true) == 0) Nombre = "minecraft:dark_oak_log";
                else if (string.Compare(Nombre, "minecraft:dark_oak_button", true) == 0) Nombre = "minecraft:oak_button";
                else if (string.Compare(Nombre, "minecraft:dark_oak_pressure_plate", true) == 0) Nombre = "minecraft:oak_pressure_plate";
                else if (string.Compare(Nombre, "minecraft:dark_oak_trapdoor", true) == 0) Nombre = "minecraft:oak_trapdoor";
                else if (string.Compare(Nombre, "minecraft:dark_prismarine_slab", true) == 0) Nombre = "minecraft:dark_oak_slab";
                else if (string.Compare(Nombre, "minecraft:dark_prismarine_stairs", true) == 0) Nombre = "minecraft:dark_oak_stairs";
                else if (string.Compare(Nombre, "minecraft:dead_brain_coral", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_brain_coral_block", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_brain_coral_fan", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_brain_coral_wall_fan", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_bubble_coral", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_bubble_coral_block", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_bubble_coral_fan", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_bubble_coral_wall_fan", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_fire_coral", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_fire_coral_block", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_fire_coral_fan", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_fire_coral_wall_fan", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_horn_coral", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_horn_coral_block", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_horn_coral_fan", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_horn_coral_wall_fan", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_tube_coral", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_tube_coral_block", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_tube_coral_fan", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:dead_tube_coral_wall_fan", true) == 0) Nombre = "minecraft:light_gray_concrete";
                //else if (string.Compare(Nombre, "minecraft:dragon_wall_head", true) == 0) Nombre = "minecraft:dragon_head";
                else if (string.Compare(Nombre, "minecraft:dried_kelp_block", true) == 0) Nombre = "minecraft:green_concrete";
                else if (string.Compare(Nombre, "minecraft:fire_coral", true) == 0) Nombre = "minecraft:red_concrete";
                else if (string.Compare(Nombre, "minecraft:fire_coral_block", true) == 0) Nombre = "minecraft:red_concrete";
                else if (string.Compare(Nombre, "minecraft:fire_coral_fan", true) == 0) Nombre = "minecraft:red_concrete";
                else if (string.Compare(Nombre, "minecraft:fire_coral_wall_fan", true) == 0) Nombre = "minecraft:red_concrete";
                else if (string.Compare(Nombre, "minecraft:four_turtle_eggs", true) == 0) Nombre = "minecraft:white_concrete";
                else if (string.Compare(Nombre, "minecraft:gray_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:green_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:horn_coral", true) == 0) Nombre = "minecraft:yellow_concrete";
                else if (string.Compare(Nombre, "minecraft:horn_coral_block", true) == 0) Nombre = "minecraft:yellow_concrete";
                else if (string.Compare(Nombre, "minecraft:horn_coral_fan", true) == 0) Nombre = "minecraft:yellow_concrete";
                else if (string.Compare(Nombre, "minecraft:horn_coral_wall_fan", true) == 0) Nombre = "minecraft:yellow_concrete";
                else if (string.Compare(Nombre, "minecraft:item_frame", true) == 0) Nombre = "minecraft:wall_sign";
                //else if (string.Compare(Nombre, "minecraft:jungle_bark", true) == 0) Nombre = "minecraft:jungle_log";
                else if (string.Compare(Nombre, "minecraft:jungle_button", true) == 0) Nombre = "minecraft:oak_button";
                else if (string.Compare(Nombre, "minecraft:jungle_pressure_plate", true) == 0) Nombre = "minecraft:oak_pressure_plate";
                else if (string.Compare(Nombre, "minecraft:jungle_trapdoor", true) == 0) Nombre = "minecraft:oak_trapdoor";
                else if (string.Compare(Nombre, "minecraft:kelp", true) == 0) Nombre = "minecraft:water"; // air
                else if (string.Compare(Nombre, "minecraft:kelp_plant", true) == 0) Nombre = "minecraft:water"; // air
                else if (string.Compare(Nombre, "minecraft:kelp_top", true) == 0) Nombre = "minecraft:water"; // air
                else if (string.Compare(Nombre, "minecraft:light_blue_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:light_gray_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:lime_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:magenta_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:mob_spawner", true) == 0) Nombre = "minecraft:spawner";
                //else if (string.Compare(Nombre, "minecraft:mushroom_stem", true) == 0) Nombre = "minecraft:brown_mushroom_block";
                //else if (string.Compare(Nombre, "minecraft:oak_bark", true) == 0) Nombre = "minecraft:oak_log";
                else if (string.Compare(Nombre, "minecraft:orange_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:pink_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:pink_coral", true) == 0) Nombre = "minecraft:pink_concrete";
                else if (string.Compare(Nombre, "minecraft:pink_coral_fan", true) == 0) Nombre = "minecraft:pink_concrete";
                else if (string.Compare(Nombre, "minecraft:pink_coral_plant", true) == 0) Nombre = "minecraft:pink_concrete";
                else if (string.Compare(Nombre, "minecraft:pink_dead_coral", true) == 0) Nombre = "minecraft:light_gray_concrete";
                //else if (string.Compare(Nombre, "minecraft:player_wall_head", true) == 0) Nombre = "minecraft:player_head";
                else if (string.Compare(Nombre, "minecraft:portal", true) == 0) Nombre = "minecraft:nether_portal";
                else if (string.Compare(Nombre, "minecraft:prismarine_brick_slab", true) == 0) Nombre = "minecraft:stone_brick_slab";
                else if (string.Compare(Nombre, "minecraft:prismarine_brick_stairs", true) == 0) Nombre = "minecraft:stone_brick_stairs";
                else if (string.Compare(Nombre, "minecraft:prismarine_bricks_slab", true) == 0) Nombre = "minecraft:stone_brick_slab";
                else if (string.Compare(Nombre, "minecraft:prismarine_bricks_stairs", true) == 0) Nombre = "minecraft:stone_brick_stairs";
                else if (string.Compare(Nombre, "minecraft:prismarine_slab", true) == 0) Nombre = "minecraft:cobblestone_slab";
                else if (string.Compare(Nombre, "minecraft:prismarine_stairs", true) == 0) Nombre = "minecraft:cobblestone_stairs";
                //else if (string.Compare(Nombre, "minecraft:pumpkin", true) == 0) Nombre = "minecraft:carved_pumpkin";
                else if (string.Compare(Nombre, "minecraft:purple_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:purple_coral", true) == 0) Nombre = "minecraft:purple_concrete";
                else if (string.Compare(Nombre, "minecraft:purple_coral_fan", true) == 0) Nombre = "minecraft:purple_concrete";
                else if (string.Compare(Nombre, "minecraft:purple_coral_plant", true) == 0) Nombre = "minecraft:purple_concrete";
                else if (string.Compare(Nombre, "minecraft:purple_dead_coral", true) == 0) Nombre = "minecraft:light_gray_concrete";
                else if (string.Compare(Nombre, "minecraft:red_coral", true) == 0) Nombre = "minecraft:red_concrete";
                else if (string.Compare(Nombre, "minecraft:red_coral_fan", true) == 0) Nombre = "minecraft:red_concrete";
                else if (string.Compare(Nombre, "minecraft:red_coral_plant", true) == 0) Nombre = "minecraft:red_concrete";
                else if (string.Compare(Nombre, "minecraft:red_dead_coral", true) == 0) Nombre = "minecraft:light_gray_concrete";
                //else if (string.Compare(Nombre, "minecraft:redstone_wall_torch", true) == 0) Nombre = "minecraft:redstone_torch";
                else if (string.Compare(Nombre, "minecraft:sea_grass", true) == 0) Nombre = "minecraft:water"; // air
                else if (string.Compare(Nombre, "minecraft:sea_pickle", true) == 0) Nombre = "minecraft:sea_lantern";
                else if (string.Compare(Nombre, "minecraft:seagrass", true) == 0) Nombre = "minecraft:water"; // air
                else if (string.Compare(Nombre, "minecraft:shulker_box", true) == 0) Nombre = "minecraft:purple_shulker_box";
                //else if (string.Compare(Nombre, "minecraft:skeleton_wall_skull", true) == 0) Nombre = "minecraft:skeleton_skull";
                //else if (string.Compare(Nombre, "minecraft:spruce_bark", true) == 0) Nombre = "minecraft:spruce_log";
                else if (string.Compare(Nombre, "minecraft:spruce_button", true) == 0) Nombre = "minecraft:oak_button";
                else if (string.Compare(Nombre, "minecraft:spruce_pressure_plate", true) == 0) Nombre = "minecraft:oak_pressure_plate";
                else if (string.Compare(Nombre, "minecraft:spruce_trapdoor", true) == 0) Nombre = "minecraft:oak_trapdoor";
                else if (string.Compare(Nombre, "minecraft:stripped_acacia_log", true) == 0) Nombre = "minecraft:acacia_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_acacia_wood", true) == 0) Nombre = "minecraft:acacia_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_birch_log", true) == 0) Nombre = "minecraft:birch_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_birch_wood", true) == 0) Nombre = "minecraft:birch_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_dark_oak_log", true) == 0) Nombre = "minecraft:dark_oak_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_dark_oak_wood", true) == 0) Nombre = "minecraft:dark_oak_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_jungle_log", true) == 0) Nombre = "minecraft:jungle_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_jungle_wood", true) == 0) Nombre = "minecraft:jungle_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_oak_log", true) == 0) Nombre = "minecraft:oak_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_oak_wood", true) == 0) Nombre = "minecraft:oak_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_spruce_log", true) == 0) Nombre = "minecraft:spruce_planks";
                else if (string.Compare(Nombre, "minecraft:stripped_spruce_wood", true) == 0) Nombre = "minecraft:spruce_planks";
                else if (string.Compare(Nombre, "minecraft:tall_sea_grass", true) == 0) Nombre = "minecraft:water"; // air
                else if (string.Compare(Nombre, "minecraft:tall_seagrass", true) == 0) Nombre = "minecraft:water"; // air
                else if (string.Compare(Nombre, "minecraft:three_turtle_eggs", true) == 0) Nombre = "minecraft:white_concrete";
                else if (string.Compare(Nombre, "minecraft:tube_coral", true) == 0) Nombre = "minecraft:blue_concrete";
                else if (string.Compare(Nombre, "minecraft:tube_coral_block", true) == 0) Nombre = "minecraft:blue_concrete";
                else if (string.Compare(Nombre, "minecraft:tube_coral_fan", true) == 0) Nombre = "minecraft:blue_concrete";
                else if (string.Compare(Nombre, "minecraft:tube_coral_wall_fan", true) == 0) Nombre = "minecraft:blue_concrete";
                else if (string.Compare(Nombre, "minecraft:turtle_egg", true) == 0) Nombre = "minecraft:white_concrete";
                else if (string.Compare(Nombre, "minecraft:two_turtle_eggs", true) == 0) Nombre = "minecraft:white_concrete";
                else if (string.Compare(Nombre, "minecraft:void_air", true) == 0) Nombre = "minecraft:air";
                else if (string.Compare(Nombre, "minecraft:wall_banner", true) == 0) Nombre = "minecraft:white_banner";
                //else if (string.Compare(Nombre, "minecraft:wall_sign", true) == 0) Nombre = "minecraft:sign";
                //else if (string.Compare(Nombre, "minecraft:wall_torch", true) == 0) Nombre = "minecraft:torch";
                else if (string.Compare(Nombre, "minecraft:white_bed", true) == 0) Nombre = "minecraft:red_bed";
                //else if (string.Compare(Nombre, "minecraft:wither_skeleton_wall_skull", true) == 0) Nombre = "minecraft:wither_skeleton_skull";
                else if (string.Compare(Nombre, "minecraft:yellow_bed", true) == 0) Nombre = "minecraft:red_bed";
                else if (string.Compare(Nombre, "minecraft:yellow_coral", true) == 0) Nombre = "minecraft:yellow_concrete";
                else if (string.Compare(Nombre, "minecraft:yellow_coral_fan", true) == 0) Nombre = "minecraft:yellow_concrete";
                else if (string.Compare(Nombre, "minecraft:yellow_coral_plant", true) == 0) Nombre = "minecraft:yellow_concrete";
                else if (string.Compare(Nombre, "minecraft:yellow_dead_coral", true) == 0) Nombre = "minecraft:light_gray_concrete";
                //else if (string.Compare(Nombre, "minecraft:zombie_wall_head", true) == 0) Nombre = "minecraft:zombie_head";
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            return Nombre;
        }

        internal SortedDictionary<string, object> Diccionario_Bloques_Desconocidos = new SortedDictionary<string, object>();
        internal string Bloques_Desconocidos = null;

        /// <summary>
        /// Obtains an ID and Data value for Minecraft 1.12.2- based on a Minecraft 1.13+ block name and it's list of properties (which is optional and basically used to properly rotate the blocks, etc).
        /// </summary>
        /// <param name="Nombre_1_13">A valid Minecraft 1.13+ block name, which should start with "minecraft:".</param>
        /// <param name="Lista_Propiedades">A list of strings that define block properties in NBT format. It can null or empty, which will result in a default Data value.</param>
        /// <param name="Data">A value between 0 and 15 defining the metadata value of a block, like it's rotation.</param>
        /// <returns>Returns the Minecraft 1.12.2- block ID, between 0 and 255, also returns a Data value, between 0 and 15. So combining those 2 values gives a value between 0 and 4.095, or with 12 bits.</returns>
        internal byte Obtener_ID_Data_Minecraft_1_12_2(string Nombre_1_13, List<string> Lista_Propiedades, out string Nombre_1_12_2, out byte Data)
        {
            Nombre_1_12_2 = Nombre_1_13;
            Data = 0; // Default block state (ranges from 0 to 15).
            try
            {
                byte ID = 0; // Defaults to an Air block.

                // First replace the 1.13+ missing blocks on 1.12.2- with relatively similar blocks.
                Nombre_1_12_2 = Reemplazar_Bloques_Minecraft_1_13(Nombre_1_13);

                // Now convert the adapted 1.13+ Minecraft name to an internal index of this program.
                if (!Minecraft.Bloques.Diccionario_Nombre_Índice.ContainsKey(Nombre_1_12_2))
                {
                    if (!Diccionario_Bloques_Desconocidos.ContainsKey(Nombre_1_12_2)) Diccionario_Bloques_Desconocidos.Add(Nombre_1_12_2, null);
                    //MessageBox.Show(Nombre_1_12_2, "Block unknown?");
                }
                short ID_Minecraft_1_13 = Minecraft.Bloques.Diccionario_Nombre_Índice[Nombre_1_12_2];

                // Then search if that index can be converted to 1.12.2- ID and Data values.
                foreach (KeyValuePair<short, short> Entrada in Minecraft.Diccionario_Bloques_Índices_1_12_2_a_Índices_1_13)
                {
                    if (Entrada.Value == ID_Minecraft_1_13)
                    {
                        ID = Minecraft.Obtener_Valores_ID_Data(Entrada.Key, out Data);
                        //if (ID != 43 && ID != 44 && ID != 125 && ID != 126 && ID != 181 && ID != 182) // Ignore all the slabs.
                        {
                            break;
                        }
                    }
                }

                //if (Lista_Propiedades != null && Lista_Propiedades.Count > 0) // Always check it.
                {
                    // Finally adapt the Data value with it's found properties, so it can rotated, etc.
                    ID = Obtener_ID_Data_Bloque_Ajustados(Nombre_1_12_2, Lista_Propiedades, ID, Data, out Data);
                }

                return ID; //Return the ID and Data values generated after being fully adapted.

                // If we are here, something went wrong and Air will replace a full type of block.
                // So if you expected a block and see Air, the conversion might have failed in here.
            }
            catch (Exception Excepción)
            {
                Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null);
                Data = 0; // On any error, try the Data 0, which will work on most cases.
            }
            //MessageBox.Show("????");
            return 0; // Return 0 or Air block, if not found, which also needs a Data value of 0.
        }

        /// <summary>
        /// Searches for a property value inside the list of properties, also ignoring the case of the letters.
        /// </summary>
        /// <param name="Propiedad">A text string with the property to search for.</param>
        /// <param name="Lista_Propiedades">A list with the NBT properties of a Minecraft 1.13+ block in the form of text strings.</param>
        /// <returns>Returns true if the list contains the selected property. Returns false toherwise.</returns>
        internal bool Buscar_Propiedad(string Propiedad, List<string> Lista_Propiedades)
        {
            try
            {
                //if (Lista_Propiedades != null && Lista_Propiedades.Count > 0) // Checked before.
                {
                    foreach (string Texto_Propiedad in Lista_Propiedades)
                    {
                        if (string.Compare(Texto_Propiedad, Propiedad, true) == 0)
                        {
                            return true; // Found the wanted property.
                        }
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
            return false; // Wanted property not found.
        }

        /// <summary>
        /// Obtains a custom Data value for 1.12.2- based on the list of properties of a block. The page "Java Edition data values" on the official Minecraft wiki was key to help to program it correctly, so please check it out also if you're interested in this topic.
        /// </summary>
        /// <param name="Nombre">A valid Minecraft 1.13+ block name.</param>
        /// <param name="Lista_Propiedades">A list with the NBT properties of a block. It can be null or empty, which will give a default Data value.</param>
        /// <param name="Data">A value between 0 and 15. It's default is 0.</param>
        /// <returns>Returns an adapted Data value between 0 and 15. If it doesn't need to be adapted it will return the original Data value passed.</returns>
        internal byte Obtener_ID_Data_Bloque_Ajustados(string Nombre, List<string> Lista_Propiedades, byte ID_Original, byte Data_Original, out byte Data)
        {
            Data = Data_Original; // Default of the original Data value passed.
            try
            {
                if (Lista_Propiedades == null) Lista_Propiedades = new List<string>(); // This can be empty, but never null.
                byte ID = ID_Original; // Default of the original ID value passed.

                // Change some IDs based on the properties, since my program ignores
                // for example if a repeater is on or off, because on it's name that
                // value never appears, so now analyze it's properties to find it out
                // and properly convert the blocks and in some cases it's ID values.
                if (string.Compare(Nombre, "minecraft:oak_log", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stripped_oak_log", true) == 0)
                {
                    if (Buscar_Propiedad("axis: x", Lista_Propiedades)) Data = 4; // Facing East/West.
                    else if (Buscar_Propiedad("axis: y", Lista_Propiedades)) Data = 0; // Facing Up/Down.
                    else if (Buscar_Propiedad("axis: z", Lista_Propiedades)) Data = 8; // Facing North/South.
                    //Data_255 |= 0; // Oak Wood.
                }
                if (string.Compare(Nombre, "minecraft:oak_log", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stripped_oak_log", true) == 0)
                {
                    if (Buscar_Propiedad("axis: x", Lista_Propiedades)) Data = 4; // Facing East/West.
                    else if (Buscar_Propiedad("axis: y", Lista_Propiedades)) Data = 0; // Facing Up/Down.
                    else if (Buscar_Propiedad("axis: z", Lista_Propiedades)) Data = 8; // Facing North/South.
                    //Data_255 |= 0; // Oak Wood.
                }
                else if (string.Compare(Nombre, "minecraft:oak_wood", true) == 0 ||
                    string.Compare(Nombre, "minecraft:oak_bark", true) == 0)
                {
                    Data = 12; // Only bark.
                    //Data_255 |= 0; // Oak Wood.
                }
                else if (string.Compare(Nombre, "minecraft:spruce_log", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stripped_spruce_log", true) == 0)
                {
                    if (Buscar_Propiedad("axis: x", Lista_Propiedades)) Data = 4; // Facing East/West.
                    else if (Buscar_Propiedad("axis: y", Lista_Propiedades)) Data = 0; // Facing Up/Down.
                    else if (Buscar_Propiedad("axis: z", Lista_Propiedades)) Data = 8; // Facing North/South.
                    Data |= 1; // Spruce Wood.
                }
                else if (string.Compare(Nombre, "minecraft:spruce_wood", true) == 0 ||
                    string.Compare(Nombre, "minecraft:spruce_bark", true) == 0)
                {
                    Data = 12; // Only bark.
                    Data |= 1; // Spruce Wood.
                }
                else if (string.Compare(Nombre, "minecraft:birch_log", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stripped_birch_log", true) == 0)
                {
                    if (Buscar_Propiedad("axis: x", Lista_Propiedades)) Data = 4; // Facing East/West.
                    else if (Buscar_Propiedad("axis: y", Lista_Propiedades)) Data = 0; // Facing Up/Down.
                    else if (Buscar_Propiedad("axis: z", Lista_Propiedades)) Data = 8; // Facing North/South.
                    Data |= 2; // Birch Wood.
                }
                else if (string.Compare(Nombre, "minecraft:birch_wood", true) == 0 ||
                    string.Compare(Nombre, "minecraft:birch_bark", true) == 0)
                {
                    Data = 12; // Only bark.
                    Data |= 2; // Birch Wood.
                }
                else if (string.Compare(Nombre, "minecraft:jungle_log", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stripped_jungle_log", true) == 0)
                {
                    if (Buscar_Propiedad("axis: x", Lista_Propiedades)) Data = 4; // Facing East/West.
                    else if (Buscar_Propiedad("axis: y", Lista_Propiedades)) Data = 0; // Facing Up/Down.
                    else if (Buscar_Propiedad("axis: z", Lista_Propiedades)) Data = 8; // Facing North/South.
                    Data |= 3; // Jungle Wood.
                }
                else if (string.Compare(Nombre, "minecraft:jungle_wood", true) == 0 ||
                    string.Compare(Nombre, "minecraft:jungle_bark", true) == 0)
                {
                    Data = 12; // Only bark.
                    Data |= 3; // Jungle Wood.
                }
                else if (string.Compare(Nombre, "minecraft:acacia_log", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stripped_acacia_log", true) == 0)
                {
                    if (Buscar_Propiedad("axis: x", Lista_Propiedades)) Data = 4; // Facing East/West.
                    else if (Buscar_Propiedad("axis: y", Lista_Propiedades)) Data = 0; // Facing Up/Down.
                    else if (Buscar_Propiedad("axis: z", Lista_Propiedades)) Data = 8; // Facing North/South.
                    Data |= 1; // Acacia Wood.
                }
                else if (string.Compare(Nombre, "minecraft:acacia_wood", true) == 0 ||
                    string.Compare(Nombre, "minecraft:acacia_bark", true) == 0)
                {
                    Data = 12; // Only bark.
                               //Data_255 |= 0; // Acacia Wood.
                }
                else if (string.Compare(Nombre, "minecraft:dark_oak_log", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stripped_dark_oak_log", true) == 0)
                {
                    if (Buscar_Propiedad("axis: x", Lista_Propiedades)) Data = 4; // Facing East/West.
                    else if (Buscar_Propiedad("axis: y", Lista_Propiedades)) Data = 0; // Facing Up/Down.
                    else if (Buscar_Propiedad("axis: z", Lista_Propiedades)) Data = 8; // Facing North/South.
                    Data |= 1; // Dark Oak Wood.
                }
                else if (string.Compare(Nombre, "minecraft:dark_oak_wood", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dark_oak_bark", true) == 0)
                {
                    Data = 12; // Only bark.
                    Data |= 1; // Dark Oak Wood.
                }
                else if (string.Compare(Nombre, "minecraft:oak_leaves", true) == 0)
                {
                    if (Buscar_Propiedad("persistent: true", Lista_Propiedades)) Data = 12; // Oak Leaves (no decay and check decay).
                    else Data = 0; // Oak Leaves.
                }
                else if (string.Compare(Nombre, "", true) == 0)
                {
                    if (Buscar_Propiedad("persistent: true", Lista_Propiedades)) Data = 13; // Spruce Leaves (no decay and check decay).
                    else Data = 1; // Spruce Leaves.
                }
                else if (string.Compare(Nombre, "", true) == 0)
                {
                    if (Buscar_Propiedad("persistent: true", Lista_Propiedades)) Data = 14; // Birch Leaves (no decay and check decay).
                    else Data = 2; // Birch Leaves.
                }
                else if (string.Compare(Nombre, "", true) == 0)
                {
                    if (Buscar_Propiedad("persistent: true", Lista_Propiedades)) Data = 15; // Jungle Leaves (no decay and check decay).
                    else Data = 3; // Jungle Leaves.
                }
                else if (string.Compare(Nombre, "", true) == 0)
                {
                    if (Buscar_Propiedad("persistent: true", Lista_Propiedades)) Data = 12; // Acacia Leaves (no decay and check decay).
                    else Data = 0; // Acacia Leaves.
                }
                else if (string.Compare(Nombre, "", true) == 0)
                {
                    if (Buscar_Propiedad("persistent: true", Lista_Propiedades)) Data = 13; // Dark Oak Leaves (no decay and check decay).
                    else Data = 1; // Dark Oak Leaves.
                }
                else if (string.Compare(Nombre, "minecraft:torch", true) == 0 ||
                    string.Compare(Nombre, "minecraft:wall_torch", true) == 0)
                {
                    if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 1; // Facing east (attached to a block to its west).
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 2; // Facing west (attached to a block to its east).
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // Facing south (attached to a block to its north).
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 4; // Facing north (attached to a block to its south).
                    else Data = 5; // Facing up (attached to a block beneath it).
                }
                else if (string.Compare(Nombre, "minecraft:redstone_torch", true) == 0 ||
                    string.Compare(Nombre, "minecraft:redstone_wall_torch", true) == 0)
                {
                    if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 1; // Facing east (attached to a block to its west).
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 2; // Facing west (attached to a block to its east).
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // Facing south (attached to a block to its north).
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 4; // Facing north (attached to a block to its south).
                    else Data = 5; // Facing up (attached to a block beneath it).

                    if (Buscar_Propiedad("lit: true", Lista_Propiedades)) ID = 76; // Lit.
                }


                // ...


                else if (string.Compare(Nombre, "minecraft:stone_slab", true) == 0 ||
                    string.Compare(Nombre, "minecraft:sandstone_slab", true) == 0 ||
                    string.Compare(Nombre, "minecraft:petrified_oak_slab", true) == 0 ||
                    string.Compare(Nombre, "minecraft:cobblestone_slab", true) == 0 ||
                    string.Compare(Nombre, "minecraft:brick_slab", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stone_brick_slab", true) == 0 ||
                    string.Compare(Nombre, "minecraft:quartz_slab", true) == 0 ||
                    string.Compare(Nombre, "minecraft:nether_brick_slab", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0)
                {
                    if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                }

                else if (string.Compare(Nombre, "minecraft:red_bed", true) == 0) // Can't extract the bed color.
                {
                    if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 0; // Head facing South.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // Head facing West.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Head facing North.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 3; // Head facing East.

                    if (Buscar_Propiedad("occupied: true", Lista_Propiedades)) Data |= 4; // The bed is occupied.

                    if (Buscar_Propiedad("part: head", Lista_Propiedades)) Data |= 8; // The head of the bed.
                }
                else if (string.Compare(Nombre, "minecraft:sunflower", true) == 0 ||
                    string.Compare(Nombre, "minecraft:lilac", true) == 0 ||
                    string.Compare(Nombre, "minecraft:tall_grass", true) == 0 ||
                    string.Compare(Nombre, "minecraft:large_fern", true) == 0 ||
                    string.Compare(Nombre, "minecraft:rose_bush", true) == 0 ||
                    string.Compare(Nombre, "minecraft:peony", true) == 0)
                {
                    if (Buscar_Propiedad("half: upper", Lista_Propiedades)) Data = 8; // Top Half of any Large Plant; low three bits 0x7 are derived from the block below.
                }
                else if (string.Compare(Nombre, "minecraft:piston", true) == 0 ||
                    string.Compare(Nombre, "minecraft:sticky_piston", true) == 0 ||
                    string.Compare(Nombre, "minecraft:piston_head", true) == 0)
                {
                    if (Buscar_Propiedad("facing: down", Lista_Propiedades)) Data = 0; // Down.
                    else if (Buscar_Propiedad("facing: up", Lista_Propiedades)) Data = 1; // Up.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // north.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 4; // west.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 5; // east.

                    if (Buscar_Propiedad("extended: true", Lista_Propiedades)) Data |= 8; // 1 for pushed out.
                }
                else if (string.Compare(Nombre, "minecraft:piston_head", true) == 0)
                {
                    // What is the "short: true" property in the piston heads?...
                    // Here will be ignored until I find what it is, so please tell me.

                    if (Buscar_Propiedad("facing: down", Lista_Propiedades)) Data = 0; // Down.
                    else if (Buscar_Propiedad("facing: up", Lista_Propiedades)) Data = 1; // Up.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // north.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 4; // west.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 5; // east.

                    if (Buscar_Propiedad("type: sticky", Lista_Propiedades)) Data |= 8; // 1 is sticky.
                }
                else if (string.Compare(Nombre, "minecraft:acacia_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:birch_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:brick_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:cobblestone_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dark_oak_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dark_prismarine_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:jungle_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:nether_brick_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:oak_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:prismarine_bricks_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:prismarine_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:purpur_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:quartz_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:red_sandstone_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:sandstone_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:spruce_stairs", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stone_brick_stairs", true) == 0)
                {
                    //if (Buscar_Propiedad("shape: straight", Lista_Propiedades)) // Not in a corner.
                    {
                        if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 0; // East.
                        else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // West.
                        else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 2; // South.
                        else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 3; // North.
                    }
                    // This needs to be finished...
                    /*else if (Buscar_Propiedad("shape: inner_left", Lista_Propiedades)) // Corner.
                    {
                        if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data_255 = 0; // East.
                        else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data_255 = 1; // West.
                        else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data_255 = 2 | 0; // South.
                        else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data_255 = 3; // North.
                    }
                    else if (Buscar_Propiedad("shape: inner_right", Lista_Propiedades)) // Corner.
                    {
                        if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data_255 = 0; // East.
                        else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data_255 = 1; // West.
                        else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data_255 = 2 | 1; // South.
                        else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data_255 = 3; // North.
                    }
                    else if (Buscar_Propiedad("shape: outer_left", Lista_Propiedades)) // Corner.
                    {
                        if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data_255 = 0; // East.
                        else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data_255 = 1; // West.
                        else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data_255 = 2; // South.
                        else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data_255 = 3; // North.
                    }
                    else if (Buscar_Propiedad("shape: outer_right", Lista_Propiedades)) // Corner.
                    {
                        if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data_255 = 0; // East.
                        else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data_255 = 1; // West.
                        else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data_255 = 2; // South.
                        else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data_255 = 3; // North.
                    }*/

                    if (Buscar_Propiedad("half: top", Lista_Propiedades)) Data |= 4; // Set if stairs are upside-down.
                }
                else if (string.Compare(Nombre, "minecraft:redstone_wire", true) == 0 ||
                    string.Compare(Nombre, "minecraft:light_weighted_pressure_plate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:heavy_weighted_pressure_plate", true) == 0)
                {
                    if (Buscar_Propiedad("power: 0", Lista_Propiedades)) Data = 0; // Power 0.
                    else if (Buscar_Propiedad("power: 1", Lista_Propiedades)) Data = 1; // Power 1.
                    else if (Buscar_Propiedad("power: 2", Lista_Propiedades)) Data = 2; // Power 2.
                    else if (Buscar_Propiedad("power: 3", Lista_Propiedades)) Data = 3; // Power 3.
                    else if (Buscar_Propiedad("power: 4", Lista_Propiedades)) Data = 4; // Power 4.
                    else if (Buscar_Propiedad("power: 5", Lista_Propiedades)) Data = 5; // Power 5.
                    else if (Buscar_Propiedad("power: 6", Lista_Propiedades)) Data = 6; // Power 6.
                    else if (Buscar_Propiedad("power: 7", Lista_Propiedades)) Data = 7; // Power 7.
                    else if (Buscar_Propiedad("power: 8", Lista_Propiedades)) Data = 8; // Power 8.
                    else if (Buscar_Propiedad("power: 9", Lista_Propiedades)) Data = 9; // Power 9.
                    else if (Buscar_Propiedad("power: 10", Lista_Propiedades)) Data = 10; // Power 10.
                    else if (Buscar_Propiedad("power: 11", Lista_Propiedades)) Data = 11; // Power 11.
                    else if (Buscar_Propiedad("power: 12", Lista_Propiedades)) Data = 12; // Power 12.
                    else if (Buscar_Propiedad("power: 13", Lista_Propiedades)) Data = 13; // Power 13.
                    else if (Buscar_Propiedad("power: 14", Lista_Propiedades)) Data = 14; // Power 14.
                    else if (Buscar_Propiedad("power: 15", Lista_Propiedades)) Data = 15; // Power 15.
                }
                else if (string.Compare(Nombre, "minecraft:daylight_detector", true) == 0)
                {
                    if (Buscar_Propiedad("power: 0", Lista_Propiedades)) Data = 0; // Power 0.
                    else if (Buscar_Propiedad("power: 1", Lista_Propiedades)) Data = 1; // Power 1.
                    else if (Buscar_Propiedad("power: 2", Lista_Propiedades)) Data = 2; // Power 2.
                    else if (Buscar_Propiedad("power: 3", Lista_Propiedades)) Data = 3; // Power 3.
                    else if (Buscar_Propiedad("power: 4", Lista_Propiedades)) Data = 4; // Power 4.
                    else if (Buscar_Propiedad("power: 5", Lista_Propiedades)) Data = 5; // Power 5.
                    else if (Buscar_Propiedad("power: 6", Lista_Propiedades)) Data = 6; // Power 6.
                    else if (Buscar_Propiedad("power: 7", Lista_Propiedades)) Data = 7; // Power 7.
                    else if (Buscar_Propiedad("power: 8", Lista_Propiedades)) Data = 8; // Power 8.
                    else if (Buscar_Propiedad("power: 9", Lista_Propiedades)) Data = 9; // Power 9.
                    else if (Buscar_Propiedad("power: 10", Lista_Propiedades)) Data = 10; // Power 10.
                    else if (Buscar_Propiedad("power: 11", Lista_Propiedades)) Data = 11; // Power 11.
                    else if (Buscar_Propiedad("power: 12", Lista_Propiedades)) Data = 12; // Power 12.
                    else if (Buscar_Propiedad("power: 13", Lista_Propiedades)) Data = 13; // Power 13.
                    else if (Buscar_Propiedad("power: 14", Lista_Propiedades)) Data = 14; // Power 14.
                    else if (Buscar_Propiedad("power: 15", Lista_Propiedades)) Data = 15; // Power 15.

                    if (Buscar_Propiedad("inverted: true", Lista_Propiedades)) ID = 178; // Inverted needs a change of ID.
                }
                else if (string.Compare(Nombre, "minecraft:wheat", true) == 0 ||
                    string.Compare(Nombre, "minecraft:carrots", true) == 0 ||
                    string.Compare(Nombre, "minecraft:potatoes", true) == 0)
                {
                    if (Buscar_Propiedad("age: 0", Lista_Propiedades)) Data = 0; // Age 0.
                    else if (Buscar_Propiedad("age: 1", Lista_Propiedades)) Data = 1; // Age 1.
                    else if (Buscar_Propiedad("age: 2", Lista_Propiedades)) Data = 2; // Age 2.
                    else if (Buscar_Propiedad("age: 3", Lista_Propiedades)) Data = 3; // Age 3.
                    else if (Buscar_Propiedad("age: 4", Lista_Propiedades)) Data = 4; // Age 4.
                    else if (Buscar_Propiedad("age: 5", Lista_Propiedades)) Data = 5; // Age 5.
                    else if (Buscar_Propiedad("age: 6", Lista_Propiedades)) Data = 6; // Age 6.
                    else if (Buscar_Propiedad("age: 7", Lista_Propiedades)) Data = 7; // Age 7.
                }
                else if (string.Compare(Nombre, "minecraft:beetroots", true) == 0)
                {
                    if (Buscar_Propiedad("age: 0", Lista_Propiedades)) Data = 0; // Age 0.
                    else if (Buscar_Propiedad("age: 1", Lista_Propiedades)) Data = 1; // Age 1.
                    else if (Buscar_Propiedad("age: 2", Lista_Propiedades)) Data = 2; // Age 2.
                    else if (Buscar_Propiedad("age: 3", Lista_Propiedades)) Data = 3; // Age 3.
                }
                else if (string.Compare(Nombre, "minecraft:farmland", true) == 0)
                {
                    if (Buscar_Propiedad("moisture: 0", Lista_Propiedades)) Data = 0; // Moisture 0.
                    else if (Buscar_Propiedad("moisture: 1", Lista_Propiedades)) Data = 1; // Moisture 1.
                    else if (Buscar_Propiedad("moisture: 2", Lista_Propiedades)) Data = 2; // Moisture 2.
                    else if (Buscar_Propiedad("moisture: 3", Lista_Propiedades)) Data = 3; // Moisture 3.
                    else if (Buscar_Propiedad("moisture: 4", Lista_Propiedades)) Data = 4; // Moisture 4.
                    else if (Buscar_Propiedad("moisture: 5", Lista_Propiedades)) Data = 5; // Moisture 5.
                    else if (Buscar_Propiedad("moisture: 6", Lista_Propiedades)) Data = 6; // Moisture 6.
                    else if (Buscar_Propiedad("moisture: 7", Lista_Propiedades)) Data = 7; // Moisture 7.
                }
                else if (string.Compare(Nombre, "minecraft:banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:black_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:blue_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:brown_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:cyan_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:gray_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:green_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:light_blue_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:light_gray_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:lime_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:magenta_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:orange_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:pink_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:purple_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:red_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:white_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:yellow_banner", true) == 0)
                {
                    if (Buscar_Propiedad("rotation: 0", Lista_Propiedades)) Data = 0; // Rotation 0.
                    else if (Buscar_Propiedad("rotation: 1", Lista_Propiedades)) Data = 1; // Rotation 1.
                    else if (Buscar_Propiedad("rotation: 2", Lista_Propiedades)) Data = 2; // Rotation 2.
                    else if (Buscar_Propiedad("rotation: 3", Lista_Propiedades)) Data = 3; // Rotation 3.
                    else if (Buscar_Propiedad("rotation: 4", Lista_Propiedades)) Data = 4; // Rotation 4.
                    else if (Buscar_Propiedad("rotation: 5", Lista_Propiedades)) Data = 5; // Rotation 5.
                    else if (Buscar_Propiedad("rotation: 6", Lista_Propiedades)) Data = 6; // Rotation 6.
                    else if (Buscar_Propiedad("rotation: 7", Lista_Propiedades)) Data = 7; // Rotation 7.
                    else if (Buscar_Propiedad("rotation: 8", Lista_Propiedades)) Data = 8; // Rotation 8.
                    else if (Buscar_Propiedad("rotation: 9", Lista_Propiedades)) Data = 9; // Rotation 9.
                    else if (Buscar_Propiedad("rotation: 10", Lista_Propiedades)) Data = 10; // Rotation 10.
                    else if (Buscar_Propiedad("rotation: 11", Lista_Propiedades)) Data = 11; // Rotation 11.
                    else if (Buscar_Propiedad("rotation: 12", Lista_Propiedades)) Data = 12; // Rotation 12.
                    else if (Buscar_Propiedad("rotation: 13", Lista_Propiedades)) Data = 13; // Rotation 13.
                    else if (Buscar_Propiedad("rotation: 14", Lista_Propiedades)) Data = 14; // Rotation 14.
                    else if (Buscar_Propiedad("rotation: 15", Lista_Propiedades)) Data = 15; // Rotation 15.
                }
                else if (string.Compare(Nombre, "minecraft:black_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:blue_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:brown_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:cyan_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:gray_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:green_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:light_blue_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:light_gray_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:lime_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:magenta_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:orange_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:pink_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:purple_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:red_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:white_wall_banner", true) == 0 ||
                    string.Compare(Nombre, "minecraft:yellow_wall_banner", true) == 0)
                {
                    if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // north.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 4; // west.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 5; // east.
                }
                else if (string.Compare(Nombre, "minecraft:acacia_door", true) == 0 ||
                    string.Compare(Nombre, "minecraft:birch_door", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dark_oak_door", true) == 0 ||
                    string.Compare(Nombre, "minecraft:iron_door", true) == 0 ||
                    string.Compare(Nombre, "minecraft:jungle_door", true) == 0 ||
                    string.Compare(Nombre, "minecraft:oak_door", true) == 0 ||
                    string.Compare(Nombre, "minecraft:spruce_door", true) == 0)
                {
                    if (Buscar_Propiedad("half: upper", Lista_Propiedades))
                    {
                        Data = 8; // This is the top half of a door.

                        if (Buscar_Propiedad("hinge: right", Lista_Propiedades)) Data |= 1; // Hinge is on the left.

                        if (Buscar_Propiedad("powered: true", Lista_Propiedades)) Data |= 2; // Door is Powered.
                    }
                    else // half: lower
                    {
                        if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 0; // Facing east.
                        else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 1; // Facing south.
                        else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 2; // Facing west.
                        else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 3; // Facing north.

                        if (Buscar_Propiedad("open: true", Lista_Propiedades)) Data |= 4; // Open.
                    }
                }
                else if (string.Compare(Nombre, "minecraft:rail", true) == 0)
                {
                    if (Buscar_Propiedad("shape: north_south", Lista_Propiedades)) Data = 0; // Straight rail connecting to the north and south.
                    else if (Buscar_Propiedad("shape: east_west", Lista_Propiedades)) Data = 1; // Straight rail connecting to the east and west.
                    else if (Buscar_Propiedad("shape: ascending_east", Lista_Propiedades)) Data = 2; // Sloped rail ascending to the east.
                    else if (Buscar_Propiedad("shape: ascending_west", Lista_Propiedades)) Data = 3; // Sloped rail ascending to the west.
                    else if (Buscar_Propiedad("shape: ascending_north", Lista_Propiedades)) Data = 4; // Sloped rail ascending to the north.
                    else if (Buscar_Propiedad("shape: ascending_south", Lista_Propiedades)) Data = 5; // Sloped rail ascending to the south.
                    else if (Buscar_Propiedad("shape: south_east", Lista_Propiedades)) Data = 6; // Curved rail connecting to the south and east.
                    else if (Buscar_Propiedad("shape: south_west", Lista_Propiedades)) Data = 7; // Curved rail connecting to the south and west.
                    else if (Buscar_Propiedad("shape: north_west", Lista_Propiedades)) Data = 8; // Curved rail connecting to the north and west.
                    else if (Buscar_Propiedad("shape: north_east", Lista_Propiedades)) Data = 9; // Curved rail connecting to the north and east.
                }
                else if (string.Compare(Nombre, "minecraft:activator_rail", true) == 0 ||
                    string.Compare(Nombre, "minecraft:detector_rail", true) == 0 ||
                    string.Compare(Nombre, "minecraft:powered_rail", true) == 0)
                {
                    if (Buscar_Propiedad("shape: north_south", Lista_Propiedades)) Data = 0; // flat track going north-south.
                    else if (Buscar_Propiedad("shape: east_west", Lista_Propiedades)) Data = 1; // flat track going west-east.
                    else if (Buscar_Propiedad("shape: ascending_east", Lista_Propiedades)) Data = 2; // sloped track ascending to the east.
                    else if (Buscar_Propiedad("shape: ascending_west", Lista_Propiedades)) Data = 3; // sloped track ascending to the west.
                    else if (Buscar_Propiedad("shape: ascending_north", Lista_Propiedades)) Data = 4; // sloped track ascending to the north.
                    else if (Buscar_Propiedad("shape: ascending_south", Lista_Propiedades)) Data = 5; // sloped track ascending to the south.

                    if (Buscar_Propiedad("powered: true", Lista_Propiedades)) Data |= 8; // Set if rail is active.
                }
                else if (string.Compare(Nombre, "minecraft:chest", true) == 0 ||
                    string.Compare(Nombre, "minecraft:ladder", true) == 0 ||
                    string.Compare(Nombre, "minecraft:trapped_chest", true) == 0)
                {
                    if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // facing north.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // facing south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 4; // facing west.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 5; // facing east.

                    if (Data < 2 || Data > 5) Data = 2; // Invalid values default to 2.
                }
                else if (string.Compare(Nombre, "minecraft:furnace", true) == 0)
                {
                    if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // facing north.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // facing south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 4; // facing west.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 5; // facing east.

                    if (Data < 2 || Data > 5) Data = 2; // Invalid values default to 2.

                    if (Buscar_Propiedad("lit: true", Lista_Propiedades)) ID = 62; // Lit needs a change of ID.
                }
                else if (string.Compare(Nombre, "minecraft:sign", true) == 0)
                {
                    if (Buscar_Propiedad("rotation: 0", Lista_Propiedades)) Data = 0; // south.
                    else if (Buscar_Propiedad("rotation: 1", Lista_Propiedades)) Data = 1; // south-southwest.
                    else if (Buscar_Propiedad("rotation: 2", Lista_Propiedades)) Data = 2; // southwest.
                    else if (Buscar_Propiedad("rotation: 3", Lista_Propiedades)) Data = 3; // west-southwest.
                    else if (Buscar_Propiedad("rotation: 4", Lista_Propiedades)) Data = 4; // west.
                    else if (Buscar_Propiedad("rotation: 5", Lista_Propiedades)) Data = 5; // west-northwest.
                    else if (Buscar_Propiedad("rotation: 6", Lista_Propiedades)) Data = 6; // northwest.
                    else if (Buscar_Propiedad("rotation: 7", Lista_Propiedades)) Data = 7; // north-northwest.
                    else if (Buscar_Propiedad("rotation: 8", Lista_Propiedades)) Data = 8; // north.
                    else if (Buscar_Propiedad("rotation: 9", Lista_Propiedades)) Data = 9; // north-northeast.
                    else if (Buscar_Propiedad("rotation: 10", Lista_Propiedades)) Data = 10; // northeast.
                    else if (Buscar_Propiedad("rotation: 11", Lista_Propiedades)) Data = 11; // east-northeast.
                    else if (Buscar_Propiedad("rotation: 12", Lista_Propiedades)) Data = 12; // east.
                    else if (Buscar_Propiedad("rotation: 13", Lista_Propiedades)) Data = 13; // east-southeast.
                    else if (Buscar_Propiedad("rotation: 14", Lista_Propiedades)) Data = 14; // southeast.
                    else if (Buscar_Propiedad("rotation: 15", Lista_Propiedades)) Data = 15; // south-southeast.
                }
                else if (string.Compare(Nombre, "minecraft:wall_sign", true) == 0)
                {
                    if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // north.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 4; // west.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 5; // east.
                }
                else if (string.Compare(Nombre, "minecraft:dispenser", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dropper", true) == 0)
                {
                    if (Buscar_Propiedad("facing: down", Lista_Propiedades)) Data = 0; // Dropper facing down.
                    else if (Buscar_Propiedad("facing: up", Lista_Propiedades)) Data = 1; // Dropper facing up.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Dropper facing north.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // Dropper facing south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 4; // Dropper facing west.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 5; // Dropper facing east.

                    if (Buscar_Propiedad("triggered: true", Lista_Propiedades)) Data |= 8; // Set if it's activated.
                }
                else if (string.Compare(Nombre, "minecraft:hopper", true) == 0)
                {
                    if (Buscar_Propiedad("facing: down", Lista_Propiedades)) Data = 0; // Output facing down.
                                                                                       //else if (Buscar_Propiedad("facing: up", Lista_Propiedades)) Data = 1; // (unused). But, why Mojang didn't add hoppers going up?
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Output facing north.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // Output facing south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 4; // Output facing west.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 5; // Output facing east.

                    if (Buscar_Propiedad("enabled: false", Lista_Propiedades)) Data |= 8; // Set if activated/disabled.
                }
                else if (string.Compare(Nombre, "minecraft:lever", true) == 0)
                {
                    if (Buscar_Propiedad("face: wall", Lista_Propiedades)) // Lever on block side.
                    {
                        if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 1; // Lever on block side facing east.
                        else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 2; // Lever on block side facing west.
                        else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // Lever on block side facing south.
                        else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 4; // Lever on block side facing north.
                    }
                    else if (Buscar_Propiedad("face: floor", Lista_Propiedades)) // Lever on block top.
                    {
                        if (Buscar_Propiedad("facing: south", Lista_Propiedades) || Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 5; // Lever on block top points south when off.
                        else if (Buscar_Propiedad("facing: east", Lista_Propiedades) || Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 6; // Lever on block top points east when off.
                    }
                    else if (Buscar_Propiedad("face: ceiling", Lista_Propiedades)) // Lever on block bottom.
                    {
                        if (Buscar_Propiedad("facing: east", Lista_Propiedades) || Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 0; // Lever on block bottom points east when off.
                        else if (Buscar_Propiedad("facing: south", Lista_Propiedades) || Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 7; // Lever on block bottom points south when off.
                    }

                    if (Buscar_Propiedad("powered: true", Lista_Propiedades)) Data |= 8; // Set if activated/disabled.
                }
                else if (string.Compare(Nombre, "minecraft:acacia_pressure_plate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:birch_pressure_plate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dark_oak_pressure_plate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:jungle_pressure_plate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:oak_pressure_plate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:spruce_pressure_plate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stone_pressure_plate", true) == 0)
                {
                    if (Buscar_Propiedad("powered: true", Lista_Propiedades)) Data = 1; // If this bit is set, the pressure plate is active.
                }
                else if (string.Compare(Nombre, "minecraft:acacia_button", true) == 0 ||
                    string.Compare(Nombre, "minecraft:birch_button", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dark_oak_button", true) == 0 ||
                    string.Compare(Nombre, "minecraft:jungle_button", true) == 0 ||
                    string.Compare(Nombre, "minecraft:oak_button", true) == 0 ||
                    string.Compare(Nombre, "minecraft:spruce_button", true) == 0 ||
                    string.Compare(Nombre, "minecraft:stone_button", true) == 0)
                {
                    if (Buscar_Propiedad("face: ceiling", Lista_Propiedades)) Data = 0; // Button on block bottom facing down.
                    else if (Buscar_Propiedad("face: wall", Lista_Propiedades)) // Button on block side.
                    {
                        if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 1; // Button on block side facing east.
                        else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 2; // Button on block side facing west.
                        else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // Button on block side facing south.
                        else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 4; // Button on block side facing north.
                    }
                    else if (Buscar_Propiedad("face: floor", Lista_Propiedades)) Data = 5; // Button on block top facing up.

                    if (Buscar_Propiedad("powered: true", Lista_Propiedades)) Data |= 8; // If this bit is set, the button is currently active.
                }
                else if (string.Compare(Nombre, "minecraft:snow", true) == 0)
                {
                    if (Buscar_Propiedad("layers: 1", Lista_Propiedades)) Data = 0; // One layer, 2 pixels thick.
                    else if (Buscar_Propiedad("layers: 2", Lista_Propiedades)) Data = 1; // Two layers, 4 pixels thick.
                    else if (Buscar_Propiedad("layers: 3", Lista_Propiedades)) Data = 2; // Three layers, 6 pixels thick.
                    else if (Buscar_Propiedad("layers: 4", Lista_Propiedades)) Data = 3; // Four layers, 8 pixels thick.
                    else if (Buscar_Propiedad("layers: 5", Lista_Propiedades)) Data = 4; // Five layers, 10 pixels thick.
                    else if (Buscar_Propiedad("layers: 6", Lista_Propiedades)) Data = 5; // Six layers, 12 pixels thick.
                    else if (Buscar_Propiedad("layers: 7", Lista_Propiedades)) Data = 6; // Seven layers, 14 pixels thick.
                    else if (Buscar_Propiedad("layers: 8", Lista_Propiedades)) Data = 7; // Eight layers, 16 pixels thick.
                }
                else if (string.Compare(Nombre, "minecraft:cactus", true) == 0 ||
                    string.Compare(Nombre, "minecraft:sugar_cane", true) == 0)
                {
                    if (Buscar_Propiedad("age: 0", Lista_Propiedades)) Data = 0; // Age 0.
                    else if (Buscar_Propiedad("age: 1", Lista_Propiedades)) Data = 1; // Age 1.
                    else if (Buscar_Propiedad("age: 2", Lista_Propiedades)) Data = 2; // Age 2.
                    else if (Buscar_Propiedad("age: 3", Lista_Propiedades)) Data = 3; // Age 3.
                    else if (Buscar_Propiedad("age: 4", Lista_Propiedades)) Data = 4; // Age 4.
                    else if (Buscar_Propiedad("age: 5", Lista_Propiedades)) Data = 5; // Age 5.
                    else if (Buscar_Propiedad("age: 6", Lista_Propiedades)) Data = 6; // Age 6.
                    else if (Buscar_Propiedad("age: 7", Lista_Propiedades)) Data = 7; // Age 7.
                    else if (Buscar_Propiedad("age: 8", Lista_Propiedades)) Data = 8; // Age 8.
                    else if (Buscar_Propiedad("age: 9", Lista_Propiedades)) Data = 9; // Age 9.
                    else if (Buscar_Propiedad("age: 10", Lista_Propiedades)) Data = 10; // Age 10.
                    else if (Buscar_Propiedad("age: 11", Lista_Propiedades)) Data = 11; // Age 11.
                    else if (Buscar_Propiedad("age: 12", Lista_Propiedades)) Data = 12; // Age 12.
                    else if (Buscar_Propiedad("age: 13", Lista_Propiedades)) Data = 13; // Age 13.
                    else if (Buscar_Propiedad("age: 14", Lista_Propiedades)) Data = 14; // Age 14.
                    else if (Buscar_Propiedad("age: 15", Lista_Propiedades)) Data = 15; // Age 15.
                }
                else if (string.Compare(Nombre, "minecraft:jukebox", true) == 0)
                {
                    if (Buscar_Propiedad("has_record: true", Lista_Propiedades)) Data = 1; // Contains a disc.
                                                                                           // The associated block entity is used to identify which record has been inserted.
                }
                else if (string.Compare(Nombre, "minecraft:carved_pumpkin", true) == 0 ||
                    string.Compare(Nombre, "minecraft:jack_o_lantern", true) == 0)
                {
                    if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 0; // Pumpkin facing south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // Pumpkin facing west.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Pumpkin facing north.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 3; // Pumpkin facing east.

                    //Data = 4; // Jack o'lantern without face. Will this work?
                }
                else if (string.Compare(Nombre, "minecraft:pumpkin", true) == 0)
                {
                    ID = 86; // "minecraft:pumpkin" needs setting a valid ID.

                    Data = 0; // Pumpkin facing south. Using this as a default because the number 4
                    // generates Air instead of pumpkin without faces, although the wiki says it's valid.

                    //Data = 4; // Pumpkin without face. Why it didn't work, there was no block.
                }
                else if (string.Compare(Nombre, "minecraft:cake", true) == 0)
                {
                    if (Buscar_Propiedad("bites: 0", Lista_Propiedades)) Data = 0; // 0 pieces eaten.
                    else if (Buscar_Propiedad("bites: 1", Lista_Propiedades)) Data = 1; // 1 piece eaten.
                    else if (Buscar_Propiedad("bites: 2", Lista_Propiedades)) Data = 2; // 2 pieces eaten.
                    else if (Buscar_Propiedad("bites: 3", Lista_Propiedades)) Data = 3; // 3 pieces eaten.
                    else if (Buscar_Propiedad("bites: 4", Lista_Propiedades)) Data = 4; // 4 pieces eaten.
                    else if (Buscar_Propiedad("bites: 5", Lista_Propiedades)) Data = 5; // 5 pieces eaten.
                    else if (Buscar_Propiedad("bites: 6", Lista_Propiedades)) Data = 6; // 6 pieces eaten.
                }
                else if (string.Compare(Nombre, "minecraft:repeater", true) == 0)
                {
                    // Note that the arrow or triangle points in the opposite direction, which is confusing.
                    if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 0; // Facing south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // Facing west.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Facing north.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 3; // Facing east.

                    if (Buscar_Propiedad("delay: 1", Lista_Propiedades)) Data |= 0; // Delay of 1 redstone tick.
                    else if (Buscar_Propiedad("delay: 2", Lista_Propiedades)) Data |= 4; // Delay of 2 redstone ticks.
                    else if (Buscar_Propiedad("delay: 3", Lista_Propiedades)) Data |= 8; // Delay of 3 redstone ticks.
                    else if (Buscar_Propiedad("delay: 4", Lista_Propiedades)) Data |= 12; // Delay of 4 redstone ticks.

                    if (Buscar_Propiedad("powered: true", Lista_Propiedades)) ID = 94; // Powered needs a change of ID.
                }
                else if (string.Compare(Nombre, "minecraft:comparator", true) == 0)
                {
                    // If it was an item in a hopper, after the conversion it will be gone,
                    // and then the comparator will still be on, and after putting back a
                    // new item in the hopper, it will be off forever, and finally needing
                    // to remove it and place it back for it work again as expected...
                    // I'm not sure how I could fix this bug, so any suggestion is welcome.
                    if (Buscar_Propiedad("powered: true", Lista_Propiedades))
                    {
                        // Note that the arrow or triangle points in the opposite direction, which is confusing.
                        if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 0; // Facing north.
                        else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 1; // Facing east.
                        else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 2; // Facing south.
                        else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 3; // Facing west.

                        if (Buscar_Propiedad("mode: subtract", Lista_Propiedades)) Data |= 4; // Set if in subtraction mode (front torch up and powered).

                        Data |= 8; // Set if powered (at any power level).

                        ID = 150; // Powered needs a change of ID.
                    }
                    else
                    {
                        if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 0; // Facing south.
                        else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // Facing west.
                        else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Facing north.
                        else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 3; // Facing east.

                        if (Buscar_Propiedad("mode: subtract", Lista_Propiedades)) Data |= 4; // Set if in subtraction mode (front torch up and powered).
                    }
                }
                else if (string.Compare(Nombre, "minecraft:acacia_trapdoor", true) == 0 ||
                    string.Compare(Nombre, "minecraft:birch_trapdoor", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dark_oak_trapdoor", true) == 0 ||
                    string.Compare(Nombre, "minecraft:jungle_trapdoor", true) == 0 ||
                    string.Compare(Nombre, "minecraft:oak_trapdoor", true) == 0 ||
                    string.Compare(Nombre, "minecraft:spruce_trapdoor", true) == 0 ||
                    string.Compare(Nombre, "minecraft:iron_trapdoor", true) == 0)
                {
                    // The directions are inverted, which is confusing.
                    if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 0; // Trapdoor on the south side of a block.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 1; // Trapdoor on the north side of a block.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 2; // Trapdoor on the east side of a block.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 3; // Trapdoor on the west side of a block.

                    if (Buscar_Propiedad("open: true", Lista_Propiedades)) Data |= 4; // If this bit is set, the trapdoor is open.

                    if (Buscar_Propiedad("half: top", Lista_Propiedades)) Data |= 8; // If this bit is set, the trapdoor is on the top half of a block. Otherwise, it is on the bottom half.
                }
                else if (string.Compare(Nombre, "minecraft:brown_mushroom_block", true) == 0 ||
                    string.Compare(Nombre, "minecraft:red_mushroom_block", true) == 0)
                {
                    // Ignore the top part or the conversion will fail sometimes.
                    if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: false", Lista_Propiedades) &&
                        Buscar_Propiedad("north: false", Lista_Propiedades) &&
                        Buscar_Propiedad("south: false", Lista_Propiedades) &&
                        Buscar_Propiedad("up: false", Lista_Propiedades) &&
                        Buscar_Propiedad("west: false", Lista_Propiedades)) Data = 0; // Pores on all sides.
                    else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: false", Lista_Propiedades) &&
                        Buscar_Propiedad("north: true", Lista_Propiedades) &&
                        Buscar_Propiedad("south: false", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: true", Lista_Propiedades) &&
                        Buscar_Propiedad("west: true", Lista_Propiedades)) Data = 1; // Cap texture on top, west and north.
                    else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: false", Lista_Propiedades) &&
                        Buscar_Propiedad("north: true", Lista_Propiedades) &&
                        Buscar_Propiedad("south: false", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: true", Lista_Propiedades) &&
                        Buscar_Propiedad("west: false", Lista_Propiedades)) Data = 2; // Cap texture on top and north.
                    else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: true", Lista_Propiedades) &&
                        Buscar_Propiedad("north: true", Lista_Propiedades) &&
                        Buscar_Propiedad("south: false", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: true", Lista_Propiedades) &&
                        Buscar_Propiedad("west: false", Lista_Propiedades)) Data = 3; // Cap texture on top, north and east.
                    else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: false", Lista_Propiedades) &&
                        Buscar_Propiedad("north: false", Lista_Propiedades) &&
                        Buscar_Propiedad("south: false", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: true", Lista_Propiedades) &&
                        Buscar_Propiedad("west: true", Lista_Propiedades)) Data = 4; // Cap texture on top and west.
                    else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: false", Lista_Propiedades) &&
                        Buscar_Propiedad("north: false", Lista_Propiedades) &&
                        Buscar_Propiedad("south: false", Lista_Propiedades) &&
                        Buscar_Propiedad("up: true", Lista_Propiedades) && // Don't ignore it here.
                        Buscar_Propiedad("west: false", Lista_Propiedades)) Data = 5; // Cap texture on top.
                    else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: true", Lista_Propiedades) &&
                        Buscar_Propiedad("north: false", Lista_Propiedades) &&
                        Buscar_Propiedad("south: false", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: true", Lista_Propiedades) &&
                        Buscar_Propiedad("west: false", Lista_Propiedades)) Data = 6; // Cap texture on top and east.
                    else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: false", Lista_Propiedades) &&
                        Buscar_Propiedad("north: false", Lista_Propiedades) &&
                        Buscar_Propiedad("south: true", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: true", Lista_Propiedades) &&
                        Buscar_Propiedad("west: true", Lista_Propiedades)) Data = 7; // Cap texture on top, south and west.
                    else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: false", Lista_Propiedades) &&
                        Buscar_Propiedad("north: false", Lista_Propiedades) &&
                        Buscar_Propiedad("south: true", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: true", Lista_Propiedades) &&
                        Buscar_Propiedad("west: false", Lista_Propiedades)) Data = 8; // Cap texture on top and south.
                    else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: true", Lista_Propiedades) &&
                        Buscar_Propiedad("north: false", Lista_Propiedades) &&
                        Buscar_Propiedad("south: true", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: true", Lista_Propiedades) &&
                        Buscar_Propiedad("west: false", Lista_Propiedades)) Data = 9; // Cap texture on top, east and south.
                                                                                      /*else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                                                                                          Buscar_Propiedad("east: false", Lista_Propiedades) &&
                                                                                          Buscar_Propiedad("north: false", Lista_Propiedades) &&
                                                                                          Buscar_Propiedad("south: false", Lista_Propiedades) &&
                                                                                          Buscar_Propiedad("up: false", Lista_Propiedades) &&
                                                                                          Buscar_Propiedad("west: false", Lista_Propiedades)) Data = 10; // Stem texture on all four sides, pores on top and bottom.*/
                    else if (Buscar_Propiedad("down: true", Lista_Propiedades) &&
                        Buscar_Propiedad("east: true", Lista_Propiedades) &&
                        Buscar_Propiedad("north: true", Lista_Propiedades) &&
                        Buscar_Propiedad("south: true", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: true", Lista_Propiedades) &&
                        Buscar_Propiedad("west: true", Lista_Propiedades)) Data = 14; // Cap texture on all six sides.
                                                                                      /*else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                                                                                          Buscar_Propiedad("east: false", Lista_Propiedades) &&
                                                                                          Buscar_Propiedad("north: false", Lista_Propiedades) &&
                                                                                          Buscar_Propiedad("south: false", Lista_Propiedades) &&
                                                                                          Buscar_Propiedad("up: false", Lista_Propiedades) &&
                                                                                          Buscar_Propiedad("west: false", Lista_Propiedades)) Data = 15; // Stem texture on all six sides.*/
                    else Data = 0;
                }
                else if (string.Compare(Nombre, "minecraft:mushroom_stem", true) == 0)
                {
                    ID = 99; // Change the block ID to "minecraft:brown_mushroom_block".

                    // Ignore the top part or the conversion will fail sometimes.
                    if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: false", Lista_Propiedades) &&
                        Buscar_Propiedad("north: false", Lista_Propiedades) &&
                        Buscar_Propiedad("south: false", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: false", Lista_Propiedades) &&
                        Buscar_Propiedad("west: false", Lista_Propiedades)) Data = 0; // Pores on all sides.
                    else if (Buscar_Propiedad("down: false", Lista_Propiedades) &&
                        Buscar_Propiedad("east: true", Lista_Propiedades) &&
                        Buscar_Propiedad("north: true", Lista_Propiedades) &&
                        Buscar_Propiedad("south: true", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: false", Lista_Propiedades) &&
                        Buscar_Propiedad("west: true", Lista_Propiedades)) Data = 10; // Stem texture on all four sides, pores on top and bottom.
                    else if (Buscar_Propiedad("down: true", Lista_Propiedades) &&
                        Buscar_Propiedad("east: true", Lista_Propiedades) &&
                        Buscar_Propiedad("north: true", Lista_Propiedades) &&
                        Buscar_Propiedad("south: true", Lista_Propiedades) &&
                        //Buscar_Propiedad("up: true", Lista_Propiedades) &&
                        Buscar_Propiedad("west: true", Lista_Propiedades)) Data = 15; // Stem texture on all six sides.
                    else Data = 0;
                }
                else if (string.Compare(Nombre, "minecraft:melon_stem", true) == 0 ||
                    string.Compare(Nombre, "minecraft:attached_melon_stem", true) == 0 ||
                    string.Compare(Nombre, "minecraft:pumpkin_stem", true) == 0 ||
                    string.Compare(Nombre, "minecraft:attached_pumpkin_stem", true) == 0)
                {
                    if (Buscar_Propiedad("age: 0", Lista_Propiedades)) Data = 0; // Freshly planted stem.
                    else if (Buscar_Propiedad("age: 1", Lista_Propiedades)) Data = 1; // First stage of growth.
                    else if (Buscar_Propiedad("age: 2", Lista_Propiedades)) Data = 2; // Second stage of growth.
                    else if (Buscar_Propiedad("age: 3", Lista_Propiedades)) Data = 3; // Third stage of growth.
                    else if (Buscar_Propiedad("age: 4", Lista_Propiedades)) Data = 4; // Fourth stage of growth.
                    else if (Buscar_Propiedad("age: 5", Lista_Propiedades)) Data = 5; // Fifth stage of growth.
                    else if (Buscar_Propiedad("age: 6", Lista_Propiedades)) Data = 6; // Sixth stage of growth.
                    else if (Buscar_Propiedad("age: 7", Lista_Propiedades)) Data = 7; // Seventh stage of growth.
                }
                else if (string.Compare(Nombre, "minecraft:vine", true) == 0)
                {
                    if (Buscar_Propiedad("south: true", Lista_Propiedades)) Data |= 1; // south.
                    if (Buscar_Propiedad("west: true", Lista_Propiedades)) Data |= 2; // west.
                    if (Buscar_Propiedad("north: true", Lista_Propiedades)) Data |= 4; // north.
                    if (Buscar_Propiedad("east: true", Lista_Propiedades)) Data |= 8; // east.
                }
                else if (string.Compare(Nombre, "minecraft:acacia_fence_gate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:birch_fence_gate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dark_oak_fence_gate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:jungle_fence_gate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:oak_fence_gate", true) == 0 ||
                    string.Compare(Nombre, "minecraft:spruce_fence_gate", true) == 0)
                {
                    if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 0; // Facing south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // Facing west.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Facing north.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 3; // Facing east.

                    if (Buscar_Propiedad("open: true", Lista_Propiedades)) Data |= 4; // 0 if the gate is closed, 1 if open.
                }
                else if (string.Compare(Nombre, "minecraft:nether_wart", true) == 0)
                {
                    if (Buscar_Propiedad("age: 0", Lista_Propiedades)) Data = 0; // Age 0.
                    else if (Buscar_Propiedad("age: 1", Lista_Propiedades)) Data = 1; // Age 1.
                    else if (Buscar_Propiedad("age: 2", Lista_Propiedades)) Data = 2; // Age 2.
                    else if (Buscar_Propiedad("age: 3", Lista_Propiedades)) Data = 3; // Age 3.
                }
                else if (string.Compare(Nombre, "minecraft:brewing_stand", true) == 0)
                {
                    if (Buscar_Propiedad("has_bottle_0: true", Lista_Propiedades)) Data |= 1; // The slot pointing east.
                    if (Buscar_Propiedad("has_bottle_2: true", Lista_Propiedades)) Data |= 2; // The slot pointing southwest.
                    if (Buscar_Propiedad("has_bottle_1: true", Lista_Propiedades)) Data |= 4; // The slot pointing northwest.
                }
                else if (string.Compare(Nombre, "minecraft:cauldron", true) == 0)
                {
                    if (Buscar_Propiedad("level: 0", Lista_Propiedades)) Data = 0; // Empty.
                    else if (Buscar_Propiedad("level: 1", Lista_Propiedades)) Data = 1; // ⅓ filled.
                    else if (Buscar_Propiedad("level: 2", Lista_Propiedades)) Data = 2; // ⅔ filled.
                    else if (Buscar_Propiedad("level: 3", Lista_Propiedades)) Data = 3; // Fully filled.
                }
                else if (string.Compare(Nombre, "minecraft:end_portal_frame", true) == 0)
                {
                    if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 0; // To the south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // To the west.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // To the north.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 3; // To the east.

                    if (Buscar_Propiedad("eye: true", Lista_Propiedades)) Data |= 4; // 0x4 is a bit flag: 0 is an "empty" frame block, 1 is a block with an Eye of Ender inserted.
                }
                else if (string.Compare(Nombre, "minecraft:cocoa", true) == 0)
                {
                    // The directions are inverted, which is confusing.
                    if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 0; // Attached to the north.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // Attached to the east.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Attached to the south.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 3; // Attached to the west.

                    if (Buscar_Propiedad("age: 0", Lista_Propiedades)) Data |= 0; // First stage.
                    else if (Buscar_Propiedad("age: 1", Lista_Propiedades)) Data |= 4; // Second stage.
                    else if (Buscar_Propiedad("age: 2", Lista_Propiedades)) Data |= 8; // Final stage.
                }
                else if (string.Compare(Nombre, "minecraft:tripwire_hook", true) == 0)
                {
                    if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 0; // Tripwire hook on block side facing south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // Tripwire hook on block side facing west.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Tripwire hook on block side facing north.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 3; // Tripwire hook on block side facing east.

                    if (Buscar_Propiedad("attached: true", Lista_Propiedades)) Data |= 4; // If set, the tripwire hook is connected and ready to trip ("middle" position).

                    if (Buscar_Propiedad("powered: true", Lista_Propiedades)) Data |= 8; // If set, the tripwire hook is currently activated ("down" position).
                }
                else if (string.Compare(Nombre, "minecraft:tripwire", true) == 0)
                {
                    if (Buscar_Propiedad("powered: true", Lista_Propiedades)) Data |= 1; // Set if tripwire is activated (an entity is intersecting its collision mask).
                                                                                         //if (Buscar_Propiedad("", Lista_Propiedades)) Data |= 2; // Unused.
                    if (Buscar_Propiedad("attached: true", Lista_Propiedades)) Data |= 4; // Set if tripwire is attached to a valid tripwire circuit.
                    if (Buscar_Propiedad("disarmed: true", Lista_Propiedades)) Data |= 8; // Set if tripwire is disarmed.
                }
                else if (string.Compare(Nombre, "minecraft:creeper_head", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dragon_head", true) == 0 ||
                    string.Compare(Nombre, "minecraft:player_head", true) == 0 ||
                    string.Compare(Nombre, "minecraft:skeleton_skull", true) == 0 ||
                    string.Compare(Nombre, "minecraft:wither_skeleton_skull", true) == 0 ||
                    string.Compare(Nombre, "minecraft:zombie_head", true) == 0)
                {
                    Data = 1; // On the floor (rotation is stored in the tile entity).
                }
                else if (string.Compare(Nombre, "minecraft:creeper_wall_head", true) == 0 ||
                    string.Compare(Nombre, "minecraft:dragon_wall_head", true) == 0 ||
                    string.Compare(Nombre, "minecraft:player_wall_head", true) == 0 ||
                    string.Compare(Nombre, "minecraft:skeleton_wall_skull", true) == 0 ||
                    string.Compare(Nombre, "minecraft:wither_skeleton_wall_skull", true) == 0 ||
                    string.Compare(Nombre, "minecraft:zombie_wall_head", true) == 0)
                {
                    if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // On a wall, facing north.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // On a wall, facing south.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 4; // On a wall, facing east.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 5; // On a wall, facing west.
                }
                else if (string.Compare(Nombre, "minecraft:anvil", true) == 0)
                {
                    if (Buscar_Propiedad("facing: east", Lista_Propiedades) || Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // Anvil (East/West).

                    //Data |= 0; // Anvil.
                }
                else if (string.Compare(Nombre, "minecraft:chipped_anvil", true) == 0)
                {
                    if (Buscar_Propiedad("facing: east", Lista_Propiedades) || Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // Slightly Damaged Anvil (East/West).

                    Data |= 4; // Slightly Damaged Anvil.
                }
                else if (string.Compare(Nombre, "minecraft:damaged_anvil", true) == 0)
                {
                    if (Buscar_Propiedad("facing: east", Lista_Propiedades) || Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // Very Damaged Anvil (East/West).

                    Data |= 8; // Very Damaged Anvil.
                }
                else if (string.Compare(Nombre, "minecraft:observer", true) == 0)
                {
                    // The directions seem to be inverted, which is confusing.
                    if (Buscar_Propiedad("facing: up", Lista_Propiedades)) Data = 0; // Facing down.
                    else if (Buscar_Propiedad("facing: down", Lista_Propiedades)) Data = 1; // Facing up.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Facing south.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // Facing north.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 4; // Facing east.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 5; // Facing west.
                }
                else if (string.Compare(Nombre, "minecraft:structure_block", true) == 0)
                {
                    if (Buscar_Propiedad("mode: save", Lista_Propiedades)) Data = 0; // Save.
                    else if (Buscar_Propiedad("mode: load", Lista_Propiedades)) Data = 1; // Load.
                    else if (Buscar_Propiedad("mode: corner", Lista_Propiedades)) Data = 2; // Corner.
                    else if (Buscar_Propiedad("mode: data", Lista_Propiedades)) Data = 3; // Data.
                }
                else if (string.Compare(Nombre, "minecraft:chorus_flower", true) == 0)
                {
                    if (Buscar_Propiedad("age: 0", Lista_Propiedades)) Data = 0000; // Age 0.
                    else if (Buscar_Propiedad("age: 1", Lista_Propiedades)) Data = 0000; // Age 1.
                    else if (Buscar_Propiedad("age: 2", Lista_Propiedades)) Data = 0000; // Age 2.
                    else if (Buscar_Propiedad("age: 3", Lista_Propiedades)) Data = 0000; // Age 3.
                    else if (Buscar_Propiedad("age: 4", Lista_Propiedades)) Data = 0000; // Age 4.
                    else if (Buscar_Propiedad("age: 5", Lista_Propiedades)) Data = 0000; // Age 5, the data value denotes its age, it will not grow anymore when data value is 0x5.
                }
                else if (string.Compare(Nombre, "minecraft:end_rod", true) == 0)
                {
                    if (Buscar_Propiedad("facing: down", Lista_Propiedades)) Data = 0; // Facing down.
                    else if (Buscar_Propiedad("facing: up", Lista_Propiedades)) Data = 1; // Facing up.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // Facing north.
                    else if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 3; // Facing south.
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 4; // Facing west.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 5; // Facing east.
                }
                else if (string.Compare(Nombre, "minecraft:black_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:blue_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:brown_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:cyan_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:gray_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:green_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:light_blue_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:light_gray_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:lime_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:magenta_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:orange_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:pink_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:purple_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:red_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:white_glazed_terracotta", true) == 0 ||
                    string.Compare(Nombre, "minecraft:yellow_glazed_terracotta", true) == 0)
                {
                    if (Buscar_Propiedad("facing: south", Lista_Propiedades)) Data = 0; // south (the player was facing north when this block was placed).
                    else if (Buscar_Propiedad("facing: west", Lista_Propiedades)) Data = 1; // west.
                    else if (Buscar_Propiedad("facing: north", Lista_Propiedades)) Data = 2; // north.
                    else if (Buscar_Propiedad("facing: east", Lista_Propiedades)) Data = 3; // east.
                }
                else if (string.Compare(Nombre, "minecraft:redstone_lamp", true) == 0)
                {
                    if (Buscar_Propiedad("lit: true", Lista_Propiedades)) ID = 124; // Lit.
                }
                else if (string.Compare(Nombre, "minecraft:redstone_ore", true) == 0)
                {
                    if (Buscar_Propiedad("lit: true", Lista_Propiedades)) ID = 74; // Lit.
                }
                /*
                else if (string.Compare(Nombre, "", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0)
                {
                    if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                }
                else if (string.Compare(Nombre, "", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0 ||
                    string.Compare(Nombre, "", true) == 0)
                {
                    if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                    else if (Buscar_Propiedad("", Lista_Propiedades)) Data = 0000; // .
                }*/
                return ID;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
            return ID_Original;
        }

        /// <summary>
        /// Thread function that converts the available dimensions of any 1.13+ Minecraft world.
        /// </summary>
        internal void Subproceso_DoWork()
        {
            bool Subproceso_Abortado = false; // Used to know if the window must be closed.
            try
            {
                Subproceso_Activo = true;
                Stopwatch Cronómetro_Total = Stopwatch.StartNew();
                Bloques_Desconocidos = null;
                Diccionario_Bloques_Desconocidos.Clear();
                ////Lista_Propiedades_Únicas.Clear(); // 2018_10_08_12_25_04_362
                //Lista_Propiedades_Ejemplos.Clear();
                this.Invoke(new Invocación.Delegado_Control_Cursor(Invocación.Ejecutar_Delegado_Control_Cursor), new object[] { this, Cursors.WaitCursor });
                //Stopwatch Cronómetro_Región = new Stopwatch();
                //Stopwatch Cronómetro_Chunk = new Stopwatch();

                // Start the progress bars.
                int Progreso_Chunk = 0;
                int Progreso_Región = 0;
                int Total_Regiones = Lista_Posiciones_Regiones_Overworld.Count + Lista_Posiciones_Regiones_Nether.Count + Lista_Posiciones_Regiones_The_End.Count;
                Etiqueta_Progreso_Chunk.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Chunk, "Chunk progress: " + Program.Traducir_Número_Decimales_Redondear(((double)Progreso_Chunk * 100d) / 65536d, 4) + " % (" + Program.Traducir_Número(Progreso_Chunk) + " of 1.024 chunks)" });
                Etiqueta_Progreso_Región.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Región, "Region progress: " + Program.Traducir_Número_Decimales_Redondear(((double)Progreso_Región * 100d) / (double)Total_Regiones, 4) + " % (" + Program.Traducir_Número(Progreso_Región) + " of " + Program.Traducir_Número(Total_Regiones) + (Total_Regiones != 1L ? " regions)" : " region)") });
                Barra_Progreso_Chunk.Invoke(new Invocación.Delegado_ProgressBar_Maximum(Invocación.Ejecutar_Delegado_ProgressBar_Maximum), new object[] { Barra_Progreso_Chunk, 1024 });
                Barra_Progreso_Región.Invoke(new Invocación.Delegado_ProgressBar_Maximum(Invocación.Ejecutar_Delegado_ProgressBar_Maximum), new object[] { Barra_Progreso_Región, Total_Regiones });

                // Load all the available information for the level and player to copy those values later.
                Minecraft.Información_Niveles Información_Nivel = Minecraft.Información_Niveles.Obtener_Información_Nivel(Ruta_Mundo);
                Dictionary<string, Minecraft.Posiciones_Jugadores> Diccionario_Posiciones_Jugadores = Minecraft.Posiciones_Jugadores.Obtener_Posiciones_Jugadores(Ruta_Mundo);
                Minecraft.Posiciones_Jugadores Posición_Jugador = new Minecraft.Posiciones_Jugadores(Información_Nivel.SpawnX, Math.Min((Información_Nivel.SpawnY + 1L), 255L), Información_Nivel.SpawnZ); // Set the spawn point as the default player position, but 1 block higher (just in case).
                if (Diccionario_Posiciones_Jugadores != null && Diccionario_Posiciones_Jugadores.Count > 0)
                {
                    foreach (KeyValuePair<string, Minecraft.Posiciones_Jugadores> Entrada in Diccionario_Posiciones_Jugadores)
                    {
                        Posición_Jugador = Entrada.Value; // Use the position for the first player found.
                        break;
                    }
                }

                string Ruta = Program.Ruta_Guardado_Minecraft + "\\" + Program.Obtener_Nombre_Temporal_Sin_Guiones() + " 1_13_to_1_12";
                if (Directory.Exists(Ruta))
                {
                    this.Invoke(new Invocación.Delegado_IWin32Window_MessageBox(Invocación.Ejecutar_Delegado_IWin32Window_MessageBox), new object[] { this, "Somehow the directory name for the new Minecraft map already exists.\r\nPlease try it again if the system clock is running properly.\r\nPath: \"" + Ruta + "\".", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning });
                    Ruta = null;
                    return;
                }
                Program.Crear_Carpetas(Ruta);
                AnvilWorld Mundo = AnvilWorld.Create(Ruta);
                Mundo.Level.LevelName = Path.GetFileName(Ruta);
                Mundo.Level.UseMapFeatures = true; // ?
                //Mundo.Level.GeneratorOptions = "1;minecraft:bedrock"; // Not used for now.
                Mundo.Level.GameType = GameType.CREATIVE;
                Mundo.Level.Spawn = new SpawnPoint((int)Información_Nivel.SpawnX, (int)Math.Min((Información_Nivel.SpawnY + 1L), 255L), (int)Información_Nivel.SpawnZ);
                Mundo.Level.AllowCommands = true; // Allow cheats.
                Mundo.Level.GameRules.DoMobSpawning = true; // Spawn mobs.
                Mundo.Level.GameRules.DoFireTick = false; // Prevent the new level to burn out.
                Mundo.Level.GameRules.MobGriefing = false; // Prevent the mobs to destroy anything.
                Mundo.Level.GameRules.KeepInventory = true; // Keep the players inventories.
                Mundo.Level.RainTime = (int)Información_Nivel.RainTime;
                Mundo.Level.IsRaining = Información_Nivel.Raining != 0L;
                Mundo.Level.Player = new Player();
                Mundo.Level.Player.Dimension = Posición_Jugador.Dimesión; // 0 = Overworld, -1 = Nether, +1 = The End.
                Mundo.Level.Player.Position = new Vector3();
                Mundo.Level.Player.Position.X = (double)Posición_Jugador.X; // Try to spawn where the player was.
                Mundo.Level.Player.Position.Y = (double)Posición_Jugador.Y;
                Mundo.Level.Player.Position.Z = (double)Posición_Jugador.Z;
                Substrate.Orientation Orientación = new Substrate.Orientation();
                Orientación.Pitch = 45d; // -90º a +90º // 45º = Camera centered (looking into the horizon).
                Orientación.Yaw = -45d; // -180º a +180º // -45º = Camera rotation (looking at the southeast).
                Mundo.Level.Player.Rotation = Orientación;
                Mundo.Level.Player.Spawn = new SpawnPoint((int)Información_Nivel.SpawnX, (int)Math.Min((Información_Nivel.SpawnY + 1L), 255L), (int)Información_Nivel.SpawnZ);
                Mundo.Level.Player.Abilities.Flying = true; // Start with creative flight enabled.
                Mundo.Level.RandomSeed = Información_Nivel.RandomSeed; // Copy the original seed.
                Mundo.Level.ThunderTime = (int)Información_Nivel.ThunderTime;
                Mundo.Level.IsThundering = Información_Nivel.Thundering != 0L;

                // Start the multiple dimensions at once to work with them.
                IChunkManager Chunks_Overworld = null;
                BlockManager Bloques_Overworld = null;
                IChunkManager Chunks_Nether = null;
                BlockManager Bloques_Nether = null;
                IChunkManager Chunks_The_End = null;
                BlockManager Bloques_The_End = null;
                //if (Lista_Posiciones_Regiones_Overworld != null && Lista_Posiciones_Regiones_Overworld.Count > 0)
                {
                    Chunks_Overworld = Mundo.GetChunkManager(0);
                    Bloques_Overworld = Mundo.GetBlockManager(0);
                }
                //if (Lista_Posiciones_Regiones_Nether != null && Lista_Posiciones_Regiones_Nether.Count > 0)
                {
                    Chunks_Nether = Mundo.GetChunkManager(-1);
                    Bloques_Nether = Mundo.GetBlockManager(-1);
                }
                //if (Lista_Posiciones_Regiones_The_End != null && Lista_Posiciones_Regiones_The_End.Count > 0)
                {
                    Chunks_The_End = Mundo.GetChunkManager(1);
                    Bloques_The_End = Mundo.GetBlockManager(1);
                }
                List<string> Listas_Rutas_Regiones = new List<string>();
                List<List<Point>> Listas_Posiciones_Regiones = new List<List<Point>>();

                // Allow cross-dimensions in the Overworld.
                if (Dimensión_Overworld == 0)
                {
                    Listas_Rutas_Regiones.Add(Ruta_Regiones_Overworld);
                    Listas_Posiciones_Regiones.Add(Lista_Posiciones_Regiones_Overworld);
                }
                else if (Dimensión_Overworld == 1)
                {
                    Listas_Rutas_Regiones.Add(Ruta_Regiones_Nether);
                    Listas_Posiciones_Regiones.Add(Lista_Posiciones_Regiones_Nether);
                }
                else if (Dimensión_Overworld == 2)
                {
                    Listas_Rutas_Regiones.Add(Ruta_Regiones_The_End);
                    Listas_Posiciones_Regiones.Add(Lista_Posiciones_Regiones_The_End);
                }

                // Allow cross-dimensions in the Nether.
                if (Dimensión_Nether == 0)
                {
                    Listas_Rutas_Regiones.Add(Ruta_Regiones_Overworld);
                    Listas_Posiciones_Regiones.Add(Lista_Posiciones_Regiones_Overworld);
                }
                else if (Dimensión_Nether == 1)
                {
                    Listas_Rutas_Regiones.Add(Ruta_Regiones_Nether);
                    Listas_Posiciones_Regiones.Add(Lista_Posiciones_Regiones_Nether);
                }
                else if (Dimensión_Nether == 2)
                {
                    Listas_Rutas_Regiones.Add(Ruta_Regiones_The_End);
                    Listas_Posiciones_Regiones.Add(Lista_Posiciones_Regiones_The_End);
                }

                // Allow cross-dimensions in The End.
                if (Dimensión_The_End == 0)
                {
                    Listas_Rutas_Regiones.Add(Ruta_Regiones_Overworld);
                    Listas_Posiciones_Regiones.Add(Lista_Posiciones_Regiones_Overworld);
                }
                else if (Dimensión_The_End == 1)
                {
                    Listas_Rutas_Regiones.Add(Ruta_Regiones_Nether);
                    Listas_Posiciones_Regiones.Add(Lista_Posiciones_Regiones_Nether);
                }
                else if (Dimensión_The_End == 2)
                {
                    Listas_Rutas_Regiones.Add(Ruta_Regiones_The_End);
                    Listas_Posiciones_Regiones.Add(Lista_Posiciones_Regiones_The_End);
                }

                List<IChunkManager> Lista_Chunks = new List<IChunkManager>(new IChunkManager[] { Chunks_Overworld, Chunks_Nether, Chunks_The_End });
                List<BlockManager> Lista_Bloques = new List<BlockManager>(new BlockManager[] { Bloques_Overworld, Bloques_Nether, Bloques_The_End });

                // If enabled, the blocks will be converted to wool or concrete just for fun.
                bool Pixel_Art = CheckBox_Mundo_Lana.CheckState != CheckState.Unchecked || CheckBox_Mundo_Plástico.CheckState != CheckState.Unchecked || CheckBox_Mundo_Minerales.CheckState != CheckState.Unchecked;
                List<Color> Lista_Pixel_Art_Paleta = null;
                MagickImage Imagen_Mapa = null;
                // Dictionary used to find the color hash codes a lot faster compared to a dictionary with hundreds of blocks.
                Dictionary<int, short> Diccionario_Códigos_Hash_Índices = new Dictionary<int, short>();
                if (Pixel_Art)
                {
                    Lista_Pixel_Art_Paleta = new List<Color>();
                    if (CheckBox_Mundo_Lana.CheckState != CheckState.Unchecked) // Add the 16 wool blocks.
                    {
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_wool"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_wool"]]);

                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_wool"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_wool"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_wool"]);
                    }
                    if (CheckBox_Mundo_Plástico.CheckState != CheckState.Unchecked) // Add the 16 concrete blocks.
                    {
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_concrete"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_concrete"]]);

                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_concrete"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_concrete"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_concrete"]);
                    }
                    if (CheckBox_Mundo_Minerales.CheckState != CheckState.Unchecked) // Add the 8 ores and it's 8 blocks.
                    {
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:coal_ore"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:diamond_ore"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:emerald_ore"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gold_ore"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:iron_ore"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lapis_ore"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:nether_quartz_ore"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:redstone_ore"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:coal_block"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:diamond_block"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:emerald_block"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gold_block"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:iron_block"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lapis_block"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:quartz_block"]]);
                        Lista_Pixel_Art_Paleta.Add(Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:redstone_block"]]);

                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:coal_ore"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:coal_ore"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:diamond_ore"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:diamond_ore"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:emerald_ore"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:emerald_ore"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gold_ore"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gold_ore"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:iron_ore"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:iron_ore"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lapis_ore"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lapis_ore"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:nether_quartz_ore"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:nether_quartz_ore"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:redstone_ore"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:redstone_ore"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:coal_block"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:coal_block"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:diamond_block"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:diamond_block"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:emerald_block"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:emerald_block"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gold_block"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gold_block"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:iron_block"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:iron_block"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lapis_block"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lapis_block"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:quartz_block"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:quartz_block"]);
                        Diccionario_Códigos_Hash_Índices.Add(Minecraft.Bloques.Diccionario_Índice_Código_Hash_Color[Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:redstone_block"]], Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:redstone_block"]);
                    }
                    // Generate an image with unique block colors for the later conversion.
                    Bitmap Imagen_Paleta = new Bitmap(Lista_Pixel_Art_Paleta.Count, 1, PixelFormat.Format24bppRgb);
                    Graphics Pintar_Paleta = Graphics.FromImage(Imagen_Paleta);
                    Pintar_Paleta.CompositingMode = CompositingMode.SourceCopy;
                    for (int Índice_Paleta = 0; Índice_Paleta < Lista_Pixel_Art_Paleta.Count; Índice_Paleta++)
                    {
                        if (Pendiente_Subproceso_Abortar)
                        {
                            Pendiente_Subproceso_Abortar = false;
                            Mundo.Save(); // Save the part of the world already generated.
                            Mundo = null;
                            Subproceso_Abortado = true;
                            return; // Cancel safely before time.
                        }
                        SolidBrush Pincel = new SolidBrush(Lista_Pixel_Art_Paleta[Índice_Paleta]);
                        Pintar_Paleta.FillRectangle(Pincel, Índice_Paleta, 0, 1, 1);
                        Pincel.Dispose();
                        Pincel = null;
                    }
                    Pintar_Paleta.Dispose();
                    Pintar_Paleta = null;
                    Imagen_Mapa = new MagickImage(Imagen_Paleta);
                }

                long Bloques_Convertidos = 0L; // Used to know the real converted blocks.

                // Iterate through the available dimensions in the original world and convert them.
                for (int Índice_Dimensión = 0; Índice_Dimensión < 3; Índice_Dimensión++)
                {
                    if (Pendiente_Subproceso_Abortar)
                    {
                        Pendiente_Subproceso_Abortar = false;
                        Mundo.Save(); // Save the part of the world already generated.
                        Mundo = null;
                        Subproceso_Abortado = true;
                        return; // Cancel safely before time.
                    }
                    //Progreso_Chunk = 0;
                    //Etiqueta_Progreso_Chunk.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Chunk, "Chunk progress: " + Program.Traducir_Número_Decimales_Redondear(((double)Progreso_Chunk * 100d) / 1024d, 4) + " % (" + Program.Traducir_Número(Progreso_Chunk) + " of 1.024 chunks)" });
                    //Barra_Progreso_Chunk.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Chunk, Progreso_Chunk });
                    if (Listas_Posiciones_Regiones[Índice_Dimensión] != null && Listas_Posiciones_Regiones[Índice_Dimensión].Count > 0)
                    {
                        // Use this trick to avoid repeating the whole code for each dimension.
                        List<Point> Lista_Posiciones_Regiones = Listas_Posiciones_Regiones[Índice_Dimensión];
                        IChunkManager Chunks = Lista_Chunks[Índice_Dimensión];
                        BlockManager Bloques = Lista_Bloques[Índice_Dimensión];
                        foreach (Point Posición_Región in Lista_Posiciones_Regiones) // Region coordinates.
                        {
                            if (Pendiente_Subproceso_Abortar)
                            {
                                Pendiente_Subproceso_Abortar = false;
                                Chunks.Save(); // Save the part of the chunks already generated.
                                Chunks = null;
                                Bloques = null;
                                Mundo.Save(); // Save the part of the world already generated.
                                Mundo = null;
                                Subproceso_Abortado = true;
                                return; // Cancel safely before time.
                            }
                            //Etiqueta_Progreso_Región.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Región, "Region progress: " + Program.Traducir_Número_Decimales_Redondear(((double)Progreso_Región * 100d) / (double)Total_Regiones, 4) + " % (" + Program.Traducir_Número(Progreso_Región) + " of " + Program.Traducir_Número(Total_Regiones) + (Total_Regiones != 1L ? " regions)" : " region)") });
                            //Barra_Progreso_Región.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Región, Progreso_Región });
                            //Progreso_Región++;

                            string Ruta_Región = Listas_Rutas_Regiones[Índice_Dimensión] + "\\r." + Posición_Región.X.ToString() + "." + Posición_Región.Y.ToString();
                            if (File.Exists(Ruta_Región + ".mca")) Ruta_Región += ".mca";
                            else if (File.Exists(Ruta_Región + ".mcr")) Ruta_Región += ".mcr";
                            else Ruta_Región = null; // Not found? A minute ago it was here.
                            if (!string.IsNullOrEmpty(Ruta_Región) && File.Exists(Ruta_Región))
                            {
                                Substrate_Jupisoft.Core.RegionFile Archivo_Región = new Substrate_Jupisoft.Core.RegionFile(Ruta_Región);
                                if (Archivo_Región != null)
                                {
                                    for (int Chunk_Z = 0; Chunk_Z < 32; Chunk_Z++)
                                    {
                                        for (int Chunk_X = 0; Chunk_X < 32; Chunk_X++)
                                        {
                                            if (Pendiente_Subproceso_Abortar)
                                            {
                                                Pendiente_Subproceso_Abortar = false;
                                                Archivo_Región = null; // Dispose the current region file.
                                                Chunks.Save(); // Save the part of the chunks already generated.
                                                Chunks = null;
                                                Bloques = null;
                                                Mundo.Save(); // Save the part of the world already generated.
                                                Mundo = null;
                                                Subproceso_Abortado = true;
                                                return; // Cancel safely before time.
                                            }
                                            // Update the progress bars in real time after every converted chunk.
                                            this.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { this, Texto_Título + " - [Conversion time: " + Program.Traducir_Intervalo_Horas_Minutos_Segundos(Cronómetro_Total.Elapsed) + "]" });
                                            Etiqueta_Progreso_Chunk.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Chunk, "Chunk progress: " + Program.Traducir_Número_Decimales_Redondear(((double)Progreso_Chunk * 100d) / 1024d, 4) + " % (" + Program.Traducir_Número(Progreso_Chunk) + " of 1.024 chunks)" });
                                            Etiqueta_Progreso_Región.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Región, "Region progress: " + Program.Traducir_Número_Decimales_Redondear((((double)Progreso_Región + (Progreso_Chunk / 1024d)) * 100d) / (double)Total_Regiones, 4) + " % (" + Program.Traducir_Número(Progreso_Región) + " of " + Program.Traducir_Número(Total_Regiones) + (Total_Regiones != 1L ? " regions)" : " region)") });
                                            Barra_Progreso_Chunk.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Chunk, Progreso_Chunk });
                                            Progreso_Chunk++;

                                            int Chunk_X_Global = (Posición_Región.X * 32) + Chunk_X; // Chunk coordinates.
                                            int Chunk_Z_Global = (Posición_Región.Y * 32) + Chunk_Z;

                                            int Bloque_X_Global = Chunk_X_Global * 16; // Block coordinates.
                                            int Bloque_Z_Global = Chunk_Z_Global * 16;

                                            string Compresión; // Finds the compression used in the chunks.
                                            Stream Lector_Chunk = Archivo_Región.GetChunkDataInputStream(Chunk_X, Chunk_Z, out Compresión);
                                            if (Lector_Chunk != null)
                                            {
                                                Substrate_Jupisoft.Nbt.NbtTree Árbol = new Substrate_Jupisoft.Nbt.NbtTree(Lector_Chunk);
                                                if (Árbol != null && Árbol.Root != null)
                                                {
                                                    Substrate_Jupisoft.Nbt.TagNodeCompound Árbol_Compuesto = (Árbol.Root as Substrate_Jupisoft.Nbt.TagNode) as Substrate_Jupisoft.Nbt.TagNodeCompound;
                                                    if (Árbol_Compuesto != null)
                                                    {
                                                        Substrate_Jupisoft.Nbt.NbtTree _tree = new Substrate_Jupisoft.Nbt.NbtTree(Árbol_Compuesto);
                                                        Substrate_Jupisoft.Nbt.TagNodeCompound Nodo_Level = _tree.Root["Level"] as Substrate_Jupisoft.Nbt.TagNodeCompound;
                                                        if (Nodo_Level.ContainsKey("Status")) // MC 1.13+
                                                        {
                                                            string Texto_Estado = Nodo_Level["Status"] as Substrate_Jupisoft.Nbt.TagNodeString;
                                                            if (!string.IsNullOrEmpty(Texto_Estado) && string.Compare(Texto_Estado, "empty", true) != 0) // The chunk is not empty. Needs to be expanded...
                                                            {
                                                                // Sorry... the biomes will be lost forever after the conversion.
                                                                // Maybe someone can give a solution to this? Thank you in advance.
                                                                /*if (Cargar_Biomas && Nodo_Level.ContainsKey("Biomes"))
                                                                {
                                                                    int[] Matriz_Bytes_Biomas = Nodo_Level["Biomes"] as TagNodeIntArray;
                                                                    //MessageBox.Show(Matriz_Bytes_Biomas.Length.ToString(), "Bio");
                                                                    if (Matriz_Bytes_Biomas != null && Matriz_Bytes_Biomas.Length >= 256)
                                                                    {
                                                                        Chunk.Matriz_Bytes_Biomas = new short[16, 16];
                                                                        for (int Índice_Z = 0, Índice = 0; Índice_Z < 16; Índice_Z++)
                                                                        {
                                                                            for (int Índice_X = 0; Índice_X < 16; Índice_X++, Índice++)
                                                                            {
                                                                                if (Pendiente_Subproceso_Abortar)
                                                                                {
                                                                                    Pendiente_Subproceso_Abortar = false;
                                                                                    Archivo_Región.Close();
                                                                                    Archivo_Región.Dispose();
                                                                                    Archivo_Región = null;
                                                                                    return new Regiones(Point.Empty);
                                                                                }
                                                                                Chunk.Matriz_Bytes_Biomas[Índice_X, Índice_Z] = (short)Matriz_Bytes_Biomas[Índice];
                                                                            }
                                                                        }
                                                                    }
                                                                    Matriz_Bytes_Biomas = null;
                                                                }*/
                                                                // Cargar las 16 posibles subsecciones del chunk de 16 bloques de alto (16 ^ 3):
                                                                Substrate_Jupisoft.Nbt.TagNodeList Nodo_Secciones = Nodo_Level["Sections"] as Substrate_Jupisoft.Nbt.TagNodeList;
                                                                if (Nodo_Secciones != null)
                                                                {
                                                                    Dictionary<SpawnPoint, string[]> Diccionario_Entidades = new Dictionary<SpawnPoint, string[]>();
                                                                    Substrate_Jupisoft.Nbt.TagNodeList Nodo_Entidades = Nodo_Level["TileEntities"] as Substrate_Jupisoft.Nbt.TagNodeList;
                                                                    if (Nodo_Entidades != null)
                                                                    {
                                                                        foreach (Substrate_Jupisoft.Nbt.TagNodeCompound Nodo_Entidad in Nodo_Entidades)
                                                                        {
                                                                            if (Pendiente_Subproceso_Abortar)
                                                                            {
                                                                                Pendiente_Subproceso_Abortar = false;
                                                                                Archivo_Región = null; // Dispose the current region file.
                                                                                Chunks.Save(); // Save the part of the chunks already generated.
                                                                                Chunks = null;
                                                                                Bloques = null;
                                                                                Mundo.Save(); // Save the part of the world already generated.
                                                                                Mundo = null;
                                                                                Subproceso_Abortado = true;
                                                                                return; // Cancel safely before time.
                                                                            }
                                                                            if (Nodo_Entidad.ContainsKey("id"))
                                                                            {
                                                                                string ID = Nodo_Entidad["id"].ToTagString();
                                                                                if (!string.IsNullOrEmpty(ID) && Nodo_Entidad.ContainsKey("x") && Nodo_Entidad.ContainsKey("y") && Nodo_Entidad.ContainsKey("z"))
                                                                                {
                                                                                    if (string.Compare(ID, "minecraft:sign", true) == 0 || string.Compare(ID, "minecraft:wall_sign", true) == 0)
                                                                                    {
                                                                                        string[] Matriz_Líneas = new string[4];
                                                                                        if (Nodo_Entidad.ContainsKey("Text1")) Matriz_Líneas[0] = Nodo_Entidad["Text1"].ToTagString();
                                                                                        if (Nodo_Entidad.ContainsKey("Text2")) Matriz_Líneas[1] = Nodo_Entidad["Text2"].ToTagString();
                                                                                        if (Nodo_Entidad.ContainsKey("Text3")) Matriz_Líneas[2] = Nodo_Entidad["Text3"].ToTagString();
                                                                                        if (Nodo_Entidad.ContainsKey("Text4")) Matriz_Líneas[3] = Nodo_Entidad["Text4"].ToTagString();
                                                                                        if (!string.IsNullOrEmpty(Matriz_Líneas[0])) // {"text":"9"}.
                                                                                        {
                                                                                            Matriz_Líneas[0] = Matriz_Líneas[0].Replace("{\"text\":\"", null);
                                                                                            Matriz_Líneas[0] = Matriz_Líneas[0].Substring(0, Matriz_Líneas[0].Length - 2);
                                                                                        }
                                                                                        if (!string.IsNullOrEmpty(Matriz_Líneas[1]))
                                                                                        {
                                                                                            Matriz_Líneas[1] = Matriz_Líneas[1].Replace("{\"text\":\"", null);
                                                                                            Matriz_Líneas[1] = Matriz_Líneas[1].Substring(0, Matriz_Líneas[1].Length - 2);
                                                                                        }
                                                                                        if (!string.IsNullOrEmpty(Matriz_Líneas[2]))
                                                                                        {
                                                                                            Matriz_Líneas[2] = Matriz_Líneas[2].Replace("{\"text\":\"", null);
                                                                                            Matriz_Líneas[2] = Matriz_Líneas[2].Substring(0, Matriz_Líneas[2].Length - 2);
                                                                                        }
                                                                                        if (!string.IsNullOrEmpty(Matriz_Líneas[3]))
                                                                                        {
                                                                                            Matriz_Líneas[3] = Matriz_Líneas[3].Replace("{\"text\":\"", null);
                                                                                            Matriz_Líneas[3] = Matriz_Líneas[3].Substring(0, Matriz_Líneas[3].Length - 2);
                                                                                        }
                                                                                        for (int Índice_Línea = 0; Índice_Línea < 4; Índice_Línea++) // Avoid null strings (just in case).
                                                                                        {
                                                                                            if (Pendiente_Subproceso_Abortar)
                                                                                            {
                                                                                                Pendiente_Subproceso_Abortar = false;
                                                                                                Archivo_Región = null; // Dispose the current region file.
                                                                                                Chunks.Save(); // Save the part of the chunks already generated.
                                                                                                Chunks = null;
                                                                                                Bloques = null;
                                                                                                Mundo.Save(); // Save the part of the world already generated.
                                                                                                Mundo = null;
                                                                                                Subproceso_Abortado = true;
                                                                                                return; // Cancel safely before time.
                                                                                            }
                                                                                            if (string.IsNullOrEmpty(Matriz_Líneas[Índice_Línea])) Matriz_Líneas[Índice_Línea] = string.Empty;
                                                                                        }
                                                                                        SpawnPoint Vector = new SpawnPoint(Nodo_Entidad["x"].ToTagInt(), Nodo_Entidad["y"].ToTagInt(), Nodo_Entidad["z"].ToTagInt());
                                                                                        if (!Diccionario_Entidades.ContainsKey(Vector)) Diccionario_Entidades.Add(Vector, Matriz_Líneas);
                                                                                        //else MessageBox.Show(this, Vector.ToString(), "Vector XYZ repeated?");
                                                                                    }
                                                                                    //else if (string.Compare(ID, "minecraft:hopper", true) == 0)
                                                                                    {
                                                                                        // TODO: Add support so the items in the chests, etc won't be lost...
                                                                                    } // This might take a few weeks... or months! (but hopefully not years).
                                                                                }
                                                                            }
                                                                        }
                                                                    }

                                                                    ChunkRef Chunk = Chunks.CreateChunk(Chunk_X_Global, Chunk_Z_Global);
                                                                    Chunk.IsTerrainPopulated = true;
                                                                    Chunk.Blocks.AutoLight = false;

                                                                    //Índice_Chunk = 0;
                                                                    //Barra_Progreso_Chunk.Invoke(new Invocación.Delegado_ProgressBar_Maximum(Invocación.Ejecutar_Delegado_ProgressBar_Maximum), new object[] { Barra_Progreso_Chunk, Nodo_Secciones.Count * 4096 });
                                                                    foreach (Substrate_Jupisoft.Nbt.TagNodeCompound Nodo_Sección in Nodo_Secciones)
                                                                    {
                                                                        if (Pendiente_Subproceso_Abortar)
                                                                        {
                                                                            Pendiente_Subproceso_Abortar = false;
                                                                            Archivo_Región = null; // Dispose the current region file.
                                                                            Chunks.Save(); // Save the part of the chunks already generated.
                                                                            Chunks = null;
                                                                            Bloques = null;
                                                                            Mundo.Save(); // Save the part of the world already generated.
                                                                            Mundo = null;
                                                                            Subproceso_Abortado = true;
                                                                            return; // Cancel safely before time.
                                                                        }
                                                                        Substrate_Jupisoft.Nbt.TagNodeCompound Árbol_Sección = Nodo_Sección as Substrate_Jupisoft.Nbt.TagNodeCompound;
                                                                        if (Árbol_Sección == null) continue; // Ignorar las seciones vacías
                                                                        byte Sección_Y = Árbol_Sección["Y"] as Substrate_Jupisoft.Nbt.TagNodeByte;
                                                                        //if (Sección_Y < 0 || Sección_Y >= 16) MessageBox.Show(Sección_Y.ToString(), "Sección_Y");
                                                                        int Sección_Y_16 = Sección_Y * 16;
                                                                        //if (Sección_Y_16 > Chunk.Y_Máximo) Chunk.Y_Máximo = (short)Sección_Y_16;

                                                                        //short[] Matriz_Índices_Paleta = null;
                                                                        //int Índice_Paleta_Aire = -1;

                                                                        if (Árbol_Sección.ContainsKey("Palette") && Árbol_Sección.ContainsKey("BlockStates"))
                                                                        {
                                                                            List<AlphaBlock> Lista_Bloques_Paleta = new List<AlphaBlock>(); // Add up to 4.096 blocks per section.
                                                                            List<string> Lista_Bloques_Pixel_Art = new List<string>(); // Add the names of the transformed blocks.
                                                                            int[] Matriz_Índices_Pixel_Art = new int[4096]; // Add 4.096 blocks per section.

                                                                            Substrate_Jupisoft.Nbt.TagNodeList Nodo_Paleta = Árbol_Sección["Palette"] as Substrate_Jupisoft.Nbt.TagNodeList;
                                                                            //Matriz_Índices_Paleta = new short[Nodo_Paleta.Count];
                                                                            //int Índice_Paleta = 0;
                                                                            foreach (Substrate_Jupisoft.Nbt.TagNodeCompound Nodo_Nombre in Nodo_Paleta)
                                                                            {
                                                                                if (Pendiente_Subproceso_Abortar)
                                                                                {
                                                                                    Pendiente_Subproceso_Abortar = false;
                                                                                    Archivo_Región = null; // Dispose the current region file.
                                                                                    Chunks.Save(); // Save the part of the chunks already generated.
                                                                                    Chunks = null;
                                                                                    Bloques = null;
                                                                                    Mundo.Save(); // Save the part of the world already generated.
                                                                                    Mundo = null;
                                                                                    Subproceso_Abortado = true;
                                                                                    return; // Cancel safely before time.
                                                                                }
                                                                                if (Nodo_Nombre != null && Nodo_Nombre.ContainsKey("Name"))
                                                                                {
                                                                                    string Nombre = Nodo_Nombre["Name"].ToTagString();
                                                                                    //if (string.IsNullOrEmpty(Nombre)) Nombre = "?";
                                                                                    //if (!Lista_Propiedades_Ejemplos.Contains(Nombre)) Lista_Propiedades_Ejemplos.Add(Nombre);
                                                                                    if (!string.IsNullOrEmpty(Nombre) && Minecraft.Diccionario_Bloques_Nombres_Índices.ContainsKey(Nombre))
                                                                                    {
                                                                                        //Matriz_Índices_Paleta[Índice_Paleta] = (short)Índice_Paleta;
                                                                                        //Matriz_Índices_Paleta[Índice_Paleta] = Minecraft.Diccionario_Bloques_Nombres_Índices[Nombre];
                                                                                        //if (string.Compare(Nombre, "minecraft:air", true) == 0) Índice_Paleta_Aire = Índice_Paleta;
                                                                                        byte ID = 0; // Air.
                                                                                        byte Data = 0; // Default air.

                                                                                        // Check if the block properties exist or not.
                                                                                        if (!Nodo_Nombre.ContainsKey("Properties")) // Without block properties.
                                                                                        {
                                                                                            string Nombre_1_12_2;
                                                                                            ID = Obtener_ID_Data_Minecraft_1_12_2(Nombre, new List<string>(), out Nombre_1_12_2, out Data);
                                                                                            if (Pixel_Art) Lista_Bloques_Pixel_Art.Add(Nombre_1_12_2);
                                                                                        }
                                                                                        else // With block properties.
                                                                                        {
                                                                                            List<string> Lista_Propiedades = new List<string>();
                                                                                            Substrate_Jupisoft.Nbt.TagNodeCompound Nodo_Propiedades = Nodo_Nombre["Properties"].ToTagCompound();
                                                                                            foreach (string Clave in Nodo_Propiedades.Keys)
                                                                                            {
                                                                                                if (Pendiente_Subproceso_Abortar)
                                                                                                {
                                                                                                    Pendiente_Subproceso_Abortar = false;
                                                                                                    Archivo_Región = null; // Dispose the current region file.
                                                                                                    Chunks.Save(); // Save the part of the chunks already generated.
                                                                                                    Chunks = null;
                                                                                                    Bloques = null;
                                                                                                    Mundo.Save(); // Save the part of the world already generated.
                                                                                                    Mundo = null;
                                                                                                    Subproceso_Abortado = true;
                                                                                                    return; // Cancel safely before time.
                                                                                                }
                                                                                                string Propiedad = Clave + ": " + Nodo_Propiedades[Clave].ToTagString();
                                                                                                Lista_Propiedades.Add(Propiedad);
                                                                                                /*if (!Lista_Propiedades_Ejemplos.Contains("\"" + Propiedad + "\","))
                                                                                                {
                                                                                                    Lista_Propiedades_Únicas.Add("\"" + Propiedad + "\", // " + Nombre + "."); // 2018_10_08_12_25_58_913
                                                                                                    Lista_Propiedades_Ejemplos.Add("\"" + Propiedad + "\",");
                                                                                                }*/
                                                                                            }
                                                                                            string Nombre_1_12_2;
                                                                                            ID = Obtener_ID_Data_Minecraft_1_12_2(Nombre, Lista_Propiedades, out Nombre_1_12_2, out Data);
                                                                                            if (Pixel_Art) Lista_Bloques_Pixel_Art.Add(Nombre_1_12_2);
                                                                                        }
                                                                                        try
                                                                                        {
                                                                                            // Start the converted block type.
                                                                                            AlphaBlock Bloque = new AlphaBlock(ID, Data);

                                                                                            // Check if this block needs an entity with it or not.
                                                                                            // Substrate is missing all the new entities (and some old)!
                                                                                            // Sadly when setting with it a block that needs a TileEntity
                                                                                            // it throw exceptions that made the conversion impossible.
                                                                                            // So now this application has a custom Substrate library
                                                                                            // without the initial definitions of the blocks that might
                                                                                            // a TileEntity but still didn't have one on Substrate, and
                                                                                            // maybe that "temporary" fix will allow it to add those
                                                                                            // blocks on the world and "maybe" Minecraft will fix them (hopefully!).
                                                                                            if (ID == 23) // TileEntityTrap
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityTrap Entidad = new Substrate.TileEntities.TileEntityTrap();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }
                                                                                            /*else if (ID == 34) // TileEntityPiston
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityPiston Entidad = new Substrate.TileEntities.TileEntityPiston();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }*/ // Too old? Ignored for now also.
                                                                                            else if (ID == 25) // TileEntityMusic
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityMusic Entidad = new Substrate.TileEntities.TileEntityMusic();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }
                                                                                            else if (ID == 52) // TileEntityMobSpawner
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityMobSpawner Entidad = new Substrate.TileEntities.TileEntityMobSpawner();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }
                                                                                            else if (ID == 54) // TileEntityChest
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityChest Entidad = new Substrate.TileEntities.TileEntityChest();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }
                                                                                            else if (ID == 61 || ID == 62) // TileEntityFurnace
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityFurnace Entidad = new Substrate.TileEntities.TileEntityFurnace();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }
                                                                                            /*else if (ID == 63 || ID == 68) // TileEntitySign // This will be set later on.
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntitySign Entidad = new Substrate.TileEntities.TileEntitySign();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }*/
                                                                                            /*else if (ID == 84) // TileEntityRecordPlayer
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityRecordPlayer Entidad = new Substrate.TileEntities.TileEntityRecordPlayer();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }*/
                                                                                            else if (ID == 116) // TileEntityEnchantmentTable
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityEnchantmentTable Entidad = new Substrate.TileEntities.TileEntityEnchantmentTable();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }
                                                                                            else if (ID == 117) // TileEntityBrewingStand
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityBrewingStand Entidad = new Substrate.TileEntities.TileEntityBrewingStand();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }
                                                                                            else if (ID == 119) // TileEntityEndPortal
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityEndPortal Entidad = new Substrate.TileEntities.TileEntityEndPortal();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }
                                                                                            else if (ID == 137) // TileEntityControl
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityControl Entidad = new Substrate.TileEntities.TileEntityControl();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }
                                                                                            else if (ID == 138) // TileEntityBeacon
                                                                                            {
                                                                                                Substrate.TileEntities.TileEntityBeacon Entidad = new Substrate.TileEntities.TileEntityBeacon();
                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                            }
                                                                                            // Add the converted block to the custom list.
                                                                                            Lista_Bloques_Paleta.Add(Bloque);
                                                                                        }
                                                                                        catch (Exception Excepción)
                                                                                        {
                                                                                            Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true;
                                                                                            try { Lista_Bloques_Paleta.Add(new AlphaBlock(0, 0)); } // Air.
                                                                                            catch { }
                                                                                        }
                                                                                    }
                                                                                    else // Unknown or null block found, so set it to Air.
                                                                                    {
                                                                                        // Adding it even if it's invalid won't make the block palette fully disordered.
                                                                                        AlphaBlock Bloque = new AlphaBlock(0, 0); // Air block.
                                                                                        Lista_Bloques_Paleta.Add(Bloque); // Add the converted block to the custom list.
                                                                                        if (Pixel_Art) Lista_Bloques_Pixel_Art.Add("minecraft:air");
                                                                                    }
                                                                                }
                                                                                //Índice_Paleta++;
                                                                            }
                                                                            if (Lista_Bloques_Paleta.Count == Nodo_Paleta.Count)
                                                                            {
                                                                                int Bits_Bloque = 0; //Lista_Bits.Count / 4096; // Bits per block.

                                                                                List<bool> Lista_Bits = new List<bool>((Árbol_Sección["BlockStates"] as Substrate_Jupisoft.Nbt.TagNodeLongArray).Matriz_Bits);
                                                                                if (Lista_Bits != null && Lista_Bits.Count > 0)
                                                                                {
                                                                                    Bits_Bloque = Math.Max(Lista_Bits.Count / 4096, 4); // Minimum of 4 bits.

                                                                                    bool[] Matriz_Bits = new bool[32];
                                                                                    int[] Matriz_Valor = new int[1];
                                                                                    int Índice_Bit = 0;

                                                                                    // Image used for the wool, concrete or ore worlds.
                                                                                    Bitmap Imagen_Pixel_Art = null;
                                                                                    Graphics Pintar_Pixel_Art = null;
                                                                                    if (Pixel_Art)
                                                                                    {
                                                                                        // Start the image and it's graphics for the next 16 x 16 x 16 blocks (section).
                                                                                        Imagen_Pixel_Art = new Bitmap(16, 256, PixelFormat.Format32bppArgb);
                                                                                        Pintar_Pixel_Art = Graphics.FromImage(Imagen_Pixel_Art);
                                                                                        Pintar_Pixel_Art.CompositingMode = CompositingMode.SourceCopy;
                                                                                        //Pintar_Pixel_Art.CompositingQuality = CompositingQuality.HighQuality;
                                                                                        //Pintar_Pixel_Art.InterpolationMode = InterpolationMode.NearestNeighbor;
                                                                                        //Pintar_Pixel_Art.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                                                                        //Pintar_Pixel_Art.SmoothingMode = SmoothingMode.None;
                                                                                        //Pintar_Pixel_Art.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                                                                                    }

                                                                                    // Read the whole 16 x 16 x 16 blocks section (it's a 1/16 chunk).
                                                                                    for (int Índice_Y = 0, Índice_Pixel_Art = 0; Índice_Y < 16; Índice_Y++)
                                                                                    {
                                                                                        // Read the 16 x 16 (256) rectangle of blocks.
                                                                                        for (int Índice_Z = 0; Índice_Z < 16; Índice_Z++)
                                                                                        {
                                                                                            // Read each row with 16 horizontal blocks.
                                                                                            for (int Índice_X = 0; Índice_X < 16; Índice_X++, Índice_Pixel_Art++)
                                                                                            {
                                                                                                if (Pendiente_Subproceso_Abortar)
                                                                                                {
                                                                                                    Pendiente_Subproceso_Abortar = false;
                                                                                                    Archivo_Región = null; // Dispose the current region file.
                                                                                                    Chunks.Save(); // Save the part of the chunks already generated.
                                                                                                    Chunks = null;
                                                                                                    Bloques = null;
                                                                                                    Mundo.Save(); // Save the part of the world already generated.
                                                                                                    Mundo = null;
                                                                                                    Subproceso_Abortado = true;
                                                                                                    return; // Cancel safely before time.
                                                                                                }
                                                                                                Array.Clear(Matriz_Bits, 0, Matriz_Bits.Length);
                                                                                                Lista_Bits.GetRange(Índice_Bit, Bits_Bloque).CopyTo(Matriz_Bits, 0); // 32 - Índice_Máscara);
                                                                                                //Lista_Bits_Máscara.CopyTo(Matriz_Bits, 0); // 32 - Índice_Máscara);
                                                                                                Matriz_Valor[0] = 0; // Reset... is this really necessary?
                                                                                                new BitArray(Matriz_Bits).CopyTo(Matriz_Valor, 0);
                                                                                                int Índice = Matriz_Valor[0];

                                                                                                if (!Pixel_Art)
                                                                                                {
                                                                                                    // Use this variable with 3 coordinates (in 3D) to quickly compare block positions.
                                                                                                    SpawnPoint Vector = new SpawnPoint(Bloque_X_Global + Índice_X, Sección_Y_16 + Índice_Y, Bloque_Z_Global + Índice_Z);
                                                                                                    if (!Diccionario_Entidades.ContainsKey(Vector)) // Save a regular block without entity.
                                                                                                    {
                                                                                                        try
                                                                                                        {
                                                                                                            Chunk.Blocks.SetBlock(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, Lista_Bloques_Paleta[Índice]);
                                                                                                        }
                                                                                                        catch (Exception Excepción)
                                                                                                        {
                                                                                                            Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true;
                                                                                                            try { Chunk.Blocks.SetBlock(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, new AlphaBlock(0, 0)); } // Air.
                                                                                                            catch { }
                                                                                                        }
                                                                                                    }
                                                                                                    else // Save the text in all the signs and wall signs. The rest of entities will be lost.
                                                                                                    {
                                                                                                        string[] Matriz_Líneas = Diccionario_Entidades[Vector];
                                                                                                        if (Lista_Bloques_Paleta[Índice].ID == 63 || Lista_Bloques_Paleta[Índice].ID == 68) // "minecraft:sign" or "minecraft:wall_sign".
                                                                                                        {
                                                                                                            try
                                                                                                            {
                                                                                                                AlphaBlock Bloque = new AlphaBlock(Lista_Bloques_Paleta[Índice].ID, Lista_Bloques_Paleta[Índice].Data);
                                                                                                                Substrate.TileEntities.TileEntitySign Entidad = new Substrate.TileEntities.TileEntitySign();
                                                                                                                Entidad.Text1 = Matriz_Líneas[0];
                                                                                                                Entidad.Text2 = Matriz_Líneas[1];
                                                                                                                Entidad.Text3 = Matriz_Líneas[2];
                                                                                                                Entidad.Text4 = Matriz_Líneas[3];
                                                                                                                Entidad.X = Vector.X;
                                                                                                                Entidad.Y = Vector.Y;
                                                                                                                Entidad.Z = Vector.Z;
                                                                                                                Bloque.SetTileEntity(Entidad);
                                                                                                                Chunk.Blocks.SetBlock(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, Bloque);
                                                                                                            }
                                                                                                            catch (Exception Excepción)
                                                                                                            {
                                                                                                                Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true;
                                                                                                                try { Chunk.Blocks.SetBlock(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, new AlphaBlock(0, 0)); } // Air.
                                                                                                                catch { }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                    if (CheckBox_Forzar_Luz_Máxima.Checked) // Force a maximum light level in the whole world.
                                                                                                    {
                                                                                                        Chunk.Blocks.SetBlockLight(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, 15);
                                                                                                        //Chunk.Blocks.SetSkyLight(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, 15);
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    Matriz_Índices_Pixel_Art[Índice_Pixel_Art] = Índice;
                                                                                                }
                                                                                                Índice_Bit += Bits_Bloque; // Prepare the next block index for the next iteration.

                                                                                                //Índice_Chunk++;
                                                                                                //Barra_Progreso_Chunk.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Chunk, Índice_Chunk });
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    if (Pixel_Art) // Reconvert the average colors to the desired block types like wool, etc.
                                                                                    {
                                                                                        // Note: this part of the function is just what I thought might be a fun or cool idea.
                                                                                        // And it's not really needed to convert from 1.13+ to 1.12.2-, although this code
                                                                                        // is very powerful and might lead the way to some new cool features in a near future.

                                                                                        // Ignore the previous conversions and obtain the average color
                                                                                        // based on the original block name found at the palette.
                                                                                        for (int Índice_Y = 0, Índice_Pixel_Art = 0; Índice_Y < 16; Índice_Y++)
                                                                                        {
                                                                                            for (int Índice_Z = 0; Índice_Z < 16; Índice_Z++)
                                                                                            {
                                                                                                for (int Índice_X = 0; Índice_X < 16; Índice_X++, Índice_Pixel_Art++)
                                                                                                {
                                                                                                    if (Pendiente_Subproceso_Abortar)
                                                                                                    {
                                                                                                        Pendiente_Subproceso_Abortar = false;
                                                                                                        Archivo_Región = null; // Dispose the current region file.
                                                                                                        Chunks.Save(); // Save the part of the chunks already generated.
                                                                                                        Chunks = null;
                                                                                                        Bloques = null;
                                                                                                        Mundo.Save(); // Save the part of the world already generated.
                                                                                                        Mundo = null;
                                                                                                        Subproceso_Abortado = true;
                                                                                                        return; // Cancel safely before time.
                                                                                                    }
                                                                                                    // Get the internal block index based on it's Minecraft 1.13+ name.
                                                                                                    short Índice_ID = Minecraft.Bloques.Diccionario_Nombre_Índice[Lista_Bloques_Pixel_Art[Matriz_Índices_Pixel_Art[Índice_Pixel_Art]]];
                                                                                                    // Get the average color based on the internal block index.
                                                                                                    Color Color_ARGB = Minecraft.Bloques.Diccionario_Índice_Color_ARGB[Índice_ID];
                                                                                                    // Start a brush with the average color obtained.
                                                                                                    SolidBrush Pincel = new SolidBrush(Color_ARGB);
                                                                                                    // Draw a single pixel.
                                                                                                    Pintar_Pixel_Art.FillRectangle(Pincel, Índice_X, (Índice_Y * 16) + Índice_Z, 1, 1);
                                                                                                    // Delete the brush after it's only use.
                                                                                                    Pincel.Dispose();
                                                                                                    Pincel = null;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        // The drawing of the 256 colors has finished.
                                                                                        Pintar_Pixel_Art.Dispose();
                                                                                        Pintar_Pixel_Art = null;

                                                                                        MagickImage Imagen_Mapeada = new MagickImage(Imagen_Pixel_Art);

                                                                                        QuantizeSettings Ajustes_Cuantización = new QuantizeSettings();
                                                                                        //Ajustes_Cuantización.Colors = Diccionario_Paleta.Count; // 2
                                                                                        //Ajustes_Cuantización.ColorSpace = ColorSpace.RGB;
                                                                                        Ajustes_Cuantización.DitherMethod = (CheckBox_Mundo_Lana.CheckState == CheckState.Indeterminate || CheckBox_Mundo_Plástico.CheckState == CheckState.Indeterminate || CheckBox_Mundo_Minerales.CheckState == CheckState.Indeterminate) ? DitherMethod.FloydSteinberg : DitherMethod.No; // No = Plain color transitions. // FloydSteinberg = Smooth color transitions and (maybe) a bit strange sometimes.
                                                                                        //Ajustes_Cuantización.MeasureErrors = false;
                                                                                        //Ajustes_Cuantización.TreeDepth = Diccionario_Paleta.Count; // 8

                                                                                        // Change the colors of the image and only allow the wool or concrete ones.
                                                                                        Imagen_Mapeada.Map(Imagen_Mapa, Ajustes_Cuantización);

                                                                                        // Convert the quantized the image to a regular bitmap.
                                                                                        Bitmap Imagen_Cuantizada = new Bitmap(16, 256, PixelFormat.Format32bppArgb);
                                                                                        Graphics Pintar_Cuantizada = Graphics.FromImage(Imagen_Cuantizada);
                                                                                        Pintar_Cuantizada.CompositingMode = CompositingMode.SourceCopy;
                                                                                        /*Pintar_Cuantizada.CompositingQuality = CompositingQuality.HighQuality;
                                                                                        Pintar_Cuantizada.InterpolationMode = InterpolationMode.NearestNeighbor;
                                                                                        Pintar_Cuantizada.PixelOffsetMode = PixelOffsetMode.HighQuality;
                                                                                        Pintar_Cuantizada.SmoothingMode = SmoothingMode.None;*/
                                                                                        Pintar_Cuantizada.DrawImage(Imagen_Mapeada.ToBitmap(ImageFormat.Png), new Rectangle(0, 0, 16, 256), new Rectangle(0, 0, 16, 256), GraphicsUnit.Pixel);
                                                                                        Pintar_Cuantizada.Dispose();
                                                                                        Pintar_Cuantizada = null;

                                                                                        // Read all the pixels of the quantized image inside a byte array.
                                                                                        BitmapData Bitmap_Data = Imagen_Cuantizada.LockBits(new Rectangle(0, 0, 16, 256), ImageLockMode.ReadOnly, Imagen_Cuantizada.PixelFormat);
                                                                                        byte[] Matriz_Bytes = new byte[Math.Abs(Bitmap_Data.Stride) * 256];
                                                                                        Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes, 0, Matriz_Bytes.Length);
                                                                                        //int Bytes_Diferencia = Math.Abs(Bitmap_Data.Stride) - ((16 * Image.GetPixelFormatSize(Imagen_Cuantizada.PixelFormat)) / 8);
                                                                                        Imagen_Cuantizada.UnlockBits(Bitmap_Data);
                                                                                        Bitmap_Data = null;
                                                                                        Imagen_Mapeada.Dispose();
                                                                                        Imagen_Mapeada = null;
                                                                                        Imagen_Pixel_Art.Dispose();
                                                                                        Imagen_Pixel_Art = null;

                                                                                        // Write back the converted colors only as blocks between wool or concrete.
                                                                                        for (int Índice_Y = 0, Índice_Byte = 0, Índice_Pixel_Art = 0; Índice_Y < 16; Índice_Y++)
                                                                                        {
                                                                                            for (int Índice_Z = 0; Índice_Z < 16; Índice_Z++)
                                                                                            {
                                                                                                for (int Índice_X = 0; Índice_X < 16; Índice_X++, Índice_Pixel_Art++, Índice_Byte += 4)
                                                                                                {
                                                                                                    if (Pendiente_Subproceso_Abortar)
                                                                                                    {
                                                                                                        Pendiente_Subproceso_Abortar = false;
                                                                                                        Archivo_Región = null; // Dispose the current region file.
                                                                                                        Chunks.Save(); // Save the part of the chunks already generated.
                                                                                                        Chunks = null;
                                                                                                        Bloques = null;
                                                                                                        Mundo.Save(); // Save the part of the world already generated.
                                                                                                        Mundo = null;
                                                                                                        Subproceso_Abortado = true;
                                                                                                        return; // Cancel safely before time.
                                                                                                    }
                                                                                                    if (string.Compare(Lista_Bloques_Pixel_Art[Matriz_Índices_Pixel_Art[Índice_Pixel_Art]], "minecraft:air", true) != 0 &&
                                                                                                        string.Compare(Lista_Bloques_Pixel_Art[Matriz_Índices_Pixel_Art[Índice_Pixel_Art]], "minecraft:water", true) != 0 &&
                                                                                                        string.Compare(Lista_Bloques_Pixel_Art[Matriz_Índices_Pixel_Art[Índice_Pixel_Art]], "minecraft:flowing_water", true) != 0 &&
                                                                                                        string.Compare(Lista_Bloques_Pixel_Art[Matriz_Índices_Pixel_Art[Índice_Pixel_Art]], "minecraft:lava", true) != 0 &&
                                                                                                        string.Compare(Lista_Bloques_Pixel_Art[Matriz_Índices_Pixel_Art[Índice_Pixel_Art]], "minecraft:flowing_lava", true) != 0)
                                                                                                    {
                                                                                                        int Código_Hash = Color.FromArgb(255/*Matriz_Bytes[Índice + 3]*/, Matriz_Bytes[Índice_Byte + 2], Matriz_Bytes[Índice_Byte + 1], Matriz_Bytes[Índice_Byte]).GetHashCode();
                                                                                                        if (Diccionario_Códigos_Hash_Índices.ContainsKey(Código_Hash))
                                                                                                        {
                                                                                                            short Índice_ID = Diccionario_Códigos_Hash_Índices[Código_Hash];
                                                                                                            if (Minecraft.Bloques.Diccionario_Índice_Nombre.ContainsKey(Índice_ID))
                                                                                                            {
                                                                                                                byte ID = 0; // Air.
                                                                                                                byte Data = 0; // Default Air.
                                                                                                                foreach (KeyValuePair<short, short> Entrada in Minecraft.Diccionario_Bloques_Índices_1_12_2_a_Índices_1_13)
                                                                                                                {
                                                                                                                    if (Pendiente_Subproceso_Abortar)
                                                                                                                    {
                                                                                                                        Pendiente_Subproceso_Abortar = false;
                                                                                                                        Archivo_Región = null; // Dispose the current region file.
                                                                                                                        Chunks.Save(); // Save the part of the chunks already generated.
                                                                                                                        Chunks = null;
                                                                                                                        Bloques = null;
                                                                                                                        Mundo.Save(); // Save the part of the world already generated.
                                                                                                                        Mundo = null;
                                                                                                                        Subproceso_Abortado = true;
                                                                                                                        return; // Cancel safely before time.
                                                                                                                    }
                                                                                                                    if (Entrada.Value == Índice_ID)
                                                                                                                    {
                                                                                                                        ID = Minecraft.Obtener_Valores_ID_Data(Entrada.Key, out Data);
                                                                                                                        break;
                                                                                                                    }
                                                                                                                }
                                                                                                                Chunk.Blocks.SetBlock(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, new AlphaBlock(ID, Data));
                                                                                                            }
                                                                                                            else Chunk.Blocks.SetBlock(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, new AlphaBlock(0, 0)); // Air.
                                                                                                        }
                                                                                                        else Chunk.Blocks.SetBlock(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, new AlphaBlock(0, 0)); // Air.
                                                                                                    }
                                                                                                    else // This could be faster...
                                                                                                    {
                                                                                                        short Índice_ID = Minecraft.Bloques.Diccionario_Nombre_Índice[Lista_Bloques_Pixel_Art[Matriz_Índices_Pixel_Art[Índice_Pixel_Art]]];
                                                                                                        byte ID = 0; // Air.
                                                                                                        byte Data = 0; // Default Air.
                                                                                                        foreach (KeyValuePair<short, short> Entrada in Minecraft.Diccionario_Bloques_Índices_1_12_2_a_Índices_1_13)
                                                                                                        {
                                                                                                            if (Pendiente_Subproceso_Abortar)
                                                                                                            {
                                                                                                                Pendiente_Subproceso_Abortar = false;
                                                                                                                Archivo_Región = null; // Dispose the current region file.
                                                                                                                Chunks.Save(); // Save the part of the chunks already generated.
                                                                                                                Chunks = null;
                                                                                                                Bloques = null;
                                                                                                                Mundo.Save(); // Save the part of the world already generated.
                                                                                                                Mundo = null;
                                                                                                                Subproceso_Abortado = true;
                                                                                                                return; // Cancel safely before time.
                                                                                                            }
                                                                                                            if (Entrada.Value == Índice_ID)
                                                                                                            {
                                                                                                                ID = Minecraft.Obtener_Valores_ID_Data(Entrada.Key, out Data);
                                                                                                                break;
                                                                                                            }
                                                                                                        }
                                                                                                        Chunk.Blocks.SetBlock(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, new AlphaBlock(ID, Data));
                                                                                                    }
                                                                                                    if (CheckBox_Forzar_Luz_Máxima.Checked) // Force a maximum light level in the whole world.
                                                                                                    {
                                                                                                        Chunk.Blocks.SetBlockLight(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, 15);
                                                                                                        //Chunk.Blocks.SetSkyLight(Índice_X, Sección_Y_16 + Índice_Y, Índice_Z, 15);
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        // Dispose some used variables.
                                                                                        Matriz_Bytes = null;
                                                                                    }
                                                                                }
                                                                            }
                                                                            //else MessageBox.Show(""); // Several blocks are missing after the conversion?...
                                                                            Bloques_Convertidos += 4096L; // Add a full block section.
                                                                        }
                                                                    }
                                                                    Chunk.Blocks.RebuildHeightMap();
                                                                    if (!CheckBox_Forzar_Luz_Máxima.Checked) Chunk.Blocks.RebuildBlockLight();
                                                                    Chunk.Blocks.RebuildSkyLight();
                                                                }
                                                            }
                                                            //Chunk.Matriz_Bytes_ID = Matriz_Índices_Bloques_XYZ.Clone() as int[,,];
                                                            //Matriz_Chunks[Chunk_X, Chunk_Z] = Chunk;
                                                        }
                                                    }
                                                    //else MessageBox.Show("Fallo al descodificar...");
                                                }
                                            }
                                        }
                                    }
                                    Chunks.Save(); // Save the chunks of the new region to save RAM memory.
                                    Archivo_Región = null;
                                    Progreso_Chunk = 0;
                                    Progreso_Región++;
                                    Etiqueta_Progreso_Chunk.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Chunk, "Chunk progress: " + Program.Traducir_Número_Decimales_Redondear(((double)Progreso_Chunk * 100d) / 1024d, 4) + " % (" + Program.Traducir_Número(Progreso_Chunk) + " of 1.024 chunks)" });
                                    Etiqueta_Progreso_Región.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Región, "Region progress: " + Program.Traducir_Número_Decimales_Redondear((((double)Progreso_Región + (Progreso_Chunk / 1024d)) * 100d) / (double)Total_Regiones, 4) + " % (" + Program.Traducir_Número(Progreso_Región) + " of " + Program.Traducir_Número(Total_Regiones) + (Total_Regiones != 1L ? " regions)" : " region)") });
                                    Barra_Progreso_Chunk.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Chunk, Progreso_Chunk });
                                    Barra_Progreso_Región.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Región, Progreso_Región });
                                    GC.Collect(); // Recover RAM memory after every region file.
                                    GC.GetTotalMemory(true);
                                }
                            }
                        }
                        Chunks.Save();
                        Chunks = null;
                        Bloques = null;
                    }
                }
                Mundo.Save();
                Mundo = null;
                Progreso_Chunk = 1024; // Force all the progress bars to it's maximum values.
                Progreso_Región = Total_Regiones;
                Etiqueta_Progreso_Chunk.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Chunk, "Chunk progress: " + Program.Traducir_Número_Decimales_Redondear(((double)Progreso_Chunk * 100d) / 65536d, 4) + " % (" + Program.Traducir_Número(Progreso_Chunk) + " of 1.024 chunks)" });
                Etiqueta_Progreso_Región.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Región, "Region progress: " + Program.Traducir_Número_Decimales_Redondear(((double)Progreso_Región * 100d) / (double)Total_Regiones, 4) + " % (" + Program.Traducir_Número(Progreso_Región) + " of " + Program.Traducir_Número(Total_Regiones) + (Total_Regiones != 1L ? " regions)" : " region)") });
                Barra_Progreso_Chunk.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Chunk, Barra_Progreso_Chunk.Maximum });
                Barra_Progreso_Región.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Región, Barra_Progreso_Región.Maximum });
                //this.Activate(); // This need to be invoked in a thread like the rest.
                //double Chunks_Convertidos = Bloques_Convertidos / 65536d; // 1 chunk in blocks.
                double Regiones_Convertidas = Bloques_Convertidos / 67108864d; // 1 region in blocks.
                if ((DialogResult)this.Invoke(new Invocación.Delegado_IWin32Window_MessageBox(Invocación.Ejecutar_Delegado_IWin32Window_MessageBox), new object[] { this, "The new world has been successfully generated. You'll find it here:\r\n\r\n\"" + Ruta + "\".\r\n\r\nBlocks converted: " + Program.Traducir_Número(Bloques_Convertidos) + (Bloques_Convertidos != 1L ? " blocks" : " block") + " (" + Program.Traducir_Número_Decimales_Redondear(Regiones_Convertidas, 4) + (Regiones_Convertidas != 1d ? " regions" : " region") + ").\r\nYou'll probably find it at the bottom of your Minecraft world list.\r\n\r\nDo you want to open now the folder with your converted world?", Program.Texto_Título_Versión, MessageBoxButtons.YesNoCancel, Bloques_Convertidos > 0L ? MessageBoxIcon.Information : MessageBoxIcon.Warning }) == DialogResult.Yes)
                {
                    Program.Ejecutar_Ruta(Ruta, ProcessWindowStyle.Maximized);
                }
                //Lista_Propiedades_Ejemplos.Sort(); // Used to extract all the properties from a debug world.
                //File.WriteAllLines(Program.Obtener_Ruta_Temporal_Escritorio() + ".txt", Lista_Propiedades_Ejemplos.ToArray(), Encoding.Unicode);
                if (Diccionario_Bloques_Desconocidos.Count > 0) // Warn of possible future unknown blocks.
                {
                    foreach (KeyValuePair<string, object> Entrada in Diccionario_Bloques_Desconocidos)
                    {
                        Bloques_Desconocidos += "\"" + Entrada.Key + "\",\r\n";
                    } // Tip: press CTRL+C on the message to copy the unknown block names as text.
                    this.Invoke(new Invocación.Delegado_IWin32Window_MessageBox(Invocación.Ejecutar_Delegado_IWin32Window_MessageBox), new object[] { this, "Unknown blocks found replaced by air: " + Program.Traducir_Número(Diccionario_Bloques_Desconocidos.Count) + ".\r\n\r\n" + Bloques_Desconocidos.TrimEnd(",\r\n".ToCharArray()) + ".", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning });
                }
                Cronómetro_Total.Reset();
                Cronómetro_Total = null;
            }
            catch (ThreadAbortException) { } // Aborted, ignore this exception.
            catch (OutOfMemoryException Excepción)
            {
                Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true;
            }
            catch (Exception Excepción)
            {
                Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true;
            }
            finally
            {
                this.Invoke(new Invocación.Delegado_Control_Cursor(Invocación.Ejecutar_Delegado_Control_Cursor), new object[] { this, Cursors.Default });
                Pendiente_Subproceso_Abortar = false;
                Subproceso_Activo = false;
                Subproceso = null;
                GC.Collect(); // Recover RAM memory at the end.
                GC.GetTotalMemory(true);
                // Reset all the progress bars.
                this.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { this, Texto_Título + " - [The original world files will never be modified]" });
                Etiqueta_Progreso_Chunk.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Chunk, "Chunk progress: 0,0000 % (0 of 1.024 chunks)" });
                Etiqueta_Progreso_Región.Invoke(new Invocación.Delegado_Control_Text(Invocación.Ejecutar_Delegado_Control_Text), new object[] { Etiqueta_Progreso_Región, "Region progress: 0,0000 % (0 of 0 regions)" });
                Barra_Progreso_Chunk.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Chunk, 0 });
                Barra_Progreso_Región.Invoke(new Invocación.Delegado_ProgressBar_Value(Invocación.Ejecutar_Delegado_ProgressBar_Value), new object[] { Barra_Progreso_Región, 0 });
                ComboBox_Ruta_Mundo_1_13.Invoke(new Invocación.Delegado_Control_Enabled(Invocación.Ejecutar_Delegado_Control_Enabled), new object[] { ComboBox_Ruta_Mundo_1_13, true });
                Botón_Convertir.Invoke(new Invocación.Delegado_Control_Enabled(Invocación.Ejecutar_Delegado_Control_Enabled), new object[] { Botón_Convertir, true });
                if (!Subproceso_Abortado)
                {
                    Botón_Convertir.Invoke(new Invocación.Delegado_Control_Select(Invocación.Ejecutar_Delegado_Control_Select), new object[] { Botón_Convertir });
                    Botón_Convertir.Invoke(new Invocación.Delegado_Control_Focus(Invocación.Ejecutar_Delegado_Control_Focus), new object[] { Botón_Convertir });
                }
                else this.Close(); // Close the window.
            }
        }
    }
}

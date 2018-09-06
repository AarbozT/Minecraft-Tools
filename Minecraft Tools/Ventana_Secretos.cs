using Minecraft_Tools.Properties;
using SevenZip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Secretos : Form
    {
        public Ventana_Secretos()
        {
            InitializeComponent();
        }

        internal readonly string Texto_Título = "Secrets for " + Program.Texto_Usuario + " by Jupisoft";
        internal bool Variable_Siempre_Visible = false;
        internal bool Variable_Excepción = false;
        //internal bool Variable_Excepción_Imagen = false;
        internal int Variable_Excepción_Total = 0;
        //internal bool Variable_Memoria = false;
        //internal static Stopwatch Cronómetro_FPS = Stopwatch.StartNew();
        //internal long Segundo_FPS_Anterior = 0L;
        //internal long FPS_Temporal = 0L;
        //internal long FPS_Real = 0L;

        private void Ventana_Secretos_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Texto_Título;
                //this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Secretos_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                //Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Secretos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Secretos_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Secretos_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Secretos_KeyDown(object sender, KeyEventArgs e)
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
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Nombre_Usuario_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Botón_Mostrar_Secretos.Enabled = CheckBox_Nombre_Usuario.Checked && !string.IsNullOrEmpty(TextBox_Nombre_Usuario.Text) && string.Compare(TextBox_Nombre_Usuario.Text, Program.Texto_Usuario, true) == 0;
                if (CheckBox_Nombre_Usuario.Enabled) Botón_Mostrar_Secretos.Image = Botón_Mostrar_Secretos.Enabled ? Resources.Ojo : Resources.Ojo_Ciego;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void TextBox_Nombre_Usuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Botón_Mostrar_Secretos.Enabled = CheckBox_Nombre_Usuario.Checked && !string.IsNullOrEmpty(TextBox_Nombre_Usuario.Text) && string.Compare(TextBox_Nombre_Usuario.Text, Program.Texto_Usuario, true) == 0;
                if (TextBox_Nombre_Usuario.Enabled) Botón_Mostrar_Secretos.Image = Botón_Mostrar_Secretos.Enabled ? Resources.Ojo : Resources.Ojo_Ciego;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void TextBox_Nombre_Usuario_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    TextBox_Nombre_Usuario.Text = Program.Texto_Usuario;
                    SystemSounds.Asterisk.Play();
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Mostrar_Secretos_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBox_Nombre_Usuario.Enabled = false;
                TextBox_Nombre_Usuario.Enabled = false;
                Botón_Mostrar_Secretos.Enabled = false;
                Etiqueta_Advertencia.ForeColor = Color.Red;
                Etiqueta_Advertencia.Text = "Please use the new buttons below to decrypt and export the secret files, but use them ONLY for learning purposes and never distribute them or do anything illegal with them. YOU'VE BEEN WARNED!";

                // Enable the sectret buttons:
                Botón_Packs_Recursos_Adventure_Time.Enabled = true;
                Botón_Packs_Recursos_Candy.Enabled = true;
                Botón_Packs_Recursos_Cartoon.Enabled = true;
                Botón_Packs_Recursos_Chinese_Mythology.Enabled = true;
                Botón_Packs_Recursos_City.Enabled = true;
                Botón_Packs_Recursos_Fallout.Enabled = true;
                Botón_Packs_Recursos_Fantasy.Enabled = true;
                Botón_Packs_Recursos_Festive.Enabled = true;
                Botón_Packs_Recursos_Greek_Mythology.Enabled = true;
                Botón_Packs_Recursos_Halloween.Enabled = true;
                Botón_Packs_Recursos_Halloween_2015.Enabled = true;
                Botón_Packs_Recursos_Halo.Enabled = true;
                Botón_Packs_Recursos_Mass_Effect.Enabled = true;
                Botón_Packs_Recursos_Natural.Enabled = true;
                Botón_Packs_Recursos_Pattern.Enabled = true;
                Botón_Packs_Recursos_Plastic.Enabled = true;
                Botón_Packs_Recursos_Skyrim.Enabled = true;
                Botón_Packs_Recursos_Steampunk.Enabled = true;

                Botón_Packs_Skins_2nd_Birthday.Enabled = true;
                Botón_Packs_Skins_3rd_Birthday_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_4th_Birthday_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Adventure_Time.Enabled = true;
                Botón_Packs_Skins_Battle_Beasts.Enabled = true;
                Botón_Packs_Skins_Battle_Beasts_2.Enabled = true;
                Botón_Packs_Skins_Biome_Settlers_Pack_1.Enabled = true;
                Botón_Packs_Skins_Birthday_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Campfire_Tales_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Chinese_Mythology.Enabled = true;
                Botón_Packs_Skins_Doctor_Who_Skins_Volume_I.Enabled = true;
                Botón_Packs_Skins_Doctor_Who_Skins_Volume_II.Enabled = true;
                Botón_Packs_Skins_Fallout.Enabled = true;
                Botón_Packs_Skins_Festive.Enabled = true;
                Botón_Packs_Skins_Festive_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Greek_Mythology.Enabled = true;
                Botón_Packs_Skins_Halloween_2015.Enabled = true;
                Botón_Packs_Skins_Halloween_Charity_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Halo.Enabled = true;
                Botón_Packs_Skins_Magic_The_Gathering_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Marvel_Avengers.Enabled = true;
                Botón_Packs_Skins_Marvel_Guardians_of_the_Galaxy.Enabled = true;
                Botón_Packs_Skins_Marvel_Spider_Man.Enabled = true;
                Botón_Packs_Skins_Mass_Effect.Enabled = true;
                Botón_Packs_Skins_Minecon_2015_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Mini_Game_Masters_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Power_Rangers_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Redstone_Specialists_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Skin_Pack_1.Enabled = true;
                Botón_Packs_Skins_Skin_Pack_2.Enabled = true;
                Botón_Packs_Skins_Skin_Pack_3.Enabled = true;
                Botón_Packs_Skins_Skin_Pack_4.Enabled = true;
                Botón_Packs_Skins_Skin_Pack_5.Enabled = true;
                Botón_Packs_Skins_Skin_Pack_6.Enabled = true;
                Botón_Packs_Skins_Skyrim.Enabled = true;
                Botón_Packs_Skins_Star_Wars_Classic_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Star_Wars_Prequel_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Star_Wars_Rebels_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Story_Mode_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_Summer_of_Arcade_Skin_Pack.Enabled = true;
                Botón_Packs_Skins_The_Simpsons.Enabled = true;
                Botón_Packs_Skins_Villains_Skin_Pack.Enabled = true;

                Botón_Minecraft_JAR_1_0_0.Enabled = true;
                Botón_Minecraft_JAR_1_1_0.Enabled = true;
                Botón_Minecraft_JAR_1_2_5.Enabled = true;
                Botón_Minecraft_JAR_1_3_2.Enabled = true;
                Botón_Minecraft_JAR_1_4_7.Enabled = true;
                Botón_Minecraft_JAR_1_5_2.Enabled = true;
                Botón_Minecraft_JAR_1_6_4.Enabled = true;
                Botón_Minecraft_JAR_1_7_10.Enabled = true;
                Botón_Minecraft_JAR_1_8_8.Enabled = true;
                Botón_Minecraft_JAR_1_9_4.Enabled = true;
                Botón_Minecraft_JAR_1_10.Enabled = true;
                Botón_Minecraft_JAR_1_11_2.Enabled = true;
                Botón_Minecraft_JAR_1_12.Enabled = true;
                Botón_Minecraft_JAR_1_13_1.Enabled = true;

                Botón_Minecraft_1_0_0.Enabled = true;
                Botón_Minecraft_1_1_0.Enabled = true;
                Botón_Minecraft_1_2_5.Enabled = true;
                Botón_Minecraft_1_3_2.Enabled = true;
                Botón_Minecraft_1_4_7.Enabled = true;
                Botón_Minecraft_1_5_2.Enabled = true;
                Botón_Minecraft_1_6_4.Enabled = true;
                Botón_Minecraft_1_7_10.Enabled = true;
                Botón_Minecraft_1_8_8.Enabled = true;
                Botón_Minecraft_1_9_4.Enabled = true;
                Botón_Minecraft_1_10.Enabled = true;
                Botón_Minecraft_1_11_2.Enabled = true;
                Botón_Minecraft_1_12.Enabled = true;
                //Botón_Minecraft_1_13.Enabled = true;

                Botón_26601_Skins.Enabled = true;
                Botón_Fuente_Alfabeto_Galáctico.Enabled = true;

                Botón_Packs_Recursos_Adventure_Time.Select();
                Botón_Packs_Recursos_Adventure_Time.Focus();
                SystemSounds.Asterisk.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_0_0_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\EC22248B", "Minecraft 1.0.0 source code", ".zip"); // Couldn't find the Minecraft 1.0.0 server jar file.
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_1_0_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\810486E4", "Minecraft 1.1.0 source code", ".zip"); // Couldn't find the Minecraft 1.1.0 server jar file.
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_2_5_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\98F3C532", "Minecraft 1.2.5 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_3_2_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\ED9DE6E4", "Minecraft 1.3.2 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_4_7_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\9B053B77", "Minecraft 1.4.7 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_5_2_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\62B6F330", "Minecraft 1.5.2 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_6_4_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\7B7F95E6", "Minecraft 1.6.4 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_7_10_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\54BD5A59", "Minecraft 1.7.10 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_8_8_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\72B08AC6", "Minecraft 1.8.8 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_9_4_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\7CCDACF0", "Minecraft 1.9.4 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_10_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\D058CD75", "Minecraft 1.10 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_11_2_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\526FA4DF", "Minecraft 1.11.2 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_12_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\7C6FC8D9", "Minecraft 1.12 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_1_13_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Sources\\00000000", "Minecraft 1.13 source code", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_0_0_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mediafire.com/?s7dyeugk867no9j", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_1_0_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mediafire.com/?wu9gfhy73m4k6a4", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_2_5_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mediafire.com/?c6liau295225253", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_3_2_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mediafire.com/?38vjh7hrpprrw1b", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_4_7_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mediafire.com/?07d59w314ewjfth", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_5_2_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mediafire.com/?95vlzp1a4n4wjqw", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_6_4_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mediafire.com/?96mrmeo57cdf6zv", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_7_10_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.modcoderpack.com/files/mcp908.zip", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_8_8_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.modcoderpack.com/files/mcp918.zip", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_9_4_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.modcoderpack.com/files/mcp928.zip", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_10_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.modcoderpack.com/files/mcp931.zip", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_11_2_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.modcoderpack.com/files/mcp937.zip", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_12_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.modcoderpack.com/files/mcp940.zip", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Minecraft_1_13_Click(object sender, EventArgs e)
        {
            try
            {
                SystemSounds.Beep.Play();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_26601_Skins_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\A24938DB", "26601 Minecraft Skins", ".rar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Fuente_Alfabeto_Galáctico_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Others\\DD08ECF8", "Standard Galactic Alphabet font", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_26601_Skins_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://www.mediafire.com/file/rhbf9vd9e002170/26601+Minecraft+Skins.rar", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Fuente_Alfabeto_Galáctico_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("http://legacy.3drealms.com/stuff/sga_ttf.zip", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Wikipedia_Alfabeto_Galáctico_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.minecraftforum.net/forums/minecraft-java-edition/discussion/157963-the-standard-galactic-alphabet", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Descargar_Xbox_360_Tutoriales_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Ejecutar_Ruta("https://www.minecraftforum.net/forums/mapping-and-modding-java-edition/maps/maps-discussion/1557054-xbox-360-edition-tutorial-world-maps-for-pc", ProcessWindowStyle.Normal);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        /// <summary>
        /// Function designed to decrypt and export any existing file.
        /// WARNING: using any part of this code to decrypt any of the "secret" files
        /// on your own will be like if you gave your consent to all of the
        /// requirements needed in order to be able to export the files
        /// using regularly the application, so again... YOU'VE BEEN WARNED!
        /// </summary>
        /// <param name="Ruta_Secreto">Any valid and existing file path.</param>
        internal void Desencriptar_Exportar_Archivo_Secreto(string Ruta_Secreto, string Nombre_Secreto, string Extensión)
        {
            try
            {
                if (!string.IsNullOrEmpty(Ruta_Secreto) && !string.IsNullOrEmpty(Nombre_Secreto) && File.Exists(Ruta_Secreto))
                {
                    if (string.IsNullOrEmpty(Extensión)) Extensión = ".zip";
                    Program.Crear_Carpetas(Program.Ruta_Guardado_Imágenes_Secretos);
                    string Ruta_Extensión = Program.Ruta_Guardado_Imágenes_Secretos + "\\" + Nombre_Secreto;
                    Program.Quitar_Atributo_Sólo_Lectura(Ruta_Secreto);
                    FileStream Lector = new FileStream(Ruta_Secreto, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                    if (Lector != null && Lector.Length > 0L)
                    {
                        Lector.Seek(0L, SeekOrigin.Begin);
                        while (File.Exists(Ruta_Extensión + Extensión)) Ruta_Extensión += "_"; // Be sure the file doesn't exist.
                        Ruta_Extensión += Extensión;
                        FileStream Lector_ZIP = new FileStream(Ruta_Extensión, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                        Lector_ZIP.SetLength(0L); // Be sure the file is empty.
                        Lector_ZIP.Seek(0L, SeekOrigin.Begin);
                        bool Desencriptar = true;
                        try
                        {
                            // Verify if the zip file can be loaded, meaning it isn't encrypted.
                            SevenZipExtractor Extractor_7_Zip = new SevenZipExtractor(Lector);
                            if (Extractor_7_Zip != null && Extractor_7_Zip.FilesCount > 0 && Extractor_7_Zip.Check())
                            {
                                Desencriptar = false; // The file somehow isn't encrypted.
                            }
                            Extractor_7_Zip = null; // Don't dispose this or it'll close the input file.
                        }
                        catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
                        byte[] Matriz_Bytes = new byte[4096];
                        for (long Índice_Bloque = 0L; Índice_Bloque < Lector.Length; Índice_Bloque += 4096L)
                        {
                            Lector.Seek(Índice_Bloque, SeekOrigin.Begin); // This might be optional.
                            int Longitud = Lector.Read(Matriz_Bytes, 0, Matriz_Bytes.Length);
                            if (Longitud > 0)
                            {
                                if (Desencriptar) Matriz_Bytes = Jupisoft_Encrypting_Decrypting.Desencriptar_Matriz_Bytes(Matriz_Bytes, true, false, true, false);
                                Lector_ZIP.Seek(Índice_Bloque, SeekOrigin.Begin); // This might be optional.
                                Lector_ZIP.Write(Matriz_Bytes, 0, Longitud); // Write the decrypted byte array.
                            }
                            else break;
                        }
                        Lector.Close(); // Close the input file.
                        Lector.Dispose();
                        Lector = null;
                        Lector_ZIP.Close(); // Close the output file.
                        Lector_ZIP.Dispose();
                        Lector_ZIP = null;
                        Program.Ejecutar_Ruta(Program.Ruta_Guardado_Imágenes_Secretos, ProcessWindowStyle.Maximized);
                    }
                    else SystemSounds.Beep.Play();
                }
                else MessageBox.Show(this, "The desired encrypted secret file couldn't be found.\r\nMake sure you have downloaded the \"full version\" of this application (the one which includes all the optional files, including the secret ones).", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Adventure_Time_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\269BB7A4", "Console Adventure Time", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Candy_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\89483C6D", "Console Candy", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Cartoon_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\CF7FB669", "Console Cartoon", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Chinese_Mythology_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\C57D709B", "Console Chinese Mythology", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_City_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\34C2F8A8", "Console City", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Fallout_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\F512D9CB", "Console Fallout", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Fantasy_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\42E12AC6", "Console Fantasy", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Festive_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\E86DD8D1", "Console Festive", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Greek_Mythology_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\D5F7FC0B", "Console Greek Mythology", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Halloween_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\E9D6C865", "Console Halloween", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Halloween_2015_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\FF4896C0", "Console Halloween 2015", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Halo_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\EB1255D9", "Console Halo", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Mass_Effect_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\72D44EAC", "Console Mass Effect", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Natural_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\118FA1D5", "Console Natural", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Pattern_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\75955242", "Console Pattern", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Plastic_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\47D86650", "Console Plastic", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Skyrim_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\680A9114", "Console Skyrim", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Recursos_Steampunk_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Resources\\CBA3979D", "Console Steampunk", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_2nd_Birthday_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\6CFC63B7", "2nd Birthday", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_3rd_Birthday_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\437C4660", "3rd Birthday Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_4th_Birthday_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\8003522", "4th Birthday Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Adventure_Time_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\3CBE35FB", "Adventure Time", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Battle_Beasts_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\E0F86053", "Battle & Beasts", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Battle_Beasts_2_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\35EC2BE3", "Battle & Beasts 2", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Biome_Settlers_Pack_1_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\2BB7998E", "Biome Settlers Pack 1", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Birthday_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\B12FE96A", "Birthday Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Campfire_Tales_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\A4AEE16C", "Campfire Tales Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Chinese_Mythology_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\BC278B06", "Chinese Mythology", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Doctor_Who_Skins_Volume_I_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\FE7F1F10", "Doctor Who Skins Volume I", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Doctor_Who_Skins_Volume_II_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\65B5D112", "Doctor Who Skins Volume II", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Fallout_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\A7C1F72C", "Fallout", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Festive_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\DED3A288", "Festive", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Festive_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\30FF6565", "Festive Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Greek_Mythology_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\67ACC6FF", "Greek Mythology", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Halloween_2015_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\B198CD49", "Halloween 2015", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Halloween_Charity_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\FCBDB984", "Halloween Charity Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Halo_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\2F12D85B", "Halo", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Magic_The_Gathering_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\622D9DAB", "Magic The Gathering Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Marvel_Avengers_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\688711E4", "Marvel Avengers", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Marvel_Guardians_of_the_Galaxy_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\89F83E2D", "Marvel Guardians of the Galaxy", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Marvel_Spider_Man_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\FC5E8B6E", "Marvel Spider-Man", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Mass_Effect_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\BEFB1F9F", "Mass Effect", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Minecon_2015_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\A53ECB15", "Minecon 2015 Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Mini_Game_Masters_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\C2189632", "Mini Game Masters Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Power_Rangers_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\AFB257C2", "Power Rangers Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Redstone_Specialists_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\3B9CAE45", "Redstone Specialists Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Skin_Pack_1_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\C7D5C98A", "Skin Pack 1", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Skin_Pack_2_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\9FF4FCEE", "Skin Pack 2", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Skin_Pack_3_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\8C2D7039", "Skin Pack 3", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Skin_Pack_4_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\14D1BD29", "Skin Pack 4", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Skin_Pack_5_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\1B0C2589", "Skin Pack 5", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Skin_Pack_6_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\DE93409", "Skin Pack 6", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Skyrim_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\EFA4B512", "Skyrim", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Star_Wars_Classic_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\18F1442D", "Star Wars Classic Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Star_Wars_Prequel_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\7025C634", "Star Wars Prequel Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Star_Wars_Rebels_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\5341A607", "Star Wars Rebels Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Story_Mode_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\5987E9B2", "Story Mode Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Summer_of_Arcade_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\9871C4F3", "Summer of Arcade Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_The_Simpsons_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\F2B4919C", "The Simpsons", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Packs_Skins_Villains_Skin_Pack_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Skins\\E7C858B1", "Villains Skin Pack", ".zip");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_0_0_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\C560F3F7", "1.0", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_1_0_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\85DE36A1", "1.1", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_2_5_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\E09534B2", "1.2.5", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_3_2_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\FC727F44", "1.3.2", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_4_7_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\555EDD3B", "1.4.7", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_5_2_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\25642598", "1.5.2", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_6_4_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\46477526", "1.6.4", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_7_10_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\6BBD3EA2", "1.7.10", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_8_8_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\CCD6E5FA", "1.8.8", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_9_4_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\65EAB3B8", "1.9.4", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_10_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\76949A07", "1.10", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_11_2_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\C3242F08", "1.11.2", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_12_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\FF9D499D", "1.12", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Botón_Minecraft_JAR_1_13_1_Click(object sender, EventArgs e)
        {
            try
            {
                Desencriptar_Exportar_Archivo_Secreto(Application.StartupPath + "\\Secrets\\Versions\\EBC7ECA1", "1.13.1", ".jar");
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Visor_Información_Bloques : Form
    {
        public Ventana_Visor_Información_Bloques()
        {
            InitializeComponent();
        }

        internal readonly string Texto_Título = "Block Information Viewer for " + Program.Texto_Usuario + " by Jupisoft";
        internal bool Variable_Siempre_Visible = false;
        internal bool Variable_Excepción = false;
        internal bool Variable_Excepción_Imagen = false;
        internal int Variable_Excepción_Total = 0;
        internal bool Variable_Memoria = false;
        internal static Stopwatch Cronómetro_FPS = Stopwatch.StartNew();
        internal long Segundo_FPS_Anterior = 0L;
        internal long FPS_Temporal = 0L;
        internal long FPS_Real = 0L;

        private void Ventana_Visor_Información_Entidades_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Texto_Título;
                this.WindowState = FormWindowState.Maximized;
                if (Minecraft.Bloques.Matriz_Bloques != null && Minecraft.Bloques.Matriz_Bloques.Length > 0)
                {
                    for (int Índice_Bloque = 0; Índice_Bloque < Minecraft.Bloques.Matriz_Bloques.Length; Índice_Bloque++)
                    {
                        DataGridView_Principal.Rows.Add(new object[]
                        {
                            Program.Obtener_Imagen_Miniatura(Program.Obtener_Imagen_Recursos(Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Recurso), 32, 32, true, false),
                            Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Nombre,
                            Program.Obtener_Nombre_Invertido(Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Nombre),
                            Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Nombre_1_13,
                            //Program.Traducir_Lista_Variables(Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Lista_ID),
                            Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Lista_ID != null && Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Lista_ID.Count > 0 ? (int)Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Lista_ID[0] : -1,
                            Program.Traducir_Lista_Variables(Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Lista_Data),
                            Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Color_ARGB,
                            Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Código_Hash_Color,
                            Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Altura_Diferente,
                            Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Obtención,
                            Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Transparencia,
                            Minecraft.Bloques.Matriz_Bloques[Índice_Bloque].Obsoleto
                        });
                    }
                    DataGridView_Principal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DataGridView_Principal.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    DataGridView_Principal.Sort(Columna_Nombre, ListSortDirection.Ascending);
                    if (DataGridView_Principal.Rows.Count > 0)
                    {
                        this.Text = Texto_Título + " - [Minecraft blocks known: " + Program.Traducir_Número(DataGridView_Principal.Rows.Count) + "]";
                        DataGridView_Principal.CurrentCell = DataGridView_Principal[Columna_Nombre.Index, 0];
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        /*new Bloques[]
        {
            
            
                                                                    







        };*/

        private void Ventana_Visor_Información_Entidades_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Información_Entidades_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Información_Entidades_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Visor_Información_Entidades_KeyDown(object sender, KeyEventArgs e)
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
                    else if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        string Tecla = e.KeyCode.ToString();
                        string Letra = Tecla[Tecla.Length - 1].ToString().ToUpperInvariant();
                        int Índice_Columna_Actual = DataGridView_Principal.CurrentCell != null ? DataGridView_Principal.CurrentCell.ColumnIndex : Columna_Nombre.Index;
                        int Índice_Fila_Actual = DataGridView_Principal.CurrentCell != null ? DataGridView_Principal.CurrentCell.RowIndex : -1;
                        for (int Índice_Fila = 0; Índice_Fila < DataGridView_Principal.Rows.Count; Índice_Fila++)
                        {
                            string Nombre = null;
                            try { Nombre = DataGridView_Principal[Índice_Columna_Actual, Índice_Fila].Value.ToString(); }
                            catch { Nombre = null; }
                            if (!string.IsNullOrEmpty(Nombre) && Nombre.StartsWith(Letra))
                            {
                                if (Índice_Fila != Índice_Fila_Actual)
                                {
                                    DataGridView_Principal.CurrentCell = DataGridView_Principal[Índice_Columna_Actual, Índice_Fila];
                                    return;
                                }
                                else
                                {
                                    Índice_Fila_Actual = int.MaxValue;
                                    break;
                                }
                            }
                        }
                        if (Índice_Fila_Actual >= int.MaxValue) // Do an inverted search.
                        {
                            for (int Índice_Fila = DataGridView_Principal.Rows.Count - 1; Índice_Fila >= 0; Índice_Fila--)
                            {
                                string Nombre = null;
                                try { Nombre = DataGridView_Principal[Índice_Columna_Actual, Índice_Fila].Value.ToString(); }
                                catch { Nombre = null; }
                                if (!string.IsNullOrEmpty(Nombre) && Nombre.StartsWith(Letra))
                                {
                                    DataGridView_Principal.CurrentCell = DataGridView_Principal[Índice_Columna_Actual, Índice_Fila];
                                    return;
                                }
                            }
                        }
                        SystemSounds.Beep.Play(); // Nothing found starting with the pressed letter.
                    }
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
                long Milisegundo_FPS = Cronómetro_FPS.ElapsedMilliseconds;
                long Segundo_FPS = Milisegundo_FPS / 1000L;
                if (Segundo_FPS != Segundo_FPS_Anterior)
                {
                    Segundo_FPS_Anterior = Segundo_FPS;
                    FPS_Real = FPS_Temporal;
                    Barra_Estado_Etiqueta_FPS.Text = FPS_Real.ToString() + " FPS";
                    FPS_Temporal = 0L;
                }
                FPS_Temporal++;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void DataGridView_Principal_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                Depurador.Escribir_Excepción(e.Exception != null ? e.Exception.ToString() : null);
                e.ThrowException = false;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void DataGridView_Principal_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    if (e.ColumnIndex > -1 && e.ColumnIndex < DataGridView_Principal.Columns.Count && e.RowIndex > -1 && e.RowIndex < DataGridView_Principal.Rows.Count)
                    {
                        string Nombre = DataGridView_Principal[e.ColumnIndex, e.RowIndex].Value.ToString();
                        if (!string.IsNullOrEmpty(Nombre))
                        {
                            Clipboard.SetText(Nombre);
                            DataGridView_Principal.CurrentCell = DataGridView_Principal[Columna_Nombre_1_13.Index, e.RowIndex];
                            SystemSounds.Asterisk.Play();
                        }
                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

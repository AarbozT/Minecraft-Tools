using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    internal static class Invocación
    {
        internal delegate void Delegado_ContextMenuStrip_Enabled(ContextMenuStrip Menú, bool Habilitar);
        internal delegate void Delegado_Control_BackColor(Control Control, Color Color_ARGB);
        internal delegate void Delegado_Control_Cursor(Control Control, Cursor Cursor);
        internal delegate void Delegado_Control_Enabled(Control Control, bool Habilitar);
        internal delegate void Delegado_Control_Focus(Control Control);
        internal delegate void Delegado_Control_Invalidate(Control Control);
        internal delegate void Delegado_Control_Invalidate_Rectangle(Control Control, Rectangle Rectángulo);
        internal delegate void Delegado_Control_Invalidate_Update(Control Control);
        internal delegate void Delegado_Control_Select(Control Control);
        internal delegate void Delegado_Control_Text(Control Control, string Texto);
        internal delegate void Delegado_Control_Update(Control Control);
        internal delegate void Delegado_Control_Visible(Control Control, bool Visible);
        internal delegate DialogResult Delegado_IWin32Window_MessageBox(IWin32Window Control, string Texto, string Título, MessageBoxButtons Botones, MessageBoxIcon Icono);
        internal delegate void Delegado_NumericUpDown_Value(NumericUpDown Control, decimal Valor);
        internal delegate void Delegado_PictureBox_Image(PictureBox Picture, Image Imagen);
        internal delegate void Delegado_ProgressBar_Maximum(ProgressBar Control, int Valor);
        internal delegate void Delegado_ProgressBar_Minimum(ProgressBar Control, int Valor);
        internal delegate void Delegado_ProgressBar_Value(ProgressBar Control, int Valor);
        internal delegate void Delegado_TextBox_SelectionLength(TextBox Control, int Longitud);
        internal delegate void Delegado_TextBox_SelectionStart(TextBox Control, int Índice);
        internal delegate void Delegado_ToolStripLabel_Text(ToolStripLabel Control, string Texto);
        internal delegate void Delegado_ToolTip_SetToolTip(ToolTip Información_Contextual, Control Control, string Texto);
        internal delegate void Delegado_TreeView_Nodes_Add(TreeView Árbol, int Índice, TreeNode Nodo);

        internal static void Ejecutar_Delegado_ContextMenuStrip_Enabled(ContextMenuStrip Menú, bool Habilitar)
        {
            Menú.Enabled = Habilitar;
        }

        internal static void Ejecutar_Delegado_Control_BackColor(Control Control, Color Color_ARGB)
        {
            Control.BackColor = Color_ARGB;
        }

        internal static void Ejecutar_Delegado_Control_Cursor(Control Control, Cursor Cursor)
        {
            Control.Cursor = Cursor;
        }

        internal static void Ejecutar_Delegado_Control_Enabled(Control Control, bool Habilitar)
        {
            Control.Enabled = Habilitar;
        }

        internal static void Ejecutar_Delegado_Control_Focus(Control Control)
        {
            Control.Focus();
        }

        internal static void Ejecutar_Delegado_Control_Invalidate(Control Control)
        {
            Control.Invalidate();
        }

        internal static void Ejecutar_Delegado_Control_Invalidate_Rectangle(Control Control, Rectangle Rectángulo)
        {
            Control.Invalidate(Rectángulo);
        }

        internal static void Ejecutar_Delegado_Control_Invalidate_Update(Control Control)
        {
            Control.Invalidate();
            Control.Update();
        }

        internal static void Ejecutar_Delegado_Control_Select(Control Control)
        {
            Control.Select();
        }

        internal static void Ejecutar_Delegado_Control_Text(Control Control, string Texto)
        {
            Control.Text = Texto;
        }

        internal static void Ejecutar_Delegado_Control_Update(Control Control)
        {
            Control.Update();
        }

        internal static void Ejecutar_Delegado_Control_Visible(Control Control, bool Visible)
        {
            Control.Visible = Visible;
        }

        internal static DialogResult Ejecutar_Delegado_IWin32Window_MessageBox(IWin32Window Ventana, string Texto, string Título, MessageBoxButtons Botones, MessageBoxIcon Icono)
        {
            return MessageBox.Show(Ventana, Texto, Título, Botones, Icono);
        }

        internal static void Ejecutar_Delegado_NumericUpDown_Value(NumericUpDown Control, decimal Valor)
        {
            Control.Value = Valor;
        }

        internal static void Ejecutar_Delegado_PictureBox_Image(PictureBox Control, Image Imagen)
        {
            Control.Image = Imagen;
        }

        internal static void Ejecutar_Delegado_ProgressBar_Maximum(ProgressBar Control, int Valor)
        {
            Control.Maximum = Valor;
        }

        internal static void Ejecutar_Delegado_ProgressBar_Minimum(ProgressBar Control, int Valor)
        {
            Control.Minimum = Valor;
        }

        internal static void Ejecutar_Delegado_ProgressBar_Value(ProgressBar Control, int Valor)
        {
            Control.Value = Math.Min(Control.Maximum, Math.Max(Control.Minimum, Valor));
        }

        internal static void Ejecutar_Delegado_TextBox_SelectionLength(TextBox Control, int Longitud)
        {
            Control.SelectionLength = Longitud;
        }

        internal static void Ejecutar_Delegado_TextBox_SelectionStart(TextBox Control, int Índice)
        {
            Control.SelectionStart = Índice;
        }

        internal static void Ejecutar_Delegado_ToolStripLabel_Text(ToolStripLabel Control, string Texto)
        {
            try
            {
                Control.Text = Texto;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        internal static void Ejecutar_Delegado_ToolTip_SetToolTip(ToolTip Información_Contextual, Control Control, string Texto)
        {
            Información_Contextual.SetToolTip(Control, Texto);
        }

        internal static void Ejecutar_Delegado_TreeView_Nodes_Add(TreeView Árbol, int Índice, TreeNode Nodo)
        {
            Árbol.Nodes[Índice].Nodes.Add(Nodo);
        }

        /*internal delegate void Delegado_Rendimiento_Control(Control Control, String Texto);
        internal delegate void Delegado_Barra_Estado(String Texto_Frecuencia, String Texto_Volumen, String Texto_Tempo, String Texto_Nota);
        internal delegate void Delegado_Invalidate(Control Control);
        internal delegate void Delegado_Invalidate_Rectangle(Control Control, Rectangle Rectángulo);
        internal delegate void Delegado_Control(Control Control);
        internal delegate void Delegado_PictureBox_Image(PictureBox Control, Image Imagen);

        internal static void Ejecutar_Delegado_Rendimiento_Control(Control Control, String Texto)
        {
            Control.Text = Texto;
        }

        internal static void Ejecutar_Delegado_Barra_Estado(String Texto_1, String Texto_2, String Texto_3, String Texto_4)
        {
            Barra_Estado_Etiqueta_1.Text = Texto_1;
            Barra_Estado_Etiqueta_2.Text = Texto_2;
            Barra_Estado_Etiqueta_3.Text = Texto_3;
            Barra_Estado_Etiqueta_4.Text = Texto_4;
            Barra_Estado.Invalidate();
            //Barra_Estado.Invalidate();
            //Barra_Estado.Update();
        }

        internal static void Ejecutar_Delegado_Invalidate(Control Control)
        {
            Control.Invalidate();
            //Control.Update();
        }

        internal static void Ejecutar_Delegado_Invalidate_Rectangle(Control Control, Rectangle Rectángulo)
        {
            Control.Invalidate(Rectángulo);
            //Control.Update();
        }

        internal static void Ejecutar_Delegado_Refresh(Control Control)
        {
            Control.Refresh();
        }

        internal static void Ejecutar_Delegado_Update(Control Control)
        {
            Control.Update();
        }

        internal static void Ejecutar_Delegado_PictureBox_Image(PictureBox Control, Image Imagen)
        {
            Control.Image = Imagen;
            Control.Invalidate();
            Control.Update();
        }*/
    }
}

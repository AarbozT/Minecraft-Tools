using Microsoft.Win32;
using Minecraft_Tools.Properties;
using Substrate;
using Substrate.Core;
using Substrate.TileEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    public partial class Ventana_Codificador_Descodificador_Archivos : Form
    {
        public Ventana_Codificador_Descodificador_Archivos()
        {
            InitializeComponent();
        }

        internal readonly string Texto_Título = "File Encoder and Decoder for " + Program.Texto_Usuario + " by Jupisoft";
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
        internal static Dictionary<short, object> Diccionario_Paleta = null;

        private void Ventana_Plantilla_Load(object sender, EventArgs e)
        {
            try
            {
                if (Diccionario_Paleta == null || Diccionario_Paleta.Count < 256)
                {
                    Diccionario_Paleta = new Dictionary<short, object>();
                    /*Minecraft.Regiones Región = Minecraft.Cargar_Región(@"C:\Users\Jupisoft\AppData\Roaming\.minecraft\saves\Paleta 256 bloques\region", new Point(0, 0), true, true, true, true, true);
                    if (Región.Matriz_Chunks != null)
                    {
                        for (int Chunk_Z = 0; Chunk_Z <= 1; Chunk_Z++)
                        {
                            for (int Z = 0; Z < 16; Z++)
                            {
                                for (int X = 0; X < 16; X++)
                                {
                                    if (!Diccionario_Paleta.ContainsKey(Región.Matriz_Chunks[0, Chunk_Z].Matriz_Bytes_IDs[X, 1, Z]))
                                    {
                                        Diccionario_Paleta.Add(Región.Matriz_Chunks[0, Chunk_Z].Matriz_Bytes_IDs[X, 1, Z], null);
                                    }
                                }
                            }
                        }
                    }
                    string Texto = null;
                    foreach (KeyValuePair<short, object> Entrada in Diccionario_Paleta)
                    {
                        Texto += "Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice[\"" + Minecraft.Bloques.Diccionario_Índice_Nombre[Entrada.Key] + "\"], \"" + Minecraft.Bloques.Diccionario_Índice_Nombre[Entrada.Key] + "\");\r\n";
                    }
                    Clipboard.SetText(Texto);
                    SystemSounds.Asterisk.Play();*/
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:air"], "minecraft:air"); // Byte 0
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:acacia_fence"], "minecraft:acacia_fence");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:acacia_leaves"], "minecraft:acacia_leaves");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:acacia_log"], "minecraft:acacia_log");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:acacia_planks"], "minecraft:acacia_planks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:acacia_slab"], "minecraft:acacia_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:acacia_stairs"], "minecraft:acacia_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:andesite"], "minecraft:andesite");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:beacon"], "minecraft:beacon");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:bedrock"], "minecraft:bedrock");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:birch_fence"], "minecraft:birch_fence");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:birch_leaves"], "minecraft:birch_leaves");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:birch_log"], "minecraft:birch_log");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:birch_planks"], "minecraft:birch_planks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:birch_slab"], "minecraft:birch_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:birch_stairs"], "minecraft:birch_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_concrete"], "minecraft:black_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_glazed_terracotta"], "minecraft:black_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_shulker_box"], "minecraft:black_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_stained_glass"], "minecraft:black_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_stained_glass_pane"], "minecraft:black_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_terracotta"], "minecraft:black_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:black_wool"], "minecraft:black_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_concrete"], "minecraft:blue_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_glazed_terracotta"], "minecraft:blue_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_shulker_box"], "minecraft:blue_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_stained_glass"], "minecraft:blue_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_stained_glass_pane"], "minecraft:blue_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_terracotta"], "minecraft:blue_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:blue_wool"], "minecraft:blue_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:bone_block"], "minecraft:bone_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:bookshelf"], "minecraft:bookshelf");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brick_slab"], "minecraft:brick_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brick_stairs"], "minecraft:brick_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:bricks"], "minecraft:bricks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_concrete"], "minecraft:brown_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_glazed_terracotta"], "minecraft:brown_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_shulker_box"], "minecraft:brown_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_stained_glass"], "minecraft:brown_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_stained_glass_pane"], "minecraft:brown_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_terracotta"], "minecraft:brown_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:brown_wool"], "minecraft:brown_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:carved_pumpkin"], "minecraft:carved_pumpkin");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cauldron"], "minecraft:cauldron");
                    //Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:chest"], "minecraft:chest");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:chiseled_quartz_block"], "minecraft:chiseled_quartz_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:chiseled_red_sandstone"], "minecraft:chiseled_red_sandstone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:chiseled_sandstone"], "minecraft:chiseled_sandstone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:chiseled_stone_bricks"], "minecraft:chiseled_stone_bricks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:clay"], "minecraft:clay");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:coal_block"], "minecraft:coal_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:coal_ore"], "minecraft:coal_ore");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:coarse_dirt"], "minecraft:coarse_dirt");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cobblestone"], "minecraft:cobblestone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cobblestone_slab"], "minecraft:cobblestone_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cobblestone_stairs"], "minecraft:cobblestone_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cobblestone_wall"], "minecraft:cobblestone_wall");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:command_block"], "minecraft:command_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cracked_stone_bricks"], "minecraft:cracked_stone_bricks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:crafting_table"], "minecraft:crafting_table");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cut_red_sandstone"], "minecraft:cut_red_sandstone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cut_sandstone"], "minecraft:cut_sandstone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_concrete"], "minecraft:cyan_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_glazed_terracotta"], "minecraft:cyan_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_shulker_box"], "minecraft:cyan_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_stained_glass"], "minecraft:cyan_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_stained_glass_pane"], "minecraft:cyan_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_terracotta"], "minecraft:cyan_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:cyan_wool"], "minecraft:cyan_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:dark_oak_fence"], "minecraft:dark_oak_fence");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:dark_oak_leaves"], "minecraft:dark_oak_leaves");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:dark_oak_log"], "minecraft:dark_oak_log");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:dark_oak_planks"], "minecraft:dark_oak_planks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:dark_oak_slab"], "minecraft:dark_oak_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:dark_oak_stairs"], "minecraft:dark_oak_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:dark_prismarine"], "minecraft:dark_prismarine");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:diamond_block"], "minecraft:diamond_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:diamond_ore"], "minecraft:diamond_ore");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:diorite"], "minecraft:diorite");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:dirt"], "minecraft:dirt");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:dispenser"], "minecraft:dispenser");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:dropper"], "minecraft:dropper");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:emerald_block"], "minecraft:emerald_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:emerald_ore"], "minecraft:emerald_ore");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:enchanting_table"], "minecraft:enchanting_table");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:end_portal_frame"], "minecraft:end_portal_frame");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:end_stone"], "minecraft:end_stone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:end_stone_bricks"], "minecraft:end_stone_bricks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:furnace"], "minecraft:furnace");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:glass"], "minecraft:glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:glass_pane"], "minecraft:glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:glowstone"], "minecraft:glowstone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gold_block"], "minecraft:gold_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gold_ore"], "minecraft:gold_ore");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:granite"], "minecraft:granite");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_concrete"], "minecraft:gray_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_glazed_terracotta"], "minecraft:gray_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_shulker_box"], "minecraft:gray_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_stained_glass"], "minecraft:gray_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_stained_glass_pane"], "minecraft:gray_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_terracotta"], "minecraft:gray_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:gray_wool"], "minecraft:gray_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_concrete"], "minecraft:green_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_glazed_terracotta"], "minecraft:green_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_shulker_box"], "minecraft:green_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_stained_glass"], "minecraft:green_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_stained_glass_pane"], "minecraft:green_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_terracotta"], "minecraft:green_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:green_wool"], "minecraft:green_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:hay_block"], "minecraft:hay_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:iron_bars"], "minecraft:iron_bars");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:iron_block"], "minecraft:iron_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:iron_ore"], "minecraft:iron_ore");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:jack_o_lantern"], "minecraft:jack_o_lantern");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:jukebox"], "minecraft:jukebox");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:jungle_fence"], "minecraft:jungle_fence");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:jungle_leaves"], "minecraft:jungle_leaves");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:jungle_log"], "minecraft:jungle_log");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:jungle_planks"], "minecraft:jungle_planks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:jungle_slab"], "minecraft:jungle_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:jungle_stairs"], "minecraft:jungle_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lapis_block"], "minecraft:lapis_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lapis_ore"], "minecraft:lapis_ore");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_concrete"], "minecraft:light_blue_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_glazed_terracotta"], "minecraft:light_blue_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_shulker_box"], "minecraft:light_blue_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_stained_glass"], "minecraft:light_blue_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_stained_glass_pane"], "minecraft:light_blue_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_terracotta"], "minecraft:light_blue_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_blue_wool"], "minecraft:light_blue_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_concrete"], "minecraft:light_gray_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_glazed_terracotta"], "minecraft:light_gray_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_shulker_box"], "minecraft:light_gray_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_stained_glass"], "minecraft:light_gray_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_stained_glass_pane"], "minecraft:light_gray_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_terracotta"], "minecraft:light_gray_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:light_gray_wool"], "minecraft:light_gray_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_concrete"], "minecraft:lime_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_glazed_terracotta"], "minecraft:lime_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_shulker_box"], "minecraft:lime_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_stained_glass"], "minecraft:lime_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_stained_glass_pane"], "minecraft:lime_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_terracotta"], "minecraft:lime_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:lime_wool"], "minecraft:lime_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_concrete"], "minecraft:magenta_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_glazed_terracotta"], "minecraft:magenta_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_shulker_box"], "minecraft:magenta_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_stained_glass"], "minecraft:magenta_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_stained_glass_pane"], "minecraft:magenta_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_terracotta"], "minecraft:magenta_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magenta_wool"], "minecraft:magenta_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:magma_block"], "minecraft:magma_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:melon_block"], "minecraft:melon_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:mossy_cobblestone"], "minecraft:mossy_cobblestone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:mossy_cobblestone_wall"], "minecraft:mossy_cobblestone_wall");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:mossy_stone_bricks"], "minecraft:mossy_stone_bricks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:nether_brick_fence"], "minecraft:nether_brick_fence");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:nether_brick_slab"], "minecraft:nether_brick_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:nether_brick_stairs"], "minecraft:nether_brick_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:nether_bricks"], "minecraft:nether_bricks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:nether_quartz_ore"], "minecraft:nether_quartz_ore");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:nether_wart_block"], "minecraft:nether_wart_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:netherrack"], "minecraft:netherrack");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:note_block"], "minecraft:note_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:oak_fence"], "minecraft:oak_fence");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:oak_leaves"], "minecraft:oak_leaves");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:oak_log"], "minecraft:oak_log");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:oak_planks"], "minecraft:oak_planks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:oak_slab"], "minecraft:oak_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:oak_stairs"], "minecraft:oak_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:obsidian"], "minecraft:obsidian");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_concrete"], "minecraft:orange_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_glazed_terracotta"], "minecraft:orange_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_shulker_box"], "minecraft:orange_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_stained_glass"], "minecraft:orange_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_stained_glass_pane"], "minecraft:orange_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_terracotta"], "minecraft:orange_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:orange_wool"], "minecraft:orange_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:packed_ice"], "minecraft:packed_ice");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_concrete"], "minecraft:pink_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_glazed_terracotta"], "minecraft:pink_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_shulker_box"], "minecraft:pink_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_stained_glass"], "minecraft:pink_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_stained_glass_pane"], "minecraft:pink_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_terracotta"], "minecraft:pink_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:pink_wool"], "minecraft:pink_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:piston"], "minecraft:piston");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:podzol"], "minecraft:podzol");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:polished_andesite"], "minecraft:polished_andesite");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:polished_diorite"], "minecraft:polished_diorite");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:polished_granite"], "minecraft:polished_granite");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:prismarine"], "minecraft:prismarine");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:prismarine_bricks"], "minecraft:prismarine_bricks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_concrete"], "minecraft:purple_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_glazed_terracotta"], "minecraft:purple_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_shulker_box"], "minecraft:purple_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_stained_glass"], "minecraft:purple_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_stained_glass_pane"], "minecraft:purple_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_terracotta"], "minecraft:purple_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purple_wool"], "minecraft:purple_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purpur_block"], "minecraft:purpur_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purpur_pillar"], "minecraft:purpur_pillar");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purpur_slab"], "minecraft:purpur_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:purpur_stairs"], "minecraft:purpur_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:quartz_block"], "minecraft:quartz_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:quartz_pillar"], "minecraft:quartz_pillar");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:quartz_slab"], "minecraft:quartz_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:quartz_stairs"], "minecraft:quartz_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_concrete"], "minecraft:red_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_glazed_terracotta"], "minecraft:red_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_nether_bricks"], "minecraft:red_nether_bricks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_sandstone"], "minecraft:red_sandstone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_sandstone_slab"], "minecraft:red_sandstone_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_sandstone_stairs"], "minecraft:red_sandstone_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_shulker_box"], "minecraft:red_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_stained_glass"], "minecraft:red_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_stained_glass_pane"], "minecraft:red_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_terracotta"], "minecraft:red_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:red_wool"], "minecraft:red_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:redstone_lamp"], "minecraft:redstone_lamp");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:redstone_ore"], "minecraft:redstone_ore");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:sandstone"], "minecraft:sandstone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:sandstone_slab"], "minecraft:sandstone_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:sandstone_stairs"], "minecraft:sandstone_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:sea_lantern"], "minecraft:sea_lantern");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:slime_block"], "minecraft:slime_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:snow_block"], "minecraft:snow_block");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:soul_sand"], "minecraft:soul_sand");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:sponge"], "minecraft:sponge");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:spruce_fence"], "minecraft:spruce_fence");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:spruce_leaves"], "minecraft:spruce_leaves");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:spruce_log"], "minecraft:spruce_log");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:spruce_planks"], "minecraft:spruce_planks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:spruce_slab"], "minecraft:spruce_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:spruce_stairs"], "minecraft:spruce_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:sticky_piston"], "minecraft:sticky_piston");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:stone"], "minecraft:stone");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:stone_brick_slab"], "minecraft:stone_brick_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:stone_brick_stairs"], "minecraft:stone_brick_stairs");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:stone_bricks"], "minecraft:stone_bricks");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:stone_slab"], "minecraft:stone_slab");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:terracotta"], "minecraft:terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:wet_sponge"], "minecraft:wet_sponge");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_concrete"], "minecraft:white_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_glazed_terracotta"], "minecraft:white_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_shulker_box"], "minecraft:white_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_stained_glass"], "minecraft:white_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_stained_glass_pane"], "minecraft:white_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_terracotta"], "minecraft:white_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:white_wool"], "minecraft:white_wool");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_concrete"], "minecraft:yellow_concrete");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_glazed_terracotta"], "minecraft:yellow_glazed_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_shulker_box"], "minecraft:yellow_shulker_box");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_stained_glass"], "minecraft:yellow_stained_glass");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_stained_glass_pane"], "minecraft:yellow_stained_glass_pane");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_terracotta"], "minecraft:yellow_terracotta");
                    Diccionario_Paleta.Add(Minecraft.Bloques.Diccionario_Nombre_Índice["minecraft:yellow_wool"], "minecraft:yellow_wool");

                    if (Diccionario_Paleta.Count != 256) MessageBox.Show(Diccionario_Paleta.Count.ToString());
                }
                int Bits_Bloque = (Diccionario_Paleta.Count * 8) / 256;
                int Bits_Chunk = Bits_Bloque * 65536;
                this.Text = Texto_Título + " - [Blocks in the palette: " + Program.Traducir_Número(Diccionario_Paleta.Count) + " (" + Program.Traducir_Número(Bits_Bloque) + (Bits_Bloque != 1 ? " bits" : " bit") + " per block or " + Program.Traducir_Tamaño_Bytes_Automático((long)Bits_Chunk / 8L, 2, false) + " per chunk)]";
                this.WindowState = FormWindowState.Maximized;
                Ocupado = true;
                Registro_Cargar_Opciones();
                Ocupado = false;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Plantilla_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Plantilla_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Plantilla_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Plantilla_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, true) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Plantilla_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                {
                    string[] Matriz_Rutas = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                    if (Matriz_Rutas != null && Matriz_Rutas.Length > 0)
                    {
                        foreach (string Ruta in Matriz_Rutas)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(Ruta) && Diccionario_Paleta != null && Diccionario_Paleta.Count >= 256)
                                {
                                    if (File.Exists(Ruta)) // Encode into a new Minecraft world.
                                    {
                                        FileStream Lector_Entrada = new FileStream(Ruta, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                                        if (Lector_Entrada != null && Lector_Entrada.Length > 0L)
                                        {
                                            Lector_Entrada.Seek(0L, SeekOrigin.Begin);
                                            List<short> Lista_Temporal = new List<short>();
                                            foreach (KeyValuePair<short, object> Entrada in Diccionario_Paleta)
                                            {
                                                Lista_Temporal.Add(Entrada.Key);
                                            }
                                            List<short> Lista_Índices = new List<short>();
                                            Lista_Índices.Add(Lista_Temporal[0]); // Be sure the first block will be air.
                                            Lista_Temporal.RemoveAt(0);
                                            for (int Índice = Lista_Temporal.Count - 1; Índice >= 0; Índice--)
                                            {
                                                int Índice_Aleatorio = Program.Rand.Next(0, Lista_Temporal.Count);
                                                Lista_Índices.Add(Lista_Temporal[Índice_Aleatorio]);
                                                Lista_Temporal.RemoveAt(Índice_Aleatorio);
                                            } // Randomize the palette block order.
                                            Lista_Temporal = null;
                                            byte[] Matriz_ID = new byte[256];
                                            byte[] Matriz_Data = new byte[256];
                                            for (int Índice = 0; Índice < 256; Índice++)
                                            {
                                                byte Data;
                                                foreach (KeyValuePair<short, short> Entrada in Minecraft.Diccionario_Bloques_Índices_1_12_2_a_Índices_1_13)
                                                {
                                                    if (Entrada.Value == Lista_Índices[Índice])
                                                    {
                                                        Matriz_ID[Índice] = Minecraft.Obtener_Valores_ID_Data(Entrada.Key, out Data);
                                                        Matriz_Data[Índice] = Data;
                                                        break;
                                                    }
                                                }
                                            }
                                            string Ruta_Salida = Program.Ruta_Guardado_Minecraft + "\\" + Program.Obtener_Nombre_Temporal_Sin_Guiones() + " Encoded file";
                                            if (Directory.Exists(Ruta_Salida))
                                            {
                                                MessageBox.Show(this, "Somehow the directory name for the new Minecraft map already exists.\r\nPlease try it again if the system clock is running properly.\r\nPath: \"" + Ruta_Salida + "\".", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                Ruta_Salida = null;
                                                return;
                                            }
                                            Program.Crear_Carpetas(Ruta_Salida);
                                            AnvilWorld Mundo = AnvilWorld.Create(Ruta_Salida);
                                            IChunkManager Chunks = Mundo.GetChunkManager(0);
                                            BlockManager Bloques = Mundo.GetBlockManager(0);
                                            Mundo.Level.LevelName = Path.GetFileName(Ruta_Salida);
                                            Mundo.Level.UseMapFeatures = false;
                                            //Mundo.Level.GeneratorOptions = "1;minecraft:bedrock";
                                            Mundo.Level.GameType = GameType.CREATIVE;
                                            Mundo.Level.Spawn = new SpawnPoint(-1, 1, -1);
                                            Mundo.Level.AllowCommands = true;
                                            Mundo.Level.GameRules.CommandBlockOutput = false; // Hide the command block messages.
                                            Mundo.Level.GameRules.DoMobSpawning = false;
                                            Mundo.Level.GameRules.DoFireTick = false;
                                            Mundo.Level.GameRules.MobGriefing = false;
                                            Mundo.Level.GameRules.KeepInventory = true;
                                            Mundo.Level.RainTime = 55555;
                                            Mundo.Level.IsRaining = false;
                                            Mundo.Level.Player = new Player();
                                            Mundo.Level.Player.Dimension = 0;
                                            Mundo.Level.Player.Position = new Vector3();
                                            Mundo.Level.Player.Position.X = -1;
                                            Mundo.Level.Player.Position.Y = 1;
                                            Mundo.Level.Player.Position.Z = -1;
                                            Substrate.Orientation Orientación = new Substrate.Orientation();
                                            Orientación.Pitch = 0d; // -90º a +90º // 25 = hacia abajo
                                            Orientación.Yaw = -45d; // -180º a +180º // 45 = Sureste
                                            Mundo.Level.Player.Rotation = Orientación;
                                            Mundo.Level.Player.Spawn = new SpawnPoint(-1, 1, -1);
                                            Mundo.Level.Player.Abilities.Flying = true;
                                            Mundo.Level.RandomSeed = 4; // Massive ocean.
                                            /*if (Variable_Estructura == Estructuras.Labyrinth || Variable_Estructura == Estructuras.Trapped_labyrinth)
                                            {
                                                Mundo.Level.DayTime = 18000; // Play at night to hide the exit light
                                                Mundo.Level.Time = 18000; // Play at night to hide the exit light
                                            }
                                            int Diámetro_16 = 253 + 16;
                                            int Bloques_Ancho = 0;
                                            int Bloques_Alto = 0;
                                            byte Data;
                                            byte ID = Minecraft.Buscar_ID_Data_Minecraft_1_12_2(Minecraft.Diccionario_Bloques_Nombres_Índices[Variable_Bloque], out Data);
                                            byte Data_Interior;
                                            byte ID_Interior = Minecraft.Buscar_ID_Data_Minecraft_1_12_2(Minecraft.Diccionario_Bloques_Nombres_Índices[Variable_Bloque_Interior], out Data_Interior);*/
                                            long Total_Bloques = Lector_Entrada.Length; // 8 bits (1 byte) per block.
                                            long Total_Chunks = Lector_Entrada.Length / 65536L; // 65.536 blocks per chunk.
                                            long Total_Regiones = Lector_Entrada.Length / 67108864L; // 1.024 chunks per region.
                                            double Raíz_Cuadrada_Regiones = Math.Sqrt(Total_Regiones);
                                            if (Raíz_Cuadrada_Regiones - Math.Truncate(Raíz_Cuadrada_Regiones) != 0d) Raíz_Cuadrada_Regiones++; // Add one extra region if it doesn't fit exactly.
                                            Raíz_Cuadrada_Regiones = Math.Max(Math.Truncate(Raíz_Cuadrada_Regiones), 1d);
                                            int Ancho_Regiones = (int)Raíz_Cuadrada_Regiones;
                                            int Alto_Regiones = Ancho_Regiones;
                                            int Ancho_Bloques = Ancho_Regiones * 512;
                                            int Alto_Bloques = Ancho_Bloques;
                                            int Diámetro_16 = Ancho_Bloques + 16;
                                            int Bloques_Ancho = 0;
                                            int Bloques_Alto = 0;
                                            bool Construir_Paredes_Cristal = true;
                                            // Pre-start the needed chunks:
                                            for (int Índice_Z = -16, Chunk_Z = -1; Índice_Z < Diámetro_16; Índice_Z += 16, Chunk_Z++, Bloques_Alto += 16)
                                            {
                                                Bloques_Ancho = 0;
                                                for (int Índice_X = -16, Chunk_X = -1; Índice_X < Diámetro_16; Índice_X += 16, Chunk_X++, Bloques_Ancho += 16)
                                                {
                                                    ChunkRef Chunk = Chunks.CreateChunk(Chunk_X, Chunk_Z);
                                                    Chunk.IsTerrainPopulated = true;
                                                    Chunk.Blocks.AutoLight = false;
                                                    if (Índice_X > -1 && Índice_Z > -1 && Índice_X < Ancho_Bloques && Índice_Z < Ancho_Bloques)
                                                    {
                                                        for (int Z = 0; Z < 16; Z++)
                                                        {
                                                            for (int X = 0; X < 16; X++)
                                                            {
                                                                Chunk.Blocks.SetID(X, 0, Z, (int)BlockType.BEDROCK); // Structure floor
                                                            }
                                                        }
                                                    }
                                                    Chunk.Blocks.RebuildHeightMap();
                                                    Chunk.Blocks.RebuildBlockLight();
                                                    Chunk.Blocks.RebuildSkyLight();
                                                }
                                            }
                                            if (Construir_Paredes_Cristal) // Add massive glass walls.
                                            {
                                                Bloques_Ancho -= 16;
                                                Bloques_Alto -= 16;
                                                for (int Índice_X = -16; Índice_X < Bloques_Ancho - 1; Índice_X++) // North glass wall
                                                {
                                                    for (int Índice_Y = 0; Índice_Y < 63; Índice_Y++)
                                                    {
                                                        Bloques.SetID(Índice_X, Índice_Y, -16, Índice_Y != 0 ? (int)BlockType.GLASS : (int)BlockType.BEDROCK);
                                                    }
                                                }
                                                for (int Índice_Z = -16; Índice_Z < Bloques_Alto - 1; Índice_Z++) // East glass wall
                                                {
                                                    for (int Índice_Y = 0; Índice_Y < 63; Índice_Y++)
                                                    {
                                                        Bloques.SetID(Bloques_Ancho - 1, Índice_Y, Índice_Z, Índice_Y != 0 ? (int)BlockType.GLASS : (int)BlockType.BEDROCK);
                                                    }
                                                }
                                                for (int Índice_X = Bloques_Ancho - 1; Índice_X >= -16; Índice_X--) // South glass wall
                                                {
                                                    for (int Índice_Y = 0; Índice_Y < 63; Índice_Y++)
                                                    {
                                                        Bloques.SetID(Índice_X, Índice_Y, Bloques_Alto - 1, Índice_Y != 0 ? (int)BlockType.GLASS : (int)BlockType.BEDROCK);
                                                    }
                                                }
                                                for (int Índice_Z = Bloques_Alto - 1; Índice_Z >= -16; Índice_Z--) // West glass wall
                                                {
                                                    for (int Índice_Y = 0; Índice_Y < 63; Índice_Y++)
                                                    {
                                                        Bloques.SetID(-16, Índice_Y, Índice_Z, Índice_Y != 0 ? (int)BlockType.GLASS : (int)BlockType.BEDROCK);
                                                    }
                                                }
                                            }
                                            // Start adding the file bytes into the new Minecraft world:
                                            // Reserve the chunk at 0, 0 to store the file header and block palette, and
                                            // without these the file will be lost forever, so never break a single block
                                            // if you ever plan to recover your file from the world, but also never break
                                            // any block which has data encoded in it or the file will also be lost forever.
                                            // Finally if it uses a password, you must input the exact same password and cipher
                                            // options in order to be able to extract the file successfully from that world.
                                            // Please never use this options to do bad things, and use them only for having fun!
                                            byte[] Matriz_Bytes = new byte[4096];
                                            int Índice_Byte = int.MaxValue;
                                            int Longitud = 0;
                                            bool Terminar = false;
                                            for (int Índice_Región_Z = 0; Índice_Región_Z < Alto_Regiones; Índice_Región_Z++)
                                            {
                                                for (int Índice_Región_X = 0; Índice_Región_X < Ancho_Regiones; Índice_Región_X++)
                                                {
                                                    for (int Índice_Z = 0; Índice_Z < 512; Índice_Z++)
                                                    {
                                                        for (int Índice_X = (Índice_Región_X > 0 || Índice_Región_Z > 0 || Índice_Z > 0) ? 0 : 1; Índice_X < 512; Índice_X++)
                                                        {
                                                            for (int Índice_Y = 0; Índice_Y < 256; Índice_Y++)
                                                            {
                                                                if (Índice_Byte >= Longitud)
                                                                {
                                                                    Longitud = Lector_Entrada.Read(Matriz_Bytes, 0, Matriz_Bytes.Length);
                                                                    Índice_Byte = 0;
                                                                    if (Longitud <= 0) // End now the encoding...
                                                                    {
                                                                        Terminar = true;
                                                                    }
                                                                }
                                                                if (Terminar) break;
                                                                int X = (Índice_Región_X * 512) + Índice_X;
                                                                int Z = (Índice_Región_Z * 512) + Índice_Z;
                                                                /*try
                                                                {
                                                                    int q = Matriz_ID[Matriz_Bytes[Índice_Byte]];
                                                                }
                                                                catch (Exception Excepción)
                                                                {
                                                                    Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true;
                                                                    return;
                                                                }*/
                                                                byte ID = Matriz_ID[Matriz_Bytes[Índice_Byte]];
                                                                byte Data = Matriz_Data[Matriz_Bytes[Índice_Byte]];
                                                                //if (ID != 23 && ID != 25 && ID != 33 && ID != 54 && ID != 61 && ID != 63 && ID != 84 && ID != 116 && ID != 117 && ID != 119 && ID != 137 && ID != 138 && ID != 158)
                                                                {
                                                                    try
                                                                    {
                                                                        //if (ID == 154) MessageBox.Show("Hopper?"); // 95 error?...
                                                                        Bloques.SetID(X, Índice_Y, Z, ID);
                                                                        Bloques.SetData(X, Índice_Y, Z, Data);
                                                                    }
                                                                    catch (Exception Excepción)
                                                                    {
                                                                        Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true;
                                                                        MessageBox.Show(ID.ToString());
                                                                        return;
                                                                    }
                                                                }
                                                                /*else if (ID == 23) // Dispenser
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.DISPENSER);
                                                                    Bloque.Data = Data;
                                                                    TileEntityTrap Entidad = Bloque.GetTileEntity() as TileEntityTrap;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 25) // Note block
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.NOTE_BLOCK);
                                                                    Bloque.Data = Data;
                                                                    TileEntityMusic Entidad = Bloque.GetTileEntity() as TileEntityMusic;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 33) // Piston
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.PISTON);
                                                                    Bloque.Data = Data;
                                                                    TileEntityPiston Entidad = Bloque.GetTileEntity() as TileEntityPiston;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 54) // Chest
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.CHEST);
                                                                    Bloque.Data = Data;
                                                                    TileEntityChest Entidad = Bloque.GetTileEntity() as TileEntityChest;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 61) // Furnace
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.FURNACE);
                                                                    Bloque.Data = Data;
                                                                    TileEntityFurnace Entidad = Bloque.GetTileEntity() as TileEntityFurnace;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 63) // Sign
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.SIGN_POST);
                                                                    Bloque.Data = Data;
                                                                    TileEntitySign Entidad = Bloque.GetTileEntity() as TileEntitySign;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 84) // Jukebox
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.JUKEBOX);
                                                                    Bloque.Data = Data;
                                                                    TileEntityRecordPlayer Entidad = Bloque.GetTileEntity() as TileEntityRecordPlayer;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 116) // Enchantment table
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.ENCHANTMENT_TABLE);
                                                                    Bloque.Data = Data;
                                                                    TileEntityEnchantmentTable Entidad = Bloque.GetTileEntity() as TileEntityEnchantmentTable;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 117) // Brewing stand
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.BREWING_STAND);
                                                                    Bloque.Data = Data;
                                                                    TileEntityBrewingStand Entidad = Bloque.GetTileEntity() as TileEntityBrewingStand;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 119) // End portal
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.END_PORTAL);
                                                                    Bloque.Data = Data;
                                                                    TileEntityEndPortal Entidad = Bloque.GetTileEntity() as TileEntityEndPortal;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 137) // Command block
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.COMMAND_BLOCK);
                                                                    Bloque.Data = Data;
                                                                    TileEntityControl Entidad = Bloque.GetTileEntity() as TileEntityControl;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                else if (ID == 138) // Beacon
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.BEACON_BLOCK);
                                                                    Bloque.Data = Data;
                                                                    TileEntityBeacon Entidad = Bloque.GetTileEntity() as TileEntityBeacon;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }
                                                                /*else if (ID == 158) // Dropper
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(BlockType.DROPPER);
                                                                    Bloque.Data = Data;
                                                                    TileEntityTrap Entidad = Bloque.GetTileEntity() as TileEntityTrap;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }*/
                                                                /*else
                                                                {
                                                                    AlphaBlock Bloque = new AlphaBlock(ID);
                                                                    Bloque.Data = Data;
                                                                    //TileEntity Entidad = Bloque.GetTileEntity() as TileEntity;
                                                                    Bloques.SetBlock(X, Índice_Y, Z, Bloque);
                                                                }*/
                                                                Índice_Byte++; // Increase the byte index for the next block.
                                                            }
                                                            if (Terminar) break;
                                                        }
                                                        if (Terminar) break;
                                                    }
                                                    if (Terminar) break;
                                                }
                                                if (Terminar) break;
                                            }
                                            if (!Terminar) MessageBox.Show("!Terminar?..."); // Unexpected.
                                            /*for (int Índice_Z = -16, Chunk_Z = -1; Índice_Z < Diámetro_16; Índice_Z += 16, Chunk_Z++)
                                            {
                                                for (int Índice_X = -16, Chunk_X = -1; Índice_X < Diámetro_16; Índice_X += 16, Chunk_X++)
                                                {
                                                    IChunk Chunk = Chunks.GetChunk(Chunk_X, Chunk_Z);
                                                    if (Chunk != null)
                                                    {
                                                        Chunk.Blocks.RebuildHeightMap(); // Try to recreate the finished chunks.
                                                        Chunk.Blocks.RebuildBlockLight(); // Not sure if this is actually useful.
                                                        Chunk.Blocks.RebuildSkyLight(); // ...
                                                    }
                                                    //else MessageBox.Show("Chunk == null?"); // Unexpected.
                                                }
                                            }*/
                                            Chunks.Save();
                                            Mundo.Save();
                                            Chunks = null;
                                            Bloques = null;
                                            Mundo = null;
                                            Lector_Entrada.Close();
                                            Lector_Entrada.Dispose();
                                            Lector_Entrada = null;
                                            MessageBox.Show("Done...");
                                            SystemSounds.Asterisk.Play();
                                        }
                                        break;
                                    }
                                    else if (Directory.Exists(Ruta)) // Decode from a Minecraft world.
                                    {
                                        // Soon...

                                        break;
                                    }
                                    //Minecraft.Información_Niveles Información_Nivel = Minecraft.Información_Niveles.Obtener_Información_Nivel(Ruta);
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
            finally { this.Cursor = Cursors.Default; }
        }

        private void Ventana_Plantilla_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Plantilla_KeyDown(object sender, KeyEventArgs e)
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

        // Encrypt bytes into bytes using a password
        // Uses Encrypt(byte[], byte[], byte[])
        public static byte[] Encrypt(byte[] clearData, string Password)
        {
            // We need to turn the password into Key and IV.
            // We are using salt to make it harder to guess our key using a
            // dictionary attack - trying to guess a password by enumerating all
            // possible words.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            // Now get the key/IV and do the encryption using the function that
            // accepts byte arrays.
            // Using PasswordDeriveBytes object we are first getting 32 bytes for
            // the Key (the default Rijndael key length is 256bit = 32 bytes) and
            // then 16 bytes for the IV.
            // IV should always be the block size, which is by default 16 bytes
            // (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is 8 bytes and
            // so should be the IV size.
            // You can also read KeySize/BlockSize properties off the algorithm
            // to find out the sizes.
            return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        // Decrypt bytes into bytes using a password
        // Uses Decrypt(byte[], byte[], byte[])
        public static byte[] Decrypt(byte[] cipherData, string Password)
        {
            // We need to turn the password into Key and IV.
            // We are using salt to make it harder to guess our key using a
            // dictionary attack - trying to guess a password by enumerating all
            // possible words.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            // Now get the key/IV and do the Decryption using the function that
            // accepts byte arrays.
            // Using PasswordDeriveBytes object we are first getting 32 bytes for
            // the Key (the default Rijndael key length is 256bit = 32 bytes) and
            // then 16 bytes for the IV.
            // IV should always be the block size, which is by default 16 bytes
            // (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is 8 bytes and
            // so should be the IV size.
            // You can also read KeySize/BlockSize properties off the algorithm
            // to find out the sizes.
            return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        // Encrypt a byte array into a byte array using a key and an IV
        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            // Create a MemoryStream to accept the encrypted bytes
            MemoryStream ms = new MemoryStream();
            // Create a symmetric algorithm.
            // We are going to use Rijndael because it is strong and available
            // on all platforms.
            // You can use other algorithms, to do so substitute the next line
            // with something like
            // TripleDES.Create();
            Rijndael alg = Rijndael.Create();
            // Now set the key and the IV.
            // We need the IV (Initialization Vector) because the algorithm is
            // operating in its default mode called CBC (Cipher Block Chaining).
            // The IV is XORed with the first block (8 byte) of the data before
            // it is encrypted, and then each encrypted block is XORed with the
            // following block of plaintext.
            // This is done to make encryption more secure.
            // There is also a mode called ECB which does not need an IV, but it
            // is much less secure.
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be pumping our
            // data.
            // CryptoStreamMode.Write means that we are going to be writing data
            // to the stream and the output will be written in the MemoryStream we
            // have provided.
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the encryption
            cs.Write(clearData, 0, clearData.Length);

            // Close the crypto stream (or do FlushFinalBlock).
            // This will tell it that we have done our encryption and there is no
            // more data coming in, and it is now a good time to apply the padding
            // and finalize the encryption process.
            cs.Close();

            // Now get the encrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here, which is not
            // the right way.
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        // Decrypt a byte array into a byte array using a key and an IV
        public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            // Create a MemoryStream that is going to accept the decrypted bytes
            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm.
            // We are going to use Rijndael because it is strong and available on
            // all platforms.
            // You can use other algorithms, to do so substitute the next line with
            // something like
            // TripleDES alg = TripleDES.Create();
            Rijndael alg = Rijndael.Create();

            // Now set the key and the IV.
            // We need the IV (Initialization Vector) because the algorithm is
            // operating in its default mode called CBC (Cipher Block Chaining).
            // The IV is XORed with the first block (8 byte) of the data after
            // it is decrypted, and then each decrypted block is XORed with the
            // previous cipher block.
            // This is done to make encryption more secure.
            // There is also a mode called ECB which does not need an IV, but it
            // is much less secure.
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be pumping our
            // data.
            // CryptoStreamMode.Write means that we are going to be writing data
            // to the stream and the output will be written in the MemoryStream we
            // have provided.
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the decryption
            cs.Write(cipherData, 0, cipherData.Length);

            // Close the crypto stream (or do FlushFinalBlock).
            // This will tell it that we have done our decryption and there is no
            // more data coming in, and it is now a good time to apply the padding
            // and finalize the decryption process.
            cs.Close();

            // Now get the encrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here, which is not
            // the right way.
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }
    }
}

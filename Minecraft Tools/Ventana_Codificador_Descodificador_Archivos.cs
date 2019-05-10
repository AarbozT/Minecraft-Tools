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
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
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

        internal readonly string Texto_Título = "File Encoder and Decoder for " + Program.Texto_Usuario + " by Jupisoft - [Drop any file to encode it as a new world or any world to extract it's file]";
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
        
        internal static List<byte> Lista_Paleta_ID = null;
        internal static List<byte> Lista_Paleta_Data = null;
        
        internal static int Variable_Altura = 64;
        internal static bool Variable_Contraseña = true;
        internal static string Variable_Texto_Contraseña = null;
        internal static bool Variable_Cifrado_Bits_Base_2 = false;
        internal static bool Variable_Cifrado_Bits_Base_4 = false;
        internal static bool Variable_Cifrado_Bits_Base_16 = false;
        internal static bool Variable_Cifrado_Bits_Base_Negativo = false;

        private void Ventana_Codificador_Descodificador_Archivos_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Program.Icono_Jupisoft.Clone() as Icon;
                // Only start the palette if it hasn't been started yet.
                if (Lista_Paleta_ID == null || Lista_Paleta_Data == null || Lista_Paleta_ID.Count < 256 || Lista_Paleta_Data.Count < 256)
                {
                    // Start the palette ID and Data lists.
                    Lista_Paleta_ID = new List<byte>();
                    Lista_Paleta_Data = new List<byte>();

                    // Add 256 block ID and Data to the palette, where 1 block equals 1 byte (8 bits).
                    Lista_Paleta_ID.Add(0); Lista_Paleta_Data.Add(0); // minecraft:air.
                    Lista_Paleta_ID.Add(1); Lista_Paleta_Data.Add(0); // minecraft:stone.
                    Lista_Paleta_ID.Add(1); Lista_Paleta_Data.Add(1); // minecraft:granite.
                    Lista_Paleta_ID.Add(1); Lista_Paleta_Data.Add(2); // minecraft:polished_granite.
                    Lista_Paleta_ID.Add(1); Lista_Paleta_Data.Add(3); // minecraft:diorite.
                    Lista_Paleta_ID.Add(1); Lista_Paleta_Data.Add(4); // minecraft:polished_diorite.
                    Lista_Paleta_ID.Add(1); Lista_Paleta_Data.Add(5); // minecraft:andesite.
                    Lista_Paleta_ID.Add(1); Lista_Paleta_Data.Add(6); // minecraft:polished_andesite.
                    Lista_Paleta_ID.Add(3); Lista_Paleta_Data.Add(0); // minecraft:dirt.
                    Lista_Paleta_ID.Add(3); Lista_Paleta_Data.Add(1); // minecraft:coarse_dirt.
                    Lista_Paleta_ID.Add(3); Lista_Paleta_Data.Add(2); // minecraft:podzol.
                    Lista_Paleta_ID.Add(4); Lista_Paleta_Data.Add(0); // minecraft:cobblestone.
                    Lista_Paleta_ID.Add(5); Lista_Paleta_Data.Add(0); // minecraft:oak_planks.
                    Lista_Paleta_ID.Add(5); Lista_Paleta_Data.Add(1); // minecraft:spruce_planks.
                    Lista_Paleta_ID.Add(5); Lista_Paleta_Data.Add(2); // minecraft:birch_planks.
                    Lista_Paleta_ID.Add(5); Lista_Paleta_Data.Add(3); // minecraft:jungle_planks.
                    Lista_Paleta_ID.Add(5); Lista_Paleta_Data.Add(4); // minecraft:acacia_planks.
                    Lista_Paleta_ID.Add(5); Lista_Paleta_Data.Add(5); // minecraft:dark_oak_planks.
                    Lista_Paleta_ID.Add(7); Lista_Paleta_Data.Add(0); // minecraft:bedrock.
                    Lista_Paleta_ID.Add(14); Lista_Paleta_Data.Add(0); // minecraft:gold_ore.
                    Lista_Paleta_ID.Add(15); Lista_Paleta_Data.Add(0); // minecraft:iron_ore.
                    Lista_Paleta_ID.Add(16); Lista_Paleta_Data.Add(0); // minecraft:coal_ore.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(0); // minecraft:oak_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(1); // minecraft:spruce_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(2); // minecraft:birch_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(3); // minecraft:jungle_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(0 | 4); // minecraft:oak_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(1 | 4); // minecraft:spruce_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(2 | 4); // minecraft:birch_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(3 | 4); // minecraft:jungle_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(0 | 8); // minecraft:oak_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(1 | 8); // minecraft:spruce_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(2 | 8); // minecraft:birch_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(3 | 8); // minecraft:jungle_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(0 | 12); // minecraft:oak_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(1 | 12); // minecraft:spruce_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(2 | 12); // minecraft:birch_log.
                    Lista_Paleta_ID.Add(17); Lista_Paleta_Data.Add(3 | 12); // minecraft:jungle_log.
                    Lista_Paleta_ID.Add(18); Lista_Paleta_Data.Add(0 | 4); // minecraft:oak_leaves.
                    Lista_Paleta_ID.Add(18); Lista_Paleta_Data.Add(1 | 4); // minecraft:spruce_leaves.
                    Lista_Paleta_ID.Add(18); Lista_Paleta_Data.Add(2 | 4); // minecraft:birch_leaves.
                    Lista_Paleta_ID.Add(18); Lista_Paleta_Data.Add(3 | 4); // minecraft:jungle_leaves.
                    Lista_Paleta_ID.Add(20); Lista_Paleta_Data.Add(0); // minecraft:glass.
                    Lista_Paleta_ID.Add(21); Lista_Paleta_Data.Add(0); // minecraft:lapis_ore.
                    Lista_Paleta_ID.Add(22); Lista_Paleta_Data.Add(0); // minecraft:lapis_block.
                    Lista_Paleta_ID.Add(23); Lista_Paleta_Data.Add(0); // minecraft:dispenser.
                    Lista_Paleta_ID.Add(23); Lista_Paleta_Data.Add(1); // minecraft:dispenser.
                    Lista_Paleta_ID.Add(23); Lista_Paleta_Data.Add(2); // minecraft:dispenser.
                    Lista_Paleta_ID.Add(23); Lista_Paleta_Data.Add(3); // minecraft:dispenser.
                    Lista_Paleta_ID.Add(23); Lista_Paleta_Data.Add(4); // minecraft:dispenser.
                    Lista_Paleta_ID.Add(23); Lista_Paleta_Data.Add(5); // minecraft:dispenser.
                    Lista_Paleta_ID.Add(24); Lista_Paleta_Data.Add(0); // minecraft:sandstone.
                    Lista_Paleta_ID.Add(24); Lista_Paleta_Data.Add(1); // minecraft:chiseled_sandstone.
                    Lista_Paleta_ID.Add(24); Lista_Paleta_Data.Add(2); // minecraft:cut_sandstone.
                    Lista_Paleta_ID.Add(25); Lista_Paleta_Data.Add(0); // minecraft:note_block.
                    Lista_Paleta_ID.Add(29); Lista_Paleta_Data.Add(0); // minecraft:sticky_piston.
                    Lista_Paleta_ID.Add(29); Lista_Paleta_Data.Add(1); // minecraft:sticky_piston.
                    Lista_Paleta_ID.Add(29); Lista_Paleta_Data.Add(2); // minecraft:sticky_piston.
                    Lista_Paleta_ID.Add(29); Lista_Paleta_Data.Add(3); // minecraft:sticky_piston.
                    Lista_Paleta_ID.Add(29); Lista_Paleta_Data.Add(4); // minecraft:sticky_piston.
                    Lista_Paleta_ID.Add(29); Lista_Paleta_Data.Add(5); // minecraft:sticky_piston.
                    Lista_Paleta_ID.Add(33); Lista_Paleta_Data.Add(0); // minecraft:piston.
                    Lista_Paleta_ID.Add(33); Lista_Paleta_Data.Add(1); // minecraft:piston.
                    Lista_Paleta_ID.Add(33); Lista_Paleta_Data.Add(2); // minecraft:piston.
                    Lista_Paleta_ID.Add(33); Lista_Paleta_Data.Add(3); // minecraft:piston.
                    Lista_Paleta_ID.Add(33); Lista_Paleta_Data.Add(4); // minecraft:piston.
                    Lista_Paleta_ID.Add(33); Lista_Paleta_Data.Add(5); // minecraft:piston.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(0); // minecraft:white_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(1); // minecraft:orange_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(2); // minecraft:magenta_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(3); // minecraft:light_blue_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(4); // minecraft:yellow_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(5); // minecraft:lime_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(6); // minecraft:pink_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(7); // minecraft:gray_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(8); // minecraft:light_gray_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(9); // minecraft:cyan_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(10); // minecraft:purple_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(11); // minecraft:blue_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(12); // minecraft:brown_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(13); // minecraft:green_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(14); // minecraft:red_wool.
                    Lista_Paleta_ID.Add(35); Lista_Paleta_Data.Add(15); // minecraft:black_wool.
                    Lista_Paleta_ID.Add(41); Lista_Paleta_Data.Add(0); // minecraft:gold_block.
                    Lista_Paleta_ID.Add(42); Lista_Paleta_Data.Add(0); // minecraft:iron_block.
                    Lista_Paleta_ID.Add(45); Lista_Paleta_Data.Add(0); // minecraft:bricks.
                    Lista_Paleta_ID.Add(47); Lista_Paleta_Data.Add(0); // minecraft:bookshelf.
                    Lista_Paleta_ID.Add(48); Lista_Paleta_Data.Add(0); // minecraft:mossy_cobblestone.
                    Lista_Paleta_ID.Add(49); Lista_Paleta_Data.Add(0); // minecraft:obsidian.
                    Lista_Paleta_ID.Add(56); Lista_Paleta_Data.Add(0); // minecraft:diamond_ore.
                    Lista_Paleta_ID.Add(57); Lista_Paleta_Data.Add(0); // minecraft:diamond_block.
                    Lista_Paleta_ID.Add(58); Lista_Paleta_Data.Add(0); // minecraft:crafting_table.
                    Lista_Paleta_ID.Add(61); Lista_Paleta_Data.Add(0); // minecraft:furnace.
                    Lista_Paleta_ID.Add(82); Lista_Paleta_Data.Add(0); // minecraft:clay.
                    Lista_Paleta_ID.Add(84); Lista_Paleta_Data.Add(0); // minecraft:jukebox.
                    Lista_Paleta_ID.Add(86); Lista_Paleta_Data.Add(0); // minecraft:carved_pumpkin.
                    Lista_Paleta_ID.Add(86); Lista_Paleta_Data.Add(1); // minecraft:carved_pumpkin.
                    Lista_Paleta_ID.Add(86); Lista_Paleta_Data.Add(2); // minecraft:carved_pumpkin.
                    Lista_Paleta_ID.Add(86); Lista_Paleta_Data.Add(3); // minecraft:carved_pumpkin.
                    Lista_Paleta_ID.Add(87); Lista_Paleta_Data.Add(0); // minecraft:netherrack.
                    Lista_Paleta_ID.Add(89); Lista_Paleta_Data.Add(0); // minecraft:glowstone.
                    Lista_Paleta_ID.Add(91); Lista_Paleta_Data.Add(0); // minecraft:jack_o_lantern.
                    Lista_Paleta_ID.Add(91); Lista_Paleta_Data.Add(1); // minecraft:jack_o_lantern.
                    Lista_Paleta_ID.Add(91); Lista_Paleta_Data.Add(2); // minecraft:jack_o_lantern.
                    Lista_Paleta_ID.Add(91); Lista_Paleta_Data.Add(3); // minecraft:jack_o_lantern.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(0); // minecraft:white_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(1); // minecraft:orange_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(2); // minecraft:magenta_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(3); // minecraft:light_blue_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(4); // minecraft:yellow_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(5); // minecraft:lime_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(6); // minecraft:pink_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(7); // minecraft:gray_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(8); // minecraft:light_gray_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(9); // minecraft:cyan_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(10); // minecraft:purple_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(11); // minecraft:blue_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(12); // minecraft:brown_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(13); // minecraft:green_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(14); // minecraft:red_stained_glass.
                    Lista_Paleta_ID.Add(95); Lista_Paleta_Data.Add(15); // minecraft:black_stained_glass.
                    Lista_Paleta_ID.Add(98); Lista_Paleta_Data.Add(0); // minecraft:stone_bricks.
                    Lista_Paleta_ID.Add(98); Lista_Paleta_Data.Add(1); // minecraft:mossy_stone_bricks.
                    Lista_Paleta_ID.Add(98); Lista_Paleta_Data.Add(2); // minecraft:cracked_stone_bricks.
                    Lista_Paleta_ID.Add(98); Lista_Paleta_Data.Add(3); // minecraft:chiseled_stone_bricks.
                    Lista_Paleta_ID.Add(99); Lista_Paleta_Data.Add(0); // minecraft:brown_mushroom_block.
                    Lista_Paleta_ID.Add(100); Lista_Paleta_Data.Add(0); // minecraft:red_mushroom_block.
                    Lista_Paleta_ID.Add(101); Lista_Paleta_Data.Add(0); // minecraft:iron_bars.
                    Lista_Paleta_ID.Add(102); Lista_Paleta_Data.Add(0); // minecraft:glass_pane.
                    Lista_Paleta_ID.Add(103); Lista_Paleta_Data.Add(0); // minecraft:melon.
                    Lista_Paleta_ID.Add(112); Lista_Paleta_Data.Add(0); // minecraft:nether_bricks.
                    Lista_Paleta_ID.Add(116); Lista_Paleta_Data.Add(0); // minecraft:enchanting_table.
                    Lista_Paleta_ID.Add(117); Lista_Paleta_Data.Add(0); // minecraft:brewing_stand.
                    Lista_Paleta_ID.Add(118); Lista_Paleta_Data.Add(0); // minecraft:cauldron.
                    Lista_Paleta_ID.Add(120); Lista_Paleta_Data.Add(0); // minecraft:end_portal_frame.
                    Lista_Paleta_ID.Add(120); Lista_Paleta_Data.Add(1); // minecraft:end_portal_frame.
                    Lista_Paleta_ID.Add(120); Lista_Paleta_Data.Add(2); // minecraft:end_portal_frame.
                    Lista_Paleta_ID.Add(120); Lista_Paleta_Data.Add(3); // minecraft:end_portal_frame.
                    Lista_Paleta_ID.Add(121); Lista_Paleta_Data.Add(0); // minecraft:end_stone.
                    Lista_Paleta_ID.Add(123); Lista_Paleta_Data.Add(0); // minecraft:redstone_lamp.
                    Lista_Paleta_ID.Add(129); Lista_Paleta_Data.Add(0); // minecraft:emerald_ore.
                    Lista_Paleta_ID.Add(133); Lista_Paleta_Data.Add(0); // minecraft:emerald_block.
                    Lista_Paleta_ID.Add(137); Lista_Paleta_Data.Add(0); // minecraft:command_block.
                    Lista_Paleta_ID.Add(153); Lista_Paleta_Data.Add(0); // minecraft:nether_quartz_ore.
                    Lista_Paleta_ID.Add(154); Lista_Paleta_Data.Add(0); // minecraft:hopper.
                    Lista_Paleta_ID.Add(154); Lista_Paleta_Data.Add(2); // minecraft:hopper.
                    Lista_Paleta_ID.Add(154); Lista_Paleta_Data.Add(3); // minecraft:hopper.
                    Lista_Paleta_ID.Add(154); Lista_Paleta_Data.Add(4); // minecraft:hopper.
                    Lista_Paleta_ID.Add(154); Lista_Paleta_Data.Add(5); // minecraft:hopper.
                    Lista_Paleta_ID.Add(155); Lista_Paleta_Data.Add(0); // minecraft:quartz_block.
                    Lista_Paleta_ID.Add(155); Lista_Paleta_Data.Add(1); // minecraft:chiseled_quartz_block.
                    Lista_Paleta_ID.Add(155); Lista_Paleta_Data.Add(2); // minecraft:quartz_pillar.
                    Lista_Paleta_ID.Add(155); Lista_Paleta_Data.Add(3); // minecraft:quartz_pillar.
                    Lista_Paleta_ID.Add(155); Lista_Paleta_Data.Add(4); // minecraft:quartz_pillar.
                    Lista_Paleta_ID.Add(158); Lista_Paleta_Data.Add(0); // minecraft:dropper.
                    Lista_Paleta_ID.Add(158); Lista_Paleta_Data.Add(1); // minecraft:dropper.
                    Lista_Paleta_ID.Add(158); Lista_Paleta_Data.Add(2); // minecraft:dropper.
                    Lista_Paleta_ID.Add(158); Lista_Paleta_Data.Add(3); // minecraft:dropper.
                    Lista_Paleta_ID.Add(158); Lista_Paleta_Data.Add(4); // minecraft:dropper.
                    Lista_Paleta_ID.Add(158); Lista_Paleta_Data.Add(5); // minecraft:dropper.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(0); // minecraft:white_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(1); // minecraft:orange_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(2); // minecraft:magenta_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(3); // minecraft:light_blue_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(4); // minecraft:yellow_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(5); // minecraft:lime_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(6); // minecraft:pink_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(7); // minecraft:gray_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(8); // minecraft:light_gray_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(9); // minecraft:cyan_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(10); // minecraft:purple_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(11); // minecraft:blue_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(12); // minecraft:brown_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(13); // minecraft:green_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(14); // minecraft:red_terracotta.
                    Lista_Paleta_ID.Add(159); Lista_Paleta_Data.Add(15); // minecraft:black_terracotta.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(0); // minecraft:white_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(1); // minecraft:orange_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(2); // minecraft:magenta_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(3); // minecraft:light_blue_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(4); // minecraft:yellow_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(5); // minecraft:lime_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(6); // minecraft:pink_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(7); // minecraft:gray_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(8); // minecraft:light_gray_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(9); // minecraft:cyan_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(10); // minecraft:purple_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(11); // minecraft:blue_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(12); // minecraft:brown_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(13); // minecraft:green_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(14); // minecraft:red_stained_glass_pane.
                    Lista_Paleta_ID.Add(160); Lista_Paleta_Data.Add(15); // minecraft:black_stained_glass_pane.
                    Lista_Paleta_ID.Add(161); Lista_Paleta_Data.Add(0 | 4); // minecraft:acacia_leaves.
                    Lista_Paleta_ID.Add(161); Lista_Paleta_Data.Add(1 | 4); // minecraft:dark_oak_leaves.
                    Lista_Paleta_ID.Add(162); Lista_Paleta_Data.Add(0); // minecraft:acacia_log.
                    Lista_Paleta_ID.Add(162); Lista_Paleta_Data.Add(1); // minecraft:dark_oak_log.
                    Lista_Paleta_ID.Add(162); Lista_Paleta_Data.Add(0 | 4); // minecraft:acacia_log.
                    Lista_Paleta_ID.Add(162); Lista_Paleta_Data.Add(1 | 4); // minecraft:dark_oak_log.
                    Lista_Paleta_ID.Add(162); Lista_Paleta_Data.Add(0 | 8); // minecraft:acacia_log.
                    Lista_Paleta_ID.Add(162); Lista_Paleta_Data.Add(1 | 8); // minecraft:dark_oak_log.
                    Lista_Paleta_ID.Add(162); Lista_Paleta_Data.Add(0 | 12); // minecraft:acacia_log.
                    Lista_Paleta_ID.Add(162); Lista_Paleta_Data.Add(1 | 12); // minecraft:dark_oak_log.
                    Lista_Paleta_ID.Add(165); Lista_Paleta_Data.Add(0); // minecraft:slime_block.
                    Lista_Paleta_ID.Add(168); Lista_Paleta_Data.Add(0); // minecraft:prismarine.
                    Lista_Paleta_ID.Add(168); Lista_Paleta_Data.Add(1); // minecraft:prismarine_bricks.
                    Lista_Paleta_ID.Add(168); Lista_Paleta_Data.Add(2); // minecraft:dark_prismarine.
                    Lista_Paleta_ID.Add(169); Lista_Paleta_Data.Add(0); // minecraft:sea_lantern.
                    Lista_Paleta_ID.Add(170); Lista_Paleta_Data.Add(0); // minecraft:hay_block.
                    Lista_Paleta_ID.Add(172); Lista_Paleta_Data.Add(0); // minecraft:terracotta.
                    Lista_Paleta_ID.Add(173); Lista_Paleta_Data.Add(0); // minecraft:coal_block.
                    Lista_Paleta_ID.Add(174); Lista_Paleta_Data.Add(0); // minecraft:packed_ice.
                    Lista_Paleta_ID.Add(179); Lista_Paleta_Data.Add(0); // minecraft:red_sandstone.
                    Lista_Paleta_ID.Add(179); Lista_Paleta_Data.Add(1); // minecraft:chiseled_red_sandstone.
                    Lista_Paleta_ID.Add(179); Lista_Paleta_Data.Add(2); // minecraft:cut_red_sandstone.
                    Lista_Paleta_ID.Add(198); Lista_Paleta_Data.Add(0); // minecraft:end_rod.
                    Lista_Paleta_ID.Add(201); Lista_Paleta_Data.Add(0); // minecraft:purpur_block.
                    Lista_Paleta_ID.Add(202); Lista_Paleta_Data.Add(0); // minecraft:purpur_pillar.
                    Lista_Paleta_ID.Add(206); Lista_Paleta_Data.Add(0); // minecraft:end_stone_bricks.
                    Lista_Paleta_ID.Add(210); Lista_Paleta_Data.Add(0); // minecraft:repeating_command_block.
                    Lista_Paleta_ID.Add(211); Lista_Paleta_Data.Add(0); // minecraft:chain_command_block.
                    Lista_Paleta_ID.Add(213); Lista_Paleta_Data.Add(0); // minecraft:magma_block.
                    Lista_Paleta_ID.Add(214); Lista_Paleta_Data.Add(0); // minecraft:nether_wart_block.
                    Lista_Paleta_ID.Add(215); Lista_Paleta_Data.Add(0); // minecraft:red_nether_bricks.
                    Lista_Paleta_ID.Add(216); Lista_Paleta_Data.Add(0); // minecraft:bone_block.
                    Lista_Paleta_ID.Add(235); Lista_Paleta_Data.Add(0); // minecraft:white_glazed_terracotta.
                    Lista_Paleta_ID.Add(236); Lista_Paleta_Data.Add(0); // minecraft:orange_glazed_terracotta.
                    Lista_Paleta_ID.Add(237); Lista_Paleta_Data.Add(0); // minecraft:magenta_glazed_terracotta.
                    Lista_Paleta_ID.Add(238); Lista_Paleta_Data.Add(0); // minecraft:light_blue_glazed_terracotta.
                    Lista_Paleta_ID.Add(239); Lista_Paleta_Data.Add(0); // minecraft:yellow_glazed_terracotta.
                    Lista_Paleta_ID.Add(240); Lista_Paleta_Data.Add(0); // minecraft:lime_glazed_terracotta.
                    Lista_Paleta_ID.Add(241); Lista_Paleta_Data.Add(0); // minecraft:pink_glazed_terracotta.
                    Lista_Paleta_ID.Add(242); Lista_Paleta_Data.Add(0); // minecraft:gray_glazed_terracotta.
                    Lista_Paleta_ID.Add(243); Lista_Paleta_Data.Add(0); // minecraft:light_gray_glazed_terracotta.
                    Lista_Paleta_ID.Add(244); Lista_Paleta_Data.Add(0); // minecraft:cyan_glazed_terracotta.
                    Lista_Paleta_ID.Add(245); Lista_Paleta_Data.Add(0); // minecraft:purple_glazed_terracotta.
                    Lista_Paleta_ID.Add(246); Lista_Paleta_Data.Add(0); // minecraft:blue_glazed_terracotta.
                    Lista_Paleta_ID.Add(247); Lista_Paleta_Data.Add(0); // minecraft:brown_glazed_terracotta.
                    Lista_Paleta_ID.Add(248); Lista_Paleta_Data.Add(0); // minecraft:green_glazed_terracotta.
                    Lista_Paleta_ID.Add(249); Lista_Paleta_Data.Add(0); // minecraft:red_glazed_terracotta.
                    Lista_Paleta_ID.Add(250); Lista_Paleta_Data.Add(0); // minecraft:black_glazed_terracotta.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(0); // minecraft:white_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(1); // minecraft:orange_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(2); // minecraft:magenta_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(3); // minecraft:light_blue_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(4); // minecraft:yellow_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(5); // minecraft:lime_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(6); // minecraft:pink_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(7); // minecraft:gray_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(8); // minecraft:light_gray_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(9); // minecraft:cyan_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(10); // minecraft:purple_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(11); // minecraft:blue_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(12); // minecraft:brown_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(13); // minecraft:green_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(14); // minecraft:red_concrete.
                    Lista_Paleta_ID.Add(251); Lista_Paleta_Data.Add(15); // minecraft:black_concrete.

                    // Check if the palette has any repeated block ID and Data.
                    int Repetidos = 0;
                    string Texto_Repetidos = null;
                    if (Lista_Paleta_ID.Count >= 256 && Lista_Paleta_Data.Count >= 256)
                    {
                        for (int Índice = 0; Índice < 256; Índice++)
                        {
                            for (int Índice_Repetido = 0; Índice_Repetido < 256; Índice_Repetido++)
                            {
                                if (Índice != Índice_Repetido)
                                {
                                    if (Lista_Paleta_ID[Índice] == Lista_Paleta_ID[Índice_Repetido] &&
                                        Lista_Paleta_Data[Índice] == Lista_Paleta_Data[Índice_Repetido])
                                    {
                                        Repetidos++;
                                        Texto_Repetidos += Lista_Paleta_ID[Índice].ToString() + ", " + Lista_Paleta_Data[Índice].ToString() + "\r\n";
                                        break;
                                    }
                                }
                            }
                        }
                        if (Repetidos > 0) MessageBox.Show(this, "Repeated blocks in the palette: " + Repetidos.ToString() + ".\r\n\r\n" + Texto_Repetidos, Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Check if the palette ID and Data has more or less than 256 blocks.
                    if (Lista_Paleta_ID.Count != 256 || Lista_Paleta_Data.Count != 256)
                    {
                        MessageBox.Show(this, "Block ID and Data in the palette: " + Lista_Paleta_ID.Count.ToString() + ", " + Lista_Paleta_Data.Count.ToString() + ".", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                Numérico_Altura.Value = Variable_Altura;
                CheckBox_Contraseña.Checked = Variable_Contraseña;
                TextBox_Contraseña.Text = Variable_Texto_Contraseña;
                CheckBox_Cifrado_Bits_Base_2.Checked = Variable_Cifrado_Bits_Base_2;
                CheckBox_Cifrado_Bits_Base_4.Checked = Variable_Cifrado_Bits_Base_4;
                CheckBox_Cifrado_Bits_Base_16.Checked = Variable_Cifrado_Bits_Base_16;
                CheckBox_Cifrado_Bits_Negativo.Checked = Variable_Cifrado_Bits_Base_Negativo;
                int Bits_Bloque = (Lista_Paleta_ID.Count * 8) / 256;
                int Bits_Chunk = Bits_Bloque * 65536;
                this.Text = Texto_Título; // + " - [Blocks in the palette: " + Program.Traducir_Número(Lista_Paleta_ID.Count) + " (" + Program.Traducir_Número(Bits_Bloque) + (Bits_Bloque != 1 ? " bits" : " bit") + " per block or " + Program.Traducir_Tamaño_Bytes_Automático((long)Bits_Chunk / 8L, 2, false) + " per chunk)]";
                this.WindowState = FormWindowState.Maximized;
                Ocupado = true;
                Registro_Cargar_Opciones();
                Ocupado = false;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Codificador_Descodificador_Archivos_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Activate();
                Temporizador_Principal.Start();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Codificador_Descodificador_Archivos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Temporizador_Principal.Stop();
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Codificador_Descodificador_Archivos_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Codificador_Descodificador_Archivos_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, true) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); }
        }

        private void Ventana_Codificador_Descodificador_Archivos_DragDrop(object sender, DragEventArgs e)
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
                                if (!string.IsNullOrEmpty(Ruta) && (File.Exists(Ruta) || Directory.Exists(Ruta)))
                                {
                                    Codificar_Descodificar_Archivo(Ruta);
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
            finally { this.Cursor = Cursors.Default; }
        }

        private void Ventana_Codificador_Descodificador_Archivos_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Ventana_Codificador_Descodificador_Archivos_KeyDown(object sender, KeyEventArgs e)
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

        private void TextBox_Contraseña_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Texto_Contraseña = TextBox_Contraseña.Text;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Cifrado_Bits_Base_2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Cifrado_Bits_Base_2 = CheckBox_Cifrado_Bits_Base_2.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Cifrado_Bits_Base_4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Cifrado_Bits_Base_4 = CheckBox_Cifrado_Bits_Base_4.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Cifrado_Bits_Base_16_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Cifrado_Bits_Base_16 = CheckBox_Cifrado_Bits_Base_16.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void CheckBox_Cifrado_Bits_Negativo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Cifrado_Bits_Base_Negativo = CheckBox_Cifrado_Bits_Negativo.Checked;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        /// <summary>
        /// Encodes and encrypts any file inside a new Minecraft 1.12.2- world (or tries to extract an existing one from a world). It can be extracted later on, even by other users of this application, as long as they know the password and encryption methods originally used. WARNING: don't use this to send any illegal file or to make anything bad. Jupisoft won't be responsible if any user uses the tools provided with bad intentions.
        /// </summary>
        /// <param name="Ruta_Entrada">Any valid and existing file path for encoding (you can add multiple files at once if you put them in a zip file first and then encode that zip file here), or any valid and existing directory path for decoding (any Minecraft 1.12.2- world folder with a file in it).</param>
        internal void Codificar_Descodificar_Archivo(string Ruta_Entrada)
        {
            try
            {
                if (!string.IsNullOrEmpty(Ruta_Entrada) && (File.Exists(Ruta_Entrada) || Directory.Exists(Ruta_Entrada)) && Lista_Paleta_ID != null && Lista_Paleta_ID.Count >= 256 && Lista_Paleta_Data != null && Lista_Paleta_Data.Count >= 256)
                {
                    if (File.Exists(Ruta_Entrada)) // Encode a file.
                    {
                        //byte[] Matriz_Paleta_ID = Lista_Paleta_ID.ToArray();
                        //byte[] Matriz_Paleta_Data = Lista_Paleta_Data.ToArray();
                        AlphaBlock[] Matriz_Bloques_Paleta = new AlphaBlock[256];
                        for (int Índice = 0; Índice < 256; Índice++)
                        {
                            Matriz_Bloques_Paleta[Índice] = new AlphaBlock(Lista_Paleta_ID[Índice], Lista_Paleta_Data[Índice]);
                        }
                        byte[] Matriz_Bytes_Filtros = Program.Combinar_Matrices_Bytes_Filtros(new byte[][]
                        {
                            (!Variable_Cifrado_Bits_Base_2 ? null : Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_2),
                            (!Variable_Cifrado_Bits_Base_4 ? null : Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_4),
                            (!Variable_Cifrado_Bits_Base_16 ? null : Program.Matriz_Bytes_Filtro_Invertir_Bits_Base_16),
                            (!Variable_Cifrado_Bits_Base_Negativo ? null : Program.Matriz_Bytes_Filtro_Negativo),
                        });
                        FileStream Lector = new FileStream(Ruta_Entrada, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        Lector.Seek(0L, SeekOrigin.Begin);
                        if (Lector.Length > 0L)
                        {
                            string Ruta = Program.Ruta_Guardado_Minecraft + "\\" + Program.Obtener_Nombre_Temporal() + " File";
                            if (Directory.Exists(Ruta))
                            {
                                this.Invoke(new Invocación.Delegado_IWin32Window_MessageBox(Invocación.Ejecutar_Delegado_IWin32Window_MessageBox), new object[] { this, "Somehow the directory name for the new Minecraft map already exists.\r\nPlease try it again if the system clock is running properly.\r\nPath: \"" + Ruta + "\".", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning });
                                Ruta = null;
                                return;
                            }
                            Program.Crear_Carpetas(Ruta);
                            AnvilWorld Mundo = AnvilWorld.Create(Ruta);
                            Mundo.Level.LevelName = Path.GetFileName(Ruta);
                            Mundo.Level.UseMapFeatures = true;
                            Mundo.Level.GameType = GameType.CREATIVE;
                            Mundo.Level.Spawn = new SpawnPoint(8, 2, 8);
                            Mundo.Level.AllowCommands = true; // Allow cheats.
                            Mundo.Level.GameRules.DoMobSpawning = false; // Never spawn mobs.
                            Mundo.Level.GameRules.DoFireTick = false; // Prevent the new level to burn out.
                            Mundo.Level.GameRules.MobGriefing = false; // Prevent the mobs to destroy anything.
                            Mundo.Level.GameRules.KeepInventory = true; // Keep the player inventory.
                            Mundo.Level.RainTime = 0;
                            Mundo.Level.IsRaining = false;
                            Mundo.Level.Player = new Player();
                            Mundo.Level.Player.Dimension = 0; // 0 = Overworld, -1 = Nether, +1 = The End.
                            Mundo.Level.Player.Position = new Vector3();
                            Mundo.Level.Player.Position.X = (double)8;
                            Mundo.Level.Player.Position.Y = (double)256;
                            Mundo.Level.Player.Position.Z = (double)8;
                            Substrate.Orientation Orientación = new Substrate.Orientation();
                            Orientación.Pitch = 45d; // -90º a +90º // 45º = Camera centered (looking into the horizon).
                            Orientación.Yaw = -45d; // -180º a +180º // -45º = Camera rotation (looking at the southeast).
                            Mundo.Level.Player.Rotation = Orientación;
                            Mundo.Level.Player.Spawn = new SpawnPoint(8, 2, 8);
                            Mundo.Level.Player.Abilities.Flying = true; // Start with creative flight enabled.
                            Mundo.Level.RandomSeed = 4L;
                            Mundo.Level.ThunderTime = 0;
                            Mundo.Level.IsThundering = false;

                            IChunkManager Chunks = Mundo.GetChunkManager(0);
                            BlockManager Bloques = Mundo.GetBlockManager(0);

                            bool Terminado = false;

                            ChunkRef Chunk_Cabecera = Chunks.CreateChunk(1, 1);
                            Chunk_Cabecera.IsLightPopulated = true; // For 1.13+ conversion support.
                            Chunk_Cabecera.IsTerrainPopulated = true;
                            Chunk_Cabecera.Blocks.AutoLight = false;

                            // TODO: Encrypt the CRCs also like the file bytes.
                            uint CRC_32_Original = 0;
                            uint CRC_32_Cifrado = 0;

                            // Add 2 Jupisoft icons on the -1, -1 chunk, so if they are missing the world will be invalid.
                            Bitmap Imagen_Jupisoft = Resources.Jupisoft.Clone(new Rectangle(0, 0, 16, 16), PixelFormat.Format32bppArgb);
                            BitmapData Bitmap_Data = Imagen_Jupisoft.LockBits(new Rectangle(0, 0, 16, 16), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                            byte[] Matriz_Bytes_Jupisoft = new byte[Math.Abs(Bitmap_Data.Stride) * 16];
                            Marshal.Copy(Bitmap_Data.Scan0, Matriz_Bytes_Jupisoft, 0, Matriz_Bytes_Jupisoft.Length);
                            Imagen_Jupisoft.UnlockBits(Bitmap_Data);
                            Bitmap_Data = null;
                            Imagen_Jupisoft.Dispose();
                            Imagen_Jupisoft = null;
                            for (int Bloque_Z = 0, Índice_BGRA = 0; Bloque_Z < 16; Bloque_Z++)
                            {
                                for (int Bloque_X = 0; Bloque_X < 16; Bloque_X++, Índice_BGRA += 4)
                                {
                                    if (Matriz_Bytes_Jupisoft[Índice_BGRA + 2] >= 255 && Matriz_Bytes_Jupisoft[Índice_BGRA + 1] >= 255 && Matriz_Bytes_Jupisoft[Índice_BGRA] >= 255) // White.
                                    {
                                        Chunk_Cabecera.Blocks.SetBlock(Bloque_X, 0, Bloque_Z, new AlphaBlock(251, 0)); // minecraft:white_concrete.
                                        Chunk_Cabecera.Blocks.SetBlock(Bloque_X, 255, Bloque_Z, new AlphaBlock(251, 0)); // minecraft:white_concrete.
                                    }
                                    else if (Matriz_Bytes_Jupisoft[Índice_BGRA + 2] <= 0 && Matriz_Bytes_Jupisoft[Índice_BGRA + 1] <= 0 && Matriz_Bytes_Jupisoft[Índice_BGRA] <= 0) // Black.
                                    {
                                        Chunk_Cabecera.Blocks.SetBlock(Bloque_X, 0, Bloque_Z, new AlphaBlock(251, 15)); // minecraft:black_concrete.
                                        Chunk_Cabecera.Blocks.SetBlock(Bloque_X, 255, Bloque_Z, new AlphaBlock(251, 15)); // minecraft:black_concrete.
                                    }
                                    else // Red.
                                    {
                                        Chunk_Cabecera.Blocks.SetBlock(Bloque_X, 0, Bloque_Z, new AlphaBlock(251, 14)); // minecraft:red_concrete.
                                        Chunk_Cabecera.Blocks.SetBlock(Bloque_X, 255, Bloque_Z, new AlphaBlock(251, 14)); // minecraft:red_concrete.
                                    }
                                    //Chunk_Cabecera.Blocks.SetBlockLight(Bloque_X, 0, Bloque_Z, 15); // Maximum light.
                                    //Chunk_Cabecera.Blocks.SetBlockLight(Bloque_X, 255, Bloque_Z, 15); // Maximum light.
                                }
                            }
                            Matriz_Bytes_Jupisoft = null;

                            // Write the full block palette in the second chunk section.
                            for (int Bloque_Z = 0, Índice_Paleta = 0; Bloque_Z < 16; Bloque_Z++)
                            {
                                for (int Bloque_X = 0; Bloque_X < 16; Bloque_X++, Índice_Paleta++)
                                {
                                    Chunk_Cabecera.Blocks.SetBlock(Bloque_X, 16, Bloque_Z, Matriz_Bloques_Paleta[Índice_Paleta]);
                                    //Chunk_Cabecera.Blocks.SetBlockLight(Bloque_X, 16, Bloque_Z, 15); // Maximum light.
                                }
                            }

                            // Add the original file name, it's extension and it's length to the "header" chunk.
                            string Nombre = Path.GetFileName(Ruta_Entrada);
                            byte[] Matriz_Bytes_Nombre = Encoding.Unicode.GetBytes(Nombre);
                            if (Matriz_Bytes_Nombre.Length > 4092) // Use only 1 section for the file name.
                            {
                                Array.Resize(ref Matriz_Bytes_Nombre, 4092);
                            }
                            byte[] Matriz_Bytes_Nombre_Longitud = BitConverter.GetBytes(Matriz_Bytes_Nombre.Length);
                            for (int Bloque_Y = 32, Índice_Byte = -4; Bloque_Y < 48; Bloque_Y++) // The second section.
                            {
                                for (int Bloque_Z = 0; Bloque_Z < 16; Bloque_Z++)
                                {
                                    for (int Bloque_X = 0; Bloque_X < 16; Bloque_X++, Índice_Byte++)
                                    {
                                        if (Índice_Byte < Matriz_Bytes_Nombre.Length)
                                        {
                                            Chunk_Cabecera.Blocks.SetBlock(Bloque_X, Bloque_Y, Bloque_Z, Matriz_Bloques_Paleta[Índice_Byte >= 0 ? Matriz_Bytes_Nombre[Índice_Byte] : Matriz_Bytes_Nombre_Longitud[Índice_Byte + 4]]);
                                            //Chunk_Cabecera.Blocks.SetBlockLight(Bloque_X, Bloque_Y, Bloque_Z, 15); // Maximum light.
                                        }
                                        else
                                        {
                                            Terminado = true;
                                            break;
                                        }
                                    }
                                    if (Terminado) break;
                                }
                                if (Terminado) break;
                            }
                            Terminado = false; // Reset the loop breaker.

                            // Now add all the available bytes in the input file, even encrypting them for safety.
                            long Total_Bytes = 0L;
                            long Total_Bytes_Cifrados = 0L;
                            int Índice_Byte_Bloque = int.MaxValue;
                            int Longitud = 0;
                            byte[] Matriz_Bytes = new byte[4096]; // 65536.
                            //byte[] Matriz_Bytes_Cifrado = null;
                            for (int Región_X = 0; Región_X < int.MaxValue; Región_X++) // Do a maximum of horizontal regions.
                            {
                                for (int Chunk_Z = 0; Chunk_Z < 32; Chunk_Z++) // Do 32 vertical chunks per region.
                                {
                                    for (int Chunk_X = 0; Chunk_X < 32; Chunk_X++) // Do 32 horizontal chunks per region.
                                    {
                                        if (Región_X > 0 || Chunk_X != 1 || Chunk_Z != 1) // Not the "header" chunk.
                                        {
                                            ChunkRef Chunk = Chunks.CreateChunk((Región_X * 32) + (Chunk_X), Chunk_Z);
                                            Chunk.IsLightPopulated = true; // For 1.13+ conversion support.
                                            Chunk.IsTerrainPopulated = true;
                                            Chunk.Blocks.AutoLight = false;
                                            for (int Bloque_Y = 0; Bloque_Y < Variable_Altura; Bloque_Y++) // Do a custom maximum height.
                                            {
                                                for (int Bloque_Z = 0; Bloque_Z < 16; Bloque_Z++) // Do 16 deep blocks per chunk.
                                                {
                                                    for (int Bloque_X = 0; Bloque_X < 16; Bloque_X++) // Do 16 horizontal blocks per chunk.
                                                    {
                                                        if ((Región_X > 0 || Chunk_X > 0) && (Chunk_Z > 0 && Chunk_Z < 31)) // Avoid the region X-Z borders.
                                                        {
                                                            if (Índice_Byte_Bloque >= Matriz_Bytes.Length) // Read the next part of the file.
                                                            {
                                                                Índice_Byte_Bloque = 0;
                                                                Longitud = Lector.Read(Matriz_Bytes, 0, Matriz_Bytes.Length);
                                                                if (Longitud > 0)
                                                                {
                                                                    Total_Bytes += Longitud;
                                                                    CRC_32_Original = Program.Calcular_CRC32(Matriz_Bytes, Longitud, CRC_32_Original);
                                                                }
                                                                else // The end of the file, finish everything now.
                                                                {
                                                                    Terminado = true;
                                                                    //break;
                                                                }
                                                                // This filters are 100 % reversible on a second pass, but in reverse order.
                                                                if (Matriz_Bytes_Filtros != null && Matriz_Bytes_Filtros.Length >= 256)
                                                                {
                                                                    for (int Índice = 0; Índice < Longitud; Índice++) // Encrypt the bytes.
                                                                    {
                                                                        Matriz_Bytes[Índice] = Matriz_Bytes_Filtros[Matriz_Bytes[Índice]];
                                                                    }
                                                                }
                                                                if (Variable_Contraseña && !string.IsNullOrEmpty(Variable_Texto_Contraseña)) // Encrypt them even more.
                                                                {
                                                                    Matriz_Bytes = Encrypt(Matriz_Bytes, Variable_Texto_Contraseña);
                                                                    if (Matriz_Bytes.Length != Longitud)
                                                                    {
                                                                        MessageBox.Show(Matriz_Bytes.Length.ToString() + " != " + Longitud.ToString() + ".", "Different lenghts after encryption");
                                                                        Longitud = Matriz_Bytes.Length; // Is this a problem?
                                                                    }
                                                                }
                                                                Total_Bytes_Cifrados += Longitud;
                                                                CRC_32_Cifrado = Program.Calcular_CRC32(Matriz_Bytes, Longitud, CRC_32_Cifrado);
                                                            }
                                                            Chunk.Blocks.SetBlock(Bloque_X, Bloque_Y, Bloque_Z, Matriz_Bloques_Paleta[!Terminado ? Matriz_Bytes[Índice_Byte_Bloque] : 0]);
                                                            //Chunk.Blocks.SetBlockLight(Bloque_X, Bloque_Y, Bloque_Z, 15); // Maximum light.
                                                            Índice_Byte_Bloque++;
                                                        }
                                                        else
                                                        {
                                                            // Set the border chunks to air blocks to avoid flowing water and lava.
                                                            Chunk.Blocks.SetBlock(Bloque_X, Bloque_Y, Bloque_Z, Matriz_Bloques_Paleta[0]);
                                                        }
                                                        Chunk.Blocks.SetBlockLight(Bloque_X, Bloque_Y, Bloque_Z, 15); // Maximum light.
                                                    }
                                                    //if (Terminado) break;
                                                }
                                                //if (Terminado) break;
                                            }
                                            Chunk.Blocks.RebuildHeightMap(); // Automatic height map.
                                            //Chunk.Blocks.RebuildBlockLight(); // Automatic block light.
                                            Chunk.Blocks.RebuildSkyLight(); // Automatic sky light.
                                        }
                                        //if (Terminado) break;
                                    }
                                    //if (Terminado) break;
                                }
                                Chunks.Save(); // Save the chunks of the new region to save RAM memory.
                                GC.Collect(); // Recover RAM memory after every region file.
                                GC.GetTotalMemory(true);
                                if (Terminado) break;
                            }

                            //if (Terminado) // File successfully encoded and encrypted.
                            {
                                Chunk_Cabecera.Blocks.RebuildHeightMap(); // Automatic height map.
                                Chunk_Cabecera.Blocks.RebuildBlockLight(); // Automatic block light.
                                Chunk_Cabecera.Blocks.RebuildSkyLight(); // Automatic sky light.
                                Chunks.Save();
                                Chunks = null;
                                Bloques = null;
                                Mundo.Save();
                                Mundo = null;
                                GC.Collect();
                                GC.GetTotalMemory(true);
                                MessageBox.Show(this, "Done!");
                                Program.Ejecutar_Ruta(Ruta, ProcessWindowStyle.Maximized);
                            }
                            /*else
                            {
                                MessageBox.Show("Not finished?");
                            }*/
                        }
                        else this.Invoke(new Invocación.Delegado_IWin32Window_MessageBox(Invocación.Ejecutar_Delegado_IWin32Window_MessageBox), new object[] { this, "The selected file is empty so the new world can't be generated.\r\nPlease select another file with some content and try again.\r\nPath: \"" + Ruta_Entrada + "\".", Program.Texto_Título_Versión, MessageBoxButtons.OK, MessageBoxIcon.Warning });
                        Lector.Close();
                        Lector.Dispose();
                        Lector = null;
                    }
                    else // Decode a file.
                    {

                    }
                }
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }

        private void Numérico_Altura_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Variable_Altura = (int)Numérico_Altura.Value;
            }
            catch (Exception Excepción) { Depurador.Escribir_Excepción(Excepción != null ? Excepción.ToString() : null); Variable_Excepción_Total++; Variable_Excepción = true; }
        }
    }
}

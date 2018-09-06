using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Tools
{
    /// <summary>
    /// This class comes from another app that I made years ago and currently is here only for old references.
    /// </summary>
    internal static class Minecraft_Old
    {
        internal static List<String> Lista_Nombres_Seleccionados = null;
        internal static List<String> Lista_Nombres_Seleccionados_PC = null;
        internal static List<String> Lista_Nombres_Seleccionados_Edición_Consola = new List<String>();

        /// <summary>
        /// Acceder Y, luego X.
        /// </summary>
        internal static readonly String[][] Matriz_Edición_Consola_Nombres = new String[32][]
        {
            new String[16]{ "grass_top", "stone", "dirt", "grass_side", "planks_oak", "stone_slab_side", "stone_slab_top", "brick", "tnt_side", "tnt_top", "tnt_bottom", "web", "flower_rose", "flower_dandelion", "portal", "sapling_oak" },
            new String[16]{ "cobblestone", "bedrock", "sand", "gravel", "log_oak", "log_oak_top", "iron_block", "gold_block", "diamond_block", "emerald_block", "redstone_block", "dropper_front_horizontal", "mushroom_red", "mushroom_brown", "sapling_jungle", "fire_layer_0" },
            new String[16]{ "gold_ore", "iron_ore", "coal_ore", "bookshelf", "cobblestone_mossy", "obsidian", "grass_side_overlay", "tallgrass", "dispenser_front_vertical", "beacon", "dropper_front_vertical", "crafting_table_top", "furnace_front_off", "furnace_side", "dispenser_front_horizontal", "fire_layer_0" },
            new String[16]{ "sponge", "glass", "diamond_ore", "redstone_ore", "leaves_oak", "leaves_oak", "stonebrick", "deadbush", "fern", "daylight_detector_top", "daylight_detector_side", "crafting_table_side", "crafting_table_front", "furnace_front_on", "furnace_top", "sapling_spruce" },
            new String[16]{ "wool_colored_white", "mob_spawner", "snow", "ice", "grass_side_snowed", "cactus_top", "cactus_side", "cactus_bottom", "clay", "reeds", "jukebox_side", "jukebox_top", "waterlily", "mycelium_side", "mycelium_top", "sapling_birch" },
            new String[16]{ "torch_on", "door_wood_upper", "door_iron_upper", "ladder", "trapdoor", "iron_bars", "farmland_wet", "farmland_dry", "wheat_stage_0", "wheat_stage_1", "wheat_stage_2", "wheat_stage_3", "wheat_stage_4", "wheat_stage_5", "wheat_stage_6", "wheat_stage_7" },
            new String[16]{ "lever", "door_wood_lower", "door_iron_lower", "redstone_torch_on", "stonebrick_mossy", "stonebrick_cracked", "pumpkin_top", "netherrack", "soul_sand", "glowstone", "piston_top_sticky", "piston_top_normal", "piston_side", "piston_bottom", "piston_inner", "pumpkin_stem_disconnected" },
            new String[16]{ "rail_normal_turned", "wool_colored_black", "wool_colored_gray", "redstone_torch_off", "log_spruce", "log_birch", "pumpkin_side", "pumpkin_face_off", "pumpkin_face_on", "cake_top", "cake_side", "cake_inner", "cake_bottom", "mushroom_block_skin_red", "mushroom_block_skin_brown", "pumpkin_stem_connected" },
            new String[16]{ "rail_normal", "wool_colored_red", "wool_colored_pink", "repeater_off", "leaves_spruce", "leaves_spruce", "bed_feet_top", "bed_head_top", "melon_side", "melon_top", "cauldron_top", "cauldron_inner", "sponge_wet", "mushroom_block_skin_stem", "mushroom_block_inside", "vine" },
            new String[16]{ "lapis_block", "wool_colored_green", "wool_colored_lime", "repeater_on", "glass_pane_top", "bed_feet_end", "bed_feet_side", "bed_head_side", "bed_head_end", "log_jungle", "cauldron_side", "cauldron_bottom", "brewing_stand_base", "brewing_stand", "endframe_top", "endframe_side" },
            new String[16]{ "lapis_ore", "wool_colored_brown", "wool_colored_yellow", "rail_golden", "redstone_dust_line0", "redstone_dust_line1", "enchanting_table_top", "dragon_egg", "cocoa_stage_2", "cocoa_stage_1", "cocoa_stage_0", "emerald_ore", "trip_wire_source", "trip_wire", "endframe_eye", "end_stone" },
            new String[16]{ "sandstone_top", "wool_colored_blue", "wool_colored_light_blue", "rail_golden_powered", "redstone_dust_overlay", "redstone_dust_overlay", "enchanting_table_side", "enchanting_table_bottom", "command_block_back", "itemframe_background", "flower_pot", "comparator_off", "comparator_on", "rail_activator", "rail_activator_powered", "quartz_ore" },
            new String[16]{ "sandstone_normal", "wool_colored_purple", "wool_colored_magenta", "rail_detector", "leaves_jungle", "leaves_jungle", "planks_spruce", "planks_jungle", "carrots_stage_0", "carrots_stage_1", "carrots_stage_2", "carrots_stage_3", "slime", "water_flow", "water_flow", "water_flow" },
            new String[16]{ "sandstone_bottom", "wool_colored_cyan", "wool_colored_orange", "redstone_lamp_off", "redstone_lamp_on", "stonebrick_carved", "planks_birch", "anvil_base", "anvil_top_damaged_1", "quartz_block_chiseled_top", "quartz_block_lines_top", "quartz_block_top", "hopper_outside", "rail_detector_powered", "water_flow", "water_flow" },
            new String[16]{ "nether_brick", "wool_colored_silver", "nether_wart_stage_0", "nether_wart_stage_1", "nether_wart_stage_2", "sandstone_carved", "sandstone_smooth", "anvil_top_damaged_0", "anvil_top_damaged_2", "quartz_block_chiseled", "quartz_block_lines", "quartz_block_side", "hopper_inside", "lava_flow", "lava_flow", "lava_flow" },
            new String[16]{ "destroy_stage_0", "destroy_stage_1", "destroy_stage_2", "destroy_stage_3", "destroy_stage_4", "destroy_stage_5", "destroy_stage_6", "destroy_stage_7", "destroy_stage_8", "destroy_stage_9", "hay_block_side", "quartz_block_bottom", "hopper_top", "hay_block_top", "lava_flow", "lava_flow" },

            new String[16]{ "coal_block", "hardened_clay", "noteblock", "stone_andesite", "stone_andesite_smooth", "stone_diorite", "stone_diorite_smooth", "stone_granite", "stone_granite_smooth", "potatoes_stage_0", "potatoes_stage_1", "potatoes_stage_2", "potatoes_stage_3", "log_spruce_top", "log_jungle_top", "log_birch_top" },
            new String[16]{ "hardened_clay_stained_black", "hardened_clay_stained_blue", "hardened_clay_stained_brown", "hardened_clay_stained_cyan", "hardened_clay_stained_gray", "hardened_clay_stained_green", "hardened_clay_stained_light_blue", "hardened_clay_stained_lime", "hardened_clay_stained_magenta", "hardened_clay_stained_orange", "hardened_clay_stained_pink", "hardened_clay_stained_purple", "hardened_clay_stained_red", "hardened_clay_stained_silver", "hardened_clay_stained_white", "hardened_clay_stained_yellow" },
            new String[16]{ "glass_black", "glass_blue", "glass_brown", "glass_cyan", "glass_gray", "glass_green", "glass_light_blue", "glass_lime", "glass_magenta", "glass_orange", "glass_pink", "glass_purple", "glass_red", "glass_silver", "glass_white", "glass_yellow" },
            new String[16]{ "glass_pane_top_black", "glass_pane_top_blue", "glass_pane_top_brown", "glass_pane_top_cyan", "glass_pane_top_gray", "glass_pane_top_green", "glass_pane_top_light_blue", "glass_pane_top_lime", "glass_pane_top_magenta", "glass_pane_top_orange", "glass_pane_top_pink", "glass_pane_top_purple", "glass_pane_top_red", "glass_pane_top_silver", "glass_pane_top_white", "glass_pane_top_yellow" },
            new String[16]{ "double_plant_fern_top", "double_plant_grass_top", "double_plant_paeonia_top", "double_plant_rose_top", "double_plant_syringa_top", "flower_tulip_orange", "double_plant_sunflower_top", "double_plant_sunflower_front", "log_acacia", "log_acacia_top", "planks_acacia", "leaves_acacia", "leaves_acacia", "prismarine_bricks", "red_sand", "red_sandstone_top" },
            new String[16]{ "double_plant_fern_bottom", "double_plant_grass_bottom", "double_plant_paeonia_bottom", "double_plant_rose_bottom", "double_plant_syringa_bottom", "flower_tulip_pink", "double_plant_sunflower_bottom", "double_plant_sunflower_back", "log_big_oak", "log_big_oak_top", "planks_big_oak", "leaves_big_oak", "leaves_big_oak", "prismarine_dark", "red_sandstone_bottom", "red_sandstone_normal" },
            new String[16]{ "flower_allium", "flower_blue_orchid", "flower_houstonia", "flower_oxeye_daisy", "flower_tulip_red", "flower_tulip_white", "sapling_acacia", "sapling_roofed_oak", "coarse_dirt", "dirt_podzol_side", "dirt_podzol_top", "", "", "prismarine_rough", "red_sandstone_carved", "red_sandstone_smooth" },
            new String[16]{ "door_acacia_upper", "door_birch_upper", "door_dark_oak_upper", "door_jungle_upper", "door_spruce_upper", "", "", "", "", "", "", ""/*"barrier"/*items*/, "ice_packed", "sea_lantern", "daylight_detector_inverted_top", "iron_trapdoor" },
            new String[16]{ "door_acacia_lower", "door_birch_lower", "door_dark_oak_lower", "door_jungle_lower", "door_spruce_lower", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Original = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 147, 147, 147), Color.FromArgb(255, 125, 125, 125), Color.FromArgb(255, 134, 96, 67), Color.FromArgb(255, 127, 107, 66), Color.FromArgb(255, 157, 128, 79), Color.FromArgb(255, 167, 167, 167), Color.FromArgb(255, 159, 159, 159), Color.FromArgb(255, 147, 100, 87), Color.FromArgb(255, 170, 93, 71), Color.FromArgb(255, 130, 65, 47), Color.FromArgb(255, 170, 77, 51), Color.FromArgb(255, 220, 220, 220), Color.FromArgb(255, 101, 58, 4), Color.FromArgb(255, 108, 162, 1), Color.FromArgb(255, 0, 42, 255), Color.FromArgb(255, 72, 102, 38),  },
            new Color[16]{ Color.FromArgb(255, 123, 123, 123), Color.FromArgb(255, 84, 84, 84), Color.FromArgb(255, 219, 211, 160), Color.FromArgb(255, 127, 124, 123), Color.FromArgb(255, 102, 81, 50), Color.FromArgb(255, 155, 125, 77), Color.FromArgb(255, 219, 219, 219), Color.FromArgb(255, 249, 236, 79), Color.FromArgb(255, 98, 219, 214), Color.FromArgb(255, 81, 217, 117), Color.FromArgb(255, 171, 28, 9), Color.FromArgb(255, 117, 117, 117), Color.FromArgb(255, 195, 54, 56), Color.FromArgb(255, 138, 106, 84), Color.FromArgb(255, 49, 86, 19), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 143, 140, 125), Color.FromArgb(255, 136, 130, 127), Color.FromArgb(255, 115, 115, 115), Color.FromArgb(255, 108, 88, 58), Color.FromArgb(255, 104, 121, 104), Color.FromArgb(255, 20, 18, 30), Color.FromArgb(255, 143, 143, 143), Color.FromArgb(255, 117, 117, 117), Color.FromArgb(255, 87, 87, 87), Color.FromArgb(255, 117, 221, 216), Color.FromArgb(255, 87, 87, 87), Color.FromArgb(255, 107, 71, 43), Color.FromArgb(255, 78, 78, 78), Color.FromArgb(255, 113, 113, 113), Color.FromArgb(255, 117, 117, 117), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 195, 196, 85), Color.FromArgb(255, 218, 241, 244), Color.FromArgb(255, 129, 140, 143), Color.FromArgb(255, 133, 107, 107), Color.FromArgb(255, 135, 135, 135), Color.FromArgb(255, 99, 99, 99), Color.FromArgb(255, 122, 122, 122), Color.FromArgb(255, 124, 80, 25), Color.FromArgb(255, 120, 120, 120), Color.FromArgb(255, 131, 116, 95), Color.FromArgb(255, 67, 55, 36), Color.FromArgb(255, 119, 96, 60), Color.FromArgb(255, 115, 95, 64), Color.FromArgb(255, 125, 102, 85), Color.FromArgb(255, 96, 96, 96), Color.FromArgb(255, 51, 58, 34),  },
            new Color[16]{ Color.FromArgb(255, 222, 222, 222), Color.FromArgb(255, 26, 40, 49), Color.FromArgb(255, 240, 251, 251), Color.FromArgb(122, 125, 173, 254), Color.FromArgb(255, 149, 121, 97), Color.FromArgb(255, 13, 100, 24), Color.FromArgb(255, 14, 102, 25), Color.FromArgb(255, 163, 186, 123), Color.FromArgb(255, 159, 164, 177), Color.FromArgb(255, 149, 193, 101), Color.FromArgb(255, 101, 68, 51), Color.FromArgb(255, 107, 73, 55), Color.FromArgb(255, 119, 119, 119), Color.FromArgb(255, 114, 88, 74), Color.FromArgb(255, 111, 100, 105), Color.FromArgb(255, 119, 151, 85),  },
            new Color[16]{ Color.FromArgb(255, 130, 106, 58), Color.FromArgb(255, 135, 103, 52), Color.FromArgb(255, 187, 187, 187), Color.FromArgb(255, 121, 95, 53), Color.FromArgb(255, 127, 93, 46), Color.FromArgb(255, 110, 108, 106), Color.FromArgb(255, 75, 41, 14), Color.FromArgb(255, 115, 76, 45), Color.FromArgb(255, 1, 179, 18), Color.FromArgb(255, 19, 172, 16), Color.FromArgb(255, 29, 138, 12), Color.FromArgb(255, 38, 140, 9), Color.FromArgb(255, 46, 128, 8), Color.FromArgb(255, 66, 123, 8), Color.FromArgb(255, 80, 119, 7), Color.FromArgb(255, 87, 102, 8),  },
            new Color[16]{ Color.FromArgb(255, 106, 89, 64), Color.FromArgb(255, 134, 102, 51), Color.FromArgb(255, 164, 164, 164), Color.FromArgb(255, 168, 76, 41), Color.FromArgb(255, 115, 119, 106), Color.FromArgb(255, 119, 119, 119), Color.FromArgb(255, 193, 118, 21), Color.FromArgb(255, 111, 54, 53), Color.FromArgb(255, 85, 64, 52), Color.FromArgb(255, 144, 118, 70), Color.FromArgb(255, 142, 146, 100), Color.FromArgb(255, 154, 130, 90), Color.FromArgb(255, 107, 102, 95), Color.FromArgb(255, 96, 96, 96), Color.FromArgb(255, 96, 96, 96), Color.FromArgb(255, 154, 154, 154),  },
            new Color[16]{ Color.FromArgb(255, 120, 108, 87), Color.FromArgb(255, 26, 22, 22), Color.FromArgb(255, 64, 64, 64), Color.FromArgb(255, 93, 63, 38), Color.FromArgb(255, 46, 29, 12), Color.FromArgb(255, 207, 206, 201), Color.FromArgb(255, 197, 121, 24), Color.FromArgb(255, 142, 77, 13), Color.FromArgb(255, 185, 133, 28), Color.FromArgb(255, 229, 206, 207), Color.FromArgb(255, 189, 142, 114), Color.FromArgb(255, 133, 57, 27), Color.FromArgb(255, 177, 89, 36), Color.FromArgb(255, 183, 38, 36), Color.FromArgb(255, 142, 107, 83), Color.FromArgb(255, 139, 139, 139),  },
            new Color[16]{ Color.FromArgb(255, 121, 109, 89), Color.FromArgb(255, 151, 52, 49), Color.FromArgb(255, 208, 132, 153), Color.FromArgb(255, 151, 147, 147), Color.FromArgb(255, 116, 116, 116), Color.FromArgb(255, 92, 92, 92), Color.FromArgb(255, 143, 23, 23), Color.FromArgb(255, 175, 116, 117), Color.FromArgb(255, 141, 146, 36), Color.FromArgb(255, 151, 154, 37), Color.FromArgb(255, 70, 70, 70), Color.FromArgb(255, 56, 56, 56), Color.FromArgb(255, 160, 159, 63), Color.FromArgb(255, 208, 204, 194), Color.FromArgb(255, 203, 171, 121), Color.FromArgb(255, 111, 111, 111),  },
            new Color[16]{ Color.FromArgb(255, 39, 67, 138), Color.FromArgb(255, 53, 71, 27), Color.FromArgb(255, 66, 174, 57), Color.FromArgb(255, 161, 147, 147), Color.FromArgb(255, 212, 240, 244), Color.FromArgb(255, 130, 51, 29), Color.FromArgb(255, 128, 45, 27), Color.FromArgb(255, 151, 102, 84), Color.FromArgb(255, 176, 161, 139), Color.FromArgb(255, 87, 68, 27), Color.FromArgb(255, 63, 63, 63), Color.FromArgb(255, 45, 45, 45), Color.FromArgb(255, 107, 107, 107), Color.FromArgb(255, 125, 103, 82), Color.FromArgb(255, 89, 117, 97), Color.FromArgb(255, 148, 160, 124),  },
            new Color[16]{ Color.FromArgb(255, 102, 112, 135), Color.FromArgb(255, 79, 51, 31), Color.FromArgb(255, 177, 166, 39), Color.FromArgb(255, 132, 108, 72), Color.FromArgb(255, 240, 240, 240), Color.FromArgb(255, 234, 234, 234), Color.FromArgb(255, 104, 64, 59), Color.FromArgb(255, 13, 9, 16), Color.FromArgb(255, 146, 81, 31), Color.FromArgb(255, 137, 108, 51), Color.FromArgb(255, 139, 140, 65), Color.FromArgb(255, 110, 129, 116), Color.FromArgb(255, 139, 129, 114), Color.FromArgb(81, 128, 128, 128), Color.FromArgb(255, 40, 72, 67), Color.FromArgb(255, 221, 224, 165),  },
            new Color[16]{ Color.FromArgb(255, 218, 210, 159), Color.FromArgb(255, 46, 57, 142), Color.FromArgb(255, 107, 138, 201), Color.FromArgb(255, 154, 105, 71), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 42, 44, 47), Color.FromArgb(255, 18, 17, 27), Color.FromArgb(255, 179, 138, 112), Color.FromArgb(255, 118, 68, 45), Color.FromArgb(255, 119, 66, 51), Color.FromArgb(255, 156, 151, 150), Color.FromArgb(255, 166, 149, 148), Color.FromArgb(255, 104, 83, 71), Color.FromArgb(255, 142, 81, 70), Color.FromArgb(255, 125, 85, 80),  },
            new Color[16]{ Color.FromArgb(255, 217, 210, 157), Color.FromArgb(255, 127, 62, 182), Color.FromArgb(255, 180, 81, 189), Color.FromArgb(255, 120, 101, 89), Color.FromArgb(255, 145, 143, 134), Color.FromArgb(255, 131, 129, 122), Color.FromArgb(255, 104, 78, 47), Color.FromArgb(255, 154, 110, 77), Color.FromArgb(255, 2, 171, 16), Color.FromArgb(255, 1, 187, 16), Color.FromArgb(255, 1, 190, 17), Color.FromArgb(255, 21, 128, 2), Color.FromArgb(152, 120, 199, 101), Color.FromArgb(202, 46, 68, 244), Color.FromArgb(202, 46, 68, 243), Color.FromArgb(202, 46, 68, 243),  },
            new Color[16]{ Color.FromArgb(255, 213, 205, 148), Color.FromArgb(255, 47, 111, 137), Color.FromArgb(255, 219, 125, 63), Color.FromArgb(255, 70, 43, 27), Color.FromArgb(255, 119, 89, 55), Color.FromArgb(255, 119, 119, 119), Color.FromArgb(255, 196, 179, 123), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 64, 61, 61), Color.FromArgb(255, 232, 228, 220), Color.FromArgb(255, 233, 230, 222), Color.FromArgb(255, 236, 233, 226), Color.FromArgb(255, 63, 63, 63), Color.FromArgb(255, 137, 93, 80), Color.FromArgb(199, 46, 68, 244), Color.FromArgb(199, 46, 68, 243),  },
            new Color[16]{ Color.FromArgb(255, 45, 23, 27), Color.FromArgb(255, 155, 161, 161), Color.FromArgb(255, 107, 15, 31), Color.FromArgb(255, 108, 15, 23), Color.FromArgb(255, 112, 19, 17), Color.FromArgb(255, 216, 208, 155), Color.FromArgb(255, 220, 212, 162), Color.FromArgb(255, 65, 61, 61), Color.FromArgb(255, 64, 61, 61), Color.FromArgb(255, 232, 228, 220), Color.FromArgb(255, 232, 228, 220), Color.FromArgb(255, 236, 233, 226), Color.FromArgb(255, 56, 56, 56), Color.FromArgb(255, 217, 105, 26), Color.FromArgb(255, 217, 105, 26), Color.FromArgb(255, 217, 105, 26),  },
            new Color[16]{ Color.FromArgb(255, 108, 108, 108), Color.FromArgb(255, 99, 99, 99), Color.FromArgb(255, 98, 98, 98), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 102, 102, 102), Color.FromArgb(255, 102, 102, 102), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 102, 102, 102), Color.FromArgb(255, 102, 102, 102), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 158, 117, 18), Color.FromArgb(255, 232, 228, 220), Color.FromArgb(255, 70, 70, 70), Color.FromArgb(255, 169, 140, 16), Color.FromArgb(255, 217, 105, 26), Color.FromArgb(255, 217, 105, 26),  },
            new Color[16]{ Color.FromArgb(255, 19, 19, 19), Color.FromArgb(255, 151, 93, 67), Color.FromArgb(255, 101, 68, 51), Color.FromArgb(255, 131, 131, 131), Color.FromArgb(255, 133, 133, 135), Color.FromArgb(255, 180, 180, 183), Color.FromArgb(255, 183, 183, 186), Color.FromArgb(255, 153, 114, 99), Color.FromArgb(255, 159, 115, 98), Color.FromArgb(255, 2, 171, 16), Color.FromArgb(255, 1, 187, 16), Color.FromArgb(255, 1, 190, 17), Color.FromArgb(255, 35, 171, 36), Color.FromArgb(255, 105, 81, 48), Color.FromArgb(255, 154, 119, 73), Color.FromArgb(255, 184, 166, 122),  },
            new Color[16]{ Color.FromArgb(255, 37, 23, 16), Color.FromArgb(255, 74, 60, 91), Color.FromArgb(255, 77, 51, 36), Color.FromArgb(255, 87, 91, 91), Color.FromArgb(255, 58, 42, 36), Color.FromArgb(255, 76, 83, 42), Color.FromArgb(255, 113, 109, 138), Color.FromArgb(255, 104, 118, 53), Color.FromArgb(255, 150, 88, 109), Color.FromArgb(255, 162, 84, 38), Color.FromArgb(255, 162, 78, 79), Color.FromArgb(255, 118, 70, 86), Color.FromArgb(255, 143, 61, 47), Color.FromArgb(255, 135, 107, 98), Color.FromArgb(255, 210, 178, 161), Color.FromArgb(255, 186, 133, 35),  },
            new Color[16]{ Color.FromArgb(159, 23, 23, 23), Color.FromArgb(159, 51, 76, 178), Color.FromArgb(159, 101, 76, 51), Color.FromArgb(159, 76, 126, 153), Color.FromArgb(159, 76, 76, 76), Color.FromArgb(159, 101, 126, 51), Color.FromArgb(159, 101, 153, 215), Color.FromArgb(159, 126, 203, 23), Color.FromArgb(159, 178, 76, 215), Color.FromArgb(159, 215, 126, 51), Color.FromArgb(159, 242, 126, 165), Color.FromArgb(159, 126, 62, 178), Color.FromArgb(159, 153, 51, 51), Color.FromArgb(159, 153, 153, 153), Color.FromArgb(159, 253, 253, 253), Color.FromArgb(159, 228, 228, 51),  },
            new Color[16]{ Color.FromArgb(209, 24, 24, 24), Color.FromArgb(209, 48, 72, 170), Color.FromArgb(209, 97, 72, 48), Color.FromArgb(209, 72, 122, 147), Color.FromArgb(209, 72, 72, 72), Color.FromArgb(209, 97, 122, 48), Color.FromArgb(209, 97, 147, 208), Color.FromArgb(209, 122, 196, 24), Color.FromArgb(209, 170, 72, 208), Color.FromArgb(209, 208, 122, 48), Color.FromArgb(209, 233, 122, 158), Color.FromArgb(209, 122, 61, 170), Color.FromArgb(209, 147, 48, 48), Color.FromArgb(209, 147, 147, 147), Color.FromArgb(209, 245, 245, 245), Color.FromArgb(209, 221, 221, 48),  },
            new Color[16]{ Color.FromArgb(255, 125, 125, 125), Color.FromArgb(255, 147, 147, 147), Color.FromArgb(255, 94, 93, 109), Color.FromArgb(255, 74, 60, 22), Color.FromArgb(255, 148, 148, 140), Color.FromArgb(255, 96, 135, 32), Color.FromArgb(255, 68, 112, 45), Color.FromArgb(255, 224, 191, 43), Color.FromArgb(255, 105, 99, 89), Color.FromArgb(255, 154, 91, 64), Color.FromArgb(255, 169, 92, 51), Color.FromArgb(255, 135, 135, 135), Color.FromArgb(255, 99, 99, 99), Color.FromArgb(255, 100, 160, 143), Color.FromArgb(255, 169, 88, 33), Color.FromArgb(255, 167, 85, 30),  },
            new Color[16]{ Color.FromArgb(255, 124, 124, 124), Color.FromArgb(255, 140, 140, 140), Color.FromArgb(255, 48, 81, 53), Color.FromArgb(255, 49, 59, 15), Color.FromArgb(255, 143, 149, 132), Color.FromArgb(255, 102, 150, 73), Color.FromArgb(255, 65, 109, 43), Color.FromArgb(255, 64, 105, 42), Color.FromArgb(255, 52, 41, 23), Color.FromArgb(255, 78, 62, 41), Color.FromArgb(255, 61, 40, 18), Color.FromArgb(255, 135, 135, 135), Color.FromArgb(255, 99, 99, 99), Color.FromArgb(255, 60, 88, 75), Color.FromArgb(255, 163, 83, 28), Color.FromArgb(255, 166, 85, 30),  },
            new Color[16]{ Color.FromArgb(255, 178, 141, 211), Color.FromArgb(255, 38, 152, 138), Color.FromArgb(255, 162, 192, 139), Color.FromArgb(255, 176, 198, 139), Color.FromArgb(255, 103, 135, 39), Color.FromArgb(255, 95, 153, 66), Color.FromArgb(255, 115, 115, 20), Color.FromArgb(255, 57, 86, 28), Color.FromArgb(255, 119, 86, 59), Color.FromArgb(255, 123, 88, 57), Color.FromArgb(255, 91, 63, 29), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 107, 170, 151), Color.FromArgb(255, 162, 83, 28), Color.FromArgb(255, 168, 86, 31),  },
            new Color[16]{ Color.FromArgb(255, 162, 93, 59), Color.FromArgb(255, 218, 211, 179), Color.FromArgb(255, 70, 48, 25), Color.FromArgb(255, 151, 114, 85), Color.FromArgb(255, 96, 75, 49), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 211, 25, 26), Color.FromArgb(255, 165, 195, 245), Color.FromArgb(255, 172, 200, 191), Color.FromArgb(255, 106, 109, 113), Color.FromArgb(255, 200, 200, 200),  },
            new Color[16]{ Color.FromArgb(255, 156, 88, 55), Color.FromArgb(255, 199, 189, 141), Color.FromArgb(255, 66, 44, 24), Color.FromArgb(255, 147, 108, 78), Color.FromArgb(255, 97, 76, 50), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Candy = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 254, 183, 214), Color.FromArgb(255, 67, 45, 22), Color.FromArgb(255, 250, 217, 168), Color.FromArgb(255, 247, 205, 176), Color.FromArgb(255, 157, 108, 68), Color.FromArgb(255, 105, 94, 92), Color.FromArgb(255, 76, 59, 54), Color.FromArgb(255, 159, 137, 110), Color.FromArgb(255, 154, 74, 73), Color.FromArgb(255, 138, 38, 38), Color.FromArgb(255, 138, 38, 38), Color.FromArgb(255, 197, 156, 77), Color.FromArgb(255, 209, 99, 96), Color.FromArgb(255, 239, 215, 87), Color.FromArgb(255, 0, 42, 255), Color.FromArgb(255, 194, 204, 158),  },
            new Color[16]{ Color.FromArgb(255, 149, 107, 109), Color.FromArgb(255, 34, 21, 11), Color.FromArgb(255, 237, 223, 158), Color.FromArgb(255, 161, 114, 47), Color.FromArgb(255, 231, 178, 112), Color.FromArgb(255, 131, 91, 54), Color.FromArgb(255, 186, 153, 125), Color.FromArgb(255, 208, 157, 48), Color.FromArgb(255, 23, 213, 188), Color.FromArgb(255, 47, 173, 14), Color.FromArgb(255, 202, 41, 41), Color.FromArgb(255, 104, 192, 210), Color.FromArgb(255, 172, 146, 158), Color.FromArgb(255, 201, 127, 138), Color.FromArgb(255, 245, 176, 151), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 124, 90, 27), Color.FromArgb(255, 116, 88, 64), Color.FromArgb(255, 54, 40, 25), Color.FromArgb(255, 148, 115, 97), Color.FromArgb(255, 168, 123, 116), Color.FromArgb(255, 55, 35, 62), Color.FromArgb(255, 245, 166, 200), Color.FromArgb(255, 201, 167, 66), Color.FromArgb(255, 101, 186, 204), Color.FromArgb(255, 190, 154, 103), Color.FromArgb(255, 102, 187, 204), Color.FromArgb(255, 215, 193, 210), Color.FromArgb(255, 89, 148, 164), Color.FromArgb(255, 81, 194, 218), Color.FromArgb(255, 104, 192, 210), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 123, 74, 39), Color.FromArgb(255, 191, 132, 54), Color.FromArgb(255, 59, 108, 85), Color.FromArgb(255, 110, 41, 26), Color.FromArgb(255, 172, 226, 183), Color.FromArgb(255, 172, 226, 183), Color.FromArgb(255, 77, 44, 17), Color.FromArgb(255, 199, 166, 126), Color.FromArgb(255, 224, 153, 189), Color.FromArgb(255, 101, 81, 65), Color.FromArgb(255, 53, 38, 28), Color.FromArgb(255, 81, 182, 209), Color.FromArgb(255, 80, 183, 210), Color.FromArgb(255, 130, 172, 146), Color.FromArgb(255, 106, 197, 216), Color.FromArgb(255, 235, 170, 105),  },
            new Color[16]{ Color.FromArgb(255, 242, 229, 186), Color.FromArgb(255, 191, 111, 117), Color.FromArgb(255, 231, 234, 238), Color.FromArgb(125, 122, 228, 225), Color.FromArgb(255, 244, 220, 184), Color.FromArgb(255, 183, 97, 48), Color.FromArgb(255, 202, 132, 56), Color.FromArgb(255, 183, 97, 48), Color.FromArgb(255, 209, 164, 65), Color.FromArgb(255, 153, 109, 73), Color.FromArgb(255, 242, 199, 167), Color.FromArgb(255, 225, 162, 131), Color.FromArgb(255, 248, 118, 23), Color.FromArgb(255, 209, 173, 186), Color.FromArgb(255, 197, 156, 228), Color.FromArgb(255, 152, 179, 134),  },
            new Color[16]{ Color.FromArgb(255, 166, 195, 178), Color.FromArgb(255, 90, 55, 34), Color.FromArgb(255, 179, 146, 120), Color.FromArgb(255, 75, 46, 19), Color.FromArgb(255, 109, 159, 98), Color.FromArgb(255, 195, 122, 128), Color.FromArgb(255, 229, 185, 121), Color.FromArgb(255, 239, 206, 157), Color.FromArgb(255, 222, 124, 85), Color.FromArgb(255, 207, 143, 121), Color.FromArgb(255, 215, 144, 117), Color.FromArgb(255, 206, 143, 118), Color.FromArgb(255, 210, 149, 127), Color.FromArgb(255, 212, 147, 116), Color.FromArgb(255, 212, 147, 135), Color.FromArgb(255, 208, 153, 145),  },
            new Color[16]{ Color.FromArgb(255, 240, 136, 147), Color.FromArgb(255, 93, 57, 38), Color.FromArgb(255, 178, 139, 108), Color.FromArgb(255, 212, 118, 117), Color.FromArgb(255, 82, 49, 17), Color.FromArgb(255, 71, 40, 17), Color.FromArgb(255, 132, 102, 71), Color.FromArgb(255, 164, 116, 58), Color.FromArgb(255, 71, 45, 25), Color.FromArgb(255, 235, 228, 203), Color.FromArgb(255, 193, 168, 138), Color.FromArgb(255, 195, 133, 102), Color.FromArgb(255, 216, 198, 180), Color.FromArgb(255, 224, 223, 223), Color.FromArgb(255, 181, 119, 59), Color.FromArgb(255, 208, 120, 147),  },
            new Color[16]{ Color.FromArgb(255, 217, 145, 110), Color.FromArgb(255, 45, 45, 45), Color.FromArgb(255, 95, 95, 95), Color.FromArgb(255, 185, 108, 107), Color.FromArgb(255, 211, 150, 97), Color.FromArgb(255, 153, 109, 73), Color.FromArgb(255, 85, 54, 49), Color.FromArgb(255, 75, 48, 44), Color.FromArgb(255, 105, 76, 57), Color.FromArgb(255, 239, 207, 203), Color.FromArgb(255, 220, 167, 137), Color.FromArgb(255, 222, 160, 125), Color.FromArgb(255, 190, 141, 84), Color.FromArgb(255, 125, 112, 97), Color.FromArgb(255, 246, 165, 216), Color.FromArgb(255, 200, 105, 134),  },
            new Color[16]{ Color.FromArgb(255, 218, 143, 110), Color.FromArgb(255, 183, 32, 29), Color.FromArgb(255, 236, 104, 222), Color.FromArgb(255, 172, 129, 85), Color.FromArgb(255, 255, 212, 121), Color.FromArgb(255, 255, 212, 121), Color.FromArgb(255, 99, 59, 145), Color.FromArgb(255, 104, 75, 98), Color.FromArgb(255, 232, 218, 144), Color.FromArgb(255, 219, 172, 112), Color.FromArgb(255, 150, 92, 36), Color.FromArgb(255, 161, 99, 69), Color.FromArgb(255, 82, 49, 26), Color.FromArgb(255, 231, 229, 227), Color.FromArgb(255, 207, 204, 197), Color.FromArgb(255, 184, 55, 72),  },
            new Color[16]{ Color.FromArgb(255, 14, 123, 202), Color.FromArgb(255, 2, 106, 23), Color.FromArgb(255, 9, 190, 33), Color.FromArgb(255, 180, 131, 87), Color.FromArgb(255, 196, 135, 57), Color.FromArgb(255, 131, 88, 116), Color.FromArgb(255, 124, 81, 115), Color.FromArgb(255, 132, 94, 94), Color.FromArgb(255, 131, 92, 58), Color.FromArgb(255, 234, 204, 131), Color.FromArgb(255, 137, 107, 51), Color.FromArgb(255, 171, 79, 39), Color.FromArgb(255, 90, 185, 199), Color.FromArgb(255, 124, 90, 89), Color.FromArgb(255, 220, 220, 220), Color.FromArgb(255, 144, 116, 97),  },
            new Color[16]{ Color.FromArgb(255, 69, 80, 96), Color.FromArgb(255, 77, 44, 18), Color.FromArgb(255, 229, 206, 14), Color.FromArgb(255, 155, 124, 161), Color.FromArgb(255, 232, 232, 232), Color.FromArgb(255, 235, 235, 235), Color.FromArgb(255, 177, 183, 219), Color.FromArgb(255, 79, 52, 31), Color.FromArgb(255, 202, 146, 163), Color.FromArgb(255, 133, 165, 92), Color.FromArgb(255, 186, 161, 88), Color.FromArgb(255, 62, 92, 22), Color.FromArgb(255, 202, 77, 62), Color.FromArgb(163, 218, 57, 59), Color.FromArgb(255, 197, 129, 129), Color.FromArgb(255, 101, 67, 32),  },
            new Color[16]{ Color.FromArgb(255, 214, 174, 112), Color.FromArgb(255, 8, 53, 169), Color.FromArgb(255, 46, 133, 253), Color.FromArgb(255, 168, 149, 184), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 60, 44, 71), Color.FromArgb(255, 55, 35, 62), Color.FromArgb(255, 164, 112, 63), Color.FromArgb(255, 110, 83, 65), Color.FromArgb(255, 221, 62, 62), Color.FromArgb(255, 173, 130, 86), Color.FromArgb(255, 181, 132, 88), Color.FromArgb(255, 168, 225, 146), Color.FromArgb(255, 200, 229, 187), Color.FromArgb(255, 185, 134, 90),  },
            new Color[16]{ Color.FromArgb(255, 210, 176, 118), Color.FromArgb(255, 92, 19, 219), Color.FromArgb(255, 157, 9, 205), Color.FromArgb(255, 250, 152, 86), Color.FromArgb(255, 255, 167, 177), Color.FromArgb(255, 255, 167, 177), Color.FromArgb(255, 70, 40, 39), Color.FromArgb(255, 107, 62, 47), Color.FromArgb(255, 95, 64, 35), Color.FromArgb(255, 150, 122, 107), Color.FromArgb(255, 182, 131, 135), Color.FromArgb(255, 187, 122, 128), Color.FromArgb(204, 85, 174, 24), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 214, 174, 112), Color.FromArgb(255, 7, 118, 169), Color.FromArgb(255, 227, 107, 12), Color.FromArgb(255, 172, 126, 75), Color.FromArgb(255, 213, 165, 108), Color.FromArgb(255, 108, 65, 35), Color.FromArgb(255, 235, 209, 137), Color.FromArgb(255, 93, 73, 40), Color.FromArgb(255, 96, 75, 43), Color.FromArgb(255, 234, 212, 208), Color.FromArgb(255, 203, 223, 236), Color.FromArgb(255, 211, 184, 182), Color.FromArgb(255, 106, 69, 21), Color.FromArgb(255, 251, 172, 120), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 156, 107, 79), Color.FromArgb(255, 163, 163, 163), Color.FromArgb(255, 170, 31, 17), Color.FromArgb(255, 179, 34, 19), Color.FromArgb(255, 179, 33, 19), Color.FromArgb(255, 174, 136, 85), Color.FromArgb(255, 210, 169, 105), Color.FromArgb(255, 96, 75, 41), Color.FromArgb(255, 95, 75, 44), Color.FromArgb(255, 202, 207, 196), Color.FromArgb(255, 210, 226, 207), Color.FromArgb(255, 221, 223, 230), Color.FromArgb(255, 166, 116, 67), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 151, 132, 100), Color.FromArgb(255, 144, 162, 84), Color.FromArgb(255, 148, 156, 74), Color.FromArgb(255, 147, 151, 84), Color.FromArgb(255, 142, 142, 79), Color.FromArgb(255, 152, 137, 77), Color.FromArgb(255, 148, 130, 75), Color.FromArgb(255, 162, 132, 77), Color.FromArgb(255, 171, 134, 70), Color.FromArgb(255, 173, 138, 79), Color.FromArgb(255, 185, 136, 110), Color.FromArgb(255, 241, 248, 255), Color.FromArgb(255, 157, 102, 59), Color.FromArgb(255, 228, 144, 144), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 40, 40, 40), Color.FromArgb(255, 191, 135, 75), Color.FromArgb(255, 242, 199, 167), Color.FromArgb(255, 59, 40, 21), Color.FromArgb(255, 60, 41, 21), Color.FromArgb(255, 170, 95, 35), Color.FromArgb(255, 177, 97, 38), Color.FromArgb(255, 218, 160, 189), Color.FromArgb(255, 219, 170, 196), Color.FromArgb(255, 95, 64, 35), Color.FromArgb(255, 150, 122, 107), Color.FromArgb(255, 182, 131, 135), Color.FromArgb(255, 198, 133, 139), Color.FromArgb(255, 197, 137, 87), Color.FromArgb(255, 224, 198, 133), Color.FromArgb(255, 204, 150, 90),  },
            new Color[16]{ Color.FromArgb(255, 88, 58, 30), Color.FromArgb(255, 102, 97, 128), Color.FromArgb(255, 144, 86, 40), Color.FromArgb(255, 121, 144, 129), Color.FromArgb(255, 146, 110, 73), Color.FromArgb(255, 131, 119, 34), Color.FromArgb(255, 171, 162, 164), Color.FromArgb(255, 163, 177, 31), Color.FromArgb(255, 216, 130, 152), Color.FromArgb(255, 216, 142, 43), Color.FromArgb(255, 223, 159, 147), Color.FromArgb(255, 189, 103, 148), Color.FromArgb(255, 202, 79, 46), Color.FromArgb(255, 201, 170, 140), Color.FromArgb(255, 230, 206, 177), Color.FromArgb(255, 221, 194, 43),  },
            new Color[16]{ Color.FromArgb(255, 78, 47, 16), Color.FromArgb(255, 93, 89, 119), Color.FromArgb(255, 138, 76, 26), Color.FromArgb(255, 113, 140, 120), Color.FromArgb(255, 140, 104, 60), Color.FromArgb(255, 124, 114, 20), Color.FromArgb(255, 168, 160, 158), Color.FromArgb(255, 158, 176, 17), Color.FromArgb(255, 216, 126, 146), Color.FromArgb(255, 216, 138, 28), Color.FromArgb(255, 224, 157, 139), Color.FromArgb(255, 188, 95, 141), Color.FromArgb(255, 202, 69, 32), Color.FromArgb(255, 200, 169, 132), Color.FromArgb(255, 231, 207, 173), Color.FromArgb(255, 222, 195, 28),  },
            new Color[16]{ Color.FromArgb(255, 81, 49, 17), Color.FromArgb(255, 96, 92, 121), Color.FromArgb(255, 141, 78, 27), Color.FromArgb(255, 116, 143, 122), Color.FromArgb(255, 143, 107, 61), Color.FromArgb(255, 127, 116, 21), Color.FromArgb(255, 170, 162, 160), Color.FromArgb(255, 161, 178, 18), Color.FromArgb(255, 218, 128, 147), Color.FromArgb(255, 218, 141, 30), Color.FromArgb(255, 226, 159, 140), Color.FromArgb(255, 190, 98, 143), Color.FromArgb(255, 204, 71, 33), Color.FromArgb(255, 202, 171, 134), Color.FromArgb(255, 233, 208, 174), Color.FromArgb(255, 224, 196, 30),  },
            new Color[16]{ Color.FromArgb(255, 136, 109, 57), Color.FromArgb(255, 217, 205, 178), Color.FromArgb(255, 85, 85, 108), Color.FromArgb(255, 165, 114, 60), Color.FromArgb(255, 236, 169, 218), Color.FromArgb(255, 243, 132, 44), Color.FromArgb(255, 40, 29, 21), Color.FromArgb(255, 192, 186, 80), Color.FromArgb(255, 199, 210, 96), Color.FromArgb(252, 210, 222, 132), Color.FromArgb(252, 151, 156, 66), Color.FromArgb(255, 182, 171, 225), Color.FromArgb(255, 182, 171, 225), Color.FromArgb(255, 232, 129, 134), Color.FromArgb(255, 180, 82, 47), Color.FromArgb(255, 170, 83, 50),  },
            new Color[16]{ Color.FromArgb(255, 165, 169, 172), Color.FromArgb(255, 213, 194, 166), Color.FromArgb(255, 67, 111, 197), Color.FromArgb(255, 165, 109, 50), Color.FromArgb(255, 212, 125, 163), Color.FromArgb(255, 241, 68, 178), Color.FromArgb(255, 76, 63, 63), Color.FromArgb(255, 149, 136, 41), Color.FromArgb(255, 229, 129, 112), Color.FromArgb(252, 195, 97, 85), Color.FromArgb(252, 156, 70, 66), Color.FromArgb(255, 172, 210, 225), Color.FromArgb(255, 172, 210, 225), Color.FromArgb(255, 229, 90, 97), Color.FromArgb(255, 170, 83, 50), Color.FromArgb(255, 175, 108, 72),  },
            new Color[16]{ Color.FromArgb(255, 198, 83, 191), Color.FromArgb(255, 86, 65, 173), Color.FromArgb(255, 230, 98, 92), Color.FromArgb(255, 234, 136, 56), Color.FromArgb(255, 223, 65, 80), Color.FromArgb(255, 216, 215, 213), Color.FromArgb(255, 159, 146, 174), Color.FromArgb(255, 211, 137, 127), Color.FromArgb(255, 239, 207, 158), Color.FromArgb(255, 218, 215, 164), Color.FromArgb(255, 157, 225, 158), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 250, 186, 188), Color.FromArgb(255, 129, 64, 36), Color.FromArgb(255, 153, 72, 42),  },
            new Color[16]{ Color.FromArgb(255, 233, 179, 195), Color.FromArgb(255, 224, 206, 213), Color.FromArgb(255, 76, 48, 46), Color.FromArgb(255, 199, 163, 103), Color.FromArgb(255, 213, 164, 110), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 211, 25, 26), Color.FromArgb(255, 123, 230, 227), Color.FromArgb(255, 247, 122, 98), Color.FromArgb(255, 49, 35, 27), Color.FromArgb(255, 88, 55, 35),  },
            new Color[16]{ Color.FromArgb(255, 232, 179, 195), Color.FromArgb(255, 216, 214, 221), Color.FromArgb(255, 72, 45, 43), Color.FromArgb(255, 198, 162, 102), Color.FromArgb(255, 210, 161, 108), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Cartoon = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 204, 204, 204), Color.FromArgb(255, 120, 136, 164), Color.FromArgb(255, 92, 60, 37), Color.FromArgb(255, 92, 81, 41), Color.FromArgb(255, 184, 149, 95), Color.FromArgb(255, 174, 181, 194), Color.FromArgb(255, 174, 181, 194), Color.FromArgb(255, 180, 103, 83), Color.FromArgb(255, 188, 81, 38), Color.FromArgb(255, 171, 50, 17), Color.FromArgb(255, 178, 47, 11), Color.FromArgb(255, 228, 228, 228), Color.FromArgb(255, 155, 65, 24), Color.FromArgb(255, 170, 165, 55), Color.FromArgb(255, 0, 42, 255), Color.FromArgb(255, 72, 134, 33),  },
            new Color[16]{ Color.FromArgb(255, 141, 158, 170), Color.FromArgb(255, 184, 128, 98), Color.FromArgb(255, 244, 228, 147), Color.FromArgb(255, 118, 109, 109), Color.FromArgb(255, 88, 53, 17), Color.FromArgb(255, 173, 138, 87), Color.FromArgb(255, 179, 179, 179), Color.FromArgb(255, 229, 184, 27), Color.FromArgb(255, 72, 172, 194), Color.FromArgb(255, 63, 182, 63), Color.FromArgb(255, 195, 48, 34), Color.FromArgb(255, 97, 105, 131), Color.FromArgb(255, 192, 65, 54), Color.FromArgb(255, 177, 98, 88), Color.FromArgb(255, 45, 122, 20), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 140, 147, 150), Color.FromArgb(255, 136, 142, 160), Color.FromArgb(255, 110, 124, 146), Color.FromArgb(255, 135, 121, 79), Color.FromArgb(255, 124, 161, 141), Color.FromArgb(255, 49, 39, 73), Color.FromArgb(255, 204, 204, 204), Color.FromArgb(255, 118, 118, 118), Color.FromArgb(255, 78, 87, 114), Color.FromArgb(255, 253, 233, 81), Color.FromArgb(255, 79, 88, 116), Color.FromArgb(255, 170, 145, 87), Color.FromArgb(255, 77, 84, 108), Color.FromArgb(255, 104, 112, 138), Color.FromArgb(255, 97, 105, 131), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 219, 203, 76), Color.FromArgb(255, 181, 207, 209), Color.FromArgb(255, 119, 147, 174), Color.FromArgb(255, 137, 127, 147), Color.FromArgb(255, 171, 171, 171), Color.FromArgb(255, 157, 157, 157), Color.FromArgb(255, 118, 133, 159), Color.FromArgb(255, 99, 77, 48), Color.FromArgb(255, 135, 135, 135), Color.FromArgb(255, 86, 145, 221), Color.FromArgb(255, 40, 76, 132), Color.FromArgb(255, 168, 132, 85), Color.FromArgb(255, 157, 133, 95), Color.FromArgb(255, 117, 110, 107), Color.FromArgb(255, 85, 94, 122), Color.FromArgb(255, 30, 88, 58),  },
            new Color[16]{ Color.FromArgb(255, 238, 238, 238), Color.FromArgb(255, 40, 59, 71), Color.FromArgb(255, 237, 253, 253), Color.FromArgb(182, 192, 232, 232), Color.FromArgb(255, 133, 116, 100), Color.FromArgb(255, 123, 208, 63), Color.FromArgb(255, 127, 208, 67), Color.FromArgb(255, 183, 221, 118), Color.FromArgb(255, 155, 129, 119), Color.FromArgb(255, 71, 147, 28), Color.FromArgb(255, 203, 97, 32), Color.FromArgb(255, 188, 88, 28), Color.FromArgb(255, 218, 218, 218), Color.FromArgb(255, 92, 87, 68), Color.FromArgb(255, 112, 217, 216), Color.FromArgb(255, 179, 128, 57),  },
            new Color[16]{ Color.FromArgb(255, 145, 155, 188), Color.FromArgb(255, 169, 137, 89), Color.FromArgb(255, 159, 44, 33), Color.FromArgb(255, 171, 134, 79), Color.FromArgb(255, 135, 87, 52), Color.FromArgb(255, 62, 65, 59), Color.FromArgb(255, 86, 44, 7), Color.FromArgb(255, 132, 87, 42), Color.FromArgb(255, 20, 123, 10), Color.FromArgb(255, 57, 176, 45), Color.FromArgb(255, 111, 188, 48), Color.FromArgb(255, 122, 187, 29), Color.FromArgb(255, 155, 210, 23), Color.FromArgb(255, 193, 213, 22), Color.FromArgb(255, 209, 207, 25), Color.FromArgb(255, 214, 189, 24),  },
            new Color[16]{ Color.FromArgb(255, 122, 146, 211), Color.FromArgb(255, 165, 131, 82), Color.FromArgb(255, 158, 43, 33), Color.FromArgb(255, 174, 112, 155), Color.FromArgb(255, 102, 130, 133), Color.FromArgb(255, 117, 132, 158), Color.FromArgb(255, 243, 118, 27), Color.FromArgb(255, 161, 58, 58), Color.FromArgb(255, 27, 191, 166), Color.FromArgb(255, 213, 183, 66), Color.FromArgb(255, 105, 148, 56), Color.FromArgb(255, 177, 144, 92), Color.FromArgb(255, 82, 98, 98), Color.FromArgb(255, 52, 85, 102), Color.FromArgb(255, 62, 85, 93), Color.FromArgb(255, 145, 145, 145),  },
            new Color[16]{ Color.FromArgb(255, 154, 147, 111), Color.FromArgb(255, 27, 27, 27), Color.FromArgb(255, 71, 71, 71), Color.FromArgb(255, 122, 124, 183), Color.FromArgb(255, 58, 40, 9), Color.FromArgb(255, 192, 191, 188), Color.FromArgb(255, 238, 116, 25), Color.FromArgb(255, 210, 108, 25), Color.FromArgb(255, 242, 144, 34), Color.FromArgb(255, 240, 235, 235), Color.FromArgb(255, 169, 148, 141), Color.FromArgb(255, 115, 84, 72), Color.FromArgb(255, 85, 57, 41), Color.FromArgb(255, 187, 38, 38), Color.FromArgb(255, 174, 87, 87), Color.FromArgb(255, 146, 146, 146),  },
            new Color[16]{ Color.FromArgb(255, 149, 141, 105), Color.FromArgb(255, 236, 58, 49), Color.FromArgb(255, 255, 198, 214), Color.FromArgb(255, 160, 157, 168), Color.FromArgb(255, 142, 142, 142), Color.FromArgb(255, 142, 142, 142), Color.FromArgb(255, 33, 174, 207), Color.FromArgb(255, 201, 233, 243), Color.FromArgb(255, 180, 190, 40), Color.FromArgb(255, 184, 194, 41), Color.FromArgb(255, 33, 44, 83), Color.FromArgb(255, 24, 33, 66), Color.FromArgb(255, 175, 160, 45), Color.FromArgb(255, 239, 231, 218), Color.FromArgb(255, 230, 186, 117), Color.FromArgb(255, 135, 135, 135),  },
            new Color[16]{ Color.FromArgb(255, 63, 118, 208), Color.FromArgb(255, 61, 105, 20), Color.FromArgb(255, 89, 239, 69), Color.FromArgb(255, 175, 164, 175), Color.FromArgb(255, 202, 226, 229), Color.FromArgb(255, 123, 186, 154), Color.FromArgb(255, 113, 184, 159), Color.FromArgb(255, 214, 219, 180), Color.FromArgb(255, 239, 226, 177), Color.FromArgb(255, 147, 126, 27), Color.FromArgb(255, 30, 40, 77), Color.FromArgb(255, 23, 32, 64), Color.FromArgb(255, 224, 188, 27), Color.FromArgb(255, 136, 142, 114), Color.FromArgb(255, 94, 129, 91), Color.FromArgb(255, 126, 170, 120),  },
            new Color[16]{ Color.FromArgb(255, 116, 139, 178), Color.FromArgb(255, 101, 68, 48), Color.FromArgb(255, 254, 240, 86), Color.FromArgb(255, 151, 130, 97), Color.FromArgb(255, 231, 231, 231), Color.FromArgb(255, 231, 231, 231), Color.FromArgb(255, 98, 198, 177), Color.FromArgb(255, 8, 117, 137), Color.FromArgb(255, 218, 125, 43), Color.FromArgb(255, 217, 190, 64), Color.FromArgb(255, 183, 190, 64), Color.FromArgb(255, 116, 149, 152), Color.FromArgb(255, 138, 151, 149), Color.FromArgb(169, 178, 208, 226), Color.FromArgb(255, 38, 102, 105), Color.FromArgb(255, 153, 197, 147),  },
            new Color[16]{ Color.FromArgb(255, 249, 233, 168), Color.FromArgb(255, 26, 45, 218), Color.FromArgb(255, 136, 176, 253), Color.FromArgb(255, 188, 134, 101), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 68, 79, 95), Color.FromArgb(255, 49, 39, 73), Color.FromArgb(255, 156, 194, 200), Color.FromArgb(255, 115, 66, 43), Color.FromArgb(255, 197, 27, 27), Color.FromArgb(255, 158, 155, 166), Color.FromArgb(255, 172, 161, 172), Color.FromArgb(255, 134, 116, 97), Color.FromArgb(255, 175, 120, 101), Color.FromArgb(255, 165, 88, 92),  },
            new Color[16]{ Color.FromArgb(255, 246, 230, 162), Color.FromArgb(255, 131, 44, 219), Color.FromArgb(255, 220, 89, 233), Color.FromArgb(255, 136, 119, 97), Color.FromArgb(255, 160, 160, 160), Color.FromArgb(255, 138, 138, 138), Color.FromArgb(255, 130, 93, 40), Color.FromArgb(255, 171, 123, 88), Color.FromArgb(255, 157, 243, 82), Color.FromArgb(255, 130, 234, 38), Color.FromArgb(255, 105, 210, 13), Color.FromArgb(255, 86, 155, 4), Color.FromArgb(179, 136, 207, 116), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 219, 199, 111), Color.FromArgb(255, 33, 174, 207), Color.FromArgb(255, 245, 168, 38), Color.FromArgb(255, 120, 68, 68), Color.FromArgb(255, 235, 92, 92), Color.FromArgb(255, 118, 134, 160), Color.FromArgb(255, 214, 193, 133), Color.FromArgb(255, 29, 40, 79), Color.FromArgb(255, 31, 42, 81), Color.FromArgb(255, 189, 209, 231), Color.FromArgb(255, 190, 209, 231), Color.FromArgb(255, 190, 210, 232), Color.FromArgb(255, 16, 77, 17), Color.FromArgb(255, 170, 122, 100), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 66, 148, 104), Color.FromArgb(255, 186, 189, 189), Color.FromArgb(255, 154, 45, 48), Color.FromArgb(255, 148, 43, 45), Color.FromArgb(255, 149, 43, 45), Color.FromArgb(255, 244, 228, 158), Color.FromArgb(255, 247, 231, 165), Color.FromArgb(255, 33, 44, 86), Color.FromArgb(255, 30, 40, 77), Color.FromArgb(255, 188, 207, 229), Color.FromArgb(255, 188, 207, 229), Color.FromArgb(255, 190, 210, 232), Color.FromArgb(255, 10, 57, 10), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 61, 61, 61), Color.FromArgb(255, 64, 64, 64), Color.FromArgb(255, 67, 67, 67), Color.FromArgb(255, 67, 67, 67), Color.FromArgb(255, 72, 72, 72), Color.FromArgb(255, 74, 74, 74), Color.FromArgb(255, 76, 76, 76), Color.FromArgb(255, 76, 76, 76), Color.FromArgb(255, 76, 76, 76), Color.FromArgb(255, 77, 77, 77), Color.FromArgb(255, 200, 172, 47), Color.FromArgb(255, 189, 209, 232), Color.FromArgb(255, 14, 70, 15), Color.FromArgb(255, 237, 216, 67), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 45, 45, 45), Color.FromArgb(255, 113, 109, 136), Color.FromArgb(255, 203, 97, 32), Color.FromArgb(255, 109, 129, 158), Color.FromArgb(255, 113, 133, 166), Color.FromArgb(255, 129, 156, 176), Color.FromArgb(255, 156, 178, 199), Color.FromArgb(255, 163, 107, 75), Color.FromArgb(255, 167, 108, 76), Color.FromArgb(255, 157, 243, 82), Color.FromArgb(255, 130, 234, 38), Color.FromArgb(255, 105, 210, 13), Color.FromArgb(255, 84, 138, 13), Color.FromArgb(255, 119, 84, 35), Color.FromArgb(255, 166, 121, 79), Color.FromArgb(255, 213, 194, 143),  },
            new Color[16]{ Color.FromArgb(255, 44, 43, 52), Color.FromArgb(255, 54, 77, 169), Color.FromArgb(255, 91, 67, 65), Color.FromArgb(255, 70, 128, 170), Color.FromArgb(255, 93, 91, 105), Color.FromArgb(255, 79, 100, 58), Color.FromArgb(255, 120, 153, 204), Color.FromArgb(255, 111, 172, 53), Color.FromArgb(255, 188, 112, 194), Color.FromArgb(255, 188, 125, 69), Color.FromArgb(255, 199, 149, 188), Color.FromArgb(255, 149, 83, 189), Color.FromArgb(255, 169, 61, 73), Color.FromArgb(255, 165, 164, 181), Color.FromArgb(255, 209, 208, 216), Color.FromArgb(255, 195, 194, 69),  },
            new Color[16]{ Color.FromArgb(255, 54, 64, 65), Color.FromArgb(255, 69, 116, 197), Color.FromArgb(255, 120, 100, 82), Color.FromArgb(255, 91, 173, 198), Color.FromArgb(255, 121, 132, 134), Color.FromArgb(255, 104, 144, 72), Color.FromArgb(255, 153, 195, 230), Color.FromArgb(255, 142, 211, 66), Color.FromArgb(255, 214, 158, 221), Color.FromArgb(255, 214, 171, 88), Color.FromArgb(255, 224, 191, 215), Color.FromArgb(255, 178, 123, 217), Color.FromArgb(255, 196, 92, 93), Color.FromArgb(255, 194, 204, 209), Color.FromArgb(255, 232, 240, 241), Color.FromArgb(255, 221, 229, 88),  },
            new Color[16]{ Color.FromArgb(255, 62, 71, 72), Color.FromArgb(255, 77, 125, 205), Color.FromArgb(255, 129, 109, 90), Color.FromArgb(255, 100, 182, 206), Color.FromArgb(255, 130, 141, 142), Color.FromArgb(255, 113, 153, 80), Color.FromArgb(255, 163, 202, 237), Color.FromArgb(255, 152, 219, 73), Color.FromArgb(255, 222, 166, 227), Color.FromArgb(255, 222, 180, 96), Color.FromArgb(255, 231, 199, 222), Color.FromArgb(255, 187, 131, 224), Color.FromArgb(255, 204, 100, 101), Color.FromArgb(255, 202, 212, 217), Color.FromArgb(255, 239, 247, 247), Color.FromArgb(255, 228, 236, 96),  },
            new Color[16]{ Color.FromArgb(255, 135, 135, 135), Color.FromArgb(255, 130, 130, 130), Color.FromArgb(255, 116, 150, 104), Color.FromArgb(255, 110, 119, 45), Color.FromArgb(255, 84, 112, 110), Color.FromArgb(255, 135, 104, 25), Color.FromArgb(255, 108, 170, 84), Color.FromArgb(255, 209, 192, 89), Color.FromArgb(255, 57, 52, 48), Color.FromArgb(255, 142, 78, 14), Color.FromArgb(255, 203, 115, 55), Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 89, 89, 89), Color.FromArgb(255, 27, 196, 203), Color.FromArgb(255, 204, 96, 45), Color.FromArgb(255, 215, 104, 50),  },
            new Color[16]{ Color.FromArgb(255, 135, 135, 135), Color.FromArgb(255, 124, 124, 124), Color.FromArgb(255, 68, 106, 53), Color.FromArgb(255, 97, 98, 37), Color.FromArgb(255, 78, 101, 89), Color.FromArgb(255, 137, 91, 96), Color.FromArgb(255, 82, 133, 62), Color.FromArgb(255, 168, 188, 90), Color.FromArgb(255, 39, 32, 24), Color.FromArgb(255, 113, 94, 67), Color.FromArgb(255, 147, 126, 111), Color.FromArgb(255, 171, 171, 171), Color.FromArgb(255, 157, 157, 157), Color.FromArgb(255, 14, 180, 205), Color.FromArgb(255, 191, 86, 38), Color.FromArgb(255, 210, 101, 49),  },
            new Color[16]{ Color.FromArgb(255, 119, 108, 173), Color.FromArgb(255, 5, 74, 179), Color.FromArgb(255, 81, 148, 126), Color.FromArgb(255, 177, 189, 145), Color.FromArgb(255, 95, 77, 30), Color.FromArgb(255, 121, 159, 112), Color.FromArgb(255, 27, 110, 18), Color.FromArgb(255, 136, 68, 21), Color.FromArgb(255, 102, 68, 48), Color.FromArgb(255, 113, 74, 32), Color.FromArgb(255, 162, 106, 21), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 21, 169, 211), Color.FromArgb(255, 205, 98, 47), Color.FromArgb(255, 212, 102, 49),  },
            new Color[16]{ Color.FromArgb(255, 180, 123, 91), Color.FromArgb(255, 221, 217, 143), Color.FromArgb(255, 41, 55, 201), Color.FromArgb(255, 70, 129, 35), Color.FromArgb(255, 110, 80, 48), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 211, 25, 26), Color.FromArgb(255, 159, 221, 221), Color.FromArgb(255, 140, 182, 188), Color.FromArgb(255, 35, 67, 118), Color.FromArgb(255, 171, 178, 191),  },
            new Color[16]{ Color.FromArgb(255, 179, 123, 91), Color.FromArgb(255, 226, 216, 135), Color.FromArgb(255, 40, 54, 201), Color.FromArgb(255, 76, 129, 32), Color.FromArgb(255, 103, 75, 44), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_City = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 81, 81, 81), Color.FromArgb(255, 125, 126, 120), Color.FromArgb(255, 111, 87, 51), Color.FromArgb(255, 88, 79, 48), Color.FromArgb(255, 157, 120, 73), Color.FromArgb(255, 122, 117, 111), Color.FromArgb(255, 129, 125, 120), Color.FromArgb(255, 119, 62, 45), Color.FromArgb(255, 60, 59, 25), Color.FromArgb(255, 44, 51, 38), Color.FromArgb(255, 33, 50, 32), Color.FromArgb(255, 224, 224, 224), Color.FromArgb(255, 82, 52, 35), Color.FromArgb(255, 150, 132, 18), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 95, 99, 42),  },
            new Color[16]{ Color.FromArgb(255, 115, 111, 106), Color.FromArgb(255, 32, 31, 30), Color.FromArgb(255, 165, 139, 101), Color.FromArgb(255, 122, 113, 102), Color.FromArgb(255, 109, 82, 51), Color.FromArgb(255, 139, 99, 63), Color.FromArgb(255, 173, 173, 173), Color.FromArgb(255, 191, 138, 45), Color.FromArgb(255, 54, 159, 153), Color.FromArgb(255, 63, 214, 106), Color.FromArgb(255, 188, 15, 0), Color.FromArgb(255, 118, 120, 125), Color.FromArgb(255, 121, 34, 35), Color.FromArgb(255, 81, 50, 37), Color.FromArgb(255, 59, 97, 30), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 126, 110, 72), Color.FromArgb(255, 106, 99, 92), Color.FromArgb(255, 75, 77, 75), Color.FromArgb(255, 90, 78, 65), Color.FromArgb(255, 88, 92, 75), Color.FromArgb(255, 29, 9, 39), Color.FromArgb(255, 66, 66, 66), Color.FromArgb(255, 125, 125, 125), Color.FromArgb(255, 150, 155, 158), Color.FromArgb(255, 76, 153, 149), Color.FromArgb(255, 150, 154, 156), Color.FromArgb(255, 57, 98, 134), Color.FromArgb(255, 114, 115, 116), Color.FromArgb(255, 166, 172, 176), Color.FromArgb(255, 117, 119, 124), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 165, 156, 2), Color.FromArgb(255, 118, 119, 120), Color.FromArgb(255, 105, 120, 119), Color.FromArgb(255, 114, 88, 78), Color.FromArgb(255, 81, 81, 81), Color.FromArgb(255, 77, 77, 77), Color.FromArgb(255, 133, 129, 123), Color.FromArgb(255, 23, 28, 19), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 48, 64, 94), Color.FromArgb(255, 60, 62, 64), Color.FromArgb(255, 92, 91, 86), Color.FromArgb(255, 88, 87, 83), Color.FromArgb(255, 138, 129, 118), Color.FromArgb(255, 195, 202, 204), Color.FromArgb(255, 40, 60, 39),  },
            new Color[16]{ Color.FromArgb(255, 227, 221, 215), Color.FromArgb(255, 70, 81, 91), Color.FromArgb(255, 213, 218, 226), Color.FromArgb(153, 134, 158, 211), Color.FromArgb(255, 131, 116, 96), Color.FromArgb(255, 103, 118, 77), Color.FromArgb(255, 70, 88, 46), Color.FromArgb(255, 136, 155, 90), Color.FromArgb(255, 133, 80, 52), Color.FromArgb(255, 113, 110, 55), Color.FromArgb(255, 45, 54, 58), Color.FromArgb(255, 49, 59, 62), Color.FromArgb(255, 148, 148, 148), Color.FromArgb(255, 88, 66, 52), Color.FromArgb(255, 82, 56, 65), Color.FromArgb(255, 51, 65, 44),  },
            new Color[16]{ Color.FromArgb(255, 133, 131, 130), Color.FromArgb(255, 112, 62, 38), Color.FromArgb(255, 175, 178, 180), Color.FromArgb(255, 118, 120, 123), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 130, 130, 130), Color.FromArgb(255, 68, 55, 18), Color.FromArgb(255, 107, 88, 50), Color.FromArgb(255, 94, 111, 50), Color.FromArgb(255, 100, 116, 54), Color.FromArgb(255, 109, 124, 63), Color.FromArgb(255, 99, 110, 59), Color.FromArgb(255, 97, 109, 58), Color.FromArgb(255, 98, 111, 53), Color.FromArgb(255, 97, 108, 51), Color.FromArgb(255, 91, 98, 47),  },
            new Color[16]{ Color.FromArgb(255, 168, 168, 168), Color.FromArgb(255, 103, 58, 38), Color.FromArgb(255, 158, 158, 160), Color.FromArgb(255, 151, 58, 55), Color.FromArgb(255, 105, 109, 89), Color.FromArgb(255, 117, 114, 109), Color.FromArgb(255, 137, 69, 17), Color.FromArgb(255, 66, 25, 21), Color.FromArgb(255, 161, 135, 99), Color.FromArgb(255, 208, 203, 202), Color.FromArgb(255, 80, 92, 44), Color.FromArgb(255, 89, 89, 41), Color.FromArgb(255, 90, 100, 111), Color.FromArgb(255, 112, 126, 138), Color.FromArgb(255, 104, 116, 126), Color.FromArgb(255, 141, 141, 141),  },
            new Color[16]{ Color.FromArgb(255, 90, 84, 79), Color.FromArgb(255, 46, 48, 51), Color.FromArgb(255, 65, 64, 63), Color.FromArgb(255, 95, 41, 41), Color.FromArgb(255, 49, 30, 11), Color.FromArgb(255, 175, 169, 161), Color.FromArgb(255, 159, 81, 20), Color.FromArgb(255, 125, 66, 19), Color.FromArgb(255, 179, 103, 41), Color.FromArgb(255, 99, 72, 110), Color.FromArgb(255, 143, 103, 88), Color.FromArgb(255, 143, 103, 88), Color.FromArgb(255, 115, 62, 38), Color.FromArgb(255, 131, 14, 9), Color.FromArgb(255, 99, 63, 48), Color.FromArgb(255, 146, 146, 146),  },
            new Color[16]{ Color.FromArgb(255, 95, 91, 87), Color.FromArgb(255, 171, 59, 52), Color.FromArgb(255, 196, 138, 154), Color.FromArgb(255, 108, 116, 127), Color.FromArgb(255, 114, 114, 114), Color.FromArgb(255, 96, 96, 96), Color.FromArgb(255, 40, 51, 94), Color.FromArgb(255, 121, 126, 157), Color.FromArgb(255, 108, 146, 57), Color.FromArgb(255, 112, 148, 59), Color.FromArgb(255, 163, 128, 79), Color.FromArgb(255, 158, 120, 73), Color.FromArgb(255, 99, 94, 22), Color.FromArgb(255, 173, 160, 136), Color.FromArgb(255, 163, 142, 109), Color.FromArgb(255, 137, 137, 137),  },
            new Color[16]{ Color.FromArgb(255, 19, 102, 174), Color.FromArgb(255, 60, 77, 28), Color.FromArgb(255, 74, 159, 64), Color.FromArgb(255, 119, 121, 132), Color.FromArgb(255, 143, 144, 146), Color.FromArgb(255, 52, 58, 79), Color.FromArgb(255, 51, 57, 78), Color.FromArgb(255, 82, 84, 97), Color.FromArgb(255, 117, 116, 122), Color.FromArgb(255, 63, 60, 30), Color.FromArgb(255, 136, 106, 66), Color.FromArgb(255, 110, 84, 51), Color.FromArgb(255, 135, 137, 139), Color.FromArgb(255, 109, 102, 107), Color.FromArgb(255, 60, 87, 57), Color.FromArgb(255, 91, 95, 68),  },
            new Color[16]{ Color.FromArgb(255, 80, 111, 123), Color.FromArgb(255, 84, 54, 35), Color.FromArgb(255, 202, 190, 99), Color.FromArgb(255, 102, 82, 62), Color.FromArgb(255, 199, 199, 199), Color.FromArgb(255, 198, 198, 198), Color.FromArgb(255, 58, 112, 87), Color.FromArgb(255, 40, 17, 46), Color.FromArgb(255, 131, 61, 20), Color.FromArgb(255, 131, 85, 42), Color.FromArgb(255, 125, 120, 41), Color.FromArgb(255, 81, 121, 84), Color.FromArgb(255, 136, 137, 139), Color.FromArgb(107, 110, 110, 110), Color.FromArgb(255, 86, 106, 74), Color.FromArgb(255, 118, 108, 82),  },
            new Color[16]{ Color.FromArgb(255, 151, 134, 109), Color.FromArgb(255, 49, 60, 144), Color.FromArgb(255, 109, 143, 213), Color.FromArgb(255, 115, 80, 59), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 63, 67, 75), Color.FromArgb(255, 40, 33, 52), Color.FromArgb(255, 46, 55, 58), Color.FromArgb(255, 111, 113, 123), Color.FromArgb(255, 167, 99, 49), Color.FromArgb(255, 108, 116, 127), Color.FromArgb(255, 119, 122, 133), Color.FromArgb(255, 92, 80, 84), Color.FromArgb(255, 112, 80, 80), Color.FromArgb(255, 55, 38, 37),  },
            new Color[16]{ Color.FromArgb(255, 142, 125, 102), Color.FromArgb(255, 117, 55, 169), Color.FromArgb(255, 175, 74, 183), Color.FromArgb(255, 99, 84, 85), Color.FromArgb(255, 122, 122, 122), Color.FromArgb(255, 104, 104, 104), Color.FromArgb(255, 76, 48, 28), Color.FromArgb(255, 185, 127, 71), Color.FromArgb(255, 0, 107, 3), Color.FromArgb(255, 0, 111, 3), Color.FromArgb(255, 0, 136, 7), Color.FromArgb(255, 85, 126, 28), Color.FromArgb(189, 113, 156, 85), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 138, 122, 99), Color.FromArgb(255, 49, 114, 141), Color.FromArgb(255, 209, 125, 66), Color.FromArgb(255, 83, 68, 37), Color.FromArgb(255, 149, 128, 80), Color.FromArgb(255, 125, 122, 117), Color.FromArgb(255, 152, 87, 30), Color.FromArgb(255, 75, 75, 69), Color.FromArgb(255, 71, 71, 66), Color.FromArgb(255, 131, 131, 131), Color.FromArgb(255, 208, 196, 177), Color.FromArgb(255, 221, 209, 190), Color.FromArgb(255, 102, 102, 102), Color.FromArgb(255, 109, 87, 83), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 50, 24, 22), Color.FromArgb(255, 211, 208, 200), Color.FromArgb(255, 123, 27, 27), Color.FromArgb(255, 128, 27, 27), Color.FromArgb(255, 126, 27, 27), Color.FromArgb(255, 142, 124, 100), Color.FromArgb(255, 148, 129, 104), Color.FromArgb(255, 74, 74, 68), Color.FromArgb(255, 64, 65, 59), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 205, 193, 174), Color.FromArgb(255, 217, 205, 186), Color.FromArgb(255, 84, 84, 84), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 106, 106, 106), Color.FromArgb(255, 108, 108, 108), Color.FromArgb(255, 98, 98, 98), Color.FromArgb(255, 93, 93, 93), Color.FromArgb(255, 89, 89, 89), Color.FromArgb(255, 85, 85, 85), Color.FromArgb(255, 73, 73, 73), Color.FromArgb(255, 68, 68, 68), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 54, 54, 54), Color.FromArgb(255, 140, 116, 9), Color.FromArgb(255, 218, 206, 187), Color.FromArgb(255, 95, 95, 95), Color.FromArgb(255, 170, 143, 8), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 29, 30, 31), Color.FromArgb(255, 136, 112, 98), Color.FromArgb(255, 45, 54, 58), Color.FromArgb(255, 120, 116, 110), Color.FromArgb(255, 112, 108, 103), Color.FromArgb(255, 201, 199, 192), Color.FromArgb(255, 227, 224, 215), Color.FromArgb(255, 176, 116, 94), Color.FromArgb(255, 149, 99, 81), Color.FromArgb(255, 0, 107, 3), Color.FromArgb(255, 0, 111, 3), Color.FromArgb(255, 0, 136, 7), Color.FromArgb(255, 49, 136, 9), Color.FromArgb(255, 112, 87, 58), Color.FromArgb(255, 113, 104, 56), Color.FromArgb(255, 157, 125, 99),  },
            new Color[16]{ Color.FromArgb(255, 57, 46, 40), Color.FromArgb(255, 69, 82, 141), Color.FromArgb(255, 107, 71, 51), Color.FromArgb(255, 86, 128, 141), Color.FromArgb(255, 109, 95, 87), Color.FromArgb(255, 95, 104, 44), Color.FromArgb(255, 134, 146, 173), Color.FromArgb(255, 126, 162, 40), Color.FromArgb(255, 186, 114, 163), Color.FromArgb(255, 186, 125, 54), Color.FromArgb(255, 194, 143, 157), Color.FromArgb(255, 155, 88, 159), Color.FromArgb(255, 170, 65, 58), Color.FromArgb(255, 168, 155, 151), Color.FromArgb(255, 203, 192, 186), Color.FromArgb(255, 191, 180, 54),  },
            new Color[16]{ Color.FromArgb(255, 77, 77, 78), Color.FromArgb(255, 84, 101, 142), Color.FromArgb(255, 108, 95, 86), Color.FromArgb(255, 95, 128, 142), Color.FromArgb(255, 108, 109, 109), Color.FromArgb(255, 100, 114, 81), Color.FromArgb(255, 123, 140, 164), Color.FromArgb(255, 118, 151, 78), Color.FromArgb(255, 158, 120, 157), Color.FromArgb(255, 158, 127, 88), Color.FromArgb(255, 166, 138, 153), Color.FromArgb(255, 136, 105, 154), Color.FromArgb(255, 147, 91, 91), Color.FromArgb(255, 145, 146, 149), Color.FromArgb(255, 173, 173, 174), Color.FromArgb(255, 163, 164, 88),  },
            new Color[16]{ Color.FromArgb(255, 92, 93, 94), Color.FromArgb(255, 100, 117, 158), Color.FromArgb(255, 123, 110, 102), Color.FromArgb(255, 110, 143, 158), Color.FromArgb(255, 124, 124, 125), Color.FromArgb(255, 116, 129, 97), Color.FromArgb(255, 138, 155, 180), Color.FromArgb(255, 133, 166, 94), Color.FromArgb(255, 174, 135, 173), Color.FromArgb(255, 174, 142, 104), Color.FromArgb(255, 181, 153, 169), Color.FromArgb(255, 152, 120, 170), Color.FromArgb(255, 162, 106, 107), Color.FromArgb(255, 160, 161, 165), Color.FromArgb(255, 188, 189, 190), Color.FromArgb(255, 178, 179, 104),  },
            new Color[16]{ Color.FromArgb(255, 113, 113, 113), Color.FromArgb(255, 119, 119, 119), Color.FromArgb(255, 132, 90, 122), Color.FromArgb(255, 122, 91, 32), Color.FromArgb(255, 156, 133, 135), Color.FromArgb(255, 138, 121, 52), Color.FromArgb(255, 77, 119, 17), Color.FromArgb(255, 174, 128, 4), Color.FromArgb(255, 71, 43, 28), Color.FromArgb(255, 100, 61, 43), Color.FromArgb(255, 86, 47, 33), Color.FromArgb(255, 97, 97, 97), Color.FromArgb(255, 64, 64, 64), Color.FromArgb(255, 71, 125, 116), Color.FromArgb(255, 163, 90, 40), Color.FromArgb(255, 158, 89, 43),  },
            new Color[16]{ Color.FromArgb(255, 111, 111, 111), Color.FromArgb(255, 109, 109, 109), Color.FromArgb(255, 101, 87, 90), Color.FromArgb(255, 105, 83, 28), Color.FromArgb(255, 145, 128, 121), Color.FromArgb(255, 123, 101, 96), Color.FromArgb(255, 79, 120, 16), Color.FromArgb(255, 135, 129, 15), Color.FromArgb(255, 45, 31, 17), Color.FromArgb(255, 76, 45, 25), Color.FromArgb(255, 35, 23, 14), Color.FromArgb(255, 81, 81, 81), Color.FromArgb(255, 77, 77, 77), Color.FromArgb(255, 57, 107, 95), Color.FromArgb(255, 146, 79, 35), Color.FromArgb(255, 149, 82, 37),  },
            new Color[16]{ Color.FromArgb(255, 165, 89, 160), Color.FromArgb(255, 80, 136, 149), Color.FromArgb(255, 143, 148, 102), Color.FromArgb(255, 194, 197, 165), Color.FromArgb(255, 111, 94, 64), Color.FromArgb(255, 139, 145, 106), Color.FromArgb(255, 91, 97, 9), Color.FromArgb(255, 69, 72, 15), Color.FromArgb(255, 118, 93, 53), Color.FromArgb(255, 111, 86, 41), Color.FromArgb(255, 116, 87, 23), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 94, 129, 120), Color.FromArgb(255, 147, 77, 30), Color.FromArgb(255, 146, 76, 27),  },
            new Color[16]{ Color.FromArgb(255, 89, 47, 31), Color.FromArgb(255, 150, 87, 43), Color.FromArgb(255, 77, 66, 64), Color.FromArgb(255, 181, 114, 49), Color.FromArgb(255, 85, 56, 25), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 153, 28, 7), Color.FromArgb(255, 144, 185, 222), Color.FromArgb(255, 124, 209, 186), Color.FromArgb(255, 36, 18, 64), Color.FromArgb(255, 145, 145, 145),  },
            new Color[16]{ Color.FromArgb(255, 98, 62, 48), Color.FromArgb(255, 151, 87, 43), Color.FromArgb(255, 74, 64, 62), Color.FromArgb(255, 178, 110, 46), Color.FromArgb(255, 82, 53, 23), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Fantasy = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 93, 92, 87), Color.FromArgb(255, 126, 125, 123), Color.FromArgb(255, 66, 43, 34), Color.FromArgb(255, 63, 50, 36), Color.FromArgb(255, 92, 72, 54), Color.FromArgb(255, 76, 77, 76), Color.FromArgb(255, 112, 115, 116), Color.FromArgb(255, 111, 75, 45), Color.FromArgb(255, 113, 85, 52), Color.FromArgb(255, 128, 41, 38), Color.FromArgb(255, 88, 74, 43), Color.FromArgb(255, 210, 210, 210), Color.FromArgb(255, 102, 40, 33), Color.FromArgb(255, 59, 69, 38), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 55, 72, 33),  },
            new Color[16]{ Color.FromArgb(255, 99, 99, 99), Color.FromArgb(255, 35, 37, 43), Color.FromArgb(255, 210, 203, 176), Color.FromArgb(255, 99, 93, 90), Color.FromArgb(255, 66, 44, 20), Color.FromArgb(255, 122, 89, 39), Color.FromArgb(255, 109, 103, 86), Color.FromArgb(255, 138, 116, 60), Color.FromArgb(255, 85, 96, 88), Color.FromArgb(255, 58, 122, 60), Color.FromArgb(255, 114, 34, 21), Color.FromArgb(255, 120, 103, 60), Color.FromArgb(255, 117, 46, 46), Color.FromArgb(255, 70, 60, 52), Color.FromArgb(255, 59, 73, 52), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 120, 106, 76), Color.FromArgb(255, 94, 78, 71), Color.FromArgb(255, 83, 82, 81), Color.FromArgb(255, 72, 61, 40), Color.FromArgb(255, 85, 85, 73), Color.FromArgb(255, 23, 25, 35), Color.FromArgb(255, 94, 94, 94), Color.FromArgb(255, 82, 82, 82), Color.FromArgb(255, 130, 118, 66), Color.FromArgb(255, 151, 173, 141), Color.FromArgb(255, 129, 117, 65), Color.FromArgb(255, 81, 67, 41), Color.FromArgb(255, 107, 92, 48), Color.FromArgb(255, 119, 107, 78), Color.FromArgb(255, 120, 103, 59), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 171, 156, 63), Color.FromArgb(255, 143, 124, 43), Color.FromArgb(255, 87, 98, 104), Color.FromArgb(255, 107, 57, 55), Color.FromArgb(255, 93, 93, 93), Color.FromArgb(255, 85, 85, 85), Color.FromArgb(255, 110, 110, 110), Color.FromArgb(255, 49, 26, 7), Color.FromArgb(255, 86, 86, 86), Color.FromArgb(255, 89, 82, 52), Color.FromArgb(255, 90, 73, 39), Color.FromArgb(255, 77, 65, 38), Color.FromArgb(255, 79, 66, 39), Color.FromArgb(255, 139, 110, 52), Color.FromArgb(255, 134, 123, 76), Color.FromArgb(255, 39, 59, 39),  },
            new Color[16]{ Color.FromArgb(255, 208, 208, 208), Color.FromArgb(255, 96, 87, 56), Color.FromArgb(255, 210, 226, 253), Color.FromArgb(166, 124, 168, 244), Color.FromArgb(255, 77, 59, 53), Color.FromArgb(255, 94, 116, 78), Color.FromArgb(255, 60, 93, 52), Color.FromArgb(255, 96, 120, 78), Color.FromArgb(255, 108, 113, 131), Color.FromArgb(255, 116, 117, 55), Color.FromArgb(255, 118, 88, 43), Color.FromArgb(255, 121, 104, 67), Color.FromArgb(255, 117, 117, 117), Color.FromArgb(255, 77, 49, 33), Color.FromArgb(255, 133, 87, 48), Color.FromArgb(255, 77, 92, 51),  },
            new Color[16]{ Color.FromArgb(255, 163, 128, 51), Color.FromArgb(255, 110, 93, 44), Color.FromArgb(255, 130, 118, 73), Color.FromArgb(255, 67, 52, 33), Color.FromArgb(255, 129, 113, 52), Color.FromArgb(255, 61, 68, 70), Color.FromArgb(255, 71, 54, 27), Color.FromArgb(255, 103, 76, 51), Color.FromArgb(255, 41, 62, 35), Color.FromArgb(255, 43, 65, 38), Color.FromArgb(255, 32, 56, 29), Color.FromArgb(255, 38, 65, 34), Color.FromArgb(255, 44, 69, 37), Color.FromArgb(255, 50, 71, 40), Color.FromArgb(255, 51, 74, 42), Color.FromArgb(255, 70, 75, 51),  },
            new Color[16]{ Color.FromArgb(255, 123, 97, 45), Color.FromArgb(255, 102, 84, 40), Color.FromArgb(255, 127, 115, 74), Color.FromArgb(255, 146, 62, 27), Color.FromArgb(255, 102, 102, 93), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 160, 68, 17), Color.FromArgb(255, 74, 12, 13), Color.FromArgb(255, 49, 65, 64), Color.FromArgb(255, 137, 90, 21), Color.FromArgb(255, 61, 65, 67), Color.FromArgb(255, 77, 63, 36), Color.FromArgb(255, 111, 101, 67), Color.FromArgb(255, 114, 107, 76), Color.FromArgb(255, 119, 108, 65), Color.FromArgb(255, 83, 83, 83),  },
            new Color[16]{ Color.FromArgb(255, 83, 74, 56), Color.FromArgb(255, 35, 35, 35), Color.FromArgb(255, 63, 63, 63), Color.FromArgb(255, 108, 77, 33), Color.FromArgb(255, 32, 23, 13), Color.FromArgb(255, 151, 150, 147), Color.FromArgb(255, 177, 89, 25), Color.FromArgb(255, 153, 75, 22), Color.FromArgb(255, 200, 138, 82), Color.FromArgb(255, 217, 198, 194), Color.FromArgb(255, 160, 124, 106), Color.FromArgb(255, 140, 74, 59), Color.FromArgb(255, 150, 82, 52), Color.FromArgb(255, 150, 20, 19), Color.FromArgb(255, 121, 79, 51), Color.FromArgb(255, 94, 94, 94),  },
            new Color[16]{ Color.FromArgb(255, 83, 74, 56), Color.FromArgb(255, 155, 4, 4), Color.FromArgb(255, 220, 125, 138), Color.FromArgb(255, 112, 99, 58), Color.FromArgb(255, 85, 85, 85), Color.FromArgb(255, 72, 72, 72), Color.FromArgb(255, 114, 27, 3), Color.FromArgb(255, 167, 132, 119), Color.FromArgb(255, 99, 129, 57), Color.FromArgb(255, 88, 123, 45), Color.FromArgb(255, 203, 180, 77), Color.FromArgb(255, 44, 44, 44), Color.FromArgb(255, 132, 122, 45), Color.FromArgb(255, 166, 162, 151), Color.FromArgb(255, 180, 154, 113), Color.FromArgb(255, 68, 68, 68),  },
            new Color[16]{ Color.FromArgb(255, 68, 83, 104), Color.FromArgb(255, 4, 96, 1), Color.FromArgb(255, 126, 190, 54), Color.FromArgb(255, 131, 94, 54), Color.FromArgb(255, 133, 105, 37), Color.FromArgb(255, 113, 57, 38), Color.FromArgb(255, 118, 58, 40), Color.FromArgb(255, 119, 96, 75), Color.FromArgb(255, 122, 108, 85), Color.FromArgb(255, 81, 67, 51), Color.FromArgb(255, 85, 78, 46), Color.FromArgb(255, 43, 43, 43), Color.FromArgb(255, 85, 69, 38), Color.FromArgb(255, 128, 107, 69), Color.FromArgb(255, 66, 67, 58), Color.FromArgb(255, 117, 120, 107),  },
            new Color[16]{ Color.FromArgb(255, 61, 88, 134), Color.FromArgb(255, 83, 50, 17), Color.FromArgb(255, 203, 172, 1), Color.FromArgb(255, 93, 81, 54), Color.FromArgb(255, 166, 166, 166), Color.FromArgb(255, 173, 173, 173), Color.FromArgb(255, 127, 70, 40), Color.FromArgb(255, 23, 8, 23), Color.FromArgb(255, 169, 91, 21), Color.FromArgb(255, 149, 114, 61), Color.FromArgb(255, 108, 110, 48), Color.FromArgb(255, 70, 126, 85), Color.FromArgb(255, 180, 149, 54), Color.FromArgb(185, 247, 216, 112), Color.FromArgb(255, 81, 93, 91), Color.FromArgb(255, 185, 184, 157),  },
            new Color[16]{ Color.FromArgb(255, 191, 179, 150), Color.FromArgb(255, 34, 50, 150), Color.FromArgb(255, 71, 184, 211), Color.FromArgb(255, 103, 79, 52), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 63, 33, 27), Color.FromArgb(255, 16, 13, 25), Color.FromArgb(255, 100, 79, 41), Color.FromArgb(255, 61, 48, 36), Color.FromArgb(255, 126, 76, 2), Color.FromArgb(255, 110, 97, 58), Color.FromArgb(255, 130, 91, 54), Color.FromArgb(255, 89, 78, 53), Color.FromArgb(255, 103, 79, 52), Color.FromArgb(255, 94, 52, 50),  },
            new Color[16]{ Color.FromArgb(255, 188, 177, 149), Color.FromArgb(255, 77, 45, 140), Color.FromArgb(255, 154, 62, 178), Color.FromArgb(255, 90, 78, 56), Color.FromArgb(255, 87, 87, 87), Color.FromArgb(255, 75, 75, 75), Color.FromArgb(255, 61, 46, 32), Color.FromArgb(255, 94, 69, 58), Color.FromArgb(255, 55, 67, 50), Color.FromArgb(255, 58, 72, 53), Color.FromArgb(255, 60, 75, 54), Color.FromArgb(255, 85, 93, 57), Color.FromArgb(179, 43, 77, 195), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 173, 161, 134), Color.FromArgb(255, 1, 123, 150), Color.FromArgb(255, 195, 107, 1), Color.FromArgb(255, 111, 82, 35), Color.FromArgb(255, 181, 159, 108), Color.FromArgb(255, 115, 115, 115), Color.FromArgb(255, 132, 107, 69), Color.FromArgb(255, 47, 50, 50), Color.FromArgb(255, 54, 57, 54), Color.FromArgb(255, 202, 198, 192), Color.FromArgb(255, 201, 198, 192), Color.FromArgb(255, 214, 211, 208), Color.FromArgb(255, 56, 56, 56), Color.FromArgb(255, 99, 76, 56), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 52, 23, 23), Color.FromArgb(255, 110, 110, 110), Color.FromArgb(255, 74, 19, 19), Color.FromArgb(255, 80, 17, 18), Color.FromArgb(255, 81, 17, 18), Color.FromArgb(255, 177, 166, 140), Color.FromArgb(255, 186, 175, 146), Color.FromArgb(255, 51, 54, 51), Color.FromArgb(255, 56, 58, 56), Color.FromArgb(255, 203, 199, 194), Color.FromArgb(255, 200, 196, 191), Color.FromArgb(255, 213, 211, 206), Color.FromArgb(255, 44, 44, 44), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 106, 106, 106), Color.FromArgb(255, 108, 108, 108), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 106, 106, 106), Color.FromArgb(255, 104, 104, 104), Color.FromArgb(255, 98, 98, 98), Color.FromArgb(255, 93, 93, 93), Color.FromArgb(255, 81, 81, 81), Color.FromArgb(255, 72, 72, 72), Color.FromArgb(255, 68, 68, 68), Color.FromArgb(255, 138, 119, 19), Color.FromArgb(255, 209, 207, 201), Color.FromArgb(255, 124, 107, 45), Color.FromArgb(255, 182, 154, 7), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 39, 39, 41), Color.FromArgb(255, 112, 112, 107), Color.FromArgb(255, 118, 88, 43), Color.FromArgb(255, 113, 113, 113), Color.FromArgb(255, 116, 116, 116), Color.FromArgb(255, 166, 166, 166), Color.FromArgb(255, 162, 162, 162), Color.FromArgb(255, 136, 99, 91), Color.FromArgb(255, 128, 89, 80), Color.FromArgb(255, 71, 82, 63), Color.FromArgb(255, 72, 85, 64), Color.FromArgb(255, 73, 87, 64), Color.FromArgb(255, 104, 100, 60), Color.FromArgb(255, 74, 57, 37), Color.FromArgb(255, 100, 91, 63), Color.FromArgb(255, 153, 140, 115),  },
            new Color[16]{ Color.FromArgb(255, 46, 46, 44), Color.FromArgb(255, 57, 83, 145), Color.FromArgb(255, 94, 72, 56), Color.FromArgb(255, 73, 128, 146), Color.FromArgb(255, 95, 95, 92), Color.FromArgb(255, 82, 104, 49), Color.FromArgb(255, 120, 146, 177), Color.FromArgb(255, 112, 162, 45), Color.FromArgb(255, 173, 114, 168), Color.FromArgb(255, 173, 126, 59), Color.FromArgb(255, 183, 143, 162), Color.FromArgb(255, 141, 88, 164), Color.FromArgb(255, 157, 66, 63), Color.FromArgb(255, 155, 155, 156), Color.FromArgb(255, 192, 192, 190), Color.FromArgb(255, 180, 180, 59),  },
            new Color[16]{ Color.FromArgb(255, 92, 80, 32), Color.FromArgb(255, 100, 104, 96), Color.FromArgb(255, 123, 97, 40), Color.FromArgb(255, 110, 131, 96), Color.FromArgb(255, 124, 112, 63), Color.FromArgb(255, 116, 117, 35), Color.FromArgb(255, 138, 143, 118), Color.FromArgb(255, 133, 153, 32), Color.FromArgb(255, 174, 123, 111), Color.FromArgb(255, 174, 130, 43), Color.FromArgb(255, 181, 141, 107), Color.FromArgb(255, 152, 107, 108), Color.FromArgb(255, 162, 93, 45), Color.FromArgb(255, 160, 149, 103), Color.FromArgb(255, 188, 176, 128), Color.FromArgb(255, 178, 167, 43),  },
            new Color[16]{ Color.FromArgb(255, 86, 69, 28), Color.FromArgb(255, 94, 93, 92), Color.FromArgb(255, 117, 86, 37), Color.FromArgb(255, 104, 120, 93), Color.FromArgb(255, 118, 101, 60), Color.FromArgb(255, 110, 106, 32), Color.FromArgb(255, 132, 132, 115), Color.FromArgb(255, 127, 142, 29), Color.FromArgb(255, 168, 112, 107), Color.FromArgb(255, 168, 119, 39), Color.FromArgb(255, 175, 130, 103), Color.FromArgb(255, 146, 96, 105), Color.FromArgb(255, 156, 82, 41), Color.FromArgb(255, 154, 137, 99), Color.FromArgb(255, 182, 165, 124), Color.FromArgb(255, 172, 155, 39),  },
            new Color[16]{ Color.FromArgb(255, 88, 88, 88), Color.FromArgb(255, 80, 80, 80), Color.FromArgb(255, 75, 55, 56), Color.FromArgb(255, 66, 45, 29), Color.FromArgb(255, 79, 53, 70), Color.FromArgb(255, 80, 64, 27), Color.FromArgb(255, 38, 51, 19), Color.FromArgb(255, 126, 97, 27), Color.FromArgb(255, 92, 54, 42), Color.FromArgb(255, 151, 95, 59), Color.FromArgb(255, 118, 72, 60), Color.FromArgb(255, 84, 84, 84), Color.FromArgb(255, 77, 77, 77), Color.FromArgb(255, 60, 130, 131), Color.FromArgb(255, 153, 82, 19), Color.FromArgb(255, 139, 69, 10),  },
            new Color[16]{ Color.FromArgb(255, 81, 81, 81), Color.FromArgb(255, 81, 81, 81), Color.FromArgb(255, 65, 53, 49), Color.FromArgb(255, 57, 49, 26), Color.FromArgb(255, 70, 53, 63), Color.FromArgb(255, 81, 76, 71), Color.FromArgb(255, 39, 54, 18), Color.FromArgb(255, 39, 58, 15), Color.FromArgb(255, 26, 16, 12), Color.FromArgb(255, 97, 80, 67), Color.FromArgb(255, 38, 28, 19), Color.FromArgb(255, 93, 93, 93), Color.FromArgb(255, 85, 85, 85), Color.FromArgb(255, 28, 80, 79), Color.FromArgb(255, 137, 68, 10), Color.FromArgb(255, 137, 68, 10),  },
            new Color[16]{ Color.FromArgb(255, 80, 54, 83), Color.FromArgb(255, 26, 72, 100), Color.FromArgb(255, 70, 86, 86), Color.FromArgb(255, 85, 90, 61), Color.FromArgb(255, 53, 47, 32), Color.FromArgb(255, 76, 101, 85), Color.FromArgb(255, 68, 69, 36), Color.FromArgb(255, 44, 50, 37), Color.FromArgb(255, 60, 39, 31), Color.FromArgb(255, 59, 41, 31), Color.FromArgb(255, 42, 40, 27), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 51, 128, 128), Color.FromArgb(255, 129, 63, 7), Color.FromArgb(255, 135, 67, 9),  },
            new Color[16]{ Color.FromArgb(255, 113, 87, 50), Color.FromArgb(255, 124, 103, 54), Color.FromArgb(255, 88, 74, 34), Color.FromArgb(255, 106, 85, 51), Color.FromArgb(255, 107, 88, 43), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 153, 28, 7), Color.FromArgb(255, 134, 175, 245), Color.FromArgb(255, 131, 157, 145), Color.FromArgb(255, 66, 55, 41), Color.FromArgb(255, 125, 117, 91),  },
            new Color[16]{ Color.FromArgb(255, 117, 86, 52), Color.FromArgb(255, 125, 105, 56), Color.FromArgb(255, 87, 72, 33), Color.FromArgb(255, 104, 82, 53), Color.FromArgb(255, 109, 86, 43), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Festive = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 164, 175, 170), Color.FromArgb(255, 108, 114, 129), Color.FromArgb(255, 67, 34, 26), Color.FromArgb(255, 65, 50, 27), Color.FromArgb(255, 99, 72, 42), Color.FromArgb(255, 103, 110, 123), Color.FromArgb(255, 105, 112, 125), Color.FromArgb(255, 150, 76, 63), Color.FromArgb(255, 210, 86, 46), Color.FromArgb(255, 239, 113, 32), Color.FromArgb(255, 217, 83, 15), Color.FromArgb(255, 242, 242, 242), Color.FromArgb(255, 109, 126, 97), Color.FromArgb(255, 170, 100, 51), Color.FromArgb(255, 0, 42, 255), Color.FromArgb(255, 45, 130, 6),  },
            new Color[16]{ Color.FromArgb(255, 148, 135, 116), Color.FromArgb(255, 13, 85, 102), Color.FromArgb(255, 209, 201, 181), Color.FromArgb(255, 153, 146, 125), Color.FromArgb(255, 138, 103, 73), Color.FromArgb(255, 190, 159, 134), Color.FromArgb(255, 176, 175, 175), Color.FromArgb(255, 232, 203, 48), Color.FromArgb(255, 78, 206, 217), Color.FromArgb(255, 52, 148, 91), Color.FromArgb(255, 210, 29, 4), Color.FromArgb(255, 120, 83, 66), Color.FromArgb(255, 140, 188, 214), Color.FromArgb(255, 189, 161, 121), Color.FromArgb(255, 198, 115, 15), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 116, 119, 117), Color.FromArgb(255, 115, 115, 124), Color.FromArgb(255, 104, 106, 113), Color.FromArgb(255, 39, 78, 95), Color.FromArgb(255, 162, 153, 148), Color.FromArgb(255, 29, 28, 37), Color.FromArgb(255, 141, 162, 141), Color.FromArgb(255, 103, 135, 103), Color.FromArgb(255, 182, 103, 54), Color.FromArgb(255, 36, 208, 197), Color.FromArgb(255, 180, 102, 54), Color.FromArgb(255, 190, 106, 54), Color.FromArgb(255, 130, 77, 57), Color.FromArgb(255, 141, 77, 60), Color.FromArgb(255, 131, 64, 63), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 33, 178, 44), Color.FromArgb(255, 109, 76, 49), Color.FromArgb(255, 99, 128, 141), Color.FromArgb(255, 119, 97, 109), Color.FromArgb(255, 90, 106, 81), Color.FromArgb(255, 74, 90, 66), Color.FromArgb(255, 105, 122, 142), Color.FromArgb(255, 76, 71, 73), Color.FromArgb(255, 127, 86, 109), Color.FromArgb(255, 150, 131, 125), Color.FromArgb(255, 187, 104, 53), Color.FromArgb(255, 95, 50, 26), Color.FromArgb(255, 94, 55, 33), Color.FromArgb(255, 156, 94, 52), Color.FromArgb(255, 202, 113, 58), Color.FromArgb(255, 91, 94, 86),  },
            new Color[16]{ Color.FromArgb(255, 225, 226, 236), Color.FromArgb(255, 70, 145, 185), Color.FromArgb(255, 220, 232, 245), Color.FromArgb(153, 153, 194, 255), Color.FromArgb(255, 97, 75, 75), Color.FromArgb(255, 192, 170, 175), Color.FromArgb(255, 115, 180, 120), Color.FromArgb(255, 15, 103, 29), Color.FromArgb(255, 109, 60, 23), Color.FromArgb(255, 104, 100, 36), Color.FromArgb(255, 102, 106, 30), Color.FromArgb(255, 150, 103, 103), Color.FromArgb(255, 195, 216, 239), Color.FromArgb(255, 82, 76, 84), Color.FromArgb(255, 140, 178, 210), Color.FromArgb(255, 135, 164, 149),  },
            new Color[16]{ Color.FromArgb(255, 217, 201, 152), Color.FromArgb(255, 54, 128, 60), Color.FromArgb(255, 193, 196, 168), Color.FromArgb(255, 225, 128, 104), Color.FromArgb(255, 58, 119, 142), Color.FromArgb(255, 157, 171, 149), Color.FromArgb(255, 66, 43, 17), Color.FromArgb(255, 107, 70, 27), Color.FromArgb(255, 182, 107, 112), Color.FromArgb(255, 187, 126, 129), Color.FromArgb(255, 183, 122, 125), Color.FromArgb(255, 173, 109, 112), Color.FromArgb(255, 171, 106, 109), Color.FromArgb(255, 167, 103, 106), Color.FromArgb(255, 167, 101, 104), Color.FromArgb(255, 166, 100, 104),  },
            new Color[16]{ Color.FromArgb(255, 220, 139, 74), Color.FromArgb(255, 74, 127, 76), Color.FromArgb(255, 224, 217, 198), Color.FromArgb(255, 139, 81, 19), Color.FromArgb(255, 125, 188, 240), Color.FromArgb(255, 96, 102, 117), Color.FromArgb(255, 238, 245, 255), Color.FromArgb(255, 161, 228, 255), Color.FromArgb(255, 129, 199, 223), Color.FromArgb(255, 119, 170, 196), Color.FromArgb(255, 202, 97, 111), Color.FromArgb(255, 184, 64, 68), Color.FromArgb(255, 85, 64, 120), Color.FromArgb(255, 197, 161, 9), Color.FromArgb(255, 21, 67, 179), Color.FromArgb(255, 127, 130, 133),  },
            new Color[16]{ Color.FromArgb(255, 95, 173, 114), Color.FromArgb(255, 24, 21, 21), Color.FromArgb(255, 77, 77, 77), Color.FromArgb(255, 93, 68, 14), Color.FromArgb(255, 135, 128, 136), Color.FromArgb(255, 161, 151, 143), Color.FromArgb(255, 232, 241, 254), Color.FromArgb(255, 185, 189, 195), Color.FromArgb(255, 204, 193, 189), Color.FromArgb(255, 205, 183, 125), Color.FromArgb(255, 151, 117, 90), Color.FromArgb(255, 118, 80, 60), Color.FromArgb(255, 97, 54, 38), Color.FromArgb(255, 14, 183, 30), Color.FromArgb(255, 183, 79, 29), Color.FromArgb(255, 126, 129, 132),  },
            new Color[16]{ Color.FromArgb(255, 98, 172, 117), Color.FromArgb(255, 155, 28, 25), Color.FromArgb(255, 191, 89, 69), Color.FromArgb(255, 168, 105, 68), Color.FromArgb(255, 92, 124, 88), Color.FromArgb(255, 61, 93, 49), Color.FromArgb(255, 179, 33, 20), Color.FromArgb(255, 188, 114, 109), Color.FromArgb(255, 166, 113, 100), Color.FromArgb(255, 214, 183, 165), Color.FromArgb(255, 196, 197, 206), Color.FromArgb(255, 127, 1, 6), Color.FromArgb(255, 30, 140, 38), Color.FromArgb(255, 194, 137, 74), Color.FromArgb(255, 202, 163, 92), Color.FromArgb(255, 71, 67, 38),  },
            new Color[16]{ Color.FromArgb(255, 7, 79, 239), Color.FromArgb(255, 95, 116, 75), Color.FromArgb(255, 88, 170, 79), Color.FromArgb(255, 176, 105, 68), Color.FromArgb(255, 105, 64, 15), Color.FromArgb(255, 211, 19, 9), Color.FromArgb(255, 170, 77, 52), Color.FromArgb(255, 175, 106, 88), Color.FromArgb(255, 178, 137, 126), Color.FromArgb(255, 91, 70, 38), Color.FromArgb(255, 181, 36, 35), Color.FromArgb(255, 188, 1, 10), Color.FromArgb(255, 200, 113, 59), Color.FromArgb(255, 165, 131, 86), Color.FromArgb(255, 158, 116, 71), Color.FromArgb(255, 120, 152, 159),  },
            new Color[16]{ Color.FromArgb(255, 107, 123, 147), Color.FromArgb(255, 128, 77, 17), Color.FromArgb(255, 196, 220, 117), Color.FromArgb(255, 99, 165, 136), Color.FromArgb(255, 133, 133, 133), Color.FromArgb(255, 132, 132, 132), Color.FromArgb(255, 152, 23, 19), Color.FromArgb(255, 18, 19, 24), Color.FromArgb(255, 146, 16, 11), Color.FromArgb(255, 144, 24, 17), Color.FromArgb(255, 149, 50, 35), Color.FromArgb(255, 102, 116, 121), Color.FromArgb(255, 54, 82, 112), Color.FromArgb(255, 195, 198, 201), Color.FromArgb(255, 120, 11, 16), Color.FromArgb(255, 118, 201, 240),  },
            new Color[16]{ Color.FromArgb(255, 234, 185, 127), Color.FromArgb(255, 46, 58, 152), Color.FromArgb(255, 100, 149, 249), Color.FromArgb(255, 106, 166, 138), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 64, 25, 29), Color.FromArgb(255, 29, 28, 37), Color.FromArgb(255, 202, 124, 39), Color.FromArgb(255, 126, 109, 66), Color.FromArgb(255, 153, 152, 101), Color.FromArgb(255, 167, 104, 68), Color.FromArgb(255, 176, 104, 68), Color.FromArgb(255, 91, 166, 116), Color.FromArgb(255, 93, 171, 124), Color.FromArgb(255, 155, 217, 254),  },
            new Color[16]{ Color.FromArgb(255, 140, 87, 61), Color.FromArgb(255, 132, 58, 196), Color.FromArgb(255, 213, 75, 191), Color.FromArgb(255, 101, 148, 110), Color.FromArgb(255, 112, 146, 102), Color.FromArgb(255, 91, 125, 77), Color.FromArgb(255, 158, 120, 72), Color.FromArgb(255, 141, 101, 71), Color.FromArgb(255, 20, 130, 2), Color.FromArgb(255, 16, 135, 4), Color.FromArgb(255, 15, 137, 4), Color.FromArgb(255, 39, 127, 4), Color.FromArgb(204, 244, 175, 194), Color.FromArgb(208, 41, 94, 253), Color.FromArgb(208, 41, 94, 253), Color.FromArgb(208, 41, 94, 253),  },
            new Color[16]{ Color.FromArgb(255, 234, 185, 127), Color.FromArgb(255, 107, 185, 217), Color.FromArgb(255, 142, 65, 46), Color.FromArgb(255, 79, 85, 101), Color.FromArgb(255, 182, 145, 78), Color.FromArgb(255, 92, 93, 105), Color.FromArgb(255, 192, 186, 158), Color.FromArgb(255, 172, 89, 47), Color.FromArgb(255, 169, 89, 47), Color.FromArgb(255, 219, 233, 248), Color.FromArgb(255, 153, 224, 249), Color.FromArgb(255, 219, 232, 247), Color.FromArgb(255, 60, 117, 156), Color.FromArgb(255, 112, 153, 113), Color.FromArgb(235, 41, 94, 253), Color.FromArgb(208, 41, 94, 253),  },
            new Color[16]{ Color.FromArgb(255, 123, 198, 228), Color.FromArgb(255, 179, 183, 183), Color.FromArgb(255, 157, 158, 161), Color.FromArgb(255, 139, 148, 163), Color.FromArgb(255, 142, 156, 174), Color.FromArgb(255, 211, 164, 151), Color.FromArgb(255, 201, 148, 102), Color.FromArgb(255, 172, 89, 47), Color.FromArgb(255, 166, 89, 47), Color.FromArgb(255, 202, 223, 237), Color.FromArgb(255, 128, 212, 245), Color.FromArgb(255, 198, 216, 237), Color.FromArgb(255, 108, 184, 100), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 165, 224, 247), Color.FromArgb(255, 162, 223, 246), Color.FromArgb(255, 162, 223, 246), Color.FromArgb(255, 163, 223, 246), Color.FromArgb(255, 163, 223, 246), Color.FromArgb(255, 163, 223, 246), Color.FromArgb(255, 163, 223, 246), Color.FromArgb(255, 163, 223, 246), Color.FromArgb(255, 163, 223, 246), Color.FromArgb(255, 165, 224, 247), Color.FromArgb(255, 158, 150, 11), Color.FromArgb(255, 193, 214, 238), Color.FromArgb(255, 47, 95, 130), Color.FromArgb(255, 215, 156, 4), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 34, 34, 34), Color.FromArgb(255, 146, 57, 29), Color.FromArgb(255, 186, 168, 161), Color.FromArgb(255, 231, 183, 125), Color.FromArgb(255, 233, 183, 124), Color.FromArgb(255, 239, 222, 168), Color.FromArgb(255, 238, 220, 167), Color.FromArgb(255, 243, 189, 203), Color.FromArgb(255, 242, 187, 202), Color.FromArgb(255, 16, 108, 1), Color.FromArgb(255, 16, 107, 1), Color.FromArgb(255, 37, 88, 5), Color.FromArgb(255, 34, 88, 5), Color.FromArgb(255, 145, 121, 109), Color.FromArgb(255, 176, 137, 98), Color.FromArgb(255, 215, 191, 145),  },
            new Color[16]{ Color.FromArgb(255, 30, 14, 8), Color.FromArgb(255, 51, 34, 72), Color.FromArgb(255, 63, 35, 17), Color.FromArgb(255, 58, 64, 64), Color.FromArgb(255, 45, 27, 19), Color.FromArgb(255, 60, 68, 22), Color.FromArgb(255, 74, 70, 113), Color.FromArgb(255, 81, 101, 24), Color.FromArgb(255, 141, 50, 74), Color.FromArgb(255, 182, 52, 0), Color.FromArgb(255, 160, 36, 38), Color.FromArgb(255, 91, 37, 56), Color.FromArgb(255, 141, 27, 13), Color.FromArgb(255, 114, 73, 62), Color.FromArgb(255, 210, 145, 115), Color.FromArgb(255, 201, 105, 0),  },
            new Color[16]{ Color.FromArgb(255, 70, 82, 92), Color.FromArgb(255, 42, 83, 116), Color.FromArgb(255, 99, 74, 33), Color.FromArgb(255, 69, 104, 119), Color.FromArgb(255, 120, 58, 68), Color.FromArgb(255, 77, 88, 87), Color.FromArgb(255, 72, 92, 124), Color.FromArgb(255, 71, 110, 48), Color.FromArgb(255, 116, 50, 69), Color.FromArgb(255, 109, 93, 51), Color.FromArgb(255, 141, 97, 134), Color.FromArgb(255, 91, 78, 109), Color.FromArgb(255, 96, 75, 75), Color.FromArgb(255, 87, 89, 96), Color.FromArgb(255, 91, 89, 90), Color.FromArgb(255, 112, 110, 80),  },
            new Color[16]{ Color.FromArgb(255, 34, 47, 55), Color.FromArgb(255, 12, 53, 78), Color.FromArgb(255, 79, 55, 11), Color.FromArgb(255, 12, 52, 77), Color.FromArgb(255, 76, 12, 26), Color.FromArgb(255, 35, 48, 55), Color.FromArgb(255, 11, 40, 75), Color.FromArgb(255, 28, 84, 13), Color.FromArgb(255, 76, 11, 26), Color.FromArgb(255, 60, 50, 9), Color.FromArgb(255, 95, 61, 104), Color.FromArgb(255, 32, 29, 59), Color.FromArgb(255, 55, 35, 40), Color.FromArgb(255, 43, 43, 45), Color.FromArgb(255, 39, 43, 48), Color.FromArgb(255, 43, 43, 43),  },
            new Color[16]{ Color.FromArgb(255, 113, 141, 74), Color.FromArgb(255, 114, 146, 115), Color.FromArgb(255, 104, 32, 29), Color.FromArgb(255, 89, 91, 47), Color.FromArgb(255, 88, 108, 55), Color.FromArgb(255, 89, 112, 44), Color.FromArgb(255, 105, 79, 10), Color.FromArgb(255, 81, 71, 30), Color.FromArgb(255, 115, 104, 96), Color.FromArgb(255, 127, 85, 62), Color.FromArgb(255, 89, 42, 13), Color.FromArgb(255, 80, 85, 20), Color.FromArgb(255, 68, 73, 17), Color.FromArgb(255, 65, 141, 173), Color.FromArgb(255, 159, 29, 26), Color.FromArgb(255, 175, 32, 29),  },
            new Color[16]{ Color.FromArgb(255, 85, 122, 73), Color.FromArgb(255, 51, 87, 37), Color.FromArgb(255, 54, 83, 36), Color.FromArgb(255, 71, 82, 40), Color.FromArgb(255, 87, 99, 69), Color.FromArgb(255, 92, 118, 72), Color.FromArgb(255, 103, 77, 9), Color.FromArgb(255, 57, 72, 28), Color.FromArgb(255, 66, 47, 35), Color.FromArgb(255, 98, 75, 64), Color.FromArgb(255, 68, 46, 34), Color.FromArgb(255, 90, 106, 81), Color.FromArgb(255, 74, 90, 66), Color.FromArgb(255, 27, 80, 102), Color.FromArgb(255, 176, 32, 29), Color.FromArgb(255, 176, 33, 30),  },
            new Color[16]{ Color.FromArgb(255, 98, 84, 71), Color.FromArgb(255, 94, 126, 136), Color.FromArgb(255, 179, 206, 229), Color.FromArgb(255, 139, 74, 79), Color.FromArgb(255, 80, 88, 37), Color.FromArgb(255, 85, 121, 77), Color.FromArgb(255, 132, 130, 74), Color.FromArgb(255, 82, 113, 92), Color.FromArgb(255, 62, 30, 24), Color.FromArgb(255, 61, 36, 32), Color.FromArgb(255, 54, 43, 37), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 65, 143, 176), Color.FromArgb(255, 166, 30, 27), Color.FromArgb(255, 166, 30, 28),  },
            new Color[16]{ Color.FromArgb(255, 151, 39, 56), Color.FromArgb(255, 197, 195, 188), Color.FromArgb(255, 67, 64, 67), Color.FromArgb(255, 68, 92, 78), Color.FromArgb(255, 58, 40, 24), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 136, 208, 253), Color.FromArgb(255, 93, 154, 180), Color.FromArgb(255, 142, 125, 120), Color.FromArgb(255, 190, 146, 146),  },
            new Color[16]{ Color.FromArgb(255, 180, 54, 60), Color.FromArgb(255, 169, 175, 158), Color.FromArgb(255, 90, 89, 91), Color.FromArgb(255, 66, 91, 77), Color.FromArgb(255, 54, 36, 22), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Greek_Mythology = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 177, 175, 166), Color.FromArgb(255, 195, 191, 180), Color.FromArgb(255, 142, 95, 52), Color.FromArgb(255, 139, 102, 57), Color.FromArgb(255, 169, 139, 85), Color.FromArgb(255, 198, 194, 180), Color.FromArgb(255, 197, 193, 179), Color.FromArgb(255, 178, 173, 155), Color.FromArgb(255, 103, 90, 73), Color.FromArgb(255, 113, 94, 71), Color.FromArgb(255, 81, 66, 48), Color.FromArgb(255, 216, 216, 216), Color.FromArgb(255, 126, 120, 110), Color.FromArgb(255, 144, 159, 41), Color.FromArgb(255, 0, 42, 255), Color.FromArgb(255, 103, 101, 42),  },
            new Color[16]{ Color.FromArgb(255, 181, 180, 178), Color.FromArgb(255, 99, 109, 128), Color.FromArgb(255, 232, 226, 181), Color.FromArgb(255, 194, 181, 149), Color.FromArgb(255, 103, 81, 49), Color.FromArgb(255, 146, 118, 73), Color.FromArgb(255, 134, 134, 134), Color.FromArgb(255, 214, 177, 48), Color.FromArgb(255, 199, 196, 136), Color.FromArgb(255, 95, 133, 85), Color.FromArgb(255, 211, 47, 49), Color.FromArgb(255, 135, 125, 109), Color.FromArgb(255, 214, 136, 57), Color.FromArgb(255, 143, 116, 99), Color.FromArgb(255, 84, 103, 59), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 192, 176, 126), Color.FromArgb(255, 187, 173, 155), Color.FromArgb(255, 133, 129, 122), Color.FromArgb(255, 133, 115, 79), Color.FromArgb(255, 142, 158, 103), Color.FromArgb(255, 32, 32, 32), Color.FromArgb(255, 175, 173, 165), Color.FromArgb(255, 156, 154, 147), Color.FromArgb(255, 161, 156, 139), Color.FromArgb(255, 215, 185, 76), Color.FromArgb(255, 162, 158, 141), Color.FromArgb(255, 144, 122, 83), Color.FromArgb(255, 132, 126, 110), Color.FromArgb(255, 159, 154, 137), Color.FromArgb(255, 142, 135, 118), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 187, 142, 31), Color.FromArgb(255, 221, 235, 235), Color.FromArgb(255, 188, 189, 181), Color.FromArgb(255, 188, 150, 142), Color.FromArgb(255, 146, 142, 127), Color.FromArgb(255, 135, 131, 117), Color.FromArgb(255, 198, 194, 179), Color.FromArgb(255, 120, 104, 76), Color.FromArgb(255, 129, 129, 129), Color.FromArgb(255, 207, 185, 75), Color.FromArgb(255, 179, 142, 17), Color.FromArgb(255, 130, 112, 79), Color.FromArgb(255, 134, 116, 83), Color.FromArgb(255, 145, 135, 110), Color.FromArgb(255, 172, 167, 149), Color.FromArgb(255, 121, 145, 67),  },
            new Color[16]{ Color.FromArgb(255, 213, 198, 157), Color.FromArgb(255, 64, 46, 24), Color.FromArgb(255, 221, 235, 244), Color.FromArgb(187, 176, 198, 212), Color.FromArgb(255, 159, 129, 101), Color.FromArgb(255, 123, 145, 58), Color.FromArgb(255, 119, 139, 56), Color.FromArgb(255, 169, 188, 94), Color.FromArgb(255, 114, 95, 80), Color.FromArgb(255, 163, 167, 74), Color.FromArgb(255, 194, 158, 43), Color.FromArgb(255, 211, 177, 47), Color.FromArgb(255, 98, 111, 51), Color.FromArgb(255, 151, 121, 93), Color.FromArgb(255, 177, 173, 169), Color.FromArgb(255, 140, 110, 54),  },
            new Color[16]{ Color.FromArgb(255, 191, 152, 28), Color.FromArgb(255, 138, 98, 36), Color.FromArgb(255, 149, 115, 38), Color.FromArgb(255, 127, 91, 27), Color.FromArgb(255, 128, 89, 32), Color.FromArgb(255, 78, 68, 55), Color.FromArgb(255, 73, 51, 31), Color.FromArgb(255, 160, 126, 92), Color.FromArgb(255, 130, 179, 27), Color.FromArgb(255, 151, 194, 59), Color.FromArgb(255, 178, 213, 100), Color.FromArgb(255, 186, 214, 121), Color.FromArgb(255, 184, 203, 128), Color.FromArgb(255, 195, 204, 135), Color.FromArgb(255, 203, 202, 135), Color.FromArgb(255, 203, 193, 135),  },
            new Color[16]{ Color.FromArgb(255, 112, 78, 46), Color.FromArgb(255, 138, 97, 33), Color.FromArgb(255, 156, 121, 34), Color.FromArgb(255, 173, 131, 122), Color.FromArgb(255, 178, 179, 155), Color.FromArgb(255, 194, 190, 176), Color.FromArgb(255, 227, 176, 25), Color.FromArgb(255, 35, 49, 72), Color.FromArgb(255, 48, 61, 80), Color.FromArgb(255, 153, 102, 34), Color.FromArgb(255, 90, 76, 54), Color.FromArgb(255, 80, 59, 27), Color.FromArgb(255, 167, 131, 21), Color.FromArgb(255, 199, 162, 32), Color.FromArgb(255, 184, 150, 34), Color.FromArgb(255, 158, 158, 158),  },
            new Color[16]{ Color.FromArgb(255, 152, 142, 123), Color.FromArgb(255, 70, 54, 41), Color.FromArgb(255, 72, 72, 72), Color.FromArgb(255, 135, 132, 129), Color.FromArgb(255, 162, 145, 109), Color.FromArgb(255, 113, 105, 93), Color.FromArgb(255, 233, 183, 36), Color.FromArgb(255, 201, 155, 19), Color.FromArgb(255, 214, 167, 23), Color.FromArgb(255, 175, 129, 64), Color.FromArgb(255, 176, 130, 64), Color.FromArgb(255, 198, 170, 106), Color.FromArgb(255, 142, 95, 33), Color.FromArgb(255, 216, 123, 36), Color.FromArgb(255, 132, 106, 89), Color.FromArgb(255, 168, 168, 168),  },
            new Color[16]{ Color.FromArgb(255, 149, 138, 118), Color.FromArgb(255, 144, 73, 34), Color.FromArgb(255, 165, 108, 90), Color.FromArgb(255, 183, 176, 162), Color.FromArgb(255, 107, 103, 86), Color.FromArgb(255, 102, 98, 82), Color.FromArgb(255, 54, 68, 40), Color.FromArgb(255, 168, 155, 116), Color.FromArgb(255, 164, 166, 109), Color.FromArgb(255, 156, 157, 96), Color.FromArgb(255, 76, 56, 30), Color.FromArgb(255, 44, 32, 16), Color.FromArgb(255, 135, 98, 30), Color.FromArgb(255, 213, 193, 177), Color.FromArgb(255, 168, 148, 131), Color.FromArgb(255, 136, 129, 116),  },
            new Color[16]{ Color.FromArgb(255, 46, 94, 171), Color.FromArgb(255, 54, 65, 44), Color.FromArgb(255, 150, 136, 19), Color.FromArgb(255, 191, 175, 161), Color.FromArgb(255, 217, 233, 233), Color.FromArgb(255, 132, 124, 47), Color.FromArgb(255, 128, 120, 45), Color.FromArgb(255, 191, 168, 87), Color.FromArgb(255, 217, 199, 128), Color.FromArgb(255, 76, 72, 50), Color.FromArgb(255, 65, 47, 25), Color.FromArgb(255, 67, 49, 26), Color.FromArgb(255, 193, 189, 175), Color.FromArgb(255, 142, 95, 53), Color.FromArgb(255, 98, 51, 42), Color.FromArgb(255, 86, 49, 41),  },
            new Color[16]{ Color.FromArgb(255, 144, 152, 164), Color.FromArgb(255, 75, 53, 26), Color.FromArgb(255, 129, 96, 71), Color.FromArgb(255, 151, 137, 106), Color.FromArgb(255, 226, 226, 226), Color.FromArgb(255, 226, 226, 226), Color.FromArgb(255, 169, 104, 61), Color.FromArgb(255, 128, 86, 75), Color.FromArgb(255, 217, 168, 41), Color.FromArgb(255, 179, 173, 34), Color.FromArgb(255, 110, 116, 40), Color.FromArgb(255, 170, 187, 165), Color.FromArgb(255, 93, 74, 48), Color.FromArgb(107, 104, 104, 104), Color.FromArgb(255, 102, 59, 34), Color.FromArgb(255, 57, 44, 36),  },
            new Color[16]{ Color.FromArgb(255, 226, 203, 159), Color.FromArgb(255, 66, 87, 134), Color.FromArgb(255, 110, 129, 149), Color.FromArgb(255, 164, 151, 113), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 155, 79, 46), Color.FromArgb(255, 102, 44, 14), Color.FromArgb(255, 167, 161, 140), Color.FromArgb(255, 121, 89, 43), Color.FromArgb(255, 112, 89, 60), Color.FromArgb(255, 185, 179, 165), Color.FromArgb(255, 193, 178, 164), Color.FromArgb(255, 157, 144, 107), Color.FromArgb(255, 164, 152, 110), Color.FromArgb(255, 61, 75, 98),  },
            new Color[16]{ Color.FromArgb(255, 227, 204, 161), Color.FromArgb(255, 91, 59, 96), Color.FromArgb(255, 150, 130, 143), Color.FromArgb(255, 147, 135, 105), Color.FromArgb(255, 122, 116, 101), Color.FromArgb(255, 113, 108, 94), Color.FromArgb(255, 117, 88, 52), Color.FromArgb(255, 148, 99, 72), Color.FromArgb(255, 139, 169, 30), Color.FromArgb(255, 100, 155, 37), Color.FromArgb(255, 68, 138, 29), Color.FromArgb(255, 102, 138, 28), Color.FromArgb(207, 120, 161, 64), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 208, 183, 139), Color.FromArgb(255, 36, 85, 101), Color.FromArgb(255, 112, 77, 45), Color.FromArgb(255, 71, 42, 24), Color.FromArgb(255, 139, 82, 13), Color.FromArgb(255, 181, 178, 164), Color.FromArgb(255, 187, 155, 95), Color.FromArgb(255, 64, 65, 71), Color.FromArgb(255, 67, 68, 74), Color.FromArgb(255, 224, 198, 146), Color.FromArgb(255, 226, 203, 157), Color.FromArgb(255, 226, 203, 159), Color.FromArgb(255, 64, 47, 25), Color.FromArgb(255, 156, 145, 112), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 41, 57, 84), Color.FromArgb(255, 182, 178, 165), Color.FromArgb(255, 38, 46, 51), Color.FromArgb(255, 38, 46, 51), Color.FromArgb(255, 38, 46, 51), Color.FromArgb(255, 224, 198, 147), Color.FromArgb(255, 224, 199, 151), Color.FromArgb(255, 64, 65, 71), Color.FromArgb(255, 75, 76, 82), Color.FromArgb(255, 223, 196, 144), Color.FromArgb(255, 221, 194, 143), Color.FromArgb(255, 227, 205, 162), Color.FromArgb(255, 39, 28, 14), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 74, 74, 74), Color.FromArgb(255, 92, 92, 92), Color.FromArgb(255, 99, 99, 99), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 103, 103, 103), Color.FromArgb(255, 103, 103, 103), Color.FromArgb(255, 104, 104, 104), Color.FromArgb(255, 104, 104, 104), Color.FromArgb(255, 104, 104, 104), Color.FromArgb(255, 104, 104, 104), Color.FromArgb(255, 206, 178, 80), Color.FromArgb(255, 208, 183, 139), Color.FromArgb(255, 64, 47, 25), Color.FromArgb(255, 247, 222, 101), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 28, 30, 32), Color.FromArgb(255, 183, 179, 166), Color.FromArgb(255, 213, 176, 46), Color.FromArgb(255, 194, 189, 180), Color.FromArgb(255, 196, 192, 184), Color.FromArgb(255, 200, 196, 194), Color.FromArgb(255, 193, 189, 188), Color.FromArgb(255, 192, 193, 196), Color.FromArgb(255, 198, 199, 205), Color.FromArgb(255, 172, 194, 93), Color.FromArgb(255, 131, 176, 89), Color.FromArgb(255, 120, 152, 77), Color.FromArgb(255, 119, 143, 73), Color.FromArgb(255, 167, 150, 119), Color.FromArgb(255, 140, 122, 90), Color.FromArgb(255, 146, 139, 127),  },
            new Color[16]{ Color.FromArgb(255, 42, 37, 33), Color.FromArgb(255, 64, 95, 123), Color.FromArgb(255, 96, 69, 38), Color.FromArgb(255, 75, 103, 111), Color.FromArgb(255, 177, 172, 159), Color.FromArgb(255, 54, 95, 75), Color.FromArgb(255, 130, 144, 156), Color.FromArgb(255, 146, 154, 83), Color.FromArgb(255, 219, 216, 204), Color.FromArgb(255, 132, 80, 59), Color.FromArgb(255, 199, 170, 123), Color.FromArgb(255, 225, 199, 149), Color.FromArgb(255, 118, 56, 47), Color.FromArgb(255, 176, 172, 160), Color.FromArgb(255, 190, 182, 174), Color.FromArgb(255, 192, 169, 130),  },
            new Color[16]{ Color.FromArgb(255, 35, 35, 35), Color.FromArgb(255, 35, 82, 127), Color.FromArgb(255, 79, 56, 30), Color.FromArgb(255, 58, 108, 126), Color.FromArgb(255, 69, 69, 69), Color.FromArgb(255, 32, 107, 82), Color.FromArgb(255, 135, 170, 202), Color.FromArgb(255, 149, 173, 74), Color.FromArgb(255, 163, 104, 169), Color.FromArgb(255, 155, 85, 64), Color.FromArgb(255, 198, 139, 159), Color.FromArgb(255, 138, 115, 157), Color.FromArgb(255, 148, 57, 55), Color.FromArgb(255, 156, 153, 141), Color.FromArgb(255, 224, 224, 224), Color.FromArgb(255, 224, 201, 154),  },
            new Color[16]{ Color.FromArgb(255, 37, 37, 37), Color.FromArgb(255, 30, 75, 118), Color.FromArgb(255, 70, 50, 26), Color.FromArgb(255, 49, 98, 116), Color.FromArgb(255, 54, 54, 54), Color.FromArgb(255, 20, 79, 59), Color.FromArgb(255, 113, 151, 185), Color.FromArgb(255, 134, 155, 42), Color.FromArgb(255, 175, 102, 183), Color.FromArgb(255, 164, 90, 67), Color.FromArgb(255, 209, 143, 165), Color.FromArgb(255, 147, 121, 168), Color.FromArgb(255, 165, 71, 70), Color.FromArgb(255, 178, 174, 161), Color.FromArgb(255, 239, 239, 239), Color.FromArgb(255, 231, 213, 176),  },
            new Color[16]{ Color.FromArgb(255, 130, 130, 130), Color.FromArgb(255, 128, 118, 102), Color.FromArgb(255, 102, 93, 82), Color.FromArgb(255, 80, 38, 32), Color.FromArgb(255, 147, 108, 149), Color.FromArgb(255, 129, 102, 52), Color.FromArgb(255, 86, 108, 40), Color.FromArgb(255, 205, 158, 46), Color.FromArgb(255, 76, 78, 70), Color.FromArgb(255, 144, 108, 65), Color.FromArgb(255, 173, 116, 55), Color.FromArgb(255, 142, 137, 122), Color.FromArgb(255, 121, 117, 104), Color.FromArgb(255, 72, 152, 136), Color.FromArgb(255, 191, 88, 47), Color.FromArgb(255, 181, 83, 44),  },
            new Color[16]{ Color.FromArgb(255, 131, 131, 131), Color.FromArgb(255, 152, 150, 143), Color.FromArgb(255, 93, 87, 69), Color.FromArgb(255, 61, 50, 38), Color.FromArgb(255, 117, 102, 104), Color.FromArgb(255, 129, 105, 89), Color.FromArgb(255, 84, 106, 40), Color.FromArgb(255, 180, 157, 40), Color.FromArgb(255, 60, 37, 17), Color.FromArgb(255, 73, 50, 28), Color.FromArgb(255, 83, 60, 35), Color.FromArgb(255, 146, 142, 127), Color.FromArgb(255, 135, 131, 117), Color.FromArgb(255, 36, 119, 107), Color.FromArgb(255, 159, 67, 39), Color.FromArgb(255, 181, 84, 44),  },
            new Color[16]{ Color.FromArgb(255, 147, 118, 199), Color.FromArgb(255, 52, 96, 104), Color.FromArgb(255, 77, 105, 87), Color.FromArgb(255, 203, 200, 162), Color.FromArgb(255, 119, 85, 50), Color.FromArgb(255, 134, 156, 128), Color.FromArgb(255, 107, 122, 67), Color.FromArgb(255, 97, 88, 37), Color.FromArgb(255, 133, 87, 43), Color.FromArgb(255, 133, 87, 46), Color.FromArgb(255, 111, 68, 29), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 66, 142, 146), Color.FromArgb(255, 187, 87, 46), Color.FromArgb(255, 181, 83, 44),  },
            new Color[16]{ Color.FromArgb(255, 179, 160, 115), Color.FromArgb(255, 190, 159, 113), Color.FromArgb(255, 95, 70, 41), Color.FromArgb(255, 143, 101, 70), Color.FromArgb(255, 54, 126, 178), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 211, 25, 26), Color.FromArgb(255, 168, 207, 231), Color.FromArgb(255, 144, 174, 143), Color.FromArgb(255, 94, 137, 162), Color.FromArgb(255, 141, 141, 141),  },
            new Color[16]{ Color.FromArgb(255, 165, 149, 108), Color.FromArgb(255, 183, 152, 111), Color.FromArgb(255, 93, 69, 40), Color.FromArgb(255, 138, 97, 67), Color.FromArgb(255, 51, 123, 173), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Halloween = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 135, 119, 129), Color.FromArgb(255, 125, 110, 120), Color.FromArgb(255, 72, 58, 76), Color.FromArgb(255, 80, 69, 73), Color.FromArgb(255, 137, 120, 94), Color.FromArgb(255, 111, 98, 106), Color.FromArgb(255, 131, 117, 126), Color.FromArgb(255, 94, 67, 57), Color.FromArgb(255, 86, 71, 59), Color.FromArgb(255, 137, 52, 56), Color.FromArgb(255, 85, 77, 63), Color.FromArgb(255, 211, 211, 211), Color.FromArgb(255, 81, 34, 41), Color.FromArgb(255, 164, 151, 20), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 82, 66, 41),  },
            new Color[16]{ Color.FromArgb(255, 121, 108, 116), Color.FromArgb(255, 37, 31, 42), Color.FromArgb(255, 211, 152, 91), Color.FromArgb(255, 102, 89, 95), Color.FromArgb(255, 92, 73, 45), Color.FromArgb(255, 146, 123, 77), Color.FromArgb(255, 162, 173, 183), Color.FromArgb(255, 235, 206, 82), Color.FromArgb(255, 103, 215, 209), Color.FromArgb(255, 78, 205, 111), Color.FromArgb(255, 178, 39, 20), Color.FromArgb(255, 90, 102, 103), Color.FromArgb(255, 84, 67, 84), Color.FromArgb(255, 124, 111, 94), Color.FromArgb(255, 100, 82, 37), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 140, 120, 118), Color.FromArgb(255, 136, 116, 123), Color.FromArgb(255, 117, 104, 112), Color.FromArgb(255, 101, 71, 45), Color.FromArgb(255, 111, 104, 103), Color.FromArgb(255, 35, 31, 46), Color.FromArgb(255, 136, 120, 130), Color.FromArgb(255, 153, 153, 153), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 169, 177, 88), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 167, 154, 118), Color.FromArgb(255, 93, 82, 80), Color.FromArgb(255, 87, 87, 87), Color.FromArgb(255, 100, 98, 83), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 173, 156, 54), Color.FromArgb(255, 66, 41, 25), Color.FromArgb(255, 117, 122, 129), Color.FromArgb(255, 136, 103, 111), Color.FromArgb(255, 57, 55, 55), Color.FromArgb(255, 33, 32, 32), Color.FromArgb(255, 75, 78, 94), Color.FromArgb(255, 42, 37, 36), Color.FromArgb(255, 103, 103, 103), Color.FromArgb(255, 115, 79, 20), Color.FromArgb(255, 58, 48, 31), Color.FromArgb(255, 83, 70, 47), Color.FromArgb(255, 87, 76, 50), Color.FromArgb(255, 95, 103, 80), Color.FromArgb(255, 121, 121, 121), Color.FromArgb(255, 38, 35, 25),  },
            new Color[16]{ Color.FromArgb(255, 227, 227, 227), Color.FromArgb(255, 22, 28, 33), Color.FromArgb(255, 223, 228, 235), Color.FromArgb(162, 106, 21, 167), Color.FromArgb(255, 98, 87, 103), Color.FromArgb(255, 89, 141, 50), Color.FromArgb(255, 110, 101, 60), Color.FromArgb(255, 142, 41, 43), Color.FromArgb(255, 96, 62, 50), Color.FromArgb(255, 99, 64, 18), Color.FromArgb(255, 57, 56, 54), Color.FromArgb(255, 94, 101, 108), Color.FromArgb(255, 55, 55, 55), Color.FromArgb(255, 83, 70, 86), Color.FromArgb(255, 110, 98, 112), Color.FromArgb(255, 174, 175, 170),  },
            new Color[16]{ Color.FromArgb(255, 81, 89, 34), Color.FromArgb(255, 90, 62, 53), Color.FromArgb(255, 23, 30, 35), Color.FromArgb(255, 93, 81, 62), Color.FromArgb(255, 52, 48, 44), Color.FromArgb(255, 24, 31, 36), Color.FromArgb(255, 41, 35, 47), Color.FromArgb(255, 84, 66, 86), Color.FromArgb(255, 91, 116, 3), Color.FromArgb(255, 96, 122, 3), Color.FromArgb(255, 133, 120, 4), Color.FromArgb(255, 190, 169, 55), Color.FromArgb(255, 171, 145, 57), Color.FromArgb(255, 181, 132, 50), Color.FromArgb(255, 173, 126, 46), Color.FromArgb(255, 168, 122, 46),  },
            new Color[16]{ Color.FromArgb(255, 77, 68, 56), Color.FromArgb(255, 95, 53, 42), Color.FromArgb(255, 23, 30, 35), Color.FromArgb(255, 67, 31, 36), Color.FromArgb(255, 63, 70, 67), Color.FromArgb(255, 67, 70, 85), Color.FromArgb(255, 169, 89, 15), Color.FromArgb(255, 74, 87, 32), Color.FromArgb(255, 51, 43, 39), Color.FromArgb(255, 141, 95, 30), Color.FromArgb(255, 89, 63, 82), Color.FromArgb(255, 78, 64, 51), Color.FromArgb(255, 100, 88, 88), Color.FromArgb(255, 116, 106, 110), Color.FromArgb(255, 106, 97, 100), Color.FromArgb(255, 120, 120, 120),  },
            new Color[16]{ Color.FromArgb(255, 136, 135, 129), Color.FromArgb(255, 89, 72, 37), Color.FromArgb(255, 40, 40, 40), Color.FromArgb(255, 47, 28, 33), Color.FromArgb(255, 53, 43, 16), Color.FromArgb(255, 178, 180, 174), Color.FromArgb(255, 178, 91, 12), Color.FromArgb(255, 120, 64, 18), Color.FromArgb(255, 197, 126, 49), Color.FromArgb(255, 192, 201, 192), Color.FromArgb(255, 137, 147, 127), Color.FromArgb(255, 83, 116, 68), Color.FromArgb(255, 95, 77, 70), Color.FromArgb(255, 109, 92, 75), Color.FromArgb(255, 107, 67, 85), Color.FromArgb(255, 126, 126, 126),  },
            new Color[16]{ Color.FromArgb(255, 148, 147, 138), Color.FromArgb(255, 172, 51, 44), Color.FromArgb(255, 100, 64, 45), Color.FromArgb(255, 122, 100, 107), Color.FromArgb(255, 89, 89, 89), Color.FromArgb(255, 73, 73, 73), Color.FromArgb(255, 171, 116, 62), Color.FromArgb(255, 175, 125, 69), Color.FromArgb(255, 88, 131, 38), Color.FromArgb(255, 83, 100, 62), Color.FromArgb(255, 50, 50, 50), Color.FromArgb(255, 40, 40, 40), Color.FromArgb(255, 113, 98, 34), Color.FromArgb(255, 212, 206, 199), Color.FromArgb(255, 148, 113, 96), Color.FromArgb(255, 86, 75, 44),  },
            new Color[16]{ Color.FromArgb(255, 56, 94, 194), Color.FromArgb(255, 108, 83, 44), Color.FromArgb(255, 86, 184, 66), Color.FromArgb(255, 141, 100, 107), Color.FromArgb(255, 69, 42, 26), Color.FromArgb(255, 100, 64, 33), Color.FromArgb(255, 108, 77, 42), Color.FromArgb(255, 108, 77, 42), Color.FromArgb(255, 102, 67, 36), Color.FromArgb(255, 95, 78, 34), Color.FromArgb(255, 45, 45, 45), Color.FromArgb(255, 32, 32, 32), Color.FromArgb(255, 60, 52, 44), Color.FromArgb(255, 108, 74, 79), Color.FromArgb(255, 163, 114, 126), Color.FromArgb(255, 145, 106, 112),  },
            new Color[16]{ Color.FromArgb(255, 117, 108, 129), Color.FromArgb(255, 184, 187, 180), Color.FromArgb(255, 216, 192, 37), Color.FromArgb(255, 148, 137, 120), Color.FromArgb(255, 164, 164, 164), Color.FromArgb(255, 158, 158, 158), Color.FromArgb(255, 101, 76, 88), Color.FromArgb(255, 47, 37, 58), Color.FromArgb(255, 48, 45, 44), Color.FromArgb(255, 36, 34, 33), Color.FromArgb(255, 31, 30, 30), Color.FromArgb(255, 117, 115, 118), Color.FromArgb(255, 79, 77, 79), Color.FromArgb(169, 151, 151, 151), Color.FromArgb(255, 95, 105, 80), Color.FromArgb(255, 206, 123, 163),  },
            new Color[16]{ Color.FromArgb(255, 205, 146, 86), Color.FromArgb(255, 118, 89, 58), Color.FromArgb(255, 76, 128, 200), Color.FromArgb(255, 150, 126, 111), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 63, 46, 68), Color.FromArgb(255, 35, 31, 46), Color.FromArgb(255, 104, 96, 86), Color.FromArgb(255, 93, 77, 53), Color.FromArgb(255, 125, 82, 67), Color.FromArgb(255, 127, 103, 110), Color.FromArgb(255, 140, 103, 111), Color.FromArgb(255, 149, 129, 122), Color.FromArgb(255, 146, 138, 130), Color.FromArgb(255, 97, 110, 56),  },
            new Color[16]{ Color.FromArgb(255, 204, 146, 85), Color.FromArgb(255, 139, 72, 195), Color.FromArgb(255, 42, 38, 32), Color.FromArgb(255, 136, 112, 106), Color.FromArgb(255, 97, 97, 97), Color.FromArgb(255, 74, 74, 74), Color.FromArgb(255, 86, 70, 42), Color.FromArgb(255, 106, 74, 52), Color.FromArgb(255, 36, 79, 20), Color.FromArgb(255, 35, 84, 25), Color.FromArgb(255, 32, 80, 22), Color.FromArgb(255, 43, 78, 24), Color.FromArgb(204, 236, 240, 240), Color.FromArgb(208, 123, 253, 26), Color.FromArgb(208, 123, 253, 26), Color.FromArgb(208, 123, 253, 26),  },
            new Color[16]{ Color.FromArgb(255, 207, 148, 87), Color.FromArgb(255, 137, 99, 52), Color.FromArgb(255, 226, 127, 42), Color.FromArgb(255, 50, 39, 34), Color.FromArgb(255, 95, 88, 62), Color.FromArgb(255, 66, 77, 95), Color.FromArgb(255, 169, 157, 112), Color.FromArgb(255, 61, 61, 61), Color.FromArgb(255, 70, 69, 69), Color.FromArgb(255, 213, 205, 190), Color.FromArgb(255, 217, 209, 193), Color.FromArgb(255, 224, 216, 201), Color.FromArgb(255, 57, 57, 57), Color.FromArgb(255, 146, 124, 108), Color.FromArgb(208, 123, 253, 26), Color.FromArgb(208, 123, 253, 26),  },
            new Color[16]{ Color.FromArgb(255, 43, 57, 42), Color.FromArgb(255, 79, 105, 73), Color.FromArgb(255, 128, 89, 135), Color.FromArgb(255, 140, 94, 154), Color.FromArgb(255, 136, 92, 147), Color.FromArgb(255, 196, 141, 84), Color.FromArgb(255, 196, 141, 83), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 75, 75, 74), Color.FromArgb(255, 223, 214, 200), Color.FromArgb(255, 214, 205, 190), Color.FromArgb(255, 225, 216, 201), Color.FromArgb(255, 57, 57, 57), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 78, 78, 78), Color.FromArgb(255, 80, 80, 80), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 86, 86, 86), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 84, 84, 84), Color.FromArgb(255, 84, 84, 84), Color.FromArgb(255, 82, 82, 82), Color.FromArgb(255, 200, 159, 35), Color.FromArgb(255, 225, 216, 201), Color.FromArgb(255, 78, 78, 78), Color.FromArgb(255, 213, 177, 52), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 34, 31, 32), Color.FromArgb(255, 94, 107, 84), Color.FromArgb(255, 57, 56, 54), Color.FromArgb(255, 134, 134, 117), Color.FromArgb(255, 185, 185, 152), Color.FromArgb(255, 143, 143, 149), Color.FromArgb(255, 182, 182, 187), Color.FromArgb(255, 157, 117, 100), Color.FromArgb(255, 187, 136, 115), Color.FromArgb(255, 36, 79, 20), Color.FromArgb(255, 35, 84, 25), Color.FromArgb(255, 23, 54, 15), Color.FromArgb(255, 55, 63, 36), Color.FromArgb(255, 126, 115, 92), Color.FromArgb(255, 122, 88, 61), Color.FromArgb(255, 201, 179, 123),  },
            new Color[16]{ Color.FromArgb(255, 37, 44, 33), Color.FromArgb(255, 48, 80, 132), Color.FromArgb(255, 83, 69, 44), Color.FromArgb(255, 63, 125, 133), Color.FromArgb(255, 84, 93, 79), Color.FromArgb(255, 72, 101, 38), Color.FromArgb(255, 109, 144, 166), Color.FromArgb(255, 101, 159, 34), Color.FromArgb(255, 164, 111, 156), Color.FromArgb(255, 164, 123, 48), Color.FromArgb(255, 174, 141, 150), Color.FromArgb(255, 131, 85, 151), Color.FromArgb(255, 147, 62, 51), Color.FromArgb(255, 145, 152, 144), Color.FromArgb(255, 184, 190, 179), Color.FromArgb(255, 170, 177, 48),  },
            new Color[16]{ Color.FromArgb(255, 18, 23, 28), Color.FromArgb(255, 54, 56, 87), Color.FromArgb(255, 69, 42, 25), Color.FromArgb(255, 63, 85, 86), Color.FromArgb(255, 46, 46, 46), Color.FromArgb(255, 70, 69, 26), Color.FromArgb(255, 63, 72, 84), Color.FromArgb(255, 97, 135, 26), Color.FromArgb(255, 24, 24, 24), Color.FromArgb(255, 56, 47, 35), Color.FromArgb(255, 41, 41, 41), Color.FromArgb(255, 89, 73, 132), Color.FromArgb(255, 65, 42, 38), Color.FromArgb(255, 140, 137, 139), Color.FromArgb(255, 215, 209, 205), Color.FromArgb(255, 47, 39, 29),  },
            new Color[16]{ Color.FromArgb(255, 29, 29, 29), Color.FromArgb(255, 55, 55, 85), Color.FromArgb(255, 78, 49, 30), Color.FromArgb(255, 18, 47, 47), Color.FromArgb(255, 54, 54, 54), Color.FromArgb(255, 71, 68, 25), Color.FromArgb(255, 42, 42, 42), Color.FromArgb(255, 89, 105, 22), Color.FromArgb(255, 42, 42, 42), Color.FromArgb(255, 61, 51, 39), Color.FromArgb(255, 56, 56, 56), Color.FromArgb(255, 86, 59, 107), Color.FromArgb(255, 42, 42, 42), Color.FromArgb(255, 142, 138, 136), Color.FromArgb(255, 219, 213, 208), Color.FromArgb(255, 61, 51, 39),  },
            new Color[16]{ Color.FromArgb(255, 102, 102, 102), Color.FromArgb(255, 160, 160, 160), Color.FromArgb(255, 157, 160, 164), Color.FromArgb(255, 76, 40, 45), Color.FromArgb(255, 89, 77, 91), Color.FromArgb(255, 141, 107, 36), Color.FromArgb(255, 47, 68, 49), Color.FromArgb(255, 178, 141, 58), Color.FromArgb(255, 77, 72, 65), Color.FromArgb(255, 92, 52, 27), Color.FromArgb(255, 84, 45, 9), Color.FromArgb(255, 103, 103, 103), Color.FromArgb(255, 72, 72, 72), Color.FromArgb(255, 65, 106, 92), Color.FromArgb(255, 165, 85, 35), Color.FromArgb(255, 168, 89, 39),  },
            new Color[16]{ Color.FromArgb(255, 97, 97, 97), Color.FromArgb(255, 159, 159, 159), Color.FromArgb(255, 165, 168, 171), Color.FromArgb(255, 64, 36, 38), Color.FromArgb(255, 82, 74, 85), Color.FromArgb(255, 134, 110, 117), Color.FromArgb(255, 44, 64, 46), Color.FromArgb(255, 94, 91, 37), Color.FromArgb(255, 54, 46, 27), Color.FromArgb(255, 88, 77, 46), Color.FromArgb(255, 60, 45, 29), Color.FromArgb(255, 57, 55, 55), Color.FromArgb(255, 33, 32, 32), Color.FromArgb(255, 44, 70, 62), Color.FromArgb(255, 170, 91, 40), Color.FromArgb(255, 169, 89, 39),  },
            new Color[16]{ Color.FromArgb(255, 133, 99, 133), Color.FromArgb(255, 39, 87, 102), Color.FromArgb(255, 74, 89, 77), Color.FromArgb(255, 156, 156, 122), Color.FromArgb(255, 106, 63, 39), Color.FromArgb(255, 131, 137, 114), Color.FromArgb(255, 77, 69, 59), Color.FromArgb(255, 64, 53, 32), Color.FromArgb(255, 69, 56, 72), Color.FromArgb(255, 95, 70, 65), Color.FromArgb(255, 234, 143, 29), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 77, 105, 87), Color.FromArgb(255, 161, 86, 39), Color.FromArgb(255, 161, 86, 39),  },
            new Color[16]{ Color.FromArgb(255, 89, 49, 27), Color.FromArgb(255, 146, 138, 107), Color.FromArgb(255, 56, 29, 3), Color.FromArgb(255, 125, 90, 39), Color.FromArgb(255, 94, 76, 51), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 211, 25, 26), Color.FromArgb(255, 117, 45, 169), Color.FromArgb(255, 161, 167, 123), Color.FromArgb(255, 100, 58, 118), Color.FromArgb(255, 23, 30, 35),  },
            new Color[16]{ Color.FromArgb(255, 88, 50, 28), Color.FromArgb(255, 161, 150, 108), Color.FromArgb(255, 61, 32, 4), Color.FromArgb(255, 127, 89, 36), Color.FromArgb(255, 91, 74, 49), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Halloween_2015 = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 135, 119, 129), Color.FromArgb(255, 125, 110, 120), Color.FromArgb(255, 72, 58, 75), Color.FromArgb(255, 80, 69, 73), Color.FromArgb(255, 141, 123, 96), Color.FromArgb(255, 111, 98, 106), Color.FromArgb(255, 131, 117, 126), Color.FromArgb(255, 93, 73, 66), Color.FromArgb(255, 86, 70, 59), Color.FromArgb(255, 137, 52, 56), Color.FromArgb(255, 84, 77, 62), Color.FromArgb(255, 211, 211, 211), Color.FromArgb(255, 164, 151, 20), Color.FromArgb(255, 81, 34, 41), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 82, 66, 41),  },
            new Color[16]{ Color.FromArgb(255, 122, 108, 116), Color.FromArgb(255, 37, 31, 42), Color.FromArgb(255, 211, 152, 91), Color.FromArgb(255, 102, 89, 95), Color.FromArgb(255, 96, 77, 47), Color.FromArgb(255, 146, 123, 77), Color.FromArgb(255, 170, 179, 190), Color.FromArgb(255, 238, 219, 90), Color.FromArgb(255, 95, 213, 206), Color.FromArgb(255, 86, 203, 116), Color.FromArgb(255, 178, 35, 15), Color.FromArgb(255, 90, 102, 103), Color.FromArgb(255, 84, 67, 84), Color.FromArgb(255, 124, 111, 94), Color.FromArgb(255, 100, 82, 37), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 140, 120, 118), Color.FromArgb(255, 136, 116, 123), Color.FromArgb(255, 117, 104, 112), Color.FromArgb(255, 74, 75, 72), Color.FromArgb(255, 110, 129, 96), Color.FromArgb(255, 33, 30, 43), Color.FromArgb(255, 136, 120, 130), Color.FromArgb(255, 143, 143, 143), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 169, 177, 88), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 167, 154, 118), Color.FromArgb(255, 93, 82, 80), Color.FromArgb(255, 87, 87, 87), Color.FromArgb(255, 100, 98, 83), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 173, 156, 54), Color.FromArgb(255, 66, 41, 25), Color.FromArgb(255, 117, 122, 129), Color.FromArgb(255, 136, 103, 111), Color.FromArgb(255, 57, 55, 55), Color.FromArgb(255, 33, 32, 32), Color.FromArgb(255, 75, 78, 94), Color.FromArgb(255, 42, 37, 36), Color.FromArgb(255, 103, 103, 103), Color.FromArgb(255, 115, 79, 20), Color.FromArgb(255, 58, 48, 31), Color.FromArgb(255, 83, 70, 47), Color.FromArgb(255, 87, 76, 50), Color.FromArgb(255, 95, 103, 80), Color.FromArgb(255, 121, 121, 121), Color.FromArgb(255, 38, 35, 25),  },
            new Color[16]{ Color.FromArgb(255, 227, 227, 227), Color.FromArgb(255, 22, 28, 33), Color.FromArgb(255, 223, 228, 235), Color.FromArgb(162, 106, 21, 167), Color.FromArgb(255, 98, 87, 103), Color.FromArgb(255, 86, 109, 44), Color.FromArgb(255, 110, 101, 60), Color.FromArgb(255, 142, 41, 43), Color.FromArgb(255, 96, 62, 50), Color.FromArgb(255, 99, 64, 18), Color.FromArgb(255, 57, 56, 54), Color.FromArgb(255, 94, 101, 108), Color.FromArgb(255, 55, 55, 55), Color.FromArgb(255, 77, 66, 80), Color.FromArgb(255, 110, 98, 112), Color.FromArgb(255, 174, 176, 171),  },
            new Color[16]{ Color.FromArgb(255, 81, 89, 34), Color.FromArgb(255, 90, 62, 52), Color.FromArgb(255, 23, 30, 35), Color.FromArgb(255, 93, 81, 62), Color.FromArgb(255, 52, 48, 44), Color.FromArgb(255, 24, 31, 36), Color.FromArgb(255, 41, 35, 47), Color.FromArgb(255, 84, 66, 86), Color.FromArgb(255, 91, 116, 3), Color.FromArgb(255, 96, 122, 3), Color.FromArgb(255, 133, 120, 4), Color.FromArgb(255, 190, 169, 55), Color.FromArgb(255, 171, 145, 57), Color.FromArgb(255, 181, 132, 50), Color.FromArgb(255, 173, 126, 46), Color.FromArgb(255, 168, 122, 46),  },
            new Color[16]{ Color.FromArgb(255, 77, 68, 56), Color.FromArgb(255, 94, 52, 42), Color.FromArgb(255, 23, 30, 35), Color.FromArgb(255, 67, 31, 36), Color.FromArgb(255, 63, 70, 67), Color.FromArgb(255, 67, 70, 85), Color.FromArgb(255, 169, 89, 15), Color.FromArgb(255, 74, 87, 32), Color.FromArgb(255, 51, 43, 39), Color.FromArgb(255, 141, 95, 30), Color.FromArgb(255, 89, 63, 82), Color.FromArgb(255, 78, 64, 51), Color.FromArgb(255, 100, 88, 88), Color.FromArgb(255, 116, 106, 110), Color.FromArgb(255, 106, 97, 100), Color.FromArgb(255, 120, 120, 120),  },
            new Color[16]{ Color.FromArgb(255, 136, 135, 129), Color.FromArgb(255, 97, 79, 42), Color.FromArgb(255, 40, 40, 40), Color.FromArgb(255, 47, 28, 33), Color.FromArgb(255, 53, 43, 16), Color.FromArgb(255, 184, 186, 180), Color.FromArgb(255, 178, 91, 12), Color.FromArgb(255, 120, 64, 18), Color.FromArgb(255, 197, 124, 40), Color.FromArgb(255, 192, 201, 192), Color.FromArgb(255, 137, 147, 127), Color.FromArgb(255, 83, 116, 68), Color.FromArgb(255, 95, 77, 70), Color.FromArgb(255, 109, 92, 75), Color.FromArgb(255, 107, 67, 85), Color.FromArgb(255, 126, 126, 126),  },
            new Color[16]{ Color.FromArgb(255, 148, 147, 138), Color.FromArgb(255, 178, 54, 46), Color.FromArgb(255, 100, 64, 45), Color.FromArgb(255, 122, 100, 107), Color.FromArgb(255, 89, 89, 89), Color.FromArgb(255, 73, 73, 73), Color.FromArgb(255, 172, 117, 62), Color.FromArgb(255, 176, 126, 70), Color.FromArgb(255, 88, 131, 38), Color.FromArgb(255, 83, 100, 62), Color.FromArgb(255, 50, 50, 50), Color.FromArgb(255, 40, 40, 40), Color.FromArgb(255, 113, 98, 34), Color.FromArgb(255, 212, 206, 199), Color.FromArgb(255, 148, 113, 96), Color.FromArgb(255, 86, 75, 44),  },
            new Color[16]{ Color.FromArgb(255, 64, 98, 198), Color.FromArgb(255, 103, 79, 42), Color.FromArgb(255, 87, 190, 65), Color.FromArgb(255, 141, 100, 107), Color.FromArgb(255, 69, 42, 26), Color.FromArgb(255, 100, 64, 33), Color.FromArgb(255, 108, 77, 42), Color.FromArgb(255, 108, 77, 42), Color.FromArgb(255, 102, 67, 36), Color.FromArgb(255, 95, 78, 34), Color.FromArgb(255, 45, 45, 45), Color.FromArgb(255, 32, 32, 32), Color.FromArgb(255, 60, 52, 44), Color.FromArgb(255, 108, 74, 79), Color.FromArgb(255, 165, 103, 123), Color.FromArgb(255, 157, 98, 114),  },
            new Color[16]{ Color.FromArgb(255, 117, 108, 129), Color.FromArgb(255, 184, 186, 180), Color.FromArgb(255, 219, 195, 35), Color.FromArgb(255, 148, 137, 120), Color.FromArgb(255, 164, 164, 164), Color.FromArgb(255, 158, 158, 158), Color.FromArgb(255, 101, 76, 88), Color.FromArgb(255, 47, 37, 58), Color.FromArgb(255, 48, 45, 44), Color.FromArgb(255, 36, 34, 33), Color.FromArgb(255, 31, 30, 30), Color.FromArgb(255, 117, 115, 118), Color.FromArgb(255, 79, 77, 79), Color.FromArgb(169, 151, 151, 151), Color.FromArgb(255, 95, 104, 80), Color.FromArgb(255, 206, 123, 163),  },
            new Color[16]{ Color.FromArgb(255, 205, 146, 86), Color.FromArgb(255, 118, 89, 58), Color.FromArgb(255, 65, 116, 190), Color.FromArgb(255, 150, 126, 111), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 63, 46, 68), Color.FromArgb(255, 35, 31, 46), Color.FromArgb(255, 104, 96, 86), Color.FromArgb(255, 93, 77, 53), Color.FromArgb(255, 125, 82, 67), Color.FromArgb(255, 127, 103, 110), Color.FromArgb(255, 140, 103, 111), Color.FromArgb(255, 149, 129, 122), Color.FromArgb(255, 146, 138, 130), Color.FromArgb(255, 97, 110, 56),  },
            new Color[16]{ Color.FromArgb(255, 206, 147, 87), Color.FromArgb(255, 135, 66, 191), Color.FromArgb(255, 42, 38, 32), Color.FromArgb(255, 136, 112, 106), Color.FromArgb(255, 97, 97, 97), Color.FromArgb(255, 74, 74, 74), Color.FromArgb(255, 86, 70, 42), Color.FromArgb(255, 106, 74, 52), Color.FromArgb(255, 36, 79, 20), Color.FromArgb(255, 35, 84, 25), Color.FromArgb(255, 32, 80, 22), Color.FromArgb(255, 43, 78, 24), Color.FromArgb(204, 236, 240, 240), Color.FromArgb(208, 123, 253, 26), Color.FromArgb(208, 123, 253, 26), Color.FromArgb(208, 123, 253, 26),  },
            new Color[16]{ Color.FromArgb(255, 207, 149, 88), Color.FromArgb(255, 137, 99, 52), Color.FromArgb(255, 219, 123, 37), Color.FromArgb(255, 59, 36, 24), Color.FromArgb(255, 106, 89, 55), Color.FromArgb(255, 66, 77, 95), Color.FromArgb(255, 179, 167, 119), Color.FromArgb(255, 61, 61, 61), Color.FromArgb(255, 70, 69, 69), Color.FromArgb(255, 213, 205, 190), Color.FromArgb(255, 217, 209, 193), Color.FromArgb(255, 224, 216, 201), Color.FromArgb(255, 57, 57, 57), Color.FromArgb(255, 146, 124, 108), Color.FromArgb(208, 123, 253, 26), Color.FromArgb(208, 123, 253, 26),  },
            new Color[16]{ Color.FromArgb(255, 43, 57, 42), Color.FromArgb(255, 79, 105, 73), Color.FromArgb(255, 128, 89, 135), Color.FromArgb(255, 140, 94, 154), Color.FromArgb(255, 136, 92, 147), Color.FromArgb(255, 224, 173, 118), Color.FromArgb(255, 212, 170, 121), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 75, 75, 74), Color.FromArgb(255, 223, 214, 200), Color.FromArgb(255, 214, 205, 190), Color.FromArgb(255, 225, 216, 201), Color.FromArgb(255, 57, 57, 57), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 78, 78, 78), Color.FromArgb(255, 80, 80, 80), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 86, 86, 86), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 84, 84, 84), Color.FromArgb(255, 84, 84, 84), Color.FromArgb(255, 82, 82, 82), Color.FromArgb(255, 200, 159, 35), Color.FromArgb(255, 225, 216, 201), Color.FromArgb(255, 78, 78, 78), Color.FromArgb(255, 213, 177, 52), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 34, 31, 32), Color.FromArgb(255, 94, 107, 84), Color.FromArgb(255, 57, 56, 54), Color.FromArgb(255, 134, 134, 117), Color.FromArgb(255, 185, 185, 152), Color.FromArgb(255, 143, 143, 149), Color.FromArgb(255, 182, 182, 187), Color.FromArgb(255, 157, 117, 100), Color.FromArgb(255, 187, 136, 115), Color.FromArgb(255, 36, 79, 20), Color.FromArgb(255, 35, 84, 25), Color.FromArgb(255, 32, 80, 22), Color.FromArgb(255, 55, 63, 36), Color.FromArgb(255, 187, 164, 106), Color.FromArgb(255, 175, 161, 93), Color.FromArgb(255, 140, 130, 110),  },
            new Color[16]{ Color.FromArgb(255, 37, 44, 33), Color.FromArgb(255, 48, 80, 132), Color.FromArgb(255, 83, 69, 44), Color.FromArgb(255, 63, 125, 133), Color.FromArgb(255, 84, 93, 79), Color.FromArgb(255, 72, 101, 38), Color.FromArgb(255, 109, 144, 166), Color.FromArgb(255, 101, 159, 34), Color.FromArgb(255, 164, 111, 156), Color.FromArgb(255, 164, 123, 48), Color.FromArgb(255, 174, 141, 150), Color.FromArgb(255, 131, 85, 151), Color.FromArgb(255, 147, 62, 51), Color.FromArgb(255, 145, 152, 144), Color.FromArgb(255, 184, 190, 179), Color.FromArgb(255, 170, 177, 48),  },
            new Color[16]{ Color.FromArgb(255, 46, 31, 22), Color.FromArgb(255, 54, 56, 87), Color.FromArgb(255, 77, 49, 31), Color.FromArgb(255, 65, 83, 87), Color.FromArgb(255, 78, 63, 54), Color.FromArgb(255, 70, 69, 26), Color.FromArgb(255, 93, 95, 109), Color.FromArgb(255, 88, 105, 23), Color.FromArgb(255, 129, 75, 102), Color.FromArgb(255, 129, 81, 33), Color.FromArgb(255, 136, 93, 98), Color.FromArgb(255, 106, 59, 99), Color.FromArgb(255, 117, 45, 35), Color.FromArgb(255, 115, 100, 94), Color.FromArgb(255, 143, 128, 119), Color.FromArgb(255, 134, 118, 33),  },
            new Color[16]{ Color.FromArgb(255, 47, 31, 21), Color.FromArgb(255, 55, 55, 85), Color.FromArgb(255, 78, 49, 30), Color.FromArgb(255, 65, 82, 86), Color.FromArgb(255, 79, 63, 53), Color.FromArgb(255, 71, 68, 25), Color.FromArgb(255, 93, 94, 108), Color.FromArgb(255, 89, 105, 22), Color.FromArgb(255, 129, 74, 101), Color.FromArgb(255, 129, 81, 32), Color.FromArgb(255, 136, 92, 97), Color.FromArgb(255, 107, 59, 98), Color.FromArgb(255, 117, 45, 35), Color.FromArgb(255, 116, 100, 93), Color.FromArgb(255, 143, 127, 117), Color.FromArgb(255, 134, 118, 32),  },
            new Color[16]{ Color.FromArgb(255, 102, 102, 102), Color.FromArgb(255, 160, 160, 160), Color.FromArgb(255, 155, 157, 161), Color.FromArgb(255, 76, 40, 45), Color.FromArgb(255, 89, 77, 91), Color.FromArgb(255, 141, 107, 36), Color.FromArgb(255, 47, 68, 49), Color.FromArgb(255, 178, 141, 58), Color.FromArgb(255, 73, 68, 62), Color.FromArgb(255, 92, 52, 27), Color.FromArgb(255, 84, 45, 9), Color.FromArgb(255, 103, 103, 103), Color.FromArgb(255, 72, 72, 72), Color.FromArgb(255, 65, 106, 92), Color.FromArgb(255, 165, 85, 35), Color.FromArgb(255, 168, 89, 39),  },
            new Color[16]{ Color.FromArgb(255, 97, 97, 97), Color.FromArgb(255, 159, 159, 159), Color.FromArgb(255, 163, 165, 169), Color.FromArgb(255, 64, 36, 38), Color.FromArgb(255, 82, 74, 85), Color.FromArgb(255, 134, 110, 117), Color.FromArgb(255, 44, 64, 46), Color.FromArgb(255, 94, 91, 37), Color.FromArgb(255, 54, 46, 27), Color.FromArgb(255, 88, 77, 46), Color.FromArgb(255, 60, 45, 29), Color.FromArgb(255, 57, 55, 55), Color.FromArgb(255, 33, 32, 32), Color.FromArgb(255, 44, 70, 62), Color.FromArgb(255, 170, 91, 40), Color.FromArgb(255, 169, 89, 39),  },
            new Color[16]{ Color.FromArgb(255, 133, 99, 133), Color.FromArgb(255, 39, 87, 102), Color.FromArgb(255, 74, 89, 77), Color.FromArgb(255, 156, 156, 122), Color.FromArgb(255, 106, 63, 39), Color.FromArgb(255, 131, 137, 114), Color.FromArgb(255, 77, 69, 59), Color.FromArgb(255, 64, 53, 32), Color.FromArgb(255, 69, 56, 72), Color.FromArgb(255, 95, 70, 65), Color.FromArgb(255, 234, 143, 29), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 77, 105, 87), Color.FromArgb(255, 161, 86, 39), Color.FromArgb(255, 161, 86, 39),  },
            new Color[16]{ Color.FromArgb(255, 89, 49, 27), Color.FromArgb(255, 137, 128, 99), Color.FromArgb(255, 58, 34, 12), Color.FromArgb(255, 125, 90, 39), Color.FromArgb(255, 94, 75, 49), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 211, 25, 26), Color.FromArgb(255, 117, 45, 169), Color.FromArgb(255, 161, 167, 123), Color.FromArgb(255, 100, 58, 118), Color.FromArgb(255, 23, 30, 35),  },
            new Color[16]{ Color.FromArgb(255, 88, 50, 28), Color.FromArgb(255, 137, 131, 92), Color.FromArgb(255, 60, 31, 3), Color.FromArgb(255, 127, 89, 36), Color.FromArgb(255, 89, 69, 41), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Halo = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 143, 143, 143), Color.FromArgb(255, 111, 102, 92), Color.FromArgb(255, 134, 71, 45), Color.FromArgb(255, 120, 79, 45), Color.FromArgb(255, 107, 110, 105), Color.FromArgb(255, 135, 127, 111), Color.FromArgb(255, 137, 133, 128), Color.FromArgb(255, 81, 87, 86), Color.FromArgb(255, 74, 66, 41), Color.FromArgb(255, 71, 61, 36), Color.FromArgb(255, 81, 67, 48), Color.FromArgb(255, 61, 39, 25), Color.FromArgb(255, 122, 93, 41), Color.FromArgb(255, 119, 89, 24), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 167, 91, 77),  },
            new Color[16]{ Color.FromArgb(255, 145, 141, 135), Color.FromArgb(255, 31, 30, 34), Color.FromArgb(255, 230, 207, 150), Color.FromArgb(255, 91, 82, 68), Color.FromArgb(255, 73, 53, 25), Color.FromArgb(255, 127, 104, 54), Color.FromArgb(255, 70, 72, 68), Color.FromArgb(255, 205, 165, 16), Color.FromArgb(255, 24, 196, 238), Color.FromArgb(255, 54, 172, 16), Color.FromArgb(255, 182, 40, 45), Color.FromArgb(255, 90, 95, 100), Color.FromArgb(255, 137, 113, 72), Color.FromArgb(255, 102, 64, 73), Color.FromArgb(255, 55, 68, 21), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 78, 71, 50), Color.FromArgb(255, 74, 68, 50), Color.FromArgb(255, 60, 60, 50), Color.FromArgb(255, 135, 113, 96), Color.FromArgb(255, 114, 100, 83), Color.FromArgb(255, 12, 19, 34), Color.FromArgb(255, 131, 131, 131), Color.FromArgb(255, 114, 114, 114), Color.FromArgb(255, 106, 118, 128), Color.FromArgb(255, 65, 156, 180), Color.FromArgb(255, 93, 102, 111), Color.FromArgb(255, 56, 113, 193), Color.FromArgb(255, 85, 93, 96), Color.FromArgb(255, 97, 106, 110), Color.FromArgb(255, 108, 120, 133), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 116, 140, 77), Color.FromArgb(255, 135, 137, 134), Color.FromArgb(255, 65, 79, 74), Color.FromArgb(255, 91, 66, 52), Color.FromArgb(255, 96, 96, 96), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 97, 96, 105), Color.FromArgb(255, 98, 61, 18), Color.FromArgb(255, 104, 104, 104), Color.FromArgb(255, 99, 94, 102), Color.FromArgb(255, 130, 123, 175), Color.FromArgb(255, 57, 62, 66), Color.FromArgb(255, 43, 46, 50), Color.FromArgb(255, 113, 138, 163), Color.FromArgb(255, 146, 157, 163), Color.FromArgb(255, 59, 64, 19),  },
            new Color[16]{ Color.FromArgb(255, 187, 194, 194), Color.FromArgb(255, 58, 53, 41), Color.FromArgb(255, 223, 233, 244), Color.FromArgb(181, 175, 202, 236), Color.FromArgb(255, 143, 97, 79), Color.FromArgb(255, 107, 100, 19), Color.FromArgb(255, 114, 106, 21), Color.FromArgb(255, 161, 162, 91), Color.FromArgb(255, 138, 126, 94), Color.FromArgb(255, 47, 54, 53), Color.FromArgb(255, 47, 63, 81), Color.FromArgb(255, 49, 109, 194), Color.FromArgb(255, 93, 93, 93), Color.FromArgb(255, 94, 56, 62), Color.FromArgb(255, 84, 61, 110), Color.FromArgb(255, 102, 99, 56),  },
            new Color[16]{ Color.FromArgb(255, 111, 110, 118), Color.FromArgb(255, 97, 96, 89), Color.FromArgb(255, 64, 65, 59), Color.FromArgb(255, 125, 123, 121), Color.FromArgb(255, 91, 82, 71), Color.FromArgb(255, 89, 89, 89), Color.FromArgb(255, 89, 76, 63), Color.FromArgb(255, 116, 104, 75), Color.FromArgb(255, 44, 55, 15), Color.FromArgb(255, 93, 88, 8), Color.FromArgb(255, 103, 70, 10), Color.FromArgb(255, 98, 50, 11), Color.FromArgb(255, 93, 43, 11), Color.FromArgb(255, 90, 45, 12), Color.FromArgb(255, 85, 46, 13), Color.FromArgb(255, 84, 48, 12),  },
            new Color[16]{ Color.FromArgb(255, 104, 100, 95), Color.FromArgb(255, 94, 93, 80), Color.FromArgb(255, 64, 66, 61), Color.FromArgb(255, 191, 105, 95), Color.FromArgb(255, 121, 119, 104), Color.FromArgb(255, 130, 124, 115), Color.FromArgb(255, 209, 129, 28), Color.FromArgb(255, 59, 25, 15), Color.FromArgb(255, 92, 68, 33), Color.FromArgb(255, 97, 118, 139), Color.FromArgb(255, 92, 75, 106), Color.FromArgb(255, 70, 73, 91), Color.FromArgb(255, 59, 64, 68), Color.FromArgb(255, 55, 60, 59), Color.FromArgb(255, 77, 83, 82), Color.FromArgb(255, 153, 153, 153),  },
            new Color[16]{ Color.FromArgb(255, 111, 160, 228), Color.FromArgb(255, 56, 55, 54), Color.FromArgb(255, 73, 75, 75), Color.FromArgb(255, 147, 116, 113), Color.FromArgb(255, 112, 84, 63), Color.FromArgb(255, 178, 176, 168), Color.FromArgb(255, 200, 121, 24), Color.FromArgb(255, 156, 84, 18), Color.FromArgb(255, 175, 103, 20), Color.FromArgb(255, 213, 166, 170), Color.FromArgb(255, 174, 173, 176), Color.FromArgb(255, 115, 112, 112), Color.FromArgb(255, 140, 138, 141), Color.FromArgb(255, 180, 148, 107), Color.FromArgb(255, 130, 67, 82), Color.FromArgb(255, 141, 141, 141),  },
            new Color[16]{ Color.FromArgb(255, 118, 165, 231), Color.FromArgb(255, 42, 44, 34), Color.FromArgb(255, 91, 78, 136), Color.FromArgb(255, 64, 63, 56), Color.FromArgb(255, 84, 84, 84), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 115, 135, 140), Color.FromArgb(255, 124, 132, 134), Color.FromArgb(255, 106, 123, 58), Color.FromArgb(255, 103, 120, 57), Color.FromArgb(255, 99, 99, 105), Color.FromArgb(255, 54, 53, 57), Color.FromArgb(255, 84, 102, 56), Color.FromArgb(255, 190, 186, 176), Color.FromArgb(255, 127, 106, 86), Color.FromArgb(255, 110, 110, 110),  },
            new Color[16]{ Color.FromArgb(255, 40, 88, 182), Color.FromArgb(255, 80, 87, 85), Color.FromArgb(255, 148, 124, 79), Color.FromArgb(255, 85, 68, 58), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 75, 89, 93), Color.FromArgb(255, 105, 124, 128), Color.FromArgb(255, 104, 123, 127), Color.FromArgb(255, 98, 116, 120), Color.FromArgb(255, 59, 60, 23), Color.FromArgb(255, 67, 67, 71), Color.FromArgb(255, 52, 52, 56), Color.FromArgb(255, 87, 75, 75), Color.FromArgb(255, 87, 94, 94), Color.FromArgb(255, 90, 95, 101), Color.FromArgb(255, 79, 92, 102),  },
            new Color[16]{ Color.FromArgb(255, 65, 72, 86), Color.FromArgb(255, 80, 87, 85), Color.FromArgb(255, 42, 45, 34), Color.FromArgb(255, 97, 139, 195), Color.FromArgb(255, 210, 210, 210), Color.FromArgb(255, 205, 205, 205), Color.FromArgb(255, 92, 126, 156), Color.FromArgb(255, 73, 47, 74), Color.FromArgb(255, 76, 73, 94), Color.FromArgb(255, 115, 99, 74), Color.FromArgb(255, 85, 102, 97), Color.FromArgb(255, 72, 87, 52), Color.FromArgb(255, 86, 79, 73), Color.FromArgb(255, 146, 144, 141), Color.FromArgb(255, 166, 87, 72), Color.FromArgb(255, 91, 124, 169),  },
            new Color[16]{ Color.FromArgb(255, 208, 177, 119), Color.FromArgb(255, 125, 109, 79), Color.FromArgb(255, 183, 149, 87), Color.FromArgb(255, 106, 148, 204), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 100, 108, 107), Color.FromArgb(255, 43, 46, 46), Color.FromArgb(255, 84, 98, 97), Color.FromArgb(255, 33, 52, 91), Color.FromArgb(255, 159, 86, 85), Color.FromArgb(255, 86, 78, 105), Color.FromArgb(255, 116, 91, 118), Color.FromArgb(255, 101, 130, 171), Color.FromArgb(255, 107, 138, 179), Color.FromArgb(255, 76, 52, 43),  },
            new Color[16]{ Color.FromArgb(255, 206, 175, 119), Color.FromArgb(255, 87, 71, 131), Color.FromArgb(255, 88, 72, 132), Color.FromArgb(255, 79, 95, 119), Color.FromArgb(255, 103, 103, 103), Color.FromArgb(255, 88, 88, 88), Color.FromArgb(255, 64, 60, 63), Color.FromArgb(255, 76, 82, 81), Color.FromArgb(255, 82, 99, 58), Color.FromArgb(255, 83, 102, 56), Color.FromArgb(255, 87, 107, 58), Color.FromArgb(255, 87, 97, 46), Color.FromArgb(191, 151, 103, 161), Color.FromArgb(246, 41, 93, 253), Color.FromArgb(246, 41, 93, 253), Color.FromArgb(246, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 166, 133, 86), Color.FromArgb(255, 174, 143, 84), Color.FromArgb(255, 43, 46, 35), Color.FromArgb(255, 97, 71, 61), Color.FromArgb(255, 171, 93, 58), Color.FromArgb(255, 101, 108, 107), Color.FromArgb(255, 69, 68, 67), Color.FromArgb(255, 66, 91, 123), Color.FromArgb(255, 75, 121, 150), Color.FromArgb(255, 121, 128, 123), Color.FromArgb(255, 121, 130, 130), Color.FromArgb(255, 106, 114, 112), Color.FromArgb(255, 72, 73, 59), Color.FromArgb(255, 95, 125, 152), Color.FromArgb(246, 41, 93, 253), Color.FromArgb(246, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 52, 23, 23), Color.FromArgb(255, 87, 91, 90), Color.FromArgb(255, 106, 61, 52), Color.FromArgb(255, 149, 137, 86), Color.FromArgb(255, 151, 135, 89), Color.FromArgb(255, 165, 110, 65), Color.FromArgb(255, 206, 176, 119), Color.FromArgb(255, 66, 96, 127), Color.FromArgb(255, 74, 132, 160), Color.FromArgb(255, 117, 124, 119), Color.FromArgb(255, 43, 42, 45), Color.FromArgb(255, 88, 100, 99), Color.FromArgb(255, 62, 62, 50), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 91, 107, 89), Color.FromArgb(255, 97, 114, 94), Color.FromArgb(255, 95, 112, 92), Color.FromArgb(255, 95, 111, 92), Color.FromArgb(255, 95, 111, 92), Color.FromArgb(255, 95, 112, 93), Color.FromArgb(255, 96, 113, 93), Color.FromArgb(255, 98, 115, 95), Color.FromArgb(255, 97, 114, 94), Color.FromArgb(255, 97, 114, 94), Color.FromArgb(255, 188, 178, 116), Color.FromArgb(255, 109, 118, 116), Color.FromArgb(255, 86, 87, 69), Color.FromArgb(255, 199, 189, 115), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 40, 44, 42), Color.FromArgb(255, 128, 128, 125), Color.FromArgb(255, 99, 94, 102), Color.FromArgb(255, 124, 124, 124), Color.FromArgb(255, 116, 116, 116), Color.FromArgb(255, 145, 164, 162), Color.FromArgb(255, 158, 176, 175), Color.FromArgb(255, 134, 97, 49), Color.FromArgb(255, 130, 96, 49), Color.FromArgb(255, 82, 99, 58), Color.FromArgb(255, 83, 102, 56), Color.FromArgb(255, 87, 107, 58), Color.FromArgb(255, 84, 102, 51), Color.FromArgb(255, 145, 111, 84), Color.FromArgb(255, 117, 119, 51), Color.FromArgb(255, 191, 160, 131),  },
            new Color[16]{ Color.FromArgb(255, 54, 54, 52), Color.FromArgb(255, 65, 92, 155), Color.FromArgb(255, 103, 81, 65), Color.FromArgb(255, 82, 137, 156), Color.FromArgb(255, 105, 105, 103), Color.FromArgb(255, 91, 114, 57), Color.FromArgb(255, 130, 156, 186), Color.FromArgb(255, 121, 170, 53), Color.FromArgb(255, 182, 124, 177), Color.FromArgb(255, 182, 135, 68), Color.FromArgb(255, 191, 153, 171), Color.FromArgb(255, 151, 97, 173), Color.FromArgb(255, 166, 74, 72), Color.FromArgb(255, 164, 164, 166), Color.FromArgb(255, 200, 200, 198), Color.FromArgb(255, 188, 188, 68),  },
            new Color[16]{ Color.FromArgb(255, 127, 128, 125), Color.FromArgb(255, 128, 131, 131), Color.FromArgb(255, 130, 130, 126), Color.FromArgb(255, 129, 133, 131), Color.FromArgb(255, 130, 131, 128), Color.FromArgb(255, 129, 132, 125), Color.FromArgb(255, 132, 135, 133), Color.FromArgb(255, 131, 136, 125), Color.FromArgb(255, 135, 133, 133), Color.FromArgb(255, 135, 133, 126), Color.FromArgb(255, 136, 134, 132), Color.FromArgb(255, 133, 131, 132), Color.FromArgb(255, 134, 130, 126), Color.FromArgb(255, 134, 135, 132), Color.FromArgb(255, 136, 138, 134), Color.FromArgb(255, 135, 137, 126),  },
            new Color[16]{ Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125), Color.FromArgb(255, 129, 130, 125),  },
            new Color[16]{ Color.FromArgb(255, 117, 117, 117), Color.FromArgb(255, 129, 113, 100), Color.FromArgb(255, 77, 100, 35), Color.FromArgb(255, 86, 44, 31), Color.FromArgb(255, 115, 97, 90), Color.FromArgb(255, 123, 111, 39), Color.FromArgb(255, 96, 122, 35), Color.FromArgb(255, 91, 73, 28), Color.FromArgb(255, 125, 84, 62), Color.FromArgb(255, 131, 89, 65), Color.FromArgb(255, 42, 45, 35), Color.FromArgb(255, 117, 117, 117), Color.FromArgb(255, 100, 100, 100), Color.FromArgb(255, 110, 89, 164), Color.FromArgb(255, 164, 87, 30), Color.FromArgb(255, 151, 75, 26),  },
            new Color[16]{ Color.FromArgb(255, 96, 96, 96), Color.FromArgb(255, 102, 102, 102), Color.FromArgb(255, 70, 92, 32), Color.FromArgb(255, 87, 48, 34), Color.FromArgb(255, 95, 83, 70), Color.FromArgb(255, 96, 99, 57), Color.FromArgb(255, 93, 118, 33), Color.FromArgb(255, 113, 112, 37), Color.FromArgb(255, 54, 40, 11), Color.FromArgb(255, 71, 52, 13), Color.FromArgb(255, 85, 70, 129), Color.FromArgb(255, 96, 96, 96), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 74, 71, 117), Color.FromArgb(255, 156, 81, 29), Color.FromArgb(255, 151, 84, 36),  },
            new Color[16]{ Color.FromArgb(255, 90, 75, 30), Color.FromArgb(255, 68, 107, 118), Color.FromArgb(255, 144, 142, 87), Color.FromArgb(255, 93, 115, 74), Color.FromArgb(255, 129, 87, 46), Color.FromArgb(255, 81, 120, 80), Color.FromArgb(255, 89, 52, 35), Color.FromArgb(255, 53, 55, 82), Color.FromArgb(255, 127, 65, 39), Color.FromArgb(255, 111, 79, 45), Color.FromArgb(255, 115, 123, 65), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 78, 91, 114), Color.FromArgb(255, 148, 73, 25), Color.FromArgb(255, 160, 79, 27),  },
            new Color[16]{ Color.FromArgb(255, 42, 45, 35), Color.FromArgb(255, 98, 108, 108), Color.FromArgb(255, 70, 68, 122), Color.FromArgb(255, 70, 77, 76), Color.FromArgb(255, 128, 121, 101), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 211, 25, 26), Color.FromArgb(255, 176, 203, 237), Color.FromArgb(255, 24, 79, 103), Color.FromArgb(255, 55, 55, 64), Color.FromArgb(255, 69, 70, 67),  },
            new Color[16]{ Color.FromArgb(255, 48, 50, 36), Color.FromArgb(255, 83, 94, 95), Color.FromArgb(255, 63, 62, 109), Color.FromArgb(255, 62, 74, 74), Color.FromArgb(255, 123, 116, 97), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Mass_Effect = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 131, 131, 131), Color.FromArgb(255, 111, 106, 98), Color.FromArgb(255, 81, 69, 57), Color.FromArgb(255, 84, 83, 57), Color.FromArgb(255, 94, 106, 123), Color.FromArgb(255, 158, 158, 158), Color.FromArgb(255, 160, 160, 160), Color.FromArgb(255, 71, 81, 88), Color.FromArgb(255, 122, 125, 96), Color.FromArgb(255, 96, 102, 86), Color.FromArgb(255, 141, 126, 46), Color.FromArgb(255, 53, 57, 72), Color.FromArgb(255, 125, 47, 26), Color.FromArgb(255, 76, 92, 70), Color.FromArgb(255, 0, 42, 255), Color.FromArgb(255, 117, 137, 47),  },
            new Color[16]{ Color.FromArgb(255, 163, 170, 170), Color.FromArgb(255, 95, 95, 94), Color.FromArgb(255, 224, 215, 165), Color.FromArgb(255, 56, 58, 61), Color.FromArgb(255, 89, 72, 54), Color.FromArgb(255, 151, 124, 93), Color.FromArgb(255, 112, 119, 125), Color.FromArgb(255, 189, 191, 175), Color.FromArgb(255, 173, 182, 199), Color.FromArgb(255, 68, 73, 83), Color.FromArgb(255, 69, 84, 103), Color.FromArgb(255, 41, 51, 59), Color.FromArgb(255, 169, 112, 70), Color.FromArgb(255, 131, 124, 117), Color.FromArgb(255, 81, 92, 71), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 97, 30, 25), Color.FromArgb(255, 203, 195, 179), Color.FromArgb(255, 91, 89, 84), Color.FromArgb(255, 179, 105, 44), Color.FromArgb(255, 117, 113, 105), Color.FromArgb(255, 202, 195, 178), Color.FromArgb(255, 119, 119, 119), Color.FromArgb(255, 119, 119, 119), Color.FromArgb(255, 44, 51, 62), Color.FromArgb(255, 89, 101, 103), Color.FromArgb(255, 45, 52, 64), Color.FromArgb(255, 132, 158, 163), Color.FromArgb(255, 42, 48, 58), Color.FromArgb(255, 65, 73, 86), Color.FromArgb(255, 42, 52, 60), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 68, 82, 101), Color.FromArgb(255, 108, 126, 132), Color.FromArgb(255, 41, 41, 41), Color.FromArgb(255, 80, 83, 92), Color.FromArgb(255, 113, 113, 113), Color.FromArgb(255, 99, 99, 99), Color.FromArgb(255, 56, 71, 81), Color.FromArgb(255, 67, 50, 31), Color.FromArgb(255, 91, 91, 91), Color.FromArgb(255, 122, 150, 158), Color.FromArgb(255, 62, 79, 90), Color.FromArgb(255, 83, 85, 88), Color.FromArgb(255, 114, 114, 115), Color.FromArgb(255, 75, 64, 64), Color.FromArgb(255, 45, 51, 63), Color.FromArgb(255, 95, 96, 50),  },
            new Color[16]{ Color.FromArgb(255, 149, 134, 134), Color.FromArgb(255, 74, 81, 86), Color.FromArgb(255, 232, 248, 248), Color.FromArgb(148, 199, 218, 244), Color.FromArgb(255, 108, 101, 91), Color.FromArgb(255, 86, 86, 85), Color.FromArgb(255, 98, 99, 105), Color.FromArgb(255, 117, 117, 121), Color.FromArgb(255, 62, 57, 36), Color.FromArgb(255, 121, 98, 83), Color.FromArgb(255, 122, 75, 51), Color.FromArgb(255, 114, 54, 41), Color.FromArgb(255, 151, 151, 132), Color.FromArgb(255, 104, 105, 110), Color.FromArgb(255, 130, 129, 129), Color.FromArgb(255, 91, 61, 42),  },
            new Color[16]{ Color.FromArgb(255, 83, 78, 48), Color.FromArgb(255, 99, 111, 127), Color.FromArgb(255, 88, 102, 112), Color.FromArgb(255, 140, 140, 140), Color.FromArgb(255, 57, 56, 49), Color.FromArgb(255, 34, 180, 243), Color.FromArgb(255, 75, 53, 52), Color.FromArgb(255, 103, 75, 74), Color.FromArgb(255, 83, 152, 67), Color.FromArgb(255, 83, 153, 67), Color.FromArgb(255, 84, 153, 67), Color.FromArgb(255, 87, 158, 70), Color.FromArgb(255, 83, 151, 66), Color.FromArgb(255, 95, 150, 57), Color.FromArgb(255, 92, 140, 48), Color.FromArgb(255, 106, 131, 36),  },
            new Color[16]{ Color.FromArgb(255, 59, 66, 73), Color.FromArgb(255, 96, 107, 123), Color.FromArgb(255, 87, 102, 112), Color.FromArgb(255, 81, 44, 36), Color.FromArgb(255, 71, 84, 87), Color.FromArgb(255, 106, 86, 86), Color.FromArgb(255, 89, 91, 98), Color.FromArgb(255, 97, 72, 71), Color.FromArgb(255, 37, 93, 117), Color.FromArgb(255, 82, 85, 87), Color.FromArgb(255, 100, 93, 51), Color.FromArgb(255, 42, 54, 56), Color.FromArgb(255, 40, 51, 54), Color.FromArgb(255, 40, 51, 54), Color.FromArgb(255, 37, 49, 51), Color.FromArgb(255, 102, 102, 102),  },
            new Color[16]{ Color.FromArgb(255, 107, 109, 113), Color.FromArgb(255, 124, 131, 146), Color.FromArgb(255, 114, 106, 121), Color.FromArgb(255, 57, 37, 37), Color.FromArgb(255, 73, 67, 63), Color.FromArgb(255, 181, 186, 180), Color.FromArgb(255, 75, 75, 82), Color.FromArgb(255, 52, 52, 55), Color.FromArgb(255, 85, 83, 82), Color.FromArgb(255, 149, 57, 49), Color.FromArgb(255, 112, 42, 43), Color.FromArgb(255, 126, 72, 67), Color.FromArgb(255, 118, 28, 20), Color.FromArgb(255, 42, 47, 54), Color.FromArgb(255, 94, 95, 89), Color.FromArgb(255, 103, 103, 103),  },
            new Color[16]{ Color.FromArgb(255, 111, 112, 116), Color.FromArgb(255, 63, 87, 98), Color.FromArgb(255, 20, 81, 97), Color.FromArgb(255, 150, 146, 146), Color.FromArgb(255, 109, 109, 109), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 48, 103, 187), Color.FromArgb(255, 126, 156, 195), Color.FromArgb(255, 240, 192, 41), Color.FromArgb(255, 240, 196, 48), Color.FromArgb(255, 102, 113, 133), Color.FromArgb(255, 116, 81, 94), Color.FromArgb(255, 53, 64, 78), Color.FromArgb(255, 41, 43, 44), Color.FromArgb(255, 101, 96, 86), Color.FromArgb(255, 152, 152, 152),  },
            new Color[16]{ Color.FromArgb(255, 108, 115, 134), Color.FromArgb(255, 68, 84, 103), Color.FromArgb(255, 172, 165, 144), Color.FromArgb(255, 158, 149, 148), Color.FromArgb(255, 70, 88, 92), Color.FromArgb(255, 45, 78, 129), Color.FromArgb(255, 45, 79, 132), Color.FromArgb(255, 95, 115, 141), Color.FromArgb(255, 139, 144, 143), Color.FromArgb(255, 147, 123, 80), Color.FromArgb(255, 72, 77, 94), Color.FromArgb(255, 71, 79, 96), Color.FromArgb(255, 50, 50, 49), Color.FromArgb(255, 100, 114, 116), Color.FromArgb(255, 72, 39, 4), Color.FromArgb(255, 116, 69, 8),  },
            new Color[16]{ Color.FromArgb(255, 60, 60, 60), Color.FromArgb(255, 37, 86, 103), Color.FromArgb(255, 73, 86, 90), Color.FromArgb(255, 102, 103, 105), Color.FromArgb(255, 185, 188, 188), Color.FromArgb(255, 140, 147, 147), Color.FromArgb(255, 44, 140, 170), Color.FromArgb(255, 93, 183, 168), Color.FromArgb(255, 62, 74, 78), Color.FromArgb(255, 58, 69, 74), Color.FromArgb(255, 55, 65, 69), Color.FromArgb(255, 176, 170, 160), Color.FromArgb(255, 60, 68, 87), Color.FromArgb(166, 172, 179, 199), Color.FromArgb(255, 137, 88, 5), Color.FromArgb(255, 134, 57, 42),  },
            new Color[16]{ Color.FromArgb(255, 128, 137, 160), Color.FromArgb(255, 77, 81, 87), Color.FromArgb(255, 168, 160, 147), Color.FromArgb(255, 92, 108, 108), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 41, 116, 131), Color.FromArgb(255, 10, 41, 52), Color.FromArgb(255, 137, 125, 126), Color.FromArgb(255, 67, 86, 96), Color.FromArgb(255, 68, 73, 97), Color.FromArgb(255, 153, 148, 148), Color.FromArgb(255, 160, 150, 149), Color.FromArgb(255, 96, 98, 105), Color.FromArgb(255, 92, 109, 117), Color.FromArgb(255, 117, 93, 92),  },
            new Color[16]{ Color.FromArgb(255, 126, 135, 158), Color.FromArgb(255, 181, 151, 153), Color.FromArgb(255, 141, 145, 158), Color.FromArgb(255, 96, 103, 120), Color.FromArgb(255, 145, 145, 145), Color.FromArgb(255, 110, 110, 110), Color.FromArgb(255, 89, 104, 119), Color.FromArgb(255, 69, 82, 86), Color.FromArgb(255, 78, 145, 62), Color.FromArgb(255, 78, 145, 62), Color.FromArgb(255, 81, 149, 65), Color.FromArgb(255, 93, 146, 60), Color.FromArgb(238, 116, 113, 66), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 100, 106, 124), Color.FromArgb(255, 128, 137, 160), Color.FromArgb(255, 43, 43, 43), Color.FromArgb(255, 97, 98, 102), Color.FromArgb(255, 118, 121, 132), Color.FromArgb(255, 71, 78, 80), Color.FromArgb(255, 57, 66, 70), Color.FromArgb(255, 41, 41, 41), Color.FromArgb(255, 40, 40, 40), Color.FromArgb(255, 66, 80, 98), Color.FromArgb(255, 43, 52, 64), Color.FromArgb(255, 69, 85, 105), Color.FromArgb(255, 53, 63, 81), Color.FromArgb(255, 90, 121, 137), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 173, 165, 152), Color.FromArgb(255, 80, 81, 82), Color.FromArgb(255, 191, 108, 17), Color.FromArgb(255, 182, 103, 17), Color.FromArgb(255, 179, 101, 16), Color.FromArgb(255, 146, 153, 174), Color.FromArgb(255, 104, 111, 130), Color.FromArgb(255, 41, 41, 41), Color.FromArgb(255, 38, 38, 38), Color.FromArgb(255, 67, 82, 100), Color.FromArgb(255, 68, 83, 103), Color.FromArgb(255, 69, 85, 105), Color.FromArgb(255, 43, 55, 70), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 20, 20, 20), Color.FromArgb(255, 22, 22, 22), Color.FromArgb(255, 23, 23, 23), Color.FromArgb(255, 26, 26, 26), Color.FromArgb(255, 26, 26, 26), Color.FromArgb(255, 28, 28, 28), Color.FromArgb(255, 28, 28, 28), Color.FromArgb(255, 28, 28, 28), Color.FromArgb(255, 28, 28, 28), Color.FromArgb(255, 31, 31, 31), Color.FromArgb(255, 78, 124, 45), Color.FromArgb(255, 52, 63, 78), Color.FromArgb(255, 53, 69, 87), Color.FromArgb(255, 170, 150, 25), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 41, 41, 41), Color.FromArgb(255, 150, 160, 182), Color.FromArgb(255, 122, 75, 51), Color.FromArgb(255, 89, 104, 128), Color.FromArgb(255, 89, 104, 128), Color.FromArgb(255, 159, 140, 122), Color.FromArgb(255, 166, 145, 125), Color.FromArgb(255, 92, 63, 47), Color.FromArgb(255, 113, 78, 58), Color.FromArgb(255, 78, 145, 62), Color.FromArgb(255, 78, 145, 62), Color.FromArgb(255, 81, 149, 65), Color.FromArgb(255, 94, 155, 67), Color.FromArgb(255, 204, 181, 127), Color.FromArgb(255, 154, 140, 96), Color.FromArgb(255, 144, 109, 85),  },
            new Color[16]{ Color.FromArgb(255, 42, 45, 51), Color.FromArgb(255, 53, 85, 162), Color.FromArgb(255, 93, 72, 65), Color.FromArgb(255, 71, 134, 162), Color.FromArgb(255, 95, 98, 107), Color.FromArgb(255, 81, 109, 57), Color.FromArgb(255, 123, 152, 190), Color.FromArgb(255, 113, 167, 52), Color.FromArgb(255, 174, 120, 181), Color.FromArgb(255, 174, 132, 68), Color.FromArgb(255, 183, 149, 177), Color.FromArgb(255, 144, 91, 178), Color.FromArgb(255, 160, 65, 73), Color.FromArgb(255, 157, 161, 171), Color.FromArgb(255, 190, 192, 199), Color.FromArgb(255, 180, 183, 68),  },
            new Color[16]{ Color.FromArgb(255, 53, 63, 66), Color.FromArgb(255, 63, 96, 156), Color.FromArgb(255, 95, 86, 77), Color.FromArgb(255, 77, 135, 156), Color.FromArgb(255, 96, 107, 110), Color.FromArgb(255, 85, 115, 71), Color.FromArgb(255, 117, 151, 183), Color.FromArgb(255, 110, 164, 67), Color.FromArgb(255, 165, 124, 175), Color.FromArgb(255, 165, 133, 81), Color.FromArgb(255, 173, 148, 169), Color.FromArgb(255, 136, 100, 171), Color.FromArgb(255, 150, 81, 84), Color.FromArgb(255, 148, 158, 165), Color.FromArgb(255, 182, 192, 194), Color.FromArgb(255, 170, 180, 81),  },
            new Color[16]{ Color.FromArgb(255, 34, 42, 45), Color.FromArgb(255, 42, 73, 133), Color.FromArgb(255, 72, 64, 55), Color.FromArgb(255, 55, 112, 133), Color.FromArgb(255, 73, 83, 86), Color.FromArgb(255, 62, 91, 49), Color.FromArgb(255, 93, 128, 162), Color.FromArgb(255, 87, 143, 45), Color.FromArgb(255, 144, 100, 153), Color.FromArgb(255, 144, 110, 58), Color.FromArgb(255, 153, 125, 148), Color.FromArgb(255, 113, 77, 149), Color.FromArgb(255, 128, 59, 61), Color.FromArgb(255, 126, 136, 143), Color.FromArgb(255, 162, 172, 174), Color.FromArgb(255, 150, 160, 58),  },
            new Color[16]{ Color.FromArgb(255, 86, 86, 86), Color.FromArgb(255, 165, 165, 165), Color.FromArgb(255, 51, 95, 65), Color.FromArgb(255, 111, 111, 71), Color.FromArgb(255, 96, 68, 39), Color.FromArgb(255, 139, 146, 79), Color.FromArgb(255, 83, 76, 24), Color.FromArgb(255, 168, 103, 63), Color.FromArgb(255, 76, 72, 67), Color.FromArgb(255, 116, 80, 33), Color.FromArgb(255, 134, 134, 152), Color.FromArgb(255, 125, 125, 125), Color.FromArgb(255, 97, 97, 97), Color.FromArgb(255, 163, 142, 88), Color.FromArgb(255, 135, 104, 83), Color.FromArgb(255, 133, 103, 82),  },
            new Color[16]{ Color.FromArgb(255, 97, 97, 97), Color.FromArgb(255, 153, 153, 153), Color.FromArgb(255, 45, 88, 60), Color.FromArgb(255, 102, 105, 68), Color.FromArgb(255, 93, 66, 38), Color.FromArgb(255, 95, 149, 114), Color.FromArgb(255, 77, 75, 17), Color.FromArgb(255, 136, 76, 49), Color.FromArgb(255, 53, 27, 16), Color.FromArgb(255, 83, 47, 29), Color.FromArgb(255, 49, 56, 60), Color.FromArgb(255, 113, 113, 113), Color.FromArgb(255, 99, 99, 99), Color.FromArgb(255, 150, 135, 94), Color.FromArgb(255, 97, 70, 52), Color.FromArgb(255, 128, 98, 78),  },
            new Color[16]{ Color.FromArgb(255, 32, 102, 43), Color.FromArgb(255, 56, 116, 73), Color.FromArgb(255, 102, 134, 94), Color.FromArgb(255, 109, 123, 44), Color.FromArgb(255, 116, 123, 63), Color.FromArgb(255, 100, 112, 45), Color.FromArgb(255, 98, 85, 48), Color.FromArgb(255, 128, 97, 29), Color.FromArgb(255, 75, 63, 53), Color.FromArgb(255, 75, 66, 51), Color.FromArgb(255, 71, 68, 41), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 92, 100, 64), Color.FromArgb(255, 125, 95, 76), Color.FromArgb(255, 126, 96, 76),  },
            new Color[16]{ Color.FromArgb(255, 132, 143, 172), Color.FromArgb(255, 164, 169, 172), Color.FromArgb(255, 76, 96, 111), Color.FromArgb(255, 126, 126, 126), Color.FromArgb(255, 47, 54, 55), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 211, 25, 26), Color.FromArgb(255, 188, 206, 234), Color.FromArgb(255, 120, 91, 58), Color.FromArgb(255, 34, 49, 57), Color.FromArgb(255, 109, 110, 107),  },
            new Color[16]{ Color.FromArgb(255, 125, 137, 165), Color.FromArgb(255, 158, 161, 164), Color.FromArgb(255, 84, 104, 121), Color.FromArgb(255, 125, 125, 126), Color.FromArgb(255, 46, 54, 58), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Natural = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 107, 107, 107), Color.FromArgb(255, 128, 118, 104), Color.FromArgb(255, 125, 93, 64), Color.FromArgb(255, 110, 89, 55), Color.FromArgb(255, 165, 120, 76), Color.FromArgb(255, 123, 115, 105), Color.FromArgb(255, 134, 127, 117), Color.FromArgb(255, 136, 90, 77), Color.FromArgb(255, 145, 54, 39), Color.FromArgb(255, 148, 82, 64), Color.FromArgb(255, 106, 57, 46), Color.FromArgb(255, 152, 152, 152), Color.FromArgb(255, 153, 81, 39), Color.FromArgb(255, 177, 179, 41), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 80, 98, 42),  },
            new Color[16]{ Color.FromArgb(255, 129, 127, 112), Color.FromArgb(255, 79, 79, 78), Color.FromArgb(255, 202, 180, 147), Color.FromArgb(255, 116, 117, 118), Color.FromArgb(255, 105, 86, 55), Color.FromArgb(255, 157, 125, 89), Color.FromArgb(255, 126, 126, 126), Color.FromArgb(255, 177, 137, 30), Color.FromArgb(255, 78, 157, 171), Color.FromArgb(255, 41, 189, 94), Color.FromArgb(255, 180, 44, 35), Color.FromArgb(255, 85, 82, 82), Color.FromArgb(255, 207, 112, 83), Color.FromArgb(255, 144, 108, 85), Color.FromArgb(255, 77, 105, 20), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 147, 132, 90), Color.FromArgb(255, 129, 113, 97), Color.FromArgb(255, 96, 89, 78), Color.FromArgb(255, 87, 72, 54), Color.FromArgb(255, 117, 120, 85), Color.FromArgb(255, 40, 27, 49), Color.FromArgb(255, 75, 75, 75), Color.FromArgb(255, 109, 109, 109), Color.FromArgb(255, 82, 79, 79), Color.FromArgb(255, 117, 150, 149), Color.FromArgb(255, 80, 77, 77), Color.FromArgb(255, 117, 105, 95), Color.FromArgb(255, 80, 78, 77), Color.FromArgb(255, 107, 105, 105), Color.FromArgb(255, 84, 81, 81), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 194, 162, 35), Color.FromArgb(255, 221, 223, 223), Color.FromArgb(255, 106, 129, 121), Color.FromArgb(255, 127, 83, 73), Color.FromArgb(255, 118, 118, 118), Color.FromArgb(255, 104, 104, 104), Color.FromArgb(255, 121, 112, 102), Color.FromArgb(255, 70, 53, 40), Color.FromArgb(255, 124, 124, 124), Color.FromArgb(255, 124, 101, 46), Color.FromArgb(255, 81, 61, 37), Color.FromArgb(255, 101, 93, 91), Color.FromArgb(255, 101, 95, 95), Color.FromArgb(255, 102, 91, 81), Color.FromArgb(255, 88, 86, 85), Color.FromArgb(255, 66, 80, 31),  },
            new Color[16]{ Color.FromArgb(255, 231, 233, 233), Color.FromArgb(255, 105, 77, 61), Color.FromArgb(255, 220, 224, 230), Color.FromArgb(197, 112, 148, 239), Color.FromArgb(255, 155, 137, 121), Color.FromArgb(255, 79, 91, 45), Color.FromArgb(255, 83, 91, 45), Color.FromArgb(255, 127, 144, 50), Color.FromArgb(255, 163, 172, 191), Color.FromArgb(255, 117, 109, 38), Color.FromArgb(255, 80, 78, 79), Color.FromArgb(255, 94, 93, 92), Color.FromArgb(255, 74, 129, 78), Color.FromArgb(255, 114, 85, 70), Color.FromArgb(255, 117, 86, 95), Color.FromArgb(255, 85, 112, 39),  },
            new Color[16]{ Color.FromArgb(255, 123, 91, 50), Color.FromArgb(255, 150, 99, 62), Color.FromArgb(255, 181, 184, 189), Color.FromArgb(255, 96, 71, 41), Color.FromArgb(255, 157, 107, 68), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 86, 62, 38), Color.FromArgb(255, 128, 99, 72), Color.FromArgb(255, 32, 143, 47), Color.FromArgb(255, 44, 131, 42), Color.FromArgb(255, 87, 116, 29), Color.FromArgb(255, 89, 102, 27), Color.FromArgb(255, 87, 88, 26), Color.FromArgb(255, 87, 89, 26), Color.FromArgb(255, 84, 79, 25), Color.FromArgb(255, 97, 86, 39),  },
            new Color[16]{ Color.FromArgb(255, 117, 94, 62), Color.FromArgb(255, 142, 96, 62), Color.FromArgb(255, 148, 151, 153), Color.FromArgb(255, 147, 69, 67), Color.FromArgb(255, 112, 109, 78), Color.FromArgb(255, 115, 107, 96), Color.FromArgb(255, 131, 62, 19), Color.FromArgb(255, 69, 18, 20), Color.FromArgb(255, 84, 65, 54), Color.FromArgb(255, 157, 117, 58), Color.FromArgb(255, 104, 85, 35), Color.FromArgb(255, 122, 79, 57), Color.FromArgb(255, 84, 77, 75), Color.FromArgb(255, 85, 83, 82), Color.FromArgb(255, 74, 71, 71), Color.FromArgb(255, 131, 131, 131),  },
            new Color[16]{ Color.FromArgb(255, 88, 67, 59), Color.FromArgb(255, 50, 50, 50), Color.FromArgb(255, 114, 114, 114), Color.FromArgb(255, 101, 73, 69), Color.FromArgb(255, 67, 51, 29), Color.FromArgb(255, 169, 167, 163), Color.FromArgb(255, 145, 75, 22), Color.FromArgb(255, 123, 65, 21), Color.FromArgb(255, 162, 93, 36), Color.FromArgb(255, 231, 201, 201), Color.FromArgb(255, 208, 174, 145), Color.FromArgb(255, 152, 123, 103), Color.FromArgb(255, 173, 113, 71), Color.FromArgb(255, 178, 54, 47), Color.FromArgb(255, 135, 98, 75), Color.FromArgb(255, 125, 125, 125),  },
            new Color[16]{ Color.FromArgb(255, 95, 73, 64), Color.FromArgb(255, 172, 52, 50), Color.FromArgb(255, 190, 118, 143), Color.FromArgb(255, 126, 123, 126), Color.FromArgb(255, 112, 112, 112), Color.FromArgb(255, 100, 100, 100), Color.FromArgb(255, 137, 56, 64), Color.FromArgb(255, 178, 139, 143), Color.FromArgb(255, 85, 128, 54), Color.FromArgb(255, 79, 121, 52), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 33, 33, 33), Color.FromArgb(255, 164, 128, 25), Color.FromArgb(255, 177, 148, 102), Color.FromArgb(255, 165, 145, 110), Color.FromArgb(255, 118, 118, 118),  },
            new Color[16]{ Color.FromArgb(255, 48, 92, 235), Color.FromArgb(255, 76, 98, 54), Color.FromArgb(255, 83, 181, 63), Color.FromArgb(255, 136, 122, 125), Color.FromArgb(255, 204, 204, 204), Color.FromArgb(255, 108, 60, 55), Color.FromArgb(255, 106, 57, 54), Color.FromArgb(255, 133, 106, 100), Color.FromArgb(255, 158, 151, 141), Color.FromArgb(255, 135, 124, 110), Color.FromArgb(255, 78, 78, 78), Color.FromArgb(255, 50, 50, 50), Color.FromArgb(255, 133, 133, 137), Color.FromArgb(255, 162, 127, 103), Color.FromArgb(255, 65, 97, 70), Color.FromArgb(255, 132, 151, 126),  },
            new Color[16]{ Color.FromArgb(255, 87, 99, 110), Color.FromArgb(255, 105, 74, 57), Color.FromArgb(255, 188, 180, 34), Color.FromArgb(255, 110, 83, 67), Color.FromArgb(255, 216, 216, 216), Color.FromArgb(255, 201, 201, 201), Color.FromArgb(255, 113, 35, 32), Color.FromArgb(255, 36, 31, 37), Color.FromArgb(255, 153, 85, 19), Color.FromArgb(255, 158, 106, 19), Color.FromArgb(255, 126, 119, 17), Color.FromArgb(255, 84, 127, 68), Color.FromArgb(255, 129, 112, 102), Color.FromArgb(255, 157, 157, 157), Color.FromArgb(255, 117, 144, 109), Color.FromArgb(255, 198, 199, 180),  },
            new Color[16]{ Color.FromArgb(255, 192, 182, 164), Color.FromArgb(255, 58, 66, 163), Color.FromArgb(255, 75, 130, 209), Color.FromArgb(255, 120, 80, 64), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 82, 45, 52), Color.FromArgb(255, 40, 27, 49), Color.FromArgb(255, 130, 132, 133), Color.FromArgb(255, 126, 80, 60), Color.FromArgb(255, 117, 45, 32), Color.FromArgb(255, 124, 121, 124), Color.FromArgb(255, 137, 121, 124), Color.FromArgb(255, 99, 79, 73), Color.FromArgb(255, 110, 76, 70), Color.FromArgb(255, 81, 52, 56),  },
            new Color[16]{ Color.FromArgb(255, 169, 157, 138), Color.FromArgb(255, 127, 59, 181), Color.FromArgb(255, 184, 81, 191), Color.FromArgb(255, 99, 77, 70), Color.FromArgb(255, 90, 90, 90), Color.FromArgb(255, 84, 84, 84), Color.FromArgb(255, 106, 82, 55), Color.FromArgb(255, 143, 99, 77), Color.FromArgb(255, 20, 148, 20), Color.FromArgb(255, 20, 172, 20), Color.FromArgb(255, 20, 167, 20), Color.FromArgb(255, 67, 153, 19), Color.FromArgb(163, 107, 147, 70), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 187, 173, 148), Color.FromArgb(255, 50, 136, 174), Color.FromArgb(255, 196, 111, 43), Color.FromArgb(255, 56, 40, 33), Color.FromArgb(255, 173, 134, 70), Color.FromArgb(255, 135, 127, 115), Color.FromArgb(255, 188, 155, 99), Color.FromArgb(255, 53, 55, 59), Color.FromArgb(255, 61, 63, 67), Color.FromArgb(255, 217, 209, 195), Color.FromArgb(255, 217, 208, 193), Color.FromArgb(255, 225, 216, 200), Color.FromArgb(255, 72, 72, 72), Color.FromArgb(255, 115, 71, 64), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 57, 33, 29), Color.FromArgb(255, 180, 186, 186), Color.FromArgb(255, 117, 8, 30), Color.FromArgb(255, 101, 9, 30), Color.FromArgb(255, 91, 10, 30), Color.FromArgb(255, 182, 172, 155), Color.FromArgb(255, 187, 177, 159), Color.FromArgb(255, 61, 63, 67), Color.FromArgb(255, 62, 63, 67), Color.FromArgb(255, 221, 213, 199), Color.FromArgb(255, 215, 207, 193), Color.FromArgb(255, 225, 216, 200), Color.FromArgb(255, 60, 60, 60), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 94, 94, 94), Color.FromArgb(255, 94, 94, 94), Color.FromArgb(255, 93, 93, 93), Color.FromArgb(255, 92, 92, 92), Color.FromArgb(255, 92, 92, 92), Color.FromArgb(255, 92, 92, 92), Color.FromArgb(255, 92, 92, 92), Color.FromArgb(255, 92, 92, 92), Color.FromArgb(255, 92, 92, 92), Color.FromArgb(255, 92, 92, 92), Color.FromArgb(255, 141, 120, 52), Color.FromArgb(255, 225, 217, 201), Color.FromArgb(255, 70, 70, 70), Color.FromArgb(255, 164, 138, 52), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 28, 29, 31), Color.FromArgb(255, 146, 130, 111), Color.FromArgb(255, 80, 78, 79), Color.FromArgb(255, 101, 99, 107), Color.FromArgb(255, 118, 117, 124), Color.FromArgb(255, 197, 197, 199), Color.FromArgb(255, 187, 187, 187), Color.FromArgb(255, 154, 107, 90), Color.FromArgb(255, 188, 116, 88), Color.FromArgb(255, 20, 148, 20), Color.FromArgb(255, 20, 172, 20), Color.FromArgb(255, 20, 167, 20), Color.FromArgb(255, 38, 130, 21), Color.FromArgb(255, 141, 122, 101), Color.FromArgb(255, 137, 137, 121), Color.FromArgb(255, 180, 161, 135),  },
            new Color[16]{ Color.FromArgb(255, 62, 54, 45), Color.FromArgb(255, 75, 92, 148), Color.FromArgb(255, 114, 81, 57), Color.FromArgb(255, 92, 138, 148), Color.FromArgb(255, 115, 106, 94), Color.FromArgb(255, 101, 115, 50), Color.FromArgb(255, 141, 157, 179), Color.FromArgb(255, 132, 171, 46), Color.FromArgb(255, 191, 125, 170), Color.FromArgb(255, 191, 136, 61), Color.FromArgb(255, 199, 153, 164), Color.FromArgb(255, 161, 98, 166), Color.FromArgb(255, 175, 75, 65), Color.FromArgb(255, 173, 165, 158), Color.FromArgb(255, 208, 200, 192), Color.FromArgb(255, 197, 189, 61),  },
            new Color[16]{ Color.FromArgb(255, 138, 140, 140), Color.FromArgb(255, 146, 164, 204), Color.FromArgb(255, 169, 157, 148), Color.FromArgb(255, 156, 191, 204), Color.FromArgb(255, 170, 172, 172), Color.FromArgb(255, 162, 177, 144), Color.FromArgb(255, 184, 203, 226), Color.FromArgb(255, 179, 213, 140), Color.FromArgb(255, 220, 183, 219), Color.FromArgb(255, 220, 190, 151), Color.FromArgb(255, 227, 201, 215), Color.FromArgb(255, 198, 167, 216), Color.FromArgb(255, 208, 153, 153), Color.FromArgb(255, 206, 208, 211), Color.FromArgb(255, 234, 236, 236), Color.FromArgb(255, 224, 226, 151),  },
            new Color[16]{ Color.FromArgb(255, 128, 128, 128), Color.FromArgb(255, 136, 152, 192), Color.FromArgb(255, 159, 146, 137), Color.FromArgb(255, 146, 179, 193), Color.FromArgb(255, 160, 160, 160), Color.FromArgb(255, 152, 165, 132), Color.FromArgb(255, 174, 191, 215), Color.FromArgb(255, 170, 202, 129), Color.FromArgb(255, 210, 171, 208), Color.FromArgb(255, 210, 178, 139), Color.FromArgb(255, 217, 189, 204), Color.FromArgb(255, 188, 156, 205), Color.FromArgb(255, 198, 142, 142), Color.FromArgb(255, 197, 197, 200), Color.FromArgb(255, 224, 224, 224), Color.FromArgb(255, 215, 215, 139),  },
            new Color[16]{ Color.FromArgb(255, 121, 121, 121), Color.FromArgb(255, 132, 132, 117), Color.FromArgb(255, 91, 85, 65), Color.FromArgb(255, 111, 58, 48), Color.FromArgb(255, 96, 88, 91), Color.FromArgb(255, 103, 92, 44), Color.FromArgb(255, 47, 78, 42), Color.FromArgb(255, 154, 128, 30), Color.FromArgb(255, 101, 63, 48), Color.FromArgb(255, 125, 86, 50), Color.FromArgb(255, 137, 82, 51), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 90, 90, 90), Color.FromArgb(255, 44, 125, 117), Color.FromArgb(255, 160, 84, 69), Color.FromArgb(255, 162, 84, 67),  },
            new Color[16]{ Color.FromArgb(255, 120, 120, 120), Color.FromArgb(255, 110, 110, 105), Color.FromArgb(255, 77, 81, 47), Color.FromArgb(255, 87, 61, 43), Color.FromArgb(255, 79, 77, 67), Color.FromArgb(255, 109, 94, 62), Color.FromArgb(255, 47, 78, 42), Color.FromArgb(255, 92, 93, 32), Color.FromArgb(255, 47, 33, 27), Color.FromArgb(255, 79, 58, 44), Color.FromArgb(255, 41, 28, 17), Color.FromArgb(255, 118, 118, 118), Color.FromArgb(255, 104, 104, 104), Color.FromArgb(255, 31, 85, 83), Color.FromArgb(255, 129, 64, 49), Color.FromArgb(255, 146, 72, 57),  },
            new Color[16]{ Color.FromArgb(255, 129, 99, 146), Color.FromArgb(255, 59, 108, 188), Color.FromArgb(255, 116, 143, 128), Color.FromArgb(255, 167, 161, 112), Color.FromArgb(255, 92, 81, 38), Color.FromArgb(255, 120, 134, 111), Color.FromArgb(255, 96, 111, 69), Color.FromArgb(255, 61, 84, 45), Color.FromArgb(255, 111, 79, 50), Color.FromArgb(255, 108, 77, 49), Color.FromArgb(255, 93, 61, 34), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 27, 94, 97), Color.FromArgb(255, 147, 74, 59), Color.FromArgb(255, 158, 81, 65),  },
            new Color[16]{ Color.FromArgb(255, 129, 76, 48), Color.FromArgb(255, 168, 135, 82), Color.FromArgb(255, 52, 37, 15), Color.FromArgb(255, 165, 105, 76), Color.FromArgb(255, 97, 66, 36), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 213, 21, 21), Color.FromArgb(255, 168, 208, 248), Color.FromArgb(255, 127, 162, 160), Color.FromArgb(255, 50, 64, 63), Color.FromArgb(255, 105, 67, 59),  },
            new Color[16]{ Color.FromArgb(255, 123, 70, 42), Color.FromArgb(255, 168, 135, 81), Color.FromArgb(255, 53, 38, 16), Color.FromArgb(255, 162, 102, 75), Color.FromArgb(255, 98, 67, 37), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Pattern = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 210, 210, 210), Color.FromArgb(255, 110, 124, 178), Color.FromArgb(255, 97, 59, 43), Color.FromArgb(255, 92, 96, 38), Color.FromArgb(255, 205, 137, 114), Color.FromArgb(255, 114, 128, 180), Color.FromArgb(255, 115, 128, 179), Color.FromArgb(255, 160, 104, 84), Color.FromArgb(255, 194, 125, 151), Color.FromArgb(255, 180, 129, 169), Color.FromArgb(255, 140, 90, 132), Color.FromArgb(255, 190, 255, 255), Color.FromArgb(255, 208, 81, 118), Color.FromArgb(255, 214, 171, 65), Color.FromArgb(255, 0, 42, 255), Color.FromArgb(255, 71, 144, 109),  },
            new Color[16]{ Color.FromArgb(255, 134, 147, 196), Color.FromArgb(255, 56, 61, 72), Color.FromArgb(255, 243, 188, 128), Color.FromArgb(255, 85, 96, 127), Color.FromArgb(255, 110, 125, 129), Color.FromArgb(255, 211, 135, 110), Color.FromArgb(255, 189, 202, 205), Color.FromArgb(255, 255, 202, 23), Color.FromArgb(255, 82, 210, 246), Color.FromArgb(255, 69, 198, 41), Color.FromArgb(255, 201, 22, 57), Color.FromArgb(255, 102, 109, 130), Color.FromArgb(255, 211, 140, 141), Color.FromArgb(255, 171, 120, 104), Color.FromArgb(255, 114, 134, 105), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 133, 138, 153), Color.FromArgb(255, 115, 126, 169), Color.FromArgb(255, 92, 103, 148), Color.FromArgb(255, 166, 116, 112), Color.FromArgb(255, 122, 170, 211), Color.FromArgb(255, 60, 41, 99), Color.FromArgb(255, 195, 195, 195), Color.FromArgb(255, 162, 162, 162), Color.FromArgb(255, 102, 105, 127), Color.FromArgb(255, 250, 227, 99), Color.FromArgb(255, 95, 106, 128), Color.FromArgb(255, 175, 114, 129), Color.FromArgb(255, 88, 103, 133), Color.FromArgb(255, 101, 118, 148), Color.FromArgb(255, 98, 108, 130), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 164, 223, 210), Color.FromArgb(255, 119, 131, 119), Color.FromArgb(255, 113, 143, 191), Color.FromArgb(255, 136, 105, 156), Color.FromArgb(255, 212, 212, 212), Color.FromArgb(255, 162, 162, 162), Color.FromArgb(255, 108, 119, 166), Color.FromArgb(255, 63, 58, 56), Color.FromArgb(255, 210, 210, 210), Color.FromArgb(255, 183, 176, 143), Color.FromArgb(255, 154, 80, 147), Color.FromArgb(255, 188, 133, 131), Color.FromArgb(255, 190, 152, 130), Color.FromArgb(255, 128, 115, 117), Color.FromArgb(255, 104, 116, 148), Color.FromArgb(255, 42, 104, 104),  },
            new Color[16]{ Color.FromArgb(255, 222, 213, 204), Color.FromArgb(255, 59, 136, 146), Color.FromArgb(255, 227, 242, 255), Color.FromArgb(163, 93, 198, 242), Color.FromArgb(255, 136, 118, 113), Color.FromArgb(255, 113, 164, 46), Color.FromArgb(255, 89, 153, 40), Color.FromArgb(255, 154, 185, 76), Color.FromArgb(255, 176, 148, 139), Color.FromArgb(255, 158, 215, 130), Color.FromArgb(255, 202, 127, 115), Color.FromArgb(255, 157, 158, 164), Color.FromArgb(255, 181, 203, 218), Color.FromArgb(255, 103, 70, 73), Color.FromArgb(255, 108, 80, 103), Color.FromArgb(255, 143, 148, 91),  },
            new Color[16]{ Color.FromArgb(255, 224, 149, 119), Color.FromArgb(255, 181, 139, 139), Color.FromArgb(255, 94, 106, 137), Color.FromArgb(255, 184, 126, 128), Color.FromArgb(255, 199, 142, 145), Color.FromArgb(255, 135, 134, 156), Color.FromArgb(255, 108, 63, 45), Color.FromArgb(255, 119, 71, 51), Color.FromArgb(255, 81, 158, 68), Color.FromArgb(255, 90, 177, 74), Color.FromArgb(255, 120, 181, 69), Color.FromArgb(255, 137, 186, 62), Color.FromArgb(255, 131, 187, 57), Color.FromArgb(255, 153, 195, 71), Color.FromArgb(255, 189, 190, 70), Color.FromArgb(255, 228, 190, 149),  },
            new Color[16]{ Color.FromArgb(255, 165, 139, 128), Color.FromArgb(255, 204, 139, 120), Color.FromArgb(255, 91, 103, 134), Color.FromArgb(255, 222, 81, 99), Color.FromArgb(255, 92, 145, 182), Color.FromArgb(255, 99, 110, 155), Color.FromArgb(255, 202, 140, 78), Color.FromArgb(255, 50, 14, 32), Color.FromArgb(255, 102, 95, 126), Color.FromArgb(255, 0, 125, 125), Color.FromArgb(255, 131, 169, 170), Color.FromArgb(255, 184, 126, 127), Color.FromArgb(255, 110, 106, 128), Color.FromArgb(255, 88, 102, 130), Color.FromArgb(255, 96, 101, 125), Color.FromArgb(255, 158, 199, 211),  },
            new Color[16]{ Color.FromArgb(255, 145, 205, 225), Color.FromArgb(255, 27, 27, 27), Color.FromArgb(255, 64, 65, 66), Color.FromArgb(255, 146, 154, 145), Color.FromArgb(255, 72, 82, 116), Color.FromArgb(255, 232, 185, 124), Color.FromArgb(255, 239, 107, 56), Color.FromArgb(255, 221, 100, 53), Color.FromArgb(255, 241, 125, 64), Color.FromArgb(255, 240, 187, 240), Color.FromArgb(255, 211, 171, 145), Color.FromArgb(255, 237, 187, 167), Color.FromArgb(255, 189, 139, 100), Color.FromArgb(255, 234, 137, 159), Color.FromArgb(255, 202, 136, 118), Color.FromArgb(255, 161, 199, 211),  },
            new Color[16]{ Color.FromArgb(255, 144, 204, 223), Color.FromArgb(255, 206, 35, 40), Color.FromArgb(255, 255, 183, 215), Color.FromArgb(255, 123, 135, 175), Color.FromArgb(255, 181, 181, 181), Color.FromArgb(255, 147, 147, 147), Color.FromArgb(255, 182, 153, 165), Color.FromArgb(255, 200, 209, 211), Color.FromArgb(255, 88, 144, 79), Color.FromArgb(255, 84, 145, 76), Color.FromArgb(255, 128, 133, 146), Color.FromArgb(255, 68, 80, 120), Color.FromArgb(255, 120, 194, 180), Color.FromArgb(255, 170, 251, 174), Color.FromArgb(255, 82, 233, 186), Color.FromArgb(255, 131, 131, 131),  },
            new Color[16]{ Color.FromArgb(255, 30, 127, 231), Color.FromArgb(255, 39, 135, 36), Color.FromArgb(255, 101, 219, 85), Color.FromArgb(255, 132, 136, 175), Color.FromArgb(255, 117, 107, 88), Color.FromArgb(255, 205, 163, 162), Color.FromArgb(255, 210, 151, 163), Color.FromArgb(255, 217, 189, 187), Color.FromArgb(255, 225, 176, 153), Color.FromArgb(255, 162, 112, 92), Color.FromArgb(255, 132, 149, 148), Color.FromArgb(255, 82, 96, 137), Color.FromArgb(255, 220, 144, 143), Color.FromArgb(255, 158, 181, 152), Color.FromArgb(255, 156, 131, 161), Color.FromArgb(255, 153, 175, 173),  },
            new Color[16]{ Color.FromArgb(255, 92, 124, 190), Color.FromArgb(255, 108, 57, 49), Color.FromArgb(255, 253, 230, 106), Color.FromArgb(255, 144, 188, 198), Color.FromArgb(255, 237, 237, 237), Color.FromArgb(255, 233, 233, 233), Color.FromArgb(255, 96, 227, 180), Color.FromArgb(255, 71, 73, 200), Color.FromArgb(255, 181, 127, 105), Color.FromArgb(255, 101, 155, 122), Color.FromArgb(255, 143, 112, 135), Color.FromArgb(255, 107, 146, 156), Color.FromArgb(255, 158, 142, 179), Color.FromArgb(107, 206, 234, 191), Color.FromArgb(255, 92, 185, 191), Color.FromArgb(255, 104, 197, 207),  },
            new Color[16]{ Color.FromArgb(255, 244, 200, 146), Color.FromArgb(255, 59, 72, 212), Color.FromArgb(255, 84, 182, 251), Color.FromArgb(255, 166, 180, 191), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 165, 144, 124), Color.FromArgb(255, 202, 128, 112), Color.FromArgb(255, 194, 139, 126), Color.FromArgb(255, 174, 111, 97), Color.FromArgb(255, 189, 136, 158), Color.FromArgb(255, 122, 134, 173), Color.FromArgb(255, 134, 134, 172), Color.FromArgb(255, 131, 182, 204), Color.FromArgb(255, 161, 171, 194), Color.FromArgb(255, 56, 45, 57),  },
            new Color[16]{ Color.FromArgb(255, 245, 201, 147), Color.FromArgb(255, 131, 79, 183), Color.FromArgb(255, 243, 113, 207), Color.FromArgb(255, 126, 174, 208), Color.FromArgb(255, 180, 180, 180), Color.FromArgb(255, 153, 153, 153), Color.FromArgb(255, 91, 115, 159), Color.FromArgb(255, 152, 95, 86), Color.FromArgb(255, 102, 201, 50), Color.FromArgb(255, 104, 199, 55), Color.FromArgb(255, 123, 198, 62), Color.FromArgb(255, 130, 161, 76), Color.FromArgb(213, 70, 242, 234), Color.FromArgb(255, 41, 93, 253), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 246, 206, 155), Color.FromArgb(255, 44, 98, 121), Color.FromArgb(255, 220, 129, 69), Color.FromArgb(255, 79, 65, 81), Color.FromArgb(255, 183, 92, 99), Color.FromArgb(255, 106, 118, 164), Color.FromArgb(255, 216, 180, 114), Color.FromArgb(255, 84, 94, 126), Color.FromArgb(255, 88, 97, 131), Color.FromArgb(255, 173, 218, 207), Color.FromArgb(255, 174, 218, 208), Color.FromArgb(255, 188, 230, 221), Color.FromArgb(255, 80, 94, 130), Color.FromArgb(255, 178, 169, 193), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 73, 44, 86), Color.FromArgb(255, 131, 136, 136), Color.FromArgb(255, 133, 104, 122), Color.FromArgb(255, 148, 109, 125), Color.FromArgb(255, 162, 104, 120), Color.FromArgb(255, 245, 202, 150), Color.FromArgb(255, 245, 205, 155), Color.FromArgb(255, 90, 100, 134), Color.FromArgb(255, 84, 94, 127), Color.FromArgb(255, 171, 216, 205), Color.FromArgb(255, 183, 229, 220), Color.FromArgb(255, 188, 230, 221), Color.FromArgb(255, 74, 90, 131), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 85, 55, 87), Color.FromArgb(255, 85, 55, 87), Color.FromArgb(255, 85, 55, 87), Color.FromArgb(255, 85, 55, 87), Color.FromArgb(255, 85, 55, 87), Color.FromArgb(255, 85, 55, 87), Color.FromArgb(255, 85, 55, 87), Color.FromArgb(255, 85, 55, 87), Color.FromArgb(255, 85, 55, 87), Color.FromArgb(255, 85, 55, 87), Color.FromArgb(255, 211, 161, 119), Color.FromArgb(255, 183, 230, 219), Color.FromArgb(255, 94, 109, 150), Color.FromArgb(255, 241, 168, 76), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 14, 14, 39), Color.FromArgb(255, 171, 121, 105), Color.FromArgb(255, 202, 127, 115), Color.FromArgb(255, 101, 119, 156), Color.FromArgb(255, 98, 116, 150), Color.FromArgb(255, 114, 124, 163), Color.FromArgb(255, 118, 133, 178), Color.FromArgb(255, 100, 119, 167), Color.FromArgb(255, 109, 127, 173), Color.FromArgb(255, 102, 201, 50), Color.FromArgb(255, 104, 199, 55), Color.FromArgb(255, 123, 198, 62), Color.FromArgb(255, 77, 150, 109), Color.FromArgb(255, 100, 131, 162), Color.FromArgb(255, 232, 154, 134), Color.FromArgb(255, 221, 164, 118),  },
            new Color[16]{ Color.FromArgb(255, 97, 97, 97), Color.FromArgb(255, 104, 116, 153), Color.FromArgb(255, 157, 126, 107), Color.FromArgb(255, 110, 148, 165), Color.FromArgb(255, 161, 157, 156), Color.FromArgb(255, 157, 155, 114), Color.FromArgb(255, 161, 191, 211), Color.FromArgb(255, 154, 209, 142), Color.FromArgb(255, 182, 114, 147), Color.FromArgb(255, 220, 143, 95), Color.FromArgb(255, 236, 148, 161), Color.FromArgb(255, 155, 107, 150), Color.FromArgb(255, 187, 113, 107), Color.FromArgb(255, 139, 119, 128), Color.FromArgb(255, 224, 213, 188), Color.FromArgb(255, 191, 152, 101),  },
            new Color[16]{ Color.FromArgb(255, 63, 66, 62), Color.FromArgb(255, 69, 114, 207), Color.FromArgb(255, 125, 87, 67), Color.FromArgb(255, 44, 186, 193), Color.FromArgb(255, 125, 130, 127), Color.FromArgb(255, 81, 191, 98), Color.FromArgb(255, 109, 181, 207), Color.FromArgb(255, 134, 205, 89), Color.FromArgb(255, 201, 87, 196), Color.FromArgb(255, 210, 156, 45), Color.FromArgb(255, 198, 88, 129), Color.FromArgb(255, 158, 83, 210), Color.FromArgb(255, 206, 64, 48), Color.FromArgb(255, 139, 157, 175), Color.FromArgb(255, 192, 196, 195), Color.FromArgb(255, 205, 190, 52),  },
            new Color[16]{ Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85), Color.FromArgb(255, 116, 106, 85),  },
            new Color[16]{ Color.FromArgb(255, 175, 170, 156), Color.FromArgb(255, 207, 207, 207), Color.FromArgb(255, 167, 153, 153), Color.FromArgb(255, 142, 141, 61), Color.FromArgb(255, 171, 166, 162), Color.FromArgb(255, 143, 109, 44), Color.FromArgb(255, 65, 178, 76), Color.FromArgb(255, 232, 181, 65), Color.FromArgb(255, 79, 84, 92), Color.FromArgb(255, 175, 95, 105), Color.FromArgb(255, 183, 101, 106), Color.FromArgb(255, 198, 198, 198), Color.FromArgb(255, 156, 156, 156), Color.FromArgb(255, 63, 173, 166), Color.FromArgb(255, 207, 88, 77), Color.FromArgb(255, 226, 100, 87),  },
            new Color[16]{ Color.FromArgb(255, 156, 155, 151), Color.FromArgb(255, 172, 172, 172), Color.FromArgb(255, 92, 124, 96), Color.FromArgb(255, 117, 171, 49), Color.FromArgb(255, 159, 178, 121), Color.FromArgb(255, 142, 117, 99), Color.FromArgb(255, 67, 179, 76), Color.FromArgb(255, 125, 206, 78), Color.FromArgb(255, 88, 66, 53), Color.FromArgb(255, 77, 135, 96), Color.FromArgb(255, 78, 145, 123), Color.FromArgb(255, 212, 212, 212), Color.FromArgb(255, 162, 162, 162), Color.FromArgb(255, 34, 145, 162), Color.FromArgb(255, 226, 100, 87), Color.FromArgb(255, 227, 102, 89),  },
            new Color[16]{ Color.FromArgb(255, 94, 139, 226), Color.FromArgb(255, 39, 163, 200), Color.FromArgb(255, 152, 197, 176), Color.FromArgb(255, 219, 238, 186), Color.FromArgb(255, 133, 106, 62), Color.FromArgb(255, 142, 172, 123), Color.FromArgb(255, 54, 151, 137), Color.FromArgb(255, 104, 142, 63), Color.FromArgb(255, 114, 65, 56), Color.FromArgb(255, 136, 58, 51), Color.FromArgb(255, 151, 57, 53), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 62, 192, 189), Color.FromArgb(255, 222, 100, 86), Color.FromArgb(255, 226, 100, 87),  },
            new Color[16]{ Color.FromArgb(255, 175, 117, 124), Color.FromArgb(255, 209, 183, 117), Color.FromArgb(255, 58, 109, 102), Color.FromArgb(255, 161, 102, 97), Color.FromArgb(255, 85, 99, 144), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 213, 21, 21), Color.FromArgb(255, 142, 228, 246), Color.FromArgb(255, 176, 199, 145), Color.FromArgb(255, 140, 148, 221), Color.FromArgb(255, 84, 95, 124),  },
            new Color[16]{ Color.FromArgb(255, 172, 116, 123), Color.FromArgb(255, 208, 180, 115), Color.FromArgb(255, 60, 117, 104), Color.FromArgb(255, 158, 100, 95), Color.FromArgb(255, 84, 101, 147), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Plastic = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 127, 127, 127), Color.FromArgb(255, 111, 111, 111), Color.FromArgb(255, 121, 85, 58), Color.FromArgb(255, 117, 107, 62), Color.FromArgb(255, 157, 126, 78), Color.FromArgb(255, 169, 169, 169), Color.FromArgb(255, 168, 168, 168), Color.FromArgb(255, 125, 70, 54), Color.FromArgb(255, 188, 93, 48), Color.FromArgb(255, 190, 85, 40), Color.FromArgb(255, 148, 49, 22), Color.FromArgb(255, 235, 235, 235), Color.FromArgb(255, 112, 42, 11), Color.FromArgb(255, 113, 160, 1), Color.FromArgb(255, 0, 42, 255), Color.FromArgb(255, 73, 117, 41),  },
            new Color[16]{ Color.FromArgb(255, 103, 103, 103), Color.FromArgb(255, 51, 51, 51), Color.FromArgb(255, 203, 190, 148), Color.FromArgb(255, 112, 111, 109), Color.FromArgb(255, 106, 85, 52), Color.FromArgb(255, 121, 99, 60), Color.FromArgb(255, 207, 207, 207), Color.FromArgb(255, 229, 196, 47), Color.FromArgb(255, 97, 211, 217), Color.FromArgb(255, 57, 205, 97), Color.FromArgb(255, 202, 43, 18), Color.FromArgb(255, 127, 127, 127), Color.FromArgb(255, 197, 46, 54), Color.FromArgb(255, 149, 117, 95), Color.FromArgb(255, 61, 118, 26), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 123, 120, 104), Color.FromArgb(255, 122, 118, 115), Color.FromArgb(255, 106, 106, 106), Color.FromArgb(255, 106, 86, 50), Color.FromArgb(255, 82, 106, 80), Color.FromArgb(255, 61, 49, 87), Color.FromArgb(255, 129, 129, 129), Color.FromArgb(255, 161, 161, 161), Color.FromArgb(255, 120, 120, 120), Color.FromArgb(255, 141, 189, 195), Color.FromArgb(255, 125, 125, 125), Color.FromArgb(255, 72, 58, 29), Color.FromArgb(255, 115, 115, 115), Color.FromArgb(255, 135, 135, 135), Color.FromArgb(255, 127, 127, 127), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 179, 179, 57), Color.FromArgb(255, 223, 237, 239), Color.FromArgb(255, 108, 121, 122), Color.FromArgb(255, 120, 103, 101), Color.FromArgb(255, 148, 148, 148), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 106, 106, 106), Color.FromArgb(255, 92, 66, 33), Color.FromArgb(255, 123, 123, 123), Color.FromArgb(255, 162, 140, 111), Color.FromArgb(255, 60, 48, 34), Color.FromArgb(255, 66, 63, 58), Color.FromArgb(255, 66, 63, 58), Color.FromArgb(255, 141, 129, 115), Color.FromArgb(255, 133, 133, 133), Color.FromArgb(255, 63, 96, 58),  },
            new Color[16]{ Color.FromArgb(255, 218, 218, 218), Color.FromArgb(255, 99, 73, 73), Color.FromArgb(255, 219, 228, 232), Color.FromArgb(153, 196, 216, 241), Color.FromArgb(255, 137, 115, 97), Color.FromArgb(255, 29, 112, 28), Color.FromArgb(255, 17, 108, 28), Color.FromArgb(255, 120, 156, 79), Color.FromArgb(255, 161, 169, 192), Color.FromArgb(255, 83, 131, 11), Color.FromArgb(255, 37, 63, 126), Color.FromArgb(255, 40, 58, 112), Color.FromArgb(255, 123, 123, 123), Color.FromArgb(255, 109, 78, 62), Color.FromArgb(255, 73, 54, 60), Color.FromArgb(255, 93, 119, 62),  },
            new Color[16]{ Color.FromArgb(255, 126, 88, 43), Color.FromArgb(255, 139, 99, 48), Color.FromArgb(255, 167, 167, 167), Color.FromArgb(255, 84, 57, 25), Color.FromArgb(255, 133, 91, 43), Color.FromArgb(255, 141, 141, 141), Color.FromArgb(255, 73, 42, 17), Color.FromArgb(255, 115, 75, 44), Color.FromArgb(255, 3, 145, 14), Color.FromArgb(255, 3, 145, 14), Color.FromArgb(255, 78, 143, 3), Color.FromArgb(255, 113, 148, 2), Color.FromArgb(255, 139, 147, 1), Color.FromArgb(255, 151, 151, 2), Color.FromArgb(255, 151, 135, 2), Color.FromArgb(255, 159, 136, 31),  },
            new Color[16]{ Color.FromArgb(255, 81, 51, 28), Color.FromArgb(255, 138, 98, 47), Color.FromArgb(255, 168, 168, 168), Color.FromArgb(255, 142, 37, 14), Color.FromArgb(255, 73, 100, 71), Color.FromArgb(255, 98, 97, 97), Color.FromArgb(255, 148, 88, 15), Color.FromArgb(255, 66, 4, 4), Color.FromArgb(255, 58, 39, 27), Color.FromArgb(255, 115, 85, 37), Color.FromArgb(255, 76, 95, 56), Color.FromArgb(255, 105, 94, 71), Color.FromArgb(255, 134, 134, 134), Color.FromArgb(255, 133, 133, 133), Color.FromArgb(255, 129, 129, 129), Color.FromArgb(255, 154, 154, 154),  },
            new Color[16]{ Color.FromArgb(255, 124, 104, 90), Color.FromArgb(255, 30, 30, 30), Color.FromArgb(255, 66, 66, 66), Color.FromArgb(255, 110, 45, 22), Color.FromArgb(255, 60, 41, 21), Color.FromArgb(255, 206, 205, 195), Color.FromArgb(255, 181, 104, 18), Color.FromArgb(255, 154, 86, 15), Color.FromArgb(255, 204, 137, 44), Color.FromArgb(255, 232, 224, 222), Color.FromArgb(255, 154, 141, 134), Color.FromArgb(255, 128, 101, 83), Color.FromArgb(255, 74, 49, 33), Color.FromArgb(255, 181, 53, 52), Color.FromArgb(255, 132, 98, 75), Color.FromArgb(255, 155, 155, 155),  },
            new Color[16]{ Color.FromArgb(255, 123, 103, 89), Color.FromArgb(255, 153, 52, 49), Color.FromArgb(255, 210, 138, 158), Color.FromArgb(255, 130, 125, 125), Color.FromArgb(255, 144, 144, 144), Color.FromArgb(255, 109, 109, 109), Color.FromArgb(255, 8, 73, 130), Color.FromArgb(255, 132, 165, 194), Color.FromArgb(255, 140, 144, 33), Color.FromArgb(255, 110, 123, 30), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 36, 36, 36), Color.FromArgb(255, 130, 130, 39), Color.FromArgb(255, 212, 208, 198), Color.FromArgb(255, 206, 173, 123), Color.FromArgb(255, 147, 147, 147),  },
            new Color[16]{ Color.FromArgb(255, 7, 77, 246), Color.FromArgb(255, 47, 63, 25), Color.FromArgb(255, 68, 183, 59), Color.FromArgb(255, 139, 125, 125), Color.FromArgb(255, 208, 248, 255), Color.FromArgb(255, 66, 100, 130), Color.FromArgb(255, 60, 97, 130), Color.FromArgb(255, 125, 144, 160), Color.FromArgb(255, 181, 184, 184), Color.FromArgb(255, 103, 71, 35), Color.FromArgb(255, 70, 70, 70), Color.FromArgb(255, 72, 72, 72), Color.FromArgb(255, 96, 96, 96), Color.FromArgb(255, 90, 129, 124), Color.FromArgb(255, 77, 97, 59), Color.FromArgb(255, 113, 126, 73),  },
            new Color[16]{ Color.FromArgb(255, 99, 107, 125), Color.FromArgb(255, 83, 53, 33), Color.FromArgb(255, 207, 194, 49), Color.FromArgb(255, 152, 112, 77), Color.FromArgb(255, 235, 235, 235), Color.FromArgb(255, 235, 235, 235), Color.FromArgb(255, 89, 45, 88), Color.FromArgb(255, 18, 6, 22), Color.FromArgb(255, 197, 115, 46), Color.FromArgb(255, 190, 147, 66), Color.FromArgb(255, 166, 166, 79), Color.FromArgb(255, 105, 121, 109), Color.FromArgb(255, 145, 137, 124), Color.FromArgb(112, 132, 132, 132), Color.FromArgb(255, 78, 129, 70), Color.FromArgb(255, 165, 154, 81),  },
            new Color[16]{ Color.FromArgb(255, 203, 191, 149), Color.FromArgb(255, 45, 56, 137), Color.FromArgb(255, 126, 153, 208), Color.FromArgb(255, 175, 114, 77), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 43, 6, 58), Color.FromArgb(255, 45, 1, 51), Color.FromArgb(255, 149, 146, 145), Color.FromArgb(255, 105, 58, 38), Color.FromArgb(255, 127, 70, 55), Color.FromArgb(255, 130, 125, 125), Color.FromArgb(255, 139, 125, 125), Color.FromArgb(255, 127, 90, 79), Color.FromArgb(255, 153, 91, 80), Color.FromArgb(255, 83, 32, 30),  },
            new Color[16]{ Color.FromArgb(255, 203, 191, 150), Color.FromArgb(255, 116, 54, 168), Color.FromArgb(255, 178, 70, 188), Color.FromArgb(255, 120, 83, 74), Color.FromArgb(255, 145, 145, 145), Color.FromArgb(255, 118, 118, 118), Color.FromArgb(255, 98, 75, 41), Color.FromArgb(255, 132, 92, 66), Color.FromArgb(255, 0, 178, 21), Color.FromArgb(255, 0, 174, 21), Color.FromArgb(255, 0, 181, 21), Color.FromArgb(255, 46, 172, 21), Color.FromArgb(191, 127, 207, 106), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 202, 189, 147), Color.FromArgb(255, 54, 128, 158), Color.FromArgb(255, 221, 131, 71), Color.FromArgb(255, 58, 47, 25), Color.FromArgb(255, 156, 139, 116), Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 173, 155, 90), Color.FromArgb(255, 58, 58, 58), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 223, 220, 210), Color.FromArgb(255, 222, 219, 209), Color.FromArgb(255, 228, 225, 215), Color.FromArgb(255, 66, 66, 66), Color.FromArgb(255, 165, 95, 85), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 49, 3, 3), Color.FromArgb(255, 144, 152, 152), Color.FromArgb(255, 124, 8, 30), Color.FromArgb(255, 122, 8, 30), Color.FromArgb(255, 111, 8, 28), Color.FromArgb(255, 203, 191, 149), Color.FromArgb(255, 203, 191, 149), Color.FromArgb(255, 64, 64, 64), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 216, 213, 200), Color.FromArgb(255, 217, 214, 202), Color.FromArgb(255, 224, 220, 209), Color.FromArgb(255, 36, 36, 36), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 150, 126, 25), Color.FromArgb(255, 228, 225, 215), Color.FromArgb(255, 85, 85, 85), Color.FromArgb(255, 176, 155, 30), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 46, 46, 46), Color.FromArgb(255, 147, 89, 64), Color.FromArgb(255, 37, 63, 126), Color.FromArgb(255, 137, 137, 142), Color.FromArgb(255, 141, 141, 150), Color.FromArgb(255, 201, 201, 209), Color.FromArgb(255, 205, 205, 213), Color.FromArgb(255, 163, 113, 95), Color.FromArgb(255, 166, 118, 100), Color.FromArgb(255, 0, 178, 21), Color.FromArgb(255, 0, 174, 21), Color.FromArgb(255, 0, 181, 21), Color.FromArgb(255, 34, 149, 23), Color.FromArgb(255, 107, 81, 47), Color.FromArgb(255, 138, 100, 67), Color.FromArgb(255, 201, 188, 134),  },
            new Color[16]{ Color.FromArgb(255, 38, 23, 16), Color.FromArgb(255, 74, 59, 91), Color.FromArgb(255, 76, 50, 35), Color.FromArgb(255, 90, 93, 93), Color.FromArgb(255, 59, 44, 36), Color.FromArgb(255, 75, 82, 42), Color.FromArgb(255, 111, 107, 137), Color.FromArgb(255, 103, 117, 52), Color.FromArgb(255, 148, 85, 104), Color.FromArgb(255, 159, 82, 36), Color.FromArgb(255, 160, 77, 78), Color.FromArgb(255, 119, 72, 88), Color.FromArgb(255, 141, 59, 46), Color.FromArgb(255, 138, 109, 100), Color.FromArgb(255, 210, 180, 162), Color.FromArgb(255, 185, 132, 35),  },
            new Color[16]{ Color.FromArgb(163, 44, 42, 39), Color.FromArgb(163, 56, 81, 186), Color.FromArgb(163, 113, 86, 59), Color.FromArgb(163, 83, 134, 162), Color.FromArgb(163, 93, 93, 93), Color.FromArgb(163, 110, 137, 56), Color.FromArgb(163, 107, 158, 218), Color.FromArgb(163, 135, 209, 39), Color.FromArgb(163, 182, 83, 217), Color.FromArgb(163, 218, 133, 60), Color.FromArgb(163, 243, 133, 169), Color.FromArgb(163, 134, 70, 185), Color.FromArgb(163, 163, 59, 59), Color.FromArgb(163, 161, 161, 161), Color.FromArgb(163, 253, 253, 253), Color.FromArgb(163, 231, 231, 62),  },
            new Color[16]{ Color.FromArgb(230, 25, 25, 25), Color.FromArgb(230, 45, 73, 174), Color.FromArgb(230, 99, 76, 48), Color.FromArgb(230, 76, 126, 148), Color.FromArgb(230, 69, 69, 69), Color.FromArgb(230, 99, 127, 48), Color.FromArgb(230, 96, 146, 207), Color.FromArgb(230, 127, 201, 25), Color.FromArgb(230, 177, 76, 215), Color.FromArgb(230, 215, 127, 48), Color.FromArgb(230, 229, 120, 158), Color.FromArgb(230, 127, 63, 177), Color.FromArgb(230, 150, 48, 48), Color.FromArgb(230, 150, 150, 150), Color.FromArgb(230, 242, 242, 242), Color.FromArgb(230, 228, 228, 48),  },
            new Color[16]{ Color.FromArgb(255, 135, 135, 135), Color.FromArgb(255, 122, 74, 24), Color.FromArgb(255, 123, 124, 148), Color.FromArgb(255, 109, 78, 40), Color.FromArgb(255, 161, 134, 156), Color.FromArgb(255, 115, 115, 41), Color.FromArgb(255, 66, 109, 44), Color.FromArgb(255, 214, 178, 19), Color.FromArgb(255, 91, 91, 91), Color.FromArgb(255, 147, 92, 65), Color.FromArgb(255, 176, 100, 63), Color.FromArgb(255, 147, 147, 147), Color.FromArgb(255, 123, 123, 123), Color.FromArgb(255, 85, 174, 160), Color.FromArgb(255, 176, 89, 35), Color.FromArgb(255, 177, 90, 35),  },
            new Color[16]{ Color.FromArgb(255, 133, 133, 133), Color.FromArgb(255, 138, 122, 107), Color.FromArgb(255, 75, 124, 93), Color.FromArgb(255, 85, 87, 29), Color.FromArgb(255, 140, 139, 128), Color.FromArgb(255, 129, 128, 93), Color.FromArgb(255, 61, 102, 39), Color.FromArgb(255, 177, 170, 31), Color.FromArgb(255, 84, 60, 36), Color.FromArgb(255, 99, 76, 43), Color.FromArgb(255, 105, 81, 45), Color.FromArgb(255, 148, 148, 148), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 50, 88, 76), Color.FromArgb(255, 176, 89, 35), Color.FromArgb(255, 181, 92, 37),  },
            new Color[16]{ Color.FromArgb(255, 174, 125, 216), Color.FromArgb(255, 43, 167, 160), Color.FromArgb(255, 182, 208, 171), Color.FromArgb(255, 193, 210, 160), Color.FromArgb(255, 119, 106, 50), Color.FromArgb(255, 129, 171, 108), Color.FromArgb(255, 88, 109, 47), Color.FromArgb(255, 57, 91, 47), Color.FromArgb(255, 120, 84, 57), Color.FromArgb(255, 117, 77, 51), Color.FromArgb(255, 114, 63, 34), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 109, 177, 160), Color.FromArgb(255, 183, 93, 37), Color.FromArgb(255, 180, 91, 36),  },
            new Color[16]{ Color.FromArgb(255, 165, 94, 59), Color.FromArgb(255, 214, 201, 151), Color.FromArgb(255, 75, 49, 24), Color.FromArgb(255, 150, 109, 78), Color.FromArgb(255, 106, 85, 54), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 211, 25, 26), Color.FromArgb(255, 183, 206, 238), Color.FromArgb(255, 132, 177, 163), Color.FromArgb(255, 76, 110, 143), Color.FromArgb(255, 162, 162, 162),  },
            new Color[16]{ Color.FromArgb(255, 159, 90, 56), Color.FromArgb(255, 195, 177, 111), Color.FromArgb(255, 71, 46, 23), Color.FromArgb(255, 147, 106, 75), Color.FromArgb(255, 100, 79, 50), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Skyrim = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 121, 121, 121), Color.FromArgb(255, 77, 85, 84), Color.FromArgb(255, 62, 45, 23), Color.FromArgb(255, 64, 50, 25), Color.FromArgb(255, 92, 83, 68), Color.FromArgb(255, 193, 183, 157), Color.FromArgb(255, 195, 185, 158), Color.FromArgb(255, 95, 98, 98), Color.FromArgb(255, 94, 78, 74), Color.FromArgb(255, 112, 95, 77), Color.FromArgb(255, 72, 60, 56), Color.FromArgb(255, 214, 232, 240), Color.FromArgb(255, 129, 85, 49), Color.FromArgb(255, 128, 119, 45), Color.FromArgb(255, 0, 42, 255), Color.FromArgb(255, 95, 99, 98),  },
            new Color[16]{ Color.FromArgb(255, 73, 65, 56), Color.FromArgb(255, 44, 40, 33), Color.FromArgb(255, 227, 208, 154), Color.FromArgb(255, 53, 50, 42), Color.FromArgb(255, 69, 69, 48), Color.FromArgb(255, 145, 130, 108), Color.FromArgb(255, 59, 62, 66), Color.FromArgb(255, 168, 154, 83), Color.FromArgb(255, 126, 122, 81), Color.FromArgb(255, 106, 100, 70), Color.FromArgb(255, 127, 100, 59), Color.FromArgb(255, 84, 75, 66), Color.FromArgb(255, 172, 103, 99), Color.FromArgb(255, 172, 126, 87), Color.FromArgb(255, 143, 174, 144), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 99, 100, 76), Color.FromArgb(255, 102, 101, 90), Color.FromArgb(255, 70, 78, 77), Color.FromArgb(255, 83, 48, 33), Color.FromArgb(255, 67, 67, 48), Color.FromArgb(255, 21, 21, 21), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 97, 97, 97), Color.FromArgb(255, 82, 74, 65), Color.FromArgb(255, 131, 116, 81), Color.FromArgb(255, 83, 74, 65), Color.FromArgb(255, 82, 58, 34), Color.FromArgb(255, 79, 70, 61), Color.FromArgb(255, 88, 78, 68), Color.FromArgb(255, 82, 73, 64), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 109, 101, 92), Color.FromArgb(255, 36, 38, 40), Color.FromArgb(255, 95, 109, 113), Color.FromArgb(255, 97, 73, 73), Color.FromArgb(255, 99, 99, 99), Color.FromArgb(255, 68, 68, 68), Color.FromArgb(255, 91, 88, 79), Color.FromArgb(255, 78, 69, 55), Color.FromArgb(255, 129, 129, 129), Color.FromArgb(255, 124, 150, 131), Color.FromArgb(255, 116, 125, 94), Color.FromArgb(255, 74, 49, 33), Color.FromArgb(255, 74, 49, 33), Color.FromArgb(255, 88, 75, 62), Color.FromArgb(255, 94, 89, 83), Color.FromArgb(255, 144, 100, 82),  },
            new Color[16]{ Color.FromArgb(255, 81, 71, 61), Color.FromArgb(255, 106, 77, 62), Color.FromArgb(255, 218, 222, 225), Color.FromArgb(171, 167, 194, 207), Color.FromArgb(255, 93, 80, 64), Color.FromArgb(255, 108, 98, 60), Color.FromArgb(255, 101, 98, 60), Color.FromArgb(255, 156, 155, 105), Color.FromArgb(255, 133, 125, 105), Color.FromArgb(255, 98, 76, 54), Color.FromArgb(255, 63, 59, 53), Color.FromArgb(255, 76, 69, 57), Color.FromArgb(255, 132, 133, 132), Color.FromArgb(255, 91, 65, 44), Color.FromArgb(255, 136, 98, 77), Color.FromArgb(255, 118, 116, 127),  },
            new Color[16]{ Color.FromArgb(255, 151, 123, 76), Color.FromArgb(255, 68, 55, 41), Color.FromArgb(255, 117, 98, 52), Color.FromArgb(255, 80, 71, 58), Color.FromArgb(255, 68, 63, 53), Color.FromArgb(255, 130, 111, 70), Color.FromArgb(255, 53, 33, 28), Color.FromArgb(255, 79, 61, 58), Color.FromArgb(255, 166, 187, 69), Color.FromArgb(255, 182, 204, 73), Color.FromArgb(255, 214, 223, 80), Color.FromArgb(255, 213, 222, 80), Color.FromArgb(255, 221, 202, 79), Color.FromArgb(255, 219, 198, 78), Color.FromArgb(255, 223, 196, 73), Color.FromArgb(255, 225, 188, 69),  },
            new Color[16]{ Color.FromArgb(255, 118, 102, 54), Color.FromArgb(255, 69, 56, 42), Color.FromArgb(255, 119, 101, 55), Color.FromArgb(255, 148, 93, 75), Color.FromArgb(255, 85, 89, 69), Color.FromArgb(255, 87, 84, 75), Color.FromArgb(255, 181, 74, 59), Color.FromArgb(255, 127, 114, 71), Color.FromArgb(255, 107, 65, 99), Color.FromArgb(255, 117, 68, 36), Color.FromArgb(255, 142, 138, 91), Color.FromArgb(255, 153, 143, 80), Color.FromArgb(255, 100, 106, 92), Color.FromArgb(255, 72, 83, 89), Color.FromArgb(255, 71, 81, 87), Color.FromArgb(255, 140, 140, 140),  },
            new Color[16]{ Color.FromArgb(255, 106, 64, 56), Color.FromArgb(255, 130, 113, 88), Color.FromArgb(255, 101, 89, 71), Color.FromArgb(255, 120, 93, 77), Color.FromArgb(255, 79, 65, 50), Color.FromArgb(255, 166, 165, 158), Color.FromArgb(255, 173, 67, 53), Color.FromArgb(255, 153, 61, 49), Color.FromArgb(255, 180, 96, 61), Color.FromArgb(255, 191, 179, 164), Color.FromArgb(255, 167, 131, 105), Color.FromArgb(255, 142, 84, 48), Color.FromArgb(255, 141, 70, 27), Color.FromArgb(255, 101, 198, 231), Color.FromArgb(255, 95, 204, 203), Color.FromArgb(255, 139, 139, 139),  },
            new Color[16]{ Color.FromArgb(255, 107, 65, 56), Color.FromArgb(255, 77, 64, 57), Color.FromArgb(255, 76, 62, 54), Color.FromArgb(255, 53, 34, 21), Color.FromArgb(255, 71, 71, 71), Color.FromArgb(255, 44, 44, 44), Color.FromArgb(255, 96, 106, 64), Color.FromArgb(255, 140, 128, 69), Color.FromArgb(255, 121, 123, 51), Color.FromArgb(255, 134, 129, 49), Color.FromArgb(255, 56, 62, 67), Color.FromArgb(255, 44, 49, 52), Color.FromArgb(255, 113, 88, 66), Color.FromArgb(255, 93, 161, 164), Color.FromArgb(255, 139, 217, 252), Color.FromArgb(255, 138, 138, 138),  },
            new Color[16]{ Color.FromArgb(255, 123, 115, 91), Color.FromArgb(255, 78, 77, 71), Color.FromArgb(255, 77, 67, 61), Color.FromArgb(255, 62, 34, 22), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 90, 88, 54), Color.FromArgb(255, 84, 88, 50), Color.FromArgb(255, 130, 120, 67), Color.FromArgb(255, 172, 149, 83), Color.FromArgb(255, 123, 110, 83), Color.FromArgb(255, 55, 60, 64), Color.FromArgb(255, 57, 63, 68), Color.FromArgb(255, 128, 105, 72), Color.FromArgb(255, 106, 90, 70), Color.FromArgb(255, 76, 146, 162), Color.FromArgb(255, 117, 145, 152),  },
            new Color[16]{ Color.FromArgb(255, 96, 76, 43), Color.FromArgb(255, 187, 171, 147), Color.FromArgb(255, 159, 139, 119), Color.FromArgb(255, 89, 66, 62), Color.FromArgb(255, 162, 162, 162), Color.FromArgb(255, 189, 189, 189), Color.FromArgb(255, 48, 75, 73), Color.FromArgb(255, 150, 174, 169), Color.FromArgb(255, 108, 53, 26), Color.FromArgb(255, 114, 76, 26), Color.FromArgb(255, 104, 95, 21), Color.FromArgb(255, 81, 109, 91), Color.FromArgb(255, 159, 139, 60), Color.FromArgb(255, 196, 181, 118), Color.FromArgb(255, 44, 152, 162), Color.FromArgb(255, 107, 107, 114),  },
            new Color[16]{ Color.FromArgb(255, 191, 175, 126), Color.FromArgb(255, 145, 130, 73), Color.FromArgb(255, 108, 99, 98), Color.FromArgb(255, 122, 98, 95), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 49, 43, 60), Color.FromArgb(255, 55, 49, 70), Color.FromArgb(255, 167, 142, 81), Color.FromArgb(255, 126, 97, 55), Color.FromArgb(255, 106, 114, 104), Color.FromArgb(255, 54, 35, 22), Color.FromArgb(255, 64, 35, 22), Color.FromArgb(255, 72, 73, 65), Color.FromArgb(255, 95, 119, 108), Color.FromArgb(255, 103, 166, 168),  },
            new Color[16]{ Color.FromArgb(255, 190, 172, 120), Color.FromArgb(255, 81, 62, 46), Color.FromArgb(255, 160, 144, 118), Color.FromArgb(255, 126, 78, 47), Color.FromArgb(255, 97, 97, 97), Color.FromArgb(255, 63, 63, 63), Color.FromArgb(255, 64, 57, 48), Color.FromArgb(255, 78, 75, 57), Color.FromArgb(255, 65, 93, 55), Color.FromArgb(255, 69, 99, 59), Color.FromArgb(255, 72, 102, 61), Color.FromArgb(255, 127, 120, 59), Color.FromArgb(194, 190, 234, 244), Color.FromArgb(163, 42, 94, 253), Color.FromArgb(163, 42, 94, 253), Color.FromArgb(163, 42, 94, 253),  },
            new Color[16]{ Color.FromArgb(255, 158, 138, 93), Color.FromArgb(255, 78, 83, 86), Color.FromArgb(255, 126, 114, 95), Color.FromArgb(255, 62, 53, 54), Color.FromArgb(255, 122, 45, 45), Color.FromArgb(255, 60, 61, 71), Color.FromArgb(255, 86, 77, 65), Color.FromArgb(255, 30, 31, 32), Color.FromArgb(255, 49, 49, 51), Color.FromArgb(255, 99, 163, 159), Color.FromArgb(255, 124, 149, 122), Color.FromArgb(255, 86, 149, 144), Color.FromArgb(255, 144, 120, 68), Color.FromArgb(255, 163, 114, 69), Color.FromArgb(163, 42, 94, 253), Color.FromArgb(163, 42, 94, 253),  },
            new Color[16]{ Color.FromArgb(255, 52, 54, 57), Color.FromArgb(255, 119, 120, 111), Color.FromArgb(255, 100, 125, 179), Color.FromArgb(255, 114, 120, 188), Color.FromArgb(255, 112, 131, 193), Color.FromArgb(255, 164, 147, 101), Color.FromArgb(255, 190, 169, 113), Color.FromArgb(255, 50, 50, 52), Color.FromArgb(255, 48, 48, 50), Color.FromArgb(255, 110, 158, 139), Color.FromArgb(255, 121, 181, 177), Color.FromArgb(255, 88, 152, 147), Color.FromArgb(255, 99, 79, 42), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 229, 43, 0), Color.FromArgb(255, 232, 47, 0), Color.FromArgb(255, 234, 50, 0), Color.FromArgb(255, 238, 54, 0), Color.FromArgb(255, 238, 56, 0), Color.FromArgb(255, 240, 58, 0), Color.FromArgb(255, 242, 60, 0), Color.FromArgb(255, 244, 63, 0), Color.FromArgb(255, 245, 64, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 183, 170, 106), Color.FromArgb(255, 56, 102, 99), Color.FromArgb(255, 124, 97, 61), Color.FromArgb(255, 222, 213, 132), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 46, 46, 51), Color.FromArgb(255, 111, 107, 100), Color.FromArgb(255, 63, 59, 53), Color.FromArgb(255, 146, 100, 77), Color.FromArgb(255, 144, 99, 80), Color.FromArgb(255, 32, 46, 50), Color.FromArgb(255, 38, 49, 52), Color.FromArgb(255, 110, 104, 90), Color.FromArgb(255, 126, 120, 102), Color.FromArgb(255, 65, 93, 55), Color.FromArgb(255, 69, 99, 59), Color.FromArgb(255, 72, 102, 61), Color.FromArgb(255, 94, 113, 69), Color.FromArgb(255, 154, 123, 98), Color.FromArgb(255, 161, 155, 121), Color.FromArgb(255, 196, 182, 151),  },
            new Color[16]{ Color.FromArgb(255, 31, 29, 26), Color.FromArgb(255, 43, 72, 148), Color.FromArgb(255, 88, 59, 40), Color.FromArgb(255, 62, 126, 149), Color.FromArgb(255, 90, 88, 83), Color.FromArgb(255, 73, 98, 32), Color.FromArgb(255, 120, 149, 186), Color.FromArgb(255, 109, 168, 27), Color.FromArgb(255, 184, 110, 175), Color.FromArgb(255, 184, 125, 44), Color.FromArgb(255, 194, 146, 168), Color.FromArgb(255, 146, 78, 170), Color.FromArgb(255, 164, 51, 48), Color.FromArgb(255, 162, 160, 161), Color.FromArgb(255, 204, 203, 200), Color.FromArgb(255, 191, 189, 44),  },
            new Color[16]{ Color.FromArgb(255, 27, 28, 28), Color.FromArgb(255, 37, 56, 107), Color.FromArgb(255, 65, 49, 39), Color.FromArgb(255, 50, 88, 104), Color.FromArgb(255, 62, 63, 64), Color.FromArgb(255, 58, 74, 35), Color.FromArgb(255, 79, 102, 133), Color.FromArgb(255, 77, 118, 29), Color.FromArgb(255, 122, 74, 126), Color.FromArgb(255, 126, 86, 41), Color.FromArgb(255, 136, 98, 116), Color.FromArgb(255, 96, 57, 118), Color.FromArgb(255, 108, 43, 44), Color.FromArgb(255, 106, 107, 112), Color.FromArgb(255, 144, 145, 146), Color.FromArgb(255, 133, 134, 41),  },
            new Color[16]{ Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78), Color.FromArgb(255, 69, 73, 78),  },
            new Color[16]{ Color.FromArgb(255, 117, 115, 96), Color.FromArgb(255, 125, 125, 125), Color.FromArgb(255, 160, 107, 101), Color.FromArgb(255, 94, 69, 43), Color.FromArgb(255, 97, 86, 126), Color.FromArgb(255, 109, 95, 49), Color.FromArgb(255, 92, 102, 48), Color.FromArgb(255, 167, 120, 58), Color.FromArgb(255, 76, 55, 45), Color.FromArgb(255, 126, 97, 86), Color.FromArgb(255, 110, 83, 76), Color.FromArgb(255, 94, 94, 94), Color.FromArgb(255, 61, 61, 61), Color.FromArgb(255, 74, 171, 174), Color.FromArgb(255, 161, 106, 73), Color.FromArgb(255, 169, 117, 84),  },
            new Color[16]{ Color.FromArgb(255, 104, 102, 78), Color.FromArgb(255, 86, 86, 86), Color.FromArgb(255, 121, 87, 78), Color.FromArgb(255, 76, 62, 43), Color.FromArgb(255, 83, 81, 59), Color.FromArgb(255, 112, 107, 85), Color.FromArgb(255, 94, 104, 49), Color.FromArgb(255, 137, 103, 50), Color.FromArgb(255, 46, 41, 31), Color.FromArgb(255, 79, 70, 57), Color.FromArgb(255, 75, 66, 52), Color.FromArgb(255, 99, 99, 99), Color.FromArgb(255, 68, 68, 68), Color.FromArgb(255, 39, 113, 115), Color.FromArgb(255, 157, 101, 68), Color.FromArgb(255, 163, 108, 76),  },
            new Color[16]{ Color.FromArgb(255, 147, 95, 90), Color.FromArgb(255, 104, 123, 129), Color.FromArgb(255, 115, 132, 77), Color.FromArgb(255, 164, 110, 163), Color.FromArgb(255, 107, 87, 48), Color.FromArgb(255, 110, 116, 83), Color.FromArgb(255, 96, 125, 108), Color.FromArgb(255, 137, 122, 94), Color.FromArgb(255, 60, 44, 28), Color.FromArgb(255, 67, 54, 30), Color.FromArgb(255, 89, 85, 59), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 61, 179, 182), Color.FromArgb(255, 161, 109, 78), Color.FromArgb(255, 165, 111, 78),  },
            new Color[16]{ Color.FromArgb(255, 78, 78, 73), Color.FromArgb(255, 97, 77, 44), Color.FromArgb(255, 53, 55, 51), Color.FromArgb(255, 44, 40, 38), Color.FromArgb(255, 48, 41, 33), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 210, 25, 26), Color.FromArgb(255, 197, 215, 223), Color.FromArgb(255, 169, 166, 110), Color.FromArgb(255, 61, 66, 57), Color.FromArgb(255, 49, 48, 42),  },
            new Color[16]{ Color.FromArgb(255, 82, 82, 75), Color.FromArgb(255, 98, 79, 45), Color.FromArgb(255, 54, 57, 53), Color.FromArgb(255, 37, 31, 29), Color.FromArgb(255, 48, 42, 34), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        internal static readonly Color[][] Matriz_Edición_Consola_Colores_Steampunk = new Color[32][]
        {
            new Color[16]{ Color.FromArgb(255, 105, 105, 105), Color.FromArgb(255, 73, 77, 81), Color.FromArgb(255, 53, 36, 32), Color.FromArgb(255, 57, 45, 36), Color.FromArgb(255, 84, 67, 42), Color.FromArgb(255, 55, 62, 67), Color.FromArgb(255, 55, 62, 67), Color.FromArgb(255, 102, 69, 54), Color.FromArgb(255, 113, 95, 74), Color.FromArgb(255, 94, 42, 31), Color.FromArgb(255, 100, 80, 60), Color.FromArgb(255, 206, 200, 190), Color.FromArgb(255, 77, 40, 25), Color.FromArgb(255, 124, 139, 67), Color.FromArgb(255, 0, 42, 255), Color.FromArgb(255, 41, 71, 11),  },
            new Color[16]{ Color.FromArgb(255, 66, 72, 82), Color.FromArgb(255, 82, 76, 63), Color.FromArgb(255, 181, 155, 119), Color.FromArgb(255, 118, 117, 117), Color.FromArgb(255, 62, 41, 30), Color.FromArgb(255, 106, 86, 48), Color.FromArgb(255, 167, 167, 167), Color.FromArgb(255, 193, 166, 77), Color.FromArgb(255, 156, 155, 144), Color.FromArgb(255, 95, 155, 90), Color.FromArgb(255, 194, 78, 69), Color.FromArgb(255, 67, 67, 67), Color.FromArgb(255, 135, 69, 54), Color.FromArgb(255, 124, 114, 107), Color.FromArgb(255, 86, 97, 21), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 101, 92, 73), Color.FromArgb(255, 111, 95, 90), Color.FromArgb(255, 57, 60, 65), Color.FromArgb(255, 94, 61, 36), Color.FromArgb(255, 50, 70, 46), Color.FromArgb(255, 22, 22, 22), Color.FromArgb(255, 106, 106, 106), Color.FromArgb(255, 80, 84, 87), Color.FromArgb(255, 58, 58, 58), Color.FromArgb(255, 106, 180, 176), Color.FromArgb(255, 59, 59, 59), Color.FromArgb(255, 87, 63, 43), Color.FromArgb(255, 61, 61, 61), Color.FromArgb(255, 63, 63, 63), Color.FromArgb(255, 62, 62, 62), Color.FromArgb(255, 255, 0, 0),  },
            new Color[16]{ Color.FromArgb(255, 191, 172, 88), Color.FromArgb(255, 99, 89, 63), Color.FromArgb(255, 94, 97, 106), Color.FromArgb(255, 95, 65, 69), Color.FromArgb(255, 103, 103, 103), Color.FromArgb(255, 70, 70, 70), Color.FromArgb(255, 87, 91, 96), Color.FromArgb(255, 39, 34, 26), Color.FromArgb(255, 145, 145, 145), Color.FromArgb(255, 81, 103, 109), Color.FromArgb(255, 70, 70, 65), Color.FromArgb(255, 104, 90, 62), Color.FromArgb(255, 104, 93, 68), Color.FromArgb(255, 91, 84, 62), Color.FromArgb(255, 58, 58, 58), Color.FromArgb(255, 47, 52, 36),  },
            new Color[16]{ Color.FromArgb(255, 204, 207, 207), Color.FromArgb(255, 43, 48, 52), Color.FromArgb(255, 200, 211, 219), Color.FromArgb(140, 136, 150, 161), Color.FromArgb(255, 75, 62, 60), Color.FromArgb(255, 70, 85, 57), Color.FromArgb(255, 56, 77, 41), Color.FromArgb(255, 94, 123, 73), Color.FromArgb(255, 128, 136, 143), Color.FromArgb(255, 84, 54, 34), Color.FromArgb(255, 73, 54, 31), Color.FromArgb(255, 86, 69, 45), Color.FromArgb(255, 81, 105, 52), Color.FromArgb(255, 69, 49, 48), Color.FromArgb(255, 121, 91, 95), Color.FromArgb(255, 117, 76, 22),  },
            new Color[16]{ Color.FromArgb(255, 168, 154, 118), Color.FromArgb(255, 93, 80, 46), Color.FromArgb(255, 77, 79, 78), Color.FromArgb(255, 24, 27, 28), Color.FromArgb(255, 162, 141, 76), Color.FromArgb(255, 40, 43, 44), Color.FromArgb(255, 56, 31, 21), Color.FromArgb(255, 115, 78, 62), Color.FromArgb(255, 139, 198, 20), Color.FromArgb(255, 136, 182, 25), Color.FromArgb(255, 145, 172, 33), Color.FromArgb(255, 157, 171, 43), Color.FromArgb(255, 163, 167, 49), Color.FromArgb(255, 169, 162, 56), Color.FromArgb(255, 177, 159, 64), Color.FromArgb(255, 200, 176, 91),  },
            new Color[16]{ Color.FromArgb(255, 51, 51, 51), Color.FromArgb(255, 95, 81, 45), Color.FromArgb(255, 82, 83, 83), Color.FromArgb(255, 96, 77, 65), Color.FromArgb(255, 75, 92, 70), Color.FromArgb(255, 84, 88, 93), Color.FromArgb(255, 131, 87, 50), Color.FromArgb(255, 115, 57, 22), Color.FromArgb(255, 105, 31, 22), Color.FromArgb(255, 127, 82, 44), Color.FromArgb(255, 83, 85, 64), Color.FromArgb(255, 73, 60, 40), Color.FromArgb(255, 70, 61, 45), Color.FromArgb(255, 51, 50, 49), Color.FromArgb(255, 49, 47, 43), Color.FromArgb(255, 104, 104, 104),  },
            new Color[16]{ Color.FromArgb(255, 108, 92, 77), Color.FromArgb(255, 38, 38, 38), Color.FromArgb(255, 69, 67, 66), Color.FromArgb(255, 85, 84, 76), Color.FromArgb(255, 111, 87, 49), Color.FromArgb(255, 110, 121, 127), Color.FromArgb(255, 143, 100, 54), Color.FromArgb(255, 138, 102, 52), Color.FromArgb(255, 164, 120, 56), Color.FromArgb(255, 213, 164, 127), Color.FromArgb(255, 206, 144, 55), Color.FromArgb(255, 215, 174, 91), Color.FromArgb(255, 181, 120, 53), Color.FromArgb(255, 152, 46, 22), Color.FromArgb(255, 132, 118, 110), Color.FromArgb(255, 111, 111, 111),  },
            new Color[16]{ Color.FromArgb(255, 102, 85, 69), Color.FromArgb(255, 101, 22, 21), Color.FromArgb(255, 140, 92, 87), Color.FromArgb(255, 76, 71, 71), Color.FromArgb(255, 69, 69, 69), Color.FromArgb(255, 57, 57, 57), Color.FromArgb(255, 99, 80, 49), Color.FromArgb(255, 180, 176, 170), Color.FromArgb(255, 93, 127, 70), Color.FromArgb(255, 98, 133, 75), Color.FromArgb(255, 130, 77, 53), Color.FromArgb(255, 68, 34, 21), Color.FromArgb(255, 158, 138, 64), Color.FromArgb(255, 205, 205, 204), Color.FromArgb(255, 150, 118, 70), Color.FromArgb(255, 95, 95, 95),  },
            new Color[16]{ Color.FromArgb(255, 67, 99, 146), Color.FromArgb(255, 43, 59, 40), Color.FromArgb(255, 54, 76, 55), Color.FromArgb(255, 89, 69, 70), Color.FromArgb(255, 46, 51, 58), Color.FromArgb(255, 75, 56, 33), Color.FromArgb(255, 72, 55, 33), Color.FromArgb(255, 122, 110, 99), Color.FromArgb(255, 132, 121, 110), Color.FromArgb(255, 128, 114, 91), Color.FromArgb(255, 131, 75, 50), Color.FromArgb(255, 118, 64, 41), Color.FromArgb(255, 121, 76, 47), Color.FromArgb(255, 136, 124, 75), Color.FromArgb(255, 97, 75, 53), Color.FromArgb(255, 111, 94, 68),  },
            new Color[16]{ Color.FromArgb(255, 54, 70, 112), Color.FromArgb(255, 78, 57, 44), Color.FromArgb(255, 102, 83, 54), Color.FromArgb(255, 140, 122, 86), Color.FromArgb(255, 153, 153, 153), Color.FromArgb(255, 157, 157, 157), Color.FromArgb(255, 106, 105, 122), Color.FromArgb(255, 168, 139, 52), Color.FromArgb(255, 114, 37, 7), Color.FromArgb(255, 131, 94, 16), Color.FromArgb(255, 123, 125, 23), Color.FromArgb(255, 74, 104, 90), Color.FromArgb(255, 95, 93, 82), Color.FromArgb(107, 154, 154, 154), Color.FromArgb(255, 142, 101, 77), Color.FromArgb(255, 145, 130, 97),  },
            new Color[16]{ Color.FromArgb(255, 176, 148, 109), Color.FromArgb(255, 88, 109, 165), Color.FromArgb(255, 79, 127, 211), Color.FromArgb(255, 144, 122, 87), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 145, 125, 67), Color.FromArgb(255, 86, 67, 34), Color.FromArgb(255, 81, 77, 76), Color.FromArgb(255, 137, 119, 55), Color.FromArgb(255, 145, 116, 39), Color.FromArgb(255, 65, 61, 60), Color.FromArgb(255, 80, 61, 60), Color.FromArgb(255, 112, 89, 76), Color.FromArgb(255, 115, 89, 77), Color.FromArgb(255, 132, 81, 44),  },
            new Color[16]{ Color.FromArgb(255, 174, 146, 108), Color.FromArgb(255, 78, 65, 97), Color.FromArgb(255, 125, 67, 125), Color.FromArgb(255, 102, 93, 89), Color.FromArgb(255, 101, 101, 101), Color.FromArgb(255, 94, 94, 94), Color.FromArgb(255, 49, 35, 23), Color.FromArgb(255, 84, 58, 40), Color.FromArgb(255, 129, 175, 49), Color.FromArgb(255, 91, 136, 33), Color.FromArgb(255, 95, 133, 35), Color.FromArgb(255, 57, 112, 19), Color.FromArgb(177, 113, 211, 121), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 144, 116, 78), Color.FromArgb(255, 61, 108, 144), Color.FromArgb(255, 92, 72, 55), Color.FromArgb(255, 78, 44, 25), Color.FromArgb(255, 134, 81, 30), Color.FromArgb(255, 68, 73, 79), Color.FromArgb(255, 120, 101, 58), Color.FromArgb(255, 115, 92, 79), Color.FromArgb(255, 130, 112, 102), Color.FromArgb(255, 211, 219, 222), Color.FromArgb(255, 213, 220, 223), Color.FromArgb(255, 236, 241, 244), Color.FromArgb(255, 75, 83, 93), Color.FromArgb(255, 108, 95, 92), Color.FromArgb(146, 41, 93, 253), Color.FromArgb(146, 41, 93, 253),  },
            new Color[16]{ Color.FromArgb(255, 75, 86, 59), Color.FromArgb(255, 104, 102, 101), Color.FromArgb(255, 109, 47, 41), Color.FromArgb(255, 116, 58, 50), Color.FromArgb(255, 105, 56, 48), Color.FromArgb(255, 172, 144, 106), Color.FromArgb(255, 182, 153, 112), Color.FromArgb(255, 126, 104, 93), Color.FromArgb(255, 143, 125, 115), Color.FromArgb(255, 216, 222, 225), Color.FromArgb(255, 218, 225, 228), Color.FromArgb(255, 236, 241, 244), Color.FromArgb(255, 38, 45, 52), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 69, 69, 69), Color.FromArgb(255, 73, 73, 73), Color.FromArgb(255, 77, 77, 77), Color.FromArgb(255, 82, 82, 82), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 81, 81, 81), Color.FromArgb(255, 86, 86, 86), Color.FromArgb(255, 85, 85, 85), Color.FromArgb(255, 87, 87, 87), Color.FromArgb(255, 79, 79, 79), Color.FromArgb(255, 161, 133, 66), Color.FromArgb(255, 206, 211, 215), Color.FromArgb(255, 82, 91, 100), Color.FromArgb(255, 161, 133, 58), Color.FromArgb(255, 245, 65, 0), Color.FromArgb(255, 245, 65, 0),  },
            new Color[16]{ Color.FromArgb(255, 32, 33, 36), Color.FromArgb(255, 116, 117, 115), Color.FromArgb(255, 73, 54, 31), Color.FromArgb(255, 123, 123, 123), Color.FromArgb(255, 130, 130, 130), Color.FromArgb(255, 110, 104, 101), Color.FromArgb(255, 114, 109, 105), Color.FromArgb(255, 150, 118, 101), Color.FromArgb(255, 166, 130, 112), Color.FromArgb(255, 129, 175, 49), Color.FromArgb(255, 91, 136, 33), Color.FromArgb(255, 95, 133, 35), Color.FromArgb(255, 77, 100, 22), Color.FromArgb(255, 129, 104, 57), Color.FromArgb(255, 133, 115, 71), Color.FromArgb(255, 112, 120, 126),  },
            new Color[16]{ Color.FromArgb(255, 46, 47, 46), Color.FromArgb(255, 58, 85, 151), Color.FromArgb(255, 96, 73, 58), Color.FromArgb(255, 74, 131, 152), Color.FromArgb(255, 97, 98, 97), Color.FromArgb(255, 83, 107, 51), Color.FromArgb(255, 123, 150, 183), Color.FromArgb(255, 114, 166, 46), Color.FromArgb(255, 177, 117, 173), Color.FromArgb(255, 177, 129, 62), Color.FromArgb(255, 187, 147, 168), Color.FromArgb(255, 145, 90, 169), Color.FromArgb(255, 160, 67, 66), Color.FromArgb(255, 158, 158, 162), Color.FromArgb(255, 196, 196, 195), Color.FromArgb(255, 184, 184, 62),  },
            new Color[16]{ Color.FromArgb(255, 90, 74, 36), Color.FromArgb(255, 99, 103, 115), Color.FromArgb(255, 127, 95, 46), Color.FromArgb(255, 111, 136, 115), Color.FromArgb(255, 128, 112, 74), Color.FromArgb(255, 118, 119, 40), Color.FromArgb(255, 146, 151, 142), Color.FromArgb(255, 140, 164, 36), Color.FromArgb(255, 190, 126, 133), Color.FromArgb(255, 190, 135, 48), Color.FromArgb(255, 199, 149, 128), Color.FromArgb(255, 163, 107, 129), Color.FromArgb(255, 176, 90, 51), Color.FromArgb(255, 174, 158, 124), Color.FromArgb(255, 208, 192, 154), Color.FromArgb(255, 196, 180, 48),  },
            new Color[16]{ Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55), Color.FromArgb(255, 164, 132, 55),  },
            new Color[16]{ Color.FromArgb(255, 148, 148, 148), Color.FromArgb(255, 81, 84, 87), Color.FromArgb(255, 109, 69, 50), Color.FromArgb(255, 59, 43, 26), Color.FromArgb(255, 117, 106, 118), Color.FromArgb(255, 76, 89, 44), Color.FromArgb(255, 167, 139, 64), Color.FromArgb(255, 103, 91, 60), Color.FromArgb(255, 106, 68, 55), Color.FromArgb(255, 99, 80, 74), Color.FromArgb(255, 108, 71, 55), Color.FromArgb(255, 116, 116, 116), Color.FromArgb(255, 83, 83, 83), Color.FromArgb(255, 42, 126, 135), Color.FromArgb(255, 181, 125, 85), Color.FromArgb(255, 171, 115, 76),  },
            new Color[16]{ Color.FromArgb(255, 143, 143, 143), Color.FromArgb(255, 67, 69, 72), Color.FromArgb(255, 101, 64, 46), Color.FromArgb(255, 57, 42, 26), Color.FromArgb(255, 105, 107, 101), Color.FromArgb(255, 76, 104, 77), Color.FromArgb(255, 127, 103, 53), Color.FromArgb(255, 153, 131, 72), Color.FromArgb(255, 51, 40, 23), Color.FromArgb(255, 78, 75, 70), Color.FromArgb(255, 49, 37, 22), Color.FromArgb(255, 103, 103, 103), Color.FromArgb(255, 70, 70, 70), Color.FromArgb(255, 28, 91, 97), Color.FromArgb(255, 146, 85, 55), Color.FromArgb(255, 172, 117, 78),  },
            new Color[16]{ Color.FromArgb(255, 181, 144, 178), Color.FromArgb(255, 74, 105, 115), Color.FromArgb(255, 137, 154, 114), Color.FromArgb(255, 87, 94, 95), Color.FromArgb(255, 66, 76, 41), Color.FromArgb(255, 75, 107, 75), Color.FromArgb(255, 89, 95, 22), Color.FromArgb(255, 39, 61, 12), Color.FromArgb(255, 47, 31, 28), Color.FromArgb(255, 52, 34, 27), Color.FromArgb(255, 56, 36, 21), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 35, 149, 162), Color.FromArgb(255, 173, 118, 80), Color.FromArgb(255, 180, 122, 79),  },
            new Color[16]{ Color.FromArgb(255, 85, 52, 35), Color.FromArgb(255, 159, 131, 50), Color.FromArgb(255, 84, 73, 54), Color.FromArgb(255, 113, 99, 88), Color.FromArgb(255, 125, 137, 140), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(255, 153, 28, 7), Color.FromArgb(255, 176, 188, 196), Color.FromArgb(255, 138, 191, 198), Color.FromArgb(255, 66, 63, 57), Color.FromArgb(255, 136, 136, 136),  },
            new Color[16]{ Color.FromArgb(255, 89, 54, 36), Color.FromArgb(255, 159, 131, 50), Color.FromArgb(255, 75, 54, 27), Color.FromArgb(255, 118, 102, 91), Color.FromArgb(255, 122, 135, 138), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  },
            new Color[16]{ Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), Color.FromArgb(0, 0, 0, 0),  }
        };

        /// <summary>
        /// Acceder Y, luego X.
        /// </summary>
        internal static readonly Byte[][] Matriz_Xbox_IDs = new Byte[][]
        {
            /*new String[16]{ "grass_top", "stone", "dirt", "grass_side", "planks_oak", "stone_slab_side", "stone_slab_top", "brick", "tnt_side", "tnt_top", "tnt_bottom", "web", "flower_rose", "flower_dandelion", "portal", "sapling_oak" },
            new String[16]{ "cobblestone", "bedrock", "sand", "gravel", "log_oak", "log_oak_top", "iron_block", "gold_block", "diamond_block", "emerald_block", "redstone_block", "dropper_front_horizontal", "mushroom_red", "mushroom_brown", "sapling_jungle", "fire_layer_0" },
            new String[16]{ "gold_ore", "iron_ore", "coal_ore", "bookshelf", "cobblestone_mossy", "obsidian", "grass_side_overlay", "tallgrass", "dispenser_front_vertical", "beacon", "dropper_front_vertical", "crafting_table_top", "furnace_front_off", "furnace_side", "dispenser_front_horizontal", "fire_layer_0" },
            new String[16]{ "sponge", "glass", "diamond_ore", "redstone_ore", "leaves_oak", "leaves_oak", "stonebrick", "deadbush", "fern", "daylight_detector_top", "daylight_detector_side", "crafting_table_front", "crafting_table_side", "furnace_front_on", "furnace_top", "sapling_spruce" },
            new String[16]{ "wool_colored_white", "mob_spawner", "snow", "ice", "grass_side_snowed", "cactus_top", "cactus_side", "cactus_bottom", "clay", "reeds", "jukebox_side", "jukebox_top", "waterlily", "mycelium_side", "mycelium_top", "sapling_birch" },
            new String[16]{ "torch_on", "door_wood_upper", "door_iron_upper", "ladder", "trapdoor", "iron_bars", "farmland_wet", "farmland_dry", "wheat_stage_0", "wheat_stage_1", "wheat_stage_2", "wheat_stage_3", "wheat_stage_4", "wheat_stage_5", "wheat_stage_6", "wheat_stage_7" },
            new String[16]{ "lever", "door_wood_lower", "door_iron_lower", "redstone_torch_on", "stonebrick_mossy", "stonebrick_cracked", "pumpkin_top", "netherrack", "soul_sand", "glowstone", "piston_top_sticky", "piston_top_normal", "piston_side", "piston_bottom", "piston_inner", "pumpkin_stem_disconnected" },
            new String[16]{ "rail_normal_turned", "wool_colored_black", "wool_colored_gray", "redstone_torch_off", "log_spruce", "log_birch", "pumpkin_side", "pumpkin_face_off", "pumpkin_face_on", "cake_top", "cake_side", "cake_inner", "cake_bottom", "mushroom_block_skin_red", "mushroom_block_skin_brown", "pumpkin_stem_connected" },
            new String[16]{ "rail_normal", "wool_colored_red", "wool_colored_pink", "repeater_off", "leaves_spruce", "leaves_spruce", "bed_feet_top", "bed_head_top", "melon_side", "melon_top", "cauldron_top", "cauldron_inner", String.Empty, "mushroom_block_skin_stem", "mushroom_block_inside", "vine" },
            new String[16]{ "lapis_block", "wool_colored_green", "wool_colored_lime", "repeater_on", "glass_pane_top", "bed_feet_end", "bed_feet_side", "bed_head_side", "bed_head_end", "log_jungle", "cauldron_side", "cauldron_bottom", "brewing_stand_base", "brewing_stand", "endframe_top", "endframe_side" },
            new String[16]{ "lapis_ore", "wool_colored_brown", "wool_colored_yellow", "rail_golden", "redstone_dust_line0", "redstone_dust_line1", "enchanting_table_top", "dragon_egg", "cocoa_stage_2", "cocoa_stage_1", "cocoa_stage_0", "emerald_ore", "trip_wire_source", "trip_wire", "endframe_eye", "end_stone" },
            new String[16]{ "sandstone_top", "wool_colored_blue", "wool_colored_light_blue", "rail_golden_powered", "redstone_dust_overlay", "redstone_dust_overlay", "enchanting_table_side", "obsidian", "command_block_back", "itemframe_background", "flower_pot", "comparator_off", "comparator_on", "rail_activator", "rail_activator_powered", "quartz_ore" },
            new String[16]{ "sandstone_normal", "wool_colored_purple", "wool_colored_magenta", "rail_detector", "leaves_jungle", "leaves_jungle", "planks_spruce", "planks_jungle", "carrots_stage_0", "carrots_stage_1", "carrots_stage_2", "carrots_stage_3", "potatoes_stage_3", "water_flow", "water_flow", "water_flow" },
            new String[16]{ "sandstone_bottom", "wool_colored_cyan", "wool_colored_orange", "redstone_lamp_off", "redstone_lamp_on", "stonebrick_carved", "planks_birch", "anvil_base", "anvil_top_damaged_1", "quartz_block_chiseled_top", "quartz_block_lines_top", "quartz_block_top", "hopper_outside", "rail_detector_powered", "water_flow", "water_flow" },
            new String[16]{ "nether_brick", "wool_colored_silver", "nether_wart_stage_0", "nether_wart_stage_1", "nether_wart_stage_2", "sandstone_carved", "sandstone_smooth", "anvil_top_damaged_0", "anvil_top_damaged_2", "quartz_block_chiseled", "quartz_block_lines", "quartz_block_side", "hopper_inside", "lava_flow", "lava_flow", "lava_flow" },
            new String[16]{ "destroy_stage_0", "destroy_stage_1", "destroy_stage_2", "destroy_stage_3", "destroy_stage_4", "destroy_stage_5", "destroy_stage_6", "destroy_stage_7", "destroy_stage_8", "destroy_stage_9", String.Empty, "quartz_block_bottom", "hopper_top", String.Empty, "lava_flow", "lava_flow" },

            new String[16]{ "", "", "", String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, "potatoes_stage_0", "potatoes_stage_1", "potatoes_stage_2", "potatoes_stage_3", "", "", "" },
            new String[16]{ "hardened_clay_stained_black", "hardened_clay_stained_blue", "hardened_clay_stained_brown", "hardened_clay_stained_cyan", "hardened_clay_stained_gray", "hardened_clay_stained_green", "hardened_clay_stained_light_blue", "hardened_clay_stained_lime", "hardened_clay_stained_magenta", "hardened_clay_stained_orange", "hardened_clay_stained_pink", "hardened_clay_stained_purple", "hardened_clay_stained_red", "hardened_clay_stained_silver", "hardened_clay_stained_white", "hardened_clay_stained_yellow" },
            new String[16]{ "glass_black", "glass_blue", "glass_brown", "glass_cyan", "glass_gray", "glass_green", "glass_light_blue", "glass_lime", "glass_magenta", "glass_orange", "glass_pink", "glass_purple", "glass_red", "glass_silver", "glass_white", "glass_yellow" },
            new String[16]{ "glass_pane_top_black", "glass_pane_top_blue", "glass_pane_top_brown", "glass_pane_top_cyan", "glass_pane_top_gray", "glass_pane_top_green", "glass_pane_top_light_blue", "glass_pane_top_lime", "glass_pane_top_magenta", "glass_pane_top_orange", "glass_pane_top_pink", "glass_pane_top_purple", "glass_pane_top_red", "glass_pane_top_silver", "glass_pane_top_white", "glass_pane_top_yellow" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "sapling_acacia", "sapling_roofed_oak", String.Empty, String.Empty, String.Empty, "", "", String.Empty, String.Empty, String.Empty },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", String.Empty, String.Empty, String.Empty, "daylight_detector_inverted_top", "iron_trapdoor" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
            new String[16]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" },
        */};
        #region Lista_Sólo_Lectura_Nombres
        internal static readonly List<String> Lista_Sólo_Lectura_Nombres = new List<String>(new String[]
        {
            "anvil_base",
            "anvil_top_damaged_0",
            "anvil_top_damaged_1",
            "anvil_top_damaged_2",
            "beacon",
            "bed_feet_end",
            "bed_feet_side",
            "bed_feet_top",
            "bed_head_end",
            "bed_head_side",
            "bed_head_top",
            "bedrock",
            "beetroots_stage_0",
            "beetroots_stage_1",
            "beetroots_stage_2",
            "beetroots_stage_3",
            "bookshelf",
            "brewing_stand",
            "brewing_stand_base",
            "brick",
            "cactus_bottom",
            "cactus_side",
            "cactus_top",
            "cake_bottom",
            "cake_inner",
            "cake_side",
            "cake_top",
            "carrots_stage_0",
            "carrots_stage_1",
            "carrots_stage_2",
            "carrots_stage_3",
            "cauldron_bottom",
            "cauldron_inner",
            "cauldron_side",
            "cauldron_top",
            "chain_command_block_back",
            "chain_command_block_conditional",
            "chain_command_block_front",
            "chain_command_block_side",
            "chorus_flower",
            "chorus_flower_dead",
            "chorus_plant",
            "clay",
            "coal_block",
            "coal_ore",
            "coarse_dirt",
            "cobblestone",
            "cobblestone_mossy",
            "cocoa_stage_0",
            "cocoa_stage_1",
            "cocoa_stage_2",
            "command_block_back",
            "command_block_conditional",
            "command_block_front",
            "command_block_side",
            "comparator_off",
            "comparator_on",
            "crafting_table_front",
            "crafting_table_side",
            "crafting_table_top",
            "daylight_detector_inverted_top",
            "daylight_detector_side",
            "daylight_detector_top",
            "deadbush",
            "debug",
            "destroy_stage_0",
            "destroy_stage_1",
            "destroy_stage_2",
            "destroy_stage_3",
            "destroy_stage_4",
            "destroy_stage_5",
            "destroy_stage_6",
            "destroy_stage_7",
            "destroy_stage_8",
            "destroy_stage_9",
            "diamond_block",
            "diamond_ore",
            "dirt",
            "dirt_podzol_side",
            "dirt_podzol_top",
            "dispenser_front_horizontal",
            "dispenser_front_vertical",
            "door_acacia_lower",
            "door_acacia_upper",
            "door_birch_lower",
            "door_birch_upper",
            "door_dark_oak_lower",
            "door_dark_oak_upper",
            "door_iron_lower",
            "door_iron_upper",
            "door_jungle_lower",
            "door_jungle_upper",
            "door_spruce_lower",
            "door_spruce_upper",
            "door_wood_lower",
            "door_wood_upper",
            "double_plant_fern_bottom",
            "double_plant_fern_top",
            "double_plant_grass_bottom",
            "double_plant_grass_top",
            "double_plant_paeonia_bottom",
            "double_plant_paeonia_top",
            "double_plant_rose_bottom",
            "double_plant_rose_top",
            "double_plant_sunflower_back",
            "double_plant_sunflower_bottom",
            "double_plant_sunflower_front",
            "double_plant_sunflower_top",
            "double_plant_syringa_bottom",
            "double_plant_syringa_top",
            "dragon_egg",
            "dropper_front_horizontal",
            "dropper_front_vertical",
            "emerald_block",
            "emerald_ore",
            "enchanting_table_bottom",
            "enchanting_table_side",
            "enchanting_table_top",
            "end_bricks",
            "end_rod",
            "end_stone",
            "endframe_eye",
            "endframe_side",
            "endframe_top",
            "farmland_dry",
            "farmland_wet",
            "fern",
            "fire_layer_0",
            "fire_layer_1",
            "flower_allium",
            "flower_blue_orchid",
            "flower_dandelion",
            "flower_houstonia",
            "flower_oxeye_daisy",
            "flower_paeonia",
            "flower_pot",
            "flower_rose",
            "flower_tulip_orange",
            "flower_tulip_pink",
            "flower_tulip_red",
            "flower_tulip_white",
            "frosted_ice_0",
            "frosted_ice_1",
            "frosted_ice_2",
            "frosted_ice_3",
            "furnace_front_off",
            "furnace_front_on",
            "furnace_side",
            "furnace_top",
            "glass",
            "glass_black",
            "glass_blue",
            "glass_brown",
            "glass_cyan",
            "glass_gray",
            "glass_green",
            "glass_light_blue",
            "glass_lime",
            "glass_magenta",
            "glass_orange",
            "glass_pane_top",
            "glass_pane_top_black",
            "glass_pane_top_blue",
            "glass_pane_top_brown",
            "glass_pane_top_cyan",
            "glass_pane_top_gray",
            "glass_pane_top_green",
            "glass_pane_top_light_blue",
            "glass_pane_top_lime",
            "glass_pane_top_magenta",
            "glass_pane_top_orange",
            "glass_pane_top_pink",
            "glass_pane_top_purple",
            "glass_pane_top_red",
            "glass_pane_top_silver",
            "glass_pane_top_white",
            "glass_pane_top_yellow",
            "glass_pink",
            "glass_purple",
            "glass_red",
            "glass_silver",
            "glass_white",
            "glass_yellow",
            "glowstone",
            "gold_block",
            "gold_ore",
            "grass_path_side",
            "grass_path_top",
            "grass_side",
            "grass_side_overlay",
            "grass_side_snowed",
            "grass_top",
            "gravel",
            "hardened_clay",
            "hardened_clay_stained_black",
            "hardened_clay_stained_blue",
            "hardened_clay_stained_brown",
            "hardened_clay_stained_cyan",
            "hardened_clay_stained_gray",
            "hardened_clay_stained_green",
            "hardened_clay_stained_light_blue",
            "hardened_clay_stained_lime",
            "hardened_clay_stained_magenta",
            "hardened_clay_stained_orange",
            "hardened_clay_stained_pink",
            "hardened_clay_stained_purple",
            "hardened_clay_stained_red",
            "hardened_clay_stained_silver",
            "hardened_clay_stained_white",
            "hardened_clay_stained_yellow",
            "hay_block_side",
            "hay_block_top",
            "hopper_inside",
            "hopper_outside",
            "hopper_top",
            "ice",
            "ice_packed",
            "iron_bars",
            "iron_block",
            "iron_ore",
            "iron_trapdoor",
            "itemframe_background",
            "jukebox_side",
            "jukebox_top",
            "ladder",
            "lapis_block",
            "lapis_ore",
            "lava_flow",
            "lava_still",
            "leaves_acacia",
            "leaves_big_oak",
            "leaves_birch",
            "leaves_jungle",
            "leaves_oak",
            "leaves_spruce",
            "lever",
            "log_acacia",
            "log_acacia_top",
            "log_big_oak",
            "log_big_oak_top",
            "log_birch",
            "log_birch_top",
            "log_jungle",
            "log_jungle_top",
            "log_oak",
            "log_oak_top",
            "log_spruce",
            "log_spruce_top",
            "melon_side",
            "melon_stem_connected",
            "melon_stem_disconnected",
            "melon_top",
            "mob_spawner",
            "mushroom_block_inside",
            "mushroom_block_skin_brown",
            "mushroom_block_skin_red",
            "mushroom_block_skin_stem",
            "mushroom_brown",
            "mushroom_red",
            "mycelium_side",
            "mycelium_top",
            "nether_brick",
            "nether_wart_stage_0",
            "nether_wart_stage_1",
            "nether_wart_stage_2",
            "netherrack",
            "noteblock",
            "obsidian",
            "piston_bottom",
            "piston_inner",
            "piston_side",
            "piston_top_normal",
            "piston_top_sticky",
            "planks_acacia",
            "planks_big_oak",
            "planks_birch",
            "planks_jungle",
            "planks_oak",
            "planks_spruce",
            "portal",
            "potatoes_stage_0",
            "potatoes_stage_1",
            "potatoes_stage_2",
            "potatoes_stage_3",
            "prismarine_bricks",
            "prismarine_dark",
            "prismarine_rough",
            "pumpkin_face_off",
            "pumpkin_face_on",
            "pumpkin_side",
            "pumpkin_stem_connected",
            "pumpkin_stem_disconnected",
            "pumpkin_top",
            "purpur_block",
            "purpur_pillar",
            "purpur_pillar_top",
            "quartz_block_bottom",
            "quartz_block_chiseled",
            "quartz_block_chiseled_top",
            "quartz_block_lines",
            "quartz_block_lines_top",
            "quartz_block_side",
            "quartz_block_top",
            "quartz_ore",
            "rail_activator",
            "rail_activator_powered",
            "rail_detector",
            "rail_detector_powered",
            "rail_golden",
            "rail_golden_powered",
            "rail_normal",
            "rail_normal_turned",
            "red_sand",
            "red_sandstone_bottom",
            "red_sandstone_carved",
            "red_sandstone_normal",
            "red_sandstone_smooth",
            "red_sandstone_top",
            "redstone_block",
            "redstone_dust_dot",
            "redstone_dust_line0",
            "redstone_dust_line1",
            "redstone_dust_overlay",
            "redstone_lamp_off",
            "redstone_lamp_on",
            "redstone_ore",
            "redstone_torch_off",
            "redstone_torch_on",
            "reeds",
            "repeater_off",
            "repeater_on",
            "repeating_command_block_back",
            "repeating_command_block_conditional",
            "repeating_command_block_front",
            "repeating_command_block_side",
            "sand",
            "sandstone_bottom",
            "sandstone_carved",
            "sandstone_normal",
            "sandstone_smooth",
            "sandstone_top",
            "sapling_acacia",
            "sapling_birch",
            "sapling_jungle",
            "sapling_oak",
            "sapling_roofed_oak",
            "sapling_spruce",
            "sea_lantern",
            "slime",
            "snow",
            "soul_sand",
            "sponge",
            "sponge_wet",
            "stone",
            "stone_andesite",
            "stone_andesite_smooth",
            "stone_diorite",
            "stone_diorite_smooth",
            "stone_granite",
            "stone_granite_smooth",
            "stone_slab_side",
            "stone_slab_top",
            "stonebrick",
            "stonebrick_carved",
            "stonebrick_cracked",
            "stonebrick_mossy",
            "structure_block",
            "structure_block_corner",
            "structure_block_data",
            "structure_block_load",
            "structure_block_save",
            "tallgrass",
            "tnt_bottom",
            "tnt_side",
            "tnt_top",
            "torch_on",
            "trapdoor",
            "trip_wire",
            "trip_wire_source",
            "vine",
            "water_flow",
            "water_overlay",
            "water_still",
            "waterlily",
            "web",
            "wheat_stage_0",
            "wheat_stage_1",
            "wheat_stage_2",
            "wheat_stage_3",
            "wheat_stage_4",
            "wheat_stage_5",
            "wheat_stage_6",
            "wheat_stage_7",
            "wool_colored_black",
            "wool_colored_blue",
            "wool_colored_brown",
            "wool_colored_cyan",
            "wool_colored_gray",
            "wool_colored_green",
            "wool_colored_light_blue",
            "wool_colored_lime",
            "wool_colored_magenta",
            "wool_colored_orange",
            "wool_colored_pink",
            "wool_colored_purple",
            "wool_colored_red",
            "wool_colored_silver",
            "wool_colored_white",
            "wool_colored_yellow",
        });
        #endregion
        #region Lista_Sólo_Lectura_Colores
        internal static readonly List<Color> Lista_Sólo_Lectura_Colores = new List<Color>(new Color[]
        {
            Color.FromArgb(255, 64, 64, 64),
            Color.FromArgb(255, 64, 60, 60),
            Color.FromArgb(255, 64, 60, 60),
            Color.FromArgb(255, 64, 61, 61),
            Color.FromArgb(255, 122, 222, 216),
            Color.FromArgb(255, 130, 55, 30),
            Color.FromArgb(255, 129, 49, 28),
            Color.FromArgb(255, 143, 23, 23),
            Color.FromArgb(255, 177, 164, 145),
            Color.FromArgb(255, 152, 109, 92),
            Color.FromArgb(255, 177, 126, 126),
            Color.FromArgb(255, 86, 86, 86),
            Color.FromArgb(255, 1, 173, 16),
            Color.FromArgb(255, 1, 189, 15),
            Color.FromArgb(255, 1, 192, 16),
            Color.FromArgb(255, 88, 116, 56),
            Color.FromArgb(255, 111, 91, 61),
            Color.FromArgb(255, 129, 107, 84),
            Color.FromArgb(255, 107, 107, 107),
            Color.FromArgb(255, 147, 101, 89),
            Color.FromArgb(255, 170, 189, 127),
            Color.FromArgb(255, 14, 104, 25),
            Color.FromArgb(255, 13, 103, 24),
            Color.FromArgb(255, 178, 89, 36),
            Color.FromArgb(255, 123, 38, 5),
            Color.FromArgb(255, 189, 145, 122),
            Color.FromArgb(255, 229, 209, 210),
            Color.FromArgb(255, 1, 173, 16),
            Color.FromArgb(255, 1, 189, 15),
            Color.FromArgb(255, 1, 192, 16),
            Color.FromArgb(255, 28, 130, 3),
            Color.FromArgb(255, 44, 44, 44),
            Color.FromArgb(255, 56, 56, 56),
            Color.FromArgb(255, 62, 62, 62),
            Color.FromArgb(255, 71, 71, 71),
            Color.FromArgb(255, 129, 152, 143),
            Color.FromArgb(255, 129, 157, 145),
            Color.FromArgb(255, 131, 161, 148),
            Color.FromArgb(255, 130, 156, 145),
            Color.FromArgb(255, 136, 108, 136),
            Color.FromArgb(255, 99, 66, 97),
            Color.FromArgb(255, 97, 62, 97),
            Color.FromArgb(255, 159, 165, 177), // Clay
            Color.FromArgb(255, 19, 19, 19),
            Color.FromArgb(255, 116, 116, 116),
            Color.FromArgb(255, 120, 86, 60),
            Color.FromArgb(255, 124, 124, 124),
            Color.FromArgb(255, 106, 122, 106),
            Color.FromArgb(255, 139, 141, 65),
            Color.FromArgb(255, 138, 109, 52),
            Color.FromArgb(255, 148, 83, 32),
            Color.FromArgb(255, 166, 129, 111),
            Color.FromArgb(255, 170, 131, 110),
            Color.FromArgb(255, 174, 134, 111),
            Color.FromArgb(255, 169, 131, 111),
            Color.FromArgb(255, 157, 153, 152),
            Color.FromArgb(255, 167, 151, 150),
            Color.FromArgb(255, 120, 99, 67),
            Color.FromArgb(255, 123, 99, 62),
            Color.FromArgb(255, 111, 74, 44),
            Color.FromArgb(255, 109, 113, 118),
            Color.FromArgb(255, 67, 55, 35),
            Color.FromArgb(255, 134, 120, 99),
            Color.FromArgb(255, 124, 80, 26),
            Color.FromArgb(255, 145, 159, 163),
            Color.FromArgb(255, 110, 110, 110),
            Color.FromArgb(255, 101, 101, 101),
            Color.FromArgb(255, 100, 100, 100),
            Color.FromArgb(255, 103, 103, 103),
            Color.FromArgb(255, 104, 104, 104),
            Color.FromArgb(255, 104, 104, 104),
            Color.FromArgb(255, 103, 103, 103),
            Color.FromArgb(255, 104, 104, 104),
            Color.FromArgb(255, 104, 104, 104),
            Color.FromArgb(255, 103, 103, 103),
            Color.FromArgb(255, 103, 220, 214),
            Color.FromArgb(255, 130, 141, 145),
            Color.FromArgb(255, 135, 97, 67),
            Color.FromArgb(255, 123, 88, 58),
            Color.FromArgb(255, 91, 63, 29),
            Color.FromArgb(255, 120, 120, 120),
            Color.FromArgb(255, 88, 88, 88),
            Color.FromArgb(255, 156, 89, 55),
            Color.FromArgb(255, 162, 93, 59),
            Color.FromArgb(255, 206, 195, 144),
            Color.FromArgb(255, 221, 213, 179),
            Color.FromArgb(255, 66, 44, 24),
            Color.FromArgb(255, 70, 48, 25),
            Color.FromArgb(255, 164, 164, 164),
            Color.FromArgb(255, 187, 187, 187),
            Color.FromArgb(255, 152, 110, 79),
            Color.FromArgb(255, 158, 116, 85),
            Color.FromArgb(255, 98, 76, 50),
            Color.FromArgb(255, 97, 75, 49),
            Color.FromArgb(255, 135, 102, 51),
            Color.FromArgb(255, 136, 104, 52),
            Color.FromArgb(255, 124, 124, 124),
            Color.FromArgb(255, 126, 126, 126),
            Color.FromArgb(255, 141, 141, 141),
            Color.FromArgb(255, 147, 147, 147),
            Color.FromArgb(255, 36, 77, 39),
            Color.FromArgb(255, 140, 137, 150),
            Color.FromArgb(255, 79, 68, 4),
            Color.FromArgb(255, 124, 67, 9),
            Color.FromArgb(255, 64, 105, 42),
            Color.FromArgb(255, 65, 109, 43),
            Color.FromArgb(255, 235, 198, 33),
            Color.FromArgb(255, 68, 112, 45),
            Color.FromArgb(255, 145, 149, 137),
            Color.FromArgb(255, 150, 149, 144),
            Color.FromArgb(255, 13, 9, 16),
            Color.FromArgb(255, 120, 120, 120),
            Color.FromArgb(255, 89, 89, 89),
            Color.FromArgb(255, 82, 218, 118),
            Color.FromArgb(255, 111, 130, 117),
            Color.FromArgb(255, 19, 17, 28),
            Color.FromArgb(255, 37, 29, 33),
            Color.FromArgb(255, 100, 59, 53),
            Color.FromArgb(255, 226, 231, 171),
            Color.FromArgb(255, 221, 200, 207),
            Color.FromArgb(255, 222, 224, 166),
            Color.FromArgb(255, 41, 73, 67),
            Color.FromArgb(255, 154, 164, 126),
            Color.FromArgb(255, 95, 121, 99),
            Color.FromArgb(255, 116, 76, 46),
            Color.FromArgb(255, 76, 41, 14),
            Color.FromArgb(255, 72, 181, 24), // fern
            Color.FromArgb(255, 242, 145, 62),
            Color.FromArgb(255, 243, 153, 61),
            Color.FromArgb(255, 179, 143, 215),
            Color.FromArgb(255, 38, 153, 151),
            Color.FromArgb(255, 118, 164, 0),
            Color.FromArgb(255, 166, 193, 145),
            Color.FromArgb(255, 181, 199, 147),
            Color.FromArgb(255, 146, 138, 158),
            Color.FromArgb(255, 119, 66, 51),
            Color.FromArgb(255, 108, 64, 5),
            Color.FromArgb(255, 98, 135, 32),
            Color.FromArgb(255, 105, 151, 80),
            Color.FromArgb(255, 105, 137, 39),
            Color.FromArgb(255, 99, 154, 73),
            Color.FromArgb(159, 125, 173, 253),
            Color.FromArgb(159, 133, 176, 253),
            Color.FromArgb(159, 136, 181, 253),
            Color.FromArgb(159, 149, 187, 253),
            Color.FromArgb(255, 82, 82, 82),
            Color.FromArgb(255, 131, 108, 92),
            Color.FromArgb(255, 115, 115, 115),
            Color.FromArgb(255, 98, 98, 98),
            Color.FromArgb(255, 219, 241, 245),
            Color.FromArgb(123, 24, 24, 24),
            Color.FromArgb(123, 49, 74, 178),
            Color.FromArgb(123, 101, 74, 49),
            Color.FromArgb(123, 74, 126, 151),
            Color.FromArgb(123, 74, 74, 74),
            Color.FromArgb(123, 101, 126, 49),
            Color.FromArgb(123, 101, 151, 215),
            Color.FromArgb(123, 126, 203, 24),
            Color.FromArgb(123, 178, 74, 215),
            Color.FromArgb(123, 215, 126, 49),
            Color.FromArgb(255, 212, 240, 245),
            Color.FromArgb(230, 24, 24, 24),
            Color.FromArgb(230, 45, 73, 169),
            Color.FromArgb(230, 96, 73, 45),
            Color.FromArgb(230, 73, 120, 147),
            Color.FromArgb(230, 73, 73, 73),
            Color.FromArgb(230, 96, 120, 45),
            Color.FromArgb(230, 96, 147, 209),
            Color.FromArgb(230, 120, 196, 24),
            Color.FromArgb(230, 169, 73, 209),
            Color.FromArgb(230, 209, 120, 45),
            Color.FromArgb(230, 231, 120, 158),
            Color.FromArgb(230, 120, 58, 169),
            Color.FromArgb(230, 147, 45, 45),
            Color.FromArgb(230, 147, 147, 147),
            Color.FromArgb(230, 246, 246, 246),
            Color.FromArgb(230, 219, 219, 45),
            Color.FromArgb(123, 242, 126, 165),
            Color.FromArgb(123, 126, 62, 178),
            Color.FromArgb(123, 151, 49, 49),
            Color.FromArgb(123, 151, 151, 151),
            Color.FromArgb(123, 254, 254, 254),
            Color.FromArgb(123, 230, 230, 49),
            Color.FromArgb(255, 147, 121, 73),
            Color.FromArgb(255, 250, 237, 79),
            Color.FromArgb(255, 145, 141, 126),
            Color.FromArgb(255, 143, 106, 70),
            Color.FromArgb(255, 150, 125, 71),
            Color.FromArgb(255, 127, 108, 66),
            Color.FromArgb(255, 144, 144, 144),
            Color.FromArgb(255, 151, 124, 102),
            Color.FromArgb(255, 72, 181, 24), // grass_top
            Color.FromArgb(255, 127, 125, 123),
            Color.FromArgb(255, 151, 93, 66),
            Color.FromArgb(255, 36, 21, 14),
            Color.FromArgb(255, 74, 59, 91),
            Color.FromArgb(255, 76, 50, 35),
            Color.FromArgb(255, 87, 91, 91),
            Color.FromArgb(255, 57, 41, 35),
            Color.FromArgb(255, 76, 83, 41),
            Color.FromArgb(255, 113, 108, 138),
            Color.FromArgb(255, 103, 118, 52),
            Color.FromArgb(255, 150, 88, 109),
            Color.FromArgb(255, 162, 84, 37),
            Color.FromArgb(255, 162, 78, 78),
            Color.FromArgb(255, 118, 70, 86),
            Color.FromArgb(255, 143, 60, 46),
            Color.FromArgb(255, 135, 107, 97),
            Color.FromArgb(255, 210, 178, 161),
            Color.FromArgb(255, 187, 133, 34),
            Color.FromArgb(255, 159, 118, 18),
            Color.FromArgb(255, 169, 140, 16),
            Color.FromArgb(255, 56, 56, 56),
            Color.FromArgb(255, 63, 63, 63),
            Color.FromArgb(255, 67, 67, 67),
            Color.FromArgb(159, 125, 173, 253),
            Color.FromArgb(255, 165, 195, 246),
            Color.FromArgb(255, 111, 109, 107),
            Color.FromArgb(255, 220, 220, 220),
            Color.FromArgb(255, 136, 131, 127),
            Color.FromArgb(255, 200, 200, 200),
            Color.FromArgb(255, 120, 68, 44),
            Color.FromArgb(255, 102, 68, 51),
            Color.FromArgb(255, 109, 74, 55),
            Color.FromArgb(255, 122, 96, 53),
            Color.FromArgb(255, 39, 67, 138),
            Color.FromArgb(255, 104, 113, 135),
            Color.FromArgb(255, 208, 93, 21),
            Color.FromArgb(255, 254, 106, 24),
            Color.FromArgb(255, 116, 109, 28), // ¿leaves_acacia? // 136, 136, 136 // 98, 93, 24
            Color.FromArgb(255, 53, 104, 30), // ¿leaves_big_oak? // 136, 136, 136 // 50, 98, 29
            Color.FromArgb(255, 128, 167, 85), // leaves_birch
            Color.FromArgb(255, 27, 91, 9), // ¿leaves_jungle? // 146, 144, 135 // 35, 99, 2
            Color.FromArgb(255, 72, 181, 24), // leaves_oak
            Color.FromArgb(255, 97, 153, 97), // leaves_spruce
            Color.FromArgb(255, 107, 90, 65),
            Color.FromArgb(255, 106, 99, 90),
            Color.FromArgb(255, 155, 91, 64),
            Color.FromArgb(255, 52, 41, 23),
            Color.FromArgb(255, 79, 63, 41),
            Color.FromArgb(255, 228, 228, 222),
            Color.FromArgb(255, 186, 168, 124),
            Color.FromArgb(255, 87, 68, 27),
            Color.FromArgb(255, 155, 120, 74),
            Color.FromArgb(255, 103, 82, 50),
            Color.FromArgb(255, 156, 126, 78),
            Color.FromArgb(255, 46, 29, 12),
            Color.FromArgb(255, 105, 82, 48),
            Color.FromArgb(255, 142, 147, 36),
            Color.FromArgb(255, 140, 140, 140),
            Color.FromArgb(255, 155, 155, 155),
            Color.FromArgb(255, 152, 154, 36),
            Color.FromArgb(255, 26, 39, 49),
            Color.FromArgb(255, 203, 171, 121),
            Color.FromArgb(255, 142, 107, 83),
            Color.FromArgb(255, 181, 29, 27),
            Color.FromArgb(255, 208, 205, 194),
            Color.FromArgb(255, 139, 106, 84),
            Color.FromArgb(255, 197, 59, 62),
            Color.FromArgb(255, 115, 89, 75),
            Color.FromArgb(255, 112, 100, 105),
            Color.FromArgb(255, 45, 22, 26),
            Color.FromArgb(255, 108, 16, 31),
            Color.FromArgb(255, 109, 16, 24),
            Color.FromArgb(255, 113, 20, 18),
            Color.FromArgb(255, 114, 57, 55),
            Color.FromArgb(255, 102, 68, 51),
            Color.FromArgb(255, 20, 18, 30),
            Color.FromArgb(255, 98, 98, 98),
            Color.FromArgb(255, 98, 98, 98),
            Color.FromArgb(255, 108, 104, 97),
            Color.FromArgb(255, 155, 131, 92),
            Color.FromArgb(255, 143, 148, 102),
            Color.FromArgb(255, 170, 92, 51),
            Color.FromArgb(255, 61, 39, 18),
            Color.FromArgb(255, 196, 180, 123),
            Color.FromArgb(255, 155, 111, 78),
            Color.FromArgb(255, 158, 128, 79),
            Color.FromArgb(255, 104, 78, 47),
            Color.FromArgb(192, 91, 14, 192),
            Color.FromArgb(255, 1, 173, 16),
            Color.FromArgb(255, 1, 189, 15),
            Color.FromArgb(255, 1, 192, 16),
            Color.FromArgb(255, 44, 171, 37),
            Color.FromArgb(255, 101, 161, 144),
            Color.FromArgb(255, 60, 88, 75),
            Color.FromArgb(255, 108, 171, 152),
            Color.FromArgb(255, 146, 81, 13),
            Color.FromArgb(255, 187, 138, 30),
            Color.FromArgb(255, 198, 121, 24),
            Color.FromArgb(255, 140, 140, 140),
            Color.FromArgb(255, 155, 155, 155),
            Color.FromArgb(255, 194, 119, 22),
            Color.FromArgb(255, 167, 122, 167),
            Color.FromArgb(255, 170, 127, 170),
            Color.FromArgb(255, 171, 129, 171),
            Color.FromArgb(255, 232, 229, 220),
            Color.FromArgb(255, 232, 229, 221),
            Color.FromArgb(255, 232, 229, 220),
            Color.FromArgb(255, 232, 228, 220),
            Color.FromArgb(255, 233, 230, 222),
            Color.FromArgb(255, 237, 234, 227),
            Color.FromArgb(255, 237, 234, 227),
            Color.FromArgb(255, 129, 90, 85),
            Color.FromArgb(255, 106, 89, 77),
            Color.FromArgb(255, 143, 87, 76),
            Color.FromArgb(255, 122, 105, 93),
            Color.FromArgb(255, 139, 96, 84),
            Color.FromArgb(255, 135, 113, 77),
            Color.FromArgb(255, 156, 109, 75),
            Color.FromArgb(255, 122, 110, 91),
            Color.FromArgb(255, 121, 109, 89),
            Color.FromArgb(255, 170, 88, 32),
            Color.FromArgb(255, 163, 83, 28),
            Color.FromArgb(255, 163, 82, 28),
            Color.FromArgb(255, 166, 85, 29),
            Color.FromArgb(255, 168, 85, 30),
            Color.FromArgb(255, 167, 85, 30),
            Color.FromArgb(255, 173, 28, 9),
            Color.FromArgb(255, 242, 242, 242),
            Color.FromArgb(255, 241, 241, 241),
            Color.FromArgb(255, 241, 241, 241),
            Color.FromArgb(0, 0, 0, 0),
            Color.FromArgb(255, 74, 45, 28),
            Color.FromArgb(255, 125, 93, 58),
            Color.FromArgb(255, 133, 110, 110),
            Color.FromArgb(255, 94, 66, 40),
            Color.FromArgb(255, 172, 83, 47),
            Color.FromArgb(255, 149, 194, 102),
            Color.FromArgb(255, 152, 149, 149),
            Color.FromArgb(255, 161, 149, 149),
            Color.FromArgb(255, 123, 108, 164),
            Color.FromArgb(255, 123, 108, 170),
            Color.FromArgb(255, 126, 109, 173),
            Color.FromArgb(255, 125, 109, 169),
            Color.FromArgb(255, 220, 212, 160),
            Color.FromArgb(255, 213, 206, 149),
            Color.FromArgb(255, 216, 208, 155),
            Color.FromArgb(255, 217, 210, 158),
            Color.FromArgb(255, 220, 212, 162),
            Color.FromArgb(255, 219, 211, 159),
            Color.FromArgb(255, 115, 116, 20),
            Color.FromArgb(255, 121, 153, 88),
            Color.FromArgb(255, 49, 87, 19),
            Color.FromArgb(255, 74, 104, 38),
            Color.FromArgb(255, 59, 87, 28),
            Color.FromArgb(255, 52, 59, 35),
            Color.FromArgb(255, 175, 201, 192),
            Color.FromArgb(188, 119, 199, 100),
            Color.FromArgb(255, 240, 252, 252),
            Color.FromArgb(255, 85, 65, 52),
            Color.FromArgb(255, 195, 196, 85),
            Color.FromArgb(255, 161, 160, 63),
            Color.FromArgb(255, 125, 125, 125),
            Color.FromArgb(255, 131, 132, 132),
            Color.FromArgb(255, 133, 134, 135),
            Color.FromArgb(255, 181, 181, 184),
            Color.FromArgb(255, 184, 184, 187),
            Color.FromArgb(255, 154, 115, 100),
            Color.FromArgb(255, 160, 115, 99),
            Color.FromArgb(255, 167, 167, 167),
            Color.FromArgb(255, 160, 160, 160),
            Color.FromArgb(255, 122, 122, 122),
            Color.FromArgb(255, 119, 119, 119),
            Color.FromArgb(255, 119, 119, 119),
            Color.FromArgb(255, 115, 119, 107),
            Color.FromArgb(255, 51, 33, 37),
            Color.FromArgb(255, 55, 38, 42),
            Color.FromArgb(255, 66, 51, 54),
            Color.FromArgb(255, 62, 46, 49),
            Color.FromArgb(255, 56, 40, 43),
            Color.FromArgb(255, 72, 181, 24), // tallgrass
            Color.FromArgb(255, 171, 79, 56),
            Color.FromArgb(255, 173, 98, 80),
            Color.FromArgb(255, 135, 68, 52),
            Color.FromArgb(255, 134, 110, 63),
            Color.FromArgb(255, 127, 94, 46),
            Color.FromArgb(167, 128, 128, 128),
            Color.FromArgb(255, 139, 129, 114),
            Color.FromArgb(255, 75, 97, 51), // vine = 112 x3
            Color.FromArgb(176, 39, 72, 250),
            Color.FromArgb(179, 47, 65, 243),
            Color.FromArgb(180, 45, 66, 243),
            Color.FromArgb(255, 32, 128, 48), // waterlily
            Color.FromArgb(255, 220, 220, 220),
            Color.FromArgb(255, 1, 180, 18),
            Color.FromArgb(255, 22, 173, 16),
            Color.FromArgb(255, 33, 139, 12),
            Color.FromArgb(255, 42, 141, 9),
            Color.FromArgb(255, 50, 130, 8),
            Color.FromArgb(255, 69, 126, 8),
            Color.FromArgb(255, 83, 121, 7),
            Color.FromArgb(255, 90, 104, 8),
            Color.FromArgb(255, 26, 22, 22),
            Color.FromArgb(255, 46, 57, 142),
            Color.FromArgb(255, 79, 50, 31),
            Color.FromArgb(255, 46, 111, 137),
            Color.FromArgb(255, 64, 64, 64),
            Color.FromArgb(255, 53, 71, 27),
            Color.FromArgb(255, 107, 138, 202),
            Color.FromArgb(255, 66, 174, 56),
            Color.FromArgb(255, 180, 81, 189),
            Color.FromArgb(255, 219, 125, 63),
            Color.FromArgb(255, 209, 133, 153),
            Color.FromArgb(255, 127, 62, 182),
            Color.FromArgb(255, 151, 52, 48),
            Color.FromArgb(255, 155, 161, 161),
            Color.FromArgb(255, 222, 222, 222),
            Color.FromArgb(255, 178, 166, 39)
        });
        #endregion

        internal static List<List<Bitmap>> Lista_Bitmaps_ID_Data = new List<List<Bitmap>>(new List<Bitmap>[]
        {
            /*new List<Bitmap>(new Bitmap[] // ID = 0
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 1
            {
                Resources.blocks_32_stone,
                Resources.blocks_32_stone_granite,
                Resources.blocks_32_stone_granite_smooth,
                Resources.blocks_32_stone_diorite,
                Resources.blocks_32_stone_diorite_smooth,
                Resources.blocks_32_stone_andesite,
                Resources.blocks_32_stone_andesite_smooth,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 2
            {
                Resources.blocks_32_grass_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 3
            {
                Resources.blocks_32_dirt,
                Resources.blocks_32_coarse_dirt,
                Resources.blocks_32_dirt_podzol_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 4
            {
                Resources.blocks_32_cobblestone,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 5
            {
                Resources.blocks_32_planks_oak,
                Resources.blocks_32_planks_spruce,
                Resources.blocks_32_planks_birch,
                Resources.blocks_32_planks_jungle,
                Resources.blocks_32_planks_acacia,
                Resources.blocks_32_planks_big_oak,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 6
            {
                Resources.blocks_32_sapling_oak,
                Resources.blocks_32_sapling_spruce,
                Resources.blocks_32_sapling_birch,
                Resources.blocks_32_sapling_jungle,
                Resources.blocks_32_sapling_acacia,
                Resources.blocks_32_sapling_roofed_oak,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 7
            {
                Resources.blocks_32_bedrock,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 8
            {
                Resources.blocks_32_water_flow,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 9
            {
                Resources.blocks_32_water_still,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 10
            {
                Resources.blocks_32_lava_flow,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 11
            {
                Resources.blocks_32_lava_still,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 12
            {
                Resources.blocks_32_sand,
                Resources.blocks_32_red_sand,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 13
            {
                Resources.blocks_32_gravel,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 14
            {
                Resources.blocks_32_gold_ore,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 15
            {
                Resources.blocks_32_iron_ore,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 16
            {
                Resources.blocks_32_coal_ore,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 17
            {
                Resources.blocks_32_log_oak_top,
                Resources.blocks_32_log_spruce_top,
                Resources.blocks_32_log_birch_top,
                Resources.blocks_32_log_jungle_top,
                Resources.blocks_32_log_oak,
                Resources.blocks_32_log_jungle, //???...
            }),
            new List<Bitmap>(new Bitmap[] // ID = 18
            {
                Resources.blocks_32_leaves_oak,
                Resources.blocks_32_leaves_spruce,
                Resources.blocks_32_leaves_birch,
                Resources.blocks_32_leaves_jungle,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 19
            {
                Resources.blocks_32_sponge,
                Resources.blocks_32_sponge_wet,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 20
            {
                Resources.blocks_32_glass,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 21
            {
                Resources.blocks_32_lapis_ore,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 22
            {
                Resources.blocks_32_lapis_block,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 23
            {
                Resources.blocks_32_dispenser_front_vertical,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 24
            {
                Resources.blocks_32_sandstone_top,
                Resources.blocks_32_sandstone_carved,
                Resources.blocks_32_sandstone_smooth,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 25
            {
                Resources.blocks_32_noteblock,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 26
            {
                Resources.blocks_32_bed_head_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 27
            {
                Resources.blocks_32_rail_golden,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 28
            {
                Resources.blocks_32_rail_detector,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 29
            {
                Resources.blocks_32_piston_top_sticky,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 30
            {
                Resources.blocks_32_web,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 31
            {
                Resources.blocks_32_deadbush,
                Resources.blocks_32_tallgrass,
                Resources.blocks_32_fern,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 32
            {
                Resources.blocks_32_deadbush,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 33
            {
                Resources.blocks_32_piston_top_normal,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 34
            {
                Resources.blocks_32_piston_top_normal,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 35
            {
                Resources.blocks_32_wool_colored_white,
                Resources.blocks_32_wool_colored_orange,
                Resources.blocks_32_wool_colored_magenta,
                Resources.blocks_32_wool_colored_light_blue,
                Resources.blocks_32_wool_colored_yellow,
                Resources.blocks_32_wool_colored_lime,
                Resources.blocks_32_wool_colored_pink,
                Resources.blocks_32_wool_colored_gray,
                Resources.blocks_32_wool_colored_silver,
                Resources.blocks_32_wool_colored_cyan,
                Resources.blocks_32_wool_colored_purple,
                Resources.blocks_32_wool_colored_blue,
                Resources.blocks_32_wool_colored_brown,
                Resources.blocks_32_wool_colored_green,
                Resources.blocks_32_wool_colored_red,
                Resources.blocks_32_wool_colored_black,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 36
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 37
            {
                Resources.blocks_32_flower_dandelion,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 38
            {
                Resources.blocks_32_flower_rose,
                Resources.blocks_32_flower_blue_orchid,
                Resources.blocks_32_flower_allium,
                Resources.blocks_32_flower_houstonia,
                Resources.blocks_32_flower_tulip_red,
                Resources.blocks_32_flower_tulip_orange,
                Resources.blocks_32_flower_tulip_white,
                Resources.blocks_32_flower_tulip_pink,
                Resources.blocks_32_flower_oxeye_daisy,
                Resources.blocks_32_flower_paeonia,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 39
            {
                Resources.blocks_32_mushroom_brown,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 40
            {
                Resources.blocks_32_mushroom_red,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 41
            {
                Resources.blocks_32_gold_block,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 42
            {
                Resources.blocks_32_iron_block,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 43
            {
                Resources.blocks_32_stone_slab_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 44
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 45
            {
                Resources.blocks_32_brick,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 46
            {
                Resources.blocks_32_tnt_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 47
            {
                Resources.blocks_32_bookshelf,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 48
            {
                Resources.blocks_32_cobblestone_mossy,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 49
            {
                Resources.blocks_32_obsidian,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 50
            {
                Resources.blocks_32_torch_on,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 51
            {
                Resources.blocks_32_fire_layer_0,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 52
            {
                Resources.blocks_32_mob_spawner,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 53
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 54
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 55
            {
                Resources.blocks_32_redstone_dust_dot,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 56
            {
                Resources.blocks_32_diamond_ore,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 57
            {
                Resources.blocks_32_diamond_block,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 58
            {
                Resources.blocks_32_crafting_table_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 59
            {
                Resources.blocks_32_wheat_stage_7,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 60
            {
                Resources.blocks_32_farmland_wet,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 61
            {
                Resources.blocks_32_furnace_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 62
            {
                Resources.blocks_32_furnace_front_on,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 63
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 64
            {
                Resources.blocks_32_door_wood_upper,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 65
            {
                Resources.blocks_32_ladder,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 66
            {
                Resources.blocks_32_rail_normal,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 67
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 68
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 69
            {
                Resources.blocks_32_lever,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 70
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 71
            {
                Resources.blocks_32_door_iron_upper,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 72
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 73
            {
                Resources.blocks_32_redstone_ore,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 74
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 75
            {
                Resources.blocks_32_redstone_torch_off,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 76
            {
                Resources.blocks_32_redstone_torch_on,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 77
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 78
            {
                Resources.blocks_32_snow,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 79
            {
                Resources.blocks_32_ice,
                Resources.blocks_32_frosted_ice_3,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 80
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 81
            {
                Resources.blocks_32_cactus_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 82
            {
                Resources.blocks_32_clay,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 83
            {
                Resources.blocks_32_reeds,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 84
            {
                Resources.blocks_32_jukebox_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 85
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 86
            {
                Resources.blocks_32_pumpkin_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 87
            {
                Resources.blocks_32_netherrack,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 88
            {
                Resources.blocks_32_soul_sand,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 89
            {
                Resources.blocks_32_glowstone,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 90
            {
                Resources.blocks_32_portal,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 91
            {
                Resources.blocks_32_pumpkin_face_on,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 92
            {
                Resources.blocks_32_cake_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 93
            {
                Resources.blocks_32_repeater_off,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 94
            {
                Resources.blocks_32_repeater_on,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 95
            {
                Resources.blocks_32_glass_white,
                Resources.blocks_32_glass_orange,
                Resources.blocks_32_glass_magenta,
                Resources.blocks_32_glass_light_blue,
                Resources.blocks_32_glass_yellow,
                Resources.blocks_32_glass_lime,
                Resources.blocks_32_glass_pink,
                Resources.blocks_32_glass_gray,
                Resources.blocks_32_glass_silver,
                Resources.blocks_32_glass_cyan,
                Resources.blocks_32_glass_purple,
                Resources.blocks_32_glass_blue,
                Resources.blocks_32_glass_brown,
                Resources.blocks_32_glass_green,
                Resources.blocks_32_glass_red,
                Resources.blocks_32_glass_black,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 96
            {
                Resources.blocks_32_trapdoor,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 97
            {
                Resources.blocks_32_stone,
                Resources.blocks_32_cobblestone,
                Resources.blocks_32_stonebrick,
                Resources.blocks_32_stonebrick_mossy,
                Resources.blocks_32_stonebrick_cracked,
                Resources.blocks_32_stonebrick_carved,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 98
            {
                Resources.blocks_32_stonebrick,
                Resources.blocks_32_stonebrick_mossy,
                Resources.blocks_32_stonebrick_cracked,
                Resources.blocks_32_stonebrick_carved,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 99
            {
                Resources.blocks_32_mushroom_block_skin_brown,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 100
            {
                Resources.blocks_32_mushroom_block_skin_red,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 101
            {
                Resources.blocks_32_iron_bars,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 102
            {
                Resources.blocks_32_glass_pane_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 103
            {
                Resources.blocks_32_melon_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 104
            {
                Resources.blocks_32_pumpkin_stem_disconnected,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 105
            {
                Resources.blocks_32_melon_stem_disconnected,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 106
            {
                Resources.blocks_32_vine,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 107
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 108
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 109
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 110
            {
                Resources.blocks_32_mycelium_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 111
            {
                Resources.blocks_32_waterlily,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 112
            {
                Resources.blocks_32_nether_brick,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 113
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 114
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 115
            {
                Resources.blocks_32_nether_wart_stage_2,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 116
            {
                Resources.blocks_32_enchanting_table_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 117
            {
                Resources.blocks_32_brewing_stand,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 118
            {
                Resources.blocks_32_cauldron_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 119
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 120
            {
                Resources.blocks_32_endframe_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 121
            {
                Resources.blocks_32_end_stone,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 122
            {
                Resources.blocks_32_dragon_egg,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 123
            {
                Resources.blocks_32_redstone_lamp_off,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 124
            {
                Resources.blocks_32_redstone_lamp_on,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 125
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 126
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 127
            {
                Resources.blocks_32_cocoa_stage_2,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 128
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 129
            {
                Resources.blocks_32_emerald_ore,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 130
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 131
            {
                Resources.blocks_32_trip_wire_source,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 132
            {
                Resources.blocks_32_trip_wire,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 133
            {
                Resources.blocks_32_emerald_block,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 134
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 135
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 136
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 137
            {
                Resources.blocks_32_command_block_front,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 138
            {
                Resources.blocks_32_beacon,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 139
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 140
            {
                Resources.blocks_32_flower_pot,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 141
            {
                Resources.blocks_32_carrots_stage_3,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 142
            {
                Resources.blocks_32_potatoes_stage_3,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 143
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 144
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 145
            {
                Resources.blocks_32_anvil_base,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 146
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 147
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 148
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 149
            {
                Resources.blocks_32_comparator_off,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 150
            {
                Resources.blocks_32_comparator_on,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 151
            {
                Resources.blocks_32_daylight_detector_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 152
            {
                Resources.blocks_32_redstone_block,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 153
            {
                Resources.blocks_32_quartz_ore,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 154
            {
                Resources.blocks_32_hopper_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 155
            {
                Resources.blocks_32_quartz_block_top,
                Resources.blocks_32_quartz_block_chiseled_top,
                Resources.blocks_32_quartz_block_lines_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 156
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 157
            {
                Resources.blocks_32_rail_activator,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 158
            {
                Resources.blocks_32_dropper_front_vertical,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 159
            {
                Resources.blocks_32_hardened_clay_stained_white,
                Resources.blocks_32_hardened_clay_stained_orange,
                Resources.blocks_32_hardened_clay_stained_magenta,
                Resources.blocks_32_hardened_clay_stained_light_blue,
                Resources.blocks_32_hardened_clay_stained_yellow,
                Resources.blocks_32_hardened_clay_stained_lime,
                Resources.blocks_32_hardened_clay_stained_pink,
                Resources.blocks_32_hardened_clay_stained_gray,
                Resources.blocks_32_hardened_clay_stained_silver,
                Resources.blocks_32_hardened_clay_stained_cyan,
                Resources.blocks_32_hardened_clay_stained_purple,
                Resources.blocks_32_hardened_clay_stained_blue,
                Resources.blocks_32_hardened_clay_stained_brown,
                Resources.blocks_32_hardened_clay_stained_green,
                Resources.blocks_32_hardened_clay_stained_red,
                Resources.blocks_32_hardened_clay_stained_black,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 160
            {
                Resources.blocks_32_glass_pane_top_white,
                Resources.blocks_32_glass_pane_top_orange,
                Resources.blocks_32_glass_pane_top_magenta,
                Resources.blocks_32_glass_pane_top_light_blue,
                Resources.blocks_32_glass_pane_top_yellow,
                Resources.blocks_32_glass_pane_top_lime,
                Resources.blocks_32_glass_pane_top_pink,
                Resources.blocks_32_glass_pane_top_gray,
                Resources.blocks_32_glass_pane_top_silver,
                Resources.blocks_32_glass_pane_top_cyan,
                Resources.blocks_32_glass_pane_top_purple,
                Resources.blocks_32_glass_pane_top_blue,
                Resources.blocks_32_glass_pane_top_brown,
                Resources.blocks_32_glass_pane_top_green,
                Resources.blocks_32_glass_pane_top_red,
                Resources.blocks_32_glass_pane_top_black,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 161
            {
                Resources.blocks_32_leaves_acacia,
                Resources.blocks_32_leaves_big_oak,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 162
            {
                Resources.blocks_32_log_acacia_top,
                Resources.blocks_32_log_big_oak_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 163
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 164
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 165
            {
                Resources.blocks_32_slime,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 166
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 167
            {
                Resources.blocks_32_iron_trapdoor,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 168
            {
                Resources.blocks_32_prismarine_rough,
                Resources.blocks_32_prismarine_bricks,
                Resources.blocks_32_prismarine_dark,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 169
            {
                Resources.blocks_32_sea_lantern,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 170
            {
                Resources.blocks_32_hay_block_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 171
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 172
            {
                Resources.blocks_32_hardened_clay,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 173
            {
                Resources.blocks_32_coal_block,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 174
            {
                Resources.blocks_32_ice_packed,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 175
            {
                Resources.blocks_32_double_plant_sunflower_front,
                Resources.blocks_32_double_plant_syringa_top,
                Resources.blocks_32_double_plant_grass_top,
                Resources.blocks_32_double_plant_fern_top,
                Resources.blocks_32_double_plant_rose_top,
                Resources.blocks_32_double_plant_paeonia_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 176
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 177
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 178
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 179
            {
                Resources.blocks_32_red_sandstone_top,
                Resources.blocks_32_red_sandstone_carved,
                Resources.blocks_32_red_sandstone_smooth,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 180
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 181
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 182
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 183
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 184
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 185
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 186
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 187
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 188
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 189
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 190
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 191
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 192
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 193
            {
                Resources.blocks_32_door_spruce_upper,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 194
            {
                Resources.blocks_32_door_birch_upper,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 195
            {
                Resources.blocks_32_door_jungle_upper,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 196
            {
                Resources.blocks_32_door_acacia_upper,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 197
            {
                Resources.blocks_32_door_dark_oak_upper,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 198
            {
                Resources.blocks_32_end_rod,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 199
            {
                Resources.blocks_32_chorus_plant,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 200
            {
                Resources.blocks_32_chorus_flower,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 201
            {
                Resources.blocks_32_purpur_block,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 202
            {
                Resources.blocks_32_purpur_pillar_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 203
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 204
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 205
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 206
            {
                Resources.blocks_32_end_bricks,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 207
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 208
            {
                Resources.blocks_32_grass_path_top,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 209
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 210
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 211
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 212
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 213
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 214
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 215
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 216
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 217
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 218
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 219
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 220
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 221
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 222
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 223
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 224
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 225
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 226
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 227
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 228
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 229
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 230
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 231
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 232
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 233
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 234
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 235
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 236
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 237
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 238
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 239
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 240
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 241
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 242
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 243
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 244
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 245
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 246
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 247
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 248
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 249
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 250
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 251
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 252
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 253
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 254
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 255
            {
                Resources.blocks_32_structure_block,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 256
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 257
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 258
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 259
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 260
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 261
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 262
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 263
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 264
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 265
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 266
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 267
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 268
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 269
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 270
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 271
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 272
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 273
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 274
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 275
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 276
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 277
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 278
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 279
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 280
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 281
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 282
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 283
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 284
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 285
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 286
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 287
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 288
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 289
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 290
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 291
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 292
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 293
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 294
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 295
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 296
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 297
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 298
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 299
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 300
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 301
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 302
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 303
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 304
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 305
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 306
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 307
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 308
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 309
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 310
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 311
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 312
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 313
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 314
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 315
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 316
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 317
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 318
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 319
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 320
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 321
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 322
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 323
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 324
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 325
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 326
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 327
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 328
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 329
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 330
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 331
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 332
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 333
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 334
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 335
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 336
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 337
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 338
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 339
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 340
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 341
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 342
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 343
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 344
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 345
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 346
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 347
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 348
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 349
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 350
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 351
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 352
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 353
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 354
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 355
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 356
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 357
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 358
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 359
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 360
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 361
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 362
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 363
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 364
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 365
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 366
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 367
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 368
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 369
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 370
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 371
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 372
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 373
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 374
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 375
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 376
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 377
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 378
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 379
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 380
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 381
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 382
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 383
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 384
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 385
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 386
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 387
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 388
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 389
            {
                Resources.blocks_32_itemframe_background,
            }),
            new List<Bitmap>(new Bitmap[] // ID = 390
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 391
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 392
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 393
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 394
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 395
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 396
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 397
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 398
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 399
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 400
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 401
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 402
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 403
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 404
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 405
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 406
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 407
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 408
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 409
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 410
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 411
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 412
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 413
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 414
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 415
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 416
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 417
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 418
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 419
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 420
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 421
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 422
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 423
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 424
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 425
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 426
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 427
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 428
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 429
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 430
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 431
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 432
            {

            }),
            new List<Bitmap>(new Bitmap[] // ID = 433
            {

            }),*/
        });

        internal static List<List<Color>> Lista_Colores_ID_Data = new List<List<Color>>(new List<Color>[]
        {
            new List<Color>(new Color[] // ID = 0
            {

            }),
            new List<Color>(new Color[] // ID = 1
            {
                Color.FromArgb(255, 125, 125, 125), // Data = 0: "stone"
                Color.FromArgb(255, 154, 115, 100), // Data = 1: "stone_granite"
                Color.FromArgb(255, 160, 115, 99), // Data = 2: "stone_granite_smooth"
                Color.FromArgb(255, 181, 181, 184), // Data = 3: "stone_diorite"
                Color.FromArgb(255, 184, 184, 187), // Data = 4: "stone_diorite_smooth"
                Color.FromArgb(255, 131, 132, 132), // Data = 5: "stone_andesite"
                Color.FromArgb(255, 133, 134, 135), // Data = 6: "stone_andesite_smooth"
            }),
            new List<Color>(new Color[] // ID = 2
            {
                Color.FromArgb(255, 95, 156, 65), // Data = 0: "grass_top"
                //Color.FromArgb(255, 72, 181, 24), // Data = 0: "grass_top"
                //Color.FromArgb(255, 127, 108, 66), // Data = : "grass_side"
                //Color.FromArgb(255, 144, 144, 144), // Data = : "grass_side_overlay"
                //Color.FromArgb(255, 151, 124, 102), // Data = : "grass_side_snowed"
            }),
            new List<Color>(new Color[] // ID = 3
            {
                Color.FromArgb(255, 135, 97, 67), // Data = 0: "dirt"
                Color.FromArgb(255, 120, 86, 60), // Data = 1: "coarse_dirt"
                Color.FromArgb(255, 91, 63, 29), // Data = 2: "dirt_podzol_top"
                //Color.FromArgb(255, 123, 88, 58), // Data = 2: "dirt_podzol_side"
            }),
            new List<Color>(new Color[] // ID = 4
            {
                Color.FromArgb(255, 124, 124, 124), // Data = : "cobblestone"
            }),
            new List<Color>(new Color[] // ID = 5
            {
                Color.FromArgb(255, 158, 128, 79), // Data = 0: "planks_oak"
                Color.FromArgb(255, 104, 78, 47), // Data = 1: "planks_spruce"
                Color.FromArgb(255, 196, 180, 123), // Data = 2: "planks_birch"
                Color.FromArgb(255, 155, 111, 78), // Data = 3: "planks_jungle"
                Color.FromArgb(255, 170, 92, 51), // Data = 4: "planks_acacia"
                Color.FromArgb(255, 61, 39, 18), // Data = 5: "planks_big_oak"
            }),
            new List<Color>(new Color[] // ID = 6
            {
                Color.FromArgb(255, 74, 104, 38), // Data = 0: "sapling_oak"
                Color.FromArgb(255, 52, 59, 35), // Data = 1: "sapling_spruce"
                Color.FromArgb(255, 121, 153, 88), // Data = 2: "sapling_birch"
                Color.FromArgb(255, 49, 87, 19), // Data = 3: "sapling_jungle"
                Color.FromArgb(255, 115, 116, 20), // Data = 4: "sapling_acacia"
                Color.FromArgb(255, 59, 87, 28), // Data = 5: "sapling_roofed_oak"
            }),
            new List<Color>(new Color[] // ID = 7
            {
                Color.FromArgb(255, 86, 86, 86), // Data = : "bedrock"
            }),
            new List<Color>(new Color[] // ID = 8
            {
                Color.FromArgb(176, 39, 72, 250), // Data = 0: "water_flow"
                //Color.FromArgb(179, 47, 65, 243), // Data = : "water_overlay"
            }),
            new List<Color>(new Color[] // ID = 9
            {
                Color.FromArgb(180, 45, 66, 243), // Data = : "water_still"
            }),
            new List<Color>(new Color[] // ID = 10
            {
                Color.FromArgb(255, 208, 93, 21), // Data = : "lava_flow"
            }),
            new List<Color>(new Color[] // ID = 11
            {
                Color.FromArgb(255, 254, 106, 24), // Data = : "lava_still"
            }),
            new List<Color>(new Color[] // ID = 12
            {
                Color.FromArgb(255, 220, 212, 160), // Data = 0: "sand"
                Color.FromArgb(255, 170, 88, 32), // Data = 1: "red_sand"
            }),
            new List<Color>(new Color[] // ID = 13
            {
                Color.FromArgb(255, 127, 125, 123), // Data = : "gravel"
            }),
            new List<Color>(new Color[] // ID = 14
            {
                Color.FromArgb(255, 145, 141, 126), // Data = : "gold_ore"
            }),
            new List<Color>(new Color[] // ID = 15
            {
                Color.FromArgb(255, 136, 131, 127), // Data = : "iron_ore"
            }),
            new List<Color>(new Color[] // ID = 16
            {
                Color.FromArgb(255, 116, 116, 116), // Data = : "coal_ore"
            }),
            new List<Color>(new Color[] // ID = 17
            {
                Color.FromArgb(255, 156, 126, 78), // Data = 0: "log_oak_top"
                Color.FromArgb(255, 105, 82, 48), // Data = 1: "log_spruce_top"
                Color.FromArgb(255, 186, 168, 124), // Data = 2: "log_birch_top"
                Color.FromArgb(255, 155, 120, 74), // Data = 3: "log_jungle_top"
                Color.FromArgb(255, 103, 82, 50), // Data = 4: "log_oak"
                Color.FromArgb(255, 87, 68, 27), // Data = 5: "log_jungle" ???...
                //Color.FromArgb(255, 103, 82, 50), // Data = : "log_oak"
                //Color.FromArgb(255, 46, 29, 12), // Data = : "log_spruce"
                //Color.FromArgb(255, 228, 228, 222), // Data = : "log_birch"
                //Color.FromArgb(255, 87, 68, 27), // Data = : "log_jungle"
                //Color.FromArgb(255, 106, 99, 90), // Data = : "log_acacia"
                //Color.FromArgb(255, 52, 41, 23), // Data = : "log_big_oak"
            }),
            new List<Color>(new Color[] // ID = 18
            {
                Color.FromArgb(255, 72, 181, 24), // Data = 0: "leaves_oak"
                Color.FromArgb(255, 97, 153, 97), // Data = 1: "leaves_spruce"
                Color.FromArgb(255, 128, 167, 85), // Data = 2: "leaves_birch"
                Color.FromArgb(255, 59, 143, 65), // Data = 3: "leaves_jungle"
                //Color.FromArgb(255, 146, 144, 135), // Data = 3: "leaves_jungle"
            }),
            new List<Color>(new Color[] // ID = 19
            {
                Color.FromArgb(255, 195, 196, 85), // Data = 0: "sponge"
                Color.FromArgb(255, 161, 160, 63), // Data = 1: "sponge_wet"
            }),
            new List<Color>(new Color[] // ID = 20
            {
                Color.FromArgb(255, 219, 241, 245), // Data = : "glass"
            }),
            new List<Color>(new Color[] // ID = 21
            {
                Color.FromArgb(255, 104, 113, 135), // Data = : "lapis_ore"
            }),
            new List<Color>(new Color[] // ID = 22
            {
                Color.FromArgb(255, 39, 67, 138), // Data = : "lapis_block"
            }),
            new List<Color>(new Color[] // ID = 23
            {
                Color.FromArgb(255, 88, 88, 88), // Data = 0: "dispenser_front_vertical"
                //Color.FromArgb(255, 120, 120, 120), // Data = : "dispenser_front_horizontal"
            }),
            new List<Color>(new Color[] // ID = 24
            {
                Color.FromArgb(255, 219, 211, 159), // Data = 0: "sandstone_top"
                Color.FromArgb(255, 216, 208, 155), // Data = 1: "sandstone_carved"
                Color.FromArgb(255, 220, 212, 162), // Data = 2: "sandstone_smooth"
                //Color.FromArgb(255, 213, 206, 149), // Data = : "sandstone_bottom"
                //Color.FromArgb(255, 217, 210, 158), // Data = : "sandstone_normal"
            }),
            new List<Color>(new Color[] // ID = 25
            {
                Color.FromArgb(255, 102, 68, 51), // Data = : "noteblock"
            }),
            new List<Color>(new Color[] // ID = 26
            {
                Color.FromArgb(255, 177, 126, 126), // Data = 0: "bed_head_top"
                //Color.FromArgb(255, 130, 55, 30), // Data = : "bed_feet_end"
                //Color.FromArgb(255, 129, 49, 28), // Data = : "bed_feet_side"
                //Color.FromArgb(255, 143, 23, 23), // Data = : "bed_feet_top"
                //Color.FromArgb(255, 177, 164, 145), // Data = : "bed_head_end"
                //Color.FromArgb(255, 152, 109, 92), // Data = : "bed_head_side"
            }),
            new List<Color>(new Color[] // ID = 27
            {
                Color.FromArgb(255, 135, 113, 77), // Data = 0: "rail_golden"
                //Color.FromArgb(255, 156, 109, 75), // Data = : "rail_golden_powered"
            }),
            new List<Color>(new Color[] // ID = 28
            {
                Color.FromArgb(255, 122, 105, 93), // Data = 0: "rail_detector"
                //Color.FromArgb(255, 139, 96, 84), // Data = : "rail_detector_powered"
            }),
            new List<Color>(new Color[] // ID = 29
            {
                Color.FromArgb(255, 143, 148, 102), // Data = : "piston_top_sticky"
            }),
            new List<Color>(new Color[] // ID = 30
            {
                Color.FromArgb(255, 220, 220, 220), // Data = : "web"
            }),
            new List<Color>(new Color[] // ID = 31
            {
                Color.FromArgb(255, 72, 181, 24),
                //Color.FromArgb(255, 124, 80, 26), // Data = 0: "deadbush"
                Color.FromArgb(255, 72, 181, 24), // Data = 1: "tallgrass"
                Color.FromArgb(255, 72, 181, 24), // Data = 2: "fern"
            }),
            new List<Color>(new Color[] // ID = 32
            {
                Color.FromArgb(255, 124, 80, 26), // Data = : "deadbush"
            }),
            new List<Color>(new Color[] // ID = 33
            {
                Color.FromArgb(255, 155, 131, 92), // Data = 0: "piston_top_normal"
                //Color.FromArgb(255, 98, 98, 98), // Data = : "piston_bottom"
                //Color.FromArgb(255, 98, 98, 98), // Data = : "piston_inner"
                //Color.FromArgb(255, 108, 104, 97), // Data = : "piston_side"
            }),
            new List<Color>(new Color[] // ID = 34
            {
                Color.FromArgb(255, 155, 131, 92), // Data = : "piston_top_normal"
            }),
            new List<Color>(new Color[] // ID = 35
            {
                Color.FromArgb(255, 222, 222, 222), // Data = 0: "wool_colored_white"
                Color.FromArgb(255, 219, 125, 63), // Data = 1: "wool_colored_orange"
                Color.FromArgb(255, 180, 81, 189), // Data = 2: "wool_colored_magenta"
                Color.FromArgb(255, 107, 138, 202), // Data = 3: "wool_colored_light_blue"
                Color.FromArgb(255, 178, 166, 39), // Data = 4: "wool_colored_yellow"
                Color.FromArgb(255, 66, 174, 56), // Data = 5: "wool_colored_lime"
                Color.FromArgb(255, 209, 133, 153), // Data = 6: "wool_colored_pink"
                Color.FromArgb(255, 64, 64, 64), // Data = 7: "wool_colored_gray"
                Color.FromArgb(255, 155, 161, 161), // Data = 8: "wool_colored_silver"
                Color.FromArgb(255, 46, 111, 137), // Data = 9: "wool_colored_cyan"
                Color.FromArgb(255, 127, 62, 182), // Data = 10: "wool_colored_purple"
                Color.FromArgb(255, 46, 57, 142), // Data = 11: "wool_colored_blue"
                Color.FromArgb(255, 79, 50, 31), // Data = 12: "wool_colored_brown"
                Color.FromArgb(255, 53, 71, 27), // Data = 13: "wool_colored_green"
                Color.FromArgb(255, 151, 52, 48), // Data = 14: "wool_colored_red"
                Color.FromArgb(255, 26, 22, 22), // Data = 15: "wool_colored_black"
            }),
            new List<Color>(new Color[] // ID = 36
            {

            }),
            new List<Color>(new Color[] // ID = 37
            {
                Color.FromArgb(255, 118, 164, 0), // Data = : "flower_dandelion"
            }),
            new List<Color>(new Color[] // ID = 38
            {
                Color.FromArgb(255, 108, 64, 5), // Data = 0: "flower_rose"
                Color.FromArgb(255, 38, 153, 151), // Data = 1: "flower_blue_orchid"
                Color.FromArgb(255, 179, 143, 215), // Data = 2: "flower_allium"
                Color.FromArgb(255, 166, 193, 145), // Data = 3: "flower_houstonia"
                Color.FromArgb(255, 105, 137, 39), // Data = 4: "flower_tulip_red"
                Color.FromArgb(255, 98, 135, 32), // Data = 5: "flower_tulip_orange"
                Color.FromArgb(255, 99, 154, 73), // Data = 6: "flower_tulip_white"
                Color.FromArgb(255, 105, 151, 80), // Data = 7: "flower_tulip_pink"
                Color.FromArgb(255, 181, 199, 147), // Data = 8: "flower_oxeye_daisy"
                Color.FromArgb(255, 146, 138, 158), // Data = ?: "flower_paeonia"
            }),
            new List<Color>(new Color[] // ID = 39
            {
                Color.FromArgb(255, 139, 106, 84), // Data = : "mushroom_brown"
            }),
            new List<Color>(new Color[] // ID = 40
            {
                Color.FromArgb(255, 197, 59, 62), // Data = : "mushroom_red"
            }),
            new List<Color>(new Color[] // ID = 41
            {
                Color.FromArgb(255, 250, 237, 79), // Data = : "gold_block"
            }),
            new List<Color>(new Color[] // ID = 42
            {
                Color.FromArgb(255, 220, 220, 220), // Data = : "iron_block"
            }),
            new List<Color>(new Color[] // ID = 43
            {
                Color.FromArgb(255, 160, 160, 160), // Data = 0: "stone_slab_top"
                //Color.FromArgb(255, 167, 167, 167), // Data = : "stone_slab_side"
            }),
            new List<Color>(new Color[] // ID = 44
            {

            }),
            new List<Color>(new Color[] // ID = 45
            {
                Color.FromArgb(255, 147, 101, 89), // Data = : "brick"
            }),
            new List<Color>(new Color[] // ID = 46
            {
                Color.FromArgb(255, 135, 68, 52), // Data = 0: "tnt_top"
                //Color.FromArgb(255, 171, 79, 56), // Data = : "tnt_bottom"
                //Color.FromArgb(255, 173, 98, 80), // Data = : "tnt_side"
            }),
            new List<Color>(new Color[] // ID = 47
            {
                Color.FromArgb(255, 111, 91, 61), // Data = : "bookshelf"
            }),
            new List<Color>(new Color[] // ID = 48
            {
                Color.FromArgb(255, 106, 122, 106), // Data = : "cobblestone_mossy"
            }),
            new List<Color>(new Color[] // ID = 49
            {
                Color.FromArgb(255, 20, 18, 30), // Data = : "obsidian"
            }),
            new List<Color>(new Color[] // ID = 50
            {
                Color.FromArgb(255, 134, 110, 63), // Data = : "torch_on"
            }),
            new List<Color>(new Color[] // ID = 51
            {
                Color.FromArgb(255, 242, 145, 62), // Data = 0: "fire_layer_0"
                //Color.FromArgb(255, 243, 153, 61), // Data = : "fire_layer_1"
            }),
            new List<Color>(new Color[] // ID = 52
            {
                Color.FromArgb(255, 26, 39, 49), // Data = : "mob_spawner"
            }),
            new List<Color>(new Color[] // ID = 53
            {

            }),
            new List<Color>(new Color[] // ID = 54
            {

            }),
            new List<Color>(new Color[] // ID = 55
            {
                Color.FromArgb(255, 235, 35, 35), // Data = 0: "redstone_dust_dot"
                //Color.FromArgb(255, 241, 241, 241), // Data = : "redstone_dust_line0"
                //Color.FromArgb(255, 241, 241, 241), // Data = : "redstone_dust_line1"
                //Color.FromArgb(0, 0, 0, 0), // Data = : "redstone_dust_overlay"
            }),
            new List<Color>(new Color[] // ID = 56
            {
                Color.FromArgb(255, 130, 141, 145), // Data = : "diamond_ore"
            }),
            new List<Color>(new Color[] // ID = 57
            {
                Color.FromArgb(255, 103, 220, 214), // Data = : "diamond_block"
            }),
            new List<Color>(new Color[] // ID = 58
            {
                Color.FromArgb(255, 111, 74, 44), // Data = 0: "crafting_table_top"
                //Color.FromArgb(255, 120, 99, 67), // Data = : "crafting_table_front"
                //Color.FromArgb(255, 123, 99, 62), // Data = : "crafting_table_side"
            }),
            new List<Color>(new Color[] // ID = 59
            {
                Color.FromArgb(255, 90, 104, 8), // Data = 0: "wheat_stage_7"
                //Color.FromArgb(255, 1, 180, 18), // Data = : "wheat_stage_0"
                //Color.FromArgb(255, 22, 173, 16), // Data = : "wheat_stage_1"
                //Color.FromArgb(255, 33, 139, 12), // Data = : "wheat_stage_2"
                //Color.FromArgb(255, 42, 141, 9), // Data = : "wheat_stage_3"
                //Color.FromArgb(255, 50, 130, 8), // Data = : "wheat_stage_4"
                //Color.FromArgb(255, 69, 126, 8), // Data = : "wheat_stage_5"
                //Color.FromArgb(255, 83, 121, 7), // Data = : "wheat_stage_6"
            }),
            new List<Color>(new Color[] // ID = 60
            {
                Color.FromArgb(255, 76, 41, 14), // Data = 0: "farmland_wet"
                //Color.FromArgb(255, 116, 76, 46), // Data = : "farmland_dry"
            }),
            new List<Color>(new Color[] // ID = 61
            {
                Color.FromArgb(255, 98, 98, 98), // Data = 0: "furnace_top"
                //Color.FromArgb(255, 82, 82, 82), // Data = : "furnace_front_off"
                //Color.FromArgb(255, 115, 115, 115), // Data = : "furnace_side"
            }),
            new List<Color>(new Color[] // ID = 62
            {
                Color.FromArgb(255, 131, 108, 92), // Data = : "furnace_front_on"
            }),
            new List<Color>(new Color[] // ID = 63
            {

            }),
            new List<Color>(new Color[] // ID = 64
            {
                Color.FromArgb(255, 136, 104, 52), // Data = 0: "door_wood_upper"
                //Color.FromArgb(255, 135, 102, 51), // Data = : "door_wood_lower"
            }),
            new List<Color>(new Color[] // ID = 65
            {
                Color.FromArgb(255, 122, 96, 53), // Data = : "ladder"
            }),
            new List<Color>(new Color[] // ID = 66
            {
                Color.FromArgb(255, 122, 110, 91), // Data = 0: "rail_normal"
                //Color.FromArgb(255, 121, 109, 89), // Data = : "rail_normal_turned"
            }),
            new List<Color>(new Color[] // ID = 67
            {

            }),
            new List<Color>(new Color[] // ID = 68
            {

            }),
            new List<Color>(new Color[] // ID = 69
            {
                Color.FromArgb(255, 107, 90, 65), // Data = : "lever"
            }),
            new List<Color>(new Color[] // ID = 70
            {

            }),
            new List<Color>(new Color[] // ID = 71
            {
                Color.FromArgb(255, 187, 187, 187), // Data = 0: "door_iron_upper"
                //Color.FromArgb(255, 164, 164, 164), // Data = : "door_iron_lower"
            }),
            new List<Color>(new Color[] // ID = 72
            {

            }),
            new List<Color>(new Color[] // ID = 73
            {
                Color.FromArgb(255, 133, 110, 110), // Data = : "redstone_ore"
            }),
            new List<Color>(new Color[] // ID = 74
            {

            }),
            new List<Color>(new Color[] // ID = 75
            {
                Color.FromArgb(255, 94, 66, 40), // Data = : "redstone_torch_off"
            }),
            new List<Color>(new Color[] // ID = 76
            {
                Color.FromArgb(255, 172, 83, 47), // Data = : "redstone_torch_on"
            }),
            new List<Color>(new Color[] // ID = 77
            {

            }),
            new List<Color>(new Color[] // ID = 78
            {
                Color.FromArgb(255, 240, 252, 252), // Data = : "snow"
            }),
            new List<Color>(new Color[] // ID = 79
            {
                Color.FromArgb(159, 125, 173, 253), // Data = 0: "ice"
                Color.FromArgb(159, 149, 187, 253), // Data = 1: "frosted_ice_3"
                //Color.FromArgb(159, 125, 173, 253), // Data = : "frosted_ice_0"
                //Color.FromArgb(159, 133, 176, 253), // Data = : "frosted_ice_1"
                //Color.FromArgb(159, 136, 181, 253), // Data = : "frosted_ice_2"
            }),
            new List<Color>(new Color[] // ID = 80
            {

            }),
            new List<Color>(new Color[] // ID = 81
            {
                Color.FromArgb(255, 13, 103, 24), // Data = 0: "cactus_top"
                //Color.FromArgb(255, 170, 189, 127), // Data = : "cactus_bottom"
                //Color.FromArgb(255, 14, 104, 25), // Data = : "cactus_side"
            }),
            new List<Color>(new Color[] // ID = 82
            {
                Color.FromArgb(255, 159, 165, 177), // Data = : "clay"
            }),
            new List<Color>(new Color[] // ID = 83
            {
                Color.FromArgb(255, 149, 194, 102), // Data = : "reeds"
            }),
            new List<Color>(new Color[] // ID = 84
            {
                Color.FromArgb(255, 109, 74, 55), // Data = 0: "jukebox_top"
                //Color.FromArgb(255, 102, 68, 51), // Data = : "jukebox_side"
            }),
            new List<Color>(new Color[] // ID = 85
            {

            }),
            new List<Color>(new Color[] // ID = 86
            {
                Color.FromArgb(255, 194, 119, 22), // Data = 0: "pumpkin_top"
                //Color.FromArgb(255, 146, 81, 13), // Data = : "pumpkin_face_off"
                //Color.FromArgb(255, 198, 121, 24), // Data = : "pumpkin_side"
            }),
            new List<Color>(new Color[] // ID = 87
            {
                Color.FromArgb(255, 114, 57, 55), // Data = : "netherrack"
            }),
            new List<Color>(new Color[] // ID = 88
            {
                Color.FromArgb(255, 85, 65, 52), // Data = : "soul_sand"
            }),
            new List<Color>(new Color[] // ID = 89
            {
                Color.FromArgb(255, 147, 121, 73), // Data = : "glowstone"
            }),
            new List<Color>(new Color[] // ID = 90
            {
                Color.FromArgb(192, 91, 14, 192), // Data = : "portal"
            }),
            new List<Color>(new Color[] // ID = 91
            {
                Color.FromArgb(255, 187, 138, 30), // Data = : "pumpkin_face_on"
            }),
            new List<Color>(new Color[] // ID = 92
            {
                Color.FromArgb(255, 229, 209, 210), // Data = 0: "cake_top"
                //Color.FromArgb(255, 178, 89, 36), // Data = : "cake_bottom"
                //Color.FromArgb(255, 123, 38, 5), // Data = : "cake_inner"
                //Color.FromArgb(255, 189, 145, 122), // Data = : "cake_side"
            }),
            new List<Color>(new Color[] // ID = 93
            {
                Color.FromArgb(255, 152, 149, 149), // Data = : "repeater_off"
            }),
            new List<Color>(new Color[] // ID = 94
            {
                Color.FromArgb(255, 161, 149, 149), // Data = : "repeater_on"
            }),
            new List<Color>(new Color[] // ID = 95
            {
                Color.FromArgb(123, 254, 254, 254), // Data = 0: "glass_white"
                Color.FromArgb(123, 215, 126, 49), // Data = 1: "glass_orange"
                Color.FromArgb(123, 178, 74, 215), // Data = 2: "glass_magenta"
                Color.FromArgb(123, 101, 151, 215), // Data = 3: "glass_light_blue"
                Color.FromArgb(123, 230, 230, 49), // Data = 4: "glass_yellow"
                Color.FromArgb(123, 126, 203, 24), // Data = 5: "glass_lime"
                Color.FromArgb(123, 242, 126, 165), // Data = 6: "glass_pink"
                Color.FromArgb(123, 74, 74, 74), // Data = 7: "glass_gray"
                Color.FromArgb(123, 151, 151, 151), // Data = 8: "glass_silver"
                Color.FromArgb(123, 74, 126, 151), // Data = 9: "glass_cyan"
                Color.FromArgb(123, 126, 62, 178), // Data = 10: "glass_purple"
                Color.FromArgb(123, 49, 74, 178), // Data = 11: "glass_blue"
                Color.FromArgb(123, 101, 74, 49), // Data = 12: "glass_brown"
                Color.FromArgb(123, 101, 126, 49), // Data = 13: "glass_green"
                Color.FromArgb(123, 151, 49, 49), // Data = 14: "glass_red"
                Color.FromArgb(123, 24, 24, 24), // Data = 15: "glass_black"
            }),
            new List<Color>(new Color[] // ID = 96
            {
                Color.FromArgb(255, 127, 94, 46), // Data = : "trapdoor"
            }),
            new List<Color>(new Color[] // ID = 97
            {
                Color.FromArgb(255, 125, 125, 125), // Data = 0: "stone"
                Color.FromArgb(255, 124, 124, 124), // Data = 1: "cobblestone"
                Color.FromArgb(255, 122, 122, 122), // Data = 2: "stonebrick"
                Color.FromArgb(255, 115, 119, 107), // Data = 3: "stonebrick_mossy"
                Color.FromArgb(255, 119, 119, 119), // Data = 4: "stonebrick_cracked"
                Color.FromArgb(255, 119, 119, 119), // Data = 5: "stonebrick_carved"
            }),
            new List<Color>(new Color[] // ID = 98
            {
                Color.FromArgb(255, 122, 122, 122), // Data = 0: "stonebrick"
                Color.FromArgb(255, 115, 119, 107), // Data = 1: "stonebrick_mossy"
                Color.FromArgb(255, 119, 119, 119), // Data = 2: "stonebrick_cracked"
                Color.FromArgb(255, 119, 119, 119), // Data = 3: "stonebrick_carved"
            }),
            new List<Color>(new Color[] // ID = 99
            {
                Color.FromArgb(255, 142, 107, 83), // Data = 0: "mushroom_block_skin_brown"
                //Color.FromArgb(255, 203, 171, 121), // Data = : "mushroom_block_inside"
                //Color.FromArgb(255, 208, 205, 194), // Data = : "mushroom_block_skin_stem"
            }),
            new List<Color>(new Color[] // ID = 100
            {
                Color.FromArgb(255, 181, 29, 27), // Data = : "mushroom_block_skin_red"
            }),
            new List<Color>(new Color[] // ID = 101
            {
                Color.FromArgb(255, 111, 109, 107), // Data = : "iron_bars"
            }),
            new List<Color>(new Color[] // ID = 102
            {
                Color.FromArgb(255, 212, 240, 245), // Data = : "glass_pane_top"
            }),
            new List<Color>(new Color[] // ID = 103
            {
                Color.FromArgb(255, 152, 154, 36), // Data = 0: "melon_top"
                //Color.FromArgb(255, 142, 147, 36), // Data = : "melon_side"
            }),
            new List<Color>(new Color[] // ID = 104
            {
                Color.FromArgb(255, 155, 155, 155), // Data = 0: "pumpkin_stem_disconnected"
                //Color.FromArgb(255, 140, 140, 140), // Data = : "pumpkin_stem_connected"
            }),
            new List<Color>(new Color[] // ID = 105
            {
                Color.FromArgb(255, 155, 155, 155), // Data = 0: "melon_stem_disconnected"
                //Color.FromArgb(255, 140, 140, 140), // Data = : "melon_stem_connected"
            }),
            new List<Color>(new Color[] // ID = 106
            {
                Color.FromArgb(255, 50, 117, 56), // Data = : "vine"
                //Color.FromArgb(255, 75, 97, 51), // Data = : "vine"
            }),
            new List<Color>(new Color[] // ID = 107
            {

            }),
            new List<Color>(new Color[] // ID = 108
            {

            }),
            new List<Color>(new Color[] // ID = 109
            {

            }),
            new List<Color>(new Color[] // ID = 110
            {
                Color.FromArgb(255, 112, 100, 105), // Data = 0: "mycelium_top"
                //Color.FromArgb(255, 115, 89, 75), // Data = : "mycelium_side"
            }),
            new List<Color>(new Color[] // ID = 111
            {
                Color.FromArgb(255, 32, 128, 48), // Data = : "waterlily"
            }),
            new List<Color>(new Color[] // ID = 112
            {
                Color.FromArgb(255, 45, 22, 26), // Data = : "nether_brick"
            }),
            new List<Color>(new Color[] // ID = 113
            {

            }),
            new List<Color>(new Color[] // ID = 114
            {

            }),
            new List<Color>(new Color[] // ID = 115
            {
                Color.FromArgb(255, 113, 20, 18), // Data = 0: "nether_wart_stage_2"
                //Color.FromArgb(255, 108, 16, 31), // Data = : "nether_wart_stage_0"
                //Color.FromArgb(255, 109, 16, 24), // Data = : "nether_wart_stage_1"
            }),
            new List<Color>(new Color[] // ID = 116
            {
                Color.FromArgb(255, 100, 59, 53), // Data = 0: "enchanting_table_top"
                //Color.FromArgb(255, 19, 17, 28), // Data = : "enchanting_table_bottom"
                //Color.FromArgb(255, 37, 29, 33), // Data = : "enchanting_table_side"
            }),
            new List<Color>(new Color[] // ID = 117
            {
                Color.FromArgb(255, 129, 107, 84), // Data = 0: "brewing_stand"
                //Color.FromArgb(255, 107, 107, 107), // Data = : "brewing_stand_base"
            }),
            new List<Color>(new Color[] // ID = 118
            {
                Color.FromArgb(255, 71, 71, 71), // Data = 0: "cauldron_top"
                //Color.FromArgb(255, 44, 44, 44), // Data = : "cauldron_bottom"
                //Color.FromArgb(255, 56, 56, 56), // Data = : "cauldron_inner"
                //Color.FromArgb(255, 62, 62, 62), // Data = : "cauldron_side"
            }),
            new List<Color>(new Color[] // ID = 119
            {

            }),
            new List<Color>(new Color[] // ID = 120
            {
                Color.FromArgb(255, 95, 121, 99), // Data = 0: "endframe_top"
                //Color.FromArgb(255, 41, 73, 67), // Data = : "endframe_eye"
                //Color.FromArgb(255, 154, 164, 126), // Data = : "endframe_side"
            }),
            new List<Color>(new Color[] // ID = 121
            {
                Color.FromArgb(255, 222, 224, 166), // Data = : "end_stone"
            }),
            new List<Color>(new Color[] // ID = 122
            {
                Color.FromArgb(255, 13, 9, 16), // Data = : "dragon_egg"
            }),
            new List<Color>(new Color[] // ID = 123
            {
                Color.FromArgb(255, 74, 45, 28), // Data = : "redstone_lamp_off"
            }),
            new List<Color>(new Color[] // ID = 124
            {
                Color.FromArgb(255, 125, 93, 58), // Data = : "redstone_lamp_on"
            }),
            new List<Color>(new Color[] // ID = 125
            {

            }),
            new List<Color>(new Color[] // ID = 126
            {

            }),
            new List<Color>(new Color[] // ID = 127
            {
                Color.FromArgb(255, 148, 83, 32), // Data = 0: "cocoa_stage_2"
                //Color.FromArgb(255, 139, 141, 65), // Data = : "cocoa_stage_0"
                //Color.FromArgb(255, 138, 109, 52), // Data = : "cocoa_stage_1"
            }),
            new List<Color>(new Color[] // ID = 128
            {

            }),
            new List<Color>(new Color[] // ID = 129
            {
                Color.FromArgb(255, 111, 130, 117), // Data = : "emerald_ore"
            }),
            new List<Color>(new Color[] // ID = 130
            {

            }),
            new List<Color>(new Color[] // ID = 131
            {
                Color.FromArgb(255, 139, 129, 114), // Data = : "trip_wire_source"
            }),
            new List<Color>(new Color[] // ID = 132
            {
                Color.FromArgb(167, 128, 128, 128), // Data = : "trip_wire"
            }),
            new List<Color>(new Color[] // ID = 133
            {
                Color.FromArgb(255, 82, 218, 118), // Data = : "emerald_block"
            }),
            new List<Color>(new Color[] // ID = 134
            {

            }),
            new List<Color>(new Color[] // ID = 135
            {

            }),
            new List<Color>(new Color[] // ID = 136
            {

            }),
            new List<Color>(new Color[] // ID = 137
            {
                Color.FromArgb(255, 174, 134, 111), // Data = 0: "command_block_front"
                //Color.FromArgb(255, 129, 152, 143), // Data = : "chain_command_block_back"
                //Color.FromArgb(255, 129, 157, 145), // Data = : "chain_command_block_conditional"
                //Color.FromArgb(255, 131, 161, 148), // Data = : "chain_command_block_front"
                //Color.FromArgb(255, 130, 156, 145), // Data = : "chain_command_block_side"
                //Color.FromArgb(255, 166, 129, 111), // Data = : "command_block_back"
                //Color.FromArgb(255, 170, 131, 110), // Data = : "command_block_conditional"
                //Color.FromArgb(255, 169, 131, 111), // Data = : "command_block_side"
                //Color.FromArgb(255, 123, 108, 164), // Data = : "repeating_command_block_back"
                //Color.FromArgb(255, 123, 108, 170), // Data = : "repeating_command_block_conditional"
                //Color.FromArgb(255, 126, 109, 173), // Data = : "repeating_command_block_front"
                //Color.FromArgb(255, 125, 109, 169), // Data = : "repeating_command_block_side"
            }),
            new List<Color>(new Color[] // ID = 138
            {
                Color.FromArgb(255, 122, 222, 216), // Data = : "beacon"
            }),
            new List<Color>(new Color[] // ID = 139
            {

            }),
            new List<Color>(new Color[] // ID = 140
            {
                Color.FromArgb(255, 119, 66, 51), // Data = : "flower_pot"
            }),
            new List<Color>(new Color[] // ID = 141
            {
                Color.FromArgb(255, 28, 130, 3), // Data = 0: "carrots_stage_3"
                //Color.FromArgb(255, 1, 173, 16), // Data = : "carrots_stage_0"
                //Color.FromArgb(255, 1, 189, 15), // Data = : "carrots_stage_1"
                //Color.FromArgb(255, 1, 192, 16), // Data = : "carrots_stage_2"
            }),
            new List<Color>(new Color[] // ID = 142
            {
                Color.FromArgb(255, 44, 171, 37), // Data = 0: "potatoes_stage_3"
                //Color.FromArgb(255, 1, 173, 16), // Data = : "potatoes_stage_0"
                //Color.FromArgb(255, 1, 189, 15), // Data = : "potatoes_stage_1"
                //Color.FromArgb(255, 1, 192, 16), // Data = : "potatoes_stage_2"
            }),
            new List<Color>(new Color[] // ID = 143
            {

            }),
            new List<Color>(new Color[] // ID = 144
            {

            }),
            new List<Color>(new Color[] // ID = 145
            {
                Color.FromArgb(255, 64, 64, 64), // Data = 0: "anvil_base"
                //Color.FromArgb(255, 64, 60, 60), // Data = : "anvil_top_damaged_0"
                //Color.FromArgb(255, 64, 60, 60), // Data = : "anvil_top_damaged_1"
                //Color.FromArgb(255, 64, 61, 61), // Data = : "anvil_top_damaged_2"
            }),
            new List<Color>(new Color[] // ID = 146
            {

            }),
            new List<Color>(new Color[] // ID = 147
            {

            }),
            new List<Color>(new Color[] // ID = 148
            {

            }),
            new List<Color>(new Color[] // ID = 149
            {
                Color.FromArgb(255, 157, 153, 152), // Data = : "comparator_off"
            }),
            new List<Color>(new Color[] // ID = 150
            {
                Color.FromArgb(255, 167, 151, 150), // Data = : "comparator_on"
            }),
            new List<Color>(new Color[] // ID = 151
            {
                Color.FromArgb(255, 134, 120, 99), // Data = 0: "daylight_detector_top"
                //Color.FromArgb(255, 109, 113, 118), // Data = : "daylight_detector_inverted_top"
                //Color.FromArgb(255, 67, 55, 35), // Data = : "daylight_detector_side"
            }),
            new List<Color>(new Color[] // ID = 152
            {
                Color.FromArgb(255, 173, 28, 9), // Data = : "redstone_block"
            }),
            new List<Color>(new Color[] // ID = 153
            {
                Color.FromArgb(255, 129, 90, 85), // Data = : "quartz_ore"
            }),
            new List<Color>(new Color[] // ID = 154
            {
                Color.FromArgb(255, 67, 67, 67), // Data = 0: "hopper_top"
                //Color.FromArgb(255, 56, 56, 56), // Data = : "hopper_inside"
                //Color.FromArgb(255, 63, 63, 63), // Data = : "hopper_outside"
            }),
            new List<Color>(new Color[] // ID = 155
            {
                Color.FromArgb(255, 237, 234, 227), // Data = 0: "quartz_block_top"
                Color.FromArgb(255, 232, 229, 220), // Data = 1: "quartz_block_chiseled_top"
                Color.FromArgb(255, 233, 230, 222), // Data = 2: "quartz_block_lines_top"
                //Color.FromArgb(255, 232, 229, 220), // Data = : "quartz_block_bottom"
                //Color.FromArgb(255, 232, 229, 221), // Data = : "quartz_block_chiseled"
                //Color.FromArgb(255, 232, 228, 220), // Data = : "quartz_block_lines"
                //Color.FromArgb(255, 237, 234, 227), // Data = : "quartz_block_side"
            }),
            new List<Color>(new Color[] // ID = 156
            {

            }),
            new List<Color>(new Color[] // ID = 157
            {
                Color.FromArgb(255, 106, 89, 77), // Data = 0: "rail_activator"
                //Color.FromArgb(255, 143, 87, 76), // Data = : "rail_activator_powered"
            }),
            new List<Color>(new Color[] // ID = 158
            {
                Color.FromArgb(255, 89, 89, 89), // Data = 0: "dropper_front_vertical"
                //Color.FromArgb(255, 120, 120, 120), // Data = : "dropper_front_horizontal"
            }),
            new List<Color>(new Color[] // ID = 159
            {
                Color.FromArgb(255, 210, 178, 161), // Data = 0: "hardened_clay_stained_white"
                Color.FromArgb(255, 162, 84, 37), // Data = 1: "hardened_clay_stained_orange"
                Color.FromArgb(255, 150, 88, 109), // Data = 2: "hardened_clay_stained_magenta"
                Color.FromArgb(255, 113, 108, 138), // Data = 3: "hardened_clay_stained_light_blue"
                Color.FromArgb(255, 187, 133, 34), // Data = 4: "hardened_clay_stained_yellow"
                Color.FromArgb(255, 103, 118, 52), // Data = 5: "hardened_clay_stained_lime"
                Color.FromArgb(255, 162, 78, 78), // Data = 6: "hardened_clay_stained_pink"
                Color.FromArgb(255, 57, 41, 35), // Data = 7: "hardened_clay_stained_gray"
                Color.FromArgb(255, 135, 107, 97), // Data = 8: "hardened_clay_stained_silver"
                Color.FromArgb(255, 87, 91, 91), // Data = 9: "hardened_clay_stained_cyan"
                Color.FromArgb(255, 118, 70, 86), // Data = 10: "hardened_clay_stained_purple"
                Color.FromArgb(255, 74, 59, 91), // Data = 11: "hardened_clay_stained_blue"
                Color.FromArgb(255, 76, 50, 35), // Data = 12: "hardened_clay_stained_brown"
                Color.FromArgb(255, 76, 83, 41), // Data = 13: "hardened_clay_stained_green"
                Color.FromArgb(255, 143, 60, 46), // Data = 14: "hardened_clay_stained_red"
                Color.FromArgb(255, 36, 21, 14), // Data = 15: "hardened_clay_stained_black"
            }),
            new List<Color>(new Color[] // ID = 160
            {
                Color.FromArgb(230, 246, 246, 246), // Data = 0: "glass_pane_top_white"
                Color.FromArgb(230, 209, 120, 45), // Data = 1: "glass_pane_top_orange"
                Color.FromArgb(230, 169, 73, 209), // Data = 2: "glass_pane_top_magenta"
                Color.FromArgb(230, 96, 147, 209), // Data = 3: "glass_pane_top_light_blue"
                Color.FromArgb(230, 219, 219, 45), // Data = 4: "glass_pane_top_yellow"
                Color.FromArgb(230, 120, 196, 24), // Data = 5: "glass_pane_top_lime"
                Color.FromArgb(230, 231, 120, 158), // Data = 6: "glass_pane_top_pink"
                Color.FromArgb(230, 73, 73, 73), // Data = 7: "glass_pane_top_gray"
                Color.FromArgb(230, 147, 147, 147), // Data = 8: "glass_pane_top_silver"
                Color.FromArgb(230, 73, 120, 147), // Data = 9: "glass_pane_top_cyan"
                Color.FromArgb(230, 120, 58, 169), // Data = 10: "glass_pane_top_purple"
                Color.FromArgb(230, 45, 73, 169), // Data = 11: "glass_pane_top_blue"
                Color.FromArgb(230, 96, 73, 45), // Data = 12: "glass_pane_top_brown"
                Color.FromArgb(230, 96, 120, 45), // Data = 13: "glass_pane_top_green"
                Color.FromArgb(230, 147, 45, 45), // Data = 14: "glass_pane_top_red"
                Color.FromArgb(230, 24, 24, 24), // Data = 15: "glass_pane_top_black"
            }),
            new List<Color>(new Color[] // ID = 161
            {
                Color.FromArgb(255, 126, 119, 30), // Data = 0: "leaves_acacia" // 136, 136, 136
                Color.FromArgb(255, 64, 126, 36), // Data = 1: "leaves_big_oak" // 136, 136, 136
            }),
            new List<Color>(new Color[] // ID = 162
            {
                Color.FromArgb(255, 155, 91, 64), // Data = 0: "log_acacia_top"
                Color.FromArgb(255, 79, 63, 41), // Data = 1: "log_big_oak_top"
            }),
            new List<Color>(new Color[] // ID = 163
            {

            }),
            new List<Color>(new Color[] // ID = 164
            {

            }),
            new List<Color>(new Color[] // ID = 165
            {
                Color.FromArgb(188, 119, 199, 100), // Data = : "slime"
            }),
            new List<Color>(new Color[] // ID = 166
            {

            }),
            new List<Color>(new Color[] // ID = 167
            {
                Color.FromArgb(255, 200, 200, 200), // Data = : "iron_trapdoor"
            }),
            new List<Color>(new Color[] // ID = 168
            {
                Color.FromArgb(255, 108, 171, 152), // Data = 0: "prismarine_rough"
                Color.FromArgb(255, 101, 161, 144), // Data = 1: "prismarine_bricks"
                Color.FromArgb(255, 60, 88, 75), // Data = 2: "prismarine_dark"
            }),
            new List<Color>(new Color[] // ID = 169
            {
                Color.FromArgb(255, 175, 201, 192), // Data = : "sea_lantern"
            }),
            new List<Color>(new Color[] // ID = 170
            {
                Color.FromArgb(255, 169, 140, 16), // Data = 0: "hay_block_top"
                //Color.FromArgb(255, 159, 118, 18), // Data = : "hay_block_side"
            }),
            new List<Color>(new Color[] // ID = 171
            {

            }),
            new List<Color>(new Color[] // ID = 172
            {
                Color.FromArgb(255, 151, 93, 66), // Data = : "hardened_clay"
            }),
            new List<Color>(new Color[] // ID = 173
            {
                Color.FromArgb(255, 19, 19, 19), // Data = : "coal_block"
            }),
            new List<Color>(new Color[] // ID = 174
            {
                Color.FromArgb(255, 165, 195, 246), // Data = : "ice_packed"
            }),
            new List<Color>(new Color[] // ID = 175
            {
                Color.FromArgb(255, 235, 198, 33), // Data = 0: "double_plant_sunflower_front"
                Color.FromArgb(255, 150, 149, 144), // Data = 1: "double_plant_syringa_top"
                Color.FromArgb(255, 147, 147, 147), // Data = 2: "double_plant_grass_top"
                Color.FromArgb(255, 126, 126, 126), // Data = 3: "double_plant_fern_top"
                Color.FromArgb(255, 124, 67, 9), // Data = 4: "double_plant_rose_top"
                Color.FromArgb(255, 140, 137, 150), // Data = 5: "double_plant_paeonia_top"
                //Color.FromArgb(255, 124, 124, 124), // Data = : "double_plant_fern_bottom"
                //Color.FromArgb(255, 141, 141, 141), // Data = : "double_plant_grass_bottom"
                //Color.FromArgb(255, 36, 77, 39), // Data = : "double_plant_paeonia_bottom"
                //Color.FromArgb(255, 79, 68, 4), // Data = : "double_plant_rose_bottom"
                //Color.FromArgb(255, 64, 105, 42), // Data = : "double_plant_sunflower_back"
                //Color.FromArgb(255, 65, 109, 43), // Data = : "double_plant_sunflower_bottom"
                //Color.FromArgb(255, 68, 112, 45), // Data = : "double_plant_sunflower_top"
                //Color.FromArgb(255, 145, 149, 137), // Data = : "double_plant_syringa_bottom"
            }),
            new List<Color>(new Color[] // ID = 176
            {

            }),
            new List<Color>(new Color[] // ID = 177
            {

            }),
            new List<Color>(new Color[] // ID = 178
            {

            }),
            new List<Color>(new Color[] // ID = 179
            {
                Color.FromArgb(255, 167, 85, 30), // Data = 0: "red_sandstone_top"
                Color.FromArgb(255, 163, 82, 28), // Data = 1: "red_sandstone_carved"
                Color.FromArgb(255, 168, 85, 30), // Data = 2: "red_sandstone_smooth"
                //Color.FromArgb(255, 163, 83, 28), // Data = : "red_sandstone_bottom"
                //Color.FromArgb(255, 166, 85, 29), // Data = : "red_sandstone_normal"
            }),
            new List<Color>(new Color[] // ID = 180
            {

            }),
            new List<Color>(new Color[] // ID = 181
            {

            }),
            new List<Color>(new Color[] // ID = 182
            {

            }),
            new List<Color>(new Color[] // ID = 183
            {

            }),
            new List<Color>(new Color[] // ID = 184
            {

            }),
            new List<Color>(new Color[] // ID = 185
            {

            }),
            new List<Color>(new Color[] // ID = 186
            {

            }),
            new List<Color>(new Color[] // ID = 187
            {

            }),
            new List<Color>(new Color[] // ID = 188
            {

            }),
            new List<Color>(new Color[] // ID = 189
            {

            }),
            new List<Color>(new Color[] // ID = 190
            {

            }),
            new List<Color>(new Color[] // ID = 191
            {

            }),
            new List<Color>(new Color[] // ID = 192
            {

            }),
            new List<Color>(new Color[] // ID = 193
            {
                Color.FromArgb(255, 97, 75, 49), // Data = 0: "door_spruce_upper"
                //Color.FromArgb(255, 98, 76, 50), // Data = : "door_spruce_lower"
            }),
            new List<Color>(new Color[] // ID = 194
            {
                Color.FromArgb(255, 221, 213, 179), // Data = 0: "door_birch_upper"
                //Color.FromArgb(255, 206, 195, 144), // Data = : "door_birch_lower"
            }),
            new List<Color>(new Color[] // ID = 195
            {
                Color.FromArgb(255, 158, 116, 85), // Data = 0: "door_jungle_upper"
                //Color.FromArgb(255, 152, 110, 79), // Data = : "door_jungle_lower"
            }),
            new List<Color>(new Color[] // ID = 196
            {
                Color.FromArgb(255, 162, 93, 59), // Data = 0: "door_acacia_upper"
                //Color.FromArgb(255, 156, 89, 55), // Data = : "door_acacia_lower"
            }),
            new List<Color>(new Color[] // ID = 197
            {
                Color.FromArgb(255, 70, 48, 25), // Data = 0: "door_dark_oak_upper"
                //Color.FromArgb(255, 66, 44, 24), // Data = : "door_dark_oak_lower"
            }),
            new List<Color>(new Color[] // ID = 198
            {
                Color.FromArgb(255, 221, 200, 207), // Data = : "end_rod"
            }),
            new List<Color>(new Color[] // ID = 199
            {
                Color.FromArgb(255, 97, 62, 97), // Data = : "chorus_plant"
            }),
            new List<Color>(new Color[] // ID = 200
            {
                Color.FromArgb(255, 136, 108, 136), // Data = 0: "chorus_flower"
                //Color.FromArgb(255, 99, 66, 97), // Data = : "chorus_flower_dead"
            }),
            new List<Color>(new Color[] // ID = 201
            {
                Color.FromArgb(255, 167, 122, 167), // Data = : "purpur_block"
            }),
            new List<Color>(new Color[] // ID = 202
            {
                Color.FromArgb(255, 171, 129, 171), // Data = 0: "purpur_pillar_top"
                //Color.FromArgb(255, 170, 127, 170), // Data = : "purpur_pillar"
            }),
            new List<Color>(new Color[] // ID = 203
            {

            }),
            new List<Color>(new Color[] // ID = 204
            {

            }),
            new List<Color>(new Color[] // ID = 205
            {

            }),
            new List<Color>(new Color[] // ID = 206
            {
                Color.FromArgb(255, 226, 231, 171), // Data = : "end_bricks"
            }),
            new List<Color>(new Color[] // ID = 207
            {

            }),
            new List<Color>(new Color[] // ID = 208
            {
                Color.FromArgb(255, 150, 125, 71), // Data = 0: "grass_path_top"
                //Color.FromArgb(255, 143, 106, 70), // Data = : "grass_path_side"
            }),
            new List<Color>(new Color[] // ID = 209
            {

            }),
            new List<Color>(new Color[] // ID = 210
            {

            }),
            new List<Color>(new Color[] // ID = 211
            {

            }),
            new List<Color>(new Color[] // ID = 212
            {

            }),
            new List<Color>(new Color[] // ID = 213
            {

            }),
            new List<Color>(new Color[] // ID = 214
            {

            }),
            new List<Color>(new Color[] // ID = 215
            {

            }),
            new List<Color>(new Color[] // ID = 216
            {

            }),
            new List<Color>(new Color[] // ID = 217
            {

            }),
            new List<Color>(new Color[] // ID = 218
            {

            }),
            new List<Color>(new Color[] // ID = 219
            {

            }),
            new List<Color>(new Color[] // ID = 220
            {

            }),
            new List<Color>(new Color[] // ID = 221
            {

            }),
            new List<Color>(new Color[] // ID = 222
            {

            }),
            new List<Color>(new Color[] // ID = 223
            {

            }),
            new List<Color>(new Color[] // ID = 224
            {

            }),
            new List<Color>(new Color[] // ID = 225
            {

            }),
            new List<Color>(new Color[] // ID = 226
            {

            }),
            new List<Color>(new Color[] // ID = 227
            {

            }),
            new List<Color>(new Color[] // ID = 228
            {

            }),
            new List<Color>(new Color[] // ID = 229
            {

            }),
            new List<Color>(new Color[] // ID = 230
            {

            }),
            new List<Color>(new Color[] // ID = 231
            {

            }),
            new List<Color>(new Color[] // ID = 232
            {

            }),
            new List<Color>(new Color[] // ID = 233
            {

            }),
            new List<Color>(new Color[] // ID = 234
            {

            }),
            new List<Color>(new Color[] // ID = 235
            {

            }),
            new List<Color>(new Color[] // ID = 236
            {

            }),
            new List<Color>(new Color[] // ID = 237
            {

            }),
            new List<Color>(new Color[] // ID = 238
            {

            }),
            new List<Color>(new Color[] // ID = 239
            {

            }),
            new List<Color>(new Color[] // ID = 240
            {

            }),
            new List<Color>(new Color[] // ID = 241
            {

            }),
            new List<Color>(new Color[] // ID = 242
            {

            }),
            new List<Color>(new Color[] // ID = 243
            {

            }),
            new List<Color>(new Color[] // ID = 244
            {

            }),
            new List<Color>(new Color[] // ID = 245
            {

            }),
            new List<Color>(new Color[] // ID = 246
            {

            }),
            new List<Color>(new Color[] // ID = 247
            {

            }),
            new List<Color>(new Color[] // ID = 248
            {

            }),
            new List<Color>(new Color[] // ID = 249
            {

            }),
            new List<Color>(new Color[] // ID = 250
            {

            }),
            new List<Color>(new Color[] // ID = 251
            {

            }),
            new List<Color>(new Color[] // ID = 252
            {

            }),
            new List<Color>(new Color[] // ID = 253
            {

            }),
            new List<Color>(new Color[] // ID = 254
            {

            }),
            new List<Color>(new Color[] // ID = 255
            {
                Color.FromArgb(255, 51, 33, 37), // Data = 0: "structure_block"
                //Color.FromArgb(255, 55, 38, 42), // Data = : "structure_block_corner"
                //Color.FromArgb(255, 66, 51, 54), // Data = : "structure_block_data"
                //Color.FromArgb(255, 62, 46, 49), // Data = : "structure_block_load"
                //Color.FromArgb(255, 56, 40, 43), // Data = : "structure_block_save"
            }),
            new List<Color>(new Color[] // ID = 256
            {

            }),
            new List<Color>(new Color[] // ID = 257
            {

            }),
            new List<Color>(new Color[] // ID = 258
            {

            }),
            new List<Color>(new Color[] // ID = 259
            {

            }),
            new List<Color>(new Color[] // ID = 260
            {

            }),
            new List<Color>(new Color[] // ID = 261
            {

            }),
            new List<Color>(new Color[] // ID = 262
            {

            }),
            new List<Color>(new Color[] // ID = 263
            {

            }),
            new List<Color>(new Color[] // ID = 264
            {

            }),
            new List<Color>(new Color[] // ID = 265
            {

            }),
            new List<Color>(new Color[] // ID = 266
            {

            }),
            new List<Color>(new Color[] // ID = 267
            {

            }),
            new List<Color>(new Color[] // ID = 268
            {

            }),
            new List<Color>(new Color[] // ID = 269
            {

            }),
            new List<Color>(new Color[] // ID = 270
            {

            }),
            new List<Color>(new Color[] // ID = 271
            {

            }),
            new List<Color>(new Color[] // ID = 272
            {

            }),
            new List<Color>(new Color[] // ID = 273
            {

            }),
            new List<Color>(new Color[] // ID = 274
            {

            }),
            new List<Color>(new Color[] // ID = 275
            {

            }),
            new List<Color>(new Color[] // ID = 276
            {

            }),
            new List<Color>(new Color[] // ID = 277
            {

            }),
            new List<Color>(new Color[] // ID = 278
            {

            }),
            new List<Color>(new Color[] // ID = 279
            {

            }),
            new List<Color>(new Color[] // ID = 280
            {

            }),
            new List<Color>(new Color[] // ID = 281
            {

            }),
            new List<Color>(new Color[] // ID = 282
            {

            }),
            new List<Color>(new Color[] // ID = 283
            {

            }),
            new List<Color>(new Color[] // ID = 284
            {

            }),
            new List<Color>(new Color[] // ID = 285
            {

            }),
            new List<Color>(new Color[] // ID = 286
            {

            }),
            new List<Color>(new Color[] // ID = 287
            {

            }),
            new List<Color>(new Color[] // ID = 288
            {

            }),
            new List<Color>(new Color[] // ID = 289
            {

            }),
            new List<Color>(new Color[] // ID = 290
            {

            }),
            new List<Color>(new Color[] // ID = 291
            {

            }),
            new List<Color>(new Color[] // ID = 292
            {

            }),
            new List<Color>(new Color[] // ID = 293
            {

            }),
            new List<Color>(new Color[] // ID = 294
            {

            }),
            new List<Color>(new Color[] // ID = 295
            {

            }),
            new List<Color>(new Color[] // ID = 296
            {

            }),
            new List<Color>(new Color[] // ID = 297
            {

            }),
            new List<Color>(new Color[] // ID = 298
            {

            }),
            new List<Color>(new Color[] // ID = 299
            {

            }),
            new List<Color>(new Color[] // ID = 300
            {

            }),
            new List<Color>(new Color[] // ID = 301
            {

            }),
            new List<Color>(new Color[] // ID = 302
            {

            }),
            new List<Color>(new Color[] // ID = 303
            {

            }),
            new List<Color>(new Color[] // ID = 304
            {

            }),
            new List<Color>(new Color[] // ID = 305
            {

            }),
            new List<Color>(new Color[] // ID = 306
            {

            }),
            new List<Color>(new Color[] // ID = 307
            {

            }),
            new List<Color>(new Color[] // ID = 308
            {

            }),
            new List<Color>(new Color[] // ID = 309
            {

            }),
            new List<Color>(new Color[] // ID = 310
            {

            }),
            new List<Color>(new Color[] // ID = 311
            {

            }),
            new List<Color>(new Color[] // ID = 312
            {

            }),
            new List<Color>(new Color[] // ID = 313
            {

            }),
            new List<Color>(new Color[] // ID = 314
            {

            }),
            new List<Color>(new Color[] // ID = 315
            {

            }),
            new List<Color>(new Color[] // ID = 316
            {

            }),
            new List<Color>(new Color[] // ID = 317
            {

            }),
            new List<Color>(new Color[] // ID = 318
            {

            }),
            new List<Color>(new Color[] // ID = 319
            {

            }),
            new List<Color>(new Color[] // ID = 320
            {

            }),
            new List<Color>(new Color[] // ID = 321
            {

            }),
            new List<Color>(new Color[] // ID = 322
            {

            }),
            new List<Color>(new Color[] // ID = 323
            {

            }),
            new List<Color>(new Color[] // ID = 324
            {

            }),
            new List<Color>(new Color[] // ID = 325
            {

            }),
            new List<Color>(new Color[] // ID = 326
            {

            }),
            new List<Color>(new Color[] // ID = 327
            {

            }),
            new List<Color>(new Color[] // ID = 328
            {

            }),
            new List<Color>(new Color[] // ID = 329
            {

            }),
            new List<Color>(new Color[] // ID = 330
            {

            }),
            new List<Color>(new Color[] // ID = 331
            {

            }),
            new List<Color>(new Color[] // ID = 332
            {

            }),
            new List<Color>(new Color[] // ID = 333
            {

            }),
            new List<Color>(new Color[] // ID = 334
            {

            }),
            new List<Color>(new Color[] // ID = 335
            {

            }),
            new List<Color>(new Color[] // ID = 336
            {

            }),
            new List<Color>(new Color[] // ID = 337
            {

            }),
            new List<Color>(new Color[] // ID = 338
            {

            }),
            new List<Color>(new Color[] // ID = 339
            {

            }),
            new List<Color>(new Color[] // ID = 340
            {

            }),
            new List<Color>(new Color[] // ID = 341
            {

            }),
            new List<Color>(new Color[] // ID = 342
            {

            }),
            new List<Color>(new Color[] // ID = 343
            {

            }),
            new List<Color>(new Color[] // ID = 344
            {

            }),
            new List<Color>(new Color[] // ID = 345
            {

            }),
            new List<Color>(new Color[] // ID = 346
            {

            }),
            new List<Color>(new Color[] // ID = 347
            {

            }),
            new List<Color>(new Color[] // ID = 348
            {

            }),
            new List<Color>(new Color[] // ID = 349
            {

            }),
            new List<Color>(new Color[] // ID = 350
            {

            }),
            new List<Color>(new Color[] // ID = 351
            {

            }),
            new List<Color>(new Color[] // ID = 352
            {

            }),
            new List<Color>(new Color[] // ID = 353
            {

            }),
            new List<Color>(new Color[] // ID = 354
            {

            }),
            new List<Color>(new Color[] // ID = 355
            {

            }),
            new List<Color>(new Color[] // ID = 356
            {

            }),
            new List<Color>(new Color[] // ID = 357
            {

            }),
            new List<Color>(new Color[] // ID = 358
            {

            }),
            new List<Color>(new Color[] // ID = 359
            {

            }),
            new List<Color>(new Color[] // ID = 360
            {

            }),
            new List<Color>(new Color[] // ID = 361
            {

            }),
            new List<Color>(new Color[] // ID = 362
            {

            }),
            new List<Color>(new Color[] // ID = 363
            {

            }),
            new List<Color>(new Color[] // ID = 364
            {

            }),
            new List<Color>(new Color[] // ID = 365
            {

            }),
            new List<Color>(new Color[] // ID = 366
            {

            }),
            new List<Color>(new Color[] // ID = 367
            {

            }),
            new List<Color>(new Color[] // ID = 368
            {

            }),
            new List<Color>(new Color[] // ID = 369
            {

            }),
            new List<Color>(new Color[] // ID = 370
            {

            }),
            new List<Color>(new Color[] // ID = 371
            {

            }),
            new List<Color>(new Color[] // ID = 372
            {

            }),
            new List<Color>(new Color[] // ID = 373
            {

            }),
            new List<Color>(new Color[] // ID = 374
            {

            }),
            new List<Color>(new Color[] // ID = 375
            {

            }),
            new List<Color>(new Color[] // ID = 376
            {

            }),
            new List<Color>(new Color[] // ID = 377
            {

            }),
            new List<Color>(new Color[] // ID = 378
            {

            }),
            new List<Color>(new Color[] // ID = 379
            {

            }),
            new List<Color>(new Color[] // ID = 380
            {

            }),
            new List<Color>(new Color[] // ID = 381
            {

            }),
            new List<Color>(new Color[] // ID = 382
            {

            }),
            new List<Color>(new Color[] // ID = 383
            {

            }),
            new List<Color>(new Color[] // ID = 384
            {

            }),
            new List<Color>(new Color[] // ID = 385
            {

            }),
            new List<Color>(new Color[] // ID = 386
            {

            }),
            new List<Color>(new Color[] // ID = 387
            {

            }),
            new List<Color>(new Color[] // ID = 388
            {

            }),
            new List<Color>(new Color[] // ID = 389
            {
                Color.FromArgb(255, 120, 68, 44), // Data = : "itemframe_background"
            }),
            new List<Color>(new Color[] // ID = 390
            {

            }),
            new List<Color>(new Color[] // ID = 391
            {

            }),
            new List<Color>(new Color[] // ID = 392
            {

            }),
            new List<Color>(new Color[] // ID = 393
            {

            }),
            new List<Color>(new Color[] // ID = 394
            {

            }),
            new List<Color>(new Color[] // ID = 395
            {

            }),
            new List<Color>(new Color[] // ID = 396
            {

            }),
            new List<Color>(new Color[] // ID = 397
            {

            }),
            new List<Color>(new Color[] // ID = 398
            {

            }),
            new List<Color>(new Color[] // ID = 399
            {

            }),
            new List<Color>(new Color[] // ID = 400
            {

            }),
            new List<Color>(new Color[] // ID = 401
            {

            }),
            new List<Color>(new Color[] // ID = 402
            {

            }),
            new List<Color>(new Color[] // ID = 403
            {

            }),
            new List<Color>(new Color[] // ID = 404
            {

            }),
            new List<Color>(new Color[] // ID = 405
            {

            }),
            new List<Color>(new Color[] // ID = 406
            {

            }),
            new List<Color>(new Color[] // ID = 407
            {

            }),
            new List<Color>(new Color[] // ID = 408
            {

            }),
            new List<Color>(new Color[] // ID = 409
            {

            }),
            new List<Color>(new Color[] // ID = 410
            {

            }),
            new List<Color>(new Color[] // ID = 411
            {

            }),
            new List<Color>(new Color[] // ID = 412
            {

            }),
            new List<Color>(new Color[] // ID = 413
            {

            }),
            new List<Color>(new Color[] // ID = 414
            {

            }),
            new List<Color>(new Color[] // ID = 415
            {

            }),
            new List<Color>(new Color[] // ID = 416
            {

            }),
            new List<Color>(new Color[] // ID = 417
            {

            }),
            new List<Color>(new Color[] // ID = 418
            {

            }),
            new List<Color>(new Color[] // ID = 419
            {

            }),
            new List<Color>(new Color[] // ID = 420
            {

            }),
            new List<Color>(new Color[] // ID = 421
            {

            }),
            new List<Color>(new Color[] // ID = 422
            {

            }),
            new List<Color>(new Color[] // ID = 423
            {

            }),
            new List<Color>(new Color[] // ID = 424
            {

            }),
            new List<Color>(new Color[] // ID = 425
            {

            }),
            new List<Color>(new Color[] // ID = 426
            {

            }),
            new List<Color>(new Color[] // ID = 427
            {

            }),
            new List<Color>(new Color[] // ID = 428
            {

            }),
            new List<Color>(new Color[] // ID = 429
            {

            }),
            new List<Color>(new Color[] // ID = 430
            {

            }),
            new List<Color>(new Color[] // ID = 431
            {

            }),
            new List<Color>(new Color[] // ID = 432
            {

            }),
            new List<Color>(new Color[] // ID = 433
            {

            }),
        });

        internal static void Crear_Matriz_ID_Data()
        {
            String Texto = new String(' ', 8) + "internal static List<List<Color>> Lista_Colores_ID_Data = new List<List<Color>>(new List<Color>[]\r\n" + new String(' ', 8) + "{\r\n";
            int ID_Máximo = 0;
            for (int Índice = 0; Índice < Lista_IDs.Count; Índice++)
            {
                if (Lista_IDs[Índice] > ID_Máximo) ID_Máximo = Lista_IDs[Índice];
            }
            for (int Índice_ID = 0; Índice_ID < ID_Máximo; Índice_ID++)
            {
                Texto += new String(' ', 12) + "new List<Color>(new Color[] // ID = " + Índice_ID.ToString() + "\r\n" + new String(' ', 12) + "{\r\n";
                String Líneas = null;
                for (int Índice_Data = 0; Índice_Data < Lista_Sólo_Lectura_Nombres.Count; Índice_Data++)
                {
                    if (Lista_IDs[Índice_Data] == Índice_ID)
                    {
                        Líneas += new String(' ', 16) + "Color.FromArgb(" + Lista_Sólo_Lectura_Colores[Índice_Data].A.ToString() + ", " + Lista_Sólo_Lectura_Colores[Índice_Data].R.ToString() + ", " + Lista_Sólo_Lectura_Colores[Índice_Data].G.ToString() + ", " + Lista_Sólo_Lectura_Colores[Índice_Data].B.ToString() + "), // Data = : \"" + Lista_Sólo_Lectura_Nombres[Índice_Data] + "\"\r\n";
                    }
                }
                if (String.IsNullOrEmpty(Líneas)) Líneas = new String(' ', 16) + "\r\n";
                Texto += Líneas;
                Texto += new String(' ', 12) + "}),\r\n";
            }
            Texto += new String(' ', 8) + "});";
            Clipboard.SetText(Texto);
        }

        #region Lista_IDs
        internal static List<int> Lista_IDs = new List<int>(new int[]
        {
            145, // anvil_base
            145, // anvil_top_damaged_0
            145, // anvil_top_damaged_1
            145, // anvil_top_damaged_2
            138, // beacon
            26, // bed_feet_end
            26, // bed_feet_side
            26, // bed_feet_top
            26, // bed_head_end
            26, // bed_head_side
            26, // bed_head_top
            7, // bedrock
            434, // beetroots_stage_0
            434, // beetroots_stage_1
            434, // beetroots_stage_2
            434, // beetroots_stage_3
            47, // bookshelf
            117, // brewing_stand
            117, // brewing_stand_base
            45, // brick
            81, // cactus_bottom
            81, // cactus_side
            81, // cactus_top
            92, // cake_bottom
            92, // cake_inner
            92, // cake_side
            92, // cake_top
            141, // carrots_stage_0
            141, // carrots_stage_1
            141, // carrots_stage_2
            141, // carrots_stage_3
            118, // cauldron_bottom
            118, // cauldron_inner
            118, // cauldron_side
            118, // cauldron_top
            137, // chain_command_block_back
            137, // chain_command_block_conditional
            137, // chain_command_block_front
            137, // chain_command_block_side
            200, // chorus_flower
            200, // chorus_flower_dead
            199, // chorus_plant
            82, // clay
            173, // coal_block
            16, // coal_ore
            3, // coarse_dirt
            4, // cobblestone
            48, // cobblestone_mossy
            127, // cocoa_stage_0
            127, // cocoa_stage_1
            127, // cocoa_stage_2
            137, // command_block_back
            137, // command_block_conditional
            137, // command_block_front
            137, // command_block_side
            149, // comparator_off
            150, // comparator_on
            58, // crafting_table_front
            58, // crafting_table_side
            58, // crafting_table_top
            151, // daylight_detector_inverted_top
            151, // daylight_detector_side
            151, // daylight_detector_top
            32, // deadbush
            Int32.MinValue, // debug
            Int32.MinValue, // destroy_stage_0
            Int32.MinValue, // destroy_stage_1
            Int32.MinValue, // destroy_stage_2
            Int32.MinValue, // destroy_stage_3
            Int32.MinValue, // destroy_stage_4
            Int32.MinValue, // destroy_stage_5
            Int32.MinValue, // destroy_stage_6
            Int32.MinValue, // destroy_stage_7
            Int32.MinValue, // destroy_stage_8
            Int32.MinValue, // destroy_stage_9
            57, // diamond_block
            56, // diamond_ore
            3, // dirt
            3, // dirt_podzol_side
            3, // dirt_podzol_top
            23, // dispenser_front_horizontal
            23, // dispenser_front_vertical
            196, // door_acacia_lower
            196, // door_acacia_upper
            194, // door_birch_lower
            194, // door_birch_upper
            197, // door_dark_oak_lower
            197, // door_dark_oak_upper
            71, // door_iron_lower
            71, // door_iron_upper
            195, // door_jungle_lower
            195, // door_jungle_upper
            193, // door_spruce_lower
            193, // door_spruce_upper
            64, // door_wood_lower
            64, // door_wood_upper
            175, // double_plant_fern_bottom
            175, // double_plant_fern_top
            175, // double_plant_grass_bottom
            175, // double_plant_grass_top
            175, // double_plant_paeonia_bottom
            175, // double_plant_paeonia_top
            175, // double_plant_rose_bottom
            175, // double_plant_rose_top
            175, // double_plant_sunflower_back
            175, // double_plant_sunflower_bottom
            175, // double_plant_sunflower_front
            175, // double_plant_sunflower_top
            175, // double_plant_syringa_bottom
            175, // double_plant_syringa_top
            122, // dragon_egg
            158, // dropper_front_horizontal
            158, // dropper_front_vertical
            133, // emerald_block
            129, // emerald_ore
            116, // enchanting_table_bottom
            116, // enchanting_table_side
            116, // enchanting_table_top
            206, // end_bricks
            198, // end_rod
            121, // end_stone
            120, // endframe_eye
            120, // endframe_side
            120, // endframe_top
            60, // farmland_dry
            60, // farmland_wet
            31, // fern
            51, // fire_layer_0
            51, // fire_layer_1
            38, // flower_allium
            38, // flower_blue_orchid
            37, // flower_dandelion
            38, // flower_houstonia
            38, // flower_oxeye_daisy
            38, // flower_paeonia
            140, // flower_pot
            38, // flower_rose
            38, // flower_tulip_orange
            38, // flower_tulip_pink
            38, // flower_tulip_red
            38, // flower_tulip_white
            79, // frosted_ice_0
            79, // frosted_ice_1
            79, // frosted_ice_2
            79, // frosted_ice_3
            61, // furnace_front_off
            62, // furnace_front_on
            61, // furnace_side
            61, // furnace_top
            20, // glass
            95, // glass_black
            95, // glass_blue
            95, // glass_brown
            95, // glass_cyan
            95, // glass_gray
            95, // glass_green
            95, // glass_light_blue
            95, // glass_lime
            95, // glass_magenta
            95, // glass_orange
            102, // glass_pane_top
            160, // glass_pane_top_black
            160, // glass_pane_top_blue
            160, // glass_pane_top_brown
            160, // glass_pane_top_cyan
            160, // glass_pane_top_gray
            160, // glass_pane_top_green
            160, // glass_pane_top_light_blue
            160, // glass_pane_top_lime
            160, // glass_pane_top_magenta
            160, // glass_pane_top_orange
            160, // glass_pane_top_pink
            160, // glass_pane_top_purple
            160, // glass_pane_top_red
            160, // glass_pane_top_silver
            160, // glass_pane_top_white
            160, // glass_pane_top_yellow
            95, // glass_pink
            95, // glass_purple
            95, // glass_red
            95, // glass_silver
            95, // glass_white
            95, // glass_yellow
            89, // glowstone
            41, // gold_block
            14, // gold_ore
            208, // grass_path_side
            208, // grass_path_top
            2, // grass_side
            2, // grass_side_overlay
            2, // grass_side_snowed
            2, // grass_top
            13, // gravel
            172, // hardened_clay
            159, // hardened_clay_stained_black
            159, // hardened_clay_stained_blue
            159, // hardened_clay_stained_brown
            159, // hardened_clay_stained_cyan
            159, // hardened_clay_stained_gray
            159, // hardened_clay_stained_green
            159, // hardened_clay_stained_light_blue
            159, // hardened_clay_stained_lime
            159, // hardened_clay_stained_magenta
            159, // hardened_clay_stained_orange
            159, // hardened_clay_stained_pink
            159, // hardened_clay_stained_purple
            159, // hardened_clay_stained_red
            159, // hardened_clay_stained_silver
            159, // hardened_clay_stained_white
            159, // hardened_clay_stained_yellow
            170, // hay_block_side
            170, // hay_block_top
            154, // hopper_inside
            154, // hopper_outside
            154, // hopper_top
            79, // ice
            174, // ice_packed
            101, // iron_bars
            42, // iron_block
            15, // iron_ore
            167, // iron_trapdoor
            389, // itemframe_background
            84, // jukebox_side
            84, // jukebox_top
            65, // ladder
            22, // lapis_block
            21, // lapis_ore
            10, // lava_flow
            11, // lava_still
            161, // leaves_acacia
            161, // leaves_big_oak
            18, // leaves_birch
            18, // leaves_jungle
            18, // leaves_oak
            18, // leaves_spruce
            69, // lever
            17, // log_acacia
            17, // log_acacia_top
            17, // log_big_oak
            17, // log_big_oak_top
            17, // log_birch
            17, // log_birch_top
            17, // log_jungle
            17, // log_jungle_top
            17, // log_oak
            17, // log_oak_top
            17, // log_spruce
            17, // log_spruce_top
            103, // melon_side
            105, // melon_stem_connected
            105, // melon_stem_disconnected
            103, // melon_top
            52, // mob_spawner
            99, // mushroom_block_inside
            99, // mushroom_block_skin_brown
            100, // mushroom_block_skin_red
            99, // mushroom_block_skin_stem
            39, // mushroom_brown
            40, // mushroom_red
            110, // mycelium_side
            110, // mycelium_top
            112, // nether_brick
            115, // nether_wart_stage_0
            115, // nether_wart_stage_1
            115, // nether_wart_stage_2
            87, // netherrack
            25, // noteblock
            49, // obsidian
            33, // piston_bottom
            33, // piston_inner
            33, // piston_side
            34, // piston_top_normal
            29, // piston_top_sticky
            5, // planks_acacia
            5, // planks_big_oak
            5, // planks_birch
            5, // planks_jungle
            5, // planks_oak
            5, // planks_spruce
            90, // portal
            142, // potatoes_stage_0
            142, // potatoes_stage_1
            142, // potatoes_stage_2
            142, // potatoes_stage_3
            168, // prismarine_bricks
            168, // prismarine_dark
            168, // prismarine_rough
            86, // pumpkin_face_off
            91, // pumpkin_face_on
            86, // pumpkin_side
            104, // pumpkin_stem_connected
            104, // pumpkin_stem_disconnected
            86, // pumpkin_top
            201, // purpur_block
            202, // purpur_pillar
            202, // purpur_pillar_top
            155, // quartz_block_bottom
            155, // quartz_block_chiseled
            155, // quartz_block_chiseled_top
            155, // quartz_block_lines
            155, // quartz_block_lines_top
            155, // quartz_block_side
            155, // quartz_block_top
            153, // quartz_ore
            157, // rail_activator
            157, // rail_activator_powered
            28, // rail_detector
            28, // rail_detector_powered
            27, // rail_golden
            27, // rail_golden_powered
            66, // rail_normal
            66, // rail_normal_turned
            12, // red_sand
            179, // red_sandstone_bottom
            179, // red_sandstone_carved
            179, // red_sandstone_normal
            179, // red_sandstone_smooth
            179, // red_sandstone_top
            152, // redstone_block
            55, // redstone_dust_dot
            55, // redstone_dust_line0
            55, // redstone_dust_line1
            55, // redstone_dust_overlay
            123, // redstone_lamp_off
            124, // redstone_lamp_on
            73, // redstone_ore
            75, // redstone_torch_off
            76, // redstone_torch_on
            83, // reeds
            93, // repeater_off
            94, // repeater_on
            137, // repeating_command_block_back
            137, // repeating_command_block_conditional
            137, // repeating_command_block_front
            137, // repeating_command_block_side
            12, // sand
            24, // sandstone_bottom
            24, // sandstone_carved
            24, // sandstone_normal
            24, // sandstone_smooth
            24, // sandstone_top
            6, // sapling_acacia
            6, // sapling_birch
            6, // sapling_jungle
            6, // sapling_oak
            6, // sapling_roofed_oak
            6, // sapling_spruce
            169, // sea_lantern
            165, // slime
            78, // snow
            88, // soul_sand
            19, // sponge
            19, // sponge_wet
            1, // stone
            1, // stone_andesite
            1, // stone_andesite_smooth
            1, // stone_diorite
            1, // stone_diorite_smooth
            1, // stone_granite
            1, // stone_granite_smooth
            43, // stone_slab_side
            43, // stone_slab_top
            98, // stonebrick
            98, // stonebrick_carved
            98, // stonebrick_cracked
            98, // stonebrick_mossy
            255, // structure_block
            255, // structure_block_corner
            255, // structure_block_data
            255, // structure_block_load
            255, // structure_block_save
            31, // tallgrass
            46, // tnt_bottom
            46, // tnt_side
            46, // tnt_top
            50, // torch_on
            96, // trapdoor
            131, // trip_wire
            131, // trip_wire_source
            106, // vine
            8, // water_flow
            8, // water_overlay
            9, // water_still
            111, // waterlily
            30, // web
            59, // wheat_stage_0
            59, // wheat_stage_1
            59, // wheat_stage_2
            59, // wheat_stage_3
            59, // wheat_stage_4
            59, // wheat_stage_5
            59, // wheat_stage_6
            59, // wheat_stage_7
            35, // wool_colored_black
            35, // wool_colored_blue
            35, // wool_colored_brown
            35, // wool_colored_cyan
            35, // wool_colored_gray
            35, // wool_colored_green
            35, // wool_colored_light_blue
            35, // wool_colored_lime
            35, // wool_colored_magenta
            35, // wool_colored_orange
            35, // wool_colored_pink
            35, // wool_colored_purple
            35, // wool_colored_red
            35, // wool_colored_silver
            35, // wool_colored_white
            35, // wool_colored_yellow
        });
        #endregion
        internal static List<String> Lista_Nombres = new List<String>(Lista_Sólo_Lectura_Nombres.GetRange(0, Lista_Sólo_Lectura_Nombres.Count));
        internal static List<Color> Lista_Colores = new List<Color>(Lista_Sólo_Lectura_Colores.GetRange(0, Lista_Sólo_Lectura_Colores.Count));
        #region Lista_Imágenes_Bloques_16
        internal static List<Bitmap> Lista_Imágenes_Bloques_16 = new List<Bitmap>(new Bitmap[]
        {
            /*Resources.blocks_16_anvil_base,
            Resources.blocks_16_anvil_top_damaged_0,
            Resources.blocks_16_anvil_top_damaged_1,
            Resources.blocks_16_anvil_top_damaged_2,
            Resources.blocks_16_beacon,
            Resources.blocks_16_bed_feet_end,
            Resources.blocks_16_bed_feet_side,
            Resources.blocks_16_bed_feet_top,
            Resources.blocks_16_bed_head_end,
            Resources.blocks_16_bed_head_side,
            Resources.blocks_16_bed_head_top,
            Resources.blocks_16_bedrock,
            Resources.blocks_16_beetroots_stage_0,
            Resources.blocks_16_beetroots_stage_1,
            Resources.blocks_16_beetroots_stage_2,
            Resources.blocks_16_beetroots_stage_3,
            Resources.blocks_16_bookshelf,
            Resources.blocks_16_brewing_stand,
            Resources.blocks_16_brewing_stand_base,
            Resources.blocks_16_brick,
            Resources.blocks_16_cactus_bottom,
            Resources.blocks_16_cactus_side,
            Resources.blocks_16_cactus_top,
            Resources.blocks_16_cake_bottom,
            Resources.blocks_16_cake_inner,
            Resources.blocks_16_cake_side,
            Resources.blocks_16_cake_top,
            Resources.blocks_16_carrots_stage_0,
            Resources.blocks_16_carrots_stage_1,
            Resources.blocks_16_carrots_stage_2,
            Resources.blocks_16_carrots_stage_3,
            Resources.blocks_16_cauldron_bottom,
            Resources.blocks_16_cauldron_inner,
            Resources.blocks_16_cauldron_side,
            Resources.blocks_16_cauldron_top,
            Resources.blocks_16_chain_command_block_back,
            Resources.blocks_16_chain_command_block_conditional,
            Resources.blocks_16_chain_command_block_front,
            Resources.blocks_16_chain_command_block_side,
            Resources.blocks_16_chorus_flower,
            Resources.blocks_16_chorus_flower_dead,
            Resources.blocks_16_chorus_plant,
            Resources.blocks_16_clay,
            Resources.blocks_16_coal_block,
            Resources.blocks_16_coal_ore,
            Resources.blocks_16_coarse_dirt,
            Resources.blocks_16_cobblestone,
            Resources.blocks_16_cobblestone_mossy,
            Resources.blocks_16_cocoa_stage_0,
            Resources.blocks_16_cocoa_stage_1,
            Resources.blocks_16_cocoa_stage_2,
            Resources.blocks_16_command_block_back,
            Resources.blocks_16_command_block_conditional,
            Resources.blocks_16_command_block_front,
            Resources.blocks_16_command_block_side,
            Resources.blocks_16_comparator_off,
            Resources.blocks_16_comparator_on,
            Resources.blocks_16_crafting_table_front,
            Resources.blocks_16_crafting_table_side,
            Resources.blocks_16_crafting_table_top,
            Resources.blocks_16_daylight_detector_inverted_top,
            Resources.blocks_16_daylight_detector_side,
            Resources.blocks_16_daylight_detector_top,
            Resources.blocks_16_deadbush,
            Resources.blocks_16_debug,
            Resources.blocks_16_destroy_stage_0,
            Resources.blocks_16_destroy_stage_1,
            Resources.blocks_16_destroy_stage_2,
            Resources.blocks_16_destroy_stage_3,
            Resources.blocks_16_destroy_stage_4,
            Resources.blocks_16_destroy_stage_5,
            Resources.blocks_16_destroy_stage_6,
            Resources.blocks_16_destroy_stage_7,
            Resources.blocks_16_destroy_stage_8,
            Resources.blocks_16_destroy_stage_9,
            Resources.blocks_16_diamond_block,
            Resources.blocks_16_diamond_ore,
            Resources.blocks_16_dirt,
            Resources.blocks_16_dirt_podzol_side,
            Resources.blocks_16_dirt_podzol_top,
            Resources.blocks_16_dispenser_front_horizontal,
            Resources.blocks_16_dispenser_front_vertical,
            Resources.blocks_16_door_acacia_lower,
            Resources.blocks_16_door_acacia_upper,
            Resources.blocks_16_door_birch_lower,
            Resources.blocks_16_door_birch_upper,
            Resources.blocks_16_door_dark_oak_lower,
            Resources.blocks_16_door_dark_oak_upper,
            Resources.blocks_16_door_iron_lower,
            Resources.blocks_16_door_iron_upper,
            Resources.blocks_16_door_jungle_lower,
            Resources.blocks_16_door_jungle_upper,
            Resources.blocks_16_door_spruce_lower,
            Resources.blocks_16_door_spruce_upper,
            Resources.blocks_16_door_wood_lower,
            Resources.blocks_16_door_wood_upper,
            Resources.blocks_16_double_plant_fern_bottom,
            Resources.blocks_16_double_plant_fern_top,
            Resources.blocks_16_double_plant_grass_bottom,
            Resources.blocks_16_double_plant_grass_top,
            Resources.blocks_16_double_plant_paeonia_bottom,
            Resources.blocks_16_double_plant_paeonia_top,
            Resources.blocks_16_double_plant_rose_bottom,
            Resources.blocks_16_double_plant_rose_top,
            Resources.blocks_16_double_plant_sunflower_back,
            Resources.blocks_16_double_plant_sunflower_bottom,
            Resources.blocks_16_double_plant_sunflower_front,
            Resources.blocks_16_double_plant_sunflower_top,
            Resources.blocks_16_double_plant_syringa_bottom,
            Resources.blocks_16_double_plant_syringa_top,
            Resources.blocks_16_dragon_egg,
            Resources.blocks_16_dropper_front_horizontal,
            Resources.blocks_16_dropper_front_vertical,
            Resources.blocks_16_emerald_block,
            Resources.blocks_16_emerald_ore,
            Resources.blocks_16_enchanting_table_bottom,
            Resources.blocks_16_enchanting_table_side,
            Resources.blocks_16_enchanting_table_top,
            Resources.blocks_16_end_bricks,
            Resources.blocks_16_end_rod,
            Resources.blocks_16_end_stone,
            Resources.blocks_16_endframe_eye,
            Resources.blocks_16_endframe_side,
            Resources.blocks_16_endframe_top,
            Resources.blocks_16_farmland_dry,
            Resources.blocks_16_farmland_wet,
            Resources.blocks_16_fern,
            Resources.blocks_16_fire_layer_0,
            Resources.blocks_16_fire_layer_1,
            Resources.blocks_16_flower_allium,
            Resources.blocks_16_flower_blue_orchid,
            Resources.blocks_16_flower_dandelion,
            Resources.blocks_16_flower_houstonia,
            Resources.blocks_16_flower_oxeye_daisy,
            Resources.blocks_16_flower_paeonia,
            Resources.blocks_16_flower_pot,
            Resources.blocks_16_flower_rose,
            Resources.blocks_16_flower_tulip_orange,
            Resources.blocks_16_flower_tulip_pink,
            Resources.blocks_16_flower_tulip_red,
            Resources.blocks_16_flower_tulip_white,
            Resources.blocks_16_frosted_ice_0,
            Resources.blocks_16_frosted_ice_1,
            Resources.blocks_16_frosted_ice_2,
            Resources.blocks_16_frosted_ice_3,
            Resources.blocks_16_furnace_front_off,
            Resources.blocks_16_furnace_front_on,
            Resources.blocks_16_furnace_side,
            Resources.blocks_16_furnace_top,
            Resources.blocks_16_glass,
            Resources.blocks_16_glass_black,
            Resources.blocks_16_glass_blue,
            Resources.blocks_16_glass_brown,
            Resources.blocks_16_glass_cyan,
            Resources.blocks_16_glass_gray,
            Resources.blocks_16_glass_green,
            Resources.blocks_16_glass_light_blue,
            Resources.blocks_16_glass_lime,
            Resources.blocks_16_glass_magenta,
            Resources.blocks_16_glass_orange,
            Resources.blocks_16_glass_pane_top,
            Resources.blocks_16_glass_pane_top_black,
            Resources.blocks_16_glass_pane_top_blue,
            Resources.blocks_16_glass_pane_top_brown,
            Resources.blocks_16_glass_pane_top_cyan,
            Resources.blocks_16_glass_pane_top_gray,
            Resources.blocks_16_glass_pane_top_green,
            Resources.blocks_16_glass_pane_top_light_blue,
            Resources.blocks_16_glass_pane_top_lime,
            Resources.blocks_16_glass_pane_top_magenta,
            Resources.blocks_16_glass_pane_top_orange,
            Resources.blocks_16_glass_pane_top_pink,
            Resources.blocks_16_glass_pane_top_purple,
            Resources.blocks_16_glass_pane_top_red,
            Resources.blocks_16_glass_pane_top_silver,
            Resources.blocks_16_glass_pane_top_white,
            Resources.blocks_16_glass_pane_top_yellow,
            Resources.blocks_16_glass_pink,
            Resources.blocks_16_glass_purple,
            Resources.blocks_16_glass_red,
            Resources.blocks_16_glass_silver,
            Resources.blocks_16_glass_white,
            Resources.blocks_16_glass_yellow,
            Resources.blocks_16_glowstone,
            Resources.blocks_16_gold_block,
            Resources.blocks_16_gold_ore,
            Resources.blocks_16_grass_path_side,
            Resources.blocks_16_grass_path_top,
            Resources.blocks_16_grass_side,
            Resources.blocks_16_grass_side_overlay,
            Resources.blocks_16_grass_side_snowed,
            Resources.blocks_16_grass_top,
            Resources.blocks_16_gravel,
            Resources.blocks_16_hardened_clay,
            Resources.blocks_16_hardened_clay_stained_black,
            Resources.blocks_16_hardened_clay_stained_blue,
            Resources.blocks_16_hardened_clay_stained_brown,
            Resources.blocks_16_hardened_clay_stained_cyan,
            Resources.blocks_16_hardened_clay_stained_gray,
            Resources.blocks_16_hardened_clay_stained_green,
            Resources.blocks_16_hardened_clay_stained_light_blue,
            Resources.blocks_16_hardened_clay_stained_lime,
            Resources.blocks_16_hardened_clay_stained_magenta,
            Resources.blocks_16_hardened_clay_stained_orange,
            Resources.blocks_16_hardened_clay_stained_pink,
            Resources.blocks_16_hardened_clay_stained_purple,
            Resources.blocks_16_hardened_clay_stained_red,
            Resources.blocks_16_hardened_clay_stained_silver,
            Resources.blocks_16_hardened_clay_stained_white,
            Resources.blocks_16_hardened_clay_stained_yellow,
            Resources.blocks_16_hay_block_side,
            Resources.blocks_16_hay_block_top,
            Resources.blocks_16_hopper_inside,
            Resources.blocks_16_hopper_outside,
            Resources.blocks_16_hopper_top,
            Resources.blocks_16_ice,
            Resources.blocks_16_ice_packed,
            Resources.blocks_16_iron_bars,
            Resources.blocks_16_iron_block,
            Resources.blocks_16_iron_ore,
            Resources.blocks_16_iron_trapdoor,
            Resources.blocks_16_itemframe_background,
            Resources.blocks_16_jukebox_side,
            Resources.blocks_16_jukebox_top,
            Resources.blocks_16_ladder,
            Resources.blocks_16_lapis_block,
            Resources.blocks_16_lapis_ore,
            Resources.blocks_16_lava_flow,
            Resources.blocks_16_lava_still,
            Resources.blocks_16_leaves_acacia,
            Resources.blocks_16_leaves_big_oak,
            Resources.blocks_16_leaves_birch,
            Resources.blocks_16_leaves_jungle,
            Resources.blocks_16_leaves_oak,
            Resources.blocks_16_leaves_spruce,
            Resources.blocks_16_lever,
            Resources.blocks_16_log_acacia,
            Resources.blocks_16_log_acacia_top,
            Resources.blocks_16_log_big_oak,
            Resources.blocks_16_log_big_oak_top,
            Resources.blocks_16_log_birch,
            Resources.blocks_16_log_birch_top,
            Resources.blocks_16_log_jungle,
            Resources.blocks_16_log_jungle_top,
            Resources.blocks_16_log_oak,
            Resources.blocks_16_log_oak_top,
            Resources.blocks_16_log_spruce,
            Resources.blocks_16_log_spruce_top,
            Resources.blocks_16_melon_side,
            Resources.blocks_16_melon_stem_connected,
            Resources.blocks_16_melon_stem_disconnected,
            Resources.blocks_16_melon_top,
            Resources.blocks_16_mob_spawner,
            Resources.blocks_16_mushroom_block_inside,
            Resources.blocks_16_mushroom_block_skin_brown,
            Resources.blocks_16_mushroom_block_skin_red,
            Resources.blocks_16_mushroom_block_skin_stem,
            Resources.blocks_16_mushroom_brown,
            Resources.blocks_16_mushroom_red,
            Resources.blocks_16_mycelium_side,
            Resources.blocks_16_mycelium_top,
            Resources.blocks_16_nether_brick,
            Resources.blocks_16_nether_wart_stage_0,
            Resources.blocks_16_nether_wart_stage_1,
            Resources.blocks_16_nether_wart_stage_2,
            Resources.blocks_16_netherrack,
            Resources.blocks_16_noteblock,
            Resources.blocks_16_obsidian,
            Resources.blocks_16_piston_bottom,
            Resources.blocks_16_piston_inner,
            Resources.blocks_16_piston_side,
            Resources.blocks_16_piston_top_normal,
            Resources.blocks_16_piston_top_sticky,
            Resources.blocks_16_planks_acacia,
            Resources.blocks_16_planks_big_oak,
            Resources.blocks_16_planks_birch,
            Resources.blocks_16_planks_jungle,
            Resources.blocks_16_planks_oak,
            Resources.blocks_16_planks_spruce,
            Resources.blocks_16_portal,
            Resources.blocks_16_potatoes_stage_0,
            Resources.blocks_16_potatoes_stage_1,
            Resources.blocks_16_potatoes_stage_2,
            Resources.blocks_16_potatoes_stage_3,
            Resources.blocks_16_prismarine_bricks,
            Resources.blocks_16_prismarine_dark,
            Resources.blocks_16_prismarine_rough,
            Resources.blocks_16_pumpkin_face_off,
            Resources.blocks_16_pumpkin_face_on,
            Resources.blocks_16_pumpkin_side,
            Resources.blocks_16_pumpkin_stem_connected,
            Resources.blocks_16_pumpkin_stem_disconnected,
            Resources.blocks_16_pumpkin_top,
            Resources.blocks_16_purpur_block,
            Resources.blocks_16_purpur_pillar,
            Resources.blocks_16_purpur_pillar_top,
            Resources.blocks_16_quartz_block_bottom,
            Resources.blocks_16_quartz_block_chiseled,
            Resources.blocks_16_quartz_block_chiseled_top,
            Resources.blocks_16_quartz_block_lines,
            Resources.blocks_16_quartz_block_lines_top,
            Resources.blocks_16_quartz_block_side,
            Resources.blocks_16_quartz_block_top,
            Resources.blocks_16_quartz_ore,
            Resources.blocks_16_rail_activator,
            Resources.blocks_16_rail_activator_powered,
            Resources.blocks_16_rail_detector,
            Resources.blocks_16_rail_detector_powered,
            Resources.blocks_16_rail_golden,
            Resources.blocks_16_rail_golden_powered,
            Resources.blocks_16_rail_normal,
            Resources.blocks_16_rail_normal_turned,
            Resources.blocks_16_red_sand,
            Resources.blocks_16_red_sandstone_bottom,
            Resources.blocks_16_red_sandstone_carved,
            Resources.blocks_16_red_sandstone_normal,
            Resources.blocks_16_red_sandstone_smooth,
            Resources.blocks_16_red_sandstone_top,
            Resources.blocks_16_redstone_block,
            Resources.blocks_16_redstone_dust_dot,
            Resources.blocks_16_redstone_dust_line0,
            Resources.blocks_16_redstone_dust_line1,
            Resources.blocks_16_redstone_dust_overlay,
            Resources.blocks_16_redstone_lamp_off,
            Resources.blocks_16_redstone_lamp_on,
            Resources.blocks_16_redstone_ore,
            Resources.blocks_16_redstone_torch_off,
            Resources.blocks_16_redstone_torch_on,
            Resources.blocks_16_reeds,
            Resources.blocks_16_repeater_off,
            Resources.blocks_16_repeater_on,
            Resources.blocks_16_repeating_command_block_back,
            Resources.blocks_16_repeating_command_block_conditional,
            Resources.blocks_16_repeating_command_block_front,
            Resources.blocks_16_repeating_command_block_side,
            Resources.blocks_16_sand,
            Resources.blocks_16_sandstone_bottom,
            Resources.blocks_16_sandstone_carved,
            Resources.blocks_16_sandstone_normal,
            Resources.blocks_16_sandstone_smooth,
            Resources.blocks_16_sandstone_top,
            Resources.blocks_16_sapling_acacia,
            Resources.blocks_16_sapling_birch,
            Resources.blocks_16_sapling_jungle,
            Resources.blocks_16_sapling_oak,
            Resources.blocks_16_sapling_roofed_oak,
            Resources.blocks_16_sapling_spruce,
            Resources.blocks_16_sea_lantern,
            Resources.blocks_16_slime,
            Resources.blocks_16_snow,
            Resources.blocks_16_soul_sand,
            Resources.blocks_16_sponge,
            Resources.blocks_16_sponge_wet,
            Resources.blocks_16_stone,
            Resources.blocks_16_stone_andesite,
            Resources.blocks_16_stone_andesite_smooth,
            Resources.blocks_16_stone_diorite,
            Resources.blocks_16_stone_diorite_smooth,
            Resources.blocks_16_stone_granite,
            Resources.blocks_16_stone_granite_smooth,
            Resources.blocks_16_stone_slab_side,
            Resources.blocks_16_stone_slab_top,
            Resources.blocks_16_stonebrick,
            Resources.blocks_16_stonebrick_carved,
            Resources.blocks_16_stonebrick_cracked,
            Resources.blocks_16_stonebrick_mossy,
            Resources.blocks_16_structure_block,
            Resources.blocks_16_structure_block_corner,
            Resources.blocks_16_structure_block_data,
            Resources.blocks_16_structure_block_load,
            Resources.blocks_16_structure_block_save,
            Resources.blocks_16_tallgrass,
            Resources.blocks_16_tnt_bottom,
            Resources.blocks_16_tnt_side,
            Resources.blocks_16_tnt_top,
            Resources.blocks_16_torch_on,
            Resources.blocks_16_trapdoor,
            Resources.blocks_16_trip_wire,
            Resources.blocks_16_trip_wire_source,
            Resources.blocks_16_vine,
            Resources.blocks_16_water_flow,
            Resources.blocks_16_water_overlay,
            Resources.blocks_16_water_still,
            Resources.blocks_16_waterlily,
            Resources.blocks_16_web,
            Resources.blocks_16_wheat_stage_0,
            Resources.blocks_16_wheat_stage_1,
            Resources.blocks_16_wheat_stage_2,
            Resources.blocks_16_wheat_stage_3,
            Resources.blocks_16_wheat_stage_4,
            Resources.blocks_16_wheat_stage_5,
            Resources.blocks_16_wheat_stage_6,
            Resources.blocks_16_wheat_stage_7,
            Resources.blocks_16_wool_colored_black,
            Resources.blocks_16_wool_colored_blue,
            Resources.blocks_16_wool_colored_brown,
            Resources.blocks_16_wool_colored_cyan,
            Resources.blocks_16_wool_colored_gray,
            Resources.blocks_16_wool_colored_green,
            Resources.blocks_16_wool_colored_light_blue,
            Resources.blocks_16_wool_colored_lime,
            Resources.blocks_16_wool_colored_magenta,
            Resources.blocks_16_wool_colored_orange,
            Resources.blocks_16_wool_colored_pink,
            Resources.blocks_16_wool_colored_purple,
            Resources.blocks_16_wool_colored_red,
            Resources.blocks_16_wool_colored_silver,
            Resources.blocks_16_wool_colored_white,
            Resources.blocks_16_wool_colored_yellow*/
        });
        #endregion
        #region Lista_Imágenes_Bloques_32
        internal static List<Bitmap> Lista_Imágenes_Bloques_32 = new List<Bitmap>(new Bitmap[]
        {
            /*Resources.blocks_32_anvil_base,
            Resources.blocks_32_anvil_top_damaged_0,
            Resources.blocks_32_anvil_top_damaged_1,
            Resources.blocks_32_anvil_top_damaged_2,
            Resources.blocks_32_beacon,
            Resources.blocks_32_bed_feet_end,
            Resources.blocks_32_bed_feet_side,
            Resources.blocks_32_bed_feet_top,
            Resources.blocks_32_bed_head_end,
            Resources.blocks_32_bed_head_side,
            Resources.blocks_32_bed_head_top,
            Resources.blocks_32_bedrock,
            Resources.blocks_32_beetroots_stage_0,
            Resources.blocks_32_beetroots_stage_1,
            Resources.blocks_32_beetroots_stage_2,
            Resources.blocks_32_beetroots_stage_3,
            Resources.blocks_32_bookshelf,
            Resources.blocks_32_brewing_stand,
            Resources.blocks_32_brewing_stand_base,
            Resources.blocks_32_brick,
            Resources.blocks_32_cactus_bottom,
            Resources.blocks_32_cactus_side,
            Resources.blocks_32_cactus_top,
            Resources.blocks_32_cake_bottom,
            Resources.blocks_32_cake_inner,
            Resources.blocks_32_cake_side,
            Resources.blocks_32_cake_top,
            Resources.blocks_32_carrots_stage_0,
            Resources.blocks_32_carrots_stage_1,
            Resources.blocks_32_carrots_stage_2,
            Resources.blocks_32_carrots_stage_3,
            Resources.blocks_32_cauldron_bottom,
            Resources.blocks_32_cauldron_inner,
            Resources.blocks_32_cauldron_side,
            Resources.blocks_32_cauldron_top,
            Resources.blocks_32_chain_command_block_back,
            Resources.blocks_32_chain_command_block_conditional,
            Resources.blocks_32_chain_command_block_front,
            Resources.blocks_32_chain_command_block_side,
            Resources.blocks_32_chorus_flower,
            Resources.blocks_32_chorus_flower_dead,
            Resources.blocks_32_chorus_plant,
            Resources.blocks_32_clay,
            Resources.blocks_32_coal_block,
            Resources.blocks_32_coal_ore,
            Resources.blocks_32_coarse_dirt,
            Resources.blocks_32_cobblestone,
            Resources.blocks_32_cobblestone_mossy,
            Resources.blocks_32_cocoa_stage_0,
            Resources.blocks_32_cocoa_stage_1,
            Resources.blocks_32_cocoa_stage_2,
            Resources.blocks_32_command_block_back,
            Resources.blocks_32_command_block_conditional,
            Resources.blocks_32_command_block_front,
            Resources.blocks_32_command_block_side,
            Resources.blocks_32_comparator_off,
            Resources.blocks_32_comparator_on,
            Resources.blocks_32_crafting_table_front,
            Resources.blocks_32_crafting_table_side,
            Resources.blocks_32_crafting_table_top,
            Resources.blocks_32_daylight_detector_inverted_top,
            Resources.blocks_32_daylight_detector_side,
            Resources.blocks_32_daylight_detector_top,
            Resources.blocks_32_deadbush,
            Resources.blocks_32_debug,
            Resources.blocks_32_destroy_stage_0,
            Resources.blocks_32_destroy_stage_1,
            Resources.blocks_32_destroy_stage_2,
            Resources.blocks_32_destroy_stage_3,
            Resources.blocks_32_destroy_stage_4,
            Resources.blocks_32_destroy_stage_5,
            Resources.blocks_32_destroy_stage_6,
            Resources.blocks_32_destroy_stage_7,
            Resources.blocks_32_destroy_stage_8,
            Resources.blocks_32_destroy_stage_9,
            Resources.blocks_32_diamond_block,
            Resources.blocks_32_diamond_ore,
            Resources.blocks_32_dirt,
            Resources.blocks_32_dirt_podzol_side,
            Resources.blocks_32_dirt_podzol_top,
            Resources.blocks_32_dispenser_front_horizontal,
            Resources.blocks_32_dispenser_front_vertical,
            Resources.blocks_32_door_acacia_lower,
            Resources.blocks_32_door_acacia_upper,
            Resources.blocks_32_door_birch_lower,
            Resources.blocks_32_door_birch_upper,
            Resources.blocks_32_door_dark_oak_lower,
            Resources.blocks_32_door_dark_oak_upper,
            Resources.blocks_32_door_iron_lower,
            Resources.blocks_32_door_iron_upper,
            Resources.blocks_32_door_jungle_lower,
            Resources.blocks_32_door_jungle_upper,
            Resources.blocks_32_door_spruce_lower,
            Resources.blocks_32_door_spruce_upper,
            Resources.blocks_32_door_wood_lower,
            Resources.blocks_32_door_wood_upper,
            Resources.blocks_32_double_plant_fern_bottom,
            Resources.blocks_32_double_plant_fern_top,
            Resources.blocks_32_double_plant_grass_bottom,
            Resources.blocks_32_double_plant_grass_top,
            Resources.blocks_32_double_plant_paeonia_bottom,
            Resources.blocks_32_double_plant_paeonia_top,
            Resources.blocks_32_double_plant_rose_bottom,
            Resources.blocks_32_double_plant_rose_top,
            Resources.blocks_32_double_plant_sunflower_back,
            Resources.blocks_32_double_plant_sunflower_bottom,
            Resources.blocks_32_double_plant_sunflower_front,
            Resources.blocks_32_double_plant_sunflower_top,
            Resources.blocks_32_double_plant_syringa_bottom,
            Resources.blocks_32_double_plant_syringa_top,
            Resources.blocks_32_dragon_egg,
            Resources.blocks_32_dropper_front_horizontal,
            Resources.blocks_32_dropper_front_vertical,
            Resources.blocks_32_emerald_block,
            Resources.blocks_32_emerald_ore,
            Resources.blocks_32_enchanting_table_bottom,
            Resources.blocks_32_enchanting_table_side,
            Resources.blocks_32_enchanting_table_top,
            Resources.blocks_32_end_bricks,
            Resources.blocks_32_end_rod,
            Resources.blocks_32_end_stone,
            Resources.blocks_32_endframe_eye,
            Resources.blocks_32_endframe_side,
            Resources.blocks_32_endframe_top,
            Resources.blocks_32_farmland_dry,
            Resources.blocks_32_farmland_wet,
            Resources.blocks_32_fern,
            Resources.blocks_32_fire_layer_0,
            Resources.blocks_32_fire_layer_1,
            Resources.blocks_32_flower_allium,
            Resources.blocks_32_flower_blue_orchid,
            Resources.blocks_32_flower_dandelion,
            Resources.blocks_32_flower_houstonia,
            Resources.blocks_32_flower_oxeye_daisy,
            Resources.blocks_32_flower_paeonia,
            Resources.blocks_32_flower_pot,
            Resources.blocks_32_flower_rose,
            Resources.blocks_32_flower_tulip_orange,
            Resources.blocks_32_flower_tulip_pink,
            Resources.blocks_32_flower_tulip_red,
            Resources.blocks_32_flower_tulip_white,
            Resources.blocks_32_frosted_ice_0,
            Resources.blocks_32_frosted_ice_1,
            Resources.blocks_32_frosted_ice_2,
            Resources.blocks_32_frosted_ice_3,
            Resources.blocks_32_furnace_front_off,
            Resources.blocks_32_furnace_front_on,
            Resources.blocks_32_furnace_side,
            Resources.blocks_32_furnace_top,
            Resources.blocks_32_glass,
            Resources.blocks_32_glass_black,
            Resources.blocks_32_glass_blue,
            Resources.blocks_32_glass_brown,
            Resources.blocks_32_glass_cyan,
            Resources.blocks_32_glass_gray,
            Resources.blocks_32_glass_green,
            Resources.blocks_32_glass_light_blue,
            Resources.blocks_32_glass_lime,
            Resources.blocks_32_glass_magenta,
            Resources.blocks_32_glass_orange,
            Resources.blocks_32_glass_pane_top,
            Resources.blocks_32_glass_pane_top_black,
            Resources.blocks_32_glass_pane_top_blue,
            Resources.blocks_32_glass_pane_top_brown,
            Resources.blocks_32_glass_pane_top_cyan,
            Resources.blocks_32_glass_pane_top_gray,
            Resources.blocks_32_glass_pane_top_green,
            Resources.blocks_32_glass_pane_top_light_blue,
            Resources.blocks_32_glass_pane_top_lime,
            Resources.blocks_32_glass_pane_top_magenta,
            Resources.blocks_32_glass_pane_top_orange,
            Resources.blocks_32_glass_pane_top_pink,
            Resources.blocks_32_glass_pane_top_purple,
            Resources.blocks_32_glass_pane_top_red,
            Resources.blocks_32_glass_pane_top_silver,
            Resources.blocks_32_glass_pane_top_white,
            Resources.blocks_32_glass_pane_top_yellow,
            Resources.blocks_32_glass_pink,
            Resources.blocks_32_glass_purple,
            Resources.blocks_32_glass_red,
            Resources.blocks_32_glass_silver,
            Resources.blocks_32_glass_white,
            Resources.blocks_32_glass_yellow,
            Resources.blocks_32_glowstone,
            Resources.blocks_32_gold_block,
            Resources.blocks_32_gold_ore,
            Resources.blocks_32_grass_path_side,
            Resources.blocks_32_grass_path_top,
            Resources.blocks_32_grass_side,
            Resources.blocks_32_grass_side_overlay,
            Resources.blocks_32_grass_side_snowed,
            Resources.blocks_32_grass_top,
            Resources.blocks_32_gravel,
            Resources.blocks_32_hardened_clay,
            Resources.blocks_32_hardened_clay_stained_black,
            Resources.blocks_32_hardened_clay_stained_blue,
            Resources.blocks_32_hardened_clay_stained_brown,
            Resources.blocks_32_hardened_clay_stained_cyan,
            Resources.blocks_32_hardened_clay_stained_gray,
            Resources.blocks_32_hardened_clay_stained_green,
            Resources.blocks_32_hardened_clay_stained_light_blue,
            Resources.blocks_32_hardened_clay_stained_lime,
            Resources.blocks_32_hardened_clay_stained_magenta,
            Resources.blocks_32_hardened_clay_stained_orange,
            Resources.blocks_32_hardened_clay_stained_pink,
            Resources.blocks_32_hardened_clay_stained_purple,
            Resources.blocks_32_hardened_clay_stained_red,
            Resources.blocks_32_hardened_clay_stained_silver,
            Resources.blocks_32_hardened_clay_stained_white,
            Resources.blocks_32_hardened_clay_stained_yellow,
            Resources.blocks_32_hay_block_side,
            Resources.blocks_32_hay_block_top,
            Resources.blocks_32_hopper_inside,
            Resources.blocks_32_hopper_outside,
            Resources.blocks_32_hopper_top,
            Resources.blocks_32_ice,
            Resources.blocks_32_ice_packed,
            Resources.blocks_32_iron_bars,
            Resources.blocks_32_iron_block,
            Resources.blocks_32_iron_ore,
            Resources.blocks_32_iron_trapdoor,
            Resources.blocks_32_itemframe_background,
            Resources.blocks_32_jukebox_side,
            Resources.blocks_32_jukebox_top,
            Resources.blocks_32_ladder,
            Resources.blocks_32_lapis_block,
            Resources.blocks_32_lapis_ore,
            Resources.blocks_32_lava_flow,
            Resources.blocks_32_lava_still,
            Resources.blocks_32_leaves_acacia,
            Resources.blocks_32_leaves_big_oak,
            Resources.blocks_32_leaves_birch,
            Resources.blocks_32_leaves_jungle,
            Resources.blocks_32_leaves_oak,
            Resources.blocks_32_leaves_spruce,
            Resources.blocks_32_lever,
            Resources.blocks_32_log_acacia,
            Resources.blocks_32_log_acacia_top,
            Resources.blocks_32_log_big_oak,
            Resources.blocks_32_log_big_oak_top,
            Resources.blocks_32_log_birch,
            Resources.blocks_32_log_birch_top,
            Resources.blocks_32_log_jungle,
            Resources.blocks_32_log_jungle_top,
            Resources.blocks_32_log_oak,
            Resources.blocks_32_log_oak_top,
            Resources.blocks_32_log_spruce,
            Resources.blocks_32_log_spruce_top,
            Resources.blocks_32_melon_side,
            Resources.blocks_32_melon_stem_connected,
            Resources.blocks_32_melon_stem_disconnected,
            Resources.blocks_32_melon_top,
            Resources.blocks_32_mob_spawner,
            Resources.blocks_32_mushroom_block_inside,
            Resources.blocks_32_mushroom_block_skin_brown,
            Resources.blocks_32_mushroom_block_skin_red,
            Resources.blocks_32_mushroom_block_skin_stem,
            Resources.blocks_32_mushroom_brown,
            Resources.blocks_32_mushroom_red,
            Resources.blocks_32_mycelium_side,
            Resources.blocks_32_mycelium_top,
            Resources.blocks_32_nether_brick,
            Resources.blocks_32_nether_wart_stage_0,
            Resources.blocks_32_nether_wart_stage_1,
            Resources.blocks_32_nether_wart_stage_2,
            Resources.blocks_32_netherrack,
            Resources.blocks_32_noteblock,
            Resources.blocks_32_obsidian,
            Resources.blocks_32_piston_bottom,
            Resources.blocks_32_piston_inner,
            Resources.blocks_32_piston_side,
            Resources.blocks_32_piston_top_normal,
            Resources.blocks_32_piston_top_sticky,
            Resources.blocks_32_planks_acacia,
            Resources.blocks_32_planks_big_oak,
            Resources.blocks_32_planks_birch,
            Resources.blocks_32_planks_jungle,
            Resources.blocks_32_planks_oak,
            Resources.blocks_32_planks_spruce,
            Resources.blocks_32_portal,
            Resources.blocks_32_potatoes_stage_0,
            Resources.blocks_32_potatoes_stage_1,
            Resources.blocks_32_potatoes_stage_2,
            Resources.blocks_32_potatoes_stage_3,
            Resources.blocks_32_prismarine_bricks,
            Resources.blocks_32_prismarine_dark,
            Resources.blocks_32_prismarine_rough,
            Resources.blocks_32_pumpkin_face_off,
            Resources.blocks_32_pumpkin_face_on,
            Resources.blocks_32_pumpkin_side,
            Resources.blocks_32_pumpkin_stem_connected,
            Resources.blocks_32_pumpkin_stem_disconnected,
            Resources.blocks_32_pumpkin_top,
            Resources.blocks_32_purpur_block,
            Resources.blocks_32_purpur_pillar,
            Resources.blocks_32_purpur_pillar_top,
            Resources.blocks_32_quartz_block_bottom,
            Resources.blocks_32_quartz_block_chiseled,
            Resources.blocks_32_quartz_block_chiseled_top,
            Resources.blocks_32_quartz_block_lines,
            Resources.blocks_32_quartz_block_lines_top,
            Resources.blocks_32_quartz_block_side,
            Resources.blocks_32_quartz_block_top,
            Resources.blocks_32_quartz_ore,
            Resources.blocks_32_rail_activator,
            Resources.blocks_32_rail_activator_powered,
            Resources.blocks_32_rail_detector,
            Resources.blocks_32_rail_detector_powered,
            Resources.blocks_32_rail_golden,
            Resources.blocks_32_rail_golden_powered,
            Resources.blocks_32_rail_normal,
            Resources.blocks_32_rail_normal_turned,
            Resources.blocks_32_red_sand,
            Resources.blocks_32_red_sandstone_bottom,
            Resources.blocks_32_red_sandstone_carved,
            Resources.blocks_32_red_sandstone_normal,
            Resources.blocks_32_red_sandstone_smooth,
            Resources.blocks_32_red_sandstone_top,
            Resources.blocks_32_redstone_block,
            Resources.blocks_32_redstone_dust_dot,
            Resources.blocks_32_redstone_dust_line0,
            Resources.blocks_32_redstone_dust_line1,
            Resources.blocks_32_redstone_dust_overlay,
            Resources.blocks_32_redstone_lamp_off,
            Resources.blocks_32_redstone_lamp_on,
            Resources.blocks_32_redstone_ore,
            Resources.blocks_32_redstone_torch_off,
            Resources.blocks_32_redstone_torch_on,
            Resources.blocks_32_reeds,
            Resources.blocks_32_repeater_off,
            Resources.blocks_32_repeater_on,
            Resources.blocks_32_repeating_command_block_back,
            Resources.blocks_32_repeating_command_block_conditional,
            Resources.blocks_32_repeating_command_block_front,
            Resources.blocks_32_repeating_command_block_side,
            Resources.blocks_32_sand,
            Resources.blocks_32_sandstone_bottom,
            Resources.blocks_32_sandstone_carved,
            Resources.blocks_32_sandstone_normal,
            Resources.blocks_32_sandstone_smooth,
            Resources.blocks_32_sandstone_top,
            Resources.blocks_32_sapling_acacia,
            Resources.blocks_32_sapling_birch,
            Resources.blocks_32_sapling_jungle,
            Resources.blocks_32_sapling_oak,
            Resources.blocks_32_sapling_roofed_oak,
            Resources.blocks_32_sapling_spruce,
            Resources.blocks_32_sea_lantern,
            Resources.blocks_32_slime,
            Resources.blocks_32_snow,
            Resources.blocks_32_soul_sand,
            Resources.blocks_32_sponge,
            Resources.blocks_32_sponge_wet,
            Resources.blocks_32_stone,
            Resources.blocks_32_stone_andesite,
            Resources.blocks_32_stone_andesite_smooth,
            Resources.blocks_32_stone_diorite,
            Resources.blocks_32_stone_diorite_smooth,
            Resources.blocks_32_stone_granite,
            Resources.blocks_32_stone_granite_smooth,
            Resources.blocks_32_stone_slab_side,
            Resources.blocks_32_stone_slab_top,
            Resources.blocks_32_stonebrick,
            Resources.blocks_32_stonebrick_carved,
            Resources.blocks_32_stonebrick_cracked,
            Resources.blocks_32_stonebrick_mossy,
            Resources.blocks_32_structure_block,
            Resources.blocks_32_structure_block_corner,
            Resources.blocks_32_structure_block_data,
            Resources.blocks_32_structure_block_load,
            Resources.blocks_32_structure_block_save,
            Resources.blocks_32_tallgrass,
            Resources.blocks_32_tnt_bottom,
            Resources.blocks_32_tnt_side,
            Resources.blocks_32_tnt_top,
            Resources.blocks_32_torch_on,
            Resources.blocks_32_trapdoor,
            Resources.blocks_32_trip_wire,
            Resources.blocks_32_trip_wire_source,
            Resources.blocks_32_vine,
            Resources.blocks_32_water_flow,
            Resources.blocks_32_water_overlay,
            Resources.blocks_32_water_still,
            Resources.blocks_32_waterlily,
            Resources.blocks_32_web,
            Resources.blocks_32_wheat_stage_0,
            Resources.blocks_32_wheat_stage_1,
            Resources.blocks_32_wheat_stage_2,
            Resources.blocks_32_wheat_stage_3,
            Resources.blocks_32_wheat_stage_4,
            Resources.blocks_32_wheat_stage_5,
            Resources.blocks_32_wheat_stage_6,
            Resources.blocks_32_wheat_stage_7,
            Resources.blocks_32_wool_colored_black,
            Resources.blocks_32_wool_colored_blue,
            Resources.blocks_32_wool_colored_brown,
            Resources.blocks_32_wool_colored_cyan,
            Resources.blocks_32_wool_colored_gray,
            Resources.blocks_32_wool_colored_green,
            Resources.blocks_32_wool_colored_light_blue,
            Resources.blocks_32_wool_colored_lime,
            Resources.blocks_32_wool_colored_magenta,
            Resources.blocks_32_wool_colored_orange,
            Resources.blocks_32_wool_colored_pink,
            Resources.blocks_32_wool_colored_purple,
            Resources.blocks_32_wool_colored_red,
            Resources.blocks_32_wool_colored_silver,
            Resources.blocks_32_wool_colored_white,
            Resources.blocks_32_wool_colored_yellow*/
        });
        #endregion

        #region Lista_Sólo_Lectura_Nombres_Seleccionados
        internal static readonly List<String> Lista_Sólo_Lectura_Nombres_Seleccionados = new List<String>(new String[]
        {
            //"anvil_base",
            //"anvil_top_damaged_0",
            //"anvil_top_damaged_1",
            //"anvil_top_damaged_2",
            "beacon",
            //"bed_feet_end",
            //"bed_feet_side",
            //"bed_feet_top",
            //"bed_head_end",
            //"bed_head_side",
            //"bed_head_top",
            "bedrock",
            //"beetroots_stage_0",
            //"beetroots_stage_1",
            //"beetroots_stage_2",
            //"beetroots_stage_3",
            "bookshelf",
            //"brewing_stand",
            //"brewing_stand_base",
            "brick",
            //"cactus_bottom",
            //"cactus_side",
            //"cactus_top",
            //"cake_bottom",
            //"cake_inner",
            //"cake_side",
            //"cake_top",
            //"carrots_stage_0",
            //"carrots_stage_1",
            //"carrots_stage_2",
            //"carrots_stage_3",
            //"cauldron_bottom",
            //"cauldron_inner",
            "cauldron_side",
            //"cauldron_top",
            //"chain_command_block_back",
            //"chain_command_block_conditional",
            //"chain_command_block_front",
            //"chain_command_block_side",
            //"chorus_flower",
            //"chorus_flower_dead",
            //"chorus_plant",
            "clay",
            "coal_block",
            "coal_ore",
            //"coarse_dirt",
            "cobblestone",
            "cobblestone_mossy",
            "cocoa_stage_0",
            "cocoa_stage_1",
            "cocoa_stage_2",
            "command_block_back",
            "command_block_conditional",
            "command_block_front",
            "command_block_side",
            "comparator_off",
            "comparator_on",
            "crafting_table_front",
            "crafting_table_side",
            "crafting_table_top",
            "daylight_detector_inverted_top",
            "daylight_detector_side",
            "daylight_detector_top",
            "deadbush",
            "debug",
            "destroy_stage_0",
            "destroy_stage_1",
            "destroy_stage_2",
            "destroy_stage_3",
            "destroy_stage_4",
            "destroy_stage_5",
            "destroy_stage_6",
            "destroy_stage_7",
            "destroy_stage_8",
            "destroy_stage_9",
            "diamond_block",
            "diamond_ore",
            "dirt",
            "dirt_podzol_side",
            "dirt_podzol_top",
            "dispenser_front_horizontal",
            "dispenser_front_vertical",
            "door_acacia_lower",
            "door_acacia_upper",
            "door_birch_lower",
            "door_birch_upper",
            "door_dark_oak_lower",
            "door_dark_oak_upper",
            "door_iron_lower",
            "door_iron_upper",
            "door_jungle_lower",
            "door_jungle_upper",
            "door_spruce_lower",
            "door_spruce_upper",
            "door_wood_lower",
            "door_wood_upper",
            "double_plant_fern_bottom",
            "double_plant_fern_top",
            "double_plant_grass_bottom",
            "double_plant_grass_top",
            "double_plant_paeonia_bottom",
            "double_plant_paeonia_top",
            "double_plant_rose_bottom",
            "double_plant_rose_top",
            "double_plant_sunflower_back",
            "double_plant_sunflower_bottom",
            "double_plant_sunflower_front",
            "double_plant_sunflower_top",
            "double_plant_syringa_bottom",
            "double_plant_syringa_top",
            "dragon_egg",
            "dropper_front_horizontal",
            "dropper_front_vertical",
            "emerald_block",
            "emerald_ore",
            "enchanting_table_bottom",
            "enchanting_table_side",
            "enchanting_table_top",
            "end_bricks",
            "end_rod",
            "end_stone",
            "endframe_eye",
            "endframe_side",
            "endframe_top",
            "farmland_dry",
            "farmland_wet",
            "fern",
            "fire_layer_0",
            "fire_layer_1",
            "flower_allium",
            "flower_blue_orchid",
            "flower_dandelion",
            "flower_houstonia",
            "flower_oxeye_daisy",
            "flower_paeonia",
            "flower_pot",
            "flower_rose",
            "flower_tulip_orange",
            "flower_tulip_pink",
            "flower_tulip_red",
            "flower_tulip_white",
            "frosted_ice_0",
            "frosted_ice_1",
            "frosted_ice_2",
            "frosted_ice_3",
            "furnace_front_off",
            "furnace_front_on",
            "furnace_side",
            "furnace_top",
            "glass",
            "glass_black",
            "glass_blue",
            "glass_brown",
            "glass_cyan",
            "glass_gray",
            "glass_green",
            "glass_light_blue",
            "glass_lime",
            "glass_magenta",
            "glass_orange",
            "glass_pane_top",
            "glass_pane_top_black",
            "glass_pane_top_blue",
            "glass_pane_top_brown",
            "glass_pane_top_cyan",
            "glass_pane_top_gray",
            "glass_pane_top_green",
            "glass_pane_top_light_blue",
            "glass_pane_top_lime",
            "glass_pane_top_magenta",
            "glass_pane_top_orange",
            "glass_pane_top_pink",
            "glass_pane_top_purple",
            "glass_pane_top_red",
            "glass_pane_top_silver",
            "glass_pane_top_white",
            "glass_pane_top_yellow",
            "glass_pink",
            "glass_purple",
            "glass_red",
            "glass_silver",
            "glass_white",
            "glass_yellow",
            "glowstone",
            "gold_block",
            "gold_ore",
            "grass_path_side",
            "grass_path_top",
            "grass_side",
            "grass_side_overlay",
            "grass_side_snowed",
            "grass_top",
            "gravel",
            "hardened_clay",
            "hardened_clay_stained_black",
            "hardened_clay_stained_blue",
            "hardened_clay_stained_brown",
            "hardened_clay_stained_cyan",
            "hardened_clay_stained_gray",
            "hardened_clay_stained_green",
            "hardened_clay_stained_light_blue",
            "hardened_clay_stained_lime",
            "hardened_clay_stained_magenta",
            "hardened_clay_stained_orange",
            "hardened_clay_stained_pink",
            "hardened_clay_stained_purple",
            "hardened_clay_stained_red",
            "hardened_clay_stained_silver",
            "hardened_clay_stained_white",
            "hardened_clay_stained_yellow",
            "hay_block_side",
            "hay_block_top",
            "hopper_inside",
            "hopper_outside",
            "hopper_top",
            "ice",
            "ice_packed",
            "iron_bars",
            "iron_block",
            "iron_ore",
            "iron_trapdoor",
            "itemframe_background",
            "jukebox_side",
            "jukebox_top",
            "ladder",
            "lapis_block",
            "lapis_ore",
            "lava_flow",
            "lava_still",
            "leaves_acacia",
            "leaves_big_oak",
            "leaves_birch",
            "leaves_jungle",
            "leaves_oak",
            "leaves_spruce",
            "lever",
            "log_acacia",
            "log_acacia_top",
            "log_big_oak",
            "log_big_oak_top",
            "log_birch",
            "log_birch_top",
            "log_jungle",
            "log_jungle_top",
            "log_oak",
            "log_oak_top",
            "log_spruce",
            "log_spruce_top",
            "melon_side",
            "melon_stem_connected",
            "melon_stem_disconnected",
            "melon_top",
            "mob_spawner",
            "mushroom_block_inside",
            "mushroom_block_skin_brown",
            "mushroom_block_skin_red",
            "mushroom_block_skin_stem",
            "mushroom_brown",
            "mushroom_red",
            "mycelium_side",
            "mycelium_top",
            "nether_brick",
            "nether_wart_stage_0",
            "nether_wart_stage_1",
            "nether_wart_stage_2",
            "netherrack",
            "noteblock",
            "obsidian",
            "piston_bottom",
            "piston_inner",
            "piston_side",
            "piston_top_normal",
            "piston_top_sticky",
            "planks_acacia",
            "planks_big_oak",
            "planks_birch",
            "planks_jungle",
            "planks_oak",
            "planks_spruce",
            "portal",
            "potatoes_stage_0",
            "potatoes_stage_1",
            "potatoes_stage_2",
            "potatoes_stage_3",
            "prismarine_bricks",
            "prismarine_dark",
            "prismarine_rough",
            "pumpkin_face_off",
            "pumpkin_face_on",
            "pumpkin_side",
            "pumpkin_stem_connected",
            "pumpkin_stem_disconnected",
            "pumpkin_top",
            "purpur_block",
            "purpur_pillar",
            "purpur_pillar_top",
            "quartz_block_bottom",
            "quartz_block_chiseled",
            "quartz_block_chiseled_top",
            "quartz_block_lines",
            "quartz_block_lines_top",
            "quartz_block_side",
            "quartz_block_top",
            "quartz_ore",
            "rail_activator",
            "rail_activator_powered",
            "rail_detector",
            "rail_detector_powered",
            "rail_golden",
            "rail_golden_powered",
            "rail_normal",
            "rail_normal_turned",
            "red_sand",
            "red_sandstone_bottom",
            "red_sandstone_carved",
            "red_sandstone_normal",
            "red_sandstone_smooth",
            "red_sandstone_top",
            "redstone_block",
            "redstone_dust_dot",
            "redstone_dust_line0",
            "redstone_dust_line1",
            "redstone_dust_overlay",
            "redstone_lamp_off",
            "redstone_lamp_on",
            "redstone_ore",
            "redstone_torch_off",
            "redstone_torch_on",
            "reeds",
            "repeater_off",
            "repeater_on",
            "repeating_command_block_back",
            "repeating_command_block_conditional",
            "repeating_command_block_front",
            "repeating_command_block_side",
            "sand",
            "sandstone_bottom",
            "sandstone_carved",
            "sandstone_normal",
            "sandstone_smooth",
            "sandstone_top",
            "sapling_acacia",
            "sapling_birch",
            "sapling_jungle",
            "sapling_oak",
            "sapling_roofed_oak",
            "sapling_spruce",
            "sea_lantern",
            "slime",
            "snow",
            "soul_sand",
            "sponge",
            "sponge_wet",
            "stone",
            "stone_andesite",
            "stone_andesite_smooth",
            "stone_diorite",
            "stone_diorite_smooth",
            "stone_granite",
            "stone_granite_smooth",
            "stone_slab_side",
            "stone_slab_top",
            "stonebrick",
            "stonebrick_carved",
            "stonebrick_cracked",
            "stonebrick_mossy",
            "structure_block",
            "structure_block_corner",
            "structure_block_data",
            "structure_block_load",
            "structure_block_save",
            "tallgrass",
            "tnt_bottom",
            "tnt_side",
            "tnt_top",
            "torch_on",
            "trapdoor",
            "trip_wire",
            "trip_wire_source",
            "vine",
            "water_flow",
            "water_overlay",
            "water_still",
            "waterlily",
            "web",
            "wheat_stage_0",
            "wheat_stage_1",
            "wheat_stage_2",
            "wheat_stage_3",
            "wheat_stage_4",
            "wheat_stage_5",
            "wheat_stage_6",
            "wheat_stage_7",
            "wool_colored_black",
            "wool_colored_blue",
            "wool_colored_brown",
            "wool_colored_cyan",
            "wool_colored_gray",
            "wool_colored_green",
            "wool_colored_light_blue",
            "wool_colored_lime",
            "wool_colored_magenta",
            "wool_colored_orange",
            "wool_colored_pink",
            "wool_colored_purple",
            "wool_colored_red",
            "wool_colored_silver",
            "wool_colored_white",
            "wool_colored_yellow",
        });
        #endregion

        internal static List<String> Lista_Bloques_Personalizados = new List<String>();
        internal static List<String> Lista_Bloques_Predeterminados = new List<String>();
        internal static List<KeyValuePair<String, Color>> Lista_Texturas_Personalizadas = new List<KeyValuePair<String, Color>>();

        internal static List<Color> Lista_Colores_Personalizados = new List<Color>();
        internal static List<String> Lista_Nombres_Personalizados = new List<String>();

        internal static ImageList Lista_Imágenes_16 = new ImageList();
        internal static ImageList Lista_Imágenes_32 = new ImageList();

        internal static String Título_Aplicación = "Pixel Art for Minecraft de Jupi Soft";
        //internal static Lenguajes Lenguaje_Actual = Lenguajes.Inglés;
        internal static System.Random Rand = new System.Random();

        internal static readonly String Ruta_Blocks_16 = Application.StartupPath + "\\blocks_16";
        internal static readonly String Ruta_Blocks_32 = Application.StartupPath + "\\blocks_32";

        internal static readonly String Ruta_Pngquant = Application.StartupPath + "\\Pngquant.exe";
        internal static readonly String Ruta_Pngquant_Salida = Application.StartupPath + "\\Minecraft_Pixel_Art.png";

        internal static String Ruta_Imagen_Pngquant = Application.StartupPath + "\\Imagen_Pngquant.png";
    }
}

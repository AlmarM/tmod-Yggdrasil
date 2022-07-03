using Terraria.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Armor;
using Yggdrasil.Content.Items.Consumables;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons.RuneTablets;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Content.UI;
using Terraria.ModLoader.IO;

namespace Yggdrasil.World
{
    public class VikingInvasionWorld : ModSystem
    {
        public static bool vikingInvasion = false;
        public static bool downedVikingInvasion = false;
        public static int vikingKilled = 0;

        public override void SaveWorldData(TagCompound tag)
        {
            var data = new TagCompound();
            var downed = new List<string>();

            if (downedVikingInvasion)
                downed.Add("vikinginvasion");

            data.Add("downed", downed);
            data.Add("vikinginvasion", vikingInvasion);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");

            downedVikingInvasion = downed.Contains("vikinginvasion");

            vikingInvasion = tag.GetBool("vikinginvasion");
        }

        public override void OnWorldLoad()
        {
            vikingInvasion = false;
            vikingKilled = 0;
        }

        public override void PostUpdateWorld()
        {
            //Set that the invasion was successfuly repelled at 200kill if it's not done already
            if (vikingInvasion && vikingKilled >= 200 && !downedVikingInvasion)
            {
                downedVikingInvasion = true;
            }

            //Viking leaves if daytime comes
            if (!Main.dayTime && vikingInvasion)
            {
                Main.NewText("The vikings have left!", 174, 128, 79);
                vikingInvasion = false;
                vikingKilled = 0;
            }

            //Invasion is repelled if 200 vikings are killed
            if (vikingInvasion && vikingKilled >= 200)
            {
                Main.NewText("The vikings have been defeated!", 174, 128, 79);
                vikingInvasion = false;
                vikingKilled = 0;
            }

            //if (downedVikingInvasion)
           // Main.NewText("ItsDown");

        }

    }

    public class VikingInvasionWorldEffect : ModSceneEffect
    {
        public override int Music => MusicID.OtherworldlyInvasion;

        public override bool IsSceneEffectActive(Player player)
        {
            return VikingInvasionWorld.vikingInvasion;
        }

        public override SceneEffectPriority Priority => SceneEffectPriority.Event;

    }
}
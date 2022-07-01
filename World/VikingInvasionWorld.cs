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
        public static bool dayTimeSwitched;
        private static bool dayTimeLast;

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
            dayTimeSwitched = false;
            dayTimeLast = Main.dayTime;
        }

        public override void PostUpdateWorld()
        {
            if (Main.dayTime != dayTimeLast)
                dayTimeSwitched = true;
            else
                dayTimeSwitched = false;

            dayTimeLast = Main.dayTime;

            if (vikingInvasion && dayTimeSwitched && !downedVikingInvasion)
                downedVikingInvasion = true;
            
            //A full day cycle ends the invasion
            if (dayTimeSwitched)
            {
                if (!Main.dayTime && vikingInvasion)
                    vikingInvasion = false;
            }
        }
    }

	
}
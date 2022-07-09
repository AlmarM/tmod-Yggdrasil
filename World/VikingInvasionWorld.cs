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
using System.IO;

namespace Yggdrasil.World
{
    public class VikingInvasionWorld : ModSystem
    {
        public static bool vikingInvasion;
        public bool downedVikingInvasion;
        public static bool valkyrieUp;
        public static int vikingKilled;
        public override void OnWorldLoad()
        {
            vikingInvasion = false;
            vikingKilled = 0;
            downedVikingInvasion = false;
            valkyrieUp = false;
        }

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

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[1] = downedVikingInvasion;
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedVikingInvasion = flags[1];
        }

        public override void PostUpdateWorld()
        {
            //Set that the invasion was successfuly repelled at 200kill if it's not done already
            if (vikingInvasion && vikingKilled >= 200 && !downedVikingInvasion)
            {
                downedVikingInvasion = true;
                if (Main.netMode != NetmodeID.SinglePlayer)
                    NetMessage.SendData(MessageID.WorldData);
            }

            //Viking leaves if daytime comes
            if (!Main.dayTime && vikingInvasion)
            {
                Main.NewText("The vikings have left!", 174, 128, 79);
                vikingInvasion = false;
                vikingKilled = 0;
            }

            //Hardmode invasion is repelled if 300 vikings are killed
            if (Main.hardMode && vikingInvasion && vikingKilled >= 300)
            {
                Main.NewText("The vikings have been defeated!", 174, 128, 79);
                vikingInvasion = false;
                vikingKilled = 0;
            }

            //Invasion is repelled if 200 vikings are killed
            if (!Main.hardMode && vikingInvasion && vikingKilled >= 200)
            {
                Main.NewText("The vikings have been defeated!", 174, 128, 79);
                vikingInvasion = false;
                vikingKilled = 0;
            }

            //if (valkyrieUp)
            //Main.NewText("Trigger");
            //Main.NewText(vikingKilled);

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
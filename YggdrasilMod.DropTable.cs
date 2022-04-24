using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Yggdrasil.Items.Others;
using Yggdrasil.Items.Weapons;

namespace Yggdrasil;

public partial class YggdrasilMod : Mod
{
    public class YggdrasilGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.QueenBee)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BeeRunicAxe>(), 3));
            }

            if ((npc.type == NPCID.AngryBones) || (npc.type == NPCID.ShortBones) || (npc.type == NPCID.BigBoned) || (npc.type >= NPCID.AngryBonesBig && npc.type <= NPCID.AngryBonesBigMuscle))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OccultShard>(), 5));
            }
        }
    }
}
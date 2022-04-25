using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons;

namespace Yggdrasil.Globals;

public class YggdrasilGlobalNPC : GlobalNPC
{
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
    {
        switch (npc.type)
        {
            case NPCID.QueenBee:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BeeRunicAxe>(), 3));
                break;

            case NPCID.AngryBones or NPCID.ShortBones or NPCID.BigBoned
                or >= NPCID.AngryBonesBig and <= NPCID.AngryBonesBigMuscle:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OccultShard>(), 5));
                break;
        }
    }
}
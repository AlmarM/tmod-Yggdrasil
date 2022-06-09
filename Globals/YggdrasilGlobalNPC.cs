using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Globals;

public class YggdrasilGlobalNPC : GlobalNPC
{
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
    {
        switch (npc.type)
        {
            case NPCID.QueenBee:
                
                break;

            case NPCID.AngryBones or NPCID.ShortBones or NPCID.BigBoned or >= NPCID.AngryBonesBig and <= NPCID.AngryBonesBigMuscle:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OccultShard>(), 5));
                break;
            case NPCID.WallofFlesh:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RunemasterEmblem>(), 4));
                break;
        }
    }
}
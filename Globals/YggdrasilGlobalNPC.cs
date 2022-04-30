using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons.Runic;
using Yggdrasil.Content.Items.Accessories;

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

            case NPCID.AngryBones or NPCID.ShortBones or NPCID.BigBoned or >= NPCID.AngryBonesBig and <= NPCID.AngryBonesBigMuscle:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OccultShard>(), 5));
                break;
            case NPCID.WallofFlesh:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RunemasterEmblem>(), 4));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FleshRunicAxe>(), 4));
                break;
            case NPCID.BloodZombie or NPCID.Drippler:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodDrops>(), 4));
                break;

        }
    }
}
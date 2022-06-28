using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons.RuneTablets;

namespace Yggdrasil.Globals;

public class YggdrasilGlobalNPC : GlobalNPC
{
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
    {
        switch (npc.type)
        {
            case NPCID.AngryBones or NPCID.ShortBones or NPCID.BigBoned or >= NPCID.AngryBonesBig and <= NPCID.AngryBonesBigMuscle:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OccultShard>(), 5));
                break;
            case NPCID.WallofFlesh:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RunemasterEmblem>(), 4));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TabletofFlesh>(), 4));
                break;
            case NPCID.IcyMerman:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GlacierShards>(), 10));
                break;
            case NPCID.IceMimic:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GlacierShards>(), 6));
                break;
            case NPCID.BigMimicHallow:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LokisGift>(), 4));
                break;
            case NPCID.Mothron:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TrueHeroFragment>(), 3));
                break;
        }
    }
}
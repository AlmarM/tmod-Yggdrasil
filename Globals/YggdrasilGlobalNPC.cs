using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons.RuneTablets;
using Yggdrasil.World;
using Yggdrasil.Content.NPCs;
using Yggdrasil.Content.NPCs.Jungle;
using Yggdrasil.Content.NPCs.Vikings;

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
            case NPCID.PirateShip:
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CreditSlab>(), 4));
                break;
        }
    }
    public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
    {
        //Changing the max spawn and spawn rate
        if (VikingInvasionWorld.vikingInvasion && player.ZoneOverworldHeight)
        {
            maxSpawns = (int)(maxSpawns * 4f);
            spawnRate = 6;
        }
    }
    public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
    { 

        //Setting the new spawn pool of vikings
        if (VikingInvasionWorld.vikingInvasion && spawnInfo.Player.ZoneOverworldHeight)
        {
            pool.Clear();

            pool.Add(ModContent.NPCType<VikingSwordMan>(), 5f);
            pool.Add(ModContent.NPCType<VikingArcher>(), 3f);
            pool.Add(ModContent.NPCType<FemaleVikingArcher>(), 3f);
            pool.Add(ModContent.NPCType<VikingAxeMan>(), 3f);
            pool.Add(ModContent.NPCType<VikingSpearman>(), 2f);
            pool.Add(ModContent.NPCType<VikingShieldMaiden>(), 4f);

            if (!NPC.AnyNPCs(ModContent.NPCType<Volva>()))
                pool.Add(ModContent.NPCType<Volva>(), .5f);

            if (!NPC.AnyNPCs(ModContent.NPCType<Berserker>()))
                pool.Add(ModContent.NPCType<Berserker>(), .3f);

            //Hardmode
            if (Main.hardMode)
            {
                pool.Add(ModContent.NPCType<GrayWolf>(), 1f);
                pool.Add(ModContent.NPCType<OdinRaven>(), 1.5f);  
            }

            if (Main.hardMode && VikingInvasionWorld.vikingKilled >= 200 && !NPC.AnyNPCs(ModContent.NPCType<Valkyrie>()) && !VikingInvasionWorld.valkyrieUp)
            {
                pool.Add(ModContent.NPCType<Valkyrie>(), 100f);
                VikingInvasionWorld.valkyrieUp = true;
            }
        }

        return;
    }
}
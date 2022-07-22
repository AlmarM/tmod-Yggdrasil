using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.GameContent.ItemDropRules;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.World;
using Yggdrasil.Content.NPCs.Vikings;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Tiles;
using Microsoft.Xna.Framework.Input;
using Yggdrasil.Content.NPCs.Svartalvheim;
using Yggdrasil.Extensions;
using Yggdrasil.Runemaster.Content.Items.Weapons.Tablets;

namespace Yggdrasil.Globals;

public class YggdrasilGlobalNPC : GlobalNPC
{
    public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
    {
        switch (npc.type)
        {
            case NPCID.AngryBones or NPCID.ShortBones or NPCID.BigBoned
                or >= NPCID.AngryBonesBig and <= NPCID.AngryBonesBigMuscle:
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
            case NPCID.Golem:
                if (!Main.expertMode || !Main.masterMode)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SunPebble>(), 1, 3, 3));
                }

                break;
            case NPCID.Plantera:
                if (!Main.expertMode || !Main.masterMode)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SturdyLeaf>(), 1, 30, 30));
                }

                break;
            case NPCID.MoonLordCore:
                if (!Main.expertMode || !Main.masterMode)
                {
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Ragnarok>(), 4));
                }

                break;
        }
    }

    public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
    {
        YggdrasilPlayer yggdrasilPlayer = player.GetYggdrasilPlayer();

        //Changing the max spawn and spawn rate
        if (yggdrasilPlayer.ZoneSvartalvheim)
        {
            spawnRate = (int)(spawnRate * 0.9f);
            maxSpawns = (int)(maxSpawns * 1.1f);
        }

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

            //Hardmode spawns
            if (Main.hardMode)
            {
                pool.Add(ModContent.NPCType<GrayWolf>(), 1f);
                pool.Add(ModContent.NPCType<OdinRaven>(), 1.5f);
            }

            if (Main.hardMode && VikingInvasionWorld.vikingKilled >= 200 &&
                !NPC.AnyNPCs(ModContent.NPCType<Valkyrie>()) && !VikingInvasionWorld.valkyrieUp)
            {
                pool.Add(ModContent.NPCType<Valkyrie>(), 100f);
                VikingInvasionWorld.valkyrieUp = true;
            }
        }

        //Changing the spawnpool when the player is in Svartalvheim
        YggdrasilPlayer yggdrasilPlayer = spawnInfo.Player.GetYggdrasilPlayer();
        if (yggdrasilPlayer.ZoneSvartalvheim)
        {
            pool.Clear();

            pool.Add(ModContent.NPCType<DwarfPeon>(), 4f);
            pool.Add(ModContent.NPCType<DwarfWarrior>(), 5f);
            pool.Add(ModContent.NPCType<SvartalvheimBat>(), 5.5f);
            pool.Add(ModContent.NPCType<Svartalslime>(), 3f);

            //Hardmode spawns
            if (Main.hardMode)
            {
                pool.Add(ModContent.NPCType<DwarfThunderer>(), 2f);
                pool.Add(ModContent.NPCType<DwarfSpirit>(), 1f);
            }

            //Hardmode post-plantera spawns
            if (Main.hardMode && NPC.downedPlantBoss)
            {
                pool.Add(ModContent.NPCType<DwarfThunderer>(), 2f);
            }
        }
    }
}
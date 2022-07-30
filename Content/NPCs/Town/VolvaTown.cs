using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Yggdrasil.Content.Items.Consumables;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Misc;
using Yggdrasil.Content.Items.Weapons.Vikings;
using Yggdrasil.Content.Projectiles.Magic;
using Yggdrasil.Runemaster.Content.Items.Accessories;
using Yggdrasil.Runes.Content.Items.Minor;
using Yggdrasil.World;

namespace Yggdrasil.Content.NPCs.Town
{
    [AutoloadHead]
    public class VolvaTown : YggdrasilNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from localization files, but the commented line below is the normal approach.
            DisplayName.SetDefault("Volva");
            Main.npcFrameCount[Type] = 25; // The amount of frames the NPC has

            NPCID.Sets.ExtraFramesCount[Type] =
                9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] =
                700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] =
                30; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 30;
            //NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = -1 // -1 is left and 1 is right.
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Hate)
                .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Mechanic, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Nurse, AffectionLevel.Like)
                .SetNPCAffection(229, AffectionLevel.Dislike) //Pirate
                .SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Hate)
                ;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true; // Sets NPC to be a Town NPC
            NPC.friendly = true; // NPC Will not attack player
            NPC.width = 30;
            NPC.height = 54;
            NPC.aiStyle = 7;
            NPC.damage = 30;
            NPC.defense = 15;
            NPC.lifeMax = 300;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                // Sets the preferred biomes of this town NPC listed in the bestiary.
                // With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,

                // Sets your NPC's flavor text in the bestiary.
                new FlavorTextBestiaryInfoElement(
                    "It is told that Völva have the ability to foretell future events and perform sorcery"),
            });
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (YggdrasilWorld.downedVikingInvasion)
            {
                return true;
            }

            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Astrid",
                "Frida",
                "Hilda",
                "Gunhild",
                "Liv",
                "Eivor",
                "Thyra"
            };
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            // These are things that the NPC has a chance of telling you when you talk to it.
            chat.Add(Language.GetTextValue("Hejsan"));
            chat.Add(Language.GetTextValue("By Freya, this part of the world is lovely"));
            chat.Add(Language.GetTextValue("On my way here I came across a weird looking merchant"), 0.2);

            if (!NPC.downedGolemBoss)
            {
                chat.Add(
                    Language.GetTextValue(
                        "There is a strong being living in a temple under the jungle, once you've slain the beast, I may be able to bargain something precious with you"),
                    0.1);
            }

            return chat; // chat is implicitly cast to a string.
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingDistaff>()));
        }

        // Make this Town NPC teleport to the King and/or Queen statue when triggered.
        public override bool CanGoToStatue(bool toQueenStatue) => true;

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 30;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection,
            ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<GlacierStaffProjectile>();
            attackDelay = 1;
        }

        public override void SetChatButtons(ref string button, ref string button2) =>
            button = Language.GetTextValue("LegacyInterface.28");

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
                shop = true;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<VikingDistaff>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<ArmRing>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<RuneBag>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<RunicPotion>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<MeadBasic>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<FrostEssence>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Linnen>());

            if (NPC.downedBoss1)
            {
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<MinorAlgizRune>());
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<MinorBerkanoRune>());
            }

            if (NPC.downedBoss3)
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<OccultShard>());

            if (Main.hardMode)
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<RunemasterEmblem>());

            if (NPC.downedPlantBoss)
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<SturdyLeaf>());

            if (NPC.downedGolemBoss)
            {
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<SunPebble>());
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<SvartalvheimKey>());
            }

            if (NPC.downedAncientCultist)
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<TrueHeroFragment>());
        }
    }
}
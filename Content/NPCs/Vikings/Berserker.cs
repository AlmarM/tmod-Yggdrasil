using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.Items.Consumables;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Misc;
using Yggdrasil.Content.Items.Weapons.Vikings;
using Yggdrasil.Runemaster.Content.Items.Armors;
using Yggdrasil.World;

namespace Yggdrasil.Content.NPCs.Vikings;

public class Berserker : YggdrasilNPC
{
    //Variable used to make sure the NPC keeps spawned during the day befause Fighter AI despawn itself during day
    //Might mess up in multiplayer
    private int _timeLeft;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Berserker");

        Main.npcFrameCount[Type] = 10;

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });

        NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[] {
                    BuffID.Frostburn,
                    BuffID.Confused
                }
        };
        NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
    }

    public override void SetDefaults()
    {
        NPC.width = 30;
        NPC.height = 40;
        NPC.damage = 50;
        NPC.defense = 10;
        NPC.lifeMax = 650;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 150f;
        NPC.knockBackResist = 0;
        NPC.aiStyle = 3;
        AIType = 213;
        AnimationType = 482;

        Banner = ModContent.NPCType<Berserker>();
        BannerItem = ModContent.ItemType<BerserkerBanner>();
    }

    //Setting the variable in PreAI to make sure the NPC keeps spawned during the day
    //Might mess up in multiplayer
    public override bool PreAI()
    {
        _timeLeft = NPC.timeLeft;

        return base.PreAI();
    }

    public override void AI()
    {
        NPC.timeLeft = _timeLeft;

        NPC.TargetClosest();
        NPC.netUpdate = true;        
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("In the Old Norse written corpus, berserker were those who were said to have fought in a trance-like fury")
            });
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingKey>()));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BerserkerBoots>()));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BerserkerChest>()));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BerserkerHelmet>()));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingDaneAxe>(), 3));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodDrops>(), 1, 2, 5));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Raggmunk>(), 100));
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        for (var i = 0; i < 10; i++)
        {
            int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);

            Dust dust = Main.dust[dustIndex];
            dust.velocity.X += Main.rand.Next(-50, 51) * 0.01f;
            dust.velocity.Y += Main.rand.Next(-50, 51) * 0.01f;
            dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
        }

        Player player = Main.player[NPC.target];

        
        if (NPC.life < (NPC.lifeMax * 0.35f))
        {
            int projectileCount = 5;

            const float projectileSpeed = 6f;
            const float radius = 25f;

            float delta = MathF.PI * 2 / projectileCount;
            if (Main.rand.Next(100) < 25)
            {
                for (var i = 0; i < projectileCount; i++)
                {
                    float theta = delta * i;
                    var position = NPC.Center + Vector2.One.RotatedBy(theta) * radius;

                    Vector2 direction = position - NPC.Center;
                    direction = Vector2.Normalize(direction);
                    direction = Vector2.Multiply(direction, projectileSpeed);

                    Projectile.NewProjectile(null, position, direction, ProjectileID.FrostWave, 15, 2, player.whoAmI);
                }
            }
        }

    }

    public override void OnKill()
    {
        if (VikingInvasionWorld.vikingInvasion)
            VikingInvasionWorld.vikingKilled += 5;
    }
}
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Misc;
using Yggdrasil.Content.Items.Weapons.Vikings;
using Yggdrasil.World;

namespace Yggdrasil.Content.NPCs.Vikings;

public class OdinRaven : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Odin's Raven");

        Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Parrot];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.Parrot);
        NPC.damage = 25;
        NPC.defense = 15;
        NPC.lifeMax = 70;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 150f;
        NPC.knockBackResist = 0.7f;
        AIType = NPCID.Parrot;
        AnimationType = NPCID.Parrot;

        Banner = ModContent.NPCType<OdinRaven>();
        BannerItem = ModContent.ItemType<OdinsRavenBanner>();
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("Huggin 'thought' and Munnin 'memory' are a pair of ravens that fly all over Midgard and bring information to the god Odin.")
            });
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) => spawnInfo.Player.ZoneSnow && Main.hardMode ? 0.3f : 0f;

    public override void AI()
    {
        NPC.TargetClosest(true);
        NPC.netUpdate = true;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodDrops>(), 5));
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
    }

    public override void OnKill()
    {
        if (VikingInvasionWorld.vikingInvasion)
        VikingInvasionWorld.vikingKilled += 1;
    }
}
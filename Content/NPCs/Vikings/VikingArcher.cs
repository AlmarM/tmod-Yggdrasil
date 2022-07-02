using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Others;
using Yggdrasil.Content.Items.Weapons.Vikings;
using Yggdrasil.World;

namespace Yggdrasil.Content.NPCs.Vikings;

public class VikingArcher : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viking Archer");

        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.GoblinArcher];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        //NPC.CloneDefaults(NPCID.GoblinArcher);
        NPC.width = 18;
        NPC.height = 40;
        NPC.damage = 30;
        NPC.defense = 6;
        NPC.lifeMax = 80;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 200f;
        NPC.knockBackResist = 0.2f;
        NPC.aiStyle = 3;
        AIType = NPCID.GoblinArcher;
        AnimationType = NPCID.GoblinArcher;

        Banner = ModContent.NPCType<VikingArcher>();
        BannerItem = ModContent.ItemType<VikingBanner>();
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("It is said that dying from an arrow in battle would be the most shameful death for a Viking. It all depends if you're the one holding the bow.")
            });
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) => spawnInfo.Player.ZoneSnow ? 0.3f : 0f;

    public override void AI()
    {
        NPC.TargetClosest();
        NPC.netUpdate = true;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingKey>(), 50));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingBow>(), 50));
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
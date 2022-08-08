using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.NPCs.Jungle;

public class Backahast : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Brook Horse");

        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Unicorn];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.Unicorn);
        NPC.damage = 60;
        NPC.defense = 30;
        NPC.lifeMax = 420;
        NPC.value = 200f;
        AIType = NPCID.Unicorn;
        AnimationType = NPCID.Unicorn;
        NPC.knockBackResist = 0.7f;
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
        {
            // Sets the spawning conditions of this NPC that is listed in the bestiary.
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,

            // Sets the description of this NPC that is listed in the bestiary.
            new FlavorTextBestiaryInfoElement(
                "The Brook Horse is a treacherous predator that lurks in streams and lakes.")
        });
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) =>
        spawnInfo.Player.ZoneJungle && Main.hardMode ? 0.2f : 0f;

    public override void AI()
    {
        NPC.TargetClosest();
        NPC.netUpdate = true;
    }

    public override void OnHitPlayer(Player player, int damage, bool crit)
    {
        player.AddBuff(BuffID.Confused, TimeUtils.SecondsToTicks(2));
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.Grapes, 40));
    }
}
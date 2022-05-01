using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.NPCs.Snow;

public class Draugr : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Draugr");

        Main.npcFrameCount[Type] = Main.npcFrameCount[524];

        // Influences how the NPC looks in the Bestiary
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            Velocity = 1f
        });
    }

    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.DesertGhoul);
        NPC.damage = 25;
        NPC.defense = 5;
        NPC.lifeMax = 80;
        NPC.value = 200f;
        AIType = NPCID.DesertGhoul;
        AnimationType = NPCID.DesertGhoul;
        NPC.knockBackResist = 0.2f;
        //npc.buffImmune[BuffID.Confused] = true;
        NPC.buffImmune[BuffID.Frostburn] = true;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.ZoneSnow)
        {
            return SpawnCondition.Underground.Chance * 2f;
        }

        return 0f;
    }

    public override void AI()
    {
        NPC.TargetClosest();
        NPC.netUpdate = true;
    }

    public override void OnHitPlayer(Player player, int damage, bool crit)
    {
        player.AddBuff(BuffID.Frostburn, TimeUtils.SecondsToTicks(3));
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostEssence>()));
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        for (int i = 0; i < 3; i++)
        {
            int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Electric);

            Dust dust = Main.dust[dustIndex];
            dust.velocity.X += Main.rand.Next(-50, 51) * 0.01f;
            dust.velocity.Y += Main.rand.Next(-50, 51) * 0.01f;
            dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
        }
    }
}
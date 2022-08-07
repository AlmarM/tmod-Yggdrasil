using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Yggdrasil.Content.NPCs;

namespace Yggdrasil.CheeseMaking.Content.NPCs;

public class Cow : YggdrasilNPC
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cow");
    }

    public override void SetDefaults()
    {
        NPC.width = 66;
        NPC.height = 52;
        NPC.aiStyle = 7;
        NPC.damage = 0;
        NPC.defense = 0;
        NPC.lifeMax = 5;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.Player.ZoneForest ? SpawnCondition.TownCritter.Chance : 0f;
    }
}
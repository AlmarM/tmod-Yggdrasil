using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.NPCs;

public class GlobalRuneNpc : GlobalNPC
{
    public override void OnKill(NPC npc)
    {
        // If the kill was made by a player
        if (npc.lastInteraction < 255)
        {
            Player player = Main.player[npc.lastInteraction];

            var runePlayer = player.GetModPlayer<RunePlayer>();
            runePlayer.ConsecutiveKills++;
        }
    }
}
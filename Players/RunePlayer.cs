using Terraria.ModLoader;

namespace Yggdrasil.Players;

public class RunePlayer : ModPlayer
{
    public int ConsecutiveKills { get; set; }

    public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
    {
        ConsecutiveKills = 0;
    }
}
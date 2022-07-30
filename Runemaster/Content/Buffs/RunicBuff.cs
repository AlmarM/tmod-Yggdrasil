using Terraria;
using Yggdrasil.Content.Buffs;

namespace Yggdrasil.Runemaster.Content.Buffs;

public class RunicBuff : YggdrasilBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Runic Buff");
        Description.SetDefault("20% increased runic damage");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetDamage<RunicDamageClass>() += 0.2f;
    }
}
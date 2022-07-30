using Terraria;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Runemaster.Content.Buffs;

public class HoneyMeadBuff : YggdrasilBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Honey Mead Buff");
        Description.SetDefault("Increases insanity gauge by 5");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<RunemasterPlayer>().InsanityThreshold += 5;
    }
}
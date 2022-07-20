using Terraria;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class HoneyMeadBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

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
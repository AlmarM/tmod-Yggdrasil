using Terraria;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class RunicBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

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
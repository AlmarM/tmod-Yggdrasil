using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Configs;

namespace Yggdrasil.Content.Buffs;

public class CotinBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cotin Focus");
        Description.SetDefault(
            $"Grants +2 runic damage" +
            $"\n10% increase runic attack speed");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetDamage<RunicDamageClass>().Flat += 2;
        player.SetEffect<CotinBuff>();
    }

}
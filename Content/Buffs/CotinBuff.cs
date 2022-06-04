using Terraria;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class CotinBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cotin Focus");
        Description.SetDefault(
            "Increases defense by 1" +
            "\nGrants +2 runic damage" +
            "\n10% increase runic attack speed");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 1;
        player.GetDamage<RunicDamageClass>().Flat += 2;
        player.SetEffect<CotinBuff>();
    }

}
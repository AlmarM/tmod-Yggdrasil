using Terraria;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class MeadowBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Meadow Focus");
        Description.SetDefault(
            "Increases defense by 5" +
            "\nGrants +3 runic damage" +
            "\n10% increase runic attack speed");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 5;
        player.GetDamage<RunicDamageClass>().Flat += 3;
        player.SetEffect<MeadowBuff>();
    }

}
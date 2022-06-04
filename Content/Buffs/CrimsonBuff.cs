using Terraria;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class CrimsonBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Crimson Focus");
        Description.SetDefault(
            "Increases defense by 4" +
            "\nGrants +10 max life" +
            "\nGrants +3 runic damage");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 4;
        player.statLifeMax2 += 10;
        player.GetDamage<RunicDamageClass>().Flat += 3;
    }

}
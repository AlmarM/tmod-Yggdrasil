using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Configs;

namespace Yggdrasil.Content.Buffs;

public class DemonicBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Demonic Focus");
        Description.SetDefault(
            "Increases defense by 4" +
            "\nGrants +10% thorns" +
            "\nGrants +3 runic damage");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 4;
        player.thorns += 0.1f;
        player.GetDamage<RunicDamageClass>().Flat += 3;
    }

}
using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Configs;

namespace Yggdrasil.Content.Buffs;

public class BloodyBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bloody Focus");
        Description.SetDefault(
            "Increases defense by 4" +
            "\nGrants 3% damage reduction" +
            "\nHitting an enemy with a runic weapon has a chance to generate a heart");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 4;
        player.endurance += 0.03f;
        player.SetEffect<BloodyBuff>();
    }

}
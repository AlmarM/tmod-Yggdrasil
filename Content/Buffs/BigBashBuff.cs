using Terraria;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class BigBashBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Big Focus");
        Description.SetDefault(
            "Increases defense by 5" +
            "\nGrants immunity to knockback" +
            "\nGrants 5% damage reduction");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 5;
        player.noKnockback = true;
        player.endurance += 0.05f;
    }

}
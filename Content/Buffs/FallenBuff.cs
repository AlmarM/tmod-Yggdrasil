using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Configs;

namespace Yggdrasil.Content.Buffs;

public class FallenBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Fallen Star Focus");
        Description.SetDefault(
            "Increases defense by 5" +
            "\nGrants immunity to knockback");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 5;
        player.noKnockback = true;
    }

}
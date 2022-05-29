using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class WoodenBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Wooden Focus");
        Description.SetDefault(
            "Increases defense by 2");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 2;
    }
}
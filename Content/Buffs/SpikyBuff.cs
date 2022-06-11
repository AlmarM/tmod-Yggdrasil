using Terraria;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class SpikyBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spiky Buff");
        Description.SetDefault("Attackers also take a lot of damage");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.thorns += 1f;
    }
}
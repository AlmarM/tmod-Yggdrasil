using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class GlacierBarrier : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Glacier Barrier");
        Description.SetDefault($"Reduces damage taken by 25%");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.endurance += .25f;
    }
}
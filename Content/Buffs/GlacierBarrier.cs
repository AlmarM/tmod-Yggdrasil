using Terraria;
using Terraria.ID;
using Yggdrasil.Configs;
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

        if (Main.rand.NextBool(5))
        {
            int dust = Dust.NewDust(player.position, player.width, player.height, DustID.Frost);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
            Main.dust[dust].scale *= 1.1f;
        }
    }
}
using Terraria;
using Terraria.ID;
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

        if (Main.rand.NextBool(5))
        {
            int dust = Dust.NewDust(player.position, player.width, player.height, DustID.Silver);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
            Main.dust[dust].scale *= 1.1f;
        }
    }
}
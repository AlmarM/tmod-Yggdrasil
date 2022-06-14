using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class BerserkerRageBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Berserker Rage Buff");
        Description.SetDefault(
            "Increases defense by 5"+
            "\n20% increase runic damage and critical strike chance");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetDamage<RunicDamageClass>() += 0.2f;
        player.GetCritChance<RunicDamageClass>() += 20;
        player.statDefense += 5;


        // DUST
        if (Main.rand.NextBool(5))
        {
            var position = new Vector2(player.position.X, player.position.Y + 5f);
            var velocityX = player.velocity.X * 0.5f;
            var velocityY = player.velocity.Y * 0.5f;

            //Dust sparkling over the character
            int d = Dust.NewDust(position, player.width, player.height, DustID.Lava, velocityX, velocityY,
                100, default, 1f);

            Main.dust[d].noGravity = true;
            Main.dust[d].velocity.X *= 0.5f;
            Main.dust[d].velocity.Y = -2f;
            Main.dust[d].noLight = true;
        }
    }
}
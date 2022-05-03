using Terraria;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;
using Yggdrasil.Configs;
using Terraria.ID;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Content.Buffs;

public class SlowDebuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        string runicText = TextUtils.GetColoredText(RuneConfig.RuneTooltipColor, "runic");

        DisplayName.SetDefault("Slow");
        Main.buffNoTimeDisplay[Type] = false;
        Main.pvpBuff[Type] = false;
    }

	public override void Update(NPC npc, ref int buffIndex)
	{
		if (npc.knockBackResist > 0f)
		{
			Player player = Main.LocalPlayer;
			var SlowDebuffValue = player.GetModPlayer<RunePlayer>().SlowDebuffValue;
			npc.velocity.X *= SlowDebuffValue;

			if (Main.rand.NextBool(5))
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Dirt);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0f;
				Main.dust[dust].scale *= 1.1f;
			}
		}
	}
}
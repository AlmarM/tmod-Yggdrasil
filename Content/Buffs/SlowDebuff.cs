using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class SlowDebuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Slow");
        
        Main.buffNoTimeDisplay[Type] = false;
        Main.pvpBuff[Type] = false;
    }

	public override void Update(NPC npc, ref int buffIndex)
	{
		if (npc.knockBackResist > 0f)
		{
			Player player = Main.LocalPlayer;
			
			var slowDebuffValue = player.GetModPlayer<RunemasterPlayer>().SlowDebuffValue;
			npc.velocity.X *= slowDebuffValue;

			if (Main.rand.NextBool(8))
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.IceRod);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0f;
				Main.dust[dust].scale *= 1.3f;
			}
		}
	}
}
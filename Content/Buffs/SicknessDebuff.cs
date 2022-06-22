using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class SicknessDebuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sickness");
        
        Main.buffNoTimeDisplay[Type] = false;
        Main.pvpBuff[Type] = false;
    }

	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.lifeRegen -= 10;
		npc.defense -= 15;

		if (Main.rand.NextBool(5))
		{
			int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GreenBlood);
			Main.dust[dust].noGravity = false;
			Main.dust[dust].velocity *= 0f;
			Main.dust[dust].scale *= 1.1f;
		}
		
	}
}
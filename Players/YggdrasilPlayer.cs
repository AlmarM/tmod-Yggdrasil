using Terraria;
using Terraria.ModLoader;

namespace Yggdrasil.Players;

public class YggdrasilPlayer : ModPlayer
{
	public int dodgeChance = 0;
		
	public override void ResetEffects()
    {
		dodgeChance = 0;
	}
	
}
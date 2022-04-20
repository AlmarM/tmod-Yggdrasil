using Terraria;
using Terraria.ModLoader;

namespace Yggdrasil.Players;

public class YggdrasilPlayer : ModPlayer
{
    public int dodgeChance = 0;
	
	public override void ResetEffects()
	{
		dodgeChance = 0;
		RunePower = 0;
	}
	
	public int RunePower { get; set; }
	
	public override void OnHitAnything(float x, float y, Entity victim)
	{
		Main.NewText(RunePower);
	}
}
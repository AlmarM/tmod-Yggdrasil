using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;
using Yggdrasil.Configs;
using Yggdrasil.Content.Projectiles.Summon;
using Yggdrasil.Content.Players;
using Yggdrasil.Content.Buffs;

namespace Yggdrasil.Content.Buffs
{
	public class VikingSummonBuff : YggdrasilBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Viking Minion");
			Description.SetDefault("The example minion will fight for you");

			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
		}

		public override void Update(Player player, ref int buffIndex)
		{
			// If the minions exist reset the buff time, otherwise remove the buff from the player
			if (player.ownedProjectileCounts[ModContent.ProjectileType<VikingSummon>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}

}
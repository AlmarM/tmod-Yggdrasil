using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Yggdrasil.Items;

namespace Yggdrasil.Buffs
{
	public class RunicBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Runic Buff");
			Description.SetDefault("20% increased runic damage");
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetDamage<RunicDamageClass>() += 0.2f;
		}
	}
}
using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Utils
{
	
	class RunePowerDisplay : InfoDisplay
	{
		
		public override void SetStaticDefaults() {
			InfoName.SetDefault("Runic Power");
		}
		
		public override bool Active() {
			return Main.LocalPlayer.GetModPlayer<YggdrasilPlayer>().showRunePower;
		}
		
		public override string DisplayValue() {
			int runePower = Main.LocalPlayer.GetModPlayer<YggdrasilPlayer>().RunePower;
			return runePower > 0 ? $"{runePower} Runic Power." : "No Runic Power";
		}
		
	}

}
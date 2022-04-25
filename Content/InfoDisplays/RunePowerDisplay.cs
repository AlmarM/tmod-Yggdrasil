using Terraria;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Content.InfoDisplays;

public class RunePowerDisplay : YggdrasilInfoDisplay
{
    public override void SetStaticDefaults()
    {
        InfoName.SetDefault("Runic Power");
    }

    public override bool Active()
    {
        return Main.LocalPlayer.GetModPlayer<RunePlayer>().ShowRunePower;
    }

    public override string DisplayValue()
    {
        int runePower = Main.LocalPlayer.GetModPlayer<RunePlayer>().RunePower;
        return runePower > 0 ? $"{runePower} Runic Power." : "No Runic Power";
    }
}
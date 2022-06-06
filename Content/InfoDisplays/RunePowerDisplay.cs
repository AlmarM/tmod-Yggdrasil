using Terraria;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;

namespace Yggdrasil.Content.InfoDisplays;

public class RunePowerDisplay : YggdrasilInfoDisplay
{
    public override void SetStaticDefaults()
    {
        InfoName.SetDefault("Runic Power");
    }

    public override bool Active()
    {
        return Main.LocalPlayer.HasEffect<RunicSlab>();
    }

    public override string DisplayValue()
    {
        int runePower = Main.LocalPlayer.GetModPlayer<RunePlayer>().RunePower;

        int FartThreshold = Main.LocalPlayer.GetModPlayer<RunePlayer>().FartThreshold;
        int FartValue = Main.LocalPlayer.GetModPlayer<RunePlayer>().FartValue;
        int PukeThreshold = Main.LocalPlayer.GetModPlayer<RunePlayer>().PukeThreshold;
        int PukeValue = Main.LocalPlayer.GetModPlayer<RunePlayer>().PukeValue;

        string display = runePower > 0 ? $"{runePower} Runic Power." : "No Runic Power";
        display += $"\n{FartValue} / {FartThreshold} farts";
        display += $"\n{PukeValue} / {PukeThreshold} biles ";


        return display;
    }
}
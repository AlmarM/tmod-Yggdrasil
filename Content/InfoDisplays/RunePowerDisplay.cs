using Terraria;
using Yggdrasil.Content.Items.Accessories;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;

namespace Yggdrasil.Content.InfoDisplays;

public class RunePowerDisplay : YggdrasilInfoDisplay
{
    public override void SetStaticDefaults()
    {
        InfoName.SetDefault("Runemaster");
    }

    public override bool Active()
    {
        return Main.LocalPlayer.HasEffect<RunicSlab>();
    }
    // NOT USED ANYMORE FOR NOW
    public override string DisplayValue()
    {
        //int runePower = Main.LocalPlayer.GetModPlayer<RunePlayer>().RunePower;

        int FocusThreshold = Main.LocalPlayer.GetModPlayer<RunePlayer>().FocusThreshold;
        int FocusValue = Main.LocalPlayer.GetModPlayer<RunePlayer>().FocusValue;
        int InsanityThreshold = Main.LocalPlayer.GetModPlayer<RunePlayer>().InsanityThreshold;
        int InsanityValue = Main.LocalPlayer.GetModPlayer<RunePlayer>().InsanityValue;

        string display = $"{FocusValue} / {FocusThreshold} focus";
        display += $"\n{InsanityValue} / {InsanityThreshold} insanity ";


        return display;
    }
}
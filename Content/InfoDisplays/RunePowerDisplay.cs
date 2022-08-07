using Terraria;
using Yggdrasil.Content.Players;
using Yggdrasil.Extensions;
using Yggdrasil.Runemaster.Content.Items.Accessories;

namespace Yggdrasil.Content.InfoDisplays;

public class RunePowerDisplay : YggdrasilInfoDisplay
{
    public override void SetStaticDefaults()
    {
        InfoName.SetDefault("Runemaster");
    }

    public override bool Active()
    {
        return true;
        return Main.LocalPlayer.HasEffect<RunicSlab>();
    }

    // NOT USED ANYMORE FOR NOW
    public override string DisplayValue()
    {
        //int runePower = Main.LocalPlayer.GetModPlayer<RunePlayer>().RunePower;

        // int FocusThreshold = Main.LocalPlayer.GetModPlayer<RunemasterPlayer>().FocusThreshold;
        // int FocusValue = Main.LocalPlayer.GetModPlayer<RunemasterPlayer>().Focus;
        // int InsanityThreshold = Main.LocalPlayer.GetModPlayer<RunemasterPlayer>().InsanityThreshold;
        // int InsanityValue = Main.LocalPlayer.GetModPlayer<RunemasterPlayer>().Insanity;
        //
        // string display = $"{FocusValue} / {FocusThreshold} focus";
        // display += $"\n{InsanityValue} / {InsanityThreshold} insanity ";

        string display = $"{Player.tileTargetX}, {Player.tileTargetY}";

        return display;
    }
}
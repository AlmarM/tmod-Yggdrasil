using Microsoft.Xna.Framework;
using Terraria;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Runic;

public class FaintLightEffect : RunicEffect
{
    public Color LightColor { get; }

    public FaintLightEffect(int runePower, Color lightColor) : base(runePower)
    {
        LightColor = lightColor;
    }

    protected override string GetDescription()
    {
        return "Generate a faint light";
    }

    public static void Apply(FaintLightEffect[] effects, RunePlayer runePlayer)
    {
        foreach (FaintLightEffect effect in effects)
        {
            if (runePlayer.RunePower >= effect.RunePowerRequired)
            {
                var centerX = (int)runePlayer.Player.Center.X / 16;
                var centerY = (int)runePlayer.Player.Center.Y / 16;

                Lighting.AddLight(centerX, centerY, effect.LightColor.R, effect.LightColor.G, effect.LightColor.B);
            }
        }
    }
}
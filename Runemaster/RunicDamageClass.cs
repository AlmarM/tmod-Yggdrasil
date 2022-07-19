using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Runemaster;

public class RunicDamageClass : DamageClass
{
    public override void SetStaticDefaults()
    {
        ClassName.SetDefault($"{RuneConfig.ColoredRunicDamageLabel} damage");
    }
}
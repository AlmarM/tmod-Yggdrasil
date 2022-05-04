using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.DamageClasses;

public class RunicDamageClass : DamageClass
{
    public override void SetStaticDefaults()
    {
        ClassName.SetDefault($"{RuneConfig.RunicDamageTooltip} damage");
    }
}
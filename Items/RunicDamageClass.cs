using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Items;

public class RunicDamageClass : DamageClass
{
    public override void SetStaticDefaults()
    {
        ClassName.SetDefault(GlobalConfig.RunicDamageLabel);
    }

    protected override float GetBenefitFrom(DamageClass damageClass)
    {
        return damageClass == Generic ? 1f : 0f;
    }
}
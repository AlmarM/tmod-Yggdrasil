using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.DamageClasses;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class SuperHPRegen : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Super Regen");
        Description.SetDefault($"Greatly improves life regeneration");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen += 20;
    }
}
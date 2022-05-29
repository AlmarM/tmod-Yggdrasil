using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Configs;

namespace Yggdrasil.Content.Buffs;

public class RunesmithBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cotin Focus");
        Description.SetDefault(
            $"Increases defense by 3" +
            $"\nSlowly regenerates life");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 3;
        player.lifeRegen += 2;
    }

}
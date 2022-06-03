using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Configs;

namespace Yggdrasil.Content.Buffs;

public class FleshBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Flesh Focus");
        Description.SetDefault(
            "Increases defense by 8" +
            "\nGrants +20 max life" +
            "\nRegenerates life");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 8;
        player.lifeRegen += 10;
        player.statLifeMax2 += 20;
    }

}
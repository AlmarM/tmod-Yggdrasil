using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Configs;

namespace Yggdrasil.Content.Buffs;

public class ObsidianBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Obsidian Focus");
        Description.SetDefault(
            "Increases defense by 7" +
            "\n5% increased runic critical strike chance" +
            "\nGrants immunity to fire blocks and lava");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 7;
        player.lavaImmune = true;
        player.fireWalk = true;
        player.GetCritChance<RunicDamageClass>() += 5;
    }

}
using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class ShinyBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shiny Focus");
        Description.SetDefault(
            "Increases defense by 4" +
            "\nShows ore around you" +
            "\nGrants immunity to OnFire and Poisoned");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 4;
        player.buffImmune[BuffID.OnFire] = true;
        player.buffImmune[BuffID.Poisoned] = true;
    }
}
using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class FrostcoreBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Focus");
        Description.SetDefault(
            "Increases defense by 5" +
            "\nSlowly regenerates life" +
            "\nGrants immunity to Chilled, Frozen and Frostburn");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 5;
        player.lifeRegen += 5;
        player.buffImmune[BuffID.Chilled] = true;
        player.buffImmune[BuffID.Frozen] = true;
        player.buffImmune[BuffID.Frostburn] = true;
    }
}
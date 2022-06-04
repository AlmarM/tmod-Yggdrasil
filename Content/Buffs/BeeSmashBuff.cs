using Terraria;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class BeeSmashBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bee Focus");
        Description.SetDefault(
            "Increases defense by 7" +
            "\nGrants 5% damage reduction" +
            "\nRunic hit heals 2");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 7;
        player.endurance += 0.05f;
        player.SetEffect<BeeSmashBuff>();
    }
}
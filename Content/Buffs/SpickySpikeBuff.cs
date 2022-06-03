using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;
using Yggdrasil.DamageClasses;
using Yggdrasil.Extensions;
using Yggdrasil.Configs;

namespace Yggdrasil.Content.Buffs;

public class SpickySpikeBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spiky Focus");
        Description.SetDefault(
            "Grants +100% thorns");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.thorns += 1f;
    }

}
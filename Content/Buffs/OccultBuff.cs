using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class OccultBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Occult Buff");
        Description.SetDefault(
            "Increases defense by 2"+
            "\nGrants immunity to Poison and Fire"+
            "\nProvide life regeneration near water candles"+
            "\nIncreases enemy spawn rate");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 2;
        player.buffImmune[BuffID.Poisoned] = true;
        player.buffImmune[BuffID.OnFire] = true;

        if (player.ZoneWaterCandle)
            player.lifeRegen += 5;
    }
}
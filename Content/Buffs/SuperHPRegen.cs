using Terraria;

namespace Yggdrasil.Content.Buffs;

public class SuperHPRegen : YggdrasilBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Super Regen");
        Description.SetDefault("Greatly improves life regeneration");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.lifeRegen += 20;
    }
}
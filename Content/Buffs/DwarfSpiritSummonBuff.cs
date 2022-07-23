using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles.Summon;

namespace Yggdrasil.Content.Buffs
{
    public class DwarfSpiritSummonBuff : YggdrasilBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dwarf Spirit Minion");
            Description.SetDefault("The dwarf spirit will fight for you");

            // This buff won't save when you exit the world
            Main.buffNoSave[Type] = true;
            
            // The time remaining won't display on this buff
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // If the minions exist reset the buff time, otherwise remove the buff from the player
            if (player.ownedProjectileCounts[ModContent.ProjectileType<DwarfSpiritSummonProjectile>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
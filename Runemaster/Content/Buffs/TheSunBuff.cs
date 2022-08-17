using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.ModEffects;

namespace Yggdrasil.Runemaster.Content.Buffs;

public class TheSunBuff : YggdrasilBuff
{
    [CloneByReference] private readonly RunicAttackSpeedModEffect _runicAttackSpeedEffect = new(0.1f);

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("The Sun Buff");
        Description.SetDefault(
            "Increases defense by 5" +
            "\nReduces damage taken by 3%" +
            "\nSlowly regenerates life" +
            "\n3% increased runic critical strike chance" +
            "\n10% increased runic damage" +
            $"\n{_runicAttackSpeedEffect.EffectDescription}" +
            "\nGrants immunity to Chilled, Frozen, Fire and Frostburn");
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense += 5;
        player.endurance += 0.03f;
        player.lifeRegen += 5;
        player.GetCritChance<RunicDamageClass>() += 3;
        player.GetDamage<RunicDamageClass>() += 0.1f;
        player.buffImmune[BuffID.Chilled] = true;
        player.buffImmune[BuffID.Frozen] = true;
        player.buffImmune[BuffID.OnFire] = true;
        player.buffImmune[BuffID.Frostburn] = true;

        if (Main.rand.NextBool(8))
        {
            int dust = Dust.NewDust(player.position, player.width, player.height, DustID.Torch);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
            Main.dust[dust].scale *= 1.5f;
        }
    }
}
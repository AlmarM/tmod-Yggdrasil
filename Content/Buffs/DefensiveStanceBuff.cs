using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class DefensiveStanceBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Defensive Stance");
        Description.SetDefault("");
        Main.buffNoSave[Type] = true;
        BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.moveSpeed = 0;
        player.statDefense += 20;
    }
}
using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class BlockBuff : YggdrasilBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Block");
        Description.SetDefault("");

        Main.buffNoSave[Type] = true;
        BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
    }
}
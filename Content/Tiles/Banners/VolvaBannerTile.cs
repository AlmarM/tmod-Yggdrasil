using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Vikings;

namespace Yggdrasil.Content.Tiles.Banners;

public class VolvaBannerTile : YggdrasilBannerTile
{
    protected override int BannerType => ModContent.ItemType<VolvaBanner>();

    protected override int[] NpcTypes => new[] { ModContent.NPCType<Volva>() };

    protected override string MapEntryName => "Volva Banner";

    protected override Color MapEntryColor => new(75, 53, 34);
}
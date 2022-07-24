using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Svartalvheim;

namespace Yggdrasil.Content.Tiles.Banners;

public class SvartalslimeBannerTile : YggdrasilBannerTile
{
    protected override int BannerType => ModContent.ItemType<SvartalslimeBanner>();

    protected override int[] NpcTypes => new[] { ModContent.NPCType<Svartalslime>() };

    protected override string MapEntryName => "Svartalslime Banner";

    protected override Color MapEntryColor => new(125, 64, 64);
}
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Svartalvheim;

namespace Yggdrasil.Content.Tiles.Banners;

public class SvartalvheimBatBannerTile : YggdrasilBannerTile
{
    protected override int BannerType => ModContent.ItemType<SvartalvheimBatBanner>();

    protected override int[] NpcTypes => new[] { ModContent.NPCType<SvartalvheimBat>() };

    protected override string MapEntryName => "Svartalvheim Bat";

    protected override Color MapEntryColor => new(102, 102, 133);
}
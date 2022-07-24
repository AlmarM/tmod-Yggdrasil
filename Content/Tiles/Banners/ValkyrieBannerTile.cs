using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Vikings;

namespace Yggdrasil.Content.Tiles.Banners;

public class ValkyrieBannerTile : YggdrasilBannerTile
{
    protected override int BannerType => ModContent.ItemType<ValkyrieBanner>();

    protected override int[] NpcTypes => new[] { ModContent.NPCType<Valkyrie>() };

    protected override string MapEntryName => "Valkyrie Banner";

    protected override Color MapEntryColor => new(250, 232, 136);
}
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Vikings;

namespace Yggdrasil.Content.Tiles.Banners;

public class OdinsRavenBannerTile : YggdrasilBannerTile
{
    protected override int BannerType => ModContent.ItemType<OdinsRavenBanner>();

    protected override int[] NpcTypes => new[] { ModContent.NPCType<OdinRaven>() };

    protected override string MapEntryName => "Odin's Raven Banner";

    protected override Color MapEntryColor => new(35, 56, 59);

}
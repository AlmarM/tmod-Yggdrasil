using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Banners;
using Yggdrasil.Content.NPCs.Svartalvheim;

namespace Yggdrasil.Content.Tiles.Banners;

public class DwarfBannerTile : YggdrasilBannerTile
{
    protected override int BannerType => ModContent.ItemType<DwarfBanner>();

    protected override int[] NpcTypes => new[]
    {
        ModContent.NPCType<DwarfPeon>(),
        ModContent.NPCType<DwarfThunderer>(),
        ModContent.NPCType<DwarfWarrior>()
    };

    protected override string MapEntryName => "Dwarf Banner";

    protected override Color MapEntryColor => new(139, 109, 76);
}
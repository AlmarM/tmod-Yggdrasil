using Terraria;
using Yggdrasil.Content.Items.Weapons.FrostCore;
using Yggdrasil.ModActions.Player;

namespace Yggdrasil;

public class TestEffectOne : ICanAutoReuseItemModAction
{
    public int Priority => 0;

    public bool? CanAutoReuseItem(Item item)
    {
        return item.ModItem is FrostCoreSpear;
    }
}
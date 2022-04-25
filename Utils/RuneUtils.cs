using System;
using Terraria;
using Yggdrasil.Runes;

namespace Yggdrasil.Utils;

public static class RuneUtils
{
    public static int CountRunesInInventory(Player player)
    {
        var count = 0;

        for (var i = 0; i < 58; i++)
        {
            if (player.inventory[i].ModItem is IRune)
            {
                count++;
            }
        }

        return count;
    }

    public static int CountRunesInInventory(Player player, params Type[] runeTypes)
    {
        var count = 0;

        for (var i = 0; i < 58; i++)
        {
            foreach (Type runeType in runeTypes)
            {
                var modItem = player.inventory[i].ModItem;
                if (modItem != null && modItem.GetType() == runeType)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
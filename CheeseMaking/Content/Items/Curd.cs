using Yggdrasil.Content.Items;

namespace Yggdrasil.CheeseMaking.Content.Items;

public class Curd : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Curd");
    }

    public override void SetDefaults()
    {
        Item.width = 12;
        Item.height = 14;
        Item.stack = 999;
    }
}
﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Content.Items.Weapons
{
    public class VikingBow : YggdrasilItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Viking Bow");
            //Tooltip.SetDefault("");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Ranged;
            Item.useAnimation = 24;
            Item.useTime = 24;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.crit = 0;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = 1;
            Item.shootSpeed = 8f;
            Item.value = Item.sellPrice(0, 0, 80);
            Item.useAmmo = AmmoID.Arrow;
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.IronWood;
using Terraria;
using Terraria.GameContent;
using Yggdrasil.Content.Tiles.IronWood;

namespace Yggdrasil.Content.Tiles.IronWood;

public class IronWoodTree : ModTree
{
    public override void SetStaticDefaults()
    {
        GrowsOnTileId = new int[1] { ModContent.TileType<IronWoodGrassTile>() };
    }

    public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
    {
        UseSpecialGroups = true,
        SpecialGroupMinimalHueValue = 11f / 72f,
        SpecialGroupMaximumHueValue = 0.25f,
        SpecialGroupMinimumSaturationValue = 0.88f,
        SpecialGroupMaximumSaturationValue = 1f
    };

    public override int CreateDust()
    {
        return 1;
    }

    public override int DropWood()
    {
    	return ModContent.ItemType<IronWoodItem>();
    }

    public override Asset<Texture2D> GetBranchTextures()
    {
        return ModContent.Request<Texture2D>("Yggdrasil/Assets/Content/Tiles/IronWood/IronWoodTreeBranches");
    }

    public override Asset<Texture2D> GetTexture()
    {
        return ModContent.Request<Texture2D>("Yggdrasil/Assets/Content/Tiles/IronWood/IronWoodTree");
    }

    public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
    {
       topTextureFrameWidth = 114;
       topTextureFrameHeight = 96;
       xoffset = 48;
    }

    public override Asset<Texture2D> GetTopTextures()
    {
        return ModContent.Request<Texture2D>("Yggdrasil/Assets/Content/Tiles/IronWood/IronWoodTreeTop");
    }


}
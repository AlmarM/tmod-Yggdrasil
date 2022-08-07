using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.CheeseMaking.Content.Players;

public class CheesePlayer : ModPlayer
{
    // public override void PreUpdate()
    // {
    //     var vector2 = new Vector2(Player.tileRangeX, Player.tileRangeY) * 16f * 2f;
    //     Rectangle value = Terraria.Utils.CenteredRectangle(Player.Center, vector2);
    //     Vector2 mousevec = Main.ReverseGravitySupport(Main.MouseScreen) + Main.screenPosition;
    //     int num = -1;
    //
    //     for (int i = 0; i < 200; i++)
    //     {
    //         NPC nPC = Main.npc[i];
    //         if (nPC.active && nPC.Hitbox.Intersects(value))
    //         {
    //             float num2 = nPC.Hitbox.Distance(mousevec);
    //             if (num == -1 || Main.npc[num].Hitbox.Distance(mousevec) > num2)
    //             {
    //                 num = i;
    //             }
    //         }
    //     }
    //
    //     if (num == -1)
    //     {
    //         return;
    //     }
    //
    //     Rectangle rectangle2 = new Rectangle(
    //         (int)(Player.position.X + (float)(Player.width / 2f) - (float)(Player.tileRangeX * 16)),
    //         (int)(Player.position.Y + (float)(Player.height / 2f) - (float)(Player.tileRangeY * 16)),
    //         Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
    //
    //     Rectangle value4 = new Rectangle((int)Main.npc[num].position.X, (int)Main.npc[num].position.Y,
    //         Main.npc[num].width, Main.npc[num].height);
    //
    //     if (rectangle2.Intersects(value4) && Player.itemAnimation == 1 && Main.mouseLeft)
    //     {
    //         Main.NewText("Test");
    //     }
    // }
    //
    // public override void PostUpdate()
    // {
    //     if (Main.mapFullscreen || Main.InGameUI.CurrentState == Main.BestiaryUI)
    //     {
    //         return;
    //     }
    //
    //     int tileX = Player.tileTargetX;
    //     int tileY = Player.tileTargetY;
    //
    //     if (!Player.IsInTileInteractionRange(tileX, tileY))
    //     {
    //         return;
    //     }
    //
    //     Tile tile = Main.tile[tileX, tileY];
    //
    //     if (!tile.HasTile)
    //     {
    //         return;
    //     }
    //
    //     Player.cursorItemIconEnabled = true;
    //     Player.cursorItemIconID = ModContent.ItemType<MilkBucket>();
    //
    //     if (WiresUI.Open || Player.ownedProjectileCounts[651] > 0)
    //     {
    //         return;
    //     }
    //
    //     if (Player.whoAmI != Main.myPlayer)
    //     {
    //         return;
    //     }
    //
    //     if (Player.itemAnimation == 1 && Main.mouseLeft)
    //     {
    //         Item.NewItem(null, Main.MouseWorld, ModContent.ItemType<MilkBucket>());
    //     }
    // }
}
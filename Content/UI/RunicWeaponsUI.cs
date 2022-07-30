using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using Yggdrasil.Content.Players;
using Yggdrasil.Runemaster.Content.Items;

namespace Yggdrasil.Content.UI
{
    internal class RunicWeaponsUI : UIState
    {
        private UIElement area;
        private UIImage runemasterMeter;
        //private UIImage focusMeter;
        //private UIImage insanityMeter;
        private Color focuscolor;
        private Color insanitycolor;
        public override void OnInitialize()
        {
            //Player player = Main.LocalPlayer;

            int width = 60;
            int height = 34;

            area = new UIElement();
            area.Left.Set(-width * 0.5f, 0.5f);
            area.Top.Set(height, 0.5f);
            area.Width.Set(width, 0f);
            area.Height.Set(height, 0f);

            runemasterMeter = new UIImage(ModContent.Request<Texture2D>("Yggdrasil/Assets/Content/UI/RuneMasterMeter"));
            //runemasterMeter.Left.Set(-width * 0.5f, 0.5f);
            //runemasterMeter.Top.Set(height, 0.5f);
            //runemasterMeter.Width.Set(width, 0f);
            //runemasterMeter.Height.Set(height, 0f);

            //focusMeter = new UIImage(ModContent.Request<Texture2D>("Yggdrasil/Assets/Content/UI/FocusBar"));
            //focusMeter.Left.Set(-24, 0.5f);
            //focusMeter.Top.Set(-11, 0.5f);
            //focusMeter.Width.Set(48, 0f);
            //focusMeter.Height.Set(8, 0f);

            //insanityMeter = new UIImage(ModContent.Request<Texture2D>("Yggdrasil/Assets/Content/UI/InsanityBar"));
            //insanityMeter.Left.Set(-24, 0.5f);
            //insanityMeter.Top.Set(3, 0.5f);
            //insanityMeter.Width.Set(48, 0f);
            //insanityMeter.Height.Set(8, 0f);

            focuscolor = new Color(177, 129, 51); // Brown/Orange
            insanitycolor = new Color(177, 51, 82); // Redish

            area.Append(runemasterMeter);
            //area.Append(focusMeter);
            //area.Append(insanityMeter);
            Append(area);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // This prevents drawing unless we are using a RunicItem
            if (!(Main.LocalPlayer.HeldItem.ModItem is RuneTablet))
                return;

            base.Draw(spriteBatch);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {           
            base.DrawSelf(spriteBatch);

            var runePlayer = Main.LocalPlayer.GetModPlayer<RunemasterPlayer>();

            float focusQuotient = (float)runePlayer.Focus / runePlayer.FocusThreshold;
            float insanityQuotient = (float)runePlayer.Insanity / runePlayer.InsanityThreshold;
            focusQuotient = MathHelper.Clamp(focusQuotient, 0f, 1f);
            insanityQuotient = MathHelper.Clamp(insanityQuotient, 0f, 1f);



            Rectangle focusHitbox = runemasterMeter.GetInnerDimensions().ToRectangle();
            focusHitbox.X += 6;
            focusHitbox.Width += 48;
            focusHitbox.Y += 6;
            focusHitbox.Height = 10;

            int focusLeft = focusHitbox.Left;
            int focusRight = focusHitbox.Right;
            int focusSteps = (int)((focusRight - focusLeft) * focusQuotient);
                      
            for (int i = 0; i < focusSteps; i += 1)
            {
                spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(focusLeft + i, focusHitbox.Y, 1, focusHitbox.Height), focuscolor);
            }

            Rectangle insanityHitbox = runemasterMeter.GetInnerDimensions().ToRectangle();
            insanityHitbox.X += 6;
            insanityHitbox.Width += 48;
            insanityHitbox.Y += 20;
            insanityHitbox.Height = 10;

            int insanityLeft = insanityHitbox.Left;
            int insanityRight = insanityHitbox.Right;
            int insanitySteps = (int)((insanityRight - insanityLeft) * insanityQuotient);

            for (int i = 0; i < insanitySteps; i += 1)
            {
                spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(insanityLeft + i, insanityHitbox.Y, 1, insanityHitbox.Height), insanitycolor);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!(Main.LocalPlayer.HeldItem.ModItem is RuneTablet))
                return;

            base.Update(gameTime);
        }
    }
}
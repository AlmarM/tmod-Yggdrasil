using Microsoft.Xna.Framework.Graphics;

namespace Yggdrasil.ModActions.Player;

public interface IGetMapBackgroundImageModAction : IPlayerModAction
{
    int Priority { get; }

    Texture2D GetMapBackgroundImage();
}
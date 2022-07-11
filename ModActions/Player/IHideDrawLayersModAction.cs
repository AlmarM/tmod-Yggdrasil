using Terraria.DataStructures;

namespace Yggdrasil.ModActions.Player;

public interface IHideDrawLayersModAction : IPlayerModAction
{
    int Priority { get; }

    void HideDrawLayers(PlayerDrawSet drawInfo);
}
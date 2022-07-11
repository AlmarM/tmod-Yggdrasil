using System.Collections.Generic;
using Terraria.ModLoader;

namespace Yggdrasil.ModActions.Player;

public interface IModifyDrawLayerOrderingModAction : IPlayerModAction
{
    int Priority { get; }

    void ModifyDrawLayerOrdering(IDictionary<PlayerDrawLayer, PlayerDrawLayer.Position> positions);
}
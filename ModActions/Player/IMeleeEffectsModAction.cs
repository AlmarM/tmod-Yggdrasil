using Microsoft.Xna.Framework;
using Terraria;

namespace Yggdrasil.ModActions.Player;

public interface IMeleeEffectsModAction : IPlayerModAction
{
    int Priority { get; }

    void MeleeEffects(Item item, Rectangle hitbox);
}
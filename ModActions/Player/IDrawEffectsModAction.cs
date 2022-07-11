using Terraria.DataStructures;

namespace Yggdrasil.ModActions.Player;

public interface IDrawEffectsModAction : IPlayerModAction
{
    int Priority { get; }

    void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright);
}
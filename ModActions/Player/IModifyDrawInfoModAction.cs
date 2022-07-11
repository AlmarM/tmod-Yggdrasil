using Terraria.DataStructures;

namespace Yggdrasil.ModActions.Player;

public interface IModifyDrawInfoModAction : IPlayerModAction
{
    int Priority { get; }

    void ModifyDrawInfo(ref PlayerDrawSet drawInfo);
}
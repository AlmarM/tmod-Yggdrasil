using Terraria.ModLoader.IO;

namespace Yggdrasil.ModActions.Player;

public interface ILoadDataModAction : IPlayerModAction
{
    int Priority { get; }

    void LoadData(TagCompound tag);
}
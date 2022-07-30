using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.World;

public class VikingInvasionWorld : ModSystem
{
    public static int vikingKilled;
    public static bool vikingInvasion;
    public static bool valkyrieUp;
    public static int vikingToKill = 200;
    public static int vikingToKillHardmode = 300;

    public override void OnWorldLoad()
    {
        vikingInvasion = false;
        vikingKilled = 0;
        valkyrieUp = false;
    }
    public override void PostUpdateWorld()
    {
        //Set that the invasion was successfuly repelled at 200kill if it's not done already
        if (vikingInvasion && vikingKilled >= vikingToKill && !YggdrasilWorld.downedVikingInvasion)
        {
            YggdrasilWorld.downedVikingInvasion = true;
            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendData(MessageID.WorldData);
        }

        //Viking leaves if daytime comes
        if (!Main.dayTime && vikingInvasion)
        {
            Main.NewText("The vikings have left!", 174, 128, 79);
            vikingInvasion = false;
            vikingKilled = 0;
        }

        //Hardmode invasion is repelled if 300 vikings are killed
        if (Main.hardMode && vikingInvasion && vikingKilled >= vikingToKillHardmode)
        {
            Main.NewText("The vikings have been defeated!", 174, 128, 79);
            vikingInvasion = false;
            vikingKilled = 0;
        }

        //Invasion is repelled if 200 vikings are killed
        if (!Main.hardMode && vikingInvasion && vikingKilled >= vikingToKill)
        {
            Main.NewText("The vikings have been defeated!", 174, 128, 79);
            vikingInvasion = false;
            vikingKilled = 0;
        }

        //if (valkyrieUp)
        //Main.NewText("Trigger");
        //Main.NewText(vikingKilled);

    }

}

public class VikingInvasionWorldEffect : ModSceneEffect
{
    public override int Music => MusicID.OtherworldlyInvasion;

    public override bool IsSceneEffectActive(Player player)
    {
        return VikingInvasionWorld.vikingInvasion;
    }

    public override SceneEffectPriority Priority => SceneEffectPriority.Event;

}
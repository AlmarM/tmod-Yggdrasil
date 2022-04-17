namespace Yggdrasil.Utils;

internal static class TimeUtils
{
    private const int TicksPerSecond = 60;
    private const int TicksPerMinute = TicksPerSecond * 60;
    private const int TicksPerHour = TicksPerMinute * 60;

    public static int SecondsToTicks(float seconds)
    {
        return (int)(TicksPerSecond * seconds);
    }

    public static int MinutesToTicks(float minutes)
    {
        return (int)(TicksPerMinute * minutes);
    }

    public static int HoursToTicks(float hours)
    {
        return (int)(TicksPerHour * hours);
    }

    public static int GetTicks(float seconds, float minutes = 0, float hours = 0)
    {
        return SecondsToTicks(seconds) + MinutesToTicks(minutes) + HoursToTicks(hours);
    }
}
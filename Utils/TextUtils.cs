namespace Yggdrasil.Utils;

public static class TextUtils
{
    public static string GetColoredText(float r, float g, float b, string text)
    {
        var rInt = (int)(r * 255);
        var gInt = (int)(g * 255);
        var bInt = (int)(b * 255);

        return GetColoredText(rInt, gInt, bInt, text);
    }

    public static string GetColoredText(int r, int g, int b, string text)
    {
        string hex = ColorUtils.RgbToHex(r, g, b);
        return GetColoredText(hex, text);
    }

    public static string GetColoredText(string hex, string text)
    {
        return $"[c/{hex}:{text}]";
    }
}
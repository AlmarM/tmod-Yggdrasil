using System;

namespace Yggdrasil.Utils;

public static class ColorUtils
{
    public static string RgbToHex(int r, int g, int b)
    {
        r = Math.Clamp(r, 0, 255);
        g = Math.Clamp(g, 0, 255);
        b = Math.Clamp(b, 0, 255);

        return $"{r:X2}{g:X2}{b:X2}";
    }
}
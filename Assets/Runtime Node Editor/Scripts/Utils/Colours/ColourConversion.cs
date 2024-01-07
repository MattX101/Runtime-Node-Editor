using UnityEngine;

namespace RuntimeNodeEditor.Utils.Colour
{
    public static class ColourConversion
    {
        public static Vector3 RGBToHSL(Color colour)
        {
            float r = colour.r;
            float g = colour.g;
            float b = colour.b;

            float min = Mathf.Min(r, g, b);
            float max = Mathf.Max(r, g, b);
            float diff = max - min;

            float hue = 0.0f;
            if (max == r) hue = (g - b) / diff % 6;
            else if (max == g) hue = (b - r) / diff + 2;
            else if (max == b) hue = (r - g) / diff + 4;
            hue *= 60;
            hue = hue < 0 ? 300 + 60 - Mathf.Abs(hue) : hue;
            hue = Mathf.Clamp(hue, 1, 359);

            float lightness = (max + min) / 2;
            float saturation = diff == 0 ? 0 : diff / (1.0f - Mathf.Abs(2.0f * lightness - 1.0f));

            return new Vector3(hue, saturation, lightness);
        }

        public static Color HSLToRGB(float hue, float saturation, float lightness)
        {
            float C = (1 - Mathf.Abs(2 * lightness - 1)) * saturation;
            float X = C * (1.0f - Mathf.Abs((hue / 60) % 2 - 1));
            float m = lightness - C / 2;

            Color rgb = Color.black;
            if (hue > 0 && hue <= 60) rgb = new Color(C, X, 0);
            else if (hue > 60 && hue <= 120) rgb = new Color(X, C, 0);
            else if (hue > 120 && hue <= 180) rgb = new Color(0, C, X);
            else if (hue > 180 && hue <= 240) rgb = new Color(0, X, C);
            else if (hue > 240 && hue <= 300) rgb = new Color(X, 0, C);
            else if (hue > 300 && hue <= 360) rgb = new Color(C, 0, X);

            rgb.r += m;
            rgb.g += m;
            rgb.b += m;

            return rgb;
        }
        public static Color HSLToRGB(Vector3 hsl)
        {
            return HSLToRGB(hsl.x, hsl.y, hsl.z);
        }
    }
}

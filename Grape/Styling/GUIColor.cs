using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace GrapeGUI.Styling;

internal class GuiColor
{
    //underlying colours
    public Vector4 Color { get; }
    private Vector4 _baseColor;

    /// <summary>
    /// Takes float arguments for RGBA
    /// </summary>
    /// <param name="R"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="a"></param>
    public GuiColor(float R, float G,float B, float A)
    {
        _baseColor = new Vector4(R,G,B,A);
        Color = new Vector4(R * (1.0f / 255f), G * (1.0f / 255f), B * (1.0f / 255f), A * (1.0f / 255f));
    }

    /// <summary>
    /// Constructor takes parameters of an int hex value
    /// and a float of alpha.
    /// </summary>
    /// <param name="hexValue"></param>
    /// <param name="alpha"></param>
    public GuiColor(int hexValue, float alpha)
    {
        float red = (hexValue >> 16) & 0xff;
        float green = (hexValue >> 8) & 0xff;
        float blue = (hexValue >> 0) & 0xff;

        _baseColor = new Vector4(red, green, blue, alpha);
        Color = new Vector4(red * (1.0f / 255f), green * (1.0f / 255f), blue * (1.0f / 255f), alpha * (1.0f / 255f));
    }

}
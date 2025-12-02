using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GrapeRenderer;

public sealed class RenderColor
{
    //creates a channel of colors 
    public float[] ColorChannels { get; } = new float[4];

    /// <summary>
    /// Takes parameter of RGBA to form the color.
    /// Will be passed to the render.
    /// </summary>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    /// <param name="alpha"></param>
    public RenderColor(float red, float green, float blue, float alpha)
    {
        ColorChannels[0] = red;
        ColorChannels[1] = green;
        ColorChannels[2] = blue;
        ColorChannels[3] = alpha;
    }

    /// <summary>
    /// Second overload defaulting the colour value to 1.0f
    /// </summary>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    public RenderColor(float red, float green, float blue) 
    {
        ColorChannels[0] = red;
        ColorChannels[1] = green;
        ColorChannels[2] = blue;
        ColorChannels[3] = 1.0f;
    }
}

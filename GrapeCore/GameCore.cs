using System;
using System.Linq;
using System.Numerics;

namespace GrapeRenderer;


/// <summary>
/// Class is in place for temporary solution in order to not pollute the other file
/// with code that will need removing at a later date
/// </summary>
public partial class Game
{
    public static readonly int STRIDE_COUNT = 10;

    public struct Square
    {
        /// <summary>
        /// Constructor used to 
        /// </summary>
        /// <param name="color"></param>
        public Square(RenderColor color)
        {
            PrimColor = color.ColorChannels;
        }


        //all vertices required to make a square
        private readonly float[] TopRightVert = [0.5f, 0.5f, 0.0f];
        private readonly float[] BottomRightVert = [0.5f, 0.5f, 0.0f];
        private readonly float[] TopLeftVert = [0.5f, 0.5f, 0.0f];
        private readonly float[] BottomLeftVert = [0.5f, 0.5f, 0.0f];


        //TextureCoords
        private readonly float[] TopRightCood = [1.0f, 1.0f];
        private readonly float[] BottomRightCord = [1.0f, 0.0f];
        private readonly float[] TopLeftCord = [0.0f, 1.0f];
        private readonly float[] BottomLeftCord = [0.0f, 0.0f];

        private float[] squareArray = 
            [0.5f,   0.5f, 0.0f,0.0f,0.0f, 1.0f, 1.0f];






        //This array controls how the EBO will use those vertices to create triangles
        private readonly uint[] _indices =
        [
            0, 1, 3,
            1, 2, 3
        ];

        //The colour of the square
        public float[] PrimColor;
    }


    // vertices for a square 
    private readonly float[] sqrVert =
    [
        0.5f,  0.5f, 0.0f,  1.0f, 1.0f, // top right
        0.5f, -0.5f, 0.0f,  0.0f, 1.0f,// bottom right
        -0.5f, -0.5f, 0.0f, 0.0f, 1.0f, // bottom left
        -0.5f,  0.5f, 0.0f // top left
    ];

    //vertices for the triangle 
    private readonly float[] _triangleVert =
    [
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
        0.5f, -0.5f, 0.0f, //Bottom-right vertex
        0.0f,  0.5f, 0.0f  //Top vertex
    ];


    // vertices for a square 
    private readonly float[] _squareVert =
    [
        0.5f,  0.5f, 0.0f, // top right
        0.5f, -0.5f, 0.0f, // bottom right
        -0.5f, -0.5f, 0.0f, // bottom left
        -0.5f,  0.5f, 0.0f // top left
    ];

    // Then, we create a new array: indices.
    // This array controls how the EBO will use those vertices to create triangles
    private readonly uint[] _indices =
    [
        // Note that indices start at 0!
        0, 1, 3, // The first triangle will be the top-right half of the triangle
        1, 2, 3  // Then the second will be the bottom-left half of the triangle
    ];

}
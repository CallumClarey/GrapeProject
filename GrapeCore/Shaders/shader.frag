#version 410 core
out vec4 outputColor;

//takes the vertex colour as a vector 4 in RGBA
//each point has a colour and then is interplated between each one
in vec4 vertexColor;

void main()
{
    outputColor = vertexColor;
}
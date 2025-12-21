using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace GRIS;

/// <summary>
/// Class used to wrap the openTk Inputs
/// </summary>
public enum Keyboard
{ 
    //Basic Keys 
    A = Keys.A,
    B = Keys.B,
    C = Keys.C,
    D = Keys.D,
    E = Keys.E,
    F = Keys.F,
    G = Keys.G,
    H = Keys.H,
    I = Keys.I,
    J = Keys.J,
    K = Keys.K,
    L = Keys.L,
    M = Keys.M,
    N = Keys.N,
    O = Keys.O,
    P = Keys.P,
    Q = Keys.Q,
    R = Keys.R,
    S = Keys.S,
    T = Keys.T,
    U = Keys.U,
    V = Keys.V,
    W = Keys.W,
    X = Keys.X,
    Y = Keys.Y,
    Z = Keys.Z,

    //Function Keys
    F1 = Keys.F1,
    F2 = Keys.F2,
    F3 = Keys.F3,
    F4 = Keys.F4,
    F5 = Keys.F5,
    F6 = Keys.F6,
    F7 = Keys.F7,
    F8 = Keys.F8,
    F9 = Keys.F9,
    F10 = Keys.F10,
    F11 = Keys.F11,
    F12 = Keys.F12,

    //Arrow Keys 
    LeftArrow = Keys.Left,
    RightArrow = Keys.Right,
    UpArrow = Keys.Up,
    DownArrow = Keys.Down,
}


public enum MouseInput
{
    //Mouse 
    //Todo: Review mouse button inputs
     LeftClick = MouseButton.Left,
     RightClick = MouseButton.Right,
     MouseWheelDown = MouseButton.Middle,
     MouseButton1 = MouseButton.Button5,
     MouseButton2 = MouseButton.Button6,
}


/// <summary>
/// Class used to convert from GRIS to opentk windowing 
/// </summary>
public static class Input
{
    //Overload 1 for the method 
    //perform cast to the keyboard
    public static Keys Read(Keyboard keyboardInput) {
        return (Keys)keyboardInput; 
    }

    //Overload 2 for the method 
    //perform cast to the mouse button 
   public static MouseButton Read(MouseInput input){
        return (MouseButton)input;
   }
    
    //overload 3 for the gamepad
}

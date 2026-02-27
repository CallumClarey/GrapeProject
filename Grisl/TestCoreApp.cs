using GRIS;
using GRIS.InputSystem;
using GRIS.Interrupter;

////Calls the main game
using var game = new Game(800, 600, "GameTitle");
game.Run();

//var manager = new InputManager("ISL_Template.txt");
//manager.LoadInputs();

//Console.WriteLine("Program done");
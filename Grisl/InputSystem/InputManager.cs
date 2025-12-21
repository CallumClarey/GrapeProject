using System;
using System.Collections.Generic;
using System.Text;
using GRIS.Interrupter;
using GRISL.Interrupter;

namespace GRIS.InputSystem;

public class InputManager(string pFileName)
{
    //stores the value of the file location
    private readonly string fileName = pFileName;

    //starts the loading process for input
    public void LoadInputs()
    {
        //source 
        var source = ReadSource();
        var scanner = new Scanner(source);
        List<Token> tokens = scanner.ScanTokens();

        //debug code remove later 
        foreach (var token in tokens) Console.WriteLine(token.ToString());

        var parser = new Parser(tokens);

        //displays whether the program in valid or not
        Console.WriteLine(parser.BeginParse());
    }

    //read the source file
    private string ReadSource()
    {
        string baseDir = AppContext.BaseDirectory;
        string filePath = Path.Combine(baseDir, fileName);
        //returns source code
        return File.ReadAllText(filePath);
    }



}

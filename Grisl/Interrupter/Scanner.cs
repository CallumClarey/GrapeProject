using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using GRIS.Interrupter;
using OpenTK.Graphics.ES11;

namespace GRIS.Interrupter;

//static uses 
using static TokenType;
using static IKeywords;


internal class Scanner (string pSource) : IKeywords
{
    //source code as a string
    public string Source = pSource;

    //Token List 
    public static List<Token> Tokens = new();

    //line and index info
    private static int start = 0;
    private static int current = 0;
    private static int line = 1;


    //------------------------------------------
    //Helper Functions
    //------------------------------------------
    //checks if at the end of the read
    private bool IsAtEnd() => current >= Source.Length;

    //consumes the next char in the source code
    private char ConsumeNext() => Source[current++];

    //checks to see if a digit
    private bool IsDigit(char c) => c >= '0' && c <= '9';

    //checks to see if a valid alpha character
    private bool IsAlpha(char c) =>
        (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '_';

    private bool IsAlphaNumeric(char c) => IsAlpha(c) || IsDigit(c);

    //function to improve substring
    private string Slice(string value,int start, int end) => value.Substring(start, end - start);


    //checks the next character without consuming it
    private char Peek()
    {
        if (IsAtEnd()) return '\0';
        else return Source[current];
    }

    private char PeekNext()
    {
        if (current + 1 >= Source.Length) return '\0';
        return Source[current + 1];
    }

    //overloads used to add tokens 
    private void AddToken(TokenType tokenType) => AddToken(tokenType, null);
    private void AddToken(TokenType tokenType, object lit)
    {
        //gets a substring of the source to get the lexeme string value
        string text = Slice(Source, start, current);
        Tokens.Add(new Token(tokenType, text, lit, line));
    }


    //error handling
    private void DisplayError() => Console.WriteLine("Unexpected character Line:", line);


    //-----------------------------
    //Value functions
    //-----------------------------

    //start function 
    public List<Token> ScanTokens()
    {
        //loops through until at the end
        while (!IsAtEnd())
        {
            start = current;
            ScanToken();
        }

        AddToken(EOF);

        //if the language changed end parsing maybe required here
        return Tokens;
    }


    private void ScanToken()
    {
        //costume the next character
        var c = ConsumeNext();

        //checks the value of current character against given outcomes
        switch (c)
        {
            //single character tokens
            case ':' : AddToken(COLON); break;
            case ',' : AddToken(COMMA); break;

            //Handles comments 
            case '#':
                while (Peek() != '\n') ConsumeNext();
                break;

            //White space and newlines
            case ' ': break;
            case '\t': break;
            case '\r': break;
            case '\n': line++; break;

            //string values 
            case '"' : Identifers(); break;

            //other literals, Indentifiers, Keywords and edge cases 
            default:
                //handle digit case 
                if (IsDigit(c) || c == '-') Number(c);
                //handles indetifer and keywords
                else if (IsAlpha(c)) InputValuesAndKeywords();
                //handles edge cases
                else DisplayError();
                break;
        }
    }


 

    //------------------------------------------------------------
    //Code used to parse a string, number and identifers
    //------------------------------------------------------------


    // Functon used to read a string inside of "".
    // Will throw a log is a string is unterminated.
    private void Identifers()
    {
        //loops forward looking for closing "
        while(Peek() != '"' && !IsAtEnd()){
            if (Peek() == '\n') line++;
            ConsumeNext();
        }

        //checks to see if the string has been terminated
        if (IsAtEnd())
        { Console.WriteLine("Unterminated String"); 
            return; 
        }

        //to use the closing "
        ConsumeNext();

        //trims the speach marks 
        string value = Slice(Source, start + 1, current - 1);
        AddToken(IDENTIFER, value);
    }



    // Used to scan numbers, creating every number into a float 
    private void Number(char currentChar)
    {
        //check to see if the next value is a digit
        if(currentChar == '-' && !IsDigit(Peek()))
        {
            //error thrown as the next value is not a digit
            DisplayError();
            return;
        } 

        //cosumes token so long as it is a digit 
        while(IsDigit(Peek())) ConsumeNext();

        //check for decimal place 
        if (Peek() == '.' && IsDigit(PeekNext()))
        {
            ConsumeNext();
            while (IsDigit(Peek())) ConsumeNext();
        }

        //adds a new token as a float type 
        AddToken(NUMBERLITERAL, float.Parse(Slice(Source,start,current)));
    }



    // Function used to scan input values and keywords 
    private void InputValuesAndKeywords()
    {
        while (IsAlphaNumeric(Peek()))
        {
            ConsumeNext();
        }

        //creates token for keyword or identifer 
        string text = Slice(Source, start, current);

        //note could be bug worth could be a logic error
        //trys to get the value and outputs the value if it can find it 
        //if it cant get the value it will return false the type must be input value
        //otherwise one of the reserved keywords 
        if(!Keywords.TryGetValue(text, out var value)) value = INPUTS;
        AddToken(value, text);
    }

}

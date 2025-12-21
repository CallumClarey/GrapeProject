using System;
using System.Collections.Generic;
using System.Text;

using static GRIS.Interrupter.TokenType;
using static GRIS.Interrupter.IKeywords;
using static GRISL.Interrupter.IParseRules;
using System.Collections;
using GRIS.Interrupter;

using static GRIS.Interrupter.TokenType;

namespace GRISL.Interrupter;


internal class Parser(List<Token> pTokens) : IParseRules
{

    //sets the tokens 
    private readonly List<Token> TokenList = pTokens;
    private Queue<Token> TokenQueue  = new Queue<Token>();
    private bool hasError = false;


    //Helper function 
    private TokenType PeekToken() => TokenQueue.Peek().pType;


    //function where parsing begins 
   public bool BeginParse()
    {
        //queue all the tokens 
        foreach (Token token in TokenList) TokenQueue.Enqueue(token);

        //first stage
        //consumes the first token
        if (PeekToken() != MAP) return ThrowError("MAP UNDEFINED");
     
        return CheckProdRules();
    }


    private bool CheckProdRules()
    {
        //loop through until the end of the queue
        while (TokenQueue.Count >= 2)
        {
            //this edge case should be very very rare
            if (!ParseRules.TryGetValue(PeekToken(), out var rules))
                return ThrowError($"TOKEN DOES NOT EXIST {ErrorLogging()}");

            //dequeue the first value always map 
            // dequeue value takes the value you have just read the rules from away
            //this allows you to then check the next token in the queue
            var pastToken = TokenQueue.Dequeue();

            //checks if it contains the rule 
            if (!rules.Contains<TokenType>(PeekToken())) 
                return ThrowError($"{pastToken} CAN NOT BE FOLLOWED BY {ErrorLogging()}");
        }
        
        if(PeekToken() == EOF) return true;
        return ThrowError("NO EOF TOkEN");
    }


    //Error handling code

    private bool ThrowError(string s)
    {
        hasError = true;
        Console.WriteLine(s);
        return false;
    }

    private string ErrorLogging() => TokenQueue.Peek().ToString();

}

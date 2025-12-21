using System;
using System.Collections.Generic;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace GRIS.Interrupter;
using static TokenType;


//interface for Keywords
internal interface IKeywords
{
    public readonly static Dictionary<string, TokenType> Keywords = new() {
        // Basic keywords
        { "Map", MAP },
        { "Context", CONTEXT },
        { "Action", ACTION },
        { "Value", VALUE },

        // Control keywords
        { "End", END },
        { "Empty", EMPTY },

        // Separators
        { ":", COLON },
        { ",", COMMA },

        //types 
        {"Bool", BOOL },
        {"Float", FLOAT }
    };
}

using System;
using System.Collections.Generic;
using System.Text;
using GRIS;
using GRIS.Interrupter;
using static System.Collections.Specialized.BitVector32;

namespace GRISL.Interrupter;

using static TokenType;

internal interface IParseRules
{
    public readonly static Dictionary<TokenType, TokenType[]> ParseRules = new() {
        // Basic ones
        {MAP, [IDENTIFER] },
        {CONTEXT, [IDENTIFER, END] },
        {END, [CONTEXT, EOF] },
        {ACTION, [IDENTIFER] },
        {VALUE,[COLON] },


        {COLON,[INPUTS] },
        


        //types 
        {FLOAT, [ACTION] },
        {BOOL, [ACTION] },

        {INPUTS, [COLON, CONTEXT, FLOAT, BOOL] },



    };



}

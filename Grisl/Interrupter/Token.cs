using System;
using System.Collections.Generic;
using System.Text;

namespace GRIS.Interrupter;

/// <summary>
/// Record used to represnt a token
/// </summary>
/// <param name="pType"></param>
/// <param name="pLexeme"></param>
/// <param name="pLiteral"></param>
/// <param name="pLine"></param>
internal sealed record Token(TokenType pType, string pLexeme,object pLiteral, int pLine)
{
    readonly TokenType Type = pType;
    readonly string lexeme = pLexeme;
    readonly object literal = pLiteral;
    readonly int line = pLine;
}

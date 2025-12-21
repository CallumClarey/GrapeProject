using System;
using System.Collections.Generic;
using System.Text;

namespace GRIS.Interrupter;

public enum TokenType
{
    //NULL VALUE, END MAPPING, AND END LINE
    EMPTY,
    END,
    EOF,

    //Basic Options  
    MAP,
    CONTEXT,
    ACTION,
    VALUE,

    //Seperators
    COLON,
    COMMA,

    //Value
    //Identifers are handles like strings
    //Inputs are like indentifers 
    INPUTS,
    IDENTIFER,
    NUMBERLITERAL,


    //Value type 
    BOOL, 
    FLOAT,
    VECTOR3,
    VECTOR2,

}

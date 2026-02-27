using System;
using System.Collections.Generic;
using System.Text;

namespace GRISL.InputSystem;

/// <summary>
/// Override the error function to display proper logging. 
/// Otherwise it is logged directly to the console.
/// </summary>
public interface IErrorSystemBase
{
    /// <summary>
    /// Function designed to be overriden 
    /// </summary>
    /// <param name="log"></param>
    /// <returns></returns>
    void ErrorInputSytem(string log);

}

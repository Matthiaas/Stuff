using System;
using System.Collections.Generic;
using System.Linq;
using TaschenRechner.Functions;
namespace Interpreter
{
    public class Interpreter
    {
        public static double rechne(string aufgabe)
        {
            return Rechner.loese(aufgabe);
        }

        public static void solveLinear(string inPut) { }
    }

}

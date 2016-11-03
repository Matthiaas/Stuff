using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenRechner.Functions
{
    class Rechner
    {
        public static double loese(string text)
        {
            if (text == "") return 0;
            RechnerList list = new RechnerList();
            int klammerZähler = 0;
            {

                String temp = "";
                char lastChar = ';';
                bool isSignAllowed = true;

                foreach (char x in text)
                {
                    if (x == ' ')
                    {
                        if (temp != "")
                            list.AddLast(temp);
                        temp = "";
                    }

                    if (x == '(')
                    {
                        klammerZähler++;
                        if (temp != "")
                            list.AddLast(temp);
                        temp = "";
                        list.AddLast("" + x);
                        isSignAllowed = true;
                    }
                    else if (x == ')')
                    {
                        klammerZähler--;
                        if (temp != "")
                            list.AddLast(temp);
                        temp = "";
                        list.AddLast("" + x);
                        isSignAllowed = false;
                    }
                    if (x == '+' || x == '^' || x == '-' || x == '/' || x == '*')
                    {
                        if (temp != "")
                            list.AddLast(temp);
                        temp = "";
                        if (isSignAllowed)
                        {
                            temp += x;
                        }
                        else
                        {
                            isSignAllowed = true;
                            list.AddLast("" + x);
                        }

                    }
                    else if (x - '0' >= 0 && x - '0' <= 9)
                    {
                        temp += x;
                        isSignAllowed = false;
                    }
                    else if (x == '.' || x == ',')
                    {
                        temp += ',';
                    }
                    else if ("modsincostansqrt√lnpie".Contains(("" + x).ToLower()))
                    {
                        if (!"modsincostansqrt√lnpie".Contains(("" + lastChar).ToLower()))
                        {
                            if (temp != "")
                                list.AddLast(temp);
                            temp = "";


                        }
                        temp += x;
                    }

                    lastChar = x;
                }
                if (klammerZähler != 0)
                {
                    throw new System.ArgumentException("Falsche Klammersetzung");
                }
                if (temp != "")
                {
                    list.AddLast(temp);
                }
                // list.ElementAt(110);

            }
            if (list.Count == 0) return 0;

            if (list.ElementAt(0) != "(" || list.ElementAt(0) != ")")
            {
                list.AddFirst("(");
                list.AddLast(")");
            }
            return gothrowList(list);
        }

        private static double gothrowList(RechnerList list)
        {

            if (list.Count == 1) return Double.Parse(list.ElementAt(0));
            else if (list.Count < 3) throw new System.ArgumentException("Ungültiger Syntax");



            LinkedList<String> temp = new LinkedList<String>();
            int indexList = 0;
            int indexTemp = 0;
            while (indexList < list.Count)
            {
                String el = list.ElementAt(indexList);

                if (el == "(")
                {
                    indexTemp = indexList;
                }
                else if (el == ")")
                {
                    double res = 0;
                    RechnerList li = new RechnerList();
                    for (int i = indexTemp + 1; i < indexList; i++)
                    {
                        li.AddLast(list.ElementAt(i));
                    }
                    string result = rechneTerm(li);

                    for (int i = indexTemp; i < indexList + 1; i++)
                    {
                        list.deleteAt(indexTemp);
                    }
                    list.InsertAt(indexTemp, result);
                    return gothrowList(list);
                }
                indexList++;

            }
            return 0;

        }
        private static string rechneTerm(RechnerList list)
        {
            int indexList = 0;

            LinkedList<String> temp = new LinkedList<String>();
            for (int i = 0; i < list.Count; i++)
            {
                String el = list.ElementAt(i);
                if ("pie".Contains(el))
                {
                    double res = 0;
                    if (el == "pi")
                        res = Math.PI;
                    if (el == "e")
                        res = Math.E;
                    list.deleteAt(i);
                    list.InsertAt(i, "" + res);
                }
                else if ("sincostansqrt√ln".Contains(el))
                {
                    double res = 0;
                    if (el == "cos")
                        res = Math.Cos(Double.Parse(list.ElementAt(i + 1)));
                    if (el == "tan")
                        res = Math.Tan(Double.Parse(list.ElementAt(i + 1)));
                    if (el == "sin")
                        res = Math.Sin(Double.Parse(list.ElementAt(i + 1)));
                    if (el == "sqrt" || el == "√")
                        res = Math.Sqrt(Double.Parse(list.ElementAt(i + 1)));
                    if (el == "ln")
                        res = Math.Log(Double.Parse(list.ElementAt(i + 1)));
                    list.deleteAt(i);
                    list.deleteAt(i);
                    list.InsertAt(i, "" + res);
                }
            }

            while (indexList < list.Count)
            {
                String el = list.ElementAt(indexList);
                if (el == "^")
                {
                    String elB = list.ElementAt(indexList - 1), elA = list.ElementAt(indexList + 1);
                    list.deleteAt(indexList - 1);
                    list.deleteAt(indexList - 1);
                    list.deleteAt(indexList - 1);
                    double res = rechnen(elB, el, elA);
                    list.InsertAt(indexList - 1, "" + res);
                    indexList--;
                }

                indexList++;
            }
            indexList = 0;
            while (indexList < list.Count)
            {
                String el = list.ElementAt(indexList);

                if (el == "*" || el == "/" || el == "mod")
                {
                    String elB = list.ElementAt(indexList - 1), elA = list.ElementAt(indexList + 1);
                    list.deleteAt(indexList - 1);
                    list.deleteAt(indexList - 1);
                    list.deleteAt(indexList - 1);
                    double res = rechnen(elB, el, elA);
                    list.InsertAt(indexList - 1, "" + res);

                    indexList--;


                }

                indexList++;
            }

            if (list.Count == 2)
            {
                string x = list.ElementAt(1);
                if (x == "+")
                {
                    return list.ElementAt(0) + x.Remove(0, 1);
                }
                else
                if (x == "-")
                {
                    if (list.ElementAt(0) == "-")
                        return x.Remove(0, 1);
                    else
                        return x;
                }
                else
                {
                    return list.ElementAt(0) + x;
                }

            }

            else if (list.Count > 1)
            {

                string elB = list.ElementAt(0), el = list.ElementAt(1), elA = list.ElementAt(2);
                double res = rechnen(elB, el, elA);
                for (int i = 3; i < list.Count; i += 2)
                {
                    el = list.ElementAt(i);
                    elA = list.ElementAt(i + 1);
                    res = rechnen(res, el, elA);
                }

                return "" + res;
            }
            else
                return list.ElementAt(0);
        }

        private static double rechnen(string a1, string zeichen, string b1)
        {

            double a = Double.Parse(a1);
            return rechnen(a, zeichen, b1);
        }

        private static double rechnen(double a, string zeichen, string b1)
        {

            double b = Double.Parse(b1);
            zeichen = zeichen.ToLower();

            switch (zeichen)
            {
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "^":
                    return Math.Pow(a, b);
                case "mod":
                    return a % b;


            }

            throw new System.ArgumentException("Ungültiges Rechenzeichen");
        }


    };
}


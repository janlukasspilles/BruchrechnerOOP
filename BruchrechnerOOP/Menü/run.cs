using System;

namespace Bruchrechner
{
    partial class main
    {
        static void Run()
        {
            Bruch bruchA;
            Bruch bruchB;
            Bruch ergebnis = new Bruch();

            int trennStrich1;
            int trennStrich2;
            int trennStrich3;

            string[] rechnung = { "", "", "", "", "", "", "" };
            int currentElement = 0;

            int posZ1;
            int posN1;
            int posZ2;
            int posN2;
            int posZ3;
            int posN3;

            bool menueAktiv = true;
            do
            {
                Console.Clear();
                trennStrich1 = GetLongerLength(rechnung[0], rechnung[1], 1);
                trennStrich2 = GetLongerLength(rechnung[3], rechnung[4], 1);
                trennStrich3 = GetLongerLength(rechnung[5], rechnung[6], 1);

                posZ1 = Console.CursorLeft + (trennStrich1 - rechnung[0].Length);
                posN1 = Console.CursorLeft + (trennStrich1 - rechnung[1].Length);
                posZ2 = posZ1 + rechnung[0].Length + 3 + (trennStrich2 - rechnung[3].Length);
                posN2 = posN1 + rechnung[1].Length + 3 + (trennStrich2 - rechnung[4].Length);
                posZ3 = posZ2 + rechnung[3].Length + 3 + (trennStrich3 - rechnung[5].Length);
                posN3 = posN2 + rechnung[4].Length + 3 + (trennStrich3 - rechnung[6].Length);

                rechnung[2] = rechnung[2].Length == 0 ? " " : rechnung[2];


                Console.WriteLine("Bruchrechner");

                Console.SetCursorPosition(posZ1, Console.CursorTop);
                Console.Write($"{rechnung[0]}");
                Console.SetCursorPosition(posZ2, Console.CursorTop);
                Console.Write(rechnung[3]);
                Console.SetCursorPosition(posZ3, Console.CursorTop);
                Console.Write(rechnung[5]);
                Console.Write("\r\n");

                Console.Write($"{new string('─', trennStrich1)}");
                Console.Write($" {rechnung[2]} ");
                Console.Write($"{new string('─', trennStrich2)}");
                Console.Write($" = ");
                Console.Write($"{new string('─', trennStrich3)}");
                Console.Write("\r\n");

                Console.SetCursorPosition(posN1, Console.CursorTop);
                Console.Write($"{rechnung[1]}");
                Console.SetCursorPosition(posN2, Console.CursorTop);
                Console.Write(rechnung[4]);
                Console.SetCursorPosition(posN3, Console.CursorTop);
                Console.Write(rechnung[6]);

                switch (currentElement)
                {
                    case 0:
                        Console.SetCursorPosition(rechnung[0].Length, 1);
                        break;
                    case 1:
                        Console.SetCursorPosition(rechnung[1].Length, 3);
                        break;
                    case 2:
                        Console.SetCursorPosition(trennStrich1 + 1, 2);
                        break;
                    case 3:
                        Console.SetCursorPosition(trennStrich1 + rechnung[3].Length + 3, 1);
                        break;
                    case 4:
                        Console.SetCursorPosition(trennStrich1 + rechnung[4].Length + 3, 3);
                        break;
                }

                ConsoleKeyInfo c = Console.ReadKey(true);

                if (c.Key == ConsoleKey.RightArrow)
                {
                    if (currentElement <= 3)
                        currentElement++;
                }
                else if (c.Key == ConsoleKey.LeftArrow)
                {
                    if (currentElement >= 1)
                        currentElement--;
                }
                else if (c.Key == ConsoleKey.Backspace)
                {
                    rechnung[currentElement] = rechnung[currentElement].Substring(0, rechnung[currentElement].Length > 0 ? rechnung[currentElement].Length - 1 : 0);
                }
                else if (c.Key == ConsoleKey.Enter)
                {
                    bruchA = new Bruch { zaehler = Convert.ToInt32(rechnung[0]), nenner = Convert.ToInt32(rechnung[1]) };
                    bruchB = new Bruch { zaehler = Convert.ToInt32(rechnung[3]), nenner = Convert.ToInt32(rechnung[4]) };
                    if (BruchValid(bruchA) && BruchValid(bruchB))
                    {
                        switch (rechnung[2])
                        {
                            case "+":
                                Addition(ref bruchA, ref bruchB, ref ergebnis);
                                break;
                            case "-":
                                Subtraktion(ref bruchA, ref bruchB, ref ergebnis);
                                break;
                            case "x":
                                Multiplikation(ref bruchA, ref bruchB, ref ergebnis);
                                break;
                            case "/":
                                Division(ref bruchA, ref bruchB, ref ergebnis);
                                break;
                            default:
                                break;
                        }
                        Kuerzen(ref ergebnis);
                        rechnung[5] = ergebnis.zaehler.ToString();
                        rechnung[6] = ergebnis.nenner.ToString();
                    }
                    else
                    {
                        //Ungültiger Bruch
                    }
                }
                else
                {
                    if (currentElement != 2)
                    {
                        if (char.IsDigit(c.KeyChar))
                        {
                            rechnung[currentElement] += c.KeyChar;
                        }
                        else if (rechnung[currentElement].Length == 0 && c.KeyChar == '-')
                        {
                            rechnung[currentElement] += c.KeyChar;
                        }
                    }
                    else if (currentElement == 2)
                    {
                        if (c.KeyChar == '+' || c.KeyChar == '-' || c.KeyChar == 'x' || c.KeyChar == '/')
                        {
                            rechnung[currentElement] = c.KeyChar.ToString();
                        }
                    }
                    else
                    {
                        //Nichts
                    }
                }
            } while (menueAktiv);
        }

        struct Bruch
        {
            public int zaehler;
            public int nenner;
        }
    }
}
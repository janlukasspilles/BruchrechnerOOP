//Autor:        Jan-Lukas Spilles
//Klasse:       IA119
//Datei:        Controller.cs
//Datum:        16.09.2020
//Beschreibung: Controllerklasse dieser objektorientierten Anwendung. Steuert den Programmfluss.
//Aenderungen:  16.09.2020 Erstellung
//              21.09.2020 Splashinfo, Run-Methode, EvaluateUserEingabe
using System;
using System.Threading;

namespace BruchrechnerOOP
{
    public class Controller
    {
        #region Attributes
        private UserInterface _userInterface;
        private Bruch _bruch1;
        private Bruch _bruch2;
        private Bruch _ergebnis;
        #endregion
        #region Properties
        public UserInterface UserInterface { get => _userInterface; set => _userInterface = value; }
        public Bruch Bruch1 { get => _bruch1; set => _bruch1 = value; }
        public Bruch Bruch2 { get => _bruch2; set => _bruch2 = value; }
        public Bruch Ergebnis { get => _ergebnis; set => _ergebnis = value; }
        #endregion
        #region Constructors
        public Controller()
        {
            UserInterface = new UserInterface();
            Bruch1 = new Bruch();
            Bruch2 = new Bruch();
            Ergebnis = new Bruch();
        }
        #endregion
        #region Methods
        public void Run()
        {
            bool isActive = true;
            Splashinfo();
            do
            {
                UserInterface.UpdateUi();
                EvaluateUserEingabe(UserInterface.UserEingabeEinlesen());
            } while (isActive);
        }

        private void EvaluateUserEingabe(ConsoleKeyInfo c)
        {
            if (c.Key == ConsoleKey.RightArrow)
            {
                if (UserInterface.CurrentElement <= 3)
                    UserInterface.CurrentElement++;
            }
            else if (c.Key == ConsoleKey.LeftArrow)
            {
                if (UserInterface.CurrentElement >= 1)
                    UserInterface.CurrentElement--;
            }
            else if (c.Key == ConsoleKey.Backspace)
            {
                UserInterface.Rechnung[UserInterface.CurrentElement] = UserInterface.Rechnung[UserInterface.CurrentElement].Substring(0, UserInterface.Rechnung[UserInterface.CurrentElement].Length > 0 ? UserInterface.Rechnung[UserInterface.CurrentElement].Length - 1 : 0);
            }
            else if (c.Key == ConsoleKey.Enter)
            {
                try
                {
                    Bruch1.Zuweisen(new Bruch(Convert.ToInt32(UserInterface.Rechnung[0]), Convert.ToInt32(UserInterface.Rechnung[1])));
                    Bruch2.Zuweisen(new Bruch(Convert.ToInt32(UserInterface.Rechnung[3]), Convert.ToInt32(UserInterface.Rechnung[4])));

                    switch (UserInterface.Rechnung[2])
                    {
                        case "+":
                            BruchAddieren();
                            break;
                        case "-":
                            BruchSubtrahieren();
                            break;
                        case "x":
                            BruchMultiplizieren();
                            break;
                        case "/":
                            BruchDividieren();
                            break;
                        default:
                            throw new ArgumentException("Ungültige Rechenoperation. Unbekannter Operator!");
                    }
                    UserInterface.Rechnung[5] = Ergebnis.Zaehler.ToString();
                    UserInterface.Rechnung[6] = Ergebnis.Nenner.ToString();
                }
                catch (Exception e)
                {
                    if (e is DivideByZeroException || e is ArgumentException || e is FormatException || e is OverflowException)
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                    }
                    else
                    {
                        Console.WriteLine(e.Message + e.StackTrace);
                    }
                    Console.ReadKey(true);
                }
            }
            else
            {
                if (UserInterface.CurrentElement != 2)
                {
                    if (char.IsDigit(c.KeyChar))
                    {
                        UserInterface.Rechnung[UserInterface.CurrentElement] += c.KeyChar;
                    }
                    else if (UserInterface.Rechnung[UserInterface.CurrentElement].Length == 0 && c.KeyChar == '-')
                    {
                        UserInterface.Rechnung[UserInterface.CurrentElement] += c.KeyChar;
                    }
                }
                else if (UserInterface.CurrentElement == 2)
                {
                    if (c.KeyChar == '+' || c.KeyChar == '-' || c.KeyChar == 'x' || c.KeyChar == '/')
                    {
                        UserInterface.Rechnung[UserInterface.CurrentElement] = c.KeyChar.ToString();
                    }
                }
                else
                {
                    //Nichts
                }
            }
        }
        private void Splashinfo()
        {
            string[] titles = { "Projektname:", "Version:", "Datum:", "Autor:", "Klasse:" };
            string[] information = { "BruchrechnerOOP", "1.3", "21.09.2020", "Jan-Lukas Spilles", "IA119" };
            Console.CursorTop = 5;
            for (int i = 0; i < information.Length; i++)
            {
                Console.CursorLeft = (Console.WindowWidth - 32) / 2;
                Console.WriteLine("{0,-12}{1,20}", titles[i], information[i]);
                Thread.Sleep(400);
            }
            Console.SetCursorPosition((Console.WindowWidth - 50) / 2, Console.WindowHeight - 2);
            Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren.");
        }
        private void BruchAddieren()
        {
            Ergebnis.Zuweisen(Bruch1.Addition(Bruch2));
        }
        private void BruchSubtrahieren()
        {
            Ergebnis.Zuweisen(Bruch1.Subtraktion(Bruch2));
        }
        private void BruchMultiplizieren()
        {
            Ergebnis.Zuweisen(Bruch1.Multiplikation(Bruch2));
        }
        private void BruchDividieren()
        {
            Ergebnis.Zuweisen(Bruch1.Division(Bruch2));
        }
        #endregion
    }

}


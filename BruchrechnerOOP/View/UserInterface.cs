//Autor:        Jan-Lukas Spilles
//Klasse:       IA119
//Datei:        UserInterface.cs
//Datum:        19.09.2020
//Beschreibung: Viewklasse dieser objektorientierten Anwendung. Nimmt die Daten die Users entgegen und stellt Daten dem User visuell zur Verfügung.
//Aenderungen:  19.09.2020 Erstellung
//              21.09.2020 UpdateUi(), UserEingabeEinlesen() und GetLongerLength() implementiert.

using System;

namespace BruchrechnerOOP
{
    public class UserInterface
    {
        #region Attributes
        private string[] _rechnung;
        private int currentElement;
        #endregion
        #region Properties

        public int CurrentElement { get => currentElement; set => currentElement = value; }
        public string[] Rechnung { get => _rechnung; set => _rechnung = value; }
        #endregion
        #region Constructors
        //Default
        public UserInterface()
        {
            Rechnung = new string[] { "", "", "", "", "", "", "" };
            currentElement = 0;
        }
        #endregion
        #region Methods

        public void UpdateUi()
        {
            Console.Clear();
            int trennStrich1 = GetLongerLength(Rechnung[0], Rechnung[1], 1);
            int trennStrich2 = GetLongerLength(Rechnung[3], Rechnung[4], 1);
            int trennStrich3 = GetLongerLength(Rechnung[5], Rechnung[6], 1);
            int posZ1 = Console.CursorLeft + (trennStrich1- Rechnung[0].Length);
            int posN1 = Console.CursorLeft + (trennStrich1- Rechnung[1].Length);
            int posZ2 = posZ1 + Rechnung[0].Length + 3 + (trennStrich2 - Rechnung[3].Length);
            int posN2 = posN1 + Rechnung[1].Length + 3 + (trennStrich2 - Rechnung[4].Length);
            int posZ3 = posZ2 + Rechnung[3].Length + 3 + (trennStrich3 - Rechnung[5].Length);
            int posN3 = posN2 + Rechnung[4].Length + 3 + (trennStrich3 - Rechnung[6].Length);

            Rechnung[2] = Rechnung[2].Length == 0 ? " " : Rechnung[2];

            
            Console.WriteLine("Bruchrechner");

            Console.SetCursorPosition(posZ1, Console.CursorTop);
            Console.Write($"{Rechnung[0]}");
            Console.SetCursorPosition(posZ2, Console.CursorTop);
            Console.Write(Rechnung[3]);
            Console.SetCursorPosition(posZ3, Console.CursorTop);
            Console.Write(Rechnung[5]);
            Console.Write("\r\n");

            Console.Write($"{new string('─', trennStrich1)}");
            Console.Write($" {Rechnung[2]} ");
            Console.Write($"{new string('─', trennStrich2)}");
            Console.Write($" = ");
            Console.Write($"{new string('─', trennStrich3)}");
            Console.Write("\r\n");

            Console.SetCursorPosition(posN1, Console.CursorTop);
            Console.Write($"{Rechnung[1]}");
            Console.SetCursorPosition(posN2, Console.CursorTop);
            Console.Write(Rechnung[4]);
            Console.SetCursorPosition(posN3, Console.CursorTop);
            Console.Write(Rechnung[6]);

            switch (currentElement)
            {
                case 0:
                    Console.SetCursorPosition(Rechnung[0].Length, 1);
                    break;
                case 1:
                    Console.SetCursorPosition(Rechnung[1].Length, 3);
                    break;
                case 2:
                    Console.SetCursorPosition(trennStrich1+ 1, 2);
                    break;
                case 3:
                    Console.SetCursorPosition(trennStrich1+ Rechnung[3].Length + 3, 1);
                    break;
                case 4:
                    Console.SetCursorPosition(trennStrich1+ Rechnung[4].Length + 3, 3);
                    break;
            }
        }

        public ConsoleKeyInfo UserEingabeEinlesen()
        {
            return Console.ReadKey(true);
        }

        private int GetLongerLength(string a, string b, int defaultReturn)
        {
            int length = (a.Length > b.Length) ? a.Length : b.Length;
            return length <= 0 ? defaultReturn : length;
        }
        #endregion
    }
}

//Autor:        Jan-Lukas Spilles
//Klasse:       IA119      
//Datei:        main.cs
//Datum:        29.08.2020
//Beschreibung: main

namespace BruchrechnerOOP
{
    partial class main
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            ui.Bruch.Zuweisen(ui.BruchEinlesen());
            ui.Bruch.Zuweisen(ui.Bruch.Addition(ui.BruchEinlesen()));
        }
    }
}

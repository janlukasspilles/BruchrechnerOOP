//Autor:        Jan-Lukas Spilles
//Klasse:       IA119
//Datei:        GetLongerLength.cs
//Datum:        08.07.2020
//Beschreibung: Vergleicht zwei Strings nach der Anzahl der Zeichen
//              und gibt die Länge des längeren zurück.
//Aenderungen:  08.07.2020 Erstellung

namespace BruchrechnerOOP
{
    partial class main
    {
        private static int GetLongerLength(string a, string b, int defaultReturn)
        {
            int length = (a.Length > b.Length) ? a.Length : b.Length;
            return length <= 0 ? defaultReturn : length;
        }
    }
}
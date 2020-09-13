using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruchrechnerOOP
{
    public class UserInterface
    {
        #region Attributes
        private Bruch _bruch;
        private string _text;
        #endregion
        #region Properties
        public Bruch Bruch { get => _bruch; set => _bruch = value; }
        public string Text { get => _text; set => _text = value; }
        #endregion
        #region Constructors
        //Default
        public UserInterface()
        {
            Bruch = new Bruch();
            Text = "";
        }
        #endregion
        #region Methods
        public Bruch BruchEinlesen()
        {
            int Zaehler;
            int Nenner;
            Console.WriteLine("Bitte geben Sie einen Zaehler ein.");
            Zaehler = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie einen Nenner ein.");
            Nenner = Convert.ToInt32(Console.ReadLine());
            return new Bruch(Zaehler, Nenner);
        }

        public void BruchAusgeben()
        {
            Console.Clear();
            Console.WriteLine(Bruch.Zaehler);
            Console.WriteLine();
            Console.WriteLine("─");
            Console.WriteLine(Bruch.Nenner);
        }

        public string TextEinlesen()
        {
            return Console.ReadLine();
        }

        public void TextAusgeben()
        {
            Console.WriteLine(Text);
        }
        #endregion
    }
}

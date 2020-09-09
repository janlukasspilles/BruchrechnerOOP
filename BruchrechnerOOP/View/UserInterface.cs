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
        private Bruch _bruch1;
        private Bruch _bruch2;
        private Bruch _bruchErgebnis;
        private string _zeile1;
        private string _zeile2;
        private string _zeile3;
        private string _fehlermeldung;
        #endregion
        #region Properties
        public Bruch Bruch1 { get => _bruch1; set => _bruch1 = value; }
        public Bruch Bruch2 { get => _bruch2; set => _bruch2 = value; }
        public Bruch BruchErgebnis { get => _bruchErgebnis; set => _bruchErgebnis = value; }
        public string Zeile1 { get => _zeile1; set => _zeile1 = value; }
        public string Zeile2 { get => _zeile2; set => _zeile2 = value; }
        public string Zeile3 { get => _zeile3; set => _zeile3 = value; }
        public string Fehlermeldung { get => _fehlermeldung; set => _fehlermeldung = value; }

        #endregion
        #region Constructors
        //Default
        public UserInterface()
        {
            Bruch1 = new Bruch();
            Bruch2 = new Bruch();
            BruchErgebnis = new Bruch();
            Zeile1 = "";
            Zeile2 = "";
            Zeile3 = "";
            Fehlermeldung = "";
        }
        #endregion
        #region Methods
        public void ZeichneRechnung()
        {

        }

        public void Berechne()
        {

        }        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruchrechnerOOP
{
    public class Controller
    {
        #region Attributes
        private Bruch _bruch1;
        private Bruch _bruch2;
        private Bruch _ergebnis;
        private UserInterface _userInterface;
        #endregion
        #region Properties
        public Bruch Bruch1 { get => _bruch1; set => _bruch1 = value; }
        public Bruch Bruch2 { get => _bruch2; set => _bruch2 = value; }
        public Bruch Ergebnis { get => _ergebnis; set => _ergebnis = value; }
        public UserInterface UserInterface { get => _userInterface; set => _userInterface = value; }
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
            do
            {
                UserInterface.Text = "Bitte geben Sie den ersten Bruch ein:";
                UserInterface.TextAusgeben();
                UserInterface.Bruch.Zuweisen(UserInterface.BruchEinlesen());
                Bruch1.Zuweisen(UserInterface.Bruch);

                UserInterface.Text = "Bitte geben Sie den zweiten Bruch ein:";
                UserInterface.TextAusgeben();
                UserInterface.Bruch.Zuweisen(UserInterface.BruchEinlesen());
                Bruch2.Zuweisen(UserInterface.Bruch);

                UserInterface.Text = "Bitte geben Sie einen der folgenden Operanden ein: + - x /";
                UserInterface.TextAusgeben();
                UserInterface.Text = UserInterface.TextEinlesen();
                switch (UserInterface.Text)
                {
                    case "+":
                        Ergebnis.Zuweisen(Bruch1.Addition(Bruch2));
                        break;
                    case "-":
                        Ergebnis.Zuweisen(Bruch1.Subtraktion(Bruch2));
                        break;
                    case "x":
                        Ergebnis.Zuweisen(Bruch1.Multiplikation(Bruch2));
                        break;
                    case "/":
                        Ergebnis.Zuweisen(Bruch1.Division(Bruch2));
                        break;
                    default:
                        break;
                }
                UserInterface.Bruch.Zuweisen(Ergebnis);
                UserInterface.BruchAusgeben();
            } while (isActive);
        }
        #endregion
    }
}

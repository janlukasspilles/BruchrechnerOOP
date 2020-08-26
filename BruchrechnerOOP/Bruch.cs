using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruchrechnerOOP
{
    public class Bruch
    {
        #region Attributes
        private int _zaehler;
        private int _nenner;
        #endregion

        #region Properties
        public int Zaehler { get; set; }
        public int Nenner { get; set; }
        #endregion

        #region Constructors

        public Bruch()
        {
            this.Zaehler = 1;
            this.Nenner = 1;
        }

        public Bruch(int zaehler, int nenner)
        {
            this.Zaehler = zaehler;
            this.Nenner = nenner;
        }

        #endregion

        #region Methods
        #endregion
    }
}

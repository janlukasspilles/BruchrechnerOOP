﻿using System;
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
        //Standardkonstruktor
        public Bruch()
        {
            this.Zaehler = 1;
            this.Nenner = 1;
        }

        public Bruch(int zaehler, int nenner)
        {
            if (nenner == 0)
            {
                throw new DivideByZeroException("Der Nenner eines Bruchs darf niemals 0 sein.");
            }
            else
            {
                this.Zaehler = zaehler;
                this.Nenner = nenner;
            }
        }

        #endregion

        #region Methods
        public Bruch Addition(Bruch bruch)
        {
            Bruch ergebnis = new Bruch();

            int nennerKgv = BerechneKgv(this.Nenner, bruch.Nenner);

            ergebnis.Zaehler = this.Zaehler * nennerKgv / this.Nenner + bruch.Zaehler * nennerKgv / bruch.Nenner;
            ergebnis.Nenner = nennerKgv;

            return ergebnis;
        }

        public Bruch Subtraktion(Bruch bruch)
        {
            Bruch ergebnis = new Bruch();

            int nennerKgv = BerechneKgv(this.Nenner, bruch.Nenner);

            ergebnis.Zaehler = this.Zaehler * nennerKgv / this.Nenner - bruch.Zaehler * nennerKgv / bruch.Nenner;
            ergebnis.Nenner = nennerKgv;

            return ergebnis;
        }

        public Bruch Multiplikation(Bruch bruch)
        {
            Bruch ergebnis = new Bruch();

            ergebnis.Zaehler = this.Zaehler * bruch.Zaehler;
            ergebnis.Nenner = this.Nenner * bruch.Nenner;

            return ergebnis;
        }

        public Bruch Division(Bruch bruch)
        {
            Bruch ergebnis = new Bruch();

            ergebnis.Zaehler = this.Zaehler * bruch.Nenner;
            ergebnis.Nenner = this.Nenner * bruch.Zaehler;

            return ergebnis;
        }

        public void Zuweisen(Bruch bruch)
        {
            this.Zaehler = bruch.Zaehler;
            this.Nenner = bruch.Nenner;
        }

        private int BerechneGgt(int zahl1, int zahl2)
        {
            int temp = 0;
            while (zahl1 % zahl2 != 0)
            {
                temp = zahl1 % zahl2;
                zahl1 = zahl2;
                zahl2 = temp;
            }
            return zahl2;
        }

        private void Kuerzen()
        {
            if (Zaehler != 0)
            {
                int ggt = BerechneGgt(Nenner, Zaehler);
                Zaehler /= ggt;
                Nenner /= ggt;
            }
            else
            {
                //Nichts
            }
        }

        private int BerechneKgv(int zahl1, int zahl2)
        {
            return zahl1 * zahl2 / BerechneGgt(zahl1, zahl2);
        }
        #endregion
    }
}
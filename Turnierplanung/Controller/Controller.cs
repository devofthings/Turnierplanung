using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnierplanung
{
    public class Controller
    {
        #region Attribute
        private List<Teilnehmer> _Klassen;
        #endregion

        #region Props
        public List<Teilnehmer> Klassen { get => _Klassen; set => _Klassen = value; }
        #endregion

        #region Konstruktoren
        public Controller()
        {
            Klassen = new List<Teilnehmer>();
        }

        public Controller(List<Teilnehmer> value)
        {
            Klassen = value;
        }
        #endregion
        #region Worker
        public void TesteKlassen()
        {
            Klassen.Add(new Fussballspieler());
            Klassen.Add(new Fussballspieler());
        }
        #endregion
    }
}

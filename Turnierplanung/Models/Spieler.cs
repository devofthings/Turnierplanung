using System;
namespace Turnierplanung
{
    public class Spieler :Teilnehmer
    {
        #region Attribute
        private bool _y;
        #endregion

        #region Propertys
        public bool Y { get => _y; set => _y = value; }
        #endregion

        #region Konstruktoren
        public Spieler() :base()
        {

        }
        #endregion

        #region Worker
        #endregion
    }
}
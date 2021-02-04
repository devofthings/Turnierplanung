using System;
namespace Turnierplanung
{
    public class Fussballspieler : Spieler
    {
        #region Attribute
        private bool _z;
        #endregion

        #region Propertys
        public bool Z { get => _z; set => _z = value; }
        #endregion

        #region Konstruktoren
        public Fussballspieler() : base()
        {

        }
        #endregion

        #region Worker
        #endregion
    }
}
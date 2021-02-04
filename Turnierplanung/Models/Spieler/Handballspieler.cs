using System;
namespace Turnierplanung
{
    public class Handballspieler : Spieler
    {
        #region Attribute
        private bool _z;
        #endregion

        #region Propertys
        public bool Z { get => _z; set => _z = value; }
        #endregion

        #region Konstruktoren
        public Handballspieler() : base()
        {

        }
        #endregion

        #region Worker
        #endregion
    }
}
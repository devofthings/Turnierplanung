using System;
namespace Turnierplanung
{
    public class Schiedsrichter : Teilnehmer
    {
        #region Attribute
        private bool _z;
        #endregion

        #region Propertys
        public bool Z { get => _z; set => _z = value; }
        #endregion

        #region Konstruktoren
        public Schiedsrichter() : base()
        {

        }
        #endregion

        #region Worker
        #endregion
    }
}
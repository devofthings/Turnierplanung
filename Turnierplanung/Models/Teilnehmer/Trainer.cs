using System;
namespace Turnierplanung
{
    public class Trainer : Teilnehmer
    {
        #region Attribute
        private bool _z;
        #endregion

        #region Propertys
        public bool Z { get => _z; set => _z = value; }
        #endregion

        #region Konstruktoren
        public Trainer() : base()
        {

        }
        #endregion

        #region Worker
        #endregion
    }
}
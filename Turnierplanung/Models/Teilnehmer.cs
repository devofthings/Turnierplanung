using System;
namespace Turnierplanung
{
    public abstract class Teilnehmer
    {
        #region Attribute
        private string _status;
        private int _alter;
        private string _beruf;
        #endregion

        #region Propertys
        public string Name { get => _status; set => _status = value; }
        public int Alter { get => _alter; set => _alter = value; }
        public string Beruf { get => _beruf; set => _beruf = value; }

        #endregion

        #region Konstruktoren
        public Teilnehmer()
        {
            Name = "Max Mustermann";
            Alter = 0;
            Beruf = "Arbeitslos";
        }
        public Teilnehmer(string name, int alter, string beruf)
        {
            Name = name;
            Alter = alter;
            Beruf = beruf;
        }
        #endregion

        #region Worker
        public abstract void StellDichVor();
        #endregion
    }
}
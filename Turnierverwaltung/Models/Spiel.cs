using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnierplanung
{
    public class Spiel
    {
        #region Attributes
        private List<Teilnehmer> _teilnehmer;
        private Teilnehmer _sieger;
        private int _punkte;
        #endregion

        #region Properties
        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }
        public Teilnehmer Sieger { get => _sieger; set => _sieger = value; }
        public int Punkte { get => _punkte; set => _punkte = value; }
        #endregion

        #region Contructors
        public Spiel (List<Teilnehmer> teilnehmer, int punkte)
        {
            Teilnehmer = teilnehmer;
            Punkte = punkte;
        }

        public Spiel(List<Teilnehmer> teilnehmer)
        {
            Teilnehmer = teilnehmer;
            Punkte = 3;
        }
        #endregion

        #region Worker
        public void ErmittleSieger()
        {
            int length = Teilnehmer.Count;
            Random rnd = new Random();
            int winner = rnd.Next(0, length);
            Sieger = Teilnehmer[winner];
        }
        #endregion
    }
}
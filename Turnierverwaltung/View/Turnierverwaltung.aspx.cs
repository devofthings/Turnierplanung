/* Datei: Turnierverwaltung.aspx.cs
 * Was passiert hier?: Erlaubt das planen und durchführen von Turnieren
 * Author: Christopher Winter
 * Klasse: IA119
 */


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using Turnierplanung;


namespace Turnierverwaltung.View
{
    public partial class Turnierverwaltung : System.Web.UI.Page
    {
        #region Attributes
        private List<Teilnehmer> _teilnehmer;
        private List<Mannschaft> _teams;
        private List<Teilnehmer> _tournament;
        private Controller _control;
        private List<Spiel> _spiele;
        private List<Teilnehmer> _sieger;
        #endregion

        #region Properties
        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }
        public List<Mannschaft> Teams { get => _teams; set => _teams = value; }
        public List<Teilnehmer> Tournament { get => _tournament; set => _tournament = value; }

        public Controller Control { get => _control; set => _control = value; }
        public List<Spiel> Spiele { get => _spiele; set => _spiele = value; }
        public List<Teilnehmer> Sieger { get => _sieger; set => _sieger = value; }
        #endregion

        #region Constructors
        public Turnierverwaltung()
        {
            Control = new Controller(Teams, "127.0.0.1", "tournament", "root", "");
            Teams = new List<Mannschaft>();
            Teilnehmer = new List<Teilnehmer>();
            Tournament = new List<Teilnehmer>();
            Spiele = new List<Spiel>();
            Sieger = new List<Teilnehmer>();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void GetParticipantsAndTeams (object sender, EventArgs e)
        {
            Teilnehmer = Control.AlleTeilnehmerErhalten();
            Teams = Control.AlleMannschaftenErhalten();
            int neueID = 0;
            foreach (Teilnehmer t in Teilnehmer)
            {
                neueID += 1;
                TableRow r = new TableRow();
                TableCell c0 = new TableCell();
                TableCell c1 = new TableCell();
                c0.Text = Convert.ToString(neueID);
                c1.Text = t.Vorname;
                r.Cells.Add(c0);
                r.Cells.Add(c1);
                tbl_participantsANDteams.Rows.Add(r);
            }
            foreach (Mannschaft m in Teams)
            {
                neueID += 1;
                TableRow r = new TableRow();
                TableCell c0 = new TableCell();
                TableCell c1 = new TableCell();
                c0.Text = Convert.ToString(neueID);
                c1.Text = m.Vorname;
                r.Cells.Add(c0);
                r.Cells.Add(c1);
                tbl_participantsANDteams.Rows.Add(r);
            }
        }

        public void GetParticipantsAndTeamsInTournament(object sender, EventArgs e)
        {
            Tournament = Control.TurnierbeteiligtenErhalten();
            int indexID = 0;
            foreach (Teilnehmer t in Tournament)
            {
                TableRow r = new TableRow();
                TableCell c0 = new TableCell();
                TableCell c1 = new TableCell();
                c0.Text = Convert.ToString(indexID);
                c1.Text = t.Vorname;
                r.Cells.Add(c1);
                tbl_tournamentParticipants.Rows.Add(r);
                indexID += 1;
            }
        }


        public void AddPariticipantOrTeamToTournament(object sender, EventArgs e)
        {
            GetParticipantsAndTeams(sender, e);

            int IDtoAdd = Convert.ToInt32(txt_IDToAdd.Text);

            Table table = tbl_participantsANDteams;
            for(int trIndex = 1; trIndex < table.Rows.Count; trIndex += 1)
            {
                // Prüfe jede Tabellenzeile die 1 Zelle ob diese mit ID übereinstimmt
                if(Convert.ToInt32(table.Rows[trIndex].Cells[0].Text) == IDtoAdd)
                {
                    if(IDtoAdd > Teilnehmer.Count)
                    {
                        int berechneteTeamID = IDtoAdd - Teilnehmer.Count - 1; //-1 um den intialen index zu entfernen der bei der tabelle hinzugefügt wurde
                        Tournament.Add(Teams[berechneteTeamID]);
                        Control.TurniermannschaftHinzufuegen(Tournament.Last());
                    }
                    else
                    {
                        Tournament.Add(Teilnehmer[IDtoAdd -1]);
                        Control.TurnierteilnehmerHinzufuegen(Tournament.Last());
                    }
                }
                else { }
            }
            GetParticipantsAndTeamsInTournament(sender, e);
        }

        public void RemovePariticipantOrTeamFromTournament(object sender, EventArgs e)
        {
            GetParticipantsAndTeams(sender, e);
            int idToRemove = Convert.ToInt32(txt_IDToRemove.Text);
            if (idToRemove > Teilnehmer.Count)
            {
                int berechneteTeamID = idToRemove - Teilnehmer.Count;
                Control.TurniermannschaftEntfernen(berechneteTeamID);
            }
            else
            {
                Control.TurnierteilnehmerEntfernen(idToRemove);
            }
            GetParticipantsAndTeamsInTournament(sender, e);
        }

        public void runTournament(object sender, EventArgs e)
        {
            GetParticipantsAndTeamsInTournament(sender, e);
            int index = 1;

            foreach (Teilnehmer t in Tournament)
            {
                if(index < Tournament.Count)
                {
                    List<Teilnehmer> hinspiel = new List<Teilnehmer>();
                    List<Teilnehmer> rueckspiel = new List<Teilnehmer>();

                    hinspiel.Add(t);
                    hinspiel.Add(Tournament.ElementAt(index));
                    rueckspiel.Add(t);
                    rueckspiel.Add(Tournament.ElementAt(index));

                    Spiele.Add(new Spiel(hinspiel));
                    Spiele.Add(new Spiel(rueckspiel));

                    index += 1;
                }
                else { }
            }

            foreach (Spiel s in Spiele)
            {
                s.ErmittleSieger();
                if(Sieger.Contains(s.Sieger))
                {
                    int i = Sieger.FindIndex(x => x.Vorname == s.Sieger.Vorname && x.ID == s.Sieger.ID);
                    Sieger[i].Punkte += s.Punkte;
                }
                else
                {
                    Sieger.Add(s.Sieger);
                    Sieger.Last().Punkte += s.Punkte;
                }
            }

            foreach (Spiel s in Spiele)
            {
                Debug.WriteLine(s.Sieger.Vorname);
                Debug.WriteLine(s.Sieger.Punkte);
            }


            Sieger = Sieger.OrderBy(s => s.Punkte).ToList();
            foreach (Teilnehmer t in Sieger)
            {
                TableRow r = new TableRow();
                TableCell c0 = new TableCell();
                TableCell c1 = new TableCell();
                c0.Text = t.Vorname;
                c1.Text = t.Punkte;
                r.Cells.Add(c0);
                r.Cells.Add(c1);
                tbl_ranking.Rows.Add(r);
            }
        }
    }
}
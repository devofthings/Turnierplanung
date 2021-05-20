using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
        #endregion

        #region Properties
        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }
        public List<Mannschaft> Teams { get => _teams; set => _teams = value; }
        public Controller Control { get => _control; set => _control = value; }
        public List<Teilnehmer> Tournament { get => _tournament; set => _tournament = value; }
        #endregion

        #region Constructors
        public Turnierverwaltung()
        {
            Control = new Controller(Teams, "127.0.0.1", "tournament", "root", "");
            Teams = new List<Mannschaft>();
            Teilnehmer = new List<Teilnehmer>();
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
            int indexID = 1;
            foreach (Teilnehmer t in Tournament)
            {
                TableRow r = new TableRow();
                TableCell c0 = new TableCell();
                TableCell c1 = new TableCell();
                c0.Text = Convert.ToString(indexID);
                c1.Text = t.Vorname;
                r.Cells.Add(c1);
                tbl_participantsANDteams.Rows.Add(r);
                indexID += 1;
            }
        }


        public void AddPariticipantOrTeamToTournament(object sender, EventArgs e)
        {
            GetParticipantsAndTeams(sender, e);

            // TODO Checken was passiert wenn kein Eingabewert eingegeben wird
            int tIDtoAdd = Convert.ToInt32(txt_pIDToAdd);
            int mIDtoAdd = Convert.ToInt32(txt_mIDToAdd);

            Table table = tbl_participantsANDteams;
            for(int trIndex = 0; trIndex < table.Rows.Count; trIndex += 1)
            {
                // Prüfe jede Tabellenzeile die 1 Zelle ob diese mit tID übereinstimmt
                if(Convert.ToInt32(table.Rows[trIndex].Cells[1].Text) == tIDtoAdd)
                {
                    Tournament.Add(Teilnehmer[tIDtoAdd]);
                }
                // Prüfe jede Tabellenzeile die 1 Zelle ob diese mit mID übereinstimmt
                else if (Convert.ToInt32(table.Rows[trIndex].Cells[1].Text) == mIDtoAdd)
                {
                    int neueID = mIDtoAdd - Teilnehmer.Last().ID;
                    Tournament.Add(Teams[mIDtoAdd]);
                }
                else { }
            }

            GetParticipantsAndTeamsInTournament(sender, e);
        }

        public void RemovePariticipantOrTeamFromTournament(object sender, EventArgs e)
        {
            int idToRemove = Convert.ToInt32(txt_IDToRemove.Text);
            Tournament.RemoveAt(idToRemove - 1);
            GetParticipantsAndTeamsInTournament(sender, e);

        }

        public void runTournament(object sender, EventArgs e)
        {
            Teilnehmer = Control.AlleTeilnehmerErhalten();
            Teams = Control.AlleMannschaftenErhalten();
        }
    }
}
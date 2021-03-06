﻿/* Datei: Mannschaftsverwaltung.aspx.cs
 * Was passiert hier?: Erlaubt einen Nutzer das anlegen, editiren und löschen von Mannschaften
 * Author: Christopher Winter
 * Klasse: IA119
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Turnierplanung;

namespace Turnierverwaltung.View
{
    public partial class Mannschaftsverwaltung : System.Web.UI.Page
    {
        #region Attributes
        private Controller _control;
        private List<Mannschaft> _teams;
        private List<Teilnehmer> _teilnehmer;
        #endregion

        #region Properties
        public Controller Control { get => _control; set => _control = value; }
        public List<Mannschaft> Teams { get => _teams; set => _teams = value; }
        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }
        #endregion

        #region Contructors
        public Mannschaftsverwaltung()
        {
            Control = new Controller(Teams, "127.0.0.1", "tournament", "root", "");
            Teams = new List<Mannschaft>();
            Teilnehmer = new List<Teilnehmer>();
        }
        #endregion
        public void Page_Load(object sender, EventArgs e)
        {
        }
        public void GetTeams(object sender, EventArgs e)
        {
            Teams = Control.AlleMannschaftenErhalten();
            foreach (Mannschaft m in Teams)
            {
                TableRow r = new TableRow();
                TableCell c0 = new TableCell();
                TableCell c1 = new TableCell();
                c0.Text = m.ID.ToString();
                c1.Text = m.Vorname;
                r.Cells.Add(c0);
                r.Cells.Add(c1);
                tbl_teams.Rows.Add(r);
            }
        }

        public void AddTeam(object sender, EventArgs e)
        {
            Teams = Control.AlleMannschaftenErhalten();
            string name = txt_teamName.Text;
            int id = Teams.Last().ID + 1;
            Teams.Add(new Mannschaft(id, name));
            Control.MannschaftHinzufuegen(Teams.Last());
            GetTeams(sender, e);
        }

        public void GetTeamByID(object sender, EventArgs e)
        {
            Teams = Control.AlleMannschaftenErhalten();
            int id = Convert.ToInt32(txt_idToChange.Text);
            int index = Teams.FindIndex(t => t.ID == id);
            Mannschaft teamToChange = Teams[index];
            txt_changeTeamName.Text = teamToChange.Vorname;
        }

        public void ChangeTeam(object sender, EventArgs e)
        {
            Teams = Control.AlleMannschaftenErhalten();
            int id = Convert.ToInt32(txt_idToChange.Text);
            int index = Teams.FindIndex(t => t.ID == id);
            Mannschaft team = Teams[index];
            team.Vorname = txt_changeTeamName.Text;
            Control.MannschaftAendern(id, team);
            GetTeams(sender, e);
        }

        public void DeleteTeam(object sender, EventArgs e)
        {
            int idToDelete = Convert.ToInt32(txt_idToDelete.Text);
            Control.MannschaftLoeschen(idToDelete);
            GetTeams(sender, e);
        }
        public void GetParticipants(object sender, EventArgs e)
        {
            Teilnehmer = Control.AlleTeilnehmerErhalten();
            foreach (Teilnehmer t in Teilnehmer)
            {
                TableRow r = new TableRow();
                TableCell c0 = new TableCell();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                c0.Text = t.ID.ToString();
                c1.Text = t.Vorname + ' ' + t.Nachname;
                c2.Text = t.Beruf;
                r.Cells.Add(c0);
                r.Cells.Add(c1);
                r.Cells.Add(c2);
                tbl_participants.Rows.Add(r);
            }
        }
        public void GetAllParticipantsByTeamID(object sender, EventArgs e)
        {
            int team_id = Convert.ToInt32(txt_teamIDToGetParticipants.Text);
            GetTeams(sender, e);
            Teilnehmer = Control.TeilnehmerEinerMannschaftErhalten(team_id);
            foreach (Teilnehmer t in Teilnehmer)
            {
                TableRow r = new TableRow();
                TableCell c0 = new TableCell();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                TableCell c3 = new TableCell();
                c0.Text = t.ID.ToString();
                c1.Text = t.Vorname + ' ' + t.Nachname;
                c2.Text = t.Beruf;
                c3.Text = Teams[team_id - 1].Vorname;
                r.Cells.Add(c0);
                r.Cells.Add(c1);
                r.Cells.Add(c2);
                r.Cells.Add(c3);
                tbl_participantsInTeam.Rows.Add(r);
            }
        }
        public void AddPariticipantToTeam(object sender, EventArgs e)
        {
            int participantID = Convert.ToInt32(txt_pIDToAdd.Text);
            int teamID = Convert.ToInt32(txt_mIDToAdd.Text);
            Control.TeilnehmerZuMannschaftHinzufügen(participantID, teamID);
        }
        public void DeletePariticipantFromTeam(object sender, EventArgs e)
        {
            int participantID = Convert.ToInt32(txt_pIDToRemove.Text);
            int teamID = Convert.ToInt32(txt_mIDToRemove.Text);
            Control.TeilnehmerAusMannschaftEntfernen(participantID, teamID);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Turnierplanung;

namespace Turnierverwaltung.View
{
    public partial class Mannschaftsverwaltung : System.Web.UI.Page
    {
        #region Attributes
        private Controller _control;
        private List<Teilnehmer> _teams;
        #endregion

        #region Properties
        public Controller Control { get => _control; set => _control = value; }
        public List<Teilnehmer> Teams { get => _teams; set => _teams = value; }
        #endregion

        #region Contructors
        public Mannschaftsverwaltung()
        {
            Control = new Controller(Teams, "127.0.0.1", "tournament", "root", "");
            Teams = new List<Teilnehmer>();
        }
        #endregion
        public void Page_Load(object sender, EventArgs e)
        {
        }
        public void GetTeams(object sender, EventArgs e)
        {
            Teams = Control.AlleTeilnehmerErhalten();
            foreach (Teilnehmer t in Teams)
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
                tbl_teams.Rows.Add(r);
            }
        }
    }
}
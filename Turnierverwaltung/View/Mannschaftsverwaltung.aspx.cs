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
        private List<Mannschaft> _teams;
        #endregion

        #region Properties
        public Controller Control { get => _control; set => _control = value; }
        public List<Mannschaft> Teams { get => _teams; set => _teams = value; }
        #endregion

        #region Contructors
        public Mannschaftsverwaltung()
        {
            Control = new Controller(Teams, "127.0.0.1", "tournament", "root", "");
            Teams = new List<Mannschaft>();
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
    }
}
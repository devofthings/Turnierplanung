using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Turnierplanung;

namespace Turnierverwaltung.WebView
{
    
    public partial class WebView : System.Web.UI.Page
    {
        #region Attributes
        private Controller _control;
        private List<Teilnehmer> _teilnehmer;
        #endregion

        #region Properties
        public Controller Control { get => _control; set => _control = value; }
        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }
        #endregion

        #region Contructors
        public WebView ()
        {
            Control = new Controller(Teilnehmer, "127.0.0.1", "tournament", "root", "");
            Teilnehmer = new List<Teilnehmer>();
        }
        #endregion
        public void Page_Load(object sender, EventArgs e)
        {
        }

        public void getParticipants(object sender, EventArgs e)
        {
            btn_getAllParticipants.Text = "Du hast mich geklickert";
            Teilnehmer = Control.AlleTeilnehmerErhalten();
            foreach (Teilnehmer t in Teilnehmer)
            {
                TableRow r = new TableRow();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                c1.Text = t.Vorname + ' ' + t.Nachname;
                c2.Text = t.Beruf;
                r.Cells.Add(c1);
                r.Cells.Add(c2);
                tbl_participants.Rows.Add(r);
            }
        }

        public void addParticipant(object sender, EventArgs e)
        {
            btn_addParticipant.Text = "Du hast hinzugefügt";
        }

        public void deleteParticipant(object sender, EventArgs e)
        {
            btn_deleteParticipant.Text = "Du hast mich gelöscht";
        }
    }
}
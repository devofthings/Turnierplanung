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

        public void AddParticipant(object sender, EventArgs e)
        {
            string firstname = txt_participantFirstName.Text;
            string lastname = txt_participantLastName.Text;
            string birthday = txt_birthday.Text;
            string health = health_status_list.SelectedValue;
            string selectedJob = job_list.SelectedValue;
            Teilnehmer = Control.AlleTeilnehmerErhalten();
            int id = Teilnehmer.Last().ID + 1;
            switch (selectedJob)
            {
                case "1":
                    int goals = Convert.ToInt32(txt_goals.Text);
                    Teilnehmer.Add(new Fussballspieler(id, firstname, lastname, birthday, "Fußballspieler", health, goals));
                    break;
                case "2":
                    int strength = Convert.ToInt32(txt_strength.Text);
                    Teilnehmer.Add(new Tennisspieler(id, firstname, lastname, birthday, "Tennisspieler", health, strength));
                    break;
                case "3":
                    string strong_arm = strong_arm_list.SelectedValue;
                    Teilnehmer.Add(new Handballspieler(id, firstname, lastname, birthday, "Handballspieler", health, strong_arm));
                    break;
                case "4":
                    int trainedTeams = Convert.ToInt32(txt_amountTeams.Text);
                    Teilnehmer.Add(new Trainer(id, firstname, lastname, birthday, "Trainer", health, trainedTeams));
                    break;
                case "5":
                    Teilnehmer.Add(new Physiologe(id, firstname, lastname, birthday, "Physiologe", health));
                    break;
                case "6":
                    Teilnehmer.Add(new Zeugwart(id, firstname, lastname, birthday, "Zeugwart", health));
                    break;
                default:
                    break;
            }
            Control.TeilnehmerHinzufuegen(Teilnehmer.Last());
            Teilnehmer = Control.AlleTeilnehmerErhalten();
        }

        public void ChangeParticipant(object sender, EventArgs e)
        {
            string firstname = txt_participantFirstName.Text;
            string lastname = txt_participantLastName.Text;
            string birthday = txt_birthday.Text;
            string health = health_status_list.SelectedValue;
            string selectedJob = job_list.SelectedValue;
            int goals = Convert.ToInt32(txt_goals);
            Teilnehmer = Control.AlleTeilnehmerErhalten();
            int id = Teilnehmer.Count();
            switch (selectedJob)
            {
                //TODO PSEUDO WERTE AUSTAUSCHEN BEI CASE 1-4
                case "1":
                    Teilnehmer.Add(new Fussballspieler(id, firstname, lastname, birthday, "Fußballspieler", health, goals));
                    break;
                case "2":
                    Teilnehmer.Add(new Tennisspieler(id, firstname, lastname, birthday, "Tennisspieler", health, 1));
                    break;
                case "3":
                    Teilnehmer.Add(new Handballspieler(id, firstname, lastname, birthday, "Handballspieler", health, "links"));
                    break;
                case "4":
                    Teilnehmer.Add(new Trainer(id, firstname, lastname, birthday, "Trainer", health, 1));
                    break;
                case "5":
                    Teilnehmer.Add(new Physiologe(id, firstname, lastname, birthday, "Physiologe", health));
                    break;
                case "6":
                    Teilnehmer.Add(new Zeugwart(id, firstname, lastname, birthday, "Zeugwart", health));
                    break;
                default:
                    break;
            }
            Control.TeilnehmerHinzufuegen(Teilnehmer.Last());
        }
        public void DeleteParticipant(object sender, EventArgs e)
        {
            int idToDelete = Convert.ToInt32(txt_idToDelete.Text);
            Control.TeilnehmerLoeschen(idToDelete);
            GetParticipants(sender, e);
        }
    }
}
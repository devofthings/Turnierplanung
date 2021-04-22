using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Turnierplanung;

namespace Turnierverwaltung.View
{
    
    public partial class Teilnehmerverwaltung : System.Web.UI.Page
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
        public Teilnehmerverwaltung()
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

        public void GetParticipantByID(object sender, EventArgs e)
        {
            Teilnehmer = Control.AlleTeilnehmerErhalten();
            int id = Convert.ToInt32(txt_idToChange.Text);
            int index = Teilnehmer.FindIndex(t => t.ID == id);
            Teilnehmer participantToChange = Teilnehmer[index];
            txt_changeParticipantFirstName.Text = participantToChange.Vorname;
            txt_changeParticipantLastName.Text = participantToChange.Nachname;

            // get rid of the timestamp deliver only the date
            DateTime birthday = DateTime.Parse(participantToChange.Geburtstag);
            txt_changeBirthday.Text = birthday.Date.ToString("yyyy-MM-dd");
            changeJob_list.SelectedValue = participantToChange.GebeJobIdAus(participantToChange.Beruf).ToString();
            changeHealth_status_list.SelectedValue = participantToChange.Status;

            switch(changeJob_list.SelectedValue)
            {
                case "1":
                    int goals = Convert.ToInt32(txt_goals.Text);
                    
                    break;
                case "2":
                    int strength = Convert.ToInt32(txt_strength.Text);
                    
                    break;
                case "3":
                    string strong_arm = strong_arm_list.SelectedValue;
                    
                    break;
                case "4":
                    break;
                default:
                    break;
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
            Teilnehmer = Control.AlleTeilnehmerErhalten();
            int id = Convert.ToInt32(txt_idToChange.Text);
            int index = Teilnehmer.FindIndex(t => t.ID == id);
            Teilnehmer participant = Teilnehmer[index];
            participant.Vorname = txt_changeParticipantFirstName.Text;
            participant.Nachname = txt_changeParticipantLastName.Text;
            participant.Geburtstag = txt_changeBirthday.Text;
            string selectedJob = changeJob_list.SelectedValue;
            switch (selectedJob)
            {
                case "1":
                    participant.Beruf = "Fussballspieler";
                    break;
                case "2":
                    participant.Beruf = "Tennisspieler";
                    break;
                case "3":
                    participant.Beruf = "Handballspieler";
                    break;
                case "4":
                    participant.Beruf = "Trainer";
                    break;
                case "5":
                    participant.Beruf = "Physiologe";
                    break;
                case "6":
                    participant.Beruf = "Zeugwart";
                    break;
                default:
                    break;
            }
            participant.Status = changeHealth_status_list.SelectedValue;

            Control.TeilnehmerAendern(id, participant);
        }
        public void DeleteParticipant(object sender, EventArgs e)
        {
            int idToDelete = Convert.ToInt32(txt_idToDelete.Text);
            Control.TeilnehmerLoeschen(idToDelete);
            GetParticipants(sender, e);
        }
    }
}
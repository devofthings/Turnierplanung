﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
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
            string firstname = txt_participantFirstName.Text;
            string lastname = txt_participantLastName.Text;
            string birthday = txt_birthday.Text;
            string health = health_status_list.SelectedValue;
            string selectedJob =job_list.SelectedValue;
            switch (selectedJob)
            {
                case "1":
                    Teilnehmer.Add(new Fussballspieler(firstname, lastname, birthday, "Fußballspieler", health));
                    break;
                case "2":
                    Teilnehmer.Add(new Tennisspieler(firstname, lastname, birthday, "Tennisspieler", health));
                    break;
                case "3":
                    Teilnehmer.Add(new Handballspieler(firstname, lastname, birthday, "Handballspieler", health));
                    break;
                case "4":
                    Teilnehmer.Add(new Trainer(firstname, lastname, birthday, "Trainer", health));
                    break;
                case "5":
                    Teilnehmer.Add(new Physiologe(firstname, lastname, birthday, "Physiologe", health));
                    break;
                case "6":
                    Teilnehmer.Add(new Zeugwart(firstname, lastname, birthday, "Zeugwart", health));
                    break;
                default:
                    break;
            }
            Control.TeilnehmerHinzufuegen(Teilnehmer.Last());
        }

        public void deleteParticipant(object sender, EventArgs e)
        {
            btn_deleteParticipant.Text = "Du hast mich gelöscht";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Turnierplanung;

namespace Turnierverwaltung.WebView
{
    public partial class WebView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller control = new Controller();
        }

        protected void getAllParticipants(object sender, EventArgs e)
        {
            btn_getAllParticipants.Text = "Du hast mich geklickert";
        }

        protected void addParticipant(object sender, EventArgs e)
        {
            btn_addParticipant.Text = "Du hast mich geklickert";
        }

        protected void deleteParticipant(object sender, EventArgs e)
        {
            btn_deleteParticipant.Text = "Du hast mich geklickert";
        }
    }
}
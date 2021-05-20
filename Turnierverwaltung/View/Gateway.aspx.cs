using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnierverwaltung.View
{
    public partial class Gateway : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_goToParticipants_Click(object sender, EventArgs e)
        {
            Response.Redirect("Teilnehmerverwaltung");
        }

        protected void btn_goToTeams_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mannschaftsverwaltung");
        }

        protected void btn_goToTournament_Click(object sender, EventArgs e)
        {
            Response.Redirect("Turnierverwaltung");
        }
    }
}
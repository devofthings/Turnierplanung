using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnierverwaltung.View
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getAllParticipants(object sender, EventArgs e)
        {
            btn_requestParticipants.Text = "Du hast mich geklickert";
        }
    }
}
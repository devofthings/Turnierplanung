<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gateway.aspx.cs" Inherits="Turnierverwaltung.View.Gateway" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn_goToParticipants" Text="Zur Teilnehmerverwaltung" OnClick="btn_goToParticipants_Click" runat="server" />
            <asp:Button ID="btn_goToTeams" Text="Zur Teamverwaltung" OnClick="btn_goToTeams_Click" runat="server" />
            <asp:Button ID="btn_goToTurnament" Text="Zur Turnierverwaltung" OnClick="btn_goToTournament_Click" runat="server" />
        </div>
    </form>
</body>
</html>

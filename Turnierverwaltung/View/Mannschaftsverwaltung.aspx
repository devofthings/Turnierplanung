<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="Turnierverwaltung.View.Mannschaftsverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        * {
            font-family: Verdana, sans-serif;
        }
        body {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            align-content: center;
            background-color: #000000;
            color: #c3c3c3;
        }

        h1 {
            text-align: center;
        }

        .border {
            border-style: solid;
            border-width: thin;
            border-color: palegreen;
            margin-bottom: 5%;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            align-content: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Turnierverwaltung</h1>
        <div class="border">
            <h3>Mannschaften ausgeben</h3>
            <asp:Table id="tbl_teams" runat="server" GridLines="Both" CellPadding="15" CellSpacing="0">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Button ID="btn_getAllTeams" text="Gebe Alle Mannschaften aus" OnClick="GetTeams" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Mannschaft hinzufügen</h3>
            <h4>Informationen</h4>
            <asp:TextBox id="txt_teamName" placeholder="Mannschaftsname" runat="server"/>
            <asp:Button id="btn_addteam" text="Teilnehmer hinzufügen" OnClick="AddTeam" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Mannschaft ändern</h3>
            <asp:TextBox id="txt_idToChange" placeholder="ID" runat="server"/>
            <asp:Button id="btn_loadTeamData" text="Teilnehmerdaten erhalten" OnClick="GetTeamByID" runat="server" Font-Names="Verdana"/>
            <h4>Informationen</h4>
            <asp:TextBox id="txt_changeTeamName" placeholder="Mannschaftsname" runat="server"/>
            <asp:Button id="btn_changeTeam" text="Mannschaft ändern" OnClick="ChangeTeam" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Mannschaft löschen</h3>
            <asp:TextBox id="txt_idToDelete" placeholder="ID" runat="server"/>
            <asp:Button id="btn_deleteParticipant" text="Teilnehmer löschen" OnClick="DeleteTeam" runat="server" Font-Names="Verdana"/>
        </div>
    </form>
</body>
</html>

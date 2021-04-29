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
        <h1>Mannschaftsverwaltung</h1>
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
        <div class="border">
            <h3>Teilnehmer ausgeben</h3>
            <asp:Table id="tbl_participants" runat="server" GridLines="Both" CellPadding="15" CellSpacing="0">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Beruf</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Button id="btn_getAllParticipants" text="Gebe Alle Teilnehmer aus" OnClick="GetParticipants" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Alle Teilnehmer einer Mannschaft anzeigen</h3>
            <asp:Table id="Table1" runat="server" GridLines="Both" CellPadding="15" CellSpacing="0">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Beruf</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Mannschaft</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:TextBox id="txt_teamID" placeholder="Mannschafts ID" runat="server"/>
            <asp:Button id="btn_GetAllParticipantsFromATeam" text="Alle Teammitglieder ausgeben" OnClick="GetAllParticipantsByTeamID" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Teilnehmer zur Mannschaft hinzufügen</h3>
            <asp:TextBox id="txt_pIDToAdd" placeholder="Teilnehmer ID" runat="server"/>
            <asp:TextBox id="txt_mIDToAdd" placeholder="Mannschafts ID" runat="server"/>
            <asp:Button id="btn_addToTeam" text="Füge Teilnhemer zu Team hinzu" OnClick="AddPariticipantToTeam" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Teilnehmer aus Mannschaft entfernen</h3>
            <asp:TextBox id="txt_pIDToRemove" placeholder="Teilnehmer ID" runat="server"/>
            <asp:TextBox id="txt_mIDToRemove" placeholder="Mannschafts ID" runat="server"/>
            <asp:Button id="btn_deleteFromTeam" text="Entferne Teilnhemer aus dem Team" OnClick="DeletePariticipantFromTeam" runat="server" Font-Names="Verdana"/>
        </div>
    </form>
</body>
</html>

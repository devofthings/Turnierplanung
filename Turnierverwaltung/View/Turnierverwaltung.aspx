<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnierverwaltung.aspx.cs" Inherits="Turnierverwaltung.View.Turnierverwaltung" %>

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
            <h3>Noch Mögliche Teilnehmer und Mannschaften anzeigen</h3>
            <asp:Table id="tbl_participantsANDteams" runat="server" GridLines="Both" CellPadding="15" CellSpacing="0">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Button ID="btn_getAllParticipantsAndTeams" text="Gebe Alle Möglichen Teilnehmer und Mannschaften aus" OnClick="GetParticipantsAndTeams" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Teilnehmer / Mannschaft hinzufügen</h3>
            <asp:TextBox id="txt_pIDToAdd" placeholder="Teilnehmer ID" runat="server"/>
            <asp:TextBox id="txt_mIDToAdd" placeholder="Mannschafts ID" runat="server"/>
            <asp:Button id="btn_addToTournament" text="Füge Teilnhemer oder Team zu Turnier hinzu" OnClick="AddPariticipantOrTeamToTournament" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Teilnehmer / Mannschaft entfernen</h3>
            <asp:TextBox id="txt_IDToRemove" placeholder="Teilnehmer ID" runat="server"/>
            <asp:Button id="btn_removeFromTournament" text="Füge Teilnhemer oder Team zu Turnier hinzu" OnClick="RemovePariticipantOrTeamFromTournament" runat="server" Font-Names="Verdana"/>
        
        </div>
        <div class="border">
            <h3>Turnierteilnehmer anzeigen</h3>
            <asp:Table id="Table1" runat="server" GridLines="Both" CellPadding="15" CellSpacing="0">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Button ID="btn_getTorunamentParticipants" text="Gebe AlleTeilnehmer und Mannschaften aus" OnClick="GetParticipantsAndTeamsInTournament" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Turnier durchführen</h3>
            <asp:Button id="btn_playTournament" text="Turnier durchführen" OnClick="runTournament" runat="server" Font-Names="Verdana"/>
            <asp:Table id="tbl_ranking" runat="server" GridLines="Both" CellPadding="15" CellSpacing="0">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Punkte</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>

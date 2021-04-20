<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebView.aspx.cs" Inherits="Turnierverwaltung.WebView.WebView" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Turnierverwaltung</title>
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
            <h3>Teilnehmer hinzufügen</h3>
            <h4>Persönliche Informationen</h4>
            <asp:TextBox id="txt_participantFirstName" placeholder="Vorname" runat="server"/>
            <asp:TextBox id="txt_participantLastName" placeholder="Nachname" runat="server"/>
            <asp:TextBox id="txt_birthday" placeholder="Geburtsdatum (YYYY-MM-DD)" runat="server"/>
            <h4>Beruf</h4>
            <asp:RadioButtonList id="job_list" runat="server">
                <asp:ListItem Value="1">Fußballspieler</asp:ListItem>
                <asp:ListItem Value="2">Tennisspieler</asp:ListItem>
                <asp:ListItem Value="3">Handballspieler</asp:ListItem>
                <asp:ListItem Value="4">Trainer</asp:ListItem>
                <asp:ListItem Value="5">Physiologe</asp:ListItem>
                <asp:ListItem Value="6">Zeugwart</asp:ListItem>
            </asp:RadioButtonList>
            <h4>Gesundheitszustand</h4>
            <asp:RadioButtonList id="health_status_list" runat="server">
                <asp:ListItem>Gesund</asp:ListItem>
                <asp:ListItem>Verletzt</asp:ListItem>
            </asp:RadioButtonList>
            <h4>Spezial Eigenschaften</h4>
            <asp:TextBox id="txt_goals" placeholder="Geschossene Tore als Ganzzahl z.B. 21" runat="server"/>
            <asp:TextBox id="txt_strength" placeholder="Schlagstärke als Ganzzahl" runat="server"/>
            <h4>Starker Arm</h4>
            <asp:RadioButtonList id="strong_arm_list" runat="server">
                <asp:ListItem>Links</asp:ListItem>
                <asp:ListItem>Rechts</asp:ListItem>
            </asp:RadioButtonList>
            <asp:TextBox id="txt_amountTeams" placeholder="Anzahl Trainierter Teams" runat="server"/>
            <asp:Button id="btn_addParticipant" text="Teilnehmer hinzufügen" OnClick="AddParticipant" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Teilnehmer ändern</h3>
            <asp:TextBox id="txt_idToChange" placeholder="ID" runat="server"/>
            <asp:Button id="btn_loadParticipantData" text="Teilnehmerdaten erhalten" OnClick="GetParticipantByID" runat="server" Font-Names="Verdana"/>
            <h4>Persönliche Informationen</h4>
            <asp:TextBox id="txt_changeParticipantFirstName" placeholder="Vorname" runat="server"/>
            <asp:TextBox id="txt_changeParticipantLastName" placeholder="Nachname" runat="server"/>
            <asp:TextBox id="txt_changeBirthday" placeholder="Geburtsdatum (YYYY-MM-DD)" runat="server"/>
            <h4>Beruf</h4>
            <asp:RadioButtonList id="changeJob_list" runat="server">
                <asp:ListItem Value="1">Fußballspieler</asp:ListItem>
                <asp:ListItem Value="2">Tennisspieler</asp:ListItem>
                <asp:ListItem Value="3">Handballspieler</asp:ListItem>
                <asp:ListItem Value="4">Trainer</asp:ListItem>
                <asp:ListItem Value="5">Physiologe</asp:ListItem>
                <asp:ListItem Value="6">Zeugwart</asp:ListItem>
            </asp:RadioButtonList>
            <h4>Gesundheitszustand</h4>
            <asp:RadioButtonList id="changeHealth_status_list" runat="server">
                <asp:ListItem>Gesund</asp:ListItem>
                <asp:ListItem>Verletzt</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button id="btn_changeParticipant" text="Teilnehmer ändern" OnClick="ChangeParticipant" runat="server" Font-Names="Verdana"/>
        </div>
        <div class="border">
            <h3>Teilnehmer löschen</h3>
            <asp:TextBox id="txt_idToDelete" placeholder="ID" runat="server"/>
            <asp:Button id="btn_deleteParticipant" text="Teilnehmer löschen" OnClick="DeleteParticipant" runat="server" Font-Names="Verdana"/>
        </div>
    </form>
</body>
</html>

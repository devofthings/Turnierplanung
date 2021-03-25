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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Turnierverwaltung</h1>
        <div>
            <h3>Teilnehmer ausgeben</h3>
            <asp:Table id="tbl_participants" runat="server" GridLines="Both" CellPadding="15" CellSpacing="0">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Beruf</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Button id="btn_getAllParticipants" text="Gebe Alle Teilnehmer aus" OnClick="getAllParticipants" runat="server" Font-Names="Verdana"/>
        </div>
        <div>
            <h3>Spieler hinzufügen</h3>
            <h4>Persönliche Informationen</h4>
            <asp:TextBox id="txt_participantFirstName" placeholder="Vorname" runat="server"/>
            <asp:TextBox id="txt_participantLastName" placeholder="Nachname" runat="server"/>
            <asp:TextBox id="txt_birthday" placeholder="Geburtsdatum (DD-MM-YYYY)" runat="server"/>
            <h4>Beruf</h4>
            <asp:RadioButtonList runat="server">
                <asp:ListItem>Fußballspieler</asp:ListItem>
                <asp:ListItem>Tennisspieler</asp:ListItem>
                <asp:ListItem>Handballspieler</asp:ListItem>
            </asp:RadioButtonList>
            <h4>Gesundheitszustand</h4>
            <asp:RadioButtonList runat="server">
                <asp:ListItem>Gesund</asp:ListItem>
                <asp:ListItem>Verletzt</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button id="btn_addParticipant" text="Teilnehmer hinzufügen" OnClick="addParticipant" runat="server" Font-Names="Verdana"/>

        </div>
        <div>
            <h3>Teilnehmer löschen</h3>
            <asp:TextBox id="txt_idToDelete" placeholder="ID" runat="server"/>
            <asp:Button id="btn_deleteParticipant" text="Teilnehmer löschen" OnClick="deleteParticipant" runat="server" Font-Names="Verdana"/>
        </div>
    </form>
</body>
</html>

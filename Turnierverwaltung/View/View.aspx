<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Turnierverwaltung.View.View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="font-family: Verdana, sans-serif; text-align: center">Turnierverwaltung</h1>
            <asp:Table id="tbl_participants" runat="server" GridLines="Both" HorizontalAlign="Center" Font-Names="Verdana" Font-Size="8pt" CellPadding="15" CellSpacing="0">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Beruf</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <asp:Button id="btn_requestParticipants" text="Gebe Alle Teilnehmer aus" OnClick="getAllParticipants" runat="server" Font-Names="Verdana"/>
    </form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mannschaftsverwaltung.aspx.cs" Inherits="Turnierverwaltung.View.Mannschaftsverwaltung" %>

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
    </form>
</body>
</html>
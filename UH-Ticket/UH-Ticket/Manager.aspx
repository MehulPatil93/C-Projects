<%@ Page Title="Manager" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="WebApplication1.Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <h1>Manager</h1>
    <h3>Display Game Information:</h3>
    Choose Game: <asp:DropDownList ID="DropDownList_GameDay" runat="server" DataSourceID="SqlDataSource1" DataTextField="AwayTeamName" DataValueField="AwayTeamName"></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UH_Ticket %>" SelectCommand="SELECT * FROM [Game]"></asp:SqlDataSource>
    <asp:Button ID="Btn_GameDay" runat="server" Text="Display Game" OnClick="Btn_GameDay_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br />
    <h3>Ticket Sales Report:</h3>
    Please choose the game: <asp:DropDownList ID="DropDownList_Report" runat="server" DataSourceID="SqlDataSource1" DataTextField="GameId" DataValueField="GameId"></asp:DropDownList>
    <asp:Button ID="btn_Report" runat="server" Text="See Report" onclick="report_click"/>
    <br />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btn_ClosetGame" runat="server" Text="The closest game seat remain" onclick="btn_closet_click"/> <br />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <br /> <br />
    <asp:Button ID="btn_Initialize" runat="server" Text="Initialize Flash Sale" onclick="btn_Initialize_click"/>
    <asp:TextBox ID="game_id" runat="server" placeholder="Game ID" Visible="false"></asp:TextBox>
    <asp:TextBox ID="btn_Type" runat="server" placeholder="Category" Visible="false"></asp:TextBox>
    <asp:TextBox ID="btn_Num" runat="server" placeholder="Number of Seats" Visible="false"></asp:TextBox>
    <asp:Button ID="btn_Go" runat="server" Text="Initialize" Visible="false" OnClick="btn_Go_Click" />
</asp:Content>

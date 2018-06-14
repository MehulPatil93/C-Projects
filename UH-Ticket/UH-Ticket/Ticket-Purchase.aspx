<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ticket-Purchase.aspx.cs" Inherits="UH_Ticket.Ticket_Purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <!--<asp:Label ID="lblTicketPurchage" runat="server" Text="Ticket Purchase Page"></asp:Label>-->
        <h1>Ticket Purchase</h1>
        <br />
        <asp:Label ID="lblGame" runat="server" Text="Select Game:"></asp:Label>

        <asp:DropDownList ID="ddlGame" runat="server" DataSourceID="SqlDataSource1" DataTextField="AwayTeamName" DataValueField="AwayTeamName">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UH_Ticket %>" SelectCommand="Select AwayTeamName 
from dbo.Game
where DateOfGame &gt; GETDATE();"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Label ID="lblCategory" runat="server" Text="Select Section:"></asp:Label>

        <asp:DropDownList ID="ddlSection" runat="server" DataSourceID="SqlDataSource2" DataTextField="Section" DataValueField="Section">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UH_Ticket %>" SelectCommand="Select distinct Section
From Seat
Where SeatId not in (Select SeatId
   from TicketSales 
    where GameId = (Select GameId 
			  from Game
			  where AwayTeamName = @game));
">
            <SelectParameters>
                <asp:FormParameter DbType="String" DefaultValue="ddlGame" FormField="ddlGame" Name="game" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue" />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <!--<asp:Label ID="lblPage2" runat="server" Text="Ticket Purchase Page"></asp:Label>-->
        <h1>Ticket Purchase</h1>
        <br />
        <asp:Label ID="lblPrice" runat="server" Text="Section Price:"></asp:Label>
        &#36;
        <asp:Label ID="lblSeatPrice" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblSeat" runat="server" Text="Select Seat(s)"></asp:Label><br />
        <asp:ListBox ID="lbSeat" runat="server" DataSourceID="SqlDataSource3" DataTextField="SeatName" DataValueField="SeatName" OnSelectedIndexChanged="lbSeat_SelectedIndexChanged" SelectionMode="Multiple"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:UH_Ticket %>" SelectCommand="Select SeatName from Seat where SeatId not in (Select SeatId from TicketSales where GameId not in             
(select GameId from Game where AwayTeamName = @game));
">
            <SelectParameters>
                <asp:FormParameter DbType="String" DefaultValue="ddlGame" FormField="ddlGame" Name="game" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email ID:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtBoxEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br /><br />
        <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblContact" runat="server" Text="Contact Number:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtContact" runat="server" MaxLength="10" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnPurchase" runat="server" Text="Purchase" OnClick="btnPurchase_Click" />
        <asp:Button ID="btnRegister" runat="server" Text="Register for Flash Sales" OnClick="btnRegister_Click" />
    </asp:Panel>
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel3" runat="server">
        <br />
        <asp:Label ID="lblThank" runat="server" Text="Thank You for purchasing tickets."></asp:Label>
        <br />
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    &nbsp;
</asp:Content>

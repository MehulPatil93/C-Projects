<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UH_Ticket.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="centered h2">Welcome to TDECU Stadium,<br />
            Home of your University of Houston Cougars!</p><br />
    <img class="center-block img-responsive" src="Content/stadium.png" />

    <br /><br />

    <h3 class="centered">Stadium Sections</h3>
    <h4 class="centered">Each section has 25 seats.</h4>

    <table class="table no-border centered">
        <tr>
            <td></td>
            <td>A</td>
            <td>B</td>
            <td>C</td>
            <td></td>
        </tr>
        <tr>
            <td>D</td>
            <td></td>
            <td></td>
            <td></td>
            <td>E</td>
        </tr>
        <tr>
            <td>F</td>
            <td></td>
            <td></td>
            <td></td>
            <td>G</td>
        </tr>
        <tr>
            <td></td>
            <td>H</td>
            <td>I</td>
            <td>J</td>
            <td></td>
        </tr>
    </table>
       
    <br /><br />

     <div class="embed-responsive embed-responsive-16by9">
    <iframe width="560" height="315" src="https://www.youtube.com/embed/IsYIuLPJUFs?showinfo=0&showsearch=0&rel=0&iv_load_policy=3&cc_load_policy=1&loop=1&ap=%2526fmt%3D18?modestbranding=1" allowfullscreen></iframe>
  </div>

</asp:Content>

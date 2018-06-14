<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Flash-Sales.aspx.cs" Inherits="UH_Ticket.Flash_Sales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- UpdateUpanel let the progress can be updated without updating the whole page (partial update). -->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
            <div class="row">


           </div>
            <div class="container">
                <h2>Customers Processed:</h2>
                <div class="progress">
                    <div id="workerBar2" runat="server" class="progress-bar" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width:0%">
                        0%
                    </div>
                </div>
            </div>
            <div class="container">
                <h2>Seats Sold:</h2>
                <div class="progress">
                    <div id="workerBar3" runat="server" class="progress-bar" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width:0%">
                        0%
                    </div>
                </div>
            </div>

            <!-- The timer which used to update the progress. -->
            <asp:Timer ID="Timer" runat="server" Interval="100" Enabled="false" ontick="Timer1_Tick"></asp:Timer>

            <div class="row">
            <!-- Start the operation by inputting value and clicking the button -->
            <div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 id="theCustomerNumber" class="panel-title" runat="server">Customer Information</h3>
                    </div>
                    <div id="customerInformation" class="panel-body" runat="server">
                        <br/>
                        <br/>
                        <br/>
                        <br/>
                        <br/>
                    </div>
                </div> 
            </div>
             <div class="col-md-4 text-center"> 
                 <asp:Button ID="btnStart" runat="server" Text="Start Flash Sale" onclick="btnStart_Click" CssClass="btn btn-success"/><br /><br />
             </div>
             <div class="col-md-4">
                 <ul class="list-group">
                     <li class="list-group-item active">
                         <span  id="enBadge" class="badge" runat="server"></span>
                         Event Name
                     </li>
                     <li class="list-group-item list-group-item-info">
                         <span  id="edBadge" class="badge" runat="server"></span>
                         Event Date
                     </li>
                     <li class="list-group-item list-group-item-info">
                         <span  id="scBdge" class="badge" runat="server"></span>
                         Flash Seat Cost
                     </li>
                     <li class="list-group-item list-group-item-success">
                         <span id="tsBadge" class="badge" runat="server"></span>
                         Total seats for Flash Sale
                     </li>
                     <li class="list-group-item list-group-item-success">
                         <span  id="tcBadge" class="badge" runat="server"></span>
                         Total Customers Signed Up for Flash Sale
                     </li>
                     <li class="list-group-item list-group-item-warning">
                         <span  id="tcsBadge" class="badge" runat="server"></span>
                         Total Seats Customers are Requesting
                     </li>
                     <li class="list-group-item list-group-item-info">
                         <span  id="sRevenueTotal" class="badge" runat="server"></span>
                         Seat Available Revenue                     </li>
                     <li class="list-group-item list-group-item-warning">
                         <span  id="rRevenueTotal" class="badge" runat="server"></span>
                         Seat Request Revenue
                     </li>
                     <li class="list-group-item list-group-item-danger">
                         <span  id="lRevenueTotal" class="badge" runat="server"></span>
                         Revenue Difference
                     </li>
                 </ul>
            </div>
          </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Btn_GameDay_Click(object sender, EventArgs e)
        {
            var str = "";
            var connectionString = WebConfigurationManager.ConnectionStrings["UH_Ticket"];
            using (var connection = new SqlConnection(connectionString.ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("Select * from Game where AwayTeamName = @selectedDate", connection);
                command.Parameters.AddWithValue("selectedDate", DropDownList_GameDay.SelectedValue);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    str += "Houston vs ";
                    str += reader.GetValue(1).ToString();
                    str += " at ";
                    str += reader.GetValue(2).ToString();
                    var dt = Convert.ToDateTime(reader.GetValue(2));
                    Label1.Text = str;
                }
                connection.Close();
            }
        }

        protected void btn_Initialize_click (object sender, EventArgs e)
        {
            //btn_Type.Visible = true;
            //btn_Num.Visible = true;
            //btn_Go.Visible = true;
            //game_id.Visible = true;

            Response.Redirect("./flash-sales.aspx");
        }
        protected void btn_closet_click(object sender, EventArgs e)
        {
            var str = "";
            var connectionString = WebConfigurationManager.ConnectionStrings["UH_Ticket"];
            var dt = DateTime.Now;
            using (var connection = new SqlConnection(connectionString.ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand("Select * from game", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var day = Convert.ToDateTime(reader.GetValue(2));
                    if ((day - dt).TotalDays <= 1 && (day - dt).TotalDays > 0)
                    {
                        str += " Game ID ";
                        str += reader.GetValue(0).ToString();
                        str += " Houston vs ";
                        str += reader.GetValue(1).ToString();
                        str += " at ";
                        str += reader.GetValue(2).ToString();
                    }
                }
                if (str != "") { Label2.Text = "The closet game is: " + "<br />" + str; }
                else { Label2.Text = "There is no Game within 24 hours"; }
                connection.Close();
            }


        }
        protected void report_click(object sender, EventArgs e)
        {
            var str = "";
            var connectionString = WebConfigurationManager.ConnectionStrings["UH_Ticket"];
            using (var connection = new SqlConnection(connectionString.ConnectionString))
            {
                connection.Open();
                var availableSeat = new SqlCommand("select section, count(SeatName) From Seat where SeatId not in (Select SeatId from TicketSales where GameId = @selected) group by section", connection);
                var revenue = new SqlCommand("select s.Section, sum(s.Price) from TicketSales t, Seat s where t.SeatId = s.SeatId and t.GameId = @s1 group by s.Section", connection);
                var ticketSold = new SqlCommand("select section, count(SeatName) From Seat where SeatId in (Select SeatId from TicketSales where GameId = @s2) group by section", connection);
                availableSeat.Parameters.AddWithValue("selected", DropDownList_Report.SelectedValue);
                revenue.Parameters.AddWithValue("s1", DropDownList_Report.SelectedValue);
                ticketSold.Parameters.AddWithValue("s2", DropDownList_Report.SelectedValue);
                SqlDataReader r = revenue.ExecuteReader();
                while (r.Read())
                {
                    str += "Revenue for the game for each section: <br/>"; 
                    str += r.GetValue(0);
                    str += " revenue: ";
                    str += r.GetValue(1);
                    str += "<br/>=======================================================================<br/>";
                }
                r.Close();
                SqlDataReader t = ticketSold.ExecuteReader();
                str += "Number of ticket sold for each section: <br/>";
                while (t.Read())
                { 
                    str += t.GetValue(0);
                    str += " tickets sold: ";
                    str += t.GetValue(1);   
                }
                str += "<br/>=======================================================================<br/>";
                t.Close();
                SqlDataReader aSeats = availableSeat.ExecuteReader();
                str += "Number of seats available for the game: <br/>";
                while (aSeats.Read())
                {
                   
                    str += aSeats.GetValue(0);
                    str += " number of seats available: ";
                    str += aSeats.GetValue(1);
                    str += "<br/>";
                }
                str += "=======================================================================<br/>";
                aSeats.Close();
                Label3.Text = str;
            }
        }

        protected void btn_Go_Click(object sender, EventArgs e)
        {
            Response.Redirect("./flash-sales.aspx");
        }
    }
}
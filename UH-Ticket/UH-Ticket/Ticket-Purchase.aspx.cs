using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UH_Ticket
{
    public partial class Ticket_Purchase : System.Web.UI.Page
    {
        
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contact { get; set; }

        public string game { get; set; }
        public string section { get; set; }
        public float price { get; set; }
        public List<string> selectedItems = new List<string>();

        //Database connection
        SqlConnection conn = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            game = ddlGame.SelectedValue.ToString();
            section = ddlSection.SelectedValue.ToString();
            //Price
            using (conn = GetConnection())
            {
                String myQuery3 = "Select Price from Seat where Section = '" + section + "'";
                SqlCommand myCommand3 = new SqlCommand(myQuery3, conn);
                conn.Open();
                price = float.Parse(myCommand3.ExecuteScalar().ToString());
                conn.Close();
            }
            lblSeatPrice.Text = price.ToString();

        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {

            Panel1.Visible = false;

            try
            {
                email = txtBoxEmail.Text;
                firstName = txtFirstName.Text;
                lastName = txtLastName.Text;
                contact = txtContact.Text;

                foreach (ListItem l in lbSeat.Items)
                {
                    if (l.Selected)
                    {
                        selectedItems.Add(l.Text);
                    }
                }

                using (conn = GetConnection())
                {

                    //Update next cutomer ID
                    String myQuery1 = "Update NextCustomerId set NewCustomerId = NewCustomerId + 1;";
                    SqlCommand myCommand1 = new SqlCommand(myQuery1, conn);
                    conn.Open();
                    myCommand1.ExecuteNonQuery();
                    conn.Close();

                    //Insert into Customer Table
                    String myQuery = "Insert into Customer"
                        + " values((Select NewCustomerId from NextCustomerId),'" + firstName + "', '" + lastName + "', '"
                        + email + "', '" + contact + "');";

                    SqlCommand myCommand = new SqlCommand(myQuery, conn);
                    conn.Open();
                    myCommand.ExecuteNonQuery();
                    conn.Close();

                    //Insert into Ticket Sales Table
                    foreach (String seats in selectedItems)
                    {
                        String myQuery2 = "Insert into TicketSales" +
                            " values((Select GameId from Game where AwayTeamName = '" + ddlGame.Text + "') , "
                            + "(Select SeatId from Seat where SeatName = '" + seats + "'),"
                            + "(Select CustomerId from Customer where Email = '" + email + "') ,"
                            + "GETDATE() , 0)";
                        SqlCommand myCommand2 = new SqlCommand(myQuery2, conn);
                        conn.Open();
                        myCommand2.ExecuteNonQuery();
                        conn.Close();
                    }

                    Panel3.Visible = true;

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.StackTrace);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        protected void lbSeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //do nothing
        }

        public static SqlConnection GetConnection()
        {

            //String connStr = @"Data Source=SUPRIYAPC\SQLEXPRESS;Initial Catalog=UH-Ticket;Integrated Security=True;";
            String connStr = ConfigurationManager.ConnectionStrings["UH_Ticket"].ConnectionString;
            return new SqlConnection(connStr);

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }

    }
    
}
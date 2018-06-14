using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace UH_Ticket
{
    public partial class Flash_Sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // run query to populate this information from database
            int totalCustomers = 10000;
            int totalCustomSeatsRequested = 32455;
            int totalSeats = 11000;
            double seatCost = 32;
            string eventName = "UH vs. RICE";
            string eventDate = DateTime.Now.ToShortDateString();


            // this populates righthand area
            tcBadge.InnerText = totalCustomers.ToString("0,0");
            scBdge.InnerText = seatCost.ToString("C0");
            tcsBadge.InnerText = totalCustomSeatsRequested.ToString("0,0");
            tsBadge.InnerText = totalSeats.ToString("0,0");
            enBadge.InnerText = eventName;
            edBadge.InnerText = eventDate;
            sRevenueTotal.InnerText = (totalSeats * seatCost).ToString("C0");
            rRevenueTotal.InnerText = (totalCustomSeatsRequested * seatCost).ToString("C0");
            lRevenueTotal.InnerText = ((totalCustomSeatsRequested - totalSeats) * seatCost).ToString("C0");

        }

        int totalCustomers = 10000;
        int totalSeats = 11000;


        BackgroundWorker _worker;

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            _worker = (BackgroundWorker)Session["FirstBar"];
            if (_worker != null)
            {
                workerBar2.Attributes.Add("style", "width:" + Session["CustomersPercent"].ToString() + "%");
                workerBar2.InnerText = Session["CustomersPercent"].ToString() + "% (" + Session["CustomersCount"].ToString() + ")";
                workerBar3.Attributes.Add("style", "width:" + Session["SeatsPercent"].ToString() + "%");
                workerBar3.InnerText = Session["SeatsPercent"].ToString() + "% (" + Session["SeatsCount"].ToString() + ")";
                theCustomerNumber.InnerText = "Customer Information For Account: " + Session["SeatsCount"].ToString();
                customerInformation.InnerHtml = Session["CurrentCustomerName"].ToString();
            }
        }

        /// <summary>
        /// Create a Background Worker to run the operation when button clicked.
        /// </summary>
        protected void btnStart_Click(object sender, EventArgs e)
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += new BackgroundWorker.DoWorkEventHandler(worker_DoWork);
            _worker.RunWorker("Started...");
            Session["FirstBar"] = _worker;
            Timer.Enabled = true;
        }

        /// <summary>
        /// This method is the operation that needs long time to complete.
        /// </summary>
        void worker_DoWork(ref int progress,
            ref object result, params object[] arguments)
        {
            //capture time
            //if time is time + 1 second, then set sessions and progress. Then reset time.
            DateTime startTime = DateTime.UtcNow;
            TimeSpan noUpdateDuration = TimeSpan.FromMilliseconds(100);
            bool isStillWorking = true;
            bool SoldAllSeats = false;
            bool ProcessedAllCustomers = false;
            //int totalCustomers = 10000;
            decimal processedCustomers = 0;
            //int totalSeats = 11000;
            decimal soldSeats = 0;
            int requestedSeats = 0;
            decimal sessionSeats = 0;
            decimal sessionCustomers = 0;


            string currentCustomerInformation = string.Empty;
            Session["CustomersPercent"] = 0;
            Session["SeatsPercent"] = 0;
            Session["CustomersCount"] = processedCustomers;
            Session["SeatsCount"] = soldSeats;
            Session["SeatsRequested"] = requestedSeats;

            Session["CurrentSeat"] = 0;
            Session["CurrentCustomerName"] = string.Empty;


            while (isStillWorking)
            {
                //this is an exmple of processing the customers and seats;
                //run through your collection class and populate as you go
                for (int i = 1; i <= totalCustomers; i++)
                {
                    //replace information with customer information of record being processed
                    currentCustomerInformation = "Bob Smith<br/>1313 Mockingbird Lane<br/>Houston, Texas 77002<br/>(713) 555-1212<br/>theEmailAddress@yahoo.com";

                    //Thread.Sleep(100);
                    Random ramdom = new Random();
                    int randomNumber = ramdom.Next(0, 3); // example of seats needed by a customer
                    if (soldSeats + randomNumber <= totalSeats)
                    {
                        // this is the real number of seats the customer wants
                        requestedSeats = randomNumber;
                        soldSeats += requestedSeats;
                    }
                    else
                    {
                        SoldAllSeats = true;
                    }
                    if (i < totalCustomers)
                    {
                        processedCustomers = i;
                    }
                    else
                    {
                        ProcessedAllCustomers = true;
                    }
                    if (DateTime.UtcNow - startTime >= noUpdateDuration)
                    {
                        sessionSeats = (soldSeats / totalSeats * 100);
                        sessionCustomers = (processedCustomers / totalCustomers * 100);
                        Session["CustomersPercent"] = (int)sessionCustomers;
                        Session["SeatsPercent"] = (int)sessionSeats;
                        Session["CustomersCount"] = processedCustomers;
                        Session["SeatsCount"] = soldSeats;
                        Session["SeatsRequested"] = requestedSeats;
                        Session["CurrentCustomerName"] = currentCustomerInformation;


                        progress += 1;
                        startTime = DateTime.UtcNow;
                        if (SoldAllSeats != ProcessedAllCustomers)
                        {
                            isStillWorking = false;
                            break;
                        }
                    }
                    Thread.Sleep(1);
                }

            }
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hw09_brodzinski.classes;

namespace hw09_brodzinski
{
    public partial class summary : System.Web.UI.Page
    {
        List<Ticket> tickets = new List<Ticket>();
        ArrayList seats = new ArrayList();
        int seatCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Populating event name
            string name = Request.QueryString["label"].ToString();
            seats = (ArrayList)Session["seats"];
            tickets = (List<Ticket>)Session["purchased"];
            if (!IsPostBack)
            {
                eventNamelbl.Text = name;
                List<Ticket> tickets1 = (List<Ticket>)Session["purchased"];

                //Populating purchased tickets in drop down
                ddlTicketHolders.DataSource = tickets;
                ddlTicketHolders.DataTextField = "Name";
                ddlTicketHolders.DataValueField = "Seat";
                ddlTicketHolders.DataBind();
                ddlTicketHolders.Items.Insert(0, new ListItem("Choose Person to Remove", "0"));

                displayTxtBox.Text = BuildSummary(tickets, seats);
            }
            else
            {
                eventNamelbl.Text = name;
                //Sorts by order purchased
                if (sortRadioList.SelectedValue.Equals("Order Purchased"))
                {
                    displayTxtBox.Text = BuildSummary(tickets, seats);
                }
                //Sorts by name
                else if (sortRadioList.SelectedValue.Equals("Name"))
                {
                    List<Ticket> nameSorted = tickets.OrderBy(o => o.Name).ToList();
                    displayTxtBox.Text = BuildSummary(nameSorted, seats);
                }
                //Sorts by seat
                else if (sortRadioList.SelectedValue.Equals("Seat"))
                {
                    List<Ticket> seatSorted = tickets.OrderBy(o => o.Seat).ToList();
                    displayTxtBox.Text = BuildSummary(seatSorted, seats);
                }
            }
                
   
               
        }


        private String BuildSummary(List<Ticket> tickets, ArrayList seats)
        {
            //Building string display
            String display = "";
            display += ("Name       | Seat       | Age        |  Price\n");
            display += "---------------------------------------------\n";

            double total = 0;
            foreach (Ticket t in tickets)
            {
                total += t.Price;
                display += String.Format("{0, -10} | {1,-10} | {2,-10} | ${3,3:0.00}\n", t.Name, t.Seat, t.Age, t.Price);
            }
            double average = total / tickets.Count;

            display += "---------------------------------------------\n";
            display += "Tickets Sold: " + tickets.Count;
            display += "\nTickets Available: " + seats.Count;
            display += "\nTotal Ticket Prices: $" + total;
            display += String.Format("\nAverage Ticket Prices: ${0:0.00}", average);
            display += "\nAvailable Seats: ";
            foreach (var item in seats)
            {
                display += item + " ";
            }

            //Maintaining state
            seatCount = seats.Count;
            Session["updatedSeats"] = seats;
            Session["purchasedTickets"] = tickets;

            return display;
        }


        protected void purchaseMoreBtn_Click(object sender, EventArgs e)
        {
            //Query String
            String url = "Default.aspx";
            url += "?";
            url += "name=" + eventNamelbl.Text + "&";
            url += "seat=" + seatCount;
            Response.Redirect(url);
            
        }

        protected void rmvBtn_Click(object sender, EventArgs e)
        {    
            //Removes picked item
            String name = "";
            List<ListItem> removedItems = new List<ListItem>();
            List<Ticket> removedTickets = new List<Ticket>();

            foreach (ListItem item in ddlTicketHolders.Items)
            {
                if (item.Selected)
                {
                    name = item.Text;
                    removedItems.Add(item);
                }

            }

            foreach (ListItem item in removedItems)
            {
                ddlTicketHolders.Items.Remove(item);
               
            }


            foreach (Ticket t in tickets)
            {
                if (t.Name.Equals(name))
                {
                    removedTickets.Add(t);
                    seats.Add(t.Seat);
                    seats.Sort();
                }
            }

            foreach (Ticket t in removedTickets)
            {
                tickets.Remove(t);
            }

            //Sorts by order purchased
            if (sortRadioList.SelectedValue.Equals("Order Purchased"))
            {
                displayTxtBox.Text = BuildSummary(tickets, seats);
            }
            //Sorts by name
            else if (sortRadioList.SelectedValue.Equals("Name"))
            {
                List<Ticket> nameSorted = tickets.OrderBy(o => o.Name).ToList();
                displayTxtBox.Text = BuildSummary(nameSorted, seats);
            }
            //Sorts by seat
            else if (sortRadioList.SelectedValue.Equals("Seat"))
            {
                List<Ticket> seatSorted = tickets.OrderBy(o => o.Seat).ToList();
                displayTxtBox.Text = BuildSummary(seatSorted, seats);
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ticket_sales_system.classes;

namespace ticket_sales_system
{
    public partial class _default : System.Web.UI.Page
    {
        List<Ticket> purchased;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //Maintaining state of seats
                ArrayList seats = (ArrayList)Session["updatedSeats"];
                if (seats != null)
                {
                    for (int i = 0; i < seats.Count; i++)
                    {
                        ListItem item = new ListItem(seats[i].ToString(), seats[i].ToString());
                        availableListBox.Items.Add(item);
                    }

                }

                //Maintaing state of name and seat count
                String name = Request.QueryString["name"];
                String seat = Request.QueryString["seat"];
                eventBox.Text = name;
                seatAmnt.Visible = true;
                seatAmnt.Text = seat;

                
                //Maintaing state of purchased tickets
                List<Ticket> purchased = new List<Ticket>();
                Session["ticketList"] = purchased;

                List<Ticket> purchasedTickets = (List<Ticket>)Session["purchasedTickets"];
                if(purchasedTickets != null){
                    foreach (Ticket t in purchasedTickets)
                    {
                        purchased.Add(t);
                    }
                }
            }
            else
            {
                purchased = (List<Ticket>)Session["ticketList"];
            }
        }

        protected void makeEventBtn_Click(object sender, EventArgs e)
        {
            int first = Int32.Parse(firstBox.Text);
            int last = Int32.Parse(lastBox.Text);

            //Displaying seat availability
            int seatsAvailable = (last + 1) - first;
            seatAmnt.Visible = true;
            seatAmnt.Text = seatsAvailable.ToString();

            //Populating list box with inputted range
            for(int i = first; i < last + 1; i++)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                availableListBox.Items.Add(item);
            }

            
        }

        protected void startOverBtn_Click(object sender, EventArgs e)
        {
            //Clearing forms and sessions
            availableListBox.Items.Clear();
            Session.Clear();
            Response.Redirect("default.aspx");
        }

        protected void purchaseBtn_Click(object sender, EventArgs e)
        {
            //Make ticket object
            string name = nameBox.Text;
            int age = Int32.Parse(ageBox.Text);
            List<ListItem> removedItems = new List<ListItem>();
            
            foreach (ListItem item in availableListBox.Items)
            {
                if (item.Selected)
                {
                    if(age > 12)
                    {
                        double price = 10.00;
                        Ticket a = new Ticket(name, Int32.Parse(item.Text), age, price);
                        removedItems.Add(item);
                        purchased.Add(a);
                    }
                    else
                    {
                        double price = 5.00;
                        Ticket a = new Ticket(name, Int32.Parse(item.Text), age, price);
                        removedItems.Add(item);
                        purchased.Add(a);
                    }

                    //Update available seats
                    int updateSeatAmnt = Int32.Parse(seatAmnt.Text) - 1;
                    seatAmnt.Text = updateSeatAmnt.ToString();
                }
            }

            //Remove items from available seats
            foreach (ListItem item in removedItems)
            {
                availableListBox.Items.Remove(item);
            }

            //Clears textbox everytime ticket is bought
            nameBox.Text = string.Empty;
            ageBox.Text = string.Empty;

            //Passing purchased tickets, avilable tickets, and avilable seats to next page
            Session["purchased"] = purchased;
            int count = availableListBox.Items.Count;
            Session["count"] = count;

            ArrayList seats = new ArrayList();
            foreach (ListItem item in availableListBox.Items)
            {
                seats.Add(Int32.Parse(item.Text));
            }
                Session["seats"] = seats;


        }

        protected void eventSummaryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("summary.aspx?label=" + eventBox.Text, false);
        }
    }
}
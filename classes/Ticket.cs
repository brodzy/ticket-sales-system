using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hw09_brodzinski.classes
{
    public class Ticket
    {
        private string name;
        private int seat;
        private int age;
        private double price;
        public Ticket(string aName, int aSeat, int aAge, double aPrice)
        {
            name = aName;
            seat = aSeat;
            age = aAge;
            Price = aPrice;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Seat
        {
            get { return seat; }
            set { seat = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
  
    }
}
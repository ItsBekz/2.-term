using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CustomerOrders
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }

        public Customer()
        {
            CustomerID = 0;
            Name = "";
        }
        
        public Customer(int CustomerID, string name)
        {
            this.CustomerID = CustomerID;
            Name = name;
        }

    }
}

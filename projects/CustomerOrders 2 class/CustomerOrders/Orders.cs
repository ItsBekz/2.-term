using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders
{
    public class Orders
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public int Items { get; set; }
        public string OrderDate { get; set; }

        public Orders()
        {
            OrderID = 0;
            CustomerID = 0;
            Items = 0;
            OrderDate = "";
        }

        public Orders(int OrderID, int CustomerID, int Items, string OrderDate)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Items = Items;
            this.OrderDate = OrderDate;
        }

        public Orders(int ID,  int OrderID, int CustomerID, string Name, int Items, string OrderDate)
        {
            this.ID = ID;
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Name = Name;
            this.Items = Items;
            this.OrderDate = OrderDate;
        }
    }
}

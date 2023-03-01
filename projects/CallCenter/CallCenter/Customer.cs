
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter
{
    public class Customer
    {
        public string name;
        public int priority;

        public Customer(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }
    }
}

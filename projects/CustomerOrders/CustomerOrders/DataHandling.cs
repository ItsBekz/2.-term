using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Threading;
using System.Data;
using CustomerOrders;

namespace CustomerOrders
{
    public class DataHandling
    {
        public ObservableCollection<Customer> CustomerData = new ObservableCollection<Customer>();
        public ObservableCollection<Orders> OrdersData = new ObservableCollection<Orders>();
    }
}

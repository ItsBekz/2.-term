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

namespace CustomerOrders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        DataHandling dh;
        public MainWindow()
        {
            InitializeComponent();
            dh = new DataHandling();
            LoadData();
        }
        public void LoadData()
        {
            var GCTask = Task.Run(() => dh.GetCustomers());
            var GOTask = Task.Run(() => dh.GetOrders());
            Task.WaitAll(GCTask, GOTask);

            CustomersTable.ItemsSource = dh.CustomerData;
            OrdersTable.ItemsSource = dh.OrdersData;
        }

        public void BtnAddCustomerCmd(object sender, RoutedEventArgs e)
        {
            DataHandling dh = new DataHandling();
            dh.AddCustomerCmd(CustomerName.Text);
            CustomerName.Text = "";
            //Application.Current.Dispatcher.Invoke(() => CustomersTable.Items.Refresh());
        }

        private void BtnAddOrderCmd(object sender, RoutedEventArgs e)
        {
            DataHandling dh = new DataHandling();
            dh.AddOrderCmd(dh.FindCustomer(CustomerName.Text),AmntItems.Text);
            CustomerName.Text = "";
            AmntItems.Text = "";
        }

        public void BtnShowOrder(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Orders> orderData = new ObservableCollection<Orders>();
            DataHandling dh = new DataHandling();
            dh.ShowOrder(dh.FindCustomer(CustomerName.Text), orderData);
            CheckOrder.ItemsSource = orderData;
        }

        public void RefreshDataGrid()
        {
            CustomersTable.Items.Refresh();
        }
        
    }



}


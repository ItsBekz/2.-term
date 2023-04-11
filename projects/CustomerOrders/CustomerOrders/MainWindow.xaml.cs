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
using Microsoft.Identity.Client;

namespace CustomerOrders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        public ObservableCollection<Customer> CustomerData = new ObservableCollection<Customer>();
        public ObservableCollection<Orders> OrdersData = new ObservableCollection<Orders>();
        public SqlConnection connection = null;

        List<string> names = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerOrders"].ConnectionString);
            LoadData();
        }

        [STAThread]
        public void LoadData()
        {
            var GCTask = Task.Run(() => GetCustomers());
            var GOTask = Task.Run(() => GetOrders());

            Task.WaitAll(GCTask, GOTask);
            CustomersTable.ItemsSource = CustomerData;
            OrdersTable.ItemsSource = OrdersData;
        }

        [STAThread]
        public void GetCustomers()
        {
            lock (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("SELECT * FROM Customers", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CustomerData.Add(new Customer
                    {
                        CustomerID = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
                reader.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public void AddCustomerCmd(object sender, RoutedEventArgs e)
        {
            lock (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("INSERT INTO Customers (Name) VALUES (@Name)", connection);
                command.Parameters.AddWithValue("@Name", CustomerName.Text);
                command.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                CustomerData.Add(new Customer
                {
                    CustomerID = CustomerData.Count + 1,
                    Name = CustomerName.Text
                });
                CustomerName.Text = "";
                CollectionViewSource.GetDefaultView(CustomerData).Refresh();
            }
        }



        public void GetOrders()
        {
            lock (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("SELECT * FROM Orders", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrdersData.Add(new Orders
                    {
                        OrderID = reader.GetInt32(0),
                        CustomerID = reader.GetInt32(1),
                        Items = reader.GetInt32(2),
                        OrderDate = reader.GetString(3)
                    });
                }
                reader.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        public void AddOrderCmd(object sender, RoutedEventArgs e)
        {
            int id = FindCustomer(CustomerName.Text);
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            lock (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("INSERT INTO Orders (CustomerID, Items, OrderDate) VALUES (@CustomerID, @Items, @OrderDate)", connection);
                command.Parameters.AddWithValue("@CustomerID", id);
                command.Parameters.AddWithValue("@Items", AmntItems.Text);
                command.Parameters.AddWithValue("@OrderDate", date);
                command.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                OrdersData.Add(new Orders
                {
                    OrderID = OrdersData.Count + 101,
                    CustomerID = id,
                    Items = Int32.Parse(AmntItems.Text),
                    OrderDate = date
                });
                CustomerName.Text = "";
                AmntItems.Text = "";
                CollectionViewSource.GetDefaultView(OrdersData).Refresh();
            }


        }

        private int FindCustomer(string name)
        {
            int ID = 0;

            lock (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE Name = @Name", connection);
                command.Parameters.AddWithValue("@Name", name);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ID = reader.GetInt32(0);
                }
                reader.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                return ID;
            }

        }

        public void ShowOrder(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Orders> orderData = new ObservableCollection<Orders>();
            int id = FindCustomer(CustomerName.Text);
            lock (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("SELECT * FROM Customers c JOIN Orders o ON c.ID = o.CustomerID WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orderData.Add(new Orders
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        OrderID = reader.GetInt32(2),
                        CustomerID = id,
                        Items = reader.GetInt32(4),
                        OrderDate = reader.GetString(5)
                    });
                }
                reader.Close();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                CheckOrder.ItemsSource = orderData;
            }
        }
        
        public class DataHandling
        {
            MainWindow mw;
            public DataHandling()
            {
                mw = new MainWindow();
            }

            public int AmountOfOrders()
            {
                return mw.OrdersData.Count;
            }
            
            public ObservableCollection<Customer> GetObsCollCustomer()
            {
                return mw.CustomerData;
            }
            
            public ObservableCollection<Orders> GetObsCollOrders()
            {
                return mw.OrdersData;
            }
        }
    }
}


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
        public ObservableCollection<Customer> CustomerData = new ObservableCollection<Customer>();
        public ObservableCollection<Orders> OrdersData = new ObservableCollection<Orders>();
        string connectionString;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = "Data Source=DESKTOP-DF1T2AS; Initial Catalog=CustomerOrders;Integrated Security=True";
            LoadData();
        }

        public void LoadData()
        {
            var GCTask = Task.Run(() => GetCustomers());
            var GOTask = Task.Run(() => GetOrders());

            Task.WaitAll(GCTask, GOTask);
            Dispatcher.Invoke(() =>
            {
                CustomersTable.ItemsSource = CustomerData;
                OrdersTable.ItemsSource = OrdersData;
            });
        }

        public async Task GetCustomers()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Customers", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    CustomerData.Add(new Customer
                    {
                        CustomerID = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        } 

        public async void BtnAddCustomerCmd(object sender, RoutedEventArgs e)
        {
            await AddCustomerCmd();
        }
        
        public async Task AddCustomerCmd()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Customers (Name) VALUES (@Name)", connection);
                command.Parameters.AddWithValue("@Name", CustomerName.Text);
                await command.ExecuteNonQueryAsync();
                connection.Close();

                Dispatcher.Invoke(() =>
                {
                    CustomerData.Add(new Customer
                    {
                        CustomerID = CustomerData.Count + 1,
                        Name = CustomerName.Text
                    });
                    CustomerName.Text = "";
                    CollectionViewSource.GetDefaultView(CustomerData).Refresh();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public async Task GetOrders()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Orders", connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();
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

            connection.Close();

        }

        public async void BtnAddOrderCmd(object sender, RoutedEventArgs e)
        {
            await AddOrderCmd();
        }
        
        public async Task AddOrderCmd()
        {
            int id = FindCustomer(CustomerName.Text);
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Orders (CustomerID, Items, OrderDate) VALUES (@CustomerID, @Items, @OrderDate)", connection);
            command.Parameters.AddWithValue("@CustomerID", id);
            command.Parameters.AddWithValue("@Items", AmntItems.Text);
            command.Parameters.AddWithValue("@OrderDate", date);
            await command.ExecuteNonQueryAsync();

            connection.Close();

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

        public int FindCustomer(string name)
        {
            int ID = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE Name = @Name", connection);
            command.Parameters.AddWithValue("@Name", name);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ID = reader.GetInt32(0);
            }
            reader.Close();
            connection.Close();
            return ID;
        }

        public async void BtnShowOrder(object sender, RoutedEventArgs e)
        {
            await ShowOrder();
        }

        public async Task ShowOrder()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            ObservableCollection<Orders> orderData = new ObservableCollection<Orders>();
            int id = FindCustomer(CustomerName.Text);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Customers c JOIN Orders o ON c.ID = o.CustomerID WHERE ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = await command.ExecuteReaderAsync();
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
            connection.Close();
            CheckOrder.ItemsSource = orderData;
        }
    }
}


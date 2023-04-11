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
using System.Windows.Threading;
using System.Collections.Specialized;


namespace CustomerOrders
{
    public class DataHandling
    {
        public ObservableCollection<Customer> CustomerData = new ObservableCollection<Customer>();
        public ObservableCollection<Orders> OrdersData = new ObservableCollection<Orders>();
        public SqlConnection connection = null;


        public DataHandling()
        {
            connection = new SqlConnection("Data Source=DESKTOP-DF1T2AS;   Initial Catalog=CustomerOrders;Integrated Security=True");
        }

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

        public void AddCustomerCmd(string name)
        {
            lock (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("INSERT INTO Customers (Name) VALUES (@Name)", connection);
                command.Parameters.AddWithValue("@Name", name);
                command.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                Customer newCustomer = new Customer
                {
                    CustomerID = CustomerData.Count + 1,
                    Name = name
                };
                CustomerData.Add(newCustomer);
                CollectionViewSource.GetDefaultView(CustomerData).Refresh();
            }
        }


        public int FindCustomer(string name)
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

        public void ShowOrder(int id, ObservableCollection<Orders> orderData)
        {
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
            }
        }
        public void AddOrderCmd(int id, string items)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");

                lock (connection)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    SqlCommand command = new SqlCommand("INSERT INTO Orders (CustomerID, Items, OrderDate) VALUES (@CustomerID, @Items, @OrderDate)", connection);
                    command.Parameters.AddWithValue("@CustomerID", id);
                    command.Parameters.AddWithValue("@Items", items);
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
                        Items = Int32.Parse(items),
                        OrderDate = date
                    });
                    CollectionViewSource.GetDefaultView(OrdersData).Refresh();
                }
            }));
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

        public int AmountOfOrders()
        {
            return OrdersData.Count;
        }

        public ObservableCollection<Customer> GetObsCollCustomer()
        {
            return CustomerData;
        }

        public ObservableCollection<Orders> GetObsCollOrders()
        {
            return OrdersData;
        }
        

    }
}

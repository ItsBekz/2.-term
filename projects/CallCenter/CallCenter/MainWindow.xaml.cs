using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Threading;

namespace CallCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PriorityQueue customers = new PriorityQueue();
        List<Customer> finishedCalls = new List<Customer>();
        List<string> names = new List<string>();
        Random rand = new Random();
        Customer customer;
        public MainWindow()
        {   
            InitializeComponent();
            customers.Enqueue(new Customer() { name = "Carl", priority = rand.Next(0,10) });
            customers.Enqueue(new Customer() { name = "Bob", priority = rand.Next(0, 10) });
            customers.Enqueue(new Customer() { name = "Alice", priority = rand.Next(0, 10) });
            customers.Enqueue(new Customer() { name = "Dave", priority = rand.Next(0, 10) });
            customers.Enqueue(new Customer() { name = "Eve", priority = rand.Next(0, 10) });
            customers.Enqueue(new Customer() { name = "Frank", priority = rand.Next(0, 10) });
            customers.Enqueue(new Customer() { name = "George", priority = rand.Next(0, 10) });
            customers.Enqueue(new Customer() { name = "Hank", priority = rand.Next(0, 10) });
            IncomingCall.ItemsSource = GetCollection<Customer>.ListToCollection(customers.queue);
        }
        private void BtnIncoming_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCall.Text != "" && CurrentCall.Text != "No Call")
            {
                MessageBox.Show("Please hang up the current call before taking another one.");
                return;
            }
            else
            {
                customer = customers.Dequeue();
                CurrentCall.Text = customer.name;
                finishedCalls.Add(customer);
                IncomingCall.ItemsSource = GetCollection<Customer>.ListToCollection(customers.queue);
            }
        }
        private void BtnHangUp_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentCall.Text == "" || CurrentCall.Text == "No Call")
            {
                MessageBox.Show("No caller to hang up on");
                return;
            }
            else
            {
                CurrentCall.Text = "No Call";
                customer.date = DateTime.Now;
                HangUp.ItemsSource = GetCollection<Customer>.ListToCollection(finishedCalls);
                customers.Enqueue(new Customer() { name = name(rand.Next(0, names.Count())), priority = rand.Next(0, 10) });
                IncomingCall.ItemsSource = GetCollection<Customer>.ListToCollection(customers.queue);
            }
        }

        public string name(int i)
        {
            names.Add("Karl");
            names.Add("Samantha");
            names.Add("John");
            names.Add("Akira");
            names.Add("Jonathan");
            names.Add("Richard");
            names.Add("Albert");
            names.Add("Hans");
            names.Add("Kiriko");
            names.Add("Karen");
            names.Add("Tomoya");
            names.Add("Shakira");

            return names[i];
        }
    }

    public class GetCollection<T>
    {
        public static ObservableCollection<T> ListToCollection(List<T> list)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>(list);
            return collection;
        }
    }
}

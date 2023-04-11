using System;
using System.Collections;
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

namespace Producer_Consumer_Pattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Queue queue;
        public Producer producer;
        public Consumer consumer;
        public int num = 0;
        public MainWindow()
        {
            InitializeComponent();
            queue = new Queue(5);
            producer = new Producer(queue, 5);
            consumer = new Consumer(queue, 5);
        }

        private void BtnProducer_Click(object sender, RoutedEventArgs e)
        {
            if (queue.Count() == 5)
            {
                queue.isFull = true;
            }
            else
            {
                queue.isFull = false;
            }
            if (queue.isFull == false)
            {
                Node n = new Node() { Name = "Node " + num };
                num++;
                producer.Produce(n);
                LstQueue.Items.Add(n.Name);
            }
            else
            {
                MessageBox.Show("The Queue is full. wait until a Node has been consumed.");
            }
        }

        private void BtnConsumer_Click(object sender, RoutedEventArgs e)
        {
            if (queue.Count() > 0)
            {
                Node n = consumer.Consume();
                LstQueue.Items.Remove(n.Name);
            }
            else
            {
                MessageBox.Show("No Nodes to consume");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace ProducerConsumerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        UdpClient udpClient;
        public MainWindow()
        {
            InitializeComponent();
            udpClient = new UdpClient();
            udpClient.Connect("192.168.0.28", 1234);

        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            byte[] sendBytes = Encoding.ASCII.GetBytes(MyTextBox.Text);
            udpClient.Send(sendBytes, sendBytes.Length);
        }
    }
}

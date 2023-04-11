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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Threading;
using System.Data;
using NUnit.Framework;
using System.Windows.Automation;
using CustomerOrders;

namespace CustomerOrders_UnitTest
{
    public class Tests
    {
        MainWindow mw;
        [SetUp]
        public void Setup()
        {
            mw = new MainWindow();
        }

        [Test]
        public void LoadData()
        {
            mw.LoadData();
            Assert.That(mw.CustomerData, Is.Not.Null);
        }
    }
}

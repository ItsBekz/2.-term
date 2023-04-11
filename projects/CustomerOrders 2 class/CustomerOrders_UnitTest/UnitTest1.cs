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
using CustomerOrders;
using Microsoft.VisualStudio;
using NUnit.Framework.Constraints;

namespace CustomerOrders_UnitTest
{
    public class Tests
    {
        DataHandling dh;
        [SetUp]
        public void Setup()
        {
            dh = new DataHandling();
        }

        [Test]
        public void TestLoadData()
        {
            /*
            bool result = false;
            MainWindow mw = new MainWindow();
            dh.AddCustomerCmd("Bent");
            if (mw.CustomerData.Last().Name == "Bent")
            {
                result = true;
            }
            Assert.IsTrue(result);
            */
        }
    }
}

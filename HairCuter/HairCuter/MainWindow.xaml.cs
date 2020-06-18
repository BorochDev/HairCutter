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

namespace HairCuter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> Customers = new List<Customer>();
        public MainWindow()
        {
            InitializeComponent();

            CustomersLV.ItemsSource = Customers;

            StatusCmb.ItemsSource = Enum.GetValues(typeof(Status));
            StatusCmb.SelectedIndex = 0;
            
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            var cust = from item in Customers
                       where item.VisitDate >= DateTime.Now
                       orderby item.VisitDate ascending
                       select item;
            Customers = cust.ToList();
            CustomersLV.ItemsSource = Customers;
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Status sts = (Status)Enum.Parse(typeof(Status), StatusCmb.SelectedItem.ToString());

            Customers.Add(new Customer(sts, NameTb.Text, SurnameTb.Text, DateBox.SelectedDate.Value.Date, float.Parse(PriceTb.Text)));
            CustomersLV.ItemsSource = Customers;
            NameTb.Text = "";
            SurnameTb.Text = "";
            DateBox.Text = null;
            PriceTb.Text = "";
            StatusCmb.SelectedIndex = 0;

        }
    }
}

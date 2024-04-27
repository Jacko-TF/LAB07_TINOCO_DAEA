using Bussiness;
using Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB07_TINOCO_DAEA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public CustomerBussiness customerBussiness = new CustomerBussiness();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtCustomerName.Text;

            List<Customer> customers = customerBussiness.getCustomersByName(name);

            dgCustomers.ItemsSource = customers;
        }
    }
}
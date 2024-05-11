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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductView productView = new ProductView();

            productView.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string name = txtCustomerName.Text;
            string address = txtCustomerAddress.Text;
            string phone = txtCustomerPhone.Text;

            bool created = customerBussiness.createCustomer(name, address, phone);
            if (created)
            {
                MessageBox.Show("Customer creado correctamente");

                dgCustomers.ItemsSource = customerBussiness.getCustomersByName(name);

                clearText();
            }
            else
            {
                MessageBox.Show("Error al crear customer");
                clearText();
            }
        }

        private void dgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer customer = (Customer)dgCustomers.SelectedItem;
            if (customer != null)
            {
                txtCustomerId.Text = customer.customer_id.ToString();
                txtCustomerName.Text = customer.name.ToString();
                txtCustomerAddress.Text= customer.address.ToString();
                txtCustomerPhone.Text= customer.phone.ToString();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int id =  0;

            Int32.TryParse(txtCustomerId.Text, out id);

            bool created = customerBussiness.deleteCustomer(id);
            if (created)
            {
                MessageBox.Show("Customer eliminado correctamente");

                dgCustomers.ItemsSource = customerBussiness.getCustomersByName("");

                clearText();
            }
            else
            {
                MessageBox.Show("Error al eliminar customer");
                clearText();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            clearText();
        }

        public void clearText()
        {
            txtCustomerId.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtCustomerPhone.Text = string.Empty;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if(txtCustomerId != null)
            {
                int id = 0;

                Int32.TryParse(txtCustomerId.Text, out id);

                string name = txtCustomerName.Text;
                string address = txtCustomerAddress.Text;
                string phone = txtCustomerPhone.Text;

                bool updated = customerBussiness.updateCustomer(id, name, address, phone);

                if (updated)
                {
                    MessageBox.Show("Customer actualizado correctamente");

                    dgCustomers.ItemsSource = customerBussiness.getCustomersByName(name);

                    clearText();
                }
                else
                {
                    MessageBox.Show("Error al crear customer");
                    clearText();
                }

            }
            else
            {
                MessageBox.Show("Seleccione una fila de la tabla");
                clearText();
            }
        }
    }
}
using Bussiness;
using Entity;
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
using System.Windows.Shapes;

namespace LAB07_TINOCO_DAEA
{
    /// <summary>
    /// Lógica de interacción para ProductView.xaml
    /// </summary>
    public partial class ProductView : Window
    {
        public ProductView()
        {
            InitializeComponent();
        }

        public ProductBussiness productBussiness = new ProductBussiness();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtProductName.Text;

                List<Product> products = productBussiness.getProductsByName(name);

                dgProducts.ItemsSource = products;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error", ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            
            mainWindow.Show();
        }
    }
}

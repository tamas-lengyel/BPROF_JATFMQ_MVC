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

namespace WpfClient
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

        private void Button_ListSalons(object sender, RoutedEventArgs e)
        {
            Window w = new SalonsWindow();
            w.Show();
            this.Close();
        }

        private void Button_ListCars(object sender, RoutedEventArgs e)
        {
            Window w = new CarsWindow();
            w.Show();
            this.Close();
        }

        private void Button_ListRenters(object sender, RoutedEventArgs e)
        {
            Window w = new RentersWindow();
            w.Show();
            this.Close();
        }
    }
}

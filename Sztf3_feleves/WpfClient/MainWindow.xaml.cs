using Models.VM;
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
        TokenVM token;

        public MainWindow(TokenVM _token)
        {
            InitializeComponent();
            token = _token;
        }

        private void Button_ListSalons(object sender, RoutedEventArgs e)
        {
            Window w = new SalonsWindow(token);
            w.Show();
            this.Close();
        }

        private void Button_ListCars(object sender, RoutedEventArgs e)
        {
            Window w = new CarsWindow(token);
            w.Show();
            this.Close();
        }

        private void Button_ListRenters(object sender, RoutedEventArgs e)
        {
            Window w = new RentersWindow(token);
            w.Show();
            this.Close();
        }
    }
}

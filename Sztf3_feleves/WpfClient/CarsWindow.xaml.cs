using Models;
using System;
using System.Collections.Generic;
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

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for CarsWindow.xaml
    /// </summary>
    public partial class CarsWindow : Window
    {
        public CarsWindow()
        {
            InitializeComponent();
            GetPlayListNames();
        }

        public async Task GetPlayListNames()
        {
            dGrid.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", "/cars");
            IEnumerable<Cars> cars =
                await restservice.Get<Cars>();

            dGrid.ItemsSource = cars;
            dGrid.SelectedIndex = 0;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Window w = new MainWindow();
            w.Show();
            this.Close();
        }

        private void Button_Refresh(object sender, RoutedEventArgs e)
        {
            GetPlayListNames();
        }

        private void Button_ModCar(object sender, RoutedEventArgs e)
        {
            Window w = new AddCarWindow(dGrid.SelectedItem as Cars);
            w.Show();
        }

        private void Button_DelCar(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService("https://localhost:5001/", "/cars");
            restservice.Delete<string>((dGrid.SelectedItem as Cars).CarId);
        }

        private void Button_AddRenter(object sender, RoutedEventArgs e)
        {
            Window w = new AddRenterWindow(dGrid.SelectedItem as Cars);
            w.Show();
        }
    }
}

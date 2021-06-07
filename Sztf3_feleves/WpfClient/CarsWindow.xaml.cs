using Models;
using Models.VM;
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
        TokenVM token;

        public CarsWindow(TokenVM _token)
        {
            InitializeComponent();
            token = _token;
            GetCars();
        }

        public async Task GetCars()
        {
            dGrid.ItemsSource = null;
            RestService restservice = new RestService(WebAddress.Address(), "/cars", token.Token);
            IEnumerable<Cars> cars =
                await restservice.Get<Cars>();

            dGrid.ItemsSource = cars;
            dGrid.SelectedIndex = 0;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Window w = new MainWindow(token);
            w.Show();
            this.Close();
        }

        private void Button_Refresh(object sender, RoutedEventArgs e)
        {
            GetCars();
        }

        private void Button_ModCar(object sender, RoutedEventArgs e)
        {
            Window w = new AddCarWindow(dGrid.SelectedItem as Cars, token);
            w.Show();
        }

        private void Button_DelCar(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService(WebAddress.Address(), "/cars", token.Token);
            restservice.Delete<string>((dGrid.SelectedItem as Cars).CarId);
            GetCars();
        }

        private void Button_AddRenter(object sender, RoutedEventArgs e)
        {
            Window w = new AddRenterWindow(dGrid.SelectedItem as Cars, token);
            w.Show();
        }
    }
}

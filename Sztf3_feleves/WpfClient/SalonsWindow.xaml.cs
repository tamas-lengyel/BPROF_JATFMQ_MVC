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
    /// Interaction logic for SalonsWindow.xaml
    /// </summary>
    public partial class SalonsWindow : Window
    {
        public SalonsWindow()
        {
            InitializeComponent();
            GetPlayListNames();
        }

        public async Task GetPlayListNames()
        {
            dGrid.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", "/salons");
            IEnumerable<Salons> salons =
                await restservice.Get<Salons>();

            dGrid.ItemsSource = salons;
            dGrid.SelectedIndex = 0;
        }

        private void Button_AddSalon(object sender, RoutedEventArgs e)
        {
            Window w = new AddSalonWindow();
            w.Show();
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

        private void Button_AddCar(object sender, RoutedEventArgs e)
        {
            Window w = new AddCarWindow(dGrid.SelectedItem as Salons);
            w.Show();
        }

        private void Button_ModSalon(object sender, RoutedEventArgs e)
        {
            Window w = new AddSalonWindow(dGrid.SelectedItem as Salons);
            w.Show();
        }

        private void Button_DelSalon(object sender, RoutedEventArgs e)
        {
            RestService restService = new RestService("https://localhost:5001/", "/salons");
            restService.Delete<string>((dGrid.SelectedItem as Salons).SalonId);
        }
    }
}

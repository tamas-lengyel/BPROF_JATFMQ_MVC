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
    /// Interaction logic for RentersWindow.xaml
    /// </summary>
    public partial class RentersWindow : Window
    {
        public RentersWindow()
        {
            InitializeComponent();
            GetPlayListNames();
        }

        public async Task GetPlayListNames()
        {
            dGrid.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", "/renter");
            IEnumerable<Renters> renters =
                await restservice.Get<Renters>();

            dGrid.ItemsSource = renters;
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

        private void Button_ModRenter(object sender, RoutedEventArgs e)
        {
            Window w = new AddRenterWindow(dGrid.SelectedItem as Renters);
            w.Show();
        }

        private void Button_DelRenter(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService("https://localhost:5001/", "/renter");
            restservice.Delete<string>((dGrid.SelectedItem as Renters).RenterId);
        }
    }
}

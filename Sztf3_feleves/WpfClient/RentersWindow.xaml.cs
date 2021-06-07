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
    /// Interaction logic for RentersWindow.xaml
    /// </summary>
    public partial class RentersWindow : Window
    {
        TokenVM token;

        public RentersWindow(TokenVM _token)
        {
            InitializeComponent();
            token = _token;
            GetRenters();
        }

        public async Task GetRenters()
        {
            dGrid.ItemsSource = null;
            RestService restservice = new RestService(WebAddress.Address(), "/renter", token.Token);
            IEnumerable<Renters> renters =
                await restservice.Get<Renters>();

            dGrid.ItemsSource = renters;
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
            GetRenters();
        }

        private void Button_ModRenter(object sender, RoutedEventArgs e)
        {
            Window w = new AddRenterWindow(dGrid.SelectedItem as Renters, token);
            w.Show();
        }

        private void Button_DelRenter(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService(WebAddress.Address(), "/renter", token.Token);
            restservice.Delete<string>((dGrid.SelectedItem as Renters).RenterId);
            GetRenters();
        }
    }
}

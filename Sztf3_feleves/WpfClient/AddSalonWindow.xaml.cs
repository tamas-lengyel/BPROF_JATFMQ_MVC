using Models;
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
using System.Windows.Shapes;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for AddSalonWindow.xaml
    /// </summary>
    public partial class AddSalonWindow : Window
    {
        string salonId;
        TokenVM token;

        public AddSalonWindow(Salons s, TokenVM _token)
        {
            InitializeComponent();
            this.postalCode.Text = s.PostalCode;
            this.city.Text = s.City;
            this.address.Text = s.Address;
            salonId = s.SalonId;
            token = _token;
        }

        public AddSalonWindow(TokenVM _token)
        {
            InitializeComponent();
            token = _token;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (salonId != null)
            {
                Salons s = new Salons();
                s.PostalCode = postalCode.Text.ToString();
                s.City = city.Text.ToString();
                s.Address = address.Text.ToString();
                s.SalonId = salonId;

                RestService restService = new RestService(WebAddress.Address(), "/salons", token.Token);
                restService.Put<string, Salons>(salonId, s);

                salonId = null;
            }
            else
            {
                Salons s = new Salons();
                s.PostalCode = postalCode.Text.ToString();
                s.City = city.Text.ToString();
                s.Address = address.Text.ToString();

                RestService restService = new RestService(WebAddress.Address(), "/salons", token.Token);
                restService.Post<Salons>(s);
            }
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

using Models;
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

        public AddSalonWindow(Salons s)
        {
            InitializeComponent();
            this.postalCode.Text = s.PostalCode;
            this.city.Text = s.City;
            this.address.Text = s.Address;
            salonId = s.SalonId;
        }

        public AddSalonWindow()
        {
            InitializeComponent();
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

                RestService restService = new RestService("https://localhost:5001/", "/salons");
                restService.Put<string, Salons>(salonId, s);

                salonId = null;
            }
            else
            {
                Salons s = new Salons();
                s.PostalCode = postalCode.Text.ToString();
                s.City = city.Text.ToString();
                s.Address = address.Text.ToString();

                RestService restService = new RestService("https://localhost:5001/", "/salons");
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

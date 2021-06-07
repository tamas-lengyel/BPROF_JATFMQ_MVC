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
    /// Interaction logic for AddRenterWindow.xaml
    /// </summary>
    public partial class AddRenterWindow : Window
    {
        string carId;

        Renters renter;

        TokenVM token;

        public AddRenterWindow(Renters r, TokenVM _token)
        {
            InitializeComponent();
            this.name.Text = r.Name;
            this.postalCode.Text = r.PostalCode;
            this.city.Text = r.City;
            this.address.Text = r.Address;
            this.email.Text = r.Email;
            this.phoneNumber.Text = r.PhoneNumber;
            this.rentedDays.Text = r.RentedDays.ToString();

            renter = r;
            token = _token;
        }

        public AddRenterWindow(Cars c, TokenVM _token)
        {
            InitializeComponent();
            this.carId = c.CarId;
            token = _token;
        }

        public AddRenterWindow(TokenVM _token)
        {
            InitializeComponent();
            token = _token;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (renter != null)
            {
                Renters r = new Renters()
                {
                    Name = this.name.Text.ToString(),
                    PostalCode = this.postalCode.Text.ToString(),
                    City = this.city.Text.ToString(),
                    Address = this.address.Text.ToString(),
                    Email = this.email.Text.ToString(),
                    PhoneNumber = this.phoneNumber.Text.ToString(),
                    RentedDays = int.Parse(this.rentedDays.Text),
                    CarId = renter.CarId,
                    RenterId = renter.RenterId,
                };
                RestService restService = new RestService(WebAddress.Address(), "/renter", token.Token);
                restService.Put<string, Renters>(renter.RenterId, r);

                renter = null;
            }
            else
            {
                Renters r = new Renters()
                {
                    Name = this.name.Text.ToString(),
                    PostalCode = this.postalCode.Text.ToString(),
                    City = this.city.Text.ToString(),
                    Address = this.address.Text.ToString(),
                    Email = this.email.Text.ToString(),
                    PhoneNumber = this.phoneNumber.Text.ToString(),
                    RentedDays = int.Parse(this.rentedDays.Text),
                    CarId = carId,
                };

                RestService restService = new RestService(WebAddress.Address(), "/renter", token.Token);
                restService.Post<Renters>(r);
            }

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

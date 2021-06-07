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
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        string salonId;

        Cars car;

        TokenVM token;

        public AddCarWindow(Cars c, TokenVM _token)
        {
            InitializeComponent();
            this.make.Text = c.Make;
            this.model.Text = c.Model;
            this.modelYear.Text = c.ModelYear.ToString();
            this.bodyType.Text = c.BodyType;
            this.combFuelEco.Text = c.CombFuelEco.ToString();
            this.pricePerDay.Text = c.PricePerDay.ToString();
            car = c;
            token = _token;
        }

        public AddCarWindow(Salons s, TokenVM _token)
        {
            InitializeComponent();
            this.salonId = s.SalonId;
            token = _token;
        }

        public AddCarWindow(TokenVM _token)
        {
            InitializeComponent();
            token = _token;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (car != null)
            {
                Cars c = new Cars()
                {
                    Make = this.make.Text.ToString(),
                    Model = this.model.Text.ToString(),
                    ModelYear = int.Parse(this.modelYear.Text),
                    BodyType = this.bodyType.Text.ToString(),
                    CombFuelEco = double.Parse(this.combFuelEco.Text.ToString()),
                    PricePerDay = int.Parse(this.pricePerDay.Text),
                    SalonId = car.SalonId,
                    Available = car.Available,
                    RenterId = car.RenterId,
                    CarId = car.CarId,
                };

                RestService restService = new RestService(WebAddress.Address(), "/cars", token.Token);
                restService.Put<string, Cars>(car.CarId, c);

                car = null;
            }
            else
            {
                Cars c = new Cars()
                {
                    Make = this.make.Text.ToString(),
                    Model = this.model.Text.ToString(),
                    ModelYear = int.Parse(this.modelYear.Text),
                    BodyType = this.bodyType.Text.ToString(),
                    CombFuelEco = double.Parse(this.combFuelEco.Text.ToString()),
                    Available = true,
                    PricePerDay = int.Parse(this.pricePerDay.Text),
                    SalonId = salonId,
                };

                RestService restService = new RestService(WebAddress.Address(), "/cars", token.Token);
                restService.Post<Cars>(c);
            }
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

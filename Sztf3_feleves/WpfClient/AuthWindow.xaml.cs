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
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
            Login();
        }

        public async Task Login()
        {
            UserName = this.username.Text.ToString();
            PassWord = this.password.Password;

            RestService restService = new RestService(WebAddress.Address(), "/auth/Login");
            TokenVM token = await restService.Put<TokenVM, LoginVM>(new LoginVM() { ValidationName = UserName, Password = PassWord });

            if (token != null)
            {
                Window w = new MainWindow(token);
                w.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }
    }
}

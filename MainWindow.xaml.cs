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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string hashedPwd;
        public MainWindow()
        {
            InitializeComponent();
            FileIOLoading.ReadAlltoMem();
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);

            var timer = new System.Threading.Timer((e) =>
            {
                //Method();
            }, null, startTimeSpan, periodTimeSpan);
        }

        private void LoadEngineer_Click(object sender, RoutedEventArgs e)
        {
            LoadEngineerWindow loadEngineerWindow = new LoadEngineerWindow(this);
            loadEngineerWindow.Show();
            this.Hide();
        }
        private void MarketManager_Click(object sender, RoutedEventArgs e)
        {
            MarketingManagerWindow marketingManagerWindow = new MarketingManagerWindow(this);
            marketingManagerWindow.Show();
            this.Hide();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.UserAccountDict.TryGetValue(usrBox.Text, out App.LoggedInUser))
            {
                //check if password match
                using (SHA512 sha512hash = SHA512.Create())
                {
                    byte[] sourcePwdBytes = Encoding.UTF8.GetBytes(pwdBox.Text); //hash can only be done on string of bytes
                    byte[] hashBytes = sha512hash.ComputeHash(sourcePwdBytes);
                    hashedPwd = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                }
                if (hashedPwd == App.LoggedInUser.getPwdHash())
                {
                    Console.WriteLine("User " + App.LoggedInUser.getUniqueID() + " Logged In Successfully");
                    UserLandingWindow landingWindow = new UserLandingWindow(this);
                    landingWindow.Show();
                    this.Hide();
                }
                else
                {
                    Console.WriteLine("User " + App.LoggedInUser.getUniqueID() + " did not log in - PWD hash did not match.");
                }
            }
            else
            {
                Console.WriteLine("User not found with UID " + usrBox.Text);
            }
        }

        private void CreateAcctBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateAcctWindow acctWindow = new CreateAcctWindow(this);
            acctWindow.Show();
            this.Hide();
        }

       
    }
}

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
using System.Threading;

namespace Software_Engineering_Project
{
    //MainWindow
    //Acts as the Login Window for the program, as well as a persistent window to handle required background processes. 
    //Users can login and access the UserLandingPage by entering their UniqueID and their password. If their password doesn't match, a prompt is shown.
    //It is first initialized on starting the program, and should not be closed until the program is to be exited. 
    //Generally, it is hidden whenever moving to a new Window.
    public partial class MainWindow : Window
    {
        public string hashedPwd;
        public MainWindow()
        {
            InitializeComponent();
            FileIOLoading.ReadAlltoMem(); 
            App.Update_Flights();
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);

            System.Threading.Timer timer1 = null;
            timer1 = new System.Threading.Timer(_ => App.Update_Flights());
            timer1.Change(startTimeSpan, periodTimeSpan);
            
        }

        private void LoadEngineer()
        {
            LoadEngineerWindow loadEngineerWindow = new LoadEngineerWindow(this);
            loadEngineerWindow.Show();
            this.Hide();
        }
        private void MarketManager()
        {
            MarketingManagerWindow marketingManagerWindow = new MarketingManagerWindow(this);
            marketingManagerWindow.Show();
            this.Hide();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (usrBox.Text.Length == 1)
            {  
                if(pwdBox.Text == "alpha")
                {
                    int employeeType = Int32.Parse(usrBox.Text);
                    switch (employeeType)
                    {
                        case 0:
                            LoadEngineer();
                            return;
                        case 1:
                            MarketManager();
                            return;
                        case 2:
                            Accountant();
                            return;
                        case 3:
                            FlightManager();
                            return;
                        default:
                            MessageBox.Show("Failed to Log in\nUserID or Password is incorrect", "Error");
                            return;

                    }
                }
                else
                {
                    MessageBox.Show("Failed to Log in\nUserID or Password is incorrect", "Error");
                }
            }
            else if (App.UserAccountDict.TryGetValue(usrBox.Text, out App.LoggedInUser))
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
                    pwdBox.Text = "";
                    landingWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to Log in\nUserID or Password is incorrect", "Error");
                    Console.WriteLine("User " + App.LoggedInUser.getUniqueID() + " did not log in - PWD hash did not match.");
                    pwdBox.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("Failed to Log in\nUser with this ID does not exist. Please double check your ID", "Error");
                Console.WriteLine("User not found with UID " + usrBox.Text);
                pwdBox.Text = "";
                return;
            }
        }

        private void CreateAcctBtn()
        {
            CreateAcctWindow acctWindow = new CreateAcctWindow(this);
            acctWindow.Show();
            this.Hide();
        }

        private void FlightManager()
        {
            FlightManagerWindow flightManager = new FlightManagerWindow(this);
            flightManager.Show();
            this.Hide();
        }

        private void Accountant()
        {
            AccountantWindow accountantWindow = new AccountantWindow(this);
            accountantWindow.Show();
            this.Hide();
        }
    }
}

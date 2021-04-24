using System;
using System.ComponentModel;
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
using System.Security.Cryptography;

namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for CreateAcctWindow.xaml
    /// </summary>
    
    public partial class CreateAcctWindow : Window
    {
        private MainWindow m_parent;
        public CreateAcctWindow(MainWindow main)
        {
            InitializeComponent();
            this.Closed += new EventHandler(CreateAcctWindow_Closed);
            m_parent = main;
        }

        private void CreateAcctBtn_Click(object sender, RoutedEventArgs e)
        {   
            //Do input checks HERE*****
            if(passwordInput.Text == "" || passwordInput.Text != passwordConfirm.Text)
            {
                MessageBox.Show("Please ensure a password is entered, and that both passwords match.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if(FirstName.Text =="" || LastName.Text == "")
            {
                MessageBox.Show("Please enter your name!", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if(AgeInput.Text == "")
            {
                MessageBox.Show("Please enter your Age.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if(address.Text == "" || city.Text == "" || USState.SelectedItem == null)
            {
                MessageBox.Show("Please ensure all fields of your address are filled.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if(phone_number.Text == "")
            {
                MessageBox.Show("Please enter a phone number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if(ccNumber.Text == "")
            {
                MessageBox.Show("Please enter a Credit Card number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //*************************
            

            UserAccountObj newAcct = new UserAccountObj();
            newAcct.setFirstName(FirstName.Text);
            newAcct.setLastName(LastName.Text);
            newAcct.setEmailAddress(emailAddress.Text);
            newAcct.setAge(Int32.Parse(AgeInput.Text));
            newAcct.setAddress(address.Text);
            newAcct.setCity(city.Text);
            newAcct.setPhoneNum(Int64.Parse(phone_number.Text));
            newAcct.setState(USState.SelectedValue.ToString());

            using (SHA512 sha512hash = SHA512.Create())
            {
                byte[] sourcePwdBytes = Encoding.UTF8.GetBytes(passwordInput.Text); //hash can only be done on string of bytes
                byte[] hashBytes = sha512hash.ComputeHash(sourcePwdBytes);
                string hashedPwd = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                newAcct.setPwdHash(hashedPwd);
            }

            newAcct.setCCNumber(Int64.Parse(ccNumber.Text));




            Random generator = new Random();
            string genNum, foundNum;
            bool foundSpace = false;
            foundNum = "000000";
            while (!foundSpace)
            {
                genNum = generator.Next(0, 1000000).ToString("000000");
                try
                {
                    App.UserAccountDict.Add(genNum, newAcct);
                    foundSpace = true;
                    foundNum = genNum;
                    App.UserAccountDict[foundNum].setUniqueID(foundNum);
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("An element with this key (" + genNum + ") already exists.");
                    foundSpace = false;

                }
            }
            Console.WriteLine("User with name " + App.UserAccountDict[foundNum].getFirstName() + " added at location " + App.UserAccountDict[foundNum].getUniqueID());
            MessageBox.Show("Account Created! Your Login ID is: " + foundNum, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            m_parent.Show();
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            m_parent.Show();
            this.Close();

        }
        void CreateAcctWindow_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
        }

       

        //first name of the account being created
        //code will run everytime the value is changed.

    }
}

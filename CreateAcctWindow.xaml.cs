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
    //CreateAcctWindow
    //This window is summoned from MainWindow on clicking the "Create Account" button with the purpose of guiding a user through creating a new User Account
    //If fields are incorrectly filled, upon clicking "Create Account", the user will be prompted to recheck their inputs and returned to the same screen.
    //If required fields are correctly filled, the user will be prompted with their Logon ID, then returned to MainWindow for login.
    
    public partial class CreateAcctWindow : Window
    {
        private MainWindow m_parent; //pass and hold the running MainWindow in the background so it can be recalled with .show()
        public CreateAcctWindow(MainWindow main)
        {
            InitializeComponent();
            this.Closed += new EventHandler(CreateAcctWindow_Closed);
            m_parent = main;
        }

        private void CreateAcctBtn_Click(object sender, RoutedEventArgs e)
        {
            //Input Checks HERE ******
            int parseTry;
            long parseLongTry;
            if(passwordInput.Text.Trim() == "" || passwordInput.Text.Trim() != passwordConfirm.Text.Trim()) 
            {   
                //Passwords do not match or no password is entered
                MessageBox.Show("Please ensure a password is entered, and that both passwords match.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if(FirstName.Text.Trim() == "" || LastName.Text.Trim() == "")
            {   
                //First name or Last Name are empty, those are required
                MessageBox.Show("Please enter your name!", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if(AgeInput.Text.Trim() == "" || !int.TryParse(AgeInput.Text, out parseTry) )
            {   
                //No age is specified
                MessageBox.Show("Please enter your Age.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if(address.Text.Trim() == "" || city.Text.Trim() == "" || USState.SelectedItem == null)
            {   
                //Something is missing in the addressing fields, either address, city, or state
                MessageBox.Show("Please ensure all fields of your address are filled.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if(phone_number.Text.Trim() == "" || phone_number.Text.Trim().Length != 10 || !long.TryParse(phone_number.Text, out parseLongTry))
            {   
                //No phone number
                MessageBox.Show("Please enter a phone number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if(ccNumber.Text.Trim() == "" || ccNumber.Text.Trim().Length != 16 || !long.TryParse(ccNumber.Text, out parseLongTry))
            {   
                //No Credit Card
                MessageBox.Show("Please enter a Credit Card number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //*************************
            

            UserAccountObj newAcct = new UserAccountObj(); //Allocate new UserAccountObj to memory

            //Set fields in UserAccountObj with the data from the Form...
            newAcct.setFirstName(FirstName.Text.Trim());
            newAcct.setLastName(LastName.Text.Trim());
            newAcct.setEmailAddress(emailAddress.Text.Trim());
            newAcct.setAge(Int32.Parse(AgeInput.Text.Trim()));
            newAcct.setAddress(address.Text.Trim());
            newAcct.setCity(city.Text.Trim());
            newAcct.setPhoneNum(Int64.Parse(phone_number.Text.Trim()));
            newAcct.setState(USState.SelectedValue.ToString().Trim());
            newAcct.setCCNumber(Int64.Parse(ccNumber.Text.Trim()));

            //...except for the password, which is hashed using SHA-512 here...
            using (SHA512 sha512hash = SHA512.Create())
            {
                byte[] sourcePwdBytes = Encoding.UTF8.GetBytes(passwordInput.Text.Trim()); //hash can only be done on string of bytes
                byte[] hashBytes = sha512hash.ComputeHash(sourcePwdBytes);
                string hashedPwd = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                newAcct.setPwdHash(hashedPwd);
            }          


            //...and the uniqueID, which is generated randomly here.
            Random generator = new Random();
            string genNum, foundNum;
            bool foundSpace = false;
            foundNum = "000000";
            while (!foundSpace)
            {
                genNum = generator.Next(0, 1000000).ToString("000000");//Generate a random number between 1 and 999999, then mask it to a 6-char string to ensure uniform length
                try
                {   //try to insert with the generated key
                    App.UserAccountDict.Add(genNum, newAcct);
                    foundSpace = true;
                    foundNum = genNum;
                    App.UserAccountDict[foundNum].setUniqueID(foundNum); //set ID after finding a suitable spot
                    break;//no need to keep trying numbers, break out of loop
                }
                catch (ArgumentException)
                {   //generated key already exists, so loop through again and try another key
                    Console.WriteLine("An element with this key (" + genNum + ") already exists.");
                    foundSpace = false;

                }
            }
            Console.WriteLine("User with name " + App.UserAccountDict[foundNum].getFirstName() + " added at location " + App.UserAccountDict[foundNum].getUniqueID());
            MessageBox.Show("Account Created! Your Login ID is: " + foundNum, "Alert", MessageBoxButton.OK, MessageBoxImage.Information); //Prompt user with UID
            //return to Login Screen (MainWindow)
            m_parent.Show();
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {   
            //functionally same as closing window with 'X'
            m_parent.Show();
            this.Close();

        }
        void CreateAcctWindow_Closed(object sender, EventArgs e)
        {   
            //Window closed, show parent MainWindow
            m_parent.Show();
        }

       

        

    }
}

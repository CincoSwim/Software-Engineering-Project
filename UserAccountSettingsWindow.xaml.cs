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
    /// Interaction logic for UserAccountDetailsWindow.xaml
    /// </summary>
    public partial class UserAccountDetailsWindow : Window
    {
        private UserLandingWindow m_parent;
        internal bool USStateChanged;
        public UserAccountDetailsWindow(UserLandingWindow main)
        {
            InitializeComponent();
            this.Closed += new EventHandler(UserSettings_Closed);
            m_parent = main;
            CanceledFlightsGrid.ItemsSource = LoadCanceledFlights();
            PreviousFlightsGrid.ItemsSource = LoadTakenFlights();

            PointsBalanceLabel.Content = App.LoggedInUser.balance.ToString();
            uidLabel.Content = App.LoggedInUser.uniqueID;

            firstNameTextBox.Text = App.LoggedInUser.firstName.Trim();
            lastNameTextBox.Text = App.LoggedInUser.lastName.Trim();
            emailTextBox.Text = App.LoggedInUser.emailAddress.Trim();
            ageTextBox.Text = App.LoggedInUser.age.ToString().Trim(); ;
            addressTextBox.Text = App.LoggedInUser.address.Trim();
            cityTextBox.Text = App.LoggedInUser.city.Trim();
            phoneTextBox.Text = App.LoggedInUser.phoneNumber.ToString().Trim();
            USStateBox.Text = App.LoggedInUser.state.Trim();
            CCTextBox.Text = App.LoggedInUser.creditCardNumber.ToString().Trim();
        }

        private List<FlightManifestObj> LoadCanceledFlights()
        {
            List<FlightManifestObj> cancelList = new List<FlightManifestObj>();
            foreach (string str in App.LoggedInUser.canceledFlights)
            {
                cancelList.Add(App.FlightPlanDict[str]);
            }
            return cancelList;
        }
        private List<FlightManifestObj> LoadTakenFlights()
        {
            List<FlightManifestObj> takenList = new List<FlightManifestObj>();
            foreach (string str in App.LoggedInUser.takenFlights)
            {
                takenList.Add(App.FlightHistoryDictionary[str]);
            }
            return takenList;
        }

        void UserSettings_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            m_parent.Show();
            this.Close();
        }

        private void EditFieldsBtn_Click(object sender, RoutedEventArgs e)
        {   //fix to reference user object in Dictionary

            //Do input checks HERE*****
            if (firstNameTextBox.Text.Trim() == "" || lastNameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your name!", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (ageTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your age.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (addressTextBox.Text.Trim() == "" || cityTextBox.Text.Trim() == "" || USStateBox.SelectedItem == null)
            {
                MessageBox.Show("Please ensure all fields of your address are filled.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (phoneTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a phone number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (CCTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a credit card number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            App.LoggedInUser.setFirstName(firstNameTextBox.Text.Trim());
            App.LoggedInUser.setLastName(lastNameTextBox.Text.Trim());
            App.LoggedInUser.setEmailAddress(emailTextBox.Text.Trim());
            App.LoggedInUser.setAge(Int32.Parse(ageTextBox.Text.Trim()));
            App.LoggedInUser.setAddress(addressTextBox.Text.Trim());
            App.LoggedInUser.setCity(cityTextBox.Text.Trim());
            App.LoggedInUser.setPhoneNum(Int64.Parse(phoneTextBox.Text.Trim()));
            App.LoggedInUser.setState(USStateBox.SelectedValue.ToString().Trim());
            App.LoggedInUser.setCCNumber(Int64.Parse(CCTextBox.Text.Trim()));

            App.UserAccountDict.Remove(App.LoggedInUser.getUniqueID());
            App.UserAccountDict.Add(App.LoggedInUser.getUniqueID(), App.LoggedInUser);

            MessageBox.Show("Account Updated", "Success", MessageBoxButton.OK);
            m_parent.WelcomeMessageLabel.Content = $"Welcome, {App.LoggedInUser.firstName} {App.LoggedInUser.lastName}!";
            m_parent.Show();
            this.Close();


            //MessageBox.Show("Fields Changed!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void PreviousFlightsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

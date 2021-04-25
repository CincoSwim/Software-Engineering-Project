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
    //UserAccountDetailsWindow
    //Shows the user's taken and canceled flights, as well as gives fields for the user to correct any changeable information about themselves. 
    //Changing any fields in the user information, then clicking the Edit Fields button will make the requested changes to their UserAcctObj and return them to the landing page.
    public partial class UserAccountDetailsWindow : Window
    {
        private UserLandingWindow m_parent;
        internal bool USStateChanged;
        public UserAccountDetailsWindow(UserLandingWindow main)
        {
            InitializeComponent();
            this.Closed += new EventHandler(UserSettings_Closed);
            m_parent = main;
            CanceledFlightsGrid.ItemsSource = LoadCanceledFlights(); //Loads user's cancelled flights into grid.
            PreviousFlightsGrid.ItemsSource = LoadTakenFlights();   //Load's user's taken flights into grid.

            //Fields the user cannot change are loaded into Labels
            PointsBalanceLabel.Content = App.LoggedInUser.balance.ToString();
            uidLabel.Content = App.LoggedInUser.uniqueID;

            //Fields the user can change are loaded into TextBoxes
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
        {   //Loads the details for each flight the user has cancelled by adding the FlightManifestObject corresponding to that flightID to the list. This is loaded into the grid.
            List<FlightManifestObj> cancelList = new List<FlightManifestObj>();
            foreach (string str in App.LoggedInUser.canceledFlights)
            {
                cancelList.Add(App.FlightPlanDict[str]);
            }
            return cancelList;
        }
        private List<FlightManifestObj> LoadTakenFlights()
        {   //Loads the details for each flight the user has taken by adding the FlightManifestObject corresponding to that flightID to the list. This is loaded into the grid.
            List<FlightManifestObj> takenList = new List<FlightManifestObj>();
            foreach (string str in App.LoggedInUser.takenFlights)
            {
                takenList.Add(App.FlightHistoryDictionary[str]);
            }
            return takenList;
        }

        void UserSettings_Closed(object sender, EventArgs e)
        {   //Shows parent after closing window
            m_parent.Show();
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {   //shows parent and closes window after clicking Back button
            m_parent.Show();
            this.Close();
        }

        private void EditFieldsBtn_Click(object sender, RoutedEventArgs e)
        {   //Checks to see what fields are changed in the Editable fields, and makes changes if changes are found.
            //If fields are found to be empty, the user is prompted to enter "something" into the fields, and no changes are made

            //Input Checks done HERE *******
            if (firstNameTextBox.Text.Trim() == "" || lastNameTextBox.Text.Trim() == "")//First or last name are empty, pop prompt
            {
                MessageBox.Show("Please enter your name!", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (ageTextBox.Text.Trim() == "") //Age empty, pop prompt
            {
                MessageBox.Show("Please enter your age.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (addressTextBox.Text.Trim() == "" || cityTextBox.Text.Trim() == "" || USStateBox.SelectedItem == null)//something in address empty, pop prompt
            {
                MessageBox.Show("Please ensure all fields of your address are filled.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (phoneTextBox.Text.Trim() == "")//phone empty, pop prompt
            {
                MessageBox.Show("Please enter a phone number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (CCTextBox.Text.Trim() == "")//Credit Card empty, pop prompt
            {
                MessageBox.Show("Please enter a credit card number.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //Sets all the changed fields to those in the Logged in User object to reflect any changes.
            App.LoggedInUser.setFirstName(firstNameTextBox.Text.Trim());
            App.LoggedInUser.setLastName(lastNameTextBox.Text.Trim());
            App.LoggedInUser.setEmailAddress(emailTextBox.Text.Trim());
            App.LoggedInUser.setAge(Int32.Parse(ageTextBox.Text.Trim()));
            App.LoggedInUser.setAddress(addressTextBox.Text.Trim());
            App.LoggedInUser.setCity(cityTextBox.Text.Trim());
            App.LoggedInUser.setPhoneNum(Int64.Parse(phoneTextBox.Text.Trim()));
            App.LoggedInUser.setState(USStateBox.SelectedValue.ToString().Trim());
            App.LoggedInUser.setCCNumber(Int64.Parse(CCTextBox.Text.Trim()));

            //Removes the old object residing at the current user's key and re-adds the updated user object at that location.
            App.UserAccountDict.Remove(App.LoggedInUser.getUniqueID());
            App.UserAccountDict.Add(App.LoggedInUser.getUniqueID(), App.LoggedInUser);

            MessageBox.Show("Account Updated", "Success", MessageBoxButton.OK);
            m_parent.WelcomeMessageLabel.Content = $"Welcome, {App.LoggedInUser.firstName} {App.LoggedInUser.lastName}!"; //Changes welcome label to be accurate to new name.
            m_parent.Show();
            this.Close(); //Return to Landing Page


           
        }

        private void PreviousFlightsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

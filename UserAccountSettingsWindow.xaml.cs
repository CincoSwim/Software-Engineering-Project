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

            firstNameTextBox.Text = App.LoggedInUser.firstName;
            lastNameTextBox.Text = App.LoggedInUser.lastName;
            emailTextBox.Text = App.LoggedInUser.emailAddress;
            ageTextBox.Text = App.LoggedInUser.age.ToString();
            phoneTextBox.Text = App.LoggedInUser.phoneNumber.ToString();
            addressTextBox.Text = App.LoggedInUser.address;
            cityTextBox.Text = App.LoggedInUser.city;
            USStateBox.SelectedItem = App.LoggedInUser.state;
            CCTextBox.Text = App.LoggedInUser.creditCardNumber.ToString();
                        
            //Contents of UserAcctObj laid bare

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
            App.LoggedInUser = null;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            m_parent.Show();
            this.Close();
        }

        private void EditFieldsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (firstNameTextBox.Text != "") App.LoggedInUser.firstName = firstNameTextBox.Text;
            if (lastNameTextBox.Text != "") App.LoggedInUser.lastName = lastNameTextBox.Text;
            if (emailTextBox.Text != "") App.LoggedInUser.emailAddress = emailTextBox.Text;
            if (phoneTextBox.Text != "") App.LoggedInUser.phoneNumber = Int64.Parse(firstNameTextBox.Text);
            if (addressTextBox.Text != "") App.LoggedInUser.address = addressTextBox.Text;
            if (cityTextBox.Text != "") App.LoggedInUser.city = cityTextBox.Text;
            if (USStateBox.SelectedItem != null) App.LoggedInUser.state = USStateBox.Text;
            if (CCTextBox.Text != "") App.LoggedInUser.creditCardNumber = Int64.Parse(CCTextBox.Text);

            MessageBox.Show("Fields Changed!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}

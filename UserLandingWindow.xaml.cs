using System;
using System.Collections;
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
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for UserLandingWindow.xaml
    /// </summary>
    public partial class UserLandingWindow : Window
    {
        private MainWindow m_parent;
        public string userWelcomeStr { get; set; } = $"Welcome, {App.LoggedInUser.firstName} {App.LoggedInUser.lastName}!";
        public UserLandingWindow(MainWindow main)
        {
            InitializeComponent();
            this.Closed += new EventHandler(UserLanding_Closed);
            m_parent = main;
            //UpcomingFlightsGrid.ItemsSource = LoadUpcomingFlights();
            UpcomingFlightsGrid.ItemsSource = LoadUpcomingFlights();
            WelcomeMessageLabel.Content = userWelcomeStr;
            

        }

        private List<FlightManifestObj> LoadUpcomingFlights()
        {   List<FlightManifestObj> gridList = new List<FlightManifestObj>();
            foreach(string str in App.LoggedInUser.upcomingFlights)
            {
                gridList.Add(App.FlightPlanDict[str]);
            }
            return gridList;
        }

        private List<UserAccountObj> LoadUsersTest()
        {
            List<UserAccountObj> gridList = new List<UserAccountObj>();
            gridList.AddRange(App.UserAccountDict.Values);
            return gridList;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BookFlightBtn_Click(object sender, RoutedEventArgs e)
        {
            UserFlightSearchWindow flightsearch = new UserFlightSearchWindow(this);
            flightsearch.Show();
            this.Hide();
        }

        private void UpcomingFlightsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            m_parent.Show();
            App.LoggedInUser = null;
            this.Close();
        }
        void UserLanding_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
            App.LoggedInUser = null;
        }

        private void AccountSettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            UserAccountDetailsWindow userAccountDetailsWindow = new UserAccountDetailsWindow(this);
            userAccountDetailsWindow.Show();
            this.Hide();
        }

        private void CancelFlightBtn_Click(object sender, RoutedEventArgs e)
        {
            if(UpcomingFlightsGrid.SelectedItem == null)
            {
                MessageBox.Show("You must select a flight to cancel.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            FlightManifestObj selected = (FlightManifestObj)UpcomingFlightsGrid.SelectedItem;
            if(DateTime.Now.AddHours(1) >= selected.departTime)
            {
                MessageBox.Show("You cannot cancel a flight within 1 hour of departure!", "Warning", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
            App.LoggedInUser.canceledFlights.Add(selected.flightID);
            App.LoggedInUser.upcomingFlights.Remove(selected.flightID);
            App.LoggedInUser.balance += selected.pointReward * 10;
            App.FlightPlanDict[selected.flightID].bookedUsers.Remove(App.LoggedInUser);
            MessageBox.Show("Flight Canceled!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void PrintBoardingPassBtn_Click(object sender, RoutedEventArgs e)
        {
            if(UpcomingFlightsGrid.SelectedItem == null)
            {
                MessageBox.Show("Please Select a Flight", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            FlightManifestObj selected = (FlightManifestObj)UpcomingFlightsGrid.SelectedItem;
            if(DateTime.Now.AddHours(24) < selected.departTime)
            {
                MessageBox.Show("You are unable to print a boarding pass at this time.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                File.WriteAllText(FileIOLoading.BoardingPassPath, JsonConvert.SerializeObject(selected, Formatting.Indented));
                MessageBox.Show("Boarding Pass Printed To: C:\temp\\Printouts\\BoardingPass.txt", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            
        }
    }
}

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
            UpcomingFlightsGrid.ItemsSource = LoadUsersTest();
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
    }
}

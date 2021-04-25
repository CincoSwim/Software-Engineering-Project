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
    //UserLandingWindow
    //Primary window that the user interacts with for daily use.
    //From this window, the user can see their upcoming flights they have booked, can cancel flights, can print a boarding pass for a flight, and can open the Flight Search or 
    //Account Settings windows. 
    public partial class UserLandingWindow : Window
    {
        private MainWindow m_parent;
        public string userWelcomeStr { get; set; } = $"Welcome, {App.LoggedInUser.firstName} {App.LoggedInUser.lastName}!"; //Sets a welcome message containing the User's full name
        public UserLandingWindow(MainWindow main)
        {
            InitializeComponent();
            this.Closed += new EventHandler(UserLanding_Closed);
            m_parent = main;
            
            UpcomingFlightsGrid.ItemsSource = LoadUpcomingFlights(); //Load the user's flights into the DataGrid
            WelcomeMessageLabel.Content = userWelcomeStr; //Sets binding for label to the welcome message
            

        }

        public List<FlightManifestObj> LoadUpcomingFlights()
        {   List<FlightManifestObj> gridList = new List<FlightManifestObj>();
            //adds each flight the user is booked for into the list, and returns that list.
            foreach(string str in App.LoggedInUser.upcomingFlights)
            {
                gridList.Add(App.FlightPlanDict[str]); //add flight in App.FlightPlanDict corresponding to the flightID
            }
            return gridList;
        }

        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BookFlightBtn_Click(object sender, RoutedEventArgs e)
        {   //Book a flight button clicked, load UserFlightSearchWindow
            UserFlightSearchWindow flightsearch = new UserFlightSearchWindow(this);
            flightsearch.Show();
            this.Hide();
        }

        private void UpcomingFlightsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {   //Logout button clicked, close window
            m_parent.Show();
            App.LoggedInUser = null; //remove logged in user from memory to prevent bad access
            this.Close();
        }
        void UserLanding_Closed(object sender, EventArgs e)
        {   //window closed, return to parent window
            m_parent.Show();
            App.LoggedInUser = null;//remove logged in user from memory to prevent bad access
            
        }

        private void AccountSettingsBtn_Click(object sender, RoutedEventArgs e)
        {   //Account settings button clicked, go to UserAccountSettingsWindow
            UserAccountDetailsWindow userAccountDetailsWindow = new UserAccountDetailsWindow(this);
            userAccountDetailsWindow.Show();
            this.Hide();
        }

        private void CancelFlightBtn_Click(object sender, RoutedEventArgs e)
        {   //User selected Cancel Flight button, so prompt to confirm
            if(UpcomingFlightsGrid.SelectedItem == null)
            {   //No flight selected to cancel, so ask the user to select a flight before returning.
                MessageBox.Show("You must select a flight to cancel.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            FlightManifestObj selected = (FlightManifestObj)UpcomingFlightsGrid.SelectedItem; //Cast selected item to a FlightManifestObj
            if(DateTime.Now.AddHours(1) >= selected.departTime)
            {   //Flight is within 1 hour of departure and cannot be cancelled. 
                MessageBox.Show("You cannot cancel a flight within 1 hour of departure!", "Warning", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
            //otherwise, add the flight to canceled list and remove from upcoming.
            App.LoggedInUser.canceledFlights.Add(selected.flightID);
            App.LoggedInUser.upcomingFlights.Remove(selected.flightID);
            App.LoggedInUser.balance += selected.pointReward * 10; //Credit the user for money or points spent on ticket
            App.FlightPlanDict[selected.flightID].bookedUsers.Remove(App.LoggedInUser); //remove the user from the Flight Manifest
            MessageBox.Show("Flight Canceled!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information); //Let user know flight was cancelled.
            UpcomingFlightsGrid.SelectedItem = null;
            UpcomingFlightsGrid.ItemsSource = LoadUpcomingFlights();
        }

        private void PrintBoardingPassBtn_Click(object sender, RoutedEventArgs e)
        {   //Called if user wants to print the Boarding pass of the selected flight.
            if(UpcomingFlightsGrid.SelectedItem == null)
            {   //No flight selected, so can't print a pass for the null flight.
                MessageBox.Show("Please Select a Flight", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            FlightManifestObj selected = (FlightManifestObj)UpcomingFlightsGrid.SelectedItem; //Cast selected item to a FlightManifestObj
            if(DateTime.Now.AddHours(24) < selected.departTime)
            {   //Can't print a boarding pass prior to 24 hrs before boarding, so deny
                MessageBox.Show("You are unable to print a boarding pass at this time.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {   //Write the boarding pass to the proper location, and prompt the user with the location of the printed pass.
                FileInfo path = new FileInfo(FileIOLoading.printoutDir); //make path if doesn't exist
                path.Directory.Create();
                File.WriteAllText(FileIOLoading.BoardingPassPath, JsonConvert.SerializeObject(selected, Formatting.Indented)); //write to path
                MessageBox.Show("Boarding Pass Printed To: C:\\temp\\Printouts\\BoardingPass.txt", "Success!", MessageBoxButton.OK, MessageBoxImage.Information); //let user know
                return;
            }
            
        }
    }
}

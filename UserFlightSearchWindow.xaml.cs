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
    /// Interaction logic for UserFlightSearchWindow.xaml
    /// </summary>
    public partial class UserFlightSearchWindow : Window
    {
        private UserLandingWindow m_parent;
        public UserFlightSearchWindow(UserLandingWindow landingWindow)
        {
            InitializeComponent();
            m_parent = landingWindow;
            this.Closed += new EventHandler(FlightSearch_Closed);
            FoundFlightsGrid.ItemsSource=LoadAllFlights();

        }

        private List<FlightManifestObj> LoadAllFlights()
        {
            List<FlightManifestObj> gridList = new List<FlightManifestObj>();
            gridList.AddRange(App.FlightPlanDict.Values);
            foreach(var flight in gridList.ToList())
            {
                if (App.LoggedInUser.upcomingFlights.Contains(flight.flightID) || flight.bookedUsers.Count >= flight.planeAssigned.numOfSeats) ;
                {
                    gridList.Remove(flight);
                }
            }
            return gridList;
        }
        void FlightSearch_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
        }

        private void BookFlightButton_Click(object sender, RoutedEventArgs e)
        {
            if(FoundFlightsGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select an item.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
            else
            {   FlightManifestObj selected = (FlightManifestObj)FoundFlightsGrid.SelectedItem;
                if(selected.bookedUsers.Count >= selected.planeAssigned.numOfSeats)
                {
                    MessageBox.Show("There are no seats remaining for this flight", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (App.LoggedInUser.upcomingFlights.Contains(selected.flightID))
                {
                    return; //already booked
                }
                //Confirm, then book the flight
                if (MessageBox.Show("Are you sure you want to book the following flight? \n Flight ID: " + selected.flightID +
                     "\n Departs From: " + selected.originCode + "\n Departure Time: " + selected.departTime.ToLongDateString(),
                     "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    //do no stuff
                    Console.WriteLine("Selected \"no\", no flight booked");
                }
                else
                {
                    //do yes stuff
                   //this line might be causing the dual addition //App.LoggedInUser.upcomingFlights.Add(selected.flightID.ToString());
                    App.UserAccountDict[App.LoggedInUser.uniqueID].upcomingFlights.Add(selected.flightID.ToString());
                    App.FlightPlanDict[selected.flightID].bookedUsers.Add(App.UserAccountDict[App.LoggedInUser.uniqueID]);
                    if(App.LoggedInUser.balance > selected.ticketPrice)
                    {
                        if((MessageBox.Show("Would you like to use your Points? \n Flight Price: " + selected.ticketPrice +
                                            "\n Account Balance: " + App.LoggedInUser.balance,"Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No))
                        {
                            //doesn't use points
                            TransactionObj newTransact = new TransactionObj();
                            newTransact.FlightUID = selected.flightID.ToString();
                            newTransact.UserUID = App.LoggedInUser.uniqueID;

                            newTransact.transactionAmt = selected.ticketPrice;

                            App.TransactionHist.Add(newTransact);

                        }
                        else
                        {
                            //does use points
                            TransactionObj newTransact = new TransactionObj();
                            newTransact.FlightUID = selected.flightID.ToString();
                            newTransact.UserUID = App.LoggedInUser.uniqueID;
                            newTransact.transactionAmt = 0;
                            App.TransactionHist.Add(newTransact);

                            //App.LoggedInUser.balance = App.LoggedInUser.balance - selected.ticketPrice;
                            App.UserAccountDict[App.LoggedInUser.uniqueID].balance = App.UserAccountDict[App.LoggedInUser.uniqueID].balance - selected.ticketPrice;

                        }
                    }
                    else
                    {
                        //doesn't use points -- because there isn't enough!
                        TransactionObj newTransact = new TransactionObj();
                        newTransact.FlightUID = selected.flightID.ToString();
                        newTransact.UserUID = App.LoggedInUser.uniqueID;

                        newTransact.transactionAmt = selected.ticketPrice;

                        App.TransactionHist.Add(newTransact);
                    }
                }
            }
        }

        private void SearchRefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            List<FlightManifestObj> searchList = new List<FlightManifestObj>();
            if(DepartureSelectionBox.SelectedItem == null || ArrivalSelectionBox.SelectedItem == null)
            {
                MessageBox.Show("Please input search criteria!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            foreach (var flight in App.FlightPlanDict)
            {
                if(flight.Value.originCode == DepartureSelectionBox.SelectedValue.ToString() && flight.Value.bookedUsers.Count < flight.Value.planeAssigned.numOfSeats)
                {
                    if(ArrivalSelectionBox.SelectedValue.ToString() == flight.Value.layoverCodeA || ArrivalSelectionBox.SelectedValue.ToString() == flight.Value.layoverCodeB || ArrivalSelectionBox.SelectedValue.ToString() == flight.Value.destinationCode)
                    {
                        if(ArriveTimePick.Value == null || DepartTimePick.Value == null)
                        {
                            searchList.Add(flight.Value);
                        }else if(DepartTimePick.Value > flight.Value.departTime){
                            searchList.Add(flight.Value);
                        }
                    }
                }
            }
            FoundFlightsGrid.ItemsSource = searchList;
        }
    }
}

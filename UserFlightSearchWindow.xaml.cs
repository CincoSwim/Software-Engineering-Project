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
    //UserFlightSearchWindow
    //Primary Window for users to book and search for new flights. Users can search for flights by their departure times, arrival times, destinations, and origins.
    //Flights that result from the search can be sorted in their list by clicking the field they wish to sort by in the DataGrid
    //Attempting to search while missing information will prompt the user to fill in missing information, and return them to the search screen.
    public partial class UserFlightSearchWindow : Window
    {
        private UserLandingWindow m_parent;
        public UserFlightSearchWindow(UserLandingWindow landingWindow)
        {
            InitializeComponent();
            m_parent = landingWindow;
            this.Closed += new EventHandler(FlightSearch_Closed);
            FoundFlightsGrid.ItemsSource=LoadAllFlights(); //Loads all flights available to book, minus any the user has already booked.

        }

        private List<FlightManifestObj> LoadAllFlights()
        {
            List<FlightManifestObj> gridList = new List<FlightManifestObj>();
            gridList.AddRange(App.FlightPlanDict.Values); //Add all upcoming flights
            foreach(var flight in gridList.ToList())
            {
                if (App.LoggedInUser.upcomingFlights.Contains(flight.flightID) || flight.bookedUsers.Count >= flight.planeAssigned.numOfSeats) 
                {   //If the user is already booked for the flight, or the flight is already fully booked, the flight is removed from the view
                    gridList.Remove(flight);
                }
            }
            return gridList;
        }
        void FlightSearch_Closed(object sender, EventArgs e)
        {   //window closed, return to prior window
            m_parent.Show();
        }

        private void BookFlightButton_Click(object sender, RoutedEventArgs e)
        {   //Finalizes booking a user on a flight they've selected from the DataGrid

            if(FoundFlightsGrid.SelectedItem == null) //They haven't selected a flight, so ask them to do so.
            {
                MessageBox.Show("Please select an item.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }           
            else
            {   
                FlightManifestObj selected = (FlightManifestObj)FoundFlightsGrid.SelectedItem; //load selected object into memory as a FlightManifestObj for access
                if(selected.bookedUsers.Count >= selected.planeAssigned.numOfSeats)//Double check to make sure there isn't any overbooking
                {
                    MessageBox.Show("There are no seats remaining for this flight", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (App.LoggedInUser.upcomingFlights.Contains(selected.flightID))//Double check to make sure the user hasn't already booked this flight.
                {
                    MessageBox.Show("You've already booked this flight!", "Warning", MessageBoxButton.OK);
                    return; //already booked
                }
                //Confirm with the user, then book the flight
                if (MessageBox.Show("Are you sure you want to book the following flight? \n Flight ID: " + selected.flightID +  
                     "\n Departs From: " + selected.originCode + "\n Departure Time: " + selected.departTime.ToLongDateString(),
                     "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    //User selected no, so don't book flight
                    Console.WriteLine("Selected \"no\", no flight booked");
                    return;
                }
                else
                {
                    //User selected yes, so book the flight
                    App.UserAccountDict[App.LoggedInUser.uniqueID].upcomingFlights.Add(selected.flightID.ToString()); //Add the flightID to the logged in user
                    App.FlightPlanDict[selected.flightID].bookedUsers.Add(App.UserAccountDict[App.LoggedInUser.uniqueID]); //Add the user to the selected flight
                    if(App.LoggedInUser.balance > selected.ticketPrice)
                    {   //User has enough points that they can pay via points, so ask if they want to pay this way.
                        if((MessageBox.Show("Would you like to use your Points? \n Flight Price: " + selected.ticketPrice +
                                            "\n Account Balance: " + App.LoggedInUser.balance,"Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No))
                        {
                            //Selected no, so don't use points

                            //Make and add transaction object to show purchase history
                            TransactionObj newTransact = new TransactionObj();
                            newTransact.FlightUID = selected;
                            newTransact.UserUID = App.LoggedInUser.uniqueID;

                            newTransact.transactionAmt = selected.ticketPrice;

                            App.TransactionHist.Add(newTransact);
                            
                        }
                        else
                        {
                            //Selected yes, so does use points

                            //Make transaction object, use 0 as amount to show they used points
                            TransactionObj newTransact = new TransactionObj();
                            newTransact.FlightUID = selected;
                            newTransact.UserUID = App.LoggedInUser.uniqueID;
                            newTransact.transactionAmt = 0;
                            App.TransactionHist.Add(newTransact);

                            //Subtract ticket amount from points balance
                            App.UserAccountDict[App.LoggedInUser.uniqueID].balance = App.UserAccountDict[App.LoggedInUser.uniqueID].balance - selected.ticketPrice;

                        }
                    }
                    else
                    {
                        //Books flight without using points -- because the user doesn't have enough!
                        TransactionObj newTransact = new TransactionObj();
                        newTransact.FlightUID = selected;
                        newTransact.UserUID = App.LoggedInUser.uniqueID;

                        newTransact.transactionAmt = selected.ticketPrice;

                        App.TransactionHist.Add(newTransact);
                    }
                    m_parent.UpcomingFlightsGrid.ItemsSource = m_parent.LoadUpcomingFlights();
                    FoundFlightsGrid.ItemsSource = LoadAllFlights();
                    //Put logic here for round trip -------- for each to find a flight with criteria
                }
            }
        }

        private void SearchRefreshBtn_Click(object sender, RoutedEventArgs e)
        {   //User clicked the search button, so augment the shown fields to have only flights that match criteria
            List<FlightManifestObj> searchList = new List<FlightManifestObj>();
            if(DepartureSelectionBox.SelectedItem == null || ArrivalSelectionBox.SelectedItem == null)
            {   //If they don't have a start and end location, throw a popup
                MessageBox.Show("Please input search criteria!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            foreach (var flight in App.FlightPlanDict)
            {
                if(flight.Value.originCode == DepartureSelectionBox.SelectedValue.ToString() && flight.Value.bookedUsers.Count < flight.Value.planeAssigned.numOfSeats)
                {   //Flight originates from where they want and has available seats
                    if(ArrivalSelectionBox.SelectedValue.ToString() == flight.Value.layoverCodeA || ArrivalSelectionBox.SelectedValue.ToString() == flight.Value.layoverCodeB || ArrivalSelectionBox.SelectedValue.ToString() == flight.Value.destinationCode)
                    {   //Flight lands in the arrival city they wanted, either as a layover or the final destination
                        if(ArriveTimePick.Value == null || DepartTimePick.Value == null)
                        {   //user doesn't care about time, so add any old flight
                            searchList.Add(flight.Value);
                        }else if(DepartTimePick.Value > flight.Value.departTime || ArriveTimePick.Value < flight.Value.arrivalTime){
                            //User specified a time and date, so only add flights that fit in that space
                            searchList.Add(flight.Value);
                        }
                    }
                }
            }
            FoundFlightsGrid.ItemsSource = searchList; //change DataGrid to point towards the new list of items that were found.
        }
    }
}

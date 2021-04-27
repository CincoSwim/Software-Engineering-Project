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
using System.IO;
using System.Collections.ObjectModel;


namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for LoadEngineerWindow.xaml
    /// </summary>
    public partial class LoadEngineerWindow : Window
    {
        private MainWindow m_parent;
        
        //Launches our Load Engineer Window
        //Will add items to the dataGrid
        public LoadEngineerWindow(MainWindow main)
        {
            InitializeComponent();
            m_parent = main;
            this.DataContext = this;
            this.Closed += new EventHandler(LoadEng_Closed);
            populateDataGrid();
        }

        //Allows usage of X close button while saving and showing main window
        void LoadEng_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
            App.LoggedInUser = null;
        }

        //Creates a reactive arrival comboBox based on our results of the departure comboBox
        //Could have been done with switch statements but this works too. 
        private void DepartureComboBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            ArrivalCitiesComboBox.Items.Clear();
            ComboBoxItem comboBoxItem = (ComboBoxItem)DepartureCitiesComboBox.SelectedItem;
            string s = comboBoxItem.Content.ToString();
            
            if(s == "Toledo, OH") 
            { 
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                
            }else if (s == "Arlington, VA")
            {
               ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");

            }else if (s == "Atlanta, GA")
            {
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");

            }else if (s == "Austin, TX")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");

            }else if (s == "Chicago, IL")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");                

            }else if (s == "Cleveland, OH")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH"); 

            }else if (s == "Denver, CO")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");  

            }else if (s == "Los Angeles, CA")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");

            }else if (s == "Minneapolis, MN")
            {
               ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");

            }
            else if (s == "Nashville, TN")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA");
            }
            else if (s == "New York City, NY")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");  

            }else if (s == "Orlando, FL")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");

            }else if (s == "Rapid City, SD")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");

            }else if (s == "Sacramento, CA")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA"); 
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");

            }else if (s == "Seattle, WA")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");
            }
        }

        //Check and See if Departure Date is before Arrival Date.
        //Check Locations and Make sure Locations are not the same. 
        //Populate List for Flight Manager Approval
        //If anything is not correct, highlight the wrong thing and display the correct error text. 
        private void FlightProposeBtn_isClicked(object sender, RoutedEventArgs e)
        { 
            FlightManifestObj proposedFlightManifestObj = new FlightManifestObj();
            DateTime parsedDepartDate, parsedArrivalDate;
            string departureDateTime;
            string departureLocation, arrivalLocation;

            //Set Locations
            ComboBoxItem comboBoxItem = (ComboBoxItem)DepartureCitiesComboBox.SelectedItem;
            if(comboBoxItem == null)
            {
                //If we have not selected a departed value, highlight the departed box red
                DepartureCitiesBorderCB.BorderBrush = Brushes.Red;
                departureLocation = null;
                return;
            }
            else 
            { 
                departureLocation = comboBoxItem.Content.ToString();
            }
            if(ArrivalCitiesComboBox.SelectedItem == null)
            { 
                //If we have not selected an arrival value, set the arrival box to red.
                ArrivalCitiesBorderCB.BorderBrush = Brushes.Red;
                arrivalLocation = null;
                return;
            }
            else
            {
                arrivalLocation = ArrivalCitiesComboBox.SelectedItem.ToString();
            }

            //Getting departure date time
            departureDateTime = DepartureDateTimePicker.Text;

            if (departureDateTime == null)
            {
                //If we have not selected a departure time, highlight the departure timeBox red.
                DepartureDateTimePicker.BorderBrush = Brushes.Red;
                parsedDepartDate = DateTime.Today;
                return;
            }
            else 
            { 
                parsedDepartDate = DateTime.Parse(departureDateTime);
            }

            //filling in our proposed flight fields and then using our graph to set Layovers
            proposedFlightManifestObj.originCode = departureLocation;
            proposedFlightManifestObj.destinationCode = arrivalLocation;

            int begin = convertLocationsToInt(proposedFlightManifestObj.originCode);
            int end = convertLocationsToInt(proposedFlightManifestObj.destinationCode);
            FlightManifestObj planWithLayovers = App.findShortestPath(proposedFlightManifestObj, begin, end);


            //Setting ArrivalTime based on Departure Time
            parsedArrivalDate = setArrivalTimeBasedOnDepartureTime(parsedDepartDate, departureLocation, arrivalLocation, planWithLayovers.layoverCodeA, planWithLayovers.layoverCodeB);

            //Set Arrival Date to 1/1/ThisYear if the previous method failed somehow
            if (parsedArrivalDate == null)
            {
                
                parsedArrivalDate = DateTime.MinValue;
            }

            //If we have a real arrival date, then generate a random 6 digit flight ID.
            if (!parsedArrivalDate.Equals(DateTime.MinValue)) {  
                Random generator = new Random();
                string genNum;
                genNum = generator.Next(0, 1000000).ToString("000000");
                for(int i = 0; i < App.MarketMangerQueue.Count; i++)
                {
                    if (genNum.Equals(App.MarketMangerQueue.ElementAt(i).flightID))
                    {
                      genNum = generator.Next(0, 1000000).ToString("000000");
                       i = 0;
                    }
                }
                // Set more fields for the proposed flight
                proposedFlightManifestObj.flightID = genNum;
                proposedFlightManifestObj.departTime = parsedDepartDate;
                proposedFlightManifestObj.arrivalTime = parsedArrivalDate;
                // Apply red eye and off peak discounts if needed
                planWithLayovers = App.applyDiscounts(planWithLayovers);
                // Add our flight to the list of proposed flights
                App.MarketMangerQueue.Add(planWithLayovers);
                // Refresh the datagrid which should have our new flight visible now. 
                populateDataGrid();
                Console.WriteLine(App.MarketMangerQueue.Count);
            }
            else
            {
                //If we fail to set a correct arrival time, then send the message box. 
                //We should never reach this point, but if somehow the user manages to get here, this is the failsafe. 
                MessageBox.Show("arrivalTime Did not set correctly.");
            }
        }
        // Set Arrival Date and Time based on our Departure Date and Time and Locations / Layovers
        private DateTime setArrivalTimeBasedOnDepartureTime(DateTime departureTime, string departureLocation, string arrivalLocation, string layoverA, string layoverB)
        {
            DateTime arrivalTime = DateTime.MinValue;
            DateTime makeTimeNotPossible = DateTime.Now;
            double miles = 0;
            double milesTimeInHours = 0;
            int begin = convertLocationsToInt(departureLocation);
            int end = convertLocationsToInt(arrivalLocation);
            int layover1 = convertLocationsToInt(layoverA);
            int layover2 = convertLocationsToInt(layoverB);

            //check if its a direct flight
            if(App.flightGraph[begin, end] != 0)
            {
                miles = App.flightGraph[begin, end];
                milesTimeInHours = miles/500;
                //Adding half an hour for beginning and end of flight
                milesTimeInHours = milesTimeInHours + .5;
                arrivalTime = departureTime.AddHours(milesTimeInHours);
                return arrivalTime;
                
            } // Check if its 1 layover
            else if(App.flightGraph[begin, layover1] != 0 && App.flightGraph[layover1, end] != 0)
            {
                miles = App.flightGraph[begin, layover1] + App.flightGraph[layover1, end];
                milesTimeInHours = miles/500;
                //Adding half an hour for beginning and end of flight
                milesTimeInHours = milesTimeInHours + .5;
                //Adding 1 hour for 1 layover flight
                milesTimeInHours = milesTimeInHours + 1;
                arrivalTime = departureTime.AddHours(milesTimeInHours);
                return arrivalTime;
            } // Check if its 2 layovers
            else if (App.flightGraph[begin, layover1] != 0 && App.flightGraph[layover1, layover2] != 0 && App.flightGraph[layover2, end] != 0)
            {
                miles = App.flightGraph[begin, layover1] + App.flightGraph[layover1, layover2] + App.flightGraph[layover2, end];
                milesTimeInHours = miles/500;
                //Adding half an hour for beginning and end of flight
                milesTimeInHours = milesTimeInHours + .5;
                //Adding 2 hours for 2 layover flights
                milesTimeInHours = milesTimeInHours + 2;
                arrivalTime = departureTime.AddHours(milesTimeInHours);
                return arrivalTime;
            } //Should never get to this point, but if we do then we return the default dateTime and this will cause the Propose Button to fail. 
            else
            {
                return arrivalTime;
            }
            
        }

        // Ability to cancel a selected flight from the datagrid and remove from our Market Manager Queue List
        // Will auto refresh when we cancel
        private void CancelProposalBtn_isClicked(object sender, RoutedEventArgs e)
        {
            FlightManifestObj selectedFlightManifestObj = (FlightManifestObj) ApprovalQueueGrid.SelectedItem;
            App.MarketMangerQueue.Remove(selectedFlightManifestObj);
            populateDataGrid();
        }

        // Setting the dataGrid to our Market Manager Queue List and refreshing said grid
        private void populateDataGrid()
        {
            ApprovalQueueGrid.ItemsSource = App.MarketMangerQueue;
            ApprovalQueueGrid.Items.Refresh();
        }

        // Converting our locations to ints so they can be used in the graph or other methods easier
        private int convertLocationsToInt(string location)
        {
            int locationNum = -1;
            if (location == "Toledo, OH") {locationNum = 12; }
            else if (location == "Nashville, TN") { locationNum = 0; }
            else if (location == "Cleveland, OH") { locationNum = 1; }
            else if (location == "New York City, NY") { locationNum = 2; }
            else if (location == "Seattle, WA") { locationNum = 3; }
            else if (location == "Chicago, IL") { locationNum = 4; }
            else if (location == "Austin, TX") { locationNum = 5; }
            else if (location == "Orlando, FL") { locationNum = 6; }
            else if (location == "Los Angeles, CA") { locationNum = 7; }
            else if (location == "Denver, CO") { locationNum = 8; }
            else if (location == "Minneapolis, MN") { locationNum = 9; }
            else if (location == "Arlington, VA") { locationNum = 10; }
            else if (location == "Atlanta, GA") { locationNum = 11; }
            else if (location == "Sacramento, CA") { locationNum = 13; }
            else if (location == "Rapid City, SD") { locationNum = 14; }
            else locationNum = 15;
            return locationNum;
        }

        //User wants to leave, and sign in as somebody else
        private void Logout_isClicked(object sender, RoutedEventArgs e)
        {
            m_parent.Show();
            this.Close();
        }        
    }
}

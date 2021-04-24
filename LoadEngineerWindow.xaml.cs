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
        
        public LoadEngineerWindow(MainWindow main)
        {
            InitializeComponent();
            m_parent = main;
            this.DataContext = this;
            this.Closed += new EventHandler(LoadEng_Closed);
            populateDataGrid();
        }

        void LoadEng_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
            App.LoggedInUser = null;
        }

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

            }else if (s == "New York City, NY")
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
            string departureDateTime, arrivalDateTime;

            //Getting Date Time Data
            departureDateTime = DepartureDateTimePicker.Text;
            arrivalDateTime = ArrivalDateTimePicker.Text;

            if (departureDateTime == null)
            {
                DepartureDateTimePicker.BorderBrush = Brushes.Red;
                parsedDepartDate = DateTime.Today;
            }
            else 
            { 
                parsedDepartDate = DateTime.Parse(departureDateTime);
            }

            if (arrivalDateTime == null)
            {
                ArrivalDateTimePicker.BorderBrush = Brushes.Red;
                parsedArrivalDate = DateTime.Today;
            }else 
            { 
            parsedArrivalDate = DateTime.Parse(arrivalDateTime);
            }

            //Getting Location Data
            string departureLocation, arrivalLocation;
            ComboBoxItem comboBoxItem = (ComboBoxItem)DepartureCitiesComboBox.SelectedItem;
            if(comboBoxItem == null)
            {
                DepartureCitiesBorderCB.BorderBrush = Brushes.Red;
                departureLocation = null;
            }
            else 
            { 
                departureLocation = comboBoxItem.Content.ToString();
            }
            if(ArrivalCitiesComboBox.SelectedItem == null)
            { 
                
                ArrivalCitiesBorderCB.BorderBrush = Brushes.Red;
                arrivalLocation = null;
            }
            else
            {
                arrivalLocation = ArrivalCitiesComboBox.SelectedItem.ToString();
            }

            
            if (parsedDepartDate.CompareTo( parsedArrivalDate) < 0)
            {
                
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
                proposedFlightManifestObj.flightID = genNum;
                proposedFlightManifestObj.departTime = parsedDepartDate;
                proposedFlightManifestObj.arrivalTime = parsedArrivalDate;
                proposedFlightManifestObj.originCode = departureLocation;
                proposedFlightManifestObj.destinationCode = arrivalLocation;

                int begin = convertLocationsToInt(proposedFlightManifestObj.originCode);
                int end = convertLocationsToInt(proposedFlightManifestObj.destinationCode);

                FlightManifestObj planWithLayovers = App.findShortestPath(proposedFlightManifestObj, begin, end);

                App.MarketMangerQueue.Add(planWithLayovers);
                
                populateDataGrid();
                Console.WriteLine(App.MarketMangerQueue.Count);
            }
        }

        private void CancelProposalBtn_isClicked(object sender, RoutedEventArgs e)
        {
            FlightManifestObj selectedFlightManifestObj = (FlightManifestObj) ApprovalQueueGrid.SelectedItem;
            /*for(int i = 0; i < App.MarketMangerQueue.Count; i++) { 
                if (selectedFlightManifestObj.flightID.Equals(App.MarketMangerQueue.ElementAt(i).flightID)){
                    App.MarketMangerQueue.RemoveAt(i);
                }
            }*/
            App.MarketMangerQueue.Remove(selectedFlightManifestObj);
            
            populateDataGrid();
        }

        private void populateDataGrid()
        {
            ApprovalQueueGrid.ItemsSource = App.MarketMangerQueue;
            ApprovalQueueGrid.Items.Refresh();
        }

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

            
            //flightManifestObj = App.findShortestPath();
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

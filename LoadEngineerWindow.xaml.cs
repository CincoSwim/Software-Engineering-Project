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
        public ObservableCollection<FlightManifestObj> flightManifestObj
        {
            get { return flightManifestObj; }
            set { flightManifestObj = value; }
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
                proposedFlightManifestObj.departTime = parsedDepartDate;
                proposedFlightManifestObj.arrivalTime = parsedArrivalDate;
                proposedFlightManifestObj.originCode = departureLocation;
                proposedFlightManifestObj.destinationCode = arrivalLocation;
                //proposedFlightManifestObj = convertLocationsToInt(departureLocation, arrivalLocation, proposedFlightManifestObj);

                App.MarketMangerQueue.Add(proposedFlightManifestObj);
                

                Console.WriteLine(App.MarketMangerQueue.Count);
            }
        }

        private void CancelProposalBtn_isClicked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ApprovalQueueGrid.Items.Count; i++)
            {
                var myCheckBox = ApprovalQueueGrid.Columns[4].GetCellContent(ApprovalQueueGrid.Items[i]) as CheckBox;
                if (myCheckBox.IsChecked == true)
                {
                    App.MarketMangerQueue.RemoveAt(i);
                }
            }
            ApprovalQueueGrid.ItemsSource = null;
            populateDataGrid();
        }
        private void populateDataGrid()
        {
            ApprovalQueueGrid.ItemsSource = App.MarketMangerQueue;
        }
        private FlightManifestObj convertLocationsToInt(string departureLocation, string arrivalLocation, FlightManifestObj flightManifestObj)
        {
            int departureNumber, arrivalNumber;
            if (departureLocation == "Toledo, OH") { departureNumber = 12; }
            else if (departureLocation == "Nashville, TN") { departureNumber = 0; }
            else if (departureLocation == "Cleveland, OH") { departureNumber = 1; }
            else if (departureLocation == "New York City, NY") { departureNumber = 2; }
            else if (departureLocation == "Seattle, WA") { departureNumber = 3; }
            else if (departureLocation == "Chicago, IL") { departureNumber = 4; }
            else if (departureLocation == "Austin, TX") { departureNumber = 5; }
            else if (departureLocation == "Orlando, FL") { departureNumber = 6; }
            else if (departureLocation == "Los Angeles, CA") { departureNumber = 7; }
            else if (departureLocation == "Denver, CO") { departureNumber = 8; }
            else if (departureLocation == "Minneapolis, MN") { departureNumber = 9; }
            else if (departureLocation == "Arlington, VA") { departureNumber = 10; }
            else if (departureLocation == "Atlanta, GA") { departureNumber = 11; }
            else if (departureLocation == "Sacramento, CA") { departureNumber = 13; }
            else if (departureLocation == "Rapid City, SD") { departureNumber = 14; }
            else departureNumber = 15;

            if (arrivalLocation == "Toledo, OH") { arrivalNumber = 12; }
            else if (arrivalLocation == "Nashville, TN") { arrivalNumber = 0; }
            else if (arrivalLocation == "Cleveland, OH") { arrivalNumber = 1; }
            else if (arrivalLocation == "New York City, NY") { arrivalNumber = 2; }
            else if (arrivalLocation == "Seattle, WA") { arrivalNumber = 3; }
            else if (arrivalLocation == "Chicago, IL") { arrivalNumber = 4; }
            else if (arrivalLocation == "Austin, TX") { arrivalNumber = 5; }
            else if (arrivalLocation == "Orlando, FL") { arrivalNumber = 6; }
            else if (arrivalLocation == "Los Angeles, CA") { arrivalNumber = 7; }
            else if (arrivalLocation == "Denver, CO") { arrivalNumber = 8; }
            else if (arrivalLocation == "Minneapolis, MN") { arrivalNumber = 9; }
            else if (arrivalLocation == "Arlington, VA") { arrivalNumber = 10; }
            else if (arrivalLocation == "Atlanta, GA") { arrivalNumber = 11; }
            else if (arrivalLocation == "Sacramento, CA") { arrivalNumber = 13; }
            else if (arrivalLocation == "Rapid City, SD") { arrivalNumber = 14; }
            else arrivalNumber = 15;

            //flightManifestObj = App.findShortestPath(departureNumber, arrivalNumber);
            return flightManifestObj;
        }

        //User wants to leave, and sign in as somebody else
        private void Logout_isClicked(object sender, RoutedEventArgs e)
        {
            m_parent.Show();
            this.Close();
        }        
    }
}

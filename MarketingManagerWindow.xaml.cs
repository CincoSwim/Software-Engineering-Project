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
using System.Data;

//EECS 3550 - Software Engineering
//Written By: Group 18 - Christopher Pucko, Cole Beddies, Bradley Austin
//Submitted: 4/28/2021

namespace Software_Engineering_Project
{
   
    public partial class MarketingManagerWindow : Window
    {
        private MainWindow m_parent;

        //Launches the Market Manager Window
        //Gives both DataGrids thier Lists to read from and refreshes the grids to ensure it is up to date.
        public MarketingManagerWindow(MainWindow main)
        {
            InitializeComponent();
            m_parent = main;
            this.DataContext = this;
            this.Closed += new EventHandler(MarketManager_Closed);
            populateLoadEngineerProposaedFlights();
            populateFinalizedFlights();
            
        }
        //Allows user to close Market Manager with the X button without losing data
        void MarketManager_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
            App.LoggedInUser = null;
        }
        //User wants to leave, and sign in as somebody else
        private void Logout_isClicked(object sender, RoutedEventArgs e)
        {
            m_parent.Show();
            this.Close();
        }  
        // Updates and sets dataGrid from the Load Engineer list of proposed flights
        private void populateLoadEngineerProposaedFlights()
        {
            ApprovalQueueGrid.ItemsSource = App.MarketMangerQueue;
            ApprovalQueueGrid.Items.Refresh();
        }

        private void FinalizeWindowBtn_Click(object sender, RoutedEventArgs e)
        {   if(PlaneTypeBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a plane!", "Alert!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(ApprovalQueueGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a flight!", "Alert!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            FlightManifestObj selected = (FlightManifestObj)ApprovalQueueGrid.SelectedItem;
            selected.planeAssigned.planeModel = PlaneTypeBox.SelectedValue.ToString();
            selected.planeAssigned.numOfSeats = selected.planeAssigned.getNumOfSeats();
            App.FlightPlanDict.Add(selected.flightID, selected);
            App.MarketMangerQueue.Remove(selected);
            ApprovalQueueGrid.Items.Refresh();
            populateLoadEngineerProposaedFlights();
            populateFinalizedFlights();
        }
        // Updates and sets dataGrid for flights that are visible to the customer
        private void populateFinalizedFlights()
        {
            List<FlightManifestObj> flightList = new List<FlightManifestObj>();
            flightList.AddRange(App.FlightPlanDict.Values);
            PostedFlightsGrid.ItemsSource = flightList;
            PostedFlightsGrid.Items.Refresh();
        }
        // Allows the Market Manager to remove flights from the customer and refund them if necessary
        // Will update the Posted Flights list and datagrid to see in real time
        private void CancelFlightBtn_Click(object sender, RoutedEventArgs e)
        { 
            
            FlightManifestObj selected = (FlightManifestObj)PostedFlightsGrid.SelectedItem;
            //Handles no selection null pointer error
            if (selected == null) return;
            //Checks each user to see if they had that flight and refunds them their money and updates thier upcoming flight list
            foreach (var user in App.UserAccountDict)
            {
                if (user.Value.upcomingFlights.Contains(selected.flightID))
                {
                    user.Value.balance += selected.pointReward;
                    user.Value.upcomingFlights.Remove(selected.flightID);
                }
            }
            //Refreshes both datagrids and moves the canceled flight back to the Load Engineer's Proposed Flights List
            App.MarketMangerQueue.Add(selected);
            App.FlightPlanDict.Remove(selected.flightID);
            populateFinalizedFlights();
            populateLoadEngineerProposaedFlights();
        }

        //If the market manager doesn't like the flight that a load engineer proposed
        //Remove the flight from the Market Manager Queue and refresh the dataGrid
        private void RejectFlightBtn_Click(object sender, RoutedEventArgs e)
        {
            FlightManifestObj selectedFlightManifestObj = (FlightManifestObj)ApprovalQueueGrid.SelectedItem;
            App.MarketMangerQueue.Remove(selectedFlightManifestObj);
            populateLoadEngineerProposaedFlights();
        }
    }
}

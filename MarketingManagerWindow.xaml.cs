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

namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for MarketingManagerWindow.xaml
    /// </summary>
    public partial class MarketingManagerWindow : Window
    {
        private MainWindow m_parent;

        public MarketingManagerWindow(MainWindow main)
        {
            InitializeComponent();
            m_parent = main;
            this.DataContext = this;
            this.Closed += new EventHandler(MarketManager_Closed);
            populateLoadEngineerProposaedFlights();
            populateFinalizedFlights();
            
        }
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

            populateLoadEngineerProposaedFlights();
            populateFinalizedFlights();


        }
        private void populateFinalizedFlights()
        {
            List<FlightManifestObj> flightList = new List<FlightManifestObj>();
            flightList.AddRange(App.FlightPlanDict.Values);
            PostedFlightsGrid.ItemsSource = flightList;
            PostedFlightsGrid.Items.Refresh();
        }

        private void CancelFlightBtn_Click(object sender, RoutedEventArgs e)
        { 
            
            FlightManifestObj selected = (FlightManifestObj)PostedFlightsGrid.SelectedItem;
            if (selected == null) return;
            foreach (var user in App.UserAccountDict)
            {
                if (user.Value.upcomingFlights.Contains(selected.flightID))
                {
                    user.Value.balance += selected.pointReward;
                    user.Value.canceledFlights.Add(selected.flightID);
                    user.Value.upcomingFlights.Remove(selected.flightID);
                }
            }
            App.MarketMangerQueue.Add(selected);
            App.FlightPlanDict.Remove(selected.flightID);
            populateFinalizedFlights();
            populateLoadEngineerProposaedFlights();
        }

        private void RejectFlightBtn_Click(object sender, RoutedEventArgs e)
        {
            FlightManifestObj selectedFlightManifestObj = (FlightManifestObj)ApprovalQueueGrid.SelectedItem;
            App.MarketMangerQueue.Remove(selectedFlightManifestObj);
            populateLoadEngineerProposaedFlights();
        }
    }
}

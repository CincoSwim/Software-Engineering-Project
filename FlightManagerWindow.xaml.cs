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
using Newtonsoft.Json;

namespace Software_Engineering_Project
{
    /// <summary>
    /// Interaction logic for FlightManagerWindow.xaml
    /// </summary>
    public partial class FlightManagerWindow : Window
    {
        private MainWindow m_parent;
        //Launches the Flight Manager Window and shows their dataGrid 
        public FlightManagerWindow(MainWindow main)
        {
            InitializeComponent();
            this.Closed += new EventHandler(FlightManagerWindow_Closed);
            m_parent = main;
            populateFMGrid();
        }
        //Allows user to logout and sign in as somebody else
        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            m_parent.Show();
            this.Close();
        }
        //Allows usuage of X button to close F.M without loss of data
        void FlightManagerWindow_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
            App.LoggedInUser = null;
        }
        //Updates and Shows the datagrid for the flight manager
        private void populateFMGrid()
        {
            FlightManagerObjDataGrid.ItemsSource = LoadUpcomingFlightsManager();
            FlightManagerObjDataGrid.Items.Refresh();
        }
        //Gets the List of Upcoming Flights to use for the datagrid item source from the FlightHistoryDictionary
        private List<FlightManifestObj> LoadUpcomingFlightsManager()
        {
            List<FlightManifestObj> gridList = new List<FlightManifestObj>();
            gridList.AddRange(App.FlightHistoryDictionary.Values);
            return gridList;
        }
        //Allows Flight Manager to print out a selected flight and store in the single selection text file
        private void PrintSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Printed: One object to C:\\temp\\Printouts\\SingleSelection.txt");
            File.WriteAllText(FileIOLoading.AccountantSinglePath, printFlightManagerSingleRecords((FlightManifestObj)FlightManagerObjDataGrid.SelectedItem));
        }
        //Allows Flight Manager to print out all flights and store in All Selection text file
        private void PrintAllRecords_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Printed: All objects to C:\\temp\\Printouts\\AllSelection.txt");
            File.WriteAllText(FileIOLoading.AccountantMultiPath, printFlightManagerAllRecord());
        }
        //Handles formatting and printing all records for the flight manager
        public static string printFlightManagerAllRecord()
        {
            string record = "";
            //Obtains the Past Flights List
            List<FlightManifestObj> flightList = new List<FlightManifestObj>();
            flightList.AddRange(App.FlightHistoryDictionary.Values);
            //Prints flight IDs and Users of said flight
            foreach (FlightManifestObj flight in flightList)
            {
                record += $"Flight ID: {flight.flightID}";
                foreach (UserAccountObj user in flight.bookedUsers)
                {
                    record += $"\n\t{user.firstName} {user.lastName}";
                }
                record += "\n\n";
            }
            return record;
        }
        //Handles printing the single flight records for the flight manager
        //Passes in a specific flight for simplicity
        public static string printFlightManagerSingleRecords(FlightManifestObj flight)
        {
            string record = "";
            //Prints flight ID
            record += $"Flight ID: {flight.flightID}\n\t";
            //Prints all users of said flight
            foreach (UserAccountObj user in flight.bookedUsers)
            {
                record += $"{user.firstName} {user.lastName}\n\t";
            }
            return record;
        }
    }
}

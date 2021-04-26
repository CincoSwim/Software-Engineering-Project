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
        public FlightManagerWindow(MainWindow main)
        {
            InitializeComponent();
            this.Closed += new EventHandler(FlightManagerWindow_Closed);
            m_parent = main;
            populateFMGrid();
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            m_parent.Show();
            this.Close();
        }
        void FlightManagerWindow_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
            App.LoggedInUser = null;
        }
        private void populateFMGrid()
        {
            FlightManagerObjDataGrid.ItemsSource = LoadUpcomingFlightsManager();
            FlightManagerObjDataGrid.Items.Refresh();
        }
        private List<FlightManifestObj> LoadUpcomingFlightsManager()
        {
            List<FlightManifestObj> gridList = new List<FlightManifestObj>();
            /*foreach (string str in App.LoggedInUser.upcomingFlights.ToList())
            {
                gridList.Add(App.FlightPlanDict[str]);
            }*/
            
            gridList.AddRange(App.FlightHistoryDictionary.Values);
            return gridList;
        }
        private void PrintSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Printed: One object to C:\\temp\\Printouts\\SingleSelection.txt");
            //File.WriteAllText(FileIOLoading.AccountantSinglePath, JsonConvert.SerializeObject(FlightManagerObjDataGrid.SelectedItem, Formatting.Indented));
            File.WriteAllText(FileIOLoading.AccountantSinglePath, printFlightManagerSingleRecords((FlightManifestObj)FlightManagerObjDataGrid.SelectedItem));
        }

        private void PrintAllRecords_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Printed: All objects to C:\\temp\\Printouts\\AllSelection.txt");
            //File.WriteAllText(FileIOLoading.AccountantMultiPath, JsonConvert.SerializeObject(App.FlightHistoryDictionary, Formatting.Indented));
            File.WriteAllText(FileIOLoading.AccountantMultiPath, printFlightManagerAllRecord());
        }

        public static string printFlightManagerAllRecord()
        {
            string record = "";
            List<FlightManifestObj> flightList = new List<FlightManifestObj>();
            flightList.AddRange(App.FlightHistoryDictionary.Values);
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
        public static string printFlightManagerSingleRecords(FlightManifestObj flight)
        {
            string record = "";
            record += $"Flight ID: {flight.flightID}\n\t";
            foreach (UserAccountObj user in flight.bookedUsers)
            {
                record += $"{user.firstName} {user.lastName}\n\t";
            }
            return record;
        }
    }
}

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
            FlightManagerObjDataGrid.ItemsSource = LoadUpcomingFlightsManager();
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
        private List<FlightManifestObj> LoadUpcomingFlightsManager()
        {
            List<FlightManifestObj> gridList = new List<FlightManifestObj>();
            foreach (string str in App.LoggedInUser.upcomingFlights.ToList())
            {
                gridList.Add(App.FlightPlanDict[str]);
            }
            return gridList;
        }
        private void PrintSelectedBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Printed: One object to C:\temp\\Printouts\\SingleSelection.txt");
            File.WriteAllText(FileIOLoading.AccountantSinglePath, JsonConvert.SerializeObject(FlightManagerObjDataGrid.SelectedItem, Formatting.Indented));
        }

        private void PrintAllRecords_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Printed: All objects to C:\temp\\Printouts\\AllSelection.txt");
            File.WriteAllText(FileIOLoading.AccountantMultiPath, JsonConvert.SerializeObject(App.FlightPlanDict, Formatting.Indented));
        }
    }
}

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
            return gridList;
        }
        void FlightSearch_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
        }
    }
}

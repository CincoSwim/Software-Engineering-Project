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
        }

        //Check and See if Departure Date is before Arrival Date.
        //Check Locations and Make sure Locations are not the same. 
        //Populate List for Flight Manager Approval
        //If anything is not correct, highlight the wrong thing and display the correct error text. 
        private void FlightProposeBtn_isClicked(object sender, RoutedEventArgs e)
        { 
            string departureDateTime = DepartureDateTimePicker.Text;
            string arrivalDateTime = ArrivalDateTimePicker.Text;
            DateTime parsedDepartDate = DateTime.Parse(departureDateTime);
            DateTime parsedArrivalDate = DateTime.Parse(arrivalDateTime);
            

            if (parsedDepartDate.CompareTo( parsedArrivalDate) < 0)
            {
                MessageBox.Show("Departure Date is before Arrival Date.");

                FlightManifestObj proposedFlightManifestObj = new FlightManifestObj();
                proposedFlightManifestObj.departTime = parsedDepartDate;
                proposedFlightManifestObj.arrivalTime = parsedArrivalDate;
                
                
                App.MarketMangerQueue.Add(proposedFlightManifestObj);
                
                Console.WriteLine(App.MarketMangerQueue.Count);
            }
        }

        private void CancelProposalBtn_isClicked(object sender, RoutedEventArgs e)
        {


        }

        //User wants to leave, and sign in as somebody else
        private void Logout_isClicked(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }        
    }
}

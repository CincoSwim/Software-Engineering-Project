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

        private void DepartureComboBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            ArrivalCitiesComboBox.Items.Clear();
            ComboBoxItem comboBoxItem = (ComboBoxItem)DepartureCitiesComboBox.SelectedItem;
            string s = comboBoxItem.Content.ToString();
            
            if(s == "Toledo, OH") 
            { 
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                
            }else if (s == "Arlington, VA")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                
            }else if (s == "Atlanta, GA")
            {
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");                
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");

            }else if (s == "Austin, TX")
            {
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");                
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");

            }else if (s == "Chicago, IL")
            {
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");                
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");   
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");                

            }else if (s == "Cleveland, OH")
            {
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Chicago, IL"); 
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");    
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");  

            }else if (s == "Denver, CO")
            {
                ArrivalCitiesComboBox.Items.Add("Austin, TX");                
                ArrivalCitiesComboBox.Items.Add("Chicago, IL"); 
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");    
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA");  

            }else if (s == "Los Angeles, CA")
            {
                ArrivalCitiesComboBox.Items.Add("Austin, TX");
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");

            }else if (s == "Minneapolis, MN")
            {
                ArrivalCitiesComboBox.Items.Add("Austin, TX");                
                ArrivalCitiesComboBox.Items.Add("Chicago, IL");
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");                
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");    
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");                
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");  

            }else if (s == "New York City, NY")
            {
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");              
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Nashville, TN");               
                ArrivalCitiesComboBox.Items.Add("Orlando, FL");  

            }else if (s == "Orlando, FL")
            {
                ArrivalCitiesComboBox.Items.Add("Arlington, VA");
                ArrivalCitiesComboBox.Items.Add("Atlanta, GA");
                ArrivalCitiesComboBox.Items.Add("Austin, TX");  
                ArrivalCitiesComboBox.Items.Add("Cleveland, OH");
                ArrivalCitiesComboBox.Items.Add("New York City, NY");
                ArrivalCitiesComboBox.Items.Add("Toledo, OH");  

            }else if (s == "Rapid City, SD")
            {
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Minneapolis, MN");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA");

            }else if (s == "Sacramento, CA")
            {
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Los Angeles, CA");
                ArrivalCitiesComboBox.Items.Add("Seattle, WA");

            }else if (s == "Seattle, WA")
            {
                ArrivalCitiesComboBox.Items.Add("Denver, CO");
                ArrivalCitiesComboBox.Items.Add("Rapid City, SD");  
                ArrivalCitiesComboBox.Items.Add("Sacramento, CA");
            }
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

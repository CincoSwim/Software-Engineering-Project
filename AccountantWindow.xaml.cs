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

//EECS 3550 - Software Engineering
//Written By: Group 18 - Christopher Pucko, Cole Beddies, Bradley Austin
//Submitted: 4/28/2021

namespace Software_Engineering_Project
{
    
    public partial class AccountantWindow : Window
    {
        private MainWindow m_parent;
        //Opens the accountant window and loads the accountant's datagrid
        public AccountantWindow(MainWindow main)
        {  
            InitializeComponent();
            this.Closed += new EventHandler(Accountant_Closed);
            m_parent = main;
            AccountingObjDataGrid.ItemsSource = App.TransactionHist;

        }
        //Logs out the user and returns to main window. 
        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
           
            m_parent.Show();
            this.Close();
        }

        //Print a selected flight's income, flightID, users on said flight to a text file
        private void PrintSelectedBtn_Click(object sender, RoutedEventArgs e)
        {   
            
            TransactionObj selected = (TransactionObj)AccountingObjDataGrid.SelectedItem;
            //Handles a no selection null pointer error
            if (selected == null)
            {
                MessageBox.Show("Please select a flight", "Alert!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //Prints the information needed for a single flight for the accountant
            MessageBox.Show("Printed: One object to C:\\temp\\Printouts\\SingleSelection.txt");
            File.WriteAllText(FileIOLoading.AccountantSinglePath, printAccountantSingleRecords(selected));
            selected = null;
            //will unselect in the datagrid
            AccountingObjDataGrid.SelectedItem = null;
        }

        //Prints every flight's income records, people on each plane, and the plane's ID
        private void PrintAllRecords_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Printed: All objects to C:\\temp\\Printouts\\AllSelection.txt");
            File.WriteAllText(FileIOLoading.AccountantMultiPath, printAccountantAllRecords());
        }

        public static string printAccountantAllRecords()
        {
            string record = "";
            double percentOfSeats = 0;
            double totalBalance = 0;
            double incomeOfFlight = 0;

            //Adding up our total income 
            foreach (var value in App.TransactionHist)
            {
                totalBalance += value.transactionAmt;
            }
            totalBalance = Math.Round(totalBalance, 2);
            record += $"Total income from all flights: {totalBalance}\n\n";

            //Finding out how full each plane was and showing the income of each plane individually
            foreach (var value in App.TransactionHist)
            {
                percentOfSeats = ((double)value.FlightUID.bookedUsers.Count / (double)value.FlightUID.planeAssigned.numOfSeats) * 100;
                percentOfSeats = Math.Round(percentOfSeats, 2);

                incomeOfFlight = value.transactionAmt;
                incomeOfFlight = Math.Round(incomeOfFlight, 2);

                record += $"Flight ID: {value.FlightUID.flightID}\n\t";
                record += $"Percentage of Seats Taken: %{percentOfSeats}\n\t";
                record += $"Total Income of Flight: {incomeOfFlight}\n\n";
            }

            List<FlightManifestObj> flightList = new List<FlightManifestObj>();
            flightList.AddRange(App.FlightHistoryDictionary.Values);

            return record;
        }

        //Prints out a single flight's income, percentage of plane filled up, and the flight ID
        internal static string printAccountantSingleRecords(TransactionObj flight)
        {
            string record = "";
            double percentOfSeats = 0;
            double totalBalance = 0;

            percentOfSeats = (flight.FlightUID.bookedUsers.Count / flight.FlightUID.planeAssigned.numOfSeats) * 100;
            percentOfSeats = Math.Round(percentOfSeats, 2);

            totalBalance += flight.transactionAmt;
            totalBalance = Math.Round(totalBalance, 2);

            List<FlightManifestObj> flightList = new List<FlightManifestObj>();
            flightList.AddRange(App.FlightHistoryDictionary.Values);

            record += $"Flight ID: {flight.FlightUID.flightID}\n\t";
            record += $"Percentage of Seats Taken: {percentOfSeats}\n\t";
            record += $"Total Income of Flight: {totalBalance}\n\n";

            return record;
        }

        //Allows usage of the X button to close out the accountant
        void Accountant_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
            App.LoggedInUser = null;
        }
    }
}

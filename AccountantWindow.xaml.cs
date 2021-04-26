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
    /// Interaction logic for AccountantWindow.xaml
    /// </summary>
    public partial class AccountantWindow : Window
    {
        private MainWindow m_parent;
        public AccountantWindow(MainWindow main)
        {  
            InitializeComponent();
            this.Closed += new EventHandler(Accountant_Closed);
            m_parent = main;
            AccountingObjDataGrid.ItemsSource = App.TransactionHist;

        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
           
            m_parent.Show();
            this.Close();
        }

        private void PrintSelectedBtn_Click(object sender, RoutedEventArgs e)
        {   
            //double transactionForPlane = 0;
            TransactionObj selected = (TransactionObj)AccountingObjDataGrid.SelectedItem;
            if (selected == null)
            {
                MessageBox.Show("Please select a flight", "Alert!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //transactionForPlane = selected.FlightUID.bookedUsers.Count * selected.FlightUID.ticketPrice;
            MessageBox.Show("Printed: One object to C:\\temp\\Printouts\\SingleSelection.txt");
            //File.WriteAllText(FileIOLoading.AccountantSinglePath, JsonConvert.SerializeObject(AccountingObjDataGrid.SelectedItem, Formatting.Indented) + "\nTotal Income: " + (transactionForPlane.ToString()));
            File.WriteAllText(FileIOLoading.AccountantSinglePath, App.printAccountantSingleRecords(selected));
            selected = null;
            AccountingObjDataGrid.SelectedItem = null;
        }

        private void PrintAllRecords_Click(object sender, RoutedEventArgs e)
        {
            //double totalBalance = 0;
            //foreach (var value in App.TransactionHist)
            //{
            //    //totalBalance += value.FlightUID.ticketPrice * value.FlightUID.bookedUsers.Count;
            //    totalBalance += value.transactionAmt;
            //}
            MessageBox.Show("Printed: All objects to C:\\temp\\Printouts\\AllSelection.txt");
            //File.WriteAllText(FileIOLoading.AccountantMultiPath, JsonConvert.SerializeObject(App.TransactionHist, Formatting.Indented) + "\nTotal Income: " + (totalBalance.ToString()));
            File.WriteAllText(FileIOLoading.AccountantMultiPath, App.printAccountantAllRecords());
        }

        void Accountant_Closed(object sender, EventArgs e)
        {
            m_parent.Show();
            App.LoggedInUser = null;
        }
    }
}

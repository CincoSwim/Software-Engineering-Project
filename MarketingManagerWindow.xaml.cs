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
        {

        }
    }
}

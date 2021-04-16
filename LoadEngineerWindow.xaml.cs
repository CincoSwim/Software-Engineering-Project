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

        private void FlightProposeBtn_isClicked(object sender, RoutedEventArgs e)
        {
            if ()
            {

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

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

namespace CasinoApp_SCRUM
{
    /// <summary>
    /// Interaction logic for ChipExchange.xaml
    /// </summary>
    public partial class ChipExchange : Window
    {
        public ChipExchange()
        {
            InitializeComponent();
            lblChips.Content = "Chips: " + GlobalData.gUserInfo.getCurrentChips();
            lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GlobalData.gMainMenu.Show();
        }

        private void buyChips(int chipNumber)
        {
            if (chipNumber <= GlobalData.gUserInfo.getCurrentMoney())
            {
                GlobalData.gUserInfo.addChips(chipNumber);
                GlobalData.gUserInfo.subtractMoney(chipNumber);
                lblChips.Content = "Chips: " + GlobalData.gUserInfo.getCurrentChips();
                lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
            }
            
        }

        private void sellChip(int chipNumber)
        {
            if (chipNumber <= GlobalData.gUserInfo.getCurrentChips())
            {
                GlobalData.gUserInfo.addMoney(chipNumber);
                GlobalData.gUserInfo.subtractChips(chipNumber);
                lblChips.Content = "Chips: " + GlobalData.gUserInfo.getCurrentChips();
                lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
            }
            
        }

        private void btnMoney1_Click(object sender, RoutedEventArgs e)
        {
            sellChip(1);
        }

        private void btnMoney5_Click(object sender, RoutedEventArgs e)
        {
            sellChip(5);
        }

        private void btnMoney10_Click(object sender, RoutedEventArgs e)
        {
            sellChip(10);
        }

        private void btnMoney25_Click(object sender, RoutedEventArgs e)
        {
            sellChip(25);
        }

        private void btnMoney50_Click(object sender, RoutedEventArgs e)
        {
            sellChip(50);
        }

        private void exchangeBtn_Click(object sender, RoutedEventArgs e)
        {
            buyChips(1);
        }

        private void btnChip5_Click(object sender, RoutedEventArgs e)
        {
            buyChips(5);
        }

        private void btnChip10_Click(object sender, RoutedEventArgs e)
        {
            buyChips(10);
        }

        private void btnChip25_Click(object sender, RoutedEventArgs e)
        {
            buyChips(25);
        }

        private void btnChip50_Click(object sender, RoutedEventArgs e)
        {
            buyChips(50);
        }

        
    }
}

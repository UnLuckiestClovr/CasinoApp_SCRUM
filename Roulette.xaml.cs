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
    /// Interaction logic for Roulette.xaml
    /// </summary>
    public partial class Roulette : Window
    {
        public Roulette()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.gMainMenu.Show();
            this.Hide();
        }

        private void spinRouletteBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //betNumber = sender.content
        }
    }

    public class RouletteBoard
    {
        public GeneralFunctions genFunctions = new GeneralFunctions();

        private string[] colorArray = { "Red", "Black" };

        public string getColor(int num) { return colorArray[num]; }
        
        public int spinWheel_Number()
        {
            return genFunctions.returnRandInt(0, 37);
        }

        public string spinWheel_Color()
        {
            return colorArray[genFunctions.returnRandInt(0, 1)];
        }

        // Bet Logic

        private int betAmount = 0;
        private string betColor;
        private int betNumber;

        public void setBetChips(int amount)
        {
            this.betAmount = amount;
        }

        public void setBet_Values(int number, string color)
        {
            this.betNumber = number;
            this.betColor = color;
        }

        public bool spinWheel()
        {
            if (betAmount == 0) { return false; }
        }
    }
}

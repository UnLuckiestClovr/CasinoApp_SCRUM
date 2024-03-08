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

        RouletteBoard rb = new RouletteBoard();
        public Roulette()
        {
            InitializeComponent();
            chipLabel.Content = (GlobalData.gUserInfo.getCurrentChips() + "");
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.gMainMenu.Show();
            this.Hide();
        }

        private void spinRouletteBTN_Click(object sender, RoutedEventArgs e)
        {




            int rolled = rb.spinWheel_Number();
            int winnings = rb.spinWheel(rolled);
            GlobalData.gUserInfo.addChips(winnings);

            rb.resetBets();
            chipLabel.Content = (GlobalData.gUserInfo.getCurrentChips() + "");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString().Equals("RED"))
            {
                rb.setBet_Values(-1, "RED");
            }else if ((sender as Button).Content.ToString().Equals("BLACK"))
            {
                rb.setBet_Values(-1, "BLACK");
            }
            else
            {
                rb.setBet_Values(int.Parse((sender as Button).Content.ToString()),null);
            }
        }

        private void betButtonClick(object sender, RoutedEventArgs e)
        {
            if (int.Parse((sender as Button).Content.ToString()) + rb.getBetNumber() < GlobalData.gUserInfo.getCurrentChips())
            {
                rb.setBetNumber(rb.getBetNumber() + int.Parse((sender as Button).Content.ToString()));
            }
        }
    }

    public class RouletteBoard
    {
        public GeneralFunctions genFunctions = new GeneralFunctions();

        private string[] colorArray = { "RED", "BLACK" };

        public string getColor(int num) { return colorArray[num]; }
        
        public int spinWheel_Number()
        {
            return genFunctions.returnRandInt(0, 37);
        }

        public string spinWheel_Color()
        {
            return colorArray[genFunctions.returnRandInt(0, 1)];
        }

        // Bet Logic ---------------------------------------

        private int betAmount = 0;
        private string betColor = null;
        private int betNumber = -1;

        public void resetBets()
        {
            betAmount = 0;
            betColor = null;
            betNumber = -1;
        }

        public void setBetChips(int amount)
        {
            this.betAmount = amount;
        }
        
        public void setBetNumber(int betnumber)
        {
            this.betNumber = betnumber;
        }

        public int getBetNumber()
        {
            return this.betNumber;
        }
        public void setBetColor(string betcolor)
        {
            this.betColor = betcolor;
        }
        public void setBet_Values(int number, string color)
        {
            this.betNumber = number;
            this.betColor = color;
        }

        public int spinWheel(int rolled)
        {
            if (betAmount == 0) { return 0; }

            //int rolled = spinWheel_Number();

            if (betNumber == 0) 
            {
                if (betNumber.Equals(rolled))
                {
                    return (int)(betAmount * 3);
                }
                else return 0;
            }
            else if (betNumber == -1 && betColor != null)
            {
                if (betColor.Equals(rolled))
                {
                    return (int)(betAmount * 1.5);
                }
                else return 0;
            }
            else if (betNumber != -1 && betColor == null)
            {
                if (betNumber.Equals(0))
                {
                    return (int)(betAmount * 2);
                }
                else return 0;
            }
            else { return 0; }

        }
    }
}

﻿using System;
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
            feedback.Content = "The wheel rolled a " + rolled;
            
            int winnings = rb.spinWheel(rolled);
            GlobalData.gUserInfo.subtractChips(rb.getBetAmount());
            GlobalData.gUserInfo.addChips(winnings);

            rb.resetBets();
            chipLabel.Content = (GlobalData.gUserInfo.getCurrentChips() + "");

            currentBetText.Text = $"Current Bet Amount : {rb.getBetAmount()}";



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

        private void bet1Chip(object sender, RoutedEventArgs e)
        {
            betButtonClick(1);
        }
        private void bet5Chips(object sender, RoutedEventArgs e)
        {
            betButtonClick(5);
        }
        private void bet10Chips(object sender, RoutedEventArgs e)
        {
            betButtonClick(10);
        }
        private void bet25Chips(object sender, RoutedEventArgs e)
        {
            betButtonClick(25);
        }
        private void bet50Chip(object sender, RoutedEventArgs e)
        {
            betButtonClick(50);
        }
        private void bet100Chip(object sender, RoutedEventArgs e)
        {
            betButtonClick(100);
        }

        private void betButtonClick(int betNum)
        {
            if (betNum + rb.getBetAmount() <= GlobalData.gUserInfo.getCurrentChips())
            {
                int betAmount = rb.getBetAmount() + betNum;
                rb.setBetAmount(betAmount);
                currentBetText.Text = $"Current Bet Amount : {betAmount}";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            rb.resetBets();
            currentBetText.Text = $"Current Bet Amount : {rb.getBetAmount()}";
        }
    }

    public class RouletteBoard
    {
        public GeneralFunctions genFunctions = new GeneralFunctions();

        private string[] colorArray = { "RED", "BLACK" };

        public string getColor(int num) { return colorArray[num]; }
        
        public int spinWheel_Number()
        {
            return genFunctions.returnRandInt(0, 37); // -----------------
        }

        // Bet Logic ---------------------------------------

        private int betAmount = 0;
        private string betColor = null;
        private int betNumber = -1;

        public void setBetAmount(int newAmount)
        {
            betAmount = newAmount;
        }

        public int getBetAmount() {  return betAmount; }

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
            int rolleddiv5 = rolled / 5;
            string color = "BLACK";
            switch (rolleddiv5)
            {
                case 0:
                    color = "RED";
                    break;
                case 2:
                    color = "RED";
                    break;
                case 4:
                    color = "RED";
                    break;
                case 6:
                    color = "RED";
                    break;
                case 8:
                    color = "RED";
                    break;
                case 10:
                    color = "RED";
                    break;
            }



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
                if (betColor.Equals(color))
                {
                    return (int)(betAmount * 1.5);
                }
                else return 0;
            }
            else if (betNumber != -1 && betColor == null)
            {
                if (betNumber.Equals(rolled))
                {
                    return (int)(betAmount * 2);
                }
                else return 0;
            }
            else { return 0; }

        }
    }
}

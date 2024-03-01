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
    /// Interaction logic for SlotMachine.xaml
    /// </summary>
    public partial class SlotMachine : Window
    {
        public SlotMachine()
        {
            InitializeComponent();
            lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
            feedbackLabel.Content = "Play Slots ($5)";
        }

        public void rollSlots(object sender, RoutedEventArgs e)
        {
            feedbackLabel.Content = "You Lose";
            if (GlobalData.gUserInfo.getCurrentMoney() >= 5)
            {
                GlobalData.gUserInfo.subtractMoney(5);
                lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
                List<int> ints = new List<int>() { 4, 4, 4, 4, 3, 3, 3, 2, 2, 1 }; // 4-cherry 3-bell 2-bar 1-sevens
                Random rnd = new Random();
                int firstSlot = ints[rnd.Next(10)];
                int secondSlot = ints[rnd.Next(10)];
                int thirdSlot = ints[rnd.Next(10)];


                switch (firstSlot)
                {
                    case 4:
                        slot1.Source = new BitmapImage(new Uri("Resources/cherry.jpg", UriKind.Relative));
                        break;
                    case 3:
                        slot1.Source = new BitmapImage(new Uri("Resources/bell.jpg", UriKind.Relative));
                        break;
                    case 2:
                        slot1.Source = new BitmapImage(new Uri("Resources/AngyCantera.png", UriKind.Relative));
                        break;
                    case 1:
                        slot1.Source = new BitmapImage(new Uri("Resources/7.jpg", UriKind.Relative));
                        break;

                }

                switch (secondSlot)
                {
                    case 4:
                        slot2.Source = new BitmapImage(new Uri("Resources/cherry.jpg", UriKind.Relative));
                        break;
                    case 3:
                        slot2.Source = new BitmapImage(new Uri("Resources/bell.jpg", UriKind.Relative));
                        break;
                    case 2:
                        slot2.Source = new BitmapImage(new Uri("Resources/AngyCantera.png", UriKind.Relative));
                        break;
                    case 1:
                        slot2.Source = new BitmapImage(new Uri("Resources/7.jpg", UriKind.Relative));
                        break;

                }

                switch (thirdSlot)
                {
                    case 4:
                        slot3.Source = new BitmapImage(new Uri("Resources/cherry.jpg", UriKind.Relative));
                        break;
                    case 3:
                        slot3.Source = new BitmapImage(new Uri("Resources/bell.jpg", UriKind.Relative));
                        break;
                    case 2:
                        slot3.Source = new BitmapImage(new Uri("Resources/AngyCantera.png", UriKind.Relative));
                        break;
                    case 1:
                        slot3.Source = new BitmapImage(new Uri("Resources/7.jpg", UriKind.Relative));
                        break;

                }

                if (firstSlot == secondSlot && firstSlot == thirdSlot)
                {
                    switch (firstSlot) // add money on win
                    {
                        case 1:
                            // cherry
                            feedbackLabel.Content = "You Won $10";
                            GlobalData.gUserInfo.addMoney(10);
                            lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentChips();
                            break;
                        case 2:
                            // bell
                            feedbackLabel.Content = "You Won $20";
                            GlobalData.gUserInfo.addMoney(20);
                            lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentChips();
                            break;
                        case 3:
                            // cantera
                            feedbackLabel.Content = "You Won $40";
                            GlobalData.gUserInfo.addMoney(40);
                            lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentChips();
                            break;
                        case 4:
                            // 7
                            feedbackLabel.Content = "You Won $100";
                            GlobalData.gUserInfo.addMoney(100);
                            lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentChips();
                            break;
                    }
                } 
                
            }
            else
            {
                feedbackLabel.Content = "You Don't Have Enough Money To Play";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.gMainMenu.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

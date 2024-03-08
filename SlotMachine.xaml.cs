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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAnimatedGif;

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

        public async void rollSlots(object sender, RoutedEventArgs e)
        {
            int slotvar1 = 0;
            int slotvar2 = 0;
            int slotvar3 = 0;

            var imagespin = new BitmapImage();
            imagespin.BeginInit();
            imagespin.UriSource = new Uri("Resources/rolling.gif", UriKind.Relative);
            imagespin.EndInit();

            var imageCherry = new BitmapImage();
            imageCherry.BeginInit();
            imageCherry.UriSource = new Uri("Resources/cherry.jpg", UriKind.Relative);
            imageCherry.EndInit();

            var imageBell = new BitmapImage();
            imageBell.BeginInit();
            imageBell.UriSource = new Uri("Resources/bell.jpg", UriKind.Relative);
            imageBell.EndInit();

            var imageCant = new BitmapImage();
            imageCant.BeginInit();
            imageCant.UriSource = new Uri("Resources/AngyCantera.png", UriKind.Relative);
            imageCant.EndInit();

            var image7 = new BitmapImage();
            image7.BeginInit();
            image7.UriSource = new Uri("Resources/7.jpg", UriKind.Relative);
            image7.EndInit();

            ImageBehavior.SetAnimatedSource(slot1, imagespin);
            ImageBehavior.SetAnimatedSource(slot2, imagespin);
            ImageBehavior.SetAnimatedSource(slot3, imagespin);
            ImageBehavior.SetRepeatBehavior(slot1, new RepeatBehavior(TimeSpan.FromSeconds(2.5)));
            ImageBehavior.SetRepeatBehavior(slot2, new RepeatBehavior(TimeSpan.FromSeconds(3)));
            ImageBehavior.SetRepeatBehavior(slot3, new RepeatBehavior(TimeSpan.FromSeconds(3.5)));
            if (GlobalData.gUserInfo.getCurrentMoney() >= 5)
            {
             

                GlobalData.gUserInfo.subtractMoney(5);
                lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
                List<int> ints = new List<int>() { 4, 4, 4, 4, 3, 3, 3, 2, 2, 1 }; // 4-cherry 3-bell 2-bar 1-sevens
                Random rnd = new Random();
                int firstSlot = ints[rnd.Next(10)];
                int secondSlot = ints[rnd.Next(10)];
                int thirdSlot = ints[rnd.Next(10)];

                await Task.Delay(2500);
                switch (firstSlot)
                {
                    case 4:
                        slot1.Source = new BitmapImage(new Uri("Resource/cherry.jpg", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot1, imageCherry);
                        slotvar1 = 4;
                        break;
                    case 3:
                        slot1.Source = new BitmapImage(new Uri("Resources/bell.jpg", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot1, imageBell);

                        slotvar1 = 3;
                        break;
                    case 2:
                        slot1.Source = new BitmapImage(new Uri("Resources/AngyCantera.png", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot1, imageCant);

                        slotvar1 = 2;
                        break;
                    case 1:
                        slot1.Source = new BitmapImage(new Uri("Resources/7.png", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot1, image7);

                        slotvar1 = 1;
                        break;

                }
                await Task.Delay(500);
                switch (secondSlot)
                {
                    case 4:
                        slot2.Source = new BitmapImage(new Uri("Resources/cherry.jpg", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot2, imageCherry);

                        slotvar2 = 4;
                        break;
                    case 3:
                        slot2.Source = new BitmapImage(new Uri("Resources/bell.jpg", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot2, imageBell);

                        slotvar2 = 3;
                        break;
                    case 2:
                        slot2.Source = new BitmapImage(new Uri("Resources/AngyCantera.png", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot2, imageCant);

                        slotvar2 = 2;
                        break;
                    case 1:
                        slot2.Source = new BitmapImage(new Uri("Resources/7.jpg", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot2, image7);

                        slotvar2 = 1;
                        break;

                }
                await Task.Delay(500);
                switch (thirdSlot)
                {
                    case 4:
                        slot3.Source = new BitmapImage(new Uri("Resources/cherry.jpg", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot3, imageCherry);

                        slotvar3 = 4;
                        break;
                    case 3:
                        slot3.Source = new BitmapImage(new Uri("Resources/bell.jpg", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot3, imageBell);

                        slotvar3 = 3;
                        break;
                    case 2:
                        slot3.Source = new BitmapImage(new Uri("Resources/AngyCantera.png", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot3, imageCant);

                        slotvar3 = 2;
                        break;
                    case 1:
                        slot3.Source = new BitmapImage(new Uri("Resources/7.jpg", UriKind.Relative));
                        ImageBehavior.SetAnimatedSource(slot3, image7);

                        slotvar3 = 1;
                        break;

                }
                if (firstSlot == secondSlot && firstSlot == thirdSlot)
                {
                    switch (firstSlot) // add money on win
                    {
                        case 4:
                            // cherry
                            feedbackLabel.Content = "You Won $10";
                            GlobalData.gUserInfo.addMoney(10);
                            lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
                            break;
                        case 3:
                            // bell
                            feedbackLabel.Content = "You Won $20";
                            GlobalData.gUserInfo.addMoney(20);
                            lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
                            break;
                        case 2:
                            // cantera
                            feedbackLabel.Content = "You Won $40";
                            GlobalData.gUserInfo.addMoney(40);
                            lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
                            break;
                        case 1:
                            // 7
                            feedbackLabel.Content = "You Won $100";
                            GlobalData.gUserInfo.addMoney(100);
                            lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
                            break;
                    }
                    lblMoney.Content = "Money: " + GlobalData.gUserInfo.getCurrentMoney();
                } 
                else if (firstSlot != secondSlot || firstSlot != thirdSlot)
                {
                    feedbackLabel.Content = "You Lose";
                    await Task.Delay(1500);
                    feedbackLabel.Content = "Play Slots ($5)";
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

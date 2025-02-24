﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CasinoApp_SCRUM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void exchangeBtnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GlobalData.gChipExchangeWindow.Show();
            GlobalData.gChipExchangeWindow.chageValue(GlobalData.gUserInfo.getCurrentMoney(), GlobalData.gUserInfo.getCurrentChips());
        }

        public void slotBtnClick(object sender, RoutedEventArgs e) 
        {
            SlotMachine slots = new SlotMachine();
            slots.Show();
            this.Hide();
        }

        public void roulBtnClick(object sender, RoutedEventArgs e) 
        {   
            Roulette roulette = new Roulette();
            roulette.Show();
            this.Hide();
        }


    }
}
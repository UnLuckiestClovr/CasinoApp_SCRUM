using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp_SCRUM
{
    public class GlobalData
    {
        public static UserInfo gUserInfo = new UserInfo();

        public static SlotMachine gSlotMachineWindow = new SlotMachine();
        public static MainWindow gMainMenu = new MainWindow();
        public static Roulette rouletteWindow = new Roulette();
        public static ChipExchange gChipExchangeWindow = new ChipExchange();
    }
}

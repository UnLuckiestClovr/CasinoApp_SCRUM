using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp_SCRUM
{
    public class GeneralFunctions
    {

        // Input Min and Max Number Range to Return Random Number within that Range
        public int returnRandInt(int min, int max)
        {
            if (min < 0 || max < 0 || min >= max) // Returns 0 if number input is below 0 or if the two numbers are equal to each other
            {
                return 0;
            }
            Random random = new Random();
            return random.Next(min, max + 1); // +1 includes the max number in the possible outcomes
        }



    }

    public class UserInfo
    {
        private string username;
        private float currentMoney;
        private int currentChips;

        // Getters / Setters

        public string getUsername()  { return username; }
        public void setUsername(string username) { this.username = username; } 

        public float getCurrentMoney() { return currentMoney; }
        public void setCurrentMoney(float money) { this.currentMoney = money; }

        public int getCurrentChips() {  return currentChips; }
        public void setCurrentChips(int chips) { this.currentChips = chips;}


        // Money Logic | Math

        public void addMoney(float money)
        {
            this.currentMoney += money;
        }

        public void subtractMoney(float money)
        {
            this.currentMoney -= money;
        }

        // Money Logic | Transferring Chips -> Money or Vice Versa

        public void buyChips(int value) // Switch out Money for Chips at values of $1, $5, $10, $50, and $100 ; Intakes the wanted Amount
        {
            switch (value)
            {
                case 1:
                    currentChips += 1;
                    currentMoney -= 1;
                    break;
                case 5:
                    currentChips += 5;
                    currentMoney -= 5;
                    break;
                case 10:
                    currentChips += 10;
                    currentMoney -= 10;
                    break;
                case 25:
                    currentChips += 25;
                    currentMoney -= 25;
                    break;
                case 50:
                    currentChips += 50;
                    currentMoney -= 50;
                    break;
                case 100:
                    currentChips += 100;
                    currentMoney -= 100;
                    break;
                default:
                    break;
            }
        }

        public void tradeInChips(int value) // Switch out Chips for Money at values of $1, $5, $10, $50, and $100 ; Intakes the wanted Amount
        {
            switch (value)
            {
                case 1:
                    currentChips -= 1;
                    currentMoney += 1;
                    break;
                case 5:
                    currentChips -= 5;
                    currentMoney += 5;
                    break;
                case 10:
                    currentChips -= 10;
                    currentMoney += 10;
                    break;
                case 25:
                    currentChips -= 25;
                    currentMoney += 25;
                    break;
                case 50:
                    currentChips -= 50;
                    currentMoney += 50;
                    break;
                case 100:
                    currentChips -= 100;
                    currentMoney += 100;
                    break;
                default:
                    break;
            }
        }
    }
}

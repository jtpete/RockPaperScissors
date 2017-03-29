using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockSissors
{
    class Player
    {
        string name;
        int winCount = 0;
        bool winner = false;
        public void SetName()
        {
            string response;
         
            Console.WriteLine("\nEvery player needs a name, what shall I call you?.\n");
            response = Console.ReadLine();
            switch (response)
            {
                case " ":
                    SetName();
                    break;
                default:
                    name = response;
                    break;
            }
        }
        public string GetName()
        {
            return name;
        }

        public int GetWinCount()
        {
            return winCount;
        }
        public void SetWinCount(int win)
        {
            winCount += win;
        }
        public void SetWinner()
        {
            winner = true;
        }
        public bool Winner()
        {
            return winner;
        }
    }
}

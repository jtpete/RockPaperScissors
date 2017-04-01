using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string response;
            do
            {
                Console.Clear();
                Console.WriteLine(" _______________________________________________ ");
                Console.WriteLine("|                                               |");
                Console.WriteLine("|       Welcome to Paper, Rock, Scissors...     |");
                Console.WriteLine("|                                               |");
                Console.WriteLine("|                  and yes...                   |");
                Console.WriteLine("|                                               |");
                Console.WriteLine("|                Lizard, Spock                  |");
                Console.WriteLine("|_______________________________________________|");
                Console.WriteLine("\nWould you like to begin a game...yes or no?\n");
                response = Console.ReadLine().ToLower();
                if (response == "yes")
                {
                    Game myGame = new Game();
                    myGame.StartGame();
                    if (!myGame.HaveWinner() && response == "yes")
                    {
                        myGame.PlayGame();
                    }
                    myGame.FinishGame();
                }
            } while (response == "yes");
        }
    }
}

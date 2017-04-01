using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Game
    {
        int bestOfCount;
        int gameType;
        bool winner = false;
        Player player1 = new Player("Player1");
        Player player2 = new Player("Player2");
        public void StartGame()
        {
            SetTypeOfGame();
            SetBestOfCount();
            if(gameType == 2)
            {
                DisplayHeader();
                player1.SetName();
                DisplayHeader();
                player2.SetName();
            }
            else
            {
                DisplayHeader();
                player1.SetName();
            }
            
        }
        public void PlayGame()
        {
            if (gameType == 2)
            {
               Match dualMatch = new Match();
               dualMatch.DualMatch(player1, player2, bestOfCount);
            }
            else
            {
                Match compMatch = new Match();
                compMatch.CompMatch(player1, bestOfCount);
            }

        }
        public void FinishGame()
        {
            DisplayHeader();
            if(gameType == 2 && player1.Winner())
            {
                Console.WriteLine($"\nCongratulations {player1.GetName()} you WIN!!\n");
            }
            else if (gameType == 2 && player2.Winner())
            {
                Console.WriteLine($"\nCongratulations {player2.GetName()} you WIN!!\n");
            }
            else if(gameType == 1 && player1.Winner())
            {
                Console.WriteLine($"\nCongratulations {player1.GetName()} you beat Al!!\n");
            }
            else if(gameType == 1 && !player1.Winner())
            {
                Console.WriteLine($"\nOuch! {player1.GetName()} Al crushed you!!\n");

            }
        }
        public bool HaveWinner()
        {
            return winner;
        }
        private void SetBestOfCount()
        {
            DisplayHeader();
            Console.WriteLine("***********************************************");
            Console.WriteLine("*  Best 2 out of 3?  Choose any odd # up to 9.*");
            Console.WriteLine("***********************************************");
            string bestOfResponse = Console.ReadLine(); ;
            switch (bestOfResponse)
            {
                case "1":
                    bestOfCount = 1;
                    break;
                case "3":
                    bestOfCount = 3;
                    break;
                case "5":
                    bestOfCount = 5;
                    break;
                case "7":
                    bestOfCount = 7;
                    break;
                case "9":
                    bestOfCount = 9;
                    break;
                default:
                    SetBestOfCount();
                    break;
            }
        }
        private void SetTypeOfGame()
        {
            DisplayHeader();
            Console.WriteLine("***********************************************");
            Console.WriteLine("*  What type of game would you like to play?  *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("1. Play against AL (the computer).");
            Console.WriteLine("2. Play head-to-head with another person.");
            string response = Console.ReadLine(); ;
            switch (response)
            {
                case "1":
                    gameType = 1;
                    break;
                case "2":
                    gameType = 2;
                    break;
                default:
                    SetTypeOfGame();
                    break;
            }
        }

        private void DisplayHeader()
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
        }
    }
}

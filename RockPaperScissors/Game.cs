using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockSissors
{
    class Game
    {
        int bestOfCount;
        int gameType;
        bool winner = false;
        Player player1 = new Player();
        Player player2 = new Player();
        public void StartGame()
        {
            SetTypeOfGame();
            SetBestOfCount();
            if(gameType == 2)
            {
                player1.SetName();
                player2.SetName();
            }
            else
            {
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

            Console.WriteLine("\nChoose a Best Of Match limit.  Please pick an odd number between 1 and 9");
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
            Console.WriteLine("\nChoose A Game:\n1. Play Against AL\n2. Play Another Person");
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
    }
}

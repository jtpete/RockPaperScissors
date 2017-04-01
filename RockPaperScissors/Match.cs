using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Match
    {
        string player1Pick = " ";
        string player2Pick = " ";
        bool player1win = false;
        bool player2win = false;
        string[] allPicks = { "Rock", "Paper", "Scissors", "Lizard", "Spock" };
        string[,] winTable = new string[5, 3] { { "Rock", "Lizard", "Scissors" }, { "Scissors", "Paper", "Lizard" }, { "Paper", "Rock", "Spock" }, { "Lizard", "Paper", "Spock" }, { "Spock", "Scissors", "Rock" } };


        public void CompMatch(Player person1, int bestOfNum)
        {
            double bestOfLimit = (double)bestOfNum / (double)2;
            bestOfLimit = Math.Ceiling(bestOfLimit);
            int computerWinCount = 0;
            do
            {
                ScoreBoard(person1.GetName(), "AL", person1.GetWinCount(), computerWinCount, bestOfNum, bestOfLimit);
                player1Pick = " ";
                player2Pick = " ";
                player1Pick = GetPlayerPick(person1);
                ScoreBoard(person1.GetName(), "AL", person1.GetWinCount(), computerWinCount, bestOfNum, bestOfLimit);
                player2Pick = GetComputerPick();
                DetermineWinner(winTable);
                computerWinCount = SetCompWinResults(person1, computerWinCount);
            } while (person1.GetWinCount() < bestOfLimit && computerWinCount < bestOfLimit);
            SetCompMatchWinner(person1, bestOfLimit);
        }
        private void SetCompMatchWinner(Player person1, double bestOfLimit)
        {
            if (person1.GetWinCount() == bestOfLimit)
            {
                person1.SetWinner();
            }
        }
        private int SetCompWinResults(Player person1, int compWinCount)
        {
            if (player1win)
            {
                person1.SetWinCount(1);
            }
            else if (player2win)
            {
                compWinCount += 1;
            }
            return compWinCount;
        }
        private void DisplayCompResults(Player person1)
        {
            if (player1win)
            {
                Console.WriteLine($"{person1.GetName()} picks {player1Pick} and beats {player2Pick}");
            }
            else if (player2win)
            {
                Console.WriteLine($"Al picks {player2Pick} and beats {player1Pick}");
            }
            else
            {
                Console.WriteLine($"{person1.GetName()} and Al both pick {player2Pick}.  Let's try again.");
            }

        }
        public void DualMatch(Player person1, Player person2, int bestOfNum)
        {
            double bestOfLimit = (double)bestOfNum / (double)2;
            bestOfLimit = Math.Ceiling(bestOfLimit);
            do
            {
                ScoreBoard(person1.GetName(), person2.GetName(), person1.GetWinCount(), person2.GetWinCount(), bestOfNum, bestOfLimit);
                player1Pick = " ";
                player2Pick = " ";
                player1Pick = GetPlayerPick(person1);
                ScoreBoard(person1.GetName(), person2.GetName(), person1.GetWinCount(), person2.GetWinCount(), bestOfNum, bestOfLimit);
                player2Pick = GetPlayerPick(person2);
                DetermineWinner(winTable);
                setDualWinCount(person1, person2);
            } while (bestOfNum > 1 && person1.GetWinCount() < bestOfLimit && person2.GetWinCount() < bestOfLimit);
            setDualWinner(person1, person2, bestOfLimit);

        }
        private void setDualWinCount(Player person1, Player person2)
        {
            if (player1win)
            {
                person1.SetWinCount(1);
            }
            else if (player2win)
            {
                person2.SetWinCount(1);
            }
        }
        private void setDualWinner(Player person1, Player person2, double bestOfLimit)
        {
            if (person1.GetWinCount() == bestOfLimit)
            {
                person1.SetWinner();
            }
            else
            {
                person2.SetWinner();
            }
        }

        private void DetermineWinner(string[,] winTable)
        {
            player1win = false;
            player2win = false;
            if (player1Pick != player2Pick)
            {
                for (int i = 0; i < winTable.Length; i++)
                {
                    if (player1Pick == winTable[i, 0])
                    {
                        if (player2Pick == winTable[i, 1] || player2Pick == winTable[i, 2])
                        {
                            player1win = true;
                            i = winTable.Length;
                        }
                        else
                        {
                            player2win = true;
                            i = winTable.Length;
                        }
                    }
                }
            }
        }
        private string GetComputerPick()
        {
            Random rand = new Random();
            return allPicks[rand.Next(0, 5)];
        }
        private string GetPlayerPick(Player person)
        {

            string response;

            Console.WriteLine($"\n{person.GetName()}, it is your turn, please pick:\n1. {allPicks[0]}\n2. {allPicks[1]}\n3. {allPicks[2]}\n4. {allPicks[3]}\n5. {allPicks[4]}\n");
            response = Console.ReadLine().ToLower();

            switch (response)
            {
                case "1":
                    Console.Clear();
                    return allPicks[0];
                    break;
                case "2":
                    Console.Clear();
                    return allPicks[1];
                    break;
                case "3":
                    Console.Clear();
                    return allPicks[2];
                    break;
                case "4":
                    Console.Clear();
                    return allPicks[3];
                    break;
                case "5":
                    Console.Clear();
                    return allPicks[4];
                    break;
                default:
                    response = GetPlayerPick(person);
                    return response;
                    break;

            }
        }
        public void ScoreBoard(string name1, string name2, int winCount1, int winCount2, int bestOfNum, double bestOfLimit)
        {
            Console.Clear();
            Console.WriteLine($" _______________________________________________________ ");
            Console.WriteLine($"            Best {bestOfLimit} out of {bestOfNum}        ");
            Console.WriteLine($"                                                         ");
            Console.WriteLine($"        WINS:                   PLAYER:                  ");
            Console.WriteLine($"        {winCount1}                       {name1}        ");
            Console.WriteLine($"----------------------VS.------------------------------- ");
            Console.WriteLine($"        {winCount2}                       {name2}        ");
            Console.WriteLine($"                                                         ");
            Console.WriteLine($"        PICK RESULTS:                                    ");
            Console.WriteLine($"-------------------------------------------------------- ");
            if (player1Pick == " " || player2Pick == " ")
            {
                Console.WriteLine($"                                                      ");
            }
            else if (player1win)
            {
                Console.WriteLine($"        {name1} picks {player1Pick} and beats {player2Pick}");
            }
            else if (player2win)
            {
                Console.WriteLine($"        {name2} picks {player2Pick} and beats {player1Pick}");
            }
            else if(player1Pick == player2Pick)
            {
                Console.WriteLine($"        {name1} and {name2} both pick {player2Pick}.  Let's try again.");
            }
            else
            {
                Console.WriteLine($"                                                         ");
            }
            Console.WriteLine($"________________________________________________________ ");

        }

    }
}

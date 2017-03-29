using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRockSissors
{
    class Match
    {
        string player1Pick;
        string player2Pick;
        bool player1win = false;
        bool player2win = false;
        string[] allPicks = { "Rock", "Paper", "Sissors", "Lizard", "Spock" };
        string[,] winTable = new string[5, 3] { { "Rock", "Lizard", "Sissors" }, { "Sissors", "Paper", "Lizard" }, { "Paper", "Rock", "Spock" }, { "Lizard", "Paper", "Spock" }, { "Spock", "Scissors", "Rock" } };


        public void CompMatch(Player person1, int bestOfNum)
        {
            int computerWinCount = 0;
            do
            {
                player1Pick = GetPlayerPick(person1);
                player2Pick = GetComputerPick();
                DetermineWinner(winTable);
                DisplayCompResults(person1);
                computerWinCount = SetCompWinResults(person1, computerWinCount);
            } while (bestOfNum > 1 && person1.GetWinCount() < bestOfNum-1 && computerWinCount < bestOfNum-1);
            SetCompMatchWinner(person1, bestOfNum);
        }
        private void SetCompMatchWinner(Player person1, int bestOfNum)
        {
            if (bestOfNum == 1 && player1win)
            {
                person1.SetWinner();
            }
            else if (bestOfNum > 1 && person1.GetWinCount() == bestOfNum - 1)
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
            //while (person1.GetWinCount() < bestOfNum && person2.GetWinCount() < bestOfNum)
            do
            {
                player1Pick = GetPlayerPick(person1);
                player2Pick = GetPlayerPick(person2);
                DetermineWinner(winTable);
                DisplayDualResults(person1, person2);
                setDualWinCount(person1, person2);
            } while (bestOfNum > 1 && person1.GetWinCount() < bestOfNum - 1 && person2.GetWinCount() < bestOfNum - 1);
            setDualWinner(person1, person2, bestOfNum);

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
        private void setDualWinner(Player person1, Player person2, int bestOfNum)
        {
            if (bestOfNum == 1 && player1win)
            {
                person1.SetWinner();
            }
            else if(bestOfNum == 1 && player2win)
            {
                person2.SetWinner();
            }
            else if (bestOfNum >1 && person1.GetWinCount() == bestOfNum - 1)
            {
                person1.SetWinner();
            }
            else
            {
                person2.SetWinner();
            }
        }
        private void DisplayDualResults(Player person1, Player person2)
        {
            if (player1win)
            {
                Console.WriteLine($"{person1.GetName()} picks {player1Pick} and beats {player2Pick}");
            }
            else if (player2win)
            {
                Console.WriteLine($"{person2.GetName()} picks {player2Pick} and beats {player1Pick}");
            }
            else
            {
                Console.WriteLine($"{person1.GetName()} and {person2.GetName()} both pick {player2Pick}.  Let's try again.");
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
                    return allPicks[0];
                    break;
                case "2":
                    return allPicks[1];
                    break;
                case "3":
                    return allPicks[2];
                    break;
                case "4":
                    return allPicks[3];
                    break;
                case "5":
                    return allPicks[4];
                    break;
                default:
                    response = GetPlayerPick(person);
                    return response;
                    break;

            }
        }

    }
}

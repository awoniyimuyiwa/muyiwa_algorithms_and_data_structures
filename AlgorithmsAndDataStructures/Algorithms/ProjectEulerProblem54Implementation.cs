using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class ProjectEulerProblem54Implementation
    {
        static readonly Dictionary<char, int> RankToValueMap = new Dictionary<char, int>() {
            {'2', 2}, {'3', 3}, {'4', 4}, {'5', 5}, 
            {'6', 6}, {'7', 7}, {'8', 8}, {'9', 9}, 
            {'T', 10}, {'J', 11}, {'Q', 12}, {'K', 13}, {'A', 14}
        };

        // Club, Diamond, Heart and Ace
        static readonly List<char> Suits = new List<char>() {'C', 'D', 'H', 'S'};

        static Dictionary<char, int> GetRankToCountMap(string[] cards)
        {
            char rank;
            Dictionary<char, int> rankToCountMap = new Dictionary<char, int>();

            foreach (string card in cards)
            {
                rank = card[0];

                if (!rankToCountMap.ContainsKey(rank)) 
                {
                    rankToCountMap.Add(rank, 1);
                }
                else
                {
                    rankToCountMap[rank] += 1;
                }
            }
            
            return rankToCountMap;
        }

        static int[] GetRankValues(string[] cards)
        {
            int[] rankValues = new int[5];
            int rankValuesIndex = 0;
            char rank;

            foreach (string card in cards)
            {
                rank = card[0];
                rankValues[rankValuesIndex] = RankToValueMap[rank];
                rankValuesIndex++;
            }

            return rankValues;
        }

        /// <summary>
        /// Returns true if there are two cards of the same rank, false otherwise
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static bool IsOnePair(string[] cards)
        {
            var rankToCountMap = GetRankToCountMap(cards);

            if (rankToCountMap.Count == 4) { return true; }
            
            return false;
        }

        /// <summary>
        /// Returns true if two cards are of the same rank and another two are of a different rank plus any fifth of a different rank, false otherwise 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static bool IsTwoPairs(string[] cards)
        {
            var rankToCountMap = GetRankToCountMap(cards);
            var pairsCount = 0;

            foreach (char rank in rankToCountMap.Keys)
            {
                if (rankToCountMap[rank] == 2) { pairsCount++; }
            }
            
            if (pairsCount == 2) { return true; }
            return false;
        }

        /// <summary>
        /// Returns true if there are 3 cards of the same rank, false otherwise
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static bool IsThreeOfAKind(string[] cards)
        {
            var rankToCountMap = GetRankToCountMap(cards);

            foreach (char rank in rankToCountMap.Keys)
            {
                if (rankToCountMap[rank] == 3) { return true; }
            }
            
            return false;
        }

        /// <summary>
        /// Returns true if the rank of the cards are consecutive, false otherwise
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static bool IsStraight(string[] cards)
        {
            int[] rankValues = GetRankValues(cards);
            
            Array.Sort(rankValues);

            if (rankValues[0] + 1 == rankValues[1] &&
             rankValues[1] + 1 == rankValues[2] &&
             rankValues[2] + 1 == rankValues[3] &&
             rankValues[3] + 1 == rankValues[4]) 
            {     
                return true; 
            }
            else if (rankValues[0] == 2 &&
             rankValues[1] == 3 &&
             rankValues[2] == 4 &&
             rankValues[3] == 5 &&
             rankValues[4] == 14)
            {
                return true;
            }
            
            return false;
        }
 
        /// <summary>
        /// Returns true when all five cards are of the same suit, false otherwise
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static bool IsFlush(string[] cards)
        {
            List<char> list = new List<char>();
            char suit;
            
            foreach (string card in cards)
            {
                suit = card[1];

                if (!list.Contains(suit)) 
                {
                    list.Add(suit);
                }
            }
    
            if (list.Count == 1) { return true; }
            return false;
        }

        /// <summary>
        /// Returns true when there are three cards of the same rank and two cards of another rank, false otherwise
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static bool IsFullHouse(string[] cards)
        {
            var rankToCountMap = GetRankToCountMap(cards);
            if (rankToCountMap.Count != 2) { return false; }
          
            foreach (char rank in rankToCountMap.Keys)
            {
                if (rankToCountMap[rank] == 3) { return true; }
            }

            return false;
        }

        /// <summary>
        /// Returns true if there are 4 cards of the same rank, false otherwise
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static bool IsFourOfAKind(string[] cards)
        {
            var rankToCountMap = GetRankToCountMap(cards);
            
            foreach (char rank in rankToCountMap.Keys)
            {
                if (rankToCountMap[rank] == 4) { return true; }
            }

            return false;
        }

        /// <summary>
        /// Returns true if cards are straight and flush, false otherwise
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static bool IsStraightFlush(string[] cards)
        {
            if (IsStraight(cards) && IsFlush(cards)) { return true; }

            return false;
        }

        /// <summary>
        /// Retuns true when the cards are all of the same suit (i.e flush) and 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static bool IsRoyalFlush(string[] cards)
        {
            if (!IsFlush(cards)) { return false; }
     
            bool isRoyal = true;
            foreach (string card in cards)
            {
                if (card[0] != 'T' || card[0] != 'J' || card[0] != 'Q' || card[0] != 'K' || card[0] != 'A')
                {
                    isRoyal = false;
                    break;
                }
            }

            return isRoyal;
        }

        static int GetHighestPair(string[] cards)
        {
            int highestPair = 0;
            int value;
            var rankToCountMap = GetRankToCountMap(cards);

            foreach (char rank in rankToCountMap.Keys) 
            {
                value = RankToValueMap[rank];

                if (rankToCountMap[rank] == 2 && highestPair < value)
                {
                    highestPair = value;
                }
            }

            return highestPair;
        }

        /// <summary>
        /// Returns the value of the rank that 3 cards belong to
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static int GetValueOfRankThat3CardsBelongTo(string[] cards)
        {
            var rankToCountMap = GetRankToCountMap(cards);
            
            foreach (char rank in rankToCountMap.Keys)
            {
                if (rankToCountMap[rank] == 3) { return RankToValueMap[rank]; }
            }

            return 0;
        }

        /// <summary>
        /// Returns the value of the rank that 4 cards belong to
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static int GetValueOfRankThat4CardsBelongTo(string[] cards)
        {
            var rankToCountMap = GetRankToCountMap(cards);
           
            foreach (char rank in rankToCountMap.Keys)
            {
                if (rankToCountMap[rank] == 4) { return RankToValueMap[rank]; }
            }

            return 0;
        }

        static int GetScore(string[] cards) 
        {
            int score = 0;

            if (IsRoyalFlush(cards))
            {
                score = 9000;
            }
            else if (IsStraightFlush(cards))
            {
                score = 8000;
            }
            else if (IsFourOfAKind(cards))
            {
                score = 7000 + GetValueOfRankThat4CardsBelongTo(cards);
            }
            else if (IsFullHouse(cards))
            {
                score = 6000 + GetValueOfRankThat3CardsBelongTo(cards);
            }
            else if (IsFlush(cards))
            {
                score = 5000;
            }
            else if (IsStraight(cards))
            {
                score = 4000;
            }
            else if (IsThreeOfAKind(cards))
            {
                score = 3000 + GetValueOfRankThat3CardsBelongTo(cards);
            }
            else if (IsTwoPairs(cards))
            {
                score = 2000 + GetHighestPair(cards);
            }
            else if (IsOnePair(cards))
            {
                score = 1000 + GetHighestPair(cards);
            }
            
            return score;
        }

        static bool IsValidCards(string[] cards)
        {
            if (cards.Length > 5 || cards.Length < 5) 
            {
                Console.WriteLine("Cards must be 5");
                return false;
            }
    
            foreach (string s in cards)
            {
                if (s.Length < 2 || s.Length > 2) 
                {
                    Console.WriteLine($"{s} must be two characters");
                    return false; 
                }

                if (!RankToValueMap.ContainsKey(s[0])) 
                {
                    Console.WriteLine($"{s[0]} is not a valid rank");
                    return false; 
                }

                if (!Suits.Contains(s[1])) 
                {
                    Console.WriteLine($"{s[1]} is not a valid suit");
                    return false; 
                }
            }

            return true;
        }

        public static void Run(string[] args) 
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******PROJECT EULER PROBLEM 54*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGiven 5 cards each for two players in a game of poker, determines which of the two players is the winner");
            Console.WriteLine("Each card should be a string of 2 characters. The first character represents the card's rank, the second character represents the card's suit");
            Console.WriteLine($"Valid ranks are: {String.Join(", ", RankToValueMap.Keys)}. Where T is for Ten, J for Jack, Q for Queen, K for King, and A is for Ace");
            Console.WriteLine($"Valid suits are: {String.Join(", ", Suits)}. Where C is for Club, D is for Diamond, H is for Heart and S is for Spades");
            Console.WriteLine("Cards should be separated by comma and space e.g 2S, 3D, 4H, 9C, QH:");
            
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\nEnter 5 cards for player 1:");
            string cardsInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            // Validate input 
            if (string.IsNullOrEmpty(cardsInput))
            {
                Console.WriteLine($"ERROR: Input must be a valid string");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }
            
            var hand1 = cardsInput.Split(", ");
            if (!IsValidCards(hand1)) 
            {
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }
            
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\nEnter 5 cards for player 2:");
            cardsInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrEmpty(cardsInput))
            {
                Console.WriteLine($"ERROR: Input must be a valid string");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            var hand2 = cardsInput.Split(", ");
            if (!IsValidCards(hand2)) 
            {
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nExecuting...");
            Console.ForegroundColor = ConsoleColor.Green;

            // Execute and dispaly result
            int player1Score = GetScore(hand1);
            int player2Score = GetScore(hand2);

            //Console.WriteLine($"player1Score: {player1Score} player2Score: {player2Score}");

            if (player1Score > player2Score) 
            {
                Console.WriteLine("\nPlayer 1 wins!");
            } 
            else if (player2Score > player1Score) 
            {
                Console.WriteLine("\nPlayer 2 wins!");
            }
            else 
            {
                int[] player1RankValues = GetRankValues(hand1);
                int[] player2RankValues = GetRankValues(hand2);

                Array.Sort(player1RankValues);
                Array.Sort(player2RankValues);

                // Start from the highest rank values which will be the last item after sorting
                int index = 4;

                while ((player1RankValues[index] == player2RankValues[index]) && index > 0)
                {
                    index--;
                }

                if (player1RankValues[index] > player2RankValues[index])
                {
                    Console.WriteLine("\nPlayer 1 Wins!");
                }
                else if (player2RankValues[index] > player1RankValues[index])
                {
                    Console.WriteLine("\nPlayer 2 Wins!");
                }
                else
                {
                    Console.WriteLine("\nTIE. No Winner!");
                }
            } 

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF PROJECT EULER PROBLEM 54*******\n");
        }
    }
}
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms
{
    /// <summary>
    /// https://projecteuler.net/problem=54
    /// </summary>
    class ProjectEulerProblem54Implementation
    {
        static readonly Dictionary<char, int> RankToValueMap = new Dictionary<char, int>() {
            {'2', 2}, {'3', 3}, {'4', 4}, {'5', 5}, 
            {'6', 6}, {'7', 7}, {'8', 8}, {'9', 9}, 
            {'T', 10}, {'J', 11}, {'Q', 12}, {'K', 13}, {'A', 14}
        };

        // Club, Diamond, Heart and Spade
        static readonly List<char> Suits = new List<char>() {'C', 'D', 'H', 'S'};

        enum Score 
        {
            OnePair,
            TwoPairs,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }

        static Dictionary<char, int> GetRankToCountMap(string[] cards)
        {
            char rank;
            var rankToCountMap = new Dictionary<char, int>();

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
            var rankValues = new int[5];
            int index = 0;
            char rank;

            foreach (string card in cards)
            {
                rank = card[0];
                rankValues[index] = RankToValueMap[rank];
                index++;
            }

            return rankValues;
        }

        /// <summary>
        /// Returns true if there are two cards of the same rank, false otherwise
        /// </summary>
        /// <param name="rankToCountMap"></param>
        /// <returns></returns>
        static bool IsOnePair(Dictionary<char, int> rankToCountMap)
        {
            if (rankToCountMap.Count == 4) { return true; }
            return false;
        }

        /// <summary>
        /// Returns true if two cards are of the same rank and another two are of a different rank plus any fifth of a different rank, false otherwise 
        /// </summary>
        /// <param name="rankToCountMap"></param>
        /// <returns></returns>
        static bool IsTwoPairs(Dictionary<char, int> rankToCountMap)
        {
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
        /// <param name="rankToCountMap"></param>
        /// <returns></returns>
        static bool IsThreeOfAKind(Dictionary<char, int> rankToCountMap)
        {
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
            var rankValues = GetRankValues(cards);
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
            var firstSuit = cards[0][1];
            
            for (int index = 1; index<=cards.Length-1; index++)
            {
                if (firstSuit != cards[index][1]) { return false; }
            }
    
            return true;
        }

        /// <summary>
        /// Returns true when there are three cards of the same rank and two cards of another rank, false otherwise
        /// </summary>
        /// <param name="rankToCountMap"></param>
        /// <returns></returns>
        static bool IsFullHouse(Dictionary<char, int> rankToCountMap)
        {
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
        /// <param name="rankToCountMap"></param>
        /// <returns></returns>
        static bool IsFourOfAKind(Dictionary<char, int> rankToCountMap)
        { 
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
        /// Retuns true when the cards are all of the same suit (i.e flush) and the rank of each card is either T, J, Q, K or A. Returns false otherwise
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        static bool IsRoyalFlush(string[] cards)
        {
            if (!IsFlush(cards)) { return false; }
     
            foreach (string card in cards)
            {
                if (card[0] != 'T' || card[0] != 'J' || card[0] != 'Q' || card[0] != 'K' || card[0] != 'A')
                {
                   return false;
                }
            }

            return true;
        }

        static int GetScore(string[] cards) 
        {
            var rankToCountMap = GetRankToCountMap(cards);

            if (IsRoyalFlush(cards))
            {
                return (int)Score.RoyalFlush;
            }
            else if (IsStraightFlush(cards))
            {
                return (int)Score.StraightFlush;
            }
            else if (IsFourOfAKind(rankToCountMap))
            {
               return (int)Score.FourOfAKind;
            }
            else if (IsFullHouse(rankToCountMap))
            {
                return (int)Score.FullHouse;
            }
            else if (IsFlush(cards))
            {
                return (int)Score.Flush;
            }
            else if (IsStraight(cards))
            {
               return (int)Score.Straight;
            }
            else if (IsThreeOfAKind(rankToCountMap))
            {
                return (int)Score.ThreeOfAKind;
            }
            else if (IsTwoPairs(rankToCountMap))
            {
               return (int)Score.TwoPairs;
            }
            else if (IsOnePair(rankToCountMap))
            {
                return (int)Score.OnePair;
            }

            return 0;
        }

        static int[] GetPairedRankValues(Dictionary<char, int> rankToCountMap)
        {
            var pairedRankValues = new int[2];
            var index = 0;
            int value;

            foreach (char rank in rankToCountMap.Keys) 
            {
                value = RankToValueMap[rank];

                if (rankToCountMap[rank] == 2)
                {
                    pairedRankValues[index] = value;
                    index++;
                }
            }

            return pairedRankValues;
        }

        /// <summary>
        /// Returns the value of the rank that 2 cards belong to
        /// </summary>
        /// <param name="rankToCountMap"></param>
        /// <returns></returns>
        static int GetValueOfRankThat2CardsBelongTo(Dictionary<char, int> rankToCountMap)
        {
            foreach (char rank in rankToCountMap.Keys)
            {
                if (rankToCountMap[rank] == 2) { return RankToValueMap[rank]; }
            }

            return 0;
        }

        /// <summary>
        /// Returns the value of the rank that 3 cards belong to
        /// </summary>
        /// <param name="rankToCountMap"></param>
        /// <returns></returns>
        static int GetValueOfRankThat3CardsBelongTo(Dictionary<char, int> rankToCountMap)
        {
            foreach (char rank in rankToCountMap.Keys)
            {
                if (rankToCountMap[rank] == 3) { return RankToValueMap[rank]; }
            }

            return 0;
        }

        /// <summary>
        /// Returns the value of the rank that 4 cards belong to
        /// </summary>
        /// <param name="rankToCountMap"></param>
        /// <returns></returns>
        static int GetValueOfRankThat4CardsBelongTo(Dictionary<char, int> rankToCountMap)
        {
            foreach (char rank in rankToCountMap.Keys)
            {
                if (rankToCountMap[rank] == 4) { return RankToValueMap[rank]; }
            }

            return 0;
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

            Console.WriteLine("*******PROJECT EULER PROBLEM 54: https://projecteuler.net/problem=54*******");
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
            var player1Score = GetScore(hand1);
            var player2Score = GetScore(hand2);
            var isTie = true;

            //Console.WriteLine($"player1Score: {player1Score} player2Score: {player2Score}");

            if (player1Score > player2Score) 
            {
                Console.WriteLine("\nPlayer 1 wins!");
                isTie = false;
            } 
            else if (player2Score > player1Score) 
            {
                Console.WriteLine("\nPlayer 2 wins!");
                isTie = false;
            }
            else if (player1Score == (int)Score.OnePair && player2Score == (int)Score.OnePair) 
            { 
                var rankToCountMap = GetRankToCountMap(hand1);
                player1Score = GetValueOfRankThat2CardsBelongTo(rankToCountMap);

                rankToCountMap = GetRankToCountMap(hand2);
                player2Score = GetValueOfRankThat2CardsBelongTo(rankToCountMap);  
            }
            else if (player1Score == (int)Score.TwoPairs && player2Score == (int)Score.TwoPairs) 
            {
                var pairedRankValuesPlayer1 = GetPairedRankValues(GetRankToCountMap(hand1));
                var pairedRankValuesPlayer2 = GetPairedRankValues(GetRankToCountMap(hand2));
                Array.Sort(pairedRankValuesPlayer1);
                Array.Sort(pairedRankValuesPlayer2);

                player1Score = pairedRankValuesPlayer1[1];
                player2Score = pairedRankValuesPlayer2[1];

                if (player1Score == player2Score) 
                {
                   player1Score = pairedRankValuesPlayer1[0];
                   player2Score = pairedRankValuesPlayer2[0]; 
                }
            }
            else if (player1Score == (int)Score.ThreeOfAKind && player2Score == (int)Score.ThreeOfAKind) 
            {
                var rankToCountMap = GetRankToCountMap(hand1);
                player1Score = GetValueOfRankThat3CardsBelongTo(rankToCountMap);

                rankToCountMap = GetRankToCountMap(hand2);
                player2Score = GetValueOfRankThat3CardsBelongTo(rankToCountMap);
            }
            else if (player1Score == (int)Score.FourOfAKind && player2Score == (int)Score.FourOfAKind) 
            {
                var rankToCountMap = GetRankToCountMap(hand1);
                player1Score = GetValueOfRankThat4CardsBelongTo(rankToCountMap);

                rankToCountMap = GetRankToCountMap(hand2);
                player2Score = GetValueOfRankThat4CardsBelongTo(rankToCountMap);
            }
            else if (player1Score == (int)Score.FullHouse && player2Score == (int)Score.FullHouse) 
            {
                var rankToCountMapPlayer1 = GetRankToCountMap(hand1);
                player1Score = GetValueOfRankThat3CardsBelongTo(rankToCountMapPlayer1);

                var rankToCountMapPlayer2 = GetRankToCountMap(hand2);
                player2Score = GetValueOfRankThat3CardsBelongTo(rankToCountMapPlayer2);

                if (player1Score == player2Score) 
                {
                   player1Score = GetValueOfRankThat2CardsBelongTo(rankToCountMapPlayer1);
                   player2Score = GetValueOfRankThat2CardsBelongTo(rankToCountMapPlayer2);
                }
            }

            // Try to determine winner again
            if (isTie) 
            {
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
                    // Finally try to resolve tie by comparing value of ranks
                    var player1RankValues = GetRankValues(hand1);
                    var player2RankValues = GetRankValues(hand2);
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
            }

            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine("\n*******END OF PROJECT EULER PROBLEM 54*******\n");
        }
    }
}
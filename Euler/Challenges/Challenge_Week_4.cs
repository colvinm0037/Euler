using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Challenges
{
    class Challenge_Week_4
    {
        const int HIGH_CARD = 1;
        const int ONE_PAIR = 2;
        const int TWO_PAIR = 3;
        const int THREE_OF_A_KIND = 4;
        const int STRAIGHT = 5;
        const int FLUSH = 6;
        const int FULL_HOUSE = 7;
        const int FOUR_OF_A_KIND = 8;
        const int STRAIGHT_FLUSH = 9;
        const int ROYAL_FLUSH = 10;

        public interface IHandStrategy
        {
            Rank GetRank(List<Card> hand);
        }

        List<IHandStrategy> strategies = new List<IHandStrategy>
{
	new RoyalFlushStrategy(), new StraightFlushStrategy(), new FourOfAKindStrategy(), new FullHouseStrategy(), new FlushStrategy(),
	new StraightStrategy(),	new ThreeOfAKindStrategy(), new TwoPairStrategy(), new PairStrategy(), new HighCardStrategy()		
};

        void Main()
        {
            LevelOne();
            LevelTwo();
        }

        void LevelOne()
        {
            String line;

            int gamesWon = 0;
            int handSize = 5;

            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\COLVINM\\Documents\\LINQPad Queries\\poker.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<String> cards = line.Split(' ').ToList();
                        bool result = doesPlayerOneWin(cards, handSize);
                        if (result)
                            gamesWon++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Level one: Player One won " + gamesWon + " games!");
        }

        void LevelTwo()
        {
            String line1;
            String line2;
            int gamesWon = 0;
            int handSize = 10;

            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\COLVINM\\Documents\\LINQPad Queries\\poker.txt"))
                {
                    while ((line1 = sr.ReadLine()) != null)
                    {
                        line2 = sr.ReadLine();

                        List<String> cards1 = line1.Split(' ').ToList();
                        List<String> cards2 = line2.Split(' ').ToList();
                        List<String> cards = new List<String>();
                        cards.AddRange(cards1);
                        cards.AddRange(cards2);

                        bool result = doesPlayerOneWin(cards, handSize);
                        if (result)
                            gamesWon++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Level two: Player One won " + gamesWon + " games!");
        }

        bool doesPlayerOneWin(List<String> cards, int handSize)
        {
            List<Card> handOne = new List<Card>();
            List<Card> handTwo = new List<Card>();
            buildHands(handOne, handTwo, cards, handSize);

            Rank playerOneResult = play(handOne);
            Rank playerTwoResult = play(handTwo);

            if (playerOneResult.RankType > playerTwoResult.RankType)
            {
                // Player One wins
                return true;
            }
            else if (playerOneResult.RankType == playerTwoResult.RankType)
            {
                // Both players have same type of hand, i.e. Full House, Straight, etc.		
                if (playerOneResult.Value > playerTwoResult.Value)
                {
                    // Player One wins with a better version of the type of hand
                    return true;
                }
                else if (playerOneResult.Value == playerTwoResult.Value)
                {
                    // Have to check high cards until winner is found
                    for (int i = 0; i < 5; i++)
                    {
                        if (playerOneResult.SortedHand[i].Value > playerTwoResult.SortedHand[i].Value)
                        {
                            // Player One wins with higher card					
                            return true;
                        }
                        else if (playerOneResult.SortedHand[i].Value < playerTwoResult.SortedHand[i].Value)
                        {
                            // Player Two wins with a higher card
                            return false;
                        }
                    }
                }
            }

            // Player Two wins or a draw
            return false;
        }

        void buildHands(List<Card> handOne, List<Card> handTwo, List<String> cards, int handSize)
        {
            // Split list of cards into two hands according to size of hand being used
            int cardNumber = 1;
            foreach (String s in cards)
            {
                if (cardNumber < handSize + 1)
                    handOne.Add(new Card(s[0], s[1]));
                else
                    handTwo.Add(new Card(s[0], s[1]));
                cardNumber++;
            }
        }

        Rank play(List<Card> hand)
        {
            Rank result = null;

            // Go through each strategy until something is found, i.e. Full House. (Check best possible hand first)
            foreach (var strategy in strategies)
            {
                result = strategy.GetRank(hand);
                if (result.Value != 0)
                    return result;
            }

            return result;
        }

        static List<Card> RemoveCardsFromHand(List<Card> hand, int cardValue, int quanity, List<Card> bestHand)
        {
            List<Card> reducedHand = new List<Card>();

            int counter = 0;
            foreach (Card c in hand)
            {
                if (c.Value == cardValue)
                {
                    counter++;
                    if (counter <= quanity)
                        bestHand.Add(c);
                    if (counter > quanity)
                        reducedHand.Add(c);
                }
                else
                    reducedHand.Add(c);
            }
            return reducedHand.OrderByDescending(x => x.Value).ToList(); // Return reduced hand in sorted order
        }

        static int FindSetOfAKind(List<Card> hand, int quanity)
        {
            // Determine if hand has a pair, three of a kind, or four of a kind

            int valueFound = 0; // EX: Set to 5 if 5's were found
            for (int i = 14; i > 0; i--)
            {
                if (hand.Count(x => x.Value == i) >= quanity)
                {
                    valueFound = i;
                    break;
                }
            }

            return valueFound;
        }

        public class HighCardStrategy : IHandStrategy
        {
            public Rank GetRank(List<Card> hand)
            {
                List<Card> bestHand = hand.OrderByDescending(x => x.Value).ToList();
                while (bestHand.Count > 5)
                    bestHand.RemoveAt(bestHand.Count - 1);

                return new Rank(HIGH_CARD, bestHand.First().Value, bestHand);
            }
        }

        public class PairStrategy : IHandStrategy
        {
            public Rank GetRank(List<Card> hand)
            {
                // Find the pair
                int pairValue = FindSetOfAKind(hand, 2);

                // Rank hand so that pair is first followed by next three highest cards
                IEnumerable<Card> sortedHand = hand.OrderByDescending(x => x.Value);
                List<Card> bestHand = new List<Card>();

                int pairValueCounter = 0;
                int nonPairValueCounter = 0;
                foreach (Card c in sortedHand)
                {
                    if (c.Value == pairValue && pairValueCounter < 2)
                    {
                        pairValueCounter++;
                        bestHand.Add(c);
                    }

                    if (c.Value != nonPairValueCounter)
                    {
                        nonPairValueCounter++;
                        bestHand.Add(c);
                    }
                    if (nonPairValueCounter == 3)
                        break;
                }

                return new Rank(ONE_PAIR, pairValue, bestHand);
            }
        }

        public class TwoPairStrategy : IHandStrategy
        {
            public Rank GetRank(List<Card> hand)
            {
                // Find two of a kind
                int firstPairValue = FindSetOfAKind(hand, 2);
                if (firstPairValue == 0)
                    return new Rank(TWO_PAIR, 0, hand);

                // Remove the first pair from the hand and put them in bestHand
                List<Card> bestHand = new List<Card>();
                List<Card> reducedHand = RemoveCardsFromHand(hand, firstPairValue, 2, bestHand);

                // Find two of a kind using reducedHand
                int secondPairValue = FindSetOfAKind(reducedHand, 2);

                // Remove the second pair from the hand and put them in bestHand
                reducedHand = RemoveCardsFromHand(reducedHand, secondPairValue, 2, bestHand);

                // Add the highest remaining card to the besthand
                bestHand.Add(reducedHand[0]);

                if (firstPairValue != 0 && secondPairValue != 0)
                {
                    return new Rank(TWO_PAIR, firstPairValue, bestHand);
                }
                else
                    return new Rank(TWO_PAIR, 0, bestHand);
            }
        }

        public class ThreeOfAKindStrategy : IHandStrategy
        {
            public Rank GetRank(List<Card> hand)
            {
                // Find three of a kind
                int tripletValue = FindSetOfAKind(hand, 3);

                // return if not found
                if (tripletValue == 0)
                    return new Rank(THREE_OF_A_KIND, 0, hand);

                // Remove the three cards and put in bestHand
                List<Card> bestHand = new List<Card>();
                List<Card> reducedHand = RemoveCardsFromHand(hand, tripletValue, 2, bestHand);

                // Put the remaining two highest cards in best hand
                bestHand.Add(reducedHand[0]);
                bestHand.Add(reducedHand[1]);

                return new Rank(THREE_OF_A_KIND, tripletValue, bestHand);
            }
        }

        public class StraightStrategy : IHandStrategy
        {
            public Rank GetRank(List<Card> hand)
            {
                List<Card> orderedHand = hand.OrderByDescending(x => x.Value).ToList();
                Rank result = new Rank(STRAIGHT, 0, hand);
                int max = 0;
                int loops = hand.Count - 4;

                /* Count ace's as low and high for straights (Disabled)
                foreach (Card c in hand)
                {
                    if (c.Value == 14)
                    {
                        orderedHand.Add(new Card('1', c.Suit));
                        loops++;		
                    }
                } */

                for (int i = 0; i < loops; i++)
                {
                    List<Card> straight = new List<Card>();
                    straight.Add(orderedHand[i]);

                    for (int k = i + 1; k < orderedHand.Count; k++)
                    {
                        if (orderedHand[k].Value == straight.Last().Value - 1)
                        {
                            straight.Add(orderedHand[k]);
                        }
                    }

                    if (straight.Count >= 5)
                    {
                        while (straight.Count > 5)
                            straight.RemoveAt(straight.Count - 1);

                        if (straight.First().Value > max)
                        {
                            max = straight.First().Value;
                            result = new Rank(STRAIGHT, max, straight);
                        }
                    }
                }

                return result;
            }
        }

        public class FlushStrategy : IHandStrategy
        {
            public Rank GetRank(List<Card> hand)
            {
                Rank result = new Rank(FLUSH, 0, hand);
                char[] SUITS = new char[] { 'C', 'D', 'H', 'S' };
                int max = 0;

                foreach (char suit in SUITS)
                {
                    if (hand.Count(x => x.Suit == suit) >= 5)
                    {
                        // Hand has flush, get value of highest card in flush
                        List<Card> flush = hand.Where(x => x.Suit == suit).ToList();
                        List<Card> sortedFlush = flush.OrderBy(x => x.Value).Reverse().ToList();

                        while (sortedFlush.Count > 5)
                            sortedFlush.RemoveAt(sortedFlush.Count - 1);

                        if (sortedFlush.First().Value > max)
                        {
                            max = sortedFlush.First().Value;
                            result = new Rank(FLUSH, max, sortedFlush);
                        }
                    }
                }

                return result;
            }
        }

        public class FullHouseStrategy : IHandStrategy
        {
            public Rank GetRank(List<Card> hand)
            {
                int tripletValue = FindSetOfAKind(hand, 3);
                if (tripletValue == 0)
                    return new Rank(FULL_HOUSE, 0, hand);

                // Remove those three cards from hand and put in finalHand
                List<Card> finalHand = new List<Card>();
                List<Card> reducedHand = RemoveCardsFromHand(hand, tripletValue, 3, finalHand);

                // Find the pair
                int pairValue = FindSetOfAKind(reducedHand, 2);
                if (pairValue == 0)
                    return new Rank(FULL_HOUSE, 0, hand);

                // Remove those two cards from hand and put in finalHand
                reducedHand = RemoveCardsFromHand(hand, pairValue, 2, finalHand);
                return new Rank(FULL_HOUSE, tripletValue, finalHand);
            }
        }

        public class FourOfAKindStrategy : IHandStrategy
        {
            public Rank GetRank(List<Card> hand)
            {
                // Find the four of a kind
                int cardValue = FindSetOfAKind(hand, 4);
                if (cardValue == 0)
                    return new Rank(FOUR_OF_A_KIND, 0, hand);

                List<Card> finalHand = new List<Card>();
                List<Card> reducedHand = RemoveCardsFromHand(hand, cardValue, 4, finalHand);
                finalHand.Add(reducedHand[0]);
                return new Rank(FOUR_OF_A_KIND, cardValue, finalHand);
            }
        }

        public class StraightFlushStrategy : IHandStrategy
        {
            public Rank GetRank(List<Card> hand)
            {
                Rank result = new Rank(STRAIGHT_FLUSH, 0, hand);
                char[] SUITS = new char[] { 'C', 'D', 'H', 'S' };
                int max = 0;

                // For each of the suits
                foreach (char suit in SUITS)
                {
                    // If five or more cards of suit in hand
                    if (hand.Count(x => x.Suit == suit) >= 5)
                    {
                        // Grab every card in the suit
                        List<Card> suitCards = hand.Where(x => x.Suit == suit).ToList();

                        // Check if a straight can be made with these cards
                        Rank straightResult = new StraightStrategy().GetRank(suitCards);

                        if (straightResult.Value != 0)
                        {
                            // There is a straight 
                            if (straightResult.Value > max)
                            {
                                result = new Rank(STRAIGHT_FLUSH, straightResult.Value, straightResult.SortedHand);
                                max = straightResult.Value;
                            }
                        }
                    }
                }

                return result;
            }
        }

        public class RoyalFlushStrategy : IHandStrategy
        {
            public Rank GetRank(List<Card> hand)
            {
                Rank result = new StraightFlushStrategy().GetRank(hand);
                if (result.Value == 14)
                    return new Rank(ROYAL_FLUSH, 14, result.SortedHand);
                else
                    return new Rank(ROYAL_FLUSH, 0, hand);
            }
        }

        public class Card
        {
            public int Value { get; set; }
            public char Suit { get; set; }

            public Card(char value, char suit)
            {
                if (value == 'T')
                    this.Value = 10;
                else if (value == 'J')
                    this.Value = 11;
                else if (value == 'Q')
                    this.Value = 12;
                else if (value == 'K')
                    this.Value = 13;
                else if (value == 'A')
                    this.Value = 14;
                else
                    this.Value = (int)Char.GetNumericValue(value);
                this.Suit = suit;
            }
        }

        public class Rank
        {
            public int RankType { get; set; }
            public int Value { get; set; }
            public List<Card> SortedHand { get; set; }

            public Rank(int rank, int value, List<Card> sortedHand)
            {
                this.RankType = rank;
                this.Value = value;
                this.SortedHand = sortedHand;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            bool restart = true;
            while (restart)
            {
                Console.WriteLine("Welcome to BlackJack, hit any key to play a round of BlackJack...");
                Console.ReadKey();

                BlackJackService blackJackService = new BlackJackService();
                blackJackService.ProcessBlackJackRound(GetDealer(), CreatePlayers());

                Console.ReadKey();
            }
        }
        private static Dealer GetDealer()
        {
            Dealer dealer = Dealer.GetDealerInstance();

            dealer.DealtCards = new List<Card>() {
                new Card() { Suit = CardSuit.Spades, CardValue = CardValue.Jack },
                new Card() { Suit = CardSuit.Hearts, CardValue = CardValue.Nine } };
          
            return dealer;
        }

         private static List<Player> CreatePlayers()
         {
            List<Player> players = new List<Player>();
     
            players.Add(new Player() { Name = "Billy", Id = 1, DealtCards = new List<Card>() { 
                new Card() { Suit = CardSuit.Spades, CardValue = CardValue.Two }, 
                new Card() { Suit = CardSuit.Diamonds, CardValue = CardValue.Two },
                new Card() { Suit = CardSuit.Hearts, CardValue = CardValue.Two }, 
                new Card() { Suit = CardSuit.Diamonds, CardValue = CardValue.Four }, 
                new Card() { Suit = CardSuit.Clubs, CardValue = CardValue.Five}}});
           
            players.Add(new Player() { Name = "Lemmy", Id = 2, DealtCards = new List<Card>() {
                new Card() { Suit = CardSuit.Spades, CardValue = CardValue.Ace },
                new Card() { Suit = CardSuit.Hearts, CardValue = CardValue.Seven },
                new Card() { Suit = CardSuit.Diamonds, CardValue = CardValue.Ace }}});
            
            players.Add(new Player() { Name = "Andrew", Id = 3, DealtCards = new List<Card>() {
                new Card() { Suit = CardSuit.Diamonds, CardValue = CardValue.King },
                new Card() { Suit = CardSuit.Spades, CardValue = CardValue.Four },
                new Card() { Suit = CardSuit.Clubs, CardValue = CardValue.Four }}
            });

            players.Add(new Player() { Name = "Carla", Id = 4, DealtCards = new List<Card>() {
                new Card() { Suit = CardSuit.Clubs, CardValue = CardValue.Queen },
                new Card() { Suit = CardSuit.Spades, CardValue = CardValue.Six },
                new Card() { Suit = CardSuit.Diamonds, CardValue = CardValue.Nine }}
            });

            return players;
        }

    }

    public class Card
    {
        public CardSuit Suit { get; set; }
        private const int ROYALTY_CARD_VALUE = 10;
        public int Value {
            get
            {
                if (CardValue == CardValue.Jack || CardValue == CardValue.Queen || CardValue == CardValue.King)
                    return ROYALTY_CARD_VALUE;
                else
                    return (int)CardValue;
            }
        }
        public CardValue CardValue { get; set; }        
    }

    public abstract class Cards
    {
        public int Hand { get; set; }
        public List<Card> DealtCards { get; set; }
    }

 
    public class Dealer : Cards
    {
        private static Dealer dealer = new Dealer();

        private Dealer() {
            Name = "Dealer";
        }

        public string Name { get; }

        public static Dealer GetDealerInstance()
        {
            return dealer;
        }
    }

    public class Player: Cards
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public string Code
        {
            get
            {
                return Name + "_" + Id;
            }
        }

        public bool IsWinner { get; set; }
    }


    public enum CardSuit
    {
        Hearts = 1,
        Spades = 2,
        Clubs = 3,
        Diamonds = 4
    }

    public enum CardValue
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

}


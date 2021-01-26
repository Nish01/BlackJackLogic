using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class BlackJackService
    {

        private BlackJackRulesService rulesService;
        public BlackJackService()
        {
            rulesService = new BlackJackRulesService();
        }

        public void ProcessBlackJackRound(Dealer dealer, List<Player> players)
        {
            ProcessHands(dealer, players);

            rulesService.DetermineWinners(dealer.Hand, players);

            PrintResults(dealer, players);
        }

        private void ProcessHands(Dealer dealer, List<Player> players)
        {
            dealer.Hand = rulesService.CalculateHands(dealer.DealtCards);

            foreach (Player player in players)
                player.Hand = rulesService.CalculateHands(player.DealtCards);           
        }

        private void PrintResults(Dealer dealer, List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine($"The {dealer.Name} had the following cards:");

            PrintCards(dealer.DealtCards);
            PrintHand(dealer.Name, dealer.Hand);

            foreach (Player player in players)
            {
                Console.WriteLine();
                string result = player.IsWinner ? "WINS and beats the Dealer" : "loses";
                Console.WriteLine($"{player.Name} {result} with the following cards:");
                
                PrintCards(player.DealtCards);
                PrintHand(player.Name, player.Hand);
                
                if (player.IsWinner)
                    Console.WriteLine($"More money for {player.Name}! Yay!");
            }
        }

        private void PrintCards(List<Card> cards)
        {
            foreach (Card card in cards)
                Console.WriteLine($"{card.CardValue} of {card.Suit}");
        }

        private void PrintHand(string name, int hand)
        {
            Console.WriteLine($"Total value of {name}'s hand: {hand}");
        }
    }
}

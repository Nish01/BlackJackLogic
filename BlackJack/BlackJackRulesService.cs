using System.Collections.Generic;

namespace BlackJack
{
    public class BlackJackRulesService : IBlackJackRulesService
    {
        public BlackJackRulesService()
        {
        }

        public int CalculateHands(List<Card> cards)
        {
            int acesCount = 0;
            int sum = 0;

            foreach (Card card in cards)
            {
                if (card.CardValue == CardValue.Ace)
                    acesCount++;

                sum += card.Value;
            }

            if (sum < 12 && acesCount > 0)
            {
                sum += 10;
                //for (int i = 0; i < acesCount; i++)
                //{
                //    int prevSum = sum;
                //    sum += 10;
                //    if (sum > 21)
                //    {
                //        sum = prevSum;
                //        i = acesCount;
                //    }
                //}
            }

            return sum;
        }

        public void DetermineWinners(int dealerHand, List<Player> players)
        {
            foreach (Player player in players)
            {
                player.IsWinner = false;

                if (player.DealtCards.Count == 5 && player.Hand <= 21)
                    player.IsWinner = true;
                
                if (player.Hand <= 21 && player.Hand >= dealerHand)
                    player.IsWinner = true;
            }           
        }
    }
}

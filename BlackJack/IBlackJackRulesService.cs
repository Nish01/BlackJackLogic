using System.Collections.Generic;

namespace BlackJack
{
    public interface IBlackJackRulesService
    {
        int CalculateHands(List<Card> cards);
        void DetermineWinners(int dealerHand, List<Player> players);
    }
}
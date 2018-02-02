using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Deck
    {
        Random random = new Random();
        private List<ICard> _cards = new List<ICard>();

        public Deck(uint size)
        {
            for (int i = 1; i <= size; i++)
            {
                int suit = random.Next(1, 4);
                int number = random.Next(1, 8);

                switch(suit)
                {
                    case 1:
                        var red = new RedCard(number);
                        _cards.Add(red);
                        break;
                    case 2:
                        var blue = new BlueCard(number);
                        _cards.Add(blue);
                        break;
                    case 3:
                        var green = new GreenCard(number);
                        _cards.Add(green);
                        break;
                    case 4:
                        var yellow = new YellowCard(number);
                        _cards.Add(yellow);
                        break;
                    default:
                        Console.WriteLine("Default case handler! Maybe I should be an exception?");
                        break;
                }
            }
        }
        public void DealCards(IPlayer player, int number)
        {
            for (int i = 1; i <= number; i++)
            {
                var temp = _cards.Count;
                player.DealCard(_cards[temp]);
                _cards.RemoveAt(temp);
            }
        }
    }
}

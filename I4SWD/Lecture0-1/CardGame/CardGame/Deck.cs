using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Deck
    {
        Random random = new Random();
        private stack<ICard> _cards;

        public Deck(uint size)
        {
            for (int i = 1; i <= size; i++)
            {
                int suit = random.Next(1, 4);
                int number = random.Next(1, 8);

                switch(ran)
                {
                    case 1:
                        _cards.Push(RedCard(number));
                        break;
                    case 2:
                        _cards.Push(BlueCard(number));
                        break;
                    case 3:
                        _cards.Push(GreenCard(number));
                        break;
                    case 4:
                        _cards.Push(YellowCard(number));
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
                player.DealCard(_cards.Peek());
                _cards.Pop();
            }
        }
    }
}

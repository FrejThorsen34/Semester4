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
            if (size > 0)
            {
                for (int i = 1; i <= size; i++)
                {
                    uint suit = (uint)random.Next(1, 6);
                    uint number = (uint)random.Next(1, 9);

                    switch (suit)
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
                        case 5:
                            var gold = new GoldCard(number);
                            _cards.Add(gold);
                            break;
                        default:
                            throw new InvalidOperationException("Suit is undefined!");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Deck must contain a mimimum of one card!");
            }
        }
        public void DealCards(IPlayer player, uint number)
        {
            if (number == 0)
                return;
            if (number > 0)
            {
                for (int i = 1; i <= number; i++)
                {
                    var temp = _cards.Count - 1;
                    player.DealCard(_cards[temp]);
                    _cards.RemoveAt(temp);
                }
            }
            else
                throw new InvalidOperationException("Number must be a positive integer!");
        }

        public int Size
        {
            get { return _cards.Count; }
        }
    }
}

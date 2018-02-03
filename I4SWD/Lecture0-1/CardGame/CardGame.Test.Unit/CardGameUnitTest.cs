using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CardGame.Test.Unit
{
    [TestFixture()]
    [Author("Nickolai Ernst")]
    public class CardGameUnitTest
    {
        private Deck _dut;
        public Deck _dparam = new Deck(32);
        private Game _gut;

        [TestCase(32)]
        public void Deck_ConstructorUnderTest(uint size)
        {
            _dut = new Deck(size);
        }

        [Test]
        public void Deck_Constructor_ExceptionThrow()
        {
            _dut = new Deck(0);
        }

        [Test]
        public void Game_ConstructorUnderTest(Deck deck)
        {
            _gut = new Game(_dparam);
        }
    }
}

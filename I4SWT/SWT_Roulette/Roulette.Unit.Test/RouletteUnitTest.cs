using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace Roulette.Unit.Test
{
    [TestFixture()]
    [Author("Gruppe 35")]
    public class RouletteUnitTest
    {
        //private RouletteGame _rouletteGame;
        private IRoulette _roulette;
        private RouletteGame _uut;
        private IRandom _random;
        private IFieldFactory _fieldFactory;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _roulette = Substitute.For<IRoulette>();
            _uut = new RouletteGame(_roulette);
            _roulette.GetResult().Returns(new Field(4, Field.Black));
        }

        [Test]
        public void OpeBets_IsRoundOpen_True()
        {
            // Act
            _uut.OpenBets();
            // Assert
            Assert.That(_uut.RoundIsOpen, Is.True);
        }
    }
}

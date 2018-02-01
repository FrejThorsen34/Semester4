using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Register;

namespace RegisterTestUnit
{
    [TestFixture()]
    public class RegisterTestUnit
    {
        [Test]
        public void Ctor_NoItemsAdded_TotalIsZero()
        {
            var uut = new MyRegister();
            Assert.That(uut.GetTotal(), Is.EqualTo(0));
        }

        [Test]
        public void Ctor_NoItemsAdded_NItemsIsZero()
        {
            var uut = new MyRegister();
            Assert.That(uut.GetItemSum(), Is.EqualTo(0));
        }
    }
}

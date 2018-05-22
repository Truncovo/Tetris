using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TetrisEngine;

namespace TruncuvTetris
{
    class XYTests
    {
        [Test]
        [TestCase(1, 1, 1, 1, true)]
        [TestCase(1, 1, 1, 2, false)]
        [TestCase(1, 1, 2, 1, false)]
        [TestCase(1, 1, 2, 2, false)]
        public void Equals_WhenCalled_Returns(int firstX, int firstY, int secondX, int secondY,bool expResult)
        {
            var first = new XY(firstX, firstY);
            var second = new XY(secondX,secondY);

            var res = first.Equals(second);

            Assert.That(res,Is.EqualTo(expResult));
        }

   
        [Test]
        public void Equals_AreSameObject_ReturnsTrue()
        {
            var first = new XY(1, 1);

            var res = first.Equals(first);

            Assert.That(res, Is.True);
        }
    }
}

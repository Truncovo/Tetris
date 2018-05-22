using NUnit.Framework;
using TetrisEngine;

namespace TruncuvTetris.UnitTests.Engine
{
    [TestFixture]
    class ShapesGeneratorTests
    {
        [Test]
        public void GetShape_WhenCalled_RenturnsOnlyShameShape()
        {
            var shapesGenerator = new ShapesGenerator(Shapes.Get4line());

            var res = shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.Get4line()));

            res = shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.Get4line()));

            res = shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.Get4line()));


        }

        [Test]
        public void GetShape_WhenCalled_ReturnsSeedSepcifShape()
        {
            //seed 1 with range: (0,7) will give: 1 0 3 5 4 3 2 6 0 4
             var shapesGenerator = new ShapesGenerator(
                Shapes.GetL(), //0
                Shapes.GetL2(), //1
                Shapes.GetZ(), //2
                Shapes.GetZ2(), //3
                Shapes.Get2x2(), //4
                Shapes.Get4line(), //5
                Shapes.GetK()); //6
            shapesGenerator.RandomSeed = 1;

            var res = shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.GetL2()));

            res = shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.GetL()));

            res = shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.GetZ2()));

            res = shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.Get4line()));
        }
    }
}
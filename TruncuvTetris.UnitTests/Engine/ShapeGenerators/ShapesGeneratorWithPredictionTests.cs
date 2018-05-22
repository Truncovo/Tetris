using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TetrisEngine;

namespace TruncuvTetris.UnitTests.Engine
{
    [TestFixture]
    class ShapesGeneratorWithPredictionTests
    {
        private ShapesGeneratorWithPrediction _shapesGenerator;

        [SetUp]
        public void SetUp()
        {
            //seed 1 with range: (0,7) will give: 1 0 3 5 4 3 2 6 0 4
           _shapesGenerator = new ShapesGeneratorWithPrediction(3,
                Shapes.GetL(), //0
                Shapes.GetL2(), //1
                Shapes.GetZ(), //2
                Shapes.GetZ2(), //3
                Shapes.Get2x2(), //4
                Shapes.Get4line(), //5
                Shapes.GetK()); //6
            _shapesGenerator.RandomSeed = 1;
            _shapesGenerator.ResetQueue();
        }

        [Test]
        public void QueueChangedEvent_ResetQueueCalled_EventInvoked()
        {
            int timesCalled = 0;
            _shapesGenerator.QueueChanged += source =>{timesCalled++;};

            _shapesGenerator.ResetQueue();

            Assert.That(timesCalled,Is.EqualTo(1));
        }

        [Test]
        public void QueueChangedEvent_GetShapeCalled_EventInvoked()
        {
            int timesCalled = 0;
            _shapesGenerator.QueueChanged += source => { timesCalled++; };

            _shapesGenerator.GetShape();

            Assert.That(timesCalled, Is.EqualTo(1));
        }

        [Test]
        public void ShapePopedEvent_GetShapeCalled_EventInvoked()
        {
            int timesCalled = 0;
            _shapesGenerator.ShapePoped += source => { timesCalled++; };

            _shapesGenerator.GetShape();

            Assert.That(timesCalled, Is.EqualTo(1));
        }
        [Test]
        public void GetPrediction_WhenCalled_ReturnsShapesMatchingWithShapesWhenCalledGetShape()
        {
            //set up
            var result = new List<Shape>();
            var prediction = new List<Shape>();

            //act
            prediction.Add(_shapesGenerator.GetPreditction(0));
            prediction.Add(_shapesGenerator.GetPreditction(1));
            prediction.Add(_shapesGenerator.GetPreditction(2));

            result.Add(_shapesGenerator.GetShape());
            result.Add(_shapesGenerator.GetShape());
            result.Add(_shapesGenerator.GetShape());

            //assert
            Assert.That(result, Is.EqualTo(prediction.ToArray()));
        }
        [Test]
        public void GetAllPredictions_WhenCalled_ReturnsShapesMatchingWithShapesWhenCalledGetShape()
        {
            //set up
            var result = new List<Shape>();

            //act
            var prediction = _shapesGenerator.GetAllPredictions();

            result.Add(_shapesGenerator.GetShape());
            result.Add(_shapesGenerator.GetShape());
            result.Add(_shapesGenerator.GetShape());

            //assert
            Assert.That(result,Is.EqualTo(prediction.ToArray()));

        }
        [Test]
        public void GetShape_WhenCalled_ReturnsSeedSepcifShape()
        {

            var res = _shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.GetL2()));

            res = _shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.GetL()));

            res = _shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.GetZ2()));

            res = _shapesGenerator.GetShape();
            Assert.That(res, Is.EqualTo(Shapes.Get4line()));
        }

    }
}
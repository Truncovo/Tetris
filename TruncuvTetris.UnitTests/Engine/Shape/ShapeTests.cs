using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media;
using NUnit.Framework;
using TetrisEngine;

namespace TruncuvTetris.UnitTests
{
    [TestFixture]
    public class ShapeTests
    {
        private Shape _shape;
        [SetUp]
        public void SetUp()
        {
            //_shape:   f T T  
            //          T T f  
            //          f f f  
            _shape = new Shape(3);
            _shape.Color = Colors.Black;
            _shape.Map[0, 0] = false;
            _shape.Map[0, 1] = true;
            _shape.Map[0, 2] = true;

            _shape.Map[1, 0] = true;
            _shape.Map[1, 1] = true;
            _shape.Map[1, 2] = false;

            _shape.Map[2, 0] = false;
            _shape.Map[2, 1] = false;
            _shape.Map[2, 2] = false;
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(6)]
        public void Constructor_SizeIsBiggerThen4_ThrowsAnExceptionArgumentOutOfRange(int size)
        {
            Assert.That(() => new Shape(size), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        public void Constructor_SizeIsSmallerThan5_DidNotThrowException(int size)
        {
            new Shape(size);
        }

        [Test]
        public void Clone_WhenCalled_BothObjectWillHaveSameColor()
        {
            Shape clonedShape = (Shape) _shape.Clone();

            Assert.That(_shape.Color, Is.EqualTo(clonedShape.Color));
        }

        [Test]
        public void Clone_WhenCalled_BothObjectWillHaveSameMap()
        {
            Shape clonedShape = (Shape) _shape.Clone();

            Assert.That(_shape.Map, Is.EqualTo(clonedShape.Map));
        }


        [Test]
        public void Clone_WhenCalled_BothObjectWillHaveSameSize()
        {
            Shape clonedShape = (Shape) _shape.Clone();

            Assert.That(_shape.Size, Is.EqualTo(clonedShape.Size));
        }

        [Test]
        public void GetRotatedCopy_RightRotation_ReturnsRightRotatedShape()
        {
            //  _shape: f T T  expected f T f
            //          T T f  result:  f T T
            //          f f f           f f T
            Shape result = _shape.GetRotatedCopy(Rotation.Right);

            Assert.AreEqual(result.Map,GetRightRotatedMap());

        }

        [Test]
        public void GetRotatedCopy_LeftRotation_ReturnsLeftRotatedShape()
        {
            //  _shape: f T T  expected T f f
            //          T T F  result:  T T f
            //          f f f           f T f
            Shape result = _shape.GetRotatedCopy(Rotation.Left);

            Assert.AreEqual(result.Map, GetLeftRotatedMap());
        }

        [Test]
        public void GetRotatedCopy_DoubleLeftRotation_ReturnsDoubleRotatedShape()
        {
            //  _shape: f T T  expected f f f
            //          T T F  result:  f T T
            //          f f f           T T f
            Shape result = _shape.GetRotatedCopy(Rotation.Left);
            result = result.GetRotatedCopy(Rotation.Left);

            Assert.AreEqual(result.Map, GetDoubleRotatedMap());
        }

        [Test]
        public void GetRotatedCopy_DoubleRightRotation_ReturnsDoubleRotatedShape()
        {
            //  _shape: f T T  expected f f f
            //          T T F  result:  f T T
            //          f f f           T T f
            Shape result = _shape.GetRotatedCopy(Rotation.Right);
            result = result.GetRotatedCopy(Rotation.Right);

            Assert.AreEqual(result.Map, GetDoubleRotatedMap());
        }

        [Test]
        public void GetEnumerator_WhenCalled_EnumeratorReturnAllTruePositions()
        {
            List<Coordinates> res = new List<Coordinates>();

            foreach (Coordinates coord in _shape)
                res.Add(coord);
            
            Assert.That(res,Is.EqualTo(GetListOf_shapeTrueCoordinates()));
        }

        [Test]
        public void Equals_ObjectsAreEqual_ReturnTrue()
        {
            _shape = Shapes.GetZ();
            var secondShape = Shapes.GetZ();

            var res = _shape.Equals(secondShape);

            Assert.IsTrue(res);
        }
        [Test]
        public void Equals_ObjectsAreNotEqualHaveSameSize_ReturnFalse()
        {
            _shape = Shapes.GetZ();
            var secondShape = _shape.GetRotatedCopy(Rotation.Right);

            var res = _shape.Equals(secondShape);

            Assert.IsFalse(res);
        }
        [Test]
        public void Equals_ObjectsAreNotEqual_ReturnFalse()
        {
            _shape = Shapes.GetZ();
            var secondShape = Shapes.Get2x2();

            var res = _shape.Equals(secondShape);

            Assert.IsFalse(res);
        }

        private List<Coordinates> GetListOf_shapeTrueCoordinates()
        {
            return  new List<Coordinates>
            {
                new Coordinates(0,1),
                new Coordinates(0,2),
                new Coordinates(1,0),
                new Coordinates(1,1)
            };


        }
        private bool[,] GetRightRotatedMap()
        {
            //f T f
            //f T T
            //f f T
            var res = new bool[3, 3];

            res[0, 0] = false;
            res[0, 1] = true;
            res[0, 2] = false;

            res[1, 0] = false;
            res[1, 1] = true;
            res[1, 2] = true;
            
            res[2, 0] = false;
            res[2, 1] = false;
            res[2, 2] = true;

            return res;
        }
        private bool[,] GetLeftRotatedMap()
        {
            //T f f
            //T T f
            //f T f
            var res = new bool[3, 3];

            res[0, 0] = true;
            res[0, 1] = false;
            res[0, 2] = false;
            
            res[1, 0] = true;
            res[1, 1] = true;
            res[1, 2] = false;

            res[2, 0] = false;
            res[2, 1] = true;
            res[2, 2] = false;

            return res;
        }
        private bool[,] GetDoubleRotatedMap()
        {
            //f f f
            //f T T 
            //T T f
            var res = new bool[3, 3];

            res[0, 0] = false;
            res[0, 1] = false;
            res[0, 2] = false;
            
            res[1, 0] = false;
            res[1, 1] = true;
            res[1, 2] = true;

            res[2, 0] = true;
            res[2, 1] = true;
            res[2, 2] = false;

            return res;
        }
    }
}
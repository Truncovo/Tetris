using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TetrisEngine;

namespace TruncuvTetris.UnitTests.Engine
{
    [TestFixture]
    class ScoreCounterTests
    {
        private Mock<ITetrisFE> _tetrisEvents;
        private ScoreCounter _scoreCounter;
        [SetUp]
        public void SetUp()
        {
            _tetrisEvents = new Mock<ITetrisFE>();
            _scoreCounter = new ScoreCounter(_tetrisEvents.Object);

        }

        [Test]
        public void FinalScoreEvent_WhenGameOverEventInvoked_IsInvoked()
        {
            int  eventInvoked = 0;
            _scoreCounter.FinalScore += (source) => { eventInvoked++; };

            _tetrisEvents.Raise(mock => mock.GameOver+=null,_tetrisEvents);

            Assert.That(eventInvoked,Is.EqualTo(1));
        }
        [Test]
        public void ScoreChangedEvent_ScoreChangedByShapeLanded_IsInvoked()
        {
            bool eventInvoked = false;
            _scoreCounter.ScoreChanged += (source) => { eventInvoked = true; };

            _tetrisEvents.Raise(mock => mock.ShapeLanded += null, _tetrisEvents);

            Assert.That(eventInvoked, Is.True);
        }
        [Test]
        public void ScoreChangedEvent_ScoreChangedByClearedLine_IsInvoked()
        {
            bool eventInvoked = false;
            _scoreCounter.ScoreChanged += (source) => { eventInvoked = true; };
            _tetrisEvents.Setup(te => te.Size).Returns(new Size(1, 1));

            _tetrisEvents.Raise(mock => mock.LineCleared += null, _tetrisEvents);

            Assert.That(eventInvoked, Is.True);
        }
    }
}

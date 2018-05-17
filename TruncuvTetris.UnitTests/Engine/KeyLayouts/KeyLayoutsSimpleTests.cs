using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Converters;
using Moq;
using NUnit.Framework;
using TetrisEngine;

namespace TruncuvTetris.UnitTests.Engine.KeyLayouts
{
    [TestFixture]
    class KeyLayoutsSimpleTests
    {
        private Mock<ITetrisControl> _tetrisControl;

        private KeyLayoutSimple _keyLayout;

        [SetUp]
        public void SetUp()
        {
            _tetrisControl = new Mock<ITetrisControl>();

            _keyLayout = new KeyLayoutSimple
            {
                DropBot = Key.Space,
                MoveDown = Key.Down,
                MoveLeft = Key.Left,
                MoveRight = Key.Right,
                RotateLeft = Key.A,
                RotateRight = Key.D
            };
        }

        [Test, RequiresThread(ApartmentState.STA)]
        public void ProcessKey_PressedSpace_CalledDropToBot()
        {
            _keyLayout.ProcessKey(_tetrisControl.Object, GetMockKeyEventArgs(Key.Space));

            _tetrisControl.Verify(tc => tc.DropToBot());
            _tetrisControl.VerifyNoOtherCalls();
        }

        [Test, RequiresThread(ApartmentState.STA)]
        public void ProcessKey_Pressedright_CalledMoveRight()
        {
            _keyLayout.ProcessKey(_tetrisControl.Object, GetMockKeyEventArgs(Key.Right));

            _tetrisControl.Verify(tc => tc.MoveRight());
            _tetrisControl.VerifyNoOtherCalls();
        }

        private KeyEventArgs GetMockKeyEventArgs(Key key)
        {
            var keyEventArgs = new KeyEventArgs(Keyboard.PrimaryDevice, new TestPresentationSource(), 1, key)
            {
                RoutedEvent = Keyboard.KeyDownEvent,
                Handled = false,
            };
            return keyEventArgs;
        }

        private class TestPresentationSource : PresentationSource
        {
            protected override CompositionTarget GetCompositionTargetCore()
            {
                throw new System.NotImplementedException();
            }

            public override Visual RootVisual { get; set; }
            public override bool IsDisposed { get; }
        }
    }
}

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
        private Mock<ITetrisFE> _tetrisControl;

        private KeyLayoutSimple _keyLayout;

        [SetUp]
        public void SetUp()
        {
            _tetrisControl = new Mock<ITetrisFE>();

            _keyLayout = new KeyLayoutSimple(new Key[6]
            {
                Key.Left,
                Key.Right,
                Key.Down,
                Key.A,
                Key.D,
                Key.Space
            });
        }
        //----------------------------------------------------------------------------------------------------
        [Test]
        public void SetKey_SettingExistingKey_ThrowException()
        {
            Assert.That(()=> _keyLayout.SetKey(Key.A, KeyLayoutSimple.Commands.DropToBot),Throws.Exception);
        }

        [Test]
        public void SetKey_SettNotExistingKey_ChangedKey()
        {
            _keyLayout.SetKey(Key.Q, KeyLayoutSimple.Commands.DropToBot);

            Assert.That(_keyLayout.ControlArray[(int)KeyLayoutSimple.Commands.DropToBot],Is.EqualTo(Key.Q));
        }

        [Test]
        public void SetKey_SettKeyToSameKey_ArrayIsSame()
        {
            var expected = _keyLayout.ControlArray.Clone();
            _keyLayout.SetKey(Key.Space, KeyLayoutSimple.Commands.DropToBot);

            Assert.That(_keyLayout.ControlArray,Is.EqualTo(expected));
        }
        //----------------------------------------------------------------------------------------------------

        [Test, RequiresThread(ApartmentState.STA)]
        public void ProcessKey_PressedSpace_CalledDropToBot()
        {
            _keyLayout.ProcessKey(_tetrisControl.Object, GetMockKeyEventArgs(Key.Space));

            _tetrisControl.Verify(tc => tc.DropToBot());
            _tetrisControl.VerifyNoOtherCalls();
        }

        [Test, RequiresThread(ApartmentState.STA)]
        public void ProcessKey_PressedLeft_CalledMoveLeft()
        {
            _keyLayout.ProcessKey(_tetrisControl.Object, GetMockKeyEventArgs(Key.Left));

            _tetrisControl.Verify(tc => tc.MoveLeft());
            _tetrisControl.VerifyNoOtherCalls();
        }

        [Test, RequiresThread(ApartmentState.STA)]
        public void ProcessKey_Pressedright_CalledMoveRight()
        {
            _keyLayout.ProcessKey(_tetrisControl.Object, GetMockKeyEventArgs(Key.Right));

            _tetrisControl.Verify(tc => tc.MoveRight());
            _tetrisControl.VerifyNoOtherCalls();
        }

        [Test, RequiresThread(ApartmentState.STA)]
        public void ProcessKey_PressedA_CalledRotateLeft()
        {
            _keyLayout.ProcessKey(_tetrisControl.Object, GetMockKeyEventArgs(Key.A));

            _tetrisControl.Verify(tc => tc.RotateLeft());
            _tetrisControl.VerifyNoOtherCalls();
        }

        [Test, RequiresThread(ApartmentState.STA)]
        public void ProcessKey_PressedD_CalledRotatedRight()
        {
            _keyLayout.ProcessKey(_tetrisControl.Object, GetMockKeyEventArgs(Key.D));

            _tetrisControl.Verify(tc => tc.RotateRight());
            _tetrisControl.VerifyNoOtherCalls();
        }

        [Test, RequiresThread(ApartmentState.STA)]
        public void ProcessKey_PressedDown_CalledMoveDown()
        {
            _keyLayout.ProcessKey(_tetrisControl.Object, GetMockKeyEventArgs(Key.Down));

            _tetrisControl.Verify(tc => tc.MoveDown());
            _tetrisControl.VerifyNoOtherCalls();
        }
        //----------------------------------------------------------------------------------------------------
        private KeyEventArgs GetMockKeyEventArgs(Key key)
        {
            var keyEventArgs = new KeyEventArgs(Keyboard.PrimaryDevice, new MockPresentationSource(), 1, key)
            {
                RoutedEvent = Keyboard.KeyDownEvent,
                Handled = false,
            };
            return keyEventArgs;
        }

        private class MockPresentationSource : PresentationSource
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

using Moq;
using Xunit;

namespace MarsRobot.UnitTests
{
    public class CommandParserTests
    {
        [Fact]
        public void ParseAndExecute_NoCommand()
        {
            var commandReceiverMock = new Mock<ICommandReceiver>(MockBehavior.Strict);
            CommandParser.ParseAndExecute("", commandReceiverMock.Object);
            commandReceiverMock.Verify();
        }

        [Fact]
        public void ParseAndExecute_CommandTurnLeft()
        {
            var commandReceiverMock = new Mock<ICommandReceiver>(MockBehavior.Strict);
            commandReceiverMock.Setup(obj => obj.TurnLeft());
            CommandParser.ParseAndExecute("L", commandReceiverMock.Object);
            commandReceiverMock.Verify(obj => obj.TurnLeft(), Times.Once());
        }

        [Fact]
        public void ParseAndExecute_CommandTurnRight()
        {
            var commandReceiverMock = new Mock<ICommandReceiver>(MockBehavior.Strict);
            commandReceiverMock.Setup(obj => obj.TurnRight());
            CommandParser.ParseAndExecute("R", commandReceiverMock.Object);
            commandReceiverMock.Verify(obj => obj.TurnRight(), Times.Once());
        }

        [Fact]
        public void ParseAndExecute_CommandMoveForward()
        {
            var commandReceiverMock = new Mock<ICommandReceiver>(MockBehavior.Strict);
            commandReceiverMock.Setup(obj => obj.MoveForward());
            CommandParser.ParseAndExecute("F", commandReceiverMock.Object);
            commandReceiverMock.Verify(obj => obj.MoveForward(), Times.Once());
        }

        [Fact]
        public void ParseAndExecute_MultipleCommands()
        {
            var commandReceiverMock = new Mock<ICommandReceiver>(MockBehavior.Strict);
            commandReceiverMock.Setup(obj => obj.TurnLeft());
            commandReceiverMock.Setup(obj => obj.TurnRight());
            commandReceiverMock.Setup(obj => obj.MoveForward());
            CommandParser.ParseAndExecute("LLRRRFFFF", commandReceiverMock.Object);
            commandReceiverMock.Verify(obj => obj.TurnLeft(), Times.Exactly(2));
            commandReceiverMock.Verify(obj => obj.TurnRight(), Times.Exactly(3));
            commandReceiverMock.Verify(obj => obj.MoveForward(), Times.Exactly(4));
        }
    }
}
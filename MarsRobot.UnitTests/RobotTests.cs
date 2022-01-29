using Xunit;

namespace MarsRobot.UnitTests
{
    public class RobotTests
    {
        [Theory]
        [InlineData(0, Robot.CardinalDirection.North)]
        [InlineData(1, Robot.CardinalDirection.West)]
        [InlineData(2, Robot.CardinalDirection.South)]
        [InlineData(3, Robot.CardinalDirection.East)]
        [InlineData(4, Robot.CardinalDirection.North)]
        public void TurnLeft_ChangeDirectionCounterClockwise(
            int repetitions, Robot.CardinalDirection expectedFinalDirection)
        {
            var robot = new Robot(1,1);
            for (int count = 0; count < repetitions; ++count)
            {
                robot.TurnLeft();
            }
            Assert.Equal(expectedFinalDirection, robot.Direction);
        }

        [Theory]
        [InlineData(0, Robot.CardinalDirection.North)]
        [InlineData(1, Robot.CardinalDirection.East)]
        [InlineData(2, Robot.CardinalDirection.South)]
        [InlineData(3, Robot.CardinalDirection.West)]
        [InlineData(4, Robot.CardinalDirection.North)]
        public void TurnRight_ChangeDirectionClockwise(
            int repetitions, Robot.CardinalDirection expectedFinalDirection)
        {
            var robot = new Robot(1, 1);
            for (int count = 0; count < repetitions; ++count)
            {
                robot.TurnRight();
            }
            Assert.Equal(expectedFinalDirection, robot.Direction);
        }

        [Fact]
        public void MoveForward_UntilEndOfPlateuThenTurnRight()
        {
            (int x, int y) max = (3,4);
            var robot = new Robot(max.x, max.y);

            // heading North:
            for (int y = 1; y <= max.y; ++y)
            {
                Assert.Equal((1, y), robot.Position);
                robot.MoveForward();
            }

            // heading East:
            robot.TurnRight();
            for (int x = 1; x <= max.x; ++x)
            {
                Assert.Equal((x, max.y), robot.Position);
                robot.MoveForward();
            }

            // heading South:
            robot.TurnRight();
            for (int y = max.y; y >= 1; --y)
            {
                Assert.Equal((max.x, y), robot.Position);
                robot.MoveForward();
            }

            // heading West:
            robot.TurnRight();
            for (int x = max.x; x >= 1; --x)
            {
                Assert.Equal((x, 1), robot.Position);
                robot.MoveForward();
            }

            // back to origin
            Assert.Equal((1,1), robot.Position);
        }
    }
}
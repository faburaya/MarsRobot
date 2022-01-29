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
            (uint x, uint y) max = (3U,4U);
            var robot = new Robot(max.x, max.y);

            // heading North:
            for (uint y = 1; y <= max.y; ++y)
            {
                Assert.Equal((1U,y), robot.Position);
                robot.MoveForward();
            }

            // heading East:
            robot.TurnRight();
            for (uint x = 1; x <= max.x; ++x)
            {
                Assert.Equal((x, max.y), robot.Position);
                robot.MoveForward();
            }

            // heading South:
            robot.TurnRight();
            for (uint y = max.y; y >= 1; --y)
            {
                Assert.Equal((max.x, y), robot.Position);
                robot.MoveForward();
            }

            // heading West:
            robot.TurnRight();
            for (uint x = max.x; x >= 1; --x)
            {
                Assert.Equal((x, 1U), robot.Position);
                robot.MoveForward();
            }

            // back to origin
            Assert.Equal((1U,1U), robot.Position);
        }
    }
}
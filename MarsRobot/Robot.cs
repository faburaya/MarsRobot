
namespace MarsRobot
{
    /// <summary>
    /// Implements a robot that receives the commands of <see cref="ICommandReceiver"/>.
    /// </summary>
    public class Robot : ICommandReceiver
    {
        public enum CardinalDirection { North = 1, West, South, East };

        public CardinalDirection Direction { get; private set; }

        public (uint x, uint y) Position => _position;

        private (uint x, uint y) _position;

        private readonly (uint x, uint y) _max;

        /// <summary>
        /// Creates the plateau where the robot moves.
        /// It is a 2-dimensional space with origin (1,1) that extends
        /// until (<paramref name="maxPlateauX"/>, <paramref name="maxPlateauY"/>).
        /// </summary>
        /// <param name="maxPlateauX">Maximum coordinate (inclusive) for the East-West axis.</param>
        /// <param name="maxPlateauY">Maximum coordinate (inclusive) for the North-South axis.</param>
        public Robot(uint maxPlateauX, uint maxPlateauY)
        {
            _max.x = maxPlateauX;
            _max.y = maxPlateauY;
            _position = (1, 1);
            Direction = CardinalDirection.North;
        }

        public void TurnLeft()
        {
            uint directionIndex = (uint)Direction;
            if (++directionIndex <= (uint)CardinalDirection.East)
                Direction = (CardinalDirection)directionIndex;
            else
                Direction = CardinalDirection.North;
        }

        public void TurnRight()
        {
            uint directionIndex = (uint)Direction;
            if (--directionIndex >= (uint)CardinalDirection.North)
                Direction = (CardinalDirection)directionIndex;
            else
                Direction = CardinalDirection.East;
        }

        public void MoveForward()
        {
            switch (Direction)
            {
                case CardinalDirection.North:
                    if (_position.y < _max.y)
                        ++_position.y;
                    break;
                case CardinalDirection.West:
                    if (_position.x > 1)
                        --_position.x;
                    break;
                case CardinalDirection.South:
                    if (_position.y > 1)
                        --_position.y;
                    break;
                case CardinalDirection.East:
                    if (_position.x < _max.x)
                        ++_position.x;
                    break;
            }
        }
    }
}

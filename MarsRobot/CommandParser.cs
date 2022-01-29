using System.Diagnostics;

namespace MarsRobot
{
    public static class CommandParser
    {
        static public void ParseAndExecute(string commands, ICommandReceiver commandReceiver)
        {
            foreach (char ch in commands)
            {
                switch (ch)
                {
                    case 'L':
                        commandReceiver.TurnLeft();
                        break;
                    case 'R':
                        commandReceiver.TurnRight();
                        break;
                    case 'F':
                        commandReceiver.MoveForward();
                        break;
                    default:
                        Debug.Assert(false, "Unknown command!");
                        break;
                }
            }
        }
    }
}

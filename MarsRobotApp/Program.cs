using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRobot
{
    class Program
    {
        static void Main(string[] _)
        {
            IList<uint> dimension = Console.ReadLine()
                .Split('x').Select(s => uint.Parse(s)).ToList();
            
            Robot robot = new(dimension[0], dimension[1]);
            string commands = Console.ReadLine();
            CommandParser.ParseAndExecute(commands, robot);
            Console.WriteLine($"{robot.Position.x},{robot.Position.y},{robot.Direction}");
        }
    }
}

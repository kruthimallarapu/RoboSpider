using System;
using System.Collections.Generic;
using RoboSpider.Domain;

namespace RoboSpider
{
    public class InputParser
    {
        private readonly ISpiderFactory _spiderFactory;

        public InputParser(ISpiderFactory spiderFactory)
        {
            _spiderFactory = spiderFactory;
        }

        public int GetWallParameter(string wallCoordinates, string parameterType)
        {
            var split = wallCoordinates.Split(' ');
            switch (parameterType)
            {
                case "WallRight":
                    return Convert.ToInt32(split[1]);

                default:
                case "WallTop":
                    return Convert.ToInt32(split[0]);
            }
        }

        public ISpider ParseSpiderInformation(string spiderInformation, int wallTop, int wallRight)
        {
            var split = spiderInformation.Split(' ');
            var currentXPosition = Convert.ToInt32(split[0]);
            var currentYPosition = Convert.ToInt32(split[1]);
            var currentOrientation = Orientation.Left;
            switch (split[2].ToUpper())
            {
                case "L":
                    currentOrientation = Orientation.Left;
                    break;
                case "R":
                    currentOrientation = Orientation.Right;
                    break;
                case "T":
                    currentOrientation = Orientation.Top;
                    break;
                case "B":
                    currentOrientation = Orientation.Bottom;
                    break;
            }

            return _spiderFactory.CreateSpider(wallTop, wallRight, currentXPosition, currentYPosition, currentOrientation);
        }

        public List<char> ParseSpiderInstructions(string spiderInstructions)
        {
            var instructions = new List<char>();
            foreach (var key in spiderInstructions)
            {
                instructions.Add(key);
            }

            return instructions;
        }
    }
}
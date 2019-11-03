using System;
using System.Collections.Generic;
using RoboSpider.Domain;

namespace RoboSpider
{
    public class UserHandler
    {
        private ISpider _spider;
        private List<char> _instructions;
        private readonly InputValidator _inputValidator;
        private readonly InputParser _inputParser;

        public UserHandler(ISpiderFactory spiderFactory)
        {
            _inputValidator = new InputValidator();
            _inputParser = new InputParser(spiderFactory);
            ReadInputInformation();
        }

        public void RunWorkFlow(Action<ISpider> onSpiderDeployed)
        {
            foreach (var key in _instructions)
            {
                switch (key)
                {
                    case 'L':
                        _spider.TurnLeft();
                        break;

                    case 'R':
                        _spider.TurnRight();
                        break;

                    case 'F':
                        _spider.MoveFront();
                        break;
                }
            }

            onSpiderDeployed?.Invoke(_spider);
        }

        private void ReadInputInformation()
        {
            var wallInformation = ReadInformation("wall information");
            if (!_inputValidator.IsWallInputValid(wallInformation))
                throw new Exception("Wall information is not valid");

            var spiderInformation = ReadInformation("spider information (L -Left R-Right T-Top B-Bottom)");
            if (!_inputValidator.IsSpiderInputValid(spiderInformation))
                throw new Exception("Spider information is not valid");

            var spiderInstructions = ReadInformation("spider instructions");
            if (!_inputValidator.IsSpiderInstructionsValid(spiderInstructions))
                throw new Exception("Spider instructions are not valid");

            var wallTop = _inputParser.GetWallParameter(wallInformation, "WallTop");
            var wallRight = _inputParser.GetWallParameter(wallInformation, "WallRight");

            _spider = _inputParser.ParseSpiderInformation(spiderInformation, wallTop, wallRight);

            var spiderPosition = _spider.GetPosition();
            if (!_inputValidator.IsSpiderWithInWallCoordinates(wallTop, wallRight, spiderPosition.X, spiderPosition.Y))
                throw new Exception("Spider initial position is not valid");

            _instructions = _inputParser.ParseSpiderInstructions(spiderInstructions);
        }

        private string ReadInformation(string what)
        {
            Console.WriteLine($"Please enter {what}");
            return Console.ReadLine();
        }
    }
}
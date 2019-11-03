using System;
using NUnit.Framework;
using RoboSpider.Domain;

namespace RoboSpider.UnitTest
{
    [TestFixture]
    public class InputParserTest
    {
        private InputParser _inputParser;
        private ISpiderFactory _spiderFactory;

        [SetUp]
        public void Setup()
        {
            _spiderFactory = new SpiderFactory();
            _inputParser = new InputParser(_spiderFactory);
        }

        [TestCase("7 15", "WallRight", 15)]
        [TestCase("7 15", "WallTop", 7)]
        public void When_get_wall_parameter_is_called_with_valid_data_and_parameter_type_then_expected_value_is_returned(
                string wallCoordinates, string parameterType, int expectedOutput)
        {
            var wallParameter = _inputParser.GetWallParameter(wallCoordinates, parameterType);
            Assert.That(wallParameter, Is.EqualTo(expectedOutput));
        }

        [TestCase("2 4 L", 7, 15)]
        [TestCase("2 4 R", 7, 15)]
        [TestCase("2 4 T", 7, 15)]
        [TestCase("2 4 B", 7, 15)]
        public void When_parse_spider_information_is_called_with_valid_data_then_spider_instance_is_returned(string spiderInformation, int wallTop, int wallRight)
        {
            var split = spiderInformation.Split(' ');
            var expectedXValue = Convert.ToInt32(split[0]);
            var expectedYValue = Convert.ToInt32(split[1]);
            var expectedOrientation = GetOrientationByKey(split[2].ToUpper());

            var spider = _inputParser.ParseSpiderInformation(spiderInformation, wallTop, wallRight);

            Assert.IsNotNull(spider);
            var spiderPosition = spider.GetPosition();
            Assert.That(spiderPosition.X, Is.EqualTo(expectedXValue));
            Assert.That(spiderPosition.Y, Is.EqualTo(expectedYValue));
            Assert.That(expectedOrientation, Is.EqualTo(spider.GetOrientation()));
        }

        [TestCase("FLFLFRFFLF")]
        public void When_parse_spider_instructions_is_called_with_valid_data_then_collection_of_instructions_are_returned(
                string spiderInstructions)
        {
            var instructions = _inputParser.ParseSpiderInstructions(spiderInstructions);
            Assert.IsNotNull(instructions);
            Assert.That(instructions.Count, Is.GreaterThan(0));
        }

        private Orientation GetOrientationByKey(string key)
        {
            switch (key)
            {
                case "L":
                    return Orientation.Left;
                case "R":
                    return Orientation.Right;
                case "T":
                    return Orientation.Top;

                case "B":
                default:
                    return Orientation.Bottom;
            }
        }
    }
}

using NUnit.Framework;

namespace RoboSpider.UnitTest
{
    [TestFixture]
    public class InputValidatorTest
    {
        private InputValidator _inputValidator;

        [SetUp]
        public void Setup()
        {
            _inputValidator = new InputValidator();
        }

        [TestCase("7 15", true)]
        [TestCase("7 15 10", false)]
        [TestCase("7 A", false)]
        [TestCase("A 7", false)]
        [TestCase("B A", false)]
        [TestCase("715", false)]
        [TestCase("7 A", false)]
        [TestCase(" ", false)]
        public void When_is_wall_input_valid_is_called_with_data_expected_value_is_returned(string wallInput, bool expectedOutput)
        {
            var isWallInputValid = _inputValidator.IsWallInputValid(wallInput);
            Assert.That(isWallInputValid, Is.EqualTo(expectedOutput));
        }

        [TestCase("2 4 L", true)]
        [TestCase("2 4 R", true)]
        [TestCase("24L", false)]
        [TestCase("2 L", false)]
        [TestCase("2 4", false)]
        [TestCase("L", false)]
        [TestCase("2", false)]
        [TestCase("2  ", false)]
        [TestCase("A B C", false)]
        [TestCase("2 4 F", false)]
        [TestCase("   ", false)]
        public void When_is_spider_input_valid_is_called_with_data_expected_value_is_returned(string spiderInput, bool expectedOutput)
        {
            var isSpiderInputValid = _inputValidator.IsSpiderInputValid(spiderInput);
            Assert.That(isSpiderInputValid, Is.EqualTo(expectedOutput));
        }

        [TestCase("LRLRLLRF", true)]
        [TestCase("LRF", true)]
        [TestCase("RRR", true)]
        [TestCase("LLL", true)]
        [TestCase("FFF", true)]
        [TestCase("", false)]
        [TestCase("123", false)]
        [TestCase("LRF123", false)]
        [TestCase("LRF ", false)]
        [TestCase("LRF L", false)]
        public void When_is_spider_instructions_valid_is_called_with_valid_data_then_expected_value_is_returned(string spiderInstructions, bool expectedOutput)
        {
            var isSpiderInstructionsValid = _inputValidator.IsSpiderInstructionsValid(spiderInstructions);
            Assert.That(isSpiderInstructionsValid, Is.EqualTo(expectedOutput));
        }

        [TestCase(7, 15, 2, 4, true)]
        [TestCase(7, 15, 0, 0, true)]
        [TestCase(7, 15, -1, -1, false)]
        [TestCase(7, 15, 8, 15, false)]
        [TestCase(7, 15, 7, 16, false)]
        public void When_is_spider_with_in_wall_coordinates_is_called_then_expected_value_is_returned(int wallTop,
            int wallRight, int spiderXCoordinate, int spiderYCoordinate, bool expectedOutput)
        {
            var isSpiderInstructionsValid = _inputValidator.IsSpiderWithInWallCoordinates(wallTop, wallRight, spiderXCoordinate, spiderYCoordinate);
            Assert.That(isSpiderInstructionsValid, Is.EqualTo(expectedOutput));
        }
    }
}

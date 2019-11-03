using System.Text.RegularExpressions;

namespace RoboSpider
{
    public class InputValidator
    {
        private const string _wallInputPattern = @"^\d+ \d+$";
        private const string _spiderInputPattern = @"^\d+ \d+ [LRTB]$";
        private const string _spiderInstructionsPattern = @"^[LRF]+$";

        public bool IsWallInputValid(string wallInput)
        {
            var regEx = new Regex(_wallInputPattern);
            return regEx.IsMatch(wallInput);
        }

        public bool IsSpiderInputValid(string spiderInput)
        {
            var regEx = new Regex(_spiderInputPattern);
            return regEx.IsMatch(spiderInput);
        }

        public bool IsSpiderInstructionsValid(string spiderInstructions)
        {
            var regEx = new Regex(_spiderInstructionsPattern);
            return regEx.IsMatch(spiderInstructions);
        }

        public bool IsSpiderWithInWallCoordinates(int wallTop, int wallRight, int spiderXCoordinate, int spiderYCoordinate)
        {
            var isXPositionValid = spiderXCoordinate >= 0 && spiderXCoordinate <= wallTop;
            var isYPositionValid = spiderYCoordinate >= 0 && spiderYCoordinate <= wallRight;

            return isXPositionValid && isYPositionValid;
        }
    }
}
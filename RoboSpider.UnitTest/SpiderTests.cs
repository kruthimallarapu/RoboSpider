using System;
using NUnit.Framework;
using RoboSpider.Domain;

namespace RoboSpider.UnitTest
{
    [TestFixture]
    public class SpiderTests
    {
        private ISpider _spider;

        [TestCaseSource(nameof(_spiderTestSource))]
        public void When_spider_is_moved_as_per_instructions_with_valid_data_final_spider_information_is_returned(
               int wallTop, 
               int wallRight,
               Position spiderPosition,
               Orientation spiderOrientation,
               string spiderInstructions,
               int finalSpiderXCoordinate,
               int finalSpiderYCoordinate,
               Orientation finalSpiderOrientation)
        {
            _spider = new Spider(wallTop, wallRight, spiderPosition, spiderOrientation);
            foreach (var key in spiderInstructions)
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

            var finalPosition = _spider.GetPosition();
            Assert.That(finalPosition.X, Is.EqualTo(finalSpiderXCoordinate));
            Assert.That(finalPosition.Y, Is.EqualTo(finalSpiderYCoordinate));
            Assert.That(_spider.GetOrientation(), Is.EqualTo(finalSpiderOrientation));
        }

        [TestCaseSource(nameof(_spiderTestExceptionSource))]
        public void When_spider_is_moved_as_per_instructions_with_invalid_data_then_exception_is_thrown_from_spider(
               int wallTop,
               int wallRight,
               Position spiderPosition,
               Orientation spiderOrientation,
               string spiderInstructions)
        {
            _spider = new Spider(wallTop, wallRight, spiderPosition, spiderOrientation);
            foreach (var key in spiderInstructions)
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
                       Assert.Throws<Exception>(() => _spider.MoveFront());
                        break;
                }
            }
        }

        private static object[] _spiderTestSource =
        {
            new object[]
            {
                7,
                15,
                new Position {X = 2, Y =4 },
                Orientation.Left,
                "FLFLFRFFLF",
                3,
                1,
                Orientation.Right
            }
        };

        private static object[] _spiderTestExceptionSource =
        {
            new object[]
            {
                7,
                15,
                new Position {X = 7, Y =15 },
                Orientation.Top,
                "FR"
            }
        };
    }
}

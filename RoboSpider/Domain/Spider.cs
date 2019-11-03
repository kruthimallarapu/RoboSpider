using System;

namespace RoboSpider.Domain
{
    public class Spider : ISpider
    {
        private readonly int _wallTop;
        private readonly int _wallRight;
        private Position _currentPosition;
        private Orientation _currentOrientation;

        public Spider(int wallTop, int wallRight, Position currentPosition, Orientation currentOrientation)
        {
            _wallTop = wallTop;
            _wallRight = wallRight;
            _currentPosition = currentPosition;
            _currentOrientation = currentOrientation;
        }

        public void MoveFront()
        {
            var newPosition = GetNewPosition();
            if (newPosition.X < 0 || newPosition.Y < 0 || newPosition.Y > _wallTop || newPosition.X > _wallRight)
                throw new Exception("Spider cannot move beyond this position");

            _currentPosition = newPosition;
        }

        private Position GetNewPosition()
        {
            var newPosition = new Position
            {
                X = _currentPosition.X,
                Y = _currentPosition.Y
            };

            switch (_currentOrientation)
            {
                case Orientation.Bottom:
                    newPosition.Y--;
                    return newPosition;
                case Orientation.Left:
                    newPosition.X--;
                    return newPosition;
                case Orientation.Top:
                    newPosition.Y++;
                    return newPosition;
                case Orientation.Right:
                default:
                    newPosition.X++;
                    return newPosition;
            }
        }

        public void TurnRight()
        {
            switch (_currentOrientation)
            {
                case Orientation.Bottom:
                    _currentOrientation = Orientation.Left;
                    break;
                case Orientation.Top:
                    _currentOrientation = Orientation.Right;
                    break;
                case Orientation.Right:
                    _currentOrientation = Orientation.Bottom;
                    break;
                case Orientation.Left:
                    _currentOrientation = Orientation.Top;
                    break;
            }
        }

        public void TurnLeft()
        {
            for (var i = 0; i < 3; i++)
                TurnRight();
        }

        public Position GetPosition()
        {
            return _currentPosition;
        }

        public Orientation GetOrientation()
        {
            return _currentOrientation;
        }
    }
}
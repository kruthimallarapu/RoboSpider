namespace RoboSpider.Domain
{
    public interface ISpider
    {
        Orientation GetOrientation();
        Position GetPosition();
        void MoveFront();
        void TurnLeft();
        void TurnRight();
    }
}
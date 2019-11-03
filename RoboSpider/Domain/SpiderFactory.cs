namespace RoboSpider.Domain
{
    public class SpiderFactory : ISpiderFactory
    {
        public ISpider CreateSpider(int wallTop, int wallRight, int x, int y, Orientation orientation)
        {
            return new Spider(wallTop, wallRight, new Position { X = x, Y = y }, orientation);
        }
    }
}
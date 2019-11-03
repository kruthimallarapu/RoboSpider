namespace RoboSpider.Domain
{
    public interface ISpiderFactory
    {
        ISpider CreateSpider(int wallTop, int wallRight, int x, int y, Orientation orientation);
    }
}
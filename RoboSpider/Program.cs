using System;
using RoboSpider.Domain;

namespace RoboSpider
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var spiderFactory = new SpiderFactory();
                var userHandler = new UserHandler(spiderFactory);
                userHandler.RunWorkFlow(OnSpiderDeployed);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void OnSpiderDeployed(ISpider spider)
        {
            Console.WriteLine("Spider position and orientation after deployment are");
            Console.WriteLine(spider.GetPosition().X);
            Console.WriteLine(spider.GetPosition().Y);
            Console.WriteLine(spider.GetOrientation().ToString());
        }
    }
}

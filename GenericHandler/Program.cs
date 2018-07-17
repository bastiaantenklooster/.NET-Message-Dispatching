using System;

namespace GenericHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            var zon = new Zon();
            var regen = new Regen();

            var router = new Router();

            router.Register(new ZonMessageHandler(zon));
            router.Register(new RegenMessageHandler(regen));

            var regenmessage = new RegenMessage(5.3);
            router.Dispatch(regenmessage);

            var zonmessage = new ZonMessage(3);
            router.Dispatch(zonmessage);

            router.Register(new ZonMessageHandler(zon));

            zonmessage = new ZonMessage(5);
            router.Dispatch(zonmessage);

            regenmessage = new RegenMessage(-.3);
            router.Dispatch(regenmessage);

            Console.WriteLine("Zonkracht: {0}", zon.Kracht);
            Console.WriteLine("Regen: {0}mm", regen.Millimeter);
            Console.Read();
        }
    }
}

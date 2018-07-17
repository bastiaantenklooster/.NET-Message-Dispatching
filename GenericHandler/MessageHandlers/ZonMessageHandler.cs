using System;

namespace GenericHandler
{
    class ZonMessageHandler : IMessageHandler<ZonMessage>
    {
        private Zon zon;

        public ZonMessageHandler(Zon zon)
        {
            this.zon = zon;
        }

        public void Handle(ZonMessage message)
        {
            Console.WriteLine("{0}: {1}", message.ToString(), message.Body.Kracht);
            this.zon.Kracht += message.Body.Kracht;
        }
    }
}

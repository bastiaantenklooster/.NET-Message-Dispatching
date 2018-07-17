using System;
using System.Collections.Generic;
using System.Text;

namespace GenericHandler
{

    class RegenMessageHandler : IMessageHandler<RegenMessage>
    {
        private Regen regen;

        public RegenMessageHandler(Regen regen)
        {
            this.regen = regen;
        }

        public void Handle(RegenMessage message)
        {
            Console.WriteLine("{0}: {1}", message.ToString(), message.Body.Millimeter);
            this.regen.Millimeter += message.Body.Millimeter;
        }
    }
}

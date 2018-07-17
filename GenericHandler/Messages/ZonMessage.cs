namespace GenericHandler
{
    class ZonMessage : Message
    {
        public ZonMessage(int kracht)
        {
            Body = new ZonMessageBody()
            {
                Kracht = kracht
            };
        }

        public ZonMessageBody Body;
    }

    class ZonMessageBody
    {
        public int Kracht;
    }
}

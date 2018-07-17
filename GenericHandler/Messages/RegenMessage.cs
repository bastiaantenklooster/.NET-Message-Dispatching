namespace GenericHandler
{
    class RegenMessage : Message
    {
        public RegenMessage(double millimeter)
        {
            Body = new RegenMessageBody()
            {
                Millimeter = millimeter
            };
        }

        public RegenMessageBody Body;
    }

    class RegenMessageBody
    {
        public double Millimeter;
    }
}

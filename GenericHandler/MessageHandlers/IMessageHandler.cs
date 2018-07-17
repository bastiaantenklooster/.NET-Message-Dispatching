namespace GenericHandler
{
    interface IMessageHandler<TMessage> where TMessage : Message
    {
        void Handle(TMessage message);
    }
}

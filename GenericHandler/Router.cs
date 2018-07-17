using System;
using System.Collections.Generic;
using System.Collections;

namespace GenericHandler
{
    class Router
    {
        /// <summary>
        /// Lists of handlers indexed by message type
        /// </summary>
        protected Dictionary<Type, object> handlers = new Dictionary<Type, object>();

        /// <summary>
        /// Register a new message handler for a specific message type
        /// </summary>
        /// <typeparam name="TMessage">Type of the message to be handled by the handler</typeparam>
        /// <param name="messageHandler">A message handler</param>
        public void Register<TMessage>(IMessageHandler<TMessage> messageHandler) where TMessage : Message
        {
            // Initialize a list for the current message type
            if (!handlers.ContainsKey(typeof(TMessage)))
                handlers.Add(typeof(TMessage), new List<IMessageHandler<TMessage>>());

            // Add the specified message handler
            ((List<IMessageHandler<TMessage>>)handlers.GetValueOrDefault(typeof(TMessage)))
                .Add(messageHandler);
        }

        public void Unregister<TMessage>(IMessageHandler<TMessage> messageHandler) where TMessage : Message
        {
            if (!handlers.ContainsKey(typeof(TMessage)))
                return;

            ((List<IMessageHandler<TMessage>>)handlers.GetValueOrDefault(typeof(TMessage)))
                .Remove(messageHandler);
        }

        /// <summary>
        /// Invoke the <see cref="IMessageHandler{TMessage}.Handle(TMessage)"/> method for 
        /// all registered message handlers of the message's type
        /// </summary>
        /// <param name="message"></param>
        public void Dispatch(Message message)
        {
            // Get the list of handlers for the message type
            IList list = (IList)handlers.GetValueOrDefault(message.GetType());

            if (list == null) // No handlers have been registered yet for this type
                return;

            object[] tempList = new object[list.Count];
            list.CopyTo(tempList, 0);

            foreach (object i in tempList)
                i.GetType().GetMethod("Handle").Invoke(i, new[] { message });
        }
    }
}

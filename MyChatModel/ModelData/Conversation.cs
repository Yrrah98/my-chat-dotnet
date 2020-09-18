﻿namespace MyChatModel.ModelData
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Conversation
    {
        /// <summary>
        /// The name of the conversation.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The messages in the conversation.
        /// </summary>
        public IEnumerable<Message> Messages { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Conversation"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the conversation.
        /// </param>
        /// <param name="messages">
        /// The messages in the conversation.
        /// </param>
        public Conversation(string name, IEnumerable<Message> messages) 
        {
            this.Name = name;
            this.Messages = messages;

        }
    }
}
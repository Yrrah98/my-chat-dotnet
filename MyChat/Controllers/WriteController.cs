﻿namespace MindLink.Recruitment.MyChat.Controllers
{
    using MindLink.Recruitment.MyChat.Interfaces.ControllerInterfaces;
    using MyChatModel.ModelData;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security;
    using System.Text;

    /// <summary>
    /// Class, separated out the WriteConversation functionality of the ConversationExporter class
    /// to this class. 
    /// </summary>
    public sealed class WriteController : IWriteController
    {
        /// <summary>
        /// CONSTRUCTOR for WriteController class, empty.
        /// </summary>
        public WriteController() 
        {

        }

        /// <summary>
        /// Helper method to write the <paramref name="conversation"/> as JSON to <paramref name="outputFilePath"/>.
        /// </summary>
        /// <param name="conversation">
        /// The conversation.
        /// </param>
        /// <param name="outputFilePath">
        /// The output file path.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when there is a problem with the <paramref name="outputFilePath"/>.
        /// </exception>
        /// <exception cref="Exception">
        /// Thrown when something else bad happens.
        /// </exception>
        public void WriteConversation(Conversation conversation, string outputFilePath) 
        {
            try
            {
                var writer = new StreamWriter(new FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite));

                var serialized = JsonConvert.SerializeObject(conversation, Formatting.Indented);

                writer.Write(serialized);

                writer.Flush();

                writer.Close();
            }
            catch (SecurityException inner)
            {
                throw new ArgumentException("No permission to file.", inner);
            }
            catch (DirectoryNotFoundException inner)
            {
                throw new ArgumentException("Path " + outputFilePath + " is invalid", inner);
            }
            catch (IOException inner)
            {
                throw new Exception("Something went wrong in the IO.", inner);
            }
        }
    }
}

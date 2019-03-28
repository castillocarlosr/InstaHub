namespace InstaHub_MVC.Models.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IMessages" />
    /// </summary>
    public interface IMessages
    {
        /// <summary>
        /// The AddMessage
        /// </summary>
        /// <param name="message">The message<see cref="Message"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task AddMessage(Message message);

        /// <summary>
        /// The GetMessages
        /// </summary>
        /// <param name="groupName">The groupName<see cref="int"/></param>
        /// <returns>The <see cref="Task{IEnumerable{Message}}"/></returns>
        Task<IEnumerable<Message>> GetMessages(int groupName);
    }
}

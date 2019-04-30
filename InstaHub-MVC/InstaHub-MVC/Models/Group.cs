namespace InstaHub_MVC.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Group" />
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the GroupType
        /// </summary>
        public GroupType GroupType { get; set; }

        /// <summary>
        /// Defines the Messages
        /// </summary>
        public ICollection<Message> Messages;

        /// <summary>
        /// Defines the Users
        /// </summary>
        public ICollection<ApplicationUser> Users;
    }

    /// <summary>
    /// Defines the GroupType
    /// </summary>
    public enum GroupType
    {
        /// <summary>
        /// Defines the DM
        /// </summary>
        DM,

        /// <summary>
        /// Defines the Public
        /// </summary>
        Public,

        /// <summary>
        /// Defines the Private
        /// </summary>
        Private
    }
}

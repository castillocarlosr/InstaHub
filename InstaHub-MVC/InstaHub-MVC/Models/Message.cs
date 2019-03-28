namespace InstaHub_MVC.Models
{
    using System;

    /// <summary>
    /// Defines the <see cref="Message" />
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the GroupName
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Defines the Group
        /// </summary>
        public Group Group;

        /// <summary>
        /// Defines the User
        /// </summary>
        public ApplicationUser User;
    }
}

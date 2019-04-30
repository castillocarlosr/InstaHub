namespace InstaHub_MVC.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the class for the application user<see cref="ApplicationUser" />
    /// </summary>
    public class ApplicationUser
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Avatar
        /// </summary>
        public string Avatar { get; set; }

       /// <summary>
       ///  Navigation Property to Groups Class
       /// </summary>
        public ICollection<Group> Groups;
    }
}

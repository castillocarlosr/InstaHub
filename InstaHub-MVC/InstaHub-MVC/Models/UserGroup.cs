namespace InstaHub_MVC.Models
{
    /// <summary>
    /// Defines the <see cref="UserGroup" />
    /// </summary>
    public class UserGroup
    {
        /// <summary>
        /// Gets or sets the UserID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the GroupID
        /// </summary>
        public int GroupID { get; set; }

        /// <summary>
        /// Defines the User
        /// </summary>
        public ApplicationUser User;

        /// <summary>
        /// Defines the Group
        /// </summary>
        public Group Group;
    }
}

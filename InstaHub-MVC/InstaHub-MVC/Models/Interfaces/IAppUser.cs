namespace InstaHub_MVC.Models.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IAppUser" />
    /// </summary>
    public interface IAppUser
    {
        /// <summary>
        /// The AddAppUser
        /// </summary>
        /// <param name="appUser">The appUser<see cref="ApplicationUser"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task AddAppUser(ApplicationUser appUser);

        /// <summary>
        /// The GetApplicationUserByEmail
        /// </summary>
        /// <param name="email">The email<see cref="string"/></param>
        /// <returns>The <see cref="Task{ApplicationUser}"/></returns>
        Task<ApplicationUser> GetApplicationUserByEmail(string email);
    }
}

using Microsoft.AspNetCore.Identity;
using Parcial3_AriasRoldanNatalia.DAL.Entities;
using Parcial3_AriasRoldanNatalia.Models;

namespace Parcial3_AriasRoldanNatalia.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task AddRoleAsync(string roleName); //Yo tengo los Roles: Admin y User, estos dos roles los va a agregar en la tabla AspNetRoles

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

       Task<SignInResult> LoginAsync(LoginViewModel loginViewModel);

        Task LogoutAsync();
    }
}

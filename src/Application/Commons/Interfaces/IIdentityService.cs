using Application.Commons.Models;

namespace Application.Commons.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> CheckPasswordAsync(string username, string password);
        Task<string?> GetUserNameAsync(string userId);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}

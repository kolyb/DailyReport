using DailyReport.BusinessLogic.ModelsDTO.IdentityDTO;
using Microsoft.AspNetCore.Identity;

namespace DailyReport.BusinessLogic.Interfaces.IdentityInterface
{
    public interface IUserIdentity
    {
        //Registration
        Task CreateAsync(UserIdentityDTO item);
        //Login
        Task<SignInResult> Authenticate(UserIdentityDTO item);
        //Log out
        Task SignOut();
    }
}

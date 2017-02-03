using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EastFive.Api.Services
{
    public interface IIdentityService
    {
        Task<TResult> ValidateToken<TResult>(string idToken,
            Func<ClaimsPrincipal, TResult> onSuccess,
            Func<string, TResult> onFailed);

        Task<TResult> CreateLoginAsync<TResult>(string displayName,
            string userId, bool isEmail, string secret, bool forceChange,
            Func<Guid, TResult> onSuccess,
            Func<Guid, TResult> usernameAlreadyInUse,
            Func<TResult> onPasswordInsufficent,
            Func<string, TResult> onFail);

        Task<TResult> GetLoginAsync<TResult>(Guid loginId,
            Func<string, bool, bool, TResult> onSuccess,
            Func<TResult> onNotFound,
            Func<string, TResult> onServiceNotAvailable);

        Task<TResult> UpdateLoginPasswordAsync<TResult>(Guid loginId, string password, bool forceChange,
            Func<TResult> onSuccess,
            Func<string, TResult> onServiceNotAvailable,
            Func<string, TResult> onFailure);

        Task DeleteLoginAsync(Guid loginId);

        Uri GetLoginUrl(string redirect_uri, byte mode, byte[] state, Uri responseControllerLocation);
        Uri GetSignupUrl(string redirect_uri, byte mode, byte[] state, Uri responseControllerLocation);
        Uri GetLogoutUrl(string redirect_uri, byte mode, byte[] state, Uri responseControllerLocation);

        TResult ParseState<TResult>(string state,
            Func<Uri, byte, byte[], TResult> onSuccess,
            Func<string, TResult> invalidState);

    }
}

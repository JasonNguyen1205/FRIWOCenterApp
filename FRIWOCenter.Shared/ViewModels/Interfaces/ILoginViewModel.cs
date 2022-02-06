using FRIWOCenter.Shared.Models;
using FRIWOCenter.Shared.Models.Twitter;
using System.Threading.Tasks;

namespace FRIWOCenter.Shared.ViewModels.Interfaces
{
    public interface ILoginViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public Task LoginUser();
        public Task<AuthenticationResponse> AuthenticateJWT();
        public Task<string> GetFacebookAppIDAndRedirectUriAsync();
        public Task<TwitterRequestTokenResponse> GetTwitterOAuthTokenAsync();
        public Task<string> GetGoogleClientIDAndRedirectUriAsync();
        public Task<User> GetUserByJWTAsync(string jwtToken);
        public Task<string> GetTwitterJWTAsync(TwitterRequestTokenResponse twitterRequestTokenResponse);
        public Task<string> GetFacebookJWTAsync(string accessToken);
    }
}
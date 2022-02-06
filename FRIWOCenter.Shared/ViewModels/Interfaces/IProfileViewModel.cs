using System.Threading.Tasks;

namespace FRIWOCenter.Shared.ViewModels.Interfaces
{
    public interface IProfileViewModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public string AboutMe { get; set; }
        public string ProfilePicDataUrl { get; set; }

        public Task UpdateProfile();
        public Task GetProfile();
    }
}

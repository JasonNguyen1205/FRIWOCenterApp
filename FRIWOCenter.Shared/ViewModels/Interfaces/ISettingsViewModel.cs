using System.Threading.Tasks;

namespace FRIWOCenter.Shared.ViewModels.Interfaces
{
    public interface ISettingsViewModel
    {
        public long UserId { get; set; }
        public bool Notifications { get; set; }
        public bool DarkTheme { get; set; }

        public Task UpdateTheme();
        public Task UpdateNotifications();
        public Task GetProfile();
    }
}

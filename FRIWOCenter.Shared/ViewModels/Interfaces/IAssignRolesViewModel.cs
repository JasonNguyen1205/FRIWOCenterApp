using FRIWOCenter.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FRIWOCenter.Shared.ViewModels.Interfaces
{
    public interface IAssignRolesViewModel
    {
        public IEnumerable<User> AllUsers { get; }

        public Task LoadAllUsers();
        public Task AssignRole(long userId, string role);
        public Task DeleteUser(long userId);
    }
}

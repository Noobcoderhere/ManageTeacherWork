using Teacher_Manage_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Core.ViewModel.Person;

namespace Teacher_Manage_Service.Service.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<UserVM>> GetUsers(bool allowTracking = true);
        UserVM GetUserByID(int id);
        UserVM GetUserByUsername(string name, bool allowTracking = true);
        Task<int> Login(string username, string password);
        bool AddUser(UserVM userVM);
        Task<bool> UpdateUser(UserVM userVM);
        bool DeleteUser(int id);

    }
}

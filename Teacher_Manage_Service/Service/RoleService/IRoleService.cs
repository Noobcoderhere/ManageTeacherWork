using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel;

namespace Teacher_Manage_Service.Service.RoleService
{
    public interface IRoleService
    {
        IEnumerable<GroupUserVM> GetRoles();
    }
}

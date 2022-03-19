using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Teacher_Manage_Core.ViewModel;
using Teacher_Manage_Repository.Repository.GroupUserRepo;

namespace Teacher_Manage_Service.Service.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IGroupUserRepository _groupUserRepository;

        public RoleService(IMapper mapper, IGroupUserRepository groupUserRepository)
        {
            _mapper = mapper;
            _groupUserRepository = groupUserRepository;
        }

        public IEnumerable<GroupUserVM> GetRoles()
        {
            var listRole = _groupUserRepository.GetAll();
            var listRoleVM = listRole.Select(x => _mapper.Map<GroupUserVM>(x));
            return listRoleVM;
        }
    }
}

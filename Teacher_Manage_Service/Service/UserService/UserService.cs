using AutoMapper;
using Teacher_Manage_Core;
using Managing_Teacher_Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teacher_Manage_Core.ViewModel.Person;
using Teacher_Manage_Repository.Contract;

namespace Teacher_Manage_Service.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool AddUser(UserVM userVM)
        {
            try
            {
                userVM.Name = userVM.Name.ToString().Trim();
                userVM.UserName = userVM.UserName.ToString().Trim();
                userVM.Password = Encryptor.MD5Hash(userVM.Password.Trim());
                userVM.Phone = userVM.Phone.ToString().Trim();
                userVM.Email = userVM.Email.ToString().Trim();
                userVM.CreatedDate = userVM.CreatedDate.GetValueOrDefault(DateTime.Now);
                userVM.ModifiedDate = userVM.ModifiedDate.GetValueOrDefault(DateTime.Now);
                var user = _mapper.Map<User>(userVM);
                _unitOfWork.User.Add(user);
                var check = _unitOfWork.Save();
                if(!check)
                {
                    return false;
                }    
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var user = _unitOfWork.User.GetById(id);
                if (user == null)
                {
                    return false;
                }
                _unitOfWork.User.Delete(user);
                var check =_unitOfWork.Save();
                if(!check)
                {
                    return false;
                }    
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public UserVM GetUserByID(int id)
        {
            var user = _unitOfWork.User.GetById(id);
            return _mapper.Map<UserVM>(user);
        }

        public UserVM GetUserByUsername(string username, bool allowTracking = true)
        {
            var user = _unitOfWork.User.Get(x => x.UserName.Equals(username) , allowTracking);
            return _mapper.Map<UserVM>(user);
        }

        public async Task<IEnumerable<UserVM>> GetUsers(bool allowTracking = true)
        {
            var users = await _unitOfWork.User.GetAllAsync(allowTracking);
            var lstUserVM = users.Select(x => _mapper.Map<UserVM>(x));
            return lstUserVM;
        }

        public async Task<int> Login(string username, string password)
        {
            var lstUser = await _unitOfWork.User.GetAllAsync();
            var user = lstUser.FirstOrDefault(x => x.UserName.Equals(username));
            if (user == null)
            {
                return 0;
            }
            else
            {
                if (user.GroupID == "ADMIN" || user.GroupID == "MEMBER")
                {
                    if (user.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (user.Password.Equals(password))
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }    
                    }
                }
                else
                {
                    return -3;
                }    
            }
        }

        public async Task<bool> UpdateUser(UserVM userVM)
        {
            try
            {
                userVM.Name = userVM.Name.ToString().Trim();
                userVM.UserName = userVM.UserName.ToString().Trim();
                userVM.Password = Encryptor.MD5Hash(userVM.Password.Trim());
                userVM.GroupID = userVM.GroupID;
                userVM.Status = userVM.Status;
                userVM.Phone = userVM.Phone.ToString().Trim();
                userVM.Email = userVM.Email.ToString().Trim();
                userVM.ModifiedDate = userVM.CreatedDate.GetValueOrDefault(System.DateTime.Now);
                var userToUpdate = _mapper.Map<User>(userVM);
                _unitOfWork.User.Update(userToUpdate);
                var check = await _unitOfWork.SaveAsync();
                if(!check)
                {
                    return false;
                }    
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}

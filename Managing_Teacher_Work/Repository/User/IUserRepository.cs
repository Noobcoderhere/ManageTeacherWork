using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managing_Teacher_Work.Repository.User
{
    public interface IUserRepository
    {
        Task AddOrUpdate();
    }
}

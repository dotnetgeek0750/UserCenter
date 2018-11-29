using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCenter.DTO;
using UserCenter.IServices;

namespace UserCenter.Services.Services
{
    public class UserGroupService : IUserGroupService
    {
        public Task AddUserToGroupAsync(long userGroupId, long userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserGroupDTO> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<UserGroupDTO[]> GetGroupsAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO[]> GetGroupUsersAsync(long userGroupId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserFromGroupAsync(long userGroupId, long userId)
        {
            throw new NotImplementedException();
        }
    }
}

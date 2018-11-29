using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCenter.DTO;
using UserCenter.IServices;

namespace UserCenter.Services.Services
{
    public class UserService : IUserService
    {
        public Task<long> AddNewAsync(string phoneNum, string nickName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckLoginAsync(string phoneNum, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByIdAsync(long id)
        {
            using (var db = new UserCenterContext())
            {
                var user = await db.Users.SingleOrDefaultAsync(p => p.Id == id);
                if (user == null)
                {
                    return null;
                }
                else
                {
                    return new UserDTO
                    {
                        Id = user.Id,
                        NickName = user.NickName,
                        PhoneNum = user.PhoneNum,
                    };
                }

            }
        }

        public Task<UserDTO> GetByPhoneNumAsync(string phoneNum)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsAsync(string phoneNum)
        {
            throw new NotImplementedException();
        }
    }
}

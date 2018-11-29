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
    public class AppInfoService : IAppInfoService
    {
        public async Task<AppInfoDTO> GetByAppKeyAsync(string appKey)
        {
            using (var db = new UserCenterContext())
            {
                var app = await db.AppInfos.Where(p => p.AppKey == appKey).FirstOrDefaultAsync();
                if (app == null)
                {
                    return null;
                }
                else
                {
                    return new AppInfoDTO
                    {
                        Id = app.Id,
                        IsEnabled = app.IsEnabled,
                        AppKey = app.AppKey,
                        AppSecret = app.AppSecret,
                        Name = app.Name,
                    };
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCenter.Services.Entities;
using UserCenter.Services.ModelConfig;

namespace UserCenter.Services
{
    public class UserCenterContext : DbContext
    {
        public UserCenterContext() : base("connstr")
        {
            //Code First 最佳做法，首次创建完DB之后，加上这句话，后续不让EF再生成DB了
            Database.SetInitializer<UserCenterContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AppInfosConfig());
            modelBuilder.Configurations.Add(new UserGroupsConfig());
            modelBuilder.Configurations.Add(new UsersConfig());
        }

        public DbSet<AppInfos> AppInfos { get; set; }

        public DbSet<UserGroups> UserGroups { get; set; }

        public DbSet<Users> Users { get; set; }
    }
}

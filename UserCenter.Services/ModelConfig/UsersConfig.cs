using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCenter.Services.Entities;

namespace UserCenter.Services.ModelConfig
{
    public class UsersConfig : EntityTypeConfiguration<Users>
    {
        public UsersConfig()
        {
            this.ToTable("T_Users");
            this.HasMany(p => p.Groups).WithMany(p => p.Users)
                .Map(p => p.ToTable("T_GroupUsers").MapLeftKey("UserId").MapRightKey("GroupId"));
        }
    }
}

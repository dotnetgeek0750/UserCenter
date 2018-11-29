using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCenter.Services.Entities;

namespace UserCenter.Services.ModelConfig
{
    public class UserGroupsConfig : EntityTypeConfiguration<UserGroups>
    {
        public UserGroupsConfig()
        {
            this.ToTable("T_UserGroups");
        }
    }
}

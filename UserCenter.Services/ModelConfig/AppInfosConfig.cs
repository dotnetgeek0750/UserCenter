using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCenter.Services.Entities;

namespace UserCenter.Services.ModelConfig
{
    public class AppInfosConfig : EntityTypeConfiguration<AppInfos>
    {
        public AppInfosConfig()
        {
            this.ToTable("T_AppInfos");
        }
    }
}

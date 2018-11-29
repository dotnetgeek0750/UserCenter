using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCenter.Services.Entities
{
    public class UserGroups : BaseModel
    {

        public string Name { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}

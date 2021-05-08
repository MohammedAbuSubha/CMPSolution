using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP.Business.DTO.Identity
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string RoleName { get; set; }
        public RoleViewModel Role { get; set; }

    }
}

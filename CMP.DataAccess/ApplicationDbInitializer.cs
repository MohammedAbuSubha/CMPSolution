using CMP.DataAccess.Model;
using CMP.Infrastructure.Common.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace CMP.DataAccess
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Roles.Add(new IdentityRole() { Id = ((int)AccountRoleEnum.Admin).ToString(), Name = "Admin"  });
            context.Roles.Add(new IdentityRole() { Id = ((int)AccountRoleEnum.User).ToString(), Name = "User"});

            base.Seed(context);
        }
    }
}

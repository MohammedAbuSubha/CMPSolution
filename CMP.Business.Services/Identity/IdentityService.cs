using CMP.Business.DTO.Identity;
using CMP.Business.Services.AutoMapper;
using CMP.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CMP.Business.Services.Identity
{
    public class IdentityService : BaseService
    {
        public IdentityService() : base()
        {

        }


        public async Task<int> CreateNewUser(string email, string roleId)
        {
            using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
            {
                ApplicationUser applicationUser = applicationDbContext.Users.FirstOrDefault(a => a.Email == email);
                applicationUser.RoleId = roleId;
                applicationUser.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole()
                {
                    RoleId = roleId,
                    UserId = applicationUser.Id,
                }); ;

                return await applicationDbContext.SaveChangesAsync();
            }
        }

        public List<UserViewModel> GetUsers()
        {
            using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
            {
                return AutoMapperConfiguration.Mapper.Map<List<UserViewModel>>(applicationDbContext.Users.Include(a => a.Role).ToList());
            }
        }
    }
}

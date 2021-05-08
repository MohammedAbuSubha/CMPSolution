using AutoMapper;
using CMP.Business.DTO.Identity;
using CMP.DataAccess.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CMP.Business.Services.AutoMapper.Profiles
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<IdentityRole, RoleViewModel>();
            CreateMap<RoleViewModel, IdentityRole>();

            CreateMap<ApplicationUser, UserViewModel>().ForMember(src => src.RoleName, opt => opt.MapFrom(x => x.Role.Name));
            CreateMap<UserViewModel, ApplicationUser>();

            CreateMap<ApplicationUser, LoginViewModel>();
            CreateMap<LoginViewModel, ApplicationUser>();

            CreateMap<ApplicationUser, RegisterViewModel>();
            CreateMap<RegisterViewModel, ApplicationUser>();
        }

    }
}

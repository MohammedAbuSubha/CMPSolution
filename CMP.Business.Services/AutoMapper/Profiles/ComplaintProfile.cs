using AutoMapper;
using CMP.Business.DTO.Complaint;
using CMP.DataAccess.Model;


namespace CMP.Business.Services.AutoMapper.Profiles
{
    public class ComplaintProfile : Profile
    {
        public ComplaintProfile()
        {
            CreateMap<ComplaintStatusViewModel, ComplaintStatus>();
            CreateMap<ComplaintStatus, ComplaintStatusViewModel>();

            CreateMap<ComplaintViewModel, DataAccess.Model.Complaint>();
            CreateMap<DataAccess.Model.Complaint, ComplaintViewModel>().ForMember(src => src.CreateByUserName, opt => opt.MapFrom(dest => dest.CreateByUser.UserName));
        }
    }
}

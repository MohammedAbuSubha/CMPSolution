using AutoMapper;
using CMP.Business.Services.AutoMapper.Profiles;

namespace CMP.Business.Services.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; set; }

        public static void ConfigureMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<IdentityProfile>();
                cfg.AddProfile<ComplaintProfile>();
            });

            Mapper = configuration.CreateMapper();
        }
    }
}

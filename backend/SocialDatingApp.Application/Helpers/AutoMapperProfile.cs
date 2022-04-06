using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Basic
            //CreateMap<fromClass, toClass>();

            //Advanced
            //CreateMap<fromClass, toClass>()
            //    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}

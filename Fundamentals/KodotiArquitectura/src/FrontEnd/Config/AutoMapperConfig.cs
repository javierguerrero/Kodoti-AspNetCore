using AutoMapper;
using DomainLayer.Identity;
using DtoLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Config
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ApplicationUser, UserGetDto>().ReverseMap();
            });
        }
    }
}

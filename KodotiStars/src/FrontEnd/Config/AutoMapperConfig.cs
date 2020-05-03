using AutoMapper;
using DomainLayer;
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
                cfg.CreateMap<ArtistCreateDto, Artist>();
                cfg.CreateMap<ArtistUpdateDto, Artist>();

                cfg.CreateMap<AlbumDto, Album>();
                cfg.CreateMap<AlbumCreateDto, Album>();
                
            });
        }
    }
}

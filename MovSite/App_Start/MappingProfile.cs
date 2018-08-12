using AutoMapper;
using MovSite.DTOs;
using MovSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovSite.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<TVShow, TVShowDto>();
            CreateMap<TVShowDto, TVShow>().ForMember(t => t.Id, opt => opt.Ignore());
        }
    }
}
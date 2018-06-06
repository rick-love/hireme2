using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HireMe2.Dtos;
using HireMe2.Models;

namespace HireMe2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Candidate, CandidateDto>();
            Mapper.CreateMap<CandidateDto, Candidate>();
        }
    }
}
using AutoMapper;
using CronJob.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CronJob.Dto.Mapper
{
  public  class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //CreateMap metodu ile entity ve dtoları eşleştirip mapliyoruz
            //ReversMap komutu ise bu mappingin iki yönlü olduğunu bildiriyor.
            CreateMap<Demo, DemoDto>().ReverseMap();
            

          
        }
    }
}

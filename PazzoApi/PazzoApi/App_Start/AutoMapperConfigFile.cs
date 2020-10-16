using AutoMapper;
using PazzoApi.DB;
using PazzoApo.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PazzoApi.App_Start
{
    public class AutoMapperConfigFile : Profile
    {
        public AutoMapperConfigFile()
        {
            CreateMap<ProductsBM, Products>().ReverseMap();
            CreateMap<Products, ProductsBM>().ReverseMap();
        }
    }
}
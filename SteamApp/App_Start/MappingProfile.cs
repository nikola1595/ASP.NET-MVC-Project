using AutoMapper;
using SteamApp.Dtos;
using SteamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApp.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Client, ClientDto>();
            Mapper.CreateMap<ClientDto, Client>();
            
            Mapper.CreateMap<ConsoleType, ConsoleTypeDto>();

            //Dto to Domain
            Mapper.CreateMap<ClientDto, Client>()
                .ForMember(c => c.ClientID, opt => opt.Ignore());


         

        }
    }
}
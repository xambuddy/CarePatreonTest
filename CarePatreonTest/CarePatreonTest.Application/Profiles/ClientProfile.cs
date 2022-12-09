using AutoMapper;
using CarePatreonTest.Application.Commands;
using CarePatreonTest.Application.Models;
using CarePatreonTest.Core.Entities;

namespace CarePatreonTest.Application.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            this.CreateMap<CreateClientDto, CreateClientCommand>();
            this.CreateMap<CreateClientCommand, Client>();
            this.CreateMap<UpdateClientDto, UpdateClientCommand>();
            this.CreateMap<UpdateClientCommand, Client>();
            this.CreateMap<Client, ClientDto>();
        }
    }
}

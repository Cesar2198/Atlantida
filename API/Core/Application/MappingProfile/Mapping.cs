
using API.Core.Application.Features.FeatureTarjeta.DTOs;
using API.Core.Domain;
using AutoMapper;
using static API.Core.Application.Features.FeatureTarjeta.Commands.AddTarjeta;

namespace API.Core.Application.MappingProfile
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AddTarjetaCommand, TarjetasCredito>();
            CreateMap<TarjetasCredito, TarjetasCreditoDto>();
        }
    }
}

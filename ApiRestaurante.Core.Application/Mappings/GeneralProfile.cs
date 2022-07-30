using AutoMapper;
using ApiRestaurante.Core.Application.ViewModels.User;
using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Core.Application.ViewModels.Ingredientes;
using ApiRestaurante.Core.Application.ViewModels.Platos;
using ApiRestaurante.Core.Application.ViewModels.Mesas;
using ApiRestaurante.Core.Application.ViewModels.Orden;
using ApiRestaurante.Core.Application.ViewModels.DetalleOrden;

namespace ApiRestaurante.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Ingredientes, IngredientesViewModel>()
                .ReverseMap();

            CreateMap<Ingredientes, SaveIngredientesViewModel>()
                .ReverseMap();

            CreateMap<Platos, PlatosViewModel>()
                .ReverseMap();

            CreateMap<Platos, SavePlatosViewModel>()
                .ReverseMap();

            CreateMap<Mesas, MesasViewModel>()
                .ReverseMap();

            CreateMap<Mesas, SaveMesasViewModel>()
                .ReverseMap();

            CreateMap<Orden, OrdenViewModel>()
                .ReverseMap();

            CreateMap<Orden, SaveOrdenViewModel>()
                .ReverseMap();

            CreateMap<DetalleOrden, DetalleOrdenViewModel>()
                .ReverseMap();

            CreateMap<DetalleOrden, SaveDetalleOrdenViewModel>()
                .ReverseMap();

            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}

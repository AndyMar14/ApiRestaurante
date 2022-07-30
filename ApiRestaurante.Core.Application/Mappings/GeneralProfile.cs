using AutoMapper;
using ApiRestaurante.Core.Application.ViewModels.User;
using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Core.Application.ViewModels.Ingredientes;
using ApiRestaurante.Core.Application.ViewModels.Platos;
using ApiRestaurante.Core.Application.ViewModels.Mesas;
using ApiRestaurante.Core.Application.ViewModels.DetallePlatos;

namespace ApiRestaurante.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Ingredientes, IngredientesViewModel>()
                .ReverseMap();

            CreateMap<Ingredientes, SaveIngredientesViewModel>()
                .ReverseMap()
                .ForMember(x => x.DetallePLatos, opt => opt.Ignore());

            CreateMap<Platos, PlatosViewModel>()
                .ForMember(x => x.Ingredientes, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Platos, SavePlatosViewModel>()
                .ForMember(x => x.Ingredientes, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PlatosViewModel, SavePlatosViewModel>()
            .ForMember(x => x.Ingredientes, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.Ingredientes, opt => opt.Ignore());



            CreateMap<Mesas, MesasViewModel>()
                .ReverseMap();

            CreateMap<Mesas, SaveMesasViewModel>()
                .ReverseMap();

            CreateMap<DetallePlatos, SaveDetallePlatosViewModel>()
                .ReverseMap();

            CreateMap<DetallePlatos, DetallePlatosViewModel>()
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

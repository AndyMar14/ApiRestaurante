﻿using AutoMapper;
using ApiRestaurante.Core.Application.ViewModels.User;
using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Core.Application.ViewModels.Ingredientes;

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
using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.ViewModels.Platos;
using ApiRestaurante.Core.Domain.Entities;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Services
{
    class PlatosService : GenericService<SavePlatosViewModel, PlatosViewModel, Platos>,IPlatosService
    {
        private readonly IPlatosRepository _platosRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PlatosService(IPlatosRepository ingredientesRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(ingredientesRepository, mapper)
        {
            _platosRepository = ingredientesRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }
    }
}

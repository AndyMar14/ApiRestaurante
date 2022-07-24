using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.ViewModels.Ingredientes;
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
    public class IngredientesService : GenericService<SaveIngredientesViewModel, IngredientesViewModel, Ingredientes>,IIngredientesService
    {
        private readonly IIngredientesRepository _ingredientesRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IngredientesService(IIngredientesRepository ingredientesRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(ingredientesRepository, mapper)
        {
            _ingredientesRepository = ingredientesRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }
    }
}

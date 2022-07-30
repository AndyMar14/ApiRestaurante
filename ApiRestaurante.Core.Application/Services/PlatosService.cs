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
        private readonly IDetallePlatosRepository _detallePlatosRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PlatosService(IDetallePlatosRepository detallePlatosRepository,IPlatosRepository platosRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(platosRepository, mapper)
        {
            _platosRepository = platosRepository;
            _detallePlatosRepository = detallePlatosRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }

        public override async Task<List<PlatosViewModel>> GetAllViewModel()
        {
            List<PlatosViewModel> platos = await base.GetAllViewModel();

            foreach (var plato in platos)
            {
                List<DetallePlatos> DetallePLatos = await _detallePlatosRepository.GetAllAsync(plato.Id);
                plato.Ingredientes = DetallePLatos.Select(ingre => new ViewModels.Ingredientes.IngredientesViewModel { 
                    Id = ingre.Ingrediente.Id,
                    Nombre = ingre.Ingrediente.Nombre
                }).ToList();
            }
            return platos;
        }

        public async Task<PlatosViewModel> GetPlatoById(int Id)
        {
            var plato = await base.GetByIdSaveViewModel(Id);
            PlatosViewModel platoVm = _mapper.Map<PlatosViewModel>(plato);

            var DetallePLato = await _detallePlatosRepository.GetAllAsync(Id);
            platoVm.Ingredientes = DetallePLato.Select(ingre => new ViewModels.Ingredientes.IngredientesViewModel
            {
                Id = ingre.Ingrediente.Id,
                Nombre = ingre.Ingrediente.Nombre
            }).ToList();

            return platoVm;
        }
    }
}

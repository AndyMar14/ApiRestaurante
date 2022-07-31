using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.ViewModels.DetalleOrden;
using ApiRestaurante.Core.Application.ViewModels.Orden;
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
    class OrdenService : GenericService<SaveOrdenViewModel, OrdenViewModel, Orden>, IOrdenesService
    {
        private readonly IOrdenesRepository _ordenRepository;
        private readonly IDetalleOrdenesService _detalleOrdenService;
        private readonly IPlatosService _platosService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrdenService(IOrdenesRepository ordenRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor,IDetalleOrdenesService detalleOrdenService, IPlatosService platosService) : base(ordenRepository, mapper)
        {
            _ordenRepository = ordenRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _detalleOrdenService = detalleOrdenService;
            _platosService = platosService;
        }

        public override async Task<SaveOrdenViewModel> Add(SaveOrdenViewModel vm)
        {
            Orden entity = _mapper.Map<Orden>(vm);
            entity = await _ordenRepository.AddAsync(entity);

            SaveOrdenViewModel svm = _mapper.Map<SaveOrdenViewModel>(entity);

            foreach (SaveDetalleOrden2ViewModel item in vm.DetalleOrden)
            {

                SaveDetalleOrdenViewModel dvm = new();
                dvm.IdOrden = svm.Id;
                dvm.IdPlato = item.IdPlato;
                await _detalleOrdenService.Add(dvm);
            }
            return svm;
        }

        public override async Task Update(SaveOrdenViewModel vm, int Id)
        {

            foreach (SaveDetalleOrden2ViewModel item in vm.DetalleOrden)
            {
                SaveDetalleOrdenViewModel dvm = new();
                dvm.IdOrden = Id;
                dvm.IdPlato = item.IdPlato;
                await _detalleOrdenService.Add(dvm);
            }

        }

        public override async Task<List<OrdenViewModel>> GetAllViewModel()
        {
            var ordenList = await _ordenRepository.GetAllWithIncludeAsync(new List<string> { "Platos" });

            List<OrdenViewModel> List = ordenList.Select(orden => new OrdenViewModel
            {
                Id = orden.Id,
                IdMesa = orden.IdMesa,
                Platos = orden.Platos.Where(d => d.IdOrden == orden.Id)
                .Select(d => new DetalleOrdenViewModel
                {
                    IdPlato     = d.IdPlato
                }).ToList()
            }).ToList();


            foreach (OrdenViewModel orden in List)
            {
                foreach (DetalleOrdenViewModel p in orden.Platos)
                {
                    var platos = await _platosService.GetPlatoById(p.IdPlato);
                    p.PlatosOrden = platos;
                }
            }

            return List;
        }
    }
}

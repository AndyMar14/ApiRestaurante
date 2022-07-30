using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.ViewModels.DetalleOrden;
using ApiRestaurante.Core.Application.ViewModels.Orden;
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
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrdenService(IOrdenesRepository ordenRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor,IDetalleOrdenesService detalleOrdenService) : base(ordenRepository, mapper)
        {
            _ordenRepository = ordenRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _detalleOrdenService = detalleOrdenService;
        }

        public override async Task<SaveOrdenViewModel> Add(SaveOrdenViewModel vm)
        {
            Orden entity = _mapper.Map<Orden>(vm);
            entity = await _ordenRepository.AddAsync(entity);

            SaveOrdenViewModel svm = _mapper.Map<SaveOrdenViewModel>(entity);

            foreach (SaveDetalleOrden2ViewModel item in vm.DetalleOrden)
            {
                DetalleOrden entityDetalle = _mapper.Map<DetalleOrden>(item);
                entityDetalle.IdPlato = item.IdPlato;
                entityDetalle.IdOrden = entity.Id;

                SaveDetalleOrdenViewModel dvm = new();
                dvm.IdOrden = svm.Id;
                dvm.IdPlato = item.IdPlato;
                await _detalleOrdenService.Add(dvm);
            }
            return svm;
        }

        public override async Task<List<OrdenViewModel>> GetAllViewModel()
        {
            var ordenList = await _ordenRepository.GetAllWithIncludeAsync(new List<string> { "Platos" });

            return ordenList.Select(orden => new OrdenViewModel
            {
                Id = orden.Id,
                IdMesa = orden.IdMesa,
                Platos = (ICollection<DetalleOrdenViewModel>)orden.Platos.Where(d => d.IdOrden == orden.Id)
                .Select(d => new DetalleOrdenViewModel
                {
                    IdPlato = d.IdPlato
                }).ToList()
            }).ToList();
        }
    }
}

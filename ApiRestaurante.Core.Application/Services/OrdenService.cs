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
        private readonly IDetalleOrdenRepository _detalleOrdenRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrdenService(IOrdenesRepository ordenRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(ordenRepository, mapper)
        {
            _ordenRepository = ordenRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<SaveOrdenViewModel> Add(SaveOrdenViewModel vm)
        {
            Orden entity = _mapper.Map<Orden>(vm);
            entity = await _ordenRepository.AddAsync(entity);

            SaveOrdenViewModel svm = _mapper.Map<SaveOrdenViewModel>(entity);

            foreach (SaveDetalleOrdenViewModel item in vm.DetalleOrden)
            {
                DetalleOrden entityDetalle = _mapper.Map<DetalleOrden>(item);
                entityDetalle.IdPlato = item.IdPlato;
                entityDetalle.IdOrden = entity.Id;
                await _detalleOrdenRepository.AddAsync(entityDetalle);
            }
            return svm;
        }

        //public virtual async Task<SaveOrdenViewModel> Add(SaveOrdenViewModel vm)
        //{
        //    Model entity = _mapper.Map<Model>(vm);

        //    entity = await _repository.AddAsync(entity);

        //    SaveViewModel categoryVm = _mapper.Map<SaveViewModel>(entity);
        //    return categoryVm;
        //}
    }
}

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
    class DetalleOrdenService : GenericService<SaveDetalleOrdenViewModel, DetalleOrdenViewModel, DetalleOrden>, IDetalleOrdenesService
    {
        private readonly IDetalleOrdenRepository _detalleOrdenRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DetalleOrdenService(IDetalleOrdenRepository detalleOrdenRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(detalleOrdenRepository, mapper)
        {
            _detalleOrdenRepository = detalleOrdenRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task DeleteAllAsync(int IdOrden)
        {
            await _detalleOrdenRepository.DeleteAllAsync(IdOrden);
        }
    }
}

using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.ViewModels.DetallePlatos;
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
    
    public class DetallePlatosService : GenericService<SaveDetallePlatosViewModel, DetallePlatosViewModel, DetallePlatos>,IDetallePlatosService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper; 
        private readonly IDetallePlatosRepository _detallePlatosRepository; 
        public DetallePlatosService(IDetallePlatosRepository detallePlatosRepository,IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(detallePlatosRepository, mapper)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _detallePlatosRepository = detallePlatosRepository;

        }

        public async Task DeleteAllAsync(int IdPlato)
        {
            await _detallePlatosRepository.DeleteAllAsync(IdPlato);
        }
    }
}

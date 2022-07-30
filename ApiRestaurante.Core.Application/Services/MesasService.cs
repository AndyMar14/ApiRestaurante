using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.ViewModels.Mesas;
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
    class MesasService : GenericService<SaveMesasViewModel, MesasViewModel, Mesas>,IMesasService
    {
        private readonly IMesasRepository _mesasRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MesasService(IMesasRepository mesasRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mesasRepository, mapper)
        {
            _mesasRepository = mesasRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<bool> ChangeStatus(int id, int statusMesa)
        {
            SaveMesasViewModel vm = new();
            vm = await base.GetByIdSaveViewModel(id);
            if (vm != null)
            {
                vm.Estado = statusMesa;
                await base.Update(vm, id);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

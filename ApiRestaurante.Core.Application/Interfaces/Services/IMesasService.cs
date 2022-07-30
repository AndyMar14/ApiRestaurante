using ApiRestaurante.Core.Application.ViewModels.Mesas;
using ApiRestaurante.Core.Application.ViewModels.Platos;
using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IMesasService : IGenericService<SaveMesasViewModel, MesasViewModel, Mesas>
    {
        Task<bool> ChangeStatus(int id, int status);
    }
}

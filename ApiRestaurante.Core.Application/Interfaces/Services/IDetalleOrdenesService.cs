using ApiRestaurante.Core.Application.ViewModels.DetalleOrden;
using ApiRestaurante.Core.Application.ViewModels.Mesas;
using ApiRestaurante.Core.Application.ViewModels.Orden;
using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IDetalleOrdenesService : IGenericService<SaveDetalleOrdenViewModel, DetalleOrdenViewModel, DetalleOrden>
    {
        Task DeleteAllAsync(int IdOrden);
    }
}

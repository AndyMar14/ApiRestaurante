using ApiRestaurante.Core.Application.ViewModels.DetallePlatos;
using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IDetallePlatosService : IGenericService<SaveDetallePlatosViewModel, DetallePlatosViewModel, DetallePlatos>
    {
        Task DeleteAllAsync(int IdPlato);
    }
}

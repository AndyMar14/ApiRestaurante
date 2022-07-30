using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Repositories
{
    public interface IDetallePlatosRepository : IGenericRepository<DetallePlatos>
    {
        Task DeleteAllAsync(int IdPlato);
        Task<List<DetallePlatos>> GetAllAsync(int IdPlato);
    }
}

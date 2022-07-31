using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Infrastructure.Persistence.Repositories
{
    public class DetalleOrdenRepository : GenericRepository<DetalleOrden>, IDetalleOrdenRepository
    {
        private readonly ApplicationContext _dbContext;

        public DetalleOrdenRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAllAsync(int IdOrden)
        {
            //_dbContext.Set<DetallePlatos>().RemoveRange(_dbContext.Set<DetallePlatos>().Where(c => c.IdPlato == IdPlato));
            _dbContext.Set<DetalleOrden>().Where(p => p.IdOrden == IdOrden)
              .ToList().ForEach(p => _dbContext.Set<DetalleOrden>().Remove(p));
            await _dbContext.SaveChangesAsync();
        }
    }
}

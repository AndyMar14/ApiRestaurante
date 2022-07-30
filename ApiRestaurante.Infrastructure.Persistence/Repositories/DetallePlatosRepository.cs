using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using Application.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Infrastructure.Persistence.Repositories
{
    public class DetallePlatosRepository : GenericRepository<DetallePlatos>, IDetallePlatosRepository
    {
        private readonly ApplicationContext _dbContext;

        public DetallePlatosRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAllAsync(int IdPlato)
        {
            //_dbContext.Set<DetallePlatos>().RemoveRange(_dbContext.Set<DetallePlatos>().Where(c => c.IdPlato == IdPlato));
             _dbContext.Set<DetallePlatos>().Where(p => p.IdPlato == IdPlato)
               .ToList().ForEach(p => _dbContext.Set<DetallePlatos>().Remove(p));
             await _dbContext.SaveChangesAsync();
        }

        public async Task<List<DetallePlatos>> GetAllAsync(int IdPlato)
        {
            return await _dbContext.Set<DetallePlatos>().Include(i => i.Ingrediente).Where(x=> x.IdPlato == IdPlato).ToListAsync();
        }
    }
}

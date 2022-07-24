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
    public class IngredientesRepository : GenericRepository<Ingredientes>,IIngredientesRepository
    {
        private readonly ApplicationContext _dbContext;

        public IngredientesRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

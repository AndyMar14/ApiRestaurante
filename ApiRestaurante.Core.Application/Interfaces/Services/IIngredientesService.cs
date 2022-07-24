using ApiRestaurante.Core.Application.ViewModels.Ingredientes;
using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IIngredientesService : IGenericService<SaveIngredientesViewModel, IngredientesViewModel, Ingredientes>
    {
    }
}

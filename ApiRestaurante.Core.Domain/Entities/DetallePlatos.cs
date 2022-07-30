using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class DetallePlatos
    {
        public int Id { get; set; }
        public int IdPlato { get; set; }
        public int IdIngrediente { get; set; }

        public Ingredientes Ingrediente { get; set; }
    }
}

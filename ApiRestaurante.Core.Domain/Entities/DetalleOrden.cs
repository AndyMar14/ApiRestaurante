using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class DetalleOrden
    {
        public int Id { get; set; }
        public int IdOrden { get; set; }
        public int IdPlato { get; set; }

        //Navigation property
        public Orden  Orden { get; set; }
        public Platos Platos  { get; set; }
    }
}

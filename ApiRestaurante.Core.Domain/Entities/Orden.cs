using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class Orden
    {
        public int Id { get; set; }
        public int IdMesa { get; set; }
        public float Subtotal { get; set; }
        public int  Estado{ get; set; }

        //Navigation property
        public ICollection<DetalleOrden> Platos { get; set; }
    }
}

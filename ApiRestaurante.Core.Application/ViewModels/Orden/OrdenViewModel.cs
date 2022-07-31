using ApiRestaurante.Core.Application.ViewModels.DetalleOrden;
using ApiRestaurante.Core.Application.ViewModels.Mesas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.Orden
{
    public class OrdenViewModel
    {
        public int Id { get; set; }
        public int IdMesa { get; set; }
        public float Subtotal { get; set; }
        public int Estado { get; set; }

        //Navigation property
        public ICollection<DetalleOrdenViewModel> Platos { get; set; }
        public ICollection<MesasViewModel> Mesa { get; set; }
    }
}

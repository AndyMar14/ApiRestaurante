using ApiRestaurante.Core.Application.ViewModels.Platos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.DetalleOrden
{
    public class DetalleOrdenViewModel
    {
        public int IdPlato { get; set; }
        public PlatosViewModel PlatosOrden { get; set; }
    }
}

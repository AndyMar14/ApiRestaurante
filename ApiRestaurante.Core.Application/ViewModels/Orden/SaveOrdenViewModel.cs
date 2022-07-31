using ApiRestaurante.Core.Application.ViewModels.DetalleOrden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.Orden
{
    public class SaveOrdenViewModel
    {
        public int Id { get; set; }
        public int IdMesa { get; set; }
        public ICollection<SaveDetalleOrden2ViewModel> DetalleOrden { get; set; }
    }
}

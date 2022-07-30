using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.Mesas
{
    public class SaveMesasViewModel
    {
        public int Id { get; set; }
        public string CantidadPersonas { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
    }
}

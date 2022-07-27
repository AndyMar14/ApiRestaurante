using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.Platos
{
    public class PlatosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int CantidadPersonas { get; set; }
        public string Ingredientes { get; set; }
        public string Categoria { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.ViewModels.DetallePlatos
{
    public class SaveDetallePlatosViewModel
    {
        public int Id { get; set; }
        public int IdPlato { get; set; }
        public int IdIngrediente { get; set; }
    }
}

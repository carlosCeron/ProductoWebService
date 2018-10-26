using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductoWebService.Models
{
    public class Producto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string correo { get; set; }
        public string pais { get; set; }
        public int precio { get; set; }
        public int undDisponibles { get; set; }
        public int undVendidas { get; set; }
        public string descripcion { get; set; }
    }
}

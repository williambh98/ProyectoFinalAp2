using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoArticulo
    {
        [Key]
        public int TiposId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public TipoArticulo()
        {
            TiposId = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            FechaCreacion = DateTime.Now;
        }

        public TipoArticulo(int tiposId, string nombre, string descripcion, DateTime fechaCreacion)
        {
            TiposId = tiposId;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaCreacion = fechaCreacion;
        }
    }
}

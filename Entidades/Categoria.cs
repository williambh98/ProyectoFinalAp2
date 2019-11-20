using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public Categoria()
        {
            CategoriaId = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Fecha = DateTime.Now;
        }

        public Categoria(int tiposId, string nombre, string descripcion, DateTime fechaCreacion)
        {
            CategoriaId = tiposId;
            Nombre = nombre;
            Descripcion = descripcion;
            Fecha = fechaCreacion;
        }
    }
}

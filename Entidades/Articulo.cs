using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Articulo
    {
        [Key]
        public int ArticuloID { get; set; }
        public int DepartamentoId { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double Cantidad { get; set; }


        public Articulo()
        {
            ArticuloID = 0;
            DepartamentoId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            FechaCreacion = DateTime.Now;
            Cantidad = 0;

        }

        public Articulo(int articuloID, int departamentoId, string descripcion, double costo, double cantidad, double precio, DateTime fechaCreacion)
        {
            ArticuloID = articuloID;
            DepartamentoId = departamentoId;
            Descripcion = descripcion;
            Costo = costo;
            Precio = precio;
            FechaCreacion = fechaCreacion;
            Cantidad = cantidad;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntradaDetalle
    {
        [Key]
        public int Id { get; set; }
        public int EntradaId { get; set; }
        public int ArticuloID { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        [ForeignKey("ArticuloID")]
        public virtual Articulo Articulo { get; set; }
        public EntradaDetalle()
        {
            Id = 0;
            Fecha = DateTime.Now;
            EntradaId = 0;
            ArticuloID = 0;
            Cantidad = 0;
            Precio = 0;
            FechaVencimiento = DateTime.Now;
        }
        public EntradaDetalle(int id, int entradaId, int articuloID, double cantidad, double precio, DateTime fecha, DateTime fechaVencimiento)
        {
            Id = id;
            EntradaId = entradaId;
            ArticuloID = articuloID;
            Cantidad = cantidad;
            Precio = precio;
            Fecha = fecha;
            FechaVencimiento = fechaVencimiento;
        }
    }
}

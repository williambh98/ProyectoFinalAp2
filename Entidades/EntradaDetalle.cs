using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable ]
    public class EntradaDetalle
    {
        [Key]
        public int Id { get; set; }
        public int EntradaId { get; set; }
        [ForeignKey("EntradaId")]
        public virtual Entrada Entrada { get; set; }
        public int ArticuloID { get; set; }
        [ForeignKey("ArticuloID")]
        public virtual Articulo Articulo { get; set; }
        public double Cantidad { get; set; }
        public double Costo { get; set; }
        public double Importe { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public EntradaDetalle()
        {
            Id = 0;
            EntradaId = 0;
            ArticuloID = 0;
            Cantidad = 0;
            Costo = 0;
            Importe = 0;
            FechaVencimiento = DateTime.Now;
        }

        public EntradaDetalle(int id, int entradaId, int articuloID, double cantidad, double costo, double importe, DateTime fechaVencimiento)
        {
            Id = id;
            EntradaId = entradaId;
            ArticuloID = articuloID;
            Cantidad = cantidad;
            Costo = costo;
            Importe = importe;
            FechaVencimiento = fechaVencimiento;
        }
    }
}

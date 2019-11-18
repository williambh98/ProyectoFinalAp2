using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Entrada
    {
        [Key]
        public int EntradaId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int ProvedorID { get; set; }
        public double CantidadTotal { get; set; }
        public virtual List<EntradaDetalle> Detalle { get; set; }

        public Entrada()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            CantidadTotal = 0;
            ProvedorID = 0;
            FechaVencimiento = DateTime.Now;
            this.Detalle = new List<EntradaDetalle>();
        }

        public Entrada(int entradaId, DateTime fecha, int provedorID, double cantidad, List<EntradaDetalle> detalle)
        {
            EntradaId = entradaId;
            Fecha = fecha;
            ProvedorID = provedorID;
            CantidadTotal = cantidad;
            Detalle = detalle;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int UsuarioID { get; set; }
        public DateTime Fecha { get; set; }
        public virtual List<EntradaDetalle> Detalle { get; set; }

        public Entrada()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            this.Detalle = new List<EntradaDetalle>();
        }

        public Entrada(int entradaId,int usuarioID, DateTime fecha,List<EntradaDetalle> detalle)
        {
            EntradaId = entradaId;
            UsuarioID = usuarioID;
            Fecha = fecha;
            Detalle = detalle;
        }

        public void AgregarDetalle(int id,int EntradaID,int articuloId, double precio, double Cantidad, double importe,DateTime FechaVencimiento)
        {
            this.Detalle.Add(new EntradaDetalle(id, EntradaID, articuloId, precio, Cantidad, importe,FechaVencimiento));
        }

        public void RemoverDetalle(int Index)
        {
            this.Detalle.RemoveAt(Index);
        }

    }
}

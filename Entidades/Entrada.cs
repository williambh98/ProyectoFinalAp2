﻿using System;
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
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public virtual List<EntradaDetalle> Detalle { get; set; }

        public Entrada()
        {
            EntradaId = 0;
            Total = 0;
            Fecha = DateTime.Now;
            this.Detalle = new List<EntradaDetalle>();
        }

        public Entrada(int entradaId,int usuarioID, decimal total, DateTime fecha,List<EntradaDetalle> detalle)
        {
            EntradaId = entradaId;
            UsuarioID = usuarioID;
            Total = total;
            Fecha = fecha;
            Detalle = detalle;
        }

        public void AgregarDetalle(int id, int entradaID,int articuloId, string descripcion, decimal Cantidad, decimal Costo, decimal importe, DateTime Fecha)
        {
            this.Detalle.Add(new EntradaDetalle(id, entradaID,articuloId, descripcion, Cantidad, Costo, importe, Fecha));
        }

        public void RemoverDetalle(int Index)
        {
            this.Detalle.RemoveAt(Index);
        }

    }
}

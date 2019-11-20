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
    public class Articulo
    {
        [Key]
        public int ArticuloID { get; set; }
        public int DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
        public virtual Departamento Departamento { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
        public int IDProveedor { get; set; }
        [ForeignKey("IDProveedor")]
        public virtual Proveedores Proveedores { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double Cantidad { get; set; }


        public Articulo()
        {
            ArticuloID = 0;
            DepartamentoId = 0;
            CategoriaId = 0;
            CategoriaId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            FechaCreacion = DateTime.Now;
            Cantidad = 0;

        }

        public Articulo(int articuloID, int departamentoId, int categoriaId, int iDProveedor, string descripcion, double costo, double precio, DateTime fechaCreacion, double cantidad)
        {
            ArticuloID = articuloID;
            DepartamentoId = departamentoId;
            CategoriaId = categoriaId;
            IDProveedor = iDProveedor;
            Descripcion = descripcion;
            Costo = costo;
            Precio = precio;
            FechaCreacion = fechaCreacion;
            Cantidad = cantidad;
        }
    }
}

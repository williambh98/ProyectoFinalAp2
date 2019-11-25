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
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Ganancia { get; set; }


        public Articulo()
        {
            ArticuloID = 0;
            DepartamentoId = 0;
            CategoriaId = 0;
            CategoriaId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            Cantidad = 0;
            Ganancia = 0;
            FechaCreacion = DateTime.Now;


        }
        public Articulo(int articuloID, int departamentoId, int categoriaId, int iDProveedor, string descripcion, decimal costo, decimal precio, DateTime fechaCreacion, decimal cantidad, decimal ganancia)
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
            Ganancia = ganancia;
        }
    }
}

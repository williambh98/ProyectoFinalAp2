using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Proveedores
    {
        [Key]
        public int IDProveedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }

        public Proveedores()
        {
            IDProveedor = 0;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Nombre = string.Empty;
            Email = string.Empty;
            Fecha = DateTime.Now;
        }

        public Proveedores(int iDProveedor, string nombreProveedor, string direccion, string telefono, string email, DateTime fechaProveedor)
        {
            IDProveedor = iDProveedor;
            Nombre = nombreProveedor;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Fecha = fechaProveedor;
        }
    }
}

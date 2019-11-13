using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedores
    {
        [Key]
        public int IDProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaProveedor { get; set; }

        public Proveedores()
        {
            IDProveedor = 0;
            Direccion = string.Empty;
            Telefono = string.Empty;
            NombreProveedor = string.Empty;
            Email = string.Empty;
            FechaProveedor = DateTime.Now;
        }

        public Proveedores(int iDProveedor, string nombreProveedor, string direccion, string telefono, string email, DateTime fechaProveedor)
        {
            IDProveedor = iDProveedor;
            NombreProveedor = nombreProveedor;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            FechaProveedor = fechaProveedor;
        }
    }
}

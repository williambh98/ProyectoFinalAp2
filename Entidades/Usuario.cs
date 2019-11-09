using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public Boolean Administrador { get; set; }
        public DateTime Fecha { get; set; }

        public Usuario()
        {
            UsuarioID = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            Contrasena = string.Empty;
            Administrador = true;
            Fecha = DateTime.Now;
        }

        public Usuario(int usuarioID, string nombre, string telefono, string email, string contrasena, bool administrador, DateTime fecha)
        {
            UsuarioID = usuarioID;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Contrasena = contrasena;
            Administrador = administrador;
            Fecha = fecha;
        }
    }
}

using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulo> _Articulo { get; set; }
        public DbSet<Departamento> Almacen { get; set; }
        public DbSet<Proveedores> provedores { get; set; }
        public DbSet<Categoria> Tipo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Entrada> Entrada { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}


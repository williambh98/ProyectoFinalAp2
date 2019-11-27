using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BLL
{
    public static class Metodo
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }


        // Calcular Ganancia
        public static decimal Ganancia(decimal Costo, decimal Precio)
        {
            decimal Ganancia = 0;
            Ganancia = Precio - Costo;
            Ganancia = Ganancia / Costo;
            Ganancia *= 100;

            return Ganancia;
        }

        // Metodo para llamar Descripcion del articulo
        public static string Descripcion(int lista)
        {
            RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();
            Articulo articulo = new Articulo();
            int id = lista;
            articulo = repositorio.Buscar(id);

            string art = articulo.Descripcion;
            return art;
        }

        //Metodo Reportes
        public static List<Articulo> INVarticulo()
        {
            Expression<Func<Articulo, bool>> filtro = p => true;
            RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();
            List<Articulo> list = new List<Articulo>();

            list = repositorio.GetList(filtro);

            return list;
        }
        public static List<Categoria> INVCategoria()
        {
            Expression<Func<Categoria, bool>> filtro = p => true;
            RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
            List<Categoria> list = new List<Categoria>();

            list = repositorio.GetList(filtro);

            return list;
        }
        public static List<Departamento> INVDepartamento()
        {
            Expression<Func<Departamento, bool>> filtro = p => true;
            RepositorioBase<Departamento> repositorio = new RepositorioBase<Departamento>();
            List<Departamento> list = new List<Departamento>();

            list = repositorio.GetList(filtro);

            return list;
        }
        public static List<Entrada> INVEntrada()
        {
            Expression<Func<Entrada, bool>> filtro = p => true;
            RepositorioBase<Entrada> repositorio = new RepositorioBase<Entrada>();
            List<Entrada> list = new List<Entrada>();

            list = repositorio.GetList(filtro);

            return list;
        }
        public static List<EntradaDetalle> INVEntradaDetalle()
        {
            Expression<Func<EntradaDetalle, bool>> filtro = p => true;
            RepositorioBase<EntradaDetalle> repositorio = new RepositorioBase<EntradaDetalle>();
            List<EntradaDetalle> list = new List<EntradaDetalle>();

            list = repositorio.GetList(filtro);

            return list;
        }
        public static List<Proveedores> INVProveedores()
        {
            Expression<Func<Proveedores, bool>> filtro = p => true;
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>();
            List<Proveedores> list = new List<Proveedores>();

            list = repositorio.GetList(filtro);

            return list;
        }
        public static List<Usuario> INVUsuario()
        {
            Expression<Func<Usuario, bool>> filtro = p => true;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            List<Usuario> list = new List<Usuario>();

            list = repositorio.GetList(filtro);

            return list;
        }

    }
}

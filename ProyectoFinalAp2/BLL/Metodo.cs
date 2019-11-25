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
        public static decimal Ganancia (decimal Costo, decimal Precio)
        {
            decimal Ganancia = 0;
            Ganancia = Precio - Costo;
            Ganancia = Ganancia / Costo;
            Ganancia *= 100;

            return Ganancia;
        }

        public static string Descripcion(int lista)
        {
            RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();
            Articulo articulo = new Articulo();
            int id = lista;
            articulo = repositorio.Buscar(id);

            string art = articulo.Descripcion;
            return art;
        }
      

    }
}

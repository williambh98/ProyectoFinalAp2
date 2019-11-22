using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioEntrada : RepositorioBase<Entrada>
    {
        public override bool Guardar(Entrada entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();
            try
            {
                foreach (var item in entrada.Detalle)
                {
                    Articulo articulo = new Articulo();
                    articulo = repositorio.Buscar(item.ArticuloID);
                    articulo.Cantidad += item.Cantidad;
                    repositorio.Modificar(articulo);
                }
                if (contexto.Entrada.Add(entrada) != null)
                {
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { contexto.Dispose(); }
            return paso;
        }
        public override bool Modificar(Entrada entrada)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();
            try
            {

                foreach (var item in entrada.Detalle)
                {
                    Articulo articulo = new Articulo();
                    articulo = repositorio.Buscar(item.ArticuloID);
                    if (item.Id == 0)
                    {
                        articulo.Cantidad += item.Cantidad;
                        contexto.Entry(item).State = EntityState.Added;
                    }

                    repositorio.Modificar(articulo);
                }
                contexto.Entry(entrada).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
                repositorio.Dispose();
            }
            return paso;
        }


        public override bool Eliminar(int id)
        {
            bool paso = false;

            RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();
            Entrada entrada = Buscar(id);
            try
            {
                foreach (var item in entrada.Detalle)
                {
                    Articulo articulo = new Articulo();
                    articulo = repositorio.Buscar(item.ArticuloID);
                    articulo.Cantidad -= item.Cantidad;
                    repositorio.Modificar(articulo);
                }
                paso = base.Eliminar(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { repositorio.Dispose(); }
            return paso;
        }


        public override Entrada Buscar(int id)
        {
            Entrada entrada = new Entrada();
            Contexto contexto = new Contexto();
            try
            {
                entrada = contexto.Entrada.Include(t => t.Detalle).Where(x => x.EntradaId == id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return entrada;
        }


        public override List<Entrada> GetList(Expression<Func<Entrada, bool>> expression)
        {
            List<Entrada> entradas = new List<Entrada>();
            Contexto contexto = new Contexto();

            try
            {
                entradas = contexto.Set<Entrada>().Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return entradas;
        }
        public static void EliminarDetalle(Entrada entrada)
        {
            Contexto contexto = new Contexto();
            RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();
            foreach (var item in entrada.Detalle)
            {
                Articulo articulo = new Articulo();
                articulo = repositorio.Buscar(item.ArticuloID);

                RepositorioBase<EntradaDetalle> db = new RepositorioBase<EntradaDetalle>();
                EntradaDetalle details = db.Buscar(item.Id);
                if (details is null)
                    return;
                articulo.Cantidad -= details.Cantidad;
                contexto.Entry(item).State = EntityState.Deleted;
                contexto.SaveChanges();
                repositorio.Modificar(articulo);
            }


        }
    }
}


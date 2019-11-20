using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalAp2Test
{
    [TestClass]
    public class ArticuloTest
    {
        [TestMethod]
        public void GuardarTest()
        {
            Articulo articulo = new Articulo();
            articulo.ArticuloID = 0;
            articulo.IDProveedor = 1;
            articulo.DepartamentoId = 1;
            articulo.Cantidad = 1;
            articulo.Descripcion = "Pedro";
            articulo.Costo = 200;
            articulo.Precio = 200;
            articulo.FechaCreacion = DateTime.Now;
            RepositorioBase<Articulo> repositorioBase = new RepositorioBase<Articulo>();
            Assert.IsTrue(repositorioBase.Guardar(articulo));
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Articulo articulo = new Articulo();
            articulo.ArticuloID = 1;
            articulo.IDProveedor = 1;
            articulo.DepartamentoId = 1;
            articulo.Cantidad = 1;
            articulo.Descripcion = "Pedro";
            articulo.Costo = 200;
            articulo.Precio = 200;
            articulo.FechaCreacion = DateTime.Now;
            RepositorioBase<Articulo> repositorioBase = new RepositorioBase<Articulo>();
            Assert.IsTrue(repositorioBase.Modificar(articulo));
        }
        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Articulo articulo = new Articulo();
            RepositorioBase<Articulo> repositorioBase = new RepositorioBase<Articulo>();
            articulo = repositorioBase.Buscar(id);
            Assert.AreEqual(true, articulo != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Articulo> repositorioBase = new RepositorioBase<Articulo>();
            List<Articulo> lista = new List<Articulo>();
            Expression<Func<Articulo, bool>> resultado = u => true;
            lista = repositorioBase.GetList(resultado);
            Assert.IsNotNull(lista);
        }


        [TestMethod()]
        public void EliminarTest()
        {
            Articulo articulo = new Articulo();
            RepositorioBase<Articulo> repositorioBase = new RepositorioBase<Articulo>();
            articulo.ArticuloID = 1;
            Assert.AreEqual(true, repositorioBase.Eliminar(articulo.ArticuloID));
        }
    }
}

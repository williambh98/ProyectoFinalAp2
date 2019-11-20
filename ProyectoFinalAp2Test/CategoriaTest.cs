using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalAp2Test
{
    [TestClass()]
    public class CategoriaTest
    {
        [TestMethod]
        public void GuardarTest()
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = "william";
            categoria.Descripcion = "Pedro";
            categoria.Fecha = DateTime.Now;
            RepositorioBase<Categoria> repositorioBase = new RepositorioBase<Categoria>();
            Assert.IsTrue(repositorioBase.Guardar(categoria));
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Categoria categoria = new Categoria();
            categoria.CategoriaId = 1;
            categoria.Descripcion = "Efectivo";
            categoria.Fecha = DateTime.Now;

            RepositorioBase<Categoria> repositorioBase = new RepositorioBase<Categoria>();
            Assert.IsTrue(repositorioBase.Modificar(categoria));
        }
        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Categoria categoria = new Categoria();
            RepositorioBase<Categoria> repositorioBase = new RepositorioBase<Categoria>();
            categoria = repositorioBase.Buscar(id);
            Assert.AreEqual(true, categoria != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Categoria> repositorioBase = new RepositorioBase<Categoria>();
            List<Categoria> lista = new List<Categoria>();
            Expression<Func<Categoria, bool>> resultado = u => true;
            lista = repositorioBase.GetList(resultado);
            Assert.IsNotNull(lista);
        }


        [TestMethod()]
        public void EliminarTest()
        {
            Categoria categoria = new Categoria();
            RepositorioBase<Categoria> repositorioBase = new RepositorioBase<Categoria>();
            categoria.CategoriaId = 1;
            Assert.AreEqual(true, repositorioBase.Eliminar(categoria.CategoriaId));
        }
    }
}


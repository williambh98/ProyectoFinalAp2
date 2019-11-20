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
    public class ProveedoresTest
    {
        [TestMethod]
        public void GuardarTest()
        {
            Proveedores proveedores = new Proveedores();
            proveedores.Nombre = "william";
            proveedores.Direccion = "Pedro";
            proveedores.Email = "Ana";
            proveedores.Telefono = "809-725-4246";
            proveedores.Fecha = DateTime.Now;
            RepositorioBase<Proveedores> repositorioBase = new RepositorioBase<Proveedores>();
            Assert.IsTrue(repositorioBase.Guardar(proveedores));
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Proveedores proveedores = new Proveedores();
            proveedores.IDProveedor = 1;
            proveedores.Nombre = "william";
            proveedores.Direccion = "Pedro";
            proveedores.Email = "Ana";
            proveedores.Telefono = "809-725-4246";
            proveedores.Fecha = DateTime.Now;

            RepositorioBase<Proveedores> repositorioBase = new RepositorioBase<Proveedores>();
            Assert.IsTrue(repositorioBase.Modificar(proveedores));
        }
        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Proveedores proveedores = new Proveedores();
            RepositorioBase<Proveedores> repositorioBase = new RepositorioBase<Proveedores>();
            proveedores = repositorioBase.Buscar(id);
            Assert.AreEqual(true, proveedores != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Proveedores> repositorioBase = new RepositorioBase<Proveedores>();
            List<Proveedores> lista = new List<Proveedores>();
            Expression<Func<Proveedores, bool>> resultado = u => true;
            lista = repositorioBase.GetList(resultado);
            Assert.IsNotNull(lista);
        }


        [TestMethod()]
        public void EliminarTest()
        {
            Proveedores proveedores = new Proveedores();
            RepositorioBase<Proveedores> repositorioBase = new RepositorioBase<Proveedores>();
            proveedores.IDProveedor = 1;
            Assert.AreEqual(true, repositorioBase.Eliminar(proveedores.IDProveedor));
        }
    }
}


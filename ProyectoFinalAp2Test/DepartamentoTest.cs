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
    public class DepartamentoTest
    {
        [TestMethod]
        public void GuardarTest()
        {
            Departamento Departamento = new Departamento();
            Departamento.Nombre = "william";
            Departamento.Fecha = DateTime.Now;
            RepositorioBase<Departamento> repositorioBase = new RepositorioBase<Departamento>();
            Assert.IsTrue(repositorioBase.Guardar(Departamento));
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Departamento departamento = new Departamento();
            departamento.DepartamentoId = 1;
            departamento.Nombre = "Ana";
            departamento.Fecha = DateTime.Now;

            RepositorioBase<Departamento> repositorioBase = new RepositorioBase<Departamento>();
            Assert.IsTrue(repositorioBase.Modificar(departamento));
        }
        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Departamento departamento = new Departamento();
            RepositorioBase<Departamento> repositorioBase = new RepositorioBase<Departamento>();
            departamento = repositorioBase.Buscar(id);
            Assert.AreEqual(true, departamento != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Departamento> repositorioBase = new RepositorioBase<Departamento>();
            List<Departamento> lista = new List<Departamento>();
            Expression<Func<Departamento, bool>> resultado = u => true;
            lista = repositorioBase.GetList(resultado);
            Assert.IsNotNull(lista);
        }


        [TestMethod()]
        public void EliminarTest()
        {
            Departamento departamento = new Departamento();
            RepositorioBase<Departamento> repositorioBase = new RepositorioBase<Departamento>();
            departamento.DepartamentoId = 1;
            Assert.AreEqual(true, repositorioBase.Eliminar(departamento.DepartamentoId));
        }
    }
}

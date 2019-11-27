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
    public class EntradaTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Entrada entrada = new Entrada();
            entrada.UsuarioID = 1;
            entrada.Total = 50;
            entrada.Fecha = DateTime.Now;
            RepositorioBase<Entrada> repositorioBase = new RepositorioBase<Entrada>();
            Assert.IsTrue(repositorioBase.Guardar(entrada));
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Entrada entrada = new Entrada();
            entrada.EntradaId = 1;
            entrada.UsuarioID = 1;
            entrada.Total = 50;
            entrada.Fecha = DateTime.Now;

            RepositorioBase<Entrada> repositorioBase = new RepositorioBase<Entrada>();
            Assert.IsTrue(repositorioBase.Modificar(entrada));
        }
        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Entrada entrada = new Entrada();
            RepositorioBase<Entrada> repositorioBase = new RepositorioBase<Entrada>();
            entrada = repositorioBase.Buscar(id);
            Assert.AreEqual(true, entrada != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Entrada> repositorioBase = new RepositorioBase<Entrada>();
            List<Entrada> lista = new List<Entrada>();
            Expression<Func<Entrada, bool>> resultado = u => true;
            lista = repositorioBase.GetList(resultado);
            Assert.IsNotNull(lista);
        }


        [TestMethod()]
        public void EliminarTest()
        {
            Entrada entrada = new Entrada();
            RepositorioBase<Entrada> repositorioBase = new RepositorioBase<Entrada>();
            entrada.EntradaId = 1;
            Assert.AreEqual(true, repositorioBase.Eliminar(entrada.EntradaId));
        }
    }
}

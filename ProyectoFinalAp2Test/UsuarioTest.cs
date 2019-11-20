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
    public class UsuarioTest
    {
        [TestMethod]
        public void GuardarTest()
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = "william";
            usuario.Contrasena = "Pedro";
            usuario.Email = "Ana";
            usuario.Telefono = "809-725-4246";
            usuario.Fecha = DateTime.Now;
            RepositorioBase<Usuario> repositorioBase = new RepositorioBase<Usuario>();
            Assert.IsTrue(repositorioBase.Guardar(usuario));
        }
        [TestMethod()]
        public void ModificarTest()
        {
            Usuario usuario = new Usuario();
            usuario.UsuarioID = 1;
            usuario.Nombre = "william";
            usuario.Contrasena = "Pedro";
            usuario.Email = "Ana";
            usuario.Telefono = "809-725-4246";
            usuario.Fecha = DateTime.Now;

            RepositorioBase<Usuario> repositorioBase = new RepositorioBase<Usuario>();
            Assert.IsTrue(repositorioBase.Modificar(usuario));
        }
        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Usuario usuario = new Usuario();
            RepositorioBase<Usuario> repositorioBase = new RepositorioBase<Usuario>();
            usuario = repositorioBase.Buscar(id);
            Assert.AreEqual(true, usuario != null);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Usuario> repositorioBase = new RepositorioBase<Usuario>();
            List<Usuario> lista = new List<Usuario>();
            Expression<Func<Usuario, bool>> resultado = u => true;
            lista = repositorioBase.GetList(resultado);
            Assert.IsNotNull(lista);
        }


        [TestMethod()]
        public void EliminarTest()
        {
            Usuario usuario = new Usuario();
            RepositorioBase<Usuario> repositorioBase = new RepositorioBase<Usuario>();
            usuario.UsuarioID = 1;
            Assert.AreEqual(true, repositorioBase.Eliminar(usuario.UsuarioID));
        }
    }
}

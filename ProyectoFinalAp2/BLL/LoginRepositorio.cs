using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL
{
    public class LoginRepositorio : RepositorioBase<Usuario>
    {
        private List<Usuario> Listar(Expression<Func<Usuario, bool>> expression)
        {
            List<Usuario> Lista = new List<Usuario>();
            try
            {
                Lista = _contexto.Set<Usuario>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }


        public bool Auntenticar(string usuario, string contraseña)
        {

            Expression<Func<Usuario, bool>> filtrar = x => true;
            filtrar = t => t.Email.Equals(usuario) && t.Contrasena.Equals(contraseña);
            bool paso = false;
            if (Listar(filtrar).Count() != 0)
            {

                paso = true;
            }
            return paso;
        }
    }
}
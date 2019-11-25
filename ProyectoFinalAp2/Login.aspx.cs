using BLL;
using Entidades;
using ProyectoFinalAp2.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalAp2
{
    public partial class Login : System.Web.UI.Page
    {
        RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
        Expression<Func<Usuario, bool>> filtrar = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Expression<Func<Usuario, bool>> filtrar = x => true;
            Usuario usuario = new Usuario();

            filtrar = t => t.Email.Equals(EmailTextox) && t.Contrasena.Equals(ContrasenaTextBox);

            if (repositorio.GetList(filtrar).Count() != 0)
                FormsAuthentication.RedirectFromLoginPage(usuario.Email, true);
            else
            Utils.ShowToastr(this, "Email o Contraseña incorrectos", "Error", "error");
        }
    }
}
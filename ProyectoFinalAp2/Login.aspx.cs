using BLL;
using Entidades;
using ProyectoFinalAp2.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalAp2
{
    public partial class Loginnn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            LoginRepositorio repositorio = new LoginRepositorio();

            if (UsuarioTextBox.Text.Length > 0 && PasswordTextBox.Text.Length > 0)
            {

                string password = Utils.Hash(PasswordTextBox.Text);
                if (repositorio.Auntenticar(UsuarioTextBox.Text, password))
                {
                    FormsAuthentication.RedirectFromLoginPage(user.Email, true);
                }
                else
                    Utils.ShowToastr(this.Page, "Usuario o contraseña Incorrecta", "Error", "error");
            }
            else
                Utils.ShowToastr(this.Page, "Debe ingresar su usuario y contraseña", "Error", "error");
        }
    }
}

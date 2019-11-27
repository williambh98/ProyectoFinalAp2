using BLL;
using Entidades;
using ProyectoFinalAp2.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalAp2.UI.Registros
{
    public partial class RegistrosUsuario : System.Web.UI.Page
    {
        RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
        Expression<Func<Usuario, bool>> filtrar = x => true;
        Expression<Func<Usuario, bool>> filtro = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (!Page.IsPostBack)
            {
                //si llego in id
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
                    Usuario user = repositorio.Buscar(id);
                    if (user == null)
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                    else
                        LlenaCampos(user);

                }
                else
                {
                    NuevoButton_Click(null, null);
                }
            }

        }


        private Usuario LlenarClase()
        {
            Usuario usuario = new Usuario();
            usuario.UsuarioID = Utils.ToInt(IdTextBox.Text);
            usuario.Nombre = NombreTextBox.Text;
            usuario.Telefono = TelefonoTextBox.Text;
            usuario.Fecha = DateTime.Now;
            usuario.Email = EmailTextBox.Text;
            usuario.Contrasena = Utils.Hash(ContraseñaTextBox.Text);
            usuario.Administrador = (Tipousuario.SelectedValue == "0") ? true : false;
            return usuario;
        }

        private void LlenaCampos(Usuario usuario)
        {
            IdTextBox.Text = usuario.UsuarioID.ToString();
            NombreTextBox.Text = usuario.Nombre;
            TelefonoTextBox.Text = usuario.Telefono;
            EmailTextBox.Text = usuario.Email;
            ContraseñaTextBox.Text = usuario.Contrasena;
            Tipousuario.SelectedValue = (usuario.Administrador == true) ? "0" : "1";
            fechaTextBox.Text = usuario.Fecha.ToString("yyyy-MM-dd");


        }
        private void Limpiar()
        {
            IdTextBox.Text = "";
            NombreTextBox.Text = "";
            TelefonoTextBox.Text = "";
            EmailTextBox.Text = "";
            ContraseñaTextBox.Text = "";
            ConfimarTextBox.Text = " ";
            Tipousuario.ClearSelection();
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }
        private bool ExisteBasedeDatos()
        {
            Usuario usuario = new Usuario();
            int id = Convert.ToInt32(IdTextBox.Text);
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            usuario = repositorio.Buscar(id);
            return usuario != null;
        }


        private bool validar()
        {
            bool estado = false;

            string s = EmailTextBox.Text;
            filtrar = t => t.Email.Equals(s);
            List<Usuario> lista = new List<Usuario>();
            lista = repositorio.GetList(filtrar);
            string p = ContraseñaTextBox.Text;
            string cp = ConfimarTextBox.Text;
            int comparacion = 0;
            comparacion = String.Compare(p, cp);

            if (comparacion != 0)
            {
                Utils.ShowToastr(this, "Las Contraseñas no son iguales", "Error", "error");
                PasswwordCustomValidator.Focus();
                estado = true;
            }

            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe de estar en cero el ID.", "Error", "Error");
                estado = true;

            }
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un nombre para guardar", "Error", "error");
                estado = true;
            }
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener una Email para guardar", "Error", "error");
                estado = true;
            }

            if (ContraseñaTextBox.Text.Length < 5 || ContraseñaTextBox.Text.Length > 15)
            {
                Utils.ShowToastr(this, "No es una contraseña corrrecta", "Error", "error");
                estado = true;
            }

            if (TelefonoTextBox.Text.Length != 10)
            {
                Utils.ShowToastr(this, "No es es correcto el numero", "Error", "error");
                estado = true;
            }

            if (lista.Count != 0)
            {
                Utils.ShowToastr(this, "Esta Email ya existe", "Error", "error");
                estado = true;
            }
            return estado;
        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            else
            {
                RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
                bool paso = false;
                Usuario usuario = LlenarClase();

                if (Convert.ToInt32(IdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(usuario);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    if (!ExisteBasedeDatos())
                    {
                        Utils.ShowToastr(this, "No existe", "Error", "Error");
                        return;
                    }
                    else
                    {
                        paso = repositorio.Modificar(usuario);
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");

                    }
                }
                if (paso)
                {
                    Limpiar();
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            int id = Utils.ToInt(IdTextBox.Text);

            var usuario = repositorio.Buscar(id);
            if (usuario != null)
            {
                if (repositorio.Eliminar(id))
                {

                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No elimado","Error", "Error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();

            var usuario = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));
            if (usuario != null)
            {
                LlenaCampos(usuario);
                Utils.ShowToastr(this, "Encontrado", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No Encontrado", "Error", "error");
            }
        }

    }

}

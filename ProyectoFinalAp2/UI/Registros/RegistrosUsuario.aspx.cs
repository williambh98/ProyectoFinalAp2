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
            usuario.Contrasena = ContrasenaTextBox.Text;
            usuario.Administrador = (Tipousuario.SelectedValue == "0") ? true : false;
            return usuario;
        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Usuario usuario = new Usuario();
            bool paso = false;
            Usuario user = LlenarClase();
            if (user.UsuarioID == 0)
                paso = repositorio.Guardar(user);
            else
                paso = repositorio.Modificar(user);
            if (paso)
            {
          
                Utils.ShowToastr(this, "Guardado", "Exito", "success");         
                Limpiar();
            }
            else
            {
                
                Utils.ShowToastr(this, "No existe", "Error", "error");

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
                   
                    MostrarMensaje("correcto", "Registro Eliminado");
                    Limpiar();
                }
                else
                    MostrarMensaje("Incorrecto", "Registro No eliminado"); ;
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();

            var usuario = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));
            if (usuario != null)
            {
                LlenaCampos(usuario);
                MostrarMensaje("correcto", "Registro Encontrado");
            }
            else
            {
                Limpiar();
                MostrarMensaje("Incorrecto", "Error no se encuentra");
            }
        }
        private bool Email()
        {
            bool HayErrores = false;
            filtrar = t => t.Email.Equals(EmailTextBox.Text);

            if (repositorio.GetList(filtrar).Count() != 0)
            {
                MostrarMensaje("Error", "Este Email ya existe");
                HayErrores = true;
            }
            return HayErrores;
        }
        private bool HayErrores()
        {
            bool HayErrores = false;
            if (TelefonoTextBox.Text.Length != 10)
            {
                MostrarMensaje("Error", "no es un numero de telefono correcto");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                MostrarMensaje("Error", "Debe tener un Id para guardar");
                HayErrores = true;
            }

            filtrar = t => t.Email.Equals(EmailTextBox.Text);

            if (repositorio.GetList(filtrar).Count() != 0)
            {
                MostrarMensaje("Error", "Este Email ya existe");
                HayErrores = true;
            }
            filtro = t => t.Nombre.Equals(NombreTextBox.Text);

            if (repositorio.GetList(filtro).Count() != 0)
            {
                MostrarMensaje("Error", "Este Nombre ya existe");
                HayErrores = true;
            }
            return HayErrores;
        }

        private void MostrarMensaje(String tipo, string Mensaje)
        {

            ErrorLabel.Text = Mensaje;
            if (tipo.ToLower() == "Correcto".ToLower())
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";
        }
        private void LlenaCampos(Usuario usuario)
        {
            IdTextBox.Text = usuario.UsuarioID.ToString();
            NombreTextBox.Text = usuario.Nombre;
            TelefonoTextBox.Text = usuario.Telefono;
            EmailTextBox.Text = usuario.Email;
            ContrasenaTextBox.Text = usuario.Contrasena;
            Tipousuario.SelectedValue = (usuario.Administrador == true) ? "0" : "1";


        }
        private void Limpiar()
        {
            IdTextBox.Text = "";
            NombreTextBox.Text = "";
            TelefonoTextBox.Text = "";
            EmailTextBox.Text = "";
            ContrasenaTextBox.Text = "";
            Tipousuario.ClearSelection();

        }
    }
    }

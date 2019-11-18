using BLL;
using Entidades;
using ProyectoFinalAp2.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalAp2.UI.Registros
{
    public partial class RegistroProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>();
                    Proveedores user = repositorio.Buscar(id);
                    if (user == null)
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                    else
                        LlenaCampo(user);
                    repositorio.Dispose();

                }

                else
                {
                    NuevoButton_Click(null, null);
                }

            }
        }

        private void Limpiar()
        {
            IdTextBox.Text = 0.ToString();
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            fechaTextBox.Text = DateTime.Now.ToString();
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Proveedores LlenaClase()
        {
            Proveedores proveedores = new Proveedores();
            proveedores.IDProveedor = Utils.ToInt(IdTextBox.Text);
            proveedores.Nombre = NombreTextBox.Text;
            proveedores.Direccion = DireccionTextBox.Text;
            proveedores.Email = EmailTextBox.Text;
            proveedores.Telefono = TelefonoTextBox.Text;
            proveedores.Fecha = DateTime.Now;
            return proveedores;
        }
        private void LlenaCampo(Proveedores proveedores)
        {
            IdTextBox.Text = proveedores.Nombre.ToString();
            NombreTextBox.Text = proveedores.Nombre;
            DireccionTextBox.Text = proveedores.Direccion;
            EmailTextBox.Text = proveedores.Email; ;
            TelefonoTextBox.Text = proveedores.Telefono;
            fechaTextBox.Text = proveedores.Fecha.ToString();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Proveedores> db = new RepositorioBase<Proveedores>();
            Proveedores proveedores = db.Buscar(Convert.ToInt32(IdTextBox.Text));
            return (proveedores != null);

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> db = new RepositorioBase<Proveedores>();
            Proveedores proveedores;
            bool paso = false;

            proveedores = LlenaClase();

            if (IdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(proveedores);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this.Page, "LLenar este campo", "Error", "error");
                    return;
                }
                paso = db.Modificar(proveedores);
                Utils.ShowToastr(this.Page, "Modificado ", "Exito", "success");
                return;
            }

            if (paso)
                Utils.ShowToastr(this.Page, "Guardado ", "Exito", "success");
            else
                Utils.ShowToastr(this.Page, "Error No Guardado", "Error", "error");
            Limpiar();

        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>();
            int id = Utils.ToInt(IdTextBox.Text);
            var proveedores = repositorio.Buscar(id);

            if (proveedores != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this.Page, "Exito Eliminado", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No Eliminado", "error");
            }
            else
                EliminarRequiredFieldValidator.IsValid = false;
            repositorio.Dispose();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> rep = new RepositorioBase<Proveedores>();
            Proveedores a = rep.Buscar(Utils.ToInt(IdTextBox.Text));
            if (a != null)
                LlenaCampo(a);
            else
            {
                Limpiar();
                Utils.ShowToastr(this.Page, "Id no exite", "Error", "error");
            }
            rep.Dispose();
        }
    }
}
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
    public partial class RegistroDepartamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Departamento> repositorio = new RepositorioBase<Departamento>();
                    Departamento user = repositorio.Buscar(id);
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
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Departamento LlenaClase()
        {
            Departamento departamento = new Departamento();
            departamento.DepartamentoId = Utils.ToInt(IdTextBox.Text);
            departamento.Nombre = NombreTextBox.Text;
            departamento.Fecha = DateTime.Now;
            return departamento;
        }
        private void LlenaCampo(Departamento departamento)
        {
            IdTextBox.Text = departamento.DepartamentoId.ToString();
            NombreTextBox.Text = departamento.Nombre;
            fechaTextBox.Text = departamento.Fecha.ToString("yyyy-MM-dd");
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Departamento> db = new RepositorioBase<Departamento>();
            Departamento departamento = db.Buscar(Convert.ToInt32(IdTextBox.Text));
            return (departamento != null);

        }

        private bool validar()
        {
            bool estado = false;
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe de estar en cero.", "Error", "Error");
                estado = true;

            }
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un nombre para guardar", "Error", "error");
                estado = true;
            }

            return estado;
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Departamento> db = new RepositorioBase<Departamento>();
            Departamento departamento;
            bool paso = false;

            departamento = LlenaClase();
            if (validar())
            {
                return;
            }
            else
          if (IdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(departamento);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this.Page, "LLenar este campo ID", "Error", "error");
                    return;
                }
                paso = db.Modificar(departamento);
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
            RepositorioBase<Departamento> repositorio = new RepositorioBase<Departamento>();
            int id = Utils.ToInt(IdTextBox.Text);
            var departamento = repositorio.Buscar(id);

            if (departamento != null)
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
                Utils.ShowToastr(this, "No existe", "Error", "error");
            repositorio.Dispose();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Departamento> rep = new RepositorioBase<Departamento>();
            Departamento a = rep.Buscar(Utils.ToInt(IdTextBox.Text));
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
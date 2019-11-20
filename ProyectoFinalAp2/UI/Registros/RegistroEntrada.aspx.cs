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
    public partial class RegistroEntrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (!Page.IsPostBack)
            {

                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Entrada> repositorio = new RepositorioBase<Entrada>();
                    Entrada user = repositorio.Buscar(id);
                    if (user == null)
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                    else
                        LlenarCombo();
                    LLenarCampo(user);
                }
                LlenarCombo();
                ViewState["Entrada"] = new Entrada();
            }

        }

        private void LlenarCombo()
        {

            ProductoDropdownList.Items.Clear();
            RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();
            ProductoDropdownList.DataSource = repositorio.GetList(x => true);
            ProductoDropdownList.DataValueField = "Articuloid";
            ProductoDropdownList.DataTextField = "Descripcion";
            ProductoDropdownList.DataBind();

            Articulo articulo = repositorio.Buscar(Utils.ToInt(ProductoDropdownList.SelectedValue));
            CostoTextBox.Text = articulo.Costo.ToString();

        }
        public void Limpiar()
        {
            IdTextBox.Text = "0";
            ProductoDropdownList.ClearSelection();
            CantidadTextBox.Text = 0.ToString();
            TotalTextBox.Text = 0.ToString();
            fechaTextBox.Text = DateTime.Now.ToString();
            FechaVencimientoTextBox.Text = DateTime.Now.ToString();
            ViewState["Entrada"] = new Entrada();
            GridView.DataSource = null;
            this.BindGrid();
        }
        private Entrada LlenarClase()
        {
            Entrada Entrada = new Entrada();
            Entrada = (Entrada)ViewState["Entrada"];
            Entrada.EntradaId = Convert.ToInt32(IdTextBox.Text);
            Entrada.Total = Utils.ToDecimal(TotalTextBox.Text);
            Entrada.Fecha = DateTime.Now;
            return Entrada;
        }

        private void LLenarCampo(Entrada entrada)
        {
            Limpiar();
            IdTextBox.Text = entrada.EntradaId.ToString();
            fechaTextBox.Text = entrada.Fecha.ToString();
            TotalTextBox.Text = entrada.Total.ToString();
            ViewState["Entrada"] = entrada;
            this.BindGrid();
        }

        private bool Validar()
        {
            bool estato = false;

            if (GridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe agregar detalle.", "Error", "error");
                estato = true;
            }
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                estato = true;
            }
            return estato;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Entrada> rep = new RepositorioBase<Entrada>();
            Entrada a = rep.Buscar(Convert.ToInt32(IdTextBox.Text));
            if (a != null)
                LLenarCampo(a);
            else
            {
                Limpiar();
                Utils.ShowToastr(this.Page, "Id no exite", "Error", "error");

            }
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BindGrid()
        {
            GridView.DataSource = ((Entrada)ViewState["Entrada"]).Detalle;
            GridView.DataBind();
        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            RepositorioEntrada repositorio = new RepositorioEntrada();
            Entrada factura = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));

            if (Validar())
            {
                return;
            }
            if (factura == null)
            {
                if (repositorio.Guardar(LlenarClase()))
                {

                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this, "No existe", "Error", "error");
                    Limpiar();
                }

            }
            else
            {
                if (repositorio.Modificar(LlenarClase()))
                {
                    Utils.ShowToastr(this.Page, "Modificado con exito!!", "Guardado", "success");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this.Page, "No se puede modificar", "Error", "error");
                    Limpiar();
                }
            }

        }



        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Entrada entrada = new Entrada();
            double total = 0;
            entrada.Detalle = new List<EntradaDetalle>();
            entrada = (Entrada)ViewState["Entrada"];
            double Importe = Convert.ToDouble(CantidadTextBox.Text) * Convert.ToDouble(CostoTextBox.Text);
            entrada.AgregarDetalle
                (0, Utils.ToInt(IdTextBox.Text),
                Utils.ToInt(ProductoDropdownList.SelectedValue), Convert.ToDouble(CostoTextBox.Text),
                Convert.ToDouble(CantidadTextBox.Text), Importe, Convert.ToDateTime(fechaTextBox.Text));
            ViewState["Entrada"] = entrada;
            this.BindGrid();
            foreach (var item in entrada.Detalle)
            {
                total += item.Importe;
            }
            TotalTextBox.Text = total.ToString();
        }

        protected void RemoveLinkButton_Click(object sender, EventArgs e)
        {
            if (GridView.Rows.Count > 0 && GridView.SelectedIndex >= 0)
            {
                Entrada entrada = new Entrada();
                entrada = (Entrada)ViewState["Entrada"];
                GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
                entrada.RemoverDetalle(row.RowIndex);
                ViewState["Entrada"] = entrada;
                this.BindGrid();

            }

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            GridViewRow grid = GridView.SelectedRow;
            RepositorioEntrada repositorio = new RepositorioEntrada();
            int id = Utils.ToInt(IdTextBox.Text);
            var entrada = repositorio.Buscar(id);

            if (entrada != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this.Page, "Exito Eliminado", "error");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No Eliminado", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
            repositorio.Dispose();
        }
    }
}
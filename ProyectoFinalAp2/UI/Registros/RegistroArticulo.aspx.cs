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
    public partial class RegistrosArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (!Page.IsPostBack)
            {
                //si llego in id
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();
                    Articulo user = repositorio.Buscar(id);
                    if (user == null)
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                    else
                        LlenarCombo();
                    LlenaCampo(user);
                }
                LlenarCombo();
            }

        }

        // Metodo utilizado.
        private void LlenarCombo()
        {
            DepartamentoDropdownList.Items.Clear();
            CategoriaDropDownList.Items.Clear();
            ProveedorDropDownList.Items.Clear();
            RepositorioBase<Departamento> repositorio = new RepositorioBase<Departamento>();
            DepartamentoDropdownList.DataSource = repositorio.GetList(x => true);
            DepartamentoDropdownList.DataValueField = "DepartamentoId";
            DepartamentoDropdownList.DataTextField = "Nombre";
            DepartamentoDropdownList.DataBind();


            RepositorioBase<Categoria> repositorioCategoria = new RepositorioBase<Categoria>();
            CategoriaDropDownList.DataSource = repositorioCategoria.GetList(x => true);
            CategoriaDropDownList.DataValueField = "CategoriaId";
            CategoriaDropDownList.DataTextField = "Nombre";
            CategoriaDropDownList.DataBind();

            RepositorioBase<Proveedores> repositorioProveedor = new RepositorioBase<Proveedores>();
            ProveedorDropDownList.DataSource = repositorioProveedor.GetList(x => true);
            ProveedorDropDownList.DataValueField = "IDProveedor";
            ProveedorDropDownList.DataTextField = "Nombre";
            ProveedorDropDownList.DataBind();


        }

        private Articulo LlenarClase()
        {
            Articulo articulo = new Articulo();
            articulo.ArticuloID = Convert.ToInt32(IdTextBox.Text);
            articulo.DepartamentoId = DepartamentoDropdownList.SelectedValue.Length;
            articulo.CategoriaId = CategoriaDropDownList.SelectedValue.Length;
            articulo.IDProveedor = ProveedorDropDownList.SelectedValue.Length;
            articulo.Descripcion = DescripcionTextBox.Text;
            articulo.Costo = Utils.ToDecimal(CostoTextBox.Text);
            articulo.Precio = Utils.ToDecimal(PrecioTextBox.Text);
            articulo.Ganancia = Utils.ToDecimal(GananciaTextBox.Text);
            articulo.FechaCreacion = DateTime.Now;
            return articulo;
        }

        private void LlenaCampo(Articulo articulo)
        {
            Limpiar();
            IdTextBox.Text = articulo.ArticuloID.ToString();
            DepartamentoDropdownList.SelectedValue = articulo.DepartamentoId.ToString();
            CategoriaDropDownList.SelectedValue = articulo.CategoriaId.ToString();
            ProveedorDropDownList.SelectedValue = articulo.IDProveedor.ToString();
            DescripcionTextBox.Text = articulo.Descripcion;
            CostoTextBox.Text = articulo.Costo.ToString();
            PrecioTextBox.Text = articulo.Precio.ToString();
            CantidadTextBox.Text = articulo.Cantidad.ToString();
            GananciaTextBox.Text = articulo.Ganancia.ToString();
            fechaTextBox.Text = articulo.FechaCreacion.ToString("yyyy-MM-dd");
        }

        public void Limpiar()
        {
            IdTextBox.Text = "0";
            ProveedorDropDownList.ClearSelection();
            CategoriaDropDownList.ClearSelection();
            DepartamentoDropdownList.ClearSelection();
            DescripcionTextBox.Text = string.Empty;
            CostoTextBox.Text = 0.ToString();
            PrecioTextBox.Text = 0.ToString();
            CantidadTextBox.Text = 0.ToString();
            GananciaTextBox.Text = 0.ToString();
            fechaTextBox.Text = DateTime.Now.ToString();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Articulo> db = new RepositorioBase<Articulo>();
            Articulo articulo = db.Buscar(Convert.ToInt32(IdTextBox.Text));
            return (articulo != null);
        }
        //Botones Guardar, Burcar, eliminar
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulo> db = new RepositorioBase<Articulo>();
            Articulo articulo;
            bool paso = false;
                  
            articulo = LlenarClase();
            if (IdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(articulo);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ShowToastr(this.Page, "LLenar el campo ID", "Error", "error");
                    return;
                }
                paso = db.Modificar(articulo);
                Utils.ShowToastr(this.Page, "Modificado ", "Exito", "success");
                return;
            }

            if (paso)
                Utils.ShowToastr(this.Page, "Guardado ", "Exito", "success");
            else
                Utils.ShowToastr(this.Page, "Error No Guardado", "Error", "error");
            Limpiar();

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulo> rep = new RepositorioBase<Articulo>();
            Articulo a = rep.Buscar(Utils.ToInt(IdTextBox.Text));
            if (a != null)
                LlenaCampo(a);
            else
            {
                Limpiar();
                Utils.ShowToastr(this.Page, "Id no exite", "Error", "error");

            }
            rep.Dispose();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();
            int id = Utils.ToInt(IdTextBox.Text);
            var articulo = repositorio.Buscar(id);

            if (articulo != null)
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
        }

        //Evento de costo y precio
        protected void CostoTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal Costo = Utils.ToDecimal(CostoTextBox.Text);
            decimal Precio = Utils.ToDecimal(PrecioTextBox.Text);
            if (CostoTextBox.Text != string.Empty || PrecioTextBox.Text != string.Empty)
            {
                if (Costo > Precio)
                {
                    Utils.ShowToastr(this, "El costo debe ser menor que el precio", "Error", "error");
                    return;
                }
                else
                    GananciaTextBox.Text = Metodo.Ganancia(Costo, Precio).ToString();
            }
            else
                Utils.ShowToastr(this, "Debe llenar campo Costo", "Error", "error");

        }
        
        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal Costo = Utils.ToDecimal(CostoTextBox.Text);
            decimal Precio = Utils.ToDecimal(PrecioTextBox.Text);

            if (CostoTextBox.Text != string.Empty || PrecioTextBox.Text != string.Empty)
            {
                if (Costo > Precio)
                {
                    Utils.ShowToastr(this, "El costo debe ser menor que el precio", "Error", "error");
                }
                else
                    GananciaTextBox.Text = Metodo.Ganancia(Costo, Precio).ToString();
            }
            else
                Utils.ShowToastr(this, "Debe llenar campo Precio", "Error", "error");
        }

       
    }
}
using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
using ProyectoFinalAp2.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalAp2.UI.Consultas
{
    public partial class ConsultasArticulo : System.Web.UI.Page
    {
        static List<Articulo> lista = new List<Articulo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (!Page.IsPostBack)
            {
                LlenaReport();
            }
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulo, bool>> filtro = x => true;
            RepositorioBase<Articulo> repositorio = new RepositorioBase<Articulo>();

            int id;
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;
                case 1://ID
                    id = Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.ArticuloID == id;
                    break;
                case 2:// Descipcion
                    filtro = c => c.Descripcion.Contains(FiltroTextBox.Text);
                    break;
            }

            DateTime desdeTextBox = Utils.ToFecha(DesdeTextBox.Text);
            DateTime FechaHasta = Utils.ToFecha(HastaTextBox.Text);
            if (fechaCheckBox.Checked)
                lista = repositorio.GetList(filtro).Where(c => c.FechaCreacion >= desdeTextBox && c.FechaCreacion <= FechaHasta).ToList();
            else
                lista = repositorio.GetList(filtro);
            this.BindGrid(lista);
        }
        private void BindGrid(List<Articulo> lista)
        {
            DatosGridView.DataSource = lista;
            DatosGridView.DataBind();
        }

        protected void FechaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fechaCheckBox.Checked)
            {
                fechaCheckBox.Visible = true;
                fechaCheckBox.Visible = true;
            }
            else
            {
                fechaCheckBox.Visible = false;
                fechaCheckBox.Visible = false;
            }
        }
        public void LlenaReport()
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", $"ShowReporte('');", true);
            ArticuloReportViewer.ProcessingMode = ProcessingMode.Local;
            ArticuloReportViewer.Reset();
            ArticuloReportViewer.LocalReport.ReportPath = Server.MapPath(@"\Reportes\ReportesArticulo.rdlc");
            ArticuloReportViewer.LocalReport.DataSources.Clear();
            ArticuloReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Articulo", Metodo.INVarticulo()));
            ArticuloReportViewer.LocalReport.Refresh();
        }
    }
}
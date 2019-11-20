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

namespace ProyectoFinalAp2.UI.Consultas
{
    public partial class ConsultasCategoria : System.Web.UI.Page
    {
        static List<Categoria> lista = new List<Categoria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //if (!Page.IsPostBack)
            //{
            //    LlenaReport();
            //}
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Categoria, bool>> filtro = x => true;
            RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();

            int id;
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;
                case 1://ID
                    id = Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.CategoriaId == id;
                    break;
                case 2:
                        filtro = c => c.Nombre.Contains(FiltroTextBox.Text);
                    break;
                case 3:// Descipcion
                    filtro = c => c.Descripcion.Contains(FiltroTextBox.Text);
                    break;
            }

            DateTime desdeTextBox = Utils.ToFecha(DesdeTextBox.Text);
            DateTime FechaHasta = Utils.ToFecha(HastaTextBox.Text);
            if (fechaCheckBox.Checked)
                lista = repositorio.GetList(filtro).Where(c => c.Fecha >= desdeTextBox && c.Fecha <= FechaHasta).ToList();
            else
                lista = repositorio.GetList(filtro);
            this.BindGrid(lista);
        }
        private void BindGrid(List<Categoria> lista)
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
        //public void LlenaReport()
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", $"ShowReporte('');", true);
        //    MyEstudiantesReportViewer.ProcessingMode = ProcessingMode.Local;
        //    MyEstudiantesReportViewer.Reset();
        //    MyEstudiantesReportViewer.LocalReport.ReportPath = Server.MapPath(@"\Reportes\ReportesEstudiante.rdlc");
        //    MyEstudiantesReportViewer.LocalReport.DataSources.Clear();
        //    MyEstudiantesReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Estudiantes", Metodo.EvEstudiantes()));
        //    MyEstudiantesReportViewer.LocalReport.Refresh();
        //}
    }
}

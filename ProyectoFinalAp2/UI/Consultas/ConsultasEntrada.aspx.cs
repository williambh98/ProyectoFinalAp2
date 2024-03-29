﻿using BLL;
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
    public partial class ConsutasEntrada : System.Web.UI.Page
    {
        static List<EntradaDetalle> lista = new List<EntradaDetalle>();
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
            Expression<Func<EntradaDetalle, bool>> filtro = x => true;
            RepositorioBase<EntradaDetalle> repositorio = new RepositorioBase<EntradaDetalle>();

            int id;
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;
                case 1://ID
                    id = Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.EntradaId == id;
                    break;
                case 2:// Cantidad
                    id = Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.Cantidad == id;
                    break;

                case 3:// Costo
                    id = Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.Costo == id;
                    break;
            }

            DateTime desdeTextBox = Utils.ToFecha(DesdeTextBox.Text);
            DateTime FechaHasta = Utils.ToFecha(HastaTextBox.Text);
            if (fechaCheckBox.Checked)
                lista = repositorio.GetList(filtro).Where(c => c.FechaVencimiento >= desdeTextBox && c.FechaVencimiento <= FechaHasta).ToList();
            else
                lista = repositorio.GetList(filtro);
            this.BindGrid(lista);
        }
        private void BindGrid(List<EntradaDetalle> lista)
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
            EntradaReportViewer.ProcessingMode = ProcessingMode.Local;
            EntradaReportViewer.Reset();
            EntradaReportViewer.LocalReport.ReportPath = Server.MapPath(@"\Reportes\ReportesEntradaD.rdlc");
            EntradaReportViewer.LocalReport.DataSources.Clear();
            EntradaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("EntradaD", Metodo.INVEntradaDetalle()));
            EntradaReportViewer.LocalReport.Refresh();
        }
    }
}

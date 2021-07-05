using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_2.Presentacion
{
    public partial class frmCartelera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListarCartelera();
                this.ListarEspectaculo();
            }
        }
        private bool ComprobarDatos()
        {
            if (this.txtEspectaculo.Text == "" || this.txtFechaComienzo.Text == "" || this.txtFechaFin.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void LimpiarCampos()
        {
            this.txtEspectaculo.Text = "";
            this.txtFechaComienzo.Text = "";
            this.txtFechaFin.Text = "";
        }
        private void ListarCartelera()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.lstListaCartelera.DataSource = null;
            this.lstListaCartelera.DataSource = unaEmpresa.ListaCartelera();
            this.lstListaCartelera.DataBind();
        }

        private void ListarEspectaculo()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaEspectaculo.DataSource = null;
            this.gvListaEspectaculo.DataSource = unaEmpresa.ListaDeEspectaculo();
            this.gvListaEspectaculo.DataBind();
        }

        protected void gvListaEspectaculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaEspectaculo.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(id);
            this.txtEspectaculo.Text = unEspectaculo.ToString();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!ComprobarDatos())
            {
                GridViewRow rowEspectaculo = gvListaEspectaculo.SelectedRow;
                short IdEspectaculo = short.Parse(rowEspectaculo.Cells[1].Text);
                DateTime FechaComienzo = DateTime.Parse(this.txtFechaComienzo.Text);
                DateTime FechaFin = DateTime.Parse(this.txtFechaFin.Text);

                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(IdEspectaculo);
                Dominio.Cartelera unaCartelera = new Dominio.Cartelera(FechaComienzo, FechaFin, unEspectaculo);
                if (unaEmpresa.AltaCartelera(unaCartelera))
                {
                    this.lblMensaje.Text = "Ingresado con exito";
                    unaCartelera.IncrementarId();
                    this.LimpiarCampos();
                    this.ListarCartelera();
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo Ingresar";
                    this.LimpiarCampos();
                }
            }
            else
            {
                this.lblMensaje.Text = "Faltan datos";
            }
        }

        protected void dtpFechaComienzo_SelectionChanged(object sender, EventArgs e)
        {
            this.txtFechaComienzo.Text = this.dtpFechaComienzo.SelectedDate.ToShortDateString();
        }

        protected void dtpFechaFin_SelectionChanged(object sender, EventArgs e)
        {
            this.txtFechaFin.Text = this.dtpFechaFin.SelectedDate.ToShortDateString();
        }

        protected void lstListaCartelera_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CargarDatos = this.lstListaCartelera.SelectedItem.ToString();
            string[] array = CargarDatos.Split(' ');
            short id = short.Parse(array[1]);

            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            Dominio.Cartelera unaCartelera = unaEmpresa.BuscarCartelera(id);

            this.txtCartelera.Text = unaCartelera.ToString();
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (this.txtCartelera.Text != "")
            {

                Dominio.Empresa unaEmpresa = new Dominio.Empresa();

                string CargarDatos = this.txtCartelera.Text;
                string[] array = CargarDatos.Split(' ');
                short id = short.Parse(array[1]);

                if (unaEmpresa.BajaCartelera(id))
                {
                    this.lblMensaje.Text = "Se Elimino con exito";
                    this.ListarCartelera();
                    this.LimpiarCampos();
                    this.txtCartelera.Text = "";
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo Eliminar";
                }

            }
            else
            {
                this.lblMensaje.Text = "Seleccione Una Cartelera";
            }
        }


    }
}
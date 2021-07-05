using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_2.Presentacion
{
    public partial class frmConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnOrdenoPremiun_Click(object sender, EventArgs e)
        {
            this.lblListaSocioPremiun.Visible = true;
            this.gvListaSocioPremiunOrdeno.Visible = true;
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaSocioPremiunOrdeno.DataSource = null;
            this.gvListaSocioPremiunOrdeno.DataSource = unaEmpresa.ListaOrdenadaSocioPremiun();
            this.gvListaSocioPremiunOrdeno.DataBind();
        }

        protected void btnSalasTickets_Click(object sender, EventArgs e)
        {
            this.lblSala.Visible = true;
            this.gvListaSala.Visible = true;
            DateTime FechaSala = this.dtpFechaSala.SelectedDate;
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaSala.DataSource = null;
            this.gvListaSala.DataSource = unaEmpresa.ListaSalasTicketVendidos(FechaSala);
            this.gvListaSala.DataBind();
        }

        protected void btnListarEspectaculos_Click(object sender, EventArgs e)
        {
            this.gvListaEspectaculosSala.Visible = true;
            string nombre = this.txtNombreSala.Text;
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaEspectaculosSala.DataSource = null;
            this.gvListaEspectaculosSala.DataSource = unaEmpresa.ListaDeEspectaculosDadoUnaSala(nombre);
            this.gvListaEspectaculosSala.DataBind();
        }

      
           

    }
}
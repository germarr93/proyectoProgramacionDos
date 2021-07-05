using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_2.Presentacion
{
    public partial class frmAuspiciante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListarAuspiciante();
        }


        private bool ComprobarDatos()
        {
            if (this.txtRut.Text == "" || this.txtDireccion.Text == "" || this.txtNombreE.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LimpiarDatos()
        {
            this.txtRut.Text = "";
            this.txtNombreE.Text = "";
            this.txtDireccion.Text = "";
            this.txtNombreE.Focus();
        }

        private void ListarAuspiciante()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaAuspiciante.DataSource = null;
            this.gvListaAuspiciante.DataSource = unaEmpresa.ListaDeAuspiciantes();
            this.gvListaAuspiciante.DataBind();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                string NombreE = this.txtNombreE.Text;
                string Direccion = this.txtDireccion.Text;
                int rut = int.Parse(this.txtRut.Text);
                Dominio.Auspiciante unAuspiciante = new Dominio.Auspiciante(NombreE, rut, Direccion);
                unAuspiciante.IncrementarId();
                if (unaEmpresa.AltaAuspiciante(unAuspiciante))
                {
                    this.lblMensaje.Text = "Ingresado con exito";
                    this.ListarAuspiciante();
                    this.LimpiarDatos();
                }
                else
                {
                    this.lblMensaje.Text = "No se ingreso";
                    unAuspiciante.DesincrementarId();
                    this.LimpiarDatos();
                }

            }
            else
            {
                this.lblMensaje.Text = "Faltan Datos";
            }
        }



        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow row = this.gvListaAuspiciante.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);

                if (unaEmpresa.BajaAuspiciante(id))
                {
                    this.lblMensaje.Text = "Eliminado con exito";
                    this.ListarAuspiciante();
                    this.LimpiarDatos();
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo eliminar";
                    this.LimpiarDatos();
                }

            }
            else
            {
                this.lblMensaje.Text = "Seleccione un Auspiciante de la lista";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow row = this.gvListaAuspiciante.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                string NombreE = this.txtNombreE.Text;
                string direccion = this.txtDireccion.Text;
                int rut = int.Parse(this.txtRut.Text);

                if (unaEmpresa.ModificarAuspiciante(id, rut, NombreE, direccion))
                {
                    this.lblMensaje.Text = "Modificado con exito";
                    this.LimpiarDatos();
                    this.ListarAuspiciante();
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo eliminar";
                    this.LimpiarDatos();
                }
            }
            else
            {
                this.lblMensaje.Text = "Seleccione un Auspiciante,Faltan Datos";
            }
        }

        protected void gvListaAuspiciante_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaAuspiciante.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Auspiciante unAuspiciante = unaEmpresa.BuscarAuspiciante(id);
            this.txtNombreE.Text = unAuspiciante.NombreEmpresa;
            this.txtRut.Text = unAuspiciante.Rut.ToString();
            this.txtDireccion.Text = unAuspiciante.Direccion;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_2.Presentacion
{
    public partial class frmSala : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private bool ComprobarDatos()
        {
            if (this.txtNombre.Text == "" || this.txtDireccion.Text == "" || this.txtTelefono.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Limpiar()
        {
            this.txtNombre.Text = "";
            this.txtDireccion.Text = "";
            this.txtTelefono.Text = "";
            this.txtNombre.Focus();
        }

        private void Listar()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaSalas.DataSource = null;
            this.gvListaSalas.DataSource = unaEmpresa.ListaDeSalas();
            this.gvListaSalas.DataBind();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                string nombre = this.txtNombre.Text;
                string direccion = this.txtDireccion.Text;
                int telefono = int.Parse(this.txtTelefono.Text);

                Dominio.Sala unaSala = new Dominio.Sala(nombre, direccion, telefono);
                unaSala.IncrementarId();
                if (unaEmpresa.AltaSala(unaSala))
                {
                    this.lblMensaje.Text = "Ingresado con exito";
                    this.Listar();
                    this.Limpiar();
                }
                else
                {
                    this.lblMensaje.Text = "No se ingreso";
                    unaSala.DesincrementarId();
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
                GridViewRow row = this.gvListaSalas.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                if (unaEmpresa.BajaSala(id))
                {
                    this.lblMensaje.Text = "Eliminado con exito";
                    this.Listar();
                    this.Limpiar();
                }
                else
                {
                    this.lblMensaje.Text = "No se dio de baja";
                    this.Limpiar();
                }

            }
            else
            {
                this.lblMensaje.Text = "Seleccione una Sala";
            }
        }

        protected void gvListaSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaSalas.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Sala unaSala = unaEmpresa.BuscarSala(id);
            this.txtNombre.Text = unaSala.Nombre;
            this.txtDireccion.Text = unaSala.Direccion;
            this.txtTelefono.Text = unaSala.Telefono.ToString();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow row = this.gvListaSalas.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                string nombre = this.txtNombre.Text;
                string direccion = this.txtDireccion.Text;
                int telefono = int.Parse(this.txtTelefono.Text);
                if (unaEmpresa.ModificarSala(id, nombre, direccion, telefono))
                {
                    this.lblMensaje.Text = "Modificado con exito";
                    this.Limpiar();
                    this.Listar();
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo modificar";
                }

            }
            else
            {
                this.lblMensaje.Text = "Faltan Datos o seleccione una Sala";
            }
        }




    }
}
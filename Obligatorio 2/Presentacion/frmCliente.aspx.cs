using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Obligatorio_2.Persistencia;

namespace Obligatorio_2.Presentacion
{
    public partial class frmCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Listar();
            }
        }

        private bool ComprobarDatos()
        {
            if (this.txtNombre.Text == "" || this.txtCedula.Text == "" || this.txtTelefono.Text == "")
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
            this.txtNombre.Text = "";
            this.txtCedula.Text = "";
            this.txtTelefono.Text = "";
            this.txtNombre.Focus();
        }

        private void Listar()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaClientes.DataSource = null;
            this.gvListaClientes.DataSource = unaEmpresa.ListaClientes();
            this.gvListaClientes.DataBind();
            }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                string nombre = this.txtNombre.Text;

                int telefono = int.Parse(this.txtTelefono.Text);
                int cedula = int.Parse(this.txtCedula.Text);

                Dominio.Validacion unaValidacion = new Dominio.Validacion();
                if (unaValidacion.ValidarCedula(cedula))
                {
                    Dominio.Cliente unCliente = new Dominio.Cliente(nombre, telefono, cedula);
                    unCliente.IncrementarId();
                    if (unaEmpresa.AltaCliente(unCliente))
                    {
                        this.lblMensaje.Text = "Ingresado con exito";
                        // unCliente.IncrementarId();
                    //    Controladora.Instancia.AltaCliente(unCliente);
                        this.Listar();
                        this.LimpiarCampos();
                    }
                    else
                    {
                        this.lblMensaje.Text = "Error no se ha ingresado";
                        unCliente.DesincremetarId();


                    }
                }
                else
                {
                    this.lblMensaje.Text = "La cedula no es correcta";
                    
                }

            }
            else
            {
                this.lblMensaje.Text = "Faltan Datos";
            }

        
        }

       
        protected void gvListaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaClientes.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Cliente unCliente = unaEmpresa.BuscarCliente(id);
            this.txtNombre.Text = unCliente.Nombre;
            this.txtCedula.Text = unCliente.Cedula.ToString();
            this.txtTelefono.Text = unCliente.Telefono.ToString();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow row = this.gvListaClientes.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                string nombre = this.txtNombre.Text;
                int cedula = int.Parse(this.txtCedula.Text);
                int telefono = int.Parse(this.txtTelefono.Text);

                if (unaEmpresa.ModificarCliente(id, nombre, telefono, cedula))
                {
                    Dominio.Validacion unaValidacion = new Dominio.Validacion();
                    if (unaValidacion.ValidarCedula(cedula))
                    {


                        this.lblMensaje.Text = "Modificado con exito";
                        this.Listar();
                        this.LimpiarCampos();
                    }
                    else
                    {
                        this.lblMensaje.Text = "La cedula no es correcta";
                    }
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo modificar";
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
                GridViewRow row = this.gvListaClientes.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                if (unaEmpresa.BajaCliente(id))
                {
                    this.lblMensaje.Text = "Eliminado con exito";
                    this.Listar();
                    this.LimpiarCampos();
                }
                else
                {
                    this.lblMensaje.Text = "No se dio de baja";
                    this.LimpiarCampos();
                }
            }
        }







        
    }
}
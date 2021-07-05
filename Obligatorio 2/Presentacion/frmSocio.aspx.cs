using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_2.Presentacion
{
    public partial class frmSocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListarSociosComunes();
                this.ListarSociosPremiun();
            }
        }

        private bool ComprobarDatos()
        {
            if (this.txtCl.Text == "" || this.txtNombre.Text == "" || this.txtDireccion.Text == "" || this.txtTelefono.Text == "" ||
                this.txtEmail.Text == "")
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
            this.txtCl.Text = "";
            this.txtNombre.Text = "";
            this.txtDireccion.Text = "";
            this.txtTelefono.Text = "";
            this.txtEmail.Text = "";
            this.txtCl.Focus();
        }

        private void ListarSociosComunes()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvSocioComun.DataSource = null;
            this.gvSocioComun.DataSource = unaEmpresa.ListaDeSociosComunes();
            this.gvSocioComun.DataBind();
        }

        private void ListarSociosPremiun()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvSocioPremiun.DataSource = null;
            this.gvSocioPremiun.DataSource = unaEmpresa.ListaDeSociosPremiuns();
            this.gvSocioPremiun.DataBind();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                Dominio.Validacion unaValidacion = new Dominio.Validacion();
                int cedula = int.Parse(this.txtCl.Text);
                string nombre = this.txtNombre.Text;
                string direccion = this.txtDireccion.Text;
                int telefono = int.Parse(this.txtTelefono.Text);
                string email = this.txtEmail.Text;
                DateTime fecha = new DateTime();
                fecha = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

                if (this.rdbComun.Checked)
                {
                    Dominio.Comun unComun = new Dominio.Comun(cedula, nombre, direccion, telefono, email, fecha);
                    if (unaValidacion.ValidarCedula(cedula))
                    {
                        unComun.IncrementarId();
                        if (unaEmpresa.AltaSocioComun(unComun))
                        {
                            this.lblMensaje.Text = "Ingresado con exito";
                            this.ListarSociosComunes();
                            this.LimpiarCampos();
                        }
                        else
                        {
                            unComun.DesincremetarId();
                            this.lblMensaje.Text = "no se pudo Ingresar";
                        }
                    }
                    else
                    {
                        this.lblMensaje.Text = "Cedula incorrecta";
                    }

                }
                else
                {
                    if (this.rdbPremiun.Checked)
                    {
                        Dominio.Premiun unPremiun = new Dominio.Premiun(cedula, nombre, direccion, telefono, email, fecha);
                        if (unaValidacion.ValidarCedula(cedula))
                        {
                            unPremiun.IncrementarId();
                            if (unaEmpresa.AltaSocioPremiun(unPremiun))
                            {
                                this.lblMensaje.Text = "Ingresado con exito";
                                this.ListarSociosPremiun();
                                this.LimpiarCampos();
                            }
                            else
                            {
                                this.lblMensaje.Text = "no se puede ingresar";
                                unPremiun.DesincrementarId();
                            }
                        }
                        else
                        {
                            this.lblMensaje.Text = "Cedula incorrecta";
                        }
                    }
                    else
                    {
                        this.lblMensaje.Text = "Seleccione un tipo de socio";
                    }
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
                if (this.rdbComun.Checked)
                {
                    GridViewRow row = this.gvSocioComun.SelectedRow;
                    short id = short.Parse(row.Cells[1].Text);
                    if (unaEmpresa.BajaSocioComun(id))
                    {
                        this.lblMensaje.Text = "Eliminado con exito";
                        this.ListarSociosComunes();
                        this.LimpiarCampos();
                        this.rdbComun.Enabled = true;
                        this.rdbPremiun.Enabled = true;
                        this.btnAlta.Enabled = true;


                    }
                    else
                    {
                        this.lblMensaje.Text = "No se pudo eliminar";
                    }
                }
                else
                {
                    if (this.rdbPremiun.Checked)
                    {
                        GridViewRow row = this.gvSocioPremiun.SelectedRow;
                        short id = short.Parse(row.Cells[1].Text);
                        if (unaEmpresa.BajaSocioPremiun(id))
                        {
                            this.lblMensaje.Text = "Eliminado con exito";
                            this.ListarSociosPremiun();
                            this.LimpiarCampos();
                            this.rdbComun.Enabled = true;
                            this.rdbPremiun.Enabled = true;
                            this.btnAlta.Enabled = true;
                        }
                        else
                        {
                            this.lblMensaje.Text = "No se pudo eliminar";
                            this.LimpiarCampos();
                            this.rdbComun.Enabled = true;
                            this.rdbPremiun.Enabled = true;
                            this.btnAlta.Enabled = true;
                        }
                    }
                    else
                    {
                        this.lblMensaje.Text = "Seleccione un tipo de socio";
                    }
                }
            }
            else
            {
                this.lblMensaje.Text = "Seleccione un Socio Primero";
            }
        
    
        }

        protected void gvSocioComun_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvSocioComun.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Comun unComun = unaEmpresa.BuscarSocioComun(id);
            this.txtNombre.Text = unComun.Nombre;
            this.txtCl.Text = unComun.Cedula.ToString();
            this.txtDireccion.Text = unComun.Direccion;
            this.txtEmail.Text = unComun.Email;
            this.txtTelefono.Text = unComun.Telefono.ToString();
            this.rdbPremiun.Enabled = false;
            this.btnAlta.Enabled = false;
            this.rdbComun.Enabled = true;
            this.rdbComun.Checked = true;
            this.rdbPremiun.Checked = false;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Validacion unaValidacion = new Dominio.Validacion();
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                string nombre = this.txtNombre.Text;
                int cedula = int.Parse(this.txtCl.Text);
                int telefono = int.Parse(this.txtTelefono.Text);
                string direccion = this.txtDireccion.Text;
                string email = this.txtEmail.Text;
                DateTime fecha = new DateTime();
                fecha = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

                if (this.rdbComun.Checked == true)
                {
                    if (unaValidacion.ValidarCedula(cedula))
                    {
                        GridViewRow row = this.gvSocioComun.SelectedRow;
                        short id = short.Parse(row.Cells[1].Text);
                        if (unaEmpresa.ModificarSocioComun(id, cedula, nombre, direccion, telefono, email, fecha))
                        {
                            this.lblMensaje.Text = "Modificado con exito";
                            this.rdbPremiun.Enabled = true;
                            this.btnAlta.Enabled = true;
                            this.rdbComun.Enabled = true;
                            this.ListarSociosComunes();
                            this.LimpiarCampos();
                        }
                        else
                        {
                            this.lblMensaje.Text = "No se pudo modificar";
                            this.rdbPremiun.Enabled = true;
                            this.btnAlta.Enabled = true;
                            this.rdbComun.Enabled = true;
                        }
                    }
                    else
                    {
                        this.lblMensaje.Text = "La cedula no es correcta";
                    }
                }
                else
                {
                    if (this.rdbPremiun.Checked == true)
                    {
                        if (unaValidacion.ValidarCedula(cedula))
                        {
                            GridViewRow row = this.gvSocioPremiun.SelectedRow;
                            short id = short.Parse(row.Cells[1].Text);
                            if (unaEmpresa.ModificarSocioPremiun(id, cedula, nombre, direccion, telefono, email, fecha))
                            {
                                this.lblMensaje.Text = "Modificado con exito";
                                this.rdbPremiun.Enabled = true;
                                this.btnAlta.Enabled = true;
                                this.rdbComun.Enabled = true;
                                this.ListarSociosPremiun();
                                this.LimpiarCampos();
                            }
                            else
                            {
                                this.lblMensaje.Text = "No se pudo modificar";
                                this.rdbPremiun.Enabled = true;
                                this.btnAlta.Enabled = true;
                                this.rdbComun.Enabled = true;
                            }

                        }
                        else
                        {
                            this.lblMensaje.Text = "Cedula Incorrecta";
                        }

                    }
                    else
                    {
                        this.lblMensaje.Text = "Seleccione un Tipo de Socio";
                    }
                }
            }
            else
            {
                this.lblMensaje.Text = "Faltan Datos";
            }
        }

        protected void gvSocioPremiun_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvSocioPremiun.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Premiun unPremiun = unaEmpresa.BuscarSocioPremiun(id);
            this.txtNombre.Text = unPremiun.Nombre;
            this.txtCl.Text = unPremiun.Cedula.ToString();
            this.txtDireccion.Text = unPremiun.Direccion;
            this.txtEmail.Text = unPremiun.Email;
            this.txtTelefono.Text = unPremiun.Telefono.ToString();
            this.rdbComun.Enabled = false;
            this.btnAlta.Enabled = false;
            this.rdbPremiun.Checked = true;
            this.rdbPremiun.Enabled = true;
            this.rdbComun.Checked = false;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtCl.Text = "";
            this.txtDireccion.Text = "";
            this.txtEmail.Text = "";
            this.txtNombre.Text = "";
            this.txtTelefono.Text = "";
            this.rdbComun.Enabled = true;
            this.rdbPremiun.Enabled = false;
        }

    

   

      


    }
}
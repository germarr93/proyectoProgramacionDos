using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Obligatorio_2.Presentacion
{
    public partial class frmVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListarEspectaculo();
                this.ListarVenta();
                this.ListarCliente();
                this.ListarSocioComun();
                this.ListarSocioPremiun();
            }
        }
        private void ListarEspectaculo()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvEspectaculo.DataSource = null;
            this.gvEspectaculo.DataSource = unaEmpresa.ListaDeEspectaculo();
            this.gvEspectaculo.DataBind();
        }
        private void ListarVenta()
        {
            Dominio.Empresa unaEmprsa = new Dominio.Empresa();
            this.lstListaVentas.DataSource = null;
            this.lstListaVentas.DataSource = unaEmprsa.ListaDeVentas();
            this.lstListaVentas.DataBind();
        }
        private void ListarSocioPremiun()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvSocioPremiun.DataSource = null;
            this.gvSocioPremiun.DataSource = unaEmpresa.ListaDeSociosPremiuns();
            this.gvSocioPremiun.DataBind();
        }
        private void ListarSocioComun()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvSocioComun.DataSource = null;
            this.gvSocioComun.DataSource = unaEmpresa.ListaDeSociosComunes();
            this.gvSocioComun.DataBind();
        }
        private void ListarCliente()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaCliente.DataSource = null;
            this.gvListaCliente.DataSource = unaEmpresa.ListaClientes();
            this.gvListaCliente.DataBind();
        }

        private bool ComprobarDatos()
        {
            if (this.txtEspectaculo.Text == "" || this.txtPersona.Text == "" || this.txtFila.Text == "" || this.txtColumna.Text == ""|| this.txtSector.Text == "")
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
            this.txtEspectaculo.Text = "";
            this.txtPersona.Text = "";
            this.txtFila.Text = "";
            this.txtColumna.Text = "";
            this.txtSector.Text = "";
        }



        protected void gvSocioPremiun_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.lstEspectaculos.ClearSelection();
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow filas = this.gvSocioPremiun.SelectedRow;
            short id = short.Parse(filas.Cells[1].Text);
            Dominio.Premiun unpremiun = unaEmpresa.BuscarSocioPremiun(id);
            this.txtPersona.Text = unpremiun.ToString();
            this.rdbCliente.Checked = false;
            this.rdbSocioComun.Checked = false;
            this.rdbCliente.Enabled = false;
            this.rdbSocioComun.Enabled = false;
            this.rdbSocioPremiun.Checked = true;
        }

        protected void gvSocioComun_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvSocioComun.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Comun unComun = unaEmpresa.BuscarSocioComun(id);
            this.txtPersona.Text = unComun.ToString();
            this.rdbSocioPremiun.Checked = false;
            this.rdbCliente.Checked = false;
            this.rdbSocioPremiun.Enabled = false;
            this.rdbCliente.Enabled = false;
            this.rdbSocioComun.Checked = true;
        }

        protected void gvListaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaCliente.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Cliente unCliente = unaEmpresa.BuscarCliente(id);
            this.txtPersona.Text = unCliente.ToString();
            this.rdbSocioPremiun.Checked = false;
            this.rdbSocioComun.Checked = false;
            this.rdbSocioPremiun.Enabled = false;
            this.rdbSocioComun.Enabled = false;
            this.rdbCliente.Checked = true;

        }

        protected void gvEspectac_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.gvEspectaculo.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(id);
            this.txtEspectaculo.Text = unEspectaculo.ToString();

            Dominio.Sala unaSala = unEspectaculo.Sala;
            this.lstSector.DataSource = null;
            this.lstSector.DataSource = unaSala.ListaSectoresEnSala();
            this.lstSector.DataBind();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow filaEspectaculo = this.gvEspectaculo.SelectedRow;
                short IdEspectaculo = short.Parse(filaEspectaculo.Cells[1].Text);
                Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(IdEspectaculo);
                DateTime fecha = new DateTime();
                fecha = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
               
                int fila = int.Parse(this.txtFila.Text);
                int columna = int.Parse(this.txtColumna.Text);
                string asignar = this.lstSector.SelectedItem.ToString();
                string[] vector = asignar.Split(' ');
                short idS = short.Parse(vector[1]);
                Dominio.Sector unSector = unEspectaculo.Sala.BuscarSector(idS);

                if (unaEmpresa.ReservarAsiento(unSector, fila, columna))
                {
                    string asiento = "Fila: " + fila + " " + "Asiento: " + columna;




                    if (this.rdbCliente.Checked)
                    {
                        GridViewRow filaCliente = this.gvListaCliente.SelectedRow;
                        short IdCliente = short.Parse(filaCliente.Cells[1].Text);
                        Dominio.Cliente unCliente = unaEmpresa.BuscarCliente(IdCliente);
                        Dominio.Venta unaVenta = new Dominio.Venta(fecha, unEspectaculo, unCliente, asiento,unSector);
                        if (unaEmpresa.AltaVenta(unaVenta))
                        {
                            unaVenta.IncrementarId();
                            this.lblMensaje.Text = "Ingresado con exito";
                            this.ListarVenta();
                            this.Limpiar();
                            this.rdbCliente.Enabled = true;
                            this.rdbSocioComun.Enabled = true;
                            this.rdbSocioPremiun.Enabled = true;
                        }
                        else
                        {
                            this.lblMensaje.Text = "No se pudo ingresar";
                            this.Limpiar();
                            this.rdbCliente.Enabled = true;
                            this.rdbSocioComun.Enabled = true;
                            this.rdbSocioPremiun.Enabled = true;
                        }
                    }
                    if (this.rdbSocioComun.Checked)
                    {
                        GridViewRow filaComun = this.gvSocioComun.SelectedRow;
                        short idSocioComun = short.Parse(filaComun.Cells[1].Text);
                        Dominio.Comun unComun = unaEmpresa.BuscarSocioComun(idSocioComun);
                        Dominio.Venta unaVenta = new Dominio.Venta(fecha, unEspectaculo, unComun, asiento, unSector);
                        if (unaEmpresa.AltaVenta(unaVenta))
                        {
                            this.lblMensaje.Text = "Ingresado con exito";
                            unaVenta.IncrementarId();
                            this.ListarVenta();
                            this.Limpiar();
                            this.rdbCliente.Enabled = true;
                            this.rdbSocioComun.Enabled = true;
                            this.rdbSocioPremiun.Enabled = true;
                        }
                        else
                        {
                            this.lblMensaje.Text = "No se pudo ingresar";
                            this.Limpiar();
                            this.rdbCliente.Enabled = true;
                            this.rdbSocioComun.Enabled = true;
                            this.rdbSocioPremiun.Enabled = true;
                        }
                    }
                    if (this.rdbSocioPremiun.Checked)
                    {
                        GridViewRow filaPremiun = this.gvSocioPremiun.SelectedRow;
                        short IdPremiun = short.Parse(filaPremiun.Cells[1].Text);
                        Dominio.Premiun unPremiun = unaEmpresa.BuscarSocioPremiun(IdPremiun);
                        Dominio.Venta unaVenta = new Dominio.Venta(fecha, unEspectaculo, unPremiun, asiento, unSector);
                        if (unaEmpresa.AltaVenta(unaVenta))
                        {
                            this.lblMensaje.Text = "Ingresado con exito";
                            unaVenta.IncrementarId();
                            this.ListarVenta();
                            this.Limpiar();
                            this.rdbCliente.Enabled = true;
                            this.rdbSocioComun.Enabled = true;
                            this.rdbSocioPremiun.Enabled = true;
                        }
                        else
                        {
                            this.lblMensaje.Text = "No se pudo ingresar";
                            this.rdbCliente.Enabled = true;
                            this.rdbSocioComun.Enabled = true;
                            this.rdbSocioPremiun.Enabled = true;
                        }
                    }
                }
                else
                {
                    this.lblMensaje.Text = "Asiento ya reservado o no existe";
                }

            }
            else
            {
                this.lblMensaje.Text = "Faltan Datos";
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (this.txtEspectaculo.Text != "")
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                string asignar = this.txtEspectaculo.Text;
                string[] vector = asignar.Split(' ');
                short id = short.Parse(vector[1]);

                if (unaEmpresa.BajaVenta(id))
                {
                    this.lblMensaje.Text = "Eliminado con exito";
                    this.ListarVenta();
                    this.Limpiar();
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo eliminar";
                    this.Limpiar();
                }
            }
            else
            {
                this.lblMensaje.Text = "Seleccione una Venta";
            }
        }

        protected void lstListaVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            string asignar = this.lstListaVentas.SelectedItem.ToString();
            string[] array = asignar.Split(' ');
            short id = short.Parse(array[1]);
            Dominio.Venta unaVenta = unaEmpresa.BuscarVenta(id);
            this.txtEspectaculo.Text = unaVenta.ToString();
        }

        protected void lstSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtEspectaculo.Text != "")
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                string asignar = this.lstSector.SelectedItem.ToString();
                string[] array = asignar.Split(' ');
                short id = short.Parse(array[1]);

                string Espectaculo = this.txtEspectaculo.Text;
                string[] vector = Espectaculo.Split(' ');
                short idEs = short.Parse(vector[1]);
                Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(idEs);
                this.txtEspectaculo.Text = unEspectaculo.ToString();
                Dominio.Sala unaSala = unEspectaculo.Sala;
                Dominio.Sector unSector = unaSala.BuscarSector(id);
                this.txtSector.Text = unSector.ToString();
            }
            else
            {
                this.lblMensaje.Text = "Seleccione un Espectaculo";
            }
        }





    }
}
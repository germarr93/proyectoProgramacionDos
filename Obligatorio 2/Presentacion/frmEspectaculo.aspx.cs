using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_2.Presentacion
{
    public partial class frmEspectaculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.ListarAuspiciantes();
            this.ListarEspectaculos();
            this.ListarEspectaculosParaAsignar();
            this.ListarSalas();
        }

        private bool ComprobarDatos()
        {
            if (this.txtNombre.Text == "" || this.txtPrecio.Text == "" || this.txtTipo.Text == "" || this.txtSala.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ListarSalas()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaDeSalas.DataSource = null;
            this.gvListaDeSalas.DataSource = unaEmpresa.ListaDeSalas();
            this.gvListaDeSalas.DataBind();
        }

        private void ListarEspectaculos()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaEspectaculos.DataSource = null;
            this.gvListaEspectaculos.DataSource = unaEmpresa.ListaDeEspectaculo();
            this.gvListaEspectaculos.DataBind();
        }
        //Listas para Asignar

        private void ListarEspectaculosParaAsignar()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaEspectaculosAsignar.DataSource = null;
            this.gvListaEspectaculosAsignar.DataSource = unaEmpresa.ListaDeEspectaculo();
            this.gvListaEspectaculosAsignar.DataBind();
        }

        private void ListarAuspiciantes()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaAuspiciante.DataSource = null;
            this.gvListaAuspiciante.DataSource = unaEmpresa.ListaDeAuspiciantes();
            this.gvListaAuspiciante.DataBind();
        }

        private void LimpiarCampos()
        {
            this.txtNombre.Text = "";
            this.txtPrecio.Text = "";
            this.txtSala.Text = "";
            this.txtTipo.Text = "";
            this.txtNombre.Focus();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                string nombre = this.txtNombre.Text;
                int precio = int.Parse(this.txtPrecio.Text);
                string tipo = this.txtTipo.Text;

                GridViewRow row = this.gvListaDeSalas.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
               /*tring asignar = this.txtSala.Text;
                string[] array = asignar.Split(' ');
                short id = short.Parse(array[1]);
                * */
                Dominio.Sala unaSala = unaEmpresa.BuscarSala(id);

                Dominio.Espectaculo unEspectaculo = new Dominio.Espectaculo(nombre, precio, tipo, unaSala);

                if (unaEmpresa.AltaEspectaculo(unEspectaculo))
                {
                    this.lblMensaje.Text = "Se ingreso correctamente";
                    unEspectaculo.IncrementarId();
                    this.LimpiarCampos();
                    this.ListarEspectaculos();
                    this.ListarEspectaculosParaAsignar();
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo Ingresar";
                    this.LimpiarCampos();
                }

            }
            else
            {
                this.lblMensaje.Text = "Faltan Datos";
            }
        }

        protected void gvListaDeSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaDeSalas.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Sala unaSala = unaEmpresa.BuscarSala(id);
            this.txtSala.Text = unaSala.ToString();
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow row = this.gvListaEspectaculos.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                if (unaEmpresa.BajaEspectaculo(id))
                {
                    this.lblMensaje.Text = "Eliminado con exito";
                    this.LimpiarCampos();
                    this.ListarEspectaculos();
                    this.ListarEspectaculosParaAsignar();
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo eliminar";
                }
            }
            else
            {
                this.lblMensaje.Text = "Faltan Datos, Seleccione un Espectaculo";
            }
        }

        protected void gvListaEspectaculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaEspectaculos.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(id);
            this.txtNombre.Text = unEspectaculo.Nombre;
            this.txtPrecio.Text = unEspectaculo.Precio.ToString();
            this.txtTipo.Text = unEspectaculo.Tipo;
            this.txtSala.Text = unEspectaculo.Sala.ToString();

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow row = this.gvListaEspectaculos.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(id);
                string nombre = this.txtNombre.Text;
                int precio = int.Parse(this.txtPrecio.Text);
                string tipo = this.txtTipo.Text;
                if (unaEmpresa.ModificarEspectaculo(id, nombre, precio, tipo))
                {
                    this.lblMensaje.Text = "Modificado con exito";
                    this.LimpiarCampos();
                    this.ListarEspectaculos();
                    this.ListarEspectaculosParaAsignar();
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo Modificar";
                    this.LimpiarCampos();
                }
            }
            else
            {
                this.lblMensaje.Text = "Faltan Datos, seleccione un espectaculo";
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            if (this.txtEspectaculo.Text != "" || this.txtAuspiciante.Text != "")
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow rowE = this.gvListaEspectaculosAsignar.SelectedRow;
                short idE = short.Parse(rowE.Cells[1].Text);
                Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(idE);

                GridViewRow rowA = this.gvListaAuspiciante.SelectedRow;
                short idA = short.Parse(rowA.Cells[1].Text);
                Dominio.Auspiciante unAuspiciante = unaEmpresa.BuscarAuspiciante(idA);

                if (unaEmpresa.AsignarAuspicianteEspectaculo(unEspectaculo, unAuspiciante))
                {
                    this.lblMensajeAsignar.Text = "Asignado con exito";
                    this.lblEspectaculo.Text = unEspectaculo.ToString();
                    this.gvListaAuspicianteEspectaculo.DataSource = null;
                    this.gvListaAuspicianteEspectaculo.DataSource = unEspectaculo.ListaAuspiciantesEnEspectaculo();
                    this.gvListaAuspicianteEspectaculo.DataBind();
                    this.txtAuspiciante.Text = "";
                    this.txtEspectaculo.Text = "";
                }
                else
                {
                    this.lblMensajeAsignar.Text = "No se pudo Asignar";
                }
            }
            else
            {
                this.lblMensajeAsignar.Text = "Faltan Datos";
            }
        }

        protected void gvListaEspectaculosAsignar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaEspectaculosAsignar.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(id);
            this.txtEspectaculo.Text = unEspectaculo.ToString();
        }

        protected void gvListaAuspiciante_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaAuspiciante.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Auspiciante unAuspiciante = unaEmpresa.BuscarAuspiciante(id);
            this.txtAuspiciante.Text = unAuspiciante.ToString();
        }

        protected void btnBuscarSector_Click(object sender, EventArgs e)
        {
            if (this.txtSala.Text != "")
            {
                Dominio.Empresa unaEmprsa = new Dominio.Empresa();
                GridViewRow row = this.gvListaDeSalas.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                Dominio.Sala unaSala = unaEmprsa.BuscarSala(id);
                this.lstSectores.DataSource = null;
                this.lstSectores.DataSource = unaSala.ListaSectoresEnSala();
                this.lstSectores.DataBind();
                this.txtSala.Text = "";
            }
            else
            {
                this.lblMensaje.Text = "Debes seleccionar una Sala";
               
            }
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            if (this.txtEspectaculo.Text != "" || this.txtAuspiciante.Text != "")
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();

                GridViewRow row = this.gvListaEspectaculosAsignar.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(id);

                GridViewRow rowAus = this.gvListaAuspicianteEspectaculo.SelectedRow;
                short idAus = short.Parse(rowAus.Cells[1].Text);
                Dominio.Auspiciante unAuspiciante = unEspectaculo.BuscarAuspiciante(idAus);

                if (unaEmpresa.RemoverAuspicianteEspectaculo(unEspectaculo, unAuspiciante))
                {
                    this.lblMensajeAsignar.Text = "Removido con exito";
                    this.gvListaAuspicianteEspectaculo.DataSource = null;
                    this.gvListaAuspicianteEspectaculo.DataSource = unEspectaculo.ListaAuspiciantesEnEspectaculo();
                    this.gvListaAuspicianteEspectaculo.DataBind();
                    this.txtAuspiciante.Text = "";
                    this.txtEspectaculo.Text = "";
                }
                else
                {
                    this.lblMensajeAsignar.Text = "No se pudo remover";
                    this.txtAuspiciante.Text = "";
                    this.txtEspectaculo.Text = "";

                }


            }
            else
            {
                this.lblMensajeAsignar.Text = "Faltan Datos";
            }
        }

        protected void gvListaAuspicianteEspectaculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtEspectaculo.Text != "")
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow row = this.gvListaEspectaculosAsignar.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(id);

                GridViewRow rowAus = this.gvListaAuspicianteEspectaculo.SelectedRow;
                short idAus = short.Parse(rowAus.Cells[1].Text);
                Dominio.Auspiciante unAuspiciante = unEspectaculo.BuscarAuspiciante(idAus);
                this.txtAuspiciante.Text = unAuspiciante.ToString();
            }
            else
            {
                this.lblMensajeAsignar.Text = "Primero seleccione un espectaculo";
            }
        }

        protected void btnLimpiar2_Click(object sender, EventArgs e)
        {
            this.txtEspectaculo.Text = "";
            this.txtAuspiciante.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.txtEspectaculo.Text != "")
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();

                GridViewRow row = this.gvListaEspectaculosAsignar.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                Dominio.Espectaculo unEspectaculo = unaEmpresa.BuscarEspectaculo(id);
                this.gvListaAuspicianteEspectaculo.DataSource = null;
                this.gvListaAuspicianteEspectaculo.DataSource = unEspectaculo.ListaAuspiciantesEnEspectaculo();
                this.gvListaAuspicianteEspectaculo.DataBind();
                this.lblEspectaculo.Text = unEspectaculo.ToString();
            }
            else
            {
                this.lblMensajeAsignar.Text = "Seleccione un Espectaculo";
            }

        }

       /* protected void lstEspectaculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            string asignar = this.lstEspectaculo.SelectedItem.ToString();
            string[] array = asignar.Split(' ');
            short id = short.Parse(array[1]);
            Dominio.Sala unaSala = unaEmpresa.BuscarSala(id);
            this.txtSala.Text = unaSala.ToString();
        }
        * */



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio_2.Presentacion
{
    public partial class frmSector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListarSectores();
            this.ListarSalas();
            this.ListarSectoresParaSala();
        }


        private bool ComprobarDatos()
        {
            if (this.txtNombre.Text == "" || this.txtCantidadA.Text == "")
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
            this.txtCantidadA.Text = "";
            this.txtNombre.Text = "";
            this.txtNombre.Focus();
        }


        private void ListarSectores()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaSectores.DataSource = null;
            this.gvListaSectores.DataSource = unaEmpresa.ListaDeSectores();
            this.gvListaSectores.DataBind();
        }


        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();

                string Nombre = this.txtNombre.Text;
                int CantidadAsientos = int.Parse(this.txtCantidadA.Text);
                Dominio.Sector unSector = new Dominio.Sector(Nombre, CantidadAsientos);
                if (unaEmpresa.AltaSector(unSector))
                {
                    
                    this.lblMensaje.Text = "Alta: Correctamente";
                    unSector.IncementarId();
                    this.Limpiar();
                    this.ListarSectores();
                    this.ListarSectoresParaSala();
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo dar de alta";
                    this.Limpiar();
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
                Dominio.Empresa unaEmprsa = new Dominio.Empresa();
                GridViewRow row = this.gvListaSectores.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                if (unaEmprsa.BajaSector(id))
                {
                    this.lblMensaje.Text = "Eliminado con exito";
                    this.ListarSectores();
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
                this.lblMensaje.Text = "Seleccione un Sector";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.ComprobarDatos())
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow row = this.gvListaSectores.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                string nombre = this.txtNombre.Text;
                int cantidad = int.Parse(this.txtCantidadA.Text);

                if (unaEmpresa.ModificarSector(id, nombre, cantidad))
                {
                    this.lblMensaje.Text = "Modificado con exito";
                    this.Limpiar();
                    this.ListarSectores();
                }
                else
                {
                    this.lblMensaje.Text = "No se pudo modificar";
                    this.Limpiar();
                }


            }
            else
            {
                this.lblMensaje.Text = "Faltan Datos";
            }
        }

        protected void btnLimiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        protected void gvListaSectores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaSectores.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Sector unSector = unaEmpresa.BuscarSectores(id);
            this.txtNombre.Text = unSector.Nombre;
            this.txtCantidadA.Text = unSector.CantidadAsientos.ToString();
        }

        protected void gvListaSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvListaSala.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Sala unaSala = unaEmpresa.BuscarSala(id);
            this.txtSala.Text = unaSala.ToString();
        }

        private void ListarSalas()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvListaSala.DataSource = null;
            this.gvListaSala.DataSource = unaEmpresa.ListaDeSalas();
            this.gvListaSala.DataBind();
        }

        private void ListarSectoresParaSala()
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            this.gvSectores.DataSource = null;
            this.gvSectores.DataSource = unaEmpresa.ListaDeSectores();
            this.gvSectores.DataBind();

        }

        protected void gvSectores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Empresa unaEmpresa = new Dominio.Empresa();
            GridViewRow row = this.gvSectores.SelectedRow;
            short id = short.Parse(row.Cells[1].Text);
            Dominio.Sector unSector = unaEmpresa.BuscarSectores(id);
            this.txtSector.Text = unSector.ToString();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            if (this.txtSala.Text != "" || this.txtSector.Text != "")
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();

                GridViewRow row = this.gvListaSala.SelectedRow;
                short id = short.Parse(row.Cells[1].Text);
                Dominio.Sala unaSala = unaEmpresa.BuscarSala(id);

                GridViewRow rowSector = this.gvSectores.SelectedRow;
                short idSector = short.Parse(rowSector.Cells[1].Text);
                Dominio.Sector unSector = unaEmpresa.BuscarSectores(idSector);

                if (unaEmpresa.AltaSectoresSala(unaSala, unSector))
                {
                    this.lblMensaje2.Text = "Asignado con exito";
                    this.lblObjetSala.Text = unaSala.ToString();
                    this.gvListaSectoresEnSala.DataSource = null;
                    this.gvListaSectoresEnSala.DataSource = unaSala.ListaSectoresEnSala();
                    this.gvListaSectoresEnSala.DataBind();
                    this.txtSala.Text = "";
                    this.txtSector.Text = "";
                    this.ListarSalas();
                    this.ListarSectores();
                    this.ListarSectoresParaSala();
                    if (unaEmpresa.BajaSector(unSector.Id))
                    {
                        this.ListarSectores();
                       this.ListarSectoresParaSala();
                        
                    }
                }
                else
                {
                    this.lblMensaje2.Text = "No se pudo asignar";
                }
            }
            else
            {
                this.lblMensaje2.Text = "Faltan Datos";
            }
        }

        protected void gvListaSectoresEnSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtSala.Text != "")
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();

                GridViewRow FilaSala = this.gvListaSala.SelectedRow;
                short idSala = short.Parse(FilaSala.Cells[1].Text);
                Dominio.Sala unaSala = unaEmpresa.BuscarSala(idSala);
                GridViewRow FilaSector = this.gvListaSectoresEnSala.SelectedRow;
                short idSector = short.Parse(FilaSector.Cells[1].Text);
                Dominio.Sector unSector = unaSala.BuscarSector(idSector);
                this.txtSector.Text = unSector.ToString();

            }
            else
            {
                this.lblMensaje2.Text = " Seleccione una Sala Pirmero";
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.txtSala.Text != "" || this.txtSector.Text != "")
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow FilaSala = this.gvListaSala.SelectedRow;
                short idSala = short.Parse(FilaSala.Cells[1].Text);
                Dominio.Sala unaSala = unaEmpresa.BuscarSala(idSala);

                GridViewRow FilaSector = this.gvListaSectoresEnSala.SelectedRow;
                short idSector = short.Parse(FilaSector.Cells[1].Text);
                Dominio.Sector unSector = unaSala.BuscarSector(idSector);

                if (unaEmpresa.BajaSectoresSala(unaSala, unSector))
                {
                    this.lblMensaje2.Text = " Eliminado con exito";
                    this.ListarSectoresParaSala();
                    this.gvListaSectoresEnSala.DataSource = null;
                    this.gvListaSectoresEnSala.DataSource = unaSala.ListaSectoresEnSala();
                    this.gvListaSectoresEnSala.DataBind();
                    this.txtSala.Text = "";
                    this.txtSector.Text = "";
                    if (unaEmpresa.AltaSector(unSector))
                    {
                        this.ListarSectores();
                        this.ListarSectoresParaSala();
                    }
                }
                else
                {
                    this.lblMensaje2.Text = "No se pudo eliminar";
                }
            }
            else
            {
                this.lblMensaje2.Text = "Faltan Datos";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.txtSala.Text != "")
            {
                Dominio.Empresa unaEmpresa = new Dominio.Empresa();
                GridViewRow rowSala = this.gvListaSala.SelectedRow;
                short idSala = short.Parse(rowSala.Cells[1].Text);
                Dominio.Sala unaSala = unaEmpresa.BuscarSala(idSala);
                this.lblObjetSala.Text = unaSala.ToString();
                this.gvListaSectoresEnSala.DataSource = null;
                this.gvListaSectoresEnSala.DataSource = unaSala.ListaSectoresEnSala();
                this.gvListaSectoresEnSala.DataBind();
                this.txtSala.Text ="";

            }
            else
            {
                this.lblMensaje2.Text = "Seleccione una sala";
            }
        }



    }
}
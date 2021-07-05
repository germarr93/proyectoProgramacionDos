using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio_2.Dominio;
using System.Data;


namespace Obligatorio_2.Persistencia
{
    public class pPremiun
    {
        private static pPremiun _instancia;

        public static pPremiun Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pPremiun();

                }
                return _instancia;
            }
        }

        private pPremiun()
        {


        }


        public bool ExistePremiun(short pId)
        {
            return Conexion.Instancia.InizializarSeccion("select *from Socio_Premiun where Id_Premiun= " + pId).Tables[0].Rows.Count > 0;

        }


        public bool AltaSocioPremium(Premiun pPremiun)
        {
            if (pPremiun == null)
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta("Insert into Socio_Premiun(Id_Premiun,Cl_Premiun,Nombre_Premiun,Direccion_Premiun,Telefono_Premiun,Email_Premiun,Fecha_Ingreso_Premiun) values (" 
                    + pPremiun.Id + ","
                    + pPremiun.Cedula + ",' "
                    + pPremiun.Nombre + "',' "
                    + pPremiun.Direccion + "', "
                    + pPremiun.Telefono + ",' "
                    + pPremiun.Email + "',' "
                    + pPremiun.FechaIngreso + "')");
                return true;
            }
        }


        public bool BajaSocioPremiun(Premiun pPremiun)
        {
            if (!this.ExistePremiun(pPremiun.Id))
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta("Delete from Socio_Premiun where Id_Premiun=" + pPremiun.Id);

                return true;
            }
        }

        public bool ModificarPremiun(Premiun pPremiun)
        {
            if (!this.ExistePremiun(pPremiun.Id))
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta(
                    "Update Socio_Premiun set Nombre_Premiun =" + "'" + pPremiun.Nombre + "'"
                    + ", Cl_Premiun =" + pPremiun.Cedula 
                    + ", Direccion_Premiun = " +  "'" + pPremiun.Direccion +  "'"
                    + ",Telefono_Premiun= " + pPremiun.Telefono 
                    + ",Email_Premiun =" +  "'" + pPremiun.Email +  "'"
                    + ",Fecha_Ingreso_Premiun =" +  "'" + pPremiun.FechaIngreso +  "'"
                    + " where Id_Premiun=" + pPremiun.Id + ";");
                return true;
            }

        }

        public List<Premiun> Listar()
        {
            string sql = "Select * from Socio_Premiun";
            DataSet datos = Conexion.Instancia.InizializarSeccion(sql);
            List<Premiun> lista = new List<Premiun>();
            if (datos == null)
            {
                return lista;
            }
            else
            {
                DataRowCollection tabla = datos.Tables[0].Rows;
                foreach (DataRow fila in tabla)
                {
                    object[] elementos = fila.ItemArray;
                    Dominio.Premiun unPremiun = new Premiun();
                    unPremiun.Id = short.Parse(elementos[0].ToString());
                    unPremiun.Cedula = int.Parse(elementos[1].ToString());
                    unPremiun.Nombre = elementos[2].ToString();
                    unPremiun.Direccion = elementos[3].ToString();
                    unPremiun.Telefono = int.Parse(elementos[4].ToString());
                    unPremiun.Email = elementos[5].ToString();
                    unPremiun.FechaIngreso = DateTime.Parse(elementos[6].ToString());
                    lista.Add(unPremiun);
                }
                return lista;
            }

        }

    }
}
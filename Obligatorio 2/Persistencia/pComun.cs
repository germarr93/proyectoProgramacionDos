using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio_2.Dominio;
using System.Data;

namespace Obligatorio_2.Persistencia
{
    public class pComun
    {
        private static pComun _instancia;

        public static pComun Instancia
        {
            get {
                if (_instancia == null)
                {
                    _instancia = new pComun();
                }
                return _instancia;
            }
        }

        private pComun()
        {

        }

        public bool ExisteComun(short pId)
        {
            return Conexion.Instancia.InizializarSeccion("select * from Socio_Comun where Id_Comun=" + pId).Tables[0].Rows.Count > 0;
        }

        public bool AltaSocioComun(Comun pComun)
        {
            if (pComun == null)
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta(
                    "Insert into Socio_Comun(Id_Comun,Cl_Comun,Nombre_Comun,Direccion_Comun,Telefono_Comun,Email_Comun,Fecha_Ingreso_Comun) values (" 
                    + pComun.Id + ", "
                    + pComun.Cedula + " ,  '"
                    + pComun.Nombre + "', ' "
                    + pComun.Direccion +"',  "
                    + pComun.Telefono + ",  '"
                    + pComun.Email + "', ' "
                    + pComun.FechaIngreso + "')");
                return true;
            }
        }

        public bool BajaSocioComun(Comun pComun)
        {
            if (!this.ExisteComun(pComun.Id))
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta("Delete from Socio_Comun where Id_Comun= " + pComun.Id);
                return true;
            }
        }

        public bool ModificarComun(Comun pComun)
        {
            if (!this.ExisteComun(pComun.Id))
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta(
                    "Update Socio_Comun set Nombre_Comun=" + "'" + pComun.Nombre + "'"
                    + ",Cl_Comun= " + pComun.Cedula
                + ",Direccion_Comun= " + "'" + pComun.Direccion + "'"
                + ",Telefono_Comun= " + pComun.Telefono
                + ",Email_Comun=" + "'" + pComun.Email + "'"
                + ",Fecha_Ingreso_Comun=" + "'" + pComun.FechaIngreso + "'"
                + " where Id_Comun=" + pComun.Id + ";");
                return true;
            }
        }

        public List<Comun> ListarComun()
        {
            string sql = "Select * from Socio_Comun";
            DataSet Datos = Conexion.Instancia.InizializarSeccion(sql);
            List<Comun> ListaDeSociosComunes = new List<Comun>();
            if (Datos == null)
            {
                return ListaDeSociosComunes;
            }
            else
            {
                DataRowCollection tabla = Datos.Tables[0].Rows;
                foreach (DataRow fila in tabla)
                {
                    object[] elementos = fila.ItemArray;
                    Comun unComun = new Comun();
                    unComun.Id = short.Parse(elementos[0].ToString());
                    unComun.Cedula = int.Parse(elementos[1].ToString());
                    unComun.Nombre = elementos[2].ToString();
                    unComun.Direccion = elementos[3].ToString();
                    unComun.Telefono = int.Parse(elementos[4].ToString());
                    unComun.Email = elementos[5].ToString();
                    unComun.FechaIngreso = DateTime.Parse(elementos[6].ToString());
                    ListaDeSociosComunes.Add(unComun);
                }
                return ListaDeSociosComunes;
            }

        }



    }
}
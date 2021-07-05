using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio_2.Dominio;
using System.Data;

namespace Obligatorio_2.Persistencia
{
    public class pAupiciante
    {
        private static pAupiciante _instancia;

        public static pAupiciante Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pAupiciante();
                }
                return _instancia;
            }

        }
        public pAupiciante()
        {

        }

        public bool ExisteAuspiciante(short pId)
        {
            return Conexion.Instancia.InizializarSeccion("Select * from Auspiciante where Id_Auspiciante=" + pId).Tables[0].Rows.Count > 0;
        }

        public bool AltaAuspiciante(Auspiciante pAuspiciantes)
        {
            if (pAuspiciantes == null)
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta(
                    "Insert into Auspiciante(Id_Auspiciante,Nombre_Empresa,Rut_Auspiciante,Direccion_Auspiciante) values (" +
                    pAuspiciantes.Id + ", '"
                    + pAuspiciantes.NombreEmpresa + "', "
                    + pAuspiciantes.Rut + ", '"
                    + pAuspiciantes.Direccion + " ' )");
                return true;
            }
        }

        public bool BajaAuspiciante(Auspiciante pAuspiciantes)
        {
            if (!this.ExisteAuspiciante(pAuspiciantes.Id))
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta("delete from Auspiciante where Id_Auspiciante=" + pAuspiciantes.Id);
                return true;
            }

        }

        public bool ModificarAuspiciante(Auspiciante pAuspiciantes)
        {
            if (!this.ExisteAuspiciante(pAuspiciantes.Id))
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta(
                    "Update Auspiciante set Nombre_Empresa=" + "'" + pAuspiciantes.NombreEmpresa + "'"
                + ",Rut_Auspiciante=" + pAuspiciantes.Rut
                + ",Direccion_Auspiciante=" + "'" + pAuspiciantes + "'"
                + ",where Id_Auspiciante=" + pAuspiciantes.Id + ";");
                return true;
            }
        }


        public List<Auspiciante> ListarAuspiciantes()
        {
            string sql = "Select * from Auspiciante";
            DataSet datos = Conexion.Instancia.InizializarSeccion(sql);
            List<Auspiciante> lista = new List<Auspiciante>();
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
                    Dominio.Auspiciante unAuspiciante = new Auspiciante();
                    unAuspiciante.Id = short.Parse(elementos[0].ToString());
                    unAuspiciante.NombreEmpresa = elementos[1].ToString();
                    unAuspiciante.Rut = int.Parse(elementos[2].ToString());
                    unAuspiciante.Direccion = elementos[3].ToString();
                    lista.Add(unAuspiciante);

                }
                return lista;


            }
        }



            
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio_2.Dominio;
using System.Data;

namespace Obligatorio_2.Persistencia
{
    public class pSala
    {
        private static pSala _instancia;

        public static pSala Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pSala();
                }
                return _instancia;
            }
        }
        private pSala()
        {

        }


        public bool ExisteSala(short pId)
        {
            return Conexion.Instancia.InizializarSeccion("Select * from Salas where Id_Sala=" + pId).Tables[0].Rows.Count > 0;
        }


        public bool AltaSala(Sala pSalas)
        {
            if (pSalas == null)
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta(
                "Insert into Salas (Id_Sala,Nombre_Sala,Telefono_Sala,Direccion_Sala) values(" + pSalas.Id + ", '"
              + pSalas.Nombre + "',  "
              + pSalas.Telefono + ", ' "
              + pSalas.Direccion + "')");
                return true;
            }
        }

        public bool BajaSala(Sala pSalas)
        {
            if (!this.ExisteSala(pSalas.Id))
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta("delete from Salas where Id_Sala=" + pSalas.Id);
                return true;
            }
        }

        public bool ModificarSala(Sala pSalas)
        {
            if (!this.ExisteSala(pSalas.Id))
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta(
                    "Update Salas set Nombre_Sala =" + "' " + pSalas.Nombre + "' "
                + ", Telefono_Sala= " + pSalas.Telefono
                + ",Direccion_Sala= " + "'" + pSalas.Direccion + "'"
                + "where Id_Sala=" + pSalas.Id + ";");
                return true;
            }
        }

        public List<Sala> Listar()
        {
            string sql = "Select * from Salas";
            DataSet datos = Conexion.Instancia.InizializarSeccion(sql);
            List<Sala> lista = new List<Sala>();
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
                    Dominio.Sala unaSala = new Sala();
                    unaSala.Id = short.Parse(elementos[0].ToString());
                    unaSala.Nombre = elementos[1].ToString();
                    unaSala.Direccion = elementos[2].ToString();
                    unaSala.Telefono = int.Parse(elementos[3].ToString());
                    lista.Add(unaSala);
                }
                return lista;
            }
        }
    }
}
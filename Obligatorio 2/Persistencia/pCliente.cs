using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio_2.Dominio;
using System.Data;

namespace Obligatorio_2.Persistencia
{
    public class pCliente
    {
        private static pCliente _instancia;

        public static pCliente Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new pCliente();
                }
                return _instancia;
            }
        }
        private pCliente()
        {

        }


        public bool ExisteCliente(short pId)
        {
            return Conexion.Instancia.InizializarSeccion("Select * from Cliente where Id_Cliente=" + pId).Tables[0].Rows.Count >0;
        }


        public bool AltaCliente(Cliente pClientes)
        {
            if (pClientes == null)
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta(
                    "Insert into Cliente (Id_Cliente,Nombre_Cliente,Telefono_Cliente,Cl_Cliente) values(" + pClientes.IdCliente + ", '"
                    + pClientes.Nombre + "',  "
                    + pClientes.Telefono + ",  "
                    + pClientes.Cedula + ")");
                return true;
            }
        }

        public bool BajaCliente(Cliente pClientes)
        {
            if (!this.ExisteCliente(pClientes.IdCliente))
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta("Delete from Cliente where Cl_Cliente=" + pClientes.Cedula);
                return true;
            }
        }

        public bool ModificarCliente(Cliente pClientes)
        {
            if (!this.ExisteCliente(pClientes.IdCliente))
            {
                return false;
            }
            else
            {
                Conexion.Instancia.InizializarConsulta(
                    "Update Cliente set Nombre_Cliente=" + "'" + pClientes.Nombre + "'"
                    + ", Telefono_Cliente=" + pClientes.Telefono
                    + ", Cl_Cliente=" + pClientes.Cedula
                    + " where Id_Cliente=" + pClientes.IdCliente + ";");
                return true;
            }
        }
        

        public List<Cliente> Listar()
        {
            string sql = "Select * from Cliente";
            DataSet datos = Conexion.Instancia.InizializarSeccion(sql);
            List<Cliente> lista = new List<Cliente>();
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
                    Cliente unCliente = new Cliente();
                    unCliente.IdCliente = short.Parse(elementos[0].ToString());
                    unCliente.Nombre = elementos[1].ToString();
                    unCliente.Telefono =int.Parse(elementos[2].ToString());
                    unCliente.Cedula = int.Parse(elementos[3].ToString());
                    lista.Add(unCliente);

                }
                return lista;
            }
        }
       
            
        


        

    }
}
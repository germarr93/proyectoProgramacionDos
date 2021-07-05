using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Obligatorio_2.Persistencia
{
    public class Conexion
    {
        private static Conexion _instancia;
        private string cadenaConexion;
        private SqlConnection conexion;


        public static Conexion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Conexion();
                }
                return _instancia;
            }
        }

        private Conexion()
        {
            this.cadenaConexion = @"Data Source=LAB1-M4-PC2;Initial Catalog=Obligatorio2Programacion;Integrated Security=true ";

        } 

        public bool Conectar()
        {
            try
            {
                this.conexion = new SqlConnection(this.cadenaConexion);
                this.conexion.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void InizializarConsulta(string sql)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql);
                this.Conectar();
                comando.Connection = this.conexion;
                comando.ExecuteNonQuery();
                comando.Dispose();
                conexion.Close();
            }
            catch (Exception e)
            {

            }
        }


        public DataSet InizializarSeccion(string sql)
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql);
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataSet resultado = new DataSet();
                this.Conectar();
                comando.Connection = this.conexion;
                adaptador.Fill(resultado);
                comando.Dispose();
                this.conexion.Close();
                return resultado;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
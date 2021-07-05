using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public class Cliente
    {
        private static short UltimoIdCliente = 0;
        private string _nombre;
        private int _telefono;
        private int _cedula;

        public short IdCliente
        {
            get;
            set;
        }
        public int Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public override string ToString()
        {
            return "Id: " + this.IdCliente + " " + "Nombre: " + this.Nombre + " " + "Telefono: " 
                + this.Telefono + " " + "Cedula: " + this.Cedula;
        }
        public void IncrementarId()
        {
            Cliente.UltimoIdCliente += 1;
            this.IdCliente = Cliente.UltimoIdCliente;
           
        }
        public void DesincremetarId()
        {
            Cliente.UltimoIdCliente --;
            this.IdCliente = Cliente.UltimoIdCliente;

        }

        public bool ExisteCliente(Cliente pCliente)
        {
            if (pCliente != null)
            {
                Cliente.UltimoIdCliente = pCliente.IdCliente;
                return true;
            }
            else
            {
                return false;
            }
        }
        public Cliente(string pNombre, int pTelefono, int pCedula)
        {
            this.IdCliente = Cliente.UltimoIdCliente;
            this.Nombre = pNombre;
            this.Telefono = pTelefono;
            this.Cedula = pCedula;
        }
        public Cliente()
        {

        }

    }
}
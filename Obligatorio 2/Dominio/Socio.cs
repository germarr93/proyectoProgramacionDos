using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public abstract class Socio
    {
        private int _cedula;
        private string _nombre;
        private string _direccion;
        private int _telefono;
        private string _email;
        private DateTime _fecha;

   

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

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public DateTime FechaIngreso
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public override string ToString()
        {
            return "Cedula: " + this.Cedula + " " + "Nombre: " + this.Nombre + " " +
                this.Nombre + " " + "Direccion: " + this.Direccion + " " + "Telefono: " + this.Telefono + " " + "Email: " +
                this.Email + " " + "Fecha Ingreso: " + this.FechaIngreso.ToShortDateString();
        }
       

        public Socio(int pCedula, string pNombre, string pDireccion, int pTelefono, string pEmail, DateTime pFechaIngreso)
        {
            
            this.Cedula = pCedula;
            this.Nombre = pNombre;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
            this.Email = pEmail;
            this.FechaIngreso = pFechaIngreso;
        }

        public Socio()
        {

        }
       

            
        
    }
}
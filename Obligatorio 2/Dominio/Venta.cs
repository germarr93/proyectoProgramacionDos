using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public class Venta
    {
        private static short UltimoId = 0;
        private DateTime _fecha;
        private Premiun _premiun;
        private Comun _comun;
        private Cliente _cliente;
        private Espectaculo _espectaculo;
        private string _Asiento;
        private Sector _sector;

        public short Id
        {
            get;
            set;
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public Premiun Premiun
        {
            get { return _premiun; }
            set { _premiun = value; }
        }
        public Comun Comun
        {
            get { return _comun; }
            set { _comun = value; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public Espectaculo Espectaculo
        {
            get { return _espectaculo; }
            set { _espectaculo = value; }
        }

        public string Asiento
        {
            get { return _Asiento; }
            set { _Asiento = value; }
        }
        public Sector Sector
        {
            get { return _sector; }
            set { _sector = value; }
        }
        public override string ToString()
        {
            return "Id: " + this.Id + " " + "Fecha: " + this.Fecha.ToShortDateString() + " " + "Espectaculo: " + this.Espectaculo.Id + " " +
                "Cliente: " + this.ValidarClienteActivo().ToString()+ " " +"Sector: " + this.Sector.Id + " " + "Reserva: "+ this.Asiento;
        }
        private Object ValidarClienteActivo()
        {
            if (Comun != null)
            {
                return "Id: " + Comun.Id + " " + "Nombre: " + Comun.Nombre+ " " + "Cl: " + Comun.Cedula;
            }
            else if (Premiun != null)
            {
                return"ID: " + Premiun.Id + " " + "Nombre: " + Premiun.Nombre + " " + "Cl: " + Premiun.Cedula;
            }
            else
            {
                return "ID: " + Cliente.IdCliente + " " + "Nombre: "+ Cliente.Nombre + " " + "Cl: " + Cliente.Cedula;
            }
        }

        public void IncrementarId()
        { 
            Venta.UltimoId += 1;
            this.Id = Venta.UltimoId;
        }

        public Venta(DateTime pFecha, Espectaculo pEspectaculo, Premiun pPremiun, string pAsiento, Sector pSector)
        {
            this.Fecha = pFecha;
            this.Espectaculo = pEspectaculo;
            this.Premiun = pPremiun;
            this.Asiento = pAsiento;
            this.Sector = pSector;
        }
        public Venta(DateTime pFecha, Espectaculo pEspectaculo, Comun pComun, string pAsiento, Sector pSector)
        {
            this.Fecha = pFecha;
            this.Espectaculo = pEspectaculo;
            this.Comun = pComun;
            this.Asiento = pAsiento;
            this.Sector = pSector;
        }
        public Venta(DateTime pFecha, Espectaculo pEspectaculo, Cliente pCliente, string pAsiento, Sector pSector)
        {
            this.Fecha = pFecha;
            this.Espectaculo = pEspectaculo;
            this.Cliente = pCliente;
            this.Asiento = pAsiento;
            this.Sector = pSector;
        }
        public Venta()
        {

        }
    }
}

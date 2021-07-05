using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public class Sala
    {
        private static short UltimoId = 0;
        private string _nombre;
        private string _direccion;
        private int _telefono;
        private Sector _sector;

        public short Id
        {
            get;
            set;
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
        public Sector Sector
        {
            get { return _sector; }
            set { _sector = value; }
        }


        public override string ToString()
        {
            return "Id: " + this.Id + " " + "Nombre: " + this.Nombre + " " + "Direccion: " + this.Direccion + " " + "Telefono: " + this.Telefono;

        }

        public Sala(string pNombre, string pDireccion, int pTelefono)
        {
            this.Id = Sala.UltimoId;
            this.Nombre = pNombre;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
        }

        public void IncrementarId()
        {
            Sala.UltimoId += 1;
            this.Id = Sala.UltimoId;
        }
        public void DesincrementarId()
        {
            Sala.UltimoId--;
            this.Id = Sala.UltimoId;
        }
        private List<Sector> _ListaSector = new List<Sector>();

        public List<Sector> ListaSectoresEnSala()
        {
            return _ListaSector;
        }

        public Sector BuscarSector(short pId)
        {
            foreach (Sector unSector in _ListaSector)
            {
                if (unSector.Id == pId)
                {
                    return unSector;
                }
            }
            return null;
        }


        public void AsignarSectorSala(Sector pSector)
        {
            Dominio.Sector unSector = this.BuscarSector(pSector.Id);
            if (unSector == null)
            {
                _ListaSector.Add(pSector);
            }
        }

        public void RemoverSectorSala(Sector pSector)
        {
            Dominio.Sector unSector = this.BuscarSector(pSector.Id);
            if (unSector != null)
            {
                _ListaSector.Remove(unSector);
            }
        }
        public Sala()
        {
        }


    }
}
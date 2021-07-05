using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public class Auspiciante
    {
        private static short UltimoId = 0;
        private string _nombreEmpresa;
        private int _rut;
        private string _direccion;

        public short Id
        {
            get;
            set;
        }

        public string NombreEmpresa
        {
            get { return _nombreEmpresa; }
            set { _nombreEmpresa = value; }
        }
        public int Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public void IncrementarId()
        {
            Auspiciante.UltimoId += 1;
            this.Id = Auspiciante.UltimoId;
        }

        public void DesincrementarId()
        {
            Auspiciante.UltimoId--;
            this.Id = Auspiciante.UltimoId;
        }
        public bool ComprobarSiExiste(Auspiciante pAuspiciante)
        {
            if (pAuspiciante != null)
            {
                Auspiciante.UltimoId = pAuspiciante.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Id:" + this.Id.ToString("00") + " " + "Nombre Empresa: " + this.NombreEmpresa;
        }

        public Auspiciante(string pNombreE, int pRut, string pDireccion)
        {
            this.Id = Auspiciante.UltimoId;
            this.NombreEmpresa = pNombreE;
            this.Rut = pRut;
            this.Direccion = pDireccion;
        }
        public Auspiciante()
        {

        }
    
    }
}
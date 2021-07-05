using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public class Cartelera
    {
        private static short UltimoId = 0;
        DateTime _FechaComienzo;
        DateTime _FechaFin;
        private Espectaculo _Espectaculo;

        public short Id
        {
            get;
            set;
        }
        public DateTime FechaComienzo
        {
            get { return _FechaComienzo; }
            set { _FechaComienzo = value; }
        }
        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }

        public Espectaculo Espectaculo
        {
            get { return _Espectaculo; }
            set { _Espectaculo = value; }
        }


        public override string ToString()
        {
            return "Id: " + this.Id + " " + "Fecha Comienzo: " + FechaComienzo.ToString("dd/MM/yyyy")
            + " " + "Fecha Fin: " + this.FechaFin.ToString("dd/MM/yyyy")
            + " " + "Espectaculo: " + this.Espectaculo;
        }

        public void IncrementarId()
        {
            Cartelera.UltimoId += 1;
            this.Id = Cartelera.UltimoId;
        }

        public Cartelera(DateTime pFechaComienzo, DateTime pFechaFin, Espectaculo pEspectaculo)
        {
            this.Id = Cartelera.UltimoId;
            this.FechaComienzo = pFechaComienzo;
            this.FechaFin = pFechaFin;
            this.Espectaculo = pEspectaculo;
        }
    }
}
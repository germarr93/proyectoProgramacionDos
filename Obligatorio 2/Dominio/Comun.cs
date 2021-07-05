using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public class Comun:Socio
    {
        private static short UltimoId = 0;

        public short Id
        {
            get;
            set;
        }
        public override string ToString()
        {
            return "Id: " + this.Id.ToString("00") + " " + base.ToString();
        }
        public void IncrementarId()
        {       
            Comun.UltimoId += 1;
            this.Id = Comun.UltimoId;
        }
        public void DesincremetarId()
        {
            Comun.UltimoId--;
            this.Id = Comun.UltimoId;

        }
        public bool ExisteSocioComun(Comun pComun)
        {
            if (pComun != null)
            {
                Comun.UltimoId = pComun.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Comun(int pCedula, string pNombre, string pDireccion, int pTelefono, string pEmail, DateTime pFechaIngreso)
            : base(pCedula, pNombre, pDireccion, pTelefono, pEmail, pFechaIngreso)
        {
            this.Id = Comun.UltimoId;
        }

        public Comun()
        {

        }
    }
}
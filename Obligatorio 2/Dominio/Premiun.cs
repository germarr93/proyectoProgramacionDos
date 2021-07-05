using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio_2.Dominio
{
    public class Premiun:Socio
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
            Premiun.UltimoId += 1;
            this.Id = Premiun.UltimoId;
        }
        public void DesincrementarId()
        {
            Premiun.UltimoId--;
            this.Id = Premiun.UltimoId;
        }
        public bool ExisteSocioPremiun(Premiun pPremiun)
        {
            if (pPremiun != null)
            {
                Premiun.UltimoId = pPremiun.Id;
                return true;
            }
            else
            {
                return false;
            }
        }
        public Premiun(int pCedula, string pNombre, string pDireccion, int pTelefono, string pEmail, DateTime pFechaIngreso)
            : base(pCedula, pNombre, pDireccion, pTelefono, pEmail, pFechaIngreso)
        {
            this.Id = Premiun.UltimoId;
        }

        public Premiun()
        {

        }

            

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio_2.Dominio;

namespace Obligatorio_2.Persistencia
{
    public class Controladora
    {
        private static Controladora _instancia;

        public static Controladora Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Controladora();
                return _instancia;
            }
        }

        private Controladora()
        {

        }

        #region "ABM Cliente"

        public bool ExisteCliente(short pId)
        {
            return pCliente.Instancia.ExisteCliente(pId);
        }
        public bool AltaCliente(Cliente pClientes)
        {
            return pCliente.Instancia.AltaCliente(pClientes);
     
        }
        public bool BajaCliente(Cliente pClientes)
        {
            return pCliente.Instancia.BajaCliente(pClientes);
        }
        public bool ModificarCliente(Cliente pClientes)
        {
            return  pCliente.Instancia.ModificarCliente(pClientes);
        }
        public List<Cliente> ListaDeClientes()
        {
                return pCliente.Instancia.Listar();
        }


        #endregion

        #region "ABM Socio Comun"
        public bool ExisteComun(short pId)
        {
            return pComun.Instancia.ExisteComun(pId);
        }
        public bool AltaComun(Comun pComunes)
        {
            return pComun.Instancia.AltaSocioComun(pComunes);
        }
        public bool BajaComun(Comun pComunes)
        {
            return pComun.Instancia.BajaSocioComun(pComunes);
        }
        public bool ModificarComun(Comun pComunes)
        {
            return pComun.Instancia.ModificarComun(pComunes);
        }
        public List<Comun> ListaDeSociosComunes()
        {
            return pComun.Instancia.ListarComun();
        }

        #endregion

        #region "ABM Auspiciante"

        public bool ExisteAuspiciante(short pId)
        {
            return pAupiciante.Instancia.ExisteAuspiciante(pId);
        }
        public bool AltaAuspiciante(Auspiciante pAuspiciantes)
        {
            return pAupiciante.Instancia.AltaAuspiciante(pAuspiciantes);
        }

        public bool BajaAuspiciante(Auspiciante pAuspiciantes)
        {
            return pAupiciante.Instancia.BajaAuspiciante(pAuspiciantes);
        }

        public bool ModificarAuspiciante(Auspiciante pAuspiciantes)
        {
            return pAupiciante.Instancia.ModificarAuspiciante(pAuspiciantes);
        }
        public List<Auspiciante> ListarAuspiciante()
        {
            return pAupiciante.Instancia.ListarAuspiciantes();
        }

        #endregion

        #region ABM SOCIO PREMIUN
        public bool ExistePremiun(short pId)
        {
            return pPremiun.Instancia.ExistePremiun(pId);
        }

        public bool AltaPremiun(Premiun pPremiuns)
        {
            return pPremiun.Instancia.AltaSocioPremium(pPremiuns);
        }
        public bool BajaPremiun(Premiun pPremiuns)
        {
            return pPremiun.Instancia.BajaSocioPremiun(pPremiuns);

        }
        public bool ModificarPremium(Premiun pPremuns)
        {
            return pPremiun.Instancia.ModificarPremiun(pPremuns);
        }
        public List<Premiun> ListadeSociosPremiun()
        {
            return pPremiun.Instancia.Listar();
        }


        #endregion 

    }
}
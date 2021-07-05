using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio_2.Persistencia;

namespace Obligatorio_2.Dominio
{
    public class Empresa
    {

        #region "Listas"
        private static List<Comun> _ListaSociosComunes = new List<Comun>();

        public List<Comun> ListaDeSociosComunes()
        {
            return _ListaSociosComunes;
        }

        private static List<Premiun> _ListaSociosPremiun = new List<Premiun>();

        public List<Premiun> ListaDeSociosPremiuns()
        {
            return _ListaSociosPremiun;
        }

        public static List<Cliente> _ListaClientes = new List<Cliente>();

        public List<Cliente> ListaClientes()
        {
            return _ListaClientes;
        }

        private static List<Auspiciante> _ListaAuspiciantes = new List<Auspiciante>();

        public List<Auspiciante> ListaDeAuspiciantes()
        {
            return _ListaAuspiciantes;
        }

        private static List<Sala> _ListaSalas = new List<Sala>();

        public List<Sala> ListaDeSalas()
        {
            return _ListaSalas;
        }

        private static List<Sector> _ListaSectores = new List<Sector>();

        public List<Sector> ListaDeSectores()
        {
            return _ListaSectores;
        }

        private static List<Espectaculo> _ListaEspectaculo = new List<Espectaculo>();

        public List<Espectaculo> ListaDeEspectaculo()
        {
            return _ListaEspectaculo;
        }

        private static List<Venta> _ListaVenta = new List<Venta>();

        public List<Venta> ListaDeVentas()
        {
            return _ListaVenta;
        }

        private static List<Cartelera> _ListaCartelera = new List<Cartelera>();

        public List<Cartelera> ListaCartelera()
        {
            return _ListaCartelera;
        }
        #endregion

        #region "ABM BUSCAR SOCIO COMUN"
        public Comun BuscarSocioComun(short pId)
        {
            foreach (Comun unComun in _ListaSociosComunes)
            {
                if (unComun.Id == pId)
                {
                    return unComun;
                }
            }
            return null;
        }
        public Comun BuscarSocioComunAlta(int pCedula)
        {
            foreach (Comun unComun in _ListaSociosComunes)
            {
                if (unComun.Cedula == pCedula)
                {
                    return unComun;
                }
            }
            return null;
        }


        public bool AltaSocioComun(Comun pComun)
        {
            Dominio.Cliente unCliente = this.BuscarClienteAlta(pComun.Cedula);
            if (unCliente == null)
            {

                Dominio.Premiun unPremiun = this.BuscarSocioPremiunAlta(pComun.Cedula);
                if (unPremiun == null)
                {

                    Dominio.Comun unComun = this.BuscarSocioComunAlta(pComun.Cedula);
                    if (unComun == null)
                    {
                        if (Controladora.Instancia.AltaComun(pComun))
                        {

                            _ListaSociosComunes.Add(pComun);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool BajaSocioComun(short pId)
        {
            Dominio.Comun unComun = this.BuscarSocioComun(pId);
            if (unComun != null)
            {
                if (Controladora.Instancia.BajaComun(unComun))
                {
                    _ListaSociosComunes.Remove(unComun);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ModificarSocioComun(short pId,int pCedula, string pNombre, string pDireccion, int pTelefono, string pEmail, DateTime pFecha)
        {
            Dominio.Comun unComun = this.BuscarSocioComun(pId);
            if (unComun != null)
            {
                
                unComun.Cedula = pCedula;
                unComun.Nombre = pNombre;
                unComun.Direccion = pDireccion;
                unComun.Telefono = pTelefono;
                unComun.Email = pEmail;
                unComun.FechaIngreso = pFecha;
                Controladora.Instancia.ModificarComun(unComun);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region "ABM BUSCAR SOCIO PREMIUN"

        public Premiun BuscarSocioPremiun(short pId)
        {
            foreach (Premiun unPremiun in _ListaSociosPremiun)
            {
                if (unPremiun.Id == pId)
                {
                    return unPremiun;
                }
            }
            return null;
        }

        public Premiun BuscarSocioPremiunAlta(int pCedula)
        {
            foreach (Premiun unPremiun in _ListaSociosPremiun)
            {
                if (unPremiun.Cedula == pCedula)
                {

                    return unPremiun;
                }

            }
            return null;
        }

            
            
    

        public bool AltaSocioPremiun(Premiun pPremiun)
        {
            Dominio.Cliente unCliente = this.BuscarClienteAlta(pPremiun.Cedula);
            if (unCliente == null)
            {
                Dominio.Comun unComun = this.BuscarSocioComunAlta(pPremiun.Cedula);
                if (unComun == null)
                {
                    Dominio.Premiun unPremiun = this.BuscarSocioPremiunAlta(pPremiun.Cedula);
                    if (unPremiun == null)
                    {
                        if (Controladora.Instancia.AltaPremiun(pPremiun))
                        {
                            _ListaSociosPremiun.Add(pPremiun);
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;

                }
            }
            else
            {
                return false;
            }
        }

        public bool BajaSocioPremiun(short pId)
        {
            Dominio.Premiun unPremiun = this.BuscarSocioPremiun(pId);
            if (unPremiun != null)
            {
                if (Controladora.Instancia.BajaPremiun(unPremiun))
                {
                    _ListaSociosPremiun.Remove(unPremiun);
                    return true;
                }
                else
                {
                    return false;
                }


            }
            else
            {
                return false;
            }
        }

        public bool ModificarSocioPremiun(short pId, int pCedula, string pNombre, string pDireccion, int pTelefono, string pEmail, DateTime pFecha)
        {
            Dominio.Premiun unPremiun = this.BuscarSocioPremiun(pId);
            if (unPremiun != null)
            {
                unPremiun.Cedula = pCedula;
                unPremiun.Nombre = pNombre;
                unPremiun.Direccion = pDireccion;
                unPremiun.Telefono = pTelefono;
                unPremiun.Email = pEmail;
                unPremiun.FechaIngreso = pFecha;
                Controladora.Instancia.ModificarPremium(unPremiun);
                return true;
            }
            else
            {
                return false;
            }
            

        }
        #endregion

        #region "ABM BUSCAR Cliente"

        public Cliente BuscarClienteAlta(int pCedula)
        {
            foreach (Cliente unCliente in _ListaClientes)
            {
                    if (unCliente.Cedula == pCedula)
                    {

                        return unCliente;
                    }
                

            }
            return null;
        }
        public Cliente BuscarCliente(short pId)
        {
            foreach (Cliente unCliente in _ListaClientes)
            {
                if (unCliente.IdCliente == pId)
                {
                    return unCliente;
                }
            }
            return null;
        }


        public bool AltaCliente(Cliente pCliente)
        {
            Dominio.Comun unComun = this.BuscarSocioComunAlta(pCliente.Cedula);
            if (unComun == null)
            {
                Dominio.Premiun unPremiun = this.BuscarSocioPremiunAlta(pCliente.Cedula);
                if (unPremiun == null)
                {
                    Dominio.Cliente unCliente = this.BuscarClienteAlta(pCliente.Cedula);

                    if (unCliente == null)
                    {
                        
                       if (Controladora.Instancia.AltaCliente(pCliente))
                       {

                            _ListaClientes.Add(pCliente);
                            return true;

                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool BajaCliente(short pId)
        {
            Dominio.Cliente unCliente = this.BuscarCliente(pId);
            if (unCliente != null)
            {
                if (Controladora.Instancia.BajaCliente(unCliente))
                {
                    _ListaClientes.Remove(unCliente);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ModificarCliente(short pId, string pNombre, int pTelefono, int pCedula)
        {
            Dominio.Cliente unCliente = this.BuscarCliente(pId);
            if (unCliente != null)
            {
                unCliente.Nombre = pNombre;
                unCliente.Telefono = pTelefono;
                unCliente.Cedula = pCedula;
                Controladora.Instancia.ModificarCliente(unCliente);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region "ABM BUSCAR Auspiciante"

        public Auspiciante BuscarAuspiciantesAlta(int pRut)
        {
            foreach (Auspiciante unAuspiciante in _ListaAuspiciantes)
            {
                if (unAuspiciante.Rut == pRut)
                {
                    return unAuspiciante;
                }
            }
            return null;
        }

        public Auspiciante BuscarAuspiciante(short pId)
        {
            foreach (Auspiciante unAuspiciante in _ListaAuspiciantes)
            {
                if (unAuspiciante.Id == pId)
                {
                    return unAuspiciante;
                }
            }
            return null;
        }

        public bool AltaAuspiciante(Auspiciante pAuspiciante)
        {
            Dominio.Auspiciante unAuspiciante = this.BuscarAuspiciantesAlta(pAuspiciante.Rut);
            if (unAuspiciante == null)
            {
                if (Controladora.Instancia.AltaAuspiciante(pAuspiciante))
                {
                    _ListaAuspiciantes.Add(pAuspiciante);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool BajaAuspiciante(short pId)
        {
            Dominio.Auspiciante unAuspiciante = this.BuscarAuspiciante(pId);
            if (unAuspiciante != null)
            {
                if (Controladora.Instancia.BajaAuspiciante(unAuspiciante))
                {
                    _ListaAuspiciantes.Remove(unAuspiciante);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ModificarAuspiciante(short pId, int pRut, string pNombre, string pDireccion)
        {
            Dominio.Auspiciante unAuspiciante = this.BuscarAuspiciante(pId);

            if (unAuspiciante != null)
            {
                unAuspiciante.Rut = pRut;
                unAuspiciante.NombreEmpresa = pNombre;
                unAuspiciante.Direccion = pDireccion;
             //   Controladora.Instancia.ModificarAuspiciante(unAuspiciante);
                return true;
            }
            else
            {
                return false;
            }
        }
        

        #endregion

        #region "ABM BUSCAR SALA"

        public Sala BuscarSalaAlta(string pNombre, string pDireccion, int pTelefono)
        {
            foreach (Sala unaSala in _ListaSalas)
            {
                if (unaSala.Nombre == pNombre || unaSala.Direccion == pDireccion || unaSala.Telefono == pTelefono)
                {
                    return unaSala;
                }
            }
            return null;
        }

        public Sala BuscarSala(short pId)
        {
            foreach (Sala unaSala in _ListaSalas)
            {
                if (unaSala.Id == pId)
                {
                    return unaSala;
                }
            }
            return null;
        }

        public bool AltaSala(Sala pSala)
        {
            Dominio.Sala unaSala = this.BuscarSalaAlta(pSala.Nombre, pSala.Direccion, pSala.Telefono);
            if (unaSala == null)
            {
               
                    _ListaSalas.Add(pSala);
                    return true;
               

            }
            else
            {
                return false;
            }
        }

        public bool BajaSala(short pId)
        {
            Dominio.Sala unaSala = this.BuscarSala(pId);
            if (unaSala != null)
            {
                
                    _ListaSalas.Remove(unaSala);
                    return true;
                
 
            }
            else
            {
                return false;
            }
        }

        public bool ModificarSala(short pId, string pNombre, string pDireccion, int pTelefono)
        {
            Dominio.Sala unaSala = this.BuscarSala(pId);
            if (unaSala != null)
            {
                unaSala.Nombre = pNombre;
                unaSala.Direccion = pDireccion;
                unaSala.Telefono = pTelefono;
                return true;
            }
            else
            {
                return false;
            }
        }














        #endregion

        #region "ABM BUSCAR SECTOR"

        public Sector BuscarSectoresNombre(string pNombre)
        {
            foreach (Sector unSector in _ListaSectores)
            {
                if (unSector.Nombre == pNombre)
                {
                    return unSector;
                }
            }
            return null;
        }

        public Sector BuscarSectores(int pId)
        {
            foreach (Sector unSector in _ListaSectores)
            {
                if (unSector.Id == pId)
                {
                    return unSector;
                }
            }
            return null;
        }


        public bool AltaSector(Sector pSector)
        {
            Dominio.Sector unSector = this.BuscarSectoresNombre(pSector.Nombre);
            if (unSector == null)
            {
                if (pSector.CantidadAsientos >= 4 && pSector.CantidadAsientos <= 200 && pSector.CantidadAsientos %2 == 0)
                {
                    
                    _ListaSectores.Add(pSector);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool BajaSector(short pId)
        {
            Dominio.Sector unSector = this.BuscarSectores(pId);
            if (unSector != null)
            {
                _ListaSectores.Remove(unSector);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarSector(short pId, string pNombre, int pCantidad)
        {
            Dominio.Sector unSector = this.BuscarSectores(pId);
            if (unSector != null)
            {
                unSector.Nombre = pNombre;
                unSector.CantidadAsientos = pCantidad;
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

        #region "Alta Baja Secto a Sala"

        public bool AltaSectoresSala(Sala pSala, Sector pSector)
        {
            Dominio.Sala unaSala = this.BuscarSala(pSala.Id);
            if (unaSala != null)
            {
                unaSala.AsignarSectorSala(pSector);
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool BajaSectoresSala(Sala pSala, Sector pSector)
        {
            Dominio.Sala unaSala = this.BuscarSala(pSala.Id);

            if (unaSala != null)
            {
                unaSala.RemoverSectorSala(pSector);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region "ABM BUSCAR Espectaculo"

        public Espectaculo BuscarEspectaculoAlta(string pNombre)
        {
            foreach (Espectaculo unEspectaculo in _ListaEspectaculo)
            {
                if (unEspectaculo.Nombre == pNombre)
                {
                    return unEspectaculo;
                }
            }
            return null;
        }

        public Espectaculo BuscarEspectaculo(short pId)
        {
            foreach (Espectaculo unEspectaculo in _ListaEspectaculo)
            {
                if (unEspectaculo.Id == pId)
                {
                    return unEspectaculo;
                }
            }
            return null;
        }


        public bool AltaEspectaculo(Espectaculo pEspectaculo)
        {
            Dominio.Espectaculo unEspectaculo = this.BuscarEspectaculoAlta(pEspectaculo.Nombre);
            if (unEspectaculo == null)
            {
              
                    _ListaEspectaculo.Add(pEspectaculo);
                    return true;
                

            }
            else
            {
                return false;
            }
        }

        public bool BajaEspectaculo(short pId)
        {
            Dominio.Espectaculo unEspectaculo = this.BuscarEspectaculo(pId);
            if (unEspectaculo != null)
            {
                _ListaEspectaculo.Remove(unEspectaculo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarEspectaculo(short pId,string pNombre, int pPrecio, string pTipo)
        {
            Dominio.Espectaculo unEspectaculo = this.BuscarEspectaculo(pId);
            if (unEspectaculo != null)
            {
                unEspectaculo.Nombre = pNombre;
                unEspectaculo.Precio = pPrecio;
                unEspectaculo.Tipo = pTipo;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region "Alta Baja Auspiciante a Espectaculo";

        public bool AsignarAuspicianteEspectaculo(Espectaculo pEspectaculo, Auspiciante pAuspiciante)
        {
            Dominio.Espectaculo unEspectaculo = this.BuscarEspectaculo(pEspectaculo.Id);
            if (unEspectaculo != null)
            {
                unEspectaculo.AsignarAuspiciante(pAuspiciante);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoverAuspicianteEspectaculo(Espectaculo pEspectaculo, Auspiciante pAuspiciante)
        {
            Dominio.Espectaculo unEspectaculo = this.BuscarEspectaculo(pEspectaculo.Id);
            if (unEspectaculo != null)
            {
                unEspectaculo.RemoverAuspiciante(pAuspiciante);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region "ABM BUSCAR VENTA"
        public Venta BuscarVenta(short pId)
        {
            foreach (Venta unaVenta in _ListaVenta)
            {
                if (unaVenta.Id == pId)
                {
                    return unaVenta;
                }
            }
            return null;
        }

        public bool AltaVenta(Venta pVenta)
        {
            Dominio.Venta unaVenta = this.BuscarVenta(pVenta.Id);
            if (unaVenta == null)
            {
                _ListaVenta.Add(pVenta);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BajaVenta(short pId)
        {
            Dominio.Venta unaVenta = this.BuscarVenta(pId);
            if (unaVenta != null)
            {
                _ListaVenta.Remove(unaVenta);
                return true;
            }
            else
            {

                return false;
            }
        }

        #endregion

        #region "ABM BUSCAR Cartelera"

        public Cartelera BuscarCartelera(short pId)
        {
            foreach (Cartelera unaCartelera in _ListaCartelera)
            {
                if (unaCartelera.Id == pId)
                {
                    return unaCartelera;
                }
            }
            return null;
        }
        public Cartelera BuscarCarteleraAlta(Cartelera pCartelera)
        {
            foreach (Cartelera unaCartelera in _ListaCartelera)
            {
                if (unaCartelera.Espectaculo.Nombre == pCartelera.Espectaculo.Nombre && unaCartelera.FechaComienzo == pCartelera.FechaComienzo)
                {
                    return unaCartelera;
                }
            }
            return null;
        }


        public bool AltaCartelera(Cartelera pCartelera)
        {
            Dominio.Cartelera unaCartelera = this.BuscarCarteleraAlta(pCartelera);
            if (unaCartelera == null)
            {
                _ListaCartelera.Add(pCartelera);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BajaCartelera(short pId)
        {
            Dominio.Cartelera unaCartelera = this.BuscarCartelera(pId);
            if (unaCartelera != null)
            {
                _ListaCartelera.Remove(unaCartelera);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region "Consultas"

        public List<Premiun> ListaOrdenadaSocioPremiun()
        {
            List<Premiun> ListaSociosPremiunOrdenadaNombre = new List<Premiun>(_ListaSociosPremiun);

            Premiun AuxPremiun;

            for (int i = 0; i < ListaSociosPremiunOrdenadaNombre.Count; i++)
            {
                for (var j = 0; j < ListaSociosPremiunOrdenadaNombre.Count - 1; j++)
                {
                    if (ListaSociosPremiunOrdenadaNombre[j].Nombre.ToUpper().CompareTo(ListaSociosPremiunOrdenadaNombre[j + 1].Nombre.ToUpper()) > 0)
                    {
                        AuxPremiun = ListaSociosPremiunOrdenadaNombre[j];
                        ListaSociosPremiunOrdenadaNombre[j] = ListaSociosPremiunOrdenadaNombre[j + 1];
                        ListaSociosPremiunOrdenadaNombre[j + 1] = AuxPremiun;
                    }
                }
            }
            return ListaSociosPremiunOrdenadaNombre;
        }

       public List<string> ListaSalasTicketVendidos(DateTime pFecha)
        {
            List<string> ListaSalas = new List<string>();
            int Contador=0;
            foreach (Venta unaVenta in _ListaVenta)
            {
                if (unaVenta.Fecha == pFecha)
                {
                    foreach (Sector unSector in unaVenta.Espectaculo.Sala.ListaSectoresEnSala())
                    {
                        for (int i = 0; i < unSector.Matriz.GetLength(0); i++)
                        {
                            for (int j = 0; j < unSector.Matriz.GetLength(1); j++)
                            {
                                if (unSector.Matriz[i, j] == "O")
                                {
                                    Contador++;
                                }
                            }

                        }
                    }
                    int cantidad = Contador;
                    Contador = 0;
                    string sala = unaVenta.Espectaculo.Sala.Nombre + " " + cantidad;
                    if(!ListaSalas.Exists(x => x == sala))
                    {
                        ListaSalas.Add(unaVenta.Espectaculo.Sala.Nombre + " " + cantidad);

                    }
                }

            }
            
            return ListaSalas;
        }
      

        public List<Espectaculo> ListaDeEspectaculosDadoUnaSala(string pNombre)
        {
            List<Espectaculo> ListaDeEspectaculos = new List<Espectaculo>();
            List<Cartelera> ListaCartelera = new List<Cartelera>();

            foreach (Cartelera unaCartelera in _ListaCartelera)
            {
                if (unaCartelera.Espectaculo.Sala.Nombre == pNombre)
                {
                    ListaDeEspectaculos.Add(unaCartelera.Espectaculo);
                }
            }

            Espectaculo AuxEspectaculo;
            for (int i = 0; i < ListaDeEspectaculos.Count; i++)
            {
                for (int j = 0; j < ListaDeEspectaculos.Count -1; j++)
                {
                    if (ListaDeEspectaculos[j].Cartelera.FechaComienzo.CompareTo(ListaDeEspectaculos[j + 1].Cartelera.FechaComienzo) > 1)
                    {
                        AuxEspectaculo = ListaDeEspectaculos[j];
                        ListaDeEspectaculos[j] = ListaDeEspectaculos[j + 1];
                        ListaDeEspectaculos[j + 1] = AuxEspectaculo;
                    }
                }
            }
            return ListaDeEspectaculos;
            
        }

        #endregion

        #region "Reservar Asiento Venta"
        public bool ReservarAsiento(Sector pSector,int pFila, int pLugar)
        {
            int fila = pFila -1;
            int asientoReservar = pLugar -1;
            // metodo Getleng() el 0 para las filas y el 1 para las columnas
            if (fila < pSector.Matriz.GetLength(0) && asientoReservar < pSector.Matriz.GetLength(1))
            {

                if (pSector.Matriz[fila, asientoReservar] != null)
                {
                    if (pSector.Matriz[fila, asientoReservar] == "V")
                    {
                        pSector.Matriz[fila, asientoReservar] = "O";
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }
        #endregion

        public Empresa()
        {
            _ListaClientes = Controladora.Instancia.ListaDeClientes();
            if (_ListaClientes.Count > 0)
            {
                Cliente unCliente = _ListaClientes.Last();
                unCliente.ExisteCliente(unCliente);
            }
            _ListaSociosComunes = Controladora.Instancia.ListaDeSociosComunes();
            if (_ListaSociosComunes.Count > 0)
            {
                Comun unComun = _ListaSociosComunes.Last();
                unComun.ExisteSocioComun(unComun);
            }
            _ListaSociosPremiun = Controladora.Instancia.ListadeSociosPremiun();
            if (_ListaSociosPremiun.Count > 0)
            {
                Dominio.Premiun unPremiun = _ListaSociosPremiun.Last();
                unPremiun.ExisteSocioPremiun(unPremiun);
            }
            _ListaAuspiciantes = Controladora.Instancia.ListarAuspiciante();
            if (_ListaAuspiciantes.Count > 0)
            {
                Dominio.Auspiciante unAuspiciante = _ListaAuspiciantes.Last();
                unAuspiciante.ComprobarSiExiste(unAuspiciante);
            }
        }
     
    }
}
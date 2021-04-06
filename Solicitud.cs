using System;
using System.Collections.Generic;
using System.Text;

namespace A133590.Ejercicio55
{
    enum Zona
    {
        SinZona = -1,
        Centro,
        Norte,
        Sur,
        Oeste
    }
    class Solicitud
    {
        int nroSolicitud;
        string nombreCliente;
        

        Zona zonaSolicitud;

        public Solicitud(int nroSolicitud, string nombreCliente, Zona zonaSolicitud)
        {
            this.nroSolicitud = nroSolicitud;
            this.nombreCliente = nombreCliente;
            this.zonaSolicitud = zonaSolicitud;
        }

        public int NroSolicitud { get => nroSolicitud; }
        public string NombreCliente { get => nombreCliente; }
        internal Zona ZonaSolicitud { get => zonaSolicitud; }
    }
}

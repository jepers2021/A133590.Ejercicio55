using System;
using System.Collections.Generic;
using System.Text;

namespace A133590.Ejercicio55
{
    class Tecnico
    {
        int idTecnico;
        List<Solicitud> solicitudes;
        Zona zona;

        public Tecnico(int idTecnico)
        {
            this.idTecnico = idTecnico;
            solicitudes = new List<Solicitud>();
            zona = Zona.SinZona;
        }

        public int IdTecnico { get => idTecnico; }
        public List<Solicitud> Solicitudes { get => solicitudes; }
        public Zona ZonaSolicitud { get => zona; }

        public bool AsignarSolicitud(Solicitud solicitud)
        {
            if(solicitudes.Count == 4)
            {
                Console.WriteLine($"Técnico {idTecnico} no disponible. Razón: Técnico con 4 solicitudes.");
                return false;
            }

            if(zona == Zona.SinZona)
            {
                zona = solicitud.ZonaSolicitud;
            }
            else
            {
                if(zona != solicitud.ZonaSolicitud)
                {
                    Console.WriteLine($"Técnico {idTecnico} no disponible. Razón: Solicitud fuera de zona de trabajo.");
                    return false;
                }    
            }

            solicitudes.Add(solicitud);
            Console.WriteLine($"Solicitud correctamente asignada a técnico {idTecnico}.");
            return true;
        }
    }
}

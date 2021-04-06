using System;
using System.Collections.Generic;

namespace A133590.Ejercicio55
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 55");
            Dictionary<string, Tecnico> clientes = new Dictionary<string, Tecnico>();
            Tecnico[] tecnicos = new Tecnico[30];
            do
            {
                Console.Write("Ingrese el número de solicitud: ");
                int nroSolicitud;
                bool exito = Int32.TryParse(Console.ReadLine(), out nroSolicitud);
                while (!exito || nroSolicitud <= 0)
                {
                    Console.WriteLine("Número de solicitud inválido.");
                    Console.Write("Ingrese el número de solicitud: ");
                    exito = Int32.TryParse(Console.ReadLine(), out nroSolicitud);
                }

                Console.Write("Por favor, ingrese el nombre o razón social del cliente: ");
                string nombreCliente = String.Join(" ", Console.ReadLine().Trim().ToLower().Split());
                while(nombreCliente.Length == 0)
                {
                    Console.Write("Nombre vacío, por favor, ingrese el nombre o razón social del cliente: ");
                    nombreCliente = String.Join(" ", Console.ReadLine().Trim().ToLower().Split());
                }

                Console.WriteLine("1) Centro");
                Console.WriteLine("2) Zona Norte");
                Console.WriteLine("3) Zona Sur");
                Console.WriteLine("4) Zona Oeste");
                Console.Write("Ingrese la zona de su solicitud: ");
                int zona;
                exito = Int32.TryParse(Console.ReadLine(), out zona);

                while (!exito || zona < 0 || zona > 3)
                {
                    Console.Write("Zona no válida, ingrese una zona: ");
                    exito = Int32.TryParse(Console.ReadLine(), out zona);
                }
                Solicitud nuevaSolicitud = new Solicitud(nroSolicitud, nombreCliente, (Zona)zona);

                Console.WriteLine("Buscando técnico disponible para su solicitud.");

                if (clientes.ContainsKey(nombreCliente))
                {
                    if (!clientes[nombreCliente].AsignarSolicitud(nuevaSolicitud))
                    {
                        Console.WriteLine("Buscando otro técnico disponible..");
                        for (int i = 0; i < 30; i++)
                        {
                            if (tecnicos[i] == null)
                            {
                                tecnicos[i] = new Tecnico(i + 1);
                            }
                            if (tecnicos[i].AsignarSolicitud(nuevaSolicitud))
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 30; i++)
                    {
                        if (tecnicos[i] == null)
                        {
                            tecnicos[i] = new Tecnico(i + 1);
                        }
                        if (tecnicos[i].AsignarSolicitud(nuevaSolicitud))
                        {
                            break;
                        }
                    }
                }

                Console.Write("¿Desea ingresar otra solicitud? (y/n): ");
                
            } while (Console.ReadLine().Equals("y"));

            Console.Clear();
            Console.WriteLine("Reporte:");
            foreach(Tecnico tecnico in tecnicos)
            {
                if(tecnico != null)
                {
                    Console.WriteLine($"Técnico: {tecnico.IdTecnico}");
                    Console.WriteLine($"Zona: {tecnico.ZonaSolicitud.ToString()}");
                    Console.WriteLine($"Cantidad de solicitudes: {tecnico.Solicitudes.Count}");
                    Console.WriteLine("Clientes:");
                    HashSet<String> aux = new HashSet<string>();
                    foreach(Solicitud solicitud in tecnico.Solicitudes)
                    {
                        aux.Add(solicitud.NombreCliente);
                    }
                    foreach(string nombre in aux)
                    {
                        Console.WriteLine($"    {nombre}");
                    }
                }
            }

        }
        
    }
}

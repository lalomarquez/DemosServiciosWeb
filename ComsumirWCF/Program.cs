using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComsumirWCF.ClienteServiceReference;

namespace ComsumirWCF
{
    class Program
    {        
        static void Main(string[] args)
        {
            Insertar();
            Consultar();
            Modificar();
            Eliminar();

            Console.WriteLine("Teclear para terminar");
            Console.ReadKey();
        }

        static void Insertar()
        {
            var servicio = new ClienteServiceClient();

            Console.WriteLine("INSERCIÓN\n-----------------------------");
            Cliente carlos = new Cliente()
            {
                Nombre = "Carlos Garcia Castaño",
                FechaNacimiento = new DateTime(1980, 2, 2)
            };

            Cliente ana = new Cliente()
            {
                Nombre = "Ana Gonzalez Sierra",
                FechaNacimiento = new DateTime(1981, 2, 22)
            };

            Cliente luis = new Cliente()
            {
                Nombre = "Luis Coria Chamorro",
                FechaNacimiento = new DateTime(1974, 6, 12)
            };

            servicio.InsertarCliente(carlos);
            servicio.InsertarCliente(ana);
            servicio.InsertarCliente(luis);
        }

        static void Consultar()
        {
            var servicio = new ClienteServiceClient();

            Console.WriteLine("CONSULTA\n-----------------------------");
            var resultado = servicio.ObtenerClientes();
            foreach (Cliente c in resultado)
            {
                Console.WriteLine(string.Format("\tID: {0}\tNOMBRE: {1}\t CUMPLEAÑOS: {2}/{3}",
                    c.IdCliente, c.Nombre, c.FechaNacimiento.Day, c.FechaNacimiento.Month));
            }
        }

        static void Modificar()
        {
            var servicio = new ClienteServiceClient();

            Console.WriteLine("MODIFICACIÓN\n-----------------------------");
            var resultado = servicio.ObtenerClientes();

            Cliente clienteModif = resultado.First();
            clienteModif.Nombre = clienteModif.Nombre + " MODIFICADO";
            servicio.ModificarCliente(clienteModif);
            resultado = servicio.ObtenerClientes();
            foreach (Cliente c in resultado)
            {
                Console.WriteLine(string.Format("\tID: {0}\tNOMBRE: {1}\t CUMPLEAÑOS: {2}/{3}",
                    c.IdCliente, c.Nombre, c.FechaNacimiento.Day, c.FechaNacimiento.Month));
            }
        }

        static void Eliminar()
        {
            var servicio = new ClienteServiceClient();

            Console.WriteLine("ELIMINACIÓN\n-----------------------------");
            var resultado = servicio.ObtenerClientes();

            Cliente clienteEliminar = resultado.Skip(1).First();
            servicio.EliminarCliente(clienteEliminar.IdCliente);
            resultado = servicio.ObtenerClientes();
            foreach (Cliente c in resultado)
            {
                Console.WriteLine(string.Format("\tID: {0}\tNOMBRE: {1}\t CUMPLEAÑOS: {2}/{3}",
                    c.IdCliente, c.Nombre, c.FechaNacimiento.Day, c.FechaNacimiento.Month));
            }
        }
    }
}

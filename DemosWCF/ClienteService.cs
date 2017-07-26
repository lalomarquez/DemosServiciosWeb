using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DemosWCF
{
    /*
      * 3. Contrato de Servicio (ServiceContract)
    */

    /*
     * Contando con datos y operaciones se codifica una clase que implemente la interfaz que define el 
     * contrato de servicio con sus correspondientes operaciones.
     * asignaremos el atributo [ServiceBehavior] a la clase
     */

    [ServiceBehavior]
    class ClienteService : IClienteService
    {
        private static List<Cliente> listaClientes = new List<Cliente>();
        private string resultado = string.Empty;

        public string EliminarCliente(int id)
        {
            try
            {
                // Recuperamos el cliente cuyo ID coincide con el pasado como parámetro
                Cliente clienteEliminar = listaClientes.Where(cliente => cliente.IdCliente == id).First();

                // Si el registro existe, se elimina
                if (clienteEliminar != null)
                {
                    listaClientes.Remove(clienteEliminar);
                    resultado = "Eliminado Correctamente!!";
                }
            }
            catch (Exception ex)
            {

                resultado = "Exception: {0}" + ex.ToString();
            }
            return resultado;
        }

        public string InsertarCliente(Cliente c)
        {
            try
            {
                // Calculamos el ID del siguiente elemento
                if (listaClientes.Count == 0)
                    c.IdCliente = 1;
                else
                    c.IdCliente = listaClientes.Max(cliente => cliente.IdCliente) + 1;

                // Añadimos el cliente a la lista
                listaClientes.Add(c);

                resultado = "Registro dado de alta!!";
            }
            catch (Exception ex)
            {
                resultado = "Exception: {0}" + ex.ToString();
            }
            return resultado;
        }

        public string ModificarCliente(Cliente c)
        {
            try
            {
                // Recuperamos el cliente cuyo ID coincide con el pasado como parámetro
                Cliente clienteModif = listaClientes.Where(cliente => cliente.IdCliente == c.IdCliente).First();

                // Si el registro existe, se modifica
                if (clienteModif != null)
                {
                    clienteModif.Nombre = c.Nombre;
                    clienteModif.FechaNacimiento = c.FechaNacimiento;
                    resultado = "Registro modificado!!";
                }
            }
            catch (Exception ex)
            {
                resultado = "Exception: {0}" + ex.ToString();
            }
            return resultado;
        }

        public List<Cliente> ObtenerClientes()
        {
            return listaClientes;
        }
    }
}

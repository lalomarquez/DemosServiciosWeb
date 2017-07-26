using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DemosWCF
{
    /*
     * 2. Contrato de Servicio (ServiceContract)
     */

    /*
     * Importaremos el namespace System.ServiceModel y adornaremos la interfaz con el atributo [ServiceContract]. 
     * Los métodos con el atributo [OperationContract], ya que establecerán el contrato de las operaciones que el servicio puede realizar.
     */

    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        List<Cliente> ObtenerClientes();

        [OperationContract]
        string InsertarCliente(Cliente c);

        [OperationContract]
        string ModificarCliente(Cliente c);

        [OperationContract]
        string EliminarCliente(int id);
    }
}

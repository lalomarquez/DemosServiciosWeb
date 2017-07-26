using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DemosWCF
{
    /*
     * 1. Contrato de datos (DataContract)
    */

    /*
     * Para que nuestro POCO adquiera la categoría de contrato de datos, es necesario adornar la clase y sus elementos 
     * con un par de atributos heredados de System.Runtime.Serialization. 
     * [DataContract] a la clase. 
     * [DataMember] a cada uno de los elementos de la clase.
     */

    [DataContract]
    public class Cliente
    {
        //POCO (Plain Old CLR Object)

        [DataMember]
        public int IdCliente;

        [DataMember]
        public string Nombre;

        [DataMember]
        public DateTime FechaNacimiento;
    }
}

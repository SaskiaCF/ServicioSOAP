using PreContractSOAP.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PreContractSOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPreContractLog" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPreContractLog
    {
        [OperationContract]
        Task<List<LogContractModel>> List();
        [OperationContract]
        Task<List<PreContractLogDetail>> ListDetails(int log_detail_id, int log_id);
        [OperationContract]
        string SendMessage(string message);
        [OperationContract]
        string[] ReceiveMessage();
    }
}

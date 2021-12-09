using PreContractSOAP.Dominio;
using PreContractSOAP.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PreContractSOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PreContractLog" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PreContractLog.svc o PreContractLog.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PreContractLog : IPreContractLog
    {
        private LogPreContract logPreContract = new LogPreContract();
        public Task<List<LogContractModel>> List()
        {
            try
            {
                return logPreContract.List();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<PreContractLogDetail>> ListDetails(int log_detail_id, int log_id)
        {
            try
            {
                return logPreContract.ListDetails(log_detail_id,log_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string[] ReceiveMessage()
        {
            try
            {
                return logPreContract.ReceiveMessage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SendMessage(string message)
        {
            try
            {
                return logPreContract.SendMessage(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

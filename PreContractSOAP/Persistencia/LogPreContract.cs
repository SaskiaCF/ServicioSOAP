using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PreContractSOAP.Dominio;

namespace PreContractSOAP.Persistencia
{
    public class LogPreContract
    {
        public async Task<List<LogContractModel>> List()
        {
            var _httpClient = new HttpClient();
            var uri = "http://18.218.163.86/precontratos/contracts/logs/search";
            var result = await _httpClient.GetAsync(uri);
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                SendMessage("Se utilizó el método List del Servicio SOAP el día " + DateTime.Now);
                return JsonConvert.DeserializeObject<List<LogContractModel>>(json);
            }
            else
            {
                return null;
            }
        }
        public async Task<List<PreContractLogDetail>> ListDetails(int log_detail_id,int log_id)
        {
            var _httpClient = new HttpClient();
            var uri = "http://18.218.163.86/precontratos/contracts/precontracts/logsDetail/search?log_detail_id="+log_detail_id+"&log_id="+log_id;
            var result = await _httpClient.GetAsync(uri);
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                SendMessage("Se utilizó el método ListDetails del Servicio SOAP el día " + DateTime.Now);
                return JsonConvert.DeserializeObject<List<PreContractLogDetail>>(json);
            }
            else
            {
                return null;
            }
        }

        public string SendMessage(string message)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "hornet-01.rmq.cloudamqp.com",
                    UserName = "rlhxyyce",
                    Password = "Z3B5ZfJqvhoVJLGz-GHnho87xtvPv7nm",
                    VirtualHost = "rlhxyyce"
                };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "SaskiaCF", durable: false, exclusive: false, autoDelete: false, arguments: null);
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish(exchange: "", routingKey: "SaskiaCF", basicProperties: null, body: body);
                    }
                }
                return "Mensaje Enviado";
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string[] ReceiveMessage()
        {
            //BasicGetResult dt;
            int c = 1, x = 0;
            string[] message = new string[10];
            while (c>0)
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "hornet-01.rmq.cloudamqp.com",
                    UserName = "rlhxyyce",
                    Password = "Z3B5ZfJqvhoVJLGz-GHnho87xtvPv7nm",
                    VirtualHost = "rlhxyyce"
                };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "SaskiaCF", durable: false, exclusive: false, autoDelete: false, arguments: null);
                        var data = channel.BasicGet("SaskiaCF", false);
                        if (data != null)
                        {
                            message[x]= Encoding.UTF8.GetString(data.Body.ToArray());
                            x += 1;
                            channel.BasicAck(data.DeliveryTag, false);
                        }
                        else
                        {
                            c = 0;
                        }
                        
                    }
                }
            }
            message = message.Except(new string[] { null }).ToArray();
            return message;
        }
    }
}
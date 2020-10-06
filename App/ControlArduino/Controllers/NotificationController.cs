using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Http;
using DataCube.Server.Communications;
using DataCube.Server.Models;

namespace DataCube.Server.Controllers
{
    public class NotificationController : ApiController
    {
        [HttpGet]
        [Route("api/Notification/Inicialize")]
        public void Initialize()
        {
            SerialCommunication.Inicialize();
        }

        [HttpPost]
        [Route("api/Notification")]
        public void SubmitNotificationColor([FromBody] NotificationViewModel notification)
        {
            Console.WriteLine($"{notification.R} {notification.G} {notification.B}");
            SerialCommunication.Inicialize();
            SerialCommunication.Write($"#SETCR{notification.R}G{notification.G}B{notification.B}#\n");
            SerialCommunication.Close();
        }

        [HttpPost]
        [Route("api/Notification/Rele")]
        public void SubmitNotificationRele([FromBody] NotificationViewModel notification)
        {
            Console.WriteLine($"{notification.Id}");
            SerialCommunication.Inicialize();
            SerialCommunication.Write($"#RELEI{notification.Id}#\n");
            SerialCommunication.Close();
        }

        [HttpPost]
        [Route("api/Notification/Humedad")]
        public string SubmitNotificationHumedad([FromBody] NotificationViewModel notification)
        {
            Console.WriteLine($"{notification.Id}");
            SerialCommunication.Inicialize();
            SerialCommunication.Write($"#HUMEI{notification.Id}#\n");
            var lectura = SerialCommunication.ReadLine();
            SerialCommunication.Close();

            var value = lectura.Substring(0, lectura.Length - 1);
            return value;
        }
    }
    
}

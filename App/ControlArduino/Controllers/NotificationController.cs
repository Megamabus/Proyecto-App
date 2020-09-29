using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
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
        public void SubmitNotification([FromBody] NotificationViewModel notification)
        {
            Console.WriteLine($"{notification.R} {notification.G} {notification.B}");
            SerialCommunication.Inicialize();
            SerialCommunication.Write(new byte[] { notification.R, notification.G,  notification.B });
            SerialCommunication.Close();
        }
    }
}

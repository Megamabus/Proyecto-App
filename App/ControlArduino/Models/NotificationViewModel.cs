using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCube.Server.Models
{
    public class NotificationViewModel
    {
        public string Intruccion { get; set; }
        public int Id { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
    }
}
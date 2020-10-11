using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class tbl_dataViewModel
    {
        public int P_id { get; set; }
        public string P_name { get; set; }
        public string P_DES { get; set; }
        public string P_IMAGE { get; set; }
        public byte[] img { get; set; }
    }
}
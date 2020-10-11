using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class CamaraViewModel
    {
        public string ImgString { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
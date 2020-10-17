using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Models.ViewModels
{
    public class FacturaViewModel
    {
        public int Id { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Compra")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime FechaCompra { get; set; }
    }
}
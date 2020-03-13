﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCCrudNet.Models.ViewModels
{
    public class TablaViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Nombre")]

        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name ="Correo")]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString ="{0:yyyy-mm-dd}",ApplyFormatInEditMode =true )]
        public DateTime Fecha_Nacimiento { get; set; }
        
    }
}
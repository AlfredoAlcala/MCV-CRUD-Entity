using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCcrud.Models.ViewModels
{
    public class TablaViewModel
    {

        public int id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name= "Email Address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name = "Birth Date")]
        public DateTime Fecha_nacimiento { get; set; }

    }
}
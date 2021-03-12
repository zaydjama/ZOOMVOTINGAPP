using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VouterApp.Models
{

    [Table("tblRegion")]
    public class RegionModel
    {
        [Key]
        [Display(Name = "Code")]

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Region")]
        [Display(Name = "Region")]

        public string RegionName { get; set; }
    }
}
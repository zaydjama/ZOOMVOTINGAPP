using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VouterApp.Models
{
    [Table("tblDistrict")]
	public class DistrictModel
	{
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter DistricName")]
        public string DistricName { get; set; }

        public int RegionId { get; set; }
        public RegionModel Region { get; set; }
	}
}
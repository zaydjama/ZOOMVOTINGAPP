using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VouterApp.Models
{
        [Table("tblCandidate")]
    public class CandidateModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter FirstN ame")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Second Name")]
        public string SecondName { get; set; }


        [Required(ErrorMessage = "Please Enter Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Select Region")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Please Select Region")]
        public string District { get; set; }

        [Required(ErrorMessage = "Please Select Party")]
        public string Party { get; set; }

        [Required(ErrorMessage = "Please Enter Election")]
        public string Election { get; set; }
    }
}
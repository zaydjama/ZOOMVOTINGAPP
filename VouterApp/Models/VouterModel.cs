using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VouterApp.Models
{


    [Table("tblVouter")]
    public class VouterModel
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter FirstN ame")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Second Name")]
        public string SecondName { get; set; }


        [Required(ErrorMessage = "Please Enter Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Nation ID")]
        public string NationalID { get; set; }

        [Required(ErrorMessage = "Please Enter Voiting Card Number")]
        public string VoutingCardNo { get; set; }

        [Required(ErrorMessage = "Please Select Region")]
        public string Region { get; set; }


        [Required(ErrorMessage = "Please Select District")]
        public string District { get; set; }

        [Required(ErrorMessage = "Please Select Center")]
        public string Center { get; set; }

        [Required(ErrorMessage = "Please Enter Family")]
        public string DontatingFamily { get; set; }

        public int userid { get; set; }
        public UserModel User { get; set; }
    }
}
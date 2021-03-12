using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VouterApp.Models
{
     [Table("tblUser")]
    public class UserModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter UserName")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Paswd { get; set; }

        [Required(ErrorMessage = "Please Select Role")]
        public string Roles { get; set; }

        public int Candidateid { get; set; }
        public CandidateModel Candidate { get; set; }
    }
}
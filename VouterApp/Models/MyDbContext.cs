using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VouterApp.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<RegionModel> tblRegion { get; set; } // My domain models
        public DbSet<DistrictModel> tblDistrict { get; set; } // My domain models
        public DbSet<CandidateModel> tblCandidate { get; set; } // My domain models
        public DbSet<UserModel> tblUser { get; set; } // My domain models
        public DbSet<VouterModel> tblVouter { get; set; } // My domain models


        
    }
}
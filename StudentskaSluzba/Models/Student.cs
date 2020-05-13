using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentskaSluzba.Models
{
    public class Student
    {
        [Key]
        public int BI { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }

        public virtual ICollection<Ispit> Ispiti { get; set; }
    }
}
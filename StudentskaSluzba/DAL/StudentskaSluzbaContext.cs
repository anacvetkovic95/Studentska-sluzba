using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace StudentskaSluzba.DAL
{
    public class StudentskaSluzbaContext : DbContext
    {
        public StudentskaSluzbaContext() : base("StudentskaSluzbaContext")
        {
        }
        public DbSet<Predmet> Predmets { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Ispit> Ispits { get; set; }
        
        //Ovim ingorisemo s koje entity dodaje kad napravi bazu 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
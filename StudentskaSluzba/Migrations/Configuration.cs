namespace StudentskaSluzba.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentskaSluzba.DAL.StudentskaSluzbaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentskaSluzba.DAL.StudentskaSluzbaContext context)
        {
            var predmeti = new List<Predmet>
            {
            new Predmet{NazivPredmeta="Matematika 1"},
            new Predmet{NazivPredmeta="Matematika 2"},
            new Predmet{NazivPredmeta="Ekonomija"},
            new Predmet{NazivPredmeta="Projektovanje softvera"},
            new Predmet{NazivPredmeta="Internet marketing"}
            };

            predmeti.ForEach(p => context.Predmets.Add(p));
            context.SaveChanges();

            var studenti = new List<Student>
            {
            new Student{Ime="Tamara",Prezime="Rakovic",Adresa="Dzona Kenedija 20",Grad="Beograd"},
            new Student{Ime="Ilija",Prezime="Rakovic",Adresa="Goce Delceva 23",Grad="Beograd"},
            new Student{Ime="Ivan",Prezime="Jovkovic",Adresa="Novosadskog Sajma 23",Grad="Novi Sad"},
            new Student{Ime="Aleksandra",Prezime="Jovkovic",Adresa="Smederevska 15",Grad="Kragujevac"}

            };

            studenti.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var ispiti = new List<Ispit>
            {
            new Ispit{BI=1,PredmetId=1,Ocena=8},
            new Ispit{BI=1,PredmetId=3,Ocena=10},
            new Ispit{BI=1,PredmetId=4,Ocena=10},
            new Ispit{BI=3,PredmetId=1,Ocena=7},
            new Ispit{BI=3,PredmetId=4,Ocena=10},
            new Ispit{BI=2,PredmetId=1,Ocena=10},
            new Ispit{BI=4,PredmetId=3,Ocena=8}
            };

            ispiti.ForEach(i => context.Ispits.Add(i));
            context.SaveChanges();
        }
    }
}

using StudentskaSluzba.Models;
using System.Collections.Generic;

namespace MVCNestedWebgrid.ViewModel
{
    public class StudentVM
    {
        public Student Student { get; set; }
        public List<Ispit> ListaIspita { get; set; }
    }
}
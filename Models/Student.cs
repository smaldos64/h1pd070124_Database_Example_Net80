using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Database_Example_Net80.Models
{
    public class Student 
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; } = "";
        public string StudentLastName { get; set; } = "";
        public int TeamID { get; set; }
        public virtual Team Team { get; set; } 
        public virtual List<Course> Courses { get; set; }
    }
}

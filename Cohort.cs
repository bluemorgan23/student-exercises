using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Cohort
    {
        public Cohort(string name) {
            Name = name;
        }
        public string Name {get; set;}
        public List<Student> ListOfStudents {get; set;} = new List<Student>();
        public List<Instructor> ListOfInstructors {get; set;} = new List<Instructor>();
    }
}
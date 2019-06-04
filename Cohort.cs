using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Cohort
    {
        public Cohort(string name, int id) {
            Name = name;
            Id = id;
        }
        public int Id { get; set; }
        public string Name {get; set;}
        public List<Student> ListOfStudents {get; set;} = new List<Student>();
        public List<Instructor> ListOfInstructors {get; set;} = new List<Instructor>();
    }
}
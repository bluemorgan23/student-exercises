using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Student {
        public Student(string firstName, string lastName) {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Slack {get; set;}
        public Cohort Cohort {get; set;}
        public List<Exercise> ExerciseList = new List<Exercise>();
    }
}
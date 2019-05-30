using System;

namespace student_exercises
{
    class Instructor
    {
        public Instructor(string firstName, string lastName, string specialty)
        {
            FirstName = firstName;
            LastName = lastName;
            Specialty = specialty;
        }
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Specialty {get; set;}
        public string Slack {get; set;}
        public Cohort Cohort {get; set;}
        public void assignExercise(Student student, Exercise exercise)
        {
            student.ExerciseList.Add(exercise);
        }
    }
}
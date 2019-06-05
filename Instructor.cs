using System;

namespace student_exercises
{
    public class Instructor : NSSPerson
    {
        public Instructor(string firstName, string lastName, string specialty, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Specialty = specialty;
            Id = id;
        }
        public int Id { get; set; }
        
        public string Specialty {get; set;}
      
        public void AssignExercise(Student student, Exercise exercise)
        {
            student.ExerciseList.Add(exercise);
            exercise.ListOfStudents.Add(student);
        }
    }
}
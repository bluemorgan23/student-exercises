using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Student {
        public Student(string firstName, string lastName, int id) {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Slack { get; set; }
        public Cohort Cohort { get; set; }
        public List<Exercise> ExerciseList {get; set;} = new List<Exercise>();

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public void GetNameAndExercises(Student student)
        {
            Console.WriteLine($"Exercise list for {student.GetFullName()}:");
            Console.WriteLine(" ");
            foreach(Exercise exercise in student.ExerciseList)
            {
                Console.WriteLine($"Exercise Name: {exercise.Name}");
                Console.WriteLine($"Language: {exercise.Language}");
                Console.WriteLine(" ");
            }
        }
    }
}
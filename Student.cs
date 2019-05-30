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

        public string getFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public void getNameAndExercises(Student student)
        {
            Console.WriteLine($"Exercise list for {student.getFullName()}:");
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
using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Exercise
    {
        public Exercise(string name, string language, int id)
        {
            Name = name;
            Language = language;
            Id = id;
        }
        public int Id { get; set; }
        public string Name {get; set;}
        public string Language {get; set;}
        public List<Student> ListOfStudents {get; set;} = new List<Student>();

        public void ListStudentsOnExercise(List<Student> students)
        {
            
            Console.WriteLine($"Students working on {this.Name}: ");

            foreach(Student student in students)
            {
                foreach(Exercise exercise in student.ExerciseList)
                {
                    if(exercise.Equals(this))
                    {
                        ListOfStudents.Add(student);
                        Console.WriteLine(student.GetFullName());
                    }
                }
                
            }
        }
    }
}

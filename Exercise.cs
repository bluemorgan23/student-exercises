using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Exercise
    {
        public Exercise(string name, string language)
        {
            Name = name;
            Language = language;
        }
        public string Name {get; set;}
        public string Language {get; set;}
        public List<Student> ListOfStudents = new List<Student>();

        public void whichStudentsWhichExercise(List<Student> students)
        {
            
            
            Console.WriteLine($"Students working on {this.Name}: ");

            foreach(Student student in students)
            {

                if(student.ExerciseList.Contains(this))
                {
                    ListOfStudents.Add(student);
                        
                }
                Console.WriteLine(student.getFullName());
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                Create 4 or more Exercises (arg1 = exercise name, arg2 = langauge, arg3 = Id)
             */

            Exercise classExercise = new Exercise("Classes and Type Definitions", "C#", 1);

            Exercise dictionaryExercise = new Exercise("Dictionaries", "C#", 2);

            Exercise apiExercise = new Exercise("Using JSON", "JavaScript", 3);

            Exercise webScrapingExercise = new Exercise("Data Scraping", "Python", 4);

            Exercise fizzbuzz = new Exercise("FizzBuzz", "JavaScript", 5);

            Exercise reactComponents = new Exercise("Components in React", "ReactJS", 6);

            Exercise natParks = new Exercise("National Parks List", "JavaScript", 7);

            /*
                Create 3 or more cohorts args = (Name, Id)
            */

            Cohort C31 = new Cohort("Cohort 31", 31);
            Cohort C33 = new Cohort("Cohort 33", 33);
            Cohort C26 = new Cohort("Cohort 36", 36);

            /*
                Create 4 or more students and assign them to one of the cohorts, add slack handle
                args = (FirstName, LastName, Id)
             */

            Student Chris = new Student("Chris", "Morgan", 1);
            Student Josh = new Student("Josh", "Hibary", 2);
            Student Brian = new Student("Brian", "Jobe", 3);
            Student Billy = new Student("Billy", "Mathison", 4);

            // slack handles

            Chris.Slack = "bluemorgan23";
            Josh.Slack = "jhibary";
            Brian.Slack = "brjobe";
            Billy.Slack = "midRowBilly";

            // adding them to cohorts

            Chris.Cohort = C31;
            Josh.Cohort = C33;
            Brian.Cohort = C26;
            Billy.Cohort = C31;

            // Create 3 instructors args = (FirstName, LastName, Specialty, Id)

            Instructor Andy = new Instructor("Andy", "Collins", "Jokes", 1);
            Instructor Kristen = new Instructor("Kristen", "Norris", "Cupcakes", 2);
            Instructor Jisie = new Instructor("Jisie", "David", "Traveling", 3);

            // Assign them to cohorts

            Andy.Cohort = C31;
            Kristen.Cohort = C26;
            Jisie.Cohort = C33;

            // Assign slack handles

            Andy.Slack = "acollins";
            Kristen.Slack = "knorris";
            Jisie.Slack = "jdavid";

            // Have each instructor assign 2 exercises to each of the students

            Andy.AssignExercise(Chris, webScrapingExercise);
            Andy.AssignExercise(Chris, apiExercise);
            Andy.AssignExercise(Billy, classExercise);
            Andy.AssignExercise(Billy, dictionaryExercise);
            Andy.AssignExercise(Josh, webScrapingExercise);
            Andy.AssignExercise(Josh, dictionaryExercise);
            Andy.AssignExercise(Brian, classExercise);
            Andy.AssignExercise(Brian, apiExercise);

            Kristen.AssignExercise(Chris, natParks);
            Kristen.AssignExercise(Chris, dictionaryExercise);
            Kristen.AssignExercise(Billy, webScrapingExercise);
            Kristen.AssignExercise(Billy, reactComponents);
            Kristen.AssignExercise(Josh, fizzbuzz);
            Kristen.AssignExercise(Josh, natParks);
            Kristen.AssignExercise(Brian, fizzbuzz);
            Kristen.AssignExercise(Brian, natParks);

            Jisie.AssignExercise(Chris, classExercise);
            Jisie.AssignExercise(Chris, reactComponents);
            Jisie.AssignExercise(Billy, fizzbuzz);
            Jisie.AssignExercise(Billy, natParks);
            Jisie.AssignExercise(Josh, classExercise);
            Jisie.AssignExercise(Josh, reactComponents);
            Jisie.AssignExercise(Brian, dictionaryExercise);
            Jisie.AssignExercise(Brian, reactComponents);

            // Create a list of students. Add all of the Student instances to it.

            List<Student> students = new List<Student>()
            {
                Chris, Josh, Billy, Brian
            };

            // Create a list of exercises. Add all of the exercise instances to it.
            
            List<Exercise> exercises = new List<Exercise>()
            {
                classExercise, dictionaryExercise, apiExercise, natParks, reactComponents, fizzbuzz, webScrapingExercise
            };

            // Generate a report that displays which students are working on which exercises.
            foreach(Student student in students)
            {
                student.GetNameAndExercises(student);
                Console.WriteLine("- - - - - - - - -");
            }

            foreach(Exercise exercise in exercises)
            {
                exercise.ListStudentsOnExercise(students);
                Console.WriteLine("- - - - - - - - -");

                // Console.WriteLine($"Students working on {exercise.Name}:");

                // foreach(Student student in exercise.ListOfStudents)
                // {
                //     Console.WriteLine(student.GetFullName());
                // }
                
                // Console.WriteLine("- - - - - - - - -");
            }

            
        }
    }
}
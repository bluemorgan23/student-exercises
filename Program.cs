using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                Create 4 or more Exercises (arg1 = exercise name, arg2 = langauge)
             */

            Exercise classExercise = new Exercise("Classes and Type Definitions", "C#");

            Exercise dictionaryExercise = new Exercise("Dictionaries", "C#");

            Exercise apiExercise = new Exercise("Using JSON", "JavaScript");

            Exercise webScrapingExercise = new Exercise("Data Scraping", "Python");

            Exercise fizzbuzz = new Exercise("FizzBuzz", "JavaScript");

            Exercise reactComponents = new Exercise("Components in React", "ReactJS");

            Exercise natParks = new Exercise("National Parks List", "JavaScript");

            Console.WriteLine($"{apiExercise.Name}, language: {apiExercise.Language}");

            /*
                Create 3 or more cohorts
            */

            Cohort C31 = new Cohort("Cohort 31");
            Cohort C33 = new Cohort("Cohort 33");
            Cohort C26 = new Cohort("Cohort 36");

            Console.WriteLine(C31.Name);

            /*
                Create 4 or more students and assign them to one of the cohorts, add slack handle
             */

            Student Chris = new Student("Chris", "Morgan");
            Student Josh = new Student("Josh", "Hibary");
            Student Brian = new Student("Brian", "Jobe");
            Student Billy = new Student("Billy", "Mathison");

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

            // Create 3 instructors

            Instructor Andy = new Instructor("Andy", "Collins", "Jokes");
            Instructor Kristen = new Instructor("Kristen", "Norris", "Cupcakes");
            Instructor Jisie = new Instructor("Jisie", "David", "Traveling");

            // Assign them to cohorts

            Andy.Cohort = C31;
            Kristen.Cohort = C26;
            Jisie.Cohort = C33;

            // Assign slack handles

            Andy.Slack = "acollins";
            Kristen.Slack = "knorris";
            Jisie.Slack = "jdavid";

            // Have each instructor assign 2 exercises to each of the students

            Andy.assignExercise(Chris, webScrapingExercise);
            Andy.assignExercise(Chris, apiExercise);
            Andy.assignExercise(Billy, classExercise);
            Andy.assignExercise(Billy, dictionaryExercise);
            Andy.assignExercise(Josh, webScrapingExercise);
            Andy.assignExercise(Josh, dictionaryExercise);
            Andy.assignExercise(Brian, classExercise);
            Andy.assignExercise(Brian, apiExercise);

            Kristen.assignExercise(Chris, natParks);
            Kristen.assignExercise(Chris, dictionaryExercise);
            Kristen.assignExercise(Billy, webScrapingExercise);
            Kristen.assignExercise(Billy, reactComponents);
            Kristen.assignExercise(Josh, fizzbuzz);
            Kristen.assignExercise(Josh, natParks);
            Kristen.assignExercise(Brian, fizzbuzz);
            Kristen.assignExercise(Brian, natParks);

            Jisie.assignExercise(Chris, classExercise);
            Jisie.assignExercise(Chris, reactComponents);
            Jisie.assignExercise(Billy, fizzbuzz);
            Jisie.assignExercise(Billy, natParks);
            Jisie.assignExercise(Josh, classExercise);
            Jisie.assignExercise(Josh, reactComponents);
            Jisie.assignExercise(Billy, dictionaryExercise);
            Jisie.assignExercise(Billy, reactComponents);

            foreach(Exercise exercise in Chris.ExerciseList)
            {
                Console.WriteLine(exercise.Name);
            }

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
        }
    }
}

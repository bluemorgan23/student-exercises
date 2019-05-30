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

            Console.WriteLine($"{apiExercise.Name}, language: {apiExercise.Language}");

            /*
                Create 3 or more cohorts
            */

            Cohort C31 = new Cohort("Cohort 31");
            Cohort C33 = new Cohort("Cohort 33");
            Cohort C26 = new Cohort("Cohort 36");

            Console.WriteLine(C31.Name);
        }
    }
}

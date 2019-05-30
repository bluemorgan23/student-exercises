using System;
using System.Collections.Generic;

namespace student_exercises
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create 4 or more Exercises (arg1 = exercise name, arg2 = langauge)
            Exercise classExercise = new Exercise("Classes and Type Definitions", "C#");

            Exercise dictionaryExercise = new Exercise("Dictionaries", "C#");

            Exercise apiExercise = new Exercise("Using JSON", "JavaScript");

            Exercise webScrapingExercise = new Exercise("Data Scraping", "Python");

            Console.WriteLine($"{apiExercise.Name}, language: {apiExercise.Language}");
        }
    }
}

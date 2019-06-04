using System;
using System.Collections.Generic;
using System.Linq;

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
            Josh.Cohort = C31;
            Brian.Cohort = C26;
            Billy.Cohort = C31;

            // Create 3 instructors args = (FirstName, LastName, Specialty, Id)

            Instructor Andy = new Instructor("Andy", "Collins", "Jokes", 1);
            Instructor Kristen = new Instructor("Kristen", "Norris", "Cupcakes", 2);
            Instructor Jisie = new Instructor("Jisie", "David", "Traveling", 3);

            // Assign them to cohorts

            Andy.Cohort = C31;
            Kristen.Cohort = C26;
            Jisie.Cohort = C31;

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

            /*
                    * * * * * * * * PART 2 * * * * * * * * *
            */

            // Create 4 new lists of students, exercises, cohorts, and instructors

            List<Student> students2 = new List<Student>() {
                Chris, Billy, Brian, Josh
            };

            List<Exercise> exercises2 = new List<Exercise>() {
                dictionaryExercise, classExercise, apiExercise, fizzbuzz, webScrapingExercise, reactComponents, natParks
            };

            List<Cohort> cohorts = new List<Cohort>() {
                C26, C31, C33
            };

            List<Instructor> instructors = new List<Instructor>() {
                Andy, Jisie, Kristen
            };

            // 1. List exercises for the JavaScript language by using the Where() LINQ method.

            IEnumerable<Exercise> listOfExercises = exercises2.Where(e => e.Language == "JavaScript");

            Console.WriteLine("List of JavaScript Exercises: ");

            foreach(Exercise e in listOfExercises)
            {
                Console.WriteLine($"{e.Name} is a {e.Language} exercise");
            }

            Console.WriteLine("- - - - - - - - -");

            // 2. List students in a particular cohort by using the Where() LINQ method.
            
            IEnumerable<Student> studentsInC31 = students2.Where(s => s.Cohort == C31);

            Console.WriteLine("Students in Cohort 31: ");

            foreach(Student s in studentsInC31)
            {
                Console.WriteLine(s.GetFullName());
            }

            Console.WriteLine("- - - - - - - - -");

            // 3. List instructors in a particular cohort by using the Where() LINQ method.

            IEnumerable<Instructor> instructorsOfC31 = instructors.Where(s => s.Cohort == C31);

            Console.WriteLine("Instructors of Cohort 31: ");

            foreach(Instructor i in instructorsOfC31)
            {
                Console.WriteLine(i.FirstName + " " + i.LastName);
            }

            Console.WriteLine("- - - - - - - - -");

            // 4. Sort students by their last name

            Console.WriteLine("Students in order by last name: ");

            IEnumerable<Student> orderedStudents = students2.OrderBy(s => s.LastName);

            foreach(Student s in orderedStudents)
            {
                Console.WriteLine(s.GetFullName());
            }

            Console.WriteLine("- - - - - - - - -");

            // 5. Display any students that aren't working on any exercises

            Student noExStudent = new Student("Sue", "Doe", 5);
            noExStudent.Slack = "suedoe55";
            noExStudent.Cohort = C33;
            students2.Add(noExStudent);

            IEnumerable<Student> whoHasNoExercises = students2.Where(s => s.ExerciseList.Count == 0);

            Console.WriteLine("List of students with no exercises: ");

            foreach(Student s in whoHasNoExercises)
            {
                Console.WriteLine(s.GetFullName());
            }

            Console.WriteLine("- - - - - - - - -");

            // 6. Which student is working on the most exercises? Make sure one of your students has more exercises than the others.

            Andy.AssignExercise(Chris, apiExercise);

            Console.WriteLine("Most Exercises: ");

            Student studentWithMost = students2.Single(s => s.ExerciseList.Count == students2.Max(student => student.ExerciseList.Count));

            Console.WriteLine(studentWithMost.GetFullName());

            Console.WriteLine("- - - - - - - - -");

            // 7. How many students in each cohort.

            Console.WriteLine("How many students in each cohort");

            cohorts.ForEach(c => Console.WriteLine($"{c.Name} has {(students2.Where(s => s.Cohort == c)).Count()}"));


        }
    }
}
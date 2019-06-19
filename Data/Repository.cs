using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using student_exercises.Models;

/// <summary>
/// Summary description for Repository
/// </summary>
namespace student_exercises.Data
{
    public class Repository
    {
        /// <summary>
        ///  Represents a connection to the database.
        ///   This is a "tunnel" to connect the application to the database.
        ///   All communication between the application and database passes through this connection.
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercisesDB;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        // Property method that queries that database for all the exercises

        public List<Exercise> GetAllExercises()
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                                           Id,
                                           ExerciseName,
                                           ExerciseLanguage
                                            FROM Exercise";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            ExerciseLanguage = reader.GetString(reader.GetOrdinal("ExerciseLanguage"))
                        };

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
            
        }

        // Query to get exercises by language

        public List<Exercise> GetExercisesByLanguage(string language)
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $@"SELECT
                                            e.Id,
                                            e.ExerciseName,
                                            e.ExerciseLanguage
                                            FROM Exercise e
                                            WHERE e.ExerciseLanguage = @language";

                    cmd.Parameters.Add(new SqlParameter("@language", language));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            ExerciseLanguage = reader.GetString(reader.GetOrdinal("ExerciseLanguage"))
                        };

                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        public void CreateExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $@"INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES (@ExerciseName, @ExerciseLanguage)";
                    cmd.Parameters.Add(new SqlParameter("@ExerciseName", exercise.ExerciseName));
                    cmd.Parameters.Add(new SqlParameter("@ExerciseLanguage", exercise.ExerciseLanguage));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Instructor> GetInstructorsWithCohort()
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                                            i.Id AS InstId,
                                            i.FirstName,
                                            i.LastName,
                                            i.CohortId,
                                            c.CohortName,
                                            c.Id AS CoId
                                            FROM Instructor i
                                            LEFT JOIN Cohort c ON c.Id = i.CohortId";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();

                    while (reader.Read())
                    {
                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("InstId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Cohort = new Cohort
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CoId")),
                                CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                            }
                        };


                        instructors.Add(instructor);
                    }

                    reader.Close();
                    return instructors;
                }
            }
        }

        public List<Cohort> GetAllCohorts()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                    
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, CohortName FROM Cohort";

                    List<Cohort> cohorts = new List<Cohort>();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Cohort cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                        };

                        cohorts.Add(cohort);

                    }

                    reader.Close();

                    return cohorts;
                }
            }
        }

        public void AddInstructorWithCohort(Instructor instructor, Cohort cohort)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Instructor (FirstName, LastName, CohortId) VALUES (@FirstName, @LastName, @CohortId)";
                    cmd.Parameters.Add(new SqlParameter("@FirstName", instructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", instructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@CohortId", cohort.Id));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Student> GetAllStudents()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, FirstName, LastName, CohortId FROM Student";

                    List<Student> students = new List<Student>();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };

                        students.Add(student);
                    }

                    reader.Close();

                    return students;
                }
            }
        }

        public void AssignExercise(Student student, Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO StudentExercise (ExerciseId, StudentId) VALUES (@ExerciseId, @StudentId)";
                    cmd.Parameters.Add(new SqlParameter("@ExerciseId", exercise.Id));
                    cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Student> StudentsCohortsAndExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                                    s.Id,
                                    s.FirstName,
                                    s.LastName,
                                    se.StudentId AS StudentId,
                                    c.Id,
                                    e.ExerciseName,
                                    e.ExerciseLanguage,
                                    c.CohortName
                                    FROM StudentExercise se
                                    JOIN Student s ON s.Id = se.StudentId
                                    JOIN Exercise e ON e.Id = se.ExerciseId
                                    LEFT JOIN Cohort c ON c.Id = s.CohortId; ";

                    List<Student> students = new List<Student>();

                    List<Exercise> exercises = new List<Exercise>();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Exercise exercise = new Exercise
                        {
                            ExerciseName = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            ExerciseLanguage = reader.GetString(reader.GetOrdinal("ExerciseLanguage"))
                        };

                        exercises.Add(exercise);

                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            ExerciseList = exercises.Where(e => reader.GetInt32(reader.GetOrdinal("StudentId")) == reader.GetInt32(reader.GetOrdinal("Id"))).ToList(),
                            Cohort = new Cohort
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                            }
                        };

                        students.Add(student);
                    }

                    reader.Close();

                    return students;
                }
            }
        }

        public List<Student> GetStudentsWithCohort()
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT
                                            s.Id AS InstId,
                                            s.FirstName,
                                            s.LastName,
                                            s.CohortId,
                                            c.CohortName,
                                            c.Id AS CoId
                                            FROM Student s
                                            LEFT JOIN Cohort c ON c.Id = s.CohortId";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();

                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("InstId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Cohort = new Cohort
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CoId")),
                                CohortName = reader.GetString(reader.GetOrdinal("CohortName"))
                            },
                        };


                        students.Add(student);
                    }

                    reader.Close();
                    return students;
                }
            }
        }

        public void AssignExerciseToCohort(Exercise exercise, Cohort cohort)
        {

            //List<Student> studentsCohorts = this.GetStudentsWithCohort().Where(s => s.CohortId == cohort.Id).ToList();

            List<Student> studentExercises = this.StudentsCohortsAndExercises().Where(s => s.Cohort.Id == cohort.Id).ToList();

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {

                    studentExercises.ForEach(student =>
                    {
                        if(student.ExerciseList.Contains(exercise) == false)
                        {
                            cmd.CommandText = $"INSERT INTO StudentExercise (StudentId, ExerciseId) VALUES (@StudentId, @ExerciseId)";
                            cmd.Parameters.Add(new SqlParameter("@StudentId", student.Id));
                            cmd.Parameters.Add(new SqlParameter("@ExerciseId", exercise.Id));
                            cmd.ExecuteNonQuery();
                        }
                         else
                        {
                            Console.WriteLine("Didn't add any");
                            cmd.ExecuteNonQuery();
                        }
                    });

                   
                }
            }
        }

    }
}


-- USE MASTER
-- GO

-- IF NOT EXISTS (
--     SELECT [name]
--     FROM sys.databases
--     WHERE [name] = N'StudentExercisesDB'
-- )

-- CREATE DATABASE StudentExercisesDB
-- GO

-- USE StudentExercisesDB
-- GO

-- Create tables from each entity in the Student Exercises ERD.


CREATE TABLE Cohort (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    CohortName VARCHAR(55)
);

CREATE TABLE Student (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName VARCHAR(55) NOT NULL,
    LastName VARCHAR(55) NOT NULL,
    Slack VARCHAR(55),
    CohortId INTEGER NOT NULL,
    CONSTRAINT FK_Student_Cohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);



CREATE TABLE Instructor (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName VARCHAR(55) NOT NULL,
    LastName VARCHAR(55) NOT NULL,
    Slack VARCHAR(55),
    Specialty VARCHAR,
    CohortId INTEGER NOT NULL,
    CONSTRAINT FK_Instructor_Cohort FOREIGN KEY (CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Exercise (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    ExerciseName VARCHAR(55),
    ExerciseLanguage VARCHAR(55)
);

CREATE TABLE StudentExercise (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    ExerciseId INTEGER NOT NULL,
    StudentId INTEGER NOT NULL,
    CONSTRAINT FK_StudentExercise_Exercise FOREIGN KEY (ExerciseId) REFERENCES Exercise (Id),
    CONSTRAINT FK_StudentExercise_Student FOREIGN KEY (StudentId) REFERENCES Student (Id)
);

-- Populate each table with data. You should have 2-3 cohorts, 5-10 students, 4-8 instructors, 2-5 exercises and each student should be assigned 1-2 exercises.

-- INSERT INTO Cohort (CohortName) VALUES ('Cohort 31');
-- INSERT INTO Cohort (CohortName) VALUES ('Cohort 30');
-- INSERT INTO Cohort (CohortName) VALUES ('Cohort 32');

SELECT * FROM Cohort;

-- INSERT INTO Student (FirstName, LastName, CohortId) VALUES ('Chris', 'Morgan', 1);
-- INSERT INTO Student (FirstName, LastName, CohortId) VALUES ('Brian', 'Jobe', 1);
-- INSERT INTO Student (FirstName, LastName, CohortId) VALUES ('Josh', 'Hibary', 2);
-- INSERT INTO Student (FirstName, LastName, CohortId) VALUES ('Alex', 'Thacker', 3);
-- INSERT INTO Student (FirstName, LastName, CohortId) VALUES ('Harry', 'Hart', 2);

SELECT * FROM Student;

-- INSERT INTO Instructor (FirstName, LastName, CohortId) VALUES ('Jisie', 'David', 1);
-- INSERT INTO Instructor (FirstName, LastName, CohortId) VALUES ('Andy', 'Collins', 2);
-- INSERT INTO Instructor (FirstName, LastName, CohortId) VALUES ('Steve', 'Brownley', 3);
-- INSERT INTO Instructor (FirstName, LastName, CohortId) VALUES ('Leah', 'H', 1);

SELECT * FROM Instructor;

-- INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Intro to SQL', 'SQL');
-- INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Dictionaries', 'C#');
-- INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Student Exercises', 'SQL');
-- INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('National Parks', 'JavaScript');


SELECT * FROM Exercise;

-- INSERT INTO StudentExercise (ExerciseId, StudentId) VALUES (1, 1);
-- INSERT INTO StudentExercise (ExerciseId, StudentId) VALUES (2, 2);
-- INSERT INTO StudentExercise (ExerciseId, StudentId) VALUES (3, 3);
-- INSERT INTO StudentExercise (ExerciseId, StudentId) VALUES (4, 4);
-- INSERT INTO StudentExercise (ExerciseId, StudentId) VALUES (2, 5);

SELECT * FROM StudentExercise;

SELECT
    s.FirstName,
    s.LastName,
    e.ExerciseName,
    e.ExerciseLanguage
    FROM StudentExercise se
    JOIN Student s ON s.Id = se.StudentId
    JOIN Exercise e ON e.Id = se.ExerciseId;



